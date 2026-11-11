---
title: Python에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- SVG 내보내기 옵션
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 글꼴, 텍스트 및 이미지를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 기록되는지를 제어할 수 있습니다.

내보낸 SVG가 작고, 브라우저 간에 예측 가능하며, 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)를 사용하십시오.

## **슬라이드를 SVG로 내보내기**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)을 만들고 슬라이드를 선택한 뒤 스트림에 씁니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 개별 SVG 파일로 내보냅니다.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

파일 이름은 루프 인덱스 대신 [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/)을 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 형상만 필요할 경우 [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)를 사용하여 개별 형상을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/)은 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/)은 프레임 회전이 적용되는지를 결정합니다. 텍스트를 합자 없이 렌더링해야 할 경우 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/)를 `True`로 설정하십시오.

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

## **화살표 머리에서 라인 끝 자르기 제어**

SVG 1.1에는 화살표 머리 아래에서 선이 멈추는 위치를 지정하는 마커 인셋 설정이 없습니다. 기본적으로 Aspose.Slides는 내보낸 선의 스트로크가 마커를 넘어 나오지 않도록 선을 짧게 만듭니다. [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/)을 `True`로 설정하면 스트로크가 원래 선 끝까지 그려집니다. 이 설정은 SVG 출력에만 영향을 미칩니다. 슬라이드상의 선 위치와 길이는 유지됩니다.

예제는 두께가 2포인트와 10포인트인 선에 삼각형 및 다이아몬드 화살표 머리를 그립니다. 크롭 옵션만 변경하여 동일한 슬라이드를 두 번 내보냅니다.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

비교 결과는 10포인트 선에 삼각형 화살표 머리를 보여줍니다. 크롭을 활성화하면 팁이 날카롭고, 비활성화하면 스트로크가 마커의 경사 면을 통해 튀어나와 평평한 끝이 됩니다.

![크롭이 활성화된 경우 날카로운 팁을 가진 확대된 10포인트 삼각형 및 크롭이 비활성화된 경우 평평한 끝](line-end-cropping.png)

예제의 다른 선에서는 2포인트 삼각형에서 돌출된 스트로크가 덜 눈에 띕니다. 채워진 다이아몬드는 두 두께 모두에서 스트로크 끝을 가립니다.

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지할지 벡터 그래픽으로 변환할지, 외부 글꼴을 어떻게 포함하거나 참조할지를 제어할 수 있습니다. 다음 옵션은 내보낸 SVG에서 시각적 일관성, 텍스트 선택 및 글꼴 종속성을 균형 있게 조절하는 데 도움이 됩니다.

### **모든 텍스트 벡터화**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)을 `True`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이렇게 하면 글꼴 종속성이 사라지고 브라우저 간에 시각적 결과가 더 일관되지만, 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **외부 글꼴 처리 방법 선택**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `ADD_LINKS_TO_FONT_FILES`를, SVG에 글꼴 데이터를 포함하려면 `EMBED`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `VECTORIZE`를 선택하십시오. 글꼴을 포함하기 전에 라이선스를 확인하세요.

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

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/)을 사용하여 내장 그림의 해상도를 낮추고, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/)를 사용해 잘린 원본 영역을 제외하며, [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/)로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질이나 보존된 이미지 데이터를 희생하면서 파일 크기를 줄입니다.

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

## **메타파일 래스터화 해상도 제어**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/)는 SVG 내보내기 중 메타파일을 래스터화할 때 최소 해상도 제한을 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 세부 사항과 파일 크기의 균형을 맞추는 데 사용합니다. 이는 SVG 전체에 대한 DPI를 정의하거나 슬라이드의 모든 객체가 래스터 이미지가 되도록 강제하지 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하십시오. 이 파일에는 촘촘히 배치된 대각선 선이 있는 EMF 이미지가 포함되어 있습니다. 다음 예제는 [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/)를 통해 첫 번째 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

출력에서는 EMF가 각 SVG에 하나의 내장 PNG로 변환되었습니다. 다음 측정값은 제공된 프레젠테이션에 대한 것이며, DPI를 픽셀 크기로 변환하는 일반적인 공식은 아닙니다.

| 메타파일 래스터화 DPI | 내장 PNG 차원 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 확대된 동일한 표시 크기에서 내장 래스터의 동일 영역을 보여줍니다. 대각선 선은 72 DPI에서 눈에 띄는 픽셀화를 보이며, 높은 해상도에서는 더 부드러운 가장자리를 나타내지만 SVG 파일 크기가 증가합니다. 값을 높인다고 해서 모든 세부 사항이 개선되거나 모든 내보낸 이미지가 변경되는 것은 아닙니다.

![72, 150 및 300 DPI에서 확대된 대각선선 세부사항](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/)는 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 관계가 없습니다.

## **FAQ**

**언제 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)를 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) 대신 사용해야 합니까?**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)를 사용하면 모든 텍스트가 글꼴에 독립적이어야 할 때입니다. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 경우에는 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)를 사용하십시오.

**SVG 파일을 더 작게 만들기 위한 최선의 방법은 무엇입니까?**

먼저 내장 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 연결된 글꼴 파일을 선택하십시오. 이미지 해상도를 낮추고 JPEG 품질을 낮추며 텍스트를 벡터화하면 각각 품질과 크기 사이에 다른 트레이드오프가 있으므로 결과를 테스트하세요.