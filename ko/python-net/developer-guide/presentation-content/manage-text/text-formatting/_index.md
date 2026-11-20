---
title: Python에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식
type: docs
weight: 50
url: /ko/python-net/text-formatting/
keywords:
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 글꼴 속성
- 글꼴 패밀리
- 텍스트 회전
- 회전 각도
- 텍스트 프레임
- 줄 간격
- 자동 맞춤 속성
- 텍스트 프레임 앵커
- 텍스트 탭 설정
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 서식 지정하고 스타일을 적용합니다. 글꼴, 색상, 정렬 등을 사용자 지정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 서식 지정하는 방법을 보여줍니다. 배경 색, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 앵커링, 탭 정지 및 언어 설정을 다룹니다.

특별히 명시되지 않는 한, 예제는 [sample.pptx](sample.pptx)를 사용합니다. 첫 번째 슬라이드의 첫 번째 도형은 텍스트 상자이며, 첫 번째 단락에 아래에 표시된 텍스트가 포함됩니다. 슬라이드와 도형 인덱스는 0부터 시작합니다. 굵은 부분을 선택하는 예제는 효과적인 서식을 사용하며, 상속된 굵은 서식도 포함합니다:

![샘플 텍스트](sample_text.png)

문자 그대로의 텍스트 또는 정규식 일치를 찾고 강조하려면, [텍스트 검색 및 바꾸기](/slides/ko/python-net/search-and-replace-text/)를 참조하십시오.

## **텍스트 배경 색 설정**

단락에 대한 기본 강조 색을 설정하려면 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)을 사용하고, 개별 텍스트 부분에 대해서는 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/)을 사용합니다.

다음 예제는 첫 번째 단락의 기본 강조 색을 연한 회색으로 설정합니다. 개별 부분에 대한 명시적인 강조 색은 이 기본값보다 우선합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 전체 단락에 대한 강조 색을 설정합니다.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![회색 단락](gray_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**의 배경 색을 설정하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 텍스트 부분에 대한 강조 색을 설정합니다.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 단락 정렬**

텍스트 프레임 내에서 단락 정렬을 설정하려면 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)을 사용합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등으로 지정할 수 있습니다.

다음 코드 예제는 단락을 **가운데**에 정렬하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 단락의 정렬을 가운데로 설정합니다.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **한 줄 내에서 글꼴 정렬**

한 줄 내에서 서로 다른 글꼴 크기의 텍스트 부분을 수직으로 정렬하려면 [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/)을 사용합니다. 이 설정은 전체 단락에 적용되며 각 줄 내 정렬을 제어합니다.

다음 독립 실행형 예제는 한 슬라이드에 네 개의 레이블이 있는 텍스트 상자를 생성합니다. 각 단락은 18, 36, 54 포인트의 동일한 텍스트를 포함하며, 다른 글꼴 정렬을 사용합니다. Arial을 사용하고 자동 맞춤 및 래핑을 비활성화하며 텍스트 프레임을 한 줄에 충분히 크게 유지합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![혼합 글꼴 크기에 대한 기준선, 위쪽, 가운데 및 아래쪽 글꼴 정렬 비교](font_alignment.png)

글꼴 정렬은 글꼴 메트릭을 사용하므로 개별 문자들의 눈에 보이는 경계가 정확히 일치하지 않을 수 있습니다. 이 예제는 대문자와 하강자를 모두 포함하여 기준선과 아래쪽 정렬의 차이를 보여줍니다. 글꼴 가용성 및 대체, 사용된 문자, 글꼴 크기의 차이가 결과에 영향을 미칩니다. 프레임 크기, 여백, 줄 간격, 래핑 및 자동 맞춤 또한 레이아웃에 영향을 주므로, 모드를 비교할 때는 동일한 글꼴과 레이아웃 설정을 사용하십시오.

이 설정은 가로 단락 정렬을 제어하는 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)와 도형 내 텍스트 블록을 수직으로 위치시키는 [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)과 다릅니다. [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/)를 통한 위 첨자 및 아래 첨자 서식은 개별 부분을 기준선에 대해 이동시켜 단락 줄의 글꼴 정렬을 설정하는 것이 아닙니다.

## **텍스트 투명도 설정**

텍스트 투명도는 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 투명도 비율이 아니라 0–255 스케일의 ARGB 알파 채널 값입니다.

다음 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 텍스트에 반투명 검은색 채우기를 설정합니다.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![투명한 단락](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 텍스트 부분의 투명도를 설정합니다.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/)을 사용하여 텍스트 상자 내 문자 간 간격을 늘리거나 줄일 수 있습니다. 예제에서는 3포인트의 간격을 추가하며, 음수 값은 텍스트를 압축합니다.

다음 Python 코드는 **전체 단락**의 문자 간격을 확장하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 참고: 문자 간격을 압축하려면 음수 값을 사용하십시오.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 문자 간격을 늘립니다.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 부분**의 문자 간격을 확장하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 참고: 문자 간격을 압축하려면 음수 값을 사용하십시오.
            portion.portion_format.spacing = 3  # 문자 간격을 늘립니다.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 폰트에 대한 커닝 비활성화**

Aspose.Slides에서 렌더링된 텍스트가 PowerPoint에서 표시되는 동일한 텍스트보다 약간 더 조밀하게 보일 수 있습니다. 이는 PowerPoint가 특정 폰트에 대한 커닝 데이터를 무시할 수 있기 때문이며, 폰트에 유효한 커닝 정보가 포함되어 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생할 수 있습니다.

이러한 경우 렌더링 결과를 PowerPoint와 가깝게 만들려면 해당 폰트를 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/)을 실제 폰트 크기보다 큰 값으로 설정하십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"가 필요합니다. 효과적인 폰트 이름(상속된 폰트 포함)을 확인하고 Roboto를 사용하는 부분에 대해 100포인트 임계값을 설정합니다. 이는 100포인트 미만의 폰트 크기를 가진 해당 부분에 대해 커닝을 비활성화합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

임계값 이하의 해당 텍스트에 대해 이 설정은 커닝을 방지하며, PowerPoint 고유 동작에 영향을 받는 폰트에 대해 Aspose.Slides 렌더링을 PowerPoint의 시각적 출력과 일치시키는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)을 통해 단락 수준에서 설정하거나, 개별 부분에 대해서는 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)을 통해 설정할 수 있습니다.

다음 예제는 첫 번째 단락의 기본 글꼴을 12포인트 Times New Roman으로 설정하고 굵게, 기울임, 점선 밑줄 서식을 적용합니다. 개별 부분에 대한 명시적인 서식은 이러한 기본값보다 우선합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 단락에 대한 글꼴 속성을 설정합니다.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락의 글꼴 속성](font_properties_for_paragraph.png)

다음 예제는 효과적인 서식이 굵게인 부분에 13포인트 Times New Roman, 기울임 서식 및 점선 밑줄을 적용합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 텍스트 부분에 대한 글꼴 속성을 설정합니다.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 높이 정규화 제어**

[BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/)을 사용하여 템플릿 타이포그래피를 재현하거나 문자 높이 차이를 조사할 때 사용할 수 있습니다. PowerPoint에서 정규화를 활성화하면 텍스트 부분 내에서 개별 문자를 수직으로 늘리거나 압축하여 균일한 가시 높이를 부여합니다. 이는 서로 다른 글꼴 간에 동일한 텍스트 높이를 보장하지는 않습니다.

속성을 [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)로 설정하면 정규화를 명시적으로 활성화하거나 비활성화할 수 있습니다. `NullableBool.NOT_DEFINED`는 로컬 설정을 정의하지 않아 부분이 예를 들어 단락의 [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)으로부터 값을 상속하도록 합니다. 이는 `False`를 의미하지 않습니다. [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)를 사용하고 [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/)를 읽어 해결된 Boolean 값을 얻으십시오.

다음 독립 실행형 예제는 **Arial**이 설치되어 있어야 합니다. 54포인트에서 동일한 대문자, 소문자, 하강자 및 억음 문자를 포함하는 두 개의 텍스트 블록을 생성합니다. 두 단락 모두 기본적으로 정규화를 활성화합니다. 상단 부분은 명시적으로 비활성화하고, 하단 부분은 이를 상속합니다. 프레임 크기, 여백 및 단락 간격은 동일하며, 비교 일관성을 위해 래핑과 자동 맞춤을 비활성화합니다. 예제는 `FALSE: False`와 `NOT_DEFINED: True`를 출력한 후 "text_height_normalization.pptx"를 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

아래 비교는 저장된 프레젠테이션에서 내보낸 것입니다. 상단 행은 정규화가 비활성화(`FALSE`)되었고, 하단 행은 활성화된 설정을 상속합니다(`NOT_DEFINED` → `True`). 이 모습을 재현하려면 Arial을 설치하십시오.

![Arial 54포인트 텍스트(위는 정규화 비활성화, 아래는 정규화 상속 활성화)](text_height_normalization.png)

정규화는 할당된 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 값을 변경하지 않고 문자 높이를 변경합니다. 단락 [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/)은 줄 간격을 제어하고, 텍스트 프레임 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)은 텍스트 또는 컨테이너가 맞추도록 조정하는 방식을 제어합니다. 이러한 설정은 서로 다른 목적을 가지며 전체 레이아웃에 독립적으로 영향을 줄 수 있습니다. 단락 서식 및 상속에 대한 자세한 내용은 [단락 관리](/slides/ko/python-net/manage-paragraph/)를 참조하십시오.

## **취소선 적용 및 제거**

텍스트 부분에 [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/)을 사용하면 원본 텍스트를 삭제하지 않고 교정, 취소된 용어 또는 이전 가격을 표시할 수 있습니다. 텍스트에 한 줄 또는 두 줄을 그으려면 [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/)으로 설정하십시오.

취소선을 제거하려면 `TextStrikethroughType.NONE`을 할당하십시오. 이것은 주변 서식이 취소선을 지정하고 있더라도 효과를 명시적으로 비활성화합니다. 반면에 `TextStrikethroughType.NOT_DEFINED`는 로컬 설정을 정의하지 않아 부분이 예를 들어 단락에서 서식을 상속하도록 합니다. 이는 취소선이 제거된다는 보장은 없습니다. 결과 서식을 읽으려면 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)를 사용하여 상속된 값을 포함한 서식을 확인하십시오.

다음 독립 실행형 예제는 세 개의 가격 비교를 생성합니다. 각 단락은 레이블, 이전 가격, 현재 가격에 대한 별도 부분을 가지고 있어 이전 가격에만 취소선이 적용됩니다. 첫 번째 행은 취소선을 적용했다가 제거하고, 다른 행은 각각 단일 및 이중 취소선을 유지합니다. 이 속성을 변경하면 텍스트와 굵게 된 이전 가격을 포함한 다른 서식이 보존됩니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # 취소선을 적용한 후 첫 번째 이전 가격에서 명시적으로 제거합니다.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

결과(위에서 아래 순서): 취소선 없음, 단일 취소선, 이중 취소선.

![취소선 없는 이전 가격, 단일 취소선 적용된 이전 가격, 이중 취소선 적용된 이전 가격](strikethrough.png)

## **텍스트 회전 설정**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)을 사용하여 도형 내에 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 도형의 텍스트 방향을 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)으로 설정하며, 이는 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![텍스트 회전](text_rotation.png)

## **텍스트 프레임 사용자 정의 회전 설정**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)을 사용하여 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)에 대한 사용자 정의 회전 각도를 설정합니다.

다음 코드 예제는 도형 내에서 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![사용자 정의 텍스트 회전](custom_text_rotation.png)

## **단락 줄 간격 설정**

Aspose.Slides는 [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/)을 제공하여 단락 간격을 제어합니다. 이러한 속리는 다음과 같이 사용됩니다:

- 양수 값을 사용하여 줄 간격을 줄 높이의 백분율로 지정합니다.
- 음수 값을 사용하여 줄 간격을 포인트 단위로 지정합니다.

다음 예제는 첫 번째 단락의 내부 간격을 줄 높이의 200%(두 배 간격)로 설정합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

![단락 내부 줄 간격](line_spacing.png)

## **줄 바꿈 제어**

단락 줄 바꿈 규칙은 좁은 텍스트 블록 및 라틴어와 동아시아 텍스트가 혼합된 프레젠테이션에 유용합니다. 다음 속성은 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)에 속하므로 전체 단락에 적용됩니다:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/)은 라틴어 줄 바꿈 규칙을 제어합니다. 혼합 텍스트에서 이를 변경하면 인접한 동아시아 텍스트와 구두점의 래핑 위치도 변경될 수 있습니다.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/)은 동아시아 줄 바꿈 규칙을 제어하며, 줄 시작 및 끝에 있는 문자에 대한 제한을 포함합니다.

이 규칙은 텍스트 프레임 내 자동 래핑을 활성화하는 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)을 대체하지 않습니다. 래핑이 발생할 때 레이아웃에 영향을 주지만, 줄 바꿈 문자를 삽입하지는 않습니다. 명시적 줄 바꿈은 사용 가능한 폭과 무관하게 단락 내에 새 줄을 강제합니다.

다음 독립 실행형 예제는 중국어와 라틴어 텍스트를 포함한 좁은 텍스트 블록을 생성합니다. 두 줄 바꿈 속성을 명시적으로 설정하고 "line_breaking.pptx"로 저장합니다. 각 규칙을 실험하려면 다른 설정은 고정한 채 해당 속성 값을 변경하십시오. 예제는 24포인트 Arial 및 SimSun을 사용하고 프레임 폭은 160포인트, 텍스트 프레임 수평 여백은 0으로 설정합니다. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)은 [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/)으로 설정되어 텍스트 크기와 프레임 크기가 고정됩니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **행말 구두점 제어**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/)은 해당 구두점이 다음 줄을 차지하는 대신 텍스트 줄의 오른쪽 끝을 넘어 확장되도록 허용합니다. 이는 전체 단락에 적용되며 행 들여쓰기와는 다릅니다.

다음 독립 실행형 예제는 100포인트 넓이 텍스트 프레임에서 행말 구두점을 활성화하고 "hanging_punctuation.pptx"로 저장합니다. 24포인트 Arial과 텍스트 프레임 수평 여백이 0인 경우, 마지막 마침표가 "sentence" 뒤에 남아 오른쪽 텍스트 가장자를 넘어갑니다. 비교를 위해 속성을 [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)로 설정하십시오: 이 설정에서는 마침표가 별도 줄에 배치됩니다. 래핑은 활성화되고 자동 맞춤은 비활성화되어 사용 가능한 폭이 고정됩니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

모든 구두점이 행말을 할 수 있는 것은 아닙니다. 눈에 보이는 결과는 [글꼴 및 레이아웃 조건](#control-line-breaking)에 따라 달라지며, 글꼴, 사용 가능한 폭, 여백 또는 자동 맞춤 설정을 변경하면 차이가 사라질 수 있습니다.

## **텍스트 프레임 자동 맞춤 유형 설정**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)은 텍스트가 컨테이너 경계를 초과할 때 동작 방식을 결정합니다. 텍스트가 축소, 넘침, 또는 도형을 자동으로 크기 조정하도록 제어하는 데 사용합니다. 다음 예제는 텍스트에 맞게 도형을 크기 조정하도록 설정하고 결과를 "autofit_type.pptx"에 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

자동 래핑 후 라인 수를 세고 텍스트 또는 도형 너비가 결과에 어떻게 영향을 주는지 보려면 [렌더링된 라인 수 세기](/slides/ko/python-net/manage-paragraph/)를 참조하십시오. 라인 수만으로 텍스트가 컨테이너를 초과했는지는 알 수 없습니다.

## **텍스트 프레임 앵커 설정**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)은 텍스트가 도형 안에서 수직으로 위치하는 방식을 정의합니다(예: 상단, 가운데, 하단). 다음 예제는 텍스트를 첫 번째 도형의 하단에 고정하고 결과를 "text_anchor.pptx"에 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **텍스트 탭 설정**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/)와 [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/)을 사용하여 단락의 탭 정지를 구성합니다. 다음 예제는 기본 탭 간격을 100포인트로 설정하고 30포인트에 왼쪽 정렬 탭 정지를 추가합니다. 이러한 설정은 탭 문자를 포함하는 텍스트에 영향을 줍니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

![단락 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)을 제공하여 텍스트 부분의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"와 최소 하나의 단락이 필요합니다. 첫 번째 단락의 내용을 "1。"으로 교체하고 글꼴을 SimSun으로 설정하며, 교정 언어를 Simplified Chinese(`zh-CN`)로 지정합니다. 결과를 "proofing_language.pptx"로 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # 교정 언어를 간체 중국어로 설정합니다.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **언어 메타데이터 복사**

템플릿에서 다국어 텍스트를 복사할 때는 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)와 [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/)를 모두 보존하십시오. 다음 독립 실행형 예제는 언어를 미국 영어, 대체 언어를 프랑스어로 설정한 소스 부분을 만들고 텍스트와 식별자를 새 프레젠테이션의 부분에 복사합니다.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # 소스에 대체 언어가 없으면, None이 대상 값을 지웁니다.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

대체 언어가 없는 소스를 테스트하려면 `"fr-FR"` 할당을 생략하십시오. 그러면 대체 식별자는 `None`이 되며, 동일한 복사 문장은 대상에 이전에 대체 언어가 할당되어 있더라도 기본값을 도입하지 않고 그 부재를 유지합니다.

이러한 식별자는 언어 메타데이터로 저장됩니다. 이를 보존한다고 해서 PowerPoint가 맞춤법이나 문법 검사에 사용할 사전이 결정되는 것은 아닙니다.

## **기본 언어 설정**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/)을 사용하여 프레젠테이션을 로드하거나 생성할 때 만들어지는 텍스트의 기본 언어를 정의합니다. 다음 예제는 기본 텍스트 언어를 미국 영어로 설정한 프레젠테이션을 만들고, 텍스트 상자를 추가한 뒤 첫 번째 텍스트 부분에 대해 `en-US`를 출력합니다.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 텍스트가 있는 새 사각형 도형을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 첫 번째 부분의 언어를 확인합니다.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)을 사용하십시오.

다음 예제는 새 프레젠테이션의 최상위 단락에 대해 14포인트 굵은 글꼴을 기본값으로 설정하고 "default_text_style.pptx"에 저장합니다. 텍스트는 보다 구체적인 서식이 이를 덮어쓰지 않는 한 이러한 기본값을 상속할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 최상위 단락 서식을 가져옵니다.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **전체 대문자 효과로 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 원래 소문자로 입력했더라도 슬라이드에 대문자로 표시됩니다. Aspose.Slides로 해당 텍스트 부분을 가져오면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)을 확인하고 값이 `ALL`인 경우 반환된 문자열을 대문자로 변환하십시오.

이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "sample2.pptx"가 필요합니다. 첫 번째 단락의 첫 번째 부분에 All Caps 효과가 적용된 "Hello, Aspose!"가 포함되어 있으며, 아래와 같습니다.

![전체 대문자 효과](all_caps_effect.png)

다음 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

출력:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 수정하려면 어떻게 해야 하나요?**

슬라이드의 표에서 텍스트를 수정하려면 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)을 사용하십시오. 셀을 반복하면서 각 셀을 [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)을 통해 업데이트하고, 단락 서식은 [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/)을 통해 지정합니다.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 적용하려면 어떻게 해야 하나요?**

텍스트에 그라디언트 색을 적용하려면 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)을 사용하십시오. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)을 [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)으로 설정하고 그라디언트 정지점, 방향 및 투명도를 구성합니다.

관련 기능: [슬라이드 내 텍스트 서식](/slides/ko/features/text-formatting/).