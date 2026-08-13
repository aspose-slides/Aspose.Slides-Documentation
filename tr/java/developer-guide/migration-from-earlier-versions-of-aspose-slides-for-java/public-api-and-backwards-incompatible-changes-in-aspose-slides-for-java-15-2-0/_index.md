---
title: Aspose.Slides for Java 15.2.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 15.2.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) sınıfları, yöntemleri, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) listeler.

{{% /alert %}} {{% alert color="info" %}} 

Bazı görüntü madde işaretleri ve WordArt nesneleriyle ilgili bilinen sorunlar vardır ve bu sorunlar Aspose.Slides for Java 15.2.0'da düzeltilecektir.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **addDataPointForDoughnutSeries yöntemleri eklendi**
IChartDataPointCollection.addDataPointForDoughnutSeries() metodunun iki aşırı yüklemesi, Donut tipi serilerine veri noktaları eklemek için eklendi.
### **com.aspose.slides.SmartArtShape sınıfı com.aspose.slides.GeometryShape sınıfından miras alındı**
com.aspose.slides.SmartArtShape sınıfı, com.aspose.slides.GeometryShape sınıfından miras alındı. Bu değişiklik Aspose.Slides nesne modelini geliştirir ve SmartArtShape sınıfına yeni özellikler ekler.
### **IGradientStopCollection.add(...) ve IGradientStopCollection.insert(...) yöntemleri değiştirildi**
IGradientStop add(float position, int presetColor) imzası, IGradientStop addPresetColor(float position, int presetColor) imzasıyla değiştirildi.

IGradientStopCollection metodunun IGradientStop add(float position, SchemeColor schemeColor) imzası, IGradientStop addSchemeColor(float position, int schemeColor) imzasıyla değiştirildi.

IGradientStopCollection metodunun void insert(int index, float position, int presetColor) imzası, void insertPresetColor(int index, float position, int presetColor) imzasıyla değiştirildi.

IGradientStopCollection metodunun void insert(int index, float position, SchemeColor schemeColor) imzası, void insertSchemeColor(int index, float position, int schemeColor) imzasıyla değiştirildi.
### **java.awt.Color getAutomaticSeriesColor() yöntemi com.aspose.slides.IChartSeries'e eklendi**
getAutomaticSeriesColor() yöntemi, seri dizini ve grafik stiline göre serinin otomatik rengini döndürür. Bu renk, FillType NotDefined olduğunda varsayılan olarak kullanılır.
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **İndeksine göre grafik veri noktasını ve grafik kategorisini kaldırma yöntemi eklendi**
IChartDataPointCollection.removeAt(int index) yöntemi, indeksine göre grafik veri noktasını kaldırmak için eklendi.
IChartCategoryCollection.removeAt(int index) yöntemi, indeksine göre grafik kategorisini kaldırmak için eklendi.
### **PptXPptY değeri com.aspose.slides.PropertyType enumarasyonuna eklendi**
PptXPptY değeri, bir serileştirme sorunu düzeltmesi kapsamında com.aspose.slides.PropertyType enumarasyonuna eklendi.