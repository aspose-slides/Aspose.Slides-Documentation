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
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 맞춤화하고, 변환하기 위해 프레젠테이션 테마를 마스터합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 개체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 개체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서는 프레젠테이션 수준 테마를 [Presentation.master_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/master_theme/) 속성을 통해 사용할 수 있습니다. 프레젠테이션은 낮은 수준에서도 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/masterthememanager/override_theme/)을 통해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃은 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)을 통해 상속된 테마를 재정의할 수 있으며, 개별 슬라이드도 동일하게 할 수 있습니다. 실제로 슬라이드의 유효 테마는 다음과 같은 상속 체인을 통해 해석됩니다: 프레젠테이션 테마, 마스터 재정의, 레이아웃 재정의, 슬라이드 재정의.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후 유효 값을 읽기.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/) 개체는 테마의 [color_scheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/font_scheme/), 그리고 [format_scheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/mastertheme/format_scheme/) 속성을 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하면 프레젠테이션이 외부 소스에서 가져온 경우 스타일 항목의 수와 내용이 달라질 수 있기 때문에 특히 유용합니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일의 개수를 보고합니다:

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

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 유효 테마를 가진다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 재정의가 존재할 수 있는 경우 이 기사에서 나중에 보여줄 유효-테마 작업 흐름을 사용하세요.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. 테마의 [ColorScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/colorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 아직 참조하고 있는 모든 개체가 새 값에 맞게 해석됩니다. 직접 RGB 색상을 사용하는 개체는 테마 색상 업데이트에 의해 변경되지 않습니다.

다음 엔드‑투‑엔드 예제는 `ACCENT4`를 사용하는 도형을 만든 뒤 테마의 `accent4` 색상을 빨간색으로 변경하고, 프레젠테이션을 저장한 뒤 다시 열어 유효 채우기 색상을 출력합니다:

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

사각형이 `ACCENT4`에 계속 연결되어 있기 때문에 테마가 변경된 후 표시 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정하여 스킴 색상을 대체하면 이후 `accent4` 변경이 해당 채우기에 영향을 주지 않게 됩니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 색상 변환을 적용하여 테마 색상에서 더 밝고 더 어두운 변형을 파생합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![추가 팔레트에서 생성된 기본 테마 색상 및 더 밝고 더 어두운 색상](additional-palette-colors.png)

**1** - 기본 테마 색상.

**2** - 기본 테마 색상에서 생성된 더 밝고 더 어두운 변형.

다음 예제는 `ACCENT4`를 기반으로 여섯 개의 사각형을 만들고 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

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

이 변형들은 여전히 테마 색상을 기반으로 합니다. `accent4`가 나중에 변경되면 변환된 색상은 새로운 `accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `ColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/schemecolor/) 열거형은 `TEXT1`, `BACKGROUND1`, `TEXT2`, `BACKGROUND2`를 사용하고, [ColorScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/colorscheme/)은 동일한 테마 슬롯을 `dark1`, `light1`, `dark2`, `light2`로 노출합니다. 매핑은 고정됩니다:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

이는 동일한 테마 슬롯에 대한 대체 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스키마는 제목에 대한 주요 폰트 집합과 본문 텍스트에 대한 부수 폰트 집합을 포함합니다. [FontScheme.major](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/major/) 및 [FontScheme.minor](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/minor/) 속성을 통해 해당 집합을 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj-lt` - 제목 글꼴 라틴어 (Major Latin Font)
* `+mn-ea` - 본문 글꼴 동아시아 (Minor East Asian Font)
* `+mj-ea` - 제목 글꼴 동아시아 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 부수 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

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

제목은 주요 글꼴을 따르고 본문 텍스트는 부수 글꼴을 따릅니다. 테마 식별자 대신 명시적인 글꼴 이름이 지정된 텍스트는 테마 글꼴 스키마가 변경되어도 자동으로 전환되지 않습니다.

주요 및 부수 글꼴 컬렉션에는 키릴 문자, 아랍어, 일본어, 그루지야 문자, 타나 문자와 같은 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script-Specific Theme Fonts](/slides/ko/python-net/script-specific-font-mappings/)를 참조하세요.

{{% alert color="info" title="팁" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/python-net/powerpoint-fonts/)를 참고하세요.
{{% /alert %}}

## **테마 복사 또는 적용**

두 가지 일반적인 작업 흐름이 있으며, 각각 다른 문제를 해결합니다.

### **슬라이드를 이동할 때 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원래 디자인을 보존하려면 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/add_clone/)으로 원본 마스터를 대상 프레젠테이션에 복제한 다음 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)과 복제된 마스터로 슬라이드를 복제합니다. 이렇게 하면 마스터와 레이아웃, 그리고 연관된 테마가 함께 이동됩니다.

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

원본 슬라이드가 목적지에서 동일하게 보여야 할 때 권장되는 작업 흐름입니다. 관련 없는 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우 원본 테마에서 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), 그리고 [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 메서드는 세 가지 주요 테마 구성 요소를 재정의로 복사합니다.

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

이렇게 하면 해당 슬라이드에 사용되는 테마가 변경되지만 다른 슬라이드가 상속받는 테마는 변경되지 않습니다. 로컬 재정의를 제거하고 상속 값으로 돌아가려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/overridetheme/clear/)를 호출하세요.

### **레이아웃에 테마 재정의 적용**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 재정의가 있는 경우를 제외합니다. 동일한 초기화 메서드를 레이아웃의 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/layoutslidethememanager/)를 통해 사용할 수 있습니다:

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

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃군이 다른 스타일링이 필요할 때는 레이아웃 재정의를, 진정한 예외인 경우에만 슬라이드 재정의를 사용하세요. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만듭니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/background_fill_styles/)에 저장됩니다. PowerPoint UI는 테마 채우기를 테마 색상 및 기타 스타일 참조와 결합할 수 있기 때문에 실제 컬렉션에 물리적으로 저장된 채우기 정의 수보다 더 많은 배경 선택지를 UI에 표시할 수 있습니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.style_index](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/style_index/)를 검사하세요. `style_index`는 테마 채우기가 없을 때 `0`을 사용하고, 양수 값은 테마 배경‑스타일 참조를 의미합니다. 이는 Python 컬렉션을 직접 인덱싱할 때 `[0]`이 첫 번째 저장 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션이 동일한 수의 배경 채우기 스타일을 포함한다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 개수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

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

보이는 결과는 마스터가 참조하는 테마 항목 및 레이아웃이나 슬라이드 수준에서의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하는 경우 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 상속이 적용된 최종 배경을 알아야 할 경우 [Background.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/get_effective/)를 사용하세요.

{{% alert color="warning" title="경고" %}}
`style_index`를 0 기반 컬렉션 인덱스로 취급하지 마세요. 또한 한 파일에서 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 외관을 가진다고 가정하지 마세요; 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="팁" %}}
직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/python-net/presentation-background/)을 참조하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스키마에는 별도의 [FormatScheme.fill_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/line_styles/), 그리고 [FormatScheme.effect_styles](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/formatscheme/effect_styles/) 컬렉션이 포함됩니다. 일반적인 Office 테마에는 미묘함, 보통, 강렬함을 시각적으로 나타내는 세 개의 주요 스타일 항목이 포함되는 경우가 많지만, 코드에서는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![같은 도형에 적용된 미묘한, 보통, 강렬한 테마 효과](presentation-design_10.png)

Python에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0 기반입니다: `[0]`은 첫 번째 저장 스타일이고 `[2]`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념으로 [IShapeStyle](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapestyle/)을 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 변하지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하고, 세 번째 효과 스타일에 외부 그림자를 활성화한 뒤 결과를 저장합니다:

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

이 슬롯을 참조하는 도형의 경우, 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 단단한 숲 녹색이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 얻게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 스타일 슬롯을 참조하고 있는지 및 직접 서식이 테마를 재정의하는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **유효 테마 값 읽기**

원시 테마 객체는 특정 수준에서 정의된 내용을 알려줍니다. 유효 값은 상속 및 로컬 재정의가 해결된 후 슬라이드나 도형이 실제로 사용하는 값을 알려줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)를 호출합니다. 배경의 경우 [Background.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/get_effective/), 채우기의 경우 [FillFormat.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/get_effective/)를 사용합니다.

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

**단일 슬라이드에 마스터를 변경하지 않고 테마를 적용할 수 있나요?**

네. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/slidethememanager/)를 사용하고 재정의 테마를 초기화하면 됩니다. 변경은 해당 슬라이드에만 적용되며 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 전달하는 가장 안전한 방법은 무엇인가요?**

슬라이드를 이동하면서 원본 외관을 보존하려면 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/add_clone/)으로 원본 마스터를 대상에 복제하고, 해당 마스터와 함께 [SlideCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/)으로 슬라이드를 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 유효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해서는 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)를 사용하고, [Background.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/background/get_effective/) 및 [FillFormat.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/get_effective/)와 같은 해당 포맷 객체의 유효‑데이터 메서드를 사용하세요. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.