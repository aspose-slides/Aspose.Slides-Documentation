---
title: 创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿
type: docs
weight: 30
url: /zh/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Cells for Node.js via Java 创建 Excel 图表，并使用 Aspose.Slides 将工作簿嵌入 PowerPoint 演示文稿中，包括图表预览。"
---
## **概述**

本文展示如何使用 Aspose.Cells for Node.js via Java 在 Node.js 中创建 Excel 柱形图，并将其工作簿嵌入到使用 Aspose.Slides for Node.js via Java 的 PowerPoint 演示文稿中。嵌入的工作簿同时包含源数据和图表。单独的 PNG 预览在 OLE 对象激活前显示幻灯片上的图表。

结果是一个嵌入的 Excel 对象，而非原生 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

安装 `aspose.cells`、`aspose.slides.via.java` 和 `java` Node.js 包。将示例作为两个 CommonJS 脚本在独立的 Node.js 进程中运行：先运行 `create-chart.js`，再运行 `embed-chart.js`，两者使用相同的工作目录。两个 Aspose 包在加载时会初始化 Java 桥，因此示例需要在不同进程中执行。生成演示文稿时不需要 Microsoft Office。

不需要已有的工作簿或图像。第一个脚本会创建 `ChartWorkbook.xlsx` 和 `ChartPreview.png`；第二个脚本读取这些文件并将 `OutputChart.pptx` 写入当前工作目录。运行时请为两个产品都应用许可证，以免进入评估模式。

## **嵌入工作原理**

1. 创建包含数据工作表和图表工作表的工作簿。  
1. 将图表工作表设为活动工作表，使工作簿在打开时直接显示图表。  
1. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。  
1. 将工作簿保存为 XLSX，并在另一个 Node.js 进程中将其字节嵌入到幻灯片中。  
1. 将 PNG 设为 OLE 对象的预览，并将演示文稿保存为 PPTX。

工作簿的显示范围和幻灯片上的框架承担不同的职责。[setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) 使用零基的起始/结束行列索引。相反，[ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) 采用顶部行、左侧列、底部行和右侧列。示例使用行索引 55 和列索引 25 作为右下边界；这些值仅是布局选择，并不代表数据行列的数量。

幻灯片框架使用点（points）单位。示例将其放置在幻灯片内部居中，并在保持 PNG 长宽比的前提下适配，而不是拉伸预览以填满幻灯片。

## **创建并嵌入图表**

将第一个示例保存为 `create-chart.js`。它向 `DataSheet` 填充四行五列的数值，每行对应一个图表系列。保存工作簿前会将 `ChartSheet` 设为活动工作表。

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // 渲染图表预览并将可编辑的工作簿单独序列化。
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// 所有同步工作已完成；停止 Java 桥接进程。
process.exit(0);
```

将以下示例保存为 `embed-chart.js`。在 `create-chart.js` 生成输入文件后运行它。它会将 OLE 框架居中，并保持预览图像的长宽比。

第二个脚本嵌入已保存的工作簿，并使用 PNG 作为其预览。工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 扩展名。PNG 直接从字节加载，无需中间位图转换。Java 桥要求为图像和工作簿数据提供显式的 Java 字节数组，以及为幻灯片框架坐标提供 Java 浮点值。通过 [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 进行赋值，可替换默认的 OLE 占位符。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // 在不改变其宽高比的情况下将预览适配到幻灯片内部。
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// 所有同步工作已完成；停止 Java 桥接进程。
process.exit(0);
```

## **预期结果**

`OutputChart.pptx` 包含一页幻灯片，内嵌 Excel 工作簿并显示图表预览。工作簿保留原始数据和一个四系列的柱形图。预览在幻灯片上居中，并保持比例。

![Excel 柱形图作为嵌入工作簿的预览](excel-chart-ole-preview.png)

在具备 Excel 的兼容桌面 PowerPoint 环境中，双击对象即可激活并编辑嵌入的工作簿。激活与编辑取决于宿主应用的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿与幻灯片预览是独立的内容。提供图表图像可让幻灯片显示图表本身，而不是默认的 “EMBEDDED OLE OBJECT” 占位符。参见 [Object Preview Issue when Adding OleObjectFrame](/slides/zh/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)。

**当我在代码中更改工作簿时，预览会自动更新吗？**

将预览视为快照。更新工作簿数据后，需要重新生成图表图像并同时替换预览和嵌入的工作簿数据。

**可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式，并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际工作簿格式匹配，仅更改扩展名并不能转换数据。

**为什么对象在激活后会改变大小？**

宿主应用在激活工作簿时可能会更新 OLE 对象的显示。工作簿的 OLE 显示范围和幻灯片框架尺寸都会影响最终效果。参见 [Working Solution for Chart Resizing in PPTX](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)。

## **相关章节**

- [Working Solution for Chart Resizing in PPTX](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/zh/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)