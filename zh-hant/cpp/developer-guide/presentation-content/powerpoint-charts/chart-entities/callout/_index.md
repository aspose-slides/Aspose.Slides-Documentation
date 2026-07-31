---
title: 使用 C++ 管理簡報圖表中的標註線
linktitle: 標註線
type: docs
url: /zh-hant/cpp/callout/
keywords:
- 圖表標註線
- 使用標註線
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用簡潔的程式碼範例在 Aspose.Slides for C++ 中建立與設計標註線，支援 PPT 與 PPTX，協助自動化簡報工作流程。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表資料標籤的標註線（callout）。它展示了如何使用 `set_ShowLabelAsDataCallout` 方法將標籤顯示為標註線，如何為環形圖設定與標註線相關的標籤設定，並指出在將簡報匯出為 PDF、HTML5、SVG 與點陣圖像格式時，標註線及其外觀會被保留。

## **使用標註線**
已在 **DataLabelFormat** 類別與 **IDataLabelFormat** 介面中新增屬性 **ShowLabelAsDataCallout**，用以決定指定圖表的資料標籤是顯示為資料標註線還是資料標籤。本範例中，我們已設定標註線。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **為環形圖設定標註線**
Aspose.Slides for C++ 提供設定環形圖系列資料標籤標註線形狀的支援。下面給出範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **常見問題**

**將簡報轉換為 PDF、HTML5、SVG 或圖像時，標註線會被保留嗎？**

會。標註線是圖表呈現的一部份，當您匯出至[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/cpp/export-to-html5/)、[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)、或[點陣圖像](/slides/zh-hant/cpp/convert-powerpoint-to-png/)時，它們會與投影片的格式一起被保留。

**自訂字型能在標註線中使用，且在匯出時外觀會被保留嗎？**

會。Aspose.Slides 支援將[嵌入字型](/slides/zh-hant/cpp/embedded-font/)嵌入至簡報，並在匯出如[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)等格式時控制字型嵌入，確保標註線在不同系統上保持相同外觀。