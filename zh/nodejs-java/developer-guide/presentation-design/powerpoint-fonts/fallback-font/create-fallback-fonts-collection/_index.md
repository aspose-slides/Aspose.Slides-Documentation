---
title: 创建回退字体集合
type: docs
weight: 20
url: /zh/nodejs-java/create-fallback-fonts-collection/
---

## **应用回退规则**

FontFallBackRule 类的实例可以组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) 中，该集合实现了 [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) 类。可以向集合中添加或删除规则。

然后此集合可以分配给 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) 类的 FontFallBackRulesCollection 方法。FontsManager 控制整个演示文稿的字体。了解更多 [关于 FontsManager 和 FontsLoader](/slides/zh/nodejs-java/about-fontsmanager-and-fontsloader/)。

每个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) 方法，返回该演示文稿自己的 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) 实例。

下面是一个示例，演示如何创建回退字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--)： ```javascript
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


在 FontsManager 使用回退字体集合初始化后，回退字体将在演示文稿渲染期间生效。

{{% alert color="primary" %}} 
阅读更多关于如何 [渲染带有回退字体的演示文稿](/slides/zh/nodejs-java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退规则会应用于 SmartArt、WordArt、图表和表格中的文本吗？**

会。对这些对象中的任何文本都使用相同的字形替换机制。

**Aspose 是否随库分发任何字体？**

不会。您需要自行添加和使用字体，责任自负。

**缺失字体的替换/替代与缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[替换](/slides/zh/nodejs-java/font-replacement/)/[替代](/slides/zh/nodejs-java/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。