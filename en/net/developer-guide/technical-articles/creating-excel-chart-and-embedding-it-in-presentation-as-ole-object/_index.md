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
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create an Excel chart with Aspose.Cells for .NET and embed the workbook in a PowerPoint presentation with Aspose.Slides, including a chart preview."
---

## **Overview**

This article shows how to create an Excel column chart with Aspose.Cells for .NET and embed its workbook in a PowerPoint presentation with Aspose.Slides for .NET. The embedded workbook contains both the source data and the chart. A separate PNG preview displays the chart on the slide before the OLE object is activated.

The result is an embedded Excel object, not a native PowerPoint chart. Editing the workbook through OLE requires a desktop application that supports OLE activation and a compatible Excel installation.

## **Prerequisites**

Add references to Aspose.Cells for .NET and Aspose.Slides for .NET in your C# project. The example uses top-level statements and requires C# 9 or later. Microsoft Office is not required to generate the presentation with these libraries.

No input files are required: the example creates the data and chart in memory, then writes `OutputChart.pptx` to the current working directory. Apply licenses for both products when running outside evaluation mode.

## **How the Embedding Works**

1. Create a workbook with a data worksheet and a chart sheet.
1. Make the chart sheet active so that the workbook opens on the chart.
1. Set the workbook's OLE display range and render the chart to PNG.
1. Save the workbook as XLSX in memory and embed those bytes in a slide.
1. Assign the PNG as the OLE object's preview and save the presentation as PPTX.

The workbook display range and the frame on the slide have different roles. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) takes zero-based start/end row and column indices. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) instead takes the top row, left column, bottom row, and right column. The example uses row index 55 and column index 25 as the lower-right boundaries; these values are layout choices, not the number of data rows or columns.

The slide frame uses points. The example fits it within the slide and centers it while preserving the PNG's aspect ratio, rather than stretching the preview to fill the slide.

## **Create and Embed the Chart**

The following complete example populates `DataSheet` with four rows and five columns of values. Each row becomes a chart series. `ChartSheet` is selected as the active sheet before the workbook is saved.

The workbook is explicitly saved as XLSX, matching the `xlsx` extension passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). The PNG is loaded directly from its stream without an intermediate bitmap conversion. Assigning it through [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) replaces the default OLE placeholder.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Render the chart preview and serialize the editable workbook separately.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Expected Result**

`OutputChart.pptx` contains one slide with an embedded Excel workbook and a chart preview. The workbook contains the original data and a column chart with four series. The preview is centered on the slide and retains its proportions.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In a compatible desktop PowerPoint environment with Excel available, double-click the object to activate and edit the embedded workbook. Activation and editing depend on the host application's OLE support and security settings.

## **FAQ**

**Why is a preview image needed?**

The embedded workbook and its slide preview are separate content. Supply a chart image so the slide shows the chart instead of the default "EMBEDDED OLE OBJECT" placeholder. See [Object Preview Issue when Adding OleObjectFrame](/slides/net/object-preview-issue-when-adding-oleobjectframe/).

**Does the preview update automatically when I change the workbook in code?**

Treat the preview as a snapshot. When updating workbook data programmatically, regenerate the chart image and replace the preview as well as the embedded workbook data.

**Can I use XLS instead of XLSX?**

Yes. Save the workbook in XLS format and use `xls` as the embedded data extension. The extension must match the actual workbook format; changing the extension alone does not convert the data.

**Why might the object change size after activation?**

The host application can update the OLE object's presentation when it activates the workbook. The workbook's OLE display range and the slide frame dimensions both matter. See [Working Solution for Chart Resizing in PPTX](/slides/net/working-solution-for-chart-resizing-in-pptx/).

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/net/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
