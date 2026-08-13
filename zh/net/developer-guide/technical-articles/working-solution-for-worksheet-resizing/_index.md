---
title: 工作表缩放的可行方案
type: docs
weight: 40
url: /zh/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像缩放
- Excel
- 工作表
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "修复演示文稿中 Excel 工作表 OLE 缩放问题：通过两种方式保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" %}} 

观察到通过 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后会被缩放到未知的比例。这会导致 OLE 对象在激活前后的视觉表现出现明显差异。我们已对此问题进行详细调查并提供了解决方案，详见本文。

{{% /alert %}} 

## **背景**

在文章[管理 OLE](/slides/zh/net/manage-ole/)中，我们解释了如何使用 Aspose.Slides for .NET 将 OLE 框添加到 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了选定工作表区域的图像。在输出的演示文稿中，当双击显示工作表图像的 OLE 对象框时，Excel 工作簿会被激活。最终用户可以对实际的 Excel 工作簿进行任何所需的更改，然后通过点击激活的 Excel 工作簿之外的区域返回到幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。缩放因子取决于 OLE 对象框的大小和嵌入的 Excel 工作簿的大小。

## **缩放原因**

由于 Excel 工作簿有其自身的窗口尺寸，它在首次激活时会尝试保留原始大小。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。缩放是基于 Excel 窗口尺寸与 OLE 对象框的尺寸和位置之间的差异而产生的。

## **可行方案**

有两种可能的解决方案来避免缩放效果。

- 将 PowerPoint 演示文稿中的 OLE 框大小缩放至与 OLE 框中所需的行列数的高度和宽度匹配。
- 保持 OLE 框大小不变，并将参与的行列大小缩放至适应所选的 OLE 框大小。

### **缩放 OLE 框大小**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿的 OLE 框大小，以匹配 Excel 工作表中参与的行和列的累计大小。

假设我们有一个模板 Excel 工作表，并希望将其作为 OLE 框添加到演示文稿中。在此情形下，OLE 对象框的大小首先基于工作簿中参与的行高和列宽的累计值进行计算。然后，我们将把 OLE 框的大小设置为该计算值。为避免 PowerPoint 中 OLE 框出现红色的“EMBEDDED OLE OBJECT”提示，我们还会捕获工作簿中所需行列的图像并将其设为 OLE 框的图像。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

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
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
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
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
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

### **缩放单元格范围大小**

在此方法中，我们将学习如何将参与的行的高度和列的宽度缩放至匹配自定义的 OLE 框大小。

假设我们有一个模板 Excel 工作表，并希望将其作为 OLE 框添加到演示文稿中。在此情形下，我们将设置 OLE 框的大小，并将参与 OLE 框区域的行列大小进行缩放。随后，我们将工作簿保存到流中以应用更改，并将其转换为字节数组以添加到 OLE 框中。为避免 PowerPoint 中 OLE 框出现红色的“EMBEDDED OLE OBJECT”提示，我们还会捕获工作簿中所需行列的图像并将其设为 OLE 框的图像。

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 当工作簿文件在 PowerPoint 中作为 OLE 对象使用时，设置其显示大小。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 将单元格范围缩放以适应框架大小。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 我们需要使用已修改的工作簿。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// 将 OLE 图像添加到演示文稿资源中。
var oleImage = presentation.Images.AddImage(imageStream);

// 创建 OLE 对象框。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">单元格范围的预期宽度（单位：点）。</param>
/// <param name="height">单元格范围的预期高度（单位：点）。</param>
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
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
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
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
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

## **结论**

{{% alert color="info" %}}

有两种方法可以解决工作表缩放问题。选择合适的方法取决于具体需求和使用场景。无论演示文稿是基于模板还是从头创建，两种方法的工作方式相同。此外，此解决方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

### 为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？

这是因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持宽高比，从而导致缩放。

### 是否可以完全防止此缩放问题？

可以。通过将 OLE 框缩放至匹配 Excel 单元格范围大小，或将单元格范围缩放至匹配所需的 OLE 框大小，您可以避免不必要的缩放。

### 我应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？

如果您想保持原始 Excel 行列尺寸，请选择 **OLE 框缩放**。如果您希望在演示文稿中拥有固定的 OLE 框大小，请选择 **单元格范围缩放**。

### 如果我的演示文稿基于模板，这些解决方案是否有效？

是的。两种解决方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

### 使用这些方法时 OLE 框的大小是否有限制？

没有。只要您适当地设置缩放比例，OLE 对象框可以任意大小。

### 是否有办法避免 PowerPoint 中的“EMBEDDED OLE OBJECT”占位文本？

有。通过对目标 Excel 单元格范围进行快照并将其设为 OLE 框的占位图像，您可以显示自定义的预览图像以替代默认占位符。

## **相关文章**

[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)