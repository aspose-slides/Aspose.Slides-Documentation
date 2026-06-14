---
title: 在 PHP 中自訂簡報圖表的繪圖區域
linktitle: 繪圖區域
type: docs
url: /zh-hant/php-java/chart-plot-area/
keywords:
- 圖表
- 繪圖區域
- 繪圖區域寬度
- 繪圖區域高度
- 繪圖區域大小
- 佈局模式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中自訂圖表的繪圖區域，輕鬆提升投影片視覔效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中處理圖表的繪圖區域。它解釋了如何透過驗證圖表佈局，然後讀取其 X、Y、寬度與高度值，以取得繪圖區域的實際位置與大小。  
它同時示範了在手動設定佈局時，如何使用 `LayoutTargetType` 來配置繪圖區域的佈局模式，以定義繪圖區域是依其內部區域計算，還是與坐標軸及軸標籤一起的外部區域計算。

## **取得圖表繪圖區域的寬度與高度**
Aspose.Slides for PHP via Java 提供一個簡單的 API 用於。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 存取第一張投影片。  
3. 新增帶有預設資料的圖表。  
4. 在取得實際值之前，呼叫方法 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/validatechartlayout/)。  
5. 取得圖表元件相對於圖表左上角的實際 X 位置（左）。  
6. 取得圖表元件相對於圖表左上角的實際 Y 位置（上）。  
7. 取得圖表元件的實際寬度。  
8. 取得圖表元件的實際高度。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定圖表繪圖區域的佈局模式**
Aspose.Slides for PHP via Java 提供了一個簡易的 API 以設定圖表繪圖區域的佈局模式。已在 [**ChartPlotArea**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ChartPlotArea) 類別中新增方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 與 [**getLayoutTargetType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--)。如果手動定義繪圖區域的佈局，此屬性指定是以內部（不包括坐標軸與軸標籤）或外部（包括坐標軸與軸標籤）方式佈局繪圖區域。可用的兩個值定義於 [**LayoutTargetType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LayoutTargetType) 列舉中。

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LayoutTargetType#Inner) - 指定繪圖區域的大小應由繪圖區域本身決定，不包括刻度標記與坐標軸標籤。  
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LayoutTargetType#Outer) - 指定繪圖區域的大小應由繪圖區域、刻度標記與坐標軸標籤共同決定。

以下提供範例程式碼。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**實際的 x、實際的 y、實際的寬度與實際的高度以什麼單位回傳？**  
以點 (points) 為單位；1 英吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區域與圖表區域在內容上有何不同？**  
繪圖區域是資料繪製區（資料系列、格線、趨勢線等）；圖表區域則包括周圍的元素（標題、圖例等）。在 3D 圖表中，繪圖區域亦包含牆面/底面與坐標軸。

**當佈局為手動時，繪圖區域的 x、y、寬度與高度如何解釋？**  
它們是相對於圖表整體大小的比例（0–1）；在此模式下，會停用自動定位，改以您設定的比例值為準。

**為何在新增/移動圖例後，繪圖區域的位置會改變？**  
圖例位於圖表區域、繪圖區域之外，但會影響佈局與可用空間，因此在啟用自動定位時，繪圖區域可能會移動。（這是 PowerPoint 圖表的標準行為。）