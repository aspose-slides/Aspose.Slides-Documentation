---
title: Aspose.Slides for PHP via Java 15.1.0 的公共 API 和向后不兼容的更改
type: docs
weight: 100
url: /zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

该页面列出了所有在 Aspose.Slides for PHP via Java 15.1.0 API 中添加的 [添加](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) 类、方法、属性等，新限制及其他 [更改](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)。

{{% /alert %}} {{% alert color="primary" %}} 

某些图像项目符号和艺术字对象存在已知问题，这将在 Aspose.Slides for PHP via Java 15.2.0 中修复。

{{% /alert %}} 
## **公共 API 更改**
### **已添加字体替换功能**
已添加全球替换演示文稿中的字体和临时渲染字体的功能。

引入了 Presentation 类的新方法 getFontsManager()。FontsManager 类具有以下成员：

**IFontSubstRuleCollection getFontSubstRuleList**() 方法

这是在渲染过程中用于替换字体的 IFontSubstRule 实例的集合。 IFontSubstRule 具有 getSourceFont() 和 getDestFont() 方法，实现了 IFontData 接口，并且有 getReplaceFontCondition() 方法，允许选择替换条件（"WhenInaccessible" 或 "Always"）。

**IFontData[] getFonts()** 方法可用于检索当前演示文稿中使用的所有字体。

**replaceFont(...)** 方法可用于持久替换演示文稿中的字体。 

以下示例演示如何在演示文稿中替换字体：

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);
```

另一个示例展示了在字体不可访问时的渲染字体替换：

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # 当 SomeRareFont 不可访问时，将使用 Arial 字体
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);
```