---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst على Android
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط treemap
- مخطط sunburst
- نقطة بيانات
- لون التسميات
- لون الفروع
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة نقاط البيانات في مخططات treemap و sunburst باستخدام Aspose.Slides للـ Android عبر Java، والمتوافق مع صيغ PowerPoint."
---

من بين الأنواع الأخرى لمخططات PowerPoint، هناك نوعان "هرميان" - مخطط **Treemap** ومخطط **Sunburst** (المعروف أيضًا باسم مخطط Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). تُظهر هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى قمة الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل لاحقًا بالفئة المقابلة. يتيح Aspose.Slides for Android عبر Java تنسيق نقاط بيانات مخطط Sunburst وTreemap في Java.

إليك مخطط Sunburst، حيث تحدد البيانات في عمود Series1 عقد الأوراق، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

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
- [**إنشاء أو تحديث مخططات عرض PowerPoint على Android**](/slides/ar/androidjava/create-chart/)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط البيانات في المخطط، يجب استخدام ما يلي:

توفر الفئات والطريقة التالية إمكانية الوصول إلى تنسيق نقاط البيانات لمخططي Treemap وSunburst.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
is used for accessing multi-level categories - it represents the container of 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) objects.
Basically it is a wrapper for 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) with
the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) class has
two methods: [**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) and 
[**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) which
provide access to corresponding settings.

## **إظهار قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
عيّن تسمية بيانات "Branch 1" لتظهر اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم اضبط لون النص إلى الأصفر:
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

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (الفرز) الأقسام في مخطط Sunburst/Treemap؟**  
لا. يقوم PowerPoint بفرز الأقسام تلقائيًا (عادةً حسب القيم المتناقصة، باتجاه عقارب الساعة). يطابق Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرةً؛ يمكنك تحقيق ذلك عن طريق معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان الأقسام والتسميات؟**  
تورث ألوان المخطط سمة/لوحة ألوان العرض التقديمي [/slides/androidjava/presentation-theme/] ما لم تقم بتعيين التعبئة/الخطوط صراحةً. للحصول على نتائج متسقة، احرص على تثبيت التعبئة الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**  
نعم. عند تصدير العرض التقديمي، تُحافظ إعدادات المخطط (التعبئة، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بالرندر باستخدام تنسيق المخطط المطبق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لوضع تراكب مخصص فوق المخطط؟**  
نعم. بعد التحقق من تخطيط المخطط، يتوفر *x* الفعلي و*y* الفعلي للعناصر (مثلاً، [DataLabel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/))، مما يساعد في تحديد المواقع بدقة للتراكبات.