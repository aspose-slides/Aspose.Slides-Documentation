---
title: 管理 .NET 簡報的備用字型
linktitle: 備用字型
type: docs
weight: 50
url: /zh-hant/net/fallback-font/
keywords:
- 備用字型
- 可用字型
- 字形替換
- 指定字型
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何使用備用字型，在原始字型不可用時，確保 PowerPoint 與 OpenDocument 簡報的文字保持可讀。"
---
## **簡介**

當系統中已安裝指定的文字字型但該字型不包含所需字形時，會使用備用字型。在此情況下，Aspose.Slides 可使用指定的備用字型之一來取代缺少的字形。

## **備用字型**

Aspose.Slides 允許建立備用字型、將其加入備用字型集合、為特定簡報設定備用字型集合、從簡報中移除備用字型、指定套用備用字型的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立備用字型](/slides/zh-hant/net/create-fallback-font)
- [建立備用字型集合](/slides/zh-hant/net/create-fallback-fonts-collection)
- [使用備用字型呈現簡報](/slides/zh-hant/net/render-presentation-with-fallback-font)

## **常見問題**

**備用字型與字型置換有何不同？**

備用字型會在主要字型缺少特定字形時，於每個字元或 Unicode 範圍內套用，只填補缺少的字元。[置換](/slides/zh-hant/net/font-substitution/) 會將缺少或無法使用的字型，於整段或文字區段中全部取代為其他字型。它們可以同時使用，但適用範圍與選擇邏輯不同。

**備用字型設定會儲存在簡報檔案內嗎？**

不會。備用字型設定僅在程式庫的處理/呈現階段存在，並不會序列化寫入 PPTX。簡報本身不會儲存您的備用字型規則。

**備用字型會影響 PowerPoint 物件（SmartArt、圖表、WordArt）所建立的元素嗎？**

會。這些物件內的文字會經過相同的呈現管線，因此會套用與一般文字相同的備用字型規則。