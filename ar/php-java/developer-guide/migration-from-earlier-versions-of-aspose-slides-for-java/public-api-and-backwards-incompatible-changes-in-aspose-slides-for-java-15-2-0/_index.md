---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 15.2.0
type: docs
weight: 110
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [التغييرات المضافة](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) من الفئات والطرق والخصائص وما إلى ذلك، أي قيود جديدة وأي [تغييرات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) أخرى تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

هناك مشاكل معروفة مع بعض النقاط التوضيحية للصورة وأجسام WordArt، والتي سيتم إصلاحها في Aspose.Slides لـ PHP عبر Java 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة طرق addDataPointForDoughnutSeries**
تمت إضافة اثنين من التحميلات الزائدة لطريقة IChartDataPointCollection.addDataPointForDoughnutSeries() لإضافة نقاط بيانات إلى سلسلة من نوع Doughnut.
### **تم وراثة فئة com.aspose.slides.SmartArtShape من فئة com.aspose.slides.GeometryShape**
تم وراثة فئة com.aspose.slides.SmartArtShape من فئة com.aspose.slides.GeometryShape. يحسن هذا التغيير نموذج كائن Aspose.Slides ويضيف ميزات جديدة إلى فئة SmartArtShape.
### **تم تغيير طرق IGradientStopCollection.add(...) و IGradientStopCollection.insert(...)**
تم استبدال توقيع IGradientStop add(float position, int presetColor) بتوقيع IGradientStop addPresetColor(float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) بتوقيع IGradientStop addSchemeColor(float position, int schemeColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, int presetColor) بتوقيع void insertPresetColor(int index, float position, int presetColor).

تم استبدال توقيع طريقة IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) بتوقيع void insertSchemeColor(int index, float position, int schemeColor).
### **تمت إضافة طريقة java.awt.Color getAutomaticSeriesColor() إلى com.aspose.slides.IChartSeries**
ترجع طريقة getAutomaticSeriesColor() لونًا تلقائيًا للسلسلة استنادًا إلى مؤشر السلسلة ونمط الرسم البياني. يُستخدم هذا اللون بشكل افتراضي إذا كان FillType يساوي NotDefined.
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }
```
### **تمت إضافة طريقة لإزالة نقطة البيانات في الرسم البياني وفئة الرسم البياني بواسطة فهرسها**
تمت إضافة طريقة IChartDataPointCollection.removeAt(int index) لإزالة نقطة بيانات الرسم البياني بواسطة فهرسها.
تمت إضافة طريقة IChartCategoryCollection.removeAt(int index) لإزالة فئة الرسم البياني بواسطة فهرسها.
### **تمت إضافة قيمة PptXPptY إلى التعداد com.aspose.slides.PropertyType**
تمت إضافة قيمة PptXPptY إلى التعداد com.aspose.slides.PropertyType في نطاق إصلاح مشكلة التسلسل.