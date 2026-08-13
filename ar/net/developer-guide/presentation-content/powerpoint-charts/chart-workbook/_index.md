---
title: إدارة مصنفات المخططات في العروض التقديمية على .NET
linktitle: مصنف المخطط
type: docs
weight: 70
url: /ar/net/chart-workbook/
keywords:
- مصنف المخطط
- بيانات المخطط
- خلية المصنف
- ملصق البيانات
- ورقة عمل
- مصدر البيانات
- مصنف خارجي
- بيانات خارجية
- ذاكرة التخزين المؤقت للمخطط
- استعادة المصنف
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: إدارة مصنفات المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مصنفات المخططات في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات المصنف، واستخدام خلايا المصنف كملصقات بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع مصنفات خارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وإسناد مصنف خارجي، واسترجاع مسار مصنف خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون المصنف متاحًا.

## **قراءة وكتابة بيانات المخطط من مصنف عمل**

Aspose.Slides يوفر طريقتي [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/writeworkbookstream/) التي تسمح لك بقراءة وكتابة مصنفات بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أنه يجب تنظيم بيانات المخطط بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يظهر هذا الكود C# عملية نموذجية:

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

## **تعيين خلية مصنف كملصق بيانات للمخطط**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية المصنّف كملصق بيانات.
1. حفظ العرض التقديمي.

يظهر هذا الكود C# كيفية تعيين خلية مصنف كملصق بيانات للمخطط:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// ينشئ فئة العرض التقديمي التي تمثل ملف عرض تقديمي 

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

يظهر هذا الكود C# عملية يتم فيها استخدام خاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) للوصول إلى مجموعة أوراق العمل:

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

يظهر هذا الكود C# كيفية تحديد نوع لمصدر البيانات:

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

## **اكتشاف صيغ المصنف المضمن غير المدعومة**

Aspose.Slides لا يدعم صيغ المصنف الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام خاصية `EmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/workbooktype/) لاكتشاف الصيغ غير المدعومة وتجاوز تلك المخططات.

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
            // دفتر العمل المدمج بصيغة .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدل بيانات دفتر المخطط هنا.
    }
}
```

## **المصنف الخارجي**

{{% alert color="info" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/ar/net/aspose-slides-for-net-19-4-release-notes/)، أضفنا دعمًا للمصنفات الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء مصنف خارجي**

باستخدام طريقتي **`ReadWorkbookStream`** و**`SetExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو تحويل مصنف داخلي إلى خارجي.

يُظهر هذا الكود C# عملية إنشاء المصنف الخارجي:

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

### **تعيين مصنف خارجي**

باستخدام طريقة **`SetExternalWorkbook`**، يمكنك إسناد مصنف خارجي إلى مخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (إذا تم نقل الأخير).

على الرغم من أنك لا تستطيع تحرير البيانات في المصنفات المخزنة في مواقع أو موارد بعيدة، يمكنك الاستمرار في استخدام هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير مسار نسبي للمصنف الخارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يُظهر هذا الكود C# كيفية تعيين مصنف خارجي:

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

معلمة `ChartData` (تحت طريقة `SetExternalWorkbook`) تُستخدم لتحديد ما إذا كان سيتم تحميل مصنف Excel أم لا.

* عندما تكون قيمة `ChartData` `false`، يتم تحديث مسار المصنف فقط — لن يتم تحميل أو تحديث بيانات المخطط من المصنف الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون المصنف الهدف غير موجود أو غير متاح.
* عندما تكون قيمة `ChartData` `true`، يتم تحديث بيانات المخطط من المصنف الهدف.

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

### **الحصول على مسار المصنف الخارجي لمصدر بيانات المخطط**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر البيانات للمصنف الخارجي.

يُظهر هذا الكود C# العملية:

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

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تقوم بها بتعديل محتويات المصنفات الداخلية. عند عدم إمكانية تحميل مصنف خارجي، يتم إلقاء استثناء.

هذا الكود C# هو تنفيذ للعميلة الموصوفة:

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

### **استعادة مصنف من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم مصنفًا خارجيًا مفقودًا أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء مصنف المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/)، واضبط [SpreadsheetOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/spreadsheetoptions/)، ثم عيّن [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) إلى `true` قبل فتح العرض التقديمي.

المثال التالي بلغة C# يفتح عرضًا تقديميًا يشير مخططه إلى مصنف خارجي غير متاح ويصل إلى البيانات المستعادة عبر [IChart.ChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/chartdata/) و[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/chartdataworkbook/) :

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

إذا كان المصنف الخارجي غير متاح وتم تعطيل الاستعادة، يقوم Aspose.Slides بإلقاء `InvalidOperationException`. فعّل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريتها على المصنف الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبط بمصنف خارجي أم مدمج؟**

نعم. للمخطط نوع مصدر بيانات [data source type](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/) ومسار إلى مصنف خارجي [path to an external workbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/)؛ إذا كان المصدر مصنفًا خارجيًا، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية للمصنفات الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لنقل المشروع؛ لكن يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام المصنفات الموجودة على موارد شبكية/مشاركات؟**

نعم، يمكن استخدام هذه المصنفات كمصدر بيانات خارجي. ومع ذلك، لا يتم دعم تحرير المصنفات البعيدة مباشرة من Aspose.Slides — يمكن فقط استخدامها كمصدر.

**هل تقوم Aspose.Slides باستبدال ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. الحل الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/net/)) والربط بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس المصنف الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا أشارت جميعها إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط عند تحميل البيانات مرة أخرى.