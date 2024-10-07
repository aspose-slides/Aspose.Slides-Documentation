---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للأجيال السابقة في Aspose.Slides لجافا 15.2.0
type: docs
weight: 110
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضاف](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) الفئات والطرق والخصائص وما إلى ذلك، وأي قيود جديدة وتغييرات أخرى [مقدمة](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) مع واجهة برمجة التطبيقات Aspose.Slides لجافا 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

توجد مشاكل معروفة مع بعض النقاط النقطية للصورة وأجسام WordArt والتي سيتم إصلاحها في Aspose.Slides لجافا 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تم إضافة طرق addDataPointForDoughnutSeries**
تمت إضافة نسختين من طريقة IChartDataPointCollection.addDataPointForDoughnutSeries() لإضافة النقاط البيانية إلى سلسلتي من نوع Doughnut.
### **تم وراثة فئة com.aspose.slides.SmartArtShape من فئة com.aspose.slides.GeometryShape**
تم وراثة فئة com.aspose.slides.SmartArtShape من فئة com.aspose.slides.GeometryShape. تحسن هذه التغيير نموذج كائنات Aspose.Slides ويضيف ميزات جديدة إلى فئة SmartArtShape.
### **تم تغيير طرق IGradientStopCollection.add(...) و IGradientStopCollection.insert(...)**
تم استبدال توقيع IGradientStop add(float position, int presetColor) بتوقيع IGradientStop addPresetColor(float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) بتوقيع IGradientStop addSchemeColor(float position, int schemeColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, int presetColor) بتوقيع void insertPresetColor(int index, float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) بتوقيع void insertSchemeColor(int index, float position, int schemeColor).
### **تمت إضافة طريقة java.awt.Color getAutomaticSeriesColor() إلى com.aspose.slides.IChartSeries**
ترجع طريقة getAutomaticSeriesColor() لوناً تلقائياً للسلسلة بناءً على فهرس السلسلة وأسلوب الرسم البياني. يتم استخدام هذا اللون بشكل افتراضي إذا كانت FillType تساوي NotDefined.
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **تمت إضافة طريقة لإزالة نقطة بيانات الرسم البياني وفئة الرسم البياني بواسطة فهرسها**
تمت إضافة طريقة IChartDataPointCollection.removeAt(int index) لإزالة نقطة بيانات الرسم البياني بواسطة فهرسها.
تمت إضافة طريقة IChartCategoryCollection.removeAt(int index) لإزالة فئة الرسم البياني بواسطة فهرسها.
### **تمت إضافة قيمة PptXPptY إلى تعداد com.aspose.slides.PropertyType**
تمت إضافة قيمة PptXPptY إلى تعداد com.aspose.slides.PropertyType في نطاق إصلاح مشكلة التسلسل.