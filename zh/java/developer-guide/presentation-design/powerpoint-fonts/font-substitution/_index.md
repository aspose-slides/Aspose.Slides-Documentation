---
title: 使用 Java 在演示文稿中配置字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/java/font-substitution/
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
- Java
- Aspose.Slides
description: "在将 PowerPoint 与 OpenDocument 演示文稿转换为其他文件格式时，启用 Aspose.Slides for Java 的最佳字体替代。"
---

## **设置字体替换规则**

Aspose.Slides 允许您设置字体规则，以确定在特定条件下（例如，当无法访问字体时）应该执行的操作，方式如下：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新的字体。
4. 为替换添加规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

下面的 Java 代码演示了字体替换过程：
```java
// 加载演示文稿
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 加载将被替换的源字体
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
    
    // 当原字体不可访问时，将使用 Arial 替代 SomeRareFont
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
您可能想查看[**字体替换**](/slides/zh/java/font-replacement/)。 
{{% /alert %}}

## **常见问题**

**字体替换和字体替代有什么区别？**

[替换](/slides/zh/java/font-replacement/) 是在整个演示文稿中强制用另一种字体覆盖原字体的操作。替代是一条在特定条件下触发的规则，例如当原始字体不可用时，会使用指定的回退字体。

**替代规则到底何时生效？**

这些规则参与标准的[字体选择](/slides/zh/java/font-selection-sequence/)序列，在加载、渲染和转换过程中进行评估；如果选定的字体不可用，则会应用替换或替代。

**如果系统缺少字体且未配置替换或替代，默认行为是什么？**

库会尝试选取最接近的可用系统字体，类似于 PowerPoint 的行为。

**我可以在运行时附加自定义外部字体以避免替代吗？**

可以。您可以在运行时[添加外部字体](/slides/zh/java/custom-font/)，库会将其纳入选择和渲染的范围，包括后续的转换。

**Aspose 是否随库分发任何字体？**

否。Aspose 不会分发付费或免费字体；您需自行添加和使用字体，承担相应责任。

**在 Windows、Linux 和 macOS 上的替代行为是否有差异？**

有。字体发现从操作系统的字体目录开始。不同平台的默认可用字体集合和搜索路径各不相同，这会影响字体的可用性以及是否需要替代。

**如何准备环境以在批量转换时最小化意外的替代？**

在机器或容器之间同步字体集，[添加外部字体](/slides/zh/java/custom-font/)以满足输出文档的需求，并在可能的情况下在演示文稿中[嵌入字体](/slides/zh/java/embedded-font/)，以确保在渲染时可用所选字体。