---
title: PHP를 사용한 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/php-java/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 그레이스케일
- 듀오톤
- 틴트
- HSL
- 색상 교체
- 블러
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 그림 프레임에 대한 이미지 변환 효과를 적용하고, 체인화하며, 검사하고, 제거하고, 검증합니다."
---
## **개요**

Aspose.Slides는 그림 조정을 이미지 변환 작업의 순서가 있는 컬렉션으로 나타냅니다. 그림 프레임의 경우 프레임의 [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/)을 시작으로 [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/)에 접근합니다. 반환된 [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/)을 사용하면 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 지울 수 있습니다.

이 문서에서는 밝기 및 대비, 색상 변환, 블러, 투명도, 순서가 있는 효과 체인, 유효값, 제거 및 PPTX 라운드트립 검증을 위한 전체 워크플로를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/)은 그림 채우기에 속하며 이미지 리소스를 참조하면서 이미지 변환 컬렉션을 저장합니다.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)은 관련 그림 채우기, 기하, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 형태입니다.

따라서 이미지 변환 작업은 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)의 바이트를 수정하지 않습니다. 동일한 `PPImage`를 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/)에 여러 번 전달하면 각 새 그림 프레임은 자체 `Picture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임이 그레이스케일이 되지는 않으며, 모든 프레임이 동일한 임베드된 이미지 리소스를 재사용한다 하더라도 마찬가지입니다.

같은 `Picture::getImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 그림 채우리에도 사용됩니다. 아래 예제는 그림 프레임에 중점을 두고 있습니다.

## **유효한 매개변수 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미 범위와 단위를 사용합니다. 특정 라이브러리 버전이 범위를 즉시 거부하지 않더라도 이 범위 내에 값을 유지하십시오. 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 잘못된 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| 작업 | 매개변수 | 유효 범위 및 단위 |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100`부터 `100`까지, 퍼센트; `0`은 구성 요소를 변경하지 않습니다. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | 숫자 매개변수가 없습니다. 알파는 변경되지 않습니다. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `java.awt.Color`의 RGB 및 알파 채널은 `0`부터 `255`까지 사용합니다. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 색조는 `0`(포함)부터 `360`(제외)까지, 도 단위; 양은 `-100`부터 `100`까지, 퍼센트. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 색조는 `0`(포함)부터 `360`(제외)까지, 도 단위; 채도와 루미넌스는 `-100`부터 `100`까지, 퍼센트. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | 대체 색상은 채널 값을 `0`부터 `255`까지 사용합니다. 기존 알파 값은 변경되지 않습니다. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위로 측정됩니다; `grow`는 블러된 내용이 원본 경계 밖으로 확장될 수 있는지를 제어하는 부울 값입니다. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 음수가 아닌 퍼센트. 일반적인 불투명도 스케일링을 위해 `0`부터 `100`을 사용합니다: `0`은 완전 투명, `100`은 기존 알파를 유지합니다. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`부터 `100`까지, 퍼센트 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`부터 `100`까지, 퍼센트 알파 임계값. 이보다 낮은 값은 투명해지고, 이 값 이상은 불투명해집니다. |

고정 알파 변조의 경우 투명도와 불투명도는 상보적입니다. 예를 들어 35% 투명도는 알파 변조 값 65%에 해당합니다.

## **밝기 및 대비 적용**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/)은 [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/)은 검사하거나 기록할 수 있는 계산된 읽기 전용 값을 반환합니다.

다음 예제는 밝기를 15% 증가시키고 대비를 20% 증가시킨 후, 임베드된 이미지를 수정하지 않고 미리 보기를 렌더링합니다:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance`는 표준 DrawingML 밝기 및 대비 효과입니다. 이러한 설정을 PPTX 라운드트립 후에도 편집 가능하도록 유지하려면 저장된 프레젠테이션을 다시 열고 작업 유형과 유효값을 모두 확인하십시오.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 그림 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개의 프레임을 만들고 그레이스케일, 듀오톤, 틴트, HSL 조정 및 색상 교체를 적용합니다.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/)은 두 개의 독립적으로 편집 가능한 색상 매개변수를 포함합니다: `color1`은 어두운 픽셀을, `color2`는 밝은 픽셀을 매핑합니다. 이는 단일 스칼라 값보다 설정이 복잡한 효과의 유용한 예시입니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/)는 알파를 유지하면서 모든 픽셀의 색상을 하나의 고정 색상으로 교체합니다. 이는 [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)와 다르며, 후자는 하나의 소스 색상을 다른 색상으로 매핑하고 소스와 대상 색상 형식을 모두 노출합니다.

### **루미넌스 임계값 적용**

루미넌스 임계값은 스캔된 페이지의 희미한 표시를 배경과 구분하기 쉽게 만들 수 있습니다. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/)는 중간 회색 음영을 유지합니다. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/)는 루미넌스를 검정 또는 흰색으로 매핑하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/)는 알파에 임계값을 적용합니다.

루미넌스 임계값은 0%에서 100%까지(포함)이며, 임계값 이하의 픽셀은 검정이 되고, 임계값 이상은 흰색이 됩니다. 임계값을 높이면 더 많은 색조가 검정으로 변환됩니다.

Download [grayscale-swatches.png](grayscale-swatches.png) to the directory containing the PHP script. Each label gives the original gray level on a scale from 0 to 255. The example places the original beside two copies and saves each copy's threshold in the presentation.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Open the output presentation in PowerPoint to compare the three frames. The swatch labeled 96 has about 38% luminance (96 out of 255). It turns white at the 20% threshold and black at the 60% threshold.

![루미넌스 임계값 20%와 60%에서의 흑백 결과와 나란히 있는 원본 그레이스케일 스와치](luminance-threshold.png)

## **블러, 투명도 및 알파 효과 추가**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/)는 알파를 포함한 모든 색상 채널에 영향을 줍니다. 블러된 가장자리가 원본 그림 경계 밖으로 확장될 수 있는 경우 `grow`를 `true`로 설정하십시오.

균일한 투명도를 위해 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)를 사용합니다. 이 효과는 기존 알파 값을 곱하므로 부분적으로 투명한 픽셀은 비례적으로 차이를 유지합니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/)는 모든 픽셀에 하나의 알파 값을 할당합니다. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/)는 임계값에 따라 알파를 두 단계로 변환합니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

다른 매개변수 없이 동작하는 알파 작업에는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)가 포함되며, 이는 0이 아닌 모든 알파를 완전 불투명하게 만들고, [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)는 100% 미만의 모든 알파를 완전 투명하게 만들며, [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)는 알파를 `100% - alpha`로 변경합니다.

## **순서가 있는 효과 체인 구축**

모든 `add...Effect` 메서드는 컬렉션 끝에 새 작업을 추가합니다. 렌더러는 컬렉션을 순서가 있는 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되며, 계속해서 이어집니다. 따라서 동일한 작업이라도 순서를 바꾸면 다른 이미지가 생성될 수 있습니다.

예를 들어, 그레이스케일 뒤에 틴트를 적용하면 색상 정보를 먼저 제거한 다음 루미넌스 결과에 색을 입히게 됩니다. 틴트 뒤에 그레이스케일을 적용하면 틴트가 다시 제거됩니다. 마찬가지로 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓸 수 있으며, 알파 변조는 상대적 차이를 유지합니다.

다음 예제는 네 개의 작업 체인을 구축하고 PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고 다시 연 결과를 렌더링합니다:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

컬렉션은 색상, 알파 및 블러 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들은 결합될 수 있지만, 조합이 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 그레이스케일을 적용하면 두 선택된 색상이 사라지며, 알파 천장, 바닥, 교체 또는 바이레벨 작업은 이전에 만든 알파 디테일을 삭제할 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구성하고, 항목을 무순서 서식 플래그처럼 취급하지 마십시오.

<!-- visual-explanation:image-transform-effects:start -->
[![같은 이미지가 그레이스케일 → 틴트 순서와 틴트 → 그레이스케일 순서로 처리됩니다. 최종 두 그레이스케일 이미지의 색조가 다릅니다.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*이 예시 Aspose.Slides for .NET 26.11 렌더링에서 220° 틴트를 25% 적용하면 그레이스케일 이미지가 변경되지 않습니다. 같은 틴트를 그레이스케일 전에 적용하면 색조가 달라집니다.*
<!-- visual-explanation:image-transform-effects:end -->

## **편집 가능한 값 및 유효값 검사**

편집 가능한 작업은 `Picture::getImageTransform`에 저장된 객체입니다. 효과에 따라 쓰기 가능한 멤버가 직접 노출될 수 있습니다. 예를 들어, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/)는 쓰기 가능한 `radius`와 `grow` 값을 노출하고, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/)는 쓰기 가능한 `amount`를, [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/)는 쓰기 가능한 `threshold`를 노출합니다. [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/)과 같은 색상 효과는 변경 가능한 [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) 객체를 노출합니다.

[Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/)와 같은 일부 작업은 생성 스칼라를 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 필요한 위치에 교체 작업을 추가하십시오.

`getEffective()`이 반환하는 유효 데이터는 계산된 읽기 전용 값입니다. 테마에 종속된 색상을 해석하고 렌더러가 사용하는 정규화된 값을 읽는 데 유용하지만, 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

그레이스케일, 알파 천장, 알파 역방향과 같은 매개변수 없이 동작하는 효과에도 유효 데이터 객체가 존재하지만, 출력할 스칼라 설정이 없으므로 출력할 내용이 없습니다. 컬렉션 내 존재 여부와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 초기화**

[ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/)을 사용해 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾은 다음 열거가 끝난 뒤 제거하십시오. [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/)을 사용하면 전체 체인을 제거할 수 있습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

변환을 제거하거나 초기화해도 그림 서식만 변경됩니다. 재사용되는 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 리소스 자체가 삭제, 재압축되거나 다른 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 PPTX가 효과 체인에 가장 적합한 편집 가능한 형식입니다. PPTX라도 모든 작업이 동일한 이식성을 보장하지는 않습니다:

- 루미넌스, 그레이스케일, 듀오톤, 틴트, HSL, 블러 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드트립에서 살아남을 가능성이 가장 높습니다. 보존이 필요할 경우 항상 생성된 파일을 다시 열어 컬렉션을 검사하십시오.
- 이진 PPT 형식은 전체 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 생략되거나 체인이 지원되는 부분 집합으로 축소되거나 외관이 근사화될 수 있습니다. 복잡한 편집 가능한 체인 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력으로 렌더링하면 지원된 체인이 렌더링된 외관에 적용됩니다. 이러한 출력에는 편집 가능한 `ImageTransformOperationCollection`이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서 또는 벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 그림을 렌더링하려면 프레젠테이션이 로드될 때 연결된 리소스가 사용 가능해야 합니다.

다양한 프레젠테이션 뷰어는 특히 여러 알파 또는 색상 양자화 작업이 결합된 경우 가장자리를 다르게 렌더링할 수 있습니다. 중요한 출력에는 프로덕션에서 사용되는 동일한 Aspose.Slides 버전으로 편집 가능한 라운드트립과 최종 내보내기 형식을 모두 테스트하십시오.

## **자주 묻는 질문**

**이미지 변환 효과가 임베드된 이미지 데이터를 수정합니까?**

아니요. 작업은 그림 채우기에 사용되는 `Picture`에 속합니다. 기본 `PPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 개의 그림 프레임이 효과를 공유합니까?**

아니요. `PPImage`를 재사용하면 중복 이미지 데이터를 피하지만 각 그림 프레임은 일반적으로 별도의 `Picture`와 이미지 변환 컬렉션을 가집니다.

**색상, 블러 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 있는 체인에 모두 수용합니다. 각 작업이 이전 작업의 출력에 어떤 영향을 미치는지 고려하십시오. 교체 및 임계값 작업은 이전 색상이나 알파 디테일을 삭제할 수 있습니다.

**왜 유효값이 읽기 전용입니까?**

유효 데이터는 렌더링에 사용되는 계산된 값이며, 해결된 색상을 포함합니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하고, 그렇지 않으면 작업을 제거하고 새로운 생성 매개변수를 사용해 교체 작업을 추가하십시오.

**어떤 형식을 사용해야 변환 체인을 보존할 수 있습니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링된 내보내기 형식은 편집 가능한 변환 작업이 아니라 외관만 보존합니다.