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
description: "在 Aspose.Slides for Java 中设置回退字体集合，以保持 PowerPoint 和 OpenDocument 演示文稿中的文本一致且清晰。"
---

## **应用回退规则**

[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 类的实例可以组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) 中，该集合实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) 接口。可以在集合中添加或删除规则。

然后此集合可以分配给 [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整个演示文稿中的字体。

每个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) 方法，返回其自己的 [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) 类实例。

下面是一个示例，演示如何创建回退字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)：
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


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
阅读更多关于如何[渲染演示文稿时使用回退字体](/slides/zh/java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

**我的回退规则会被嵌入到 PPTX 文件中，并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的界面中。

**回退是否适用于 SmartArt、WordArt、图表和表格中的文本？**

会。相同的字形替换机制用于这些对象中的所有文本。

**Aspose 是否随库一起分发任何字体？**

不会。您需要自行添加和使用字体，责任自负。

**缺失字体的替换/替代和缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[替换](/slides/zh/java/font-replacement/)/[替代](/slides/zh/java/font-substitution/)），随后回退为可用字体中的缺失字形填补空白。