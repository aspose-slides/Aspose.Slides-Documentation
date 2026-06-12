---
title: Podpora vkládání videa do prezentace
type: docs
weight: 80
url: /cs/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 
Microsoft SQL Server Reporting Services nemá vestavěné možnosti exportu zpráv s vloženým videem do prezentací PowerPoint. Aspose.Slides pro Reporting Services verze 4.10 a novější podporují vkládání videa do prezentace. 
{{% /alert %}} 
Pro vložení videa do snímků vložte do sestavy textové pole s textem: 
``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Funguje pro verzi SQL Server 2008 a novější. Funkce je podporována pouze při exportu do PPTX.