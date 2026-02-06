---
title: 数式テキスト
type: docs
weight: 160
url: /ja/python-net/examples/elements/math-text/
keywords:
- 数式テキスト
- 数式テキストの追加
- 数式テキストへのアクセス
- 数式テキストの削除
- 数式テキストの書式設定
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides を使用して数式テキストを操作します：方程式、分数、根号、スクリプトの作成と編集、書式設定、PPT および PPTX 用の結果のレンダリング。"
---
**Aspose.Slides for Python via .NET** を使用して、数式テキスト シェイプの操作と数式の書式設定を示します。

## **数式テキストの追加**

分数とピタゴラスの定理を含む数式シェイプを作成します。

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # スライドに数式シェイプを追加します。
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # 数式段落にアクセスします。
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # 簡単な分数を追加します: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # 方程式を追加します: c² = a² + b².
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

## **数式テキストへのアクセス**

スライド上で数式段落を含むシェイプを見つけます。

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 数式段落を含む最初のシェイプを見つけます。
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

## **数式テキストの削除**

スライドから数式シェイプを削除します。

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが数式テキストを含むシェイプであると想定します。
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **数式テキストの書式設定**

数式部分のフォント プロパティを設定します。

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが数式テキストを含むシェイプであると想定します。
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```