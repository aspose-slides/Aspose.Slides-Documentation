---
title: 工作表調整大小的可行解決方案
type: docs
weight: 20
url: /zh-hant/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "修正簡報中 Excel 工作表 OLE 調整大小的問題：提供兩種方法保持物件框架一致——縮放框架或縮放工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="info" title="注意" %}}
使用 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 工作表，可能在首次啟動後意外調整大小。此行為會在 OLE 物件啟動前後產生明顯的視覺差異。本文章說明此問題並描述兩種解決方法。
{{% /alert %}}

## **背景**

在文章 [管理 OLE](/slides/zh-hant/nodejs-java/manage-ole/)，我們說明如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中新增 OLE 框架。為了解決[物件預覽問題](/slides/zh-hant/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)，我們將所選工作表區域的圖像指派給 OLE 物件框架。在輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框架時，Excel 工作簿會被啟動。最終使用者可以對實際的 Excel 工作簿進行任何想要的變更，然後透過點擊已啟動的 Excel 工作簿外部返回投影片。使用者返回投影片時，OLE 物件框架的大小會變更。調整大小的因素會依 OLE 物件框架與嵌入的 Excel 工作簿的大小而異。

## **調整大小的原因**

由於 Excel 工作簿具有自己的視窗大小，它在首次啟動時會嘗試保留原始大小。另一方面，OLE 物件框架則有自己的尺寸。根據 Microsoft 的說法，當 Excel 工作簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。調整大小是根據 Excel 視窗大小與 OLE 物件框架的尺寸與位置之差異發生的。

## **可行的解決方案**

有兩種可能的解決方案可避免調整大小的現象。

- 將 PowerPoint 簡報中的 OLE 框架縮放至與所選行列的總高度和寬度相匹配。
- 保持 OLE 框架尺寸不變，並縮放所選的行列以適應其內部。

### **縮放 OLE 框架尺寸**

此方法將 OLE 框架的尺寸設定為與嵌入的 Excel 工作表中所選行列的總高度與寬度相匹配。

範例載入現有的 Excel 工作簿，並使用從零開始的索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) 定義要顯示的範圍。預覽以 96 DPI 渲染，並使用每英吋 72 點的轉換將像素尺寸換算為點數。[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) 將修改過的工作簿以這些尺寸嵌入框架中。預覽透過 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派，以取代已儲存簡報中的「EMBEDDED OLE OBJECT」佔位符。

安裝 `aspose.cells`、`aspose.slides.via.java` 與 `java` 套件，並將 `sample.xlsx` 放置於工作目錄。對於每種方法，先執行準備腳本，然後在相同目錄的獨立 Node.js 行程中執行嵌入腳本。兩個 Aspose 套件分別初始化 Java 橋接。

將此準備腳本儲存為 `prepare-frame-scaled.js`，並以 `node prepare-frame-scaled.js` 執行。它會產生 `frame-scaled.xlsx` 與 `frame-scaled.png`。

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

// 所有同步工作已完成；停止 Java 橋接程序。
process.exit(0);
```

將此嵌入腳本儲存為 `embed-frame-scaled.js`，並以 `node embed-frame-scaled.js` 執行。它會讀取上述檔案並產生 `frame-scaled.pptx`。

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

// 所有同步工作已完成；停止 Java 橋接程序。
process.exit(0);
```

預覽輔助工具將 [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) 設為所選範圍，並移除邊距、頁首與頁尾。啟用 [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) 後，[SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) 會將該範圍渲染為 PNG 圖像。輔助工具將 PNG 圖像儲存至檔案，以供簡報使用。

### **縮放儲存格範圍尺寸**

此方法將所選列的高度與所選欄的寬度縮放，以符合自訂的 OLE 框架尺寸。

範例載入現有的 Excel 工作簿，並使用從零開始的索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) 定義顯示範圍，輔助工具將該範圍縮放至寬 400 點、高 100 點的框架。將修改過的工作簿儲存至檔案後，[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) 依指定大小將其嵌入。以 96 DPI 渲染的預覽透過 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派，使已儲存的簡報顯示所選儲存格，而非預設的佔位符。

將此準備腳本儲存為 `prepare-cells-scaled.js`，並以 `node prepare-cells-scaled.js` 執行。它會產生 `cells-scaled.xlsx` 與 `cells-scaled.png`。

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

// 所有同步工作已完成；停止 Java 橋接程序。
process.exit(cellsPrepared ? 0 : 1);
```

將此嵌入腳本儲存為 `embed-cells-scaled.js`，並以 `node embed-cells-scaled.js` 執行。它會讀取上述檔案並產生 `cells-scaled.pptx`。

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

// 所有同步工作已完成；停止 Java 橋接程序。
process.exit(0);
```

縮放輔助工具為所選範圍計算寬度與高度比例，保留其欄寬與列高的相對比例。它會先將計算得出的尺寸從點轉換為英吋，然後使用 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) 與 [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) 套用。所選範圍必須具有非零的寬度與高度。

此預覽輔助工具使用 [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) 渲染調整大小後的範圍。它將 [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) 限定於該範圍，移除邊距、頁首與頁尾，並將 PNG 圖像儲存至檔案。

## **結論**

{{% alert color="info" title="注意" %}}
有兩種方法可解決工作表調整大小的問題。請選擇最符合您需求與使用情境的方法。無論簡報是從範本建立或從頭開始，兩種方法皆以相同方式運作。此外，此解決方案對 OLE 物件框架的大小沒有任何限制。
{{% /alert %}}

## **常見問題**

**為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會變更大小？**

這是因為 Excel 在啟動時會嘗試維持原始視窗大小，而 PowerPoint 中的 OLE 物件框架則有其自己的尺寸。PowerPoint 與 Excel 會協商尺寸以保持長寬比例，這可能導致調整大小。

**是否能完全防止此調整大小問題？**

可以。透過將 OLE 框架縮放至符合 Excel 儲存格範圍的尺寸，或將儲存格範圍縮放至符合所需的 OLE 框架尺寸，即可避免不必要的調整大小。

**我應該使用哪種縮放方法，OLE 框架縮放還是儲存格範圍縮放？**

若希望保留原始 Excel 列與欄的尺寸，請選擇 **OLE 框架縮放**。若希望在簡報中使用固定大小的 OLE 框架，請選擇 **儲存格範圍縮放**。

**如果我的簡報是基於範本，這些解決方案仍然可行嗎？**

可以。兩種解決方案皆適用於從範本或從頭建立的簡報。

**使用這些方法時，OLE 框架的大小有無限制？**

沒有。只要適當設定縮放比例，OLE 物件框架可以設為任意大小。

**是否有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？**

可以。透過擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框架的佔位圖像，即可在預設佔位符位置顯示自訂的預覽圖像。

## **相關文章**

[在簡報中建立 Excel 圖表並以 OLE 物件嵌入](/slides/zh-hant/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 Microsoft PowerPoint 外掛程式自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)