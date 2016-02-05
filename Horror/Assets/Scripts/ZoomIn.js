#pragma strict
var zoom : int =20;
var smooth : float =5;



function Update () {
GetComponent.<Camera>().fieldOfView = Mathf.Lerp(GetComponent.<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);


}