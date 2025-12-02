---
title: 在 Python 中配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/python-net/create-fallback-fonts-collection/
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
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中设置回退字体集合，以确保 PowerPoint 和 OpenDocument 演示文稿中的文本保持一致且清晰。"
---

## **应用回退规则**

可以将 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类的实例组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) 中，该集合实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) 接口。可以在集合中添加或删除规则。

然后可以将此集合分配给 [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 属性，该属性位于 [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 类。FontsManager 控制整个演示文稿中的字体。了解更多 [关于 FontsManager 和 FontsLoader](/slides/zh/python-net/about-fontsmanager-and-fontsloader/)。

每个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 都有一个 [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 属性，它拥有自己的 FontsManager 类实例。

以下示例展示了如何创建回退字体规则集合并将其分配到特定演示文稿的 FontsManager 中：   ```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染期间生效。

{{% alert color="primary" %}} 
进一步了解如何 [Render Presentation with Fallback Font](/slides/zh/python-net/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退是否适用于 SmartArt、WordArt、图表和表格中的文本？**

是的。相同的字形替换机制用于这些对象中的所有文本。

**Aspose 是否随库分发任何字体？**

不会。字体需由您自行添加和使用，您自行负责。

**可以同时使用缺失字体的替换/替代和缺失字形的回退吗？**

可以。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/python-net/font-replacement/)/[substitution](/slides/zh/python-net/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。