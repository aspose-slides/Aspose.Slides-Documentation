---
title: PowerPoint megjelenítési kiterjesztés feliratának testreszabása
type: docs
weight: 60
url: /hu/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Ez a cikk bemutatja, hogyan testreszabhatja az Aspose.Slides for Reporting Services megjelenítési beállítások feliratait. 

{{% /alert %}} 
## **Example**
Az Aspose.Slides for Reporting Services telepítésekor a kiexportálási beállítások legördülő menüjéhez 4 további exportálási lehetőség kerül hozzáadásra:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **A feliratok szövegének módosítása**
Ezen kiterjesztések alapértelmezett feliratai felülírásával módosíthatók. Ezek a lépések megmutatják, hogyan változtatható meg a felirat a “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” formátumról “ **PowerPoint 97 – 2003 format(PPT)** ” formátumra. 

**1. lépés:** Keresse meg a **rsreportserver.config** fájlt, amely általában ebben a könyvtárban található: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**2. lépés:** Keresse meg ezeket a sorokat a rsreportserver.config fájlban: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**3. lépés:** Cserélje le a kiterjesztés paraméterét ezzel: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Az exportálási lehetőségek mostantól így fognak megjelenni: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)