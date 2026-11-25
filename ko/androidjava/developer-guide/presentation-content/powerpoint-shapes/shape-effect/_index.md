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
- 글로우 효과
- 소프트 엣지 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문가 수준의 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 하는 데 사용할 수 있지만, [채우기](/slides/ko/androidjava/shape-formatting/#gradient-fill) 또는 테두리와는 다릅니다. PowerPoint 효과를 사용하면 도형에 실감나는 반사 효과를 만들고, 도형의 광채를 퍼뜨리는 등 다양한 효과를 만들 수 있습니다.

![Shape effect](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

효과 조합 중 일부는 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래 옵션을 제공합니다. Preset 옵션은 두 개 이상의 효과를 조합한 것으로, 보기 좋게 보이는 것으로 알려져 있습니다. 따라서 프리셋을 선택하면 다양한 효과를 테스트하거나 조합하여 좋은 조합을 찾는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for Android via Java는 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대해 돋보이게 할 수 있습니다. 그림자가 도형의 가장자리를 넘어 확장되어 도형이 슬라이드 위로 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 조정하여 템플릿의 조명 및 스타일에 맞추세요.

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

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때, 내부 그림자를 사용하면 카드나 패널에 움푹 들어간 모양을 부여할 수 있습니다. 외부 그림자는 도형 밖으로 확장되어 도형이 떠 있는 듯 보이게 하고, 내부 그림자는 가장자리 안쪽을 음영 처리합니다.

먼저 [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)를 호출하고, 이후 [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--)가 반환하는 그림자를 구성합니다. 블러 반경 값이 클수록 가장자리가 부드러워집니다.

다음 Java 예제는 연한 파란색 카드에 짙은 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리는 7포인트, 블러 반경은 6포인트입니다:

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

![내부 그림자가 있는 연한 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 effect format에 대해 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)를 호출합니다.

### **프리셋 그림자 적용, 변경 및 제거**

먼저 [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--)를 호출하고, [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-)을 사용하여 [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/)을 선택합니다. 스타일을 전환하려면 동일한 도형에서 프리셋을 변경하세요. [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--)를 호출하면 채우기와 테두리는 유지한 채 그림자를 제거할 수 있습니다.

이 예제는 한 슬라이드에 네 단계가 나란히 표시됩니다. 두 그림자는 모두 10포인트만큼 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형의 왼쪽 위에, 45° 방향은 두 번째 그림자를 오른쪽 아래에 배치합니다.

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
| ![그림자 없음](preset_shadow_original.png) | ![왼쪽 위 그림자](preset_shadow_top_left.png) | ![오른쪽 아래 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Android via Java에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 가치를 높여줍니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용하여 일관된 디자인을 만들 수 있습니다.

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

## **글로우 효과 적용**

Aspose.Slides for Android via Java에서 도형에 글로우 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하면서 부드럽고 빛나는 오라를 도형 주위에 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 더합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 Java 코드는 도형에 [글로우 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--)를 적용하는 방법을 보여줍니다:

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

![글로우 효과](glow_effect.png)

## **소프트 엣지 효과 적용**

Aspose.Slides for Android via Java에서 소프트 엣지 효과를 적용하려면 도형 가장자리에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 은은하고 정교한 외관을 제공하여 부드러운 모양이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 Java 코드는 도형에 [소프트 엣지 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--)를 적용하는 방법을 보여줍니다:

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

![소프트 엣지 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형을 편집 가능한 상태로 유지하면서 채우기와 테두리를 부드럽게 할 수 있습니다. 도형의 effect format에 대해 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)를 호출합니다. 반경은 포인트(1/72 인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 블러가 강해집니다. 반경이 0이면 외관이 변하지 않습니다.

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 설정은 효과의 보이는 경계를 제어합니다. `false`인 경우 블러가 원래 그려진 경계(테두리 포함)로 잘립니다. `true`인 경우 블러가 해당 경계를 넘어 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 변경하지 않습니다.

아래 비교에서는 전체적으로 동일한 채우기, 테두리 및 도형 크기를 사용합니다. 상단 행은 `grow = false`를, 하단 행은 `grow = true`를 사용합니다.

![블러 반경 5와 15포인트, grow 비활성화 및 활성화된 원본 사각형 비교](shape_blur_comparison.png)

다음 Java 예제는 주황색 사각형에 짙은 파란색 테두리를 적용하고 5포인트 블러를 적용한 뒤, 다시 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)를 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 후, [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--)를 호출하여 블러가 없는 도형을 저장합니다.

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

도형 블러는 채우기와 테두리를 함께 영향을 줍니다. 소프트 엣지 효과는 도형의 가장자리를 흐리게 하는 반면, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 effect format에 직접 블러를 적용합니다.

## **자주 묻는 질문**

**동일한 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.