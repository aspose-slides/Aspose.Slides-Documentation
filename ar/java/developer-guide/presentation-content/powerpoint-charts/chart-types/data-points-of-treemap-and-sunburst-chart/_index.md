---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام Java
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
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
- Java
- Aspose.Slides
description: "تعرف على كيفية إدارة نقاط البيانات في مخططات treemap و sunburst باستخدام Aspose.Slides for Java، المتوافق مع تنسيقات PowerPoint."
---

من بين أنواع مخططات PowerPoint الأخرى، هناك نوعان "هرميان" - **Treemap** و **Sunburst** (المعروفة أيضًا بمخطط Sunburst، رسم بياني Sunburst، مخطط شعاعي، رسم بياني شعاعي أو مخطط فطيرة متعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى قمة الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل بالفئة المقابلة. يتيح Aspose.Slides for Java تنسيق نقاط بيانات مخطط Sunburst و Treemap في Java.

فيما يلي مخطط Sunburst، حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
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

إذا كان هناك حاجة لتنسيق نقاط بيانات المخطط، يجب استخدام ما يلي:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)،
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) فئات
و[**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) طريقة
توفر وصولًا لتنسيق نقاط بيانات مخططي Treemap و Sunburst.
يُستخدم [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)
للوصول إلى الفئات متعددة المستويات – فهو يمثل حاوية
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) مع
الخصائص المضافة الخاصة بنقاط البيانات.
في الأساس هو مغلف لـ
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) مع
الخصائص المضافة الخاصة بنقاط البيانات.
تحتوي فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) على
طريقتين: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) و
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) اللتين
توفران وصولًا إلى الإعدادات المقابلة.

## **إظهار قيمة نقطة البيانات**
إظهار قيمة نقطة البيانات "Leaf 4":
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
اجعل تسمية البيانات لـ "Branch 1" تُظهر اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم عيّن لون النص إلى الأصفر:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيّر لون فرع "Steam 4":
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

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (الفرز) الأقسام في مخطط Sunburst/Treemap؟**
لا. يقوم PowerPoint بفرز الأقسام تلقائيًا (عادةً بترتيب تنازلي للقيم، باتجاه عقارب الساعة). ينسخ Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرةً؛ بل تحقق ذلك بمعالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان الأقسام والتسميات؟**
وراثة ألوان المخطط سمة العرض التقديمي [theme/palette](/slides/ar/java/presentation-theme/) ما لم تقم بتحديد التعبئة/الخطوط صراحةً. للحصول على نتائج متسقة، احرص على تثبيت التعبئة الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**
نعم. عند تصدير العرض التقديمي، يتم الحفاظ على إعدادات المخطط (التعبئة، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بالعرض مع تطبيق تنسيق المخطط.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لإجراء تراكب مخصص فوق المخطط؟**
نعم. بعد التحقق من تخطيط المخطط، تتوفر قيم *x* و*y* الفعلية للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/))، مما يساعد في تحديد موضع التراكبات بدقة.