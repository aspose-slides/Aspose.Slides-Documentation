---
title: دفتر العمل للرسم البياني
type: docs
weight: 70
url: /ar/net/chart-workbook/
keywords: "دفتر عمل الرسم البياني، بيانات الرسم البياني، عرض PowerPoint، C#، Csharp، Aspose.Slides ل .NET"
description: "دفتر العمل للرسم البياني في عرض PowerPoint في C# أو .NET"
---

## **تعيين بيانات الرسم البياني من دفتر العمل**
توفر Aspose.Slides طرق [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) التي تتيح لك قراءة وكتابة دفاتر عمل بيانات الرسم البياني (التي تحتوي على بيانات رسم بياني تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات الرسم البياني يجب أن تكون منظمة بنفس الطريقة أو يجب أن تحتوي على هيكل مشابه للمصدر.

توضح هذه الشيفرة C# عملية نموذجية:

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


## **تعيين خلية دفتر العمل كـ DataLabel للرسم البياني**
1. انشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا فقاعيًّا مع بعض البيانات.
1. الوصول إلى سلسلة الرسم البياني.
1. تعيين خلية دفتر العمل كـ DataLabel.
1. احفظ العرض التقديمي.

توضح هذه الشيفرة C# كيفية تعيين خلية دفتر العمل كـ DataLabel للرسم البياني:

```c#
string lbl0 = "قيمة خلية التسمية 0";
string lbl1 = "قيمة خلية التسمية 1";
string lbl2 = "قيمة خلية التسمية 2";

// ينشئ مثيلًا من فئة التقديم التي تمثل ملف عرض تقديمي 

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

توضح هذه الشيفرة C# عملية حيث يتم استخدام خاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) للوصول إلى مجموعة ورقة العمل:

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

تظهر هذه الشيفرة C# كيفية تحديد نوع لمصدر البيانات:

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

## **دفتر العمل الخارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/)، طبقنا دعم دفاتر العمل الخارجية كمصدر بيانات للرسم البياني.
{{% /alert %}} 

### **إنشاء دفتر العمل الخارجي**
باستخدام طرق **`ReadWorkbookStream`** و **`SetExternalWorkbook`**، يمكنك إما إنشاء دفتر العمل الخارجي من الصفر أو جعل دفتر العمل الداخلي خارجيًا.

توضح هذه الشيفرة C# عملية إنشاء دفتر العمل الخارجي:

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


### **تعيين دفتر العمل الخارجي**
باستخدام طريقة **`SetExternalWorkbook`**، يمكنك تعيين دفتر العمل الخارجي لرسم بياني كمصدر بيانات له. يمكن استخدام هذه الطريقة أيضًا لتحديث المسار لدفتر العمل الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، يمكنك استخدام مثل هذه دفاتر العمل كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لدفتر العمل الخارجي، فسيتم تحويله تلقائيًا إلى مسار كامل.

توضح هذه الشيفرة C# كيفية تعيين دفتر العمل الخارجي:

```c#
// المسار إلى الدليل الخاص بالمستندات.
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

بارامتر `ChartData` (تحت طريقة `SetExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر العمل Excel أم لا. 

* عندما يتم تعيين قيمة `ChartData` إلى `false`، يتم تحديث مسار دفتر العمل فقط—لن يتم تحميل أو تحديث بيانات الرسم البياني من دفتر العمل المستهدف. قد ترغب في استخدام هذا الإعداد في حالة وجود دفتر العمل المستهدف غير موجود أو غير متاح.
* عندما يتم تعيين قيمة `ChartData` إلى `true`، يتم تحديث بيانات الرسم البياني من دفتر العمل المستهدف.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **الحصول على مسار مصدر البيانات الخارجي للرسم البياني**

1. انشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أنشئ كائنًا لشكل الرسم البياني.
1. أنشئ كائنًا لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات الرسم البياني.
1. حدد الشرط ذي الصلة بناءً على كون نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

توضح هذه الشيفرة C# العملية:

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
    
    // حفظ العرض التقديمي
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما يتعذر تحميل دفتر العمل الخارجي، يتم إصدار استثناء.

تظهر هذه الشيفرة C# تنفيذ العملية الموصوفة:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```