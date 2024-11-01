---
title: Anpassen der Beschriftung der PowerPoint-Rendering-Erweiterung
type: docs
weight: 60
url: /de/reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

Dieser Artikel zeigt Ihnen, wie Sie die Beschriftungen der Rendering-Optionen von Aspose.Slides für Reporting Services anpassen können. 

{{% /alert %}} 
## **Beispiel**
Bei der Installation von Aspose.Slides für Reporting Services werden im Dropdown-Menü der Exportoptionen 4 zusätzliche Exportoptionen hinzugefügt:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **So ändern Sie den Beschriftungstext**
Die Standardbeschriftungen dieser Erweiterungen können durch das Überschreiben der Standardnamen geändert werden. Diese Schritte zeigen Ihnen, wie Sie die Beschriftung von “ **PPT – PowerPoint** **Präsentation über** **Aspose.Slides** ” auf “ **PowerPoint 97 – 2003 Format(PPT)** ” ändern. 

**Schritt 1:** Suchen Sie die Datei **rsreportserver.config**, die sich normalerweise in diesem Verzeichnis befindet: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Schritt 2:** Finden Sie diese Zeilen in der rsreportserver.config-Datei: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Schritt 3:** Ersetzen Sie den Erweiterungsparameter mit diesem: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="de-DE">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Die Exportoptionen werden nun wie folgt angezeigt: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)