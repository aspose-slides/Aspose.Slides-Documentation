---
title: 导出数学方程
type: docs
weight: 30
url: /zh/net/exporting-math-equations/
keywords: "导出数学方程, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中导出 PowerPoint 数学方程"
---

Aspose.Slides for .NET 允许您从演示文稿中导出数学方程。例如，您可能需要提取特定演示文稿中幻灯片的数学方程，并在另一个程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将方程导出为 MathML，这是一种流行的数学方程和类似内容的格式或标准，可在许多应用程序和网站上看到。 

{{% /alert %}}

虽然人类可以轻松编写某些方程格式（如 LaTeX）的代码，但在编写 MathML 的代码时却会遇到困难，因为后者旨在由应用程序自动生成。程序可以轻松读取和解析 MathML，因为它的代码是 XML 格式，因此 MathML 在许多领域被普遍用作输出和打印格式。

以下示例代码演示了如何将演示文稿中的数学方程导出为 MathML：

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