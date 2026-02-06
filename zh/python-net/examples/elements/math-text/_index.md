---
title: 数学文本
type: docs
weight: 160
url: /zh/python-net/examples/elements/math-text/
keywords:
- 数学文本
- 添加数学文本
- 访问数学文本
- 删除数学文本
- 格式化数学文本
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 处理数学文本：创建和编辑公式、分数、根式、上下标、格式，并渲染 PPT 和 PPTX 的结果。"
---
演示如何使用 **Aspose.Slides for Python via .NET** 处理数学文本形状并格式化公式。

## **添加数学文本**
创建包含分数和勾股公式的数学形状。

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 向幻灯片添加数学形状。
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # 访问数学段落。
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # 添加一个简单的分数：x / y。
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # 添加公式：c² = a² + b²。
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **访问数学文本**
在幻灯片上定位包含数学段落的形状。

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 查找包含数学段落的第一个形状。
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **删除数学文本**
从幻灯片中删除数学形状。

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是带有数学文本的形状。
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **格式化数学文本**
设置数学部分的字体属性。

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是带有数学文本的形状。
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```