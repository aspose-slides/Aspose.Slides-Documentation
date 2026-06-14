---
title: 工作表調整大小的可行解決方案
type: docs
weight: 20
url: /zh-hant/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽影像
- 影像重新調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在簡報中修復 Excel 工作表 OLE 大小重新調整問題：提供兩種方法保持物件框一致 - 縮放框架或縮放工作表 - 適用於 PPT 與 PPTX 格式。"
---
{{% alert color="primary" %}}
已觀察到，通過 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 工作表，在首次啟動後會被重新調整至未知的比例。此行為在 OLE 物件的啟動前後狀態之間產生明顯的視覺差異。我們已深入調查此問題並提供了解決方案，詳情請見本文。
{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh-hant/java/manage-ole/)中，我們說明了如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中加入 OLE 框。為了解決[物件預覽問題](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)，我們將選取工作表區域的圖像指派給 OLE 物件框。在輸出的簡報中，當您雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何所需的變更，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會變更。重新調整的比例會依 OLE 物件框的大小和嵌入的 Excel 活頁簿而異。

## **重新調整的原因**

由於 Excel 活頁簿擁有自己的視窗大小，它會在首次啟動時嘗試保持原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。重新調整是根據 Excel 視窗大小與 OLE 物件框的大小和位置之間的差異而發生的。

## **可行的解決方案**

有兩種可能的解決方案可避免此重新調整效果。

- 在 PowerPoint 簡報中調整 OLE 框的大小，使其符合 OLE 框內所需的行數與列數的高度與寬度。
- 保持 OLE 框的大小不變，並調整參與的行列大小，以符合選取的 OLE 框尺寸。

### **調整 OLE 框大小**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿的 OLE 框大小，使其匹配 Excel 工作表中參與行列的累計尺寸。

假設我們有一個範本 Excel 工作表，並想將其作為 OLE 框加入簡報。在此情況下，OLE 物件框的大小將首先根據工作簿中參與行列的累計行高與列寬計算。接著，我們將把 OLE 框的大小設定為此計算值。為了避免 PowerPoint 中 OLE 框顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需行列的圖像，並將其設為 OLE 框的佔位圖像。

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 取得 OLE 圖像的寬度與高度（以點為單位）。
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// 我們需要使用已修改的工作簿。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 將 OLE 圖像加入簡報資源。
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// 建立 OLE 物件框。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **調整儲存格範圍大小**

在此方法中，我們將學習如何調整參與行的高度與參與列的寬度，以匹配自訂的 OLE 框大小。

假設我們有一個範本 Excel 工作表，並想將其作為 OLE 框加入簡報。在此情況下，我們將設定 OLE 框的大小，並調整參與 OLE 框區域的行列大小，使其符合所選的 OLE 框尺寸。之後，我們會將活頁簿儲存至串流以套用變更，並轉換為位元組陣列以加入 OLE 框。為了避免 PowerPoint 中 OLE 框顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們同樣會擷取工作簿中所需行列的圖像，並將其設為 OLE 框的佔位圖像。

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 將儲存格範圍縮放以符合框架尺寸。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 我們需要使用已修改的工作簿。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 將 OLE 圖像加入簡報資源。
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// 建立 OLE 物件框。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     預期的儲存格範圍寬度（點）。
 * @param height    預期的儲存格範圍高度（點）。
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **結論**

{{% alert color="primary" %}} 
有兩種方法可解決工作表重新調整大小的問題。選擇合適的方法取決於具體需求與使用情境。無論簡報是從範本還是從頭建立，兩種方法的運作方式皆相同。此外，此解決方案對 OLE 物件框的大小沒有任何限制。
{{% /alert %}}

## **常見問題**

**為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**  
這是因為 Excel 在啟動時會嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框有其自身的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致重新調整。

**是否能完全防止此重新調整問題？**  
是的。透過將 OLE 框縮放以符合 Excel 儲存格範圍大小，或將儲存格範圍縮放以符合所需的 OLE 框大小，即可防止不必要的重新調整。

**我應該使用哪種縮放方法，OLE 框縮放還是儲存格範圍縮放？**  
若您想保留原始的 Excel 行列大小，請選擇**OLE 框縮放**。若您希望在簡報中 OLE 框具有固定大小，請選擇**儲存格範圍縮放**。

**如果我的簡報是基於範本，這些解決方案會有效嗎？**  
會的。這兩種解決方案皆適用於從範本建立或全新建立的簡報。

**使用這些方法時，OLE 框的大小是否有限制？**  
沒有。只要適當設定縮放比例，OLE 物件框可以任意大小。

**是否有方法避免 PowerPoint 中顯示「EMBEDDED OLE OBJECT」佔位文字？**  
有。透過擷取目標 Excel 儲存格範圍的快照並設定為 OLE 框的佔位圖像，即可以自訂的預覽圖取代預設的佔位文字。

## **相關文章**

[在簡報中建立 Excel 圖表並以 OLE 物件嵌入](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 外掛自動更新 OLE 物件](/slides/zh-hant/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)