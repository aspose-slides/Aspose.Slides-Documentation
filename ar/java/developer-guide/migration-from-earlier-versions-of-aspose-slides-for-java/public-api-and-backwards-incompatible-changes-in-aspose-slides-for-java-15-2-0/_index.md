---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- ترحيل
- شفرة قديمة
- شفرة حديثة
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for Java للانتقال بسلاسة حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 
هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك، بالإضافة إلى أي قيود جديدة و[التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) التي تم إدخالها مع Aspose.Slides for Java 15.2.0 API.
{{% /alert %}} {{% alert color="info" %}} 
هناك مشكلات معروفة مع بعض نقاط الصورة وكائنات WordArt والتي سيتم إصلاحها في Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **تغييرات API العامة**
### **تمت إضافة طرق addDataPointForDoughnutSeries**
تمت إضافة طريقتين متجاوزتين IChartDataPointCollection.addDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلاسل من نوع Doughnut.
### **تم توريث الفئة com.aspose.slides.SmartArtShape من الفئة com.aspose.slides.GeometryShape**
تم توريث الفئة com.aspose.slides.SmartArtShape من الفئة com.aspose.slides.GeometryShape. يحسن هذا التغيير نموذج كائنات Aspose.Slides ويضيف ميزات جديدة إلى الفئة SmartArtShape.
### **تم تغيير طرق IGradientStopCollection.add(...) و IGradientStopCollection.insert(...)**
تم استبدال توقيع IGradientStop add(float position, int presetColor) بالتوقيع IGradientStop addPresetColor(float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) بالتوقيع IGradientStop addSchemeColor(float position, int schemeColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, int presetColor) بالتوقيع void insertPresetColor(int index, float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) بالتوقيع void insertSchemeColor(int index, float position, int schemeColor).
### **تمت إضافة طريقة java.awt.Color getAutomaticSeriesColor() إلى com.aspose.slides.IChartSeries**
طريقة getAutomaticSeriesColor() تُعيد لونًا تلقائيًا للسلسلة بناءً على فهرس السلسلة ونمط المخطط. يُستخدم هذا اللون افتراضيًا إذا كان FillType يساوي NotDefined.
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **تمت إضافة طريقة لإزالة نقطة بيانات المخطط وفئة المخطط حسب الفهرس**
تمت إضافة طريقة IChartDataPointCollection.removeAt(int index) لإزالة نقطة بيانات المخطط حسب الفهرس.
تمت إضافة طريقة IChartCategoryCollection.removeAt(int index) لإزالة فئة المخطط حسب الفهرس.
### **تمت إضافة القيمة PptXPptY إلى تعداد com.aspose.slides.PropertyType**
تمت إضافة القيمة PptXPptY إلى تعداد com.aspose.slides.PropertyType في إطار إصلاح مشكلة التسلسل.