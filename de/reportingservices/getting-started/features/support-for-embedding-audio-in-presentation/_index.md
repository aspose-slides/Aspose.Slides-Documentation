---
title: Unterstützung für das Einbetten von Audio in Präsentationen
type: docs
weight: 90
url: /de/reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services verfügt nicht über integrierte Funktionen zum Exportieren von Berichten mit eingebettetem Audio in PowerPoint-Präsentationen. Aspose.Slides für Reporting Services Version 4.10 und höher unterstützen das Einbetten von Audio in exportierte Präsentationen. 

{{% /alert %}} 

Um Audio in Folien einzubetten, fügen Sie dem Bericht ein Textfeld mit folgendem Text hinzu: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Es funktioniert für SQL Server Version 2008 und höher. Die Funktion wird nur für den PPTX-Export unterstützt.