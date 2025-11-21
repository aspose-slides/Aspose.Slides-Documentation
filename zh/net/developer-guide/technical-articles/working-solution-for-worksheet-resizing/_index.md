---
title: 工作表缩放的可行解决方案
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
description: "在演示文稿中修复 Excel 工作表 OLE 缩放问题：通过两种方式保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---

{{% alert color="primary" %}} 

已观察到，通过 Aspose 组件在 PowerPoint 演示文稿中嵌入的 Excel 工作表作为 OLE 对象后，在第一次激活后会被缩放到未知的比例。此行为导致 OLE 对象在激活前后呈现出明显的视觉差异。我们已对该问题进行了深入调查并提供了解决方案，本文即对此进行介绍。

{{% /alert %}} 

## **背景**

在文章[管理 OLE](/slides/zh/net/manage-ole/)中，我们说明了如何使用 Aspose.Slides for .NET 向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框指定了选定工作表区域的图像。在生成的演示文稿中，双击显示工作表图像的 OLE 对象框会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后点击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。缩放比例取决于 OLE 对象框的大小和嵌入的 Excel 工作簿的大小。

## **缩放原因**

Excel 工作簿拥有自己的窗口大小，首次激活时会尝试保持原始大小。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说明，Excel 工作簿激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中过保持正确的比例。缩放依据的是 Excel 窗口尺寸与 OLE 对象框尺寸及位置之间的差异。

## **可行方案**

有两种可能的解决办法可避免缩放效应。

- 在 PowerPoint 演示文稿中缩放 OLE 框的尺寸，使其匹配 OLE 框中所需行列的高度和宽度。
- 保持 OLE 框尺寸不变，缩放参与的行和列的尺寸以适配选定的 OLE 框大小。

### **缩放 OLE 框尺寸**

采用此方法时，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框尺寸设置为与工作表中参与行列的累计尺寸相匹配。

假设我们有一个模板 Excel 表格，想将其以 OLE 框形式添加到演示文稿中。在此场景下，OLE 对象框的尺寸将首先依据工作簿中参与行的累计行高和参与列的累计列宽进行计算。随后，我们将把 OLE 框的尺寸设置为该计算值。为避免 PowerPoint 中 OLE 框出现红色“EMBEDDED OLE OBJECT”提示，我们还会捕获工作簿中所需行列的图像，并将其设为 OLE 框的预览图像。
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 当工作簿文件作为 PowerPoint 中的 OLE 对象使用时，设置显示的大小。
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


### **缩放单元格范围尺寸**

采用此方法时，我们将学习如何缩放参与的行高和列宽，以匹配自定义的 OLE 框尺寸。

同样假设我们有一个模板 Excel 表格，想将其以 OLE 框形式添加到演示文稿中。在此场景下，我们先设置 OLE 框的尺寸，然后缩放参与 OLE 框区域的行列大小。随后将工作簿保存到流中以应用更改，并转换为字节数组以供添加到 OLE 框。为避免 PowerPoint 中 OLE 框出现红色“EMBEDDED OLE OBJECT”提示，我们同样会捕获工作簿中所需行列的图像，并将其设为 OLE 框的预览图像。
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 设置当工作簿文件在 PowerPoint 中作为 OLE 对象使用时的显示大小。
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

{{% alert color="primary" %}}

解决工作表缩放问题有两种方法。选择哪种方法取决于具体需求和使用场景。无论演示文稿是基于模板创建还是从空白开始，两种方法的工作原理相同。此外，此方案对 OLE 对象框的尺寸没有限制。

{{% /alert %}}

## FAQ

**问：为什么嵌入的 Excel 工作表首次在 PowerPoint 中激活时会改变尺寸？**  
答：因为 Excel 在激活时会尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，导致出现缩放。

**问：是否可以彻底避免此缩放问题？**  
答：可以。通过将 OLE 框缩放至匹配 Excel 单元格范围的尺寸，或将单元格范围缩放至匹配期望的 OLE 框尺寸，均可防止不必要的缩放。

**问：应该使用哪种缩放方式，OLE 框缩放还是单元格范围缩放？**  
答：如果希望保留 Excel 原始行列尺寸，请选择**OLE 框缩放**。如果希望在演示文稿中固定 OLE 框大小，请选择**单元格范围缩放**。

**问：这些解决方案在基于模板的演示文稿中也适用吗？**  
答：适用。两种方案都可用于基于模板创建的演示文稿以及从零开始创建的演示文稿。

**问：使用这些方法时 OLE 框的尺寸是否有限制？**  
答：没有限制。只要适当设置缩放比例，OLE 对象框可以任意大小。

**问：如何避免 PowerPoint 中的“EMBEDDED OLE OBJECT”占位文本？**  
答：通过对目标 Excel 单元格范围进行快照，并将其设为 OLE 框的占位图像，即可显示自定义的预览图像，取代默认的占位文本。

## **相关文档**

[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)