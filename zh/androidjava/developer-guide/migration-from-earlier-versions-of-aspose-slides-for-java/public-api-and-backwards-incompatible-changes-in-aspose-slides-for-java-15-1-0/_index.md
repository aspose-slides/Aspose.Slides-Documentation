---
title: Aspose.Slides for Java 15.1.0 的公共 API 和不兼容的变更
type: docs
weight: 100
url: /zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.1.0 API 中[添加](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)的类、方法、属性等，以及任何新的限制和其他[变更](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)。

{{% /alert %}} {{% alert color="primary" %}} 

一些图像项符号和 WordArt 对象存在已知问题，该问题将在 Aspose.Slides for Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 变更**
### **添加了字体替换功能**
添加了在整个演示文稿中全局替换字体和临时渲染的功能。

引入了 Presentation 类的新方法 getFontsManager()。FontsManager 类具有以下成员：

**IFontSubstRuleCollection getFontSubstRuleList**() 方法

这是在渲染过程中用于替换字体的 IFontSubstRule 实例的集合。 IFontSubstRule 有 getSourceFont() 和 getDestFont() 方法实现 IFontData 接口，并具有 getReplaceFontCondition() 方法，允许选择替换条件（"WhenInaccessible" 或 "Always"）。

**IFontData[] getFonts()** 方法可用于检索当前演示文稿中使用的所有字体。

**replaceFont(...)** 方法可用于持久性地替换演示文稿中的字体。 

以下示例演示了如何替换演示文稿中的字体：

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

另一个示例显示了在字体不可访问时进行渲染的字体替换：

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// 当 SomeRareFont 不可访问时，将使用 Arial 字体

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```