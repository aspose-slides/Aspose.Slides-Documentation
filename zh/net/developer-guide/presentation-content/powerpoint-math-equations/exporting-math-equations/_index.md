---
title: 导出数学公式
type: docs
weight: 30
url: /zh/net/exporting-math-equations/
keywords: "导出数学公式, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中导出 PowerPoint 数学公式"
---

## **简介**

Aspose.Slides for .NET 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片上的数学公式（来自特定的演示文稿），并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将公式导出为 MathML，这是一种在网络和众多应用程序中常见的数学公式及类似内容的流行格式或标准。

{{% /alert %}}

## **将数学公式保存为 MathML**

虽然人们可以轻松编写像 LaTeX 这样的公式格式代码，但编写 MathML 代码却比较困难，因为后者旨在由应用程序自动生成。程序可以轻松读取和解析 MathML，因为其代码采用 XML，因而 MathML 在许多领域常被用作输出和打印格式。

下面的示例代码演示了如何将演示文稿中的数学公式导出为 MathML：
```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```


## **FAQ**

**到底是导出段落还是单个公式块到 MathML？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)）导出为 MathML。两种类型都提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图片？**

公式位于[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)中，并且拥有一个[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)。没有[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)的图片和普通文本段落不是可导出的公式。

**演示文稿中的 MathML 来源于何处——是特定于 PowerPoint 还是标准？**

导出目标是标准 MathML（XML）。Aspose 使用 Presentation MathML——该标准的演示子集，已广泛在各种应用程序和网络中使用。

**是否支持导出位于表格、SmartArt、组合等中的公式？**

是的，如果这些对象包含带有[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)的文本段落（即真正的 PowerPoint 公式），则会被导出。如果公式以图片形式嵌入，则不会被导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。