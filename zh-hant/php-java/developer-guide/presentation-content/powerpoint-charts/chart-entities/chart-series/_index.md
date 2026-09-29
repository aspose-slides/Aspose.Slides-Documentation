---
title: 在 PHP 簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/php-java/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 系列名稱
- 資料點
- 工作簿儲存格
- 系列間距
- 負值
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在簡報中使用 PHP 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度以及負值。"
---
## **概述**

圖表將其繪製的資料儲存在圖表資料工作簿中。 [ChartSeries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/) 代表一組相關的數值，而系列中的每個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/) 會對應一個或多個工作簿儲存格。 [ChartCategory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartcategory/) 物件提供系列共同使用的標籤或分組值。因此，系列名稱、類別與點值是連結到 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/) 物件，而不是僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格用於系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引皆為從 0 開始。此配置在建立預設資料的圖表時很有用，但請不要假設每個既有圖表都使用相同配置。對於已載入的簡報，請在變更工作簿值之前，先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的層級：

- 系列層級設定，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getFormat)，提供整個系列中所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫該點的系列外觀。
- 群組設定套用於屬於同一個 [ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/) 的相容系列。當需要設定重疊或間距寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。

當未明確設定點或系列的填色時，圖表樣式與主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列的重疊**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getOverlap) 會回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100% 至 100%。它是父系列群組設定的唯讀投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新該群組中所有相容系列。此選項僅適用於顯示分組長條或柱狀的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例設定包含第一個系列的群組的重疊：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新的圖表包含範例系列、類別和數值。
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![The series overlap](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getFormat) 來設定整個系列的預設填色。如果某個點已具備明確的填色，則其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getFormat) 設定會覆寫該系列的填色。

以下範例將第一個系列套用實心藍色填色：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例裡。對於預設建立的群組柱狀圖，B1 儲存格位於第 0 列第 1 欄，包含第一個系列的名稱。以下範例中的變數說明了此結構：

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

您也可以直接更新由 [ChartSeries.getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getName) 參照的儲存格。此方式避免在既有圖表中假設特定的列與欄：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![The series name](series_name.png)

## **取得自動系列填色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會回傳根據系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅會讀取計算出的顏色，不會指派新填色。

以下範例列印每個預設系列的自動顏色：

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

預設圖表樣式的範例輸出：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

實際顏色會依圖表樣式與主題而異。

## **為圖表系列設定負值倒置填色**

對於長條、柱狀與氣泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#setInvertIfNegative) 可讓負值以不同的填色顯示。將一般系列填色設定為實心、啟用倒置，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值顏色。工作簿中的負數值保持不變，僅變更其顯示顏色。

以下範例以單一系列取代預設圖表資料。第 0 列儲存系列名稱，第 0 欄儲存類別名稱，第 1 欄儲存數值：

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以對單一點啟用倒置，使用 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative)。以下範例在系列全部停用倒置的情況下，僅為選取的點啟用，且該點被指派為負值以顯示效果：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **清除特定資料點的數值**

若要讓某個點變為空白但不移除其他點，請將其對應的工作簿儲存格設為 `null`。對於柱狀圖，繪製的數值可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getValue) 取得。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個點：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

散佈圖使用分開的 X、Y 儲存格，氣泡圖還會使用大小儲存格。僅清除您想移除的那個值儲存格。不要在想保留其他點時呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointcollection/#clear)，因為該方法會移除該系列的所有資料點。

## **控制空白儲存格的顯示方式**

包含值的隱藏儲存格屬於另一種情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白工作簿儲存格代表缺失資料；包含 `0` 的儲存格代表已知的數值。呼叫 [ChartDataCell::setValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setValue) 並傳入 `null` 能使儲存格變為空白。數值 0 仍然是 0，且不受空白儲存格設定影響。

使用 [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/#setDisplayBlanksAs) 可選擇圖表如何顯示空白儲存格。此設定適用於整個圖表，會改變空白的繪製方式，但不會將空白工作簿儲存格填入 0 或插值值。

以下自行完整的範例建立一條線圖，包含一個系列，清除第 3 天的數值，並以每種模式分別儲存相同的圖表。此範例不需要輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/) 使用第 0 工作表，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保留系列名稱。最終資料為 `10, 20, empty, 30, 40`。

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 將第 3 天真正留空，同時保留其類別與資料點。
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

每個輸出檔案會在儲存前記錄使用的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想產生單一版本，請設定所需模式後僅儲存一次簡報，而非對所有模式迭代。

下表比較了三個檔案中相同的資料。第 3 天在工作簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。線圖最能清楚比較三種模式。長條與柱狀圖沒有連接線可跨過缺失的類別，因此 `Span` 無法產生上圖的連接段落；缺失的柱狀與高度為 0 的柱狀看起來也很相似。類似地，僅有標記的散佈圖也沒有連接線。請勿期望每種圖表類型皆有三種明顯結果；請依實際使用的圖表類型檢查輸出。

## **設定系列間距寬度**

間距寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊類似，它屬於父系列群組而非單一系列。對群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。較大的數值會在叢集之間產生更多空間，較小的數值則會使叢集更緊密。

以下範例變更間距寬度，並僅儲存最終的簡報：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![The gap width](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/) 列舉表示的圖表類型都使用圖表資料，但其系列並非全部具備相同的數值結構或設定。例如，類別圖使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間距寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可以包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addChart) 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集合前先清除系列與類別集合。亦可使用其他重載方法建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點數值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更所參照的儲存格會更新對應的圖表元素。自行建立資料時，請確保類別列與系列值列保持對齊，以便每個點都在正確的類別下繪製。

**如何只清除單一點而不是整個系列？**

將相關的數值儲存格設為 `null`，即可保留該點的類別位置但使其成為空白點。僅在想要移除該系列全部點時才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointcollection/#clear)。如果同時移除類別，請記得更新所有系列，使其數值仍與類別集合保持對齊。

**空白點會如何顯示？**

結果取決於圖表類型以及透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的顯示方式。支援的圖表可以將空白顯示為間斷、零值或連接相鄰點。選擇最能表達缺失資料意義的設定。請參閱 [控制空白儲存格的顯示方式](#control-the-display-of-empty-cells) 了解完整範例與視覺比較。

**負值會如何格式化？**

對於支援的長條、柱狀與氣泡系列，呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 回傳的顏色。您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點覆寫此行為。這些方法僅影響顯示格式，並不會改變儲存的數值。

**當系列與點同時被格式化時，哪個優先？**

明確的資料點格式會優先套用於該點。其他點則會使用明確的系列格式，若系列格式未定義，則使用自動的圖表樣式與主題。群組設定（如重疊與間距寬度）控制版面配置，並非點層級的格式覆寫。

**圖表能容納的系列數量有限制嗎？**

Aspose.Slides 本身並未設定固定的系列數量上限。實務上，簡報檔案本身的限制、可用記憶體、渲染時間以及圖表可讀性會決定實際的上限。

**如果柱狀過於靠近或過於稀疏，應該怎麼調整？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大數值會擴寬叢集之間的空間，減小則會使叢集更緊密。