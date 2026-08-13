---
title: 在 Java 中設定備援字型集合
linktitle: 備援字型集合
type: docs
weight: 20
url: /zh-hant/java/create-fallback-fonts-collection/
keywords:
- 備援字型
- 備援規則
- 字型集合
- 設定字型
- 設置字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中設定備援字型集合，以確保 PowerPoint 與 OpenDocument 簡報的文字保持一致且清晰。"
---
## **概覽**

Aspose.Slides 允許您為簡報配置備援字型規則的集合。每個備援規則由 `FontFallBackRule` 類別表示，並可新增至 `FontFallBackRulesCollection`，它實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以將其指派給簡報的 `FontsManager` 的 `FontFallBackRulesCollection` 屬性。`FontsManager` 控制整個簡報的字型，且每個 `Presentation` 實例都有自己的 `FontsManager`。

一旦 `FontsManager` 使用備援字型集合初始化，指定的備援字型將在簡報渲染過程中套用。

## **套用備援規則**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 類別可組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRulesCollection)，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFontFallBackRulesCollection) 介面。可以在集合中加入或移除規則。

然後可將此集合指派給 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 類別的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整個簡報的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 都有一個 [getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getFontsManager--) 方法，該方法返回其自己的 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 實例。

以下是建立備援字型規則集合並指派至特定簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getFontsManager--) 的範例：

```java
import com.aspose.slides.*;

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

在 FontsManager 使用備援字型集合初始化後，備援字型將於簡報渲染時套用。

{{% alert color="info" %}} 
了解更多有關 [Render Presentation with Fallback Font](/slides/zh-hant/java/render-presentation-with-fallback-font/) 的資訊。
{{% /alert %}}

## **常見問題**

### 我的備援規則會嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？

不會。備援規則屬於執行時的渲染設定，不會序列化至 PPTX，也不會在 PowerPoint 的使用者介面中顯示。

### 備援機制會套用於 SmartArt、WordArt、圖表和表格中的文字嗎？

會。這些物件中的所有文字皆使用相同的字形替換機制。

### Aspose 會隨函式庫一併分發任何字型嗎？

不會。字型需由您自行加入與使用，風險由您自行承擔。

### 缺少字型時的取代/替換與缺少字形的備援可以一起使用嗎？

會。它們是同一字型解析管線的獨立階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/java/font-replacement/)/[substitution](/slides/zh-hant/java/font-substitution/)），然後備援會為可用字型中缺少的字形填補空缺。