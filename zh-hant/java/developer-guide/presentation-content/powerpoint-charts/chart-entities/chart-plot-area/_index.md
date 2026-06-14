---
title: 在 Java 中自訂簡報圖表的繪圖區
linktitle: 繪圖區
type: docs
url: /zh-hant/java/chart-plot-area/
keywords:
- 圖表
- 繪圖區
- 繪圖區寬度
- 繪圖區高度
- 繪圖區大小
- 佈局模式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 於 PowerPoint 簡報中自訂圖表繪圖區，輕鬆提升投影片的視覽效果。"
---
## **概述**

本篇說明如何在 Aspose.Slides 中處理圖表的繪圖區（Plot Area）。它說明了透過驗證圖表佈局後，如何讀取 X、Y、寬度與高度值，以取得繪圖區的實際位置與大小。

同時也示範了在手動設定佈局時，如何使用 `LayoutTargetType` 來定義繪圖區是依其內部區域（不含坐標軸與坐標軸標籤）或外部區域（包含坐標軸與坐標軸標籤）計算。

## **取得圖表繪圖區的寬度與高度**
Aspose.Slides for Java 提供了簡易的 API 用於 。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
2. 存取第一張投影片。
3. 加入具有預設資料的圖表。
4. 在取得實際值之前呼叫方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChart#validateChartLayout--)。
5. 取得圖表元件相對於圖表左上角的實際 X 位置（左）。
6. 取得圖表元件相對於圖表左上角的實際 Y 位置（上）。
7. 取得圖表元件的實際寬度。
8. 取得圖表元件的實際高度。

```java
// 建立 Presentation 類別的執行個體
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定圖表繪圖區的佈局模式**
Aspose.Slides for Java 提供了簡易的 API 以設定圖表繪圖區的佈局模式。已在 [**ChartPlotArea**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ChartPlotArea) 類別與 [**IChartPlotArea**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartPlotArea) 介面中加入方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 與 [**getLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--)。若手動定義繪圖區的佈局，該屬性指定是以內部（不含坐標軸與坐標軸標籤）或外部（含坐標軸與坐標軸標籤）方式佈局。可接受的兩個值定義於 [**LayoutTargetType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LayoutTargetType) 列舉。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LayoutTargetType#Inner) - 指定繪圖區大小應決定繪圖區本身的大小，不包括刻度標記與坐標軸標籤。  
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LayoutTargetType#Outer) - 指定繪圖區大小應決定繪圖區本身、刻度標記以及坐標軸標籤的大小。

以下提供範例程式碼。

```java
// 建立 Presentation 類別的執行個體
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**實際的 x、y、寬度與高度以何種單位回傳？**  

以點 (point) 為單位；1 吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區與圖表區的內容有何差異？**  

繪圖區是資料繪製區域（系列、格線、趨勢線等）；圖表區則包含周圍元素（標題、圖例等）。在 3D 圖表中，繪圖區亦包括牆面/底面與坐標軸。

**當佈局為手動時，繪圖區的 x、y、寬度與高度如何解讀？**  

它們是相對於整個圖表大小的比例（0–1）。在此模式下會關閉自動定位，使用者設定的比例值直接套用。

**為何在新增或移動圖例後繪圖區位置會改變？**  

圖例位於圖表區、繪圖區之外，會影響版面配置與可用空間；因此在自動定位啟用時，圖例的變動會導致繪圖區移動。這是 PowerPoint 圖表的標準行為。