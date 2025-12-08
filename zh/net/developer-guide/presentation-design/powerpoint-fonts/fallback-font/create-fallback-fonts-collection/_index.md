---
title: 创建回退字体集合
type: docs
weight: 20
url: /zh/net/create-fallback-fonts-collection/
keywords: "回退字体集合, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint 中的回退字体集合，使用 C# 或 .NET"
---

## **应用回退规则**

可以将[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)类的实例组织到[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)中，该集合实现了[IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection)接口。可以在集合中添加或删除规则。

然后可以将此集合分配给[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager)类的[FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)属性。FontsManager 控制整个演示文稿中的字体。了解更多[About FontsManager and FontsLoader](/slides/zh/net/about-fontsmanager-and-fontsloader/)。

每个[Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)都有一个[FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)属性，拥有自身的 FontsManager 类实例。

以下示例演示如何创建回退字体规则集合并将其分配到特定演示文稿的 FontsManager 中：  
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
了解更多如何[Render Presentation with Fallback Font](/slides/zh/net/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退规则适用于 SmartArt、WordArt、图表和表格中的文本吗？**

是的。这些对象中的任何文本都使用相同的字形替换机制。

**Aspose 是否随库分发任何字体？**

不会。您需要自行添加和使用字体，责任自负。

**缺失字体的替换/替代和缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/net/font-replacement/)/[substitution](/slides/zh/net/font-substitution/)），然后回退填补可用字体中缺失字形的空白。