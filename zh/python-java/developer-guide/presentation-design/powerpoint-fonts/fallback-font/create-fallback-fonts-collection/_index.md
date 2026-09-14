---
title: 通过 Java 在 Python 中配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/python-java/create-fallback-fonts-collection/
keywords:
- 回退字体
- 回退规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides 中为 Python via Java 设置回退字体集合，以确保 PowerPoint 和 OpenDocument 演示文稿中的文本保持一致且清晰。"
---
## **概述**

Aspose.Slides 允许您为演示文稿配置一组回退字体规则。每个回退规则由 [FontFallBackRule](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontfallbackrule/) 类表示，并且可以添加到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontfallbackrulescollection/) 中。

创建集合后，您可以使用演示文稿的 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 的 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 方法将其分配。[FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 控制整个演示文稿的字体，每个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例都有它自己的 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)。

一旦使用回退字体集合初始化了 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)，在演示文稿渲染期间会应用指定的回退字体。

## **应用回退规则**

[FontFallBackRule](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontfallbackrule/) 类的实例可以组织成一个 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontfallbackrulescollection/)。您可以向该集合添加或删除规则。

然后可以使用 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 类的 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 方法将此集合分配，它控制整个演示文稿的字体。

每个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 都有一个 [getFontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getFontsManager) 方法，返回其自己的 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 实例。

下面的示例展示了如何创建回退字体规则集合并将其分配给演示文稿的 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

在使用回退字体集合初始化 [FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 后，回退字体将在演示文稿渲染期间被应用。

{{% alert color="info" title="Note" %}}
了解更多关于如何[使用回退字体渲染演示文稿](/slides/zh/python-java/render-presentation-with-fallback-font/)的信息。
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的 UI 中。

**回退规则会应用于 SmartArt、WordArt、图表和表格中的文本吗？**

会。相同的字形替换机制用于这些对象中的任何文本。

**Aspose 会随库分发任何字体吗？**

不会。您需要自行添加和使用字体，并自行负责。

**可以同时使用缺失字体的替换/替换和缺失字形的回退吗？**

可以。它们是同一字体解析管线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/python-java/font-replacement/)/[substitution](/slides/zh/python-java/font-substitution/)），然后回退为可用字体中缺失的字形填补空白。