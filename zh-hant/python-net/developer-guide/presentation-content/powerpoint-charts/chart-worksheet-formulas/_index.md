---
title: 使用 Python 在簡報中套用圖表工作表公式
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
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 的圖表工作表中套用 Excel 風格公式，重新計算數值，並將結果用於 PowerPoint 圖表。"
---
## **概觀**

PowerPoint 圖表通常將其來源資料儲存在嵌入式工作表中。在 Aspose.Slides for Python via .NET 中，您可以透過圖表資料工作簿存取該工作表、寫入輸入值、將公式指派給儲存格、計算支援的公式，並將計算結果的儲存格作為圖表資料使用。

本文說明完整的公式工作流程：建立圖表、填入工作表、指派 A1 風格或 R1C1 風格公式、重新計算它們、讀取計算值、將這些儲存格連結至圖表系列，最後儲存簡報。同時也描述支援的公式語法、內建函式子集、快取值、未支援的公式以及試算表特定錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、系列名稱與數值。在 PowerPoint 中，您可以開啟圖表資料編輯器來檢視工作表：

![PowerPoint 圖表開啟其嵌入式工作表，顯示類別與系列資料](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過[圖表資料工作簿](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdataworkbook/)暴露。對於 A1 風格公式使用[formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/formula/)屬性，對於 R1C1 風格公式使用[r1c1_formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)屬性。變更輸入儲存格或公式後，呼叫[calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)以重新計算支援的公式並更新相應的儲存格值。

計算後的儲存格仍透過[value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/value/)屬性公開其結果。當您需要在程式碼中檢查公式結果或將儲存格用作圖表資料點時，這點非常重要。

## **建立圖表並計算工作表公式**

以下範例示範端對端工作流程。它建立叢集柱狀圖、清除範例資料、寫入季營收與費用值、使用公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，最後儲存簡報。

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

圖表資料點參照 `D2:D4`，因此圖表使用計算出的利潤值。在此工作流程中沒有單獨的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 表示法以字母標示欄、以數字標示列。透過[IChartDataCell.formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/formula/)指派 A1 風格表達式。

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

常見的 A1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相對參照在公式被移動或複製時會改變。絕對參照則固定兩個座標，混合參照僅固定列或欄其中之一。

## **使用 R1C1 風格公式**

R1C1 表示法以數字同時標示列與欄。相對參照使用方括號內的位移。透過[IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)指派此語法。

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

常見的 R1C1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在儲存格 `D2` 中，`RC[-2]` 代表同一列左移兩欄的儲存格（`B2`）。

## **公式常數與運算子**

內建公式評估器支援布林值、數值常數、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與文字**

| 類型 | 範例 | 備註 |
|---|---|---|
| 布林 | `TRUE`, `FALSE` | 可直接用於如 `A2=TRUE` 的布林表達式。 |
| 數值 | `1`, `0.5`, `.3`, `1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`, `"2/3/2020 12:00"` | 文字常數須以雙引號包住於公式內。 |
| 錯誤結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式也可能評估為試算表錯誤值，而非正常結果。 |

以下範例使用多種常數類型：

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

| 運算子 | 意義 | 範例 |
|---|---|---|
| `+` | 加法或單項正號 | `2+3` |
| `-` | 減法或負號 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 次方 | `2^3` |

使用括號明確指定計算順序，例如 `(A2+B2)*C2`。

### **比較運算子**

比較表達式會傳回布林值。

| 運算子 | 意義 | 範例 |
|---|---|---|
| `=` | 等於 | `A2=3` |
| `<>` | 不等於 | `A2<>3` |
| `>` | 大於 | `A2>3` |
| `>=` | 大於或等於 | `A2>=3` |
| `<` | 小於 | `A2<3` |
| `<=` | 小於或等於 | `A2<=3` |

## **支援的預定義函式**

Aspose.Slides 包含用於圖表工作表的內建公式評估器，但它並非完整的 Excel 計算引擎。文件中僅列出以下函式。請勿假設任意 Excel 函式皆可由 [calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) 重新計算。

| 函式 | 目的或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 連接文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 連接文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 回傳兩日期之天數差 | `DAYS(B2,A2)` |
| `FIND` | 在文字中尋找文字 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 加總 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直搜尋 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記載，而 `LOOKUP` 與 `MATCH` 以向量形式記載。`DATE` 使用 1900 日期系統。未列於此處的功能應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **使用偏好語系計算公式**

某些工作簿函式會依語系規則解讀文字。這對於使用雙位元組字元集（DBCS）的語言尤為重要。若要正確計算此類公式，請建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/)，透過[LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/spreadsheet_options/) 設定[SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/spreadsheetoptions/)，然後載入簡報。

以下範例選取日語語系，使用已配置的載入選項開啟簡報，並對每個圖表工作簿呼叫[ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

偏好語系是簡報載入設定的一部份，須在建立[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例之前指定。使用工作簿公式所需的語系，例如針對日語 DBCS 計算規則使用 `ja-JP`。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與最後一次計算的值。Aspose.Slides 因此在載入簡報且相關圖表資料未變更時，會從[IChartDataCell.value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/value/) 讀取快取值。

變更輸入儲存格或公式後，請於讀取計算值或儲存依賴於它們的圖表資料之前，呼叫[ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)。

對於不在支援子集內的公式，Aspose.Slides 可能無法解析公式或確定其相依性。若工作簿已被修改，先前的快取值將不再可靠。此時讀取含未支援資料的儲存格值可能拋出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

如果您的圖表依賴於 Aspose.Slides 無法評估的 Excel 函式，請使用支援這些函式的試算表引擎先計算，然後將結果寫回圖表工作簿。不要以猜測值取代未支援的公式。

## **處理公式錯誤**

需區分兩種不同的問題類型。

公式本身可能有效，但會產生試算表錯誤結果，如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!`。此類錯誤代號是儲存格結果，可透過 `value` 取得。

公式也可能在解析、參照、相依性或支援資料層面失敗。Aspose.Slides 為這些情況提供試算表專屬例外：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

當公式來自範本或使用者輸入時，請在重新計算與存取值的程式區塊中捕捉這些例外：

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

圖表工作表的公式支援旨在提供限定的試算表計算子集，而非完整的 Excel 相容性。設計報表工作流程時請記得以下限制：

- 僅使用文件中列出的常數、運算子、參照與函式，才能讓 Aspose.Slides 重新計算公式。
- 在變更公式結果所依賴的儲存格後，務必重新計算。
- 將載入簡報時的快取值視為快照，而非編輯後的重新計算替代方案。
- 在依賴既有範本的公式前，先測試其計算結果，特別是使用了文件未列出的函式時。
- 需要完整試算表計算引擎的公式，請先在外部計算後再更新圖表工作簿的值。

## **常見問題**

**`formula` 與 `r1c1_formula` 有何差異？**

[formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/formula/) 儲存 A1 風格的表達式，例如 `B2-C2`。[r1c1_formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) 儲存 R1C1 風格的表達式，例如 `RC[-2]-RC[-1]`。請依照您產生或複製公式的慣用表示法選擇。

**計算後需要讀取儲存格本身還是其值？**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) 會回傳 `IChartDataCell`。重新計算後，取該儲存格的[value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/value/) 屬性即可取得計算結果。

**何時應呼叫 `calculate_formulas`？**

在變更輸入值或公式之後，且在依賴計算結果之前，呼叫[calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)。這會更新內建評估器支援的公式值。

**Aspose.Slides 是否支援所有 Excel 函式？**

不支援。內建評估器僅支援文件列出的子集。未列出的函式不應假設能正確重新計算。若需要完整的 Excel 公式相容性，請使用適當的試算表引擎完成計算，然後將最終值寫入圖表工作簿。

**若載入的簡報包含未支援的公式會怎樣？**

如果圖表資料未變更，工作簿可能仍保留先前計算的快取值。當相關資料被修改後，該快取值可能不再有效。存取無法處理的公式之儲存格時，可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

**公式錯誤值等同於 Python 例外嗎？**

不等同。`#DIV/0!` 之類的結果是由有效計算產生的試算表值。像 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) 這類例外表示公式無法正常處理。

**公式儲存格變更時圖表會自動更新嗎？**

圖表系列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或渲染簡報。如果圖表資料點參照的是計算後的儲存格，圖表會使用這些已更新的值；此工作流程不需要額外的圖表重新整理方法。

**圖表可以使用外部 Excel 工作簿嗎？**

可以，圖表資料可透過圖表資料 API 設定使用外部工作簿。然而，本文描述的公式計算工作流程僅與圖表資料工作簿及 Aspose.Slides 評估的公式子集相關。不要假設 [calculate_formulas](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) 能完整重新計算外部 XLSX 檔案中的任意公式。

**可以使用參照其他工作表或工作簿的公式嗎？**

圖表工作簿中可能出現 Excel 風格的跨工作表或跨檔案參照，但公式評估受支援的解析器與函式集合限制。若跨表或外部參照為必要，請先以目標 Aspose.Slides 版本驗證該公式。對於需要廣泛 Excel 參照相容性的工作流程，請在外部計算工作簿，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例會指派如 `B2-C2` 或 `SUM(B2:B5)` 之類的表達式，且不含前置的 `=`。使用此形式可使產生的公式與文件中的 API 範例保持一致。