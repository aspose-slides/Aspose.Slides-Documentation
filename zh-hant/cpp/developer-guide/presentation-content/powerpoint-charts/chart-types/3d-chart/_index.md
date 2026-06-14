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
description: "了解如何在 Aspose.Slides for C++ 中建立與自訂 3D 圖表，支援 PPT 與 PPTX 檔案 —— 立即提升您的簡報效果。"
---
## **概述**

本文說明如何透過設定 `Rotation3D`（如 `RotationX`、`RotationY`、`DepthPercents` 與 `RightAngleAxes`）來自訂 Aspose.Slides 中的 3D 圖表。內容包括建立簡報、加入預設資料的 3D 圖表、套用必要的 3D 觀察設定，最後將修改後的簡報儲存為 PPTX 檔案。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**
Aspose.Slides for C++ 提供簡易的 API 來設定這些屬性。以下示範說明如何設定 X、Y 旋轉與 **DepthPercents** 等屬性。範例程式碼展示了上述屬性的設定方式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 存取第一張投影片。
3. 新增包含預設資料的圖表。
4. 設定 Rotation3D 屬性。
5. 將修改後的投影片寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援 3D 版本的柱狀圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，並透過 [ChartType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 列舉公開其他相關的 3D 類型。欲取得完整且最新的清單，請檢查您所安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖用於報告或網頁嗎？**

可以。您可以透過 [chart API](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/) 將圖表匯出為影像，或是將整張投影片[將整張投影片渲染](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在您需要像素完美的預覽或想將圖表嵌入文件、儀表板或網頁，且不需要 PowerPoint 時，非常有用。

**建立與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為獲得最佳效能，建議儘量減少 3D 效果、避免在牆面與繪圖區使用大量紋理，盡可能限制每個系列的資料點數，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的適當大小。