---
title: Working Solution for Worksheet Resizing
type: docs
weight: 20
url: /nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- preview image
- image resizing
- Excel
- worksheet
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Fix Excel worksheet OLE resizing in presentations: two ways to keep object frames consistent—scale the frame or the sheet—across the PPT and PPTX formats."
---

{{% alert color="info" title="Note" %}}

Excel worksheets embedded as OLE objects in a PowerPoint presentation using Aspose components may resize unexpectedly after their first activation. This behavior creates a noticeable visual difference between the OLE object before and after activation. This article explains the issue and describes two ways to address it.

{{% /alert %}}

## **Background**

In the article [Manage OLE](/slides/nodejs-java/manage-ole/), we explained how to add an OLE frame to a PowerPoint presentation using Aspose.Slides for Node.js via Java. To address the [object preview issue](/slides/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), we assigned an image of the selected worksheet area to the OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the worksheet image, the Excel workbook is activated. End users can make any desired changes to the actual Excel workbook and then return to the slide by clicking outside the activated Excel workbook. The size of the OLE object frame will change when the user returns to the slide. The resizing factor will vary depending on the size of the OLE object frame and the embedded Excel workbook.

## **Cause of Resizing**

Since the Excel workbook has its own window size, it tries to retain its original size upon first activation. On the other hand, the OLE object frame has its own size. According to Microsoft, when the Excel workbook is activated, Excel and PowerPoint negotiate the size to ensure it maintains the correct proportions as part of the embedding process. The resizing occurs based on the differences between the Excel window size and the OLE object frame's size and position.

## **Working Solution**

There are two possible solutions to avoid the resizing effect.

- Scale the OLE frame in the PowerPoint presentation to match the total height and width of the selected rows and columns.
- Keep the OLE frame size constant and scale the selected rows and columns to fit within it.

### **Scale the OLE Frame Size**

This approach sets the OLE frame size to match the total height and width of the selected rows and columns in the embedded Excel worksheet.

The example loads an existing Excel workbook and selects the first 10 rows and 13 columns of its first worksheet using zero-based indices. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) defines the displayed range. The preview is rendered at 96 DPI, and its pixel dimensions are converted to points using 72 points per inch. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) embeds the modified workbook in a frame with those dimensions. The preview is assigned through [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) to replace the "EMBEDDED OLE OBJECT" placeholder in the saved presentation.

Install the `aspose.cells`, `aspose.slides.via.java`, and `java` packages and place `sample.xlsx` in the working directory. For each approach, run the preparation script first, then the embedding script in a separate Node.js process in the same directory. The two Aspose packages initialize the Java bridge separately.

Save this preparation script as `prepare-frame-scaled.js` and run it with `node prepare-frame-scaled.js`. It writes `frame-scaled.xlsx` and `frame-scaled.png`.

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

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

Save this embedding script as `embed-frame-scaled.js` and run it with `node embed-frame-scaled.js`. It reads those files and writes `frame-scaled.pptx`.

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

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

The preview helper sets [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) to the selected range and removes margins, headers, and footers. With [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) enabled, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) renders the range as a PNG image. The helper saves the PNG image to a file for use in the presentation.

### **Scale the Cell Range Size**

This approach scales the heights of the selected rows and the widths of the selected columns to match a custom OLE frame size.

The example loads an existing Excel workbook and selects the first 10 rows and 13 columns of its first worksheet using zero-based indices. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) defines the displayed range, and the helper scales that range to fit a frame 400 points wide and 100 points high. After saving the modified workbook to a file, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) embeds it at the specified size. A preview rendered at 96 DPI is assigned through [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), so the saved presentation displays the selected cells instead of the default placeholder.

Save this preparation script as `prepare-cells-scaled.js` and run it with `node prepare-cells-scaled.js`. It writes `cells-scaled.xlsx` and `cells-scaled.png`.

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

// All synchronous work is complete; stop the Java bridge process.
process.exit(cellsPrepared ? 0 : 1);
```

Save this embedding script as `embed-cells-scaled.js` and run it with `node embed-cells-scaled.js`. It reads those files and writes `cells-scaled.pptx`.

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

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

The scaling helper calculates separate width and height ratios for the selected range, preserving the relative widths of its columns and the relative heights of its rows. It converts the calculated dimensions from points to inches before applying them with [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) and [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). The selected range must have nonzero width and height.

This preview helper renders the resized range using [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). It limits [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) to that range, removes margins, headers, and footers, and saves the PNG image to a file.

## **Conclusion**

{{% alert color="info" title="Note" %}}

There are two approaches to fix the worksheet resizing issue. Choose the approach that best fits your requirements and use case. Both approaches work the same way, whether the presentations are created from a template or from scratch. Additionally, there is no limit on the size of the OLE object frame in this solution.

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**

This happens because Excel tries to maintain the original window size when activated, while the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain the aspect ratio, which can cause the resizing.

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

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
