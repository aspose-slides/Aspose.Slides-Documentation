---
title: Android에서 WordArt 효과 만들기 및 적용
linktitle: 워드아트
type: docs
weight: 110
url: /ko/androidjava/wordart/
keywords:
- 워드아트
- 워드아트 만들기
- 워드아트 템플릿
- 워드아트 효과
- 그림자 효과
- 반사 효과
- 발광 효과
- 워드아트 변환
- 3D 효과
- 외부 그림자 효과
- 내부 그림자 효과
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 WordArt 효과를 만들고 맞춤화합니다. 이 단계별 가이드는 개발자가 Android에서 전문적인 텍스트로 프레젠테이션을 향상하도록 도와줍니다."
---
## **개요**

WordArt 효과를 사용하면 텍스트를 채우기, 외곽선, 그림자, 반사, 발광, 변형 및 3D 서식으로 스타일링할 수 있습니다. 이 문서에서는 Microsoft Office 없이 Aspose.Slides for Android via Java를 사용하여 PowerPoint 프레젠테이션에서 이러한 효과를 만들고 사용자 지정하는 방법을 설명합니다.

## **간단한 WordArt 템플릿 만들기 및 텍스트에 적용**

다음 예제에서는 텍스트, 글꼴, 패턴 채우기 및 외곽선을 설정하여 간단한 WordArt 스타일을 만듭니다.

각 예제는 새 프레젠테이션을 생성하고 첫 번째 슬라이드에 사각형을 추가합니다; 입력 파일이 필요하지 않습니다. 첫 번째 예제에서는 텍스트를 "Aspose.Slides"로 설정합니다. 도형의 위치와 크기는 포인트 단위로 측정됩니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

서식을 더 눈에 띄게 하려면 글꼴을 Arial Black으로 36 포인트로 설정합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

어두운 주황색 전경과 흰색 배경을 가진 [SmallGrid](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/patternstyle/#SmallGrid) 패턴을 적용하고, 폭이 1 포인트인 검은색 텍스트 외곽선을 추가합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

결과 텍스트:

![간단한 WordArt 템플릿](WordArt_template.png)

## **다른 WordArt 효과 적용**

다음 예제에서는 텍스트에 그림자, 반사, 발광, 변형 및 3D 효과를 적용하는 방법을 보여줍니다.

### **외부 그림자 효과 적용**

외부 그림자는 텍스트 뒤에 그림자를 배치하여 깊이를 추가합니다. 색상, 방향, 거리, 흐림 반경, 스케일 및 왜곡을 사용자 지정할 수 있습니다.

이 예제는 [enableOuterShadowEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--)을 호출하고 흐림 반경 4 포인트, 방향 230도, 거리 30 포인트인 검은색 그림자를 설정합니다. 스케일 값 100은 그림자 크기를 유지하고, 수평 왜곡은 20도 기울입니다. 알파 변환은 불투명도를 32%로 설정합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

결과 텍스트:

![외부 그림자 효과](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 외부 그림자와 사전 설정 그림자를 함께 사용할 경우, 외부 그림자만 적용됩니다.
- 외부 그림자와 내부 그림자를 동시에 사용하면, 결과 효과는 PowerPoint 버전에 따라 달라집니다. 예를 들어 PowerPoint 2013에서는 효과가 두 배가 되고, PowerPoint 2007에서는 외부 그림자만 적용됩니다.
{{% /alert %}}

### **반사 효과 적용**

반사는 텍스트의 거울 복사본을 만듭니다. 위치, 스케일, 흐림 및 불투명도를 조정하여 모양을 제어합니다.

이 예제는 [enableReflectionEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--)을 호출하고 스케일 -100%로 반사를 수직으로 뒤집습니다. 흐림 반경 0.5 포인트와 거리 4.72 포인트를 사용합니다. 불투명도는 반사 위치 0%에서 60% 사이에서 60%에서 0.9%로 감소합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
} finally {
    presentation.dispose();
}
```

결과 텍스트:

![반사 효과](reflection_effect.png)

### **발광 효과 적용**

발광은 텍스트 주위에 부드러운 색상 외곽선을 추가합니다. 색상, 불투명도 및 반경을 조정하여 효과를 제어합니다.

이 예제는 [enableGlowEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--)을 호출하고 불투명도 54% 및 반경 7 포인트인 빨간색 발광을 적용합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

결과 텍스트:

![발광 효과](glow_effect.png)

### **WordArt 변환 적용**

WordArt 변환은 텍스트 블록을 구부리거나, 늘리거나, 뒤틀 수 있습니다.

[setTransform](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframeformat/#setTransform-int-)을 [ArchUpPour](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textshapetype/#ArchUpPour)으로 설정하여 전체 텍스트 프레임을 위쪽으로 곡선 형태로 만들 수 있습니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

결과 텍스트:

![WordArt 변환](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java는 미리 정의된 [transformation types](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textshapetype/) 집합을 제공합니다.
{{% /alert %}}

### **도형 및 텍스트에 3D 효과 적용**

도형이나 텍스트에 3D 효과를 적용할 수 있습니다. 베벨, 압출, 조명 및 카메라 설정이 결과 모양을 제어합니다.

다음 예제는 [ThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/threedformat/)을 사용하여 사각형에 원형 베벨, 주황색 압출 및 짙은 빨간색 윤곽선을 추가합니다. 베벨 치수, 압출 높이, 윤곽선 너비 및 깊이는 포인트 단위로 측정됩니다. 플라스틱 재질, Z 축을 중심으로 40도 회전된 균형 조명 및 원근 카메라가 외형을 정의합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

결과 도형:

![도형 3D 효과](shape_3D_effect.png)

이 예제는 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--)을 통해 텍스트에도 유사한 3D 서식을 적용합니다. 작은 베벨이 글자 가장자리를 형성하고, 압출과 조명이 텍스트에 깊이를 부여합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

결과 텍스트:

![텍스트 3D 효과](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
텍스트 또는 도형에 3D 효과를 적용하고 이러한 효과 간의 상호 작용은 특정 규칙에 따라 결정됩니다. 텍스트와 이를 포함하는 도형이 모두 포함된 장면을 생각해 보십시오. 3D 효과는 객체의 3D 표현과 해당 객체가 배치되는 장면을 포함합니다.

- 도형과 텍스트 모두에 장면이 설정된 경우, 도형의 장면이 우선하고 텍스트의 장면은 무시됩니다.
- 도형에 자체 장면이 없지만 3D 표현이 있는 경우, 텍스트의 장면이 사용됩니다.
- 도형에 3D 효과가 전혀 없으면 평면으로 처리되어 3D 효과는 텍스트에만 적용됩니다.

이러한 동작은 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/threedformat/#getLightRig--) 및 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/threedformat/#getCamera--) 메서드와 관련됩니다.
{{% /alert %}}

텍스트를 평평하고 읽기 쉽게 유지하면서 도형의 3D 서식을 유지하려면, 두 설정의 비교 및 전체 Java 예제가 포함된 [Keep Text Flat on a 3D Shape](/slides/ko/androidjava/3d-presentation/) 를 참조하십시오.

## **FAQ**

**다른 글꼴이나 스크립트(예: 아라비아어, 중국어)에도 WordArt 효과를 사용할 수 있나요?**

예, Aspose.Slides for Android via Java는 유니코드를 지원하며 모든 주요 글꼴 및 스크립트와 함께 작동합니다. 그림자, 채우기 및 외곽선과 같은 WordArt 효과는 언어에 관계없이 적용할 수 있지만, 글꼴 가용성 및 렌더링은 시스템 글꼴에 따라 달라질 수 있습니다.

**슬라이드 마스터 요소에도 WordArt 효과를 적용할 수 있나요?**

예, 마스터 슬라이드의 도형(제목 자리 표시자, 바닥글 또는 배경 텍스트 포함)에 WordArt 효과를 적용할 수 있습니다. 마스터 레이아웃에 대한 변경 사항은 모든 관련 슬라이드에 반영됩니다.

**WordArt 효과가 프레젠테이션 파일 크기에 영향을 줍니까?**

약간 영향을 줍니다. 그림자, 발광 및 그라디언트 채우기와 같은 WordArt 효과는 추가된 서식 메타데이터 때문에 파일 크기를 약간 증가시킬 수 있지만, 차이는 보통 무시할 정도입니다.

**프레젠테이션을 저장하지 않고 WordArt 효과 결과를 미리 볼 수 있나요?**

예, [ISlide.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#getImage--)를 사용하여 WordArt가 포함된 슬라이드를 이미지(PNG, JPEG 등)로 렌더링하거나, [IShape.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getImage--)를 사용해 개별 도형을 렌더링할 수 있습니다. 이를 통해 프레젠테이션을 저장하거나 전체 내보내기 전에 메모리나 화면에서 결과를 미리볼 수 있습니다.