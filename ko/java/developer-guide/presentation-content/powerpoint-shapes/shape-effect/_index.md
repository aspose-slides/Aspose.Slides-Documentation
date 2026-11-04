---
title: 프레젠테이션에서 Java를 사용한 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 발광 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환합니다—몇 초 만에 인상적이고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/java/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 실감 나는 반사 효과를 만들거나 도형의 발광을 확대하는 등 다양한 효과를 적용할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 도형에 하나 이상의 효과를 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이런 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. 프리셋 옵션은 두 개 이상의 효과를 조합한 것으로, 보기 좋은 조합으로 알려져 있습니다. 따라서 프리셋을 선택하면 다양한 효과를 테스트하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 클래스 아래에 속성과 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있습니다.

## **그림자 효과 적용**

Aspose.Slides for Java는 도형에 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 정의하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대해 돋보이게 할 수 있습니다. 그림자가 도형 가장자리 밖으로 확장되어 도형이 슬라이드 위로 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞출 수 있습니다.

이 Java 코드는 사각형에 [outer shadow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--)을 적용하는 방법을 보여 줍니다:

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

템플릿의 시각적 스타일을 재현할 때 내부 그림자를 사용하면 카드나 패널에 움푹 들어간 외관을 부여할 수 있습니다. 외부 그림자는 도형 밖으로 확장되어 도형이 떠 있는 듯 보이게 하고, 내부 그림자는 가장자리 안쪽을 어둡게 처리합니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)을 호출한 다음, [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--)이 반환하는 그림자를 구성합니다. 흐림 반경 값을 크게 할수록 가장자리가 부드러워집니다.

이 Java 예제는 연파랑 색상의 카드를 어두운 회색 내부 그림자와 함께 만들고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리 7포인트, 흐림 반경 6포인트입니다:

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

![내부 그림자가 적용된 연파랑 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)을 호출합니다.

## **반사 효과 적용**

Aspose.Slides for Java에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 품질을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

이 Java 코드는 도형에 [reflection effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--)을 적용하는 방법을 보여 줍니다:

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

Aspose.Slides for Java에서 도형에 발광 효과를 적용하려면 부드럽고 빛나는 오라를 도형 주위에 추가하고 색상 및 크기와 같은 속성을 조정하면 됩니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 전반적인 모습을 향상시킵니다.

이 Java 코드는 도형에 [glow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--)을 적용하는 방법을 보여 줍니다:

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

![발광 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주위에 부드럽고 흐려진 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 모습을 부여하여 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션 내 다양한 도형에 원하는 효과를 얻을 수 있습니다.

이 Java 코드는 도형에 [soft edges effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--)을 적용하는 방법을 보여 줍니다:

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

도형 흐림을 사용하면 도형의 채우기와 윤곽선을 부드럽게 만들면서도 도형을 편집 가능하게 유지합니다. 도형의 EffectFormat에서 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)을 호출합니다. 반경은 포인트(1/72인치) 단위이며, 값이 클수록 흐림이 강해집니다. 반경이 0이면 모양이 변하지 않습니다.

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 설정은 효과의 가시 경계를 제어합니다. `false`이면 흐림이 원래 그린 경계(윤곽선 포함)에 클리핑되고, `true`이면 경계를 넘어 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 전체에 걸쳐 동일한 채우기, 윤곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = false`이며, 하단 행은 `grow = true`입니다.

![원본 사각형과 흐림 반경 5포인트와 15포인트를 적용한 결과, grow 비활성 및 활성 비교](shape_blur_comparison.png)

이 Java 예제는 주황색 사각형에 짙은 파란색 윤곽선을 적용하고 5포인트 흐림을 적용한 뒤, 다시 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)을 호출해 15포인트 흐림으로 업데이트합니다. 두 흐림 상태를 저장한 뒤 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--)을 호출해 흐림이 없는 도형을 저장합니다.

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

도형 흐림은 채우기와 윤곽선을 동시에 영향을 주며, 부드러운 가장자리 효과는 도형 가장자를 흐리게 만들고 그림자 흐림은 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 적용되지만, 이 예제는 도형을 이미지로 변환하지 않고 직접 도형의 EffectFormat에 흐림을 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 발광 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등을 포함한 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.