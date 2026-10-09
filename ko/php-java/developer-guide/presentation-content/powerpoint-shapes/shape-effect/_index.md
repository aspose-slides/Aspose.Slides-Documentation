---
title: PHP를 사용하여 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/php-java/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 광채 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용한 고급 도형 효과로 PPT 및 PPTX 파일을 변환하여 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/php-java/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 사실적인 반사 효과를 만들거나, 도형의 광채를 퍼뜨리는 등 다양한 효과를 적용할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. Preset 옵션은 보기 좋은 두 개 이상의 효과 조합으로 구성됩니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 멋진 조합을 찾는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for PHP via Java는 도형에 대한 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 프레젠테이션 디자인에 맞게 사용자 지정할 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대해 돋보이게 할 수 있습니다. 그림자는 도형의 가장자리를 넘어 확장되어 도형이 슬라이드 위로 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

다음 PHP 코드는 직사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect)를 적용하는 방법을 보여줍니다:

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

템플릿의 시각 스타일을 재현할 때 내부 그림자를 사용하면 카드나 패널에 움푹 들어간 외관을 줄 수 있습니다. 외부 그림자는 도형 밖으로 확장되어 도형이 떠 있는 것처럼 보이게 하는 반면, 내부 그림자는 가장자리 안쪽을 그림자로 처리합니다.

먼저 [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)를 호출한 다음, [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect)로 반환된 그림자를 구성합니다. 흐림 반경 값이 클수록 가장자리가 부드러워집니다.

다음 PHP 예제는 연한 파란색 카드에 어두운 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다. 그림자 방향은 225도, 거리 7포인트, 흐림 반경 6포인트입니다:

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

내부 그림자를 제거하려면 도형의 EffectFormat에서 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)를 호출합니다.

## **반사 효과 적용**

Aspose.Slides for PHP via Java에서 반사 효과를 적용하면 도형에 거울과 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정할 수 있습니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미학을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용해 일관된 디자인을 만들 수 있습니다.

다음 PHP 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect)를 적용하는 방법을 보여줍니다:

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

## **광채 효과 적용**

Aspose.Slides for PHP via Java에서 광채 효과를 적용하면 도형 주변에 부드럽고 빛나는 오라를 추가하고 색상 및 크기와 같은 속성을 조정할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드만으로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 PHP 코드는 도형에 [광채 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect)를 적용하는 방법을 보여줍니다:

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

![광채 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for PHP via Java에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 섬세하고 정교한 외관을 제공하여 부드러운 외형이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 PHP 코드는 도형에 [부드러운 가장자리 효과](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect)를 적용하는 방법을 보여줍니다:

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

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 광채와 같은 서로 다른 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과가 전체 그룹에 적용됩니다.