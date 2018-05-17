﻿/**********************************************************************
 * LoggingDisplay handles the aquiring and display of the logs
 * 
 * First created: 2016/09/22
 * 
 * Under the MIT License (MIT)
 *
 * Written by Jon Smith : GitHub JonPSmith, www.thereformedprogrammer.net
 **********************************************************************/

var LoggingDisplay = (function($) {
    'use strict';

    var logApiUrl;
    var logs = null;
    var traceIdentLocal;

    var $showLogsLink = $('#show-logs');
    var $logModal = $('#log-modal');
    var $logModalBody = $logModal.find('.modal-body');
    var $logDisplaySelect = $logModal.find('#displaySelect');

    function getDisplayType() {
        return $logDisplaySelect.find('input[name=displaySelect]:checked').val();
    }

    function updateLogsCountDisplay() {
        var allCount = logs.requestLogs.length;
        $('.modal-title span').text(allCount);
        $('#all-select span').text(allCount);
        var sqlCount = 0;
        for (var i = 0; i < logs.requestLogs.length; i++) {
            if (logs.requestLogs[i].isDb) {
                sqlCount++;
            }
        }
        $('#sql-select span').text(sqlCount);
    }

    function showModal() {
        updateLogsCountDisplay();
        $logModal.modal();
    }

    function setContextualColors(eventType) {
        switch (eventType) {
            case 'Information':
                return 'text-info';
            case 'Warning':
                return 'text-warning';
            case 'Error':
                return 'text-danger';
            case 'Critical':
                return 'text-danger bold';
            default:
                return '';
        }
    }

    function fillModalBody() {
        var displayType = getDisplayType();
        var body = '<div class="panel-group" id="log-accordian" role="tablist" aria-multiselectable="true">';
        for (var i = 0; i < logs.requestLogs.length; i++) {
            if (displayType !== 'sql' || logs.requestLogs[i].isDb)
            body +=     
'<div class="panel panel-default">'+
   '<div class ="panel-heading" role="tab" id="heading'+i+'">'+
      '<h4 class ="panel-title text-overflow-dots">'+
        '<a role="button" data-toggle="collapse" data-parent="#log-accordion" href="#collapse' + i + '" aria-expanded="true" aria-controls="collapse' + i + '">' +
          '<span class="' + setContextualColors(logs.requestLogs[i].logLevel) + '">' + logs.requestLogs[i].logLevel + ':&nbsp;</span>'+
            logs.requestLogs[i].eventString + 
        '</a>'+
      '</h4>'+
    '</div>'+
    '<div id="collapse'+i+'" class ="panel-collapse collapse" role="tabpanel" aria-labelledby="heading'+i+'">'+
            '<div class ="panel-body white-space-pre">' + logs.requestLogs[i].eventString+''+
       '</div>'+
  '</div>'+
'</div>';
        }
        body += '</div>';
        $logModalBody.html(body);
    }

    function getLogs(traceIdentifier) {
        $.ajax({
            url: logApiUrl,
            data: { traceIdentifier: traceIdentifier }
        })
        .done(function (data) {
            logs = data;
            fillModalBody();
            showModal();
        })
        .fail(function () {
            alert("error");
        });
    }

    function startModal() {
        getLogs(traceIdentLocal);
    }

    function setupTrace(traceIdentifier, numLogs) {
        //now set up the log menu link
        traceIdentLocal = traceIdentifier;
        $showLogsLink.find('.badge').text(numLogs + '+');
    }

    //public parts
    return {
        initialise: function(exLogApiUrl, traceIdentifier, numLogs) {
            logApiUrl = exLogApiUrl;

            setupTrace(traceIdentifier, numLogs);

            //setup the events
            $showLogsLink.unbind('click')
                .bind('click',
                    function() {
                        startModal();
                    });
            $showLogsLink.removeClass('hidden');
            $logDisplaySelect.unbind('change')
                .bind('change',
                    function() {
                        fillModalBody();
                    });
        },

        newTrace: function(traceIdentifier, numLogs) {
            setupTrace(traceIdentifier, numLogs);
        }
    };
}(window.jQuery));