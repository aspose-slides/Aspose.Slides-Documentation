---
title: تسمية بيانات المخطط
type: docs
url: /ar/net/chart-data-label/
keywords: "تسمية بيانات المخطط, مسافة التسمية, C#, Csharp, Aspose.Slides for .NET"
description: "تعيين تسمية بيانات مخطط PowerPoint والمسافة في C# أو .NET"
---

تُظهر تسميات البيانات في المخطط تفاصيل حول سلسلة بيانات المخطط أو نقاط البيانات الفردية. فهي تسمح للقراء بتحديد سلاسل البيانات بسرعة كما تجعل المخططات أسهل في الفهم.

## **تعيين دقة البيانات في تسميات بيانات المخطط**

يظهر هذا الكود C# كيفية تعيين دقة البيانات في تسمية بيانات المخطط:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **عرض النسبة المئوية كتسميات**

تتيح لك Aspose.Slides for .NET تعيين تسميات النسبة المئوية على المخططات المعروضة. يوضح هذا الكود C# العملية:
```c#
// إنشاء كائن من فئة Presentation
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

// حفظ العرض التقديمي الذي يحتوي على المخطط
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```



## **تعيين علامة النسبة المئوية في تسميات بيانات المخطط**

يظهر هذا الكود C# كيفية تعيين علامة النسبة المئوية لتسمية بيانات المخطط:
```c#
// ينشئ كائنًا من فئة Presentation
Presentation presentation = new Presentation();

// يحصل على مرجع الشريحة عبر فهرسها
ISlide slide = presentation.Slides[0];

// ينشئ مخطط PercentsStackedColumn على شريحة
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// يضبط الخاصية NumberFormatLinkedToSource إلى false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// يحصل على ورقة بيانات المخطط
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// يضيف سلسلة جديدة
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// يضبط لون التعبئة للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// يضبط خصائص تنسيق التسمية
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// يضيف سلسلة جديدة
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// يضبط نوع التعبئة واللون
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// يحفظ العرض التقديمي إلى القرص
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **تعيين مسافة التسمية من المحور**

يظهر هذا الكود C# كيفية تعيين مسافة التسمية من محور الفئات عندما تكون تتعامل مع مخطط مرسم من المحاور:
```c#
// ينشئ كائنًا من فئة Presentation
Presentation presentation = new Presentation();

// يحصل على مرجع الشريحة
ISlide sld = presentation.Slides[0];

// ينشئ مخططًا على الشريحة
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// يضبط مسافة التسمية من المحور
ch.Axes.HorizontalAxis.LabelOffset = 500;

// يحفظ العرض التقديمي إلى القرص
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **ضبط موضع التسمية**

عند إنشاء مخطط لا يعتمد على أي محور مثل مخطط الفطيرة، قد تكون تسميات البيانات قريبة جدًا من حافته. في هذه الحالة، عليك ضبط موضع تسمية البيانات بحيث تظهر خطوط الربط بوضوح.

يظهر هذا الكود C# كيفية ضبط موضع التسمية في مخطط الفطيرة:
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


![مخطط دائري مع تسمية مضبوطة](pie-chart-adjusted-label.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**

استخدام وضعية وضع التسميات التلقائي، خطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، إخفاء بعض الحقول (مثل الفئة) أو إظهار التسميات فقط للنقاط المتطرفة/المفتاحية.

**كيف يمكنني إلغاء تفعيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

تصفية نقاط البيانات قبل تمكين التسميات وإيقاف العرض للقيم التي تساوي 0 أو القيم السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان نمط تسمية متسق عند التصدير إلى PDF/صور؟**

تعيين الخطوط صراحةً (العائلة، الحجم) والتأكد من توفر الخط على جانب العرض لتجنب fallback.