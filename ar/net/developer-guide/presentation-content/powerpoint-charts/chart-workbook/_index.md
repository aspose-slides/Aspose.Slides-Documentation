---
title: إدارة دفاتر عمل المخطط في العروض التقديمية باستخدام .NET
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
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ .NET: إدارة دفاتر عمل المخطط بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عرضك التقديمي."
---

## **تعيين بيانات المخطط من دفتر العمل**
يقدم Aspose.Slides طرقًا [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) التي تسمح لك بقراءة وكتابة دفاتر بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

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


## **تعيين خلية دفتر العمل كوسم بيانات المخطط**
1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مخطط فقاعة مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية دفتر العمل كوسم بيانات.
6. حفظ العرض التقديمي.

يعرض هذا الكود C# كيفية تعيين خلية دفتر العمل كوسم بيانات المخطط:
```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// يقوم بإنشاء فئة عرض تقديمي تمثل ملف عرض تقديمي 

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


## **إدارة ورقات العمل**
يعرض هذا الكود C# عملية يتم فيها استخدام الخاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) للوصول إلى مجموعة ورقة العمل:
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
يظهر هذا الكود C# كيفية تحديد نوع لمصدر البيانات:
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


## **دفتر عمل خارجي**
{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/)، تم تنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**
باستخدام طريقتي **`ReadWorkbookStream`** و **`SetExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يعرض هذا الكود C# عملية إنشاء دفتر العمل الخارجي:
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
باستخدام طريقة **`SetExternalWorkbook`**، يمكنك ربط دفتر عمل خارجي بمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

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


معامل `ChartData` (تحت طريقة `SetExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر إكسل أم لا.

* عندما تكون قيمة `ChartData` `false`، يتم فقط تحديث مسار دفتر العمل — لن يتم تحميل أو تحديث بيانات المخطط من دفتر العمل المستهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل المستهدف غير موجود أو غير متاح.
* عندما تكون قيمة `ChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```


### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي للمخطط**
1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن للنوع (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
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
يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما يتعذر تحميل دفتر عمل خارجي، يتم رمي استثناء.

هذا الكود C# هو تنفيذ للعملية الموضحة:
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

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**  
نعم. للمخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**  
نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لتقابلية نقل المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**  
نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل عن بُعد مباشرةً — يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**  
لا. يقوم العرض التقديمي بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**  
Aspose.Slides لا يقبل كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة ( على سبيل المثال باستخدام [Aspose.Cells](/cells/net/) ) والربط بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**  
نعم. كل مخطط يخزن الرابط الخاص به. إذا كانت جميع المخططات تشير إلى نفس الملف، سيظهر التحديث الذي يُجرى على ذلك الملف في كل مخطط عند تحميل البيانات مرة أخرى.