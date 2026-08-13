---
title: "Aspose.Slides for Java 15.1.0 的公共 API 与向后不兼容的更改"
linktitle: "Aspose.Slides for Java 15.1.0"
type: docs
weight: 100
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，帮助您平稳迁移 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) 类、方法、属性等，所有新的限制以及其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)，这些都是在 Aspose.Slides for Java 15.1.0 API 中引入的。

{{% /alert %}} {{% alert color="info" %}} 

已知某些图像项目符号和 WordArt 对象存在问题，这些问题将在 Aspose.Slides for Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 更改**
### **已添加字体替换功能**
现在可以在整个演示文稿中全局替换字体，并在渲染时临时替换。

引入了 Presentation 类的新方法 getFontsManager()。FontsManager 类具有以下成员：

**IFontSubstRuleCollection getFontSubstRuleList**() 方法

这是在渲染期间用于替换字体的 IFontSubstRule 实例的集合。IFontSubstRule 具有实现 IFontData 接口的 getSourceFont() 和 getDestFont() 方法，以及允许选择替换条件（"WhenInaccessible" 或 "Always"）的 getReplaceFontCondition() 方法。

**IFontData[] getFonts()** 方法可用于检索当前演示文稿中使用的所有字体。

**replaceFont(...)** 方法可用于在演示文稿中持久替换字体。

以下示例演示了如何在演示文稿中替换字体：

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

另一个示例展示了在字体不可访问时进行渲染的字体替换：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // 当不可访问时，将使用 Arial 字体代替 SomeRareFont。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```