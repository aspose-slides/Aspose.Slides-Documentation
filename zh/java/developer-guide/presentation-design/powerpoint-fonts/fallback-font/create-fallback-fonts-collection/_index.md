---
title: 在 Java 中配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/java/create-fallback-fonts-collection/
keywords:
- 回退字体
- 回退规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中设置回退字体集合，以确保在 PowerPoint 和 OpenDocument 演示文稿中的文本保持一致且清晰。"
---

## **应用回退规则**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) interface. It is possible to add or remove rules from the collection.

可以将 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 类的实例组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) 中，该集合实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) 接口。可以向集合中添加或删除规则。

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/zh/java/about-fontsmanager-and-fontsloader/).

然后可以将此集合分配给 [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整个演示文稿中的字体。了解更多 [About FontsManager and FontsLoader](/slides/zh/java/about-fontsmanager-and-fontsloader/)。

Each [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) class.

每个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) 方法，拥有自己的 [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) 实例。

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) of a certain presentation:  
以下示例展示如何创建回退字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)：
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


After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

在用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
阅读更多关于如何 [Render Presentation with Fallback Font](/slides/zh/java/render-presentation-with-fallback-font/)。 
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的界面中。

**回退规则会应用于 SmartArt、WordArt、图表和表格中的文本吗？**

是的。这些对象中的任何文本都使用相同的字形替换机制。

**Aspose 是否随库分发任何字体？**

不会。字体由您自行添加和使用，风险自负。

**缺失字体的替换/替代和缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析管线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/java/font-replacement/)/[substitution](/slides/zh/java/font-substitution/)），随后回退为可用字体中的缺失字形填补空缺。