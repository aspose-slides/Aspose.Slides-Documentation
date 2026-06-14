---
title: 在簡報中使用 PHP 套用圖表工作表公式
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP 中透過 Java 圖表工作表套用 Excel 風格公式，並自動化 PPT 與 PPTX 檔案的報表。"
---
## **概述**

圖表工作表是簡報中圖表的資料來源。它儲存類別與系列名稱以及圖表顯示的數值。在 Aspose.Slides 中，這個工作表可透過圖表資料工作簿取得，讓您以程式方式處理圖表資料。

本文說明如何在圖表資料中使用工作表公式，使儲存格值能自動計算與更新，而不必手動輸入。內容包括指派公式、使用 A1 風格與 R1C1 風格參照、重新計算工作簿公式，以及在簡報中的圖表工作表可使用的常數、運算子、儲存格參照與預定義函式。

## **關於簡報中的圖表試算表公式**
**圖表試算表**（或圖表工作表）在簡報中是圖表的資料來源。圖表試算表包含資料，這些資料會以圖形方式顯示在圖表上。當您在 PowerPoint 中建立圖表時，會自動建立與該圖表關聯的工作表。圖表工作表會為所有圖表類型建立：折線圖、長條圖、旭日圖、圓餅圖等。要在 PowerPoint 中看到圖表試算表，只需雙擊圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應於這些類別與系列的數值資料表。預設情況下，建立新圖表時，圖表試算表資料會以預設資料填入。之後您可以手動變更試算表資料。

通常圖表會呈現複雜資料（例如財務分析師、科學分析師），其中的儲存格是由其他儲存格的值或其他動態資料計算而得。若手動計算儲存格值並硬編碼，未來變更將變得困難。若變更某個儲存格的值，所有依賴它的儲存格都必須同時更新。此外，表格資料可能依賴其他表格的資料，形成複雜的簡報資料結構，需要以簡易且彈性的方式更新。

**圖表試算表公式** 在簡報中是一個自動計算與更新圖表試算表資料的表達式。公式為特定儲存格或儲存格集合定義資料計算邏輯。公式可能是數學或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，該儲存格不再僅含單一值。公式計算出結果並回傳，然後將結果指派給儲存格。簡報中的圖表試算表公式實際上與 Excel 公式相同，支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/php-java/) 中，圖表試算表由
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 方法表示於
[**ChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/) 型別。
可使用
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 方法指派與變更試算表公式。Aspose.Slides 支援的公式功能包括：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格儲存格參照
- R1C1 風格儲存格參照
- 預定義函式


通常試算表會儲存最後計算的公式值。若簡報載入後圖表資料未變更，則 [**ChartDataCell::getValue**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#getValue) 會回傳這些值。但若試算表資料已變更，在讀取值時會拋出 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/CellUnsupportedDataException) 以表示公式不支援。這是因為當公式成功解析時，會確定儲存格之間的相依性並驗證最後值的正確性；若公式無法解析，則無法保證儲存格值的正確性。

## **在簡報中新增圖表試算表公式**
首先，使用 [ShapeCollection::addChart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addChart) 在新簡報的第一張投影片上新增圖表。圖表的工作表會自動建立，可透過
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 方法存取：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

讓我們使用 **Object** 型別的 [**ChartDataCell::setValue**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setValue) 方法在儲存格寫入一些值，這表示您可以設定任何值：

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

現在要在儲存格寫入公式，可使用
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 方法。

*註*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setFormula) 方法用於設定 A1 風格儲存格參照。

若要以 R1C1 風格設定公式，可使用 [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 方法。

接著若讀取儲存格 B2 與 C2 的值，會自動計算：

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 等邏輯常數：

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// 該值包含布林 "false"
```

## **數值常數**
可使用一般或科學記號的數字建立圖表試算表公式：

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **字串常數**
字串（或文字）常數是指直接使用且不會變動的特定值。字串常數可能是：日期、文字、數字等：

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **錯誤常數**
有時公式無法計算出結果，這時會在儲存格中顯示錯誤代碼而非值。每種錯誤都有特定代碼：

- #DIV/0! - 公式嘗試除以零。
- #GETTING_DATA - 可能在儲存格仍在計算時顯示。
- #N/A - 資訊遺失或不可用。原因可能包括：公式中使用的儲存格為空、額外的空白字元、拼寫錯誤等。
- #NAME? - 無法依名稱找到某個儲存格或其他公式物件。
- #NULL! - 公式中出現錯誤，例如使用 (,) 或以空格取代冒號 (:)。
- #NUM! - 公式中的數值無效、過長或過短等。
- #REF! - 無效的儲存格參照。
- #VALUE! - 值類型不符合預期，例如將字串值放入數值儲存格。

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// 該值包含字串 "#DIV/0!"


```

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**說明**|**範例**|
| :- | :- | :- |
|+ (plus sign)|加法或單項正號|2 + 3|
|- (minus sign)|減法或負號|2 - 3<br>-3|
|* (asterisk)|乘法|2 * 3|
|/ (forward slash)|除法|2 / 3|
|% (percent sign)|百分比|30%|
|^ (caret)|次方|2 ^ 3|

*註*: 若要變更計算順序，請將欲先計算的部分以括號括起。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較兩個值時，結果會是 *TRUE* 或 *FALSE* 的邏輯值：

|**運算子**|**說明**|**說明**|
| :- | :- | :- |
|= (equal sign)|等於|A2 = 3|
|<> (not equal sign)|不等於|A2 <> 3|
|> (greater than sign)|大於|A2 > 3|
|>= (greater than or equal to sign)|大於或等於|A2 >= 3|
|< (less than sign)|小於|A2 < 3|
|<= (less than or equal to sign)|小於或等於|A2 <= 3|

## **A1 風格儲存格參照**
**A1 風格儲存格參照** 用於欄位以字母識別（例如 "*A*"）且列以數字識別（例如 "*1*"）的工作表。A1 風格儲存格參照的使用方式如下：

|**儲存格參照**|**範例**|||
| :- | :- | :- | :- |
||**絕對**|**相對**|**混合**|
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2|-|
|欄|$A:$A|A:A|-|
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


以下範例示範如何在公式中使用 A1 風格儲存格參照：

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **R1C1 風格儲存格參照**
**R1C1 風格儲存格參照** 用於欄列皆以數字識別的工作表。R1C1 風格儲存格參照的使用方式如下：

|**儲存格參照**|**範例**|||
| :- | :- | :- | :- |
||**絕對**|**相對**|**混合**|
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]|-|
|欄|C3|C[3]|-|
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


以下範例示範如何在公式中使用 R1C1 風格儲存格參照：

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **預定義函式**
以下是可在公式中使用的預定義函式，可簡化實作。這些函式封裝了最常用的操作，例如：

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

**外部 Excel 檔案是否支援作為包含公式的圖表資料來源？**

是。Aspose.Slides 支援外部工作簿作為[圖表的資料來源](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatasourcetype/)，讓您可以使用簡報外部的 XLSX 公式。

**圖表公式是否可以透過工作表名稱參照同一工作簿內的工作表？**

是。公式遵循標準的 Excel 參照模型，您可以參照同一工作簿或外部工作簿中的其他工作表。對於外部參照，請使用 Excel 語法包含路徑和工作簿名稱。