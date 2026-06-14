---
title: 在 Android 上自訂簡報圖表的繪圖區
linktitle: 繪圖區
type: docs
url: /zh-hant/androidjava/chart-plot-area/
keywords:
- 圖表
- 繪圖區
- 繪圖區寬度
- 繪圖區高度
- 繪圖區大小
- 版面模式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "發現如何使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中自訂圖表繪圖區。輕鬆提升投影片視覺效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表的繪圖區。它解釋了透過驗證圖表版面配置，然後讀取其 X、Y、寬度與高度值，如何取得繪圖區的實際位置與大小。

它同時示範了在手動設定版面配置時，如何使用 `LayoutTargetType` 來定義繪圖區是依其內部區域還是包含座標軸與軸標籤的外部區域來計算，從而配置繪圖區的版面模式。

## **取得圖表繪圖區的寬度與高度**
Aspose.Slides for Android via Java 提供了簡單的 API。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
1. 存取第一張投影片。
1. 加入具有預設資料的圖表。
1. 在取得實際值之前，呼叫方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChart#validateChartLayout--)。
1. 取得圖表元件相對於圖表左上角的實際 X 位置（左側）。
1. 取得圖表元件相對於圖表左上角的實際 Y 位置（上方）。
1. 取得圖表元件的實際寬度。
1. 取得圖表元件的實際高度。

```java
// 建立 Presentation 類別的實例
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

## **設定圖表繪圖區的版面模式**
Aspose.Slides for Android via Java 提供了簡單的 API 以設定圖表繪圖區的版面模式。已將方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 與 [**getLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) 新增至 [**ChartPlotArea**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ChartPlotArea) 類別與 [**IChartPlotArea**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartPlotArea) 介面。若繪圖區的版面配置是手動定義，則此屬性指定是依內部（不含座標軸與軸標籤）或外部（包含座標軸與軸標籤）來排版繪圖區。此列舉 [**LayoutTargetType**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LayoutTargetType) 中定義了兩個可能的值。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LayoutTargetType#Inner) - 指定繪圖區的大小應決定繪圖區的尺寸，而不包含刻度線與軸標籤。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LayoutTargetType#Outer) - 指定繪圖區的大小應決定繪圖區、刻度線以及軸標籤的尺寸。

以下提供範例程式碼。

```java
// 建立 Presentation 類別的實例
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

## **FAQ**

**實際的 x、實際的 y、實際的寬度與實際的高度以什麼單位回傳？**

以點 (point) 為單位；1 吋 = 72 點。這是 Aspose.Slides 使用的座標單位。

**繪圖區與圖表區在內容上有何差異？**

繪圖區是資料繪製區域（例如系列、格線、趨勢線等）；圖表區則包含周圍的元素（例如標題、圖例等）。在 3D 圖表中，繪圖區還包括牆面/底面以及座標軸。

**在手動版面配置時，繪圖區的 x、y、寬度與高度如何解釋？**

它們是相對於圖表整體大小的比例（0–1 之間）；在此模式下，會停用自動定位，使用您設定的比例值。

**為何在新增或移動圖例後，繪圖區的位置會改變？**

圖例位於圖表區（繪圖區之外），但會影響版面配置與可用空間，因而在啟用自動定位時會導致繪圖區移動。（這是 PowerPoint 圖表的標準行為。）