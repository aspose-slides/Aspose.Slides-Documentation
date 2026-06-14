---
title: 使用 С++ 管理簡報圖表中的引線
linktitle: 引線
type: docs
url: /zh-hant/cpp/callout/
keywords:
- 圖表引線
- 使用引線
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "使用簡潔的程式碼範例在 Aspose.Slides for С++ 中建立與樣式化引線，兼容 PPT 與 PPTX，以自動化簡報工作流程。"
---
## **概觀**

本文說明了如何在 Aspose.Slides 中處理圖表資料標籤的引線。它展示了如何使用 `set_ShowLabelAsDataCallout` 方法將標籤顯示為引線，如何為環狀圖設定與引線相關的標籤設定，並說明在將簡報匯出為 PDF、HTML5、SVG 與點陣圖格式時，會保留引線及其外觀。

## **使用引線**
已在 **DataLabelFormat** 類別和 **IDataLabelFormat** 介面中新增屬性 **ShowLabelAsDataCallout**，該屬性決定指定圖表的資料標籤是顯示為資料引線還是顯示為資料標籤。以下範例中，我們已設定引線。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **為環狀圖設定引線**
Aspose.Slides for C++ 提供設定環狀圖系列資料標籤引線形狀的支援。以下提供範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **常見問題**

**將簡報轉換為 PDF、HTML5、SVG 或影像時，會保留引線嗎？**

是的。引線是圖表呈現的一部份，因此在匯出為[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/cpp/export-to-html5/)、[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)或[點陣圖](/slides/zh-hant/cpp/convert-powerpoint-to-png/)時，都會與投影片的格式一起保留下來。

**自訂字型能在引線中使用，且其外觀在匯出時能被保留嗎？**

是的。Aspose.Slides 支援將[嵌入字型](/slides/zh-hant/cpp/embedded-font/)加入簡報，並在匯出如[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)時控制字型嵌入，確保引線在不同系統上保持相同的外觀。