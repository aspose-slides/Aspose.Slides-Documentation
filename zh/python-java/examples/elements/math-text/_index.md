---
title: 数学文本
type: docs
weight: 160
url: /zh/python-java/examples/elements/math-text/
keywords:
- 代码示例
- 数学文本
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Python via Java 的数学文本示例：在 PPT、PPTX 和 ODP 演示文稿中创建和格式化公式、分数、矩阵和符号。"
---
本文演示了如何使用 **Aspose.Slides for Python via Java** 处理数学文本形状并格式化公式。

按照[Installation](/slides/zh/python-java/installation/)中的说明安装此软件包。每个示例在启动 JVM 之前导入 `asposeslides`，然后在 JVM 运行后导入 API。

## **添加数学文本**

创建一个包含分数和勾股公式的数学形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 向幻灯片添加数学形状。
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # 访问数学段落。
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # 添加一个简单分数：x / y。
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # 添加公式：c² = a² + b²。
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **访问数学文本**

在幻灯片上定位包含数学段落的形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 添加一个可以在下面找到的数学形状。
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # 查找包含数学段落的第一个形状。
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # 示例：创建一个分数（此处未添加）。
        fraction = MathematicalText("x").divide("y")

        # 根据需要使用 math_paragraph 或 fraction。
finally:
    presentation.dispose()
```

## **移除数学文本**

从幻灯片中删除数学形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # 删除数学形状。
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **格式化数学文本**

为数学部分设置字体属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```