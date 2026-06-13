---
title: Python에서 PowerPoint 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/python-net/presentation-theme/
keywords:
- PowerPoint 테마
- 프레젠테이션 테마
- 슬라이드 테마
- 테마 설정
- 테마 변경
- 테마 관리
- 테마 색상
- 추가 팔레트
- 테마 글꼴
- 테마 스타일
- 테마 효과
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 통한 .NET으로 프레젠테이션 테마를 마스터하여 일관된 브랜드를 유지하면서 PowerPoint 파일을 만들고, 사용자 정의하고, 변환합니다."
---
## **소개**

프레젠테이션 테마는 디자인 요소의 속성을 정의합니다. 테마를 선택하면 시각 요소와 해당 속성이 조화된 세트를 선택하는 것입니다.

PowerPoint에서 테마는 색상, [글꼴](/slides/ko/python-net/powerpoint-fonts/), [배경 스타일](/slides/ko/python-net/presentation-background/), 및 효과를 포함합니다.

![theme-constituents](theme-constituents.png)

## **테마 색상 변경**

PowerPoint 테마는 슬라이드의 다양한 요소에 대해 특정 색상 집합을 사용합니다. 기본값이 마음에 들지 않으면 새 테마 색상을 적용하여 변경할 수 있습니다. 새로운 테마 색상을 선택할 수 있도록 Aspose.Slides는 [SchemeColor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/schemecolor/) 열거형에 값을 제공합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

다음과 같이 결과 색상의 실제 값을 확인할 수 있습니다:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# 예제 출력:
#
# ff8064a2 (색상 [A=255, R=128, G=100, B=162])
```

색상 변경을 추가로 보여주기 위해 다른 요소를 만들고, 초기 단계에서의 강조 색상을 할당한 다음 테마 색상을 업데이트합니다.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

새 색상은 두 요소에 자동으로 적용됩니다.

### **추가 팔레트에서 테마 색상 설정**

주 테마 색상(1)에 광도 변환을 적용하면 추가 팔레트(2)의 색상이 생성됩니다. 그런 다음 해당 테마 색상을 설정하고 검색할 수 있습니다.

![additional-palette-colors](additional-palette-colors.png)

**1** — 주요 테마 색상  
**2** — 추가 팔레트의 색상  

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 강조 색상 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # 강조 색상 4, 밝게 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # 강조 색상 4, 밝게 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # 강조 색상 4, 밝게 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # 강조 색상 4, 어둡게 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # 강조 색상 4, 어둡게 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **`SchemeColor`를 `ColorScheme` 색으로 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/schemecolor/)를 사용할 때 다음과 같은 테마 색상 값이 포함되어 있음을 알 수 있습니다:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, and `TEXT2`.

하지만 `Presentation.master_theme.color_scheme`는 [ColorScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/colorscheme/)을 반환하며, 해당 색상을 다음과 같이 제공합니다:

`dark1`, `dark2`, `light1`, and `light2`.

이 차이는 명명 방식만 다른 것입니다. 이 값들은 동일한 테마 색상 슬롯을 가리키며 매핑은 고정되어 있습니다:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

`TEXT`/`BACKGROUND`와 `dark`/`light` 사이에 동적 변환은 없습니다. 단순히 같은 테마 색상의 다른 이름일 뿐입니다.

이 명명 차이는 Microsoft Office 용어에서 비롯되었습니다. 기존 Office 버전에서는 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`를 사용했으며, 최신 UI에서는 동일한 슬롯을 `Text 1`, `Background 1`, `Text 2`, `Background 2`로 표시합니다.

## **테마 글꼴 변경**

테마와 기타 목적을 위한 글꼴 선택을 가능하게 하기 위해 Aspose.Slides는 PowerPoint와 유사한 다음 특수 식별자를 사용합니다:

- **+mn-lt** — 본문 라틴어 글꼴 (Minor Latin Font)
- **+mj-lt** — 제목 라틴어 글꼴 (Major Latin Font)
- **+mn-ea** — 본문 동아시아 글꼴 (Minor East Asian Font)
- **+mj-ea** — 제목 동아시아 글꼴 (Major East Asian Font)

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

다음 Python 예제는 프레젠테이션의 테마 글꼴을 변경하는 방법을 보여줍니다:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

모든 텍스트 상자가 새 글꼴로 업데이트됩니다.

{{% alert color="primary" title="TIP" %}}
자세한 내용은 [Python으로 마스터 PowerPoint 글꼴](/slides/ko/python-net/powerpoint-fonts/)을 참조하십시오.
{{% /alert %}}

## **테마 배경 스타일 변경**

기본적으로 PowerPoint는 12개의 미리 정의된 배경을 제공하지만, 일반적인 프레젠테이션은 그 중 3개만 저장합니다.

![todo:image_alt_text](presentation-design_8.png)

예를 들어, PowerPoint에서 프레젠테이션을 저장한 후 다음 Python 코드를 실행하여 포함된 미리 정의된 배경 수를 확인할 수 있습니다:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
[FormatScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/) 클래스의 `background_fill_styles` 속성을 사용하면 PowerPoint 테마에서 배경 스타일을 추가하거나 접근할 수 있습니다.
{{% /alert %}}

```python
presentation.masters[0].background.style_index = 2  # 0은 채우기 없음; 인덱스는 1부터 시작합니다.
```

{{% alert color="primary" title="TIP" %}}
자세한 내용은 [Python에서 프레젠테이션 배경 관리](/slides/ko/python-net/presentation-background/)를 확인하십시오.
{{% /alert %}}

## **테마 효과 변경**

PowerPoint 테마는 일반적으로 각 스타일 배열에 세 가지 값을 포함합니다. 이러한 배열은 미묘, 보통, 강도라는 세 가지 효과 수준으로 결합됩니다. 예를 들어, 특정 도형에 이러한 효과를 적용했을 때의 결과는 다음과 같습니다:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/) 클래스의 세 속성—`FillStyles`, `LineStyles`, `EffectStyles`—을 사용하면 PowerPoint보다 더 유연하게 테마 요소를 수정할 수 있습니다.

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

결과적인 변경 사항에는 채우기 색, 채우기 유형, 그림자 효과 및 기타 속성 업데이트가 포함됩니다:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**마스터를 변경하지 않고 단일 슬라이드에 테마를 적용할 수 있나요?**  
예. Aspose.Slides는 슬라이드 수준 테마 재정의를 지원하므로, 마스터 테마는 그대로 유지하면서 해당 슬라이드에만 로컬 테마를 적용할 수 있습니다([SlideThemeManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/slidethememanager/)를 통해).

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 안전하게 옮기는 방법은 무엇인가요?**  
[슬라이드 복제](/slides/ko/python-net/clone-slides/)를 마스터와 함께 대상 프레젠테이션에 복사합니다. 이렇게 하면 원본 마스터, 레이아웃 및 관련 테마가 보존되어 외관이 일관됩니다.

**모든 상속 및 재정의 후의 “실제(effective)” 값은 어떻게 확인할 수 있나요?**  
테마/색상/글꼴/효과에 대한 API의 ["effective" 뷰](/slides/ko/python-net/shape-effective-properties/)를 사용하십시오. 이러한 뷰는 마스터와 로컬 재정의를 적용한 후 해결된 최종 속성을 반환합니다.