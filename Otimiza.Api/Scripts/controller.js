var myapp = angular.module('myapp', []);
myapp.controller('VeiculoController', function ($scope, $http) {
    $http.get('http://localhost:51396/api/Veiculo').success(function (response) {
        $scope.result = response;
    });
    $scope.DeletaVeiculo = function (id) {
        $http.delete('http://localhost:51396/api/Veiculo/' + id).success(function (response) {
            $http.get('http://localhost:51396/api/Veiculo').success(function (response) {
                $scope.result = response;
            });
        })

    };
    $scope.EditVeiculo = function (id) {
        window.location.href = "/Home/Edit/" + id;
    };
    $scope.InfoVeiculo = function (id) {
        window.location.href = "/Home/Info/" + id;
    };
    $scope.NewVeiculo = function () {
        window.location.href = "/Home/New";
    };
});

myapp.controller('EditController', function ($scope, $http) {
    var url_atual = window.location.href;
    var id = url_atual.split("/")[5];
    $http.get('http://localhost:51396/api/Veiculo/' + id).success(function (response) {
        $scope.edit = response;
        $http.get('http://localhost:51396/api/TipoVeiculo').success(function (response) {
            $scope.result = response;
        });
        $http.get('http://localhost:51396/api/TipoVeiculo/' + $scope.edit.tipoVeiculoId).success(function (response) {
            $scope.tipoVeiculo = response;
        });
    });

    $scope.Voltar = function () {
        window.location.href = "/Home";
    }

    $scope.Editar = function () {
        console.log($scope.edit.placa);
        console.log($scope.edit.tipoVeiculo.id);
        console.log($scope.edit.proprietario);
        if ($scope.edit.placa != "") {
            var request = $http({
                method: "put",
                url: "http://localhost:51396/api/Veiculo/" + $scope.edit.id,
                data: {
                    id: $scope.edit.id,
                    placa: $scope.edit.placa,
                    tipoVeiculoId: $scope.edit.tipoVeiculo.id,
                    proprietario: $scope.edit.proprietario
                },
                headers: { 'Content-Type': 'application/json;charset=utf8' }
            });
            request.success(function (data) {
                $('#myModal').modal('show');
            });
        }
    };
});
myapp.controller('InfoController', function ($scope, $http) {
    var url_atual = window.location.href;
    var id = url_atual.split("/")[5];
    $http.get('http://localhost:51396/api/Veiculo/' + id).success(function (response) {
        $scope.info = response;
        $http.get('http://localhost:51396/api/TipoVeiculo/' + $scope.info.tipoVeiculoId).success(function (response) {
            $scope.tipoVeiculo = response;
        });
    });
});

myapp.controller('NewController', function ($scope, $http) {
    $http.get('http://localhost:51396/api/TipoVeiculo').success(function (response) {
        $scope.result = response;
    });

    $scope.Voltar = function () {
        window.location.href = "/Home";
    }

    $scope.Veiculo = function () {
        console.log($scope.veiculo.placa);
        console.log($scope.veiculo.tipoVeiculo.id);
        console.log($scope.veiculo.proprietario);
        if ($scope.veiculo.placa != "") {
            var request = $http({
                method: "post",
                url: "http://localhost:51396/api/Veiculo",
                data: {
                    placa: $scope.veiculo.placa,
                    tipoVeiculoId: $scope.veiculo.tipoVeiculo.id,
                    proprietario: $scope.veiculo.proprietario
                },
                headers: { 'Content-Type': 'application/json;charset=utf8' }
            });
            request.success(function (data) {
                $('#myModal').modal('show');
                $scope.veiculo.placa = "";
                $scope.veiculo.proprietario = "";
            });
        }
    };
});
