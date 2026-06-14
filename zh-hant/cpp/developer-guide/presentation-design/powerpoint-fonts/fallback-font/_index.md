---
title: 在 С++ 中管理簡報的備援字型
linktitle: 備援字型
type: docs
weight: 50
url: /zh-hant/cpp/fallback-font/
keywords:
- 備援字型
- 可用字型
- 字形取代
- 指定字型
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- С++
- Aspose.Slides
description: "了解 Aspose.Slides for С++ 如何使用備援字型，在 PowerPoint 和 OpenDocument 簡報中於原始字型不可用時保持文字可讀性。"
---
## **簡介**

當文字指定的字型在系統中可用但缺少所需字形時，會使用備援字型。在此情況下，Aspose.Slides 可使用指定的備援字型之一來取代缺失的字形。

## **備援字型**
當文字指定的字型在系統中可用，但該字型未包含必要的字形時，會使用備援字型。在此情況下，可以使用指定的備援字型之一來取代缺失的字形。

Aspose.Slides 允許建立備援字型、將其加入備援字型集合、為特定簡報設定備援字型集合、從簡報中移除備援字型、指定套用備援字型的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立備援字型](/slides/zh-hant/cpp/create-fallback-font)
- [建立備援字型集合](/slides/zh-hant/cpp/create-fallback-fonts-collection)
- [使用備援字型呈現簡報](/slides/zh-hant/cpp/render-presentation-with-fallback-font)

## **常見問題**

**備援字型與字型替換有何不同？**

當主要字型缺少特定字形時，備援字型會以每個字元或每個 Unicode 範圍的方式套用，只填補缺失的字元。[替換](/slides/zh-hant/cpp/font-substitution/) 會將缺少或無法使用的字型整段或文字部份替換為其他字型。兩者可以結合使用，但其適用範圍與選擇邏輯不同。

**備援字型設定會儲存在簡報檔案內嗎？**

不會。備援設定僅在程式庫的處理/呈現階段存在，並不會序列化至 PPTX。簡報不會儲存您的備援規則。

**備援字型會影響由 PowerPoint 物件（SmartArt、圖表、WordArt）建立的元素嗎？**

會。這些物件中的文字會經過相同的呈現管線，因此會套用與一般文字相同的備援規則。