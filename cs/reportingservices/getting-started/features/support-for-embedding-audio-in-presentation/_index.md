---
title: Podpora vkládání zvuku do prezentace
type: docs
weight: 90
url: /cs/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services nemá vestavěné možnosti exportovat zprávy s vloženým zvukem do prezentací PowerPoint. Aspose.Slides for Reporting Services verze 4.10 a novější podporují vložení zvuku do exportované prezentace. 

{{% /alert %}} 

Pro vložení zvuku do snímků umístěte do sestavy textové pole s textem: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Funguje pro verzi SQL Server 2008 a novější. Tato funkce je podporována pouze pro export do formátu PPTX.