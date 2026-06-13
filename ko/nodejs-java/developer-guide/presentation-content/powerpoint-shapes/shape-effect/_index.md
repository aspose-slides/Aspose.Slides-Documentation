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
- 소프트 에지 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/nodejs-java/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 사실적인 반사 효과를 만들거나, 도형의 빛남을 퍼뜨리는 등 다양한 효과를 만들 수 있습니다.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다. 

* 일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **Preset** 옵션이 있습니다. 프리셋 옵션은 본질적으로 두 개 이상의 효과가 잘 어울리는 조합을 미리 정의한 것입니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있는 [EffectFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/EffectFormat) 클래스의 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

다음 JavaScript 코드는 외부 그림자 효과([getOuterShadowEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect))를 사각형에 적용하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **반사 효과 적용**

다음 JavaScript 코드는 반사 효과를 도형에 적용하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **글로우 효과 적용**

다음 JavaScript 코드는 글로우 효과를 도형에 적용하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **소프트 에지 효과 적용**

다음 JavaScript 코드는 소프트 에지를 도형에 적용하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모양을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 이미지, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 그룹 전체에 적용됩니다.