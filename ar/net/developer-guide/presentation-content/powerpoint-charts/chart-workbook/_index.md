---
title: إدارة دفاتر عمل المخططات في العروض التقديمية على .NET
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
- ذاكرة مخطط مؤقتة
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

يشرح هذا المقال كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. يوضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما يغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بالمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [Control the Display of Empty Cells](/slides/ar/net/chart-series/) للحصول على الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا المرئية فقط، أو `false` لتضمين كل من الخلايا المرئية والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ لا يخفي أو يظهر صفوف أو أعمدة ورقة العمل.

يحتوي [sample presentation](hidden-source-data.pptx) على مخطط عمودي كأول قالب في شريحته الأولى. تحتوي ورقة العمل المضمنة، `Sheet1`، على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: البيع بالتجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) وقراءة [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) للتحقق من حالة الإخفاء. هذه الخاصية للقراءة فقط. في هذا الملف، B2 مرئي، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ يطبع المثال `False`، `True`، و`True` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمن باستخدام [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) وأعد تحميله باستخدام [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). عند تضمين كل الخلايا، استخدم أيضًا [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وتسميات الفئات في هذا المثال.

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

        // تحديث بيانات المخطط من دفتر العمل المضمن.
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

يحفظ المثال نسختين من العرض التقديمي: واحدة تحتوي فقط على قيم البيع بالتجزئة المرئية (10 و20)، والأخرى تحتوي على جميع القيم الست. تم إنشاء الصور أدناه من العروض التقديمية المحفوظة بعد إعادة فتحها؛ كل من الملفين يحافظ على إعداد الرسم المعين. يظل الصف 3 والعمود C مخفيين في كلٍ من دفاتر العمل المضمنة.

| فقط الخلايا المرئية (`true`) | كل الخلايا (`false`) |
| --- | --- |
| ![الخلايا المرئية فقط: قيم البيع بالتجزئة 10 و20 لشهري يناير ومارس.](hidden_cells_True.png) | ![كل الخلايا: قيم البيع بالتجزئة والجملة لشهري يناير وفبرruary ومارس.](hidden_cells_False.png) |

خلية مخفية تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) في طريقة عرض القيم المفقودة؛ لا يضيف أو يستثني بيانات المصدر المخفية. راجع [Control the Display of Empty Cells](/slides/ar/net/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **استرجاع نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، تحقق من نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُرجع طريقة [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) النطاق الحالي للبيانات كمعادلة مؤهلة للورقة، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم الورقة، و`!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع مطلقة للصف والعمود.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل. إذا لم يستخدم المخطط دفتر عمل كمصدر للبيانات، فإنها تُطرح استثناء [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). لمزيد من المعلومات، راجع [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويفحص القوالب مباشرة على كل شريحة للبحث عن مخططات. يطبع اسم كل مخطط ونطاق المصدر. إذا لم يستخدم المخطط دفتر عمل، يطبع رسالة ويستمر إلى المخطط التالي.

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

توفر Aspose.Slides for .NET طرقًا مثل [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) تسمح لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب تنظيمها بنفس الطريقة أو أن تكون ذات بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول قالب في شريحته الأولى. يقرأ دفتر العمل المضمن إلى تدفق، يمسح السلاسل والفئات الحالية، ويعيد كتابة دفتر العمل نفسه. تظل التغييرات في الذاكرة؛ لا يحفظ المثال العرض التقديمي.

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

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعات فئاته الأصلية. قد يتسبب هذا الاختلاف في فشل [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) مع خطأ "فهرس خارج النطاق". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى المخطط. يستخدم هذا المثال مخططًا هو القالب الأول على الشريحة الأولى. العلامة التعليقية توضح أين سيُجرى تعديل دفتر العمل؛ يكتب المثال القابل للتنفيذ دفتر العمل الأصلي مرة أخرى ويُحقق من التخطيط في الذاكرة.

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

    // عدّل تدفق دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

يمسح مسح المجموعات المراجع القديمة للبيانات قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تعيينات فئة مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **اختيار طريقة تخزين تسميات الفئات**

عيّن [IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/) على مجموعة الفئات الفارغة قبل إضافة التسميات. استخدم خلايا ورقة العمل للتسميات التي تشير إلى بيانات دفتر العمل أو تُشكل هيكلًا هرميًا، مثل الأرباع المجمعة حسب السنة. استخدم النصوص الحرفية لتسميات من مستوى واحد لا تحتاج مراجع خلايا. يُطبق هذا الإعداد على الفئات فقط. يستخدم كلا المخططين أدناه خلايا ورقة العمل لقيم السلسلة الرقمية.

ينشئ المثال مخططين عموديين ويطبع `Q1 Q2 Q3 Q4` لكلٍ منهما، إلى جانب وضع التخزين الخاص به. لتسميات مدعومة من ورقة العمل، يوفّر [IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/) الوصول إلى الخلية الأساسية و[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) تُعيد تسميتها. للتسميات الحرفية، اقرأ السلسلة مباشرة من [IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **تعيين تنسيقات رقمية مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) للتحكم في طريقة ظهور القيم الرقمية في دفتر العمل المضمن للمخطط. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربع منازل عشرية ومعامل بخمسة منازل عشرية. حافظ على كِلا القِيَمَين كقِيَم رقمية لتظل متاحة للحسابات ورسم المخطط.

تنسيق الرقم يغيّر طريقة العرض فقط، ولا يغيّر القيمة المخزنة. يعرض التنسيق `0.0000%` القيمة `0.125` كـ `12.5000%`؛ ولا يستبدل الرقم المخزن بـ `12.5`. وبالمثل، يعرض `0.00000` القيمة `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستَخدم [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) بدلاً منه.

ينشئ المثال التالي مخططًا عموديًا ويصل إلى خلاياه عبر [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). في الورقة 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلتا الخليتين توفران قيم المخطط. كما يُفعِّل المثال تسميات القيم المرتبطة بتنسيقات المصدر.

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

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات المعينة مباشرة على محاور المخطط أو تسميات البيانات. في هذا المثال، كل تسمية تُظهر قيمة الخلية المصدر لأن [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) مفعَّلة، وتلتزم بتنسيق الرقم المصدر لأن [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) هي `true`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر التسميات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي تنسيقه الخاص [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) بـ `0.00`، مع [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) مُعيَّنة إلى `false`.

لتنسيق تسمية البيانات بشكل مستقل، اضبط علم ارتباط المصدر إلى `false` وعيّن لها [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). لا يغيّر ذلك تنسيق خلية دفتر العمل. على سبيل المثال، يعرض تنسيق تسمية مستقل بـ `0.00` القيمة الأولى كـ `0.13`، بينما يظل B2 يعرض `12.5000%`. راجع [Chart Data Labels](/slides/ar/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق التسميات مباشرة.

![مخطط عمودي مع تسميات مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور رقمي مُنسق بشكل مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر عمل كعلامة بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعلامات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في الورقة 0 لأول ثلاث تسميات في السلسلة الأولى، يُفعِّل التسميات من الخلايا، ويحفظ العرض التقديمي المحدث.

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

توفر خاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

يمكن أيضًا تخزين قيم نقاط السلسلة مباشرةً كقِيَم عددية حرفية. راجع [Set Series Values Using Numeric Literals](/slides/ar/net/chart-series/#set-series-values-using-numeric-literals) للحصول على مثال كامل يحفظها ويقرأها. نوع مصدر قيم النقاط منفصل عن تكوين دفتر العمل الداخلي أو الخارجي للمخطط؛ لا يزيل استخدام القِيَم العددية الحرفية دفتر العمل المضمن بحد ذاته.

ينشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويعيّن اسمي سلسلتين باستخدام مصادر بيانات مختلفة. يستخدم الاسم الأول قيمة نصية حرفية؛ يستخدم الاسم الثاني الخلية C1 في الورقة 0. تحدد تعداد [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بأسماء السلاسل المحدثة.

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

## **كشف تنسيقات دفتر العمل المضمن غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام خاصية [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) على [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال القوالب في الشريحة الأولى من عرض تقديمي موجود، يتخطى القوالب غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

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

    // قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يغلق تدفق الإخراج قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض التقديمي المرتبط.

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

بينما لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تحتوي ورقة العمل المسماة `Sheet1` على اسم السلسلة في B1، أسماء الفئات في A2:A4، وقيم عددية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لتعيين A1:B4 لسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

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

معامل `updateChartData` في [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) يتحكم فيما إذا كان دفتر العمل يُحمَّل.

* عندما يكون `updateChartData` `false`، يتم فقط تحديث مسار دفتر العمل. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `updateChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

يعين المثال التالي عنوان URL نائب مع `updateChartData` مضبوطًا على `false`. يحتفظ ببيانات المخطط الدائري الافتراضية ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي للمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واسترجع مسار دفتر العمل الخاص به.

يفحص هذا المثال القالب الأول في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع المثال [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

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

يمكنك تحرير البيانات في دفاتر عمل خارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُطرح استثناء.

يستخدم هذا المثال مخططًا هو القالب الأول على الشريحة الأولى ومربوطًا بدفتر عمل خارجي يمكن الوصول إليه. يضبط قيمة الخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المحدث. يمكن لتعديل قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة إلى الحفاظ على دفتر العمل الأصلي.

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

## **تحديث بيانات المخطط من دفاتر العمل المصدر**

تضيف Aspose.Slides for .NET 26.11 طريقة [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) لمخطط واحد وطريقة [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) للعرض التقديمي. استخدمهما بعد تغيير قيم دفتر العمل المصدر. يجب أن تكون دفاتر العمل الخارجية قابلة للوصول ومدعومة.

مع تثبيت [Aspose.Slides for .NET](/slides/ar/net/installation/) 26.11 أو أحدث، يُحدث هذا المثال المخطط الأول في الشريحة الأولى من `charts.pptx`. يجب أن يكون دفتر العمل المصدر متاحًا. احفظ النتيجة للاحتفاظ ببيانات المخطط المحدثة.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

لتحديث جميع المخططات، استخدم نسخة عرض تقديمي منفصلة كما هو موضح. تمرير `false` يجعل فشل التحديث ينتقل إلى المستدعي؛ لا يتراجع عن المخططات التي تم تحديثها بالفعل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

الإعداد الافتراضي هو `true`: تُخَفِي [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) المخطط الفاشل وتستمر مع الآخرين. لا تُعيد أي نتائج لكل مخطط، لذا لا يثبت أن كل مخطط تم تحديثه. استخدم استدعاءات فردية لـ [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) إذا كنت تحتاج لتحديد كل مخطط فاشل.

التحديث يعيد تحميل بيانات المصدر. وهو منفصل عن حساب الصيغ، والتحقق من تخطيط المخطط، وتحديث معاينة OLE. افحص القيم الحية المستندة إلى الخلايا للتحقق من التحديث في الذاكرة. قد يصف [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) المخطط المحفوظ مسبقًا حتى تقوم بحفظ وإعادة فتح العرض التقديمي.

### **قراءة القيم المخزنة للمخطط دون دفتر عمل**

في .NET 26.11، تُقرأ قيم المخزن المؤقت دون فتح دفتر عمل المخطط. تكون مفيدة عندما يكون الملف المرتبط غير متاح وتحتاج فقط إلى آخر بيانات مخزنة للمخطط. هذا مختلف عن إعادة بناء دفتر العمل باستخدام خيار الاستعادة أدناه.

| الكائن | الوصول المخزن |
| --- | --- |
| نقطة بيانات سلسلة عادية | [القيمة المخزنة](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| نقطة بيانات مبعثرة أو فقاعة | [القيمة السينية المخزنة](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/)، [القيمة الصادية المخزنة](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| نقطة بيانات فقاعة | [حجم الفقاعة المخزن](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| فئة المخطط | [القيمة المخزنة](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

كل وصول يُعيد [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/). تُظهر الخاصية [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) الكائن المخزن؛ تُعيد [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) النص؛ تُعيد [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) `NaN` للقيمة الغائبة أو غير الرقمية. قد تكون الذاكرة مفقودة أو قديمة، بما في ذلك مخطط جديد لم يُحفظ بعد. لا تفترض أن كل حقل موجود أو يحتوي على رقم.

يقرأ هذا المثال جميع هذه الحقول من `cached-chart.pptx`، وهو عرض تقديمي محفوظ يحتوي على مخططات. يُعدُّ عدم وجود دفتر عمل خارجي مقبولًا لأن الكود لا يصل إلى [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) أو خلايا دفتر العمل الحية.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

استخدم التحديث عندما تحتاج إلى بيانات مصدر حديثة؛ استخدم القراءة من الذاكرة المؤقتة عندما تكون اللقطة المخزنة كافية. الذاكرة ليست نسخة كاملة من دفتر العمل ولا يمكنها توفير التغييرات التي أُجريت بعد آخر تحديث.

### **استعادة دفتر عمل من ذاكرة مخطط البيانات**

إذا كان مخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة في الذاكرة. أنشئ [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)، اضبط [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)، وعين [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) إلى `true` قبل فتح العرض التقديمي.

يستعيد المثال التالي بلغة C# بيانات دفتر العمل لمخطط هو القالب الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

إذا وصل الكود إلى دفتر العمل الخارجي وهو غير متاح وتم تعطيل الاستعادة، تُطرح Aspose.Slides استثناءً من نوع [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). فعّل الاستعادة فقط عندما يكون استخدام البيانات المخزنة للمخطط هو حل مقبول، لأن الذاكرة قد لا تحتوي على تغييرات أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**  
نعم. يحتوي المخطط على [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**  
نعم. إذا حُدد مسار نسبي، يتم تحويله تلقائيًا إلى مسار كامل. يخزن العرض التقديمي المسار الكامل في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**  
نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير الدفاتر عن بُعد مباشرةً؛ يمكن استخدامها فقط كمصدر.

**هل تستبدل Aspose.Slides ملف XLSX الخارجي عند حفظ العرض التقديمي؟**  
يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). قد تقوم تحرير بيانات المخطط المرتبطة بالخلية أيضًا بتحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان الأصل يجب أن يبقى دون تعديل.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**  
Aspose.Slides لا تقبل كلمة مرور عند الربط. عادةً ما يتم إزالة الحماية مسبقًا أو إعداد نسخة غير مشفّرة (مثلاً باستخدام [Aspose.Cells](https://reference.aspose.com/cells/net/)) وربطها بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**  
نعم. يخزن كل مخطط رابطه الخاص. إذا أشار جميعها إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط في المرة القادمة التي يُحمَّل فيها البيانات.