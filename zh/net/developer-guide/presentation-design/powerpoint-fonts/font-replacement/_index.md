---
title: 字体替换 - PowerPoint C# API
linktitle: 字体替换
type: docs
weight: 60
url: /zh/net/font-replacement/
keywords: "字体, 替换字体, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: 使用 C# PowerPoint API，您可以在演示文稿中显式地将字体替换为另一种字体。
---

如果您改变了对某种字体的想法，可以用另一种字体替换它。旧字体的所有实例将被新字体替换。

Aspose.Slides 允许您以这种方式替换字体：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 替换字体。
5. 将修改后的演示文稿写为 PPTX 文件。

以下 C# 代码演示了字体替换：

```c#
// 加载演示文稿
Presentation presentation = new Presentation("Fonts.pptx");

// 加载将被替换的源字体
IFontData sourceFont = new FontData("Arial");

// 加载新字体
IFontData destFont = new FontData("Times New Roman");

// 替换字体
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// 保存演示文稿
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="注意" color="warning" %}} 

要设置在某些条件下（例如如果无法访问某个字体）发生的情况的规则，请参阅 [**字体替换**](/slides/zh/net/font-substitution/)。 

{{% /alert %}}