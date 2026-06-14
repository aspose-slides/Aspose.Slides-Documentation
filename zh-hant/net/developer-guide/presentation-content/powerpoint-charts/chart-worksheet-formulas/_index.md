---
title: 在 .NET 中於簡報套用圖表工作表公式
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
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 的圖表工作表中套用 Excel 風格公式，並自動化 PPT 與 PPTX 檔案的報告。"
---
## **概觀**

圖表工作表是簡報中圖表背後的資料來源。它儲存類別與系列名稱以及圖表顯示的數值。在 Aspose.Slides 中，這個工作表可透過圖表資料工作簿取得，讓您以程式方式操作圖表資料。

本文說明如何在圖表資料中使用工作表公式，使儲存格值能自動計算與更新，而不必手動輸入。內容包括指派公式、使用 A1 以及 R1C1 兩種參照樣式、重新計算工作簿公式，以及在簡報圖表工作表中可使用的常數、運算子、儲存格參照與預定義函式。

## **關於簡報中的圖表試算表公式**
簡報中的**圖表試算表**（或圖表工作表）是圖表的資料來源。圖表試算表包含資料，這些資料以圖形方式在圖表上呈現。當您在 PowerPoint 中建立圖表時，系統會自動建立與之關聯的工作表。圖表工作表會為所有圖表類型建立：折線圖、長條圖、環形圖、圓餅圖等。若要在 PowerPoint 中檢視圖表試算表，只需雙擊圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應於這些類別與系列的數值表格。預設情況下，建立新圖表時，圖表試算表資料會以預設資料填入。之後您可以手動變更工作表中的資料。

通常，圖表會呈現複雜的資料（例如財務分析、科學分析），其中的儲存格可能根據其他儲存格或動態資料計算得出。若手動計算儲存格值並硬編碼進儲存格，未來要變更時會非常困難。若更改某個儲存格的值，所有依賴於它的儲存格也必須更新。此外，表格資料可能會依賴其他表格的資料，形成需要以簡單且彈性方式更新的複雜簡報資料結構。

簡報中的**圖表試算表公式**是一種自動計算與更新圖表試算表資料的表達式。試算表公式定義某個儲存格或一組儲存格的資料計算邏輯。試算表公式可以是數學公式或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，而該儲存格本身不會直接包含簡單值。試算表公式計算出結果並回傳，然後將該值指派給儲存格。簡報中的圖表試算表公式實質上與 Excel 公式相同，支援相同的預設函式、運算子與常數。

在[**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/net/) 中，圖表試算表以  
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) 屬性表示，屬於  
[**IChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook) 類型。  
可透過[**IChartDataCell.Formula**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/properties/formula) 屬性指派與變更公式。Aspose.Slides 支援以下公式功能：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 樣式儲存格參照
- R1C1 樣式儲存格參照
- 預定義函式

通常，試算表會儲存最後計算出的公式值。若在簡報載入後圖表資料未變更，**IChartDataCell.Value** 屬性會在讀取時返回這些值。但若試算表資料已變更，讀取 **ChartDataCell.Value** 屬性時會拋出 **CellUnsupportedDataException**，因為不支援的公式無法正確解析。這是因為只有成功解析的公式才會確定儲存格相依性與最後值的正確性；若公式無法解析，則無法保證儲存格值的正確性。

## **將圖表試算表公式加入簡報**
首先，使用 [IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/addchart/methods/1) 在新簡報的第一張投影片加入一個帶有範例資料的圖表。圖表的工作表會自動建立，並可透過  
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) 屬性存取：

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```

接著使用 **Object** 型別的 [**IChartDataCell.Value**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/properties/value) 屬性寫入儲存格值，這表示您可以將任意值指派給該屬性：

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

現在若要為儲存格寫入公式，可使用 [**IChartDataCell.Formula**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/properties/formula) 屬性：

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*註*：[**IChartDataCell.Formula**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/properties/formula) 屬性用於設定 A1 樣式的儲存格參照。

若要設定 [R1C1Formula](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) 參照，可使用 [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) 屬性：

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

然後呼叫 [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) 方法以計算工作簿中的所有公式，並更新相應儲存格的值：

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 等邏輯常數：

## **數值常數**
數字可以使用普通或科學記號表示，以建立圖表試算表公式：

## **字串常數**
字串（或文字）常數是指不會改變、直接使用的特定值。字串常數可能是日期、文字、數字等：

## **錯誤常數**
有時公式無法計算出結果，這時會在儲存格中顯示錯誤代碼而非值。每種錯誤都有特定代碼：

- #DIV/0! – 公式嘗試除以零。
- #GETTING_DATA – 可能出現在儲存格上，表示其值仍在計算中。
- #N/A – 資訊缺失或不可用。可能原因：公式中使用的儲存格為空、存在多餘的空格、拼寫錯誤等。
- #NAME? – 無法依名稱找到某個儲存格或其他公式物件。
- #NULL! – 公式中可能出現錯誤，例如使用了 (,) 或將空格取代冒號 (:)。
- #NUM! – 公式中的數值無效、過長或過小等。
- #REF! – 無效的儲存格參照。
- #VALUE! – 型別不符，例如將字串值設定於數值儲存格。

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**意義**|**範例**|
| :- | :- | :- |
|+ (加號)|加法或一元正號|2 + 3|
|- (減號)|減法或相反數|2 - 3<br>-3|
|* (星號)|乘法|2 * 3|
|/ (斜線)|除法|2 / 3|
|% (百分號)|百分比|30%|
|^ (插入符號)|指數|2 ^ 3|

*註*：若要變更計算順序，請將優先計算的部分以括號括起來。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較兩個值時，結果為邏輯值 *TRUE* 或 *FALSE*：

|**運算子**|**意義**|**範例**|
| :- | :- | :- |
|= (等號)|等於|A2 = 3|
|<> (不等號)|不等於|A2 <> 3|
|> (大於號)|大於|A2 > 3|
|>= (大於等於號)|大於或等於|A2 >= 3|
|< (小於號)|小於|A2 < 3|
|<= (小於等於號)|小於或等於|A2 <= 3|

## **A1 樣式儲存格參照**
**A1 樣式儲存格參照** 用於欄位以字母標識（例如 "*A*"）且列以數字標識（例如 "*1*"）的工作表。A1 樣式儲存格參照可如下使用：

|**儲存格參照**|**絕對**|**相對**|**混合**|
| :- | :- | :- | :- |
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2|-|
|欄|$A:$A|A:A|-|
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下範例示範如何在公式中使用 A1 樣式儲存格參照：

## **R1C1 樣式儲存格參照**
**R1C1 樣式儲存格參照** 用於行與列皆以數字標識的工作表。R1C1 樣式儲存格參照可如下使用：

|**儲存格參照**|**絕對**|**相對**|**混合**|
| :- | :- | :- | :- |
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]|-|
|欄|C3|C[3]|-|
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下範例示範如何在公式中使用 R1C1 樣式儲存格參照：

## **預定義函式**
以下是可在公式中使用的預定義函式，能簡化實作。這些函式封裝了最常用的運算，例如：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 日期系統)
- DAYS
- FIND
- FINDB
- IF
- INDEX (參照形式)
- LOOKUP (向量形式)
- MATCH (向量形式)
- MAX
- SUM
- VLOOKUP

## **常見問題**

**是否支援將外部 Excel 檔案作為包含公式的圖表資料來源？**

是。Aspose.Slides 支援外部工作簿作為[圖表的資料來源](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdatasourcetype/)，讓您能使用簡報外的 XLSX 檔案中的公式。

**圖表公式是否能以工作表名稱引用同一本工作簿內的其他工作表？**

是。公式遵循標準 Excel 參照模型，您可以引用同一本工作簿或外部工作簿內的其他工作表。對於外部參照，請使用 Excel 語法加入路徑與工作簿名稱。