---
title: Java를 사용하여 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 광채 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PPT 및 PPTX 파일에 고급 도형 효과를 적용하고, 몇 초 만에 인상적이고 전문적인 슬라이드를 만들세요."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/java/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사효과를 만들거나, 도형의 광채를 퍼뜨리는 등 다양한 효과를 적용할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. Preset 옵션은 보기 좋은 두 개 이상의 효과 조합으로 이루어져 있습니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 좋은 조합을 찾는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for Java는 도형에 대해 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

슬라이드 배경에 대비해 카드 또는 패널을 돋보이게 하려면 외부 그림자를 사용하십시오. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위로 떠 있는 것처럼 보이게 합니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞추세요.

다음 Java 코드에서는 직사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--)를 적용하는 방법을 보여줍니다:

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

#### **도형 회전 시 그림자 방향 제어**

기본적으로 외부 그림자는 도형과 함께 회전합니다. 회전이 다른 도형들이 동일한 방향에서 조명된 것처럼 보이게 하려면 `false`와 함께 [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-)을 호출하고, [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-)을 사용해 그림자 방향을 동일하게 지정하세요.

예제는 오른쪽으로 42포인트 오프셋된 회색 그림자를 가진 파란색 화살표 두 개(0°)를 생성합니다. 그런 다음 슬라이드를 복제하고 두 화살표를 시계 방향으로 90° 회전시킵니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

두 번째 슬라이드에서 왼쪽 화살표는 그림자를 아래로 드리우고, 오른쪽 화살표는 여전히 오른쪽으로 그림자를 드리웁니다. 설정된 방향은 두 그림자 모두 0°로 유지됩니다.

![90° 회전 전후 PowerPoint 렌더링. 두 그림자 모두 오른쪽에 시작합니다. 회전 후, 그림자는 왼쪽 화살표 아래로 이동하고 오른쪽 화살표 오른쪽에 남아 있습니다.](arrow-shadow-rotation.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때, 카드 또는 패널에 움푹 들어간 모습을 주려면 내부 그림자를 사용합니다. 외부 그림자는 도형 외부로 확장되어 도형이 떠 있는 것처럼 보이게 하고, 내부 그림자는 가장자리 내부를 음영 처리합니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)을 호출한 다음, [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--)가 반환하는 그림자를 구성합니다. 블러 반경 값이 클수록 가장자리가 부드러워집니다.

이 Java 예제는 연한 파란색 카드에 어두운 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리 7포인트, 블러 반경은 6포인트입니다:

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

![내부 그림자가 있는 연한 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 effect format에 대해 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)을 호출하세요.

### **프리셋 그림자 적용, 변경 및 제거**

[enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--)을 호출하고 [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-)을 사용해 [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/)을 선택합니다. 스타일을 전환하려면 동일한 도형에서 프리셋을 변경하세요. [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--)을 호출하면 채우기와 윤곽선을 유지하면서 그림자를 제거할 수 있습니다.

이 예제는 한 슬라이드에 네 단계가 나란히 표시됩니다. 두 그림자는 모두 10포인트 오프셋됩니다. 방향 225°는 첫 번째 그림자를 사각형의 위와 왼쪽에 배치하고, 45°는 두 번째 그림자를 아래와 오른쪽에 배치합니다.

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
| ![그림자 없음](preset_shadow_original.png) | ![좌상단 그림자](preset_shadow_top_left.png) | ![우하단 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Java에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정할 수 있습니다. 이 효과는 도형을 보다 깔끔하고 세련된 모습으로 만들어 프레젠테이션의 미적 품질을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용하여 일관된 디자인을 구현할 수 있습니다.

다음 Java 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--)를 적용하는 방법을 보여줍니다:

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

## **광채 효과 적용**

Aspose.Slides for Java에서 도형에 광채 효과를 적용하려면 색상과 크기와 같은 속성을 조정하여 도형 주변에 부드럽고 빛나는 광원을 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈길을 끄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 Java 코드는 도형에 [광채 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--)를 적용하는 방법을 보여줍니다:

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

![광채 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Java에서 부드러운 가장자리 효과를 적용하려면 도형 가장자리에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 은은하고 정교한 모습을 추가하여 부드럽고 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 Java 코드는 도형에 [부드러운 가장자리 효과](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--)를 적용하는 방법을 보여줍니다:

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

## **흐림 효과 적용**

도형 흐림을 사용하면 도형을 편집 가능하게 유지하면서 채우기와 윤곽선을 부드럽게 만들 수 있습니다. 도형의 effect format에 대해 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)을 호출하십시오. 반경은 포인트(1/72 인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 흐림이 강해집니다. 반경이 0이면 외관이 변하지 않습니다.

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 설정은 효과의 보이는 경계를 제어합니다. `false`인 경우 흐림은 외곽선을 포함한 원래 그려진 경계에 클리핑됩니다. `true`인 경우 흐림이 해당 경계 밖으로 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 변경하지 않습니다.

아래 비교에서는 전체적으로 동일한 채우기, 윤곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = false`를 사용하고, 하단 행은 `grow = true`를 사용합니다.

![grow 비활성 및 활성인 5포인트와 15포인트 흐림 반경을 가진 원본 사각형 비교](shape_blur_comparison.png)

이 Java 예제는 주황색 사각형에 진한 파란색 윤곽선을 추가하고 5포인트 흐림을 적용한 뒤, 다시 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)을 호출하여 15포인트 흐림으로 업데이트합니다. 두 흐림 상태를 저장한 다음 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--)을 호출해 흐림 없는 도형을 저장합니다.

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

도형 흐림은 채우기와 윤곽선을 동시에 영향을 줍니다. 부드러운 가장자리 효과는 도형 가장자리를 흐리게 하고, 그림자 흐림은 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 effect format에 직접 흐림을 적용합니다.

## **자주 묻는 질문**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 광채와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.