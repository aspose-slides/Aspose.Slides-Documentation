---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام .NET
linktitle: سلاسل البيانات
type: docs
url: /ar/net/chart-series/
keywords:
- سلسلة المخطط
- تراكب السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إدارة سلاسل المخططات، نقاط البيانات، خلايا دفتر العمل، التنسيق، التراكب، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام C#."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر عمل بيانات المخطط. تمثل [IChartSeries](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/) مجموعة واحدة من القيم المرتبطة، ويشير كل [IChartDataPoint](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بـ كائنات [IChartDataCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/) بدلاً من تخزينها كنص عرض فقط.

في مخطط الفئات النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلسلة. فهارس ورقة العمل والصف والعمود التي تُمرَّر إلى [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/getcell/) هي ذات أساس صفر. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، لكن لا تُفترض أن كل مخطط موجود يستخدمه. بالنسبة لعروض تقديمية محملة، تحقق من الخلايا التي تُشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات مستوى السلسلة، مثل [IChartSeries.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/format/)، تُوفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [IChartDataPoint.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- تنطبق إعدادات المجموعة على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/). يمكن الوصول إلى المجموعة عبر [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/parentseriesgroup/) عندما تحتاج لتعيين خيارات مثل التراكب أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تتفوق تنسيق النقطة على تلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين تراكب سلاسل المخطط**

يُبلغ [IChartSeries.Overlap](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/overlap/) عن مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 حتى 100 بالمائة. إنه عرض للقراءة فقط للإعداد على مجموعة السلاسل الأصلية. قم بتعيين [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. هذا الخيار يُطبق على أنماط المخططات التي تعرض أشرطة أو أعمدة مجمعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// المخطط الجديد يحتوي على سلاسل وعناصر فئة وقيم عينة.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

![تراكب السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة تحتوي بالفعل على تعبئة صريحة، فإن إعداد [IChartDataPoint.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر عمل بيانات المخطط وعادةً ما يُعرض في وسيلة الإيضاح. في دفتر العمل الافتراضي المُنشأ لمخطط أعمدة متكتلة، الخلية B1 تقع في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسمّاة في المثال التالي تجعل هذا الهيكل واضحًا:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

يمكنك أيضًا تحديث الخلية التي يشير إليها بالفعل [IChartSeries.Name](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/name/). ي避免 هذا النهج الافتراض بوجود صف وعمود محددين في مخطط موجود:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

تعيد [IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) اللون المحسوب بناءً على فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحةً. استدعاء الطريقة يقرأ اللون المحسوب؛ ولا يعيّن تعبئة جديدة.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

مثال على مخرجات نمط المخطط الافتراضي:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة مقلوب لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة والأعمدة والفقاعات، يمكن لـ [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertifnegative/) عرض القيم السلبية بتعبئة مختلفة. قم بتعيين تعبئة السلسلة العادية إلى صلبة، فعِّل العكس، وعيّن لون القيمة السلبية عبر [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). الأعداد السلبية تظل دون تغيير في دفتر العمل؛ فقط يتغير لون عرضها.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

![لون التعبئة الصلبة المقلوب](inverted_solid_fill_color.png)

يمكنك تمكين العكس لنقطة واحدة عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). في المثال التالي، تم تعطيل العكس للسلسلة وتم تمكينه فقط للنقطة المختارة. تم أيضًا تعيين قيمة سلبية للنقطة لتكون الظاهرة واضحة:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون إزالة بقية النقاط، عيّن خلية دفتر العمل الداعمة لها إلى `null`. في مخطط الأعمدة، تُتوفر القيمة المرسومة عبر [IChartDataPoint.YValue](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/yvalue/). تظل نقطة البيانات في نفس موقع الفئة، لكن المخطط يعامل قيمتها كخالية وفقًا لإعدادات القيم الفارغة في المخطط.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

تستخدم مخططات التشتت خلايا X و Y منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تستدعِ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointcollection/clear/) عندما ترغب في الاحتفاظ بالنقاط الأخرى، لأن هذه الطريقة تزيل جميع نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

تمثل الخلية الفارغة في دفتر العمل بيانات مفقودة؛ والخلية التي تحتوي على `0` تمثل قيمة عددية معروفة. عيّن [IChartDataCell.Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/) إلى `null` لجعل الخلية فارغة. يظل الصفر الرقمي صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/displayblanksas/) لاختيار كيف يعرض المخطط الخلايا الفارغة. هذا الإعداد يُطبق على المخطط بأكمله. يغيّر طريقة رسم الفراغات، دون ملء الخلية الفارغة في دفتر العمل بصفر أو قيمة مُستنتَجَة.

يُنشئ المثال التالي المستقل مخططًا خطيًا بسلسلة واحدة، يمسح القيمة للّوم الثالث، ويحفظ نفس المخطط بكل وضع. لا يلزم ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

كل ملف إخراج يخزن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات الخطوط ذات البيانات المتطابقة: الفجوة تقطع الخط عند اليوم 3، الصفر يخفض الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

يعتمد التأثير الظاهر على نوع المخطط. يجعل مخطط الخط جميع الأوضاع الثلاثة سهلة المقارنة. لا تحتوي المخططات الشريطية والعمودية على خط لربط الفئات المفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل المعروض أعلاه؛ يمكن أن يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، مخطط التشتت مع العلامات فقط لا يحتوي على خط ربط. لا تتوقع ثلاثة نتائج متميزة لكل نوع مخطط؛ تحقق من الناتج للنوع الذي تستخدمه.

## **تعيين عرض الفجوة للسلسلة**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يعبر عنها كنسبة مئوية من عرض الشريط أو العمود. مثل التراكب، ينتمي إلى مجموعة السلسلة الأصلية بدلاً من سلسلة واحدة. عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ القيمة الأصغر تجعلها أكثر كثافة.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسِلها لا تتشارك جميعها نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات التشتت قيم X و Y، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التراكب وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هو مجموعة سلاسل المخطط؟**

تحتوي [IChartSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/) على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تغيير المجموعة التي يتم الوصول إليها من خلال سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط الذي تم إنشاؤه حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، يقوم [IShapeCollection.AddChart](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addchart/) بإنشاء سلاسل، فئات، وقيم نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا إنشاء مخطط بدون بيانات افتراضية عبر إصدارة مختلفة.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/). تغيير خلية مشار إليها يحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على توافق صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف يمكنني مسح نقطة واحدة بدلاً من السلسلة بالكامل؟**

عيّن خلية القيمة المعنية إلى `null` للاحتفاظ بموقع فئة النقطة كنقطة فارغة. استخدم [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointcollection/clear/) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا قمت أيضًا بإزالة الفئات، فحدّث كل سلسلة بحيث تظل قيمها متماسكة مع مجموعة الفئات.

**كيف يتم عرض النقاط الفارغة؟**

يعتمد النتيجة على نوع المخطط و[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/displayblanksas/). يمكن للمخططات المدعومة عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يطابق معنى البيانات المفقودة في العرض التقديمي الخاص بك. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يتم تنسيق القيم السلبية؟**

بالنسبة للسلاسل المدعومة من الأشرطة، الأعمدة، والفقاعات، فعّل [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertifnegative/) وعيّن [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). يمكنك تجاوز السلوك لنقطة فردية باستخدام [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). هذه الخصائص تؤثر على التنسيق، وليس على القيم العددية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوق تنسيق نقطة البيانات الصريحة لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُعرّف تنسيق السلسلة، نمط المخطط والموضوع تلقائيًا. تتحكم خصائص المجموعة مثل التراكب وعرض الفجوة في التخطيط ولا تُعدّ تجاوزات لتنسيق مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن للمخطط احتواؤها؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، الذاكرة المتاحة، وقت التقديم، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب أن أغير عندما تكون الأعمدة قريبة جدًا من بعضها أو متباعدة جدًا؟**

عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لتقريب المجموعات من بعضها.