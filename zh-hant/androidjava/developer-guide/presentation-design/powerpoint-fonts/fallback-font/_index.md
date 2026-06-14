---
title: 在 Android 上管理簡報的回退字型
linktitle: 回退字型
type: docs
weight: 50
url: /zh-hant/androidjava/fallback-font/
keywords:
- 回退字型
- 可用字型
- 字形替換
- 指定字型
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android（透過 Java）如何使用回退字型，在原始字型不可用時，確保 PowerPoint 與 OpenDocument 簡報中的文字仍然可讀。"
---
## **簡介**

當系統中已安裝指定的文字字型，但該字型不包含必要的字形時，會使用回退字型。在此情況下，可以使用指定的回退字型之一來取代缺少的字形。

## **回退字型**

Aspose.Slides 允許建立回退字型、將它們加入回退字型集合、為特定簡報設定回退字型集合、從簡報中移除回退字型、指定套用回退字型的規則等。

若要熟悉這些功能，請使用以下連結：

- [建立回退字型](/slides/zh-hant/androidjava/create-fallback-font)
- [建立回退字型集合](/slides/zh-hant/androidjava/create-fallback-fonts-collection)
- [使用回退字型呈現簡報](/slides/zh-hant/androidjava/render-presentation-with-fallback-font)

## **常見問題**

**回退字型與字型替代有何不同？**

當主要字型缺少特定字形時，回退會在每個字元或 Unicode 範圍內套用，只填補缺失的字元。[字型替代](/slides/zh-hant/androidjava/font-substitution/) 會將缺少或無法使用的字型替換為另一個字型，適用於整段文字或文字片段。兩者可同時使用，但其作用範圍與選擇邏輯不同。

**回退設定會儲存於簡報檔案內嗎？**

不會。回退設定僅在程式庫的處理/呈現階段存在，並不會序列化寫入 PPTX。簡報檔不會儲存您的回退規則。

**回退會影響由 PowerPoint 物件（如 SmartArt、圖表、WordArt）所建立的元素嗎？**

會。這些物件內的文字會經過相同的呈現流程，因此會套用與一般文字相同的回退規則。