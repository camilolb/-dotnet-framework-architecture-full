(function () {

    var app = angular.module('pruebaTecnica', ["ngRoute", 'angularNotify']);

    app.config(function ($routeProvider, $httpProvider) {

        $routeProvider
            .when("/Index", {
                templateUrl: "./Index.html"
                , controller: "LayoutController"
                , allowAnonymous: true
            })

            // Crear un documento
            .when("/SumaCubos/Crear", {
                templateUrl: "./Paginas/SumaCubos/Index.html"
                , controller: "SumaCubosController"
            })

            .otherwise({
                redirectTo: "/"
            });

        $httpProvider.interceptors.push('AccessTokenHttpInterceptor');
    });

})();