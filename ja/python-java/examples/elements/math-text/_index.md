---
title: 数式テキスト
type: docs
weight: 160
url: /ja/python-java/examples/elements/math-text/
keywords:
- コード例
- 数式テキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java の数式テキスト例を確認し、PPT、PPTX、ODP プレゼンテーションで方程式、分数、行列、記号の作成と書式設定を行います。"
---
この記事では、**Aspose.Slides for Python via Java** を使用した数式テキスト シェイプの操作および方程式の書式設定について示します。

パッケージは、[Installation](/slides/ja/python-java/installation/) に記載された手順に従ってインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **数式テキストの追加**

分数とピタゴラスの定理を含む数式シェイプを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # スライドに数式シェイプを追加します。
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # 数式段落にアクセスします。
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # 単純な分数を追加します: x / y。
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # 方程式を追加します: c² = a² + b²。
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **数式テキストへのアクセス**

スライド上で数式段落を含むシェイプを見つけます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 以下に見つけられる数式シェイプを追加します。
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # 数式段落を含む最初のシェイプを検索します。
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

        # 例: 分数を作成します（ここでは追加しません）。
        fraction = MathematicalText("x").divide("y")

        # 必要に応じて math_paragraph または fraction を使用します。
finally:
    presentation.dispose()
```

## **数式テキストの削除**

スライドから数式シェイプを削除します。

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

    # 数式シェイプを削除します。
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **数式テキストの書式設定**

数式部分のフォント プロパティを設定します。

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