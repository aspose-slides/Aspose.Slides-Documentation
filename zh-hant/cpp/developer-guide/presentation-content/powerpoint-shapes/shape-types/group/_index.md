---
title: C++ 中的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/cpp/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習使用 Aspose.Slides for C++ 在 PowerPoint 簡報中對形狀進行群組與解除群組 — 快速、逐步指南，提供免費的 C++ 程式碼。"
---
## **概述**

本篇文章說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何將群組形狀新增至投影片、在其中放置形狀，並儲存更新後的簡報。它亦示範如何存取群組內的形狀並讀取它們的 `AlternativeText` 值。此外，本文還簡要介紹相關的群組形狀功能，例如巢狀群組、Z 順序以及鎖定選項。

## **新增群組形狀**
Aspose.Slides 支援在投影片上使用群組形狀。此功能協助開發人員製作更豐富的簡報。Aspose.Slides for C++ 支援新增或存取群組形狀。您可以將形狀新增至已建立的群組形狀中以填充內容，或存取群組形狀的任何屬性。使用 Aspose.Slides for C++ 將群組形狀新增至投影片的方法如下：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)類別的實例。
2. 使用索引取得投影片的參考。
3. 將群組形狀新增至投影片。
4. 將形狀新增至已建立的群組形狀。
5. 將修改後的簡報儲存為 PPTX 檔案。

以下範例將群組形狀新增至投影片。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **存取 AltText 屬性**
本主題展示了簡單的步驟與程式碼範例，以在投影片上新增群組形狀並存取其 AltText 屬性。使用 Aspose.Slides for C++ 存取投影片中群組形狀的 AltText 方法如下：

1. 實例化代表 PPTX 檔案的 `Presentation` 類別。
2. 使用索引取得投影片的參考。
3. 存取投影片的形狀集合。
4. 存取群組形狀。
5. 存取 AltText 屬性。

以下範例存取群組形狀的替代文字。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **常見問題**

**是否支援巢狀分組（群組內有群組）？**

是的。[GroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/groupshape/) 具備[get_ParentGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/get_parentgroup/) 方法，可直接顯示層級支援（群組可以是另一個群組的子項）。

**如何控制群組相對於投影片上其他物件的 Z 順序？**

使用[GroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/groupshape/)的[Z-Order position](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/get_zorderposition/)來檢查其在顯示堆疊中的位置。

**我可以防止移動/編輯/解除群組嗎？**

是的。群組的鎖定區段可透過[get_GroupShapeLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/groupshape/get_groupshapelock/)取得，讓您限制對該物件的操作。