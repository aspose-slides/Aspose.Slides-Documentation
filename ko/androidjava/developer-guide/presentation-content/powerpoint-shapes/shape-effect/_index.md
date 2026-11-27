---
title: Android에서 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/androidjava/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 발광 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 인상적이고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/androidjava/shape-formatting/#gradient-fill)나 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형에 빛 번짐을 퍼뜨리는 등 다양한 시각 효과를 구현할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

효과 조합에 따라 결과가 달라집니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공하는데, 프리셋 옵션은 보기 좋은 두 개 이상의 효과 조합을 미리 정의한 것입니다. 프리셋을 선택하면 여러 효과를 별도로 조정하거나 시험해 볼 필요 없이 적절한 조합을 바로 사용할 수 있습니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있게 합니다.

## **그림자 효과 적용**

Aspose.Slides for Android via Java는 도형에 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대비되어 돋보이게 할 수 있습니다. 그림자가 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞출 수 있습니다.

다음 Java 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--)를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![그림자 효과](shadow_effect.png)

#### **도형 회전 시 그림자 방향 제어**

기본적으로 외부 그림자는 도형과 함께 회전합니다. 회전 각도가 다른 도형에 동일한 방향에서 빛이 비추는 것처럼 보이게 하려면 `false` 를 인자로 전달해 [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-)을 호출하고, [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-)을 사용해 그림자 방향을 동일하게 지정합니다.

예제에서는 회색 그림자가 오른쪽으로 42포인트(0°) 오프셋된 두 개의 파란색 화살표를 만든 뒤, 슬라이드를 복제하고 두 화살표를 각각 시계 방향 90° 회전시킵니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
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

두 번째 슬라이드에서 왼쪽 화살표는 그림자가 아래쪽으로 드리워지고, 오른쪽 화살표는 여전히 오른쪽으로 그림자를 유지합니다. 두 그림자의 방향은 0°로 동일하게 유지됩니다.

![90° 회전 전후 PowerPoint 렌더링. 두 그림자는 오른쪽에 위치했으며 회전 후 왼쪽 화살표 아래로, 오른쪽 화살표는 여전히 오른쪽에 있음](arrow-shadow-rotation.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때는 내부 그림자를 사용해 카드나 패널에 움푹 들어간 느낌을 줄 수 있습니다. 외부 그림자는 도형 외부에 그림자를 만들고 도형을 떠오르게 보이게 하는 반면, 내부 그림자는 가장자리 안쪽을 어둡게 해서 도형이 들어간 듯한 효과를 줍니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)을 호출한 뒤, [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--)이 반환하는 그림자를 구성합니다. 흐림 반경 값이 클수록 가장자리가 부드러워집니다.

다음 Java 예제는 연한 파란색 카드에 어두운 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다. 그림자 방향은 225°, 거리 7포인트, 흐림 반경 6포인트입니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![내부 그림자가 적용된 연파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)을 호출합니다.

### **프리셋 그림자 적용, 변경 및 제거**

[enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--)을 호출하고, [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-)을 사용해 [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) 중 하나를 선택합니다. 동일 도형에서 스타일을 전환하려면 프리셋을 변경하면 됩니다. 그림자를 제거하면서 채우기와 윤곽선은 유지하려면 [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--)을 호출합니다.

다음 예제는 하나의 슬라이드에 네 단계(프리셋 적용 전, 첫 번째 프리셋, 두 번째 프리셋, 제거 후)를 나란히 보여줍니다. 두 그림자는 각각 10포인트 오프셋이며, 225° 방향은 첫 번째 그림자를 사각형 왼쪽 위에, 45° 방향은 두 번째 그림자를 오른쪽 아래에 배치합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Aspose.Slides for Android via Java에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도 및 크기 등을 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 전문적인 느낌을 부여해 프레젠테이션의 미적 완성도를 높여 줍니다. 간단한 코드로 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

다음 Java 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--)를 적용하는 방법을 보여줍니다:

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

## **발광 효과 적용**

Aspose.Slides for Android via Java에서 도형에 발광 효과를 적용하면 부드럽고 빛나는 아우라를 추가할 수 있습니다. 색상 및 크기와 같은 속성을 조정해 도형을 돋보이게 하고, 프레젠테이션에 매력적인 시각 요소를 더합니다. 최소한의 코드로 구현이 가능해 슬라이드 전체에 일관된 룩을 손쉽게 부여할 수 있습니다.

다음 Java 코드는 도형에 [발광 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--)를 적용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![발광 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Android via Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 섬세하고 정교한 외관을 제공해, 부드러운 외관이 필요한 디자인에 적합합니다. 반경 등 파라미터를 조절해 다양한 도형에 원하는 효과를 쉽게 구현할 수 있습니다.

다음 Java 코드는 도형에 [부드러운 가장자리 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--)를 적용하는 방법을 보여줍니다:

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

도형 흐림을 사용하면 도형의 채우기와 윤곽선을 부드럽게 만들면서도 도형 자체는 편집 가능하게 유지됩니다. 도형의 EffectFormat에서 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)을 호출합니다. 반경은 포인트(1/72인치) 단위이며, 값이 클수록 흐림이 강해집니다. 0이면 외관이 변하지 않습니다.

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 설정은 효과의 가시적 경계를 제어합니다. `false`이면 흐림이 원본 페인팅 경계(윤곽선 포함) 안에 제한되고, `true`이면 경계를 넘어 확장될 수 있습니다. 어느 설정을 사용해도 도형의 위치나 크기는 변하지 않습니다.

아래 비교는 동일한 채우기, 윤곽선 및 도형 크기를 사용한 예시이며, 상단 행은 `grow = false`, 하단 행은 `grow = true`인 경우를 보여줍니다.

![원본 사각형과 흐림 반경이 5포인트와 15포인트인 경우를 비교한 이미지( grow 비활성화 및 활성화 상태) ](shape_blur_comparison.png)

다음 Java 예제는 주황색 사각형에 짙은 파란색 윤곽선을 적용하고, 5포인트 흐림을 적용한 뒤, 다시 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)을 호출해 15포인트 흐림으로 업데이트합니다. 두 흐림 상태를 저장한 뒤, [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--)을 호출해 흐림이 없는 상태로 저장합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

도형 흐림은 채우기와 윤곽선을 함께 영향을 주며, 부드러운 가장자리 효과는 도형 가장자리만 흐리게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 적용되지만, 이 예제는 도형을 이미지로 변환하지 않고 바로 도형의 EffectFormat에 흐림을 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 발광 등 다양한 효과를 하나의 도형에 결합해 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에도 효과를 적용할 수 있나요?**

예, 그룹화된 도형 전체에 효과가 적용됩니다.