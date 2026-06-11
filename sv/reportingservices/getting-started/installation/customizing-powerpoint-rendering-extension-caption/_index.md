---
title: Anpassa bildtexter för PowerPoint-renderingtillägg
type: docs
weight: 60
url: /sv/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Denna artikel visar hur du anpassar bildtexterna för renderingsalternativen i Aspose.Slides for Reporting Services. 

{{% /alert %}} 
## **Exempel**
När du installerar Aspose.Slides for Reporting Services läggs 4 ytterligare exportalternativ till i rullgardinsmenyn för exportalternativ:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Hur du ändrar bildtextens text**
Standardbildtexterna för dessa tillägg kan ändras genom att åsidosätta standardnamnen. Stegen nedan visar hur du ändrar bildtexten från “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” till “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Steg 1:** Hitta filen **rsreportserver.config** som vanligtvis finns i följande katalog: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Steg** **2:** Leta upp dessa rader i rsreportserver.config‑filen: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Steg** **3:** Ersätt extensionsparametern med följande: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Exportalternativen kommer nu att visas så här: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)