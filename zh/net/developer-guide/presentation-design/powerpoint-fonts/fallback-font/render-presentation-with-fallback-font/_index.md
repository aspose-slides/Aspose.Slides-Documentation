---
title: 使用后备字体在 .NET 中渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/net/render-presentation-with-fallback-font/
keywords:
- 后备字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用后备字体渲染演示文稿 — 通过一步一步的 C# 代码示例，保持 PPT、PPTX 和 ODP 文本的一致性。"
---

下面的示例包括以下步骤：

1. 我们[创建后备字体规则集合](/slides/zh/net/create-fallback-fonts-collection/)。
1. 使用[Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove)移除后备字体规则，并使用[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts)添加到另一个规则。
1. 将规则集合设置为[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)属性。
1. 使用[Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4)方法，我们可以将演示文稿保存为相同的格式，或保存为其他格式。在将后备字体规则集合设置到FontsManager后，这些规则会在对演示文稿的任何操作中生效：保存、渲染、转换等。
```c#
// 创建规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 尝试从已加载的规则中移除后备字体 "Tahoma"
	fallBackRule.Remove("Tahoma");

	// 并为指定范围更新规则
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// 我们也可以从列表中移除任何现有规则
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
阅读更多关于[演示文稿的保存和转换](/slides/zh/net/convert-powerpoint-to-png/)的信息。
{{% /alert %}}