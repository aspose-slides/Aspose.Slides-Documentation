---
title: 在 Android 簡報中套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/androidjava/chart-worksheet-formulas/
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
- A1 樣式
- R1C1 樣式
- 預定義函式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 透過 Java 圖表工作表套用 Excel 樣式公式，並自動化 PPT 與 PPTX 檔案的報告。"
---
## **概觀**

圖表工作表是簡報中圖表背後的資料來源。它儲存類別與系列名稱以及圖表所顯示的數值。在 Aspose.Slides 中，這個工作表可透過圖表資料活頁簿取得，讓您以程式方式操作圖表資料。

本文章說明如何在圖表資料中使用工作表公式，讓儲存格值可自動計算與更新，而不必手動輸入。內容包括指派公式、使用 A1 及 R1C1 兩種參照樣式、重新計算活頁簿公式，以及在簡報圖表工作表中支援的常數、運算子、儲存格參照與預定義函式的使用方式。

## **關於簡報中的圖表試算表公式**
**圖表試算表**（或圖表工作表）是圖表的資料來源。圖表試算表包含資料，這些資料以圖形方式呈現在圖表上。當您在 PowerPoint 中建立圖表時，系統會自動建立與之對應的工作表。圖表工作表會為所有圖表類型建立：折線圖、長條圖、環形圖、圓餅圖等。若要在 PowerPoint 中檢視圖表試算表，請雙擊圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應於這些類別與系列的數值資料表。預設情況下，建立新圖表時，圖表試算表會填入預設資料，然後您可以手動變更工作表中的資料。

通常，圖表會呈現複雜的資料（例如財務分析、科學分析），其中的儲存格會依其他儲存格或動態資料計算得出。若手動計算儲存格值並硬編碼於儲存格中，未來變更將變得困難。若變更某個儲存格的值，所有依賴於它的儲存格也必須同步更新。此外，表格資料可能會依賴於其他表格的資料，形成需要以簡便且彈性方式更新的複雜簡報資料結構。

**圖表試算表公式** 在簡報中是一種自動計算與更新圖表試算表資料的表達式。公式定義了特定儲存格或一組儲存格的資料計算邏輯。圖表試算表公式可以是數學公式或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，該儲存格不再只包含簡單值。公式會計算出值並回傳，然後將值指派給儲存格。簡報中的圖表試算表公式實際上與 Excel 公式相同，支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/androidjava/) 中，圖表試算表由
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法表示，屬於
[**IChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataWorkbook) 類型。可使用
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法指派或變更公式。Aspose.Slides 支援公式的以下功能：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 參照樣式
- R1C1 參照樣式
- 預定義函式

通常，試算表會儲存最後計算出的公式值。若在簡報載入後圖表資料未被變更，呼叫 [**IChartDataCell.getValue**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#getValue--) 方法會回傳這些值。然而，若試算表資料已變更，讀取 **ChartDataCell.Value** 屬性時會拋出 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CellUnsupportedDataException)，因為不支援的公式導致無法保證儲存格值的正確性。這是因為只有成功解析的公式才能確定儲存格相依關係與最後值的正確性。

## **在簡報中加入圖表試算表公式**
首先，使用
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-)
在新簡報的第一張投影片上加入圖表。圖表的工作表會自動建立，並可透過
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法存取：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ……
} finally {
    if (pres != null) pres.dispose();
}
```

接著使用
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 屬性（屬於 **Object** 型別）寫入儲存格值，這表示您可以為該屬性設定任何型別的值：

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

現在若要在儲存格中寫入公式，可使用
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法：

*注意*：[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法用於設定 A1 參照樣式的儲存格。

若要設定
[R1C1Formula](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) 參照，可使用
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) 方法：

之後若讀取 B2 與 C2 儲存格的值，將會自動計算：

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 這兩個邏輯常數：

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 該值包含布林值 "false"
```

## **數值常數**
可以使用一般或科學記號的數字來建立圖表試算表公式：

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **字串常數**
字串（或文字）常數是指直接使用且不會變動的特定值。字串常數可能是日期、文字、數字等：

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **錯誤常數**
有時公式無法計算出結果，這時儲存格會顯示錯誤代碼而非值。每種錯誤都有對應的代碼：

- #DIV/0! – 公式嘗試除以零。
- #GETTING_DATA – 當儲存格的值仍在計算中時可能顯示此訊息。
- #N/A – 資訊缺失或不可用。可能原因包括：公式中使用的儲存格為空、出現多餘空格、拼寫錯誤等。
- #NAME? – 找不到某個儲存格或其他公式物件的名稱。
- #NULL! – 公式中出現錯誤的語法，例如使用「,」或空格取代冒號「:」。
- #NUM! – 公式中的數字無效、過長或過短等。
- #REF! – 無效的儲存格參照。
- #VALUE! – 值類型不符合預期，例如將字串值放入數值儲存格。

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 該值包含字串 "#DIV/0!"
```

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**說明**|**範例**|
| :- | :- | :- |
|+ (plus sign)|加法或正號|2 + 3|
|- (minus sign)|減法或負號|2 - 3<br>-3|
|* (asterisk)|乘法|2 * 3|
|/ (forward slash)|除法|2 / 3|
|% (percent sign)|百分比|30%|
|^ (caret)|次方|2 ^ 3|

*注意*：若要變更計算順序，請在欲先計算的部分加上括號。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較兩個值時，結果會是 *TRUE* 或 *FALSE*：

|**運算子**|**說明**|**說明**|
| :- | :- | :- |
|= (equal sign)|等於|A2 = 3|
|<> (not equal sign)|不等於|A2 <> 3|
|> (greater than sign)|大於|A2 > 3|
|>= (greater than or equal to sign)|大於或等於|A2 >= 3|
|< (less than sign)|小於|A2 < 3|
|<= (less than or equal to sign)|小於或等於|A2 <= 3|

## **A1 參照樣式**
**A1 參照樣式** 用於欄位以字母表示（如 "*A*"）且列以數字表示（如 "*1*"）的工作表。A1 參照可以下列方式使用：

|**儲存格參照**|**範例**| | |
| :- | :- | :- | :- |
| |**絕對**|**相對**|**混合**|
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2|-|
|欄|$A:$A|A:A|-|
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下範例示範如何在公式中使用 A1 參照樣式：

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1 參照樣式**
**R1C1 參照樣式** 用於列與欄皆以數字表示的工作表。R1C1 參照可以下列方式使用：

|**儲存格參照**|**範例**| | |
| :- | :- | :- | :- |
| |**絕對**|**相對**|**混合**|
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]|-|
|欄|C3|C[3]|-|
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下範例示範如何在公式中使用 R1C1 參照樣式：

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **預定義函式**
以下是可在公式中使用的預定義函式，以簡化實作。這些函式封裝了最常用的操作，例如：

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

## **常見問答**

**是否支援將外部 Excel 檔案作為含公式圖表的資料來源？**

是的。Aspose.Slides 支援將外部活頁簿作為[圖表的資料來源](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdatasourcetype/)，讓您可以使用簡報外的 XLSX 檔案中的公式。

**圖表公式能否以工作表名稱引用同一本活頁簿內的工作表？**

可以。公式遵循標準 Excel 參照模型，您可以引用同一活頁簿內的其他工作表或外部活頁簿。對於外部參照，請使用 Excel 語法加入路徑與活頁簿名稱。