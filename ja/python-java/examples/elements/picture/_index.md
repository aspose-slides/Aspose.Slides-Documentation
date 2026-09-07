---
title: 画像
type: docs
weight: 50
url: /ja/python-java/examples/elements/picture/
keywords:
- コード例
- 画像
- 画像の追加
- 画像の取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してメモリ内で作成された画像を挿入および取得し、PowerPoint と OpenDocument のプレゼンテーションの例を示します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して、メモリ内画像から画像を挿入および取得する方法を示します。以下の例では、メモリ内に画像を作成し、スライドに配置してから、ピクチャフレームを取得します。

パッケージは[Installation](/slides/ja/python-java/installation/) に記載された手順でインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **画像の追加**

このコードは小さなビットマップを生成し、ストリームに変換して、最初のスライドにピクチャフレームとして挿入します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # シンプルなインメモリ画像を作成します。
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # ビットマップをバイト配列に変換します。
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # 画像をプレゼンテーションに追加します。
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # 最初のスライドに画像を表示するピクチャフレームを挿入します。
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **画像の取得**

この例では、スライドにピクチャフレームが含まれていることを確認し、見つかった最初のフレームにアクセスします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import PictureFrame, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bitmap = BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB)
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image)

    picture_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is None:
        print("The slide contains no picture frames.")
finally:
    presentation.dispose()
```