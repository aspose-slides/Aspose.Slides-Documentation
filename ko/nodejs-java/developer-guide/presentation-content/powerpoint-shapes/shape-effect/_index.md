---
title: JavaScript를 사용하여 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/nodejs-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 인상적이고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/nodejs-java/shape-formatting/#gradient-fill)나 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 실감나는 반사 효과를 만들거나, 도형의 글로우를 퍼뜨리는 등 다양한 효과를 적용할 수 있습니다.

![Shape effect](shape-effect.png)

PowerPoint에서는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 옵션을 제공합니다. Preset 옵션은 보기 좋은 두 개 이상의 효과 조합을 미리 정의한 것입니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 좋은 조합을 찾는 데 시간을 들일 필요가 없습니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for Node.js via Java는 도형에 대한 바깥 그림자와 안쪽 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 프레젠테이션 디자인에 맞게 사용자 지정할 수 있습니다.

### **바깥 그림자 적용**

바깥 그림자를 사용하면 카드나 패널이 슬라이드 배경에서 돋보이게 할 수 있습니다. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

다음 JavaScript 코드는 [바깥 그림자 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect)를 사각형에 적용하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **안쪽 그림자 적용**

템플릿의 시각적 스타일을 재현할 때는 안쪽 그림자를 사용하여 카드나 패널에 움푹 들어간 모양을 줄 수 있습니다. 바깥 그림자는 도형 외부에 적용되어 도형이 올라온 듯 보이게 하는 반면, 안쪽 그림자는 가장자리 내부를 음영 처리합니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)를 호출한 후, [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect)에서 반환된 그림자를 구성합니다. 블러 반경 값이 클수록 가장자리가 부드러워집니다.

다음 JavaScript 예제는 연한 파란색 카드에 짙은 회색 안쪽 그림자를 적용하고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리 7포인트, 블러 반경은 6포인트입니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![안쪽 그림자가 있는 연파랑 사각형](inner_shadow_effect.png)

안쪽 그림자를 제거하려면 도형의 EffectFormat에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)를 호출합니다.

## **반사 효과 적용**

Aspose.Slides for Node.js via Java에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정할 수 있습니다. 이 효과는 도형을 보다 세련되고 정교하게 보이게 하여 프레젠테이션의 미관을 향상시킵니다. 간단한 코드로 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

다음 JavaScript 코드는 [반사 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect)를 도형에 적용하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![반사 효과](reflection_effect.png)

## **글로우 효과 적용**

Aspose.Slides for Node.js via Java에서 도형에 글로우 효과를 적용하려면 부드럽고 빛나는 오라를 도형 주위에 추가하고 색상 및 크기와 같은 속성을 조정할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 구현이 쉬워 슬라이드 전체의 외관을 향상시킵니다.

다음 JavaScript 코드는 [글로우 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect)를 도형에 적용하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![글로우 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Node.js via Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리에 부드럽고 흐려진 전환을 만들 수 있습니다. 이 효과는 보다 섬세하고 정제된 모습을 제공하며, 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 JavaScript 코드는 [부드러운 가장자리 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect)를 도형에 적용하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![부드러운 가장자리 효과](soft_edges_effect.png)

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.