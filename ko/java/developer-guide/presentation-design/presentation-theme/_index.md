---
title: Java에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 사용자 지정 및 변환할 수 있는 마스터 프레젠테이션 테마."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선, 효과의 조정된 집합을 정의합니다. 테마를 인식하는 개체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 개체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서는 프레젠테이션 수준의 테마를 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)를 통해 사용할 수 있습니다. 프레젠테이션에는 하위 수준에서 테마를 재정의하는 경우도 있을 수 있습니다. 마스터는 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/masterthememanager/)를 통해 프레젠테이션 테마를 재정의할 수 있으며, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/baseoverridethememanager/)를 통해 상속된 테마를 재정의할 수 있습니다. 실제로 슬라이드에 적용되는 유효 테마는 다음과 같은 상속 체인을 통해 해결됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여 줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후 유효 값을 읽는 방법.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mastertheme/) 개체는 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mastertheme/), [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/mastertheme/)을 통해 테마의 색상 스키마, 글꼴 스키마, 포맷 스키마를 노출합니다. 변경 전에 이러한 컬렉션을 검사하는 것이 특히 외부 소스에서 가져온 프레젠테이션의 경우 유용합니다. 스타일 항목의 수와 내용이 다양할 수 있기 때문입니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선, 효과 스타일이 각각 몇 개 있는지 보고합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 유효 테마를 갖는다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃 또는 슬라이드 재정의가 존재할 수 있는 경우 아래에 소개된 유효 테마 작업 흐름을 사용하십시오.

## **테마 색상 변경**

테마를 인식하는 채우기, 선, 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. [IColorScheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icolorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 계속 참조하는 모든 개체가 새로운 값으로 다시 해결됩니다. 직접 RGB 색상을 사용하는 개체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 종단‑종단 예제는 `Accent4`를 사용하는 도형을 만든 뒤 테마의 `Accent4` 색상을 빨간색으로 변경하고, 프레젠테이션을 저장한 뒤 다시 열어 유효 채우기 색상을 출력합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

사각형이 `Accent4`에 계속 연결되어 있기 때문에 테마가 변경된 후 표시되는 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정해 스킴 색상을 교체하면 이후 `Accent4` 변경이 해당 채우기에 영향을 주지 않게 됩니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 테마 색상에 색상 변환을 적용하여 더 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 주요 테마 색상.

**2** - 주요 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개의 사각형을 만든 뒤 다섯 개에 밝기 변환을 적용하고 결과를 저장합니다:

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

이 변형들은 여전히 테마 색상을 기반으로 합니다. `Accent4`가 나중에 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `IColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [IColorScheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icolorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 동일한 테마 슬롯에 대한 별칭이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스키마는 제목용 주요 글꼴 세트와 본문용 보조 글꼴 세트를 포함합니다. [IFontScheme.getMajor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontscheme/)와 [IFontScheme.getMinor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontscheme/) 메서드를 통해 해당 세트를 확인할 수 있습니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj-lt` - 제목 글꼴 라틴어 (Major Latin Font)
* `+mn-ea` - 본문 글꼴 동아시아어 (Minor East Asian Font)
* `+mj-ea` - 제목 글꼴 동아시아어 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 보조 라틴 테마 글꼴을 사용하는 본문 줄 하나를 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

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

제목은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 테마 식별자가 아닌 명시적인 글꼴 이름을 가진 텍스트는 테마 글꼴 스키마가 변경되어도 자동으로 전환되지 않습니다.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/java/powerpoint-fonts/)를 참조하세요.
{{% /alert %}}

## **테마 복사 또는 적용**

두 가지 일반적인 작업 흐름이 있으며, 해결하는 문제가 다릅니다.

### **슬라이드를 이동하면서 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하고 원본 디자인을 유지하려면 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterslidecollection/)를 사용해 소스 마스터를 대상 프레젠테이션에 복제한 후 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/)와 복제된 마스터를 사용해 슬라이드를 복제합니다. 이렇게 하면 마스터, 레이아웃 및 연관된 테마가 함께 이동됩니다.

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

이 방법은 소스 슬라이드가 대상에서도 동일하게 보여야 할 때 권장되는 작업 흐름입니다. 관련 없는 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우 소스 테마에서 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/overridetheme/) 메서드를 사용해 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

이렇게 하면 해당 슬라이드에만 적용되는 테마가 변경되고, 다른 슬라이드가 상속받는 테마는 바뀌지 않습니다. 로컬 재정의를 제거하고 상속값으로 되돌리려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/overridetheme/)를 호출하세요.

### **레이아웃에 테마 재정의 적용**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 재정의가 없는 경우에만 적용됩니다. 동일한 초기화 메서드를 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/layoutslidethememanager/)를 통해 사용할 수 있습니다:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 특정 레이아웃 그룹에 다른 스타일링이 필요할 때는 레이아웃 재정의를, 진정한 예외인 경우에만 슬라이드 재정의를 사용하세요. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만듭니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iformatscheme/)에 저장됩니다. PowerPoint는 UI에서 실제 컬렉션에 물리적으로 저장된 채우기 정의보다 더 많은 배경 옵션을 제공할 수 있는데, 이는 UI가 테마 채우기와 테마 색상 및 기타 스타일 참조를 결합할 수 있기 때문입니다.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.getStyleIndex](https://reference.aspose.com/slides/ko/java/com.aspose.slides/background/)를 검사하세요. 스타일 인덱스 `0`은 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 나타냅니다. 이는 Java 컬렉션을 직접 인덱싱할 때 `get_Item(0)`이 첫 번째 저장 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션에 동일한 수의 배경 채우기 스타일이 있다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 개수를 보고, 첫 번째 마스터에 테마 배경 참조를 할당하고 프레젠테이션을 저장합니다:

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

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드 수준에서의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하고 있다면 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 상속이 적용된 최종 배경을 알아야 할 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/background/)를 사용하세요.

{{% alert color="warning" title="Warning" %}}
스타일 인덱스를 0 기반 컬렉션 인덱스로 취급하지 마세요. 또한 한 파일에서 사용된 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 모양을 가진다고 가정하지 마세요. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 지정 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/java/presentation-background/)를 참조하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스키마는 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iformatscheme/)를 통해 노출되는 별도의 채우기, 선, 효과 스타일 컬렉션을 포함합니다. 일반적인 Office 테마에는 미묘함, 보통, 강렬함에 시각적으로 대응하는 세 개의 주요 스타일 항목이 포함되는 경우가 많지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Java에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0 기반입니다: `get_Item(0)`은 첫 번째 저장 스타일이고 `get_Item(2)`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념이며, 이는 [IShapeStyle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapestyle/)를 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외부 그림자를 설정하고 결과를 저장합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 슬롯을 참조하는 도형의 경우 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 단단한 포레스트 그린이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 얻게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 스타일 슬롯을 참조하는지와 직접 서식이 테마를 재정의하는지에 따라 달라집니다.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **유효 테마 값 읽기**

원시 테마 객체는 특정 레벨에 정의된 내용을 알려 줍니다. 유효 값은 상속 및 로컬 재정의가 해결된 후 슬라이드나 도형이 실제로 사용하고 있는 값을 알려 줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/baseoverridethememanager/)를 호출하고, 배경의 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/background/), 채우기의 경우 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fillformat/)를 사용하세요.

다음 예제는 슬라이드에서 유효 테마, 배경, 첫 번째 도형 채우기를 읽습니다:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

렌더링 진단, 검증 및 비교를 위해 유효 데이터를 사용하세요. [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 재정의로 인해 최종 모양이 바뀐 경우를 놓칠 수 있습니다.

## **FAQ**

**단일 슬라이드에만 테마를 적용하고 마스터는 변경하지 않으려면 어떻게 해야 하나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidethememanager/)를 사용하고 재정의 테마를 초기화하면 됩니다. 변경 내용은 해당 슬라이드에만 적용되고 다른 슬라이드는 기존 테마를 그대로 상속합니다.

**프레젠테이션 간에 테마를 안전하게 전달하려면 어떤 방법이 가장 좋나요?**

슬라이드를 이동하면서 원본 디자인을 보존하려면 소스 마스터를 대상에 복제하고, 해당 마스터와 함께 슬라이드를 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterslidecollection/)와 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/)를 사용해 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 유효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해서는 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/baseoverridethememanager/)를 사용하고, 포맷 객체에 대해서는 [Background.getEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/background/)와 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fillformat/)와 같은 유효‑데이터 메서드를 사용하세요. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.