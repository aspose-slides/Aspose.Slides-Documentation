---
title: Aanpassen van het bijschrift van de PowerPoint-renderingextensie
type: docs
weight: 60
url: /nl/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Dit artikel laat zien hoe u de bijschriften van de weergave‑opties van Aspose.Slides for Reporting Services kunt aanpassen. 

{{% /alert %}} 
## **Voorbeeld**
Bij het installeren van Aspose.Slides for Reporting Services worden er vier extra exportopties toegevoegd aan het keuzemenu van de exportopties:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Hoe u de bijschriften wijzigt**
De standaardbijschriften van deze extensies kunnen worden gewijzigd door de standaardnamen te overschrijven. Deze stappen laten zien hoe u het bijschrift wijzigt van “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” naar “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Stap 1:** Zoek het bestand **rsreportserver.config** dat zich meestal in deze map bevindt: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Stap** **2:** Zoek de volgende regels in het bestand rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Stap** **3:** Vervang de extensieparameter door het volgende: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

De exportopties worden nu als volgt weergegeven: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)