---
title: 用回退字体在 .NET 中呈现演示文稿
linktitle: 渲染演示文稿
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
description: "在 Aspose.Slides for .NET 中使用回退字体渲染演示文稿 – 通过逐步 C# 代码示例保持 PPT、PPTX 和 ODP 中的文本一致。"
---

以下示例包含以下步骤：

1. 我们 [创建回退字体规则集合](/slides/zh/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) 删除回退字体规则并将 [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 添加到另一个规则。
1. 将规则集合设置为 [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 属性。
1. 使用 [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) 方法我们可以以相同的格式保存演示文稿，或保存为其他格式。将回退字体规则集合设置到 FontsManager 后，这些规则会在对演示文稿的任何操作期间生效：保存、渲染、转换等。
```c#
// 创建规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 创建多个规则
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 尝试从已加载的规则中移除回退字体 "Tahoma"
	fallBackRule.Remove("Tahoma");

	// 并为指定范围更新规则
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// 也可以从列表中移除任何现有的规则
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

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


{{% alert color="primary" %}} 
了解更多关于[演示文稿的保存和转换](/slides/zh/net/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}