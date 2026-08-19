---
title: 在 Python 中於簡報套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/python-net/chart-worksheet-formulas/
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
- A1 樣式
- R1C1 樣式
- 預定義函數
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 圖表工作表中套用 Excel 風格公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概觀**

PowerPoint 圖表通常將其來源資料儲存在內嵌工作表中。 在 Aspose.Slides for Python via .NET 中，您可以透過圖表資料工作簿存取該工作表、寫入輸入值、將公式指派給儲存格、計算受支援的公式，並將計算後的儲存格用作圖表資料。

本文說明完整的公式工作流程：建立圖表、填寫其工作表、指派 A1 樣式或 R1C1 樣式的公式、重新計算它們、讀取計算結果、將這些儲存格連接至圖表系列，並儲存簡報。 同時也描述受支援的公式語法、內建函數子集、快取值、未支援的公式，以及試算表專屬錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表所使用的類別、系列名稱與數值。  
在 PowerPoint 中，您可以開啟圖表資料編輯器來檢視工作表：

![PowerPoint 圖表開啟其內嵌工作表，顯示類別與系列資料](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過 [圖表資料工作簿](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdataworkbook/) 來呈現。 使用 [formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/formula/) 屬性設定 A1 樣式的公式，使用 [r1c1_formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) 屬性設定 R1C1 樣式的公式。 在變更輸入儲存格或公式後，呼叫 [calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) 以重新計算受支援的公式並更新相應的儲存格值。

即使是已計算的儲存格仍透過 [value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/value/) 屬性公開其結果。 當您需要在程式碼中檢查公式結果或將儲存格作為圖表資料點時，這點相當重要。

## **建立圖表並計算工作表公式**

以下範例示範完整的工作流程。 它建立叢集柱狀圖、清除範例資料、寫入每季營收與支出值、使用公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，並儲存簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

圖表資料點參照 `D2:D4`，因此圖表使用計算後的利潤值。 在此工作流程中沒有單獨的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向已計算儲存格的圖表資料。

## **使用 A1 樣式公式**

A1 記號以字母表示欄，以數字表示列。 透過 [IChartDataCell.formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/formula/) 指派 A1 樣式的運算式。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相對參照在公式被試算表應用程式移動或複製時會變更。 絕對參照固定兩個座標，而混合參照則只固定列或欄之一。

## **使用 R1C1 樣式公式**

R1C1 記號以數字同時識別列與欄。 相對參照使用方括號內的偏移值。 透過 [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) 指派此語法。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在儲存格 `D2` 中，`RC[-2]` 代表同一列向左兩欄的儲存格 (`B2`)。

## **公式常數與運算子**

內建的公式評估器支援邏輯值、數值字面值、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與字面值**

| 類型 | 範例 | 備註 |
|---|---|---|
| 邏輯 | `TRUE`, `FALSE` | 可直接於邏輯運算式中使用，例如 `A2=TRUE`。 |
| 數值 | `1`, `0.5`, `.3`, `1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`, `"2/3/2020 12:00"` | 文字字面值須在公式內以雙引號括住。 |
| 錯誤結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效的公式可以評估為試算表錯誤值而非正常結果。 |

此範例使用了多種常數類型：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # 假
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **算術運算子**

| 運算子 | 含義 | 範例 |
|---|---|---|
| `+` | 加法或單元正號 | `2+3` |
| `-` | 減法或負號 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 乘方 | `2^3` |

使用括號可明確指定運算順序，例如 `(A2+B2)*C2`。

### **比較運算子**

比較運算式會傳回邏輯值。

| 運算子 | 含義 | 範例 |
|---|---|---|
| `=` | 等於 | `A2=3` |
| `<>` | 不等於 | `A2<>3` |
| `>` | 大於 | `A2>3` |
| `>=` | 大於等於 | `A2>=3` |
| `<` | 小於 | `A2<3` |
| `<=` | 小於等於 | `A2<=3` |

## **支援的內建函數**

Aspose.Slides 包含用於圖表工作表的內建公式評估器，但它並非完整的 Excel 計算引擎。 文件化的函數集合僅限於以下函數。 請勿假設任意 Excel 函數皆可由 [calculate_formulas] 重新計算。

| 函數 | 用途或受支援的形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選擇值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合併文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合併文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 回傳兩日期之間的天數 | `DAYS(B2,A2)` |
| `FIND` | 在字串中尋找文字 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 加總 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查找 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記錄，而 `LOOKUP` 與 `MATCH` 以向量形式記錄。`DATE` 使用 1900 日期系統。未列於此處的功能與函數應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與其最後計算的值。 因此，在載入簡報且相關圖表資料未變更時，Aspose.Slides 可以從 [IChartDataCell.value] 讀取快取值。

變更輸入儲存格或公式後，請勿依賴舊的快取結果。 在讀取計算值或儲存依賴於這些值的圖表資料之前，呼叫 [ChartDataWorkbook.calculate_formulas]。

對於超出支援子集的公式，Aspose.Slides 可能無法解析該公式或確定其相依性。 若工作簿已被修改，先前的快取值不再可信。 在此情況下，讀取含未支援資料的儲存格的值可能拋出 [CellUnsupportedDataException]。

如果您的圖表依賴 Aspose.Slides 未計算的 Excel 函數，請使用支援這些函數的試算表引擎計算公式，然後將結果寫回圖表工作簿。 請勿以猜測值取代未支援的公式。

## **處理公式錯誤**

有兩種不同類型的問題需要區分。

公式可能是有效的，但會產生試算表錯誤結果，例如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!` 或 `#VALUE!`。 在此情況下，錯誤代碼是儲存格的結果，可透過 `value` 回傳。

公式也可能在解析、參照、相依性或受支援資料層面失敗。 Aspose.Slides 為這些情況提供試算表特定的例外：[CellInvalidFormulaException]、[CellInvalidReferenceException]、[CellCircularReferenceException]，以及 [CellUnsupportedDataException]。

當公式來自範本或使用者輸入時，請在重新計算與取得值的過程中處理這些例外：

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **實務限制**

圖表工作表中的公式支援旨在針對特定子集的試算表計算，而非完整的 Excel 相容性。 在設計報表工作流程時，請留意以下限制：

- 僅在需要 Aspose.Slides 重新計算公式時使用文件化的常數、運算子、參照與函數。  
- 變更公式結果所依賴的儲存格後，請重新計算。  
- 將載入的簡報中的快取值視為快照，而非在編輯後取代重新計算的方式。  
- 在依賴現有範本的公式計算值之前先測試，特別是當它們使用未列於文件的函數時。  
- 對於需要完整試算表計算引擎的公式，請在外部計算後再將結果更新至圖表工作簿。

## **常見問題**

**`formula` 與 `r1c1_formula` 有何不同？**  
[formula] 儲存 A1 樣式的運算式，例如 `B2-C2`。 [r1c1_formula] 儲存 R1C1 樣式的運算式，例如 `RC[-2]-RC[-1]`。 請使用最符合您產生或複製公式方式的記法。

**變更計算後，我需要讀取儲存格本身還是它的值？**  
[ChartDataWorkbook.get_cell] 會傳回 `IChartDataCell`。 若要取得計算結果，請在重新計算後讀取該儲存格的 [value] 屬性。

**什麼時候應該呼叫 `calculate_formulas`？**  
在變更輸入值或公式後、在依賴計算結果之前，呼叫 [calculate_formulas]。 這會更新內建評估器支援的公式之值。

**Aspose.Slides 支援每一個 Excel 函數嗎？**  
不會。 內建的評估器只支援文件化的函數子集。 不應假設子集之外的函數能正確重新計算。 若需完整的 Excel 公式相容性，請使用適當的試算表引擎執行計算，並將最終值寫回圖表工作簿。

**如果載入的簡報包含未支援的公式會發生什麼？**  
如果圖表資料未變更，工作簿可能仍保留先前計算的快取值。 當相關資料被修改後，該快取值可能不再有效。 嘗試存取無法處理的公式之儲存格時，可能拋出 [CellUnsupportedDataException]。

**公式錯誤值與 Python 例外相同嗎？**  
不是。 像 `#DIV/0!` 這樣的結果是有效計算產生的試算表值。 例外情況如 [CellInvalidFormulaException] 或 [CellCircularReferenceException] 表示公式無法正常處理。

**當公式儲存格變更時，圖表會自動更新嗎？**  
圖表系列可以參照工作簿儲存格。 請先重新計算工作簿，然後儲存或渲染簡報。 若圖表資料點參照計算過的儲存格，圖表會使用這些更新後的儲存格值；此工作流程不需要額外的圖表重新整理方法。

**圖表可以使用外部 Excel 工作簿嗎？**  
是的，圖表資料可透過圖表資料 API 設定為使用外部工作簿。 但本文所描述的公式計算工作流程僅涉及圖表資料工作簿以及 Aspose.Slides 評估的公式子集。 請勿假設 [calculate_formulas] 能完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**  
圖表工作簿中可能會出現 Excel 風格的跨工作表或跨工作簿參照，但公式評估受限於支援的解析器與函數集合。 若跨工作表或外部參照為必要，請以目標 Aspose.Slides 版本驗證該公式的正確性。 對於需要廣泛 Excel 參照相容性的工作流程，請在外部計算工作簿，並將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**  
Aspose.Slides API 範例會指派如 `B2-C2` 或 `SUM(B2:B5)` 的運算式，且不加前導 `=`。 使用此形式可讓產生的公式與文件化的 API 範例保持一致。