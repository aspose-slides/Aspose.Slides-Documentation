---
title: 工作表大小调整的可行方案
type: docs
weight: 20
url: /zh/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "修复演示文稿中 Excel 工作表 OLE 大小调整：提供两种方法保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="注意" %}}

使用 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，首次激活时可能会出现意外的大小调整。此行为会导致 OLE 对象在激活前后的视觉差异明显。本文章解释了此问题并描述了两种解决方案。

{{% /alert %}}

## **背景**

在文章[Manage OLE](/slides/zh/nodejs-java/manage-ole/)中，我们阐述了如何使用 Aspose.Slides for Node.js via Java 向 PowerPoint 演示文稿添加 OLE 框。为了解决[object preview issue](/slides/zh/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了选定工作表区域的图像。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后点击激活的 Excel 工作簿外部返回幻灯片。返回幻灯片时，OLE 对象框的大小会发生变化。调整因子取决于 OLE 对象框和嵌入的 Excel 工作簿的尺寸。

## **调整大小的原因**

由于 Excel 工作簿有自己的窗口大小，它在首次激活时会尝试保留原始尺寸。另一方面，OLE 对象框有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。大小调整基于 Excel 窗口尺寸与 OLE 对象框尺寸和位置之间的差异发生。

## **可行方案**

有两种可能的方案可以避免大小调整效果。

- 将 PowerPoint 演示文稿中的 OLE 框缩放至与选定行列的总高度和宽度匹配。
- 保持 OLE 框尺寸不变，缩放选定的行列以适应其内部。

### **缩放 OLE 框大小**

此方法将 OLE 框的大小设置为与嵌入的 Excel 工作表中选定行列的总高度和宽度匹配。

示例加载现有 Excel 工作簿，并使用零基索引选取其第一个工作表的前 10 行和前 13 列。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize)定义显示范围。预览以 96 DPI 渲染，其像素尺寸使用每英寸 72 点转换为点数。[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame)使用该尺寸将修改后的工作簿嵌入框中。预览通过[OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)分配，以替换已保存演示文稿中的“EMBEDDED OLE OBJECT”占位符。

安装 `aspose.cells`、`aspose.slides.via.java` 和 `java` 包，并将 `sample.xlsx` 放置在工作目录中。对每种方法，首先运行准备脚本，然后在同一目录的单独 Node.js 进程中运行嵌入脚本。两个 Aspose 包分别初始化 Java 桥接。

将此准备脚本保存为 `prepare-frame-scaled.js` 并使用 `node prepare-frame-scaled.js` 运行。它会生成 `frame-scaled.xlsx` 和 `frame-scaled.png`。

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// 所有同步工作已完成；停止 Java 桥接进程。
process.exit(0);
```

将此嵌入脚本保存为 `embed-frame-scaled.js` 并使用 `node embed-frame-scaled.js` 运行。它会读取这些文件并写入 `frame-scaled.pptx`。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// 所有同步工作已完成；停止 Java 桥接进程。
process.exit(0);
```

预览助手将[PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea)设置为选定范围，并移除页边距、页眉和页脚。启用[ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea)后，[SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage)将范围渲染为 PNG 图像。辅助程序将 PNG 图像保存到文件以供演示文稿使用。

### **缩放单元格范围大小**

此方法将选定行的高度和选定列的宽度缩放至匹配自定义 OLE 框大小。

示例加载现有 Excel 工作簿，并使用零基索引选取其第一个工作表的前 10 行和前 13 列。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize)定义显示范围，助手将该范围缩放至宽 400 点、高 100 点的框中。将修改后的工作簿保存为文件后，[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame)按指定大小嵌入。以 96 DPI 渲染的预览通过[OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)分配，因此已保存的演示文稿显示选定的单元格而非默认占位符。

将此准备脚本保存为 `prepare-cells-scaled.js` 并使用 `node prepare-cells-scaled.js` 运行。它会生成 `cells-scaled.xlsx` 和 `cells-scaled.png`。

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// 所有同步工作已完成；停止 Java 桥接进程。
process.exit(cellsPrepared ? 0 : 1);
```

将此嵌入脚本保存为 `embed-cells-scaled.js` 并使用 `node embed-cells-scaled.js` 运行。它会读取这些文件并写入 `cells-scaled.pptx`。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// 所有同步工作已完成；停止 Java 桥接进程。
process.exit(0);
```

缩放助手为选定范围计算宽高比例，分别保持列的相对宽度和行的相对高度。它在使用[Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch)和[Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch)设置之前，将计算得到的尺寸从点转换为英寸。选定范围的宽度和高度必须非零。

此预览助手使用[SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage)渲染已调整大小的范围。它将[PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea)限制在该范围内，移除页边距、页眉和页脚，并将 PNG 图像保存到文件。

## **结论**

{{% alert color="info" title="注意" %}}

有两种方法可以解决工作表大小调整问题。请选择最符合您需求和使用场景的方法。两种方法在从模板创建或从头创建演示文稿时都以同样方式工作。此外，此解决方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框具有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，这会导致大小调整。

**是否可以完全防止此大小调整问题？**

可以。通过将 OLE 框缩放至适合 Excel 单元格范围的大小，或将单元格范围缩放至适合所需的 OLE 框大小，均可防止不希望的大小调整。

**应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？**

如果希望保持原始 Excel 行列的尺寸，请选择 **OLE 框缩放**。如果希望在演示文稿中拥有固定的 OLE 框尺寸，请选择 **单元格范围缩放**。

**这些解决方案在基于模板的演示文稿中是否同样适用？**

是的。两种方案都适用于从模板创建的演示文稿以及从头创建的演示文稿。

**使用这些方法时 OLE 框的尺寸是否有限制？**

没有限制。只要适当设置比例，OLE 对象框可以任意大小。

**是否有办法避免 PowerPoint 中的 “EMBEDDED OLE OBJECT” 占位符文本？**

有。通过对目标 Excel 单元格范围进行快照并将其设置为 OLE 框的占位图像，可在默认占位符位置显示自定义预览图像。

## **相关文档**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/zh/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)