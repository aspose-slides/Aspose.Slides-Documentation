---
title: إدارة تسميات بيانات المخطط في العروض التقديمية في .NET
linktitle: تسمية البيانات
type: docs
url: /ar/net/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موضع التسمية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET للحصول على شرائح أكثر جاذبية."
---

توفر تسميات البيانات على المخطط تفاصيل حول سلسلة بيانات المخطط أو نقاط البيانات الفردية. فهي تمكّن القراء من التعرف بسرعة على سلاسل البيانات وتساعد أيضًا في جعل المخططات أسهل للفهم.

## **تعيين دقة البيانات في تسميات بيانات المخطط**

يُظهر لك هذا الكود C# كيفية تعيين دقة البيانات في تسمية بيانات المخطط:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **عرض النسبة المئوية كعلامات**

يتيح لك Aspose.Slides for .NET تعيين تسميات النسبة المئوية على المخططات المعروضة. يُظهر لك هذا الكود C# العملية:
```c#
// إنشاء مثيل من فئة Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// يحفظ العرض التقديمي الذي يحتوي على المخطط
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```


## **تعيين علامة النسبة المئوية مع تسميات بيانات المخطط**

يُظهر لك هذا الكود C# كيفية تعيين علامة النسبة المئوية لتسمية بيانات المخطط:
```c#
// إنشاء مثيل من فئة Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// الحصول على مرجع الشريحة عبر الفهرس
// (هذه السطر تم ترجمته بالفعل أعلاه، يتم الاحتفاظ به كما هو لا تعديل الكود)

// إنشاء مخطط PercentsStackedColumn على شريحة
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// تعيين NumberFormatLinkedToSource إلى false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Gets the chart data worksheet
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Adds new series
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Sets the fill color of series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Sets the LabelFormat properties
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Adds new series
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Sets Fill type and color
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// حفظ العرض التقديمي إلى القرص
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **تعيين مسافة التسمية من المحور**

يُظهر لك هذا الكود C# كيفية تعيين مسافة التسمية من محور الفئة عندما تتعامل مع مخطط مرسوم من المحاور:
```c#
// إنشاء مثيل من فئة Presentation
Presentation presentation = new Presentation();

// الحصول على مرجع الشريحة
ISlide sld = presentation.Slides[0];

// إنشاء مخطط على الشريحة
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// تعيين مسافة التسمية من المحور
ch.Axes.HorizontalAxis.LabelOffset = 500;

// حفظ العرض التقديمي إلى القرص
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **ضبط موضع التسمية**

عند إنشاء مخطط لا يعتمد على أي محور مثل مخطط الفطيرة، قد تصبح تسميات بيانات المخطط قريبة جدًا من حافته. في هذه الحالة، يتعين عليك ضبط موضع التسمية بحيث يتم عرض خطوط الربط بوضوح.

يُظهر لك هذا الكود C# كيفية ضبط موضع التسمية على مخطط الفطيرة:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![مخطط فطيرة مع تعديل التسمية](pie-chart-adjusted-label.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكثفة؟**

استخدم وضعية التسمية التلقائية، خطوط الربط، وتقليل حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للنقاط المتطرفة/المفتاحية.

**كيف يمكنني تعطيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

قم بترشيح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم التي تساوي 0 أو القيم السلبية أو القيم الفارغة وفقاً لقاعدة محددة.

**كيف أضمن نمط تسميات متسق عند التصدير إلى PDF/صور؟**

حدّد الخطوط (العائلة، الحجم) صراحةً وتأكد من توفر الخط على جانب العرض لتجنّب الاعتماد على الخطوط البديلة.