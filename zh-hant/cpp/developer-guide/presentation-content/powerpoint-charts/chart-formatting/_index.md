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
description: "學習在 Aspose.Slides for C++ 中的圖表格式化，並以專業、吸睛的樣式提升您的 PowerPoint 簡報。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂圖表的關鍵元件，例如坐標軸、格線、標題、圖例、繪圖區域以及牆壁填色，以提升圖表資料的外觀與可讀性。

此外，還示範了如何設定圖表文字的字型屬性、對圖表資料套用預設或自訂的數字格式，並啟用圖表區域的圓角。這些範例共同說明了如何同時控制簡報中圖表的視覺樣式與資料呈現。

## **格式化圖表實體**
Aspose.Slides for C++ 讓開發人員能從頭建立自訂圖表。本文章說明如何格式化不同的圖表實體，包含圖表類別與數值坐標軸。

Aspose.Slides for C++ 提供簡易的 API 來管理各種圖表實體，並以自訂值進行格式化：

1. 建立 **Presentation** 類別的實例。  
2. 依索引取得投影片的參考。  
3. 加入圖表與預設資料，並使用任一想要的類型（本例使用 **ChartType.LineWithMarkers**）。  
4. 取得圖表的數值坐標軸，並設定以下屬性：  
   1. 為數值坐標軸主要格線設定 **Line format**  
   1. 為數值坐標軸次要格線設定 **Line format**  
   1. 為數值坐標軸設定 **Number Format**  
   1. 為數值坐標軸設定 **Min, Max, Major and Minor units**  
   1. 為數值坐標軸資料設定 **Text Properties**  
   1. 為數值坐標軸設定 **Title**  
   1. 為數值坐標軸設定 **Line Format**  
5. 取得圖表的類別坐標軸，並設定以下屬性：  
   1. 為類別坐標軸主要格線設定 **Line format**  
   1. 為類別坐標軸次要格線設定 **Line format**  
   1. 為類別坐標軸資料設定 **Text Properties**  
   1. 為類別坐標軸設定 **Title**  
   1. 為類別坐標軸設定 **Label Positioning**  
   1. 為類別坐標軸標籤設定 **Rotation Angle**  
6. 取得圖表的圖例，並為其設定 **Text Properties**  
7. 設定圖例顯示方式，使其不會與圖表重疊  
8. 取得圖表的 **Secondary Value Axis**，並設定以下屬性：  
   1. 啟用次要 **Value Axis**  
   1. 為次要數值坐標軸設定 **Line Format**  
   1. 為次要數值坐標軸設定 **Number Format**  
   1. 為次要數值坐標軸設定 **Min, Max, Major and Minor units**  
9. 在次要數值坐標軸上繪製第一條圖表系列  
10. 為圖表的背牆設定填色  
11. 為圖表的繪圖區域設定填色  
12. 將修改後的簡報寫入 PPTX 檔案  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **設定圖表字型屬性**
Aspose.Slides for C++ 提供設定圖表字型相關屬性的支援。請依下列步驟為圖表設定字型屬性。

- 建立 **Presentation** 類別的物件。  
- 在投影片上加入圖表。  
- 設定字型高度。  
- 儲存已修改的簡報。  

以下提供範例程式碼。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **設定圖表資料表的字型屬性**
Aspose.Slides for C++ 支援變更系列顏色中類別的顏色。

1. 建立 **Presentation** 類別的物件。  
1. 在投影片上加入圖表。  
1. 設定圖表資料表。  
1. 設定字型高度。  
1. 儲存已修改的簡報。  

以下提供範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **設定圖表區域的圓角邊框**
Aspose.Slides for C++ 支援設定圖表區域。已在 Aspose.Slides 中加入 **IChart.HasRoundedCorners** 與 **Chart.HasRoundedCorners** 屬性。

1. 建立 **Presentation** 類別的物件。  
1. 在投影片上加入圖表。  
1. 設定圖表的填充類型與填充顏色。  
1. 將圓角屬性設為 **True**。  
1. 儲存已修改的簡報。  

以下提供範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **設定數字格式**
Aspose.Slides for C++ 提供簡易的 API 來管理圖表資料格式：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 加入圖表與預設資料，並使用任一想要的類型（本例使用 **ChartType.ClusteredColumn**）。  
1. 從可能的預設值中設定預設數字格式。  
1. 逐一遍歷每個圖表系列的圖表資料儲存格，並設定圖表資料的數字格式。  
1. 儲存簡報。  
1. 設定自訂的數字格式。  
1. 逐一遍歷每個圖表系列的圖表資料儲存格，為其設定不同的數字格式。  
1. 儲存簡報。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**以下列出可使用的預設數字格式值及其對應索引：**|
| :- | :- |
|**0**|General|
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

## **常見問題**

**我可以為柱形/區域設定半透明填色，同時保持邊框不透明嗎？**

可以。填色透明度與輪廓是分別設定的，這有助於提升密集視覺化圖表中格線與資料的可讀性。

**當資料標籤重疊時，我該怎麼處理？**

可以縮小字型尺寸、停用非必要的標籤元件（例如類別）、調整標籤的偏移/位置，必要時僅顯示選取點的標籤，或改為「值 + 圖例」的格式。

**我可以對系列套用漸層或圖案填色嗎？**

可以。通常同時支援實色與漸層/圖案填色。實務上建議少用漸層，並避免與格線或文字形成低對比度的組合。