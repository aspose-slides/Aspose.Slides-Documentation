---
title: 在 C++ 中格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/cpp/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式化
- 圖表實體
- 圖表屬性
- 圖表設定
- 圖表選項
- 字型屬性
- 圓角邊框
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解在 Aspose.Slides for C++ 中的圖表格式化，並以專業且引人注目的樣式提升您的 PowerPoint 簡報。"
---
## **概觀**

本文說明如何在 PowerPoint 簡報中使用 Aspose.Slides 來格式化圖表。它展示了如何自訂圖表的關鍵元素，如座標軸、格線、標題、圖例、繪圖區域及牆面填色，以提升圖表資料的外觀與可讀性。它還示範了如何設定圖表文字的字型屬性、套用預設與自訂的數值格式到圖表資料，並啟用圖表區域的圓角。透過這些範例，可了解如何同時控制簡報中圖表的視覺樣式與資料呈現方式。

## **格式化圖表實體**
Aspose.Slides for C++ 讓開發人員可以從頭在投影片中新增自訂圖表。本文說明如何格式化不同的圖表實體，包括圖表類別軸與數值軸。

Aspose.Slides for C++ 提供簡易的 API 以管理不同的圖表實體，並使用自訂值進行格式設定：

1. 建立 **Presentation** 類別的實例。
1. 依索引取得投影片的參考。
1. 加入一個帶有預設資料的圖表，並選擇任意所需類型（本例使用 ChartType.LineWithMarkers）。
1. 存取圖表的數值軸，並設定以下屬性：
   1. 設定 數值軸主要格線的 **Line format**
   1. 設定 數值軸次要格線的 **Line format**
   1. 設定 數值軸的 **Number Format**
   1. 設定 數值軸的 **Min, Max, Major and Minor units**
   1. 設定 數值軸資料的 **Text Properties**
   1. 設定 數值軸的 **Title**
   1. 設定 數值軸的 **Line Format**
1. 存取圖表的類別軸，並設定以下屬性：
   1. 設定 類別軸主要格線的 **Line format**
   1. 設定 類別軸次要格線的 **Line format**
   1. 設定 類別軸資料的 **Text Properties**
   1. 設定 類別軸的 **Title**
   1. 設定 類別軸的 **Label Positioning**
   1. 設定 類別軸標籤的 **Rotation Angle**
1. 存取圖表圖例，並為其設定 **Text Properties**
1. 設定顯示圖表圖例且不與圖表重疊
1. 存取圖表的 **Secondary Value Axis**，並設定以下屬性：
   1. 啟用次要 **Value Axis**
   1. 設定 次要數值軸的 **Line Format**
   1. 設定 次要數值軸的 **Number Format**
   1. 設定 次要數值軸的 **Min, Max, Major and Minor units**
1. 現在在次要數值軸上繪製第一個圖表系列
1. 將圖表背面牆設為填色
1. 設定圖表繪圖區域的填色
1. 將修改後的簡報寫入 PPTX 檔案

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **為圖表設定字型屬性**
Aspose.Slides for C++ 提供設定圖表字型相關屬性的支援。請依照以下步驟為圖表設定字型屬性。

- 實例化 Presentation 類別的物件。
- 在投影片上加入圖表。
- 設定字型高度。
- 儲存修改後的簡報。

以下提供範例程式碼。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **為圖表資料表設定字型屬性**
Aspose.Slides for C++ 提供變更系列中類別顏色的支援。

1. 實例化 Presentation 類別的物件。
1. 在投影片上加入圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存修改後的簡報。

以下提供範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **設定圖表區域圓角邊框**
Aspose.Slides for C++ 提供設定圖表區域的支援。已在 Aspose.Slides 中加入 **IChart.HasRoundedCorners** 與 **Chart.HasRoundedCorners** 屬性。

1. 實例化 Presentation 類別的物件。
1. 在投影片上加入圖表。
1. 設定圖表的填充類型與填充顏色
1. 將圓角屬性設為 True。
1. 儲存修改後的簡報。

以下提供範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **設定數值格式**
Aspose.Slides for C++ 提供簡易的 API 以管理圖表資料格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 加入一個帶有預設資料的圖表，並選擇任意所需類型（本例使用 **ChartType.ClusteredColumn**）。
1. 從可能的預設值中設定預設數字格式。
1. 遍歷每個圖表系列中的圖表資料儲存格，並設定圖表資料的數字格式。
1. 儲存簡報。
1. 設定自訂數字格式。
1. 遍歷每個圖表系列中的圖表資料儲存格，設定不同的圖表資料數字格式。
1. 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**以下列出可使用的預設數值格式值及其索引：**|
| :- | :- |
|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**我可以為柱狀/區域設定半透明填色，同時保持邊框不透明嗎？**

可以。填色的透明度與輪廓是分別設定的。這在密集的可視化圖表中有助於提升格線與資料的可讀性。

**當資料標籤重疊時，我該如何處理？**

減小字型大小、停用非必要的標籤組件（例如類別）、設定標籤的偏移/位置、必要時僅顯示選取點的標籤，或將格式切換為「值 + 圖例」。

**我可以對系列套用漸層或圖案填色嗎？**

可以。通常同時支援純色與漸層/圖案填色。實務上請節制使用漸層，並避免與格線和文字形成對比度低的組合。