---
title: 在 Android 上配置演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/androidjava/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在使用 Java 将 PowerPoint 和 OpenDocument 演示文稿转换为其他文件格式时，通过 Aspose.Slides for Android 实现最佳的字体替代。"
---

## **设置字体替代规则**

Aspose.Slides 允许您设置字体规则，以确定在特定条件下（例如，无法访问字体时）应采取的操作，方式如下：

1. 加载相关演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 为替换添加规则。
5. 将该规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 Java 代码演示了字体替代过程：
```java
// 加载演示文稿
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 加载要被替换的源字体
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 加载新字体
    IFontData destFont = new FontData("Arial");
    
    // 添加字体替换规则
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // 将规则添加到字体替换规则集合
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // 将字体规则集合添加到规则列表
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // 当 SomeRareFont 不可访问时，将使用 Arial 字体代替
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 将图像以 JPEG 格式保存到磁盘
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**Font Replacement**](/slides/zh/androidjava/font-replacement/)。
{{% /alert %}}

## **常见问题**

**字体替代（font replacement）和字体置换（font substitution）有什么区别？**

[Replacement](/slides/zh/androidjava/font-replacement/) 是在整个演示文稿中强制用另一个字体覆盖一个字体。Substitution 是在特定条件下触发的规则，例如原始字体不可用时，使用指定的回退字体。

**替代规则究竟何时生效？**

这些规则参与标准的[font selection](/slides/zh/androidjava/font-selection-sequence/)序列，该序列在加载、渲染和转换期间评估；如果所选字体不可用，则会应用替代或置换。

**如果未配置替代或置换且系统缺少该字体，默认行为是什么？**

库将尝试选择最接近的可用系统字体，类似于 PowerPoint 的行为。

**我可以在运行时附加自定义外部字体以避免置换吗？**

可以。您可以在运行时[add external fonts](/slides/zh/androidjava/custom-font/)，使库在选择和渲染时考虑这些字体，包括后续的转换。

**Aspose 是否随库分发任何字体？**

否。Aspose 不分发付费或免费字体；您自行添加和使用字体，需自行负责。

**在 Windows、Linux 和 macOS 上，置换行为是否存在差异？**

是的。字体发现从操作系统的字体目录开始。不同平台的默认可用字体集和搜索路径不同，这会影响可用性以及是否需要置换。

**如何准备环境以最大程度减少批量转换期间的意外置换？**

在机器或容器之间同步字体集，[add the external fonts](/slides/zh/androidjava/custom-font/)以满足输出文档的需求，并在可能的情况下在演示文稿中[embed fonts](/slides/zh/androidjava/embedded-font/)，确保渲染时可用所选字体。