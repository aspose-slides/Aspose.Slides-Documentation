---
title: 프레젠테이션에서 JavaScript를 사용하여 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/nodejs-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 소프트 엣지 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용한 고급 도형 효과로 PPT 및 PPTX 파일을 변환하여 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint에서 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/nodejs-java/shape-formatting/#gradient-fill)이나 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형의 광채를 퍼뜨리는 등 다양한 효과를 줄 수 있습니다.

![그림자 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. Preset 옵션은 두 개 이상 효과를 조합한 것으로 보기 좋은 조합으로 알려져 있습니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for Node.js via Java는 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자는 카드나 패널을 슬라이드 배경에 대비해 돋보이게 합니다. 그림자는 도형 경계를 넘어 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

이 JavaScript 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect)를 적용하는 방법을 보여줍니다:
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

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때는 카드나 패널에 오목한 외관을 주기 위해 내부 그림자를 사용합니다. 외부 그림자는 도형 외부에 확장되어 도형이 떠 있는 것처럼 보이게 하고, 내부 그림자는 가장자리 내부에 그늘을 만들어 줍니다.

먼저 [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)를 호출한 다음, [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect)에서 반환된 그림자를 구성합니다. 더 큰 흐림 반경 값은 부드러운 가장자리를 만듭니다.

이 JavaScript 예제는 연한 파란색 카드를 어두운 회색 내부 그림자와 함께 생성하고 PPTX 파일로 저장합니다. 그림자 방향은 225도이며, 거리는 7포인트, 흐림 반경은 6포인트입니다:
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

![내부 그림자가 있는 연한 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 효과 포맷에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)를 호출하십시오.

### **프리셋 그림자 적용, 변경 및 제거**

[enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect)를 호출하고 [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset)을 사용하여 [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/)을 선택합니다. 스타일을 전환하려면 같은 도형의 프리셋을 변경하십시오. [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect)를 호출하면 채우기와 외곽선을 유지하면서 그림자를 제거합니다.

이 예제는 한 슬라이드에 네 단계가 나란히 표시됩니다. 두 그림자는 각각 10포인트씩 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형의 왼쪽 위에 배치하고, 45° 방향은 두 번째 그림자를 오른쪽 아래에 배치합니다.
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 원본 | 첫 번째 프리셋 | 두 번째 프리셋 | 제거 후 |
| :---: | :---: | :---: | :---: |
| ![그림자 없음](preset_shadow_original.png) | ![좌상단 그림자](preset_shadow_top_left.png) | ![우하단 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Node.js via Java에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 요소를 강화합니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용해 일관된 디자인을 구현할 수 있습니다.

이 JavaScript 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect)를 적용하는 방법을 보여줍니다:
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

Aspose.Slides for Node.js via Java에서 도형에 글로우 효과를 적용하려면 색상과 크기와 같은 속성을 조정하여 부드럽고 빛나는 후광을 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 더합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

이 JavaScript 코드는 도형에 [글로우 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect)를 적용하는 방법을 보여줍니다:
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

## **소프트 엣지 효과 적용**

Aspose.Slides for Node.js via Java에서 소프트 엣지 효과를 적용하면 도형의 가장자리 주위에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 외관을 제공하여 부드럽고 부드러운 모양이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션 내 다양한 도형에 원하는 효과를 얻을 수 있습니다.

이 JavaScript 코드는 도형에 [소프트 엣지 효과](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect)를 적용하는 방법을 보여줍니다:
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

![소프트 엣지 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형을 편집 가능하게 유지하면서 채우기와 외곽선을 부드럽게 할 수 있습니다. 도형의 효과 포맷에서 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)를 호출합니다. 반경은 포인트(1/72인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 블러 강도가 높아집니다. 반경이 0이면 외관이 변경되지 않습니다.

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 설정은 효과의 가시 경계를 제어합니다. `false`인 경우 블러가 외곽선을 포함한 원래 그린 경계로 잘립니다. `true`인 경우 블러가 그 경계를 넘어 확장될 수 있습니다. 어느 설정도 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 전체적으로 동일한 채우기, 외곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = false`를, 하단 행은 `grow = true`를 사용합니다.
![블러 반경 5와 15포인트, grow 비활성 및 활성 상태의 원본 사각형 비교](shape_blur_comparison.png)

이 JavaScript 예제는 주황색 사각형에 진한 파란색 외곽선을 추가하고, 5포인트 블러를 적용한 뒤 다시 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)를 호출해 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 후 [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect)를 호출해 블러 없이 도형을 저장합니다.
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

도형 블러는 채우기와 외곽선을 동시에 영향을 줍니다. 소프트 엣지 효과는 도형의 가장자리를 흐리게 하는 반면, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변형 효과는 이미지 내용에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 효과 포맷에 직접 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 여러 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.