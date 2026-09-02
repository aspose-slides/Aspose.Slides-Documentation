---
title: 使用 PHP 管理簡報中的圖表資料系列
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
- 系列間隙
- 負值
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在使用 PHP 的簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度與負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料工作簿中。**[ChartSeries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/)** 代表一組相關值，系列中的每個 **[ChartDataPoint](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/)** 皆對應一個或多個工作簿儲存格。**[ChartCategory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartcategory/)** 物件提供系列共用的標籤或分組值。因此系列名稱、類別與點的值會連結到 **[ChartDataCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/)** 物件，而不僅是以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 行作為類別名稱，其餘儲存格則存放系列值。傳遞給 **[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#getCell)** 的工作表、列與欄索引皆是從零開始。此配置在建立預設資料的圖表時很有用，但請勿假設每個現有圖表都使用此配置。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 **[ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getFormat)**，提供整個系列所有點的預設外觀。
- 資料點層級設定，例如 **[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getFormat)**，會覆寫該點的系列外觀。
- 群組設定套用於屬於同一 **[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/)** 的相容系列。當需要設定重疊或間隙寬度等選項時，請透過 **[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getParentSeriesGroup)** 取得群組。

若未明確設定點或系列的填色，則圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![圖表系列 PowerPoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

**[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getOverlap)** 會回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100 到 100%。它是父系列群組設定的唯讀投影。使用 **[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/#setOverlap)** 來更新該群組中所有相容系列。此選項僅適用於顯示分組長條或柱狀的圖表類型，對組合圖中不相關的系列群組不產生影響。

以下範例設定包含第一個系列的群組的重疊：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新圖表包含範例系列、類別和數值。
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

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 **[ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getFormat)** 為整個系列設定預設填色。如果某個點已具備明確填色，其 **[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getFormat)** 設定會覆寫該點的系列填色。

以下範例為第一個系列套用實心藍色填色：

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

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例中。對於叢集柱狀圖的預設工作簿，儲存格 B1（第 0 列，第 1 欄）即為第一個系列的名稱。以下範例中的具名變數明確表示了此結構：

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

您也可以更新 **[ChartSeries.getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getName)** 已參照的儲存格。此做法避免對現有圖表的特定列與欄作假設：

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

![系列名稱](series_name.png)

## **取得自動系列填色**

**[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor)** 會根據系列索引與圖表樣式計算顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅會讀取計算出的顏色，不會指派新填色。

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

實際顏色取決於圖表樣式與佈景主題。

## **為圖表系列設定負值反轉填色**

對於長條、柱狀與氣泡系列，**[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#setInvertIfNegative)** 可在負值時顯示不同的填色。將系列的常規填色設為實心，啟用反轉，並透過 **[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor)** 指定負值顏色。負數在工作簿中保持不變，僅改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列為系列名稱，第 0 欄為類別名稱，第 1 欄為數值：

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

![反轉實心填色](inverted_solid_fill_color.png)

您也可以透過 **[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative)** 為單一點啟用反轉。以下範例在系列層級停用反轉，僅為選取的點啟用，並將該點設定為負值，以便觀察效果：

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

## **清除特定資料點的值**

若要使某一點變為空白而不移除其他點，將其對應的工作簿儲存格設為 `null`。對於柱狀圖，繪製值可透過 **[ChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getValue)** 取得。資料點仍保留在相同類別位置，但圖表會依照空白值設定將其視為空白。

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

散佈圖使用獨立的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。只清除您欲移除之值所對應的儲存格。若僅想保留其他點，請勿呼叫 **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointcollection/#clear)**，因為該方法會移除集合中的所有資料點。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，表示為長條或柱狀寬度的百分比。與重疊類似，它屬於父系列群組而非單一系列。對群組呼叫 **[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/#setGapWidth)** 即可。較大的值會在叢集之間產生更多空間，較小的值則使其更緊密。

以下範例變更間隙寬度，並僅儲存最終的簡報：

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

![間隙寬度](gap_width.png)

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由 **[ChartType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/)** 列舉表示的圖表類型皆使用圖表資料，但其系列的值結構與設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

**[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/)** 包含相容的系列，這些系列共用群組層級的繪製設定。組合圖可能包含多個群組，於單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，**[ShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addChart)** 會產生範例系列、類別與值。您可以編輯這些儲存格或在加入完全自訂的資料集之前先清除系列與類別集合。也可以使用其他重載建立不含預設資料的圖表。

**圖表物件如何連結到工作簿儲存格？**

系列名稱、類別標籤與資料點值皆參照 **[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/)** 中的儲存格。變更參照的儲存格會同步更新相應的圖表元素。自行建構資料時，請確保類別列與系列值列保持對齊，以便每個點皆繪製在正確的類別下。

**如何只清除單一點而非整個系列？**

將相關的值儲存格設為 `null`，即可保留點的類別位置但使其成為空白點。僅在需要移除該系列全部點時才使用 **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointcollection/#clear)**。

**空白點會如何顯示？**

結果取決於圖表類型以及透過 **[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/#setDisplayBlanksAs)** 所設定的行為。支援的圖表可以將空白顯示為間隙、零值，或連接相鄰點。請選擇符合簡報中遺失資料意義的設定。

**負值會如何格式化？**

對於支援的長條、柱狀與氣泡系列，呼叫 **[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#setInvertIfNegative)** 並設定 **[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor)** 回傳的顏色。您也可以使用 **[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative)** 為單一點覆寫此行為。這些方法僅影響格式，而不會改變儲存的數值。

**當系列與點同時被格式化時，哪一個優先？**

對該點而言，明確的資料點格式會優先於系列格式。其他點則會繼續使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與佈景主題。群組設定（如重疊與間隙寬度）僅影響版面配置，並非點層級的格式覆寫。

**圖表能容納多少系列？有上限嗎？**

Aspose.Slides 本身未設置固定的系列數上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實際可接受的上限。

**當柱狀圖的間距過近或過遠時，我該怎麼調整？**

對相應的父系列群組呼叫 **[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/#setGapWidth)**。增大此值可擴寬叢集之間的空間，減少則可使叢集更靠近。