---
title: إدارة دفاتر عمل المخططات في العروض التقديمية في .NET
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/net/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخبئ المخطط
- استرجاع دفتر العمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: قم بإدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

هذا المقال يشرح كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. يوضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما يغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحاً.

لمعالجة خلايا دفتر العمل التي تمثل بيانات مفقودة، انظر إلى [التحكم في عرض الخلايا الفارغة](/slides/ar/net/chart-series/) للحصول على الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. عيّنه إلى `true` لرسم الخلايا الظاهرة فقط، أو إلى `false` لتضمين كل من الخلايا الظاهرة والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ لا يخفي أو يظهر صفوف أو أعمدة ورقة العمل.

يحتوي [عرض تقديمي تجريبي](hidden-source-data.pptx) على مخطط عمودي كأول شكل في شريحته الأولى. تحتوي ورقة العمل المضمّنة، `Sheet1`، على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحوي قيمًا.

| صف ورقة العمل | A: شهر | B: تجارة تجزئة | C: تجارة جملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى الخلايا المصدر من خلال [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) وقراءة [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) لفحص حالة إخفائها. هذه الخاصية للقراءة فقط. في هذا الملف، B2 ظاهر، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ يطبع المثال `False`، `True`، و`True` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمّن باستخدام [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) وأعد تحميله باستخدام [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). عند تضمين كل الخلايا، استخدم أيضًا [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزّنة في الذاكرة وتسميات الفئات في هذا النموذج.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // تحديث بيانات المخطط من دفتر العمل المضمّن.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

يحفظ المثال نسختين من العرض التقديمي: واحدة تحتوي فقط على قيم التجزئة الظاهرة (10 و20)، وأخرى تحتوي على جميع القيم الست. تم توليد الصور أدناه من العروض التقديمية المحفوظة بعد إعادة فتحها؛ كلا الملفين يحافظان على إعداد الرسم المحدد. يبقى الصف 3 والعمود C مخفيين في كل من دفاتر العمل المضمّنة.

| الخلايا الظاهرة فقط (`true`) | جميع الخلايا (`false`) |
| --- | --- |
| ![الخلايا الظاهرة فقط: قيم التجزئة 10 و20 لشهري يناير ومارس.](hidden_cells_True.png) | ![جميع الخلايا: قيم التجزئة وتجارة الجملة لشهري يناير، فبراير، ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) في طريقة عرض القيم المفقودة؛ لا يضيف أو يُزيل البيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/net/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **استعلام عن نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص النطاقات المصدر لتحديد خانات ورقة العمل التي يستخدمها كل مخطط. تُعيد طريقة [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) النطاق الحالي للبيانات كصيغة مؤهلة لورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملة. تشير علامات الدولار إلى مراجع مطلقة للصف والعمود.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل. إذا لم يستخدم المخطط دفتر عمل كمصدر بيانات، فإنها تُطلق استثناء [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). لمزيد من المعلومات، راجع [مرجع API لبيانات المخطط](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويفحص الأشكال مباشرة على كل شريحة للبحث عن المخططات. يطبع اسم كل مخطط ونطاقه المصدر. إذا لم يستخدم المخطط دفتر عمل، يطبع رسالة ويستمر إلى المخطط التالي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for .NET طريقتي [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) اللتين تسمحان بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو يجب أن يكون لها بنية مماثلة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمّن إلى تدفق، يمسح السلاسل والفئات الحالية، ويكتب نفس دفتر العمل مرة أخرى. تظل التغييرات في الذاكرة؛ لا يحفظ المثال العرض التقديمي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **تحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بالسلاسل ومجموعات الفئات الأصلية. قد يتسبب هذا الاختلاف في فشل [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) مع خطأ "index-out-of-range". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. تُظهر التعليقات الموضع الذي سيتم فيه تعديل دفتر العمل؛ يكتب المثال دفتر العمل الأصلي مرة أخرى ويُصحّح التخطيط في الذاكرة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // تعديل تدفق دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

إزالة المجموعات تُزيل مراجع البيانات البالية قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تعيينات فئات مطلوبة للدفتر المحدث قبل استخدام المخطط.

## **تعيين تنسيقات رقمية مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) للتحكم في كيفية ظهور القيم الرقمية في دفتر عمل المخطط المضمّن. على سبيل المثال، قد يحتاج التقرير إلى عرض معدل التحويل كنسبة مئوية بأربع منازل عشرية ومعامل بخمس منازل عشرية. احتفظ بالقيمتين كأرقام لتبقى متاحة للحسابات ورسم المخطط.

تغيّر صيغة الرقم العرض فقط، ولا تغير القيمة المخزّنة. الصيغة `0.0000%` تُظهر `0.125` كـ `12.5000%`؛ لا تستبدل العدد المخزّن بـ `12.5`. بالمثل، الصيغة `0.00000` تُظهر `0.1234567` كـ `0.12346` دون تقريب القيمة المخزّنة. إذا كانت الصيغة المخصصة سلسلة فارغة (`""`)، يُستخدم [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) بدلاً منها.

ينشئ المثال التالي مخططًا عموديًا ويصل إلى خلاياه عبر [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلا الخليتين تزودان المخطط بالقيم. يُفعّل المثال أيضًا تسميات القيم المرتبطة بصيغ المصدر.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات التي تُضبط مباشرة على محاور المخطط أو تسميات البيانات. في هذا المثال، تُظهر كل تسيمة قيمتها من الخلية المصدر لأن [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) مفعلة، وتتبع صيغة الرقم المصدر لأن [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) = `true`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر التسميات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي صيغته الخاصة [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) بـ `0.00`، مع [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) = `false`.

لتنسيق تسمية بيانات بشكل مستقل، قم بتعطيل علم الارتباط بالمصدر (`false`) وعيّن [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). لا يغيّر هذا تنسيق خلية دفتر العمل. على سبيل المثال، تنسيق تسمية مستقل بـ `0.00` يعرض القيمة الأولى كـ `0.13`، بينما لا يزال B2 يعرض `12.5000%`. راجع [تسميات بيانات المخطط](/slides/ar/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق التسميات مباشرة.

![مخطط عمودي مع تسميات مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور عددي مُنسق بشكل مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر عمل كعلامة بيانات للمخطط**

يمكنك استخدام نص من خلايا دفتر العمل كعلامات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للملصقات الثلاث الأولى في السلسلة الأولى، يفعّل الملصقات من الخلايا، ويحفظ العرض التقديمي المُحدَّث.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **إدارة أوراق العمل**

توفر خاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل على وحدة التحكم.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **تحديد نوع مصدر البيانات**

يمكن أيضًا تخزين قيم نقاط السلسلة مباشرة كقيم رقمية ثابتة. راجع [تعيين قيم السلسلة باستخدام قيم رقمية ثابتة](/slides/ar/net/chart-series/#set-series-values-using-numeric-literals) للحصول على مثال كامل يحفظها ويقرأها. نوع مصدر القيم منفصل عن تكوين دفتر العمل الداخلي أو الخارجي للمخطط؛ استخدام القيم الرقمية الثابتة لا يزيل دفتر العمل المضمّن بحد ذاته.

ينشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويُعيّن اسمين للسلسلة باستخدام مصادر بيانات مختلفة. يستخدم الاسم الأول قيمة نصية ثابتة؛ الثاني يستخدم الخلية C1 في ورقة العمل 0. تحدد تعداد [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) مصدر كل اسم. يحفظ المثال العرض التقديمي بأسماء السلاسل المحدثة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **كشف صيغ دفاتر العمل المضمّنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام خاصية [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) على [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) لاكتشاف الصيغ غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // قراءة أو تعديل بيانات دفتر العمل للمخطط المدعومة هنا.
}
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدّر دفتر عمله. يغلق تدفق الإخراج قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض التقديمي المرتبط.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من عدم إمكانية تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر العمل الخارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي حيث تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لتعيين A1:B4 كسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

معامل `updateChartData` في طريقة [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) يتحكم فيما إذا كان دفتر العمل سيتم تحميله.

* عندما تكون `updateChartData` = `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متاح.
* عندما تكون `updateChartData` = `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

يعين المثال التالي عنوان URL نائب مع `updateChartData` = `false`. يحتفظ ببيانات المخطط الافتراضية للمخطط الدائري ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **الحصول على مسار دفتر العمل الخارجي لمصدر البيانات لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخرج مسار دفتر العمل.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان شكلًا مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتوى دفاتر العمل الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يُطلق استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بدفتر عمل خارجي قابل للوصول. يعيّن القيمة المدعومة بالخلية لأول نقطة بيانات في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المُحدَّث. يمكن أن يؤدي تحرير قيم الخلايا إلى تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت تحتاج إلى الحفاظ على دفتر العمل الأصلي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **استعادة دفتر عمل من ذاكرة مخطط التخزين المؤقت**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزّنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)، وضبط [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)، وعين [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) إلى `true` قبل فتح العرض التقديمي.

يستعيد المثال التالي بيانات دفتر العمل لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يَنفُذ الوصول إلى البيانات المستعادة عبر [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // قراءة أو تعديل بيانات دفتر العمل المسترد هنا.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُطلق Aspose.Slides استثناءً من نوع [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). فعل الاستعادة فقط عندما يكون الاعتماد على بيانات المخطط المخزّنة مؤقتًا حلاً مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على تغييرات تم إجراؤها على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مضمّن؟**

نعم. للمخطط نوع مصدر بيانات ([data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)) ومسار إلى دفتر عمل خارجي ([path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/))؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). يمكن أن يؤدي تحرير بيانات المخطط المدعومة بالخلية أيضًا إلى تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان من الضروري ترك الأصلي دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. يُنصح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/net/)) والربط بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا أشاروا جميعًا إلى نفس الملف، سيُعكس تحديث ذلك الملف في كل مخطط عند تحميل البيانات مرة أخرى.