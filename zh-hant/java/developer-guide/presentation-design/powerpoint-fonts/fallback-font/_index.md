---
title: 管理 Java 簡報的備援字體
linktitle: 備援字體
type: docs
weight: 50
url: /zh-hant/java/fallback-font/
keywords:
- 備援字體
- 可用字體
- 字形替換
- 指定字體
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何使用備援字體，在原始字體不可用時，使 PowerPoint 和 OpenDocument 簡報中的文字保持可讀性。"
---
## **簡介**

備援字體在系統中已安裝但不包含所需字形的情況下使用。在此情形下，Aspose.Slides 可以使用指定的備援字體之一來取代缺少的字形。

## **備援字體**

Aspose.Slides 允許建立備援字體、將其新增至備援字體集合、為特定簡報設定備援字體集合、從簡報中移除備援字體、指定套用備援字體的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立備援字體](/slides/zh-hant/java/create-fallback-font)
- [建立備援字體集合](/slides/zh-hant/java/create-fallback-fonts-collection)
- [使用備援字體呈現簡報](/slides/zh-hant/java/render-presentation-with-fallback-font)

## **常見問題**

**備援字體與字體替換有何不同？**

備援字體會在主要字體缺少特定字形時，針對單一字元或 Unicode 範圍套用，只填補缺少的字元。[字體替換](/slides/zh-hant/java/font-substitution/)則會在整段或整個文字區塊缺少或無法使用的字體時，將其全部換成另一種字體。兩者可以同時使用，但其適用範圍與選擇邏輯不同。

**備援設定會儲存在簡報檔案內嗎？**

不會。備援設定僅在程式庫的處理/呈現階段存在，並不會序列化寫入 PPTX。簡報本身不會儲存您的備援規則。

**備援會影響 PowerPoint 物件（SmartArt、圖表、WordArt）建立的元素嗎？**

會。這些物件內的文字會經過相同的呈現管線，因此也會套用與一般文字相同的備援規則。