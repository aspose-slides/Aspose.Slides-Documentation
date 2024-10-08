---
title: 字体替换 - PowerPoint Java API
linktitle: 字体替换
type: docs
weight: 70
url: /zh/java/font-substitution/
keywords: "字体, 替代字体, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中替代 PowerPoint 字体"
---

Aspose.Slides 允许您设置字体规则，以确定在某些条件下（例如，当无法访问某个字体时）必须执行的操作：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 添加替换规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 Java 代码演示了字体替换的过程：

```java
// 加载演示文稿
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 加载将被替换的源字体
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 加载新字体
    IFontData destFont = new FontData("Arial");
    
    // 添加用于字体替换的字体规则
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // 将规则添加到字体替代规则集合中
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // 将字体规则集合添加到规则列表中
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // 在 SomeRareFont 无法访问时，将使用 Arial 字体
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 将图像保存为 JPEG 格式到磁盘中
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="注意"  color="warning"   %}} 

您可能想查看 [**字体替换**](/slides/zh/java/font-replacement/)。 

{{% /alert %}}