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
- 외부 테마
- THMX
- 테마 색상
- 추가 팔레트
- 테마 글꼴
- 테마 스타일
- 테마 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET을 통해 Python용 Aspose.Slides에서 프레젠테이션 테마를 마스터하여 일관된 브랜드 적용으로 PowerPoint 파일을 만들고, 사용자 지정하며, 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서 프레젠테이션 수준의 테마는 [Presentation.master_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/master_theme/) 속성을 통해 사용할 수 있습니다. 프레젠테이션은 또한 하위 수준에서 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/masterthememanager/override_theme/)를 통해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃은 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)를 통해 상속된 테마를 재정의할 수 있으며, 개별 슬라이드도 동일하게 할 수 있습니다. 실제로 슬라이드의 유효 테마는 다음 상속 체인을 통해 해결됩니다: 프레젠테이션 테마, 마스터 재정의, 레이아웃 재정의 및 슬라이드 재정의.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 상속 및 재정의가 해결된 후 유효 값을 읽기.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/) 객체는 테마의 [color_scheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/font_scheme/), 및 [format_scheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/format_scheme/) 속성을 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하는 것은 프레젠테이션이 외부 소스에서 온 경우 특히 유용합니다. 스타일 항목의 수와 내용은 다양할 수 있기 때문입니다.

다음 예제는 기본 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일이 각각 얼마나 있는지 보고합니다:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

파일에 여러 마스터가 사용되는 경우 모든 슬라이드가 동일한 유효 테마를 가지고 있다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 재정의가 존재할 수 있는 경우 이 문서 아래에 나와 있는 유효 테마 작업 흐름을 사용하세요.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. 테마의 [ColorScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/colorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 아직 참조하고 있는 모든 객체가 새 값으로 해결됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트에 영향을 받지 않습니다.

다음 끝‑끝 예제는 `ACCENT4`를 사용하는 도형을 만들고, 테마의 `accent4` 색상을 빨간색으로 변경한 뒤 프레젠테이션을 저장하고 다시 열어 유효 채우기 색상을 출력합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

사각형이 `ACCENT4`에 계속 연결되어 있기 때문에 테마가 변경된 후 표시 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정하면 이후 `accent4` 변경이 해당 채우기에 영향을 주지 않습니다.

### **추가 팔레트에서 색상 사용**

PowerPoint는 테마 색상에 색상 변환을 적용하여 더 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![주요 테마 색상 및 추가 팔레트에서 생성된 밝고 어두운 색상](additional-palette-colors.png)

**1** - 주요 테마 색상.

**2** - 주요 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `ACCENT4`를 기반으로 하는 여섯 개의 사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

이 변형은 여전히 테마 색상을 기반으로 합니다. `accent4`가 이후에 변경되면 변환된 색상은 새로운 `accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `ColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/schemecolor/) 열거형은 `TEXT1`, `BACKGROUND1`, `TEXT2`, `BACKGROUND2`를 사용하고, [ColorScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/colorscheme/)은 동일한 테마 슬롯을 `dark1`, `light1`, `dark2`, `light2`로 노출합니다. 매핑은 고정됩니다:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

이는 동일한 테마 슬롯에 대한 대체 이름이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스킴에는 헤딩용 주요 글꼴 세트와 본문용 보조 글꼴 세트가 포함됩니다. [FontScheme.major](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/major/) 및 [FontScheme.minor](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/minor/) 속성이 해당 세트를 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj-lt` - 헤딩 글꼴 라틴어 (Major Latin Font)
* `+mn-ea` - 본문 글꼴 동아시아 (Minor East Asian Font)
* `+mj-ea` - 헤딩 글꼴 동아시아 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 헤딩 하나와 보조 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

헤딩은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 테마 식별자가 아닌 명시적 글꼴 이름을 가진 텍스트는 테마 글꼴 스킴이 변경되어도 자동으로 전환되지 않습니다.

주요 및 보조 글꼴 컬렉션에는 키릴문자, 아랍어, 일본어, 조지아어, 타아나 등 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/python-net/script-specific-font-mappings/)를 참조하세요.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/python-net/powerpoint-fonts/)를 참조하십시오.
{{% /alert %}}

## **테마 복사 또는 적용**

아래 작업 흐름은 다양한 테마 관련 문제를 해결합니다.

### **마스터에 의존하는 슬라이드에 외부 테마 적용**

PowerPoint 테마 파일(`.thmx`)이 있고 특정 마스터에 의존하는 모든 슬라이드의 스타일을 바꾸려면 [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/)를 사용하세요. [Presentation.masters](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/masters/) 컬렉션에서 마스터를 선택하고, 해당 마스터는 [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/)을 구현합니다. 그런 다음 테마 파일 경로를 메서드에 전달합니다.

이 메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 외부 테마를 새 마스터에 적용합니다.
1. 이전에 선택한 마스터에 의존하던 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 만든 [IMasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterslide/)를 반환합니다.

다음 예제는 첫 번째 마스터에 의존하는 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxexception/) 또는 해당 형식 관련 하위 클래스 중 하나를 발생시킬 수 있습니다. 사용자 제공 경로를 검증하고 파일 시스템 액세스 오류를 처리하며 테마 적용이 성공적으로 완료된 후에만 프레젠테이션을 저장하세요.

선택한 마스터에 의존하던 슬라이드만 재할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 따라 해결됩니다. 직접 할당된 색상, 글꼴, 채우기 및 기타 명시적 서식은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 재정의도 새 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 런타임 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [custom font sources](/slides/ko/python-net/custom-font/)를 통해 제공하거나 [font substitution](/slides/ko/python-net/font-substitution/)을 구성하세요.

이것은 직접적인 마스터 수준 작업 흐름이며, 메서드는 `.thmx` 파일 경로만 받으며 슬라이드‑level 또는 레이아웃‑level 테마 재정의를 수동으로 생성할 필요가 없습니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

관련 마스터를 사전에 알 수 없는 경우, [Slide.layout_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/layout_slide/)와 [LayoutSlide.master_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/master_slide/)을 통해 대표 슬라이드에서 마스터를 가져오세요. 테마를 적용하기 전에 원본 마스터 참조를 저장하세요. 각 호출은 프레젠테이션에 새로운 마스터를 생성합니다.

다음 예제는 두 섹션의 슬라이드를 사용해 각각의 마스터를 찾고, 각 그룹에 서로 다른 외부 테마를 적용합니다:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

첫 번째 호출은 `first_group_master`에 의존하던 슬라이드에만 영향을 주고, 두 번째 호출은 `second_group_master`에 의존하던 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 스타일이 변경되지 않습니다.

### **슬라이드 이동 시 원본 테마 유지**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 유지하려면 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/add_clone/)를 사용해 소스 마스터를 대상 프레젠테이션에 복제한 뒤, [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)와 복제된 마스터를 사용해 슬라이드를 복제하세요. 이렇게 하면 마스터와 레이아웃, 관련 테마가 함께 복사됩니다.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

대상 프레젠테이션에 슬라이드를 동일하게 표시해야 할 때 선호되는 작업 흐름입니다. 무관한 대상 마스터에만 콘텐츠를 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드를 현재 마스터와 레이아웃에 그대로 두고 소스 테마에서 슬라이드‑level 재정의를 초기화하려면 [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 메서드를 사용해 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

이렇게 하면 다른 슬라이드가 상속하는 테마는 그대로 두고 해당 슬라이드에만 테마가 변경됩니다. 로컬 재정의를 제거하고 상속값으로 돌아가려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/clear/)를 호출하세요.

### **레이아웃에 테마 재정의 적용**

레이아웃‑level 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 특정 슬라이드에 자체 재정의가 있는 경우에는 그 슬라이드가 우선합니다. 동일한 초기화 메서드는 레이아웃의 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/layoutslidethememanager/)를 통해 사용할 수 있습니다:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃 군에 다른 스타일링이 필요할 때는 레이아웃 재정의를, 진정한 예외가 있을 때만 슬라이드 재정의를 사용하세요. 과도한 슬라이드‑level 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/background_fill_styles/)에 저장됩니다. PowerPoint UI에서는 실제 컬렉션에 물리적으로 저장된 채우기 정의보다 더 많은 배경 옵션을 표시할 수 있습니다. UI는 테마 채우기와 테마 색상 및 기타 스타일 참조를 결합할 수 있기 때문입니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.style_index](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/style_index/)를 검사하세요. `style_index`가 `0`이면 테마 채우기가 없으며, 양수 값은 테마 배경‑style 참조를 의미합니다. 이는 Python 컬렉션을 직접 인덱싱할 때 `[0]`이 첫 번째 저장 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션에 동일한 배경 채우기 스타일 수가 있다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드 수준에서의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하고 있다면 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 최종 상속된 배경을 알아야 할 경우 [Background.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/get_effective/)를 사용하세요.

{{% alert color="warning" title="Warning" %}}
`style_index`를 0부터 시작하는 컬렉션 인덱스로 취급하지 마세요. 또한 하나의 파일에서 사용한 스타일 번호를 다른 파일에 그대로 적용한다고 가정하지 마세요. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/python-net/presentation-background/)를 참조하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스킴에는 별도의 [FormatScheme.fill_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/line_styles/), 및 [FormatScheme.effect_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/effect_styles/) 컬렉션이 포함됩니다. 일반적인 Office 테마에는 미묘, 보통, 강렬한 서식을 시각적으로 나타내는 세 개의 주요 스타일 항목이 포함되는 경우가 많지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![같은 도형에 적용된 미묘, 보통, 강렬 테마 효과](presentation-design_10.png)

Python에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0부터 시작합니다: `[0]`은 첫 번째 저장 스타일이고 `[2]`는 세 번째 스타일입니다. 도형의 스타일‑reference 인덱스는 별개의 개념이며, [IShapeStyle](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapestyle/)를 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하고, 세 번째 효과 스타일에 외부 그림자를 적용한 뒤 결과를 저장합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

이 슬롯을 참조하는 도형의 경우 첫 번째 테마 선 스타일이 빨간색이 되고, 세 번째 테마 채우기 스타일이 단단한 숲 녹색이 되며, 세 번째 효과 스타일에 거리 10포인트의 외부 그림자가 추가됩니다. 정확한 시각적 결과는 각 도형이 어떤 슬롯을 참조하고 직접 서식이 테마를 재정의했는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **유효 테마 값 읽기**

원시 테마 객체는 특정 레벨에 정의된 내용을 알려줍니다. 유효 값은 상속 및 로컬 재정의가 해결된 후 슬라이드 또는 도형이 실제로 사용하는 값을 알려줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)를 호출하세요. 배경의 경우 [Background.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/get_effective/)를, 채우기의 경우 [FillFormat.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/get_effective/)를 사용합니다.

다음 예제는 슬라이드에서 유효 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

렌더링 진단, 검증 및 비교를 위해 유효 데이터를 사용하세요. [Presentation.master_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/master_theme/)만 검사하면 최종 외관을 변경하는 마스터, 레이아웃, 슬라이드 또는 도형 재정의를 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드에 영향을 줍니까?**

아니요. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/)는 선택한 마스터에 의존하는 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에만 테마를 적용할 수 있나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/slidethememanager/)를 사용하고 해당 슬라이드의 재정의 테마를 초기화하세요. 변경은 해당 슬라이드에만 적용되며, 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 전달하는 가장 안전한 방법은?**

슬라이드를 이동하면서 원본 외관을 보존하려면 소스 마스터를 대상에 복제하고, [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/add_clone/)와 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)를 사용해 해당 마스터와 함께 슬라이드를 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 유효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마의 경우 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)를, 포맷 객체(예: [Background.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/get_effective/) 및 [FillFormat.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/get_effective/))의 경우 해당 유효‑data 메서드를 사용하세요. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.