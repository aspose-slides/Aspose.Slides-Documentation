---
title: Java를 사용한 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 모양을 돋보이게 할 수 있지만, [채우기](/slides/ko/java/shape-formatting/#gradient-fill) 또는 외곽선과 다릅니다. PowerPoint 효과를 사용하면 모양에 설득력 있는 반사를 만들거나, 모양의 빛을 확산시키는 등 다양한 효과를 만들 수 있습니다.

![모양 효과](shape-effect.png)

PowerPoint는 모양에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 모양에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. 프리셋 옵션은 두 개 이상의 효과를 조합한 것으로 보기 좋은 것으로 알려져 있습니다. 이렇게 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 모양에 동일한 효과를 적용할 수 있게 합니다.

## **그림자 효과 적용**

Aspose.Slides for Java는 모양에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널을 슬라이드 배경에 대비해 돋보이게 할 수 있습니다. 그림자는 모양의 가장자리를 넘어 확장되어 모양이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞추십시오.

이 Java 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--)를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때는 카드나 패널에 오목한 외관을 주기 위해 내부 그림자를 사용합니다. 외부 그림자는 모양 밖으로 확장되어 떠 있는 것처럼 보이게 하고, 내부 그림자는 가장자리 내부를 음영 처리합니다.

먼저 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)를 호출하고, 그런 다음 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--)에서 반환된 그림자를 구성합니다. 큰 흐림 반경 값은 더 부드러운 가장자를 만듭니다.

이 Java 예제는 연한 파란색 카드를 어두운 회색 내부 그림자와 함께 생성하고 PPTX 파일로 저장합니다. 그림자 방향은 225도이고, 거리는 7포인트이며, 흐림 반경은 6포인트입니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![내부 그림자가 있는 연파란 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 모양의 효과 형식에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)를 호출하십시오.

### **프리셋 그림자 적용, 변경 및 제거**

먼저 [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--)를 호출하고 [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-)을 사용하여 [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/)을 선택합니다. 같은 모양에서 프리셋을 변경하여 스타일을 전환할 수 있습니다. 채우기와 외곽선을 유지하면서 그림자를 제거하려면 [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--)을 호출하십시오.

이 예제는 한 슬라이드에 네 단계를 나란히 보여줍니다. 두 그림자는 모두 10포인트만큼 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형의 위 왼쪽에 배치하고, 45°는 두 번째 그림자를 아래 오른쪽에 배치합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 원본 | 첫 번째 프리셋 | 두 번째 프리셋 | 제거 후 |
| :---: | :---: | :---: | :---: |
| ![그림자 없음](preset_shadow_original.png) | ![왼쪽 위 그림자](preset_shadow_top_left.png) | ![오른쪽 아래 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Java에서 반사 효과를 적용하려면 모양에 거울 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 모양에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 감각을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용해 일관된 디자인을 만들 수 있습니다.

이 Java 코드는 모양에 [반사 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--)를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![반사 효과](reflection_effect.png)

## **글로우 효과 적용**

Aspose.Slides for Java에서 모양에 글로우 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하여 부드럽고 빛나는 후광을 추가할 수 있습니다. 이 효과는 모양을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

이 Java 코드는 모양에 [글로우 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--)를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![글로우 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Java에서 부드러운 가장자리 효과를 적용하려면 모양의 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 외관을 추가하여 부드럽고 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 모양에 원하는 효과를 적용할 수 있습니다.

이 Java 코드는 모양에 [부드러운 가장자리 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--)를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![부드러운 가장자리 효과](soft_edges_effect.png)

## **블러 효과 적용**

모양 블러를 사용하면 모양을 편집 가능하게 유지하면서 채우기와 외곽선을 부드럽게 만들 수 있습니다. 모양의 효과 형식에서 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)를 호출합니다. 반경은 포인트(1/72인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 블러가 강해집니다. 반경이 0이면 외관이 변경되지 않습니다.

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 설정은 효과의 가시적인 경계를 제어합니다. `false`인 경우 블러가 외곽선을 포함한 원래 그려진 경계에 맞게 클리핑됩니다. `true`인 경우 블러가 그 경계를 넘어 확장될 수 있습니다. 두 설정 모두 모양의 위치나 크기를 변경하지 않습니다.

아래 비교에서는 전체적으로 동일한 채우기, 외곽선 및 모양 크기를 사용합니다. 상단 행은 `grow = false`를, 하단 행은 `grow = true`를 사용합니다.

![블러 반경 5와 15포인트, grow 비활성 및 활성 상태를 비교한 원본 사각형](shape_blur_comparison.png)

이 Java 예제는 주황색 사각형에 짙은 파란색 외곽선을 추가하고 5포인트 블러를 적용한 뒤, [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)를 다시 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 다음 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--)을 호출하여 블러가 없는 모양을 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

모양 블러는 채우기와 외곽선을 함께 영향을 미칩니다. 부드러운 가장자리 효과는 모양의 가장자리를 페이드 처리하고, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 작용하지만, 이 예제는 모양을 이미지로 변환하지 않고 모양의 효과 형식에 직접 블러를 적용합니다.

## **FAQ**

**같은 모양에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 모양에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 모양에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 모양에 효과를 적용할 수 있습니다.

**그룹화된 모양에도 효과를 적용할 수 있나요?**

예, 그룹화된 모양에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.