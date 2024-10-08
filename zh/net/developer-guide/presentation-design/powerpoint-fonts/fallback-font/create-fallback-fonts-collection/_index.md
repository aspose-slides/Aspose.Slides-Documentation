---
title: 创建备用字体集合
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "备用字体集合, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中的 PowerPoint 备用字体集合"
---

[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)类的实例可以组织成[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)，它实现了[IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection)接口。可以从集合中添加或删除规则。

然后，这个集合可以分配给[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager)类的[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)属性。FontsManager 控制整个演示文稿中的字体。有关更多信息，请阅读[关于 FontsManager 和 FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/)。

每个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)都有一个带有自身 FontsManager 实例的[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)属性。

以下是如何创建备用字体规则集合并将其分配给特定演示文稿的 FontsManager 的示例：

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

在 FontsManager 初始化备用字体集合后，备用字体将在演示文稿渲染时应用。

{{% alert color="primary" %}} 
阅读更多关于[使用备用字体渲染演示文稿](/slides/net/render-presentation-with-fallback-font/)的信息。
{{% /alert %}}