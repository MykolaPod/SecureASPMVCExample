
AutoLogOutApp.Controllers.SessionHandler = function() {
    this.logOutFormIdSelector = '#logoutForm';
    this.isSessionExpiredInputIdSelector = '#isSessionExpired';
    this.sessionTimeout = AutoLogOutApp.Resources.SessionTimeout;
    this.sessionTimer;

    this._init();
};

AutoLogOutApp.Controllers.SessionHandler.prototype._init = function() {
    var self = this;

    self._setTimer();
}


AutoLogOutApp.Controllers.SessionHandler.prototype._setTimer = function() {
    var self = this;
    if (self.sessionTimer) {
        clearTimeout(self.sessionTimer);
    }
    self.sessionTimer = setTimeout(function(event) { return self._sessionExpiredEventHandler(self, event); }, self.sessionTimeout * 60 * 1000);
};

AutoLogOutApp.Controllers.SessionHandler.prototype._sessionExpiredEventHandler = function(controller, event) {
    var self = controller;
    $(self.isSessionExpiredInputIdSelector).val(true);
    $(self.logOutFormIdSelector).submit();
};


$(document).ready(function () {

    AutoLogOutApp.Controllers.currentControllers.push( new AutoLogOutApp.Controllers.SessionHandler());

});