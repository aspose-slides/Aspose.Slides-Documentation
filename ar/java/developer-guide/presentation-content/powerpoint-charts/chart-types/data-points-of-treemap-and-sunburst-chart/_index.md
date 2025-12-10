---
title: "تخصيص نقاط البيانات في مخططي Treemap و Sunburst باستخدام Java"
linktitle: "نقاط البيانات في مخططي Treemap و Sunburst"
type: docs
url: /ar/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط treemap
- مخطط sunburst
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- عرض تقديمي
- جافا
- Aspose.Slides
description: "تعلم كيفية إدارة نقاط البيانات في مخططي Treemap و Sunburst باستخدام Aspose.Slides لجافا، المتوافق مع صيغ PowerPoint."
---

من بين الأنواع الأخرى لمخططات PowerPoint، هناك نوعان "هرميان" - **Treemap** و **Sunburst** (المعروفة أيضًا باسم مخطط Sunburst أو رسم Sunburst أو مخطط قطبي أو رسم قطبي أو مخطط فطيرة متعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل لاحق بالفئة المقابلة. يسمح Aspose.Slides for Java بتنسيق نقاط البيانات لمخططي Sunburst وTreemap في Java.

فيما يلي مخطط Sunburst، حيث تُعرّف البيانات في عمود **Series1** عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

دعونا نبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء مخطط Sunburst**](/slides/ar/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط البيانات في المخطط، ينبغي علينا استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)، 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) الفئات و 
[**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) الطريقة توفر إمكانية الوصول لتنسيق نقاط البيانات لمخططي Treemap وSunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) يُستخدم للوصول إلى الفئات متعددة المستويات - وهو يمثل حاوية كائنات [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel). أساسًا هو غلاف للـ [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) مع الخصائص المضافة الخاصة بنقاط البيانات. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) يحتوي على طريقتين: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) و [**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) التي توفر الوصول إلى الإعدادات المقابلة.

## **إظهار قيمة نقطة البيانات**
إظهار قيمة نقطة البيانات "Leaf 4":
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
تعيين تسمية البيانات "Branch 1" لإظهار اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم تعيين لون النص إلى الأصفر:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيير لون فرع "Steam 4":
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **الأسئلة الشائعة**

**هل يمكنني تغيير ترتيب (فرز) القطاعات في مخططي Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً بالقيم المتناقصة وبالاتجاه الساعي للساعة). Aspose.Slides يطابق هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ بل تقوم بذلك عن طريق معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**

ترث ألوان المخطط [السمة/لوحة الألوان](/slides/ar/java/presentation-theme/) ما لم تقم بتعيين التعبئات/الخطوط صراحةً. للحصول على نتائج متسقة، احرص على تثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، يتم حفظ إعدادات المخطط (التعبئة، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بتص rendering المخطط مع تطبيق تنسيقه.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لوضع طبقة مخصصة فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تتوفر قيم *x* و*y* الفعلية للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/))، مما يساعد في تحديد مواضع الطبقات بدقة.