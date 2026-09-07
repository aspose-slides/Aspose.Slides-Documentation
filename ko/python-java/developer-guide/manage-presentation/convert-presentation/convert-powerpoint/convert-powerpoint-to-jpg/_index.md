---
title: Python에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로
type: docs
weight: 60
url: /ko/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PowerPoint를 JPG로
- PPT를 JPG로
- PPTX를 JPG로
- 슬라이드를 JPG로 저장
- PPT를 JPG로 내보내기
- PPTX를 JPG로 내보내기
- Python
- Java
- Aspose.Slides
description: "Python via Java를 사용하여 PowerPoint(PPT, PPTX) 슬라이드를 JPG 이미지로 변환합니다. 사용자 지정 이미지 크기를 설정하고 Aspose.Slides로 노트와 주석을 렌더링합니다."
---
## **소개**

Aspose.Slides for Python via Java를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 JPEG 이미지로 변환할 수 있습니다. 모든 슬라이드 또는 선택한 슬라이드를 내보내어 썸네일을 만들거나 프레젠테이션 뷰어를 구축하거나 웹사이트 또는 애플리케이션에 슬라이드 미리보기를 삽입할 수 있습니다.

## **PowerPoint PPT/PPTX를 JPG로 변환**

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 로드합니다.
2. [getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides)를 사용하여 슬라이드를 가져옵니다.
3. [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)를 수평 및 수직 배율 인수와 함께 호출하여 각 슬라이드를 렌더링합니다.
4. [ImageFormat.Jpeg](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imageformat/#Jpeg)를 사용하여 각 렌더링된 이미지를 JPEG로 저장하고 이미지 리소스를 해제합니다.

{{% alert color="info" title="Note" %}}
JPG로 내보내면 각 슬라이드마다 별도의 이미지가 생성됩니다. 프레젠테이션을 직접 이미지 형식으로 저장하는 대신 렌더링된 이미지를 저장하세요.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **맞춤형 크기로 PowerPoint PPT/PPTX를 JPG로 변환**

원하는 픽셀 크기와 원본 슬라이드 크기에서 수평 및 수직 배율 인수를 계산한 다음 이를 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)에 전달합니다. 다음 예제는 각 슬라이드에 대해 1200 × 800 이미지 크기를 목표로 합니다.

다른 배율 인수를 사용하면 슬라이드가 늘어날 수 있습니다. 종횡비를 유지하려면 두 축에 동일한 배율 인수를 사용하세요. 이렇게 하면 결과 너비와 높이가 원본 슬라이드 비율을 따르게 됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **슬라이드를 이미지로 저장할 때 주석 렌더링**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/)를 사용하여 노트와 주석을 구성하고, [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions)로 레이아웃을 적용합니다. 이 예제는 노트를 하단에 배치하고 맞지 않는 노트는 잘라내며, 오른쪽에 200픽셀 너비 영역에 주석을 표시합니다. 각 렌더링된 슬라이드를 JPG 이미지로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**여러 슬라이드 또는 프레젠테이션을 JPG로 변환할 수 있나요?**

예. 예제에서는 모든 슬라이드를 순회하면서 슬라이드당 하나의 JPG를 저장합니다. 여러 프레젠테이션을 처리하려면 각 입력 파일에 대해 변환을 반복하고, 이미지가 겹치지 않도록 별도의 출력 폴더나 고유한 파일 이름을 사용하십시오.

**이미지에 차트, SmartArt, 테이블 및 도형이 포함되나요?**

이러한 객체들은 슬라이드의 일부로 렌더링됩니다. 글꼴 대체로 인한 차이를 줄이려면 프레젠테이션에서 사용하는 글꼴을 변환 환경에 제공하십시오.

**대용량 프레젠테이션을 내보낼 때 메모리 사용량을 줄이는 방법은?**

이미지를 하나씩 처리하고 저장 후 각 이미지를 해제하며, 불필요하게 큰 출력 크기를 피하십시오. 메모리 요구량은 슬라이드 내용과 이미지 크기에 따라 달라집니다.

## **관련 문서**

- [PowerPoint를 PNG로 변환](/slides/ko/python-java/convert-powerpoint-to-png/).
- [슬라이드를 SVG 이미지로 렌더링](/slides/ko/python-java/render-a-slide-as-an-svg-image/).