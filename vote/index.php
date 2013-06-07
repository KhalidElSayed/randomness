<?php require_once('Connections/conn_vote.php'); ?>
<?php
if (!function_exists("GetSQLValueString")) {
function GetSQLValueString($theValue, $theType, $theDefinedValue = "", $theNotDefinedValue = "") 
{
  $theValue = get_magic_quotes_gpc() ? stripslashes($theValue) : $theValue;

  $theValue = function_exists("mysql_real_escape_string") ? mysql_real_escape_string($theValue) : mysql_escape_string($theValue);

  switch ($theType) {
    case "text":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;    
    case "long":
    case "int":
      $theValue = ($theValue != "") ? intval($theValue) : "NULL";
      break;
    case "double":
      $theValue = ($theValue != "") ? "'" . doubleval($theValue) . "'" : "NULL";
      break;
    case "date":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;
    case "defined":
      $theValue = ($theValue != "") ? $theDefinedValue : $theNotDefinedValue;
      break;
  }
  return $theValue;
}
}

$editFormAction = $_SERVER['PHP_SELF'];
if (isset($_SERVER['QUERY_STRING'])) {
  $editFormAction .= "?" . htmlentities($_SERVER['QUERY_STRING']);
}

if ((isset($_POST["MM_insert"])) && ($_POST["MM_insert"] == "form1")) {
  $insertSQL = sprintf("INSERT INTO poll (id, question) VALUES (%s, %s)",
                       GetSQLValueString($_POST['id'], "int"),
                       GetSQLValueString($_POST['Poll'], "text"));

  mysql_select_db($database_conn_vote, $conn_vote);
  $Result1 = mysql_query($insertSQL, $conn_vote) or die(mysql_error());

  $insertGoTo = "results.php";
  if (isset($_SERVER['QUERY_STRING'])) {
    $insertGoTo .= (strpos($insertGoTo, '?')) ? "&" : "?";
    $insertGoTo .= $_SERVER['QUERY_STRING'];
  }
  header(sprintf("Location: %s", $insertGoTo));
}

$colname_rs_vote = "-1";
if (isset($_GET['recordID'])) {
  $colname_rs_vote = $_GET['recordID'];
}
mysql_select_db($database_conn_vote, $conn_vote);
$query_rs_vote = sprintf("SELECT * FROM poll WHERE id = %s", GetSQLValueString($colname_rs_vote, "int"));
$rs_vote = mysql_query($query_rs_vote, $conn_vote) or die(mysql_error());
$row_rs_vote = mysql_fetch_assoc($rs_vote);
$totalRows_rs_vote = mysql_num_rows($rs_vote);
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Poll</title>
<link href="style.css" rel="stylesheet" type="text/css" />
<link href="../web/css/fonts.css" rel="stylesheet">
<link href="../web/css/font-styles.css" rel="stylesheet">
<link href="../web/css/bootstrap.css" rel="stylesheet">
</head>

<body>

<fieldset dir="rtl">

	<legend class="persian-legend">یک عدد به تصادف از اعداد زیر انتخاب نمایید</legend>
	
	<form action="<?php echo $editFormAction; ?>" id="form1" name="form1" method="POST">
    
    <label dir="rtl" class="persian-text">
    	<input type="radio" name="Poll" value="One" id="Poll_0" />
     	یک
     </label>
     
    <label dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Two" id="Poll_1" />
      	دو
    </label>
    
    <label dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Three" id="Poll_2" />
		سه
	 </label>
    <label  dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Four" id="Poll_3" />
        چهار
	</label>

    <label  dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Five" id="Poll_4" />
		پنج
	</label>

	<label  dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Six" id="Poll_5" />
		شش
	</label>
	<label  dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Seven" id="Poll_6" />
		هفت
	</label>
    <label  dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Eight" id="Poll_7" />
		هشت
	</label>
	<label  dir="rtl" class="persian-text vote-items">
    	<input type="radio" name="Poll" value="Nine" id="Poll_8" />
		نه
	</label>
    
    <input type="submit" name="submit" id="submit" value="ثبت نظر"/>
    <btn herf="results.php">مشاهده نتایج</btn>
    
	<input type="hidden" name="id" value="form1" />
	
	<input type="hidden" name="MM_insert" value="form1" />
</form>
</fieldset>
</body>
</html>

<?php
mysql_free_result($rs_vote);
?>
