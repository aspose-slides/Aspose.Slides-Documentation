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
description: "通过 .NET 在 Aspose.Slides 中为 Python 设置回退字体集合，以确保 PowerPoint 和 OpenDocument 演示文稿中的文本保持一致且清晰。"
---

## **Apply Fallback Rules**

可以将 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类的实例组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) 中。可以向集合中添加或删除规则。

然后可以将此集合分配给 [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) 属性，属于 [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 类。FontsManager 控制整个演示文稿中的字体。

每个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 都有一个 [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) 属性，其中包含 FontsManager 类的实例。

以下示例展示如何创建回退字体规则集合并将其分配给特定演示文稿的 FontsManager：  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
了解更多关于如何[呈现带回退字体的演示文稿](/slides/zh/python-net/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **FAQ**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

否。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退规则会应用于 SmartArt、WordArt、图表和表格中的文本吗？**

是。相同的字形替换机制用于这些对象中的所有文本。

**Aspose 是否随库分发任何字体？**

否。您需要自行添加和使用字体，责任自负。

**缺失字体的 replacement/substitution 与缺失字形的 fallback 可以一起使用吗？**

是。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/python-net/font-replacement/)/[substitution](/slides/zh/python-net/font-substitution/)），然后 fallback 填补可用字体中缺失字形的空白。