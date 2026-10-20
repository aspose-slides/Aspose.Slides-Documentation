---
title: 工作表大小调整的可行解决方案
type: docs
weight: 40
url: /zh/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 大小调整：通过两种方式保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

使用 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿时，可能在首次激活后出现意外的大小调整。此行为会导致 OLE 对象在激活前后出现明显的视觉差异。本文解释了此问题并描述了两种解决方案。

{{% /alert %}} 

## **背景**

在文章[管理 OLE](/slides/zh/net/manage-ole/)中，我们说明了如何使用 Aspose.Slides for .NET 向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)，我们将选定工作表区域的图像分配给 OLE 对象框。在输出的演示文稿中，当双击显示工作表图像的 OLE 对象框时，Excel 工作簿会被激活。最终用户可以对实际的 Excel 工作簿进行任意更改，然后通过点击激活的 Excel 工作簿之外的区域返回到幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。调整大小的因子会根据 OLE 对象框的大小和嵌入的 Excel 工作簿的大小而有所不同。

## **调整大小的原因**

由于 Excel 工作簿具有自己的窗口大小，它会尝试在首次激活时保持原始大小。另一方面，OLE 对象框也有自己的大小。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商大小，以确保在嵌入过程中保持正确的比例。大小调整是依据 Excel 窗口大小与 OLE 对象框的大小和位置之间的差异而发生的。

## **工作解决方案**

有两种可能的解决方案可以避免大小调整的影响。

- 将 PowerPoint 演示文稿中的 OLE 框缩放，以匹配所选行和列的总高度和宽度。
- 保持 OLE 框大小不变，并将所选行和列缩放以适应其内部。

### **缩放 OLE 框大小**

此方法将 OLE 框大小设置为匹配嵌入的 Excel 工作表中所选行和列的总高度和宽度。

示例加载现有的 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) 定义要显示的范围。预览以 96 DPI 渲染，并使用每英寸 72 点将像素尺寸转换为点。[ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) 将修改后的工作簿嵌入具有这些尺寸的框中。通过 [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) 将预览分配，以替换已保存演示文稿中 “EMBEDDED OLE OBJECT” 占位符。

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

// 设置工作簿文件作为 PowerPoint 中 OLE 对象时的显示尺寸。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// 获取 OLE 图像的宽度和高度（单位为点）。
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// 我们需要使用已修改的工作簿。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// 将 OLE 图像添加到演示文稿资源中。
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// 创建 OLE 对象框。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

预览帮助程序将 [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) 设置为选定范围，并去除页边距、页眉和页脚。启用 [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) 后，[SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) 将该范围渲染为 PNG 图像。帮助程序在返回图像流以供演示文稿使用之前会将其倒回到起始位置。

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

此方法将所选行的高度和所选列的宽度缩放，以匹配自定义的 OLE 框大小。

示例加载现有的 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) 定义要显示的范围，下面的帮助程序将该范围缩放以适应宽 400 点、高 100 点的框。将修改后的工作簿保存到流后，[ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) 按指定大小嵌入。通过 [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) 将以 96 DPI 渲染的预览分配，使已保存的演示文稿显示选定的单元格而不是默认占位符。

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

// 在 PowerPoint 中将工作簿文件用作 OLE 对象时设置显示尺寸。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 将单元格范围缩放以适应框架尺寸。
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

缩放帮助程序为选定范围计算独立的宽度和高度比例，保持列的相对宽度和行的相对高度。它在使用 [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) 和 [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) 应用之前，将计算得到的尺寸从点转换为英寸。选定范围的宽度和高度必须均非零。

```cs
/// <param name="width">单元格范围在点单位下的预期宽度。</param>
/// <param name="height">单元格范围在点单位下的预期高度。</param>
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

此预览帮助程序使用 [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) 渲染已调整大小的范围。它将 [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) 限制为该范围，去除页边距、页眉和页脚，并返回定位在起始位置的 PNG 流。

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

{{% alert color="info" title="Note" %}}

有两种方法可以解决工作表大小调整问题。请选择最符合您需求和使用场景的方法。两种方法的工作方式相同，无论演示文稿是从模板创建还是从头开始。另外，在此解决方案中对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

这是因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有其自身的尺寸。PowerPoint 与 Excel 协商尺寸以保持纵横比，这可能导致大小调整。

**是否可以完全防止此大小调整问题？**

可以。通过将 OLE 框缩放以匹配 Excel 单元格范围大小，或将单元格范围缩放以适应所需的 OLE 框大小，您可以防止不必要的大小调整。

**我应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？**

如果您想保持原始的 Excel 行列大小，请选择 **OLE 框缩放**。如果您希望在演示文稿中 OLE 框保持固定大小，请选择 **单元格范围缩放**。

**如果我的演示文稿基于模板，这些解决方案仍然有效吗？**

是的。两种方案都适用于基于模板创建的演示文稿以及从头开始创建的演示文稿。

**使用这些方法时，OLE 框的大小是否有限制？**

没有。只要适当设置比例，OLE 对象框可以任意大小。

**有没有办法避免 PowerPoint 中的 “EMBEDDED OLE OBJECT” 占位符文本？**

有。通过对目标 Excel 单元格范围进行快照并将其设置为 OLE 框的占位符图像，您可以显示自定义的预览图像来替代默认占位符。

## **相关文章**

[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)