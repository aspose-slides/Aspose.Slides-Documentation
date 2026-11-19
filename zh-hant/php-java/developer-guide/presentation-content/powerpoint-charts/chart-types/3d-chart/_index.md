---
title: 使用 PHP 自訂簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/php-java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 PHP 範例調整旋轉、高度比例、圖表深度與系列之間的間距。"
---
## **概述**

Aspose.Slides for PHP via Java 讓您透過 [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) 方法自訂 3D 圖表的檢視方式。本文章說明如何調整旋轉、縱向比例、高度、深度、直角座標軸以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉和深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，並使用 [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) 在其第一張投影片上新增堆疊 3D 柱狀圖。它會以兩個系列（每個系列包含三個值）取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) 與 [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) 方法分別將圖表的旋轉設定為 40 與 270 度。[setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) 設定深度為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) 則啟用直角座標軸以取代透視。最終產生的簡報包含已套用這些 3D 觀點設定的圖表。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **調整 3D 圖表的高度比例**

使用 [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) 以寬度的百分比設定 3D 圖表的高度。此方式會改變 3D 場景的比例，卻不會改變投影片上圖表物件的實際大小。

以下範例建立一個預設資料的 [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 圖表：三個系列、四個類別。它會儲存三個簡報，分別使用 50%、100% 與 200% 的高度比例。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同；唯一改變的是高度百分比。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

下列影像說明了相同高度設定在等效 .NET 範例中的呈現結果，並由 Microsoft PowerPoint 匯出。較小的百分比會產生較平坦的場景，較大的百分比則在相同圖表物件內產生較高的場景。PowerPoint 也可能會調整座標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度為寬度 50% 的 3D 柱狀圖](height_percent_50.png) | ![高度為寬度 100% 的 3D 柱狀圖](height_percent_100.png) | ![高度為寬度 200% 的 3D 柱狀圖](height_percent_200.png) |

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 場景的高度佔寬度的百分比。 |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | 投影片上圖表物件的高度（單位為點）。 |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 場景的深度佔寬度的百分比。 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 沿深度軸的系列間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條狀圖（包括圓柱、圓錐與金字塔變體），以及 3D 線圖、區域圖、圓餅圖與表面圖。上述比較使用已驗證的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱皆為 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 類別的成員。如需其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/php-java/chart-formatting/)。

## **調整系列之間的間距**

使用 [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) 以深度軸上系列之間的距離（以標記寬度的百分比表示）控制 3D 圖表的間距。允許的值為 **0 到 500**（含），`0` 代表移除間距，較大的值會增加間距。若圖表深度固定，增大間距會使標記在深度軸上變得較細。

透過 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。此設定會套用至該群組中的每個系列，而不僅限於取得群組的系列。[ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) 可回傳目前的深度間距，並反映父群組的設定。

此設定會影響 3D 柱狀圖與條狀圖（包括圓柱、圓錐與金字塔變體），以及 3D 線圖與區域圖。外觀取決於系列在深度方向的排列方式（深度、叢集或堆疊）。若要清楚比較不同系列之間的間距，請使用來自 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 類別的 `ChartType::Column3D`。

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 沿深度軸的系列間距，以標記寬度的百分比表示。 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 相鄰條形或柱狀叢集之間的間距，以條形或柱狀寬度的百分比表示。 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 圖表整體深度，佔圖表寬度的百分比。 |

以下自主範例使用預設圖表資料（包含三個系列與四個類別），儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅深度間距不同。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

下列影像說明了相同深度間距設定在等效 .NET 範例中的呈現結果，並由 Microsoft PowerPoint 匯出。

| 深度間距：0% | 深度間距：500% |
| --- | --- |
| ![沿深度軸的系列之間沒有間距的 3D 柱狀圖](gap_depth_0.png) | ![沿深度軸的系列之間有 500% 間距的 3D 柱狀圖](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在叢集圓柱圖中，第一個系列起初使用圓柱形條形。範例會在每次變更前後列印 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 與 [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) 所回傳的整數值。下表列出相對應的常數名稱。

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 變更第一個系列 | 系列類型 | 條形形狀 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 將系列類型設為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將條形形狀設為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 也會將系列類型變更為 `ClusteredColumn3D`。如果您的程式碼依系列類型分支，請在變更形狀後呼叫 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 取得最新值。若在指派前已快取值，仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一個系列依序為圓柱、圓錐與矩形柱形](series-shapes.png)

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援多種 3D 柱狀圖變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 類別公開的相關 3D 類型。欲取得完整且最新的清單，請檢視您所安裝版本的 API 參考文件中 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網頁嗎？**

可以。您可以使用 [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 將圖表匯出為影像，或將整張投影片 [render the entire slide](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在需要點陣圖預覽或將圖表嵌入文件、儀表板或網頁，而不需要 PowerPoint 時特別有用。

**建立與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為獲得最佳結果，請盡量減少 3D 效果，避免在牆面與繪圖區使用大量紋理，盡可能限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。