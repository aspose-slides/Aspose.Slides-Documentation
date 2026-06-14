---
title: 在 Android 上配置備援字型集合
linktitle: 備援字型集合
type: docs
weight: 20
url: /zh-hant/androidjava/create-fallback-fonts-collection/
keywords:
- 備援字型
- 備援規則
- 字型集合
- 配置字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for Android 中設定備援字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概述**

Aspose.Slides 允許您為簡報配置一組備援字型規則。每個備援規則由 `FontFallBackRule` 類別表示，並可加入 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以將其指派給簡報的 `FontsManager` 的 `FontFallBackRulesCollection` 屬性。`FontsManager` 負責控制整個簡報的字型，而每個 `Presentation` 實例都有自己的 `FontsManager`。

一旦使用備援字型集合初始化 `FontsManager`，在簡報渲染期間將套用指定的備援字型。

## **應用備援規則**

可以將 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 類別的實例組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRulesCollection)，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFontFallBackRulesCollection) 介面。可以在集合中新增或移除規則。

然後可以將此集合指派給 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRulesCollection) 方法，該方法屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager) 類別。FontsManager 控制整個簡報的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 都有一個 [getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getFontsManager--) 方法，返回其自己的 [FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager) 類別實例。

以下範例說明如何建立備援字型規則集合，並將其指派至特定簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getFontsManager--)：

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

在使用備援字型集合初始化 FontsManager 後，備援字型將在簡報渲染期間套用。

{{% alert color="primary" %}} 
了解更多有關如何[以備援字型渲染簡報](/slides/zh-hant/androidjava/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常見問題**

**我的備援規則會被嵌入 PPTX 檔並在儲存後於 PowerPoint 中可見嗎？**

不會。備援規則是執行時渲染設定，不會序列化到 PPTX 中，也不會出現在 PowerPoint 的使用者介面中。

**備援字型是否適用於 SmartArt、WordArt、圖表和表格內的文字？**

是。這些物件中的所有文字皆使用相同的字形替換機制。

**Aspose 是否隨函式庫一起分發任何字型？**

不會。字型需由您自行添加與使用，並自行負責。

**缺字型的替換/替代與缺字形的備援可以同時使用嗎？**

可以。它們是相同字型解析管線的獨立階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/androidjava/font-replacement/)/[substitution](/slides/zh-hant/androidjava/font-substitution/)），然後備援會填補可用字型中缺少的字形。