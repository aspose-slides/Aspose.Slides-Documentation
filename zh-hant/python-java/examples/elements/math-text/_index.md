---
title: 數學文字
type: docs
weight: 160
url: /zh-hant/python-java/examples/elements/math-text/
keywords:
- 程式碼範例
- 數學文字
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Python via Java 的數學文字範例：在 PPT、PPTX 與 ODP 簡報中建立與格式化方程式、分數、矩陣與符號。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 來操作數學文字形狀並格式化方程式。

如同 [Installation](/slides/zh-hant/python-java/installation/) 所述安裝套件。每個範例皆於啟動 JVM 前匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

## **新增數學文字**

建立包含分數與畢氏定理公式的數學圖形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增數學圖形至投影片。
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # 存取數學段落。
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # 新增簡單分數：x / y。
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # 新增方程式：c² = a² + b²。
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **存取數學文字**

在投影片上定位包含數學段落的圖形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增可於下方找到的數學圖形。
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # 尋找第一個包含數學段落的圖形。
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

        # 範例：建立分數（此處未加入）。
        fraction = MathematicalText("x").divide("y")

        # 視需求使用 math_paragraph 或 fraction。
finally:
    presentation.dispose()
```

## **移除數學文字**

從投影片中刪除數學圖形。

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

    # 移除數學圖形。
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **格式化數學文字**

設定數學區塊的字型屬性。

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