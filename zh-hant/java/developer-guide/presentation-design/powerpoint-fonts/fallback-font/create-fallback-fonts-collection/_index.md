---
title: 在 Java 中設定備援字體集合
linktitle: 備援字體集合
type: docs
weight: 20
url: /zh-hant/java/create-fallback-fonts-collection/
keywords:
- 備援字體
- 備援規則
- 字體集合
- 設定字體
- 建立字體
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中設定備援字體集合，使 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概述**

Aspose.Slides 允許您為簡報配置備援字體規則的集合。每個備援規則由 `FontFallBackRule` 類別表示，且可加入至 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以將它指派給簡報的 `FontsManager` 中的 `FontFallBackRulesCollection` 屬性。`FontsManager` 控制簡報中的字體，且每個 `Presentation` 實例都有自己的 `FontsManager`。

一旦使用備援字體集合初始化 `FontsManager`，在簡報渲染過程中即會套用指定的備援字體。

## **套用備援規則**

`FontFallBackRule` 類別的實例可以組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRulesCollection)，它實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFontFallBackRulesCollection) 介面。可以在集合中新增或移除規則。

然後可以將此集合指派給 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRulesCollection) 方法，該方法屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 類別。FontsManager 控制簡報中的字體。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 都有一個 [getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getFontsManager--) 方法，該方法返回其自身的 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 類別實例。

以下是一個示範，說明如何建立備援字體規則集合並指派給特定簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getFontsManager--)：

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

在使用備援字體集合初始化 FontsManager 後，備援字體會在簡報渲染時套用。

{{% alert color="primary" %}} 
閱讀更多有關 [Render Presentation with Fallback Font](/slides/zh-hant/java/render-presentation-with-fallback-font/) 的說明。
{{% /alert %}}

## **常見問題**

**我的備援規則會被嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。備援規則屬於執行時渲染設定，並不會序列化至 PPTX，亦不會出現在 PowerPoint 的使用者介面中。

**備援是否適用於 SmartArt、WordArt、圖表與表格內的文字？**

會。這些物件中的任何文字皆使用相同的字形置換機制。

**Aspose 是否隨函式庫一起分發任何字體？**

不會。字體須由您自行加入並使用，相關責任由您自行承擔。

**缺字體的替換/置換與缺字形的備援可以同時使用嗎？**

會。它們是同一字體解析流程中獨立的階段：首先引擎解決字體可用性（[replacement](/slides/zh-hant/java/font-replacement/)/[substitution](/slides/zh-hant/java/font-substitution/)），接著備援會填補可用字體中缺少的字形。