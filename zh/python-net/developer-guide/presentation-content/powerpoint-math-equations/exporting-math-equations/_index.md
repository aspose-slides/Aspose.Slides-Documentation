---
title: 使用 Python 导出演示文稿中的数学公式
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
description: "通过 Aspose.Slides for Python via .NET，实现从 PowerPoint 无缝导出数学公式为 MathML，保持格式并提升兼容性。"
---

## **简介**

Aspose.Slides for Python via .NET 允许您从演示文稿中导出数学公式。例如，您可能需要从特定幻灯片中提取公式，并在其他程序或平台中重用它们。

{{% alert color="primary" %}}您可以将公式导出为 MathML，这是一种在 Web 和许多应用程序中广泛使用的数学内容表示标准。{{% /alert %}}

## **将数学公式保存为 MathML**

虽然人们可以轻松编写 LaTeX，但 MathML 通常由应用程序自动生成。由于 MathML 基于 XML，程序可以可靠地读取和解析它，因此它在多个领域被普遍用作输出和打印格式。

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

**究竟是导出 MathML 的段落还是单独的公式块？**

您可以导出整个数学段落([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/))或单独的块([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/))为 MathML。这两种类型都提供了写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文字或图片？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 中并拥有 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 的图片和普通文字段落不是可导出的公式。

**演示文稿中的 MathML 来源于 PowerPoint 特有还是标准？**

导出目标是标准 MathML（XML）。Aspose 使用的是 Presentation MathML——标准的演示子集，已在众多应用和 Web 中广泛使用。

**是否支持导出表格、SmartArt、组合等内的公式？**

是的，只要这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 的文字段落（即真实的 PowerPoint 公式），它们都会被导出。若公式以图片形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。