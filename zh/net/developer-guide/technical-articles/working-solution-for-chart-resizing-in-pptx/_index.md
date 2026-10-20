---
title: PPTX 中图表大小调整的可行解决方案
type: docs
weight: 60
url: /zh/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表大小调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 PPTX 中使用嵌入的 Excel OLE 对象与 Aspose.Slides for .NET 时，修复意外的图表大小调整。设置固定图表尺寸，以保持图表和 OLE 框尺寸一致。"
---
## **背景**

使用 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在第一次激活后可能会改变大小。这会导致图表在激活前后的外观出现明显差异。本文解释了发生重新调整大小的原因，并展示了通过将固定的图表尺寸与 OLE 框匹配来防止此问题的方法。

在 [创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) 中，我们说明了如何使用 Aspose.Cells for .NET 创建 Excel 图表并使用 Aspose.Slides for .NET 将其嵌入 PowerPoint 演示文稿。为了解决 [对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在生成的演示文稿中，双击显示图表图像的 OLE 对象框时，Excel 图表会被激活。用户可以编辑嵌入的 Excel 工作簿，然后通过点击激活工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，且重新调整大小的比例取决于 OLE 对象框和嵌入的 Excel 工作簿的原始尺寸。

## **重新调整大小的原因**

嵌入的 Excel 工作簿拥有自己的窗口尺寸，Excel 在对象首次激活时会尝试保留该尺寸。幻灯片上的 OLE 框具有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商对象的大小，以在嵌入过程中保持其比例。因此，工作簿窗口与 OLE 框之间的差异可能导致对象重新调整大小。

## **可行的解决方案**

将图表尺寸与幻灯片上的 OLE 框匹配，并使图表尺寸独立于工作簿窗口。此解决方案适用于新演示文稿或现有模板。

示例需要 Aspose.Cells for .NET 和 Aspose.Slides for .NET。它在活动图表工作表上创建一个简单的柱形图，并以 XLS 格式嵌入工作簿。未分配图表预览图像；图表将在 PowerPoint 中激活 OLE 对象时可见。

示例创建了一个新的演示文稿，其中包含一个 9.5 × 4 英寸的 OLE 框，位于左边缘 0.5 英寸、顶部 1 英寸处。幻灯片坐标和尺寸以点为单位（每英寸 72 点）。对于已有演示文稿，请参见 [使用模板](#use-a-template)。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 幻灯片坐标和尺寸以点为单位（每英寸 72 点）。
var width = 684f; // 9.5 英寸。
var height = 288f; // 4 英寸。

chart.SizeWithWindow = false;
// 使用每英寸 96 像素将点转换为图表像素。
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **设置固定图表尺寸**

将 [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) 设置为 false，以便图表尺寸独立于工作簿窗口。通过 [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) 和 [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) 设置 [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) 的尺寸，并使用每英寸 96 像素的比例将点转换为像素：一个 684 × 288 点的框对应于 912 × 384 像素的图表。将 [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) 设置为 [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) 的 Custom 值。示例使用 [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) 将工作簿嵌入，并保存一个带有 9.5 × 4 英寸 OLE 框的演示文稿。

## **使用模板**

对于已有的演示文稿，尺寸计算逻辑相同。要改编示例：

1. 加载模板演示文稿，而不是创建空白演示文稿。
1. 检查第一张幻灯片是否至少包含三个形状，然后使用索引为 2 的形状作为占位符。
1. 从该形状获取框的宽度和高度，而不是使用固定值 684 和 288。保持尺寸计算不变。
1. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。
1. 在保存演示文稿之前移除占位符。

## **常见问题**

**为什么我的嵌入 Excel 图表在 PowerPoint 中激活后会改变大小？**

这发生是因为 Excel 在首次激活时尝试恢复原始窗口尺寸，而 PowerPoint 中的 OLE 对象框具有自己的尺寸。PowerPoint 与 Excel 协商大小以保持纵横比，这可能导致重新调整大小。

**如何保持图表和 OLE 框的尺寸一致？**

设置与 OLE 框匹配的固定图表尺寸，并在嵌入工作簿之前使用自定义图表打印尺寸。上面的示例展示了所需的设置和单位换算。

**仅匹配工作簿窗口尺寸够吗？**

仅匹配工作簿窗口尺寸并不能可靠地防止 OLE 框在激活后改变大小。请使用示例中显示的固定图表尺寸。

**此解决方案是否同时适用于基于模板的演示文稿和新演示文稿？**

是的。对于模板，使用占位符的尺寸和位置。对于新演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**

示例使用的是由 Aspose.Cells 创建的 Excel 工作簿。它未演示其他电子表格程序的激活行为。

## **相关章节**

- [创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [使用 PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)