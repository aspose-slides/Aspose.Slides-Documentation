---
title: Java에서 WordArt 효과 만들기 및 적용
linktitle: WordArt
type: docs
weight: 110
url: /ko/java/wordart/
keywords:
- WordArt
- WordArt 만들기
- WordArt 템플릿
- WordArt 효과
- 그림자 효과
- 디스플레이 효과
- 글로우 효과
- WordArt 변환
- 3D 효과
- 외부 그림자 효과
- 내부 그림자 효과
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 WordArt 효과를 만들고 맞춤 설정합니다. 이 단계별 가이드는 개발자가 Java에서 전문적인 텍스트로 프레젠테이션을 향상시키는 데 도움을 줍니다."
---
## **개요**

WordArt 효과를 사용하면 PowerPoint 프레젠테이션에 시각적으로 매력적이고 스타일화된 텍스트를 추가할 수 있습니다. Aspose.Slides를 사용하면 개발자가 Microsoft PowerPoint와 동일하게 WordArt를 프로그래밍 방식으로 생성, 사용자 정의 및 관리할 수 있으며, Office를 설치할 필요가 없습니다. 이 문서는 WordArt 작업에 대한 개요를 제공하며, 텍스트 변환, 채우기 스타일, 윤곽선, 그림자 및 기타 서식 옵션을 적용하여 프레젠테이션 콘텐츠를 보다 풍부하고 매력적으로 만드는 방법을 포함합니다. WordArt는 텍스트를 그래픽 객체처럼 다룰 수 있게 해줍니다. 텍스트에 적용되는 효과나 특수 수정으로 텍스트를 더 매력적이거나 눈에 띄게 만들 수 있습니다.

## **간단한 WordArt 템플릿 만들기 및 텍스트에 적용하기**

**Using Aspose.Slides** 

먼저, 이 Java 코드를 사용하여 간단한 텍스트를 생성합니다: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
이제, 텍스트의 글꼴 크기를 더 크게 설정하여 효과를 더 눈에 띄게 만들기 위해 다음 코드를 사용합니다:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Using Microsoft PowerPoint**

Microsoft PowerPoint에서 WordArt 효과 메뉴로 이동합니다:

![todo:image_alt_text](image-20200930113926-1.png)

오른쪽 메뉴에서 미리 정의된 WordArt 효과를 선택할 수 있습니다. 왼쪽 메뉴에서 새 WordArt에 대한 설정을 지정할 수 있습니다. 

다음은 사용 가능한 일부 매개변수 또는 옵션입니다:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

여기에서는 텍스트에 [SmallGrid](https://reference.aspose.com/slides/ko/java/com.aspose.slides/PatternStyle#SmallGrid) 패턴 색상을 적용하고, 다음 코드를 사용하여 두께 1의 검은색 텍스트 테두리를 추가합니다:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

결과 텍스트:

![todo:image_alt_text](image-20200930114108-4.png)

## **다른 WordArt 효과 적용**

**Using Microsoft PowerPoint**

프로그램 인터페이스에서 텍스트, 텍스트 블록, 도형 또는 유사한 요소에 이러한 효과를 적용할 수 있습니다:

![todo:image_alt_text](image-20200930114129-5.png)

예를 들어, 그림자, 반사 및 글로우 효과는 텍스트에 적용할 수 있고; 3D 형식 및 3D 회전 효과는 텍스트 블록에 적용할 수 있으며; Soft Edges 속성은 도형 객체에 적용할 수 있습니다(3D 형식 속성이 설정되지 않아도 효과가 적용됩니다). 

### **그림자 효과 적용**

여기서는 텍스트에만 관련된 속성을 설정하려고 합니다. Java 코드를 사용하여 텍스트에 그림자 효과를 적용합니다:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API는 OuterShadow, InnerShadow 및 PresetShadow의 세 가지 그림자 유형을 지원합니다. 

PresetShadow를 사용하면 사전 설정값으로 텍스트에 그림자를 적용할 수 있습니다. 

**Using Microsoft PowerPoint**

PowerPoint에서는 하나의 그림자 유형만 사용할 수 있습니다. 예시는 다음과 같습니다:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides는 실제로 InnerShadow와 PresetShadow 두 가지 그림자를 동시에 적용할 수 있습니다.

**Notes:**

- OuterShadow와 PresetShadow를 함께 사용할 경우, OuterShadow 효과만 적용됩니다. 
- OuterShadow와 InnerShadow를 동시에 사용할 경우, 적용되는 효과는 PowerPoint 버전에 따라 다릅니다. 예를 들어 PowerPoint 2013에서는 효과가 두 배가 되지만, PowerPoint 2007에서는 OuterShadow 효과만 적용됩니다. 

### **텍스트에 디스플레이 적용**

다음 Java 코드 샘플을 통해 텍스트에 디스플레이를 추가합니다:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **텍스트에 글로우 효과 적용**

다음 코드를 사용하여 텍스트에 글로우 효과를 적용해 빛나거나 돋보이게 합니다:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

작업 결과:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

그림자, 디스플레이 및 글로우의 매개변수를 변경할 수 있습니다. 효과 속성은 텍스트의 각 부분에 별도로 설정됩니다. 

{{% /alert %}} 

### **WordArt에서 변환 사용**

다음 코드를 통해 Transform 속성(전체 텍스트 블록에 적용되는)을 사용합니다:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

결과:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint와 Aspose.Slides for Java 모두 미리 정의된 변환 유형을 일정 수 제공합니다. 

{{% /alert %}} 

**Using PowerPoint**

미리 정의된 변환 유형에 접근하려면 다음 경로를 따릅니다: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

변환 유형을 선택하려면 TextShapeType 열거형을 사용합니다. 

### **텍스트 및 도형에 3D 효과 적용**

다음 샘플 코드를 사용하여 텍스트 도형에 3D 효과를 설정합니다:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

결과 텍스트와 해당 도형:

![todo:image_alt_text](image-20200930114816-9.png)

다음 Java 코드를 사용하여 텍스트에 3D 효과를 적용합니다:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

작업 결과:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

텍스트 또는 그 도형에 3D 효과를 적용하고 효과 간 상호 작용은 특정 규칙에 따라 수행됩니다. 

텍스트와 해당 텍스트를 포함하는 도형에 대한 장면을 고려하십시오. 3D 효과는 3D 객체 표현과 객체가 배치된 장면을 포함합니다. 

- 도형과 텍스트 모두에 장면이 설정된 경우, 도형 장면이 더 높은 우선순위를 갖고 텍스트 장면은 무시됩니다. 
- 도형에 자체 장면은 없지만 3D 표현이 있는 경우, 텍스트 장면이 사용됩니다. 
- 그 외의 경우—도형에 원래 3D 효과가 없으면—도형은 평면이며 3D 효과는 텍스트에만 적용됩니다. 

이 설명은 ThreeDFormat.getLightRig() 및 ThreeDFormat.getCamera() 메서드와 연결됩니다. 

{{% /alert %}} 

## **텍스트에 외부 그림자 효과 적용**
Aspose.Slides for Java는 [**IOuterShadow**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioutershadow/) 및 [**IInnerShadow**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinnershadow/) 클래스를 제공하여 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframe/)에 포함된 텍스트에 그림자 효과를 적용할 수 있습니다. 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 Rectangle 유형의 AutoShape를 추가합니다.
4. AutoShape와 연결된 TextFrame에 접근합니다.
5. AutoShape의 FillType을 NoFill로 설정합니다.
6. OuterShadow 클래스를 인스턴스화합니다.
7. 그림자의 BlurRadius를 설정합니다.
8. 그림자의 Direction을 설정합니다.
9. 그림자의 Distance를 설정합니다.
10. RectanglelAlign를 TopLeft로 설정합니다.
11. 그림자의 PresetColor를 Black으로 설정합니다.
12. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.

다음 Java 샘플 코드는 위 단계들을 구현한 것으로, 텍스트에 외부 그림자 효과를 적용하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    // 슬라이드에 대한 참조 가져오기
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle 유형의 AutoShape 추가
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle에 TextFrame 추가
    ashp.addTextFrame("Aspose TextBox");

    // 텍스트 그림자를 얻기 위해 도형 채우기를 비활성화
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 외부 그림자를 추가하고 필요한 모든 매개변수를 설정
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //프레젠테이션을 디스크에 저장
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형에 내부 그림자 효과 적용**
다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 슬라이드에 대한 참조를 가져옵니다.
3. Rectangle 유형의 AutoShape를 추가합니다.
4. InnerShadowEffect를 활성화합니다.
5. 필요한 모든 매개변수를 설정합니다.
6. ColorType을 Scheme으로 설정합니다.
7. Scheme Color를 설정합니다.
8. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.

다음 Java 샘플 코드는 위 단계들을 기반으로 두 도형 사이에 연결선을 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    // 슬라이드에 대한 참조 가져오기
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle 유형의 AutoShape 추가
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle에 TextFrame 추가
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect 활성화
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 필요한 모든 매개변수 설정
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType을 Scheme으로 설정
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme 색상 설정
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 프레젠테이션 저장
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**다양한 글꼴이나 스크립트(예: 아랍어, 중국어)와 함께 WordArt 효과를 사용할 수 있나요?**

네, Aspose.Slides는 Unicode를 지원하며 모든 주요 글꼴 및 스크립트와 함께 작동합니다. 언어에 관계없이 그림자, 채우기 및 윤곽선과 같은 WordArt 효과를 적용할 수 있지만, 글꼴 가용성 및 렌더링은 시스템에 설치된 글꼴에 따라 달라질 수 있습니다.

**슬라이드 마스터 요소에 WordArt 효과를 적용할 수 있나요?**

네, 마스터 슬라이드의 도형(제목 자리 표시자, 바닥글 또는 배경 텍스트 등)에 WordArt 효과를 적용할 수 있습니다. 마스터 레이아웃에 변경을 가하면 해당 슬라이드에 연결된 모든 슬라이드에 반영됩니다.

**WordArt 효과가 프레젠테이션 파일 크기에 영향을 미치나요?**

약간 영향을 줍니다. 그림자, 글로우 및 그라데이션 채우기와 같은 WordArt 효과는 추가 서식 메타데이터 때문에 파일 크기를 약간 증가시킬 수 있지만, 차이는 일반적으로 무시할 정도입니다.

**프레젠테이션을 저장하지 않고 WordArt 효과 결과를 미리 볼 수 있나요?**

네, [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 및 [ISlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/) 인터페이스의 `getImage` 메서드를 사용하여 WordArt가 포함된 슬라이드를 이미지(PNG, JPEG 등)로 렌더링할 수 있습니다. 이를 통해 프레젠테이션을 저장하거나 전체로 내보내기 전에 메모리 내 또는 화면에서 결과를 미리 볼 수 있습니다.