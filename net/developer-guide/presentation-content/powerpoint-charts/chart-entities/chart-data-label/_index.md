---
title: Chart Data Label
type: docs
url: /net/chart-data-label/
keywords: "Chart data label,label distance, C#, Csharp, Aspose.Slides for .NET"
description: "Set PowerPoint chart data label and distance in C# or .NET"
---

## **Set Precision of Data in Chart Data Labels**
Aspose.Slides for .NET provides a simple API for setting precision of data in chart data label. Below sample example is given. 

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```



## **Display Percentage as Labels**
Aspose.Slides for .NET supports displaying the percentage as labels. In this topic, we will see with example how to display the percentage as labels using Aspose.Slides. In order to set percentage as display. Please follow the steps below.

1. Instantiate [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object.
1. Add stacked column chart.
1. Calculate the series data point values for particular categories.
1. Displaying the percentage as labels.
1. Set properties of label.
1. Write presentation to disk.

In the example given below, we have set the percentage as label.

```c#
// Create an instance of Presentation class
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

// Save presentation with chart
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```



## **Set Percentage Sign with Chart Data Labels**
In order to set the percentage sign with chart data labels. Please follow the steps below:

- Create an instance of `Presentation` class.
- Get reference of the slide.
- Add PercentsStackedColumn chart on a slide.
- Set NumberFormatLinkedToSource to false.
- Getting the chart data worksheet.
- Add new series.
- Setting the fill color of series.
- Setting LabelFormat properties.
- Write the presentation as a PPTX file.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get reference of the slide
ISlide slide = presentation.Slides[0];

// Add PercentsStackedColumn chart on a slide
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Set NumberFormatLinkedToSource to false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Add new series
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Setting the fill color of series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Setting LabelFormat properties
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Add new series
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Setting Fill type and color
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Write presentation to disk
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```



## **Set Label Distances**
In order to set the Label Distance. Please follow the steps below:

- Create an instance of `Presentation` class.
- Get reference of the slide.
- Adding a chart on slide.
- Setting the position of label from axis.
- Write the presentation as a PPTX file.

In the example given below, we have set the label distance from category axis.

```c#
Presentation presentation = new Presentation();

// Get reference of the slide
ISlide sld = presentation.Slides[0];

// Adding a chart on slide
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Setting the position of label from axis
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Write the presentation file to disk
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

