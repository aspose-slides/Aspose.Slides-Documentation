---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報中
type: docs
weight: 30
url: /zh-hant/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Cells for Android via Java 建立 Excel 圖表，並使用 Aspose.Slides for Android via Java 將活頁簿嵌入 PowerPoint 簡報，包含圖表預覽。"
---
## **概述**

本文說明如何使用 Aspose.Cells for Android via Java 建立 Excel 縱向長條圖，並將其活頁簿嵌入使用 Aspose.Slides for Android via Java 的 PowerPoint 簡報中。嵌入的活頁簿同時包含來源資料與圖表。另一個 PNG 預覽會在 OLE 物件被啟用前於投影片上顯示圖表。

最終結果是一個嵌入的 Excel 物件，而非原生 PowerPoint 圖表。透過 OLE 編輯活頁簿需要支援 OLE 啟動且安裝相容 Excel 的桌面應用程式。

## **先決條件**

將 Aspose.Cells for Android via Java 與 Aspose.Slides for Android via Java 加入專案相依性。於 Android Activity 中呼叫 `ExcelChartEmbedding.createPresentation(getFilesDir())`。產生簡報不需要安裝 Microsoft Office。

不需要任何輸入檔案：範例會在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入應用程式的內部檔案目錄。於非試用模式執行時，請為兩個產品皆套用授權。

## **嵌入運作方式**

1. 建立包含資料工作表與圖表工作表的活頁簿。  
2. 將圖表工作表設為作用中工作表，使活頁簿開啟時直接顯示圖表。  
3. 設定活頁簿的 OLE 顯示範圍，並將圖表渲染為 PNG。  
4. 以 XLSX 格式在記憶體中保存活頁簿，並將其位元組嵌入投影片。  
5. 將 PNG 指定為 OLE 物件的預覽，最後保存簡報為 PPTX。

活頁簿的顯示範圍與投影片框架的角色不同。[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 使用零基的起始/結束列與欄索引。相對地，[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) 需要指定上列、左欄、下列與右欄。本範例以第 55 列與第 25 欄作為右下角邊界；這些值屬於版面配置的選擇，而非資料列或欄的數量。

投影片框架使用點 (points)。範例會在投影片內調整框架大小並置中，且保留 PNG 的長寬比，而不是將預覽圖拉伸至填滿投影片。

## **建立並嵌入圖表**

以下完整範例會將 `DataSheet` 內填入四列五欄的數值。每一列會成為圖表的一個資料系列。儲存活頁簿前，先將 `ChartSheet` 設為作用中工作表。

活頁簿會明確以 XLSX 形式保存，其副檔名與傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 相同。PNG 直接從位元組載入，未經中介 bitmap 轉換。透過 [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 指定 PNG，可取代預設的 OLE 佔位圖。

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // 渲染圖表預覽並分別序列化可編輯的活頁簿。
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

                        // 在投影片內調整預覽尺寸，使其適合且不改變長寬比。
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **預期結果**

`OutputChart.pptx` 內含一張投影片，嵌入 Excel 活頁簿與圖表預覽。活頁簿保留原始資料及一個包含四個系列的縱向長條圖。預覽圖置於投影片中央，且維持比例。

![Excel 縱向長條圖作為嵌入活頁簿的預覽圖](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊物件即可啟動並編輯嵌入的活頁簿。啟動與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為什麼需要預覽圖？**

嵌入的活頁簿與投影片預覽屬於不同內容。提供圖表影像可讓投影片顯示圖表，而不是預設的「EMBEDDED OLE OBJECT」佔位字樣。請參閱 [Object Preview Issue when Adding OleObjectFrame](/slides/zh-hant/androidjava/object-preview-issue-when-adding-oleobjectframe/)。

**在程式碼變更活頁簿時，預覽圖會自動更新嗎？**

把預覽視為快照。若以程式方式更新活頁簿資料，必須重新產生圖表影像，並同時取代預覽與嵌入的活頁簿資料。

**可以使用 XLS 而非 XLSX 嗎？**

可以。將活頁簿以 XLS 格式保存，並以 `xls` 作為嵌入資料的副檔名。副檔名必須與實際的活頁簿格式相符；僅變更副檔名不會轉換資料。

**為何物件在啟動後會改變大小？**

主機應用程式在啟動活頁簿時可能會更新 OLE 物件的呈現。活頁簿的 OLE 顯示範圍與投影片框架尺寸兩者皆會影響此行為。詳情請參閱 [Working Solution for Worksheet Resizing](/slides/zh-hant/androidjava/working-solution-for-worksheet-resizing/)。

## **相關章節**

- [Working Solution for Worksheet Resizing](/slides/zh-hant/androidjava/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/zh-hant/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE](/slides/zh-hant/androidjava/manage-ole/)