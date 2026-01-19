---
title: 在 Python 中使用回退字体渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/python-net/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中使用回退字体渲染演示文稿——确保 PPT、PPTX 和 ODP 中的文本保持一致，提供逐步代码示例。"
---

以下示例包括以下步骤：

1. 我们[创建回退字体规则集合](/slides/zh/python-net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) 删除回退字体规则并[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) 添加到另一个规则。
1. 将规则集合设置为[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)属性。
1. 使用[Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)方法，我们可以在相同格式下保存演示文稿，或保存为其他格式。将回退字体规则集合设置到FontsManager后，这些规则将在对演示文稿的任何操作期间生效：保存、渲染、转换等。
```py
import aspose.slides as slides

# 创建规则集合的新实例
rulesList = slides.FontFallBackRulesCollection()

# 创建多个规则
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#尝试从已加载的规则中删除回退字体 "Tahoma"
	
	#并为指定范围更新规则
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#还可以从列表中删除任何现有的规则
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#为使用分配准备好的规则列表
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# 使用已初始化的规则集合渲染缩略图并保存为 PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```



{{% alert color="primary" %}} 
了解更多关于如何在 Python 中[将 PowerPoint 幻灯片转换为 PNG](/slides/zh/python-net/convert-powerpoint-to-png/)的信息。
{{% /alert %}}