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
- التعامل مع المحور
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
description: "اكتشف كيف تستخدم Aspose.Slides لـ .NET لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والمرئيات."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for .NET. تغطي القيم المحسوبة للمحور، وتبديل صفوف وأعمدة المخطط، ورؤية المحور، وفواصل تسميات الفئات وعلامات التدريج، وفئات التاريخ وتنسيقها، وتدوير العنوان، وتحديد موضع المحور، ووحدات العرض، والقياس اللوغاريتمي.

## **احصل على القيم القصوى على المحور الرأسي في المخططات**

قم بإنشاء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وإضافة مخطط مساحة ببيانات افتراضية. استدعِ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحور لضمان أن تخطيط المخطط محدث.

اقرأ [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) و[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) للحصول على حدود المحور، و[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) و[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) لفواصل العلامات. توفر [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) و[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) مقاييس الوحدات الزمنية، وهي ذات صلة بالمحاور التاريخية. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ ولا يبدّل المحاور الأفقية والرأسية. يستخدم المثال [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ المخطط بأربع سلاسل وثلاث فئات.

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

## **تعطيل المحور الرأسي للرسوم الخطية**

قم بتعيين [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) إلى `false` على المحور الرأسي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **تعطيل المحور الأفقي للرسوم الخطية**

قم بتعيين [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) إلى `false` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

قم بتعيين [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخية عددية من Excel. يغيّر المحور الأفقي إلى محور تاريخي. ضبط [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) إلى `false`، و[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) إلى `1`، و[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) إلى أشهر يضع العلامات الرئيسية على فواصل شهرية.

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

عندما يحتوي المخطط على العديد من الفئات، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. اضبط [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) إلى `false`، ثم اضبط [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) إلى الفاصل الفئوي المطلوب. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، بحيث يبقى بين كل تسميتين اثنتان مخفيتان. لا يتم حذف الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يضمن عرض كل تسمية.

علامات التدريج لها تحكم منفصل. اضبط [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) إلى `false` واستخدم [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) لتعيين فاصلها. على سبيل المثال، `1` يحافظ على علامة تدريج في كل فاصل فئة بينما تظهر التسميات فقط كل فئة ثالثة. اضبط [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) إلى نمط مرئي لتتمكن من رؤية النتيجة. إعادة تعيين أي من خصائص التباعد التلقائي إلى `true` يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في ملف `CategoryAxisIntervals.pptx`: التباعد التلقائي، تباعد التسميات يدويًا مع علامات تدريج مستقلة، وإعادة التباعد التلقائي. النسختان تحافظان على بيانات المخطط الأصلية. لا يلزم عرض تقديمي مدخل. يجعل نص التسمية الأفقي الفرق في الكثافة واضحًا.

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

// الشريحة 2: إظهار كل تسمية ثالثة، ولكن الحفاظ على علامة تدريج لكل فئة.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتُكّسّ على سطرين. قد يختلف الناتج التلقائي حسب حجم المخطط، الخطوط، وعامل العرض.

![تباعد تسميات الفئة تلقائيًا مع رؤية جميع الأعمدة الـ24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تظل علامات التدريج في كل فاصل فئة. جميع 24 عمودًا، بما في ذلك تلك التي لا تحتوي على تسميات، تظل مرئية بنفس القيم. تستعيد الشريحة 3 المظهر التلقائي المعروض أعلاه.

![تباعد يدوي لتسميات الفئة بثلاثة مع رؤية جميع الأعمدة الـ24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل القائم على عدد الفئات لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خطي، مساحي أو شريطي. في المخطط العمودي، يكون هو المحور الأفقي. في المخطط الشريطي الأفقي، يكون محور الفئة رأسيًا، لذا طبّق هذه الإعدادات على [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). ينطبق تباعد علامات التدريج أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لضبط المقياس الرقمي لمحور القيمة. على محور القيمة، يحدد [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) الفرق بين القيم: على سبيل المثال، وحدة رئيسية مقدارها `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعد مواضع الفئات بدلًا من قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيمة بدلاً من محور فئة نصية. لمحور التاريخ، استخدم الوحدات الرئيسية القائمة على الوقت والمقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام مسلسل OLE Automation في ورقة العمل الأولى (الفهرس `0`). اضبط [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) إلى محور تاريخي، عطل [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)، وعين `yyyy` إلى [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) حتى تُظهر تسميات الفئة السنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

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

فعّل [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) على المحور الرأسي، وفر نصًا للعنوان، واضبط [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططًا عموديًا مع عنوان محور القيمة مدورًا بمقدار 90 درجة.

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

## **تعيين موضع المحور على محور الفئة أو القيمة**

استخدم [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. تُطبق هذه الخاصية على محاور الفئة. يضبط المثال هذه الخاصية إلى `true` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

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

قم بتعيين [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) لتكبير تسميات محور القيمة دون تغيير البيانات الأساسية. عندما يكون [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) مُعيّنًا إلى `Millions`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

## **تكوين محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة مرتبة من الحجم. على سبيل المثال، قد تتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا على مدار خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة بالقرب من الصفر. يجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: تمثل المسافات المتساوية نسبًا متساوية بدلًا من فروقًا متساوية.

اضبط [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) إلى `true` على محور القيمة واستخدم [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ ولا يغيّر البيانات أو يضيف خط اتجاه لوغاريتمي. يمثل خط الاتجاه علاقة مُناسبة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

في مخطط خطي أو عمودي، يكون محور القيمة هو [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). في المخطط الشريطي الأفقي، يكون هو [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). للمخططات التشتتية والفقاعية محوران للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كليهما. لا تطبق القياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. للمخططات PPTX، استخدم قاعدة من `2` إلى `1000` شاملة؛ القواعد الكسرية مثل `2.5` مدعومة أيضًا. مع القاعدة `10`، تكون القوى المتتابعة مثل 10، 100، 1,000، و10,000 متساوية المسافات.

### **قارن بين القياس الخطي واللوغاريتمي**

ينشئ المثال المستقل التالي مخططًا خطيًا يحتوي على خمس عدادات طلب في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشرحتين بنفس البيانات.

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

// حافظ على الشريحة الأولى خطية وقم بتغيير مقياس محور القيمة للنسخة فقط.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**المقياس الخطي (الشريحة 1):** تمثل المسافات العمودية المتساوية فروقًا متساوية في عدد الطلبات. هيمن القيمة الأكبر على المخطط، مما يصعب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمس عدادات طلب على محور قيمة خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تمثل المسافات العمودية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف عدد الطلبات مقارنةً بالفترة السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على المقياس القاعدي 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس خمس عدادات الطلب في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **التعامل مع القيم صفر والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السالبة ذات معنى، حافظ على مقياس خطي أو أظهرها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسر السبب. لا تستبدلها صامتًا بأرقام صغيرة موجبة، لأن ذلك يغير معنى البيانات. يجب أن تكون أي حد أدنى أو أقصى يُضبط يدويًا لمحور لوغاريتمي إيجابيًا أيضًا.

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحور)؟**

استخدم [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع عددية، اضبط [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**

اضبط [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات التدريج نفسها، استخدم [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) أو [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); هذه منفصلة عن تحديد موضع التسميات.