---
title: JavaScript에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides를 사용하여 JavaScript에서 프레젠테이션 테마를 마스터하고, 일관된 브랜드를 유지하면서 PowerPoint 파일을 생성, 맞춤 설정 및 변환합니다."
---
## **Introduction**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 모든 시각 속성을 고정 값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 많은 객체가 한 번에 업데이트됩니다.

Aspose.Slides에서 프레젠테이션 수준의 테마는 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getmastertheme/)를 통해 사용할 수 있습니다. 프레젠테이션은 또한 하위 수준에서 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterthememanager/)를 통해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseoverridethememanager/)를 통해 상속된 테마를 재정의할 수 있습니다. 실제로 슬라이드의 적용 테마는 다음과 같은 상속 체인을 통해 해결됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후의 실제 값을 읽기 등.

## **Inspect a Theme**

[MasterTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mastertheme/) 객체는 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mastertheme/), 그리고 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mastertheme/)을 통해 테마의 색상 스킴, 글꼴 스킴, 그리고 포맷 스킴을 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하는 것은 프레젠테이션이 외부 소스에서 온 경우 특히 유용합니다. 스타일 항목의 수와 내용이 다양할 수 있기 때문입니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선, 그리고 효과 스타일이 각각 몇 개 있는지 보고합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

파일에 여러 마스터가 사용되는 경우, 모든 슬라이드가 동일한 적용 테마를 가진다고 가정하지 마십시오. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 재정의가 존재할 수 있는 경우 이 문서 뒷부분에 나오는 적용 테마 작업 흐름을 사용하십시오.

## **Change Theme Colors**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. [ColorScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/colorscheme/)에서 해당 항목을 변경하면, 여전히 그 테마 색상을 참조하고 있는 모든 객체가 새 값으로 해석됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4`를 사용하는 도형을 만들고, 테마의 `Accent4` 색상을 빨간색으로 변경한 뒤 프레젠테이션을 저장하고 다시 열어 실제 채우기 색상을 출력합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

사각형이 `Accent4`에 계속 연결돼 있기 때문에 테마가 변경되면 보이는 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정하면 이후 `Accent4`가 변경돼도 해당 채우기에 영향을 주지 않습니다.

### **Use Colors from the Additional Palette**

PowerPoint는 테마 색상에 색상 변환을 적용하여 더 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 주요 테마 색상.

**2** - 주요 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개의 사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 변형들은 여전히 테마 색상을 기반으로 합니다. `Accent4`가 나중에 변경되면 변환된 색상은 새 `Accent4` 값으로 다시 계산됩니다.

### **Map `SchemeColor` Values to `ColorScheme` Slots**

[SchemeColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [ColorScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/colorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이들은 동일한 테마 슬롯에 대한 대체 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값은 아닙니다.

## **Change Theme Fonts**

테마 글꼴 스킴은 제목에 대한 메이저 글꼴 집합과 본문에 대한 마이너 글꼴 집합을 포함합니다. [FontScheme.getMajor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontscheme/) 및 [FontScheme.getMinor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontscheme/) 메서드는 해당 집합을 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj-lt` - 제목 글꼴 라틴어 (Major Latin Font)
* `+mn-ea` - 본문 글꼴 동아시아어 (Minor East Asian Font)
* `+mj-ea` - 제목 글꼴 동아시아어 (Major East Asian Font)

다음 예제는 메이저 라틴 테마 글꼴을 사용하는 제목 하나와 마이너 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

제목은 메이저 글꼴을 따르고 본문 텍스트는 마이너 글꼴을 따릅니다. 테마 식별자 대신 명시적인 글꼴 이름이 사용된 텍스트는 테마 글꼴 스킴이 변경되어도 자동으로 전환되지 않습니다.

메이저 및 마이너 글꼴 컬렉션에는 키릴 문자, 아라비아어, 일본어, 조지아어, 타나와 같은 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/nodejs-java/script-specific-font-mappings/) 를 참조하십시오.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/nodejs-java/powerpoint-fonts/)를 확인하십시오.
{{% /alert %}}

## **Copy or Apply a Theme**

두 가지 일반적인 작업 흐름이 있으며, 각각 다른 문제를 해결합니다.

### **Preserve a Source Theme When Moving Slides**

슬라이드를 다른 프레젠테이션으로 이동하면서 원래 디자인을 보존하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslidecollection/)을 사용해 소스 마스터를 대상 프레젠테이션에 복제한 후, [SlideCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/)과 복제된 마스터를 사용해 슬라이드를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 연결된 테마가 함께 이동합니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

이 방법은 원본 슬라이드가 대상에서도 동일하게 보이도록 해야 할 때 권장되는 작업 흐름입니다. 관련 없는 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **Apply Theme Values to an Existing Slide**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우, 소스 테마에서 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/overridetheme/), 그리고 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/overridetheme/) 메서드는 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

이렇게 하면 다른 슬라이드가 상속하는 테마를 변경하지 않고 해당 슬라이드에서만 테마가 변경됩니다. 로컬 재정을 제거하고 상속된 값으로 되돌리려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/overridetheme/)를 호출하십시오.

### **Apply a Theme Override to a Layout**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 특정 슬라이드에 자체 재정의가 있는 경우를 제외합니다. 동일한 초기화 메서드는 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslidethememanager/)를 통해 사용할 수 있습니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃 패밀리만 다른 스타일이 필요할 때는 레이아웃 재정의를, 실제 예외에 대해서만 슬라이드 재정을 사용하십시오. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **Update Theme Background Styles**

테마의 배경 채우기는 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/formatscheme/)에 저장됩니다. PowerPoint UI에서는 테마 채우기와 테마 색상, 기타 스타일 참조를 조합할 수 있기 때문에 실제 저장된 컬렉션보다 더 많은 배경 옵션을 표시할 수 있습니다.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.getStyleIndex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/background/)를 검사하십시오. `0` 인덱스는 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 나타냅니다. 이는 JavaScript 컬렉션을 직접 인덱싱할 때 `0`이 첫 번째 저장 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션이 동일한 수의 배경 채우기 스타일을 포함한다고 가정하지 마십시오.

다음 예제는 사용 가능한 배경 채우기 개수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드 수준에 있는 배경 재정의에 따라 달라집니다. 슬라이드가 자체 배경을 사용하는 경우 마스터 배경만 변경해도 해당 슬라이드는 변하지 않을 수 있습니다. 상속이 적용된 최종 배경을 알아야 할 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/background/)를 사용하십시오.

{{% alert color="warning" title="Warning" %}}
스타일 인덱스를 0부터 시작하는 컬렉션 인덱스로 취급하지 마십시오. 또한 한 파일에서 사용한 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 외观을 기대하지 마십시오; 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/nodejs-java/presentation-background/)를 참고하십시오.
{{% /alert %}}

## **Update Theme Effects**

테마 포맷 스킴은 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/formatscheme/), 그리고 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/formatscheme/)을 통해 각각 채우기, 선, 효과 스타일 컬렉션을 노출합니다. 일반적인 Office 테마는 시각적으로 미묘함, 보통, 강렬함에 해당하는 세 가지 주요 스타일 항목을 포함하는 경우가 많지만, 코드에서는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

JavaScript에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0부터 시작합니다: 인덱스 `0`은 첫 번째 저장된 스타일이고 인덱스 `2`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념이며, 이는 [ShapeStyle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapestyle/)을 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 그대로 유지될 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외부 그림자를 적용한 뒤 결과를 저장합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 단단한 포레스트 그린이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 얻게 됩니다. 정확한 시각 효과는 각 도형이 어떤 스타일 슬롯을 참조하고 있는지, 그리고 직접 서식이 테마를 재정의하는지에 따라 달라집니다.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Read Effective Theme Values**

원시 테마 객체는 특정 수준에서 정의된 내용을 알려줍니다. 실제 값은 상속 및 로컬 재정의가 해결된 후 슬라이드나 도형이 실제로 사용하는 값을 알려줍니다. 슬라이드에 대해서는 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseoverridethememanager/)를 호출하십시오. 배경에 대해서는 [Background.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/background/), 채우기에 대해서는 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/)을 사용하십시오.

다음 예제는 슬라이드에서 실제 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

렌더링 진단, 검증 및 비교를 위해 실제 데이터를 사용하십시오. [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getmastertheme/)만 검사하면 최종 모습에 영향을 주는 마스터, 레이아웃, 슬라이드 또는 도형 재정의를 놓칠 수 있습니다.

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidethememanager/)를 사용하고 재정의 테마를 초기화하면 됩니다. 변경 사항은 해당 슬라이드에만 적용되며 다른 슬라이드는 기존 테마를 계속 상속합니다.

**What is the safest way to carry a theme from one presentation to another?**

슬라이드를 이동하면서 원본 외형을 보존하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslidecollection/)과 [SlideCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/)을 사용해 대상에 소스 마스터와 슬라이드를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**How can I see the effective values after inheritance and overrides?**

슬라이드 또는 레이아웃 테마에 대해서는 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseoverridethememanager/)를 사용하고, 포맷 객체에 대해서는 [Background.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/background/)와 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/) 등 해당 실제‑데이터 메서드를 사용하십시오. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.