---
title: Hang beágyazása a prezentációban
type: docs
weight: 90
url: /hu/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

A Microsoft SQL Server Reporting Services nem rendelkezik beépített képességekkel a beágyazott audióval rendelkező jelentések PowerPoint-prezentációkká exportálásához. Az Aspose.Slides for Reporting Services 4.10-es és újabb verziói támogatják az audió beágyazását az exportált prezentációba. 

{{% /alert %}} 

Az audió diákba való beágyazásához kérjük, helyezzen a jelentésbe egy szövegmezőt a következő szöveggel: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Ez a 2008-as és újabb SQL Server verziók esetén működik. Ez a funkció csak PPTX export esetén támogatott.