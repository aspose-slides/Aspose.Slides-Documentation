---
title: Videó beágyazásának támogatása a prezentációban
type: docs
weight: 80
url: /hu/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

A Microsoft SQL Server Reporting Services nem rendelkezik beépített képességgel a beágyazott videót tartalmazó jelentések PowerPoint‑prezentációba történő exportálásához. Az Aspose.Slides for Reporting Services 4.10‑es és annál újabb verziói támogatják a videó beágyazását a prezentációba. 

{{% /alert %}} 

A videó diákba való beágyazásához helyezzen a jelentésbe egy szövegdobozt a következő szöveggel: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

2008‑as és újabb SQL Server verziók esetén működik. Ez a funkció csak PPTX export esetén támogatott.