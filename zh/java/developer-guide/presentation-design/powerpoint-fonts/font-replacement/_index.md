---
title: 字体替换 - PowerPoint Java API
linktitle: 字体替换
type: docs
weight: 60
url: /java/font-replacement/
description: 学习如何使用 Java API 在 PowerPoint 中使用显式替换方法替换字体。
---

如果您改变了对使用某种字体的看法，可以用另一种字体替换该字体。所有旧字体的实例将被新字体替换。

Aspose.Slides 允许您以这种方式替换字体：

1. 加载相关演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 替换字体。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了字体替换：

```java
// 加载演示文稿
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 加载将被替换的源字体
    IFontData sourceFont = new FontData("Arial");
    
    // 加载新字体
    IFontData destFont = new FontData("Times New Roman");
    
    // 替换字体
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // 保存演示文稿
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

要设置在某些条件下（例如，当无法访问某种字体时）将发生的情况的规则，请参阅 [**字体替代**](/slides/java/font-substitution/)。 

{{% /alert %}}