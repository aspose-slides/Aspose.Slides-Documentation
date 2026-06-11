---
title: Stöd för att bädda in ljud i presentation
type: docs
weight: 90
url: /sv/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services har inte inbyggda funktioner för att exportera rapporter med inbäddat ljud till PowerPoint-presentationer. Aspose.Slides for Reporting Services 4.10 och senare versioner stödjer inbäddning av ljud i den exporterade presentationen. 

{{% /alert %}} 

För att bädda in ljud i bildspel, placera i rapporten en textruta med följande text: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Det fungerar för SQL Server version 2008 och senare. Funktionen stöds endast för PPTX-export.