---
title: 在簡報中使用 JavaScript 套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/nodejs-java/chart-worksheet-formulas/
keywords:
- 圖表試算表
- 圖表工作表
- 圖表公式
- 工作表公式
- 試算表公式
- 圖表資料工作簿
- 公式計算
- 首選文化
- 文化特定公式
- DBCS
- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格
- R1C1 風格
- 預定義函數
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js（透過 Java）圖表工作表中套用 Excel 風格的公式，重新計算數值，並在 PowerPoint 圖表中使用結果。"
---
## **概觀**

PowerPoint 圖表通常會將來源資料儲存在嵌入式工作表中。於 Aspose.Slides for Node.js via Java，您可以透過圖表資料工作簿存取該工作表、寫入輸入值、為儲存格指派公式、計算支援的公式，並將計算後的儲存格作為圖表資料使用。

本文說明完整的公式工作流程：建立圖表、填入工作表、指派 A1 風格或 R1C1 風格的公式、重新計算、讀取計算結果、將這些儲存格連接到圖表系列，最後儲存簡報。也會描述支援的公式語法、內建函數子集、快取值、未支援的公式以及試算表特定錯誤。

## **圖表工作表與公式**

圖表工作表包含圖表使用的類別、系列名稱與數值。在 PowerPoint 中，您可以透過開啟圖表資料編輯器來檢視工作表：

![PowerPoint 圖表與其嵌入工作表開啟的畫面，顯示類別與系列資料](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表透過 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/) 類別公開。使用 [ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) 來設定 A1 風格公式，使用 [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) 來設定 R1C1 風格公式。變更輸入儲存格或公式後，呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) 以重新計算支援的公式並更新相對應的儲存格值。

計算後的儲存格仍透過 [ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#getValue--) 暴露其結果。當您需要在程式碼中檢查公式結果或將儲存格作為圖表資料點時，這點相當重要。

## **建立圖表並計算工作表公式**

以下範例示範端對端工作流程。它建立叢集直條圖、清除範例資料、寫入季度營收與費用數值、以公式計算利潤、讀取結果、將計算後的儲存格作為圖表值，最後儲存簡報。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

圖表資料點參考 `D2:D4`，因此圖表使用計算出的利潤值。此工作流程中沒有額外的圖表重新整理呼叫：先重新計算工作簿，然後使用或儲存指向已計算儲存格的圖表資料。

## **使用 A1 風格公式**

A1 記號使用字母表示欄、數字表示列。透過 [ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) 指派 A1 風格表達式。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

常見的 A1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 列 | `2:2` | `$2:$2` | — |
| 欄 | `A:A` | `$A:$A` | — |
| 範圍 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相對參照在公式被移動或複製時會變動。絕對參照會固定兩個座標，混合參照則僅固定列或欄之一。

## **使用 R1C1 風格公式**

R1C1 記號以數字同時表示列與欄。相對參照使用方括號內的偏移量。透過 [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) 指派此語法。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

常見的 R1C1 參照形式如下：

| 參照 | 相對 | 絕對 | 混合 |
|---|---|---|---|
| 儲存格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 列 | `R[2]` | `R2` | — |
| 欄 | `C[3]` | `C3` | — |
| 範圍 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在儲存格 `D2` 中，`RC[-2]` 代表同列左移兩欄的儲存格 (`B2`)。

## **公式常數與運算子**

內建公式評估器支援布林值、數值常數、字串、試算表錯誤值、算術運算子與比較運算子。

### **常數與字面值**

| 類型 | 範例 | 註記 |
|---|---|---|
| 布林 | `TRUE`, `FALSE` | 可直接用於類似 `A2=TRUE` 的布林表達式。 |
| 數值 | `1`, `0.5`, `.3`, `1E-2` | 支援十進位與科學記號。 |
| 字串 | `"abc"`, `"2/3/2020 12:00"` | 文字常數須以雙引號包住於公式中。 |
| 錯誤結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式也可能評估為試算表錯誤值。 |

以下範例使用了多種常數類型：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **算術運算子**

| 運算子 | 意義 | 範例 |
|---|---|---|
| `+` | 加法或一元正號 | `2+3` |
| `-` | 減法或負號 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 指數 | `2^3` |

使用括號明確指定運算順序，例如 `(A2+B2)*C2`。

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

## **支援的內建函數**

Aspose.Slides 為圖表工作表提供內建公式評估器，但它並非完整的 Excel 計算引擎。以下列出文件中記載的函數子集。不要假設任意 Excel 函數都能由 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) 重新計算。

| 函數 | 目的或支援形式 | 範例 |
|---|---|---|
| `ABS` | 絕對值 | `ABS(A2)` |
| `AVERAGE` | 算術平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整至倍數 | `CEILING(A2,5)` |
| `CHOOSE` | 依索引選取值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合併文字值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合併文字值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系統建立日期值 | `DATE(2026,8,19)` |
| `DAYS` | 回傳兩日期之天數差 | `DAYS(B2,A2)` |
| `FIND` | 在字串中尋找文字 | `FIND("-",A2)` |
| `FINDB` | 以位元組為單位的文字搜尋 | `FINDB("a",A2)` |
| `IF` | 條件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 參照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 加總 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直搜尋 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表格中顯示的限制相當重要：`INDEX` 以參照形式記載，而 `LOOKUP` 與 `MATCH` 則以向量形式記載。`DATE` 使用 1900 日期系統。未列於此處的功能與函數應視為 Aspose.Slides 公式評估器不支援，除非另有文件說明。

## **以特定文化資訊計算公式**

某些工作簿函數會依文化資訊解讀文字，特別是針對使用雙位元組字元集 (DBCS) 語言的函數。若要正確計算此類公式，請建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)，使用 [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) 設定首選文化，透過 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) 套用，然後載入簡報。

以下範例選取日文文化，使用已配置的載入選項開啟簡報，並對每個圖表工作簿呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

首選文化是簡報載入設定的一部份，因此必須在建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例之前指定。使用與工作簿公式相符的文化，例如 `ja-JP` 用於需要遵循日文 DBCS 計算規則的公式。

## **重新計算與快取值**

試算表檔案通常會同時存放公式與其最後計算的值。Aspose.Slides 因此在載入簡報且相關圖表資料未被變更時，可從 [ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#getValue--) 讀取快取值。

變更輸入儲存格或公式後，切勿依賴舊的快取結果。於讀取計算值或儲存依賴於它們的圖表資料之前，先呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)。

對於不在支援子集內的公式，Aspose.Slides 可能無法解析或確定其相依性。若工作簿已被修改，先前的快取值將不再可靠。此時，讀取包含未支援資料的儲存格可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellunsupporteddataexception/)。

如果您的圖表依賴 Aspose.Slides 無法評估的 Excel 函數，請使用支援這些函數的試算表引擎先行計算，然後將結果寫回圖表工作簿。不要以猜測值取代未支援的公式。

## **處理公式錯誤**

需區分兩種不同的問題。

公式本身有效，但會產生試算表錯誤結果，例如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!` 或 `#VALUE!`。此時錯誤代號是儲存格結果，可透過 [ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#getValue--) 取得。

公式也可能在解析、參照、相依性或支援資料層面失敗。Aspose.Slides 為此提供試算表專屬例外：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellcircularreferenceexception/) 與 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellunsupporteddataexception/)。

當公式來自範本或使用者輸入時，請在重新計算與取得值的程式區塊捕捉例外。錯誤細節會說明底層的試算表問題：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **實務限制**

圖表工作表的公式支援旨在提供一組定義好的試算表計算子集，並非完整的 Excel 相容性。設計報表工作流程時請留意以下限制：

- 僅使用文件中列出的常數、運算子、參照與函數，以讓 Aspose.Slides 重新計算公式。
- 在變更公式結果所依賴的儲存格後，務必重新計算。
- 將載入簡報時的快取值視為快照，而非編輯後的重新計算替代方案。
- 在依賴既有範本的計算結果前，先測試其公式，特別是使用了文件未列出的函數時。
- 若公式需要完整的試算表計算引擎，請於外部先行計算，然後將結果寫回圖表工作簿。

## **常見問題集**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) 與 [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) 有什麼差異？**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) 會儲存類似 `B2-C2` 的 A1 風格表達式。[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) 則儲存類似 `RC[-2]-RC[-1]` 的 R1C1 風格表達式。請依照您產生或複製公式的方式選擇最合適的記號。

**計算後，我需要讀取儲存格本身還是它的值？**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) 會回傳一個 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/)。在重新計算之後，呼叫該儲存格的 [ChartDataCell.getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#getValue--) 方法即可取得計算結果。

**什麼時候應該呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)？**

在變更輸入值或公式後、在依賴計算結果之前，請呼叫 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)。這會更新內建評估器支援的公式值。

**Aspose.Slides 是否支援所有 Excel 函數？**

不支援。內建評估器僅支援文件中列出的子集。未列出的函數不能保證正確重新計算。若需求完整的 Excel 公式相容性，請使用適當的試算表引擎執行計算，然後將最終值寫入圖表工作簿。

**載入的簡報若包含未支援的公式會發生什麼情況？**

如果圖表資料未變更，工作簿可能仍保有先前計算的快取值。當相關資料被修改後，該快取值可能不再有效。存取無法處理的公式之儲存格時，可能拋出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellunsupporteddataexception/)。

**公式錯誤值與例外是相同的嗎？**

不是。`#DIV/0!` 之類的結果是有效計算產生的試算表值。例外，例如 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellcircularreferenceexception/)，表示公式無法正常處理。

**當公式儲存格變更時，圖表會自動更新嗎？**

圖表系列可以參照工作簿儲存格。先重新計算工作簿，然後儲存或呈現簡報。只要圖表資料點參考已計算的儲存格，圖表就會使用更新後的值；此工作流程不需要額外的圖表重新整理方法。

**圖表可以使用外部 Excel 工作簿嗎？**

可以，圖表資料可透過圖表資料 API 設定為使用外部工作簿。然而，本篇文章描述的公式計算工作流程僅針對圖表工作簿及 Aspose.Slides 所評估的公式子集。不要假設 [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) 能完整重新計算外部 XLSX 檔案中的任意公式。

**我可以使用參照其他工作表或工作簿的公式嗎？**

在圖表工作簿中可能存在 Excel 風格的跨工作表或跨檔案參照，但公式評估受限於支援的解析器與函數集合。若跨工作表或外部參照為必要，請先以目標 Aspose.Slides 版本驗證該公式。對於需要廣泛 Excel 參照相容性的工作流程，建議在外部先行計算，然後將解析後的值寫回圖表資料。

**公式字串需要以 `=` 開頭嗎？**

Aspose.Slides API 範例會直接指派 `B2-C2` 或 `SUM(B2:B5)` 等表達式，沒有前置的 `=`。使用此形式可使產生的公式與文件中的 API 範例保持一致。