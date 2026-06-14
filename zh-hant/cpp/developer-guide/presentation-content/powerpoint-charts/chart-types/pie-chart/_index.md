---
title: 使用 C++ 自訂簡報中的圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/cpp/pie-chart/
keywords:
- 圓餅圖
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
description: "了解如何使用 Aspose.Slides 在 C++ 中建立及自訂圓餅圖，並匯出至 PowerPoint，讓您在數秒內提升資料敘事效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為 Pie of Pie 與 Bar of Pie 圖表設定次要圖表選項，以及如何為標準圓餅圖啟用自動切片著色。

範例側重於實務圖表客製化步驟，例如將圖表新增至投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **對於 Pie of Pie 與 Bar of Pie 圖表的次要圖表選項**
Aspose.Slides for C++ 現已支援 Pie of Pie 或 Bar of Pie 圖表的次要圖表選項。在本主題中，我們將透過範例說明如何使用 Aspose.Slides 指定這些選項。請依照下列步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別物件。
1. 在投影片上新增圖表。
1. 指定圖表的次要圖表選項。
1. 將簡報寫入磁碟。

以下範例中，我們設定了 Pie of Pie 圖表的不同屬性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **設定自動圓餅圖切片顏色**
Aspose.Slides for C++ 提供簡易 API 以設定自動圓餅圖切片顏色。以下示範程式碼套用前述屬性設定。

1. 建立 Presentation 類別的實例。
1. 取得第一張投影片。
1. 新增帶預設資料的圖表。
1. 設定圖表標題。
1. 設定第一系列為顯示數值。
1. 設定圖表資料工作表的索引。
1. 取得圖表資料工作表。
1. 刪除預設產生的系列與類別。
1. 新增類別。
1. 新增系列。

將修改後的簡報寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**是否支援「Pie of Pie」與「Bar of Pie」變體？**

是的，函式庫 [supports](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 次要圖表繪製，包含「Pie of Pie」與「Bar of Pie」類型。

**我可以僅將圖表匯出為影像（例如 PNG）嗎？**

可以，您可以 [export the chart itself as an image](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)（如 PNG），而不必匯出整個簡報。