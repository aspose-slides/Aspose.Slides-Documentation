---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية في .NET
linktitle: سلاسل البيانات
type: docs
url: /ar/net/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة بيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخططات، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام C#."
---
## **نظرة عامة**

يمكن للمخطط تخزين القيم المرسومة إما في خلايا دفتر العمل أو مباشرةً كقواعد عددية. يمثل [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) مجموعة واحدة من القيم المرتبطة، ويمثل كل [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) نقطة في تلك السلسلة. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) العلامات أو قيم التجميع المشتركة بين السلاسل. في المخططات التي تم إنشاؤها ببيانات افتراضية، تستخدم أسماء السلاسل والفئات وقيم النقاط كائنات [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) من دفتر عمل المخطط.

في مخطط الفئة النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والباقي للقيم. الفهارس للورقة، الصف والعمود التي تُمرّر إلى [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) هي صفرية. هذا التخطيط مفيد عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. للعرض المحمَّل، افحص الخلايا التي تشير إليها السلاسل والفئات والنقاط قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)، توفِّر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات للنقطة، مثل [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تطبق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). يمكن الوصول إلى المجموعة عبر [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) عندما تحتاج لتعيين خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدِّد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تأخذ تنسيق النقطة الأسبقية لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين قيم السلسلة باستخدام قواعد عددية**

استخدم القواعد العددية عندما تأتي قيم السلسلة من بيانات التطبيق أو الحسابات ولا تحتاج إلى مراجع خلايا ورقة العمل. عيّن [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) إلى [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) قبل تعيين [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) لكل نقطة عبر [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

تتحكم إعدادات المجموعة بنوع مصدر جميع قيم النقاط في تلك السلسلة. كل نقطة تُظهر نوعها المختار عبر [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/). يمكن تغييره من خلال إعدادات المجموعة. مع `Worksheet`، استخدم [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) للوصول إلى الخلية المشار إليها. مع `DoubleLiterals`، استخدم `AsLiteralDouble` لقراءة أو كتابة الرقم مباشرة.

المثال التالي ينشئ مخطط عمودي بسلاسل وفئات افتراضية، ثم يُعيّن قيمًا محسوبة 10، 20، وهكذا للنقاط الموجودة في سلتها الأولى. ثم يحفظ العرض، يعيده للفتح، ويطبع القيم المخزنة.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

نوع مصدر قيمة النقطة منفصل عن [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/)، الذي يحدد تكوين دفتر العمل الداخلي أو الخارجي للمخطط. استخدام القواعد العددية لا يزيل دفتر العمل المضمّن بحد ذاته. في هذا المثال، يظل دفتر العمل متاحًا لتسميات الفئات، أسماء السلاسل، والسلاسل الأخرى. راجع [Chart Workbook](/slides/ar/net/chart-workbook/) لإدارة دفتر العمل.

للمخططات النقطية والفقاعية، عيّن [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) و[DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) لاختيار المصادر لـ [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) و[YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). تستخدم المخططات الفقاعية أيضًا [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) لـ [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). عيّن كل مصدر مناسب إلى `DoubleLiterals` قبل تعيين الأرقام عبر خاصية `AsLiteralDouble` لتلك القيمة.

## **تعيين تداخل سلسلة المخطط**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) يُظهر مقدار تداخل الأعمدة أو الأشرطة في مخطط ثنائي الأبعاد، من -100 إلى 100 ٪. هو عرض للقراءة فقط لإعداد التداخل في مجموعة السلاسل الأم. عيّن [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) لتحديث جميع السلاسل المتوافقة في تلك المجموعة. هذا الخيار يُطبق على أنواع المخططات التي تُظهر أشرطة أو أعمدة مجمَّعة؛ ولا يُؤثر على مجموعات السلاسل غير المتصلة في مخطط مركب.

المثال التالي يعيّن التداخل للمجموعة التي تحتوي السلسلة الأولى:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// المخطط الجديد يحتوي على سلاسل وعينات وفئات وقيم.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

الناتج:

![The series overlap](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت نقطة ما لها تعبئة صريحة، فإن إعداد [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبّق تعبئة صلبة زرقاء على السلسلة الأولى:

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

الناتج:

![The color of the series](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر عمل بيانات المخطط ويُعرض عادةً في وسيلة الإيضاح. في دفتر العمل الافتراضي الذي يُنشئ لمخطط عمودي مُجَمَّع، الخلية B1 هي الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يُشير إليها [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). يَتَجنَّب هذا النهج الافتراض بوجود صف وعمود محددين في مخطط موجود:

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

الناتج:

![The series name](series_name.png)

### **إنشاء سلسلة باسم من خلايا متعددة**

يُفيد اسم سلسلة مركّب عندما يكون اسم المنتج وفترة التقرير مخزَّنين في خلايا دفتر عمل منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و`2026` في C1 في اسم سلسلة واحد مع إبقاء الجزأين مرتبطين بخلايا المصدر.

استخدم [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) لاسترجاع نطاق الاسم، ثم مرّر ذلك التجميع إلى [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). المتغيّر `skipHiddenCells` يتحكم فيما إذا كان سيتم تضمين الخلايا المخفية: `true` يستثنيها، بينما `false` يضمّنها. يستخدم هذا المثال `false` لتضمين جميع الخلايا في نطاق الاسم.

المثال التالي ينشئ عرضًا بسلسلة واحدة ونقطتي بيانات. تُزود الخلايا B1:C1 باسم السلسلة فقط؛ A2:A3 تُزود علامات الفئات، وB2:B3 تُزود القيم العددية.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// هاتان الخليتان تزودان اسم السلسلة.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// خلايا منفصلة تزود الفئات ونقاط البيانات الرقمية.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

اسم السلسلة الناتج هو `Product A 2026`، مع مسافة بين القيمتين. تعرض وسيلة الإيضاح ذلك كمدخل واحد للعمودين. الصُّورة أدناه تم توليدها من العرض المحفوظ:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) يُعيد اللون المُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدَّد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المُحسب؛ ولا يعيّن تعبئة جديدة.

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

ناتج المثال للنمط الافتراضي للمخطط:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين تعبئة معكوسة لسلسلة المخطط**

للسلاسل العمودية، العمودية والمفقَّطة، يمكن لـ [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية لتكون صلبة، فعِّل الانعكاس، وعيّن لون القيمة السالبة عبر [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). تُبقى الأعداد السالبة كما هي في دفتر العمل؛ يتغيّر فقط لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في ورقة العمل يحتوي اسم السلسلة، العمود 0 يحتوي أسماء الفئات، والعمود 1 يحتوي القيم:

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

الناتج:

![The inverted solid fill color](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). في المثال التالي، يُعطل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المختارة. تُعطى النقطة قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، عيّن خلية دفتر العمل الداعمة لها إلى `null`. بالنسبة لمخطط عمودي، القيم المرسومة متاحة عبر [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). تبقى نقطة البيانات في موقع الفئة نفسه، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة للمخطط.

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

المخططات النقطية تستخدم خلايا X وY منفصلة، والمخططات الفقاعية تستخدم أيضًا خلية للحجم. امسح الخلية التي تمثل القيمة التي تريد إزالتها فقط. لا تستدعِ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) إذا أردت الإبقاء على باقي النقاط، لأن هذه الطريقة تحذف جميع نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحوي قيمًا هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

خلية دفتر العمل الفارغة تمثل بيانات مفقودة؛ الخلية التي تحوي `0` تمثل قيمة رقمية معروفة. عيّن [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) إلى `null` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلايا الفارغة.

استخدم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) لاختيار كيفية عرض المخطط للخلايا الفارغة. هذا الإعداد يُطبق على المخطط بأكمله. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة بصفر أو قيمة مُستَنتَجة.

المثال التالي يُنشئ مخطط خط مع سلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه لكل وضع. لا يلزم ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

// اترك اليوم 3 فارغًا فعليًا مع الاحتفاظ بالفئة ونقطة البيانات.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

كل ملف ناتج يُخزن الوضع المعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في الثلاث ملفات. اليوم 3 فارغ في دفتر العمل في كل حالة:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. مخطط الخط يظهر جميع الأوضاع الثلاثة بوضوح. مخططات الأعمدة والأشرطة لا تملك خطًا لربط الفئات المفقودة، لذا لا يستطيع وضع `Span` إنتاج قطعة الربط المعروضة أعلاه؛ قد يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، مخطط النثر مع العلامات فقط لا يحتوي على خط ربط. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من المخرجات للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو الأشرطة المتقاربة، تُعبَّر كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، هو خاص بمجموعة السلاسل الأم وليس بسلسلة واحدة. عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط:

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

الناتج:

![The gap width](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

كل أنواع المخططات التي يمثلها تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في بنية القيم أو الإعدادات. على سبيل المثال، المخططات الفئوية تستخدم الفئات والقيم، المخططات النقطية تستخدم قيم X وY، والمخططات الفقاعية تضيف أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. الخيارات مثل التداخل وعرض الفجوة تُطبق فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تعديل المجموعة التي يُشار إليها عبر سلسلة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) يُنشئ سلاسل، فئات، وقيم عينات. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. هناك نسخة مُحمَّلة تُنشئ مخططًا دون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تُشير إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). تعديل خلية مُشار إليها يُحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلًا من مسح السلسلة كاملة؟**

عيّن خلية القيمة ذات الصلة إلى `null` لتبقي موقع الفئة للنقطة كقيمة فارغة. استخدم [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) فقط عندما ترغب بإزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدِّث كل السلاسل لتظل قيمها محاذية مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط و[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). المخططات المدعومة يمكنها عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يطابق معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) لمثال كامل ومقارنة مرئية.

**كيف يتم تنسيق القيم السالبة؟**

للسلاسل المتوافقة من الأشرطة، الأعمدة، والفقاعات، فعِّل [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) وعيّن [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). يمكنك تجاوز السلوك لنقطة فردية عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). تؤثر هذه الخصائص على التنسيق فقط، ولا تغير القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

تنسيق النقطة الصريح يتفوق لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق السلسلة، النمط والموضوع الافتراضي للمخطط. خصائص المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا لعدد السلاسل. في الممارسة العملية، تحدد قيود ملف العرض، الذاكرة المتاحة، زمن التصيير، وقابلية القراءة للمخطط حدًا عمليًا.

**ماذا أفعل إذا كانت الأعمدة قريبة جدًا أو متباعدة جدًا؟**

عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) على مجموعة السلاسل الأم المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لجعل المجموعات أقرب إلى بعضها.