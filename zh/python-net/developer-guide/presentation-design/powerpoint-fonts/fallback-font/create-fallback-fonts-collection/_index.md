---
title: 创建后备字体集合
type: docs
weight: 20
url: /python-net/create-fallback-fonts-collection/
keywords: "后备字体集合, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中 PowerPoint 的后备字体集合"
---

[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类的实例可以组织成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)，它实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) 接口。可以从集合中添加或删除规则。

然后，这个集合可以被分配给 [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 属性。FontsManager 控制演示文稿中的字体。阅读更多 [有关 FontsManager 和 FontsLoader](/slides/python-net/about-fontsmanager-and-fontsloader/)。

每个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 都有一个具有其自身 FontsManager 实例的 [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 属性。

以下是如何创建后备字体规则集合并将其分配到特定演示文稿的 FontsManager 的示例：  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

在 FontsManager 用后备字体集合初始化后，后备字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
阅读更多关于如何 [使用后备字体渲染演示文稿](/slides/python-net/render-presentation-with-fallback-font/) 的信息。
{{% /alert %}}