---
title: 在 JavaScript 中自訂簡報圖表的繪圖區
linktitle: 繪圖區
type: docs
url: /zh-hant/nodejs-java/chart-plot-area/
keywords:
  - 圖表
  - 繪圖區
  - 繪圖區寬度
  - 繪圖區高度
  - 繪圖區大小
  - 版面模式
  - PowerPoint
  - 簡報
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "探索如何使用 JavaScript 及 Aspose.Slides for Node.js 在 PowerPoint 簡報中自訂圖表的繪圖區，輕鬆提升投影片視覺效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中操作圖表的繪圖區。它解釋了如何透過驗證圖表版面配置，然後讀取其 X、Y、寬度和高度值，以取得繪圖區的實際位置與大小。

它還示範了在手動設定版面配置時，如何使用 `LayoutTargetType` 來設定繪圖區的版面模式，以定義是以內部區域（不含坐標軸和坐標標籤）或外部區域（包含坐標軸和坐標標籤）來計算繪圖區。

## **取得圖表繪圖區的寬度與高度**

Aspose.Slides for Node.js via Java 提供簡單的 API。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 存取第一張投影片。
3. 加入含預設資料的圖表。
4. 呼叫方法 [Chart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Chart#validateChartLayout--) 以取得實際值。
5. 取得圖表元素相對於圖表左上角的實際 X 位置（左側）。
6. 取得圖表元素相對於圖表左上角的實際 Y 位置（上方）。
7. 取得圖表元素的實際寬度。
8. 取得圖表元素的實際高度。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定圖表繪圖區的版面模式**

Aspose.Slides for Node.js via Java 提供簡單的 API 來設定圖表繪圖區的版面模式。已在 [**ChartPlotArea**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartPlotArea) 類別中加入方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 與 [**getLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--)。如果手動定義繪圖區的版面，此屬性指定是依內部（不包含坐標軸與坐標標籤）或外部（包含坐標軸與坐標標籤）來布局繪圖區。此屬性有兩個可能的值，定義於 [**LayoutTargetType**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LayoutTargetType) 列舉。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LayoutTargetType#Inner) - 指定繪圖區的大小僅決定繪圖區本身的大小，不包括刻度標記與坐標標籤。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LayoutTargetType#Outer) - 指定繪圖區的大小決定繪圖區本身、刻度標記與坐標標籤的大小。

以下示範程式碼。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**實際的 X、Y、寬度與高度以什麼單位回傳？**

以點 (point) 為單位；1 英吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區與圖表區在內容上有何不同？**

繪圖區是資料繪製區域（系列、格線、趨勢線等）；圖表區則包含其周圍的元素（標題、圖例等）。在 3D 圖表中，繪圖區還包括牆面/底面及坐標軸。

**當版面手動設定時，繪圖區的 X、Y、寬度與高度如何解讀？**

它們是相對於圖表整體大小的比例（0–1）；在此模式下會停用自動定位，使用您設定的比例值。

**為何在加入或移動圖例後繪圖區位置會改變？**

圖例位於繪圖區之外的圖表區域，但會影響版面配置與可用空間，因而在啟用自動定位時會導致繪圖區移動。（這是 PowerPoint 圖表的標準行為。）