---
title: 在 .NET 簡報中套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/net/chart-worksheet-formulas/
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
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 的圖表工作表中套用 Excel 風格公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概觀**

PowerPoint 圖表通常將來源資料儲存在嵌入的工作表中。在 Aspose.Slides for .NET 中，您可以透過圖表資料工作簿存取該工作表、寫入輸入值、為儲存格指派公式、計算受支援的公式，並使用計算後的儲存格作為圖表資料。

本文說明完整的公式工作流程：建立圖表、填寫其工作表、指派 A1 風格或 R1C1 風格的公式、重新計算它們、讀取計算值、將這些儲存格連結至圖表系列，最後儲存簡報。亦會描述受支援的公式語法、內建函式子集、快取值、不支援的公式以及試算表特定錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、系列名稱與數值。在 PowerPoint 中，您可以透過開啟圖表資料編輯器來檢視工作表：

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過[chart data workbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/)對外暴露。使用[Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/formula/)屬性設定 A1 風格公式，使用[R1C1Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/r1c1formula/)屬性設定 R1C1 風格公式。變更輸入儲存格或公式後，呼叫[CalculateFormulas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)以重新計算受支援的公式並更新相應的儲存格值。

計算後的儲存格仍透過[Value](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/value/)屬性曝露其結果。當您需要在程式碼中檢查公式結果或將儲存格作為圖表資料點使用時，這點非常重要。

## **建立圖表並計算工作表公式**

以下範例示範端對端工作流程。它建立叢集直條圖、清除範例資料、寫入每季收入與支出值、使用公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，最後儲存簡報。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

圖表資料點參考`D2:D4`，因此圖表使用計算後的利潤值。此工作流程中沒有單獨的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 記號使用字母代表欄、數字代表列。透過[IChartDataCell.Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/formula/)指派 A1 風格表達式。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

常見的 A1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相對參照在公式移動或複製時會變更。絕對參照將兩個座標皆固定，混合參照則僅固定列或欄。

## **使用 R1C1 風格公式**

R1C1 記號以數字同時識別列與欄。相對參照使用方括號內的位移。透過[IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/r1c1formula/)指派此語法。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

常見的 R1C1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在儲存格`D2`中，`RC[-2]`表示同一列左移兩欄的儲存格 (`B2`)。

## **公式常數與運算子**

內建公式評估器支援邏輯值、數值文字、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與文字**

| 類型 | 範例 | 註記 |
|---|---|---|
| 邏輯 | `TRUE`, `FALSE` | 可直接用於例如 `A2=TRUE` 的邏輯運算式。 |
| 數值 | `1`, `0.5`, `.3`, `1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`, `"2/3/2020 12:00"` | 文字文字必須在公式內以雙引號包住。 |
| 錯誤結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式可評估為試算表錯誤值而非一般結果。 |

此範例使用了多種常數類型：

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // False
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **算術運算子**

| 運算子 | 意義 | 範例 |
|---|---|---|
| `+` | 加法或一元正號 | `2+3` |
| `-` | 減法或否定 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 次方 | `2^3` |

使用括號明確指定運算順序，例如 `(A2+B2)*C2`。

### **比較運算子**

比較運算式傳回邏輯值。

| 運算子 | 意義 | 範例 |
|---|---|---|
| `=` | 等於 | `A2=3` |
| `<>` | 不等於 | `A2<>3` |
| `>` | 大於 | `A2>3` |
| `>=` | 大於或等於 | `A2>=3` |
| `<` | 小於 | `A2<3` |
| `<=` | 小於或等於 | `A2<=3` |

## **受支援的預定義函式**

Aspose.Slides 為圖表工作表提供內建公式評估器，但它並非完整的 Excel 計算引擎。文件中列出的函式集僅限於下表所示。不要假設任意 Excel 函式皆可由[CalculateFormulas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)重新計算。

| 函式 | 用途或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至最接近的倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合併文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合併文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 以 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 計算兩日期之間的天數 | `DAYS(B2,A2)` |
| `FIND` | 在字串中搜尋文字 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 加總 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查找 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記載，`LOOKUP` 與 `MATCH` 則以向量形式記載。`DATE` 使用 1900 日期系統。未列於此處的功能與函式應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **以首選語系計算公式**

某些工作簿函式會根據語系規則解讀文字。這在處理使用雙位元組字元集 (DBCS) 語言的函式時尤為重要。若要正確計算此類公式，請建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)，透過[LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/spreadsheetoptions/)設定[ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ispreadsheetoptions/preferredculture/)，然後載入簡報。

以下範例選取日語語系，使用已設定的載入選項開啟簡報，並對每個圖表工作簿呼叫[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)：

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

首選語系是簡報載入設定的一部份，因此請在建立[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)實例之前指定。使用工作簿公式所需的語系，例如對應日語 DBCS 計算規則時使用 `ja-JP`。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與最後計算的值。Aspose.Slides 因此能在載入簡報且相關圖表資料未變更時，從[IChartDataCell.Value](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/value/)讀取快取值。

變更輸入儲存格或公式後，請在讀取計算值或儲存依賴於它們的圖表資料之前，呼叫[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。

對於不在受支援子集之公式，Aspose.Slides 可能無法解析公式或確定其相依性。若工作簿已被修改，先前的快取值將不再可靠。在此情況下，讀取含不支援資料的儲存格會拋出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

如果您的圖表依賴 Aspose.Slides 無法評估的 Excel 函式，請使用支援這些函式的試算表引擎先行計算，然後將結果寫回圖表工作簿。不要以猜測的值取代不支援的公式。

## **處理公式錯誤**

需區分兩種不同的問題。

公式可能有效，但產生試算表錯誤結果，如 `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` 或 `#VALUE!`。此情況下，錯誤代號為儲存格結果，可透過 `Value` 取得。

公式也可能在語法、參照、相依性或支援資料層面失敗。Aspose.Slides 為這些情況提供特定的試算表例外：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellcircularreferenceexception/)、以及[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

當公式來自範本或使用者輸入時，請在重新計算與存取值的程式碼區塊周圍捕捉這些例外：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **實務限制**

圖表工作表中的公式支援旨在涵蓋特定的試算表計算子集，而非完整的 Excel 相容性。設計報表工作流程時請留意以下限制：

- 只使用文件中列出的常數、運算子、參照與函式，才能讓 Aspose.Slides 重新計算公式。
- 在變更公式結果所依賴的儲存格後必須重新計算。
- 將載入簡報時的快取值視為快照，而非編輯後的重新計算替代方案。
- 在依賴已計算值之前，先測試來自既有範本的公式，尤其是使用未列於文件的函式時。
- 對於需要完整試算表計算引擎的公式，請先於外部計算，然後再將結果寫回圖表工作簿。

## **常見問題**

**`Formula` 與 `R1C1Formula` 有何不同？**

[Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/formula/) 儲存 A1 風格的表達式，例如 `B2-C2`。[R1C1Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/r1c1formula/) 儲存 R1C1 風格的表達式，例如 `RC[-2]-RC[-1]`。使用最符合您產生或複製公式方式的記號。

**計算後我需要讀取儲存格本身還是其值？**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/getcell/) 會回傳 `IChartDataCell`。在重新計算後，讀取該儲存格的[Value](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/value/)屬性即可取得計算結果。

**什麼時候應該呼叫 `CalculateFormulas`？**

在變更輸入值或公式後、在依賴計算結果之前，呼叫[CalculateFormulas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。這會更新內建評估器支援的公式值。

**Aspose.Slides 支援所有 Excel 函式嗎？**

否。內建評估器只支援文件中列出的子集。未列於子集的函式不應假設能正確重新計算。如需完整的 Excel 公式相容性，請使用適當的試算表引擎進行計算，然後將最終值寫入圖表工作簿。

**如果載入的簡報包含不支援的公式會發生什麼？**

如果圖表資料未變更，工作簿仍可能保有先前計算的快取值。相關資料變更後，該快取值可能不再有效。存取無法處理的公式之儲存格可能拋出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

**公式錯誤值與 .NET 例外相同嗎？**

不相同。`#DIV/0!` 等結果是有效計算產生的試算表值。像 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) 這類例外表示公式無法正常處理。

**當公式儲存格變更時圖表會自動更新嗎？**

圖表系列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或呈現簡報。如果圖表資料點參考計算後的儲存格，圖表將使用更新後的值；此工作流程不需要額外的圖表刷新方法。

**圖表可以使用外部 Excel 工作簿嗎？**

可以，圖表資料可透過圖表資料 API 設定使用外部工作簿。然而，本文描述的公式計算工作流程僅涉及圖表資料工作簿以及 Aspose.Slides 評估的公式子集。不要假設 [CalculateFormulas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 能完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**

Excel 風格的參照可能存在於圖表工作簿中，但公式評估受限於支援的解析器與函式集。如果跨工作表或外部參照為關鍵，請先在目標 Aspose.Slides 版本中驗證該公式。如需廣泛的 Excel 參照相容性，請在外部計算工作簿，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例在指派表達式時，如 `B2-C2` 或 `SUM(B2:B5)`，皆未加前置 `=`。使用此形式可使產生的公式與文件中的 API 範例保持一致。