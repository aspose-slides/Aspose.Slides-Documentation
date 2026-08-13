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
description: "在 Aspose.Slides for Java 中设置回退字体集合，以在 PowerPoint 和 OpenDocument 演示文稿中保持文本一致且清晰。"
---
## **概述**

Aspose.Slides 允许您为演示文稿配置一组回退字体规则。每个回退规则由 `FontFallBackRule` 类表示，可添加到实现 `IFontFallBackRulesCollection` 接口的 `FontFallBackRulesCollection` 中。

创建集合后，您可以将其分配给演示文稿的 `FontsManager` 的 `FontFallBackRulesCollection` 属性。`FontsManager` 控制整个演示文稿的字体，每个 `Presentation` 实例都有自己的 `FontsManager`。

一旦 `FontsManager` 使用回退字体集合初始化，指定的回退字体将在演示文稿渲染期间生效。

## **应用回退规则**

可以将 [FontFallBackRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule) 类的实例组织到实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IFontFallBackRulesCollection) 接口的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRulesCollection) 中。可以向集合中添加或移除规则。

随后可以将该集合分配给 [FontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制整个演示文稿的字体。

每个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 都有一个返回其自身 [FontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsManager) 实例的 [getFontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getFontsManager--) 方法。

下面是创建回退字体规则集合并将其分配到特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getFontsManager--) 的示例：  

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

在 FontsManager 使用回退字体集合初始化后，回退字体将在演示文稿渲染期间生效。

{{% alert color="info" %}} 
了解更多关于[渲染演示文稿使用回退字体](/slides/zh/java/render-presentation-with-fallback-font/)的信息。
{{% /alert %}}

## **常见问答**

### 我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？

不会。回退规则是运行时渲染设置，不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

### 回退是否适用于 SmartArt、WordArt、图表和表格中的文本？

是的。相同的字形替换机制用于这些对象中的任何文本。

### Aspose 是否随库一起分发任何字体？

不会。您需要自行添加并使用字体，责任自负。

### 缺失字体的替换/替代和缺失字形的回退可以同时使用吗？

可以。它们是同一字体解析流水线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/java/font-replacement/)/[substitution](/slides/zh/java/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。