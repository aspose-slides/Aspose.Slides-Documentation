---
title: 在 Python via Java 的簡報中套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/python-java/chart-worksheet-formulas/
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
- 雙位元組字元集
- 布林常數
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
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides (Python via Java) 的圖表工作表中套用 Excel 風格公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概觀**

PowerPoint 圖表通常將其來源資料儲存在嵌入式工作表中。 在 Aspose.Slides for Python via Java 中，您可以透過圖表資料工作簿存取該工作表，寫入輸入值、為儲存格指派公式、計算受支援的公式，並將計算後的儲存格用作圖表資料。

本文說明完整的公式工作流程：建立圖表、填充其工作表、指派 A1 風格或 R1C1 風格公式、重新計算、讀取計算值、將這些儲存格連接到圖表系列，最後儲存簡報。 也會描述受支援的公式語法、內建函式子集、快取值、未受支援的公式，以及試算表特有的錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、系列名稱與數值。 在 PowerPoint 中，您可以透過開啟圖表資料編輯器來檢視工作表：

![PowerPoint 圖表其嵌入式工作表已開啟，顯示類別與系列資料](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/)類別公開。 使用[ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setFormula)設定 A1 風格公式，使用[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setR1C1Formula)設定 R1C1 風格公式。 更改輸入儲存格或公式後，呼叫[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)以重新計算受支援的公式並更新相應的儲存格值。

計算過的儲存格仍可透過[ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#getValue)取得其結果。 這在您需要在程式碼中檢查公式結果或將儲存格作為圖表資料點時尤為重要。

## **建立圖表並計算工作表公式**

以下範例示範端對端工作流程。 它建立叢集柱狀圖、清除範例資料、寫入每季營收與費用值、使用公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，最後儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

圖表資料點參考 `D2:D4`，因此圖表使用計算出的利潤值。 此工作流程中沒有單獨的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 表記使用字母表示欄，數字表示列。 透過[ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setFormula)指派 A1 風格表達式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

常見的 A1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`、`$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`、`$A2:C$4` |

相對參照在公式被移動或複製時會變動。 絕對參照則兩個座標皆固定，混合參照只固定列或欄其中之一。

## **使用 R1C1 風格公式**

R1C1 表記以數字同時識別列與欄。 相對參照使用方括號內的偏移量。 透過[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setR1C1Formula)指派此語法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

常見的 R1C1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`、`R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`、`R[2]C3:R5C[7]` |

例如，在儲存格 `D2` 中，`RC[-2]` 代表同列向左兩欄的儲存格 (`B2`)。

## **公式常數與運算子**

內建公式運算子支援布林值、數值常數、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與字面值**

| 類型 | 範例 | 備註 |
|---|---|---|
| 布林 | `TRUE`、`FALSE` | 可直接在布林運算式中使用，例如 `A2=TRUE`。 |
| 數值 | `1`、`0.5`、`.3`、`1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`、`"2/3/2020 12:00"` | 文字常數需以雙引號包住。 |
| 錯誤結果 | `#DIV/0!`、`#N/A`、`#REF!` | 有效公式可能會評估為試算表錯誤值。 |

以下範例使用了多種常數類型：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # False
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **算術運算子**

| 運算子 | 意義 | 範例 |
|---|---|---|
| `+` | 加法或單正號 | `2+3` |
| `-` | 減法或負號 | `2-3`、`-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 次方 | `2^3` |

使用括號明確指定計算順序，例如 `(A2+B2)*C2`。

### **比較運算子**

比較運算式會傳回布林值。

| 運算子 | 意義 | 範例 |
|---|---|---|
| `=` | 等於 | `A2=3` |
| `<>` | 不等於 | `A2<>3` |
| `>` | 大於 | `A2>3` |
| `>=` | 大於等於 | `A2>=3` |
| `<` | 小於 | `A2<3` |
| `<=` | 小於等於 | `A2<=3` |

## **受支援的預先定義函式**

Aspose.Slides 為圖表工作表提供內建公式運算子，但它不是完整的 Excel 計算引擎。 文件中列出的函式集合有限，請勿假設任意 Excel 函式可由[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)重新計算。

| 函式 | 目的或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至最接近的倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 連接文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 連接文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 回傳兩個日期之間的天數 | `DAYS(B2,A2)` |
| `FIND` | 在文字中尋找另一段文字 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直搜尋 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式文件化，而 `LOOKUP` 與 `MATCH` 以向量形式文件化。`DATE` 使用 1900 日期系統。未列於此處的功能與函式皆應視為 Aspose.Slides 公式運算子不支援，除非另有文件說明。

## **以首選語系計算公式**

某些工作簿函式會依語系規則解讀文字，特別是針對使用雙位元組字元集 (DBCS) 的語言。 若要正確計算此類公式，請建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/)，使用[SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture)設定首選語系，透過[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)指派試算表選項，然後載入簡報。

以下範例選擇日語語系，使用配置好的載入選項開啟簡報，並對每個圖表工作簿呼叫[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

首選語系是簡報載入設定的一部分，必須在建立[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)實例之前指定。使用與工作簿公式相同的語系；例如，對於應遵循日文 DBCS 計算規則的公式，使用 `ja-JP`。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與最後一次計算的結果。 Aspose.Slides 因此在載入簡報且相關圖表資料未變更時，可從[ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#getValue) 讀取快取值。

變更輸入儲存格或公式後，請在讀取計算值或儲存依賴於它們的圖表資料之前，呼叫[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)。

對於超出支援子集的公式，Aspose.Slides 可能無法解析或建立其相依關係。若工作簿已被修改，先前的快取值將不再可靠。此情況下，讀取含有未受支援資料的儲存格可能拋出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellunsupporteddataexception/)。

如果您的圖表依賴於 Aspose.Slides 無法評估的 Excel 函式，請使用支援該函式的試算表引擎先行計算，然後將計算結果寫回圖表工作簿。不要以猜測值取代未受支援的公式。

## **處理公式錯誤**

問題可分為兩類。

公式本身有效，但會產生試算表錯誤結果，例如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!` 或 `#VALUE!`。此時錯誤代碼是儲存格的結果，會透過[ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#getValue)傳回。

公式也可能在語法、參照、相依或支援資料層面失敗。Aspose.Slides 為此提供試算表專屬例外：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellcircularreferenceexception/) 與 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellunsupporteddataexception/)。

當公式來自範本或使用者輸入時，請在重新計算與取得值的程式碼區塊中捕捉這些例外：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **實作限制**

圖表工作表的公式支援僅針對特定的試算表計算子集，並非完整的 Excel 相容性。 設計報表工作流程時請留意以下限制：

- 僅使用文件中列出的常數、運算子、參照與函式，才可期待 Aspose.Slides 重新計算公式。
- 在變更公式結果所依賴的儲存格後，務必重新計算。
- 由已載入簡報取得的快取值僅為快照，編輯後仍需重新計算。
- 在依賴既有範本的公式之前，先於測試環境驗證其計算結果，特別是使用未列於文件的函式時。
- 若公式需要完整的試算表計算引擎，請先於外部計算，再將結果寫回圖表工作簿。

## **常見問答**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setFormula) 與 [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setR1C1Formula) 有何差異？**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setFormula) 以 A1 風格儲存例如 `B2-C2` 的表達式。 [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setR1C1Formula) 以 R1C1 風格儲存例如 `RC[-2]-RC[-1]` 的表達式。請依照您產生或複製公式的方式選擇相符的記法。

**計算完畢後，我需要讀取儲存格本身還是其值？**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#getCell) 會傳回一個 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/) 物件。要取得計算結果，請在重新計算後呼叫該儲存格的 [ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#getValue) 方法。

**什麼時機需要呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)？**

在變更輸入值或公式後、且在依賴計算結果之前，務必呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)。這會更新內建運算子支援的公式值。

**Aspose.Slides 是否支援所有 Excel 函式？**

不支援。內建運算子僅支援文件中列出的函式子集。未列出的函式不可假設會正確重新計算。若需要完整的 Excel 公式相容性，請使用其他試算表引擎計算後，再把最終值寫回圖表工作簿。

**若載入的簡報內含未受支援的公式，會發生什麼？**

如果圖表資料未變更，工作簿可能仍保留先前計算好的快取值。當相關資料被修改後，該快取值可能不再有效。嘗試存取無法處理的公式儲存格時，可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellunsupporteddataexception/)。

**公式錯誤值與例外是同一概念嗎？**

不是。`#DIV/0!` 等錯誤值是有效計算後的試算表值。例外如 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellcircularreferenceexception/) 表示公式無法正常處理。

**當公式儲存格變更時，圖表會自動更新嗎？**

圖表系列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或呈現簡報即可。只要圖表資料點參考的是計算後的儲存格，圖表就會使用更新後的值；不需要額外的圖表重新整理方法。

**圖表可以使用外部 Excel 工作簿嗎？**

可以，圖表資料可透過圖表資料 API 設定使用外部工作簿。但本文件描述的公式計算工作流程僅針對圖表資料工作簿及 Aspose.Slides 所評估的公式子集。不要假設 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) 能完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**

圖表工作簿中可以出現 Excel 風格的跨工作表或外部參照，但公式評估受限於支援的解析器與函式集合。若跨工作表或外部參照是必要的，請先以目標 Aspose.Slides 版本驗證該公式的可行性。對於需要廣泛 Excel 參照相容性的工作流程，請先在外部計算工作簿，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例會直接指派 `B2-C2`、`SUM(B2:B5)` 等字串，未加前置 `=`。使用此形式可確保產生的公式與文件中的 API 範例保持一致。