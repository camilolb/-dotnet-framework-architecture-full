(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("SumaCubosController", function ($scope, SumaCubosService) {


        $scope.obtenerSuma = function ()
        {
            if (parseInt($scope.sumaX) > -1
                && parseInt($scope.sumaZ) > -1)
            {
                var resultado = SumaCubosService.obtenerSuma($scope.sumaX, $scope.sumaY, $scope.sumaZ);
                resultado.then(success, error);

                function success(e) {

                    var resultado = angular.fromJson(e.data);

                    if (resultado
                        && resultado != null) {
                        $scope.totalSuma = resultado;
                    }
                }

                function error(e) {
                    alert("Error al consumir el api");
                }
            } else {

                alert("Todos los campos son requeridos");
            }



        };


        $scope.consulta = function ()
        {
            var resultado = SumaCubosService.consulta($scope.X1, $scope.Y1, $scope.Z1, $scope.X2, $scope.Y2, $scope.Z2);
            resultado.then(success, error);

            function success(e) {

                var resultado = angular.fromJson(e.data);

                if (resultado != null)
                {
                    $scope.totalConsulta = parseInt(resultado);
                }
            }

            function error(e) {
                alert("Error al consumir el api");
            }
        };


        $scope.actualizar = function () {
            var resultado = SumaCubosService.actualizar($scope.dimension);
            resultado.then(success, error);

            function success(e) {

                var resultado = e.data;

                console.log("RESULTADO");
                console.log(resultado);


            }

            function error(e) {
                alert("Error al consumir el api");
            }
        };

    });

    app.service("SumaCubosService", function ($http, $q) {

        this.obtenerSuma = function (x,y,z) {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('./api/Value?x='+x+'&y='+y+'&z='+z+'', config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);
            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);
            };

            return response.promise;
        }

        this.actualizar = function (dimension) {

            var response = $q.defer();

            var config = {};

            dimension = 1;

            $http.get('./api/Value?dimension=' + dimension, config).then(successCallback, errorCallback);
            //$http.post('./api/SumaCubos?x=' + x + '&y=' + y + '&z=' + z + '&value=' + valor, data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);

            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);

            };

            return response.promise;
        };
            
        this.consulta = function (x1, y1, z1, x2, y2, z2) {

            var response = $q.defer();
            var config = {};

            $http.get('./api/Value?x1=' + x1 + '&y1=' + y1 + '&z1=' + z1 + '&x2=' + x2 + '&y2=' + y2 + '&z2=' + z2, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);

            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);

            };

            return response.promise;
        };


    });

})();