---
title: 在 PPTX 中解決圖表尺寸調整的實作方案
type: docs
weight: 40
url: /zh-hant/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表尺寸調整
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 嵌入 Excel OLE 物件時，修復 PPTX 中意外的圖表尺寸調整。設定固定圖表尺寸，以保持圖表與 OLE 框尺寸一致。"
---
## **概述**

使用 Aspose 元件將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 簡報時，圖表在首次啟動後可能會改變尺寸。這會導致圖表在啟動前後的外觀有明顯差異。本文說明為什麼會發生重新調整尺寸，並展示如何透過將固定圖表尺寸與 OLE 框匹配來防止此問題。

在[建立 Excel 圖表並將其嵌入為 OLE 物件於簡報](/slides/zh-hant/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for Android via Java 建立 Excel 圖表，並使用 Aspose.Slides for Android via Java 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/androidjava/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表圖像指派給圖表的 OLE 物件框。在輸出簡報中，當您雙擊顯示圖表圖像的 OLE 物件框時，Excel 圖表會被啟動。使用者可以編輯嵌入的 Excel 工作簿，然後點擊已啟動工作簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的尺寸會變化，且重新調整的比例取決於 OLE 物件框和嵌入的 Excel 工作簿的原始大小。

## **尺寸變更的原因**

嵌入的 Excel 工作簿具有自己的視窗尺寸，Excel 會在物件首次啟動時嘗試保留該尺寸。投影片上的 OLE 框則有獨立定義的尺寸。當 Excel 工作簿被啟動時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中維持其比例。工作簿視窗與 OLE 框之間的差異因此會導致物件重新調整尺寸。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框匹配，並使圖表尺寸獨立於工作簿視窗。此解決方案適用於新簡報或現有樣板。

此範例需要 Aspose.Cells for Android via Java 與 Aspose.Slides for Android via Java。它在活動圖表工作表上建立簡單的柱狀圖，並以 XLS 格式嵌入工作簿。從 Android Activity 呼叫 `FixedChartSize.createPresentation(getFilesDir())` 以將輸出儲存於應用程式的內部檔案目錄。OLE 啟動需要桌面版 PowerPoint 以及相容的 Excel 安裝。未指派圖表預覽圖像；圖表會在 PowerPoint 中啟動 OLE 物件時顯示。

此範例建立一個 9.5 × 4 吋的 OLE 框，左邊距 0.5 吋、上邊距 1 吋。投影片座標與尺寸以點為單位（每吋 72 點）。若使用現有簡報，請參考[使用樣板](#use-a-template)。

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // 投影片座標與尺寸以點為單位（每吋 72 點）。
                    float width = 684f; // 9.5 吋。
                    float height = 288f; // 4 吋。

                    chart.setSizeWithWindow(false);
                    // 使用每吋 96 像素將點轉換為圖表像素。
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **設定固定圖表尺寸**

將[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) 設為 false，使圖表尺寸不受工作簿視窗影響。透過[setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) 與[setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) 設定[getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) 的尺寸，並以每吋 96 像素的換算將點轉為像素：684 × 288 點的框框相當於 912 × 384 像素的圖表。將[setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) 設為[PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) 的 CUSTOM 值。範例使用[addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) 嵌入工作簿，並以 9.5 × 4 吋的 OLE 框儲存簡報。

## **使用樣板**

尺寸邏輯在現有簡報中相同。調整範例步驟如下：

1. 載入樣板簡報，而不是建立空白簡報。
2. 確認第一張投影片至少包含三個圖形，然後使用索引為 2 的圖形作為佔位元。
3. 從該圖形取得框架寬度和高度，而非使用固定值 684 與 288。保持尺寸計算不變。
4. 在佔位元位置加入 OLE 框，而非使用固定座標 36 與 72。
5. 在儲存簡報前移除佔位元。

## **常見問題**

**為什麼我的嵌入式 Excel 圖表在 PowerPoint 中啟動後會改變尺寸？**

這是因為 Excel 在首次啟動時嘗試復原原始視窗大小，而 PowerPoint 中的 OLE 物件框有其自行定義的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致重新調整。

**如何確保圖表與 OLE 框尺寸一致？**

設定與 OLE 框匹配的固定圖表尺寸，並在嵌入工作簿前使用自訂的圖表列印尺寸。上述範例顯示了所需的設定與單位換算。

**僅匹配工作簿視窗尺寸是否足夠？**

僅匹配工作簿視窗尺寸無法可靠防止 OLE 框在啟動後變更尺寸。必須使用如範例所示的固定圖表尺寸。

**此解決方案同時適用於基於樣板的簡報與新簡報嗎？**

是的。對於樣板，使用佔位元的尺寸與位置；對於新簡報，直接指定框架的尺寸與位置。

**我可以將此範例用於其他試算表程式產生的圖表嗎？**

此範例使用 Aspose.Cells 所建立的 Excel 工作簿。它未示範其他試算表程式的啟動行為。

## **相關章節**

- [建立 Excel 圖表並將其嵌入為 OLE 物件於簡報](/slides/zh-hant/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)