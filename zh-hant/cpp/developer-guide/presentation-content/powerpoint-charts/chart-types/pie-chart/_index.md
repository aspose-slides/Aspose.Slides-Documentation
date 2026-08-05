---
title: 使用 C++ 自訂簡報中的餅圖
linktitle: 餅圖
type: docs
url: /zh-hant/cpp/pie-chart/
keywords:
- 餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 C++ 搭配 Aspose.Slides 建立與自訂餅圖，並匯出為 PowerPoint，讓您在數秒內提升資料敘事效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用餅圖。它展示了如何為 Pie of Pie 與 Bar of Pie 圖表設定次要圖層選項，以及如何為一般餅圖啟用自動切片著色。

示例聚焦於實作圖表自訂的步驟，包括將圖表加入投影片、調整系列與標籤設定、以自訂的類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的第二圖層選項**
Aspose.Slides for C++ 現已支援 Pie of Pie 或 Bar of Pie 圖表的次要圖層選項。本主題將透過範例說明如何使用 Aspose.Slides 指定這些選項。請依照以下步驟操作：

1. 建立 Presentation 類別的實例物件。
1. 在投影片上新增圖表。
1. 指定圖表的第二圖層選項。
1. 將簡報寫入磁碟。

在下方範例中，我們設定了 Pie of Pie 圖表的不同屬性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **設定自動餅圖切片顏色**
Aspose.Slides for C++ 提供簡易的 API 以設定餅圖自動切片顏色。範例程式碼套用了上述屬性設定。

1. 建立 Presentation 類別的實例。
2. 取得第一張投影片。
3. 使用預設資料新增圖表。
4. 設定圖表標題。
5. 設定第一個資料系列為顯示值。
6. 設定圖表資料工作表的索引。
7. 取得圖表資料工作表。
8. 刪除預設產生的系列與類別。
9. 新增類別。
10. 新增系列。

將修改後的簡報寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **常見問題**

**是否支援 “Pie of Pie” 與 “Bar of Pie” 變體？**

是的，該函式庫[支援](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/)餅圖的次要圖層，包括 “Pie of Pie” 與 “Bar of Pie” 類型。

**我可以只將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)（例如 PNG），而不需要整個簡報。