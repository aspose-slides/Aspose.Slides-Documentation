---
title: 使用 Java 自訂 Treemap 與 Sunburst 圖表中的資料點
linktitle: Treemap 與 Sunburst 圖表中的資料點
type: docs
url: /zh-hant/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 圖表
- Sunburst 圖表
- 資料點
- 標籤顏色
- 分支顏色
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Java 管理 Treemap 與 Sunburst 圖表中的資料點，並相容於 PowerPoint 格式。"
---
## **簡介**

在其他 PowerPoint 圖表類型中，有兩種「階層」類型——**Treemap** 和 **Sunburst** 圖表（亦稱為 Sunburst 圖、Sunburst 圖示、徑向圖、徑向圖表或多層餅圖）。這些圖表顯示按樹狀結構組織的階層資料，從葉節點到分支的頂端。葉節點由系列資料點定義，每個後續的嵌套分組層級則由相應的類別定義。Aspose.Slides for Java 允許在 Java 中格式化 Sunburst 圖表和 Treemap 的資料點。

以下是一個 Sunburst 圖表，其中 Series1 欄位的資料定義葉節點，而其他欄位則定義階層資料點：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

讓我們從在簡報中加入新 Sunburst 圖表開始：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="另請參閱" %}} 
- [**在 Java 中建立或更新 PowerPoint 簡報圖表**](/slides/zh-hant/java/create-chart/)
{{% /alert %}}

如果需要格式化圖表的資料點，我們應該使用以下內容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataPointLevelsManager)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataPointLevel) 類別以及 [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 方法提供存取，以格式化 Treemap 和 Sunburst 圖表的資料點。

[**IChartDataPointLevelsManager**] 用於存取多層類別——它代表 [**IChartDataPointLevel**] 物件的容器。基本上它是 [**IChartCategoryLevelsManager**] 的包裝器，並加入了針對資料點的特定屬性。

[**IChartDataPointLevel**] 類別有兩個方法： [**getFormat**] 和 [**getDataLabel**]，它們提供對應設定的存取。

## **顯示資料點值**
顯示「Leaf 4」資料點的值：

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **設定資料點標籤與顏色**
將「Branch 1」資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱。接著將文字顏色設為黃色：

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **設定資料點分支顏色**
變更「Steam 4」分支的顏色：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常見問題**

**我可以更改 Sunburst/Treemap 中區段的順序（排序）嗎？**

不行。PowerPoint 會自動依照（通常是遞減值、順時針）排序區段。Aspose.Slides 會映射此行為：無法直接變更順序；必須透過事前處理資料來實現。

**簡報主題如何影響區段和標籤的顏色？**

圖表顏色會繼承簡報的[主題/調色盤](/slides/zh-hant/java/presentation-theme/)，除非您明確設定填色或字型。為確保一致的結果，請在所需層級鎖定實心填色與文字格式。

**匯出為 PDF/PNG 時會保留自訂分支顏色和標籤設定嗎？**

會。匯出簡報時，圖表的設定（填色、標籤）會在輸出格式中被保留，因為 Aspose.Slides 會依照圖表的格式進行渲染。

**我能計算標籤/元素的實際座標，以在圖表上方放置自訂覆蓋層嗎？**

可以。圖表版面配置驗證完成後，元素（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/datalabel/)）會提供實際的 *x* 與 *y* 座標，方便精確定位覆蓋層。