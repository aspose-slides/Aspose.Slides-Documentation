---
title: 그림
type: docs
weight: 50
url: /ko/python-java/examples/elements/picture/
keywords:
- 코드 예제
- 그림
- 그림 추가
- 그림 액세스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 메모리에서 생성된 그림을 삽입하고 액세스합니다. PowerPoint 및 OpenDocument 프레젠테이션에 대한 예제가 포함됩니다."
---
이 문서에서는 **Aspose.Slides for Python via Java**를 사용하여 메모리 내 이미지에서 그림을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제에서는 메모리 내에 이미지를 생성하고 슬라이드에 배치한 다음 그림 프레임을 검색합니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 임포트하고, JVM이 실행된 후 API를 임포트합니다.

## **그림 추가**

이 코드는 작은 비트맵을 생성하고 이를 스트림으로 변환한 뒤 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

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

    # 간단한 메모리 내 이미지를 생성합니다.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # 비트맵을 바이트 배열로 변환합니다.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # 이미지를 프레젠테이션에 추가합니다.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그림 액세스**

이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 다음 찾아진 첫 번째 프레임에 접근합니다.

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