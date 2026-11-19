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
- 系列間隙
- 負值
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 PHP 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度與負值。"
---
## **概觀**

圖表可以將其繪製的值儲存在工作簿儲存格中，或直接作為數值文字。 [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) 代表一組相關的值，而每個 [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) 代表該系列中的一個點。 [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) 物件提供系列共用的標籤或分組值。 在使用預設資料建立的圖表中，系列名稱、類別和點值使用來自圖表工作簿的 [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) 物件。

對於典型的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 行作為類別名稱，其餘儲存格則存放系列值。 傳遞給 [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) 的工作表、列與欄索引皆為從零開始。 這種佈局在建立使用預設資料的圖表時很有用，但不要假設每個現有圖表都使用它。 對於已載入的簡報，請在變更工作簿值之前檢查系列、類別和資料點所引用的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)，提供單一系列中所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/)，覆寫單一點的系列外觀。
- 群組設定套用於屬於同一個 [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) 的相容系列。 需要設定如重疊或間隙寬度等選項時，請透過 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) 取得群組。

當未設定明確的點或系列填充時，圖表樣式與主題會決定自動外觀。 當同時存在系列與點的格式設定時，點的格式會覆寫該點的系列格式。

![chart-series-powerpoint](chart-series-powerpoint.png)

對於群集圓柱圖，請參考 [changing the 3D series type or bar shape](/slides/zh-hant/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape) 如何影響第一個系列。

## **使用數值文字設定系列值**

當系列值來源於應用程式資料或計算，且不需要工作表儲存格參照時，請使用數值文字。 在將每個點的 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) 結果透過 [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/) 指派之前，先以 [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 呼叫 [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)。

集合設定會控制該系列中所有點值的來源類型。 每個點值的 [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) 方法會回報所選類型；請透過集合設定變更它。 使用 `Worksheet` 時，使用 [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) 存取參照的儲存格。 使用 `DoubleLiterals` 時，使用 [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) 或 `setAsLiteralDouble` 直接讀寫數字。

以下範例建立一個具有預設系列與類別的直條圖，然後將計算出的 10、20 等值指派給其第一個系列的現有點。 程式會儲存簡報、重新開啟，並列印已儲存的值。

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

點值來源類型與 [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) 分開，後者識別圖表的內部或外部工作簿配置。 使用數值文字本身並不會移除內嵌工作簿。 在此範例中，工作簿仍可供類別標籤、系列名稱及其他系列使用。 請參閱 [Chart Workbook](/slides/zh-hant/php-java/chart-workbook/) 以了解工作簿管理。

對於散佈圖與氣泡圖，請分別使用 [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) 與 [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) 來選擇 [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) 與 [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) 的來源。 氣泡圖亦使用 [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) 來設定 [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/)。 在指派數字之前，先將每個相關來源設為 `DoubleLiterals`，再使用該值的 `setAsLiteralDouble` 方法。

## **設定圖表系列重疊**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) 會回報 2D 圖表中條形或柱形的重疊程度，範圍從 -100 到 100 百分比。 這是父系列群組設定的唯讀投射。 使用 [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) 以更新該群組中所有相容的系列。 此選項僅適用於顯示群組條形或柱形的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例設定包含第一個系列的群組的重疊：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新圖表包含樣本系列、類別和數值。
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

使用 [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) 可為整個系列設定預設填色。 若某個點已明確設定填色，則其 [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) 會覆寫該點的系列填色。

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。 在預設為群集直條圖建立的工作簿中，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。 以下範例中的命名變數明確說明了此結構：

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

您也可以直接更新由 [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) 參照的儲存格。 這種做法避免在現有圖表中假設特定的列與欄：

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

### **從多個儲存格建立帶名稱的系列**

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，複合系列名稱相當有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 合併為單一系列名稱，同時保留兩個部份與來源儲存格的連結。

使用 [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) 取得名稱範圍，然後將該集合傳遞給 [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/)。 `skipHiddenCells` 參數控制是否包含隱藏儲存格：`true` 會排除，`false` 會包含。本範例使用 `false` 以包含名稱範圍內的每個儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。 儲存格 B1:C1 只提供系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // 這兩個儲存格提供系列名稱。
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // 分別的儲存格提供類別和數值資料點。
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間保留一個空格。 圖例會將其顯示為同一條目。 下圖說明了結果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) 會回傳依系列索引與圖表樣式計算出的顏色。 這是當系列填色未明確定義時所使用的顏色。 呼叫此方法僅會讀取計算出的顏色，並不會指派新的填色。

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

實際顏色取決於圖表樣式與主題。

## **設定系列反轉填色**

對於條形、柱形與氣泡系列，使用 [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) 可以在負值時顯示不同的填色。 將一般系列填色設為實色、啟用反轉，並透過 [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) 指派負值顏色。 負數在工作簿中保持不變，僅改變顯示顏色。

以下範例以單一系列取代預設圖表資料。 工作表第 0 列包含系列名稱，第 0 欄包含類別名稱，第 1 欄包含數值：

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

您也可以透過 [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) 為單一點啟用反轉。 在下列範例中，系列的反轉被關閉，僅為選取的點啟用，且該點亦被指派負值以顯示效果：

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

## **清除特定資料點值**

若要讓某一點變為空白而不移除其他點，請將其對應的工作簿儲存格設定為 `null`。 對於直條圖，可透過 [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) 取得繪製值。 資料點仍保留在相同的類別位置，但圖表會依據圖表的空值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。 請僅清除代表欲移除之值的儲存格。 若希望保留其他點，請勿呼叫 [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)，因為該方法會移除該系列的所有資料點。

## **控制空儲存格的顯示**

隱藏且含有值的儲存格屬於不同情況，與空儲存格分開處理。 若要包括或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表缺失資料；儲存格內含 `0` 則代表已知的數值。 呼叫 [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) 並傳入 `null` 即可使儲存格變為空白。 數值零即使在空儲存格設定下仍保持為零。

使用 [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) 選擇圖表如何顯示空儲存格。 此設定套用於整張圖表，會改變空白的繪製方式，而不會將空的工作簿儲存格填入零或插值。

以下自包含範例建立一個包含單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存相同的圖表。 無需輸入檔案。 [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保存系列名稱。 最終資料為 `10, 20, empty, 30, 40`。

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

    // 將第 3 天真正保留為空白，同時保留其類別與資料點。
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

每個輸出檔案會在儲存前記錄其模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。 若只需一個版本，請設定所需模式並僅儲存一次簡報，而非對所有模式迭代。

下方比較顯示三個檔案中相同的資料。 第 3 天在工作簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。 折線圖能清楚比較三種模式。 條形與柱形圖因缺少連接線，`Span` 無法產生上述的連接段落；缺失的柱形與零高度的柱形看起來也可能相似。 同樣地，僅有標記的散佈圖也沒有連接線。 不要期望每種圖表類型都有三種明顯的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空間，表達為條形或柱形寬度的百分比。 如同重疊，它屬於父系列群組而非單一系列。 只需對該群組呼叫一次 [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)。 較大的值會在叢集間產生更多空間，較小的值則使其更密集。

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

![The gap width](gap_width.png)

## **顯示或隱藏系列線條**

系列線條在圖表中視覺上連接相關部份。 使用 [ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/) 可在受支援的堆疊條形與堆疊圓餅圖表中顯示或隱藏它們。 在二維堆疊條形與柱形圖表中，它們連接跨類別的相對堆疊邊界。 在 Pie of Pie 與 Bar of Pie 圖表中，則連接主圖與次圖。 此設定僅適用於上述圖表類型，並非一般圖表的連接器。

透過 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) 取得群組。 該設定會套用於群組中每個系列。 [ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/) 為唯讀屬性，反映父群組的設定；請呼叫群組的 setter 進行更新。

以下範例建立一個使用預設資料的 [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 圖表，分別以啟用與關閉系列線條儲存相同圖表，產生兩個簡報以作比較。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Series lines enabled | Series lines disabled |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| The two lines connect the main pie to the secondary pie. | Both pies remain visible, but the connecting lines are hidden. |

系列線條不同於資料標籤指引線（連接標籤與其資料點）、格線（標示圖表軸上的間隔），以及折線圖中的線條（代表資料值）。 此設定不會控制上述元素。

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列並非全部具備相同的值結構或設定。例如，類別圖使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。 請使用符合系列類型的資料點建立方式。 重疊與間隙寬度等選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。 組合圖表可能包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。 預設情況下，[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) 會建立範例系列、類別與數值。 您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。 也有覆載方法可在不使用預設資料的情況下建立圖表。

**圖表物件如何連結到工作簿儲存格？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) 中的儲存格。 變更被參照的儲存格會更新相應的圖表元素。 建立自訂資料時，請保持類別列與系列值列對齊，以確保每個點繪製在預期的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設定為 `null`，即可保留該點的類別位置作為空白點。 只在您確實想移除該系列所有點時才使用 [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)，因為該方法會移除該系列的全部資料點。 若同時移除類別，請更新所有系列，使其值仍與類別集合保持對齊。

**空點會如何顯示？**

結果取決於圖表類型以及透過 [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) 設定的顯示方式。 支援的圖表可以將空白顯示為間隙、零值，或透過連接相鄰點的方式呈現。 請選擇與簡報中缺失資料意義相符的設定。 完整範例與視覺比較請參閱 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**負值如何格式化？**

對於受支援的條形、柱形與氣泡系列，可呼叫 [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/)，並設定由 [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) 回傳的顏色。 您也可以透過 [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) 為單一點覆寫此行為。 這些方法僅影響格式化，不會改變儲存的數值。

**當系列與資料點同時設定格式時，哪個優先？**

明確的資料點格式會在該點上優先。 其他點會繼續使用明確的系列格式，或在系列格式未定義時使用自動圖表樣式與主題。 群組設定（如重疊與間隙寬度）控制版面配置，並非點層級的格式覆寫。

**圖表可包含的系列數量有限制嗎？**

Aspose.Slides 並未設置固定的系列數量上限。 實際上，簡報檔案的限制、可用記憶體、渲染時間以及圖表可讀性會決定實務上的上限。

**當柱狀圖過於靠近或過於分散時，我應該調整什麼？**

對相應的父系列群組呼叫 [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)。 增大數值會擴大叢集之間的間距，減小則使叢集更靠近。