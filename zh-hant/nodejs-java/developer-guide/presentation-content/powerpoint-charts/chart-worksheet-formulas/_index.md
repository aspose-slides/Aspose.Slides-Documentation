---
title: 在投影片中使用 JavaScript 套用圖表工作表公式
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
- 資料來源
- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術常數
- 比較運算子
- A1 風格
- R1C1 風格
- 預定義函式
- PowerPoint
- 投影片
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中透過 Java 圖表工作表套用 Excel 風格公式，並以 JavaScript 自動化產生 PPT 與 PPTX 檔案的報告。"
---
## **概觀**

圖表工作表是投影片中圖表背後的資料來源。它儲存類別和系列名稱以及圖表顯示的數值。 在 Aspose.Slides 中，此工作表可透過圖表資料工作簿取得，讓您以程式方式操作圖表資料。

本文說明如何在圖表資料中使用工作表公式，使儲存格值能自動計算與更新，而不需手動輸入。它展示了如何指定公式、使用 A1 以及 R1C1 兩種引用樣式、重新計算工作簿公式，並處理圖表工作表在投影片中支援的常數、運算子、儲存格引用與預定義函式。

## **關於投影片中的圖表試算表公式**

投影片中的 **Chart spreadsheet**（或稱 chart worksheet）是圖表的資料來源。Chart spreadsheet 包含資料，這些資料會以圖形方式呈現在圖表上。當您在 PowerPoint 中建立圖表時，與該圖表相關聯的工作表也會自動建立。Chart worksheet 會為所有類型的圖表建立：折線圖、長條圖、日暈圖、圓餅圖等。若要在 PowerPoint 中查看 chart spreadsheet，請雙擊該圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet 包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應這些類別與系列的數值資料表。預設情況下，建立新圖表時，chart spreadsheet 的資料會以預設資料設定。之後您可以手動在工作表中變更試算表資料。

通常，圖表會呈現複雜資料（例如金融分析師、科學分析師），其中的儲存格是根據其他儲存格的值或其他動態資料計算得出。若手動計算儲存格值並硬編碼於儲存格中，未來變更會變得困難。若您變更某個儲存格的值，所有依賴於該儲存格的儲存格也需要更新。此外，表格資料可能依賴於其他表格的資料，形成複雜的投影片資料架構，需要以簡易且彈性的方式更新。

投影片中的 **Chart spreadsheet formula** 是用來自動計算與更新圖表試算表資料的表達式。試算表公式定義了特定儲存格或一組儲存格的資料計算邏輯。試算表公式可以是數學公式或邏輯公式，使用：儲存格引用、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格內，而該儲存格不會只包含單純的值。試算表公式計算出值並回傳，然後將此值指派給儲存格。投影片中的 chart spreadsheet 公式實際上與 Excel 公式相同，且支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/nodejs-java/) 中，chart spreadsheet 以 [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) 方法所屬的 [**ChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook) 型別表示。可透過 [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 方法指派與變更試算表公式。Aspose.Slides 在公式方面支援以下功能：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格儲存格參照
- R1C1 風格儲存格參照
- 預定義函式

一般而言，試算表會儲存最後計算的公式值。若在載入投影片後圖表資料未變更，則 [**ChartDataCell.getValue**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#getValue--) 方法在讀取時會回傳這些值。但若試算表資料已變更，在讀取 **ChartDataCell.Value** 屬性時會拋出 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CellUnsupportedDataException)，因為該公式不受支援。這是因為當公式成功解析時，會確定儲存格相依性並驗證最後值的正確性；若公式無法解析，則無法保證儲存格值的正確性。

## **將圖表試算表公式新增至投影片**

首先，使用 [ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-) 方法在新投影片的第一張投影片上新增圖表。圖表的工作表會自動建立，且可透過 [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) 方法存取：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

讓我們使用 **Object** 類型的 [**ChartDataCell.setValue**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) 屬性在儲存格中寫入一些值，這表示您可以為該屬性設定任意值：

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

現在要在儲存格寫入公式，您可以使用 [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 方法：

*注意*： [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 方法用於設定 A1 風格的儲存格參照。

若要設定 [R1C1Formula](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) 儲存格參照，可使用 [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) 方法：

接著若讀取儲存格 B2 與 C2 的值，它們將被計算：

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **邏輯常數**

您可以在儲存格公式中使用像 *FALSE* 與 *TRUE* 這樣的邏輯常數：

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// 該值包含布林值 "false"
```

## **數值常數**

可使用一般或科學記號的數字來建立圖表試算表公式：

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **字串常數**

字串（或文字）常數是一種直接使用且不會變動的特定值。字串常數可以是：日期、文字、數字等：

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **錯誤常數**

有時候公式無法計算出結果。此時，儲存格會顯示錯誤代碼而非值。每種錯誤都有特定的代碼：

- #DIV/0! - 公式嘗試除以零。
- #GETTING_DATA - 可能在儲存格上顯示，表示其值仍在計算中。
- #N/A - 資訊缺失或不可用。可能原因包含：公式中使用的儲存格為空、額外的空格字元、拼寫錯誤等。
- #NAME? - 無法依名稱找到某個儲存格或其他公式物件。
- #NULL! - 當公式有錯誤時可能出現，例如使用 (,) 或以空格字元取代冒號 (:)。
- #NUM! - 公式中的數值可能無效、過長或過小等。
- #REF! - 無效的儲存格參照。
- #VALUE! - 不符合預期的值類型。例如，將字串值設定到數值儲存格。

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// 該值包含字串 "#DIV/0!"
```

## **算術運算子**

您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**意義**|**範例**|
| :- | :- | :- |
|+ (加號)|加法或單元正號|2 + 3|
|- (減號)|減法或負號|2 - 3<br>-3|
|* (星號)|乘法|2 * 3|
|/ (斜線)|除法|2 / 3|
|% (百分號)|百分比|30%|
|^ (插入符號)|次方|2 ^ 3|

*注意*：若要變更運算順序，請將欲先計算的公式部分加上括號。

## **比較運算子**

您可以使用比較運算子比較儲存格的值。當使用這些運算子比較兩個值時，結果會是邏輯值 *TRUE* 或 FALSE：

|**運算子**|**說明**|**範例**|
| :- | :- | :- |
|= (等於號)|等於|A2 = 3|
|<> (不等於號)|不等於|A2 <> 3|
|> (大於號)|大於|A2 > 3|
|>= (大於等於號)|大於等於|A2 >= 3|
|< (小於號)|小於|A2 < 3|
|<= (小於等於號)|小於等於|A2 <= 3|

## **A1 風格儲存格參照**

**A1 風格儲存格參照** 用於工作表中，欄位以字母標識（例如 "*A*"），列則以數字標識（例如 "*1*"）。A1 風格儲存格參照可如下使用：

|**儲存格參照**|**範例**|||
| :- | :- | :- | :- |
||**絕對**|**相對**|**混合**|
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2|-|
|欄|$A:$A|A:A|-|
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下範例示範如何在公式中使用 A1 風格儲存格參照：

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1 風格儲存格參照**

**R1C1 風格儲存格參照** 用於工作表中，列與欄皆以數字標識。R1C1 風格儲存格參照可如下使用：

|**儲存格參照**|**範例**|||
| :- | :- | :- | :- |
||**絕對**|**相對**|**混合**|
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]|-|
|欄|C3|C[3]|-|
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下範例示範如何在公式中使用 R1C1 風格儲存格參照：

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **預定義函式**

有預定義函式可在公式中使用，以簡化實作。這些函式封裝了最常用的操作，例如：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **常見問題**

**是否支援將外部 Excel 檔案作為帶公式的圖表資料來源？**

是的。Aspose.Slides 支援將外部工作簿作為[圖表的資料來源](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatasourcetype/)，讓您在投影片外的 XLSX 中使用公式。

**圖表公式是否可以透過工作表名稱引用同一工作簿內的工作表？**

是的。公式遵循標準的 Excel 參照模型，您可以引用同一工作簿內或外部工作簿的其他工作表。對於外部參照，請使用 Excel 語法包含路徑與工作簿名稱。