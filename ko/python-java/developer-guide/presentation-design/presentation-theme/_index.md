---
title: Python을 통한 Java에서 프레젠테이션 테마 관리
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
description: "Python을 위한 Aspose.Slides에서 Java를 사용하여 마스터 프레젠테이션 테마를 관리하고, 일관된 브랜딩으로 PowerPoint 파일을 만들고, 맞춤화하며 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로, 테마 변경으로 한 번에 많은 객체를 업데이트할 수 있습니다.

Aspose.Slides에서 프레젠테이션 수준의 테마는 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasterTheme) 를 통해 사용할 수 있습니다. 프레젠테이션에는 하위 수준에서 테마 재정의가 포함될 수도 있습니다. 마스터는 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterthememanager/#getOverrideTheme) 를 사용해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) 를 통해 상속된 테마를 재정의할 수 있습니다. 실제로 슬라이드의 적용 테마는 다음 상속 체인을 통해 결정됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후의 실효값 읽기.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mastertheme/) 객체는 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mastertheme/#getFontScheme), [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mastertheme/#getFormatScheme) 를 통해 테마의 색 구성표, 글꼴 구성표, 형식 구성표를 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하면 외부 소스에서 가져온 프레젠테이션의 경우 스타일 항목 수와 내용이 다양할 수 있기 때문에 특히 유용합니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선, 효과 스타일이 각각 몇 개 있는지 보고합니다:

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

파일에 여러 마스터가 사용되는 경우 모든 슬라이드가 동일한 적용 테마를 가진다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 재정의가 존재할 수 있는 경우 아래에서 설명한 적용‑테마 작업 흐름을 사용하세요.

## **테마 색상 변경**

테마 인식 채우기, 선, 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/schemecolor/) 열거형의 논리 색상을 참조할 수 있습니다. [ColorScheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/colorscheme/) 에서 해당 항목을 변경하면, 여전히 해당 테마 색상을 참조하고 있는 모든 객체가 새로운 값으로 해석됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4` 를 사용하는 도형을 만들고, 테마의 `Accent4` 색상을 빨간색으로 변경한 뒤 프레젠테이션을 저장하고 다시 열어 실효 채우기 색상을 출력합니다:

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

사각형이 `Accent4` 에 계속 연결되어 있기 때문에 테마가 변경되면 눈에 보이는 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정하면 이후 `Accent4` 변경이 해당 채우기에 더 이상 영향을 주지 않습니다.

### **추가 팔레트 색상 사용**

PowerPoint는 테마 색상에 색 변환을 적용해 밝고 어두운 변형을 만들어냅니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 주요 테마 색상.

**2** - 주요 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4` 를 기반으로 하는 여섯 개 사각형을 만들고, 그 중 다섯 개에 광도 변환을 적용한 뒤 결과를 저장합니다:

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

이 변형들은 여전히 테마 색상을 기반으로 합니다. 이후 `Accent4` 가 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `ColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2` 를 사용하고, [ColorScheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/colorscheme/) 은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2` 로 노출합니다. 매핑은 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 동일한 테마 슬롯에 대한 다른 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 구성표에는 헤딩용 주요 글꼴 세트와 본문용 보조 글꼴 세트가 포함됩니다. [FontScheme.getMajor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontscheme/#getMajor) 와 [FontScheme.getMinor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontscheme/#getMinor) 메서드를 통해 해당 세트를 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 라틴 글꼴 (Minor Latin Font)
* `+mj-lt` - 헤딩 라틴 글꼴 (Major Latin Font)
* `+mn-ea` - 본문 동아시아 글꼴 (Minor East Asian Font)
* `+mj-ea` - 헤딩 동아시아 글꼴 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 헤딩 하나와 보조 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤, 테마 글꼴을 변경하고 결과를 저장합니다:

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

헤딩은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 명시적인 글꼴 이름을 사용한 텍스트는 테마 글꼴 구성표가 변경되어도 자동으로 전환되지 않습니다.

주요 및 보조 글꼴 컬렉션에는 키릴 문자, 아라비아 문자, 일본어, 그루지야어, 타아나어 등 개별 문자 체계에 대한 매핑도 포함될 수 있습니다. 이러한 매핑을 검사·추가·교체·제거하려면 [Script‑Specific Theme Fonts](/slides/ko/python-java/script-specific-font-mappings/) 를 참고하세요.

{{% alert color="success" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/python-java/powerpoint-fonts/) 를 확인하세요.
{{% /alert %}}

## **테마 복사 또는 적용**

다음 작업 흐름은 서로 다른 테마 관련 문제를 해결합니다.

### **마스터에 종속된 슬라이드에 외부 테마 적용**

PowerPoint 테마 파일(`.thmx`) 이 있고 특정 마스터에 의존하는 모든 슬라이드를 다시 스타일링하려면 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 를 사용합니다. [Presentation.getMasters](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasters) 컬렉션(= [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/)) 에서 마스터를 선택하고, 테마 파일 경로를 메서드에 전달합니다.

메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 외부 테마를 새 마스터에 적용합니다.
1. 이전에 선택한 마스터에 의존하던 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 생성된 [MasterSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/) 를 반환합니다.

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

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxReadException](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pptxreadexception/) 을 발생시킬 수 있습니다. 사용자가 제공한 경로를 검증하고 파일 시스템 액세스 오류를 처리하며 테마 적용이 성공적으로 완료된 후에만 프레젠테이션을 저장하세요.

선택한 마스터에 의존하던 슬라이드만 재할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 맞게 해석됩니다. 직접 할당된 색상, 글꼴, 채우기 등 명시적 서식은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 재정의가 새 마스터에서 상속된 값보다 우선할 수도 있습니다.

테마가 런타임 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [custom font sources](/slides/ko/python-java/custom-font/) 를 통해 제공하거나 [font substitution](/slides/ko/python-java/font-substitution/)을 구성하세요.

이 방법은 파일 경로만 받으며 슬라이드‑레벨 또는 레이아웃‑레벨 테마 재정의를 수동으로 만들 필요가 없는 직접적인 마스터‑레벨 작업 흐름입니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

관련 마스터를 미리 알 수 없는 경우, [Slide.getLayoutSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getLayoutSlide) 와 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#getMasterSlide) 를 통해 대표 슬라이드에서 마스터를 얻으세요. 테마를 적용하기 전에 원본 마스터 참조를 저장하세요. 각 호출은 프레젠테이션에 새 마스터를 추가합니다.

다음 예제는 두 섹션의 슬라이드를 사용해 각각의 마스터를 찾고, 각 그룹에 다른 외부 테마를 적용합니다:

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

첫 번째 호출은 `first_group_master` 에 의존하는 슬라이드에만 영향을 주고, 두 번째 호출은 `second_group_master` 에 의존하는 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 재스타일링되지 않습니다.

### **슬라이드 이동 시 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 유지하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/#addClone) 로 소스 마스터를 대상 프레젠테이션에 복제하고, 이후 [SlideCollection.addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 로 해당 마스터와 함께 슬라이드를 복제합니다. 이렇게 하면 마스터, 레이아웃 및 연관된 테마가 함께 복사됩니다.

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

원본 슬라이드가 대상에서도 동일하게 보이게 해야 할 때 권장되는 작업 흐름입니다. 무관한 대상 마스터에만 콘텐츠를 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 바뀔 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우, 소스 테마에서 슬라이드‑레벨 재정의를 초기화합니다. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/overridetheme/#initFontSchemeFrom), [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) 메서드는 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

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

이렇게 하면 다른 슬라이드가 상속하는 테마는 변경되지 않은 채 해당 슬라이드만 다른 테마를 사용하게 됩니다. 로컬 재정의를 제거하고 상속값으로 되돌리려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/overridetheme/#clear) 를 호출하세요.

### **레이아웃에 테마 재정의 적용**

레이아웃‑레벨 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 재정의가 있지 않은 경우에만 적용됩니다. 동일한 초기화 메서드를 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslidethememanager/) 를 통해 사용할 수 있습니다:

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

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 하면 마스터 또는 프레젠테이션 수준 테마를 사용하고, 특정 레이아웃군에 다른 스타일이 필요하면 레이아웃 재정의를, 진정한 예외에만 슬라이드 재정의를 사용하세요. 과도한 슬라이드‑레벨 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ko/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) 에 저장됩니다. PowerPoint UI에서는 테마 채우기와 테마 색상 및 기타 스타일 참조를 결합해 실제보다 더 많은 배경 선택지를 제공할 수 있습니다.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.getStyleIndex](https://reference.aspose.com/slides/ko/python-java/aspose.slides/background/#getStyleIndex) 를 검사하세요. 인덱스 `0` 은 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 나타냅니다. 이는 컬렉션을 직접 인덱싱하는 방법과 다르며, `get_Item(0)` 은 첫 번째 저장 항목을 의미합니다. 모든 프레젠테이션에 동일한 배경 채우기 스타일 수가 있다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 개수를 보고, 첫 번째 마스터에 테마 배경 참조를 할당하고 프레젠테이션을 저장합니다:

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

표시 결과는 마스터가 참조하는 테마 항목 및 레이아웃 또는 슬라이드 수준에서의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용 중이라면 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 최종 배경을 확인하려면 [Background.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/background/#getEffective) 를 사용하세요.

{{% alert color="warning" title="Warning" %}}
스타일 인덱스를 0부터 시작하는 컬렉션 인덱스로 취급하지 마세요. 또한 한 파일에서 사용한 스타일 번호를 다른 파일에 그대로 적용한다고 가정하지 마세요. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
직접적인 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/python-java/presentation-background/) 를 참고하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 형식 구성표는 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ko/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ko/python-java/aspose.slides/formatscheme/#getLineStyles), [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ko/python-java/aspose.slides/formatscheme/#getEffectStyles) 로 노출되는 별개의 채우기, 선, 효과 스타일 컬렉션을 포함합니다. 일반적인 Office 테마는 미묘함, 보통, 강렬함에 해당하는 세 개의 주요 스타일 항목을 포함하지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Python에서 Java API를 사용할 때 컬렉션 인덱스는 0부터 시작합니다: `get_Item(0)` 은 첫 번째 저장 스타일이고 `get_Item(2)` 은 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개 개념이며, [ShapeStyle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapestyle/) 로 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주지만, 직접 서식이 적용된 도형은 변하지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외곽 그림자를 활성화한 뒤 결과를 저장합니다:

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

해당 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 진한 숲 녹색이 되며, 세 번째 효과 스타일은 거리 10포인트의 외곽 그림자를 갖게 됩니다. 실제 시각 결과는 각 도형이 어떤 슬롯을 참조하고 직접 서식이 있는지에 따라 달라집니다.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **실효 단색 채우기가 테마 색상을 사용하는지 판별**

채우기는 객체에 직접 저장되거나 단락, 레이아웃, 마스터, 테마 스타일 또는 다른 서식 수준에서 상속될 수 있습니다. [FillFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/#getEffective) 를 호출해 계층 구조를 불변의 실효 채우기 데이터로 해석합니다. 먼저 실효 데이터 객체의 `getFillType` 을 확인하세요. `FillType.Solid` 인 경우에만 단색 채우기 속성을 읽어야 합니다.

단색 채우기의 경우 `getSolidFillColor` 는 상속, 테마 조회, 색 변환이 적용된 최종 RGB 값을 반환합니다. `getSolidFillSchemeColor` 는 해당 논리 [SchemeColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/schemecolor/) 슬롯(`Text1`, `Accent6` 등)을 반환합니다. `SchemeColor.NotDefined` 은 실효 단색 채우기가 스킴 색상을 기반으로 하지 않음을 의미합니다. 테마 색상 또는 직접 RGB 색상 중 하나만 사용되는 워크플로에서 이 값은 직접 RGB 채우기를 식별합니다.

로컬 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/colorformat/#getSchemeColor) 값만으로 채우기를 분류하지 마세요. 예를 들어 텍스트 부분에 로컬 스킴 색상이 정의되지 않아 `NotDefined` 일 수 있지만, 실효 채우기는 테마 색상을 상속받아 `Text1` 혹은 `Accent6` 로 해석될 수 있습니다. 반대로 `getSolidFillSchemeColor` 는 어느 논리 테마 슬롯이 최종 색상을 만든 것인지 알려 주지만, 그 슬롯이 객체, 단락, 레이아웃, 마스터 중 어느 수준에서 온지는 알려 주지 않습니다.

다음 예제는 프레젠테이션을 로드하고, 도형 채우기와 텍스트 부분 채우기를 모두 감사하고, 각 최종 RGB 값과 연관된 스킴 색상을 출력하며, 테마 색상 변경에 따라 추적되지 않을 단색 채우기에 플래그를 표시합니다:

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

`NotDefined` 분기는 테마 색상 슬롯 변경에 반응하지 않는 단색 채우기의 감사 목록을 제공합니다. 새 브랜드 팔레트를 적용해야 할 때 해당 객체들을 검토하세요. 보고된 RGB 값은 현재 모습을 보여 주며, 스킴 값은 그 모습이 테마와 연결되어 있는지 설명합니다.

실효 형식 객체는 스냅샷입니다. 프레젠테이션 테마, 테마 재정의 또는 상속된 서식을 변경한 후에는 다시 `getEffective` 를 호출해 새로운 실효 채우기 데이터 객체를 읽고 색상을 비교하거나 보고해야 합니다.

## **실효 테마값 읽기**

원시 테마 객체는 특정 수준에서 정의된 내용을 알려 주고, 실효값은 상속 및 로컬 재정의가 해결된 후 슬라이드나 도형이 실제로 사용하는 값을 알려 줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) 를 호출합니다. 배경의 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/background/#getEffective), 채우기의 경우 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/#getEffective) 를 사용합니다.

다음 예제는 슬라이드에서 실효 테마, 배경, 첫 번째 도형 채우기를 읽습니다:

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

렌더링 진단, 검증 및 비교를 위해 실효 데이터를 사용하세요. [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasterTheme) 만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 재정의로 인한 최종 모습 변화를 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드에 영향을 줍니까?**

아니요. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 은 선택한 마스터에 의존하는 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에만 테마를 적용할 수 있나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidethememanager/) 를 사용해 해당 슬라이드의 재정의 테마를 초기화하면 됩니다. 변경은 해당 슬라이드에만 적용되며 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 안전하게 옮기는 방법은?**

슬라이드를 이동하면서 원본 모습을 보존하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/#addClone) 로 소스 마스터를 대상에 복제하고, 그 마스터와 함께 [SlideCollection.addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 로 슬라이드를 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 실효값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해서는 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) 를, 형식 객체(예: 배경, 채우기)에는 [Background.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/background/#getEffective) 와 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/#getEffective) 를 사용하세요. 이 API들은 상속 및 재정의가 적용된 최종 값을 반환합니다.