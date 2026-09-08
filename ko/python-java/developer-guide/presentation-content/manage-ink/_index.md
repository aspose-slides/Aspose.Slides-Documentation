---
title: Java를 통해 Python에서 프레젠테이션 잉크 객체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/python-java/manage-ink/
keywords:
- 잉크
- 잉크 객체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- 잉크 내보내기
- 잉크 렌더링
- 잉크 숨기기
- InkOptions
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 잉크 개체를 관리하고, 트레이스와 브러시 속성을 편집하며, PDF, HTML, SVG, TIFF 및 이미지 내보내기 시 잉크 모양을 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 개체를 강조하거나, 연결 및 프로세스를 표시하고, 슬라이드의 특정 항목에 주의를 끌 때 사용할 수 있습니다.

Aspose.Slides는 잉크 개체를 다루는 데 필요한 유형을 제공합니다. 예를 들어, [Ink](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ink/) 클래스는 슬라이드상의 잉크 개체를 나타냅니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 shape 개체로 표현됩니다. 가장 단순한 형태의 shape는 개체 자체(프레임)의 영역을 정의하는 컨테이너이며, 컨테이너 크기, 모양 및 배경과 같은 속성을 가집니다. 자세한 내용은 [Shape Layout Format](/slides/ko/python-java/shape-manipulations/#access-layout-formats-for-shape)을 참조하십시오.

그러나 PowerPoint가 잉크 개체를 처리할 때는 프레임(컨테이너)의 모든 속성을 무시하고 크기만을 사용합니다. 컨테이너 영역의 크기는 표준 [Shape.getWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getWidth) 및 [Shape.getHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getHeight) 메서드에 의해 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 작성할 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 순서를 저장합니다.

가장 단순한 인코딩 형식은 각 샘플 지점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 라인을 그리는 데 사용됩니다. 브러시는 자체 색상과 크기를 가지며, 이는 [InkBrush.getColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkbrush/#getColor) 및 [InkBrush.getSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkbrush/#getSize) 메서드로 표시됩니다.

### **잉크 브러시 색상 설정**

다음 Python 코드에서는 잉크 브러시의 색상을 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **잉크 브러시 크기 설정**

다음 Python 코드에서는 잉크 브러시의 크기를 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색 처리됨). 브러시의 너비와 높이가 일치할 때 PowerPoint는 크기를 다음과 같이 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 보기 위해 잉크 개체의 높이를 늘리고 중요한 차원을 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시의 크기를 고려하지 않으며, 항상 선 두께가 0이라고 가정합니다(이전 이미지를 참조).

따라서 전체 잉크 개체의 가시 영역을 결정하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서 대상 개체(손글씨 텍스트 트레이스)는 컨테이너(프레임)의 크기에 맞게 스케일되었습니다. 컨테이너 크기가 변경되면 브러시 크기는 일정하게 유지되고 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 개체에도 유사한 동작을 사용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 시 잉크 모양 제어**

Aspose.Slides는 [InkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/) 클래스를 제공하여 잉크 개체가 내보내기 또는 렌더링 결과에 어떻게 표시되는지 제어할 수 있습니다. 이 클래스의 속성을 사용하여 잉크를 완전히 숨기거나 잉크 브러시 마스크 작업의 해석 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 형식에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| 출력 | 잉크 옵션 속성 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/#getInkOptions) |

다음 [InkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/) 메서드는 동일한 두 설정을 노출합니다:

- [getHideInk](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#getHideInk) 은 잉크 개체가 출력에 포함되는지를 결정합니다. 기본값은 `False` 입니다.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 은 잉크 브러시를 렌더링할 때 마스크 작업을 불투명도로 해석할지 여부를 결정합니다. 기본값은 `True`이며, `False` 로 호출하여 [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) 로 ROP 작업을 사용하도록 전환할 수 있습니다.

### **PDF 출력에서 잉크 개체 숨기기**

기본적으로 잉크 개체는 내보내기 시에 보입니다. 손글씨 주석이나 기타 잉크 콘텐츠 없이 깔끔한 출력을 만들려면 [InkOptions.setHideInk](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#setHideInk) 에 `True` 를 전달하십시오.

다음 Python 예제는 모든 잉크 개체를 숨기면서 프레젠테이션을 PDF로 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **슬라이드 이미지를 렌더링할 때 잉크 개체 숨기기**

슬라이드를 비트맵 이미지로 렌더링할 때 잉크 개체를 숨기려면 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/#getInkOptions) 를 구성하고 해당 렌더링 옵션을 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage) 에 전달하십시오.

다음 Python 예제는 첫 번째 슬라이드를 PNG 이미지로 렌더링하면서 잉크 개체를 제외합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **잉크 마스크 렌더링 제어**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 설정은 잉크 브러시를 렌더링할 때 마스크 작업을 어떻게 해석할지를 제어합니다. 기본값은 `True`이며, 이는 불투명도를 사용함을 의미합니다. ROP 작업을 사용하려면 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) 에 `False` 를 전달하십시오.

다음 Python 예제는 슬라이드를 SVG로 내보내고 잉크 마스크 작업에 ROP 기반 렌더링을 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

동일한 설정은 프레젠테이션을 내보내거나 슬라이드를 TIFF로 렌더링할 때 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#getInkOptions) 를 통해 적용할 수 있습니다.

### **잉크를 숨길지 보존할지 선택**

주석이 포함된 프레젠테이션을 배포용으로 깔끔하게 만들고 싶다면 내보내기 중에 [InkOptions.setHideInk](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#setHideInk) 에 `True` 를 전달하십시오.

잉크 주석이 리뷰 의견, 손글씨 메모, 강조 표시 또는 그림과 같이 의도된 콘텐츠의 일부인 경우 [InkOptions.getHideInk](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#getHideInk) 을 기본값인 `False` 로 두어야 합니다. 이렇게 하면 동일한 프레젠테이션에서 소스 잉크 개체를 수정하지 않고도 별도의 리뷰용 및 최종용 출력물을 생성할 수 있습니다.

## **FAQ**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예. [Ink.getTraces](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ink/#getTraces) 로 트레이스를 가져온 다음 해당 [InkTrace.getBrush](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inktrace/#getBrush) 를 변경하십시오. [InkBrush.setColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkbrush/#setColor) 또는 [InkBrush.setSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkbrush/#setSize) 를 호출하여 브러시를 변경할 수 있습니다.

**잉크를 숨기는 것이 원본 프레젠테이션을 변경하나요?**

아니요. [InkOptions.setHideInk](https://reference.aspose.com/slides/ko/python-java/aspose.slides/inkoptions/#setHideInk) 은 렌더링 또는 내보내기 결과에만 영향을 주며, 원본 프레젠테이션의 잉크 개체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지 출력에 대해 위에 표시된 해당 내보내기 또는 렌더링 옵션을 통해 잉크 옵션을 구성할 수 있습니다.

## **추가 읽기**

* 일반적인 shape에 대해 알아보려면 [PowerPoint Shapes](/slides/ko/python-java/powerpoint-shapes/) 섹션을 참고하십시오.
* 효과적인 값에 대한 자세한 내용은 [Shape Effective Properties](/slides/ko/python-java/shape-effective-properties/#get-effective-font-height-value)를 확인하십시오.
* PDF 내보내기에 대한 자세한 내용은 [Convert PPT and PPTX to PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/)를 참조하십시오.
* HTML 내보내기에 대한 자세한 내용은 [Convert PowerPoint Presentations to HTML](/slides/ko/python-java/convert-powerpoint-to-html/)를 확인하십시오.
* SVG 내보내기에 대한 자세한 내용은 [Render Presentation Slides as SVG Images](/slides/ko/python-java/render-a-slide-as-an-svg-image/)를 보십시오.
* TIFF 내보내기에 대한 자세한 내용은 [Convert PowerPoint Presentations to TIFF](/slides/ko/python-java/convert-powerpoint-to-tiff/)를 읽어보십시오.
* 슬라이드 이미지를 렌더링하는 방법에 대한 자세한 내용은 [Convert Presentation Slides to Images](/slides/ko/python-java/convert-slide/)를 확인하십시오.