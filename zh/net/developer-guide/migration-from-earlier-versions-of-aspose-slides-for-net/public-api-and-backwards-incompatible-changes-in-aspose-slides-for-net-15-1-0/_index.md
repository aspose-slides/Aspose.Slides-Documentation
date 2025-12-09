---
title: Aspose.Slides for .NET 15.1.0 的公共 API 与向后不兼容更改
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 
此页面列出了所有已[添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)或已[移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 15.1.0 API 中引入的其他更改。
{{% /alert %}} 
## **Public API 更改**
#### **已添加字体替换功能**
已添加在整个演示文稿中全局替换字体以及在渲染时临时替换的功能。

在 Presentation 类中引入了新的属性 “FontsManager”。FontsManager 类具有以下成员：

属性 **IFontSubstRuleCollection FontSubstRuleList**  
此集合包含 IFontSubstRule 实例，用于在渲染期间替换字体。IFontSubstRule 拥有实现 IFontData 接口的 SourceFont 和 DestFont 属性，以及 ReplaceFontCondition 属性，可用于选择替换条件（“WhenInaccessible”或“Always”）。

方法 **IFontData[] GetFonts()**  
用于检索当前演示文稿中使用的所有字体。

方法 **ReplaceFont**  
用于在演示文稿中持久替换字体。

以下示例演示如何在演示文稿中替换字体：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

另一个示例演示在不可访问时用于渲染的字体替换：

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