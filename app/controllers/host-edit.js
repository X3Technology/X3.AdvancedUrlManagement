app.controller('hostEditController', ['$parse', '$scope', '$q', 'toastr', 'friendlyUrlService', function ($parse, $scope, $q, toastr, friendlyUrlService) {

    $scope.host_settings = null;

    $scope.get = function () {
        friendlyUrlService.getHostSettings().then(
            function (response) {
                $scope.host_settings = response.data;

            },
            function (response) {
                $scope.host_settings = null;
                console.log('get host settings failed', response);
                toastr.error('There was a problem getting the host settings.', 'Failure!');
            }
        );
    }

    $scope.save = function () {
        friendlyUrlService.saveHostSettings($scope.host_settings).then(
            function (response) {
                console.log('host settings saved');
                toastr.success('Host URL Management Settings Saved!', 'Success!');
            },
            function (response) {
                console.log('save host settings failed', response);
                toastr.error('There was a problem saving the host settings.', 'Failure!');
            }
        );
    }

    $scope.clear = function () {
        friendlyUrlService.clearHostSettings().then(
            function (response) {
                console.log('host settings cleard');
                toastr.success('Host URL Management Settings Cleared!', 'Success!');
            },
            function (response) {
                console.log('clear host settings failed', response);
                toastr.error('There was a problem clearing the host settings.', 'Failure!');
            }
        );
    }

    $scope.init = function () {
        var promises = [];

        promises.push($scope.get());

        return $q.all(promises);
    };

    $scope.init();

}]);
