---
title: 使用后备字体渲染演示文稿
type: docs
weight: 30
url: /zh/python-net/render-presentation-with-fallback-font/
keywords: "后备字体, 渲染 PowerPoint, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中使用后备字体渲染 PowerPoint"
---

以下示例包括以下步骤：

1. 我们 [创建后备字体规则集合](/slides/zh/python-net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) 一个后备字体规则并 [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) 到另一个规则。
1. 将规则集合设置为 [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 属性。
1. 使用 [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法，我们可以以相同格式保存演示文稿，或以其他格式保存。当后备字体规则集合设置给 FontsManager 后，这些规则在对演示文稿进行任何操作时都会应用：保存、渲染、转换等。

```py
import aspose.slides as slides

# 创建规则集合的新实例
rulesList = slides.FontFallBackRulesCollection()

# 创建多个规则
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# 尝试从加载的规则中移除后备字体 "Tahoma"
	fallBackRule.remove("Tahoma")

	# 并更新指定范围的规则
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# 我们还可以从列表中移除任何现有规则
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# 分配准备好的规则列表以供使用
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# 使用初始化的规则集合渲染缩略图并保存为 PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
了解更多关于 [演示文稿中的保存和转换](/slides/zh/python-net/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}