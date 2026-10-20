---
title: 워크시트 크기 조정을 위한 실용 솔루션
type: docs
weight: 20
url: /ko/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 개체 프레임을 일관되게 유지하기 위한 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT 및 PPTX 형식 전반에 적용됩니다."
---
{{% alert color="info" title="Note" %}}

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트는 처음 활성화된 후 예상치 못하게 크기가 조정될 수 있습니다. 이 동작은 OLE 개체가 활성화 전후에 눈에 띄는 시각적 차이를 만들게 됩니다. 이 문서에서는 문제를 설명하고 이를 해결하는 두 가지 방법을 소개합니다.

{{% /alert %}}

## **배경**

In the article [OLE 관리](/slides/ko/nodejs-java/manage-ole/), we explained how to add an OLE frame to a PowerPoint presentation using Aspose.Slides for Node.js via Java. To address the [개체 미리보기 문제](/slides/ko/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), we assigned an image of the selected worksheet area to the OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the worksheet image, the Excel workbook is activated. End users can make any desired changes to the actual Excel workbook and then return to the slide by clicking outside the activated Excel workbook. The size of the OLE object frame will change when the user returns to the slide. The resizing factor will vary depending on the size of the OLE object frame and the embedded Excel workbook.

## **크기 조정 원인**

Since the Excel workbook has its own window size, it tries to retain its original size upon first activation. On the other hand, the OLE object frame has its own size. According to Microsoft, when the Excel workbook is activated, Excel and PowerPoint negotiate the size to ensure it maintains the correct proportions as part of the embedding process. The resizing occurs based on the differences between the Excel window size and the OLE object frame's size and position.

## **작업 솔루션**

There are two possible solutions to avoid the resizing effect.

- Scale the OLE frame in the PowerPoint presentation to match the total height and width of the selected rows and columns.
- Keep the OLE frame size constant and scale the selected rows and columns to fit within it.

### **OLE 프레임 크기 조정**

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

// 모든 동기 작업이 완료되었습니다; Java 브리지 프로세스를 중지합니다.
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

// 모든 동기 작업이 완료되었습니다; Java 브리지 프로세스를 중지합니다.
process.exit(0);
```

The preview helper sets [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) to the selected range and removes margins, headers, and footers. With [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) enabled, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) renders the range as a PNG image. The helper saves the PNG image to a file for use in the presentation.

### **셀 범위 크기 조정**

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

// 모든 동기 작업이 완료되었습니다; Java 브리지 프로세스를 중지합니다.
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

// 모든 동기 작업이 완료되었습니다; Java 브리지 프로세스를 중지합니다.
process.exit(0);
```

The scaling helper calculates separate width and height ratios for the selected range, preserving the relative widths of its columns and the relative heights of its rows. It converts the calculated dimensions from points to inches before applying them with [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) and [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). The selected range must have nonzero width and height.

This preview helper renders the resized range using [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). It limits [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) to that range, removes margins, headers, and footers, and saves the PNG image to a file.

## **결론**

{{% alert color="info" title="Note" %}}

There are two approaches to fix the worksheet resizing issue. Choose the approach that best fits your requirements and use case. Both approaches work the same way, whether the presentations are created from a template or from scratch. Additionally, there is no limit on the size of the OLE object frame in this solution.

{{% /alert %}}

## **FAQ**

**왜 PowerPoint에서 처음 활성화될 때 삽입된 Excel 워크시트의 크기가 변하나요?**

Excel은 활성화될 때 원래 창 크기를 유지하려고 하고, PowerPoint의 OLE 개체 프레임은 자체적인 크기를 가지고 있기 때문입니다. PowerPoint와 Excel은 비율을 유지하도록 크기를 협상하므로 크기 조정이 발생합니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞추어 스케일링하거나, 셀 범위를 원하는 OLE 프레임 크기에 맞추어 스케일링하면 원치 않는 크기 조정을 방지할 수 있습니다.

**어떤 스케일링 방법을 사용해야 하나요, OLE 프레임 스케일링인가 셀 범위 스케일링인가요?**

원본 Excel 행과 열 크기를 유지하려면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임의 크기를 고정하려면 **셀 범위 스케일링**을 선택하십시오.

**템플릿을 기반으로 만든 프레젠테이션에도 이 해결책이 작동하나요?**

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에서 작동합니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

아니요. 적절히 스케일을 설정하면 OLE 개체 프레임의 크기를 원하는 만큼 크게 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리표시자 텍스트를 제거할 수 있는 방법이 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 찍어 OLE 프레임의 자리표시자 이미지로 설정하면 기본 자리표시자 대신 사용자 정의 미리보기 이미지를 표시할 수 있습니다.

## **관련 기사**

[Excel 차트를 생성하고 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint 추가 기능을 사용하여 OLE 개체를 자동으로 업데이트하기](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)