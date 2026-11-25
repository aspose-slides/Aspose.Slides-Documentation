---
title: 使用 PHP 在簡報中自訂 3D 圖表
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
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 PHP 範例調整旋轉、垂直比例、圖表深度以及系列之間的間距。"
---
## **概觀**

Aspose.Slides for PHP via Java 允許您透過 [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) 方法自訂 3D 圖表的檢視方式。本文示範如何調整旋轉、垂直比例、高度、深度、直角坐標軸以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例會建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，並使用 [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) 在第一張投影片中加入堆疊式 3D 柱狀圖。它將預設的系列與分類取代為兩個系列，每個系列包含三個值。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存分類標籤。

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) 與 [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) 方法分別將圖表的旋轉角度設定為 40 度與 270 度。[setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) 將其深度設定為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) 則啟用直角坐標軸而非透視。最終產生的簡報包含套用這些 3D 檢視設定的圖表。

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

## **對 3D 圖表表面套用圖片填滿**

您可以分別填滿 3D 圖表的 [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/)、[back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) 與 [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/)。將表面的 [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 設為 `Picture` 並指派影像。將 [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) 與表面的 [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) 都設為 `Stretch`，即可讓單一影像複本覆蓋整個表面。

將 [arrow.png](arrow.png) 檔案儲存在 PHP 程式碼旁邊。此範例會旋轉圖表並提升垂直軸的最大值，使底面在柱狀之間可見。然後將投影片複製兩次，並在每張投影片的不同表面套用箭頭。三個圖表皆保持相同的資料、檢視角度與背景。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint 會如下顯示這三張投影片。

| 側牆 | 背牆 | 底面 |
| --- | --- | --- |
| ![沿側牆指向圖表的箭頭](side-wall.png) | ![沿背牆向右指的箭頭](back-wall.png) | ![沿底面在柱子之間向右指的箭頭](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) 可將 3D 圖表的高度設定為寬度的百分比。此操作會變更 3D 場景的比例，而不會調整投影片上圖表物件的大小。

以下範例建立一個帶有預設資料（三個系列與四個分類）的 [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 圖表。它會儲存三個簡報，分別使用 50%、100% 與 200% 的高度比例。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在所有三個檔案中皆相同，僅高度百分比不同。

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

以下圖像說明了在等效的 .NET 範例中相同的高度設定，並以 Microsoft PowerPoint 匯出。較小的百分比會產生較平的場景，而較大的百分比則在相同圖表物件內產生較高的場景。PowerPoint 亦可能會調整軸刻度間隔與標籤位置以符合場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱狀圖，高度設定為寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，高度設定為寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，高度設定為寬度的 200%](height_percent_200.png) |

這些方法控制圖表的不同層面：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 場景的高度，作為寬度的百分比。 |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | 投影片上圖表物件的高度，以點為單位。 |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 場景的深度，作為寬度的百分比。 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 沿深度軸的系列間距，作為標記寬度的百分比。 |

高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔變體，以及 3D 線條圖、面積圖、餅圖與曲面圖。上述比較使用經驗證的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱屬於 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 類別的成員。如需其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/php-java/chart-formatting/)。 

## **調整系列之間的間隙**

使用 [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) 來控制 3D 圖表中資料系列沿深度軸的距離，以標記寬度的百分比表示。可使用 **0 到 500**（含）的數值：`0` 會移除間隙，較大的數值則會增加間距。當圖表深度固定時，增大間隙會使標記在深度軸上變得較薄。

透過 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得該群組。此設定會套用到群組中所有系列，而不僅是用來存取的那個系列。[ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) 會返回深度間隙，並反映父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，以及 3D 線條圖與面積圖。外觀取決於系列是以深度排列、叢集或堆疊方式呈現。若要清楚比較不同系列間的間隙，請使用來自 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 類別的 `ChartType::Column3D`。

這些方法控制圖表的不同層面：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 沿深度軸的系列間距，作為標記寬度的百分比。 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 相鄰柱或條叢集之間的間距，作為柱或條寬度的百分比。 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 整體圖表深度，作為圖表寬度的百分比。 |

以下獨立範例使用預設圖表資料，包含三個系列與四個分類。它會儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅間隙深度不同。

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

以下圖像說明了等效 .NET 範例中相同的間隙深度設定，並以 Microsoft PowerPoint 匯出。

| 間隙深度：0% | 間隙深度：500% |
| --- | --- |
| ![沿深度軸的系列之間沒有間隙的 3D 柱狀圖](gap_depth_0.png) | ![沿深度軸的系列之間有 500% 間隙的 3D 柱狀圖](gap_depth_500.png) |

## **變更 3D 系列類型與柱形狀態**

在叢集圓柱圖中，第一個系列起始為圓柱形柱狀。範例於每次變更前後列印 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 與 [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) 所回傳的整數值。表格提供對應的常數名稱。

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

| 對第一個系列的變更 | 系列類型 | 柱形狀態 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 將系列類型設為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將柱形狀態設為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設為 `Box` 也會將系列類型改為 `ClusteredColumn3D`。如果程式碼根據系列類型分支，請在變更形狀後呼叫 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/)。在指派前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一個系列從左至右分別為圓柱、圓錐與矩形柱形](series-shapes.png)

## **常見問題**

**哪種圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 類別所揭露的相關 3D 類型。欲取得精確且最新的清單，請查閱您所安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖用於報告或網路嗎？**

可以。您可以使用 [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 將圖表匯出為影像，或 [render the entire slide](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 為 PNG 或 JPEG 等格式。當您需要點陣預覽或想將圖表嵌入文件、儀表板或網頁，而不需 PowerPoint 時，這很有用。

**建立與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳結果，請盡量減少 3D 效果，避免在牆面與繪圖區域使用大量紋理，盡可能限制每個系列的資料點數量，並將輸出渲染至適當大小（解析度與尺寸），以符合目標顯示或列印需求。