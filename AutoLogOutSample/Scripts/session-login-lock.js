
AutoLogOutApp.Controllers.SessionLoginLock = function () {
    this.locationHash = "login";
    this.pageShowEvent = "pageshow";
    this._init();
};

AutoLogOutApp.Controllers.SessionLoginLock.prototype._init = function () {
    var self = this;

    self._subscribe();
    self._changeHash();
}


AutoLogOutApp.Controllers.SessionLoginLock.prototype._subscribe = function () {
    var self = this;
  
    $(window).bind(self.pageShowEvent, function (event) {
        self._pageShowEventHandler(self, event);
    });
    
};

AutoLogOutApp.Controllers.SessionLoginLock.prototype._pageShowEventHandler = function (controller, event) {
    var self = controller;
    if (event.originalEvent.persisted) {
        window.location.reload();
    }
};


AutoLogOutApp.Controllers.SessionLoginLock.prototype._changeHash = function() {
    var self = this;
    window.location.hash = self.locationHash;
}


$(document).ready(function () {

    AutoLogOutApp.Controllers.currentControllers.push(new AutoLogOutApp.Controllers.SessionLoginLock());

});