---
title: 使用后备字体渲染演示文稿
type: docs
weight: 30
url: /net/render-presentation-with-fallback-font/
keywords: 
- 后备字体
- 渲染 PowerPoint
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "使用 C# 或 .NET 渲染带有后备字体的 PowerPoint"
---

以下示例包括这些步骤：

1. 我们[创建后备字体规则集合](/slides/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) 移除一个后备字体规则，并[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 添加到另一个规则。
1. 将规则集合设置为[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)属性。
1. 使用[Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4)方法，我们可以以相同格式保存演示文稿，或保存为另一种格式。在将后备字体规则集合设置为 FontsManager 后，这些规则在对演示文稿的任何操作中都会应用：保存、渲染、转换等。

```c#
// 创建规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 创建若干规则
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//尝试从加载的规则中移除后备字体 "Tahoma"
	fallBackRule.Remove("Tahoma");

	//并更新指定范围的规则
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//我们也可以从列表中移除任何现有规则
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //分配准备好的规则列表以供使用
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 使用初始化的规则集合渲染缩略图并保存为 PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
了解更多关于[演示文稿中的保存与转换](/slides/net/creating-saving-and-converting-a-presentation/)的信息。
{{% /alert %}}