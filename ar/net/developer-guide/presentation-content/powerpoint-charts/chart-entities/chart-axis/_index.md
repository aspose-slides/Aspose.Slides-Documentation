---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام .NET
linktitle: محور المخطط
type: docs
url: /ar/net/chart-axis/
keywords:
- محور المخطط
- محور عمودي
- محور أفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for .NET لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for .NET. تغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، رؤية المحور، فواصل تسميات الفئات وعلامات العقارب، الفئات التاريخية والتنسيق، تدوير العنوان، موضع المحور، ووحدات العرض.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

أنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وأضف مخطط منطقة ببيانات افتراضية. استدعِ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحاور لضمان تحديث تخطيط المخطط.

اقرأ [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) و[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) لحدود المحور، و[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) و[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) لفواصل العلامات. توفر [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) و[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) مقاييس الزمن، وهي ذات صلة بالمحاور التاريخية. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. تصبح كل فئة سابقة سلسلة، وتصبح كل سلسلة سابقة فئة. هذا يغيّر طريقة تجميع البيانات؛ لا يبدل المحاور الأفقية والرأسية. يستخدم المثال [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، متضمنًا صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **إلغاء تفعيل المحور الرأسي لمخططات الخط**

عيّن [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) إلى `false` على المحور الرأسي لإخفائه. ينشئ المثال مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **إلغاء تفعيل المحور الأفقي لمخططات الخط**

عيّن [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) إلى `false` على المحور الأفقي لإخفائه. ينشئ المثال مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

عيّن [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال ملف `ExistingChart.pptx`، بحيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخية رقمية من Excel. يغيّر ذلك المحور الأفقي إلى محور تاريخ. ضبط [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) إلى `false`، و[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) إلى `1`، و[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) إلى الأشهر يضع العلامات الرئيسية بفواصل شهرية.

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

عند وجود مخطط يحتوي على عدد كبير من الفئات، قلل عدد التسميات المرئية للمحور دون إزالة الفئات أو نقاط البيانات. عيّن [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) إلى `false`، ثم عيّن [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) إلى الفاصل الزمني المطلوب للفئة. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

الفاصل `3` يعرّض كل تسمية ثالثة، مع إخفاء تسميتين بين كل تسمية معروضة. لا يزيل ذلك الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يعرض بالضرورة كل تسمية.

لعلامات العقرب تحكم منفصل. عيّن [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) إلى `false` واستخدم [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) لتحديد فاصلها. على سبيل المثال، `1` يحافظ على علامة عقرب عند كل فاصل فئة بينما تظهر التسميات فقط كل فئة ثالثة. عيّن [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) إلى نمط مرئي لتتمكن من رؤية النتيجة. إعادة تعيين أي من خصائص التباعد التلقائي إلى `true` يسمح للمخطط باختيار ذلك الفاصل مرة أخرى.

المثال المستقل التالي يُنشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسمية مع علامات عقرب مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم تقديم عرض تقديمي كمدخل. يجعل نص التسمية الأفقي الفرق في الكثافة واضحًا.

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

// الشريحة 2: عرض كل تسمية ثالثة، مع الحفاظ على علامة عقرب لكل فئة.
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

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف إلى سطرين. قد يختلف النتيجة التلقائية بحسب حجم المخطط، الخطوط، أو طريقة العرض.

![تباعد تسميات الفئات التلقائي مع إظهار جميع الأعمدة الـ 24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة في سطر واحد، بينما تظل علامات العقرب عند كل فاصل فئة. جميع الأعمدة الـ 24، بما فيها تلك بدون تسميات، تظل مرئية بنفس القيم. تستعيد الشريحة 3 المظهر التلقائي المعروض أعلاه.

![فاصل تسميات الفئات اليدوي ثلاثة مع إظهار جميع الأعمدة الـ 24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل للعدد الفئوي لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خط، منطقة أو شريطي. في مخطط عمودي، يكون هو المحور الأفقي. في مخطط شريطي أفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). يطبق تباعد علامات العقرب أيضًا على محور سلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتعيين مقياس رقمي لمحور القيم. في محور القيم، يحدد [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية بـ`10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسميات الفئة بـ`3` يُحصي مواضع الفئات بغض النظر عن قيمها. تستخدم مخططات التشتت والفقاعات محاور القيم بدلاً من محور فئة نصية. للمحور التاريخي، استخدم الوحدات الرئيسية الزمنية والمقاييس كما هو موضح في [Change a Category Axis](#change-a-category-axis).

## **ضبط تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`). عيّن [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) إلى محور تاريخ، عطل [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)، وعيّن `yyyy` إلى [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) لكي تُظهر تسميات الفئة السنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

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

## **تحديد زاوية تدوير لعنوان محور المخطط**

فعّل [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) على المحور الرأسي، قدِّم نص العنوان، وعيّن [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ هذا المثال مخططًا عموديًا مع تدوير عنوان محور القيم بزاوية 90 درجة.

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

## **تحديد موضع المحور على محور الفئة أو القيم**

استخدم [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) للتحكم فيما إذا كان محور القيمة يتقاطع مع محور الفئة بين الفئات أو عند علامات الفئة. تنطبق هذه الخاصية على محاور الفئة. يعيّن المثالها إلى `true` على محور الفئة الأفقي في مخطط عمودي ويحفظ النتيجة.

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

## **ضبط وحدة العرض على محور القيم في المخطط**

عيّن [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) لتقليص حجم التسميات على محور القيم دون تغيير البيانات الأساسية. عند ضبط [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) إلى `Millions`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

## **الأسئلة المتكررة**

**كيف يمكنني تحديد القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

استخدم [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع رقمية، عيّن [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور؟**

عيّن [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`، `High`، `NextTo` أو `None`. للتحكم في علامات العقرب نفسها، استخدم [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) أو [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); هذه منفصلة عن موضع التسميات.