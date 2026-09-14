---
title: Python에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드에서 이미지로
type: docs
weight: 35
url: /ko/python-java/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드를 이미지로 저장
- 슬라이드 EMF 변환
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PPT, PPTX 및 ODP 프레젠테이션의 슬라이드를 PNG, JPEG, GIF, TIFF, EMF 및 기타 이미지 형식으로 변환합니다."
---
## **소개**

Aspose.Slides for Python via Java는 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 PNG, JPEG, GIF, TIFF 등 다양한 이미지 형식으로 렌더링할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 렌더링하려는 슬라이드를 선택합니다.
3. 필요한 경우 [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/) 클래스로 렌더링을 구성합니다.
4. [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) 메서드를 호출합니다. 이 메서드는 이미지 객체를 반환합니다.
5. 이미지를 저장하고 [ImageFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imageformat/) 값을 사용하여 출력 형식을 지정합니다.

## **슬라이드를 PNG 이미지로 변환**

가장 간단한 변환은 기본 렌더링 설정을 사용합니다. 결과 이미지 객체는 메모리에서 처리하거나 파일로 저장할 수 있습니다.

다음 Python 예제는 첫 번째 슬라이드를 렌더링하고 PNG 이미지로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **맞춤 크기로 슬라이드를 이미지로 변환**

[Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) 오버로드를 사용하여 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 값을 전달하면 정확한 픽셀 크기로 슬라이드를 렌더링할 수 있습니다.

다음 예제는 1820 × 1040 JPEG 이미지를 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **노트 및 댓글이 포함된 슬라이드를 이미지로 변환**

기본적으로 슬라이드 이미지는 노트나 댓글을 포함하지 않습니다. [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/) 객체를 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 메서드에 전달하여 노트와 댓글이 표시되는 위치를 제어할 수 있습니다.

다음 예제는 잘린 노트를 슬라이드 아래에, 댓글을 오른쪽에 배치합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
슬라이드-이미지 변환 시, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 메서드에 [BottomFull](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/#BottomFull)을 전달하지 마십시오. 노트는 고정된 이미지 크기가 수용할 수 있는 텍스트보다 더 많을 수 있습니다. 대신 [BottomTruncated](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/#BottomTruncated)을 사용하세요.
{{% /alert %}}

## **TIFF 옵션을 사용하여 슬라이드를 이미지로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/) 클래스를 사용하면 렌더링된 TIFF 이미지의 크기, 해상도 및 기타 속성을 제어할 수 있습니다.

다음 예제는 첫 번째 슬라이드를 300 DPI에서 2160 × 2880 TIFF 이미지로 렌더링합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
TIFF 지원은 JDK 9 이전의 Java 버전에서는 보장되지 않습니다.
{{% /alert %}}

## **전체 슬라이드를 이미지로 변환**

슬라이드 컬렉션을 순회하여 전체 프레젠테이션을 일련의 이미지로 변환합니다. 명시적으로 건너뛰지 않는 한 숨겨진 슬라이드도 포함됩니다.

다음 예제는 모든 슬라이드를 가로 및 세로 배율 2로 JPEG 이미지로 렌더링합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **향상 메타파일 출력 생성**

Enhanced Metafile (EMF)은 벡터 기반 그래픽을 Microsoft Office 또는 Windows 메타파일을 지원하는 다른 Windows 애플리케이션과 교환해야 할 때 유용합니다. 픽셀 기반 이미지와 달리 EMF는 선명도 손실 없이 확장할 수 있는 벡터 그리기 작업을 보존합니다. 그러나 EMF는 주로 Windows 메타파일 지원 애플리케이션을 위한 호환성 형식이며, 보편적인 교환 형식은 아닙니다. 또한 비트맵 이미지 및 일부 효과와 같은 복잡한 슬라이드 콘텐츠는 벡터 메타파일 컨테이너 내부에 래스터화된 요소로 저장될 수 있습니다.

### **슬라이드를 EMF로 내보내기**

[Slide.writeAsEmf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 메서드는 [Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/)을 EMF 형식의 대상 스트림에 기록합니다. 다음 예제는 프레젠테이션을 로드하고, 첫 번째 슬라이드를 선택한 뒤, EMF 파일 스트림에 기록합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

위 호출에서 전달된 스트림은 호출자가 소유하며, 위와 같이 스트림을 닫는 책임도 호출자에게 있습니다.

### **SVG 이미지를 EMF로 변환하고 프레젠테이션에 추가하기**

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)을 사용하여 SVG 콘텐츠를 EMF로 변환합니다. 생성된 바이트는 [ImageCollection.addImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/#addImage)으로 프레젠테이션에 추가하고, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addPictureFrame)으로 슬라이드에 배치할 수 있습니다.

다음 예제는 SVG 마크업으로부터 [SvgImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)을 생성하고, 메모리 내 EMF로 변환한 뒤, 첫 번째 슬라이드에 메타파일을 삽입하고 프레젠테이션을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgimage/)은 대상 스트림의 소유권을 가져가지 않습니다. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html)은 모든 생성 데이터를 메모리에 저장하므로 [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--)를 호출하기 전에 위치 재설정이 필요하지 않습니다. 반환된 바이트 배열은 스트림이 닫힌 후에도 유효합니다.

EMF 생성은 선택한 Aspose.Slides for Python via Java 및 JDK 구성에서 지원되는 운영 체제에서 사용할 수 있지만, 폰트나 그래픽 종속성이 없을 경우 플랫폼마다 렌더링 결과가 달라질 수 있습니다. 소스 콘텐츠에서 사용하는 폰트를 설치하거나 적절한 대체 폰트를 구성하고, Aspose.Slides for Python via Java의 [플랫폼 요구 사항](/slides/ko/python-java/system-requirements/)을 따른 후 대상 EMF 소비 애플리케이션에서 결과를 검증하십시오. Linux 및 macOS 애플리케이션은 Windows 메타파일을 표시·편집하는 지원이 제한적이거나 일관되지 않을 수 있습니다.

## **컬러 이모지 렌더링**

{{% alert title="Note" color="info" %}}
프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되어 있어야 컬러 이모지를 올바르게 렌더링할 수 있습니다. 예를 들어 프레젠테이션이 **Segoe UI Emoji**를 사용하고 이 폰트가 없을 경우, 출력 이미지에서 이모지가 단색으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides는 애니메이션이 포함된 슬라이드 렌더링을 지원합니까?**

아니요. [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) 메서드는 슬라이드의 정적 이미지를 렌더링하며 애니메이션을 내보내지 않습니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있습니까?**

예. 숨겨진 슬라이드는 일반 슬라이드와 동일하게 렌더링할 수 있습니다. 위 예제와 같이 처리 루프에 포함시키면 됩니다.

**슬라이드 이미지에 그림자 및 기타 효과가 보존됩니까?**

예. Aspose.Slides는 슬라이드 이미지에 그림자, 투명도 및 기타 지원되는 그래픽 효과를 렌더링합니다.