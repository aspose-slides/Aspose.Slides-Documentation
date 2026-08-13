---
title: 工作表大小調整的可行解決方案
type: docs
weight: 20
url: /zh-hant/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在簡報中修正 Excel 工作表 OLE 大小調整：透過兩種方式保持物件框一致——縮放框架或工作表——適用於 PPT 和 PPTX 格式。"
---
{{% alert color="info" %}}

已觀察到，通過 Aspose 元件將 Excel 工作表作為 OLE 物件嵌入 PowerPoint 簡報後，在首次啟動後會被調整為未知的比例。此行為導致簡報中 OLE 物件的啟動前後狀態在視覺上有明顯差異。我們已詳細調查此問題並提供了解決方案，相關內容已在本文中說明。

{{% /alert %}}

## **背景**

在文章 [Manage OLE](/slides/zh-hant/java/manage-ole/) 中，我們說明了如何使用 Aspose.Slides for Java 將 OLE 框新增至 PowerPoint 簡報。為了解決 [object preview issue](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/) ，我們將所選工作表區域的圖像指派給 OLE 物件框。在輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何所需的變更，然後點擊已啟動的 Excel 活頁簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化。調整比例會依據 OLE 物件框的大小與嵌入的 Excel 活頁簿的大小而有所不同。

## **調整大小的原因**

由於 Excel 活頁簿擁有自己的視窗大小，首次啟動時會嘗試保留原始大小。另一方面，OLE 物件框也有其自身的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。調整大小是根據 Excel 視窗尺寸與 OLE 物件框的尺寸和位置之差異而發生的。

## **可行的解決方案**

有兩種可能的解決方案可避免此調整效果。

- 在 PowerPoint 簡報中調整 OLE 框的大小，使其匹配 OLE 框中所需行列數的高度與寬度。
- 保持 OLE 框大小不變，並調整參與的行與列的大小，使其適應選定的 OLE 框尺寸。

### **調整 OLE 框大小**

在此方法中，我們將學習如何設定嵌入式 Excel 活頁簿的 OLE 框大小，使其符合 Excel 工作表中參與行與列的累積大小。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框加入簡報。在此情況下，OLE 物件框的大小將首先根據工作簿中參與行的高度總和與列的寬度總和計算。然後，我們會將 OLE 框的大小設定為此計算值。為了避免 PowerPoint 中 OLE 框顯示紅色「EMBEDDED OLE OBJECT」訊息，我們還會捕獲工作簿中所需行列的圖像，並將其設定為 OLE 框的圖像。

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件使用時的顯示大小。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

在此方法中，我們將學習如何調整參與的行高與列寬，使其符合自訂的 OLE 框大小。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框加入簡報。在此情況下，我們會設定 OLE 框的大小，並調整參與 OLE 框區域的行與列的尺寸，使其符合該框的大小。接著，我們會將工作簿保存至串流以套用變更，並轉換為位元組陣列以加入 OLE 框。為了避免 PowerPoint 中 OLE 框出現紅色「EMBEDDED OLE OBJECT」訊息，我們同樣會捕獲工作簿中所需行列的圖像，並將其設定為 OLE 框的圖像。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件使用時的顯示大小。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 縮放儲存格範圍以符合框架大小。
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" %}} 

有兩種方法可解決工作表調整大小的問題。選擇適當的方法取決於具體需求與使用情境。無論是從範本還是從頭建立簡報，兩種方法皆以相同方式運作。此外，此解決方案對 OLE 物件框的大小沒有任何限制。

{{% /alert %}}

## **常見問題**

### 為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？

這是因為 Excel 在啟動時嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框則有其自己的尺寸。PowerPoint 和 Excel 會協商尺寸以維持長寬比，從而導致調整大小的情況。

### 是否可以完全避免此調整問題？

可以。透過將 OLE 框縮放以符合 Excel 儲存格範圍的大小，或將儲存格範圍縮放以符合所需的 OLE 框大小，即可防止不必要的調整。

### 應該使用哪種縮放方法，OLE 框縮放還是儲存格範圍縮放？

如果您希望保留原始的 Excel 行與列大小，請選擇 **OLE frame scaling**。如果您希望在簡報中使用固定大小的 OLE 框，請選擇 **cell range scaling**。

### 如果我的簡報是基於範本，這些解決方案是否仍適用？

會。兩種解決方案皆適用於從範本建立或從頭開始建立的簡報。

### 使用這些方法時，OLE 框的大小是否有限制？

沒有。只要適當設定縮放比例，就可以將 OLE 物件框調整為任意大小。

### 是否有方法避免 PowerPoint 中顯示「EMBEDDED OLE OBJECT」佔位文字？

可以。透過截取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框的佔位圖像，即可顯示自訂的預覽圖像，取代預設的佔位文字。

## **相關文章**

[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加載項自動更新 OLE 物件](/slides/zh-hant/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)