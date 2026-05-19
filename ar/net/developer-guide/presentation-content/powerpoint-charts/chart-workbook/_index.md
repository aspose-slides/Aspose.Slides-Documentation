---
title: "إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام .NET"
linktitle: "دفتر عمل المخطط"
type: docs
weight: 70
url: /ar/net/chart-workbook/
keywords:
- "دفتر عمل المخطط"
- "بيانات المخطط"
- "خلية دفتر العمل"
- "علامة البيانات"
- "ورقة العمل"
- "مصدر البيانات"
- "دفتر عمل خارجي"
- "بيانات خارجية"
- "PowerPoint"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "اكتشف Aspose.Slides لـ .NET: إدارة دفاتر عمل المخططات في صيغ PowerPoint وOpenDocument بسهولة لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعلامات بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides الطريقة [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) والطريقة [WriteWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/writeworkbookstream/) التي تسمح لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

يعرض هذا الكود C# عملية نموذجية:

```c#
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

## **تعيين خلية دفتر العمل كعلامة بيانات للمخطط**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مخطط فقاعي مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية دفتر العمل كعلامة بيانات.
6. حفظ العرض التقديمي.

يعرض هذا الكود C# كيفية تعيين خلية دفتر العمل كعلامة بيانات للمخطط:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي 

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

يعرض هذا الكود C# عملية يتم فيها استخدام الخاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) للوصول إلى مجموعة أوراق العمل:

``` csharp
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

## **اكتشاف صيغ دفاتر العمل المدمجة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر عمل Excel الثنائي (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام الخاصية `EmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/workbooktype/) لاكتشاف الصيغ غير المدعومة وتخطي تلك المخططات.

```csharp
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
            // دفتر العمل المدمج بتنسيق .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدل بيانات دفتر عمل المخطط هنا.
    }
}
```

## **دفتر عمل خارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/ar/net/aspose-slides-for-net-19-4-release-notes/)، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**
باستخدام الطريقتين **`ReadWorkbookStream`** و **`SetExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يعرض هذا الكود C# عملية إنشاء دفتر عمل خارجي:

```c#
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

على الرغم من عدم إمكانية تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، يمكنك الاستمرار في استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله إلى مسار كامل تلقائيًا.

يعرض هذا الكود C# كيفية تعيين دفتر عمل خارجي:

```c#
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

يُستخدم معامل `ChartData` (تحت طريقة `SetExternalWorkbook`) لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما يتم تعيين قيمة `ChartData` إلى `false`، يتم فقط تحديث مسار دفتر العمل — لن يتم تحميل أو تحديث بيانات المخطط من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.
* عندما يتم تعيين قيمة `ChartData` إلى `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي لمخطط**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على أن نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

يعرض هذا الكود C# العملية:

```c#
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

يمكنك تعديل البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إطلاق استثناء.

هذا الكود C# هو تنفيذ العملية الموضحة:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/) ومسار إلى دفتر عمل خارجي ([path to an external workbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/))؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لتسهيل نقل المشاريع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يتم دعم تعديل دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides باستبدال ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عندما يتم حفظ العرض التقديمي.

**ماذا عليّ أن أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/net/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.