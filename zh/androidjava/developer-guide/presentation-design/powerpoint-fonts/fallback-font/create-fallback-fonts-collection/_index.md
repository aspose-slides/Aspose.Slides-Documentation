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
description: "在 Aspose.Slides for Android 中通过 Java 设置回退字体集合，以保持 PowerPoint 和 OpenDocument 演示文稿中的文本一致且清晰。"
---

## **Apply Fallback Rules**

实例 [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) 类可以组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) 中，它实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) 接口。可以向集合中添加或删除规则。

然后可以将此集合分配给 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整个演示文稿中的字体。了解更多 [About FontsManager and FontsLoader](/slides/zh/androidjava/about-fontsmanager-and-fontsloader/)。

每个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) 方法，返回其自己的 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 实例。

下面是一个示例，演示如何创建回退字体规则集合并将其分配到特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) 中:  
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


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染过程中应用。

{{% alert color="primary" %}} 
了解更多如何 [Render Presentation with Fallback Font](/slides/zh/androidjava/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的 UI 中。

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

是的。这些对象中的任何文本都使用相同的字形替换机制。

**Does Aspose distribute any fonts with the library?**

不会。您需要自行添加和使用字体，责任自行承担。

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

可以。它们是同一字体解析管线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/androidjava/font-replacement/)/[substitution](/slides/zh/androidjava/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。