---
title: Python을 통한 Java로 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/python-java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 프레젠테이션 테마를 마스터하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 사용자 지정하며, 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마를 인식하는 객체는 모든 시각적 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마 변경으로 여러 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서는 [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) 를 통해 프레젠테이션 수준의 테마에 접근할 수 있습니다. 프레젠테이션은 낮은 수준에서도 테마 오버라이드를 포함할 수 있습니다. 마스터는 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme) 를 통해 프레젠테이션 테마를 오버라이드할 수 있고, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) 를 통해 상속된 테마를 오버라이드할 수 있습니다. 실제로 슬라이드에 적용되는 테마는 다음과 같은 상속 체인을 통해 결정됩니다: 프레젠테이션 테마 → 마스터 오버라이드 → 레이아웃 오버라이드 → 슬라이드 오버라이드.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 오버라이드가 적용된 후의 실효값 읽기.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) 객체는 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) 및 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme) 을 통해 테마의 색상 스키마, 글꼴 스키마 및 포맷 스키마를 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하면 프레젠테이션이 외부 소스에서 온 경우 스타일 항목의 수와 내용이 다양할 수 있기 때문에 특히 유용합니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일의 개수를 보고합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()

    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 실효 테마를 가진다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고 레이아웃이나 슬라이드 오버라이드가 존재할 수 있는 경우 이 문서 후반에 소개되는 실효 테마 작업 흐름을 사용하세요.

## **테마 색상 변경**

테마를 인식하는 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) 에서 해당 항목을 변경하면 해당 테마 색상을 여전히 참조하는 모든 객체가 새로운 값으로 해석됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4` 를 사용하는 도형을 만든 뒤 테마의 `Accent4` 색상을 빨간색으로 변경하고, 프레젠테이션을 저장한 뒤 다시 열어 실효 채우기 색상을 출력합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)

    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

사각형이 `Accent4` 에 계속 연결되어 있기 때문에 테마가 변경된 뒤 보이는 색상이 빨간색으로 바뀝니다. 도형에 직접 색상을 지정하면 이후 `Accent4` 가 변경되어도 해당 채우기는 영향을 받지 않습니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 테마 색상에 색상 변환을 적용하여 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![주요 테마 색상 및 추가 팔레트에서 생성된 밝고 어두운 색상](additional-palette-colors.png)

**1** - 주요 테마 색상.

**2** - 주요 테마 색상으로부터 생성된 밝고 어두운 변형.

다음 예제는 `Accent4` 를 기반으로 하는 여섯 개의 사각형을 만든 뒤 다섯 개에 밝기 변환을 적용하고 결과를 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 변형들은 여전히 테마 색상을 기반으로 합니다. `Accent4` 가 나중에 변경되면 변환된 색상도 새로운 `Accent4` 값으로 재계산됩니다.

### **`SchemeColor` 값을 `ColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2` 를 사용하고, [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) 은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2` 로 노출합니다. 매핑은 다음과 같이 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 동일한 테마 슬롯에 대한 다른 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스키마는 헤딩용 주요 글꼴 집합과 본문용 보조 글꼴 집합을 포함합니다. [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) 와 [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) 메서드를 통해 해당 집합을 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에서 사용할 수 있습니다:

* `+mn‑lt` - 본문 라틴 글꼴 (Minor Latin Font)
* `+mj‑lt` - 헤딩 라틴 글꼴 (Major Latin Font)
* `+mn‑ea` - 본문 동아시아 글꼴 (Minor East Asian Font)
* `+mj‑ea` - 헤딩 동아시아 글꼴 (Major East Asian Font)
* `+mn‑cs` - 본문 복합 스크립트 글꼴 (Minor Complex Script Font)
* `+mj‑cs` - 헤딩 복합 스크립트 글꼴 (Major Complex Script Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 헤딩 하나와 보조 라틴 테마 글꼴을 사용하는 본문 라인을 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

헤딩은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 명시적으로 글꼴 이름을 지정한 텍스트는 테마 글꼴 스키마가 변경되더라도 자동으로 전환되지 않습니다.

주요 및 보조 글꼴 컬렉션에는 키릴 문자, 아랍어, 일본어, 조지아어, 타아나 등 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/python-java/script-specific-font-mappings/) 를 참고하세요.

{{% alert color="success" title="Tip" %}}

프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/python-java/powerpoint-fonts/) 를 확인하세요.

{{% /alert %}}

### **테마 글꼴 참조 해결**

텍스트를 검사할 때 [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) 은 `+mn‑lt` 와 같은 테마 참조를 반환할 수 있습니다. 해당 참조를 해결하려면 적절한 실효 테마 데이터를 사용해 [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) 를 호출하세요. `+mj` 와 `+mn` 접두사는 각각 주요 및 보조 글꼴 집합을 선택하고, `-lt`, `-ea`, `-cs` 접미사는 라틴, 동아시아, 복합 스크립트 글꼴을 선택합니다.

객체의 테마가 적용되는 테마 관리자의 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) 를 호출해 실효 테마를 얻으세요. 일반 슬라이드 텍스트의 경우 해당 슬라이드의 테마 관리자를 사용하면 컨텍스트에 슬라이드가 상속한 테마와 로컬 오버라이드가 포함됩니다. 레이아웃이나 마스터 자체를 검사할 때는 해당 객체의 실효 테마를 사용하세요. 첫 번째 마스터의 테마가 모든 슬라이드에 적용된다고 가정하지 마세요.

다음 예제는 보조 라틴 글꼴을 명시적으로 참조하는 텍스트 구간을 만들고, [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) 를 통해 슬라이드 글꼴 스키마를 초기화한 뒤 주요 및 보조 라틴 글꼴을 각각 `Arial` 과 `Calibri` 로 설정합니다. 이로써 입력 파일 없이도 결과를 재현할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

출력은 `+mn‑lt -> Calibri` 뒤에 `Verdana -> Verdana` 가 표시됩니다. 저장된 참조는 변경되지 않으며, 명시적인 글꼴 이름은 그대로 반환됩니다. 구간이 `+mj‑lt` 를 사용했다면 이 테마에서는 `Arial` 로 해석됩니다.

테마 참조를 해결한다는 것은 테마에 의해 지정된 글꼴 패밀리를 확인한다는 의미이며, 글꼴 가용성 검사나 렌더링 시 대체/글리프 폴백에 의해 최종적으로 사용되는 글꼴 파일을 결정하지는 않습니다. 관련 단계는 [Font Selection Sequence](/slides/ko/python-java/font-selection-sequence/) 와 [Font Substitution](/slides/ko/python-java/font-substitution/) 를 참고하세요.

## **테마 복사 또는 적용**

아래 작업 흐름은 다양한 테마 관련 문제를 해결합니다.

### **외부 테마를 마스터 종속 슬라이드에 적용**

PowerPoint 테마 파일(`.thmx`) 이 있고 특정 마스터에 종속된 모든 슬라이드를 재디자인하려면 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 를 사용하세요. [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) 컬렉션(구현은 [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/)) 에서 마스터를 선택하고 메서드에 테마 파일 경로를 전달합니다.

메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 새 마스터에 외부 테마를 적용합니다.
1. 이전에 선택한 마스터에 종속된 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 생성된 [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) 을 반환합니다.

다음 예제는 첫 번째 마스터에 종속된 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")
    print("Created master:", themed_master.getName())

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

잘못되었거나 손상됐거나 지원되지 않는 테마는 [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/) 을 발생시킬 수 있습니다. 사용자가 제공한 경로를 검증하고 파일 시스템 접근 오류를 처리하며 테마 적용이 성공한 뒤에만 프레젠테이션을 저장하세요.

선택한 마스터에 종속된 슬라이드만 재할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 맞춰 해석됩니다. 직접 지정된 색상, 글꼴, 채우기 및 기타 서식은 변경되지 않을 수 있습니다. 레이아웃‑레벨 및 슬라이드‑레벨 오버라이드도 새 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 런타임 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [custom font sources](/slides/ko/python-java/custom-font/) 를 통해 제공하거나 [font substitution](/slides/ko/python-java/font-substitution/) 을 구성하세요.

이 방법은 파일 경로만 전달하고 별도의 슬라이드‑레벨이나 레이아웃‑레벨 테마 오버라이드를 직접 만들 필요가 없는 직접적인 마스터‑레벨 작업 흐름입니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

관련 마스터를 미리 알 수 없는 경우 [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) 와 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide) 를 통해 대표 슬라이드에서 마스터를 가져오세요. 테마를 적용하기 전에 원본 마스터 참조를 저장하세요. 각 호출은 프레젠테이션에 새로운 마스터를 생성합니다.

다음 예제는 두 섹션의 슬라이드를 사용하여 각각의 마스터를 찾고, 각 그룹에 서로 다른 외부 테마를 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

첫 번째 호출은 `first_group_master` 에 종속된 슬라이드에만 영향을 주고, 두 번째 호출은 `second_group_master` 에 종속된 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 재디자인되지 않습니다.

### **슬라이드를 이동하면서 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 유지하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) 로 소스 마스터를 대상 프레젠테이션에 복제한 뒤, [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 로 해당 마스터와 함께 슬라이드를 복제하세요. 이렇게 하면 마스터와 레이아웃, 관련 테마가 함께 복제됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)

        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

대상 슬라이드가 현재 마스터와 레이아웃을 유지하면서도 소스 테마를 사용하도록 하려면 권장되는 작업 흐름입니다. 무관한 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우 소스 테마에서 슬라이드‑레벨 오버라이드를 초기화합니다. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) 및 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) 메서드를 사용해 세 가지 주요 테마 구성 요소를 오버라이드에 복사합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

이렇게 하면 해당 슬라이드에만 적용되는 테마가 변경되고, 다른 슬라이드가 상속받은 테마는 그대로 유지됩니다. 로컬 오버라이드를 제거하고 상속된 값으로 돌아가려면 [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear) 를 호출하세요.

### **레이아웃에 테마 오버라이드 적용**

레이아웃‑레벨 오버라이드는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 오버라이드가 있는 경우는 제외됩니다. 동일한 초기화 메서드는 [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/) 를 통해 사용할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 하면 마스터 또는 프레젠테이션‑레벨 테마를 사용하고, 특정 레이아웃 패밀리만 다른 스타일이 필요하면 레이아웃 오버라이드를, 진짜 예외에만 슬라이드 오버라이드를 사용하세요. 과도한 슬라이드‑레벨 오버라이드는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

<!-- visual-explanation:presentation-theme:start -->
[![마스터 테마가 두 레이아웃에 적용되고, 레이아웃 오버라이드가 해당 슬라이드에 영향을 주며, 보다 로컬 오버라이드가 있는 슬라이드는 제외됩니다.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*레이아웃 오버라이드는 해당 레이아웃을 사용하는 슬라이드에 적용되지만, 슬라이드가 자체 오버라이드를 제공하면 그 효과는 무시됩니다. 테마 기반 값은 해석된 스키마를 따르고, 명시적으로 서식이 지정된 객체는 로컬 외형을 유지할 수 있습니다. 오버라이드는 의도된 디자인 예외만큼 좁게 유지하세요.*
<!-- visual-explanation:presentation-theme:end -->

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) 에 저장됩니다. PowerPoint는 UI에서 테마 채우기와 테마 색상, 기타 스타일 참조를 결합하여 실제 컬렉션에 저장된 채우기 정의보다 더 많은 배경 옵션을 표시할 수 있습니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) 를 검사하세요. 인덱스 `0` 은 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 나타냅니다. 이는 컬렉션을 직접 인덱싱하는 `get_Item(0)` 과는 다르므로, 프레젠테이션마다 배경 채우기 스타일 수가 동일하다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 개수를 보고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)

        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드‑레벨에서의 배경 오버라이드에 따라 달라집니다. 슬라이드가 자체 배경을 사용하는 경우 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 최종 상속 배경을 확인하려면 [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) 를 사용하세요.

{{% alert color="warning" title="Warning" %}}

인덱스를 0 기반 컬렉션 인덱스로 착각하지 마세요. 또한 하나의 파일에서 사용한 스타일 번호를 다른 파일에 그대로 적용한다고 가정하지 마십시오. 테마 스타일 정의는 프레젠테이션마다 다릅니다.

{{% /alert %}}

{{% alert color="success" title="Tip" %}}

직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/python-java/presentation-background/) 를 참고하세요.

{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스키마는 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) 및 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles) 로 노출되는 별도의 채우기, 선 및 효과 스타일 컬렉션을 포함합니다. 일반적인 Office 테마는 미묘함, 보통, 강렬함을 시각적으로 나타내는 세 개의 주요 스타일 항목을 포함하지만, 코드에서는 고정된 개수를 가정하지 말고 각 컬렉션을 검사하세요.

![같은 도형에 적용된 미묘한, 보통, 강렬한 테마 효과](presentation-design_10.png)

Python을 Java와 함께 사용할 때 이 컬렉션의 인덱스는 0 기반입니다: `get_Item(0)` 은 첫 번째 저장된 스타일이고 `get_Item(2)` 은 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념이며, [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/) 로 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주지만, 직접 서식이 적용된 도형은 변하지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외부 그림자를 적용한 뒤 결과를 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)

        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 진한 숲색이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 갖게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 슬롯을 참조하는지와 직접 서식이 테마를 오버라이드하는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **도형에 대한 테마 채우기 및 선 스타일 선택**

도형은 [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) 와 [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex) 로 채우기와 외곽선을 독립적으로 선택할 수 있습니다. 두 메서드 모두 인덱스 `1` 은 해당 테마 컬렉션의 첫 번째 항목(`get_Item(0)`)을, 인덱스 `2` 는 두 번째 항목(`get_Item(1)`)을 선택합니다.

다음 예제는 새로운 프레젠테이션의 기본 테마에 두 개의 채우기 스타일(금색 및 하늘색)과 두 개의 선 스타일(6pt 어두운 파랑 및 12pt 어두운 빨강)을 설정하고, 슬라이드를 세 단계에 걸쳐 저장하여 PowerPoint에서 결과를 비교할 수 있게 합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 초기 스타일 | 오른쪽 외곽선 변경 | 첫 번째 테마 채우기 편집 |
|:---:|:---:|:---:|
| ![금색 및 하늘색 사각형에 얇은 어두운 파란 외곽선이 일치함](theme-style-initial.png) | ![하늘색 사각형에 이제 두꺼운 어두운 빨간 외곽선이 적용됨](theme-style-line-changed.png) | ![왼쪽 사각형이 이제 녹색이며 두 외곽선은 변함 없음](theme-style-fill-changed.png) |

다른 선 스타일을 선택하면 오른쪽 사각형의 외곽선만 변경됩니다. 첫 번째 테마 채우기를 편집하면 해당 채우기를 사용하는 모든 도형이 업데이트됩니다. 여기서는 왼쪽 사각형만 녹색으로 바뀝니다.

기존 도형에 로컬 채우기 색, 선 색 또는 선 두께가 지정된 경우 테마 스타일의 해당 부분을 오버라이드합니다. 스타일 인덱스를 변경해도 시각적 효과가 없으면 도형의 [direct formatting](/slides/ko/python-java/shape-formatting/) 을 확인하세요.

## **실효 솔리드 채우기가 테마 색상을 사용하는지 판별**

채우기는 객체에 직접 저장되거나 단락, 레이아웃, 마스터, 테마 스타일 또는 다른 서식 수준에서 상속될 수 있습니다. [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) 를 호출해 해당 계층을 불변의 실효 채우기 데이터로 해석하십시오. 먼저 실효 데이터 객체의 `getFillType` 을 확인하고, `FillType.Solid` 일 때만 솔리드‑채우기 속성을 읽으세요.

솔리드 채우기의 경우 `getSolidFillColor` 는 상속, 테마 조회 및 색상 변환이 적용된 후 최종 렌더링된 RGB 값을 반환합니다. `getSolidFillSchemeColor` 는 해당 논리적 [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 슬롯(`Text1`, `Accent6` 등)을 반환합니다. `SchemeColor.NotDefined` 은 실효 솔리드 채우기가 스키마 색상을 기반으로 하지 않음을 의미합니다. 테마 색상 또는 직접 RGB 색상 중 하나만 사용하는 워크플로에서는 이 값이 직접 RGB 채우기를 식별합니다.

로컬 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) 값만으로 채우기를 분류하지 마세요. 예를 들어 텍스트 구간이 로컬에 스키마 색상이 정의되어 있지 않아 `NotDefined` 일 수 있지만, 실효 채우기는 테마 색상을 상속받아 `Text1` 또는 `Accent6` 로 해석될 수 있습니다. 반대로 `getSolidFillSchemeColor` 는 실효 색상을 만든 논리적 테마 슬롯을 알려 주지만, 그 슬롯이 어떤 수준에서 온 것인지는 알려 주지 않습니다.

다음 예제는 프레젠테이션을 로드하고, 도형 채우기와 텍스트 구간 채우기를 모두 감사하여 각 최종 RGB 값과 관련 스키마 색상을 출력하고, 테마 색상 변경에 따라 변하지 않을 솔리드 채우기를 표시합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

`NotDefined` 분기는 테마 색상 슬롯 변화에 반응하지 않는 솔리드 채우기 목록을 제공합니다. 새 브랜드 팔레트를 적용해야 하는 경우 이 객체들을 검토하세요. 보고된 RGB 값은 현재 외형을 보여주고, 스키마 값은 해당 외형이 테마와 연결되어 있는지를 설명합니다.

실효‑포맷 객체는 스냅샷입니다. 프레젠테이션 테마, 테마 오버라이드 또는 상속된 서식을 변경한 뒤에는 다시 `getEffective` 를 호출하고 새로운 실효 채우기 데이터 객체를 읽은 후에 색상을 비교하거나 보고하세요.

## **실효 테마 값 읽기**

원시 테마 객체는 특정 수준에서 정의된 내용을 알려 주지만, 실효 값은 상속 및 로컬 오버라이드가 해석된 뒤 슬라이드나 도형이 실제로 사용하는 값을 알려 줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) 를 호출합니다. 배경의 경우 [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), 채우기의 경우 [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) 를 사용하세요.

다음 예제는 슬라이드에서 실효 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

렌더링 진단, 검증 및 비교에 실효 데이터를 사용하세요. [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) 만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 오버라이드로 인해 최종 외형이 바뀐 경우 이를 놓칠 수 있습니다.

## **자주 묻는 질문**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드에 영향을 줍니까?**

아니요. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 은 선택한 마스터에 종속된 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에만 테마를 적용할 수 있습니까?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) 를 사용해 오버라이드 테마를 초기화하면 변경 내용이 해당 슬라이드에만 적용되고, 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 안전하게 옮기는 방법은?**

슬라이드를 이동하면서 원본 외형을 보존하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) 로 소스 마스터를 대상에 복제하고, 해당 마스터와 함께 [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 로 슬라이드를 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 오버라이드 후 실효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해서는 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) 를 사용하고, 포맷 객체에 대해서는 [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) 와 [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) 를 사용하세요. 이러한 API는 상속 및 오버라이드가 적용된 후 해석된 값을 반환합니다.