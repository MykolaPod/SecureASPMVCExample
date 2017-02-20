
AutoLogOutApp.Controllers.SessionPing = function() {

    this.pingActionUrl = AutoLogOutApp.Resources.PingActionUrl;
    this.pingActionInterval = AutoLogOutApp.Resources.PingActionInterval;
    this._init();
};

AutoLogOutApp.Controllers.SessionPing.prototype._init = function () {
    var self = this;
    self._subscribe();
    self._setTimer();
};


AutoLogOutApp.Controllers.SessionPing.prototype._pingRequest = function (isClosingWindow) {
    var self = this;
    $.ajax({
        url: self.pingActionUrl,
        type: "POST",
        data: { "isClosing": isClosingWindow }
    });
};

AutoLogOutApp.Controllers.SessionPing.prototype._subscribe = function () {
    var self = this;

    window.onbeforeunload = function() {
        self._pingRequest(false);
        return;
    }
};

AutoLogOutApp.Controllers.SessionPing.prototype._setTimer = function () {
    var self = this;
    setInterval(function () { self._pingRequest(true); }, parseFloat(self.pingActionInterval));
};

$(document).ready(function () {

    AutoLogOutApp.Controllers.currentControllers.push(new AutoLogOutApp.Controllers.SessionPing());

});