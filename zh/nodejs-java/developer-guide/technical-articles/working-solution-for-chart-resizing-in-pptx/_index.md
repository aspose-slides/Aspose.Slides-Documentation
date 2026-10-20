---
title: PPTX 中图表大小调整的可行解决方案
type: docs
weight: 40
url: /zh/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表大小调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 嵌入 Excel OLE 对象时，修复 PPTX 中意外的图表大小调整。设置固定图表尺寸以保持图表和 OLE 框大小一致。"
---
## **概述**

使用 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，首次激活后可能会改变大小。这会导致图表在激活前后的外观出现明显差异。本文解释了大小调整的原因，并展示了通过将固定图表尺寸与 OLE 框匹配来防止此问题的办法。

在[创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我们说明了如何使用 Aspose.Cells for Node.js via Java 创建 Excel 图表并使用 Aspose.Slides for Node.js via Java 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。 在输出的演示文稿中，双击显示图表图像的 OLE 对象框会激活 Excel 图表。用户可以编辑嵌入的 Excel 工作簿，然后点击激活工作簿之外的区域返回幻灯片。当用户返回幻灯片时，OLE 对象框的大小会发生变化，且缩放因子取决于 OLE 对象框和嵌入的 Excel 工作簿的原始大小。

## **大小调整的原因**

嵌入的 Excel 工作簿拥有自己的窗口尺寸，Excel 在对象首次激活时会尝试保留该尺寸。幻灯片中的 OLE 框则拥有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商对象的尺寸，以在嵌入过程中保持其比例。因此，工作簿窗口与 OLE 框之间的差异可能导致对象大小变化。

## **可行方案**

将图表尺寸与幻灯片上的 OLE 框匹配，并保持图表尺寸独立于工作簿窗口。此方案适用于新建演示文稿或已有模板。

示例需要 Aspose.Cells for Node.js via Java 和 Aspose.Slides for Node.js via Java。安装 `aspose.cells`、`aspose.slides.via.java` 和 `java` Node.js 包。以下两个 CommonJS 脚本需在独立的 Node.js 进程中运行，使用相同的工作目录，因为两个 Aspose 包在加载时都会初始化 Java 桥。脚本在活动图表工作表上创建一个简单的柱状图，并以 XLS 格式嵌入工作簿。未分配图表预览图像；图表将在 PowerPoint 中激活 OLE 对象后可见。

示例创建一个新演示文稿，包含一个 9.5 × 4 英寸的 OLE 框，距左边缘 0.5 英寸，距顶部 1 英寸。幻灯片坐标和尺寸使用点（每英寸 72 点）表示。对于已有演示文稿，请参见[使用模板](#use-a-template)。

## **设置固定图表大小**

将[setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow)设为 false，以使图表尺寸独立于工作簿窗口。通过[setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth)和[setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight)设置[getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject)的尺寸，并使用每英寸 96 像素将点转换为像素：宽高为 684 × 288 点的框对应宽高为 912 × 384 像素的图表。将[setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize)设为 `PrintSizeType` 的 CUSTOM 值。示例使用[addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame)嵌入工作簿，并保存一个带有 9.5 × 4 英寸 OLE 框的演示文稿。

将此第一个脚本保存为 `create-fixed-chart.js`。它会生成 `chart-fixed-size.xls`，其中图表尺寸为 912 × 384 像素，匹配第二个脚本使用的 684 × 288 点框。无需输入工作簿。

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // 匹配 OLE 框的尺寸，以点为单位（每英寸 72 点）。
    const width = 684; // 9.5 英寸。
    const height = 288; // 4 英寸。

    chart.setSizeWithWindow(false);
    // 使用每英寸 96 像素将点转换为图表像素。
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// 所有同步工作已完成；停止 Java 桥进程。
process.exit(0);
```

将第二个脚本保存为 `embed-fixed-chart.js`，并在 `create-fixed-chart.js` 之后运行。它读取生成的 XLS 工作簿并保存为 `chart-fixed-size.pptx`。Java 桥需要为工作簿数据提供显式的 Java 字节数组，并为框的坐标和尺寸提供 Java float 值。`xls` 扩展名对应工作簿的保存格式。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // 幻灯片坐标和尺寸以点为单位（每英寸 72 点）。
    const width = 684; // 9.5 英寸。
    const height = 288; // 4 英寸。
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// 所有同步工作已完成；停止 Java 桥进程。
process.exit(0);
```

## **使用模板**

对于已有演示文稿，尺寸逻辑相同。要调整示例：

1. 加载模板演示文稿，而不是创建空白演示文稿。
1. 确认第一张幻灯片至少包含三个形状，然后使用索引为 2 的形状作为占位符。
1. 从该形状获取框的宽度和高度，而不是使用固定值 684 和 288。将在工作簿创建脚本中使用相同的尺寸，保持尺寸计算不变，并在嵌入之前重新生成 XLS 工作簿。
1. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。
1. 在保存演示文稿之前移除占位符。

## **常见问题**

**为什么在 PowerPoint 中激活后，我嵌入的 Excel 图表会改变大小？**

这是因为 Excel 在首次激活时尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象框有自己的尺寸。PowerPoint 与 Excel 协商尺寸以保持纵横比，这可能导致大小调整。

**如何保持图表和 OLE 框的尺寸一致？**

将固定的图表尺寸设置为匹配 OLE 框，并在嵌入工作簿前使用自定义图表打印尺寸。上面的示例展示了所需的设置和单位换算。

**仅匹配工作簿窗口大小是否足够？**

仅匹配工作簿窗口大小并不能可靠地防止 OLE 框在激活后改变大小。请使用示例中所示的固定图表尺寸。

**此方案是否同时适用于基于模板的演示文稿和新建演示文稿？**

是的。对于模板，使用占位符的尺寸和位置。对于新建演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**

该示例使用 Aspose.Cells 创建的 Excel 工作簿。不演示其他电子表格程序的激活行为。

## **相关部分**

- [创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)