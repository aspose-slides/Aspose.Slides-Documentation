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
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 마스터 프레젠테이션 테마를 만들고, 맞춤 설정하고, 변환하여 일관된 브랜드를 유지합니다."
---
## **소개**

프레젠테이션 테마는 디자인 요소의 속성을 정의합니다. 프레젠테이션 테마를 선택하면 본질적으로 특정 시각적 요소와 해당 속성 집합을 선택하는 것입니다.

PowerPoint에서 테마는 색상, [글꼴](/slides/ko/nodejs-java/powerpoint-fonts/), [배경 스타일](/slides/ko/nodejs-java/presentation-background/), 그리고 효과로 구성됩니다.

![테마-구성요소](theme-constituents.png)

## **테마 색상 변경**

PowerPoint 테마는 슬라이드의 다양한 요소에 대해 특정 색상 집합을 사용합니다. 색상이 마음에 들지 않으면 테마에 새로운 색상을 적용하여 색상을 변경할 수 있습니다. 새 테마 색상을 선택할 수 있도록 Aspose.Slides는 [SchemeColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SchemeColor) 열거형에 값을 제공합니다.

This JavaScript code shows you how to change the accent color for a theme:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

You can determine the resulting color's effective value this way:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

To further demonstrate the color change operation, we create another element and assign the accent color (from the initial operation) to it. Then we change the color in the theme:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

새 색상이 두 요소 모두에 자동으로 적용됩니다.

### **추가 팔레트에서 테마 색상 설정**

주 테마 색상(1)에 휘도 변환을 적용하면 추가 팔레트(2)의 색상이 생성됩니다. 그런 다음 해당 테마 색상을 설정하고 가져올 수 있습니다.

![추가-팔레트-색상](additional-palette-colors.png)

**1** - 주 테마 색상  
**2** - 추가 팔레트 색상.

This JavaScript code demonstrates an operation where additional palette colors are obtained from the main theme color and then used in shapes:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 강조 색상 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // 강조 색상 4, 밝게 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // 강조 색상 4, 밝게 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // 강조 색상 4, 밝게 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // 강조 색상 4, 어둡게 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // 강조 색상 4, 어둡게 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **`SchemeColor`를 `ColorScheme` 색상에 매핑**

다음과 같은 테마 색상 값이 포함되어 있음을 알 수 있습니다:

`Background1`, `Background2`, `Text1`, and `Text2`.

하지만 `Presentation.getMasterTheme().getColorScheme()`는 [ColorScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/colorscheme/)을 반환하며, 해당 색상은 다음과 같이 노출됩니다:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

이 차이는 이름만 다를 뿐입니다. 이러한 값은 동일한 테마 색상 슬롯을 가리키며 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background`와 `Dark`/`Light` 사이에 동적 변환은 없습니다. 동일한 테마 색상의 대체 이름일 뿐입니다.

이 명명 차이는 Microsoft Office 용어에서 비롯되었습니다. 오래된 Office 버전은 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`를 사용했으며, 최신 UI 버전은 동일한 슬롯을 `Text 1`, `Background 1`, `Text 2`, `Background 2`로 표시합니다.

## **테마 글꼴 변경**

테마 및 기타 용도로 글꼴을 선택할 수 있도록 Aspose.Slides는 다음과 같은 특수 식별자를 사용합니다 (PowerPoint와 유사):

* **+mn-lt** - 본문 글꼴 라틴 (소형 라틴 글꼴)
* **+mj-lt** - 제목 글꼴 라틴 (대형 라틴 글꼴)
* **+mn-ea** - 본문 글꼴 동아시아 (소형 동아시아 글꼴)
* **+mj-ea** - 본문 글꼴 동아시아 (대형 동아시아 글꼴)

This JavaScript code shows you how to assign the Latin font to a theme element:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

This JavaScript code shows you how to change the presentation theme font:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

모든 텍스트 상자의 글꼴이 업데이트됩니다.

{{% alert color="primary" title="TIP" %}} 
PowerPoint 글꼴을 확인해 보시기 바랍니다. [PowerPoint 글꼴](/slides/ko/nodejs-java/powerpoint-fonts/)
{{% /alert %}}

## **테마 배경 스타일 변경**

기본적으로 PowerPoint 앱은 12개의 미리 정의된 배경을 제공하지만, 일반적인 프레젠테이션에서는 그 중 3개만 저장됩니다.

![프레젠테이션 디자인](presentation-design_8.png)

예를 들어 PowerPoint 앱에서 프레젠테이션을 저장한 후, 다음 JavaScript 코드를 실행하여 프레젠테이션에 포함된 미리 정의된 배경 수를 확인할 수 있습니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 속성을 [FormatScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FormatScheme) 클래스에서 사용하면 PowerPoint 테마의 배경 스타일을 추가하거나 접근할 수 있습니다.
{{% /alert %}} 

This JavaScript code shows you how to set the background for a presentation:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**인덱스 안내**: 0은 채우기 없음에 사용됩니다. 인덱스는 1부터 시작합니다.

{{% alert color="primary" title="TIP" %}} 
PowerPoint 배경을 확인해 보시기 바랍니다. [PowerPoint 배경](/slides/ko/nodejs-java/presentation-background/)
{{% /alert %}}

## **테마 효과 변경**

PowerPoint 테마는 일반적으로 각 스타일 배열에 대해 3개의 값을 포함합니다. 이 배열들은 미묘함, 보통, 강렬이라는 3가지 효과로 결합됩니다. 예를 들어 특정 도형에 효과를 적용했을 때의 결과는 다음과 같습니다:

![프레젠테이션 디자인](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--) 등 3가지 속성을 [FormatScheme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FormatScheme) 클래스에서 사용하면 PowerPoint 옵션보다 더 유연하게 테마의 요소를 변경할 수 있습니다.

This JavaScript code shows you how to change a theme effect by altering parts of elements:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

채우기 색상, 채우기 유형, 그림자 효과 등의 결과적인 변경 사항:

![프레젠테이션 디자인](presentation-design_11.png)

## **FAQ**

**마스터를 변경하지 않고 단일 슬라이드에 테마를 적용할 수 있나요?**

예. Aspose.Slides는 슬라이드 수준 테마 재정의를 지원하므로 마스터 테마를 유지하면서 해당 슬라이드에만 로컬 테마를 적용할 수 있습니다 (via the [SlideThemeManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidethememanager/)).

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 옮기는 가장 안전한 방법은 무엇인가요?**

[Clone slides](/slides/ko/nodejs-java/clone-slides/)를 마스터와 함께 대상 프레젠테이션에 복사합니다. 이렇게 하면 원본 마스터, 레이아웃 및 관련 테마가 보존되어 외관이 일관됩니다.

**모든 상속 및 재정의 후 'effective' 값을 어떻게 확인할 수 있나요?**

테마/색상/글꼴/효과에 대한 API의 ["effective" views](/slides/ko/nodejs-java/shape-effective-properties/)를 사용하십시오. 이는 마스터와 모든 로컬 재정의를 적용한 후 해결된 최종 속성을 반환합니다.