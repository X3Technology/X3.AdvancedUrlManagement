app.controller('portalEditController', ['$parse', '$scope', '$q', 'toastr', 'friendlyUrlService', function ($parse, $scope, $q, toastr, friendlyUrlService) {

    $scope.portal_settings = null;
    
    $scope.get = function () {
        friendlyUrlService.getPortalSettings().then(
            function (response) {
                $scope.portal_settings = response.data;
            },
            function (response) {
                $scope.portal_settings = null;
                console.log('get portal settings failed', response);
                toastr.error('There was a problem getting the portal settings.', 'Failure!');
            }
        );
    }

    $scope.save = function () {
        friendlyUrlService.savePortalSettings($scope.portal_settings).then(
            function (response) {
                console.log('portal settings saved');
                toastr.success('Portal URL Management Settings Saved!', 'Success!');
            },
            function (response) {
                console.log('save portal settings failed', response);
                toastr.error('There was a problem saving the portal settings.', 'Failure!');
            }
        );
    }

    $scope.clear = function () {
        friendlyUrlService.clearPortalSettings().then(
            function (response) {
                console.log('Portal settings cleared');
                toastr.success('Portal URL Management Settings Cleared!', 'Success!');
            },
            function (response) {
                console.log('clear portal settings failed', response);
                toastr.error('There was a problem clearing the portal settings.', 'Failure!');
            }
        );
    }
    
    $scope.collapseAll = function () {
        $scope.$broadcast('angular-ui-tree:collapse-all');
    };

    $scope.expandAll = function () {
        $scope.$broadcast('angular-ui-tree:expand-all');
    };

    $scope.viewUrls = function (page) {
        console.log('view', page);
    };


    $scope.init = function () {
        var promises = [];

        promises.push($scope.get());

        return $q.all(promises);
    };

    $scope.init();

}]);
