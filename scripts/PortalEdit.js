'use strict';
define(
    function () {

        return {
            init: function (wrapper, util, params, callback) {
                //console.log("init");

                require(
                    [

                        "https://ajax.googleapis.com/ajax/libs/angularjs/1.7.2/angular.min.js",
                        "https://stackpath.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"
                    ],
                    function () {
                        //console.log("angular loaded");
                        require([
                            "/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/plugins/angular-toastr/angular-toastr.tpls.min.js",
                            "/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/plugins/angular-ui-switch/angular-ui-switch.min.js",
                            "/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/app/app.js",

                        ], function () {
                            //console.log("angular dependant scripts loaded");
                            require([
                                "/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/app/services/friendly-url.js",
                                "/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/app/controllers/portal-edit.js"
                            ], function () {
                                //console.log('services and controllers loaded last');

                                // manually bootstrap the angular app
                                angular.element(function () {
                                    angular.bootstrap(document.getElementById('X3AdvancedUrlManagementPersonaBarPortal'), ['X3AdvancedUrlManagement']);
                                });
                            })
                        })
                    }
                );
            },

            initMobile: function (wrapper, util, params, callback) {
                //console.log("init mobile");
            },

            load: function (params, callback) {
                //console.log("load");
            },

            loadMobile: function (params, callback) {
                //console.log("load mobile");
            }
        };
    }
);


