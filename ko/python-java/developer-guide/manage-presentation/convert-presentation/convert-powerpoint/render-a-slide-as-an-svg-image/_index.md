---
title: Python을 통한 Java로 프레젠테이션 슬라이드를 SVG 이미지로 변환
linktitle: 슬라이드 SVG
type: docs
weight: 50
url: /ko/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 를 SVG 로
- 프레젠테이션을 SVG 로
- 슬라이드를 SVG 로
- PPT 를 SVG 로
- PPTX 를 SVG 로
- SVG 내보내기 옵션
- 인터랙티브 SVG
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 통해 Java로 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides로 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별개의 SVG 파일로 내보내며 텍스트, 글꼴, 이미지 및 SVG 요소가 작성되는 방식을 제어할 수 있습니다.

내보낸 SVG가 작고 브라우저 전반에 걸쳐 예측 가능하거나 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/)를 사용하세요.

## **슬라이드를 SVG로 내보내기**

새 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)을(를) 만들고 슬라이드를 선택한 다음 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/)을 사용해 스트림에 기록합니다. 예제들은 기존 `presentation.pptx` 파일이 필요합니다. 각 예제는 필요에 따라 JVM을 시작하고 출력 스트림을 닫습니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별개의 SVG 파일로 내보냅니다.

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

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber)를 사용합니다. 슬라이드 뷰어나 웹 페이지가 해당 도형만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize)는 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation)은 프레임 회전이 적용될지 여부를 결정합니다. 텍스트를 합자 없이 렌더링해야 할 경우 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures)를 `True`로 설정합니다.

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

## **화살촉에서 선 끝 자르기 제어**

SVG 1.1에는 화살촉 아래에서 선이 멈추는 지점을 지정하는 마커 인셋 설정이 없습니다. 기본적으로 Aspose.Slides는 내보낸 선을 짧게 하여 스트로크가 마커를 통과하지 않도록 합니다. `True`와 함께 [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping)를 호출하면 스트로크가 선의 원래 끝점까지 그려집니다. 이 설정은 SVG 출력에만 영향을 미칩니다. 슬라이드에서 선의 위치와 길이는 유지됩니다.

예제는 2포인트와 10포인트 두께의 선에 삼각형 및 다이아몬드 화살촉을 그립니다. 동일한 슬라이드를 두 번 내보내며, 자르기 옵션만 변경합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

비교 결과는 10포인트 선의 삼각형 화살촉을 보여줍니다. 자르기가 활성화된 경우 팁이 날카롭습니다. 자르기가 비활성화된 경우 스트로크가 마커의 경사진 면을 통해 돌출되어 평평한 끝이 됩니다.

![자르기 활성화 시 날카로운 팁을 가진 확대된 10포인트 삼각형과 자르기 비활성화 시 평평한 끝](line-end-cropping.png)

예제의 다른 선에서는 돌출된 스트로크가 2포인트 삼각형에서 덜 눈에 띕니다. 채워진 다이아몬드는 두 두께 모두에서 스트로크 끝을 가립니다.

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지할지 벡터 그래픽으로 변환할지, 외부 글꼴을 포함하거나 참조하는 방식을 제어할 수 있습니다. 다음 옵션은 내보낸 SVG에서 시각적 일관성, 텍스트 선택 및 글꼴 종속성을 균형 있게 유지하는 데 도움이 됩니다.

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)를 `True`로 설정하면 모든 슬라이드 텍스트가 벡터 그래픽으로 기록됩니다. 이는 글꼴 종속성을 없애고 브라우저 간 시각적 결과를 보다 일관되게 만들지만, 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

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

### **외부 글꼴 처리 방식 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `AddLinksToFontFiles`를, SVG에 글꼴 데이터를 포함하려면 `Embed`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `Vectorize`를 선택합니다. 글꼴을 포함하기 전에 라이선스를 확인하세요.

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

## **내장 이미지 크기 감소**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression)을 사용해 내장 사진의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)를 사용해 잘린 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality)를 사용해 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질이나 보존된 이미지 데이터의 대가로 파일 크기를 감소시킵니다.

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

## **메타파일 래스터화 해상도 제어**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi)는 SVG 내보내기 중 메타파일을 래스터화할 때 하한 해상도 제한을 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 세부 사항과 파일 크기를 균형 있게 맞추는 데 사용합니다. 이는 SVG 전체의 DPI를 정의하거나 슬라이드의 모든 객체가 래스터 이미지가 되도록 강제하지 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하십시오. 이 파일에는 촘촘한 대각선이 있는 EMF 이미지가 포함되어 있습니다. 다음 예제는 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/)를 통해 첫 번째 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

출력에서는 EMF가 각 SVG에 임베드된 PNG 하나로 변환됩니다. 아래 측정값은 제공된 프레젠테이션에 대한 것이며, DPI를 픽셀 차원으로 변환하는 일반 공식은 아닙니다.

| 메타파일 래스터화 DPI | 내장 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 확대된 표시 크기에서 동일 영역의 내장 래스터를 보여줍니다. 대각선 선은 72 DPI에서 눈에 띄는 픽셀화가 보이며, 높은 해상도에서는 더 부드러운 가장자리를 제공합니다. 동시에 SVG 파일 크기가 증가합니다. 값을 높인다고 해서 모든 디테일이 향상되거나 모든 내보낸 이미지가 바뀌는 것은 아닙니다.

![72, 150, 300 DPI에서 확대된 대각선 선 상세](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality)은 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 관계가 없습니다.

## **도형 및 텍스트에 안정적인 ID 할당**

`jpype.JProxy`를 통해 등록된 Python 포맷팅 컨트롤러를 사용해 도형에 [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) 값을, 텍스트 `tspan` 요소에 [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) 값을 할당합니다. 프록시는 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController)로 할당합니다.

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

다음 컨트롤러는 도형의 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)를 사용하고, 텍스트 스팬에 대해 반복 가능한 카운터를 사용합니다. 이렇게 생성된 ID는 변경되지 않은 프레젠테이션의 후처리에 적합합니다.

## **SVG 이벤트 핸들러 추가**

Python 포맷팅 컨트롤러에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler)를 [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) 값과 함께 호출하면 내보낸 도형에 JavaScript 이벤트 핸들러를 추가할 수 있습니다. 컨트롤러는 `jpype.JProxy`를 통해 등록하고 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController)로 할당합니다. 결과를 호스팅하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의하십시오.

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

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 활성화할 수 있습니다.

## **FAQ**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 대신 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)를 사용해야 하나요?**

모든 텍스트가 글꼴에 독립적이어야 할 경우 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)를 사용합니다. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 경우 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)를 사용합니다.

**SVG를 작게 만들기 위한 최선의 방법은 무엇인가요?**

먼저 내장 사진을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 링크된 글꼴 파일을 선택하십시오. 낮은 이미지 해상도, 낮은 JPEG 품질, 벡터화된 텍스트는 각각 품질과 크기 사이에 다른 트레이드오프가 있으므로 결과를 테스트해야 합니다.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.