---
title: Stöd för inbäddning av video i presentation
type: docs
weight: 80
url: /sv/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 
Microsoft SQL Server Reporting Services har inga inbyggda funktioner för att exportera rapporter med inbäddad video till PowerPoint-presentationer. Aspose.Slides för Reporting Services 4.10 och senare versioner stödjer inbäddning av video i presentationen. 
{{% /alert %}} 
För att bädda in video i bildspel, lägg till en textruta med text i rapporten: 
``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```
Det fungerar för SQL Server version 2008 och senare. Funktionen stöds endast för PPTX-export.