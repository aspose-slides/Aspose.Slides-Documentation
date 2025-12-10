---
title: 工作表缩放的工作解决方案
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

已观察到，通过 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，第一次激活时会被缩放到未知的比例。这会导致 OLE 对象在激活前后的演示效果出现明显的视觉差异。我们对该问题进行了深入研究，并提供了解决方案，详见本文。

{{% /alert %}} 

## **Background**

在文章 [Manage OLE](/slides/zh/net/manage-ole/) 中，我们说明了如何使用 Aspose.Slides for .NET 向 PowerPoint 演示文稿添加 OLE 框。为了解决 [object preview issue](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/) ，我们将选定工作表区域的图像分配给 OLE 对象框。在生成的演示文稿中，双击显示工作表图像的 OLE 框时，会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后点击激活的 Excel 工作簿之外的区域返回幻灯片。返回幻灯片时，OLE 对象框的大小会发生变化。缩放因子取决于 OLE 对象框的大小以及嵌入的 Excel 工作簿的大小。

## **Cause of Resizing**

由于 Excel 工作簿有自己的窗口大小，它会尝试在首次激活时保持原始尺寸。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说法，Excel 工作簿激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中的比例保持正确。缩放基于 Excel 窗口尺寸与 OLE 对象框尺寸和位置之间的差异产生。

## **Working Solution**

有两种可能的解决方案可以避免缩放效果。

- 将 PowerPoint 演示文稿中的 OLE 框尺寸缩放至与 OLE 框中所需行列数的高度和宽度相匹配。
- 保持 OLE 框尺寸不变，缩放参与的行列大小，使其适配选定的 OLE 框尺寸。

### **Scale the OLE Frame Size**

在此方法中，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框尺寸设置为与工作表中参与的行列累计尺寸相匹配。

假设我们有一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在这种情况下，OLE 对象框的尺寸首先根据工作簿中参与的行高和列宽的累计值进行计算。然后，我们将 OLE 框的尺寸设置为此计算值。为避免 PowerPoint 中 OLE 框出现红色 “EMBEDDED OLE OBJECT” 提示，我们还会捕获工作簿中所需行列的图像，并将其设为 OLE 框的图片。
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 设置工作簿文件作为 OLE 对象在 PowerPoint 中使用时的显示尺寸。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// 获取 OLE 图像的宽度和高度（单位为点）。
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// 我们需要使用修改后的工作簿。
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


### **Scale the Cell Range Size**

在此方法中，我们将学习如何将参与行的高度和参与列的宽度缩放至匹配自定义的 OLE 框尺寸。

假设我们有一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在这种情况下，我们先设置 OLE 框的尺寸，然后缩放位于 OLE 框区域内的行列尺寸。随后将工作簿保存到流中以应用更改，并转换为字节数组以添加到 OLE 框中。为避免 PowerPoint 中 OLE 框出现红色 “EMBEDDED OLE OBJECT” 提示，我们同样会捕获工作簿中所需行列的图像，并将其设为 OLE 框的图片。
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 设置工作簿文件作为 OLE 对象在 PowerPoint 中使用时的显示尺寸。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 将单元格范围缩放以适应框架尺寸。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 我们需要使用修改后的工作簿。
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
/// <param name="width">单元格范围的预期宽度（单位为点）。</param>
/// <param name="height">单元格范围的预期高度（单位为点）。</param>
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


## **Conclusion**

{{% alert color="primary" %}}

解决工作表缩放问题有两种方法。选择哪种方法取决于具体需求和使用场景。两种方法在基于模板创建演示文稿或从头创建演示文稿时表现相同。此外，此方案对 OLE 对象框的尺寸没有限制。

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**  
This happens because Excel tries to maintain the original window size when activated, while the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain aspect ratio, which can cause the resizing.

**Is it possible to prevent this resizing issue entirely?**  
Yes. By scaling the OLE frame to fit the Excel cell range size or scaling the cell range to fit the desired OLE frame size, you can prevent unwanted resizing.

**Which scaling method should I use, OLE frame scaling or cell range scaling?**  
Select **OLE frame scaling** if you want to maintain the original Excel row and column sizes. Select **cell range scaling** if you want a fixed size for the OLE frame in your presentation.

**Will these solutions work if my presentation is based on a template?**  
Yes. Both solutions work for presentations created from templates and from scratch.

**Is there a limit to the size of the OLE frame when using these methods?**  
No. You can make the OLE object frame any size as long as you set the scale appropriately.

**Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?**  
Yes. By taking a snapshot of the target Excel cell range and setting it as the OLE frame's placeholder image, you can display a custom preview image in place of the default placeholder.

## **Related Articles**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)