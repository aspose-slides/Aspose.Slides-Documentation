---
title: 數學文字
type: docs
weight: 160
url: /zh-hant/python-net/examples/elements/math-text/
keywords:
- 數學文字
- 新增數學文字
- 存取數學文字
- 移除數學文字
- 格式化數學文字
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 處理數學文字：建立與編輯方程式、分數、根號、上下標、格式設定，並為 PPT 與 PPTX 輸出結果。"
---
說明如何使用 **Aspose.Slides for Python via .NET** 處理數學文字形狀並格式化方程式。

## **新增數學文字**

建立一個包含分數與畢氏定理的數學形狀。

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增數學形狀至投影片。
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # 存取數學段落。
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # 新增簡單分數：x / y。
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # 新增方程式：c² = a² + b²。
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

## **存取數學文字**

在投影片上定位包含數學段落的形狀。

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 尋找第一個包含數學段落的形狀。
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

## **移除數學文字**

從投影片中刪除數學形狀。

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是包含數學文字的形狀。
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **格式化數學文字**

設定數學部分的字型屬性。

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是包含數學文字的形狀。
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```