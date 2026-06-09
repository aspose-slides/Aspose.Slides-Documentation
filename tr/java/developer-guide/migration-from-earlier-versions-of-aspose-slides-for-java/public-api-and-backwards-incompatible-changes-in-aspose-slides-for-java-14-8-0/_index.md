---
title: Aspose.Slides for Java 14.8.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 14.8.0 API'si ile tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) sınıfları, metodları, özellikleri vb. ve yeni kısıtlamaları ile diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() ve setOverlap(byte) Yöntemleri Eklendi**
Aspose.Slides.Charts.IChartSeries.getOverlap() 2D grafiklerde çubukların ve sütunların ne kadar üst üste gelmesi gerektiğini (‑100 ile 100 arasında) alır.  
Bu yöntem yalnızca belirli bir seri için değil, üst seri grubundaki tüm seriler için geçerlidir – bu, ilgili grup özelliğinin bir yansımasıdır.

- IChartSeries.getParentSeriesGroup() yöntemini kullanarak üst seri grubuna erişin.  
- Değeri yönetmek için IChartSeriesGroup.getOverlap() ve setOverlap(byte) yöntemlerini kullanın.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **ShapeThumbnailBounds.Appearance Enum Değeri Eklendi**
Bu şekil miniati oluşturma yöntemi, geliştiricilerin bir şeklin miniatiyi görünüm sınırları içinde üretmesine olanak tanır. Tüm şekil efektleri dikkate alınır. Oluşturulan şekil miniati slayt sınırlarıyla kısıtlanır.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject Sınıfı ve IVbaProject Arayüzü Eklendi, Presentation.getVbaProject() ve setVbaProject(VbaProject) Yöntemleri Değiştirildi**
Yeni bir özellik, geliştiricilerin bir sunum içinde VBA projeleri oluşturup düzenlemesine olanak tanır.

``` java

 Presentation pres = new Presentation();

// Yeni VBA Projesi Oluştur

pres.setVbaProject(new VbaProject());

// VBA projesine boş modül ekle

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Modül kaynak kodunu ayarla

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// <stdole>'ye referans oluştur

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office'e referans oluştur

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA projesine referansları ekle

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```