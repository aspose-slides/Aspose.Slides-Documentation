---
title: Manage Chart Workbooks in Presentations in .NET
linktitle: Chart Workbook
type: docs
weight: 70
url: /net/chart-workbook/
keywords:
- chart workbook
- chart data
- workbook cell
- data label
- worksheet
- data source
- external workbook
- external data
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Discover Aspose.Slides for .NET: effortlessly manage chart workbooks in PowerPoint and OpenDocument formats to streamline your presentation data."
---

## **Set Chart Data from Workbook**
Aspose.Slides provides the [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) and [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This C# code demonstrates a sample operation:

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


## **Set WorkBook Cell as Chart DataLabel**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
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

## **Manage Worksheets**

This C# code demonstrates an operation where the [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) property is used to access a worksheet collection:

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

## **External Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **Create External Workbook**
Using the **`ReadWorkbookStream`** and **`SetExternalWorkbook`** methods, you can either create an external workbook from scratch or make an internal workbook external.

This C# code demonstrates the external workbook creation process:

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


### **Set External Workbook**
Using the **`SetExternalWorkbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This C# code shows you how to set an external workbook:

```c#
// The path to the documents directory.
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

The `ChartData` parameter (under the `SetExternalWorkbook` method) is used to specify whether an excel workbook will be loaded or not. 

* When `ChartData` value is set to `false`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When `ChartData` value is set to `true` , the chart data gets updated from the target workbook.

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

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
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
    
    // Saves the presentation
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

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

## **FAQ**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) and a [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Are relative paths to external workbooks supported, and how are they stored?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. This is convenient for project portability; however, be aware that the presentation will store the absolute path in the PPTX file.

**Can I use workbooks located on network resources/shares?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

No. The presentation stores a [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) and uses it for reading data. The external file itself is not modified when the presentation is saved.

**What should I do if the external file is password-protected?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](/cells/net/)) and link to that copy.

**Can multiple charts reference the same external workbook?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.
