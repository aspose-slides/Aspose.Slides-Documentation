---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في .NET
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط treemap
- مخطط sunburst
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة نقاط البيانات في مخططات treemap و sunburst باستخدام Aspose.Slides for .NET، المتوافق مع صيغ PowerPoint."
---

من بين أنواع مخططات PowerPoint الأخرى، هناك نوعان "هرميان" - مخطط **Treemap** ومخطط **Sunburst** (المعروف أيضًا باسم مخطط Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). هذه المخططات تعرض بيانات هرمية منظمة كشجرة - من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل لاحق بالفئة المقابلة. يتيح Aspose.Slides for .NET تنسيق نقاط البيانات لمخطط Sunburst و Treemap باستخدام C#.

فيما يلي مخطط Sunburst، حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء مخطط Sunburst**](/slides/ar/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط البيانات في المخطط، يجب استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)، 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) الفئات 
وخاصية [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) 
توفر الوصول لتنسيق نقاط البيانات لمخططي Treemap و Sunburst. 
يُستخدم [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
للوصول إلى الفئات المتعددة المستويات - فهو يمثل حاوية كائنات 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel). 
في الأساس هو غلاف لـ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) مع 
الخصائص المضافة الخاصة بنقاط البيانات. 
تحتوي فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) على 
خاصيتين: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) و 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) التي 
توفر الوصول إلى الإعدادات المقابلة.

## **إظهار قيمة نقطة البيانات**
إظهار قيمة نقطة البيانات "Leaf 4":
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية نقطة البيانات واللون**
تعيين تسمية بيانات "Branch 1" لتظهر اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم تعيين لون النص إلى الأصفر:
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

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (فرز) القطاعات في Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً حسب القيم المتناقصة، باتجاه عقارب الساعة). Aspose.Slides يطابق هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ بل يتم تحقيقه عبر معالجة البيانات مسبقًا.

**كيف تؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**

ألوان المخطط ترث سمة/لوحة الألوان الخاصة بالعرض التقديمي [theme/palette](/slides/ar/net/presentation-theme/) ما لم تقم بتعيين التعبئات/الخطوط صراحة. للحصول على نتائج متسقة، احرص على تعيين تعبئات صلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، يتم الحفاظ على إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بالعرض مع تطبيق تنسيق المخطط.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لوضع تغطية مخصصة فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تكون `ActualX`/`ActualY` متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/))، مما يساعد في تحديد موضع التغطيات بدقة.