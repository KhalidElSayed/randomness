<script language="javascript" type="text/javascript">
    Array.prototype.contains = function ( needle ) {
        for (i in this) {
            if (this[i] == needle) return true;
        }
        return false;
    }

    function lcg(m,seed,a,c){
        var data = Array();
        var _number = ((a * seed) + c )% m;
        while (!data.contains(_number)) {
            data.push(_number);
            _number = (a * _number + c )% m;
        }
        var distribution = [];
        for (var i = 0; i < data.length; i++) {
            distribution.push(data[i]/m);
        }
        return distribution;
    }
</script>