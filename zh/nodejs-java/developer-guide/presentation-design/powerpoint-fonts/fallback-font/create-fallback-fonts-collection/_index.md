---
title: 在 JavaScript 中配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/nodejs-java/create-fallback-fonts-collection/
keywords:
- 回退字体
- 回退规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js 设置回退字体集合，以保持 PowerPoint 和 OpenDocument 演示文稿中的文字一致且清晰。"
---

## **应用回退规则**

[FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) 类的实例可以组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) 中，该集合实现了 [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) 类。可以向集合中添加或删除规则。

然后可以将此集合分配给 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整个演示文稿的字体。

每个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) 方法，返回其自己的 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) 实例。

以下示例演示如何创建回退字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--)：
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


在为 FontsManager 初始化回退字体集合后，渲染演示文稿时会应用回退字体。

{{% alert color="primary" %}} 
了解更多，请参阅 [Render Presentation with Fallback Font](/slides/zh/nodejs-java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **FAQ**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的 UI 中。

**回退是否适用于 SmartArt、WordArt、图表和表格中的文本？**

是的。相同的字形替换机制用于这些对象中的任何文本。

**Aspose 是否随库分发任何字体？**

不。您需要自行添加和使用字体，责任自负。

**缺失字体的替换/子stitution 与缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析流水线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/nodejs-java/font-replacement/)/[substitution](/slides/zh/nodejs-java/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。