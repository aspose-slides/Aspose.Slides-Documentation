---
title: Aspose.Slides for .NET 15.1.0 中的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}}

此页面列出了所有[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 15.1.0 API 引入的其他更改。

{{% /alert %}}
## **Public API Chages**
#### **Fonts substitutions functinality has been added**
已添加在整个演示文稿中全局替换字体以及在渲染时临时替换的功能。

已在 Presentation 类中引入名为 "FontsManager" 的新属性。FontsManager 类包含以下成员：

**IFontSubstRuleCollection FontSubstRuleList** Property

该集合包含 IFontSubstRule 实例，用于在渲染时替换字体。IFontSubstRule 拥有实现 IFontData 接口的 SourceFont 和 DestFont 属性，以及 ReplaceFontCondition 属性，可选择替换条件（"WhenInaccessible" 或 "Always"）。

**IFontData[] GetFonts()** Method

用于检索当前演示文稿中使用的所有字体。

**ReplaceFont** Methods

用于在演示文稿中持久地替换字体。

以下示例演示了如何在演示文稿中替换字体：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

另一个示例演示在渲染时无法访问时的字体替换：

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial font will be used instead of SomeRareFont when inaccessible

            pres.Slides[0].GetThumbnail();

```