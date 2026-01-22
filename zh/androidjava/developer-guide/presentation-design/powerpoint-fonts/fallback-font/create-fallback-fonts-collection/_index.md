---
title: 在 Android 上配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/androidjava/create-fallback-fonts-collection/
keywords:
- 回退字体
- 回退规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Android 中设置回退字体集合，以确保在 PowerPoint 和 OpenDocument 演示文稿中的文字保持一致且清晰。"
---

## **应用回退规则**

可以将[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)类的实例组织到[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection)中，该集合实现了[IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection)接口。可以向集合中添加或删除规则。

然后可以将此集合分配给[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)类的[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection)方法。FontsManager 控制整个演示文稿中的字体。

每个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)都有一个[getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)方法，并拥有自己的[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)类实例。

下面示例演示如何创建回退字体规则集合并将其分配给特定演示文稿的[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)：
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


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染过程中生效。

{{% alert color="primary" %}} 
了解更多关于[Render Presentation with Fallback Font](/slides/zh/androidjava/render-presentation-with-fallback-font/)的内容。
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退规则会应用于 SmartArt、WordArt、图表和表格中的文本吗？**

会。这些对象中的所有文本都使用相同的字形替换机制。

**Aspose 是否随库分发任何字体？**

不会。字体需由您自行添加和使用，风险由您自行承担。

**缺失字体的替换/替代与缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析流水线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/androidjava/font-replacement/)/[substitution](/slides/zh/androidjava/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。