---
title: Android에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android용 Aspose.Slides에서 마스터 프레젠테이션 테마를 관리하고, 일관된 브랜드 적용을 위해 PowerPoint 파일을 생성, 맞춤 설정 및 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선, 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 각 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 객체가 한 번에 업데이트됩니다.

Aspose.Slides에서 프레젠테이션 수준 테마는 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)을 통해 사용할 수 있습니다. 프레젠테이션은 하위 수준에서도 테마 오버라이드를 포함할 수 있습니다. 마스터는 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/masterthememanager/)를 통해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseoverridethememanager/)를 통해 상속된 테마를 재정의할 수 있습니다. 실제로 슬라이드의 유효 테마는 다음 상속 체인을 통해 해결됩니다: 프레젠테이션 테마, 마스터 오버라이드, 레이아웃 오버라이드, 슬라이드 오버라이드.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 워크플로우를 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 상속 및 오버라이드가 해결된 후 유효 값을 읽는 방법.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mastertheme/) 객체는 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/mastertheme/)을 통해 테마의 색상 스키마, 글꼴 스키마 및 포맷 스키마를 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하는 것은 프레젠테이션이 외부 소스에서 온 경우 특히 유용합니다. 스타일 항목의 수와 내용은 다양할 수 있기 때문입니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선, 효과 스타일이 각각 몇 개인지 보고합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

파일에 여러 마스터가 포함되어 있는 경우 모든 슬라이드가 동일한 유효 테마를 가진다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃 또는 슬라이드 오버라이드가 존재할 수 있는 경우 아래에 표시된 유효 테마 워크플로우를 사용하십시오.

## **테마 색상 변경**

테마 인식 채우기, 선, 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. [IColorScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icolorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 계속 참조하는 모든 객체가 새 값으로 해결됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4`를 사용하는 도형을 만들고, 테마의 `Accent4` 색상을 빨간색으로 변경하고, 프레젠테이션을 저장한 뒤 다시 열어 유효 채우기 색상을 출력합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

사각형이 `Accent4`에 계속 연결되어 있기 때문에 테마가 변경된 후 보이는 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정하면 이후 `Accent4`가 변경되어도 해당 채우기는 더 이상 영향을 받지 않습니다.

### **추가 팔레트 색상 사용**

PowerPoint는 색상 변환을 적용하여 테마 색상에서 밝고 어두운 변형을 파생합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![주 테마 색상 및 추가 팔레트에서 생성된 밝고 어두운 색상](additional-palette-colors.png)

**1** - 주 테마 색상.

**2** - 주 테마 색상으로부터 생성된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 한 여섯 개의 사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 변형은 여전히 테마 색상을 기반으로 합니다. `Accent4`가 나중에 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `IColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [IColorScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icolorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이들은 동일한 테마 슬롯에 대한 대체 이름이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스키마는 헤딩용 주요 글꼴 세트와 본문용 보조 글꼴 세트를 포함합니다. [IFontScheme.getMajor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontscheme/) 및 [IFontScheme.getMinor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontscheme/) 메서드가 해당 세트를 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj-lt` - 헤딩 글꼴 라틴어 (Major Latin Font)
* `+mn-ea` - 본문 글꼴 동아시아어 (Minor East Asian Font)
* `+mj-ea` - 헤딩 글꼴 동아시아어 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 헤딩 하나와 보조 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤, 테마 글꼴을 변경하고 결과를 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

헤딩은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 명시적으로 글꼴 이름을 지정한 텍스트는 테마 글꼴 스키마가 변경되어도 자동으로 전환되지 않습니다.

주요 및 보조 글꼴 컬렉션에는 키릴 문자, 아라비아어, 일본어, 그루지아어, 타아나와 같은 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [스크립트별 테마 글꼴](/slides/ko/androidjava/script-specific-font-mappings/)을 참조하세요.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/androidjava/powerpoint-fonts/)를 확인하세요.
{{% /alert %}}

## **테마 복사 또는 적용**

아래 워크플로우는 다양한 테마 관련 문제를 해결합니다.

### **외부 테마를 마스터 종속 슬라이드에 적용**

PowerPoint 테마 파일(`.thmx`)이 있고 특정 마스터에 종속된 모든 슬라이드의 스타일을 다시 적용하려면 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslide/)를 사용합니다. [Presentation.getMasters](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 컬렉션에서 마스터를 선택하고(이 컬렉션은 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslidecollection/)을 구현) 테마 파일 경로를 메서드에 전달합니다.

메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 외부 테마를 새 마스터에 적용합니다.
1. 이전에 선택한 마스터에 종속됐던 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 만든 [IMasterSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslide/)를 반환합니다.

다음 예제는 첫 번째 마스터에 종속된 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxReadException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxreadexception/)을 발생시킬 수 있습니다. 사용자가 제공한 경로를 검증하고 파일 시스템 액세스 실패를 처리하며 테마가 성공적으로 적용된 후에만 프레젠테이션을 저장하세요.

선택한 마스터에 종속된 슬라이드만 다시 할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 대해 해결됩니다. 직접 지정된 색상, 글꼴, 채우기 및 기타 명시적 서식은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 오버라이드는 새 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 런타임 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [맞춤 글꼴 소스](/slides/ko/androidjava/custom-font/)를 통해 제공하거나 [글꼴 대체](/slides/ko/androidjava/font-substitution/)를 구성하세요.

이것은 직접적인 마스터 수준 워크플로우이며, 메서드는 `.thmx` 파일 경로만 받아 슬라이드‑레벨이나 레이아웃‑레벨 테마 오버라이드를 별도로 만들 필요가 없습니다.

### **다중 마스터 프레젠테이션에서 다른 외부 테마 적용**

관련 마스터를 미리 알 수 없는 경우 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/)와 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/)를 통해 대표 슬라이드에서 마스터를 가져옵니다. 테마를 적용하기 전에 원본 마스터 참조를 저장하세요. 각 호출은 프레젠테이션에 새로운 마스터를 추가합니다.

다음 예제는 두 섹션의 슬라이드를 사용해 마스터를 찾아 각각 다른 외부 테마를 적용합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

첫 번째 호출은 `firstGroupMaster`에 종속된 슬라이드에만 영향을 주며, 두 번째 호출은 `secondGroupMaster`에 종속된 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 재스타일링되지 않습니다.

### **슬라이드 이동 시 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 유지하려면 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslidecollection/)로 소스 마스터를 대상 프레젠테이션에 복제한 뒤, [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidecollection/)와 복제된 마스터를 사용해 슬라이드를 복제하세요. 이렇게 하면 마스터와 레이아웃, 그리고 연결된 테마가 함께 복제됩니다.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 할 때 권장되는 워크플로우입니다. 무관한 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃에 머물러야 한다면 소스 테마에서 슬라이드‑레벨 오버라이드를 초기화합니다. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/overridetheme/) 메서드는 세 가지 주요 테마 구성 요소를 오버라이드에 복사합니다.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

이렇게 하면 해당 슬라이드에만 테마가 변경되고 다른 슬라이드가 상속받는 테마는 그대로 유지됩니다. 로컬 오버라이드를 제거하고 상속값으로 돌아가려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/overridetheme/)를 호출하세요.

### **레이아웃에 테마 오버라이드 적용**

레이아웃‑레벨 오버라이드는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 오버라이드가 없는 경우에만 적용됩니다. 동일한 초기화 메서드를 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/layoutslidethememanager/)를 통해 사용할 수 있습니다:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 하면 마스터 또는 프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃군에 다른 스타일링이 필요하면 레이아웃 오버라이드를, 진정한 예외가 있을 때만 슬라이드 오버라이드를 사용하세요. 과도한 슬라이드‑레벨 오버라이드는 이후 전체 테마 변경을 예측하기 어렵게 만듭니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iformatscheme/)에 저장됩니다. PowerPoint는 UI에서 실제 컬렉션에 저장된 채우기 정의보다 더 많은 배경 선택지를 제공할 수 있습니다. UI는 테마 채우기를 테마 색상 및 기타 스타일 참조와 결합할 수 있기 때문입니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.getStyleIndex](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/background/)를 검사하세요. `0` 인덱스는 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 나타냅니다. 이는 Java 컬렉션을 직접 인덱싱할 때 `get_Item(0)`이 첫 번째 저장된 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션이 동일한 수의 배경 채우기 스타일을 포함한다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

보이는 결과는 마스터가 참조하는 테마 항목 및 레이아웃이나 슬라이드 수준의 배경 오버라이드 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하는 경우 마스터 배경만 변경해도 슬라이드가 바뀌지 않을 수 있습니다. 상속이 적용된 최종 배경을 알아야 할 때는 [Background.getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/background/)를 사용하세요.

{{% alert color="warning" title="Warning" %}}
스타일 인덱스를 0부터 시작하는 컬렉션 인덱스로 취급하지 마세요. 또한 한 파일에서 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 외형을 가진다고 가정하지 마세요. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접적인 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/androidjava/presentation-background/)를 참조하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스키마는 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iformatscheme/)를 통해 별개의 채우기, 선, 효과 스타일 컬렉션을 노출합니다. 일반적인 Office 테마는 미묘, 중간, 강렬한 서식을 시각적으로 대응하는 세 개의 주요 스타일 항목을 포함하지만, 코드는 고정된 개수를 가정하기보다 각 컬렉션을 검사해야 합니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

Java에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0부터 시작합니다: `get_Item(0)`은 첫 번째 저장된 스타일이고 `get_Item(2)`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별도의 개념이며, [IShapeStyle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapestyle/)를 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주고, 직접 서식을 적용한 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외부 그림자를 거리 10포인트로 적용하고 결과를 저장합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 슬롯을 참조하는 도형의 경우 첫 번째 테마 선 스타일이 빨간색이 되고, 세 번째 테마 채우기 스타일이 짙은 숲 녹색(실선)으로 변하며, 세 번째 효과 스타일에 거리 10포인트의 외부 그림자가 추가됩니다. 정확한 시각적 결과는 각 도형이 어떤 슬롯을 참조하고 직접 서식이 테마를 오버라이드했는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **유효 테마 값 읽기**

원시 테마 객체는 특정 수준에 정의된 내용을 알려줍니다. 유효 값은 상속 및 로컬 오버라이드가 해결된 후 슬라이드나 도형이 실제로 사용하는 값을 알려줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseoverridethememanager/)를 호출합니다. 배경의 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/background/)를, 채우기의 경우 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fillformat/)를 사용합니다.

다음 예제는 슬라이드에서 유효 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

렌더링 진단, 검증 및 비교를 위해 유효 데이터를 사용하세요. [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 오버라이드로 인해 최종 외형이 변경된 경우를 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드에 영향을 줍니까?**

아니요. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslide/)는 선택한 마스터에 종속된 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에 테마를 적용할 수 있나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidethememanager/)를 사용하고 오버라이드 테마를 초기화합니다. 변경은 해당 슬라이드에만 적용되고 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 옮기는 가장 안전한 방법은?**

슬라이드를 이동하면서 원본 모양을 보존하려면 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslidecollection/)로 소스 마스터를 대상에 복제하고, 그 마스터와 함께 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidecollection/)로 슬라이드를 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 오버라이드 후 유효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseoverridethememanager/)를 사용하고, [Background.getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/background/)와 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fillformat/)와 같은 포맷 객체에 대한 유효‑데이터 메서드를 호출하세요. 이러한 API는 상속 및 오버라이드가 적용된 후 해결된 값을 반환합니다.