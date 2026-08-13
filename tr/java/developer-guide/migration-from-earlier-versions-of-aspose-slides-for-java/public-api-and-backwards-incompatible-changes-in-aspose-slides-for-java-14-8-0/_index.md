---
title: Aspose.Slides for Java 14.8.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 14.8.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) sınıfları, metotları, özellikleri ve benzeri, yeni kısıtlamaları ve diğer [değişiklikler](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() ve setOverlap(byte) Metodları Eklendi**
Aspose.Slides.Charts.IChartSeries.getOverlap() metodu, çubuk ve sütunların 2D grafiklerde ne kadar üst üste gelmesi gerektiğini (-100 ile 100 arasında) elde eder. Bu metod yalnızca belirli bir seriye değil, üst seriler grubundaki tüm serilere uygulanır – bu, ilgili grup özelliğinin yansıtılmasıdır.

- Üst seriler grubuna erişmek için IChartSeries.getParentSeriesGroup() metodunu kullanın.
- Değeri yönetmek için IChartSeriesGroup.getOverlap() ve setOverlap(byte) metodlarını kullanın.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **ShapeThumbnailBounds.Appearance Enum Değeri Eklendi**
Bu şekil küçük resimleri oluşturma yöntemi, geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim üretmesine izin verir. Tüm şekil efektlerini göz önünde bulundurur. Oluşturulan şekil küçük resmi slayt sınırlarıyla kısıtlanır.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject Sınıfı ve IVbaProject Arayüzü Eklendi, Presentation.getVbaProject() ve setVbaProject(VbaProject) Metodları Değiştirildi**
Yeni bir özellik, geliştiricilerin bir sunum içinde VBA projeleri oluşturmasına ve düzenlemesine olanak tanır.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Yeni VBA Projesi Oluştur

pres.setVbaProject(new VbaProject());

// VBA projesine boş modül ekle

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Modül kaynak kodunu ayarla

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// <stdole> referansı oluştur

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office referansı oluştur

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA projesine referansları ekle

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```