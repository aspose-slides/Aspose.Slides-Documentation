---
title: Ondersteuning voor het insluiten van video in een presentatie
type: docs
weight: 80
url: /nl/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services heeft geen ingebouwde mogelijkheden om rapporten met ingebedde video naar PowerPoint-presentaties te exporteren. Aspose.Slides for Reporting Services 4.10 en latere versies ondersteunen het insluiten van video in presentaties. 

{{% /alert %}} 

Om video in dia's in te voegen, plaats u in het rapport een tekstvak met de tekst: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Het werkt voor SQL Server-versie 2008 en hoger. De functionaliteit wordt alleen ondersteund voor PPTX-export.