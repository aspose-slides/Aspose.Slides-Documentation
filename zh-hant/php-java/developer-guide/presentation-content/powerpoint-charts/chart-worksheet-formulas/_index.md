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
- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格
- R1C1 風格
- 預先定義函式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 的圖表工作表中套用 Excel 風格的公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概觀**

PowerPoint 圖表通常將其來源資料儲存在內嵌工作表中。在 Aspose.Slides for PHP via Java 中，您可以透過圖表資料工作簿存取該工作表、寫入輸入值、將公式指派給儲存格、計算支援的公式，並將計算後的儲存格作為圖表資料使用。

本文說明完整的公式工作流程：建立圖表、填入工作表、指派 A1 風格或 R1C1 風格的公式、重新計算、讀取計算結果、將這些儲存格連結到圖表系列，並儲存簡報。它還說明了支援的公式語法、內建函式子集、快取值、不支援的公式，以及試算表特定的錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、系列名稱與數值。在 PowerPoint 中，您可以開啟圖表資料編輯器來檢視工作表：

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/) 類別公開。使用 [ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 設定 A1 風格公式，使用 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 設定 R1C1 風格公式。變更輸入儲存格或公式後，呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 重新計算支援的公式並更新相應的儲存格值。

計算後的儲存格仍透過 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 取得其結果。當您需要在程式碼中檢查公式結果或將儲存格作為圖表資料點時，這一點非常重要。

## **建立圖表並計算工作表公式**

以下範例示範端對端工作流程。它會建立叢集柱狀圖、清除範例資料、寫入每季收入與支出值、使用公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，最後儲存簡報。

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

圖表資料點參照 `D2:D4`，因此圖表使用計算後的利潤值。在此工作流程中不需要額外的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 記號使用字母表示欄，數字表示列。透過 [ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 指派 A1 風格表達式。

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

相對參照在公式被移動或複製時可能會改變。絕對參照會固定兩個座標，混合參照則只固定列或欄。

## **使用 R1C1 風格公式**

R1C1 記號使用數字表示列與欄。相對參照在方括號內使用偏移量。透過 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 指派此語法。

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

例如，在儲存格 `D2` 中，`RC[-2]` 表示同一列向左兩欄的儲存格 (`B2`)。

## **公式常數與運算子**

內建公式評估器支援邏輯值、數值常數、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與文字**

| 類型 | 範例 | 註記 |
|---|---|---|
| 邏輯 | `TRUE`, `FALSE` | 可直接用於如 `A2=TRUE` 的邏輯運算式。 |
| 數值 | `1`, `0.5`, `.3`, `1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`, `"2/3/2020 12:00"` | 文字常數必須在公式內以雙引號包住。 |
| 錯誤結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效的公式可能會評估為試算表錯誤值，而非正常結果。 |

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

比較運算式會傳回邏輯值。

| 運算子 | 說明 | 範例 |
|---|---|---|
| `=` | 等於 | `A2=3` |
| `<>` | 不等於 | `A2<>3` |
| `>` | 大於 | `A2>3` |
| `>=` | 大於或等於 | `A2>=3` |
| `<` | 小於 | `A2<3` |
| `<=` | 小於或等於 | `A2<=3` |

## **支援的預定義函式**

Aspose.Slides 為圖表工作表提供內建公式評估器，但它並非完整的 Excel 計算引擎。文件中列出的函式僅限以下列表。請勿假設任意 Excel 函式都能由 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 正確重新計算。

| 函式 | 用途或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合併文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合併文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 回傳兩個日期之間的天數 | `DAYS(B2,A2)` |
| `FIND` | 在文字中搜尋另一段文字 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直搜尋 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記錄，`LOOKUP` 與 `MATCH` 以向量形式記錄。`DATE` 使用 1900 日期系統。未列於此處的功能與函式應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與最後計算出的值。載入簡報且相關圖表資料未變更時，Aspose.Slides 可以從 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 讀取快取值。

變更輸入儲存格或公式後，請勿依賴舊的快取結果。於讀取計算值或儲存依賴於這些值的圖表資料前，先呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)。

對於不屬於支援子集的公式，Aspose.Slides 可能無法解析公式或確定其相依性。若工作簿已被修改，先前的快取值不再可靠。在此情況下，讀取含有不支援資料的儲存格會拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellunsupporteddataexception/)。

如果您的圖表依賴於 Aspose.Slides 無法評估的 Excel 函式，請使用支援這些函式的試算表引擎先計算，然後將結果寫回圖表工作簿。不要以猜測值取代不支援的公式。

## **處理公式錯誤**

需要區分兩種不同的問題。

公式本身可能有效，但會產生如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` 等試算表錯誤結果。此情況下，錯誤代碼是儲存格結果，可透過 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 取得。

公式也可能在解析、參照、相依性或支援資料層級失敗。Aspose.Slides 為這些情況提供試算表特定的例外類型： [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellcircularreferenceexception/)、以及 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellunsupporteddataexception/)。

在 PHP via Java 中，Java 例外會以 `JavaException` 形式呈現。當公式來自範本或使用者輸入時，請在重新計算與存取值的程式區塊中捕捉。堆疊追蹤中顯示的 Java 例外可幫助確定具體的試算表失敗原因：

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

圖表工作表的公式支援旨在提供一組已定義的試算表計算子集，而非完整的 Excel 相容性。設計報表工作流程時請記住以下限制：

- 只有在文件中列出的常數、運算子、參照與函式才能讓 Aspose.Slides 重新計算公式。
- 在變更公式結果所依賴的儲存格後必須重新計算。
- 從已載入的簡報取得的快取值僅為快照，編輯後仍須重新計算。
- 在依賴計算結果之前，先測試既有範本中的公式，尤其是使用未列於文件的函式時。
- 若公式需要完整的試算表計算引擎，請先於外部計算，然後將結果寫回圖表工作簿。

## **常見問答**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 與 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 有何不同？**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 會儲存 A1 風格的表達式，例如 `B2-C2`。[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 會儲存 R1C1 風格的表達式，例如 `RC[-2]-RC[-1]`。請依照您產生或複製公式的方式選擇適合的記號。

**計算後，我是要讀取儲存格本身還是它的值？**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#getCell) 會回傳一個 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/)。在重新計算之後，呼叫該儲存格的 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 以取得計算結果。

**什麼時候應該呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)？**

在變更輸入值或公式後、且在依賴計算結果之前，呼叫 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)。這會更新內建評估器支援的公式值。

**Aspose.Slides 是否支援所有 Excel 函式？**

不支援。內建評估器僅支援文件中列出的子集。未列出的函式不應假設能正確重新計算。若需要完整的 Excel 公式相容性，請使用適當的試算表引擎執行計算，然後將最終值寫入圖表工作簿。

**如果載入的簡報包含不支援的公式會發生什麼？**

如果圖表資料未變更，工作簿可能仍保留先前計算的快取值。相關資料變更後，該快取值可能不再有效。存取無法處理的公式的儲存格時，可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellunsupporteddataexception/)。

**公式錯誤值與 PHP 例外是一樣的嗎？**

不是。`#DIV/0!` 等結果是由有效計算產生的試算表值。試算表處理失敗（如 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellcircularreferenceexception/)）則是 Java 例外，透過 `JavaException` 於 PHP 中顯示。

**當公式儲存格變更時，圖表會自動更新嗎？**

圖表系列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或呈現簡報即可。如果圖表資料點引用了計算後的儲存格，圖表會使用更新後的值；此工作流程不需要額外的圖表重新整理方法。

**圖表可以使用外部 Excel 工作簿嗎？**

可以，圖表資料可以透過圖表資料 API 設定為使用外部工作簿。然而，本文所述的公式計算工作流程僅針對圖表資料工作簿及 Aspose.Slides 評估的公式子集。不要假設 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 能完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**

Excel 風格的跨工作表或跨檔案參照在圖表工作簿中可能存在，但公式評估受限於支援的解析器與函式集。若跨表或外部參照是必須的，請先以目標 Aspose.Slides 版本驗證該公式的正確性。對於需要廣泛 Excel 參照相容性的工作流程，請在外部計算工作簿，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例會直接指派 `B2-C2` 或 `SUM(B2:B5)`，不帶前置的 `=`。使用此形式可讓產生的公式與文件中的 API 範例保持一致。