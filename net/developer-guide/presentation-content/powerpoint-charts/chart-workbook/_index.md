---
title: Chart Workbook
type: docs
weight: 70
url: /net/chart-workbook/
keywords: "Chart workbook, chart data, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Chart workbook in PowerPoint presentation in C# or .NET"
---

## **Set Chart Data from Workbook**
Aspose.Slides provides the [ReadWorkbookStream](https://apireference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) and [WriteWorkbookStream](https://apireference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This C# code demonstrates a sample operation:

```c#
Presentation pres = new Presentation(dataDir+"Test.pptx");

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
chart.ChartData.ChartDataWorkbook.Clear(0);

Workbook workbook = null;
try
{
	workbook = new Aspose.Cells.Workbook("a1.xlsx");
}
catch (Exception ex)
{
	Console.Write(ex);
}
MemoryStream mem = new MemoryStream();
workbook.Save(mem, Aspose.Cells.SaveFormat.Xlsx);

chart.ChartData.WriteWorkbookStream(mem);

chart.ChartData.SetRange("Sheet1!$A$1:$B$9");
IChartSeries series = chart.ChartData.Series[0];
series.ParentSeriesGroup.IsColorVaried = true;
pres.Save(dataDir+"response2.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Set WorkBook Cell as Chart DataLabel**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Add a Bubble chart with some data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This C# code shows you to set a workbook cell as a chart data label:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instantiates a presentation class that represents a presentation file 

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

## Manage Worksheets

This C# code demonstrates an operation where the [IChartDataWorkbook.Worksheets](https://apireference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) property is used to access a worksheet collection:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Specify Data Source Type**

This C# code shows you how to specify a type for a data source:

```

```



## **External Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **Create External Workbook**
Using the **`IChartData.ReadWorkbookStream`** and **`IChartData.SetExternalWorkbook`** methods, you can either create an external workbook from scratch or make an internal workbook external.

This C# code demonstrates the external workbook creation process:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    string externalWbPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);

    if (File.Exists(externalWbPath))
        File.Delete(externalWbPath);

    using (FileStream fileStream = new FileStream(externalWbPath, FileMode.CreateNew))
    {
        byte[] worbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(worbookData, 0, worbookData.Length);
    }

    chart.ChartData.SetExternalWorkbook(externalWbPath);

    pres.Save("Presentation_with_externalWbPath.pptx", SaveFormat.Pptx);
}
```


### **Set External Workbook**
Using the **`IChartData.SetExternalWorkbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This C# code shows you how to an external workbook:

```c#
// The path to the documents directory.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook("externalWorkbook.xlsx");
                  

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

The `updateChartData` parameter (under the `SetExternalWorkbook` method) is used to specify whether an excel workbook will be loaded or not. 

* When `updateChartData` value is set to `false`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When `updateChartData` value is set to `true` , the chart data gets updated from the target workbook.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Get Chart External Data Source Workbook Path**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Create an object for the chart shape.
1. Create an object for the source (`ChartDataSourceType`) type that represents the chart's data source.
1. Specify the relevant condition based on the source type being the same as the external workbook data source type.

This C# code demonstrates the operation:

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
}
// Saves the presentation
pres.Save("Result.pptx", SaveFormat.Pptx);
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an  exception is thrown.

This C# code is an implementation of the described process:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```
