---
title: 使用 C++ 在簡報中自訂 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/cpp/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中建立與自訂 3-D 圖表，支援 PPT 與 PPTX 檔案—立即提升您的簡報效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中透過設定 `Rotation3D`（如 `RotationX`、`RotationY`、`DepthPercents` 與 `RightAngleAxes`）來自訂 3D 圖表。文章將逐步示範建立簡報、加入預設資料的 3D 圖表、套用必要的 3D 檢視設定，並將修改後的簡報儲存為 PPTX 檔案。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**
Aspose.Slides for C++ 提供簡易的 API 來設定這些屬性。以下範例將說明如何設定 X、Y 旋轉、**DepthPercents** 等屬性。範例程式碼會套用上述屬性設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 取得第一張投影片。
1. 新增帶有預設資料的圖表。
1. 設定 Rotation3D 屬性。
1. 將修改後的簡報寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，並透過 [ChartType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 列舉揭露相關的 3D 類型。欲取得最精確、最新的清單，請檢查已安裝版本 API 參考中的 [ChartType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網站嗎？**

可以。您可透過 [chart API](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/) 將圖表匯出為影像，或將整張投影片[轉換為 PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 等格式（如 PNG 或 JPEG）。當您需要像素完美的預覽，或想在文件、儀表板或網頁中嵌入圖表而不需 PowerPoint 時，這非常有用。

**建立與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳效能，建議將 3D 效果維持在最低，避免在牆面與繪圖區使用大量紋理，盡可能限制每個系列的資料點數量，並依目標顯示或列印需求，將輸出解析度與尺寸設為適當大小。