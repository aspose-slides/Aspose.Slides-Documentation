---
title: 在 Python（透過 Java）中管理簡報的備援字體
linktitle: 備援字體
type: docs
weight: 50
url: /zh-hant/python-java/fallback-font/
keywords:
- 備援字體
- 可用字體
- 字形取代
- 指定字體
- 指定規則
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何在原始字體不可用時，使用備援字體確保 PowerPoint 與 OpenDocument 簡報中的文字可讀。"
---
## **簡介**

當系統中存在指定的文字字體，但該字體不包含所需字形時，會使用備援字體。在此情況下，Aspose.Slides 可以使用指定的備援字體之一來取代缺失的字形。

## **備援字體**

Aspose.Slides 允許您建立備援字體、將其加入備援字體集合、為特定簡報設定備援字體集合、從簡報中移除備援字體、指定套用備援字體的規則，以及執行其他相關操作。

若要熟悉這些功能，請使用以下連結：

- [建立備援字體](/slides/zh-hant/python-java/create-fallback-font/)
- [建立備援字體集合](/slides/zh-hant/python-java/create-fallback-fonts-collection/)
- [使用備援字體呈現簡報](/slides/zh-hant/python-java/render-presentation-with-fallback-font/)

## **常見問題**

**備援字體與字型替代有何不同？**

當主要字體缺少特定字形時，備援會針對單一字元或 Unicode 範圍套用，只填補缺失的字元。[替代](/slides/zh-hant/python-java/font-substitution/) 則會將缺少或不可用的字體在整段文字或文字區段中全部換成另一個字體。兩者可結合使用，但其範圍與選擇邏輯不同。

**備援設定會儲存在簡報檔案內嗎？**

不會。備援設定僅在程式庫的處理/呈現階段存在，且不會序列化至 PPTX。簡報不會儲存您的備援規則。

**備援會影響由 PowerPoint 物件（SmartArt、圖表、WordArt）建立的元素嗎？**

會。這些物件內的文字會經過相同的呈現管線，因而套用與一般文字相同的備援規則。