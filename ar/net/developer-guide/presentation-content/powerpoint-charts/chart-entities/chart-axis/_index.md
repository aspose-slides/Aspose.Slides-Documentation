---
title: تخصيص محاور المخططات في العروض التقديمية في .NET
linktitle: محور المخطط
type: docs
url: /ar/net/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة العظمى
- القيمة الصغرى
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for .NET لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخططات باستخدام Aspose.Slides for .NET. تتناول القيم المحسوبة للمحاور، تبديل صفوف الأعمدة في المخطط، إظهار وإخفاء المحاور، فترات فواصل علامات الفئات والفواصل، الفئات التاريخية وتنسيقها، دوران العنوان، موضع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

أنشئ [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وأضف مخطط منطقة ببيانات افتراضية. استدعِ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحور لضمان أن تخطيط المخطط محدث.

اقرأ [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) و[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) لحدود المحور، و[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) و[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) لفواصل العلامات. توفر [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) و[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) مقاييس الوحدات الزمنية، وهي ذات صلة بمحاور التاريخ. تخزن الأمثلة هذه القيم في متغيرات محلية وتحفظ المخطط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **تبديل البيانات بين المحاور**

استخدم [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغير هذا طريقة تجميع البيانات؛ لا يُبدل المحاور الأفقية والعمودية. يستخدم المثال [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5` بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يُحفظ مخطط بأربع سلاسل وثلاث فئات.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **عكس ترتيب رسم محور**

استخدم [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) لعكس محور فئة أو قيمة. على سبيل المثال، يمكن لمخطط شريط أفقي عرض مراحل المشروع من الأعلى إلى الأسفل بالترتيب نفسه كما في ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ لا يقوم بفرز أو إعادة ترتيب بيانات المصنف. بالمقابل، يقوم [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) بتبادل أدوار السلاسل والفئات.

ينشئ المثال التالي مخطط شريط أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرايح: الترتيب الطبيعي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويُعكَس محور واحد فقط في كل نسخة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// الشريحة 2: عرض الفئة الأولى في الأعلى.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// إبقاء محور القيمة الأفقي في الأسفل.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// الشريحة 3: عكس مقياس الأرقام الأفقي فقط.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

يمكن لعكس محور أيضًا نقل المحور المتقاطع إلى الجانب المقابل من الرسم. يتحكم [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) في مكان تقاطع المحور الآخر مع المحور المُكوَّن. في الشريحة 2، ضبطه على `Maximum` على محور الفئة المعكوس يجعل محور القيمة الأفقي يبقى في الأسفل. لتحديد نقطة تقاطع معينة، استخدم [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصةً إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. اضبط `IsPlotOrderReversed` مرة أخرى إلى `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب الطبيعي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريط أفقي بالترتيب الطبيعي للفئة والمحور القيمي](axis-order-normal.png) | ![مخطط شريط أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريط أفقي مع محور قيمة معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تتزايد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لم يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تتزايد من اليمين إلى اليسار. يتقاطع محور الفئة عند الصفر على اليمين. |

## **إخفاء المحور العمودي في المخططات الخطية**

اضبط [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) إلى `false` على المحور العمودي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور العمودي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **إخفاء المحور الأفقي في المخططات الخطية**

اضبط [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) إلى `false` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **تغيير محور الفئة**

اضبط [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، يحتوي على مخطط كأول شكل في الشريحة الأولى وخلايا الفئة تحتوي على قيم تاريخية رقمية من Excel. يغيّر المحور الأفقي إلى محور تاريخ. اضبط [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) إلى `false`، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) إلى `1`، و[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) إلى أشهر لتحديد الفواصل الشهرية للعلامات الرئيسية.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود many فئات في المخطط، قلّل عدد تسميات المحور الظاهرة دون حذف الفئات أو نقاط البيانات. اضبط [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) إلى `false`، ثم اضبط [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) إلى الفاصل الفئوي المطلوب. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، … الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، … الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، … الفئة 22 |

يعرض الفاصل `3` كل تسمية ثالثة، مع إخفاء اثنتين بين كل تسمية مرئية. لا يزيل الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ لا يُظهر بالضرورة كل تسمية.

للعلامات الفاصلة تحكم منفصل. اضبط [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) إلى `false` واستخدم [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة فاصلة عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. اضبط [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) إلى نمط مرئي لتتمكن من رؤية النتيجة. إرجاع أي خاصية تباعد تلقائي إلى `true` يسمح للمخطط باختيار الفاصل مرة أخرى.

ينشئ المثال المستقل التالي 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرايح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسميات مع علامات فاصلة مستقلة، وإعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي كدخل. يجعل نص التسميات الأفقي الاختلاف في الكثافة واضحًا.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// الشريحة 2: إظهار كل تسمية ثالثة، مع الحفاظ على علامة فاصلة لكل فئة.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// الشريحة 3: السماح للمخطط باختيار الفواصل مرة أخرى.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُظهر كل تسمية فئة ثانية وتُلف إلى سطرين. قد يختلف الناتج التلقائي بحسب حجم المخطط، الخطوط، وعميل العرض.

![تباعد تلقائي لتسميات الفئة مع ظهور جميع الأعمدة الـ24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُظهر كل تسمية ثالثة على سطر واحد، بينما تبقى علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ24، بما فيها التي بدون تسميات، تظل مرئية بنفس القيم. الشريحة 3 تعيد الشكل التلقائي المعروض أعلاه.

![تباعد يدوي لتسمية الفئة بثلاثة مع ظهور جميع الأعمدة الـ24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيحين**

استخدم هذا الفاصل لعدد الفئات لمحور فئة نصية، مثل محور الفئة في مخطط عمودي أو خطي أو مساحي أو شريطي. في المخطط العمودي، يكون هو المحور الأفقي. في المخطط الشريطي الأفقي، يكون محور الفئة عموديًا، لذا يتم تطبيق هذه الإعدادات على [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). ينطبق تباعد علامات الفواصل أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتحديد مقياس عددية للمحور القيمي. في محور القيم، يحدد [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية مقدارها `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. بينما فاصل تسمية الفئة `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيمية بدلاً من محور فئة نصية. للمحور التاريخي، استخدم وحدات زمنية رئيسية ومقاييس كما هو موصوف في [تغيير محور الفئة](#تغيير-محور-الفئة).

## **تحديد تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية لـ OLE Automation في ورقة العمل الأولى (الفهرس `0`). اضبط [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) إلى محور تاريخ، عطل [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)، وعيّن `yyyy` إلى [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) لجعل تسميات الفئة تُظهر السنوات ذات الأربع أرقام بشكل مستقل عن تنسيق الخلية.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **تعيين زاوية دوران لعنوان محور المخطط**

فعّل [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) على المحور العمودي، قدِّم نص العنوان، واضبط [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططًا عموديًا مع عنوان محور القيمة مدورًا بـ 90 درجة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **تحديد موضع المحور على محور الفئة أو القيمة**

استخدم [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) للتحكم فيما إذا كان محور القيمة يتقاطع مع محور الفئة بين الفئات أو عند علامات الفئات. تُطبق هذه الخاصية على محاور الفئة. يضبط المثال الخاصية إلى `true` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **تعيين وحدة العرض على محور قيمة المخطط**

اضبط [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) لتكبير أو تصغير التسميات على محور قيمة دون تعديل البيانات الأساسية. مع ضبط [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) إلى `Millions`، تُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره العمودي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **تهيئة محور قيمة لوغاريتمي**

يكون محور القيمة اللوغاريتمي مفيدًا عندما تتراوح القيم الموجبة عبر عدة ترتيبات من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. يسهّل المقياس اللوغاريتمي مقارنة النمو النسبي: تمثل المسافات المتساوية نسبًا متساوية بدلاً من فروق متساوية.

اضبط [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) إلى `true` على محور القيمة واستخدم [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) لاختيار الأساس. يغيّر هذا طريقة عرض القيم الحالية؛ لا يُغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو ميزة مستقلة.

### **اختر محور القيمة والأساس**

في مخطط خطي أو عمودي، يكون محور القيمة هو [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). في المخطط الشريطي الأفقي، يكون هو [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). للمخططات المتناثرة والفقاعية هناك محوران قيميان؛ اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كلاهما. لا تُطبّق القياس اللوغاريتمي على محور الفئة.

الأساس اللوغاريتمي الافتراضي هو `10`. بالنسبة لمخططات PPTX، يمكن استخدام أساس من `2` إلى `1000` شاملًا؛ كما تُدعم الأساسات الكسرية مثل `2.5`. باستخدام الأساس `10`، تكون القوى المتتالية مثل 10، 100، 1,000، و10,000 متباعدة بالتساوي.

### **قارن بين القياس الخطي واللوغاريتمي**

ينشئ المثال المستقل التالي مخططًا خطيًا بأعداد الطلبات الخمسة على الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي للأساس 10 على الشريحة الثانية. تحتفظ الشريحتان بنفس البيانات.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// احتفظ بالشرائح الأولى خطيًا وقم بتغيير مقياس محور القيمة فقط في النسخة.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**القياس الخطي (الشريحة 1):** تمثل المسافات الرأسية المتساوية فروقًا متساوية في عدد الطلبات. تُهيمن القيمة الأكبر على المخطط، مما يجعل القيم الأصغر صعوبة في التمييز.

![مخطط خطي في PowerPoint يُظهر خمس طلبات على محور قيمة خطي](value-axis-linear.png)

**القياس اللوغاريتمي (الشريحة 2):** تمثل المسافات الرأسية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف الطلبات مقارنةً بالفترة السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس الأساس 10. لا تزال تسميات المحور تظهر عدد الطلبات الأصلي.

![نفس خمس طلبات في PowerPoint على محور قيمة لوغاريتمي للأساس 10](value-axis-logarithmic.png)

### **التعامل مع الصفر والقيم السلبية**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة صstrict فقط. تحقّق من البيانات قبل تفعيلها. إذا كان الصفر أو القيم السلبية ذات معنى، احتفظ بالقياس الخطي أو اعرضها منفصلًا. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسِّر الإزالة. لا تستبدلها صامتًا بأرقام صغيرة موجبة، لأن ذلك يغيّر معنى البيانات. يجب أن تكون أي قيمة دنيا أو قصوى مضبوطة يدويًا للمحور اللوغاريتمي موجبة أيضًا.

## **الأسئلة المتداولة**

**كيف يمكنني تحديد القيمة التي يقطع عندها أحد المحاور الآخر (تقاطع المحاور)؟**

استخدم [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع عددية، اضبط [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات نسبةً إلى المحور؟**

اضبط [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) أو [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); هذه مستقلة عن موضع التسميات.