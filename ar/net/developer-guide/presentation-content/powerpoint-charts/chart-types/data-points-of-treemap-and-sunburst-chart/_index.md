---
title: نقاط بيانات مخطط الشجرة ومخطط الشمس
type: docs
url: /ar/net/data-points-of-treemap-and-sunburst-chart/
keywords: "مخطط الشمس, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة مخطط الشمس في عرض PowerPoint باستخدام C# أو .NET"
---

من بين أنواع المخططات المختلفة في PowerPoint، هناك نوعان "هرميان" - **مخطط الشجرة** و **مخطط الشمس** (المعروف أيضًا بمخطط الشمس، الرسم البياني الشمسي، المخطط الشعاعي، الرسم الشعاعي أو مخطط الفطيرة المتعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى قمة الفرع. يتم تعريف الأوراق بواسطة نقاط بيانات السلسلة، وكل مستوى تجميع متداخل لاحق يتم تحديده بواسطة الفئة المقابلة. يسمح Aspose.Slides for .NET بتنسيق نقاط بيانات مخطط الشمس ومخطط الشجرة بلغة C#.

إليك مخطط الشمس، حيث تحدد البيانات في عمود Series1 العقد الورقية، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط شمس جديد إلى العرض:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="راجع أيضًا" %}} 
- [**إنشاء مخطط الشمس**](/slides/ar/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

إذا كانت هناك حاجة لتنسيق نقاط بيانات المخطط، يجب أن نستخدم ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)، 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) الفئات 
و [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) الخاصية 
تقدم وصولًا لتنسيق نقاط بيانات مخطط الشجرة ومخطط الشمس. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
يستخدم للوصول إلى الفئات متعددة المستويات - إذ يمثل حاوية 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) الكائنات. 
بشكل أساسي هو غلاف لـ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) مع 
الخصائص المضافة المحددة لنقاط البيانات. 
الفئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) تحتوي 
على خاصيتين: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) و 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) مما 
يوفر الوصول إلى الإعدادات المقابلة.

## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية نقطة البيانات ولونها**
تعيين تسمية البيانات "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم تعيين لون النص إلى الأصفر:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيير لون فرع "Stem 4":

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)