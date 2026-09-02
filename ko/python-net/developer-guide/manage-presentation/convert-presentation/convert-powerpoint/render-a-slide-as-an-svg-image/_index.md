---
title: "Python에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링"
linktitle: "슬라이드를 SVG로"
type: docs
weight: 50
url: /ko/python-net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint를 SVG로"
- "프레젠테이션을 SVG로"
- "슬라이드를 SVG로"
- "PPT를 SVG로"
- "PPTX를 SVG로"
- "SVG 내보내기 옵션"
- "PowerPoint"
- "프레젠테이션"
- "Python"
- "Aspose.Slides"
description: "Python에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides로 글꼴, 텍스트 및 이미지를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 포스트 프로세싱에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별개의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 기록되는지를 제어할 수 있습니다.

내보낸 SVG가 작고, 브라우저 간에 일관되며, 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/)를 사용합니다.

## **슬라이드 SVG 내보내기**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 만들고 슬라이드를 선택한 뒤 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별개의 SVG 파일로 내보냅니다.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

파일 이름은 루프 인덱스가 아니라 [Slide.slide_number](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/slide_number/)을 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 도형만 필요할 경우 [Shape.write_as_svg](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.use_frame_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/use_frame_size/)가 텍스트 프레임을 렌더링 영역에 포함하고, [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/use_frame_rotation/)는 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 때는 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/)를 `True`로 설정합니다.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **텍스트 및 글꼴 제어**

### **모든 텍스트 벡터화**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/vectorize_text/)를 `True`로 설정하면 슬라이드의 모든 텍스트가 벡터 그래픽으로 작성됩니다. 이렇게 하면 글꼴 의존성이 사라지고 브라우저 간 시각적 결과가 일관되지만, 텍스트는 더 이상 SVG 텍스트로 선택하거나 검색할 수 없습니다.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **외부 글꼴 처리 방식 선택**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/external_fonts_handling/)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgexternalfontshandling/) 값을 사용합니다. `ADD_LINKS_TO_FONT_FILES`를 선택하면 별도의 글꼴 파일을 참조하고, `EMBED`를 선택하면 글꼴 데이터를 SVG에 포함하며, `VECTORIZE`를 선택하면 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링합니다. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **내장 이미지 크기 축소**

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/pictures_compression/)을 사용해 삽입된 그림의 해상도를 낮추고, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/)를 사용해 잘린 원본 영역을 생략하며, [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/jpeg_quality/)를 사용해 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질이나 보존 데이터와 비용을 교환하여 파일 크기를 줄입니다.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**언제 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/vectorize_text/)를 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgexternalfontshandling/) 대신 사용해야 하나요?**

모든 텍스트가 글꼴에 독립적이어야 할 때는 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/vectorize_text/)를 사용합니다. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환하려면 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgexternalfontshandling/)를 사용합니다.

**SVG 파일을 작게 만들기 위한 최선의 방법은 무엇인가요?**

먼저 삽입된 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 링크된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질과 크기에서 다른 트레이드오프를 갖기 때문에 결과를 테스트해야 합니다.