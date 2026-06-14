---
title: 使用 JavaScript 自訂 Treemap 與 Sunburst 圖表中的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 圖表
- Sunburst 圖表
- 資料點
- 標籤顏色
- 分支顏色
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 以及 Aspose.Slides for Node.js via Java 來管理 Treemap 與 Sunburst 圖表中的資料點，並相容於 PowerPoint 格式。"
---
## **簡介**

除了其他類型的 PowerPoint 圖表外，還有兩種「階層」類型──**Treemap** 與 **Sunburst** 圖表（亦稱為 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。這些圖表以樹狀結構顯示階層資料——從葉節點一直到分支頂端。葉節點由系列資料點定義，而每個後續的巢狀分組層級則由相應的類別定義。Aspose.Slides for Node.js via Java 允許在 JavaScript 中格式化 Sunburst 圖表與 Treemap 的資料點。

以下是一個 Sunburst 圖表，其中 Series1 欄位的資料定義葉節點，而其他欄位則定義階層資料點：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

讓我們從在簡報中新增一個 Sunburst 圖表開始：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // …
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="另請參閱" %}} 
- [**在 JavaScript 中建立或更新 PowerPoint 簡報圖表**](/slides/zh-hant/nodejs-java/create-chart/)
{{% /alert %}}

如果需要格式化圖表的資料點，我們應該使用以下方式：

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevelsManager)、 
[ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevel) 類別  
以及 [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) 方法  
提供對 Treemap 和 Sunburst 圖表資料點的格式化存取。  
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevelsManager) 用於存取多層級類別——它代表  
[**ChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevel) 物件的容器。  
基本上它是 [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartCategoryLevelsManager) 的封裝，加入了專屬於資料點的屬性。  
[**ChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevel) 類別有兩個方法：  
[**getFormat**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) 和  
[**getDataLabel**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--)，可存取相應的設定。

## **顯示資料點值**
顯示「Leaf 4」資料點的值：

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **設定資料點標籤與色彩**
將「Branch 1」的資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱。接著將文字顏色設定為黃色：

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **設定資料點分支色彩**
變更「Steam 4」分支的顏色：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常見問題**

**我可以變更 Sunburst / Treemap 中區段的順序（排序）嗎？**

不能。PowerPoint 會自動排序區段（通常依值遞減、順時針方向）。Aspose.Slides 會遵循相同的行為：無法直接變更順序，只能透過前置處理資料來實現。

**簡報主題如何影響區段與標籤的顏色？**

圖表顏色會繼承簡報的 [theme/palette](/slides/zh-hant/nodejs-java/presentation-theme/)（除非您明確設定填色或字型）。若需一致的結果，請在所需層級上鎖定實心填色與文字格式設定。

**匯出為 PDF/PNG 時會保留自訂的分支顏色和標籤設定嗎？**

會。匯出簡報時，圖表的設定（填色、標籤）會保留在輸出格式中，因為 Aspose.Slides 會以圖表的格式化結果渲染。

**我能計算標籤/元素的實際座標，以在圖表上方自訂覆蓋層的位置嗎？**

可以。圖表版面配置驗證完畢後，元素（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/)) 會提供實際的 X 與 Y 座標，方便精確定位覆蓋層。