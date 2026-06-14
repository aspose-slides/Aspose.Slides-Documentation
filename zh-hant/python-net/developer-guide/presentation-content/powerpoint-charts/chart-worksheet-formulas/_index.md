---
title: "在簡報中使用 Python 套用圖表工作表公式"
linktitle: "工作表公式"
type: docs
weight: 70
url: /zh-hant/python-net/chart-worksheet-formulas/
keywords:
- "圖表試算表"
- "圖表工作表"
- "圖表公式"
- "工作表公式"
- "試算表公式"
- "資料來源"
- "邏輯常數"
- "數值常數"
- "字串常數"
- "錯誤常數"
- "算術常數"
- "比較運算子"
- "A1 樣式"
- "R1C1 樣式"
- "預定義函式"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Python"
- "Aspose.Slides"
description: "在 Aspose.Slides for Python 中透過 .NET 圖表工作表套用 Excel 風格的公式，並自動化 PPT、PPTX 與 ODP 檔案的報告。"
---
## **概述**

圖表工作表是簡報中圖表背後的資料來源。它儲存類別名稱與系列名稱，以及圖表所顯示的數值。於 Aspose.Slides 中，透過 chart data workbook 可取得此工作表，讓您以程式方式操作圖表資料。

本文說明如何在圖表資料中使用工作表公式，使儲存格值能自動計算與更新，而非手動輸入。內容包括指派公式、使用 A1 及 R1C1 參照樣式、重新計算工作簿公式，以及在簡報圖表工作表中支援的常數、運算子、儲存格參照與內建函式的使用方式。

## **關於簡報中的圖表試算表公式**
**圖表試算表**（或圖表工作表）是圖表的資料來源。圖表試算表包含資料，這些資料會以圖形方式呈現在圖表上。當您在 PowerPoint 中建立圖表時，系統會自動建立與該圖表關聯的工作表。圖表工作表會為所有圖表類型建立：折線圖、長條圖、環形圖、圓餅圖等。要在 PowerPoint 中檢視圖表試算表，請雙擊圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應這些類別與系列的數值資料表。預設情況下，建立新圖表時，圖表試算表資料會以預設資料填入。之後您可以手動變更工作表中的資料。

通常，圖表會呈現複雜資料（例如財務分析、科學分析），其中儲存格的值是由其他儲存格或動態資料計算而得。若手動計算並硬編碼儲存格值，未來若要變更將相當困難。當您變更某個儲存格的值時，所有依賴於該儲存格的儲存格也必須同步更新。此外，表格資料可能依賴其他表格的資料，形成需要彈性且容易更新的簡報資料結構。

**圖表試算表公式**是用來自動計算與更新圖表試算表資料的表達式。公式定義某個或一組儲存格的資料計算邏輯。公式可以是數學或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，而該儲存格不含單純值。公式會計算出結果並回傳，然後將結果指派給儲存格。簡報中的圖表試算表公式實際上與 Excel 公式相同，支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/python-net/) 中，圖表試算表以 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdata/) 屬性呈現，屬於 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdataworkbook/) 類型。  
公式可以透過 
[**formula**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/) 屬性指派與變更。  
在 Aspose.Slides 中支援的公式功能包括：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 參照樣式
- R1C1 參照樣式
- 內建函式

通常，試算表會儲存最後計算出的公式值。若在簡報載入後圖表資料未變更，**IChartDataCell.Value** 屬性會回傳這些值。但若試算表資料已變更，讀取 **ChartDataCell.Value** 屬性時會拋出 **CellUnsupportedDataException**，因為無法保證未支援公式的儲存格值正確性。這是因為成功解析公式時會確定儲存格相依關係與最後值的正確性；若公式無法解析，則無法保證儲存格值的正確性。

## **將圖表試算表公式加入簡報**
首先，使用 [add_chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapecollection/) 在新簡報的第一張投影片中加入一個帶有範例資料的圖表。圖表的工作表會自動建立，並可透過 
[**chart_data_workbook**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdata/) 屬性存取：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

接著，使用 **Object** 型別的 
[**value**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/) 屬性寫入儲存格值，意味著您可以對該屬性設定任意值：

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

現在要在儲存格寫入公式，可使用 
[**formula**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/) 屬性：

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*注意*：[**IChartDataCell.Formula**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/) 屬性用於設定 A1 參照樣式的儲存格。

若要設定 
[r1c1_formula](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/) 參照，可使用 [**r1c1_formula**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichartdatacell/) 屬性：

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

然後呼叫 [**calculate_formulas**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/) 方法，以計算工作簿內所有公式並更新相應儲存格的值：

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 這類邏輯常數：

## **數值常數**
數字可以使用常規或科學記號表示，以建立圖表試算表公式：

## **字串常數**
字串（或文字）常數是指直接使用且不會變動的特定值。字串常數可能是日期、文字、數字等：

## **錯誤常數**
有時公式無法計算出結果，這時會在儲存格中顯示錯誤代碼而非值。每種錯誤都有特定代碼：

- #DIV/0! ‑ 公式嘗試除以零。
- #GETTING_DATA ‑ 可能在儲存格仍在計算時顯示。
- #N/A ‑ 資訊缺失或不可用。可能原因包括：公式使用的儲存格為空、存在多餘的空格字元、拼寫錯誤等。
- #NAME? ‑ 找不到某個儲存格或其他公式物件的名稱。
- #NULL! ‑ 公式中出現錯誤的逗號或使用空格取代冒號 (:) 時可能出現。
- #NUM! ‑ 公式中的數值無效、過長或過小等。
- #REF! ‑ 無效的儲存格參照。
- #VALUE! ‑ 不符合預期的值類型，例如將字串值設定到數值儲存格。

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**說明**|**範例**|
| :- | :- | :- |
|+（加號）|加法或一元正號|2 + 3|
|-（減號）|減法或取負|2 - 3<br>-3|
|*（星號）|乘法|2 * 3|
|/（斜線）|除法|2 / 3|
|%（百分號）|百分比|30%|
|^（脫字符）|指數|2 ^ 3|

*注意*：如需改變計算順序，請使用括號將需先計算的部分括起來。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較兩個值時，結果為布林值 *TRUE* 或 *FALSE*：

|**運算子**|**說明**|**範例**|
| :- | :- | :- |
|=（等號）|等於|A2 = 3|
|<>（不等號）|不等於|A2 <> 3|
|>（大於號）|大於|A2 > 3|
|>=（大於等於號）|大於或等於|A2 >= 3|
|<（小於號）|小於|A2 < 3|
|<=（小於等於號）|小於或等於|A2 <= 3|

## **A1 參照樣式**
**A1 參照樣式**用於列以字母標識（例如 "*A*"）而行以數字標識（例如 "*1*"）的工作表。A1 參照樣式可如下使用：

|**儲存格參照**|**範例**| | |
| :- | :- | :- | :- |
| |絕對參照|相對參照|混合參照|
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2| - |
|欄|$A:$A|A:A| - |
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下為在公式中使用 A1 參照樣式的範例：

## **R1C1 參照樣式**
**R1C1 參照樣式**用於列與欄皆以數字標識的工作表。R1C1 參照樣式可如下使用：

|**儲存格參照**|**範例**| | |
| :- | :- | :- | :- |
| |絕對參照|相對參照|混合參照|
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]| - |
|欄|C3|C[3]| - |
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下為在公式中使用 R1C1 參照樣式的範例：

## **預定義函式**
以下是可在公式中使用的預定義函式，以簡化實作。這些函式封裝了最常用的操作，例如：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE（1900 日期系統）
- DAYS
- FIND
- FINDB
- IF
- INDEX（參照形式）
- LOOKUP（向量形式）
- MATCH（向量形式）
- MAX
- SUM
- VLOOKUP

## **常見問題**

**是否支援將外部 Excel 檔案作為帶有公式的圖表資料來源？**

是的。Aspose.Slides 支援將外部工作簿作為 [圖表資料來源](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatasourcetype/)，讓您可使用簡報外的 XLSX 中的公式。

**圖表公式能否透過工作表名稱引用同一工作簿中的其他工作表？**

可以。公式遵循標準 Excel 參照模型，您可以引用同一工作簿或外部工作簿中的其他工作表。對於外部參照，請使用 Excel 語法加入路徑與工作簿名稱。