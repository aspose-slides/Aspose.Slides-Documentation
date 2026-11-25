---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام .NET
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/net/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل باستخدام أمثلة C#."
---
## **نظرة عامة**

تتيح لك Aspose.Slides لـ .NET تخصيص طريقة عرض مخطط ثلاثي الأبعاد عبر الخاصية [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . توضح هذه المقالة كيفية ضبط الدوران، نسب الارتفاع، العمق، المحاور بزاوية قائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

يوضح المثال أدناه إنشاء كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) واستخدام [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاثة قيم. يحدد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تحدد الخصائص [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) و[RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) دوران المخطط إلى 40 و270 درجة على التوالي. يضبط [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) عمقه إلى 150 % من عرضه، بينما يفعّل [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) المحاور بزاوية قائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض الثلاثي الأبعاد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **تطبيق تعبئة صورة على سطح مخطط ثلاثي الأبعاد**

يحتوي مخطط ثلاثي الأبعاد على ثلاثة أسطح يمكنك تعبئتها بشكل مستقل: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/)، [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/)، و[ floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). اضبط خاصية [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) للسطح المحدد على `Picture` وعيّن صورة. اضبط كلًا من [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) و[picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) للسطح على `Stretch` لتناسب نسخة واحدة من الصورة عبر السطح.

احفظ الملف [arrow.png](arrow.png) في دليل العمل. يدور المثال المخطط ويرفع القيمة القصوى على المحور العمودي حتى يصبح floor مرئيًا بين الأعمدة. ثم ينسخ الشريحة مرتين قبل تطبيق السهم على سطح مختلف في كل شريحة. تحتفظ جميع المخططات الثلاثة بنفس البيانات وزاوية الرؤية والخلفية.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

يعرض Microsoft PowerPoint الشرائح الثلاث كما يلي.

| الجدار الجانبي | الجدار الخلفي | الأرضية |
| --- | --- | --- |
| ![سهم يشير إلى داخل المخطط على طول الجدار الجانبي](side-wall.png) | ![سهم يشير إلى اليمين عبر الجدار الخلفي](back-wall.png) | ![سهم يشير إلى اليمين عبر الأرضية بين الأعمدة](floor.png) |

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) لتعيين ارتفاع مخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر هذا نسب المشهد الثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

ينشئ المثال التالي مخططًا من النوع [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاثة عروض تقديمية بنسب ارتفاع 50%، 100%، و200%. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات والدوران والعمق وتباعد السلاسل والتنسيق هي نفسها في جميع الملفات الثلاثة؛ تتغيّر فقط نسبة الارتفاع.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

تم تصدير الصور التالية من العروض التقديمية المولَّدة باستخدام Microsoft PowerPoint. النسبة الأصغر تُنتج مشهدًا أكثر تسطحًا، بينما النسبة الأكبر تُنتج مشهدًا أطول داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بضبط فواصل علامات المحاور ومواقع التسميات لتناسب المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع محدد إلى 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع محدد إلى 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع محدد إلى 200٪ من عرضه](height_percent_200.png) |

تتحكم هذه الخصائص في جوانب مختلفة من المخطط:

| الخاصية | التأثير |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | ارتفاع المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | عمق المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | التباعد بين السلاسل على طول محور العمق، كنسبة مئوية من عرض العلامة. |

تؤثر إعدادات الارتفاع على مخططات الأعمدة والشرائط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخطوط، المناطق، الفطائر، والسطوح ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع `Column3D` المؤكد. لا يغيّر هذا الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء في تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). للحصول على إعدادات أخرى لمظهر المخطط، راجع [Chart Formatting](/slides/ar/net/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) للتحكم في المسافة بين سلاسل البيانات على طول محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** بما في ذلك: `0` يزيل الفجوة، بينما القيم الأكبر تزيد التباعد. مع عمق مخطط ثابت، يزيد زيادة الفجوة من رقة العلامات على محور العمق.

يمكن الوصول إلى المجموعة عبر [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). ينطبق الإعداد على جميع السلاسل في تلك المجموعة، ليس فقط السلسلة المستخدمة للوصول إليها. الخاصية [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) للقراءة فقط وتعكس إعداد المجموعة الأم.

يُؤثر هذا الإعداد على مخططات الأعمدة والشرائط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخطوط والمساحات ثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، مجمّعة، أو مكدسة. للحصول على مقارنة واضحة للفجوات بين سلاسل منفصلة، استخدم `ChartType.Column3D` من تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

تتحكم هذه الخصائص في جوانب مختلفة من المخطط:

| الخاصية | التأثير |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | التباعد بين السلاسل على طول محور العمق، كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | التباعد بين مجموعات الأعمدة أو الشرائط المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | العمق الكلي للمخطط، كنسبة مئوية من عرض المخطط. |

يستخدم المثال المدمج التالي بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات ودوران وتباعد عرض وعمق مخطط متطابقة؛ تتغيّر فقط قيمة فجوة العمق.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

تم تصدير الصور التالية من العروض التقديمية المولَّدة باستخدام Microsoft PowerPoint.

| فجوة العمق: 0% | فجوة العمق: 500% |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد دون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة الثلاثية الأبعاد وشكل الشريط**

في مخطط أسطوانة مجمّع، تبدأ السلسلة الأولى بشكل شريط أسطواني. يقرأ المثال الخاصيتين [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) و[IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) قبل وبعد كل تغيير.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| التغيير في السلسلة الأولى | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set `Type` to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set `Bar3DShape` to `Box` | `ClusteredColumn3D` | `Box` |

ضبط الشكل على `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان كودك يتفرع بناءً على نوع السلسلة، فاقرأ `series.Type` بعد تغيير الشكل. القيمة المخزنة قبل الإسناد ستظل تختار الفرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى على شكل أسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **FAQ**

**ما هي أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides المتغيرات الثلاثية الأبعاد لمخططات الأعمدة، بما في ذلك Column 3D وClustered Column 3D وStacked Column 3D و100 % Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية الأبعاد المرتبطة المعروضة عبر تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدَّثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) في وثائق واجهة برمجة التطبيقات للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط كصورة باستخدام [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو [render the entire slide](/slides/ar/net/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد الرسوم. للحصول على أفضل النتائج، حافظ على تأثيرات 3D بأقل قدر ممكن، تجنّب القوام الثقيلة على الجدران ومناطق الرسم، قلل عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالعرض إلى مخرجات ذات حجم مناسب (الدقة والأبعاد) لتتناسب مع عرض الشاشة أو متطلبات الطباعة المستهدفة.