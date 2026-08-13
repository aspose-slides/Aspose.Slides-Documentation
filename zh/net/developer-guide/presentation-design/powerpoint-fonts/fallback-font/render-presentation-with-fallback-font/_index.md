---
title: 在 .NET 中使用回退字体呈现演示文稿
linktitle: 呈现演示文稿
type: docs
weight: 30
url: /zh/net/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用回退字体呈现演示文稿 - 通过一步一步的 C# 代码示例保持 PPT、PPTX 和 ODP 文本的一致性。"
---
## **概述**

Aspose.Slides 允许您使用回退字体规则渲染演示文稿。本文展示如何创建回退字体规则集合、通过删除或添加回退字体来修改其规则，以及将该集合分配给 `FontsManager.FontFallBackRulesCollection` 属性。

一旦将回退字体规则集合分配给演示文稿的 `FontsManager`，这些规则将在保存、渲染和转换演示文稿等操作期间生效。示例演示了在渲染幻灯片缩略图并将其保存为 PNG 图像时如何使用配置好的规则。

## **使用回退字体规则渲染幻灯片**

以下示例包括这些步骤：

1. 我们[创建回退字体规则集合](/slides/zh/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/zh/net/aspose.slides/fontfallbackrule/methods/remove) 删除一个回退字体规则，并[AddFallBackFonts()](https://reference.aspose.com/slides/zh/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 添加到另一个规则。
1. 将规则集合设置为[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 属性。
1. 使用[Presentation.Save()](https://reference.aspose.com/slides/zh/net/aspose.slides.presentation/save/methods/4) 方法，我们可以以相同格式保存演示文稿，或保存为其他格式。将回退字体规则集合设置到 FontsManager 后，这些规则将在对演示文稿的任何操作期间生效：保存、渲染、转换等。

```c#
using Aspose.Slides;

// 创建规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 创建多个规则
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 尝试从已加载的规则中移除回退字体 "Tahoma"
	fallBackRule.Remove("Tahoma");

	// 并为指定范围更新规则
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// 同时我们可以从列表中移除任何现有规则，保留至少一个用于渲染的规则
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 为使用分配准备好的规则列表
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 使用已初始化的规则集合渲染缩略图并保存为 PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
阅读更多关于[在演示文稿中保存和转换](/slides/zh/net/convert-powerpoint-to-png/)的内容。 
{{% /alert %}}