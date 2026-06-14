---
title: 在 JavaScript 中管理簡報的備援字型
linktitle: 備援字型
type: docs
weight: 50
url: /zh-hant/nodejs-java/fallback-font/
keywords:
- 備援字型
- 可用字型
- 字形替換
- 指定字型
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js 如何使用備援字型，在原始字型不可用時，讓 PowerPoint 和 OpenDocument 簡報中的文字保持可讀性。"
---
## **簡介**

當系統中已安裝指定的文字字型，但該字型未包含所需字形時，會使用備援字型。在此情況下，Aspose.Slides 可以使用指定的備援字型之一來取代缺失的字形。

## **備援字型**

Aspose.Slides 允許建立備援字型、將其加入備援字型集合、為特定簡報設定備援字型集合、從簡報中移除備援字型、指定套用備援字型的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立備援字型](/slides/zh-hant/nodejs-java/create-fallback-font)
- [建立備援字型集合](/slides/zh-hant/nodejs-java/create-fallback-fonts-collection)
- [使用備援字型繪製簡報](/slides/zh-hant/nodejs-java/render-presentation-with-fallback-font)

## **常見問題**

**備援字型與字型替代有何不同？**

當主要字型缺少特定字形時，備援字型會針對單一字符或 Unicode 範圍套用，只填補缺失的字符。[替代](/slides/zh-hant/nodejs-java/font-substitution/) 會將缺失或無法使用的字型整段或文字區塊替換為另一個字型。兩者可結合使用，但其範圍與選取邏輯不同。

**備援設定會儲存在簡報檔案內嗎？**

不會。備援設定僅在程式庫的處理/繪製階段存在，並不會序列化寫入 PPTX。簡報不會儲存您的備援規則。

**備援會影響由 PowerPoint 物件（SmartArt、圖表、WordArt）建立的元件嗎？**

會。這些物件內的文字會經過相同的繪製流程，因此會套用與一般文字相同的備援規則。