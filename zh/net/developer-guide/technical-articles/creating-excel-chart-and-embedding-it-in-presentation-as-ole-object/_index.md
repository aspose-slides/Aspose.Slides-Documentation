---
title: 创建 Excel 图表并将其作为 OLE 对象嵌入到演示文稿中
type: docs
weight: 50
url: /zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Cells for .NET 创建 Excel 图表，并将工作簿嵌入到 PowerPoint 演示文稿中（使用 Aspose.Slides），包括图表预览。"
---
## **概述**

本文展示了如何使用 Aspose.Cells for .NET 创建 Excel 列图表，并将其工作簿嵌入到使用 Aspose.Slides for .NET 的 PowerPoint 演示文稿中。嵌入的工作簿包含源数据和图表。单独的 PNG 预览在 OLE 对象激活之前显示幻灯片上的图表。

结果是嵌入的 Excel 对象，而非原生的 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

在 C# 项目中添加对 Aspose.Cells for .NET 和 Aspose.Slides for .NET 的引用。示例使用顶层语句，要求 C# 9 或更高版本。生成演示文稿无需 Microsoft Office。

无需输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入当前工作目录。运行时若不在评估模式，请为两个产品应用许可证。

## **嵌入工作原理**

1. 创建一个包含数据工作表和图表工作表的工作簿。
1. 将图表工作表设为活动工作表，使工作簿打开时显示图表。
1. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。
1. 将工作簿保存为内存中的 XLSX 并将其字节嵌入到幻灯片中。
1. 将 PNG 设为 OLE 对象的预览图像，并将演示文稿保存为 PPTX。

工作簿的显示范围和幻灯片上的框架具有不同的作用。[SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) 接受基于零的起始/结束行和列索引。相反，[ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) 接受顶行、左列、底行和右列。示例使用行索引 55 和列索引 25 作为右下边界；这些值是布局选择，而不是数据行或列的数量。

幻灯片框架使用点（pt）。示例将其放置在幻灯片内部并居中，同时保持 PNG 的宽高比，而不是将预览拉伸以填满幻灯片。

## **创建并嵌入图表**

以下完整示例向 `DataSheet` 填充四行五列的数值。每行对应一个图表系列。保存工作簿前，将 `ChartSheet` 设为活动工作表。

工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 的 `xlsx` 扩展名。PNG 直接从其流中加载，无需中间的位图转换。通过 [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) 进行分配可替换默认的 OLE 占位符。

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

// 渲染图表预览并单独序列化可编辑的工作簿。
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

## **预期结果**

`OutputChart.pptx` 包含一个幻灯片，内嵌 Excel 工作簿并带有图表预览。工作簿包含原始数据和一个包含四个系列的列图表。预览居中显示在幻灯片上并保持比例。

![Excel 列图作为嵌入工作簿的预览显示](excel-chart-ole-preview.png)

在具备 Excel 的兼容桌面 PowerPoint 环境中，双击对象即可激活并编辑嵌入的工作簿。激活和编辑取决于宿主应用程序的 OLE 支持以及安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和其幻灯片预览是独立的内容。提供图表图像，使幻灯片显示图表而不是默认的“EMBEDDED OLE OBJECT”占位符。参见[在添加 OleObjectFrame 时的对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)。

**当我在代码中更改工作簿时，预览会自动更新吗？**

将预览视为快照。当以编程方式更新工作簿数据时，需要重新生成图表图像并替换预览以及嵌入的工作簿数据。

**我可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿另存为 XLS 格式，并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际工作簿格式匹配，仅更改扩展名并不会转换数据。

**为什么对象在激活后会改变大小？**

宿主应用程序在激活工作簿时可以更新 OLE 对象的呈现方式。工作簿的 OLE 显示范围和幻灯片框架尺寸都很重要。参见[在 PPTX 中图表大小调整的可行解决方案](/slides/zh/net/working-solution-for-chart-resizing-in-pptx/)。

## **相关章节**

- [在 PPTX 中图表大小调整的可行解决方案](/slides/zh/net/working-solution-for-chart-resizing-in-pptx/)
- [在添加 OleObjectFrame 时的对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)
- [使用 PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)