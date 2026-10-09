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
- 빛남 효과
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

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/androidjava/shape-formatting/#gradient-fill)나 테두리와는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형의 빛남을 퍼뜨리는 등 다양한 효과를 적용할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 보기 좋습니다. 이러한 이유로 PowerPoint는 **프리셋** 아래에 옵션을 제공하는데, 프리셋 옵션은 보기 좋은 두 가지 이상의 효과 조합을 의미합니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합해 보면서 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있게 합니다.

## **그림자 효과 적용**

Aspose.Slides for Android via Java는 도형에 대한 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널을 슬라이드 배경에 대해 돋보이게 할 수 있습니다. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

다음 Java 코드는 [외부 그림자 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--)를 사각형에 적용하는 방법을 보여줍니다:

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

템플릿의 시각적 스타일을 재현할 때는 내부 그림자를 사용하여 카드나 패널에 움푹 들어간 모습을 부여할 수 있습니다. 외부 그림자는 도형 외부에 그림자를 만들고 도형을 떠 있게 하지만, 내부 그림자는 가장자리 내부를 어둡게 처리합니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)을 호출한 다음, [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--)이 반환하는 그림자를 구성합니다. 흐림 반경 값이 클수록 가장자리가 부드러워집니다.

다음 Java 예제는 밝은 파란색 카드를 어두운 회색 내부 그림자와 함께 만들고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리는 7포인트, 흐림 반경은 6포인트입니다:

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

![내부 그림자가 적용된 밝은 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 효과 형식에 대해 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)을 호출하십시오.

## **반사 효과 적용**

Aspose.Slides for Android via Java에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 고급스러운 모습을 부여하여 프레젠테이션의 미관을 향상시킵니다. 간단한 코드로 손쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

다음 Java 코드는 [반사 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--)를 도형에 적용하는 방법을 보여줍니다:

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

## **빛남 효과 적용**

Aspose.Slides for Android via Java에서 도형에 빛남 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하여 도형 주위에 부드럽고 빛나는 아우라를 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 더합니다. 최소한의 코드로 손쉽게 구현되어 슬라이드 전체의 외관을 향상시킵니다.

다음 Java 코드는 [빛남 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--)를 도형에 적용하는 방법을 보여줍니다:

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

![빛남 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Android via Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주위에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 모습을 제공하여 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션 내 다양한 도형에 원하는 효과를 구현할 수 있습니다.

다음 Java 코드는 [부드러운 가장자리 효과](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--)를 도형에 적용하는 방법을 보여줍니다:

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

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사 및 빛남과 같은 다양한 효과를 하나의 도형에 결합하여 보다 동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에도 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.