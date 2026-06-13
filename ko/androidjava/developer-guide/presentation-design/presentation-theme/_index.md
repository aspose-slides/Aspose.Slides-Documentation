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
description: "Aspose.Slides for Android에서 Java를 사용하여 프레젠테이션 테마를 마스터하고, 일관된 브랜딩으로 PowerPoint 파일을 생성, 맞춤 설정 및 변환합니다."
---
## **소개**

프레젠테이션 테마는 디자인 요소의 속성을 정의합니다. 프레젠테이션 테마를 선택하면 기본적으로 특정 시각 요소와 해당 속성 집합을 선택하는 것입니다.

PowerPoint에서 테마는 색상, [글꼴](/slides/ko/androidjava/powerpoint-fonts/), [배경 스타일](/slides/ko/androidjava/presentation-background/), 그리고 효과로 구성됩니다.

![theme-constituents](theme-constituents.png)

## **테마 색상 변경**

PowerPoint 테마는 슬라이드의 다양한 요소에 대해 특정 색상 집합을 사용합니다. 색상이 마음에 들지 않으면 새 색상을 적용하여 테마 색상을 변경합니다. 새 테마 색상을 선택할 수 있도록 Aspose.Slides는 [SchemeColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SchemeColor) 열거형에 정의된 값을 제공합니다.

다음 Java 코드에서는 테마의 강조 색상을 변경하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

다음과 같이 결과 색상의 실제 값을 확인할 수 있습니다:

```java
IFfillEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

색상 변경 작업을 더 보여주기 위해 다른 요소를 만들고 처음 작업에서 얻은 강조 색상을 할당합니다. 그런 다음 테마의 색상을 변경합니다:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

새 색상이 두 요소에 자동으로 적용됩니다.

### **추가 팔레트에서 테마 색상 설정**

주 테마 색상(1)에 밝기 변환을 적용하면 추가 팔레트(2)에서 색상이 생성됩니다. 이후 해당 테마 색상을 설정하고 가져올 수 있습니다.

![additional-palette-colors](additional-palette-colors.png)

**1** - 주 테마 색상

**2** - 추가 팔레트의 색상.

다음 Java 코드는 주 테마 색상에서 추가 팔레트 색상을 가져와 도형에 사용하는 작업을 보여줍니다:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 강조 색상 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 강조 색상 4, 밝게 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 강조 색상 4, 밝게 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 강조 색상 4, 밝게 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // 강조 색상 4, 어둡게 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 강조 색상 4, 어둡게 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor`를 `IColorScheme` 색상에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/schemecolor/)를 사용할 때 다음과 같은 테마 색상 값을 포함하고 있음을 알 수 있습니다:

`Background1`, `Background2`, `Text1`, and `Text2`.

하지만 `Presentation.getMasterTheme().getColorScheme()`는 [IColorScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icolorscheme/)을 반환하며, 해당 색상을 다음과 같이 노출합니다:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

이 차이는 명명 방식만 다를 뿐이며, 이 값들은 동일한 테마 색상 슬롯을 가리키고 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background`와 `Dark`/`Light` 사이에 동적 변환은 없습니다. 이들은 동일한 테마 색상의 다른 이름일 뿐입니다.

이 명명 차이는 Microsoft Office 용어에서 비롯되었습니다. 이전 Office 버전에서는 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`를 사용했으며, 최신 UI 버전에서는 동일한 슬롯을 `Text 1`, `Background 1`, `Text 2`, `Background 2`로 표시합니다.

## **테마 글꼴 변경**

테마 및 기타 용도로 글꼴을 선택할 수 있도록 Aspose.Slides는 다음과 같은 특수 식별자를 사용합니다 (PowerPoint에서 사용되는 것과 유사합니다):

* **+mn-lt** - 본문 라틴 글꼴 (Minor Latin Font)
* **+mj-lt** - 헤딩 라틴 글꼴 (Major Latin Font)
* **+mn-ea** - 본문 동아시아 글꼴 (Minor East Asian Font)
* **+mj-ea** - 본문 동아시아 글꼴 (Major East Asian Font)

다음 Java 코드는 라틴 글꼴을 테마 요소에 할당하는 방법을 보여줍니다:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

다음 Java 코드는 프레젠테이션 테마 글꼴을 변경하는 방법을 보여줍니다:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

모든 텍스트 상자의 글꼴이 업데이트됩니다.

{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint 글꼴](/slides/ko/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **테마 배경 스타일 변경**

기본적으로 PowerPoint 앱은 12개의 사전 정의된 배경을 제공하지만 일반 프레젠테이션에서는 그 중 3개만 저장됩니다.

![todo:image_alt_text](presentation-design_8.png)

예를 들어 PowerPoint 앱에서 프레젠테이션을 저장한 후, 다음 Java 코드를 실행하여 프레젠테이션에 포함된 사전 정의된 배경 수를 확인할 수 있습니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

[BackgroundFillStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 속성을 [FormatScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FormatScheme) 클래스에서 사용하면 PowerPoint 테마의 배경 스타일을 추가하거나 접근할 수 있습니다.

{{% /alert %}} 

다음 Java 코드는 프레젠테이션의 배경을 설정하는 방법을 보여줍니다:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**인덱스 안내**: 0은 채우기 없음에 사용됩니다. 인덱스는 1부터 시작합니다.

{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint 배경](/slides/ko/androidjava/presentation-background/).

{{% /alert %}}

## **테마 효과 변경**

PowerPoint 테마는 일반적으로 각 스타일 배열에 대해 3개의 값을 포함합니다. 이러한 배열은 미묘한, 보통, 강렬한 3가지 효과로 결합됩니다. 예를 들어, 특정 도형에 효과를 적용했을 때의 결과는 다음과 같습니다:

![todo:image_alt_text](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--) 등 3가지 속성을 [FormatScheme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FormatScheme) 클래스에서 사용하면 테마의 요소들을 (PowerPoint 옵션보다 더 유연하게) 변경할 수 있습니다.

다음 Java 코드는 요소의 일부를 변경하여 테마 효과를 바꾸는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

그 결과로 채우기 색상, 채우기 유형, 그림자 효과 등에서 변화가 나타납니다:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**마스터를 변경하지 않고 단일 슬라이드에 테마를 적용할 수 있나요?**

예. Aspose.Slides는 슬라이드 수준의 테마 오버라이드를 지원하므로, 마스터 테마는 그대로 두고 해당 슬라이드에만 로컬 테마를 적용할 수 있습니다 ([SlideThemeManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidethememanager/)를 통해).

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 안전하게 옮기는 가장 좋은 방법은 무엇인가요?**

[슬라이드 복제](/slides/ko/androidjava/clone-slides/)를 사용해 마스터와 함께 대상 프레젠테이션에 복사합니다. 이렇게 하면 원본 마스터, 레이아웃 및 연관된 테마가 보존되어 외관이 일관성을 유지합니다.

**상속 및 오버라이드 후 "실제" 값을 어떻게 확인할 수 있나요?**

API의 ["effective" 뷰](/slides/ko/androidjava/shape-effective-properties/)를 사용하면 테마·색상·글꼴·효과의 실제 값을 확인할 수 있습니다. 이는 마스터와 로컬 오버라이드가 적용된 후 해결된 최종 속성을 반환합니다.