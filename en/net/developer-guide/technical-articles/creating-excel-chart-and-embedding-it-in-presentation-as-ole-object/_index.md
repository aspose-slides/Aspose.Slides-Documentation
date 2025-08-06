---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create Excel charts and embed them as OLE objects in PowerPoint and OpenDocument presentations with C#/.NET. Step-by-step guide with code samples."
---

## **Background**

In PowerPoint, using editable charts to display data graphically is a common practice. Aspose supports creating Excel charts with Aspose.Cells for .NET, and these charts can then be embedded as OLE objects in PowerPoint slides through Aspose.Slides for .NET. This article covers the necessary steps and provides C# code samples for creating an Excel chart and embedding it as an OLE object in a PowerPoint presentation using Aspose.Cells and Aspose.Slides.

## **Required Steps**

The following sequence of steps is required to create and embed an Excel chart as an OLE object in a PowerPoint slide:

1. Create an Excel chart using Aspose.Cells.
1. Set the OLE size of the Excel chart using Aspose.Cells.
1. Get an image of the Excel chart with Aspose.Cells.
1. Embed the Excel chart as an OLE object in a PPTX presentation using Aspose.Slides.
1. Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address the [object preview issue](/slides/net/object-preview-issue-when-adding-oleobjectframe/).
1. Save the presentation to disk in PPTX format.

## **Implementation of the Required Steps**

The C# implementation of the above steps is as follows:

```cs
// Step - 1: Create an Excel chart using Aspose.Cells.
// ---------------------------------------------------
// Create a workbook.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Set the OLE size of the chart using Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Get the image of the chart with Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Save the workbook to a stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Step - 4 AND 5
// ==============
// Step - 4: Embed the chart as an OLE object inside a .ppt presentation using Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Step - 5: Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address Object Preview Issue.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Add the workbook to the slide.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Step - 6: Save the output presentation to disk.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // An array of cell names.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // An array of cell data.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Add a new worksheet to populate cells with data.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Populate the data sheet with data.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Add a chart sheet.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Add a chart to the chart sheet with data series from the data sheet.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Set the chart sheet as an active sheet.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

The presentation created by the above method will contain the Excel chart as an OLE object that can be activated by double-clicking the OLE object frame.

## **Conclusion**

By using Aspose.Cells for .NET together with Aspose.Slides for .NET, we can create any Excel chart supported by Aspose.Cells and embed the chart as an OLE object in a PowerPoint slide. The OLE size of the Excel chart can also be defined. End users can then edit the Excel chart like any other OLE object.

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/net/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
