---
title: テキスト ボックス
type: docs
weight: 40
url: /ja/python-java/examples/elements/text-box/
keywords:
- コード例
- テキストボックス
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でテキスト ボックスを操作します。PowerPoint と OpenDocument のプレゼンテーションでテキストの追加、書式設定、検索、削除を行います。"
---
**Aspose.Slides for Python via Java** では、テキスト ボックスはテキストを含む自動図形です。ほぼすべての図形がテキストを含めますが、一般的なテキスト ボックスには塗りつぶしや枠線がなく、テキストのみが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、取得、削除する方法を説明します。

[Installation](/slides/ja/python-java/installation/) に記載された手順でパッケージをインストールします。各サンプルは JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **テキスト ボックスの追加**

矩形を作成し、塗りつぶしと枠線を削除し、書式設定されたテキストを割り当てます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 四角形の図形を作成します。
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # 塗りつぶしと枠線を削除してテキストのみを表示します。
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # デフォルトのテキスト書式を設定します。
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **内容でテキスト ボックスにアクセス**

サンプルのテキスト ボックスを追加し、テキストにキーワード「Slide」を含む図形を検索します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # 一致するテキストボックスを使用します。
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **内容でテキスト ボックスを削除**

最初のスライドで特定のキーワードを含むテキスト ボックスを検索し、削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
イテレーション中に図形コレクションを変更しないよう、削除する前に一致する図形を別のリストに集めてください。
{{% /alert %}}