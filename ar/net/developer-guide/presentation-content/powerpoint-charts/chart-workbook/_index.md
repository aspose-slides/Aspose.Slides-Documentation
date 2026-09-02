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
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخزن المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاصة بك."
---
## **نظرة عامة**

هذه المقالة توضح طريقة العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
Aspose.Slides توفر الطريقتين [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/writeworkbookstream/) اللتين تتيحان لك قراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يعرض هذا الكود C# عملية نموذجية:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بمجموعات السلاسل والفئات الأصلية. هذا الاختلاف قد يسبب فشل [IChart.ValidateChartLayout](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/validatechartlayout/) مع خطأ "فهرس خارج النطاق". قم بمسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى المخطط.

```csharp
// بعد تعديل تدفق دفتر العمل (مثلاً، باستخدام Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// مسح مراجع البيانات الحالية.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

مسح المجموعات يضمن أن بنية بيانات المخطط متسقة مع دفتر العمل الجديد، مما يسمح لـ `ValidateChartLayout` بالاكتمال بدون أخطاء.

## **تعيين خلية دفتر عمل كعنوان بيانات للمخطط**
1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة عبر مؤشرها.
1. إضافة مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية دفتر العمل كعنوان بيانات.
1. حفظ العرض التقديمي.

يعرض هذا الكود C# كيفية تعيين خلية دفتر عمل كعنوان بيانات للمخطط:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// ينشئ كائن فئة العرض التقديمي التي تمثل ملف عرض تقديمي

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **إدارة أوراق العمل**

يعرض هذا الكود C# عملية يستخدم فيها الخاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) للوصول إلى مجموعة أوراق العمل:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **تحديد نوع مصدر البيانات**

يعرض هذا الكود C# كيفية تحديد نوع لمصدر البيانات:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **اكتشاف تنسيقات دفاتر العمل المضمنة غير المدعومة**

Aspose.Slides لا يدعم تنسيق دفتر عمل Excel الثنائي (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام الخاصية `EmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتخطي تلك المخططات.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // دفتر العمل المضمّن بتنسيق .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدل بيانات دفتر عمل المخطط هنا.
    }
}
```

## **دفتر عمل خارجي**

{{% alert color="info" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/ar/net/aspose-slides-for-net-19-4-release-notes/)، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**
باستخدام الطريقتين **`ReadWorkbookStream`** و**`SetExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يعرض هذا الكود C# عملية إنشاء دفتر عمل خارجي:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **تعيين دفتر عمل خارجي**
باستخدام الطريقة **`SetExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يعرض هذا الكود C# كيفية تعيين دفتر عمل خارجي:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// مسار دليل المستندات.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

معامل `ChartData` (تحت طريقة `SetExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما تكون قيمة `ChartData` `false`، يتم تحديث مسار دفتر العمل فقط—لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.
* عندما تكون قيمة `ChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **الحصول على مسار مصدر البيانات الخارجي لدفتر عمل المخطط**

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة عبر مؤشرها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على أن نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

يعرض هذا الكود C# العملية:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // يحفظ العرض التقديمي
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتويات دفاتر العمل الداخلية. عند عدم القدرة على تحميل دفتر عمل خارجي، يتم رمي استثناء.

يعرض هذا الكود C# تنفيذ العملية الموصوفة:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/)، وضبط [SpreadsheetOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/spreadsheetoptions/)، وعين [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) إلى `true` قبل فتح العرض التقديمي.

المثال التالي بلغة C# يفتح عرضًا تقديميًا حيث يشير المخطط إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [IChart.ChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/chartdata/) و[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يقوم Aspose.Slides برمي `InvalidOperationException`. فعل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا مقبولًا كخيار احتياطي، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**

نعم. يمتلك المخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبياً، يتحول تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشروع؛ لكن تجدر الإشارة إلى أن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يقوم العرض التقديمي بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا يقبل كلمة مرور عند الربط. الحل الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/net/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا أشارت جميعها إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط عند تحميل البيانات مرة أخرى.