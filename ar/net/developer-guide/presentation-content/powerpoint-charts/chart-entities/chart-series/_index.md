---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام .NET
linktitle: سلاسل البيانات
type: docs
url: /ar/net/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
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
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام C#."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر عمل بيانات المخطط. تمثل [IChartSeries](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/) مجموعة واحدة من القيم المرتبطة، وكل [IChartDataPoint](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. لذلك يتم ربط اسم السلسلة، الفئات، وقيم النقاط بكائنات [IChartDataCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/) بدلاً من تخزينها كنص عرض فقط.

في مخطط الفئة النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، العمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلاسل. الفهارس للورقة والصف والعمود التي تُمرَّر إلى [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/getcell/) تبدأ من الصفر. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة للعرض التقديمي المُحمَّل، افحص الخلايا التي تشير إليها السلاسل، الفئات، ونقاط البيانات قبل تغيير قيم دفتر العمل.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/format/)، تُوفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات على مستوى نقطة البيانات، مثل [IChartDataPoint.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/). يمكن الوصول إلى المجموعة عبر [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/parentseriesgroup/) عندما تحتاج إلى تعيين خيارات مثل التداخل أو عرض الفجوة.

عند عدم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تُعطى تنسيق النقطة الأولوية لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/overlap/) يُظهر مقدار تداخل الأعمدة أو القضبان في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. وهو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأصلية. عيّن [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يُطبق هذا الخيار على أنواع المخططات التي تعرض أعمدة أو قضبان مجمَّعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يعيّن التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// المخطط الجديد يحتوي على سلاسل، فئات، وقيم نموذجية.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

النتيجة:

![The series overlap](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة، فإن إعداد [IChartDataPoint.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

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

النتيجة:

![The color of the series](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر عمل بيانات المخطط ويُعرض عادةً في وسيلة الإيضاح. في دفتر العمل الافتراضي الذي يُنشئ لمخطط عمودي متكتل، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل ذلك الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها [IChartSeries.Name](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/name/). يَتَجنّب هذا النهج الافتراض بوجود صف أو عمود محدد في مخطط موجود:

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

النتيجة:

![The series name](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) يُعيد اللون الذي يُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تكون تعبئة السلسلة مُحدَّدة صراحة. استدعاء الطريقة يقرأ اللون المُحسب؛ لا يُعيّن تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

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

مخرجات المثال للنمط الافتراضي للمخطط:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة معكوس لسلسلة المخطط**

بالنسبة لسلاسل القضبان، الأعمدة، والفقاعات، يمكن لـ [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertifnegative/) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، مّكن العكس، وعين لون القيمة السالبة عبر [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). الأرقام السالبة تظل غير مُغيَّرة في دفتر العمل؛ يتغير فقط لون العرض.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في ورقة العمل يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

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

النتيجة:

![The inverted solid fill color](inverted_solid_fill_color.png)

يمكنك تمكين العكس لنقطة واحدة عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). في المثال التالي، يتم تعطيل العكس للسلسلة وتفعيله فقط للنقطة المحددة. تُعطى النقطة قيمة سالبة لكي يكون التأثير مرئيًا:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، عيّن خلية دفتر العمل الداعمة لها إلى `null`. بالنسبة لمخطط عمودي، القيمة المرسومة متاحة عبر [IChartDataPoint.YValue](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/yvalue/). تظل نقطة البيانات في نفس موضع الفئة، لكن المخطط يعامل قيمتها كقيمة فارغة وفقًا لإعدادات القيم الفارغة للمخطط.

المثال التالي يمسح النقطة الثانية فقط في السلسلة الأولى:

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

تستخدم مخططات التبعثر خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية الحجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تُستدعِ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointcollection/clear/) عندما تريد الحفاظ على النقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفية في ورقة العمل، راجع [Include Data from Hidden Rows and Columns](/slides/ar/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

الخلية الفارغة في دفتر العمل تمثّل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثّل قيمة رقمية معروفة. عيّن [IChartDataCell.Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/) إلى `null` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/displayblanksas/) لاختيار كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. إنه يغيّر طريقة رسم الفراغات، دون ملء الخلية الفارغة بالصفر أو قيمة مُinterp.

المثال التالي كامل يُنشئ مخططًا خطيًا بسلسلة واحدة، يمسح القيمة لليوم الثالث، ويحفظ نفس المخطط بكل وضع. لا يلزم ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

// اتّرك اليوم الثالث فارغًا فعليًا، مع الاحتفاظ بفئته ونقطة البيانات الخاصة به.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

كل ملف ناتج يخزن الوضع المعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلًا من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم الثالث فارغ في دفتر العمل في كل حالة:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. المخطط الخطي يُظهر الثلاثة أوضاع بسهولة للمقارنة. مخططات الشريط والعمود لا تمتلك خطًا للتوصيل عبر فئة مفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل الموضح أعلاه؛ قد يبدو العمود المفقود والعمود صفر الارتفاع متماثلين. بالمثل، مخطط التبعثر مع علامات فقط لا يمتلك خطًا موصلاً. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من الناتج للنوع الذي تستخدمه.

## **تعيين عرض فجوة السلسلة**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو القضبان المتجاورة، تُعبَّر كنسبة مئوية من عرض العمود أو القضيب. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ القيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

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

النتيجة:

![The gap width](gap_width.png)

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثَّلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها ليس لها نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئة الفئات والقيم، ومخططات التبعثر تستخدم قيم X وY، ومخططات الفقاعات تُضيف أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. الخيارات مثل التداخل وعرض الفجوة تُطبق فقط على مجموعات الشرائط أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/) تحتوي على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تغيير المجموعة التي تصل من خلالها سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، يُنشئ [IShapeCollection.AddChart](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addchart/) سلاسل، فئات، وقيم نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أن يُنشئ تحميل زائد مخططًا بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/). تغيير خلية مُشار إليها يُحدِّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من السلسلة بأكملها؟**

عيّن خلية القيمة ذات الصلة إلى `null` للاحتفاظ بموضع الفئة للنقطة كنقطة فارغة. استخدم [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointcollection/clear/) فقط عندما ترغب في إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها محاذية مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط و[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/displayblanksas/). المخططات المدعومة يمكنها عرض الفراغات كفجوات أو كقيم صفرية أو بربط النقاط المتجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) لمثال كامل ومقارنة بصرية.

**كيف تُنسق القيم السالبة؟**

بالنسبة للسلاسل المدعومة من نوع الشريط، العمود، والفقاعة، فعّل [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertifnegative/) وعيّن [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). يمكنك تجاوز السلوك لنقطة فردية عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). هذه الخصائص تؤثر على التنسيق، ليست على القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما تكون كل من السلسلة والنقطة مُنسّقين؟**

التنسيق الصريح لنقطة البيانات يتفوّق لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدد تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. خصائص المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعدّ تجاوزًا لتنسيق مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا لعدد السلاسل. في الممارسة العملية، تحدد قيود ملف العرض التقديمي، الذاكرة المتاحة، وقت العرض، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب أن أغيّر عندما تكون الأعمدة قريبة جدًا أو متباعدة كثيرًا؟**

عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لتقريب المجموعات من بعضها.