---
title: 在 C++ 投影片中套用圖表工作表公式
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
description: "在 Aspose.Slides 的 C++ 圖表工作表中套用 Excel 風格公式，並自動化 PPT 及 PPTX 檔案的報表。"
---
## **概觀**

圖表工作表是投影片中圖表的資料來源。它儲存類別與系列名稱以及圖表顯示的數值。在 Aspose.Slides 中，這個工作表可透過圖表資料工作簿取得，讓您可以以程式方式操作圖表資料。

本文章說明如何在圖表資料中使用工作表公式，使儲存格的值能自動計算與更新，而不必手動輸入。內容包括如何指派公式、使用 A1 及 R1C1 兩種參照方式、重新計算工作簿公式，以及在投影片圖表工作表中可使用的常數、運算子、儲存格參照與內建函式。

## **關於投影片中的圖表試算表公式**
**圖表試算表**（或圖表工作表）是圖表的資料來源。圖表試算表包含資料，這些資料會以圖形方式呈現在圖表上。當您在 PowerPoint 中建立圖表時，系統會自動建立與圖表關聯的試算表。圖表工作表會為所有圖表類型建立：折線圖、長條圖、日暈圖、餅圖等。要在 PowerPoint 中檢視圖表試算表，只要對圖表雙擊：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

圖表試算表包含圖表元素的名稱（類別名稱：*Category1*、系列名稱）以及對應這些類別與系列的數值表格。預設情況下，建立新圖表時，圖表試算表資料會設定為預設資料。之後您可以手動變更工作表中的資料。

通常，圖表會呈現複雜資料（例如財務分析師、科學分析師），其中的儲存格會根據其他儲存格或動態資料計算得出。若手動計算儲存格值並硬編碼於儲存格中，未來要變更時會相當困難。若變更某個儲存格的值，所有依賴該儲存格的儲存格也必須同步更新。此外，表格資料可能會依賴其他表格的資料，形成需要以簡便彈性方式更新的複雜投影片資料結構。

**圖表試算表公式** 是用於自動計算與更新圖表試算表資料的表達式。公式定義某個儲存格或一組儲存格的資料計算邏輯。它可以是數學公式或邏輯公式，使用：儲存格參照、數學函式、邏輯運算子、算術運算子、轉換函式、字串常數等。公式的定義寫入儲存格，該儲存格不會只包含單純值，而是計算後的結果會回傳並賦值給儲存格。投影片中的圖表試算表公式實質上與 Excel 公式相同，支援相同的預設函式、運算子與常數。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/cpp/) 中，圖表試算表由 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法（屬於 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_workbook) 類型）表示。  
公式可透過  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法指派與變更。  
Aspose.Slides 支援的公式功能包括：

- 邏輯常數
- 數值常數
- 字串常數
- 錯誤常數
- 算術運算子
- 比較運算子
- A1 風格儲存格參照
- R1C1 風格儲存格參照
- 內建函式

通常，試算表會儲存最後計算出的公式值。若在投影片載入後圖表資料未變更，**IChartDataCell.get_Value()** 方法會回傳這些值。若試算表資料已變更，讀取 **ChartDataCell.get_Value()** 時會拋出 **CellUnsupportedDataException**，因為無法保證未能正確解析的公式的儲存格值的正確性。

## **將圖表試算表公式加入投影片**
首先，使用 [IShapeCollection::AddChart()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) 在新投影片的第一張投影片上新增圖表。圖表的工作表會自動建立，並可透過  
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法存取：

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

使用 **Object** 類型的  
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 方法寫入儲存格值，意味著您可以傳入任何型別的值：

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

現在若要寫入公式至儲存格，可使用  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法：

*注意*：[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法用於設定 A1 風格的儲存格參照。

若要設定 R1C1 風格的公式參照，可使用  
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) 方法：

接著若讀取 B2 與 C2 儲存格的值，將會自動計算：

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **邏輯常數**
您可以在儲存格公式中使用 *FALSE* 與 *TRUE* 這類邏輯常數：

## **數值常數**
可使用一般或科學記號的數字建立圖表試算表公式：

## **字串常數**
字串（或文字）常數是以原樣使用且不會變動的特定值。字串常數可以是日期、文字、數字等：

## **錯誤常數**
當公式無法計算出結果時，儲存格會顯示錯誤代碼而非數值。每種錯誤都有對應代碼：

- #DIV/0! - 公式嘗試除以零。
- #GETTING_DATA - 儲存格的值仍在計算中時會顯示此錯誤。
- #N/A - 資訊缺失或不存在。可能原因包括：公式使用的儲存格為空、包含多餘空格、拼寫錯誤等。
- #NAME? - 無法依名稱找到某個儲存格或其他公式物件。
- #NULL! - 公式中出現錯誤的分隔符號，例如使用「,」或空格取代冒號「:」。
- #NUM! - 公式中的數值無效、過大或過小等。
- #REF! - 無效的儲存格參照。
- #VALUE! - 資料類型不符合預期。例如，將字串值放入數值儲存格。

## **算術運算子**
您可以在圖表工作表公式中使用所有算術運算子：

|**運算子**|**意義**|**範例**|
| :- | :- | :- |
|+（加號）|加法或一元正號|2 + 3|
|-（減號）|減法或否定|2 - 3<br>-3|
|*（星號）|乘法|2 * 3|
|/（斜線）|除法|2 / 3|
|%（百分號）|百分比|30%|
|^（脫字符）|次方|2 ^ 3|

*注意*：若需變更運算次序，請使用括號將欲先計算的部分括起來。

## **比較運算子**
您可以使用比較運算子比較儲存格的值。使用這些運算子比較兩個值時，結果會是 *TRUE* 或 *FALSE*：

|**運算子**|**意義**|**說明**|
| :- | :- | :- |
|=（等號）|等於|A2 = 3|
|<>（不等號）|不等於|A2 <> 3|
|>（大於號）|大於|A2 > 3|
|>=（大於等於號）|大於或等於|A2 >= 3|
|<（小於號）|小於|A2 < 3|
|<=（小於等於號）|小於或等於|A2 <= 3|

## **A1 風格儲存格參照**
**A1 風格儲存格參照** 用於欄位以字母標示（如 "*A*"），列以數字標示（如 "*1*"）的工作表。A1 風格儲存格參照的使用方式如下：

|**儲存格參照**|**範例**|**絕對**|**相對**|**混合**|
| :- | :- | :- | :- | :- |
|||絕對|相對|混合|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下範例說明如何在公式中使用 A1 風格儲存格參照：

## **R1C1 風格儲存格參照**
**R1C1 風格儲存格參照** 用於欄列皆以數字標示的工作表。R1C1 風格儲存格參照的使用方式如下：

|**儲存格參照**|**範例**|**絕對**|**相對**|**混合**|
| :- | :- | :- | :- | :- |
|||絕對|相對|混合|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下範例說明如何在公式中使用 R1C1 風格儲存格參照：

## **內建函式**
以下為可在公式中使用的內建函式，以簡化實作。這些函式封裝了最常用的操作，例如：

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

## **常見問題集 (FAQ)**

**是否支援將外部 Excel 檔案作為含公式圖表的資料來源？**

是的。Aspose.Slides 支援將外部活頁簿作為[圖表的資料來源](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdatasourcetype/)，讓您能使用投影片之外的 XLSX 檔案中的公式。

**圖表公式能否以工作表名稱引用同一本活頁簿內的工作表？**

可以。公式遵循標準 Excel 參照模型，您可以引用同一本活頁簿或外部活頁簿中的其他工作表。對於外部參照，請使用 Excel 語法加入路徑與活頁簿名稱。