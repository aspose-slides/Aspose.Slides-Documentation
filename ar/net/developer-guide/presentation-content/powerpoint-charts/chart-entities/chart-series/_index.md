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

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. تمثل [IChartSeries](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/) مجموعة واحدة من القيم المرتبطة، وكل [IChartDataPoint](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بكائنات [IChartDataCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/) بدلاً من تخزينها كنص عرض فقط.

للمخطط الفئوي النمطي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُستَخدم الخلايا المتبقية لقيم السلاسل. فهارس ورقة العمل والصف والعمود التي تُمرّر إلى [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/getcell/) هي صفرية الأساس. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. عند تحميل عرض تقديمي، افحص الخلايا المشار إليها من قبل السلاسل والفئات ونقاط البيانات قبل تغيير قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/format/)، تُوفّر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [IChartDataPoint.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/). يمكن الوصول إلى المجموعة عبر [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/parentseriesgroup/) عندما تحتاج إلى تعيين خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو للسلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، فإن تنسيق النقطة له الأفضلية لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ضبط تداخل سلسلة المخطط**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/overlap/) يُظهر مقدار تداخل الأعمدة أو الشرائط في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. وهو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأم. عيّن [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أعمدة أو شرائط مُجمَّعة؛ لا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يضبط التداخل للمجموعة التي تحتوي على السلسلة الأولى:

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

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة، فإن إعداد [IChartDataPoint.Format](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة باللون الأزرق على السلسلة الأولى:

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

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر بيانات المخطط ويُعرض عادةً في دليل الألوان. في دفتر العمل الافتراضي المُنشأ لمخطط عمود مُجمَّع، الخلية B1 هي في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المعرفة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية المشار إليها بالفعل من قبل [IChartSeries.Name](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/name/). هذه المقاربة تتجنب الافتراض بوجود صف أو عمود محدد في مخطط موجود:

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

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) يُعيد اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المُستخدم عندما لا تُحدَّد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يُعيّن تعبئة جديدة.

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

مثال على المخرجات لنمط المخطط الافتراضي:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين تعبئة مقلوبة لسلسلة المخطط**

بالنسبة لسلاسل الشريط والعمود والفقاعة، يمكن لـ [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertifnegative/) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل العكس، وعيّن لون القيمة السالبة من خلال [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). تظل الأرقام السالبة غير متغيرة في دفتر العمل؛ فقط لون عرضها يتغير.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 من ورقة العمل يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

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

![لون التعبئة الصلبة المقلوبة](inverted_solid_fill_color.png)

يمكنك تمكين العكس لنقطة واحدة عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). في المثال التالي، يتم تعطيل العكس للسلسلة وتفعيلها فقط للنقطة المختارة. تُعيّن النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

## **مسح قيمة نقطة بيانات معينة**

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، عيّن الخلية الداعمة في دفتر العمل إلى `null`. بالنسبة لمخطط عمود، تكون القيمة المرسومة متاحة عبر [IChartDataPoint.YValue](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/yvalue/). تظل نقطة البيانات في نفس موقع الفئة، لكن المخطط يعامل قيمتها كخالية وفقًا لإعدادات القيم الفارغة للمخطط.

المثال التالي يمسح فقط النقطة الثانية في السلسلة الأولى:

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

تستخدم المخططات النقطية خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تستدعِ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointcollection/clear/) عندما تريد الاحتفاظ بالنقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من المجموعة.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو الشرائط المتقاربة، يُعبّر عنه بنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأم وليس إلى سلسلة واحدة. عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أكثر تكثفًا.

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

![عرض الفجوة](gap_width.png)

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم السلاسل البيانية؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك دائمًا في نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية الفئات والقيم، وتستخدم المخططات النقطية قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات المطابقة لنوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأعمدة أو الشرائط المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

تحتوي [IChartSeriesGroup](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/) على سلاسل متوافقة تشترك في إعدادات التخطيط على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا تغيير المجموعة التي يتم الوصول إليها من خلال سلسلة واحدة لا يعني بالضرورة تغيير كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، يُنشئ [IShapeCollection.AddChart](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addchart/) سلاسل وعوامل وتصنيفات وعينات قيم. يمكنك تحرير تلك الخلايا أو مسح مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا استدعاء نسخة أخرى تُنشئ مخططًا دون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، وتسميات الفئات، وقيم نقاط البيانات إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/). تغيير خلية مشار إليها يُحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على توافق صفوف الفئات وصفوف قيم السلسلة بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلًا من مسح السلسلة بأكملها؟**

عيّن الخلية التي تحتوي على القيمة ذات الصلة إلى `null` للاحتفاظ بموقع الفئة كنقطة فارغة. استخدم [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapointcollection/clear/) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، قُم بتحديث كل السلاسل لتظل قيمها متطابقة مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

يعتمد الناتج على نوع المخطط وإعداد [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/displayblanksas/). يمكن للمخططات المدعومة عرض الفراغات كفجوات، أو كقيم صفرية، أو بربط النقاط المتجاورة. اختر الإعداد الذي يتوافق مع معنى فقدان البيانات في عرضك التقديمي.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة لسلاسل الشريط والعمود والفقاعة المدعومة، فعّل [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertifnegative/) وعيّن [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). يمكنك تجاوز السلوك لنقطة فردية عبر [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). تؤثر هذه الخصائص على التنسيق فقط، ولا تغير القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوّق تنسيق نقطة البيانات الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدد تنسيق السلسلة، نمط المخطط والموضوع التلقائي. خصائص المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط وليست تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض التقديمي، والذاكرة المتاحة، ووقت التصيير، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب تعديل عندما تكون الأعمدة قريبة جدًا من بعضها أو متباعدة جدًا؟**

عيّن [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) على مجموعة السلسلة الأم المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لتقريب المجموعات من بعضها.