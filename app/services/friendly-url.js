app.factory('friendlyUrlService', ['$http', '$q', function friendlyUrlService($http, $q) {

    var base_path = "/api/x3.advancedurlmanagement/friendlyurl/";

    // interface
    var service = {
        getHostSettings: getHostSettings,
        saveHostSettings: saveHostSettings,
        clearHostSettings: clearHostSettings,
        getPortalSettings: getPortalSettings,
        savePortalSettings: savePortalSettings,
        clearPortalSettings: clearPortalSettings        
    };
    return service;


    // get host settings
    function getHostSettings() {
        var request = $http({
            method: "get",
            url: base_path + "getHostSettings"
        });
        return request;
    }

    // save host settings
    function saveHostSettings(data) {
        var request = $http({
            method: "post",
            url: base_path + "saveHostSettings",
            data: data
        });
        return request;
    }

    // clear host settings
    function clearHostSettings() {
        var request = $http({
            method: "get",
            url: base_path + "clearHostSettings"
        });
        return request;
    }


    // get portal settings
    function getPortalSettings() {
        var request = $http({
            method: "get",
            url: base_path + "getPortalSettings"
        });
        return request;
    }

    // save portal settings
    function savePortalSettings(data) {
        var request = $http({
            method: "post",
            url: base_path + "savePortalSettings",
            data: data
        });
        return request;
    }

    // clear portal settings
    function clearPortalSettings() {
        var request = $http({
            method: "get",
            url: base_path + "clearPortalSettings"
        });
        return request;
    }
    
}]);
