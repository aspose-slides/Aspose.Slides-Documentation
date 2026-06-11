---
title: Obsługa osadzania wideo w prezentacji
type: docs
weight: 80
url: /pl/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services nie posiada wbudowanych możliwości eksportowania raportów z osadzonym wideo do prezentacji PowerPoint. Aspose.Slides for Reporting Services w wersji 4.10 i nowszych obsługuje osadzanie wideo w prezentacji. 

{{% /alert %}} 

Aby osadzić wideo w slajdach, umieść w raporcie pole tekstowe z tekstem: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Działa w wersji SQL Server 2008 i nowszych. Funkcja jest obsługiwana wyłącznie przy eksporcie do formatu PPTX.