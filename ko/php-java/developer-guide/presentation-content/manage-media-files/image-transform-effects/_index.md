---
title: PHP를 사용한 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/php-java/image-transform-effects/
keywords:
- 이미지 변환
- 사진 효과
- 밝기
- 대비
- 그레이스케일
- 듀오톤
- 색조
- HSL
- 색상 교체
- 흐림
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 사진 프레임의 이미지 변환 효과를 적용하고, 체인화하며, 검사하고, 제거하고, 검증합니다."
---
## **개요**

Aspose.Slides는 사진 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 사진 프레임의 경우 프레임의 [Picture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picture/)부터 시작하고 [Picture::getImageTransform](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picture/getimagetransform/)에 접근합니다. 반환된 [ImageTransformOperationCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/)를 사용하면 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 지울 수 있습니다.

이 문서에서는 밝기와 대비, 색상 변환, 흐림, 투명도, 순서가 지정된 효과 체인, 유효값, 제거 및 PPTX 라운드 트립 검증 전체 워크플로우를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 사진은 서로 다른 객체입니다.

- [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [Picture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picture/)은 사진 채우기에 속하며 이미지 리소스를 참조하면서 이미지 변환 컬렉션을 저장합니다.
- [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)은 해당 사진 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 셰이프입니다.

따라서 이미지 변환 작업은 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)의 바이트를 수정하지 않습니다. 동일한 `PPImage`를 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addpictureframe/)에 여러 번 전달하면 각 새 사진 프레임은 자체 `Picture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임은 그레이스케일이 적용되지 않으며, 모두 동일한 임베디드 이미지 리소스를 재사용합니다.

같은 `Picture::getImageTransform` 모델은 셰이프나 슬라이드 배경과 같은 다른 사진 채우기에서도 사용됩니다. 아래 예시는 사진 프레임에 초점을 맞춥니다.

## **유효 파라미터 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미 범위와 단위를 사용합니다. 특정 라이브러리 버전이 바로 범위 외 값을 거부하지 않더라도 이 범위 내 값을 유지하십시오. 대상 프레젠테이션 형식이 저장 시 또는 PowerPoint가 파일을 열 때 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100`부터 `100`까지, 퍼센트; `0`은 해당 구성 요소를 변경하지 않음. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | 숫자 파라미터 없음. 알파 값은 변경되지 않음. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀에 대한 두 색상. `java.awt.Color`의 RGB 및 알파 채널은 `0`부터 `255`까지 사용. |
| [addTintEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 색조는 0 (포함)부터 360 (미포함)까지 도 단위; 양은 `-100`부터 `100`까지, 퍼센트. |
| [addHSLEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 색조는 0 (포함)부터 360 (미포함)까지 도 단위; 채도와 밝기는 `-100`부터 `100`까지, 퍼센트. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | 교체 색상은 `0`부터 `255`까지 채널 값을 사용. 기존 알파 값은 변경되지 않음. |
| [addBlurEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위; `grow`는 흐릿한 내용이 원본 경계를 넘어 확장될 수 있는지 제어하는 Boolean 값. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 음수가 아닌 퍼센트. 일반적인 불투명도 스케일링은 `0`부터 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파를 유지. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`부터 `100`까지, 퍼센트 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`부터 `100`까지, 퍼센트 알파 임계값. 임계값 이하이면 투명, 이상이면 불투명. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계에 있습니다. 예를 들어 35% 투명도는 알파 변조 값 65%에 해당합니다.

## **밝기와 대비 적용**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/)는 [Luminance](https://reference.aspose.com/slides/ko/php-java/aspose.slides/luminance/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [Luminance::getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/luminance/geteffective/)은 읽기 전용 계산값을 반환하며, 이를 검사하거나 로그에 기록할 수 있습니다.

다음 예시는 밝기를 15%, 대비를 20% 증가시킨 뒤 임베디드 이미지를 수정하지 않고 미리보기를 렌더링합니다.

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

`Luminance`는 표준 DrawingML 밝기 및 대비 효과입니다. PPTX 라운드 트립 후에도 이러한 설정을 편집 가능하도록 유지하려면 저장된 프레젠테이션을 다시 열어 작업 유형과 유효값을 확인하십시오.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 사진 프레임에 독립적으로 적용할 수 있습니다. 다음 예시는 다섯 개의 프레임을 만들고 그레이스케일, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[Duotone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/duotone/)은 `color1`이 어두운 픽셀을, `color2`가 밝은 픽셀을 매핑하는 두 개의 독립적인 색상 파라미터를 가집니다. 이는 단일 스칼라 값보다 설정이 복잡한 효과의 유용한 예시입니다.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/)는 알파를 유지하면서 모든 픽셀의 색을 고정 색상으로 교체합니다. 이는 하나의 소스 색상을 다른 색상에 매핑하고 소스 및 대상 색상 형식을 모두 노출하는 [addColorChangeEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)와 다릅니다.

## **흐림, 투명도 및 알파 효과 추가**

[addBlurEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/)는 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐릿한 가장자리가 원본 사진 경계를 넘어설 수 있는 경우 `grow`를 `true`로 설정하십시오.

균일한 투명도를 위해서는 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)를 사용합니다. 이 효과는 기존 알파 값을 모두 곱하므로 부분 투명 픽셀은 비례적으로 차이를 유지합니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/)는 모든 픽셀에 동일한 알파 값을 할당하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/)는 임계값에 따라 알파를 두 단계로 변환합니다.

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

파라미터가 없는 다른 알파 작업으로는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)가 있으며, 이는 0이 아닌 모든 알파를 완전 불투명하게 만들고, [addAlphaFloorEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)는 100% 이하 모든 알파를 완전 투명하게 만들며, [addAlphaInverseEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)는 알파를 `100% - alpha`로 바꿉니다.

## **순서가 지정된 효과 체인 구축**

각 `add...Effect` 메서드는 새 작업을 컬렉션 끝에 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이렇게 계속됩니다. 따라서 같은 작업이라도 순서가 다르면 다른 이미지를 생성할 수 있습니다.

예를 들어, 그레이스케일 뒤에 색조를 적용하면 색조 정보가 먼저 제거된 후 색조가 다시 적용됩니다. 색조 뒤에 그레이스케일을 적용하면 색조가 다시 사라집니다. 마찬가지로 알파 교체는 앞선 작업에서 계산된 알파값을 덮어쓸 수 있지만, 알파 변조는 상대적인 차이를 유지합니다.

다음 예시는 네 개 작업으로 구성된 체인을 만들고 PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고 다시 연 결과를 렌더링합니다.

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

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들은 결합될 수 있지만 조합이 언제나 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 그레이스케일을 적용하면 두 선택 색상이 사라지며, 알파 천장·바닥·교체·이중 레벨 작업은 앞서 만든 알파 디테일을 없앨 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구성하고, 항목을 무순서 서식 플래그처럼 취급하지 마십시오.

## **편집 가능 및 유효값 검사**

편집 가능한 작업은 `Picture::getImageTransform`에 저장된 객체입니다. 효과에 따라 직접 쓸 수 있는 멤버를 노출할 수 있습니다. 예를 들어, [Blur](https://reference.aspose.com/slides/ko/php-java/aspose.slides/blur/)는 `radius`와 `grow` 값을 쓸 수 있게 하고, [AlphaModulateFixed](https://reference.aspose.com/slides/ko/php-java/aspose.slides/alphamodulatefixed/)는 `amount`를, [AlphaBiLevel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/alphabilevel/)는 `threshold`를 쓸 수 있게 합니다. [Duotone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/duotone/)과 같은 색상 효과는 변경 가능한 [ColorFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colorformat/) 객체를 노출합니다.

[Luminance](https://reference.aspose.com/slides/ko/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tint/) 및 [AlphaReplace](https://reference.aspose.com/slides/ko/php-java/aspose.slides/alphareplace/)와 같은 일부 작업은 생성 스칼라를 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 필요한 위치에 교체 작업을 추가하십시오.

`getEffective()`가 반환하는 유효 데이터는 계산된 읽기 전용 값입니다. 테마 의존 색상을 해결하고 렌더러가 사용하는 정규화 값을 읽는 데 유용하지만 다른 편집 표면은 아닙니다. 다음 예시는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다.

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

그레이스케일, 알파 천장, 알파 역전과 같은 파라미터가 없는 효과도 유효 데이터 객체를 가지지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 전체 지우기**

[ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/removeat/)를 사용하면 인덱스로 하나의 작업을 제거할 수 있습니다. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾아 열거한 뒤 제거하십시오. [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagetransformoperationcollection/clear/)를 사용하면 전체 체인을 제거합니다.

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

변환을 제거하거나 지우면 사진 서식만 변경됩니다. 재사용되는 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 리소스가 삭제, 재압축 또는 다른 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 유래하므로 PPTX가 효과 체인에 가장 적합한 편집 가능한 형식입니다. PPTX라 하더라도 모든 작업이 동일한 이식성을 보장하지는 않습니다.

- DrawingML 표준 작업(밝기, 그레이스케일, 듀오톤, 색조, HSL, 흐림 및 일반 알파 작업)은 PPTX 라운드 트립에서 살아남을 가능성이 가장 높습니다. 보존이 필요하면 항상 생성된 파일을 다시 열어 컬렉션을 확인하십시오.
- 바이너리 PPT 형식은 전체 DrawingML 효과 모델보다 먼저 등장했습니다. PPT로 저장하면 지원되지 않는 작업이 생략되거나 체인이 지원되는 하위 집합으로 축소되거나 근사화될 수 있습니다. 복잡한 편집 가능한 체인의 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력 형식은 지원되는 체인을 렌더링된 모습에 적용합니다. 이러한 출력에는 편집 가능한 `ImageTransformOperationCollection`이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서·벡터 형식은 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 사진을 렌더링하려면 프레젠테이션이 로드될 때 해당 리소스가 사용 가능해야 합니다.

여러 알파 또는 색상 양자화 작업이 결합될 경우 가장자리 사례가 다르게 렌더링될 수 있습니다. 중요한 출력물은 편집 가능한 라운드 트립과 최종 내보내기 형식을 모두 동일한 Aspose.Slides 버전으로 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베디드 이미지 데이터를 수정합니까?**

아니오. 작업은 사진 채우기에 사용되는 `Picture`에 속하며, 기본 `PPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 사진 프레임이 효과를 공유합니까?**

아니오. `PPImage`를 재사용하면 이미지 데이터 중복을 피하지만 각 사진 프레임은 일반적으로 별도의 `Picture`와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인으로 이를 허용합니다. 교체 및 임계값 작업은 이전 색상 또는 알파 디테일을 삭제할 수 있으므로 각 작업이 이전 작업 결과에 어떤 영향을 미치는지 고려하십시오.

**유효값이 읽기 전용인 이유는 무엇입니까?**

유효 데이터는 렌더링에 사용되는 계산값(해결된 색상 포함)을 나타냅니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하고, 그렇지 않으면 해당 작업을 제거하고 새 생성 파라미터로 교체하십시오.

**어떤 형식이 변환 체인을 보존하기에 적합합니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링 내보내기 형식은 편집 가능한 변환 작업이 아니라 외관만 보존합니다.