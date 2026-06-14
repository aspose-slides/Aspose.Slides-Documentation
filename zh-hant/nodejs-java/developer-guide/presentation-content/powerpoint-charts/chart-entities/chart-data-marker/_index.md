---
title: 使用 JavaScript 管理簡報中的圖表資料標記
linktitle: 資料標記
type: docs
url: /zh-hant/nodejs-java/chart-data-marker/
keywords:
- 圖表
- 資料點
- 標記
- 標記選項
- 標記大小
- 填充類型
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Node.js 中自訂圖表資料標記，透過清晰的程式碼範例提升 PPT 與 PPTX 簡報的效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表資料標記。它展示了如何建立圖表、存取系列及其資料點、在資料點層級對標記套用圖片填充、調整標記大小，以及儲存更新後的簡報。它還指出，可透過 `MarkerStyleType` 列舉取得標準標記形狀，且在將圖表匯出為點陣格式或 SVG 時，標記的外觀會被保留。

## **設定圖表標記選項**

標記可以在特定系列的圖表資料點上設定。為了設定圖表標記選項，請依照以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 設定圖片。
- 取得第一個圖表系列。
- 新增資料點。
- 將簡報寫入磁碟。

在下方的範例中，我們已在資料點層級設定圖表標記選項。

```javascript
// 建立空白簡報
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 建立預設圖表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // 取得預設圖表資料工作表索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 刪除示範系列
    chart.getChartData().getSeries().clear();
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // 載入圖片 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // 載入圖片 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // 取得第一個圖表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 在此新增資料點 (1:3)。
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // 變更圖表系列標記
    series.getMarker().setSize(15);
    // 儲存含圖表的簡報
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**有哪些內建的標記形狀可用？**

標準形狀可用（圓形、方形、菱形、三角形等）；清單由 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markerstyletype/) 列舉定義。如需非標準形狀，請使用帶圖片填充的標記來模擬自訂視覺效果。

**在將圖表匯出為影像或 SVG 時，標記會被保留嗎？**

會。將圖表渲染為 [點陣格式](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 或儲存 [形狀為 SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/) 時，標記會保留其外觀與設定，包括大小、填充與輪廓。