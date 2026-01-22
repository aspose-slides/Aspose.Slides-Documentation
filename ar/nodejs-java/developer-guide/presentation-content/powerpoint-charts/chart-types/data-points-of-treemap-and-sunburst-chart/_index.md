---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام JavaScript
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط treemap
- مخطط sunburst
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرّف على كيفية إدارة نقاط البيانات في مخططات treemap و sunburst باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java، مع توافق مع صيغ PowerPoint."
---

إلى جانب أنواع أخرى من مخططات PowerPoint ، هناك نوعان "هرميان" - مخطط **Treemap** ومخطط **Sunburst** (المعروف أيضًا باسم Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة ، ويُحدَّد كل مستوى تجميع متداخل لاحق بالفئة المقابلة. يتيح Aspose.Slides لـ Node.js عبر Java تنسيق نقاط بيانات مخطط Sunburst و Treemap في JavaScript.

هنا مخطط Sunburst ، حيث تحدد البيانات في عمود Series1 عقد الأوراق ، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

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
- [**إنشاء أو تحديث مخططات عرض PowerPoint في JavaScript**](/slides/ar/nodejs-java/create-chart/)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط بيانات المخطط ، يجب استخدام ما يلي:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager)، [ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) الفئات و[**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) الطريقة توفر إمكانية الوصول إلى تنسيق نقاط بيانات مخططات Treemap و Sunburst. يستخدم [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) للوصول إلى الفئات متعددة المستويات - فهو يمثل الحاوية لـ [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) الكائنات. أساساً هو غلاف لـ [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) مع الخصائص المضافة المحددة لنقاط البيانات. تحتوي فئة [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) على طريقتين: [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) و[**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) اللتين توفران إمكانية الوصول إلى الإعدادات المقابلة.

## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
عيّن تسمية بيانات "Branch 1" لإظهار اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم عيّن لون النص إلى الأصفر:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
غيّر لون الفرع "Steam 4":
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

**هل يمكنني تغيير ترتيب (فرز) القطاعات في مخطط Sunburst/Treemap؟**
لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً حسب القيم تنازليًا، باتجاه عقارب الساعة). يطابق Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ بل يتم ذلك عبر التحضير المسبق للبيانات.

**كيف يؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**
وراثة ألوان المخطط لسمة العرض التقديمي [theme/palette](/slides/ar/nodejs-java/presentation-theme/) ما لم تقم بتعيين التعبئة أو الخطوط صراحةً. للحصول على نتائج متسقة، قم بتثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**
نعم. عند تصدير العرض التقديمي، تُحافظ إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يُظهر المخطط بتطبيق التنسيق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لتحديد موضع تغطية مخصصة فوق المخطط؟**
نعم. بعد التحقق من تخطيط المخطط، تتوفر قيم X وY الفعلية للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/))، مما يساعد على تحديد موضع الدُسُور بدقة.