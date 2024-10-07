---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.2.0
type: docs
weight: 110
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [المضافات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) من الفئات والطرق والخصائص وغيرها، وأي قيود جديدة وأخرى [التغييرات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) المقدمة مع واجهة برمجة تطبيقات Aspose.Slides لـ Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

هناك مشاكل معروفة مع بعض العناوين النقطية للصورة وأجسام WordArt والتي سيتم إصلاحها في Aspose.Slides لـ Java 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة طرق addDataPointForDoughnutSeries**
تمت إضافة نسختين من طريقة IChartDataPointCollection.addDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلسلة من نوع Doughnut.
### **تم وراثة فئة com.aspose.slides.SmartArtShape من فئة com.aspose.slides.GeometryShape**
تم وراثة فئة com.aspose.slides.SmartArtShape من فئة com.aspose.slides.GeometryShape. يحسن هذا التغيير نموذج كائن Aspose.Slides ويضيف ميزات جديدة إلى فئة SmartArtShape.
### **تم تغيير طرق IGradientStopCollection.add(...) وIGradientStopCollection.insert(...)**
تم استبدال توقيع IGradientStop add(float position, int presetColor) بتوقيع IGradientStop addPresetColor(float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) بتوقيع IGradientStop addSchemeColor(float position, int schemeColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, int presetColor) بتوقيع void insertPresetColor(int index, float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) بتوقيع void insertSchemeColor(int index, float position, int schemeColor).
### **تمت إضافة طريقة java.awt.Color getAutomaticSeriesColor() إلى com.aspose.slides.IChartSeries**
ترجع طريقة getAutomaticSeriesColor() لونًا تلقائيًا للسلسلة بناءً على فهرس السلسلة ونمط الرسم البياني. يتم استخدام هذا اللون بشكل افتراضي إذا كان FillType يساوي NotDefined.
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **تمت إضافة طريقة لإزالة نقطة بيانات الرسم البياني وفئة الرسم البياني حسب فهرسها**
تمت إضافة طريقة IChartDataPointCollection.removeAt(int index) لإزالة نقطة بيانات الرسم البياني حسب فهرسها.
تمت إضافة طريقة IChartCategoryCollection.removeAt(int index) لإزالة فئة الرسم البياني حسب فهرسها.
### **تمت إضافة قيمة PptXPptY إلى تعداد com.aspose.slides.PropertyType**
تمت إضافة قيمة PptXPptY إلى تعداد com.aspose.slides.PropertyType في نطاق إصلاح مشكلة التسلسل.