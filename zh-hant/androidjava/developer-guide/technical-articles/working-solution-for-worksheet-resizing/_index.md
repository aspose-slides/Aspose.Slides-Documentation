---
title: 工作表調整大小的實作解決方案
type: docs
weight: 20
url: /zh-hant/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在簡報中修復 Excel 工作表 OLE 調整大小問題：提供兩種方法保持物件框一致——縮放框架或工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="primary" %}}

已觀察到，透過 Aspose 元件將 Excel 工作表以 OLE 物件嵌入 PowerPoint 簡報時，首次啟動後會被調整為未知的比例。此行為在 OLE 物件的啟動前後造成明顯的視覺差異。我們已深入調查此問題並提供了解決方案，詳情請見本文。

{{% /alert %}}

## **Background**

在文章 [Manage OLE](/slides/zh-hant/androidjava/manage-ole/) 中，我們說明了如何使用 Aspose.Slides for Android via Java 為 PowerPoint 簡報加入 OLE 框。為了解決 [object preview issue](/slides/zh-hant/androidjava/object-preview-issue-when-adding-oleobjectframe/)，我們將選取的工作表區域圖像指派給 OLE 物件框。於輸出簡報中，當雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任意變更，然後點擊已啟動的 Excel 活頁簿外部返回投影片。返回時 OLE 物件框的大小會發生變化，調整係數會依 OLE 物件框與嵌入的 Excel 活頁簿的大小而異。

## **Cause of Resizing**

由於 Excel 活頁簿有自己的視窗大小，它會嘗試在首次啟動時保留原始尺寸。另一方面，OLE 物件框也有自己的尺寸。根據微軟的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。調整發生於 Excel 視窗尺寸與 OLE 物件框的尺寸與位置之間的差異。

## **Working Solution**

有兩種可能的解決方案可以避免此調整效果。

- 在 PowerPoint 簡報中將 OLE 框尺寸縮放至與 OLE 框內所需的列數與欄數的高度與寬度相匹配。
- 保持 OLE 框尺寸不變，將參與的列與欄的大小縮放至適合選定的 OLE 框尺寸。

### **Scale the OLE Frame Size**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿的 OLE 框尺寸，使之符合 Excel 工作表中參與列與欄的累計大小。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框加入簡報。此情況下，OLE 物件框的尺寸將先根據工作簿中參與列的高度總和與欄的寬度總和計算。然後，我們會將 OLE 框的尺寸設定為此計算值。為了避免 PowerPoint 中 OLE 框顯示紅色「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需列與欄的圖像，並將其設定為 OLE 框的圖像。

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示大小。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
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

### **Scale the Cell Range Size**

在此方法中，我們將學習如何將參與列的高度與參與欄的寬度縮放，以符合自訂的 OLE 框尺寸。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框加入簡報。此情況下，我們會設定 OLE 框的尺寸，並將參與 OLE 框區域的列與欄的大小縮放至該尺寸。接著，我們將工作簿儲存至串流以套用變更，並轉換為位元組陣列以加入 OLE 框。為了避免 PowerPoint 中 OLE 框顯示紅色「EMBEDDED OLE OBJECT」訊息，我們同樣會擷取工作簿中所需列與欄的圖像，並將其設定為 OLE 框的圖像。

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示大小。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 縮放儲存格範圍以符合框架尺寸。
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

// 建立 OLE 物件框架。
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
 * @param width     預期儲存格範圍的寬度（以點為單位）。
 * @param height    預期儲存格範圍的高度（以點為單位）。
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

## **Conclusion**

{{% alert color="primary" %}} 

有兩種方法可解決工作表調整大小的問題。選擇哪種方法取決於具體需求與使用情境。無論簡報是從範本建立還是從頭開始，兩種方法皆可運作。此外，此解決方案對 OLE 物件框的大小沒有任何限制。

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**

這是因為 Excel 在啟動時會嘗試保留原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而產生調整。

**Is it possible to prevent this resizing issue entirely?**

可以。透過將 OLE 框縮放至符合 Excel 儲存格範圍大小，或將儲存格範圍縮放至符合目標 OLE 框尺寸，即可防止不必要的調整。

**Which scaling method should I use, OLE frame scaling or cell range scaling?**

若希望保留原始 Excel 列與欄的大小，請選擇 **OLE frame scaling**。若希望在簡報中固定 OLE 框的尺寸，請選擇 **cell range scaling**。

**Will these solutions work if my presentation is based on a template?**

會。兩種解決方案皆適用於由範本建立或全新建立的簡報。

**Is there a limit to the size of the OLE frame when using these methods?**

沒有。只要適當設定縮放比例，OLE 物件框可以任意大小。

**Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?**

可以。只要擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框的佔位圖像，即可以自訂預覽圖取代預設的佔位文字。