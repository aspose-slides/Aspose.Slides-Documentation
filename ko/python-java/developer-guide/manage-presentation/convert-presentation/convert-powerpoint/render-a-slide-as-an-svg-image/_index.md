---
title: 파이썬에서 Java를 통해 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
type: docs
weight: 50
url: /ko/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- SVG 내보내기 옵션
- 대화형 SVG
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Java를 통해 Python에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides로 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 이미지 및 SVG 요소가 기록되는 방식을 제어할 수 있습니다.

내보낸 SVG가 작고, 브라우저마다 예측 가능하며, 인터랙티브 사용을 위해 준비되어야 할 때는 [SVGOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/)을 사용하십시오.

## **슬라이드를 SVG로 내보내기**

다음 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)을 생성하고, 슬라이드를 선택한 뒤 [Slide.writeAsSvg](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/)를 사용해 스트림에 기록합니다. 예제에는 기존 `presentation.pptx` 파일이 필요합니다. 각 예제는 필요한 경우 JVM을 시작하고 출력 스트림을 닫습니다. 아래 예제는 프레젠테이션의 모든 슬라이드를 개별 SVG 파일로 내보냅니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getSlideNumber)를 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 도형만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setUseFrameSize)는 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setUseFrameRotation)은 프레임 회전을 적용할지 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 때는 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setDisableFontLigatures)를 `True`로 설정하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **텍스트 및 글꼴 제어**

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setVectorizeText)를 `True`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이렇게 하면 글꼴 종속성이 없으며 브라우저 간 시각적 결과가 보다 일관되지만, 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **외부 글꼴 처리 방법 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setExternalFontsHandling)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `AddLinksToFontFiles`를, SVG에 글꼴 데이터를 포함하려면 `Embed`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `Vectorize`를 선택하십시오. 글꼴을 포함하기 전에 라이선스를 확인하세요.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **내장 이미지 크기 축소**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setPicturesCompression)을 사용하면 내장 이미지의 해상도를 낮출 수 있고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)로 잘라낸 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setJpegQuality)로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질이나 유지되는 이미지 데이터의 손실을 대가로 파일 크기를 감소시킵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **도형 및 텍스트에 안정적인 ID 할당**

`jpype.JProxy`를 통해 등록된 Python 포맷팅 컨트롤러를 사용하여 도형에 [SvgShape.setId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgshape/#setId) 값을, 텍스트 `tspan` 요소에 [SvgTSpan.setId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgtspan/#setId) 값을 할당합니다. 프록시는 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setShapeFormattingController)로 지정하십시오.

다음 컨트롤러는 도형의 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getOfficeInteropShapeId)와 텍스트 스팬에 대한 반복 가능한 카운터를 사용합니다. 이를 통해 생성된 ID를 변경되지 않은 프레젠테이션의 후처리에 사용할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG 이벤트 핸들러 추가**

Python 포맷팅 컨트롤러에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgshape/#setEventHandler)에 [SvgEvent](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgevent/) 값을 전달하여 내보낸 도형에 JavaScript 이벤트 핸들러를 추가합니다. 컨트롤러는 `jpype.JProxy`를 통해 등록하고 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setShapeFormattingController)로 지정합니다. 결과를 호스팅하는 페이지나 SVG 문서에 JavaScript 함수를 정의하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 지원합니다.

## **FAQ**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgoptions/#setVectorizeText)를 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) 대신 사용해야 하나요?**

모든 텍스트가 글꼴에 독립적이어야 할 때는 [SVGOptions.setVectorizeText]를 사용하십시오. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 경우에는 [SvgExternalFontsHandling.Vectorize]를 사용합니다.

**SVG 파일을 더 작게 만들기 위한 최선의 방법은 무엇인가요?**

먼저 내장된 이미지를 압축하고, 잘라낸 이미지 영역을 삭제하며, 대상 환경이 제공할 수 있는 경우에는 연결된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 낮추기, 텍스트 벡터화 각각이 품질과 크기 사이에 다른 트레이드오프를 갖으므로 결과를 테스트하세요.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.