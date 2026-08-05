---
title: 管理 C++ 簡報的備援字體
linktitle: 備援字體
type: docs
weight: 50
url: /zh-hant/cpp/fallback-font/
keywords:
- 備援字體
- 可用字體
- 字形取代
- 指定字體
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何使用備援字體，在原始字體不可用時，確保 PowerPoint 與 OpenDocument 簡報中的文字可讀。"
---
## **簡介**

當系統中已安裝的文字指定字體存在，但不包含所需字形時，會使用備援字體。在此情況下，Aspose.Slides 可以使用指定的備援字體之一來取代缺失的字形。

## **備援字體**
當系統中已安裝的文字指定字體存在，但該字體未包含必要的字形時，會使用備援字體。在此情況下，可以使用指定的備援字體之一來取代缺失的字形。

Aspose.Slides 允許建立備援字體、將其加入備援字體集合、為特定簡報設定備援字體集合、從簡報中移除備援字體、指定套用備援字體的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立備援字體](/slides/zh-hant/cpp/create-fallback-font)
- [建立備援字體集合](/slides/zh-hant/cpp/create-fallback-fonts-collection)
- [使用備援字體呈現簡報](/slides/zh-hant/cpp/render-presentation-with-fallback-font)

## **常見問題**

**備援字體與字體替換有何不同？**

當主要字體缺少特定字形時，備援字體會逐字元或逐 Unicode 範圍套用，只填補缺失的字元。[字體替換](/slides/zh-hant/cpp/font-substitution/) 則會將缺失或無法使用的字體在整段或文字區塊中全部取代為其他字體。兩者可結合使用，但其範圍與選擇逻辑不同。

**備援設定會儲存在簡報檔案中嗎？**

不會。備援設定僅在程式庫的處理/渲染階段存在，並不會序列化寫入 PPTX。簡報不會儲存您的備援規則。

**備援會影響由 PowerPoint 物件（SmartArt、圖表、WordArt）建立的元素嗎？**

會。這些物件內的文字會經過相同的渲染流程，因此會套用與一般文字相同的備援規則。