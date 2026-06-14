---
title: 在 JavaScript 中設定備援字型集合
linktitle: 備援字型集合
type: docs
weight: 20
url: /zh-hant/nodejs-java/create-fallback-fonts-collection/
keywords:
- 備援字型
- 備援規則
- 字型集合
- 設定字型
- 配置字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中設定備援字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概觀**

Aspose.Slides 允許您為簡報設定一組備援字型規則的集合。每個備援規則皆以 `FontFallBackRule` 類別表示，且可以加入到 `FontFallBackRulesCollection` 中。

建立集合後，您可以透過簡報的 `FontsManager` 所提供的 `setFontFallBackRulesCollection` 方法將其指定。`FontsManager` 負責管理整個簡報的字型，而每個 `Presentation` 實例皆擁有自己的 `FontsManager`。

當 `FontsManager` 使用備援字型集合完成初始化後，指定的備援字型便會在簡報呈現時套用。

## **套用回退規則**

`FontFallBackRule` 類別的實例可以組織成[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRulesCollection)，並實作[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRulesCollection)類別。可以在集合中新增或移除規則。

然後，此集合可以指派給[FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontsManager)類別的相關方法。FontsManager 控制整個簡報的字型。

每個[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)都有一個[getFontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getFontsManager--)方法，該方法返回其自身的[FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontsManager)類別實例。

以下示範如何建立備援字型規則集合並將其指派至特定簡報的[FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getFontsManager--)：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

在 FontsManager 使用備援字型集合初始化後，備援字型會在簡報呈現時套用。

{{% alert color="primary" %}} 
欲了解更多，請參閱[以備援字型呈現簡報](/slides/zh-hant/nodejs-java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常見問題**

**我的備援規則會嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。備援規則屬於執行時的呈現設定，並不會序列化寫入 PPTX，因此不會在 PowerPoint 介面中顯示。

**備援規則是否會套用於 SmartArt、WordArt、圖表與表格中的文字？**

會。這些物件中的文字皆使用相同的字形置換機制。

**Aspose 是否會隨函式庫一起提供任何字型？**

不會。您需自行加入並使用字型，相關責任亦由您自行承擔。

**缺字型的取代/置換與缺字形的備援可以同時使用嗎？**

可以。它們是同一字型解析流程中的獨立階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/nodejs-java/font-replacement/)/[substitution](/slides/zh-hant/nodejs-java/font-substitution/)），接著備援會填補可用字型中缺失的字形。