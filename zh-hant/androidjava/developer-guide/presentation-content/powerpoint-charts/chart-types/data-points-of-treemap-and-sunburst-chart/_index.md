---
title: 在 Android 上自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 圖表
- Sunburst 圖表
- 資料點
- 標籤顏色
- 分支顏色
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 管理 Treemap 與 Sunburst 圖表的資料點，並相容於 PowerPoint 格式。"
---
## **簡介**

在 PowerPoint 圖表的其他類型中，有兩種「階層」類型——**Treemap** 與 **Sunburst** 圖表（亦稱 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。這些圖表顯示以樹狀結構組織的階層資料——從葉節點到分支的頂部。葉節點由系列資料點定義，每個後續的嵌套分組層級則由相應的類別定義。Aspose.Slides for Android via Java 允許在 Java 中設定 Sunburst 圖表與 Treemap 的資料點。

以下是一個 Sunburst 圖表，其中 Series1 欄位的資料定義葉節點，而其他欄位則定義階層資料點：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

讓我們從在簡報中新增 Sunburst 圖表開始：

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
- [**在 Android 上建立或更新 PowerPoint 簡報圖表**](/slides/zh-hant/androidjava/create-chart/)
{{% /alert %}}

如果需要設定圖表的資料點，我們應該使用以下項目：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPointLevel) 類別以及 [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 方法提供存取 Treemap 與 Sunburst 圖表資料點的格式設定。[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPointLevelsManager) 用於存取多層級類別——它代表 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartCategoryLevelsManager) 物件的容器，並加入了針對資料點的特定屬性。[**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPointLevel) 類別具有兩個方法： [**getFormat**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) 和 [**getDataLabel**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--)，可取得相應的設定。

## **顯示資料點值**

顯示「Leaf 4」資料點的值：

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **設定資料點標籤與顏色**

將「Branch 1」的資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱。然後將文字顏色設定為黃色：

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

**我可以變更 Sunburst/Treemap 中區段的順序（排序）嗎？**

不行。PowerPoint 會自動排序區段（通常依值遞減、順時針方向）。Aspose.Slides 會遵循此行為：無法直接變更順序；只能透過預先處理資料來達成。

**簡報主題如何影響區段和標籤的顏色？**

圖表顏色會繼承簡報的 [主題/調色板](/slides/zh-hant/androidjava/presentation-theme/)，除非你明確設定填色或字型。為了取得一致的結果，請在所需層級上鎖定實色填充與文字格式。

**匯出為 PDF/PNG 時會保留自訂的分支顏色和標籤設定嗎？**

會。匯出簡報時，圖表的設定（填色、標籤）會在輸出格式中保留，因為 Aspose.Slides 會根據圖表的格式進行渲染。

**我可以計算標籤/元素的實際座標，以便在圖表上自訂覆蓋位置嗎？**

可以。圖表版面配置驗證完成後，可取得元素的實際 *x* 與實際 *y*（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/datalabel/)），這有助於精確地定位覆蓋層。