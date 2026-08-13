---
title: Aspose.Slides for Java 14.10.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 14.10.0 API'si ile tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) sınıfları, yöntemleri, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
### **com.aspose.slides.FieldType.getFooter() yöntemi eklendi**
getFooter() yöntemi altbilgi alan türünü döndürür. Bu yöntem, bu türde alanlar oluşturma olanağını sağlamak ve geçerli sunum serileştirmesi için eklenmiştir.
### **Element com.aspose.slides.ShapeElementFillSource.Own silindi**
ShapeElementFillSource.Own öğesi yinelenmiş olduğu için silinmiştir. ShapeElementFillSource.Own yerine ShapeElementFillSource.Shape kullanın.
### **Grafik veri noktaları ve kategorileri kaldırma yöntemleri eklendi**
**Aşağıdaki yöntemler, bir grafik veri nokta koleksiyonundan grafik veri noktasını kaldırmayı sağlar ve eklenmiştir:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Aşağıdaki yöntem, bir grafik kategorisini içeren koleksiyondan kaldırmayı sağlar ve eklenmiştir:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ChartCategory.remove() ile kaldır

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ChartCategoryCollection.remove() ile kaldır

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ChartDataPoint.remove() ile kaldır

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Obsolete Aspose.Slides.ParagraphFormat yöntemleri kaldırıldı**
getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() ve karşılık gelen set yöntemleri kaldırılmıştır. Uzun süredir obsolete olarak işaretlenmişlerdi.
### **Kullanışsız ve obsolete yapıcılar kaldırıldı**
Aşağıdaki yapıcılar kaldırılmıştır:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)