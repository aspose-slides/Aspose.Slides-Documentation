---
title: 在 Android 上配置后备字体集合
linktitle: 后备字体集合
type: docs
weight: 20
url: /zh/androidjava/create-fallback-fonts-collection/
keywords:
- 后备字体
- 后备规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Android 中设置后备字体集合，以保持 PowerPoint 和 OpenDocument 演示文稿中的文本一致且清晰。"
---
## **概述**

Aspose.Slides 允许您为演示文稿配置一组后备字体规则。每个后备规则由 `FontFallBackRule` 类表示，并且可以添加到 `FontFallBackRulesCollection`，该集合实现了 `IFontFallBackRulesCollection` 接口。

创建集合后，您可以将其分配给演示文稿的 `FontsManager` 的 `FontFallBackRulesCollection` 属性。`FontsManager` 控制整个演示文稿的字体，每个 `Presentation` 实例都有其自己的 `FontsManager`。

一旦使用后备字体集合初始化 `FontsManager`，在演示文稿渲染期间将应用指定的后备字体。

## **应用后备规则**

可以将 [FontFallBackRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule) 类的实例组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRulesCollection) 中，该集合实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IFontFallBackRulesCollection) 接口。可以向集合中添加或删除规则。

然后可以将此集合分配给 [FontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整个演示文稿的字体。

每个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getFontsManager--) 方法，返回其自己的 [FontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontsManager) 实例。

以下示例演示如何创建后备字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getFontsManager--)：

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

在使用后备字体集合初始化 FontsManager 后，后备字体将在演示文稿渲染期间被应用。

{{% alert color="info" %}} 
了解更多关于如何 [Render Presentation with Fallback Font](/slides/zh/androidjava/render-presentation-with-fallback-font/) 的信息。 
{{% /alert %}}

## **常见问题**

### 我的后备规则会嵌入 PPTX 文件并在保存后在 PowerPoint 中可见吗？

不会。后备规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

### 后备机制是否适用于 SmartArt、WordArt、图表和表格中的文本？

是的。这些对象中的所有文本都使用相同的字形替换机制。

### Aspose 是否随库分发任何字体？

不会。字体需由您自行添加和使用，责任自负。

### 可以同时使用缺失字体的替换/替代和缺失字形的后备吗？

是的。它们是同一字体解析流水线中的独立阶段：首先，引擎解析字体可用性（[replacement](/slides/zh/androidjava/font-replacement/)/[substitution](/slides/zh/androidjava/font-substitution/)），然后后备机制为可用字体中缺失的字形填补空缺。