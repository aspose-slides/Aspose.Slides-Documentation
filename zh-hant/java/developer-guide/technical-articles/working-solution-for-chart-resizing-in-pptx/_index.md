---
title: PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "修復在 PPTX 中使用嵌入式 Excel OLE 物件與 Aspose.Slides for Java 時出現的意外圖表調整大小問題。設定固定圖表尺寸以保持圖表與 OLE 框大小的一致性。"
---
## **背景**

使用 Aspose 元件在 PowerPoint 簡報中以 OLE 物件嵌入的 Excel 圖表在首次啟用後可能會改變大小。這會導致圖表在啟用前後的外觀出現顯著差異。本文說明了尺寸變化的原因，並展示如何透過將固定的圖表尺寸與 OLE 框匹配來防止此問題。

在[建立 Excel 圖表並將其嵌入為 OLE 物件於簡報](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我們說明了如何使用 Aspose.Cells for Java 建立 Excel 圖表並使用 Aspose.Slides for Java 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表圖像指派給圖表的 OLE 物件框。於輸出簡報中，當您雙擊顯示圖表圖像的 OLE 物件框時，Excel 圖表將被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後點擊已啟用活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會改變，且調整比例會因 OLE 物件框與嵌入的 Excel 活頁簿的原始尺寸不同而有所差異。

## **調整大小的原因**

嵌入的 Excel 活頁簿有自己的視窗尺寸，Excel 會在物件首次啟用時嘗試保留該尺寸。投影片上的 OLE 框則有自行定義的尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的尺寸，以在嵌入過程中維持比例。活頁簿視窗與 OLE 框之間的差異因此會導致物件重新調整大小。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框相匹配，並使圖表尺寸獨立於活頁簿視窗。此解決方案可用於新簡報或現有範本。

此範例需要 Aspose.Cells for Java 與 Aspose.Slides for Java。它在活動圖表工作表上建立一個簡單的柱狀圖，並以 XLS 格式嵌入活頁簿。未指派圖表預覽圖像；圖表會在 PowerPoint 中啟用 OLE 物件時顯示。

範例會建立一個 9.5 × 4 吋的 OLE 框，新簡報中該框位於左邊緣 0.5 吋、上邊緣 1 吋的位置。投影片座標與尺寸以點為單位（每英吋 72 點）。若使用現有簡報，請參考[使用範本](#use-a-template)。

## **設定固定的圖表大小**

設定[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-)為 false，使圖表尺寸獨立於活頁簿視窗。透過[setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-)與[setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)設定[getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--)的尺寸，使用每英吋 96 像素的換算：一個測量為 684 × 288 點的框架相當於 912 × 384 像素的圖表。將[setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-)設定為[PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/)的 CUSTOM 值。範例使用[addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)嵌入活頁簿，並以 9.5 × 4 吋的 OLE 框儲存簡報。

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

        // 投影片座標與尺寸以點為單位（每英吋 72 點）。
        float width = 684f; // 9.5 吋。
        float height = 288f; // 4 吋。

        chart.setSizeWithWindow(false);
        // 使用每英吋 96 像素將點轉換為圖表像素。
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **使用範本**

調整大小的邏輯在現有簡報中相同。要套用此範例：

1. 載入範本簡報，而不是建立空白簡報。
2. 確認第一張投影片至少包含三個圖形，然後使用索引為 2 的圖形作為佔位元。
3. 從該圖形取得框架的寬度與高度，而不是使用固定值 684 與 288。保持尺寸計算不變。
4. 在佔位元的位置加入 OLE 框，而不是使用固定座標 36 與 72。
5. 在儲存簡報前移除佔位元。

## **常見問題**

**為什麼我的嵌入式 Excel 圖表在 PowerPoint 中啟用後會變更大小？**  
這是因為 Excel 在首次啟用時會嘗試恢復原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致重新調整大小。

**我要如何保持圖表與 OLE 框的尺寸一致？**  
設定與 OLE 框相匹配的固定圖表尺寸，並在嵌入活頁簿前使用自訂的圖表列印大小。上述範例顯示了所需的設定與單位換算。

**僅匹配活頁簿視窗大小就足夠了嗎？**  
僅匹配活頁簿視窗大小並不能可靠地防止 OLE 框在啟用後改變大小。請使用如範例所示的固定圖表尺寸。

**此解決方案同時適用於基於範本的簡報與新簡報嗎？**  
是的。對於範本，使用佔位元的尺寸與位置；對於新簡報，直接指定框架的尺寸與位置。

**我可以將此範例套用於其他試算表程式建立的圖表嗎？**  
此範例使用 Aspose.Cells 建立的 Excel 活頁簿，未示範其他試算表程式的啟用行為。

## **相關章節**

- [建立 Excel 圖表並將其嵌入為 OLE 物件於簡報](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)