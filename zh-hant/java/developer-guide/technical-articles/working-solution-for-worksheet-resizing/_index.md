---
title: 工作表調整大小的可行解決方案
type: docs
weight: 20
url: /zh-hant/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽影像
- 影像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "修復簡報中 Excel 工作表 OLE 調整大小問題：提供兩種方法保持物件框一致——縮放框架或縮放工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}
使用 Aspose 元件將 Excel 工作表嵌入 PowerPoint 簡報作為 OLE 物件時，首次啟用後可能會意外調整大小。此行為會在 OLE 物件啟用前後產生明顯的視覺差異。本文說明此問題並描述兩種解決方式。
{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh-hant/java/manage-ole/)中，我們說明了如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中加入 OLE 框。為了解決[物件預覽問題](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)，我們為 OLE 物件框指定了所選工作表區域的影像。在輸出簡報中，當您雙擊顯示工作表影像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以在實際的 Excel 活頁簿中進行任何想要的修改，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會變更。調整大小的因素會根據 OLE 物件框與嵌入式 Excel 活頁簿的大小而有所不同。

## **調整大小的原因**

由於 Excel 活頁簿有自己的視窗大小，首次啟用時它會嘗試保留原始大小。另一方面，OLE 物件框有其自身的大小。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小是根據 Excel 視窗尺寸與 OLE 物件框的尺寸和位置之差異而發生的。

## **可行的解決方案**

有兩種可避免調整大小效果的解決方案。

- 將 PowerPoint 簡報中的 OLE 框縮放至與所選列與欄的總高度與寬度相匹配。
- 保持 OLE 框大小固定，並將所選列與欄縮放至適應該框框內。

### **縮放 OLE 框大小**

此方法將 OLE 框的大小設定為與嵌入式 Excel 工作表中所選列與欄的總高度與寬度相匹配。

此範例載入現有的 Excel 活頁簿，並使用從零開始的索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 定義顯示的範圍。預覽以 96 DPI 產生，並使用每英吋 72 點將其像素尺寸轉換為點數。[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) 將修改後的活頁簿嵌入具有該尺寸的框架中。透過 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 將預覽指派，以取代已儲存簡報中的「EMBEDDED OLE OBJECT」佔位符。
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

// 設定工作簿檔案在 PowerPoint 中作為 OLE 物件使用時的顯示大小。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
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
預覽輔助程式將 [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) 設為所選範圍，並移除邊界、頁首與頁尾。啟用 [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) 後，[SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) 會將該範圍渲染為 PNG 影像。該輔助程式回傳包含 PNG 影像的新輸入串流，並將指標置於開頭，以供簡報使用。
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

### **縮放儲存格範圍大小**

此方法將所選列的高度與所選欄的寬度縮放，使其符合自訂的 OLE 框大小。

此範例載入現有的 Excel 活頁簿，並使用從零開始的索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 定義顯示的範圍，以下輔助程式將該範圍縮放以適應寬 400 點、高 100 點的框架。將修改後的活頁簿儲存至串流後，[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) 以指定尺寸嵌入其中。透過 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 指派以 96 DPI 渲染的預覽，使已儲存的簡報顯示所選儲存格而非預設佔位符。
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

// 設定工作簿檔案在 PowerPoint 中作為 OLE 物件使用時的顯示大小。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 將儲存格範圍縮放以符合框架大小。
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
縮放輔助程式會為所選範圍計算寬度與高度的比例，保留其欄的相對寬度與列的相對高度。它會先將計算出的尺寸從點數轉換為英吋，然後使用 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) 與 [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) 套用。所選範圍的寬度與高度必須非零。
```java
/**
 * @param width     儲存格範圍的預期寬度（單位：點）。
 * @param height    儲存格範圍的預期高度（單位：點）。
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
此預覽輔助程式使用 [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) 來渲染已調整大小的範圍。它將 [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) 限制於該範圍，移除邊界、頁首與頁尾，並回傳指向開頭的 PNG 串流。
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
{{% alert color="info" title="Note" %}}
有兩種方法可解決工作表調整大小的問題。請選擇最符合您需求與情境的方法。無論簡報是從範本還是從頭建立，兩種方法的運作方式皆相同。此外，此解決方案對 OLE 物件框的大小沒有任何限制。
{{% /alert %}}

## **常見問題**

**為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟用時會改變大小？**  
這是因為 Excel 在啟用時會嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**是否可以完全防止此調整大小問題？**  
可以。透過將 OLE 框縮放至符合 Excel 儲存格範圍大小，或將儲存格範圍縮放至符合所需的 OLE 框大小，即可防止不必要的調整大小。

**我應該使用哪種縮放方法，OLE 框縮放還是儲存格範圍縮放？**  
如果您想保留原始的 Excel 列與欄大小，請選擇 **OLE 框縮放**。如果您希望簡報中的 OLE 框具有固定大小，請選擇 **儲存格範圍縮放**。

**如果我的簡報是基於範本，這些解決方案是否仍然有效？**  
會。兩種解決方案皆適用於從範本建立或從頭建立的簡報。

**使用這些方法時，OLE 框的大小是否有限制？**  
沒有。只要適當設定縮放，就可以將 OLE 物件框調整為任意大小。

**是否有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？**  
可以。透過擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框的佔位圖像，即可在預設佔位符位置顯示自訂的預覽影像。

## **相關文章**

[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 外掛程式自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)