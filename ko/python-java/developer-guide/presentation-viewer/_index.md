---
title: Python via Java에서 프레젠테이션 뷰어 만들기
linktitle: 프레젠테이션 뷰어
type: docs
weight: 50
url: /ko/python-java/presentation-viewer/
keywords:
- 프레젠테이션 보기
- 프레젠테이션 뷰어
- 프레젠테이션 뷰어 만들기
- PPT 보기
- PPTX 보기
- ODP 보기
- 파워포인트
- 오픈문서
- 프레젠테이션
- 파이썬
- 자바
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java에서 맞춤형 프레젠테이션 뷰어를 만들고, Microsoft PowerPoint 없이도 PowerPoint 및 OpenDocument 파일을 쉽게 표시합니다."
---
## **소개**

Aspose.Slides for Python via Java는 슬라이드가 포함된 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 예를 들어 Microsoft PowerPoint에서 프레젠테이션을 열어 볼 수 있습니다. 그러나 때때로 개발자는 선호하는 이미지 뷰어에서 슬라이드를 이미지로 보거나 자체 프레젠테이션 뷰어를 만들 필요가 있을 수 있습니다. 이런 경우 Aspose.Slides를 사용하면 개별 슬라이드를 이미지로 내보낼 수 있습니다. 이 문서에서는 그 방법을 설명합니다.

## **슬라이드에서 SVG 이미지 생성**

Aspose.Slides를 사용하여 프레젠테이션 슬라이드에서 SVG 이미지를 생성하려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 바이트 스트림을 엽니다.
1. 슬라이드를 SVG 이미지로 스트림에 저장하고 파일에 씁니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **맞춤형 도형 ID로 SVG 생성**

Aspose.Slides를 사용하면 맞춤형 도형 ID를 가진 슬라이드에서 [SVG](https://docs.fileformat.com/page-description-language/svg/) 를 생성할 수 있습니다. 이를 위해서는 [SvgShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgshape/) 의 [SvgShape.setId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgshape/#setId) 메서드를 사용합니다. `CustomSvgShapeFormattingController`를 사용하여 도형 ID를 설정할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **슬라이드 썸네일 이미지 생성**

Aspose.Slides를 사용하면 슬라이드의 썸네일 이미지를 생성할 수 있습니다. Aspose.Slides를 사용하여 슬라이드의 썸네일을 생성하려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 비율로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **사용자 정의 크기로 슬라이드 썸네일 생성**

사용자 정의 크기로 슬라이드 썸네일 이미지를 생성하려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 크기로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **스피커 노트가 포함된 슬라이드 썸네일 생성**

Aspose.Slides를 사용하여 스피커 노트가 포함된 슬라이드의 썸네일을 생성하려면 아래 단계에 따라 주세요:

1. [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/) 클래스의 인스턴스를 생성합니다.
1. [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 메서드를 사용하여 스피커 노트 위치를 설정합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 렌더링 옵션을 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **실시간 예제**

Aspose.Slides API로 구현할 수 있는 내용을 확인하려면 무료 앱인 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ko/viewer/)를 사용해 볼 수 있습니다:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**웹 애플리케이션에 프레젠테이션 뷰어를 삽입할 수 있나요?**

예. 서버 측에서 Aspose.Slides를 사용하여 슬라이드를 이미지나 HTML로 렌더링하고 브라우저에 표시할 수 있습니다. 탐색 및 확대/축소 기능은 JavaScript로 구현하여 인터랙티브한 경험을 제공할 수 있습니다.

**맞춤형 뷰어 안에서 슬라이드를 표시하는 가장 좋은 방법은 무엇인가요?**

권장 방법은 각 슬라이드를 이미지(PNG 또는 SVG 등)로 렌더링하거나 Aspose.Slides를 사용해 HTML로 변환한 다음, 데스크톱의 경우 사진 상자에, 웹의 경우 HTML 컨테이너에 출력물을 표시하는 것입니다.

**많은 슬라이드가 있는 대용량 프레젠테이션을 어떻게 처리하나요?**

대용량 프레젠테이션의 경우 슬라이드의 지연 로드 또는 필요 시 렌더링을 고려하세요. 이는 사용자가 슬라이드로 이동할 때 해당 슬라이드의 내용을 생성함으로써 메모리 사용량과 로드 시간을 줄이는 방법입니다.