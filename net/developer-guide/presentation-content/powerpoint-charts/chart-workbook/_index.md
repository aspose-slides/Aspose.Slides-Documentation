---
title: Chart Workbook
type: docs
weight: 70
url: /net/chart-workbook/
---

## **Chart Workbook**
### **Set Chart Data from Workbook**
A new property has been added to set chart data from workbook. Now Aspose.Slides does allow ReadWorkbookStream() and WrtiteWorkbookStream() methods to read and write chart data workbooks containing chart data edited using Aspose.Cells. However, the chart data needs to be organized in same way or of similar type as of source type. Below sample example is given.

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


### **Set WorkBook Cell as Chart DataLabel**
Aspose.Slides for .NET provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();



string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instantiate Presentation class that represents a presentation file 

using (Presentation pres = new Presentation(dataDir + "chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save(path + "resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


### **Get Chart External Data Source Workbook Path**
Aspose.Slides for .NET provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation pres = new Presentation(dataDir+"pres.pptx"))
           {
ISlide slide = pres.Slides[1];
IChart chart = (IChart)slide.Shapes[0];
ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
if (sourceType == ChartDataSourceType.ExternalWorkbook)
{
string path = chart.ChartData.ExternalWorkbookPath;
 }
}
    // Saving presentation
    pres.Save(dataDir + "Result.pptx", SaveFormat.Pptx);
}
```




## **External Workbook**
{{% alert color="primary" %}} 
Aspose.Slides for .NET for 19.4 supports external workbooks as a data source for charts.
{{% /alert %}} 
### **Create External Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides for .NET. **IChartData.ReadWorkbookStream()** and **IChartData.SetExternalWorkbook()** methods can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation(dataDir + "presentation.pptx"))
{
    string externalWbPath = dataDir + "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);

    if (File.Exists(externalWbPath))
        File.Delete(externalWbPath);

    using (FileStream fileStream = new FileStream(externalWbPath, FileMode.CreateNew))
    {
        byte[] worbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(worbookData, 0, worbookData.Length);
    }

    chart.ChartData.SetExternalWorkbook(externalWbPath);

    pres.Save(dataDir + "Presentation_with_externalWbPath.pptx", SaveFormat.Pptx);
}
```




### **Set External Workbook**
Using Aspose.Slides for .NET, an external workbook can be assigned to a chart as a data source. For this purpose **IChartData.SetExternalWorkbook** method has been added.

**SetExternalWorkbook()** method can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(dataDir+ "externalWorkbook.xlsx");
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save(dataDir + "Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

The **SetExternalWorkbook(System::String workbookPath, bool updateChartData)** method has been added with **updateChartData** parameter to the **ChartData** and **IChartData** classes.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***false*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **true** chart data will be updated from the target workbook as the **SetExternalWorkbook(System::String)** method does.

```c#
 // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Charts();

            using (Presentation pres = new Presentation())
            {
                IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
                IChartData chartData = chart.ChartData;

                (chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);


                pres.Save(dataDir + "SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
            }
```


### **Edit Chart Data**
Using Aspose.Slides for .NET, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation(dataDir + "presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save(dataDir + "presentation_out.pptx", SaveFormat.Pptx);
}
```



