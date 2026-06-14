---
title: 在 C++ 中將線條圖形新增至簡報
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/cpp/line/
keywords:
- 線條
- 建立線條
- 新增線條
- 普通線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 操作 PowerPoint 簡報中的線條格式設定。探索屬性、方法與範例。"
---
## **概述**

Aspose.Slides 允許您以程式方式將線條圖形新增至 PowerPoint 投影片中。本文說明如何建立簡單的線條以及如何自訂線條使其呈現為箭頭。

您將學習如何將線條圖形新增至投影片、調整其視覺外觀，並儲存已更新的簡報。範例著重於實用的線條格式設定，例如樣式、寬度、虛線樣式、箭頭選項與填色。

## **建立普通線條**
要在簡報的選定投影片中加入簡單的普通線條，請遵循以下步驟：

- 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的實例。
- 使用索引取得投影片的參照。
- 使用 Shapes 物件提供的 [AddAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addautoshape/) 方法，新增類型為 Line 的 AutoShape。
- 將已修改的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片新增了一條線條。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **建立箭頭形線條**
Aspose.Slides for C++ 亦允許開發人員設定線條的某些屬性，使其更具吸引力。讓我們嘗試設定幾個屬性，使線條呈現為箭頭。請依照以下步驟進行：

- 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的實例。
- 使用索引取得投影片的參照。
- 使用 Shapes 物件提供的 AddAutoShape 方法，新增類型為 Line 的 AutoShape。
- 將 Line Style 設定為 Aspose.Slides for C++ 所提供的樣式之一。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linedashstyle/) 設定為 Aspose.Slides for C++ 所提供的樣式之一。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/lineformat/) 與長度。
- 設定線條終點的 Arrow Head Style 與長度。
- 將已修改的簡報寫入為 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **常見問題**

**我可以將一般線條轉換為連接線，使其能「貼齊」形狀嗎？**

不會。一般線條（[AutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/autoshape/) 類型為 [Line](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapetype/)）不會自動變為連接線。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/connector/) 類型，並使用用於連接的 [相應的 API](/slides/zh-hant/cpp/connector/)。

**如果線條的屬性繼承自佈景主題且難以確定最終值，我該怎麼辦？**

透過 [閱讀有效屬性](/slides/zh-hant/cpp/shape-effective-properties/) 以及 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilinefillformateffectivedata/) 介面來取得——這些已考慮了繼承和佈景主題樣式。

**我可以鎖定線條以防止編輯（移動、調整大小）嗎？**

可以。Shapes 提供 [鎖定物件](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/autoshape/get_autoshapelock/) 讓您可以 [禁止編輯操作](/slides/zh-hant/cpp/applying-protection-to-presentation/)。