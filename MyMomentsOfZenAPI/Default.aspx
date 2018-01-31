<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyMomentsOfZenAPI.Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>

        function incplaycount(form) 
        {
            
            var clipid = document.getElementById("ipc_clipid").value;
            var userid = document.getElementById("ipc_userid").value;

            var uri = "api/VideoClips/" + clipid + "/IncPlayCount/" + userid;
            form.action = uri;
            alert(uri);
            form.submit();           
        }

        function favorclip(form) {

            var clipid = document.getElementById("fc_clipid").value;
            var userid = document.getElementById("fc_userid").value;

            var uri = "api/Users/" + userid + "/FavorClip/" + clipid;
            form.action = uri;
            alert(uri);
            form.submit();
        }
        function unfavorclip(form) {

            var clipid = document.getElementById("ufc_clipid").value;
            var userid = document.getElementById("ufc_userid").value;

            var uri = "api/Users/" + userid + "/UnFavorClip/" + clipid;
            form.action = uri;
            alert(uri);
            form.submit();
        }
        function GetAll(form) {

            var uri = "api/VideoClips";
            form.action = uri;
            alert(uri);
           form.submit();
        }

        function Search(form) {

            var crit = document.getElementById("criteria").value;
            var uri = "api/VideoClips/search/" + crit;
            form.action = uri;
            alert(uri);
            form.submit();
        }

        function GetSingle(form) {

            var clipid = document.getElementById("getsingle_id").value;
            
            var uri = "api/VideoClips/" + clipid ;
            form.action = uri;
            alert(uri);
            form.submit();
        }
        

    </script>
</head>
<body>
    <p>
    User being used:  User id =3 UserName = Deanna
    </p>
    <form method="get" action="wtf" onsubmit="GetAll(this)">
       
                <input type="submit" value="Get All Clips List" />

    </form>
    <br />
    <form method="get" action="wtf" onsubmit="GetSingle(this)">
                <input type="text" id="getsingle_id" />
                <input type="submit" value="Get Single Clip" />
    </form>
    <br />
    <form method="get" action="wtf" onsubmit="Search(this)">
                <input type="text" id="criteria" />
                <input type="submit" value="Search Clip" />
    </form>
    <br />
        <form method="Post" action="wtf" onsubmit="incplaycount(this)">
            Increment Play Count<br />
            Clip id:<input id="ipc_clipid" type="text" name="clipid" />
            User id:<input id="ipc_userid" type="text" name="userid" />
            <input type="submit" />
        </form>
    <hr />
        <br />
        <form method="Post" action="wtf" onsubmit="favorclip(this)">
            Favor Clip<br />
            Clip id:<input id="fc_clipid" type="text" name="clipid" />
            User id:<input id="fc_userid" type="text" name="userid" />
            <input type="submit" />
        </form>
    <br />
        <form method="Post" action="wtf" onsubmit="unfavorclip(this)">
            UNFavor Clip<br />
            Clip id:<input id="ufc_clipid" type="text" name="clipid" />
            User id:<input id="ufc_userid" type="text" name="userid" />
            <input type="submit" />
        </form>
            
</body>
</html>
