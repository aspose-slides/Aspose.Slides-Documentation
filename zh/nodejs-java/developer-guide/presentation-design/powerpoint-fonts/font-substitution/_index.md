---
title: 字体替代 - PowerPoint JavaScript API
linktitle: 字体替代
type: docs
weight: 70
url: /zh/nodejs-java/font-substitution/
keywords: "字体, 替代字体, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中替换 PowerPoint 的字体"
---

## **设置字体替代规则**

Aspose.Slides 允许您设置字体规则，以确定在特定条件下（例如，无法访问字体时）应采取的操作，方法如下：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 添加替换规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 JavaScript 代码演示了字体替代过程：
```javascript
// 加载演示文稿
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 加载将被替换的源字体
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // 加载新字体
    var destFont = new aspose.slides.FontData("Arial");
    // 添加用于字体替换的字体规则
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // 将规则添加到字体替代规则集合
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // 将字体规则集合添加到规则列表
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // 当 SomeRareFont 无法访问时，将使用 Arial 字体代替
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 将图像以 JPEG 格式保存到磁盘
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

您可能想查看[**字体替换**](/slides/zh/nodejs-java/font-replacement/)。

{{% /alert %}}

## **常见问题**

**字体替换和字体替代有什么区别？**

[替换](/slides/zh/nodejs-java/font-replacement/) 是在整个演示文稿中将一种字体强制覆盖为另一种字体的做法。替代是当满足特定条件时触发的规则，例如原始字体不可用时，使用指定的后备字体。

**替代规则到底何时应用？**

这些规则参与标准的[字体选择](/slides/zh/nodejs-java/font-selection-sequence/)序列，在加载、渲染和转换过程中进行评估；如果所选字体不可用，则会应用替换或替代。

**如果未配置替换或替代且系统缺少该字体，默认行为是什么？**

库将尝试选择最接近的可用系统字体，类似于 PowerPoint 的行为。

**我可以在运行时附加自定义外部字体以避免替代吗？**

可以。您可以在运行时[添加外部字体](/slides/zh/nodejs-java/custom-font/)，使库在选择和渲染时考虑这些字体，包括后续的转换。

**Aspose 是否随库分发任何字体？**

不。Aspose 不会分发付费或免费字体；您需要自行添加和使用字体，需自行承担责任。

**在 Windows、Linux 和 macOS 上，替代行为是否存在差异？**

是的。字体发现从操作系统的字体目录开始。默认可用字体集合和搜索路径在各平台之间有所不同，这会影响可用性以及是否需要替代。

**在批量转换期间，如何准备环境以最小化意外的替代？**

在机器或容器之间同步字体集合，[添加外部字体](/slides/zh/nodejs-java/custom-font/)以满足输出文档的需求，并在可能的情况下[嵌入字体](/slides/zh/nodejs-java/embedded-font/)到演示文稿中，以确保渲染时可用所选字体。