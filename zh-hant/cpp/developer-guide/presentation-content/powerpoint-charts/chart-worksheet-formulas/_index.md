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
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 的圖表工作表中套用 Excel 風格公式，並自動化 PPT 與 PPTX 檔案的報告。"
---
## **概述**

圖表工作表是簡報中圖表背後的資料來源。它儲存類別與系列名稱，以及圖表顯示的數值。在 Aspose.Slides 中，這個工作表可透過圖表資料工作簿取得，讓您以程式方式操作圖表資料。

本文章說明如何在圖表資料中使用工作表公式，使儲存格值能自動計算與更新，而不必手動輸入。內容包括指派公式、使用 A1 以及 R1C1 兩種參照方式、重新計算工作簿公式，並說明在簡報圖表工作表中支援的常數、運算子、儲存格參照與預定義函式。

## **關於簡報中的圖表試算表公式**
簡報中的 **圖表試算表**（或圖表工作表）是圖表的資料來源。圖表試算表包含資料，這些資料會以圖形方式呈現在圖表上。當您在 PowerPoint 中建立圖表時，系統會自動為該圖表建立對應的工作表。所有圖表類型皆會建立工作表：折線圖、長條圖、旭日圖、圓餅圖等。要在 PowerPoint 中查看圖表試算表，只需雙擊圖表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應於這些類別與系列的數值資料表。預設情況下，建立新圖表時，圖表試算表資料會以預設資料填入。之後您可以手動在工作表中變更資料。

通常，圖表會呈現複雜資料（例如財務分析、科學分析），其儲存格可能需要根據其它儲存格或動態資料計算得出。若手動計算儲存格值並硬寫入，日後變更將變得困難。若變更某個儲存格的值，所有依賴該儲存格的儲存格也必須同步更新。此外，表格資料可能依賴其他表格的資料，形成需要以簡易彈性方式更新的複雜簡報資料結構。

簡報中的 **圖表試算表公式** 是用來自動計算與更新圖表試算表資料的表達式。公式定義了某個儲存格或一組儲存格的資料計算邏輯。圖表試算表公式可以是數學公式或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，而該儲存格本身不包含單純的值。公式計算後的結果會回傳並賦值給儲存格。簡報中的圖表試算表公式與 Excel 公式相同，且支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/cpp/) 中，圖表試算表由 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法的
[**IChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_workbook) 類型表示。  
可以使用  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法指派或變更公式。  
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

通常，試算表會儲存上一次計算的公式結果。若簡報載入後圖表資料未變更，**IChartDataCell.get_Value()** 會回傳這些值。若試算表資料已變更，讀取 **ChartDataCell.get_Value()** 時會拋出 **CellUnsupportedDataException**，因為無法保證未解析公式的儲存格值的正確性。

## **將圖表試算表公式加入簡報**
首先，使用 [IShapeCollection::AddChart()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) 在新簡報的第一張投影片加入圖表。圖表的工作表會自動建立，並可透過 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法存取：

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

接著使用 **Object** 類型的  
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 方法寫入儲存格值，您可以傳入任何型別的值：

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

要在儲存格寫入公式，請使用  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法：

*注意*：此方法用於設定 A1 風格的儲存格參照。

若要設定 R1C1 風格的公式參照，可使用  
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) 方法：

然後讀取 B2 與 C2 儲存格的值時，會自動計算出結果：

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 這類邏輯常數：

## **數值常數**
數字可使用一般或科學記號表示法建立圖表試算表公式：

## **字串常數**
字串（或文字）常數是固定不變的值，例如日期、文字、數字等：

## **錯誤常數**
當公式無法計算出結果時，會在儲存格中顯示錯誤代碼。每種錯誤都有對應的代碼：

- #DIV/0! - 公式嘗試除以零。
- #GETTING_DATA - 儲存格的值仍在計算中。
- #N/A - 資訊缺失或不可用。可能原因包括：公式使用的儲存格為空、存在多餘空格、拼寫錯誤等。
- #NAME? - 找不到某個儲存格或公式物件的名稱。
- #NULL! - 公式中有錯誤的語法，例如使用了「,」或空格取代冒號 (:)。
- #NUM! - 公式中的數值無效、過長或過小等。
- #REF! - 無效的儲存格參照。
- #VALUE! - 值類型不符合預期，例如將字串賦予數值儲存格。

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**含義**|**範例**|
| :- | :- | :- |
|+ (加號)|加法或單元正號|2 + 3|
|- (減號)|減法或負號|2 - 3<br>-3|
|* (星號)|乘法|2 * 3|
|/ (斜線)|除法|2 / 3|
|% (百分號)|百分比|30%|
|^ (插入符號)|次方|2 ^ 3|

*注意*：若需變更計算順序，請將優先計算的部分加上括號。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較時，結果會是 *TRUE* 或 *FALSE* 的邏輯值：

|**運算子**|**含義**|**範例**|
| :- | :- | :- |
|= (等於)|相等|A2 = 3|
|<> (不等於)|不相等|A2 <> 3|
|> (大於)|大於|A2 > 3|
|>= (大於等於)|大於等於|A2 >= 3|
|< (小於)|小於|A2 < 3|
|<= (小於等於)|小於等於|A2 <= 3|

## **A1 風格儲存格參照**
**A1 風格儲存格參照** 適用於欄位以字母標示（如 "*A*"），列以數字標示（如 "*1*"）的工作表。A1 風格參照可依下表使用：

|**儲存格參照**|**範例**| | |
| :- | :- | :- | :- |
| |**絕對**|**相對**|**混合**|
|儲存格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|列|$2:$2|2:2| - |
|欄|$A:$A|A:A| - |
|範圍|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下為在公式中使用 A1 風格儲存格參照的範例：

## **R1C1 風格儲存格參照**
**R1C1 風格儲存格參照** 適用於列與欄皆以數字標示的工作表。R1C1 風格參照可依下表使用：

|**儲存格參照**|**範例**| | |
| :- | :- | :- | :- |
| |**絕對**|**相對**|**混合**|
|儲存格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|列|R2|R[2]| - |
|欄|C3|C[3]| - |
|範圍|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下為在公式中使用 R1C1 風格儲存格參照的範例：

## **預定義函式**
以下是可在公式中使用的預定義函式，可簡化實作。這些函式封裝了最常用的運算，例如：

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

**是否支援將外部 Excel 檔案作為含公式圖表的資料來源？**

是。Aspose.Slides 支援外部工作簿作為[圖表的資料來源](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdatasourcetype/)，讓您使用簡報外部的 XLSX 公式。

**圖表公式是否能以工作表名稱引用同一工作簿內的工作表？**

是。公式遵循標準 Excel 參照模型，您可以引用同一工作簿內或外部工作簿的其他工作表。若為外部參照，請使用 Excel 語法加入路徑與工作簿名稱。