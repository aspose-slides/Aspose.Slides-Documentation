---
title: Python으로 프레젠테이션에 글꼴 포함
linktitle: 글꼴 포함
type: docs
weight: 40
url: /ko/python-net/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 포함
- 글꼴 임베딩
- 임베드된 글꼴 가져오기
- 임베드된 글꼴 추가
- 임베드된 글꼴 제거
- 임베드된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 글꼴을 포함시켜 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint에 글꼴을 포함**하면 프레젠테이션이 다양한 시스템에서도 의도한 모습대로 유지됩니다. 창의적인 디자인을 위해 고유 글꼴을 사용하든 일반 글꼴을 사용하든, 글꼴을 포함하면 텍스트와 레이아웃이 깨지는 것을 방지할 수 있습니다.

작업에 창의성을 부여하기 위해 서드파티 또는 비표준 글꼴을 사용했다면, 글꼴을 포함해야 하는 이유가 더욱 늘어납니다. 포함되지 않은 글꼴일 경우 슬라이드의 텍스트나 숫자, 레이아웃, 스타일 등이 변경되거나 알 수 없는 사각형으로 표시될 수 있습니다.

[FontsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontdata/), 그리고 [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 클래스를 활용해 포함된 글꼴을 관리하십시오.

## **임베드된 글꼴 가져오기 및 제거**

프레젠테이션에서 임베드된 글꼴을 손쉽게 가져오거나 제거하려면 [get_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 및 [remove_embedded_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/remove_embedded_font/) 메서드를 사용하십시오.

다음 Python 코드는 프레젠테이션에서 임베드된 글꼴을 가져오고 제거하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # 임베드된 'FunSized' 글꼴을 사용하는 텍스트 프레임이 포함된 슬라이드를 렌더링합니다.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # 모든 임베드된 글꼴을 가져옵니다.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 'Calibri' 글꼴을 찾습니다.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 'Calibri' 글꼴을 제거합니다.
    fonts_manager.remove_embedded_font(font_data)

    # 슬라이드를 렌더링합니다; 'Calibri' 글꼴은 기존 글꼴로 교체됩니다.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # 임베드된 'Calibri' 글꼴 없이 프레젠테이션을 디스크에 저장합니다.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **임베드된 글꼴 추가**

[EmbedFontCharacters](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/embedfontcharacters/) 열거형과 [add_embedded_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/add_embedded_font/) 메서드의 두 가지 오버로드를 사용하면 프레젠테이션에 글꼴을 포함하는 규칙을 선택할 수 있습니다. 다음 Python 코드는 글꼴을 임베드하고 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# 프레젠테이션을 로드합니다.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **임베드된 글꼴 압축**

[compress_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/)을 사용해 임베드된 글꼴을 압축하여 파일 크기를 최적화하십시오.

압축 예제 코드:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**프레젠테이션에 포함된 특정 글꼴이 렌더링 중에도 여전히 대체되는지 어떻게 확인할 수 있나요?**

글꼴 관리자의 [substitution information](/slides/ko/python-net/font-substitution/)와 [fallback/substitution rules](/slides/ko/python-net/fallback-font/)를 확인하십시오. 글꼴이 사용 불가능하거나 제한된 경우 대체 글꼴이 적용됩니다.

**Arial/Calibri와 같은 “시스템” 글꼴을 포함할 가치가 있나요?**

대부분의 경우 필요하지 않습니다—해당 글꼴은 거의 항상 존재합니다. 하지만 “얇은” 환경(예: Docker, 사전 설치된 글꼴이 없는 Linux 서버)에서 완전한 이식성을 위해 시스템 글꼴을 포함하면 예상치 못한 대체 위험을 없앨 수 있습니다.