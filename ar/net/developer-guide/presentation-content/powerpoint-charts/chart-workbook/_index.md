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
- ذاكرة التخزين المؤقت للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides for .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالرسوم البيانية في Aspose.Slides. تظهر كيفية قراءة وكتابة بيانات الرسم البياني عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات الرسم البياني، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم الرسم البياني.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للرسوم البيانية. تظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بالرسم البياني، وتعديل بيانات الرسم البياني عندما يكون دفتر العمل متاحًا.

بالنسبة لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/net/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط الخط لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) للتحكم فيما إذا كان الرسم البياني يرسم البيانات من الصفوف والأعمدة المخفية في ورقة العمل. عينه `true` لت رسم الخلايا المرئية فقط، أو `false` لتضمين كل من الخلايا المرئية والمخفية. هذه الإعدادات تتحكم في رسم الرسم البياني؛ وليس لها علاقة بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

قم بتنزيل [hidden-source-data.pptx](hidden-source-data.pptx) وضعه في دليل العمل. يحتوي الشريحة الأولى على مخطط عمودي كشكل أول. ورقة العمل المضمنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى الخلايا المصدر عبر [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/chartdataworkbook/) وقراءة [IChartDataCell.IsHidden](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/ishidden/) لتفقد حالة الإخفاء. هذه الخاصية للقراءة فقط. في هذا الملف، B2 مرئي، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على التوالي.

للمثال هذا، حدّث بيانات الرسم البياني بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمن باستخدام [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) وأعد تحميله باستخدام [WriteWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/writeworkbookstream/). عند تضمين جميع الخلايا، استخدم أيضًا [SetRange](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات الرسم المخزنة مؤقتًا وتسميات الفئات في هذا المثال.

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

        // تجديد بيانات المخطط من دفتر العمل المضمن.
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

يحفظ المثال `hidden_cells_True.pptx` مع قيم التجزئة المرئية فقط (10 و 20)، و`hidden_cells_False.pptx` مع جميع القيم الستة. الصور أدناه تم عرضها من العروض التقديمية المحفوظة بعد إعادة فتحها؛ كلا الملفين يحافظان على إعداد الرسم المحدد. يبقى الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمنين.

| الخلايا المرئية فقط (`true`) | جميع الخلايا (`false`) |
| --- | --- |
| ![الخلايا المرئية فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![جميع الخلايا: قيم التجزئة والجملة لشهري يناير وفبراير ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/displayblanksas/) في كيفية عرض القيم المفقودة؛ ولا يضيف أو يستثني بيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/net/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **قراءة وكتابة بيانات الرسم البياني من دفتر عمل**

توفر Aspose.Slides for .NET طريقتي [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/writeworkbookstream/) اللتين تسمحان بقراءة وكتابة دفاتر عمل بيانات الرسم البياني (التي تحتوي على بيانات تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات الرسم يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها هيكل مشابه للمصدر.

يفتح هذا المثال `chart.pptx`، ويجب أن يحتوي على رسم بياني كشكل أول في شريحته الأولى. يقرأ دفتر العمل المضمن إلى تدفق، يمسح السلاسل والفئات الحالية، ثم يكتب دفتر العمل نفسه مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يحفظ المثال العرض التقديمي.

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

### **التحقق من تخطيط الرسم البياني بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ الرسم البياني بسلسلاته ومجموعات فئاته الأصلية. يمكن لهذا الاختلاف أن يتسبب في فشل [IChart.ValidateChartLayout](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/validatechartlayout/) مع خطأ “index-out-of-range”. امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى الرسم البياني. يتطلب هذا المثال وجود `chart.pptx` مع رسم بياني كشكل أول في شريحته الأولى. علامة التعليق توضح مكان تحرير دفتر العمل؛ يكتب المثال القالب الأصلي مرة أخرى ويُصادق على التخطيط في الذاكرة.

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

    // قم بتعديل تدفق دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

إزالة المجموعات تمسح إشارات البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو خرائط فئات مطلوبة لدفتر العمل المحدث قبل استخدام الرسم البياني.

## **تعيين خلية دفتر العمل كعلامة بيانات للرسم البياني**

يمكنك استخدام النص من خلايا دفتر العمل كعلامات بيانات للرسم البياني. توضح الخطوات التالية كيفية ربط العلامات في مخطط الفقاعات بالخلايا في دفتر البيانات الخاص به.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى باستخدام الفهرس صفر-الأساس.
3. إضافة مخطط فقاعة بالبيانات الافتراضية.
4. الوصول إلى سلسلة الرسم البياني.
5. تعيين خلية دفتر العمل كعلامة بيانات.
6. حفظ العرض التقديمي.

يفتح هذا المثال `chart2.pptx`، ويجب أن يحتوي على شريحة واحدة على الأقل، ويضيف مخطط فقاعة بالبيانات الافتراضية. يستخدم الخلايا A10:A12 في ورقة العمل 0 للعلامات الثلاث الأولى في السلسلة الأولى، يُفعِّل العلامات من الخلايا، ويحفظ النتيجة إلى `resultchart.pptx`.

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

توفر الخاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/worksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل الرسم البياني. ينشئ هذا المثال مخططًا دائريًا بالبيانات الافتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

ينشئ هذا المثال مخطط عمودي ثلاثي الأبعاد بالبيانات الافتراضية ويضبط اسمي سلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم نصًا حرفيًا؛ الثاني يستخدم الخلية C1 في ورقة العمل 0. يحدِّد تعداد [DataSourceType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يتم حفظ النتيجة إلى `pres.pptx`.

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

## **اكتشاف صيغ دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر عمل Excel الثنائي (.xlsb) التي يمكن تضمينها في بعض الرسوم البيانية. يمكنك استخدام الخاصية [EmbeddedWorkbookType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) على [IChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/workbooktype/) لتحديد الصيغ غير المدعومة وتخطي تلك الرسوم البيانية. يفحص هذا المثال الأشكال في الشريحة الأولى من `sample.pptx`، يتخطى الأشكال غير الرسومية، ويطبع رسالة تشخيصية لكل رسم بياني يحتوي على دفتر عمل .xlsb مضمّن.

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

    // قراءة أو تعديل بيانات دفتر العمل المدعومة للرسوم البيانية هنا.
}
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للرسوم البيانية.

### **إنشاء دفتر عمل خارجي**

استخدم [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[SetExternalWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/setexternalworkbook/) لتصدير دفتر عمل رسم بياني مضمّن إلى ملف وربط الرسم البياني بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا بالبيانات الافتراضية، يكتب دفتر عمله إلى `externalWorkbook1.xlsx`، ويغلق تدفق الإخراج قبل تعيين الملف كمصدر بيانات للرسم البياني. يحفظ العرض المرتبط إلى `externalWorkbook.pptx`.

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

باستخدام طريقة [SetExternalWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/setexternalworkbook/)، يمكنك تعيين دفتر عمل خارجي للرسم البياني كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الملف).

في حين لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع بعيدة أو موارد، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يتطلب هذا المثال وجود `externalWorkbook.xlsx` في دليل العمل. يجب أن تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم عددية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [SetRange](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/setrange/) لتعيين A1:B4 كسلسلة واحدة وثلاث فئات. يحفظ النتيجة إلى `Presentation_with_externalWorkbook.pptx`.

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

معامل `updateChartData` في طريقة [SetExternalWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/setexternalworkbook/) يتحكم في ما إذا كان دفتر العمل يتم تحميله.

* عندما تكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل أو تحديث بيانات الرسم البياني من دفتر العمل المستهدف، وبالتالي يمكن أن يكون دفتر العمل غير متاح.
* عندما تكون `updateChartData` `true`، يتم تحديث بيانات الرسم البياني من دفتر العمل المستهدف.

يعرض المثال التالي تعيين عنوان URL كعنصر نائبي مع `updateChartData` مضبوطة على `false`. يحتفظ ببيانات الرسم البياني الافتراضية ويحفظ العرض دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي للرسم البياني**

لتحديد دفتر العمل المرتبط بالرسم البياني، تحقق أولاً ما إذا كان الرسم يستخدم مصدر بيانات خارجي. إذا كان كذلك، يمكنك استرداد مسار دفتر العمل باتباع الخطوات التالية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى باستخدام الفهرس صفر-الأساس.
3. التحقق من أن الشكل الأول هو رسم بياني.
4. قراءة نوع مصدر بيانات الرسم.
5. إذا كان المصدر دفتر عمل خارجي، قراءة مساره.

يفتح هذا المثال `externalWorkbook.pptx`، الذي تم إنشاؤه في المثال السابق، ويفحص الشكل الأول في الشريحة الأولى. إذا كان رسمًا بيانيًا مرتبطًا بدفتر عمل خارجي، يطبع [ExternalWorkbookPath](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/externalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض إلى `Result.pptx`.

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

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات الدفاتر الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

يتطلب هذا المثال وجود `presentation.pptx` مع رسم بياني كشكل أول في الشريحة الأولى ودفتر عمل خارجي يمكن الوصول إليه. يضبط قيمة النقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض إلى `presentation_out.pptx`. يمكن لتعديل قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة إلى الحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للرسم البياني**

إذا كان الرسم البياني يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل الرسم من البيانات المخزنة مؤقتًا في العرض. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/)، اضبط [SpreadsheetOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/spreadsheetoptions/)، واضبط [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) إلى `true` قبل فتح العرض.

يفتح المثال التالي بلغة C# ملف `presentation.pptx`، ويجب أن يكون الشكل الأول في الشريحة الأولى رسمًا بيانيًا يشير إلى دفتر عمل خارجي غير متاح، ويصل إلى البيانات المستعادة عبر [IChart.ChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/chartdata/) و[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يرمي Aspose.Slides استثناءً من نوع [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). فعل الاستعادة فقط عندما تكون استخدام البيانات المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان رسم بياني معين مرتبط بدفتر عمل خارجي أو مضمّن؟**

نعم. يحتوي الرسم البياني على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الارتباط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكية؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً؛ يمكن استخدامها فقط كمصدر.

**هل تستبدل Aspose.Slides ملف XLSX الخارجي عند حفظ العرض؟**

يخزن العرض [ارتباطًا بالملف الخارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/). قد يؤدي تحرير بيانات الرسم المستندة إلى الخلايا أيضًا إلى تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان الأصل يجب أن يبقى دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند ربط الملف. يُنصح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفّرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/net/)) وربط العرض بتلك النسخة.

**هل يمكن لعدة رسومات بيانية الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل رسم بياني يخزن ارتباطه الخاص. إذا أشارت جميعها إلى نفس الملف، فسيتم عكس أي تحديث للملف في كل رسم بياني في المرة التالية التي يتم فيها تحميل البيانات.