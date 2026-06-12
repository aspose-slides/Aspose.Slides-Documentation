---
title: Přizpůsobení popisku rozšíření pro vykreslování PowerPoint
type: docs
weight: 60
url: /cs/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Tento článek vám ukazuje, jak přizpůsobit popisky možností vykreslování Aspose.Slides pro Reporting Services. 

{{% /alert %}} 
## **Příklad**
Při instalaci Aspose.Slides pro Reporting Services jsou do rozbalovací nabídky možností exportu přidány 4 další exportní možnosti:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Jak upravit text popisků**
Výchozí popisky těchto rozšíření lze změnit přepsáním výchozích názvů. Tyto kroky vám ukážou, jak změnit popisek z “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” na “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Krok 1:** Najděte soubor **rsreportserver.config**, který se obvykle nachází v tomto adresáři: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Krok** **2:** Najděte tyto řádky v souboru rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Krok** **3:** Nahraďte parametr rozšíření tímto: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Možnosti exportu se nyní zobrazí takto: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)