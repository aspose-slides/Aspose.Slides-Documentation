---
title: 在簡報中使用 Java 套用圖表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh-hant/java/chart-worksheet-formulas/
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
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 的圖表工作表中套用 Excel 風格公式，並自動化 PPT 與 PPTX 檔案的報表。"
---
## **概觀**

圖表工作表是簡報中圖表背後的資料來源。它儲存類別和系列名稱以及圖表顯示的數值。在 Aspose.Slides 中，此工作表可透過圖表資料活頁簿取得，讓您以程式方式處理圖表資料。

本文說明如何在圖表資料中使用工作表公式，使儲存格的值能自動計算與更新，而不是手動輸入。內容包括如何指派公式、使用 A1 以及 R1C1 兩種參照方式、重新計算活頁簿公式，以及在簡報圖表工作表中可使用的常數、運算子、儲存格參照與預定義函式。

## **關於簡報中的圖表試算表公式**
簡報中的 **圖表試算表**（或稱圖表工作表）是圖表的資料來源。圖表試算表包含資料，這些資料以圖形方式呈現在圖表上。當您在 PowerPoint 中建立圖表時，系統會自動建立與之關聯的工作表。圖表工作表會為所有圖表類型建立：折線圖、長條圖、日晷圖、圓餅圖等。若要在 PowerPoint 中檢視圖表試算表，請雙擊圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應於這些類別與系列的數值表格。預設情況下，建立新圖表時，圖表試算表資料會以預設資料設定。之後您可以手動變更工作表中的資料。

通常，圖表會呈現複雜資料（例如財務分析師、科學分析師），其中的儲存格會根據其他儲存格或動態資料計算得出。若手動計算儲存格值並硬編碼在儲存格內，未來要變更時會變得困難。若您變更某個儲存格的值，所有依賴該儲存格的儲存格也必須同步更新。而且，表格資料可能依賴其他表格資料，形成需要以簡易且彈性方式更新的複雜簡報資料結構。

**圖表試算表公式** 是用於自動計算與更新圖表試算表資料的表達式。公式定義了特定儲存格或一組儲存格的資料計算邏輯。圖表試算表公式可以是數學公式或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，該儲存格本身不會只含單純值；公式會計算出結果並回傳，然後將結果賦值給儲存格。簡報中的圖表試算表公式實際上與 Excel 公式相同，支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/java/) 中，圖表試算表以
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法在
[**IChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataWorkbook) 類型中表示。  
公式可透過
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法指派與變更。  
Aspose.Slides 支援的公式功能包括：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格儲存格參照
- R1C1 風格儲存格參照
- 預定義函式


通常，試算表會儲存最後計算出的公式值。若在簡報載入後圖表資料未變更，則
[**IChartDataCell.getValue**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#getValue--) 方法會在讀取時回傳這些值。但若試算表資料已變更，在讀取 **ChartDataCell.Value** 屬性時會拋出
[**CellUnsupportedDataException**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/CellUnsupportedDataException) 例外，因為不支援的公式無法正確解析。這是因為當公式成功解析時，系統會確定儲存格之間的相依關係，並驗證最後值的正確性；若公式無法解析，則無法保證儲存格值的正確性。

## **將圖表試算表公式加入簡報**
首先，使用
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) 在新簡報的第一張投影片加入圖表。圖表的工作表會自動建立，且可透過
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法存取：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

接著使用
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 屬性（**Object** 型別）寫入儲存格值，這表示您可以將任何型別的值指派給該屬性：

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

現在要在儲存格寫入公式，可使用
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法：

*注意*： [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法用於設定 A1 風格的儲存格參照。

若要設定
[R1C1Formula](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) 參照，可使用
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) 方法：

然後若讀取 B2 與 C2 儲存格的值，將會自動計算：

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 之類的邏輯常數：

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 該值包含布林值 "false"
```

## **數值常數**
可使用一般或科學記號的數字建立圖表試算表公式：

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **字串常數**
字串（或文字）常數是指直接使用且不會變更的特定值。字串常數可以是：日期、文字、數字等：

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **錯誤常數**
有時公式無法計算出結果，此時會在儲存格顯示錯誤代碼而非值。每種錯誤都有對應的代碼：

- #DIV/0! - 公式嘗試除以零。
- #GETTING_DATA - 當儲存格的值尚在計算中時可能出現。
- #N/A - 資訊缺失或不可用。可能原因包括：公式中使用的儲存格為空、含有多餘空格、拼寫錯誤等。
- #NAME? - 找不到某個儲存格或其他公式物件的名稱。
- #NULL! - 公式中出現錯誤的語法，例如使用逗號 (,) 或空白取代冒號 (:)。
- #NUM! - 公式中的數值無效、過長或過短等。
- #REF! - 無效的儲存格參照。
- #VALUE! - 資料類型不符，例如將字串值指派給數值儲存格。

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 該值包含字串 "#DIV/0!"
```

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**說明**|**範例**|
| :- | :- | :- |
|+ (加號)|加法或一元正號|2 + 3|
|- (減號)|減法或否定|2 - 3<br>-3|
|* (星號)|乘法|2 * 3|
|/ (斜線)|除法|2 / 3|
|% (百分號)|百分比|30%|
|^ (插入符號)|指數|2 ^ 3|

*注意*：若要變更運算順序，請將需優先計算的部分置於括號內。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較兩個值時，結果會是 *TRUE* 或 FALSE 的邏輯值：

|**運算子**|**說明**|**說明**|
| :- | :- | :- |
|= (等號)|等於|A2 = 3|
|<> (不等號)|不等於|A2 <> 3|
|> (大於號)|大於|A2 > 3|
|>= (大於等於號)|大於等於|A2 >= 3|
|< (小於號)|小於|A2 < 3|
|<= (小於等於號)|小於等於|A2 <= 3|

## **A1 風格儲存格參照**
**A1 風格儲存格參照** 用於欄位以字母標示（例如 "*A*"）且列以數字標示（例如 "*1*"）的工作表。A1 風格參照的使用方式如下：

|**儲存格參照**|**範例**|||
| :- | :- | :- | :- |
||絕對|相對|混合|
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2|-|
|欄|$A:$A|A:A|-|
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下範例示範如何在公式中使用 A1 風格儲存格參照：

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1 風格儲存格參照**
**R1C1 風格儲存格參照** 用於欄列皆以數字標示的工作表。R1C1 風格參照的使用方式如下：

|**儲存格參照**|**範例**|||
| :- | :- | :- | :- |
||絕對|相對|混合|
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]|-|
|欄|C3|C[3]|-|
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


以下範例示範如何在公式中使用 R1C1 風格儲存格參照：

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **預定義函式**
以下是可於公式中使用以簡化實作的預定義函式，這些函式封裝了最常用的運算，例如：

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

**是否支援外部 Excel 檔案作為具有公式的圖表資料來源？**

是。Aspose.Slides 支援將外部活頁簿作為 [chart's data source](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdatasourcetype/)，讓您使用簡報之外的 XLSX 內的公式。

**圖表公式能否透過工作表名稱參照同一本活頁簿內的其他工作表？**

可以。公式遵循標準 Excel 參照模型，您可以參照同一本活頁簿或外部活頁簿中的其他工作表。對於外部參照，請使用 Excel 語法加入路徑與活頁簿名稱。