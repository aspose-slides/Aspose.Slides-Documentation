---
title: 在 PHP 簡報中套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/php-java/chart-worksheet-formulas/
keywords:
- 圖表試算表
- 圖表工作表
- 圖表公式
- 工作表公式
- 試算表公式
- 圖表資料工作簿
- 公式計算
- 首選語系
- 語系特定公式
- DBCS
- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格
- R1C1 風格
- 預定義函式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 的圖表工作表中套用 Excel 風格公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概觀**

PowerPoint 圖表通常將其來源資料儲存在嵌入式工作表中。於 Aspose.Slides for PHP via Java，您可以透過圖表資料工作簿存取該工作表、寫入輸入值、為儲存格指派公式、計算支援的公式，並使用計算後的儲存格作為圖表資料。

本文說明完整的公式工作流程：建立圖表、填充其工作表、指派 A1 風格或 R1C1 風格的公式、重新計算、讀取計算值、將這些儲存格連接到圖表序列，最後儲存簡報。亦說明支援的公式語法、內建函式子集、快取值、未支援的公式以及試算表特定錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、序列名稱與數值。在 PowerPoint 中，您可以開啟圖表資料編輯器檢視工作表：

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/) 類別公開。對於 A1 風格公式使用 [ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula)，對於 R1C1 風格公式使用 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula)。在變更輸入儲存格或公式後，呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 重新計算支援的公式並更新相應的儲存格值。

計算後的儲存格仍透過 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 取得結果。當您需要在程式碼中檢查公式結果或將儲存格作為圖表資料點時，這點非常重要。

## **建立圖表並計算工作表公式**

下列範例示範端對端工作流程。它建立群組柱狀圖、清除範例資料、寫入季度收入與支出值、使用公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，最後儲存簡報。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

圖表資料點參照 `D2:D4`，因此圖表使用計算出的利潤值。此工作流程中沒有單獨的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 表記法以字母識別欄、以數字識別列。透過 [ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 指派 A1 風格的運算式。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

常見的 A1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相對參照在公式被移動或複製時會變更。絕對參照會將兩個座標固定，混合參照則僅固定列或欄。

## **使用 R1C1 風格公式**

R1C1 表記法以數字識別列與欄。相對參照使用方括號內的位移。透過 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 指派此語法。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

常見的 R1C1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在儲存格 `D2` 中，`RC[-2]` 表示同列左移兩欄的儲存格 (`B2`)。

## **公式常數與運算子**

內建公式評估器支援邏輯值、數值常數、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與字面值**

| 類型 | 範例 | 備註 |
|---|---|---|
| 邏輯 | `TRUE`, `FALSE` | 可直接用於邏輯運算式，如 `A2=TRUE`。 |
| 數值 | `1`, `0.5`, `.3`, `1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`, `"2/3/2020 12:00"` | 文字字面值需以雙引號包住於公式中。 |
| 錯誤結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式可能評估為試算表錯誤值，而非正常結果。 |

此範例使用了多種常數類型：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **算術運算子**

| 運算子 | 說明 | 範例 |
|---|---|---|
| `+` | 加法或單元正號 | `2+3` |
| `-` | 減法或負號 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 指數 | `2^3` |

使用括號明確指定運算順序，例如 `(A2+B2)*C2`。

### **比較運算子**

比較運算式傳回邏輯值。

| 運算子 | 說明 | 範例 |
|---|---|---|
| `=` | 等於 | `A2=3` |
| `<>` | 不等於 | `A2<>3` |
| `>` | 大於 | `A2>3` |
| `>=` | 大於或等於 | `A2>=3` |
| `<` | 小於 | `A2<3` |
| `<=` | 小於或等於 | `A2<=3` |

## **支援的預定義函式**

Aspose.Slides 內建的公式評估器僅支援以下函式，並非完整的 Excel 計算引擎。請勿假設任意 Excel 函式皆能被 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 重新計算。

| 函式 | 目的或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 連接文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 連接文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 以 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 返迴兩個日期之間的天數 | `DAYS(B2,A2)` |
| `FIND` | 在文字中尋找另一文字 | `FIND("-",A2)` |
| `FINDB` | 位元組導向的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 加總 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直搜尋 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記錄，而 `LOOKUP` 與 `MATCH` 以向量形式記錄。`DATE` 使用 1900 日期系統。未列於此處的功能與函式應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **以首選語系計算公式**

某些工作簿函式會依語系規則解讀文字，特別是針對使用雙位元組字元集 (DBCS) 的語言。若要正確計算此類公式，請建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/)，使用 [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) 設定首選語系，透過 [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) 指派試算表選項，然後載入簡報。

以下範例選取日語語系，使用設定好的載入選項開啟簡報，並對每個圖表工作簿呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

首選語系屬於簡報載入設定的一部份，因此必須在建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例之前指定。使用工作簿公式所需的語系，例如對應日本 DBCS 計算規則的 `ja-JP`。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與最後計算的值。Aspose.Slides 因此能在載入簡報且相關圖表資料未變更時，從 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 讀取快取值。

在變更輸入儲存格或公式後，請不要依賴舊的快取結果。呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 後，再讀取計算值或儲存依賴這些值的圖表資料。

對於不在支援子集內的公式，Aspose.Slides 可能無法解析公式或確定其相依性。若工作簿已被修改，先前的快取值不再可靠。此時，讀取包含未支援資料的儲存格可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellunsupporteddataexception/)。

如果您的圖表依賴於 Aspose.Slides 無法評估的 Excel 函式，請使用支援該函式的試算表引擎先行計算，然後將結果寫回圖表工作簿。不要以猜測值取代未支援的公式。

## **處理公式錯誤**

需要區分兩種不同的問題。

1. 公式本身有效，但產生試算表錯誤結果，如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!`。此時錯誤代碼是儲存格的結果，可透過 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 取得。

2. 公式在解析、參照、相依性或支援資料層面失敗。Aspose.Slides 為此提供試算表特定例外： [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellunsupporteddataexception/)。

在 PHP via Java 中，Java 例外會透過 `JavaException` 轉譯。當公式來源於範本或使用者輸入時，請在重新計算與取得值的程式區塊周圍處理此例外。堆疊追蹤中顯示的 Java 例外會指出具體的試算表失敗原因：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **實務限制**

圖表工作表的公式支援旨在提供一組已定義的試算表計算子集，而非完整的 Excel 相容性。設計報表工作流程時請留意以下限制：

- 僅使用文件化的常數、運算子、參照與函式，才能讓 Aspose.Slides 重新計算公式。
- 在變更公式結果所依賴的儲存格後，務必重新計算。
- 將載入簡報時的快取值視為快照，而非編輯後不重新計算的替代方案。
- 在依賴既有範本的計算結果前，先測試其公式，尤其是使用未列於文件的函式時。
- 對於需要完整試算表計算引擎的公式，請先於外部計算，再將結果寫回圖表工作簿。

## **常見問題**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 與 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 有何差異？**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 會儲存 A1 風格的表達式，例如 `B2-C2`。[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 會儲存 R1C1 風格的表達式，例如 `RC[-2]-RC[-1]`。請依您產生或複製公式的方式選擇最適合的表記法。

**計算後，我需要讀取儲存格本身還是其值？**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#getCell) 會返回一個 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/)。在重新計算之後，呼叫該儲存格的 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 以取得計算結果。

**什麼時候應該呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)？**

在變更輸入值或公式後，且在依賴計算結果之前，請呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)。這會更新內建評估器支援的公式值。

**Aspose.Slides 是否支援所有 Excel 函式？**

否。內建評估器僅支援文件化的子集。未列於子集的函式不應假設能正確重新計算。若需完整的 Excel 公式相容性，請使用適當的試算表引擎進行計算，並將最終值寫入圖表工作簿。

**如果載入的簡報包含未支援的公式會發生什麼？**

若圖表資料未變更，工作簿可能仍保有先前計算的快取值。相關資料變更後，該快取值可能不再有效。存取無法處理的公式所在的儲存格可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellunsupporteddataexception/)。

**公式錯誤值等同於 PHP 例外嗎？**

不等同。`#DIV/0!` 之類的結果是由有效計算產生的試算表值。像 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellcircularreferenceexception/) 之類的試算表處理失敗會以 Java 例外形式透過 `JavaException` 轉換至 PHP。

**當公式儲存格變更時，圖表會自動更新嗎？**

圖表序列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或渲染簡報即可。只要圖表資料點參照計算後的儲存格，圖表就會使用更新後的值，無需額外的圖表重新整理方法。

**圖表能使用外部 Excel 工作簿嗎？**

可以，圖表資料可透過圖表資料 API 設定使用外部工作簿。然而，本篇文章描述的公式計算工作流程僅針對圖表工作簿與 Aspose.Slides 評估的公式子集。不要假設 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 會完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**

圖表工作簿中可能出現 Excel 風格的跨表或跨檔案參照，但公式評估受限於支援的解析器與函式集。若跨表或外部參照為必要，請先在目標 Aspose.Slides 版本上驗證該公式。對於需要廣泛 Excel 參照相容性的工作流程，請於外部計算工作簿，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例在指派表達式時使用 `B2-C2` 或 `SUM(B2:B5)`，不加前置的 `=`。採用此形式可使產生的公式與文件中的 API 範例保持一致。