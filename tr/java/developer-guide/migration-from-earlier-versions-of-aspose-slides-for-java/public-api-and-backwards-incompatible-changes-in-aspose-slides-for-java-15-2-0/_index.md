---
title: Aspose.Slides for Java 15.2.0'de Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.2.0 API'si ile tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) sınıfları, metodları, özellikleri vb., yeni sınırlamaları ve diğer [değişiklikler](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) listeler.

{{% /alert %}} {{% alert color="primary" %}} 

Bazı görüntü madde işaretleri ve WordArt nesneleriyle ilgili bilinen sorunlar vardır ve bu sorunlar Aspose.Slides for Java 15.2.0'de düzeltilecektir.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **addDataPointForDoughnutSeries metotları eklendi**
IChartDataPointCollection.addDataPointForDoughnutSeries() metodunun iki aşırı yüklemesi, Donut tipi serilere veri noktaları eklemek için eklendi.
### **com.aspose.slides.SmartArtShape sınıfı com.aspose.slides.GeometryShape sınıfından miras alındı**
com.aspose.slides.SmartArtShape sınıfı, com.aspose.slides.GeometryShape sınıfından miras almıştır. Bu değişiklik, Aspose.Slides nesne modelini iyileştirir ve SmartArtShape sınıfına yeni özellikler ekler.
### **IGradientStopCollection.add(...) ve IGradientStopCollection.insert(...) metotları değiştirildi**
IGradientStop add(float position, int presetColor) imzası, IGradientStop addPresetColor(float position, int presetColor) imzası ile değiştirildi.

IGradientStopCollection üzerindeki IGradientStop add(float position, SchemeColor schemeColor) imzası, IGradientStop addSchemeColor(float position, int schemeColor) imzası ile değiştirildi.

IGradientStopCollection metodunun void insert(int index, float position, int presetColor) imzası, void insertPresetColor(int index, float position, int presetColor) imzası ile değiştirildi.

IGradientStopCollection metodunun void insert(int index, float position, SchemeColor schemeColor) imzası, void insertSchemeColor(int index, float position, int schemeColor) imzası ile değiştirildi.
### **java.awt.Color getAutomaticSeriesColor() metodu com.aspose.slides.IChartSeries'e eklendi**
getAutomaticSeriesColor() metodu, seri indeksi ve grafik stiline göre serinin otomatik rengini döndürür. Bu renk, FillType NotDefined olduğunda varsayılan olarak kullanılır.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Endeksine göre grafik veri noktasını ve grafik kategorisini kaldırma metodu eklendi**
IChartDataPointCollection.removeAt(int index) metodu, grafik veri noktasını endeksine göre kaldırmak için eklendi.
IChartCategoryCollection.removeAt(int index) metodu, grafik kategorisini endeksine göre kaldırmak için eklendi.
### **PptXPptY değeri com.aspose.slides.PropertyType enumerasyonuna eklendi**
PptXPptY değeri, bir serileştirme sorunu düzeltmesi kapsamında com.aspose.slides.PropertyType enumerasyonuna eklendi.