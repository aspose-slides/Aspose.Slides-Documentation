---
title: نقاط البيانات لمخطط Treemap و Sunburst
type: docs
url: /ar/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "رسوم Sunburst في Aspose.Slides لـ Node.js عبر Java"
description: "رسوم Sunburst، مخطط Sunburst، مخطط شجري، مخطط دائري، رسم دائري أو مخطط فطيرة متعدد المستويات باستخدام Aspose.Slides لـ Node.js عبر Java."
---

بالإضافة إلى أنواع أخرى من مخططات PowerPoint، هناك نوعان "هرميان" - **Treemap** و**Sunburst** (المعروف أيضًا باسم Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى أعلى الفرع. يتم تعريف الأوراق بنقاط بيانات السلسلة، ويُحدد كل مستوى تجميع متداخل لاحقًا بالفئة المقابلة. يتيح Aspose.Slides for Node.js عبر Java تنسيق نقاط البيانات لمخططي Sunburst وTreemap باستخدام JavaScript.

فيما يلي مخطط Sunburst، حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء مخطط Sunburst**](/slides/ar/nodejs-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط البيانات في المخطط، يجب استخدام ما يلي:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) classes 
and [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
is used for accessing multi-level categories - it represents the container of 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) objects.
Basically it is a wrapper for 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) with
the properties added specific for data points. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) class has
two methods: [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) and 
[**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) which
provide access to corresponding settings.

## **إظهار قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية نقطة البيانات واللون**
قم بتعيين تسمية بيانات "Branch 1" لتعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم اضبط لون النص إلى الأصفر:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيير لون فرع "Steam 4":
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **الأسئلة الشائعة**

**هل يمكنني تغيير ترتيب (الفرز) القطاعات في مخطط Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً حسب القيم المتناقصة، باتجاه عقارب الساعة). تقوم Aspose.Slides بمحاكاة هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ بل يمكنك تحقيق ذلك من خلال معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**

تورث ألوان المخطط سمة العرض التقديمي [theme/palette](/slides/ar/nodejs-java/presentation-theme/) ما لم تقم بتعيين التعبئات/الخطوط صراحةً. للحصول على نتائج متسقة، احرص على تثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ تصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، يتم الاحتفاظ بإعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides تقوم بإجراء عرض المخطط مع تطبيق التنسيق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر من أجل وضع تغطية مخصصة فوق المخطط؟**

نعم. بعد التحقق من صحة تخطيط المخطط، تكون قيم X و Y الفعلية متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/))، مما يساعد في وضع التغطيات بدقة.