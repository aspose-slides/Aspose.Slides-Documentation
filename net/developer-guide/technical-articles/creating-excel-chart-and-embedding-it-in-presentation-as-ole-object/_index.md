---
title: Creating Excel Chart and Embedding it in Presentation as OLE Object
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

In PowerPoint Slides, the use of editable chats for graphical display of the data is a common activity. Aspose provides the support of creating the Excel Charts with the use of Aspose.Cells for .NET and further these charts can be embedded as an OLE Object in the PowerPoint Slide through Aspose.Slides for .NET. This article covers the required steps along with the implementation in C# and VB.NET to create and embed an MS Excel Chart as an OLE Object in PowerPoint presentation by using Aspose.Cells for .NET and Aspose.Slides for .NET.

{{% /alert %}} 
## **Required Steps**
Following sequence of steps is required to create and embed an Excel Chart as an OLE Object in the PowerPoint Slide:

1. Create an Excel Chart using Aspose.Cells for .NET.# Set the OLE size of the Excel Chart. using Aspose.Cells for .NET.# Get the image of the Excel Chart with Aspose.Cells for .NET.# Embed the Excel Chart as an OLE Object inside PPTX presentation using Aspose.Slides for .NET.# Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue# Write the output presentation to disk in PPTX format
## **Implementation of the Required Steps**
The implementation of the above steps in C# and Visual Basic is as under:

```c#
//Step - 1: Create an excel chart using Aspose.Cells
//--------------------------------------------------
//Create a workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: Set the OLE size of the chart. using Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Get the image of the chart with Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  AND 5
//-----------------------------------------------------------
//Step - 4: Embed the chart as an OLE object inside .ppt presentation using Aspose.Slides
//-----------------------------------------------------------
//Step - 5: Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue
//-----------------------------------------------------------
//Create a presentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Add the workbook on slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: Write the output presentation on disk
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Array of cell names
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array of cell data
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Add a new worksheet to populate cells with data
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Populate DataSheet with data
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Add a chart sheet
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Add a chart in ChartSheet with data series from DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Set ChartSheet an active sheet
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;
    int x = 0;
    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);
    
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = null;
    oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, dataInfo);
    oof.SubstitutePictureFormat.Picture.Image = pres.Images.AddImage((System.Drawing.Image)imgChart);
}
```





{{% alert color="primary" %}} 

The presentation created through above method, will carry the Excel chart as OLE Object that can be activated by double clicking the OLE Object Frame.

{{% /alert %}} 
## **Conclusion**
{{% alert color="primary" %}} 

By using Aspose.Cells for .NET along with Aspose.Slides for .NET, we can create any of the Excel Charts as supported by Aspose.Cells for .NET and embed the created chart as an OLE Object in a PowerPoint Slide. The OLE Size of the Excel Chart can also be defined. The end users can further edit the Excel Chart like any other OLE Object.

{{% /alert %}} 
## **Related Sections**
[Working Solution for Chart Resizing](/slides/net/working-solution-for-chart-resizing-in-pptx/)[Object Changed Issue](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
