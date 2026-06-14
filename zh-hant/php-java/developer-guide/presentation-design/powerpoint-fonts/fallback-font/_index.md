---
title: 在 PHP 中管理簡報的後備字體
linktitle: 後備字體
type: docs
weight: 50
url: /zh-hant/php-java/fallback-font/
keywords:
- 後備字體
- 可用字體
- 字形替換
- 指定字體
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP 如何在原始字體不可用時，使用後備字體使 PowerPoint 和 OpenDocument 簡報中的文字保持可讀。"
---
## **簡介**

當系統中已安裝指定的文字字體，但該字體不包含所需字形時，會使用後備字體。在此情況下，Aspose.Slides 可以使用指定的後備字體之一來取代缺少的字形。

## **後備字體**
當系統中已安裝指定的文字字體，但該字體不包含必要的字形時，會使用後備字體。在此情況下，可以使用指定的後備字體之一來進行字形替換。

Aspose.Slides 允許建立後備字體、將其加入後備字體集合、為特定簡報設定後備字體集合、從簡報中移除後備字體、指定套用後備字體的規則等等。

若要熟悉這些功能，請使用以下連結：

- [建立後備字體](/slides/zh-hant/php-java/create-fallback-font)
- [建立後備字體集合](/slides/zh-hant/php-java/create-fallback-fonts-collection)
- [使用後備字體呈現簡報](/slides/zh-hant/php-java/render-presentation-with-fallback-font)

## **常見問題**

**後備字體與字體替換有何不同？**

後備字體會在主要字體缺少特定字形時，依每個字元或每個 Unicode 範圍套用，只填補缺少的字元。[Substitution](/slides/zh-hant/php-java/font-substitution/) 則會將缺少或無法使用的字體整段或文字片段取代為其他字體。它們可以結合使用，但適用範圍與選擇邏輯不同。

**後備設定會儲存在簡報檔案內嗎？**

不會。後備設定僅在程式庫的處理/呈現階段存在，且不會序列化寫入 PPTX。簡報本身不會儲存您的後備規則。

**後備字體會影響 PowerPoint 物件（SmartArt、圖表、WordArt）所建立的元素嗎？**

會。這些物件內的文字會走相同的呈現管線，因此會套用與一般文字相同的後備規則。