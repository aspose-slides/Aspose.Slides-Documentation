---
title: 导出数学方程
type: docs
weight: 30
url: /python-net/exporting-math-equations/
keywords: "导出数学方程, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中导出 PowerPoint 数学方程"
---

Aspose.Slides for Python via .NET 允许您从演示文稿中导出数学方程。例如，您可能需要提取幻灯片上的数学方程（来自特定演示文稿），并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将方程导出为 MathML，这是一种流行的数学方程和类似内容的格式或标准，广泛应用于网络和许多应用程序中。

{{% /alert %}}

尽管人类可以轻松编写一些方程格式的代码，例如 LaTeX，但他们在编写 MathML 的代码时却会遇到困难，因为后者是自动由应用程序生成的。程序可以轻松读取和解析 MathML，因为其代码采用 XML 格式，因此 MathML 通常作为输出和打印格式在许多领域中使用。

以下示例代码演示如何将数学方程从演示文稿导出为 MathML：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_math_shape(0, 0, 500, 50)
    mathParagraph = autoShape.text_frame.paragraphs[0].portions[0].math_paragraph

    mathParagraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as stream:
        mathParagraph.write_as_math_ml(stream)
```