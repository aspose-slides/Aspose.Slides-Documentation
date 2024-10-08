---  
title: Unterstützung für das Einbetten von Videos in Präsentationen  
type: docs  
weight: 80  
url: /de/reportingservices/support-for-embedding-video-in-presentation/  
---  

{{% alert color="primary" %}}  

Microsoft SQL Server Reporting Services verfügt nicht über integrierte Möglichkeiten, Berichte mit eingebetteten Videos in PowerPoint-Präsentationen zu exportieren. Aspose.Slides für Reporting Services Version 4.10 und höher unterstützt das Einbetten von Videos in Präsentationen.  

{{% /alert %}}  

Um Videos in Folien einzubetten, fügen Sie dem Bericht ein Textfeld mit folgendem Text hinzu:  

``` xml  

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>  

```  

Es funktioniert für SQL Server Version 2008 und höher. Die Funktion wird nur für den PPTX-Export unterstützt.  