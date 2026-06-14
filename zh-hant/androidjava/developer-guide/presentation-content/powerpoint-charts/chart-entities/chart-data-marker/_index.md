---
title: 在 Android 上管理簡報中的圖表資料標記
linktitle: 資料標記
type: docs
url: /zh-hant/androidjava/chart-data-marker/
keywords:
- 圖表
- 資料點
- 標記
- 標記選項
- 標記大小
- 填充類型
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中自訂圖表資料標記，透過清晰的 Java 程式碼範例提升 PPT 與 PPTX 簡報的效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表資料標記。它展示了如何建立圖表、存取系列及其資料點、在資料點層級對標記套用圖片填充、調整標記大小，以及儲存更新後的簡報。文章亦指出可透過 `MarkerStyleType` 列舉取得標準標記形狀，且在將圖表匯出為點陣格式或 SVG 時，標記外觀會被保留。

## **設定圖表標記選項**
標記可以設定在特定系列的圖表資料點上。若要設定圖表標記選項，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 設定圖片。
- 取得第一個圖表系列。
- 新增資料點。
- 將簡報寫入磁碟。

在下方範例中，我們在資料點層級設定了圖表標記選項。

```java
// 建立空白簡報
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 建立預設圖表
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // 取得預設圖表資料工作表索引
    int defaultWorksheetIndex = 0;
    
    // 取得圖表資料工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 刪除示範系列
    chart.getChartData().getSeries().clear();
    
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // 載入圖片 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 載入圖片 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // 取得第一個圖表系列
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 在此新增資料點 (1:3)。
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // 更改圖表系列標記
    series.getMarker().setSize(15);
    
    // 儲存帶圖表的簡報
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問答**

**預設提供哪些標記形狀？**

提供標準形狀（圓形、方形、菱形、三角形等）；此清單由 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markerstyletype/) 類別定義。若需要非標準形狀，可使用帶圖片填充的標記來模擬自訂視覺效果。

**在將圖表匯出為影像或 SVG 時，標記會被保留嗎？**

會。將圖表渲染為 [raster formats](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 或儲存為 [shapes as SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/) 時，標記會保留其外觀與設定，包括大小、填充與輪廓。