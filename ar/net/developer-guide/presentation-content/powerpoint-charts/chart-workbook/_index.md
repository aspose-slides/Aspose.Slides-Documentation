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
- ذاكرة مخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كتسميات بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرداد مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

للخلايا التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/net/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) للتحكم فيما إذا كان المخطط يرسم بيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا المرئية فقط، أو على `false` لتضمين كل من الخلايا المرئية والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ ولا يخفي أو يظهر صفوف أو أعمدة ورقة العمل.

[عرض تقديمي تجريبي](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في الشريحة الأولى. ورقة العمل المضمّنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) وقراءة [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) لفحص حالتها المخفية. هذه الخاصية للقراءة فقط. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمّن باستخدام [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) وأعد تحميله باستخدام [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). عند تضمين كل الخلايا، استخدم أيضًا [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة لا يكفي لتحديث بيانات المخطط المخزنة في الذاكرة وعناوين الفئات لهذا المثال.

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
            // استعادة نطاق المصدر الكامل، بما في ذلك الفئات المخفية.
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

يحفظ المثال نسختين من العرض التقديمي: واحدة تحتوي فقط على قيم التجزئة المرئية (10 و20)، وأخرى تحتوي على جميع القيم الست. الصور أدناه تم توليدها من العروض التقديمية المحفوظة بعد إعادة فتحها؛ كلتا الملفين تحافظان على إعداد الرسم المحدد. يظل الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمّنَين.

| الخلايا المرئية فقط (`true`) | كل الخلايا (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) في طريقة عرض القيم المفقودة؛ ولا يشمل أو يستثني البيانات المصدر المخفيّة. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/net/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **استرداد نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، تحقق من نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُرجع طريقة [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) النطاق الحالي للبيانات كصيغة مؤهلة للورقة، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم الورقة، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع مطلقة للصف والعمود.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل. إذا لم يستخدم المخطط دفتر عمل كمصدر للبيانات، فإنها ترمي استثناءًا من نوع [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). لمزيد من المعلومات، راجع [مرجع ChartData API](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

يفتح هذا المثال عرض تقديمي ويفحص الأشكال مباشرة على كل شريحة للبحث عن المخططات. يطبع اسم كل مخطط ونطاق المصدر الخاص به. إذا لم يستخدم المخطط دفتر عمل، فإنه يطبع رسالة ويستمر إلى المخطط التالي.

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

يوفر Aspose.Slides for .NET الطريقتين [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) اللتين تسمحان بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط محررة باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرض تقديمي يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمّن إلى تدفق، يمسح السلاسل والفئات الحالية، ثم يكتب نفس دفتر العمل مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

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

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعاته الفئوية الأصلية. هذا الاختلاف قد يؤدي إلى فشل [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) بخطأ "فهرس خارج النطاق". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى المخطط. يستخدم هذا المثال مخططًا كأول شكل في الشريحة الأولى. يوضح التعليق مكان تحرير دفتر العمل؛ المثال القابل للتنفيذ يكتب دفتر العمل الأصلي مرة أخرى ويُحقق من التخطيط في الذاكرة.

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

    // عدل تدفق دفتر العمل هنا، على سبيل المثال، باستخدام Aspose.Cells.

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

يمسح مسح المجموعات البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تعيينات فئات مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين تنسيقات رقمية مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) للتحكم في طريقة عرض القيم العددية في دفتر عمل المخطط المضمّن. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربعة منازل عشرية ومعامل بخمسة منازل عشرية. احتفظ بالقيمتين كعددية لتظل متاحة للحسابات ورسم المخطط.

تنسيق العدد يغيّر طريقة العرض فقط، لا القيمة المخزنة. التنسيق `0.0000%` يعرض `0.125` كـ `12.5000%`؛ ولا يستبدل العدد المخزن بـ `12.5`. بالمثل، `0.00000` يعرض `0.1234567` كـ `0.12346` دون تعديل القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستخدم [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) بدلًا من ذلك.

المثال التالي ينشئ مخططًا عموديًا ويصل إلى خلاياه عبر [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). في ورقة العمل 0، تحتوي B2 على معدل التحويل وC2 على المعامل. كلا الخليتين تزودان المخطط بالقيم. يُفعل المثال أيضًا تسميات القيم المرتبطة بتنسيقات المصدر.

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

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات التي تُضبط مباشرة على محاور المخطط أو تسميات البيانات. في هذا المثال، كل تسمية تعرض قيمة خلية المصدر لأنها مفعلة عبر [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) وتستخدم تنسيق الرقم المصدر لأن [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) قيمتها `true`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر التسميات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي تنسيقه الخاص [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) وهو `0.00`، مع ضبط [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) إلى `false`.

لتنسيق تسمية بيانات بشكل مستقل، قم بإلغاء ربطها بالمصدر (`false`) وعين لها [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). لا يغيّر هذا تنسيق خلية دفتر العمل. على سبيل المثال، تنسيق تسمية مستقل `0.00` يعرض القيمة الأولى كـ `0.13`، بينما لا تزال B2 تُظهر `12.5000%`. راجع [تسميات بيانات المخطط](/slides/ar/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق التسميات مباشرة.

الصورة أدناه تم توليدها من العرض التقديمي المحفوظ بعد إعادة فتحه:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **تعيين خلية دفتر عمل كعلامة بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعلامات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعات ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للثلاث تسميات الأولى في السلسلة الأولى، يفعِّل العلامات من الخلايا، ثم يحفظ العرض التقديمي المحدث.

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

توفر الخاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) وصولًا إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

ينشئ هذا المثال مخطط عمود ثلاثي الأبعاد ببيانات افتراضية ويعيّن اسمين للسلاسل باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قيمة نصية ثابتة؛ والثاني يستخدم الخلية C1 في ورقة العمل 0. يختار التعداد [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي مع أسماء السلاسل المحدثة.

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

## **الكشف عن صيغ دفاتر العمل المضمنة غير المدعومة**

لا يدعم Aspose.Slides صيغ دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام الخاصية [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) على [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) لتحديد الصيغ غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال الأشكال على الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

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

    // اقرأ أو عدل بيانات دفتر عمل المخطط المدعومة هنا.
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدّر دفتر عمله. يغلق تدفق الإخراج قبل تعيين دفتر العمل الخارجي كمصدر للبيانات، ثم يحفظ العرض التقديمي المرتبط.

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

باستخدام طريقة [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الملف).

على الرغم من أنه لا يمكن تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تحتوي ورقة عمله المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم عددية في B2:B4. يُنشئ مثالًا لمخطط دائري، يربط الدفتر، ويستخدم [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لربط النطاق A1:B4 بسلسلة واحدة وثلاث فئات. ثم يحفظ العرض التقديمي بالمخطط المرتبط.

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

معامل `updateChartData` في [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) يتحكم فيما إذا كان دفتر العمل سيتم تحميله.

* عندما يكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `updateChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

المثال التالي يعيّن عنوان URL نائب مع `updateChartData` مضبوطة على `false`. يحتفظ بالمخطط الدائري ببياناته الافتراضية ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر العمل المصدر الخارجي للمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق ما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخرج مسار دفتر العمل.

يفحص هذا المثال أول شكل في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان المخطط مرتبطًا بدفتر عمل خارجي، يطبع [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجرى بها تغييرات على محتويات الدفاتر الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُرمى استثناء.

يستخدم هذا المثال مخططًا كأول شكل في الشريحة الأولى ومرتبطًا بدفتر عمل خارجي يمكن الوصول إليه. يعيّن القيمة المدعومة بالخلية للنقطة البيانات الأولى في السلسلة الأولى إلى `100` ويحفظ العرض التقديمي المحدث. تحرير قيم الخلايا قد يحدث تحديثًا للملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة للحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر عمل من ذاكرة مخطط البيانات**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)، واضبط [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)، ثم عيّن [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) إلى `true` قبل فتح العرض التقديمي.

المثال التالي بلغة C# يستعيد بيانات دفتر العمل لمخطط كأول شكل في الشريحة الأولى ويشير إلى دفتر عمل غير متاح. يصل إلى البيانات المستعادة عبر [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // اقرأ أو عدل بيانات دفتر العمل المستعاد هنا.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

إذا كان دفتر العمل الخارجي غير متاح وتعطيل الاستعادة، يرمي Aspose.Slides استثناءً من نوع [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). فعّل الاستعادة فقط عندما يكون الاعتماد على بيانات المخطط المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني معرفة ما إذا كان مخطط معين مرتبط بدفتر عمل خارجي أم مضمّن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و[مسار دفتر العمل الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تُدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف تُخزّن؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكية؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يُعيد Aspose.Slides كتابة ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

العرض التقديمي يخزن [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). تحرير بيانات المخطط المدعومة بالخلية قد يُحدّث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان الأصل يجب أن يظل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا يقبل كلمة مرور عند الربط. يُفضَّل إزالة الحماية مسبقًا أو إعداد نسخة غير مُشفَّرة (مثلاً باستخدام [Aspose.Cells](https://reference.aspose.com/cells/net/)) وربطها.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. لكل مخطط رابط خاص به. إذا كانت جميعها تشير إلى نفس الملف، فإن تحديث هذا الملف سيظهر في كل مخطط عند تحميل البيانات مرة أخرى.