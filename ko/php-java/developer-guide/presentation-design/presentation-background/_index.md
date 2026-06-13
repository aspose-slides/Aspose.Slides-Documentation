---
title: PHP에서 프레젠테이션 배경 관리
linktitle: 슬라이드 배경
type: docs
weight: 20
url: /ko/php-java/presentation-background/
keywords:
- 프레젠테이션 배경
- 슬라이드 배경
- 단색
- 그라디언트 색상
- 이미지 배경
- 배경 투명도
- 배경 속성
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 파일에서 동적 배경을 설정하는 방법을 배우고, 프레젠테이션을 향상시키는 코드 팁을 제공합니다.
---
## **소개**

단색, 그라디언트 및 이미지는 일반적으로 슬라이드 배경에 사용됩니다. **일반 슬라이드**(단일 슬라이드) 또는 **마스터 슬라이드**(한 번에 여러 슬라이드에 적용) 배경을 설정할 수 있습니다.

![PowerPoint background](powerpoint-background.png)

## **일반 슬라이드에 단색 배경 설정**

Aspose.Slides를 사용하면 프레젠테이션의 특정 슬라이드에 단색을 배경으로 설정할 수 있습니다—프레젠테이션이 마스터 슬라이드를 사용하더라도. 변경 내용은 선택된 슬라이드에만 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/backgroundtype/)을 `OwnBackground` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)을 `Solid` 로 설정합니다.
4. 단색 배경 색상을 지정하려면 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)에서 [getSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/#getSolidFillColor) 메서드를 사용합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 PHP 예제는 일반 슬라이드의 배경을 파란색 단색으로 설정하는 방법을 보여줍니다:

```php
// Presentation 클래스의 인스턴스를 생성합니다.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 슬라이드의 배경 색상을 파란색으로 설정합니다.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // 프레젠테이션을 디스크에 저장합니다.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **마스터 슬라이드에 단색 배경 설정**

Aspose.Slides를 사용하면 프레젠테이션의 마스터 슬라이드에 단색을 배경으로 설정할 수 있습니다. 마스터 슬라이드는 모든 슬라이드의 형식을 제어하는 템플릿 역할을 하므로, 마스터 슬라이드 배경에 단색을 선택하면 모든 슬라이드에 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. `getMasters`를 통해 마스터 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/backgroundtype/)을 `OwnBackground` 로 설정합니다.
3. 마스터 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)을 `Solid` 로 설정합니다.
4. 단색 배경 색상을 지정하려면 [getSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/#getSolidFillColor) 메서드를 사용합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 PHP 예제는 마스터 슬라이드의 배경을 녹색 단색으로 설정하는 방법을 보여줍니다:

```php
// Presentation 클래스의 인스턴스를 생성합니다.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // 마스터 슬라이드의 배경 색상을 포레스트 그린으로 설정합니다.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // 프레젠테이션을 디스크에 저장합니다.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **슬라이드에 그라디언트 배경 설정**

그라디언트는 색상이 점진적으로 변하면서 만들어지는 그래픽 효과입니다. 슬라이드 배경으로 사용하면 프레젠테이션이 더 예술적이고 전문적으로 보일 수 있습니다. Aspose.Slides를 사용하면 슬라이드의 배경을 그라디언트 색상으로 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/backgroundtype/)을 `OwnBackground` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)을 `Gradient` 로 설정합니다.
4. 원하는 그라디언트 설정을 구성하려면 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)에서 [getGradientFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/#getGradientFormat) 메서드를 사용합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 PHP 예제는 슬라이드의 배경을 그라디언트 색상으로 설정하는 방법을 보여줍니다:

```php
// Presentation 클래스의 인스턴스를 생성합니다.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 배경에 그라디언트 효과를 적용합니다.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // 프레젠테이션을 디스크에 저장합니다.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **슬라이드 배경으로 이미지 설정**

단색 및 그라디언트 채우기에 추가로 Aspose.Slides를 사용하면 이미지를 슬라이드 배경으로 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/backgroundtype/)을 `OwnBackground` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)을 `Picture` 로 설정합니다.
4. 슬라이드 배경으로 사용할 이미지를 로드합니다.
5. 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
6. 이미지를 배경으로 지정하려면 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)에서 [getPictureFillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/#getPictureFillFormat) 메서드를 사용합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 PHP 예제는 슬라이드 배경을 이미지로 설정하는 방법을 보여줍니다:

```php
// Presentation 클래스의 인스턴스를 생성합니다.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 배경 이미지 속성을 설정합니다.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // 이미지를 로드합니다.
    $image = Images::fromFile("Tulips.jpg");
    // 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // 프레젠테이션을 디스크에 저장합니다.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

다음 코드 샘플은 배경 채우기 유형을 타일링된 그림으로 설정하고 타일링 속성을 수정하는 방법을 보여줍니다:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // 배경 채우기에 사용되는 이미지를 설정합니다.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // 그림 채우기 모드를 Tile(타일)로 설정하고 타일 속성을 조정합니다.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
자세히 보기: [**타일 이미지 텍스처**](/slides/ko/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **배경 이미지 투명도 변경**

슬라이드 배경 이미지의 투명도를 조정하여 슬라이드 내용이 돋보이게 할 수 있습니다. 다음 PHP 코드는 슬라이드 배경 이미지의 투명도를 변경하는 방법을 보여줍니다:

```php
$transparencyValue = 30; // 예시로.

    // 그림 변환 작업 컬렉션을 가져옵니다.
    $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

    // 기존의 고정 비율 투명도 효과를 찾습니다.
    $transparencyOperation = null;
    foreach($imageTransform as $operation) {
        if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
            $transparencyOperation = $operation;
            break;
        }
    }

    // 새 투명도 값을 설정합니다.
    if (java_is_null($transparencyOperation)) {
        $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
    } else {
        $transparencyOperation->setAmount(100 - $transparencyValue);
    }
```

## **슬라이드 배경 값 가져오기**

Aspose.Slides는 슬라이드의 실제 배경 값을 검색하기 위해 `BackgroundEffectiveData` 클래스를 제공합니다. 이 클래스는 실제 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/) 및 [EffectFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effectformat/)을 노출합니다.

[BaseSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/) 클래스의 `getBackground` 메서드를 사용하면 슬라이드의 실제 배경을 얻을 수 있습니다.

다음 PHP 예제는 슬라이드의 실제 배경 값을 가져오는 방법을 보여줍니다:

```php
// Presentation 클래스의 인스턴스를 생성합니다.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 마스터, 레이아웃 및 테마를 고려하여 실제 배경을 검색합니다.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**사용자 지정 배경을 재설정하고 테마/레이아웃 배경을 복원할 수 있나요?**

예. 슬라이드의 사용자 지정 채우기를 제거하면 배경이 해당 [layout](/slides/ko/php-java/slide-layout/)/[master](/slides/ko/php-java/slide-master/) 슬라이드에서 다시 상속됩니다(즉, [theme background](/slides/ko/php-java/presentation-theme/)).

**프레젠테이션의 테마를 나중에 변경하면 배경은 어떻게 되나요?**

슬라이드에 자체 채우기가 있으면 변경되지 않은 상태로 유지됩니다. 배경이 [layout](/slides/ko/php-java/slide-layout/)/[master](/slides/ko/php-java/slide-master/)에서 상속된 경우, 새 테마에 맞게 업데이트됩니다.