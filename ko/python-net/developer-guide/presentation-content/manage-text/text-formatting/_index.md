---
title: Python에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/python-net/text-formatting/
keywords:
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 폰트 속성
- 폰트 패밀리
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 서식 지정하고 스타일을 적용합니다. 폰트, 색상, 정렬 등을 맞춤 설정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 배경색, 투명도, 문자 간격, 폰트 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 앵커링, 탭 정지 및 언어 설정을 다룹니다.

별도의 언급이 없는 한 예제에서는 [sample.pptx](sample.pptx)를 사용합니다. 첫 슬라이드의 첫 번째 도형은 텍스트 상자이며, 첫 번째 단락에 아래에 표시된 텍스트가 포함됩니다. 슬라이드와 도형 인덱스는 0부터 시작합니다. 굵은 부분을 선택하는 예제는 상속된 굵은 서식을 포함한 효율적인 서식을 사용합니다:

![샘플 텍스트](sample_text.png)

리터럴 텍스트 또는 정규식 일치를 찾고 강조하려면 [텍스트 검색 및 바꾸기](/slides/ko/python-net/search-and-replace-text/)를 참조하십시오.

## **텍스트 배경색 설정**

단락의 기본 강조 색을 설정하려면 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)을 사용하고, 개별 텍스트 구간에 대해서는 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/)을 사용하십시오.

다음 예제는 첫 번째 단락에 대해 라이트 그레이 강조 색을 기본값으로 설정합니다. 개별 구간에 지정된 강조 색이 이 기본값보다 우선합니다:

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

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 구간**의 배경 색을 설정하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 텍스트 구간에 대한 강조 색을 설정합니다.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![회색 텍스트 구간](gray_text_portions.png)

## **텍스트 단락 정렬**

텍스트 프레임 내에서 단락 정렬을 설정하려면 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)을 사용합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등일 수 있습니다.

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

## **줄 내 폰트 정렬**

줄 내에서 서로 다른 폰트 크기의 텍스트 구간을 수직으로 정렬하려면 [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/)을 사용합니다. 이 설정은 전체 단락에 적용되며 각 줄 내 정렬을 제어합니다.

다음 독립적인 예제는 하나의 슬라이드에 네 개의 레이블이 있는 텍스트 상자를 만듭니다. 각 단락은 18, 36, 54포인트 크기의 동일한 텍스트를 포함하고, 서로 다른 폰트 정렬을 적용합니다. Arial을 사용하고 자동 맞춤 및 줄 바꿈을 비활성화하며 텍스트 프레임을 한 줄에 충분히 크게 유지합니다.

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

![혼합된 폰트 크기에서 기준선, 위쪽, 가운데 및 아래쪽 폰트 정렬 비교](font_alignment.png)

폰트 정렬은 폰트 메트릭을 사용하므로 개별 문자 가장자리가 정확히 맞지 않을 수 있습니다. 이 예제에는 대문자와 하강자를 포함하여 기준선과 아래쪽 정렬의 차이를 보여줍니다. 폰트 가용성 및 대체, 사용된 문자, 폰트 크기 차이가 결과에 영향을 미칩니다. 프레임 크기, 여백, 줄 간격, 줄 바꿈 및 자동 맞춤도 레이아웃에 영향을 주므로 모드를 비교할 때 동일한 폰트와 레이아웃 설정을 사용하십시오.

이 설정은 수평 단락 정렬을 제어하는 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 및 텍스트 블록을 도형 내부에 수직으로 배치하는 [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)와 다릅니다. [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/)을 통한 위첨자 및 아래첨자 서식은 개별 구간을 기준선에 대해 이동시키며, 단락 줄에 대한 폰트 정렬을 설정하지는 않습니다.

## **텍스트 투명도 설정**

텍스트 투명도는 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)에 지정된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0–255 범위의 ARGB 알파 채널 값이며, 투명도 퍼센트가 아닙니다.

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

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 구간**에 투명도를 적용하는 방법을 보여줍니다:

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
            # 텍스트 구간의 투명도를 설정합니다.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![투명한 텍스트 구간](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

텍스트 상자 내 문자 간격을 늘리거나 줄이려면 [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/)를 사용합니다. 예제에서는 3포인트 간격을 추가하며, 음수 값은 텍스트를 압축합니다.

다음 파이썬 코드는 **전체 단락**의 문자 간격을 확장하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 참고: 문자 간격을 압축하려면 음수를 사용하십시오.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 문자 간격을 확장합니다.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

다음 코드 예제는 **굵은 글꼴이 적용된 텍스트 구간**의 문자 간격을 확장하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 참고: 문자 간격을 압축하려면 음수를 사용하십시오.
            portion.portion_format.spacing = 3  # 문자 간격을 확장합니다.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![텍스트 구간의 문자 간격](character_spacing_in_text_portions.png)

### **특정 폰트에 대한 커닝 비활성화**

Aspose.Slides에서 렌더링된 텍스트가 PowerPoint에서 표시되는 텍스트보다 약간 더 촘촘하게 보일 수 있습니다. 이는 PowerPoint가 특정 폰트에 대해 커닝 데이터를 무시할 수 있기 때문이며, 해당 폰트에 유효한 커닝 정보가 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우에 PowerPoint와 더 가깝게 렌더링하려면 영향을 받는 폰트를 사용하는 텍스트 구간에 대해 커닝을 비활성화할 수 있습니다. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/)을 실제 폰트 크기보다 큰 값으로 설정하십시오. 이 예제는 첫 번째 슬라이드 첫 번째 도형에 텍스트 상자가 있는 "presentation.pptx"가 필요합니다. 효과적인 폰트 이름(상속된 폰트 포함)을 확인하고 Roboto를 사용하는 구간에 대해 100포인트 임계값을 설정합니다. 이렇게 하면 100포인트 미만의 폰트 크기를 가진 해당 구간의 커닝이 비활성화됩니다:

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

임계값 이하의 일치 텍스트에 대해 이 설정은 커닝을 방지하고 PowerPoint에서 해당 폰트에 적용되는 동작과 더 일치하도록 도와줍니다.

## **텍스트 폰트 속성 관리**

폰트 속성은 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)을 통해 단락 수준에서 설정하거나, 개별 구간에 대해서는 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)을 통해 설정할 수 있습니다.

다음 예제는 첫 번째 단락의 기본 폰트를 12포인트 Times New Roman으로 설정하고 굵게, 기울임꼴 및 점선 밑줄 서식을 적용합니다. 개별 구간에 대한 명시적인 서식이 이러한 기본값보다 우선합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 단락에 대한 폰트 속성을 설정합니다.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락의 폰트 속성](font_properties_for_paragraph.png)

다음 예제는 효과적인 서식이 굵게인 구간에 13포인트 Times New Roman, 기울임꼴 및 점선 밑줄을 적용합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 텍스트 구간에 대한 폰트 속성을 설정합니다.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![텍스트 구간의 폰트 속성](font_properties_for_text_portions.png)

## **텍스트 높이 정규화 제어**

템플릿 타이포그래피를 재현하거나 문자 높이 차이를 조사할 때 [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/)를 사용하십시오. PowerPoint에서 정규화를 활성화하면 개별 문자를 수직으로 늘리거나 압축하여 텍스트 구간 내에서 균일한 시각적 높이를 제공합니다. 이는 다른 폰트 간에 동일한 텍스트 높이를 보장하지는 않습니다.

속성을 [NullableBool.TRUE 또는 FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)로 설정하여 정규화를 명시적으로 활성화 또는 비활성화할 수 있습니다. `NullableBool.NOT_DEFINED`는 로컬 설정을 지정하지 않아 단락의 [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 등에서 값을 상속받게 합니다. 이는 `False`와 동일하지 않습니다. 해결된 부울 값을 얻으려면 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)와 [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/)를 사용하십시오.

다음 독립적인 예제는 **Arial**이 설치되어 있어야 합니다. 54포인트 크기의 동일한 대문자, 소문자, 하강자 및 억음 문자를 포함하는 두 개의 텍스트 블록을 만듭니다. 두 단락 모두 기본적으로 정규화를 활성화합니다. 위쪽 구간은 명시적으로 비활성화하고, 아래쪽 구간은 상속받습니다. 프레임 크기, 여백 및 단락 간격은 동일하며, 래핑 및 자동 맞춤을 비활성화하여 비교를 일관되게 유지합니다. 예제는 `FALSE: False`와 `NOT_DEFINED: True`를 출력한 후 "text_height_normalization.pptx"를 저장합니다:

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

아래 비교는 저장된 프레젠테이션에서 내보낸 것입니다. 위 행은 정규화가 비활성화된(`FALSE`) 상태이고, 아래 행은 활성화된 설정을 상속받은(`NOT_DEFINED` → `True`) 상태입니다. 동일한 모습을 재현하려면 Arial이 설치되어 있어야 합니다.

![Arial 54포인트 텍스트, 위는 정규화 비활성화, 아래는 상속된 정규화 활성화](text_height_normalization.png)

정규화는 할당된 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 값을 변경하지 않고 문자 높이를 바꾸며, 이 값은 포인트 단위의 폰트 크기를 지정합니다. 단락의 [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/)은 줄 간격을 제어하고, 텍스트 프레임의 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)은 텍스트나 컨테이너가 맞추기 위해 어떻게 조정되는지를 제어합니다. 이러한 설정은 서로 다른 목적을 가지며 전체 레이아웃에 독립적으로 영향을 줄 수 있습니다. 단락 서식 및 상속에 대한 자세한 내용은 [단락 관리](/slides/ko/python-net/manage-paragraph/)를 참조하십시오.

## **취소선 적용 및 제거**

텍스트 구간에 [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/)을 사용하면 원본 텍스트를 삭제하지 않고 수정, 취소된 용어 또는 이전 가격을 표시할 수 있습니다. 한 줄 또는 두 줄의 취소선을 적용하려면 각각 [TextStrikethroughType.SINGLE 또는 DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/)을 설정합니다.

취소선을 제거하려면 `TextStrikethroughType.NONE`을 할당하십시오. 이렇게 하면 주변 서식이 취소선을 지정하더라도 효과가 명시적으로 비활성화됩니다. 반면 `TextStrikethroughType.NOT_DEFINED`는 로컬 설정을 정의하지 않아 구간이 단락 등에서 서식을 상속받게 합니다. 이는 취소선이 반드시 제거된다는 보장은 아닙니다. 결과 서식을 읽으려면 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)를 사용하십시오.

다음 독립적인 예제는 세 개의 가격 비교를 생성합니다. 각 단락은 레이블, 이전 가격, 현재 가격에 대한 별도 구간을 가지고 있어 이전 가격에만 영향을 줍니다. 첫 번째 행은 취소선을 적용한 뒤 제거하고, 다른 행은 각각 단일 및 이중 취소선을 유지합니다. 이 속성을 변경하면 텍스트와 다른 서식(예: 굵은 이전 가격)은 유지됩니다:

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

    # 스트라이크스루를 적용한 다음 첫 번째 이전 가격에서 명시적으로 제거합니다.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

결과(위에서 아래 순서): 취소선 없음, 단일 취소선, 이중 취소선.

![취소선이 없는 이전 가격, 단일 취소선, 이중 취소선](strikethrough.png)

## **텍스트 회전 설정**

텍스트 프레임 내에서 미리 정의된 텍스트 방향을 설정하려면 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)을 사용하십시오.

다음 코드 예제는 텍스트를 **시계 반대 방향으로 90도** 회전하는 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)으로 설정합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임 사용자 정의 회전 설정**

텍스트 프레임에 대한 사용자 정의 회전 각도를 지정하려면 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)을 사용하고, [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)에 적용하십시오.

다음 코드 예제는 도형 내 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![사용자 정의 텍스트 회전](custom_text_rotation.png)

## **단락 줄 간격 설정**

Aspose.Slides는 [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/)를 제공하여 단락 간격을 제어합니다. 이러한 속성은 다음과 같이 사용됩니다:

* 양의 값을 사용하면 줄 간격을 줄 높이의 백분율로 지정합니다.
* 음의 값을 사용하면 줄 간격을 포인트 단위로 지정합니다.

다음 예제는 첫 번째 단락의 내부 간격을 줄 높이의 200%(두 배)로 설정합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락 내 줄 간격](line_spacing.png)

## **줄 바꿈 제어**

줄 바꿈 규칙은 좁은 텍스트 블록과 라틴어 및 동아시아 텍스트가 혼합된 프레젠테이션에 유용합니다. 다음 속성은 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)에 속하므로 전체 단락에 적용됩니다:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/)은 라틴어 줄 바꿈 규칙을 제어합니다. 혼합 텍스트에서 이를 변경하면 인접한 동아시아 텍스트와 구두점의 줄 바꿈 위치도 변경될 수 있습니다.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/)은 동아시아 줄 바꿈 규칙을 제어하며, 줄 시작 및 끝에 배치될 수 없는 문자에 대한 제한을 포함합니다.

이 규칙은 텍스트 프레임 내 자동 줄 바꿈을 활성화하는 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)을 대체하지 않으며, 자동 줄 바꿈이 발생할 때 레이아웃에 영향을 미칩니다. 줄 바꿈 문자를 삽입하지는 않으며, 명시적인 줄 바꿈은 가용 너비와 무관하게 단락 내에 새 줄을 강제로 삽입합니다.

다음 독립적인 예제는 중국어와 라틴어 텍스트가 포함된 좁은 텍스트 블록을 만들고 두 줄 바꿈 속성을 명시적으로 설정한 뒤 "line_breaking.pptx"를 저장합니다. 각 규칙을 실험하려면 다른 속성의 값을 고정한 상태에서 해당 속성 값을 변경하십시오. 예제는 24포인트 Arial 및 SimSun을 사용하고 프레임 너비는 160포인트, 텍스트 프레임 가로 여백은 0으로 설정합니다. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)은 텍스트 크기와 프레임 차원을 고정하기 위해 [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/)으로 설정됩니다:

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

## **걸이 구두점 제어**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/)을 사용하면 해당 구두점이 다음 줄에 배치되지 않고 텍스트 라인의 오른쪽 끝을 넘어 확장될 수 있습니다. 이는 전체 단락에 적용되며 걸이 들여쓰기와는 다릅니다.

다음 독립적인 예제는 100포인트 너비 텍스트 프레임에서 걸이 구두점을 활성화하고 "hanging_punctuation.pptx"를 저장합니다. 24포인트 Arial 및 가로 여백 0인 경우, 마지막 마침표는 "sentence" 뒤에 남아 오른쪽 텍스트 가장자리를 넘어갑니다. 속성을 [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)로 설정하면 비교할 수 있습니다. 이 설정에서는 마침표가 별도 줄에 배치됩니다. 줄 바꿈은 활성화하고 자동 맞춤은 비활성화하여 가용 너비를 고정합니다:

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

모든 구두점이 걸이될 수 있는 것은 아닙니다. 눈에 보이는 결과는 [폰트 및 레이아웃 조건](#control-line-breaking)에 따라 달라지며, 폰트, 가용 너비, 여백 또는 자동 맞춤 설정을 변경하면 눈에 보이는 차이가 사라질 수 있습니다.

## **텍스트 프레임 자동 맞춤 유형 설정**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)은 텍스트가 컨테이너 경계를 초과할 때 텍스트가 어떻게 동작하는지를 결정합니다. 텍스트가 축소, 넘침 또는 도형이 자동으로 크기를 조정하도록 제어할 수 있습니다. 다음 예제는 텍스트에 맞추기 위해 도형을 크기 조정하도록 구성하고 결과를 "autofit_type.pptx"에 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

자동 줄 바꿈 후 라인 수를 계산하고 텍스트 또는 도형 너비가 결과에 어떻게 영향을 미치는지 확인하려면 [렌더링된 라인 수 계산](/slides/ko/python-net/manage-paragraph/)을 참조하십시오. 라인 수만으로는 텍스트가 컨테이너를 초과했는지 여부를 판단할 수 없습니다.

## **텍스트 프레임 기준점 설정**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)은 텍스트가 도형 내부에서 수직으로 어떻게 배치되는지를 정의합니다(예: 위, 가운데, 아래). 다음 예제는 텍스트를 첫 번째 도형의 아래쪽에 고정하고 결과를 "text_anchor.pptx"에 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **텍스트 탭 설정**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/)와 [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/)를 사용하여 단락의 탭 정지를 구성합니다. 다음 예제는 기본 탭 간격을 100포인트로 설정하고 30포인트에 왼쪽 정렬 탭 정지를 추가합니다. 이러한 설정은 탭 문자를 포함한 텍스트에 영향을 줍니다:

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

결과:

![단락 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)를 제공하여 텍스트 구간의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행할 때 사용되는 언어를 결정합니다.

다음 예제는 첫 번째 슬라이드 첫 번째 도형에 텍스트 상자가 있는 "presentation.pptx"가 필요합니다. 첫 번째 단락의 내용을 "1。"로 교체하고, 폰트를 SimSun으로 설정한 뒤, 교정 언어를 Simplified Chinese(`zh-CN`)로 지정합니다. 결과를 "proofing_language.pptx"에 저장합니다:

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

## **기본 언어 설정**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/)를 사용하여 프레젠테이션을 로드하거나 생성할 때 생성되는 텍스트의 기본 언어를 정의합니다. 다음 예제는 기본 텍스트 언어를 미국 영어로 설정하고 텍스트 상자를 추가한 뒤 첫 번째 텍스트 구간의 언어를 `en-US`로 출력합니다:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 텍스트가 포함된 새로운 사각형 도형을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 첫 번째 구간의 언어를 확인합니다.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)를 사용하십시오.

다음 예제는 새 프레젠테이션의 최상위 단락에 14포인트 굵은 폰트를 기본값으로 설정하고 이를 "default_text_style.pptx"에 저장합니다. 텍스트는 보다 구체적인 서식이 없으면 이러한 기본값을 상속받습니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 최상위 수준의 단락 서식을 가져옵니다.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **전체 대문자 효과로 텍스트 추출**

PowerPoint에서 **전체 대문자** 글꼴 효과를 적용하면 원래 소문자로 입력된 텍스트도 슬라이드에서는 대문자로 표시됩니다. Aspose.Slides로 해당 텍스트 구간을 가져오면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)을 확인하고 값이 `ALL`인 경우 반환된 문자열을 대문자로 변환하십시오.

이 예제는 첫 번째 슬라이드 첫 번째 도형에 텍스트 상자가 있는 "sample2.pptx"가 필요합니다. 첫 번째 단락의 첫 번째 구간에 전체 대문자 효과가 적용된 "Hello, Aspose!"가 포함되어 있습니다.

![전체 대문자 효과](all_caps_effect.png)

다음 코드 예제는 **전체 대문자** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

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

**슬라이드의 표에서 텍스트를 어떻게 수정합니까?**

표의 텍스트를 수정하려면 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)을 사용하십시오. 셀을 순회하면서 각 셀을 [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)을 통해 업데이트하고, [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/)을 통해 단락 서식을 업데이트하십시오.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 어떻게 적용합니까?**

그라디언트 색을 적용하려면 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)을 사용하십시오. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)을 [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)으로 설정하고 그라디언트 정지점, 방향 및 투명도를 구성하십시오.

관련 기능: [슬라이드 내 텍스트 서식 지정](/slides/ko/features/text-formatting/).