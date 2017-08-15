var myapp = angular.module('myapp', []);
myapp.directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);

        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        })
    }
    return {
        link: fn_link
    }

}])
myapp.controller('fupController', function ($scope, $http) {
    var formdata = new FormData();

    $scope.getTheFiles = function ($files) {
        $scope.imagesrc = [];

        for (var i = 0; i < $files.length; i++) {
            var reader = new FileReader();
            reader.fileName = $files[i].name;

            reader.onload = function (event) {
                var image = {};
                image.Name = event.target.fileName;
                image.Size = (event.total / 1024).toFixed(2);
                image.Src = event.target.result;
                $scope.imagesrc.push(image);
                $scope.$apply();
            }

            reader.readAsDataURL($files[i]);
        }

        angular.forEach($files, function (value, key) {
            formdata.append(key, value);
        })
    }

    $scope.uploadFiles = function () {
        var url_atual = window.location.href;
        var id = url_atual.split("/")[5];
        var request = {
            method: 'PUT',
            url: '/api/FileUpload/'+ id,
            data: formdata,
            headers: {
                'Content-Type': undefined
            }
        };
        $http(request).success(function (d) {
            $('#myModal').modal('show');
            $scope.reset();
        }).error(function () {
            $('#myModal2').modal('show');
            $scope.reset();
        })
    }

    $scope.reset = function () {
        angular.forEach(
            angular.element("input [type = 'file']"),
            function (inputElem) {
                angular.element(inputElem).val(null);
            }
        );
        $scope.imagesrc = [];
        formdata = new FormData();
    }
})
myapp.controller('VeiculoController', function ($scope, $http) {
    $http.get('http://localhost:51396/api/Veiculo').success(function (response) {
        $scope.result = response;
    });
    $scope.DeletaVeiculo = function (id) {
        $scope.id = id;
        $('#myModal').modal('show');
    };
    $scope.ExcluirVeiculo = function (id) {
        $http.delete('http://localhost:51396/api/Veiculo/' + id).success(function (response) {
            $http.get('http://localhost:51396/api/Veiculo').success(function (response) {
                $scope.result = response;
                $('#myModal').modal('hide');
            });
        })
    }
    $scope.EditVeiculo = function (id) {
        window.location.href = "/Home/Edit/" + id;
    };
    $scope.InfoVeiculo = function (id) {
        window.location.href = "/Home/Info/" + id;
    };
    $scope.AddFotos = function (id) {
        window.location.href = "/Home/Gallery/" + id;
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
        $http.get('http://localhost:51396/api/Imagens/' + id).success(function (response) {
            $scope.imagens = response;
            $scope.fotos = false;
            if ($scope.imagens.length > 0){
                $scope.fotos = true;
            }
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
