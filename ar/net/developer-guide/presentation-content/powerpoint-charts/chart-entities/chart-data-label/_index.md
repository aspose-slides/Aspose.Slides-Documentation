---
title: ملصق بيانات الرسم البياني
type: docs
url: /net/chart-data-label/
keywords: "ملصق بيانات الرسم البياني, مسافة الملصق, C#, Csharp, Aspose.Slides for .NET"
description: "تعيين ملصق بيانات الرسم البياني في PowerPoint والمسافة في C# أو .NET"
---

تظهر ملصقات البيانات على الرسم البياني تفاصيل حول سلسلة بيانات الرسم البياني أو نقاط البيانات الفردية. تتيح للقراء التعرف بسرعة على سلسلة البيانات كما تجعل الرسوم البيانية أسهل في الفهم.

## **تعيين دقة البيانات في ملصقات بيانات الرسم البياني**

يوضح هذا الكود بلغة C# كيفية تعيين دقة البيانات في ملصق بيانات الرسم البياني:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **عرض النسبة المئوية كملصقات**
تتيح Aspose.Slides for .NET تعيين ملصقات النسبة المئوية على الرسوم البيانية المعروضة. يوضح هذا الكود بلغة C# العملية:

```c#
// ينشئ مثيلاً لفئة Presentation
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

// يحفظ العرض التقديمي الذي يحتوي على الرسم البياني
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **تعيين علامة النسبة المئوية مع ملصقات بيانات الرسم البياني**
يوضح هذا الكود بلغة C# كيفية تعيين علامة النسبة المئوية لملصق بيانات الرسم البياني:

```c#
// ينشئ مثيلاً لفئة Presentation
Presentation presentation = new Presentation();

// يحصل على مرجع شريحة من خلال فهرسها
ISlide slide = presentation.Slides[0];

// ينشئ الرسم البياني PercentsStackedColumn على شريحة
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// يعين NumberFormatLinkedToSource إلى false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// يحصل على ورقة عمل بيانات الرسم البياني
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// يضيف سلسلتين جديدتين
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// يعين لون التعبئة للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// يعين خصائص LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// يضيف سلسلتين جديدتين
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// يعين نوع التعبئة واللون
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// يكتب العرض التقديمي إلى القرص
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **تعيين مسافة الملصق من المحور**
يوضح هذا الكود بلغة C# كيفية تعيين مسافة الملصق من محور الفئة عندما تتعامل مع رسم بياني مرسوم من المحاور:

```c#
// ينشئ مثيلاً لفئة Presentation
Presentation presentation = new Presentation();

// يحصل على مرجع شريحة
ISlide sld = presentation.Slides[0];

// ينشئ رسمًا بيانيًا على الشريحة
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// يعين مسافة الملصق من المحور
ch.Axes.HorizontalAxis.LabelOffset = 500;

// يكتب العرض التقديمي إلى القرص
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **تعديل موقع الملصق**

عندما تقوم بإنشاء رسم بياني لا يعتمد على أي محور مثل الرسم البياني الدائري، قد تنتهي ملصقات بيانات الرسم البياني بالقرب من حافته. في مثل هذه الحالة، تحتاج إلى تعديل موقع ملصق البيانات بحيث يتم عرض خطوط الربط بوضوح.

يوضح هذا الكود بلغة C# كيفية تعديل موقع الملصق على رسم بياني دائري:

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

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)