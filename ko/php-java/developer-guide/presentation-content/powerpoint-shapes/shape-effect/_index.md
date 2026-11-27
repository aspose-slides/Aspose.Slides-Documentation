---
title: PHP를 사용하여 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/php-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 소프트 엣지 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 인상적이고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/php-java/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 실감 나는 반사 효과를 만들거나, 도형의 빛남 효과를 퍼뜨리는 등 다양한 연출이 가능합니다.

![Shape effect](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 도형에 하나 이상의 효과를 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. Preset 옵션은 보기 좋은 두 개 이상의 효과 조합으로 미리 정의되어 있습니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for PHP via Java는 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 프레젠테이션 디자인에 맞게 사용자 지정할 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대비되어 돋보이게 할 수 있습니다. 그림자가 도형 가장자리 밖으로 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

This PHP code shows how to apply the [외부 그림자 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) to a rectangle:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Shadow effect](shadow_effect.png)

#### **도형 회전 시 그림자 방향 제어**

기본적으로 외부 그림자는 도형과 함께 회전합니다. 회전이 다른 도형들이 동일한 방향에서 빛을 받는 것처럼 보이게 하려면 `false`와 함께 [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) 를 호출하고, [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) 를 사용하여 그림자 방향을 동일하게 지정하십시오.

예제는 회색 그림자가 오른쪽으로 42포인트 오프셋된(0°) 두 개의 파란색 화살표를 만들고, 슬라이드를 복제한 뒤 두 화살표를 시계 방향으로 90° 회전합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

두 번째 슬라이드에서 왼쪽 화살표는 그림자가 아래로 드리워지고, 오른쪽 화살표는 여전히 오른쪽으로 그림자를 남깁니다. 두 그림자의 설정된 방향은 모두 0°로 유지됩니다.

![90° 회전 전후의 PowerPoint 렌더링. 두 그림자 모두 오른쪽에서 시작합니다. 회전 후, 그림자는 왼쪽 화살표 아래로 이동하고 오른쪽 화살표 오른쪽에 머무릅니다.](arrow-shadow-rotation.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때 내부 그림자를 사용하면 카드나 패널에 들어간 듯한 모습을 줄 수 있습니다. 외부 그림자는 도형 밖으로 확장되어 도형이 떠 있는 듯 보이게 하는 반면, 내부 그림자는 가장자리 안쪽을 음영 처리합니다.

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) 를 호출한 뒤, [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) 로 반환된 그림자를 구성하십시오. 흐림 반경 값이 클수록 가장자리가 부드러워집니다.

이 PHP 예제는 연한 파란색 카드에 어두운 회색 내부 그림자를 만들고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리 7포인트, 흐림 반경은 6포인트입니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![내부 그림자가 있는 연한 파란 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 효과 형식에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) 를 호출하십시오.

### **프리셋 그림자 적용, 변경 및 제거**

프리셋 그림자를 활성화하려면 [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) 를 호출하십시오. [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) 을 사용하여 [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) 을 선택하거나 같은 도형에서 다른 스타일로 전환할 수 있습니다. 그림자를 제거하면서 채우기와 윤곽선을 유지하려면 [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) 를 호출하십시오.

이 PHP 예제는 처음 세 단계마다 사각형을 복제하여 하나의 슬라이드에서 네 단계를 나란히 비교할 수 있게 합니다. 두 그림자는 각각 10포인트씩 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형 위쪽 왼쪽에 배치하고, 45° 방향은 두 번째 그림자를 아래쪽 오른쪽에 배치합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 원본 | 첫 번째 프리셋 | 두 번째 프리셋 | 제거 후 |
| :---: | :---: | :---: | :---: |
| ![그림자 없음](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for PHP via Java에서 반사 효과를 적용하면 도형에 거울처럼 반사되는 모습을 추가할 수 있으며, 거리, 투명도 및 크기와 같은 매개변수를 조정할 수 있습니다. 이 효과는 도형을 보다 세련되고 정교하게 보이게 하여 프레젠테이션의 미관을 향상시킵니다. 간단한 코드로 손쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

This PHP code shows how to apply the [반사 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) to a shape:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![반사 효과](reflection_effect.png)

## **글로우 효과 적용**

Aspose.Slides for PHP via Java에서 글로우 효과를 적용하면 도형 주위에 부드러운 빛나는 오라를 추가할 수 있으며, 색상 및 크기와 같은 속성을 조정할 수 있습니다. 이 효과는 도형을 돋보이게 하며 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 구현이 쉬워 슬라이드 전체의 외관을 향상시킵니다.

This PHP code shows how to apply the [글로우 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) to a shape:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![글로우 효과](glow_effect.png)

## **소프트 엣지 효과 적용**

Aspose.Slides for PHP via Java에서 소프트 엣지 효과를 적용하면 도형 가장자리 주위에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 섬세하고 정교한 외관을 제공하므로 부드러운 모양이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 구현할 수 있습니다.

This PHP code shows how to apply the [소프트 엣지 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) to a shape:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![소프트 엣지 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 흐림을 사용하면 도형의 채우기와 윤곽선을 부드럽게 만들면서도 도형은 편집 가능 상태를 유지합니다. 도형의 효과 형식에서 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) 를 호출하십시오. 반경은 포인트(1/72인치) 단위이며, 값이 클수록 흐림 효과가 강해집니다. 0이면 외관이 변하지 않습니다.

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 설정은 효과의 표시 경계를 제어합니다. `false`이면 흐림이 원래 그려진 경계(윤곽선 포함) 내에 클리핑되고, `true`이면 흐림이 그 경계를 넘어 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 동일한 채우기, 윤곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = false`이며, 하단 행은 `grow = true`입니다.

![5포인트와 15포인트 흐림 반경을 가진 원본 사각형 비교, grow 비활성 및 활성 상태](shape_blur_comparison.png)

This PHP example creates an orange rectangle with a dark blue outline, applies a 5‑point blur, and then updates it to a 15‑point blur by calling [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) again. It saves both blurred states, then calls [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) and saves the shape without blur.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Shape blur affects the fill and outline together. A soft edges effect fades the shape's edges, while shadow blur softens only the shadow. Image transformation effects operate on image content; this example applies blur directly to the shape's effect format without converting the shape to an image.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

네, 그림자, 반사, 글로우 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

네, 그룹화된 도형에도 효과를 적용할 수 있으며, 해당 효과는 전체 그룹에 적용됩니다.