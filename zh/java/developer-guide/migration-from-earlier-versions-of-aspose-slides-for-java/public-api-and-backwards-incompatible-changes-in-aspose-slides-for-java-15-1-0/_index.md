---
title: Aspose.Slides for Java 15.1.0 的公共 API 和向后不兼容的更改
type: docs
weight: 100
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for Java 15.1.0 API 中添加的所有 [类](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)、方法、属性等，任何新限制和其他 [更改](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)。

{{% /alert %}} {{% alert color="primary" %}} 

某些图像项目符号和 WordArt 对象存在已知问题，将在 Aspose.Slides for Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 更改**
### **添加了字体替换功能**
增加了在整个演示文稿中全局替换字体和临时用于渲染的可能性。

介绍了 Presentation 类的新方法 getFontsManager()。FontsManager 类具有以下成员：

**IFontSubstRuleCollection getFontSubstRuleList**() 方法

这是一个 IFontSubstRule 实例的集合，用于在渲染期间替换字体。 IFontSubstRule 具有 getSourceFont() 和 getDestFont() 方法，实现了 IFontData 接口，并允许选择替换条件的 getReplaceFontCondition() 方法（“WhenInaccessible” 或 “Always”）。

**IFontData[] getFonts()** 方法可用于检索当前演示文稿中使用的所有字体。

**replaceFont(...)** 方法可用于持久性地替换演示文稿中的字体。

以下示例展示如何在演示文稿中替换字体：

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

另一个示例展示了在字体不可访问时的渲染字体替换：

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// 如果 SomeRareFont 不可用，将使用 Arial 字体

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```