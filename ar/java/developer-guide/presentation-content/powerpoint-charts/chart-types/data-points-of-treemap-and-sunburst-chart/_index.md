---
title: نقاط البيانات لرسم الشجرة والمخطط الشمسي
type: docs
url: /ar/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "مخطط شمسي في Aspose.Slides لـ Java"
description: "مخطط شمسي، مخطط شمسي، مخطط شمسي، مخطط شعاعي، رسم شعاعي أو مخطط دائري متعدد المستويات مع Aspose.Slides لـ Java."
---

من بين أنواع المخططات في PowerPoint الأخرى، هناك نوعان "هرميان" - **مخطط الشجرة** و **المخطط الشمسي** (المعروف أيضًا باسم مخطط شمسي، مخطط شمسي، مخطط شعاعي، رسم شعاعي أو مخطط دائري متعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة على شكل شجرة - من الأوراق إلى قمة الفرع. يتم تحديد الأوراق بواسطة نقاط بيانات السلاسل، وكل مستوى تجميع متداخل لاحق يتم تحديده بواسطة الفئة المقابلة. يتيح Aspose.Slides لـ Java تنسيق نقاط بيانات المخطط الشمسي ومخطط الشجرة في Java.

إليك مخطط شمسي، حيث تحدد البيانات في عمود Series1 العقد الورقية، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط شمسي جديد إلى العرض التقديمي:

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
- [**إنشاء مخطط شمسي**](/slides/ar/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


إذا كانت هناك حاجة لتنسيق نقاط بيانات المخطط، يجب علينا استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)، 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) الفئات 
و [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) الطريقة 
توفر الوصول لتنسيق نقاط بيانات مخططات الشجرة والمخطط الشمسي. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
يستخدم للوصول إلى الفئات متعددة المستويات - يمثل حاوية لـ 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) كائنات. 
أساسًا هو غلاف لـ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) مع 
الخصائص المضافة المحددة لنقاط البيانات. 
فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) لديها 
طريقتان: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) و 
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) والتي 
توفر الوصول للإعدادات المقابلة.
## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "ورقة 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين علامة نقطة البيانات و اللون**
تعيين علامة بيانات "فرع 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم قم بتعيين لون النص إلى الأصفر:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيير لون فرع "بخار 4":

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
