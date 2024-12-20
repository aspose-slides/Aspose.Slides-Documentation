---
title: Working Solution for Worksheet Resizing
type: docs
weight: 40
url: /net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- preview image
- image resizing
- Excel
- worksheet
- PowerPoint
- presentation
- C#
-Aspose.Slides for .NET
description: "Working solution for worksheet resizing in PowerPoint presentations using C#"
---

{{% alert color="primary" %}} 

It has been observed that Excel worksheets embedded as OLE objects in a PowerPoint presentation through Aspose components are resized to an unidentified scale after the first activation. This behavior creates a noticeable visual difference in the presentation between the pre- and post-activation states of the OLE object. We have investigated this issue in detail and provided a solution, which is covered in this article.

{{% /alert %}} 

## **Background**

In the article [Manage OLE](/slides/net/manage-ole/), we explained how to add an OLE frame to a PowerPoint presentation using Aspose.Slides for .NET. To address the [object preview issue](/slides/net/object-preview-issue-when-adding-oleobjectframe/), we assigned an image of the selected worksheet area to the OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the worksheet image, the Excel workbook is activated. End users can make any desired changes to the actual Excel workbook and then return to the slide by clicking outside the activated Excel workbook. The size of the OLE object frame will change when the user returns to the slide. The resizing factor will vary depending on the size of the OLE object frame and the embedded Excel workbook. 

## **Cause of Resizing**

Since the Excel workbook has its own window size, it tries to retain its original size upon first activation. On the other hand, the OLE object frame has its own size. According to Microsoft, when the Excel workbook is activated, Excel and PowerPoint negotiate the size to ensure it maintains the correct proportions as part of the embedding process. The resizing occurs based on the differences between the Excel window size and the OLE object frame's size and position.

## **Working Solution**

There are two possible solutions to avoid the resizing effect.

- Scale the OLE frame size in the PowerPoint presentation to match the height and width of the desired number of rows and columns in the OLE frame.
- Keep the OLE frame size constant and scale the size of the participating rows and columns to fit within the selected OLE frame size.

## **Scale the OLE Frame Size**

In this approach, we will learn how to set the OLE frame size of the embedded Excel workbook to match the cumulative size of the participating rows and columns in the Excel worksheet.

Suppose we have a template Excel sheet and want to add it to a presentation as an OLE frame. In this scenario, the size of the OLE object frame will first be calculated based on the cumulative row heights and column widths of the participating rows and columns in the workbook. Then, we will set the size of the OLE frame to this calculated value. To avoid the red "EMBEDDED OLE OBJECT" message for the OLE frame in PowerPoint, we will also capture an image of the desired portions of the rows and columns in the workbook and set it as the OLE frame image.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange);

// Get the width and height of the OLE image in points.
using var oleBitmap = new Bitmap(imageStream);
var imageWidth = oleBitmap.Width * 72 / oleBitmap.HorizontalResolution;
var imageHeight = oleBitmap.Height * 72 / oleBitmap.VerticalResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = 96,
        HorizontalResolution = 96,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Scale the Cell Range Size**

In this approach, we will learn how to scale the heights of the participating rows and the width of the participating columns to match a custom OLE frame size.

Suppose we have a template Excel sheet and want to add it to a presentation as an OLE frame. In this scenario, we will set the size of the OLE frame and scale the size of the rows and columns that participate in the OLE frame area. We will then save the workbook to a stream to apply the changes and convert it to a byte array for adding it to the OLE frame. To avoid the red "EMBEDDED OLE OBJECT" message for the OLE frame in PowerPoint, we will also capture an image of the desired portions of the rows and columns in the workbook and set it as the OLE frame image.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Scale the cell range to fit the frame size.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange);

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">The expected width of the cell range in points.</param>
/// <param name="height">The expected height of the cell range in points.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = 96,
        HorizontalResolution = 96,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Conclusion**

{{% alert color="primary" %}}

There are two approaches to fix the worksheet resizing issue. The selection of the appropriate approach depends on the specific requirements and use case. Both approaches work the same way, whether the presentations are created from a template or from scratch. Additionally, there is no limit on the size of the OLE object frame in this solution.

{{% /alert %}}

## **Related Articles**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
