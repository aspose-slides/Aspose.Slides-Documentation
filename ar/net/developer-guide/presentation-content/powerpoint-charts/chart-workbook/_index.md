---
title: إدارة مصنفات المخططات في العروض التقديمية في .NET
linktitle: مصنف المخطط
type: docs
weight: 70
url: /ar/net/chart-workbook/
keywords:
- مصنف المخطط
- بيانات المخطط
- خلية المصنف
- علامة البيانات
- ورقة عمل
- مصدر البيانات
- مصنف خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: إدارة مصنفات المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **قراءة وكتابة بيانات المخطط من مصنف**
توفر Aspose.Slides طريقة [ReadWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdata/writeworkbookstream/) التي تتيح لك قراءة وكتابة مصنفات بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

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

## **تعيين خلية مصنف كعلامة بيانات المخطط**
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط فقاعة مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية المصنف كعلامة بيانات.
6. حفظ العرض.

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// يقوم بإنشاء مثال من فئة العرض التقديمي التي تمثل ملف عرض تقديمي

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

يوضح هذا الكود C# عملية يتم فيها استخدام الخاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) للوصول إلى مجموعة أوراق العمل:

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

## **اكتشاف صيغ المصنفات المدمجة غير المدعومة**

لا تدعم Aspose.Slides صيغة المصنف الثنائي لبرنامج Excel (.xlsb) التي يمكن دمجها في بعض المخططات. يمكنك استخدام الخاصية `EmbeddedWorkbookType` على `IChartData` مع تعداد `WorkbookType` لاكتشاف الصيغ غير المدعومة وتجاوز تلك المخططات.

```csharp
using (var presentation = new Presentation("pres.pptx"))
{
    foreach (var shape in presentation.Slides[0].Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // المصنف المدمج بصيغة .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدّل بيانات مصنف المخطط هنا.
    }
}
```

## **مصنف خارجي**
{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/ar/net/aspose-slides-for-net-19-4-release-notes/) ، قمنا بتنفيذ دعم للمصنفات الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء مصنف خارجي**
باستخدام طريقتي **`ReadWorkbookStream`** و **`SetExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو جعل مصنف داخلي خارجيًا.

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

### **تعيين مصنف خارجي**
باستخدام طريقة **`SetExternalWorkbook`**، يمكنك تعيين مصنف خارجي إلى مخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (إذا تم نقل الأخير).

في حين لا يمكنك تعديل البيانات في المصنفات المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لمصنف خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

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

المعامل `ChartData` (تحت طريقة `SetExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل مصنف Excel أم لا.

* عندما تكون قيمة `ChartData` مضبوطة على `false`، يتم تحديث مسار المصنف فقط — لن يتم تحميل بيانات المخطط أو تحديثها من المصنف المستهدف. قد ترغب في استخدام هذا الإعداد عندما يكون المصنف المستهدف غير موجود أو غير متاح.  
* عندما تكون قيمة `ChartData` مضبوطة على `true`، يتم تحديث بيانات المخطط من المصنف المستهدف.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **الحصول على مسار مصنف مصدر البيانات الخارجي لمخطط**
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على ما إذا كان نوع المصدر هو نفسه نوع مصدر البيانات للمصنف الخارجي.

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
يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتويات المصنفات الداخلية. عند عدم القدرة على تحميل مصنف خارجي، يتم إثارة استثناء.

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بمصنف خارجي أم مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/) و[مسار إلى مصنف خارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/)؛ إذا كان المصدر مصنفًا خارجيًا، يمكنك قراءة المسار الكامل للتأكد من أن ملفًا خارجيًا يتم استخدامه.

**هل تدعم المسارات النسبية للمصنفات الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لتقابلية نقل المشروع؛ ومع ذلك، يرجى العلم أن العرض سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام المصنفات الموجودة على موارد أو مشاركات شبكية؟**

نعم، يمكن استخدام هذه المصنفات كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير المصنفات البعيدة مباشرةً — يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**

لا. يقوم العرض بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض.

**ماذا أفعل إذا كان الملف الخارجي محمياً بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. عادةً ما يتم إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/net/)) وربطها.

**هل يمكن لعدة مخططات الإشارة إلى نفس المصنف الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا أشاروا جميعًا إلى نفس الملف، سيظهر تحديث ذلك الملف في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.