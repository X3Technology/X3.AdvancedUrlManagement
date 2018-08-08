var app = angular.module('X3AdvancedUrlManagement', ['ngAnimate', 'ui.bootstrap', 'toastr', 'uiSwitch'], function ($locationProvider) {

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});

app.config(function ($httpProvider) {
    $httpProvider.defaults.withCredentials = true;
});


app.directive('uibDatepickerPopup', function (dateFilter, uibDateParser, uibDatepickerPopupConfig) {
    return {
        restrict: 'A',
        priority: 1,
        require: 'ngModel',
        link: function (scope, element, attr, ngModel) {
            var dateFormat = attr.uibDatepickerPopup || uibDatepickerPopupConfig.datepickerPopup;
            ngModel.$validators.date = function (modelValue, viewValue) {
                var value = viewValue || modelValue;

                if (!attr.ngRequired && !value) {
                    return true;
                }

                if (angular.isNumber(value)) {
                    value = new Date(value);
                }
                if (!value) {
                    return true;
                } else if (angular.isDate(value) && !isNaN(value)) {
                    return true;
                } else if (angular.isString(value)) {
                    var date = uibDateParser.parse(value, dateFormat);
                    return !isNaN(date);
                } else {
                    return false;
                }
            };
        }
    };
});
