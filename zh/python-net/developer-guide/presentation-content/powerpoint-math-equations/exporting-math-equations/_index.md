---
title: 从 PowerPoint 演示文稿中导出数学公式（Python）
linktitle: 导出公式
type: docs
weight: 30
url: /zh/python-net/exporting-math-equations/
keywords:
- 导出数学公式
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 实现从 PowerPoint 到 MathML 的无缝导出——保持格式并提升兼容性。"
---

## **介绍**

Aspose.Slides for Python via .NET 允许您从演示文稿中导出数学公式。例如，您可能需要从特定幻灯片中提取公式并在其他程序或平台中重复使用。

{{% alert color="primary" %}}

您可以将公式导出为 MathML，这是一种在 Web 与众多应用中广泛使用的数学内容表示标准。

{{% /alert %}}

## **将数学公式保存为 MathML**

虽然人们可以轻松编写 LaTeX，但 MathML 通常由应用程序自动生成。由于 MathML 基于 XML，程序可以可靠地读取和解析它，因此它在许多领域被广泛用作输出和打印格式。

以下示例代码展示了如何将演示文稿中的数学公式导出为 MathML：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **常见问题**

**究竟是导出整个段落还是单个公式块为 MathML？**

您可以导出完整的数学段落（[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)）或单个公式块（[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)）为 MathML。两种类型均提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式位于 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 中，并且拥有一个 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 的图像或普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来源于哪里——是 PowerPoint 专有的还是标准的？**

导出目标是标准的 MathML（XML）。Aspose 使用的是 Presentation MathML——标准的呈现子集，已在众多应用和 Web 中得到广泛使用。

**是否支持导出表格、SmartArt、组合等内部的公式？**

支持。如果这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），则会被导出。如果公式以图像形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会更改演示文稿文件。