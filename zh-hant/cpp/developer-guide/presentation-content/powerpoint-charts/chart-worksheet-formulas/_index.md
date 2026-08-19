---
title: 在簡報中使用 C++ 套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/cpp/chart-worksheet-formulas/
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
- 預定義函式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 的圖表工作表中套用 Excel 風格公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概述**

PowerPoint 圖表通常將其來源資料儲存在內嵌工作表中。在 Aspose.Slides for C++ 中，您可以透過圖表資料工作簿存取該工作表，寫入輸入值，將公式指派給儲存格，計算支援的公式，並使用計算後的儲存格作為圖表資料。

本文說明完整的公式工作流程：建立圖表、填充其工作表、指派 A1 風格或 R1C1 風格的公式、重新計算、讀取計算值、將這些儲存格連結到圖表系列，最後儲存簡報。亦說明支援的公式語法、內建函式子集、快取值、未支援的公式以及試算表特有的錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、系列名稱與數值。在 PowerPoint 中，您可以透過開啟圖表資料編輯器來檢視工作表：

![PowerPoint 圖表開啟其內嵌工作表，顯示類別與系列資料](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/) 介面公開。使用 [IChartDataCell::set_Formula](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_formula/) 以 A1 風格公式，或使用 [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) 以 R1C1 風格公式。變更輸入儲存格或公式後，呼叫 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 以重新計算支援的公式並更新相對應的儲存格值。

計算過的儲存格仍可透過 [IChartDataCell::get_Value](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/get_value/) 取得其結果。當需要在程式碼中檢查公式結果或將儲存格作為圖表資料點使用時，這一點很重要。

## **建立圖表並計算工作表公式**

以下範例示範端對端工作流程。它建立一個群組柱狀圖，清除範例資料，寫入每季營收與支出值，使用公式計算利潤，讀取結果，將計算過的儲存格作為圖表值，最後儲存簡報。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

圖表資料點參考 `D2:D4`，因此圖表使用計算後的利潤值。在此工作流程中不需要額外的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 記號使用字母表示欄，數字表示列。透過 [IChartDataCell::set_Formula](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_formula/) 指派 A1 風格表達式。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

常見的 A1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`、`$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`、`$A2:C$4` |

相對參照在公式被移動或複製時會變化。絕對參照會將兩個座標皆固定，混合參照則僅固定列或欄之一。

## **使用 R1C1 風格公式**

R1C1 記號以數字同時識別列與欄。相對參照使用方括號內的偏移量。透過 [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) 指派此語法。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

常見的 R1C1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`、`R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`、`R[2]C3:R5C[7]` |

例如，在儲存格 `D2` 中，`RC[-2]` 代表同一列向左兩欄的儲存格（即 `B2`）。

## **公式常數與運算子**

內建公式評估器支援布林值、數字常值、字串、試算表錯誤值、算術運算子以及比較運算子。

### **常數與文字值**

| 類型 | 範例 | 備註 |
|---|---|---|
| 布林 | `TRUE`、`FALSE` | 可直接在布林運算式中使用，例如 `A2=TRUE`。 |
| 數字 | `1`、`0.5`、`.3`、`1E-2` | 支援一般與科學記號。 |
| 字串 | `"abc"`、`"2/3/2020 12:00"` | 文字常值須在公式內以雙引號包住。 |
| 錯誤結果 | `#DIV/0!`、`#N/A`、`#REF!` | 有效公式可評估為試算表錯誤值，而非正常結果。 |

以下範例使用了多種常數類型：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // 偽
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **算術運算子**

| 運算子 | 意義 | 範例 |
|---|---|---|
| `+` | 加法或單項正號 | `2+3` |
| `-` | 減法或取負 | `2-3`、`-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 次方 | `2^3` |

使用圓括號可明確指定運算順序，例如 `(A2+B2)*C2`。

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

## **支援的預先定義函式**

Aspose.Slides 為圖表工作表提供內建公式評估器，但它並非完整的 Excel 計算引擎。文件中列出的函式集僅限於下表所示的函式。不要假設任意 Excel 函式都能透過 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 重新計算。

| 函式 | 目的或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至指定倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合併文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合併文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 回傳兩個日期之間的天數 | `DAYS(B2,A2)` |
| `FIND` | 在文字中尋找子字串 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 求和 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查尋 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記錄，`LOOKUP` 與 `MATCH` 以向量形式記錄。`DATE` 使用 1900 日期系統。未列於此處的功能與函式應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **重新計算與快取值**

試算表檔案通常同時儲存公式與最後一次計算的結果。載入簡報且相關圖表資料未變更時，Aspose.Slides 可以從 [IChartDataCell::get_Value](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/get_value/) 讀取快取值。

變更輸入儲存格或公式後，請勿依賴舊的快取結果。應在讀取計算值或儲存依賴於計算值的圖表資料之前呼叫 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。

對於不在支援子集內的公式，Aspose.Slides 可能無法解析公式或確立其相依性。如果工作簿已被修改，先前的快取值將不再可靠。在此情況下，讀取具有未支援資料的儲存格可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

若您的圖表依賴於 Aspose.Slides 無法評估的 Excel 函式，請使用支援該函式的試算表引擎計算公式，然後將結果寫回圖表工作簿。不要以猜測值取代未支援的公式。

## **處理公式錯誤**

需區分兩種不同的問題類型。

公式本身可能有效，但會產生試算表錯誤結果，例如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!`。此時錯誤代碼是儲存格的結果，可透過 [IChartDataCell::get_Value](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/get_value/) 取得。

公式也可能在解析、參照、相依性或支援資料層面失敗。Aspose.Slides 為這些情況提供特定的例外類別：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/)、以及 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

當公式來自範本或使用者輸入時，請在重新計算與取值的程式碼區塊周圍捕捉這些例外：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // 處理無效的公式。
}
catch (CellInvalidReferenceException&)
{
    // 處理無效的儲存格參照。
}
catch (CellCircularReferenceException&)
{
    // 處理循環參照。
}
catch (CellUnsupportedDataException&)
{
    // 處理不支援的試算表資料。
}
```

## **實務限制**

圖表工作表中的公式支援僅針對一組已定義的試算表計算，並非完整的 Excel 相容性。設計報表工作流程時請考慮以下限制：

- 僅使用文件中列出的常數、運算子、參照與函式，才能讓 Aspose.Slides 正確重新計算公式。
- 在變更公式結果所依賴的儲存格後，必須重新計算。
- 將載入簡報時的快取值視為快照，而非編輯後的重新計算替代方案。
- 在依賴已計算值之前，先測試來自現有範本的公式，特別是使用了文件未列出的函式時。
- 若公式需要完整的試算表計算引擎，請在外部先行計算，然後將最終值寫回圖表工作簿。

## **常見問題集**

**`set_Formula` 與 `set_R1C1Formula` 有何不同？**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_formula/) 會儲存 A1 風格的表達式，例如 `B2-C2`。[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) 會儲存 R1C1 風格的表達式，例如 `RC[-2]-RC[-1]`。請使用最符合您產生或複製公式方式的記號。

**計算後應該讀取儲存格本身還是其值？**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) 會傳回 `IChartDataCell`。在重新計算之後，請透過該儲存格的 [IChartDataCell::get_Value](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/get_value/) 取得計算結果。

**什麼時候應該呼叫 `CalculateFormulas`？**

在變更輸入值或公式後，且在依賴計算結果之前，呼叫 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。這會更新內建評估器支援的公式值。

**Aspose.Slides 是否支援所有 Excel 函式？**

不會。內建評估器只支援文件中列出的子集。未列於子集的函式不應假設能正確重新計算。若需要完整的 Excel 公式相容性，請使用適當的試算表引擎完成計算，然後將最終值寫入圖表工作簿。

**如果載入的簡報包含未支援的公式會發生什麼？**

若圖表資料未變更，工作簿可能仍保留先前計算的快取值。相關資料變更後，該快取值可能不再有效。嘗試存取無法處理的公式儲存格時，可能會拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

**公式錯誤值與 C++ 例外是一樣的嗎？**

不是。`#DIV/0!` 等結果是由有效計算產生的試算表值。例外如 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) 表示公式無法正常處理。

**當公式儲存格變更時，圖表會自動更新嗎？**

圖表系列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或渲染簡報即可。若圖表資料點參考的是計算後的儲存格，圖表會使用更新後的值；此工作流程不需要額外的圖表重新整理方法。

**圖表可以使用外部的 Excel 工作簿嗎？**

可以，圖表資料可透過圖表資料 API 設定使用外部工作簿。但本文描述的公式計算工作流程僅適用於圖表資料工作簿以及 Aspose.Slides 評估的公式子集。不要假設 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 會完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**

圖表工作簿中可能出現 Excel 風格的跨表或跨檔案參照，但公式評估受限於支援的解析器與函式集。若跨表或外部參照是必要的，請先以目標 Aspose.Slides 版本驗證該公式。對於需要廣泛 Excel 參照相容性的工作流程，請在外部計算工作簿，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例會直接指派類似 `B2-C2` 或 `SUM(B2:B5)` 的表達式，而不加前置的 `=`。使用此形式可保持產生的公式與文件中示範的 API 範例一致。