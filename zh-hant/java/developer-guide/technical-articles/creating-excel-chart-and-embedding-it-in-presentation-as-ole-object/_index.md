---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報
type: docs
weight: 30
url: /zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Cells for Java 建立 Excel 圖表，並將工作簿嵌入 PowerPoint 簡報（使用 Aspose.Slides），包含圖表預覽。"
---
## **概觀**

本文說明如何使用 Aspose.Cells for Java 建立 Excel 縱向長條圖，並將其活頁簿嵌入使用 Aspose.Slides for Java 的 PowerPoint 簡報中。嵌入的活頁簿同時包含來源資料與圖表。另有一個 PNG 預覽圖在 OLE 物件啟動前於投影片上顯示圖表。

結果是一個嵌入的 Excel 物件，而非 PowerPoint 原生圖表。透過 OLE 編輯活頁簿需要支援 OLE 啟動且安裝相容 Excel 的桌面應用程式。

## **前置條件**

將 Aspose.Cells for Java 與 Aspose.Slides for Java 加入專案相依性。於 Java 方法內執行範例。產生簡報不需要 Microsoft Office。

不需要任何輸入檔案：範例會在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入目前工作目錄。於非評估模式執行時請為兩個產品套用授權。

## **嵌入的運作方式**

1. 建立包含資料工作表與圖表工作表的活頁簿。  
2. 將圖表工作表設為使用中工作表，使活頁簿在開啟時直接顯示圖表。  
3. 設定活頁簿的 OLE 顯示範圍並將圖表轉為 PNG。  
4. 以 XLSX 格式將活頁簿存於記憶體，並將這些位元組嵌入投影片。  
5. 將 PNG 設為 OLE 物件的預覽，最後將簡報存為 PPTX。

活頁簿顯示範圍與投影片框架的角色不同。[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 以「零基」的起始/結束列與欄索引為參數。相較之下，[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) 需要提供上方列、左側欄、下方列與右側欄。範例使用第 55 列與第 25 欄作為右下邊界；這些值屬於版面配置選擇，並非資料列或欄的數量。

投影片框架使用點 (points) 為單位。範例將圖表置於投影片中央，且保持 PNG 的長寬比，而非將預覽拉伸至填滿整張投影片。

## **建立並嵌入圖表**

以下完整範例會在 `DataSheet` 中填入四列五欄的值。每一列會成為圖表的一個系列。於儲存活頁簿前，先將 `ChartSheet` 設為使用中工作表。

活頁簿會明確以 XLSX 格式保存，與傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 副檔名相符。PNG 直接從位元組載入，無需中間的 bitmap 轉換。透過 [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 將其指定為預覽，可取代預設的 OLE 佔位圖。

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // 渲染圖表預覽並將可編輯的活頁簿分別序列化。
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // 在不改變長寬比的情況下，將預覽圖調整至投影片內。
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **預期結果**

`OutputChart.pptx` 包含一張投影片，其中嵌入了 Excel 活頁簿與圖表預覽。活頁簿內含原始資料與一個四系列的縱向長條圖。預覽圖位於投影片中央，且比例保持不變。

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊物件即可啟動並編輯嵌入的活頁簿。啟動與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為什麼需要預覽圖片？**

嵌入的活頁簿與投影片預覽是兩個獨立的內容。提供圖表圖片可讓投影片顯示圖表，而非預設的「EMBEDDED OLE OBJECT」佔位文字。請參考 [Object Preview Issue when Adding OleObjectFrame](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)。

**在程式碼變更活頁簿時，預覽會自動更新嗎？**

預覽僅是快照。若以程式方式更新活頁簿資料，需重新產生圖表圖片，並同時取代預覽與嵌入的活頁簿資料。

**可以使用 XLS 而非 XLSX 嗎？**

可以。將活頁簿以 XLS 格式保存，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際活頁簿格式相符；僅更改副檔名並不會轉換資料。

**為何物件在啟動後會改變大小？**

主機應用程式在啟動活頁簿時可能會更新 OLE 物件的顯示方式。活頁簿的 OLE 顯示範圍與投影片框架尺寸皆會影響結果。請參考 [Working Solution for Chart Resizing in PPTX](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)。

## **相關章節**

- [Working Solution for Chart Resizing in PPTX](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/zh-hant/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)