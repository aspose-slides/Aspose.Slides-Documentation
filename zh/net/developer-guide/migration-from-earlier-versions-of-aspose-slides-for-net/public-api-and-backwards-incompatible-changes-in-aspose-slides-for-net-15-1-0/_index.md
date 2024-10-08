---
title: Aspose.Slides for .NET 15.1.0 中的公共 API 和不兼容的变化
type: docs
weight: 130
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for .NET 15.1.0 API 中[添加的](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)或[移除的](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)类、方法、属性等，以及其他变化。

{{% /alert %}} 
## **公共 API 变化**
#### **添加了字体替换功能**
添加了在演示文稿中全局替换字体的可能性，并用于渲染的临时替代。

引入了演示文稿类的新属性 "FontsManager"。FontsManager 类具有以下成员：

**IFontSubstRuleCollection FontSubstRuleList** 属性

此集合由 IFontSubstRule 实例组成，用于在渲染过程中替换字体。IFontSubstRule 具有 SourceFont 和 DestFont 属性，接口实现 IFontData，并具有 ReplaceFontCondition 属性允许选择替换条件（"WhenInaccessible" 或 "Always"）。

**IFontData[] GetFonts()** 方法

用于检索当前演示文稿中使用的所有字体。

**ReplaceFont** 方法

用于在演示文稿中持久性替换字体。

以下示例演示了如何替换演示文稿中的字体：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

``` 

另一个示例演示了当字体不可访问时的渲染字体替换：

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // 当 SomeRareFont 不可访问时，将使用 Arial 字体

            pres.Slides[0].GetThumbnail();

``` 