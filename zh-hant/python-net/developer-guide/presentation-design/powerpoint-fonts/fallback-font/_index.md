---
title: 在 Python 中管理簡報的備援字體
linktitle: 備援字體
type: docs
weight: 50
url: /zh-hant/python-net/fallback-font/
keywords:
- 備援字體
- 可用字體
- 字形替換
- 指定字體
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何使用備援字體，在 PowerPoint 與 OpenDocument 簡報中於原始字體不可用時保持文字可讀性。"
---
## **簡介**

當系統中已安裝指定的文字字體，但該字體不包含所需字形時，會使用備援字體。在此情況下，Aspose.Slides 可以使用指定的備援字體之一來取代缺失的字形。

## **備援字體**

Aspose.Slides 允許建立備援字體、將其加入備援字體集合、為特定簡報設定備援字體集合、從簡報中移除備援字體、指定套用備援字體的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立備援字體](/slides/zh-hant/python-net/create-fallback-font)
- [建立備援字體集合](/slides/zh-hant/python-net/create-fallback-fonts-collection)
- [使用備援字體呈現簡報](/slides/zh-hant/python-net/render-presentation-with-fallback-font)

## **常見問題**

**備援字體與字體替換有何不同？**

當主字體缺少特定字形時，備援會依每個字元或 Unicode 範圍套用，只填補缺失的字元。[字體替換](/slides/zh-hant/python-net/font-substitution/) 會將缺少或無法使用的字體取代整個文字段落或文字區塊的字體。兩者可結合使用，但其適用範圍與選取邏輯不同。

**備援設定會儲存在簡報檔案內嗎？**

不會。備援設定僅在程式庫的處理/呈現階段存在，並不會序列化寫入 PPTX。簡報不會儲存您的備援規則。

**備援會影響 PowerPoint 物件（如 SmartArt、圖表、WordArt）所建立的元素嗎？**

會。這些物件內的文字會走相同的渲染流程，因此會套用與一般文字相同的備援規則。