---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية في .NET
linktitle: مخطط 3D
type: docs
url: /ar/net/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- تدوير
- عمق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. ضبط التدوير، نسب الارتفاع، عمق المخطط، والمسافة بين السلاسل باستخدام أمثلة C#."
---
## **نظرة عامة**

تسمح لك Aspose.Slides لـ .NET بتخصيص عرض مخطط ثلاثي الأبعاد من خلال الخاصية [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . توضح هذه المقالة كيفية ضبط التدوير، نسب الارتفاع، العمق، المحاور ذات الزوايا القائمة، والمسافة بين السلاسل، ثم حفظ العرض التقديمي بصيغة PPTX.

## **ضبط التدوير والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ كائنًا من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ويستخدم [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين كل منهما يحتوي على ثلاثة قيم. يشير فهرس ورقة العمل `0` إلى ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تحدد الخاصيتان [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) و[RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) تدوير المخطط إلى 40 و270 درجة على التوالي. تضع الخاصية [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) عمقه عند 150٪ من عرضه، بينما تمكّن الخاصية [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) المحاور ذات الزوايا القائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض الثلاثي الأبعاد.

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

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم الخاصية [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) لتعيين ارتفاع المخطط الثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر ذلك نسب المشهد الثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخططًا من نوع [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاعية 50٪، 100٪، و200٪. يبقى موقع المخطط وعرضه وارتفاعه ثابتًا. البيانات، التدوير، العمق، تباعد السلاسل، والتنسيق متطابقة في جميع الملفات الثلاثة؛ فقط نسبة الارتفاع تتغير.

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

الصور التالية تم تصديرها من العروض التقديمية المولدة باستخدام Microsoft PowerPoint. نسبة أصغر تنتج مشهدًا أكثر تسطحًا، بينما نسبة أكبر تنتج مشهدًا أطول داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بتعديل فواصل علامات المحور ووضع التسميات لتناسب المشهد.

| الارتفاع: 50٪ | الارتفاع: 100٪ | الارتفاع: 200٪ |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 200٪ من عرضه](height_percent_200.png) |

هذه الخصائص تتحكم في جوانب مختلفة من المخطط:

| الخاصية | التأثير |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | ارتفاع المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | عمق المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | المسافة بين السلاسل على محور العمق كنسبة مئوية من عرض العلامة. |

إعداد الارتفاع يؤثر على مخططات الأعمدة والشرائط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية، المساحية، الدائرية، وسطحية ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع `Column3D` المؤكد. لا يغيّر هذا الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء في تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). للحصول على إعدادات مظهر أخرى للمخططات، انظر [Chart Formatting](/slides/ar/net/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم الخاصية [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملًا: `0` يزيل الفجوة، بينما القيم الأكبر تزيد التباعد. مع ثبات عمق المخطط، يؤدي زيادة الفجوة إلى جعل العلامات أرفع على محور العمق.

يمكن الوصول إلى المجموعة عبر [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). ينطبق الإعداد على جميع السلاسل في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. الخاصية [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) للقراءة فقط وتعكس إعداد المجموعة الأصلية.

هذا الإعداد يؤثر على مخططات الأعمدة والشرائط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية والمساحية ثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، أو متجمعة، أو مكدسة. للحصول على مقارنة واضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

هذه الخصائص تتحكم في جوانب مختلفة من المخطط:

| الخاصية | التأثير |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | المسافة بين السلاسل على محور العمق كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | المسافة بين مجموعات الأعمدة أو الشرائط المتجاورة كنسبة مئوية من عرض العمود أو الشريط. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | العمق الكلي للمخطط كنسبة مئوية من عرض المخطط. |

المثال التالي المستقل يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، تدوير، عرض فجوة، وعمق مخطط متطابقة؛ فقط يتغير عمق الفجوة.

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

الصور التالية تم تصديرها من العروض التقديمية المولدة باستخدام Microsoft PowerPoint.

| عمق الفجوة: 0٪ | عمق الفجوة: 500٪ |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة الثلاثية الأبعاد وشكل الشريط**

في مخطط أسطواني مُجمّع، تبدأ السلسلة الأولى بشكل شريط أسطواني. يقرأ المثال الخاصيتين [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) و[IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) قبل وبعد كل تعديل.

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

| تغيير للسلسلة الأولى | `Type` | `Bar3DShape` |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين `Type` إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين `Bar3DShape` إلى `Box` | `ClusteredColumn3D` | `Box` |

تعيين الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان كودك يتفرّع بناءً على نوع السلسلة، فاقرأ `series.Type` بعد تغيير الشكل. القيمة المخزنة مسبقًا قبل الإسناد ستظل تختار فرع `ClusteredCone`.

![مقارنة PowerPoint تظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides المتنوعات الثلاثية الأبعاد لمخططات الأعمدة، بما في ذلك Column 3D وClustered Column 3D وStacked Column 3D و100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد المرتبطة المعروضة عبر تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) في مرجع API للنسخة المثبتة لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط 3D لتقرير أو الويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو [render the entire slide](/slides/ar/net/convert-powerpoint-to-png/) إلى تنسيقات مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو ترغب في تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما هو أداء بناء وعرض مخططات 3D الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد الرسوم. للحصول على أفضل النتائج، حافظ على الحد الأدنى من تأثيرات 3D، تجنّب القوام الثقيلة على الجدران ومناطق الرسم، قلل عدد نقاط البيانات لكل سلسلة عند الإمكان، وقم بالعرض إلى إخراج بحجم مناسب (الدقة والأبعاد) لتطابق شاشة العرض أو متطلبات الطباعة.