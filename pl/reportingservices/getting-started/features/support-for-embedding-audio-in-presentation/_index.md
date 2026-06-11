---
title: Wsparcie dla osadzania dźwięku w prezentacji
type: docs
weight: 90
url: /pl/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services nie posiada wbudowanych możliwości eksportowania raportów z wbudowanym dźwiękiem do prezentacji PowerPoint. Aspose.Slides for Reporting Services w wersji 4.10 i nowszych obsługuje osadzanie dźwięku w wyeksportowanej prezentacji. 

{{% /alert %}} 

Aby osadzić dźwięk na slajdach, umieść w raporcie pole tekstowe z tekstem: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Działa w wersjach SQL Server 2008 i nowszych. Funkcja jest obsługiwana wyłącznie przy eksporcie do formatu PPTX.