---
title: PHP를 사용한 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/php-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 빛나는 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 강렬하고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint에서 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/php-java/shape-formatting/#gradient-fill)나 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 현실적인 반사 효과를 만들거나, 도형의 빛나는 효과를 퍼뜨리는 등 다양한 작업을 수행할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

효과 조합에 따라 결과가 달라집니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. Preset 옵션은 두 개 이상의 효과를 조합한 것으로, 보기 좋은 조합으로 알려져 있습니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for PHP via Java는 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 사용자 프레젠테이션 디자인에 맞게 사용자 지정할 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에서 돋보이게 할 수 있습니다. 그림자는 도형 가장자리 밖으로 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

이 PHP 코드는 직사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect)를 적용하는 방법을 보여줍니다:
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

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때, 카드나 패널에 움푹 들어간 외관을 주기 위해 내부 그림자를 사용합니다. 외부 그림자는 도형 밖으로 확장되어 떠 있는 듯한 효과를 주는 반면, 내부 그림자는 가장자리 안쪽을 음영 처리하여 움푹 들어간 모습을 만듭니다.

먼저 [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)를 호출한 다음, [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect)에서 반환되는 그림자를 구성합니다. 블러 반경 값이 클수록 가장자리가 부드러워집니다.

이 PHP 예제는 연한 파란색 카드에 짙은 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다. 그림자 방향은 225도이며, 거리는 7포인트, 블러 반경은 6포인트입니다:
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

![내부 그림자가 있는 연한 파란색 직사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 효과 형식에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)를 호출하십시오.

## **반사 효과 적용**

Aspose.Slides for PHP via Java에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정할 수 있습니다. 이 효과는 도형에 더욱 세련되고 고급스러운 외관을 부여하여 프레젠테이션의 미적 감각을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용해 일관된 디자인을 구현할 수 있습니다.

이 PHP 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect)를 적용하는 방법을 보여줍니다:
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

## **빛나는 효과 적용**

Aspose.Slides for PHP via Java에서 도형에 빛나는 효과를 적용하려면 도형 주위에 부드럽고 빛나는 후광을 추가하고 색상 및 크기와 같은 속성을 조정할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

이 PHP 코드는 도형에 [빛나는 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect)를 적용하는 방법을 보여줍니다:
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

![빛나는 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for PHP via Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 은은하고 정교한 외관을 제공하며, 부드럽고 부드러운 모습을 필요로 하는 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 구현할 수 있습니다.

이 PHP 코드는 도형에 [부드러운 가장자리 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect)를 적용하는 방법을 보여줍니다:
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

![부드러운 가장자리 효과](soft_edges_effect.png)

## **블러 효과 적용**

형태 블러를 사용하면 도형을 편집 가능하게 유지하면서 도형의 채우기와 윤곽선을 부드럽게 만들 수 있습니다. 도형의 효과 형식에 대해 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)를 호출하십시오. 반경은 포인트(1/72인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 강한 블러가 적용됩니다. 반경이 0이면 외관이 변하지 않습니다.

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 설정은 효과의 가시적 경계를 제어합니다. `false`일 경우 블러가 원래 그려진 경계(윤곽선 포함) 내에 제한되고, `true`일 경우 블러가 그 경계를 넘어 확장될 수 있습니다. 어느 설정도 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 동일한 채우기, 윤곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = false`; 하단 행은 `grow = true`를 사용합니다.

![원본 직사각형과 블러 반경 5포인트와 15포인트 비교 (grow 비활성 및 활성)](shape_blur_comparison.png)

이 PHP 예제는 주황색 직사각형에 짙은 파란색 윤곽선을 적용하고, 5포인트 블러를 적용한 뒤 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)를 다시 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 다음 [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect)를 호출하여 블러 없이 도형을 저장합니다.
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

도형 블러는 채우기와 윤곽선을 함께 영향을 줍니다. 부드러운 가장자리 효과는 도형의 가장자를 흐리게 하고, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 내용에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 효과 형식에 직접 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

네, 그림자, 반사, 빛나는 효과와 같이 서로 다른 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에도 효과를 적용할 수 있나요?**

네, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.