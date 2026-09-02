---
title: Python에서 프레젠테이션 잉크 객체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/python-net/manage-ink/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 잉크 객체를 관리하고, 트레이스와 브러시 속성을 편집하며, PDF, HTML, SVG, TIFF 및 이미지 내보내기 시 잉크 모양을 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 개체를 강조하고, 연결 및 프로세스를 표시하며, 슬라이드에서 특정 항목에 주의를 끌기 위해 사용할 수 있습니다.

[aspose.slides.ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/) 네임스페이스는 잉크 객체를 다루는 데 필요한 클래스를 포함합니다. 예를 들어, [Ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/ink/) 클래스는 슬라이드의 잉크 객체를 나타냅니다.

## **일반 객체와 잉크 객체의 차이점**

PowerPoint 슬라이드의 객체는 일반적으로 도형 객체로 표시됩니다. 가장 단순한 형태에서 도형은 객체 자체의 영역(프레임)과 컨테이너 크기, 모양, 배경과 같은 속성을 정의하는 컨테이너입니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/python-net/shape-manipulations/#access-layout-formats-for-shape)을 참조하세요.

하지만 PowerPoint가 잉크 객체를 처리할 때는 크기를 제외한 객체 프레임(컨테이너)의 모든 속성을 무시합니다. 컨테이너 영역의 크기는 표준 [Ink.width](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/ink/width/) 및 [Ink.height](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/ink/height/) 속성으로 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 순서를 저장합니다.

가장 단순한 인코딩 형태는 각 샘플 점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링될 때 아래와 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 선을 그리는 데 사용됩니다. 브러시의 [InkBrush.color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/inkbrush/color/) 및 [InkBrush.size](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/inkbrush/size/) 속성이 색상과 크기를 제어합니다.

### **잉크 브러시 색상 설정**

다음 Python 코드는 잉크 브러시 색상을 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **잉크 브러시 크기 설정**

다음 Python 코드는 잉크 브러시 크기를 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색 처리됨). 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 보기 위해 잉크 객체의 높이를 늘리고 중요한 차원을 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시의 크기를 고려하지 않으며—항상 선 두께가 0이라고 가정합니다(앞 이미지 참고).

따라서 전체 잉크 객체의 표시 영역을 결정하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서는 대상 객체(필기 텍스트 트레이스)가 컨테이너(프레임) 크기에 맞게 스케일링되었습니다. 컨테이너 크기가 변하면 브러시 크기는 그대로 유지되고 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 객체에 대해서도 유사한 동작을 사용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 시 잉크 모양 제어**

Aspose.Slides는 [InkOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/) 클래스를 제공하여 내보내기 또는 렌더링된 출력에서 잉크 객체가 어떻게 표시되는지 제어합니다. 이 클래스의 속성을 사용해 잉크를 완전히 숨기거나 잉크 브러시 마스크 연산이 해석되는 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 유형에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| Output | Ink options property |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| 슬라이드 이미지 | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/ink_options/) |

이 속성을 통해 두 가지 설정을 사용할 수 있습니다:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/hide_ink/) 은 잉크 객체를 출력에 포함시킬지를 결정합니다. 기본값은 `False`입니다.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) 은 잉크 브러시를 렌더링할 때 마스크 연산을 불투명도로 해석할지를 결정합니다. 기본값은 `True`이며, `False` 로 설정하면 ROP 연산을 사용합니다.

### **PDF 출력에서 잉크 객체 숨기기**

기본적으로 잉크 객체는 내보내기 시 표시됩니다. 필기 주석이나 기타 잉크 내용이 없는 깨끗한 출력을 원한다면 [InkOptions.hide_ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/hide_ink/) 을 `True` 로 설정하세요.

다음 Python 예제는 모든 잉크 객체를 숨긴 상태로 프레젠테이션을 PDF로 내보냅니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **슬라이드를 이미지로 렌더링할 때 잉크 객체 숨기기**

비트맵 이미지로 슬라이드를 렌더링할 때 잉크 객체를 숨기려면 [RenderingOptions.ink_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/ink_options/) 을 구성하고 해당 렌더링 옵션을 [Slide.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/) 메서드에 전달합니다.

다음 Python 예제는 첫 번째 슬라이드를 PNG 이미지로 렌더링하면서 잉크 객체를 제외합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **잉크 마스크 렌더링 제어**

[InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) 속성은 잉크 브러시를 렌더링할 때 마스크 연산을 어떻게 해석할지를 제어합니다. 기본값은 `True`이며, 이는 불투명도를 사용한다는 의미입니다. `False` 로 설정하면 ROP 연산을 사용합니다.

다음 Python 예제는 슬라이드를 SVG로 내보내고 잉크 마스크 연산에 ROP 기반 렌더링을 사용합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

동일한 설정은 프레젠테이션을 내보내거나 슬라이드를 TIFF로 렌더링할 때 [TiffOptions.ink_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/ink_options/) 을 통해 적용할 수 있습니다.

### **잉크를 숨길지 보존할지 선택**

주석이 포함된 프레젠테이션의 정리된 버전을 내보내야 하는 경우(예: 검토 표시가 없는 최종 사본) [InkOptions.hide_ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/hide_ink/) 을 `True` 로 설정하세요.

잉크 주석이 의도된 내용의 일부인 경우(검토 의견, 필기 노트, 강조 표시 또는 보이길 원하는 그림 등) [InkOptions.hide_ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/hide_ink/) 을 기본값인 `False` 로 두세요. 이렇게 하면 동일한 프레젠테이션에서 소스 잉크 객체를 수정하지 않고도 검토용 출력과 최종 출력을 별도로 생성할 수 있습니다.

## **FAQ**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예. [Ink.traces](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/ink/traces/) 에서 트레이스를 가져온 다음 [InkTrace.brush](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/inktrace/brush/) 를 변경하면 됩니다. 브러시의 [InkBrush.color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/inkbrush/color/) 및 [InkBrush.size](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/inkbrush/size/) 속성을 설정할 수 있습니다.

**잉크를 숨겨도 원본 프레젠테이션이 변경되나요?**

아니요. [InkOptions.hide_ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/inkoptions/hide_ink/) 은 렌더링 또는 내보내기 결과에만 영향을 미치며, 원본 프레젠테이션의 잉크 객체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지에 대해 위에 표시된 해당 내보내기 또는 렌더링 옵션을 통해 잉크 옵션을 구성할 수 있습니다.

**추가 읽을 거리**

* 일반적인 도형에 대해 읽으려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/python-net/powerpoint-shapes/) 섹션을 참조하십시오.
* 효과적인 값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/python-net/shape-effective-properties/#get-effective-font-height-value) 를 참고하세요.
* PDF 내보내기 세부사항은 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ko/python-net/convert-powerpoint-to-pdf/) 를 확인하세요.
* HTML 내보내기 세부사항은 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ko/python-net/convert-powerpoint-to-html/) 를 확인하세요.
* SVG 내보내기 세부사항은 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ko/python-net/render-a-slide-as-an-svg-image/) 를 확인하세요.
* TIFF 내보내기 세부사항은 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ko/python-net/convert-powerpoint-to-tiff/) 를 확인하세요.
* 슬라이드 이미지 렌더링 세부사항은 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ko/python-net/convert-slide/) 를 확인하세요.