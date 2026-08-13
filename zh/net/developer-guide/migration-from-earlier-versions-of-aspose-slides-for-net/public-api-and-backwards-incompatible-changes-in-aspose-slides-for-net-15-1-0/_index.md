---
title: Aspose.Slides for .NET 15.1.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有已添加[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 或 [已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 的类、方法、属性等，以及 Aspose.Slides for .NET 15.1.0 API 引入的其他更改。

{{% /alert %}} 
## **Public API 更改**
#### **已添加字体替换功能**
已添加在整个演示文稿中全局替换字体以及在渲染时临时替换的功能。

在 Presentation 类中引入了新属性 "FontsManager"。FontsManager 类包含以下成员：

**IFontSubstRuleCollection FontSubstRuleList** Property

此集合包含用于在渲染期间替换字体的 IFontSubstRule 实例。IFontSubstRule 拥有实现 IFontData 接口的 SourceFont 和 DestFont 属性，以及 ReplaceFontCondition 属性，可用于选择替换条件（"WhenInaccessible" 或 "Always"）。

**IFontData[] GetFonts()** Method

用于检索当前演示文稿中使用的所有字体。

**ReplaceFont** Methods

用于在演示文稿中持久替换字体。

以下示例展示了如何在演示文稿中替换字体：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

另一个示例演示了在字体不可用时的渲染替换：

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // 当某些罕见字体不可用时，将使用 Arial 字体

            pres.Slides[0].GetImage();

```