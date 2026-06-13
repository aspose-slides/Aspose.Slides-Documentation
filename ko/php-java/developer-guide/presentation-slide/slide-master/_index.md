---
title: PHP에서 프레젠테이션 슬라이드 마스터 관리
linktitle: 슬라이드 마스터
type: docs
weight: 70
url: /ko/php-java/slide-master/
keywords:
- 슬라이드 마스터
- 마스터 슬라이드
- PPT 마스터 슬라이드
- 다중 마스터 슬라이드
- 마스터 슬라이드 비교
- 배경
- 자리 표시자
- 마스터 슬라이드 복제
- 마스터 슬라이드 복사
- 마스터 슬라이드 복제본 생성
- 사용되지 않는 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 슬라이드 마스터를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션에서 마스터 슬라이드를 접근, 편집, 복제, 비교 및 제거합니다."
---
## **개요**

**슬라이드 마스터**는 그룹 슬라이드에 대한 공유 디자인 설정을 정의합니다. 여기에는 공통 도형, 로고, 배경, 텍스트 스타일, 테마 설정 및 바닥글 설정이 포함될 수 있습니다. PowerPoint에서는 슬라이드 마스터를 편집하는 것이 같은 서식을 모든 슬라이드에 반복하지 않고 프레젠테이션을 일관되게 유지하는 일반적인 방법입니다.

Aspose.Slides for PHP via Java도 동일한 모델을 지원합니다. 프레젠테이션에는 하나 이상의 마스터 슬라이드가 포함될 수 있으며, 각 마스터 슬라이드에는 여러 레이아웃 슬라이드가 포함될 수 있습니다. 일반 슬라이드는 보통 마스터 슬라이드를 직접 참조하지 않습니다. 대신 일반 슬라이드는 레이아웃 슬라이드를 사용하고, 해당 레이아웃 슬라이드는 마스터 슬라이드에 귀속됩니다.

계층 구조는 다음과 같습니다:

1. **슬라이드 마스터** – 공유 디자인 및 테마를 정의합니다.  
1. **레이아웃 슬라이드** – 자리 표시자와 레이아웃 수준 서식의 특정 배치를 정의합니다.  
1. **일반 슬라이드** – 실제 프레젠테이션 내용을 포함하고 하나의 레이아웃 슬라이드를 사용합니다.

![마스터 슬라이드, 레이아웃 슬라이드 및 일반 슬라이드의 계층 구조](slide-master_2.jpg)

Aspose.Slides에서 슬라이드 마스터는 [MasterSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/) 클래스로 표현됩니다. 프레젠테이션의 모든 마스터 슬라이드는 [Presentation.getMasters](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getMasters) 메서드를 통해 접근할 수 있으며, 이 메서드는 [MasterSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslidecollection/) 객체를 반환합니다.

{{% alert color="info" title="Inheritance" %}}
같은 속성이 두 개 이상의 수준에서 정의된 경우, 보다 구체적인 수준이 우선합니다. 예를 들어 마스터 슬라이드와 레이아웃 슬라이드 모두 배경을 정의한 경우, 해당 레이아웃을 기반으로 하는 슬라이드는 레이아웃 배경을 사용합니다. 레이아웃 슬라이드에 대한 자세한 내용은 [Apply or Change Slide Layouts](/slides/ko/php-java/slide-layout/)를 참고하십시오.
{{% /alert %}}

## **슬라이드 마스터 액세스**

PowerPoint에서는 **보기** > **슬라이드 마스터**에서 슬라이드 마스터 보기를 열 수 있습니다.

![PowerPoint 보기 탭의 슬라이드 마스터 명령](slide-master_3.jpg)

Aspose.Slides에서는 `getMasters` 메서드를 사용하여 마스터 슬라이드에 접근합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

또한 일반 슬라이드의 레이아웃을 통해 해당 슬라이드가 사용 중인 마스터 슬라이드를 얻을 수 있습니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **슬라이드 마스터에 포함되는 내용**

마스터 슬라이드는 슬라이드와 유사한 객체입니다. [BaseSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/)을 상속하므로 일반 슬라이드와 레이아웃 슬라이드에서 사용되는 많은 슬라이드 속성을 그대로 노출합니다. 마스터 전용 멤버는 [MasterSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/) API 페이지에 나와 있습니다.

주요 마스터 슬라이드 멤버는 다음과 같습니다:

| 멤버 | 목적 |
| --- | --- |
| `getBackground` | 마스터 수준 슬라이드 배경을 설정합니다. |
| `getShapes` | 로고, 사진 프레임, 공유 텍스트 등 마스터에 배치된 도형을 저장합니다. |
| `getLayoutSlides` | 마스터에 속한 레이아웃 슬라이드를 저장합니다. |
| `getThemeManager` | 마스터 테마 API에 대한 접근을 제공합니다. |
| `getHeaderFooterManager` | 마스터와 해당 레이아웃에 대한 머리글, 바닥글, 날짜 및 슬라이드 번호를 제어합니다. |
| `getDependingSlides` | 레이아웃을 통해 마스터에 의존하는 일반 슬라이드를 반환합니다. |

## **슬라이드 마스터에 이미지 추가**

마스터 슬라이드에 이미지를 추가하면 해당 마스터의 레이아웃을 사용하는 모든 슬라이드에 표시됩니다. 이는 로고, 워터마크, 장식 밴드 등 반복되는 시각 요소에 유용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 로고를 추가합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

그림 프레임에 대한 자세한 내용은 [Picture Frame](/slides/ko/php-java/picture-frame/)를 참고하십시오.

## **자리 표시자 작업**

자리 표시자는 일반적으로 레이아웃 슬라이드에 정의됩니다. 마스터 슬라이드는 이러한 레이아웃이 상속받는 공유 스타일 및 테마를 제공하고, 각 레이아웃은 어떤 자리 표시자를 사용할지와 위치를 결정합니다.

PowerPoint에서는 슬라이드 마스터 보기에서 자리 표시자 명령을 사용할 수 있습니다.

![PowerPoint 슬라이드 마스터 보기의 자리 표시자 삽입 명령](slide-master_5.png)

Aspose.Slides에서 새로운 자리 표시자를 추가하려면 마스터에 속한 레이아웃 슬라이드를 작업합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이미 마스터 슬라이드에 존재하는 자리 표시자 도형을 서식 지정할 수도 있습니다. 다음 예제는 제목 자리 표시자를 찾아 선형 그라디언트 채우기를 적용합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![일반 슬라이드에서 상속된 서식이 적용된 제목 자리 표시자](slide-master_8.png)

자리 표시자 및 텍스트 서식 옵션에 대해서는 [Set Prompt Text in Placeholder](/slides/ko/php-java/manage-placeholder/)와 [Text Formatting](/slides/ko/php-java/text-formatting/)를 참고하십시오.

## **슬라이드 마스터 배경 변경**

마스터 배경은 레이아웃 및 해당 배경을 재정의하지 않은 슬라이드에 상속됩니다. 다음 예제는 첫 번째 마스터 슬라이드에 단색 배경 색을 설정합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

관련 항목은 [Presentation Background](/slides/ko/php-java/presentation-background/)와 [Presentation Theme](/slides/ko/php-java/presentation-theme/)를 참조하십시오.

## **슬라이드 마스터를 다른 프레젠테이션에 복제**

[MasterSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslidecollection/)의 `addClone`을 사용하면 마스터 슬라이드를 다른 프레젠테이션으로 복사할 수 있습니다. 복제된 마스터는 대상 프레젠테이션의 레이아웃 및 슬라이드에서 사용할 수 있습니다.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

마스터와 함께 일반 슬라이드를 복제해야 하는 경우는 [Clone Slides](/slides/ko/php-java/clone-slides/)를 참고하십시오.

## **여러 슬라이드 마스터 추가**

프레젠테이션에는 여러 마스터 슬라이드를 포함시킬 수 있습니다. 이는 섹션마다 다른 브랜딩, 페이지 구조 또는 테마 설정이 필요할 때 유용합니다.

![마스터 슬라이드 삽입 및 관리 PowerPoint 명령](slide-master_9.jpg)

다음 예제는 기본 마스터를 복제하고, 복제본에 다른 배경을 지정한 뒤, 해당 복제 마스터 아래에 레이아웃을 만들고, 그 레이아웃을 기반으로 새 슬라이드를 추가합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **슬라이드 마스터 비교**

마스터 슬라이드는 [BaseSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/)에서 상속받은 `equals` 메서드를 사용해 비교할 수 있습니다. 비교는 구조와 정적 콘텐츠(도형, 텍스트, 서식, 애니메이션 등)를 체크하며, 슬라이드 ID와 같은 고유 식별자나 현재 날짜와 같은 동적 자리 표시자 값은 비교 대상이 아닙니다.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

자세한 내용은 [Compare Presentation Slides](/slides/ko/php-java/compare-slides/)를 참고하십시오.

## **슬라이드 마스터 보기를 기본 보기로 설정**

[ViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/)의 `setLastView` 메서드를 사용하면 PowerPoint가 처음 열릴 때의 보기를 제어할 수 있습니다. 다음 예제는 프레젠테이션을 슬라이드 마스터 보기로 엽니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

다른 보기 설정에 대해서는 [Save Presentation](/slides/ko/php-java/save-presentation/)를 참고하십시오.

## **사용되지 않는 마스터 슬라이드 제거**

프레젠테이션에 사용되지 않는 마스터 슬라이드가 있을 경우 파일 크기가 커지고 템플릿 관리가 복잡해질 수 있습니다. `removeUnused`를 사용하여 `getMasters` 컬렉션에서 사용되지 않는 마스터를 제거합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

또는 [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 클래스의 저코드 `removeUnusedMasterSlides` 메서드를 사용할 수 있습니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**슬라이드 마스터와 레이아웃 슬라이드의 차이점은 무엇인가요?**

슬라이드 마스터는 테마, 배경, 공통 도형 및 텍스트 스타일과 같은 공유 디자인 설정을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 자리 표시자의 특정 배치를 정의합니다. 일반 슬라이드는 레이아웃 슬라이드를 사용하므로 레이아웃과 마스터 양쪽으로부터 상속받습니다.

**하나의 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있나요?**

네. 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있습니다. 섹션마다 다른 시각 시스템이나 브랜딩이 필요할 때 여러 마스터를 사용하십시오.

**자리 표시자는 마스터 슬라이드에 추가해야 하나요, 레이아웃 슬라이드에 추가해야 하나요?**

대부분의 경우 레이아웃 슬라이드에 자리 표시자를 추가합니다. 공유 시각 요소와 공통 서식은 마스터 슬라이드에 배치하고, 실제 콘텐츠 자리 표시자는 일반 슬라이드가 사용할 레이아웃에 배치하십시오.

**사용 중인 마스터 슬라이드를 삭제할 수 있나요?**

아니요. 종속 슬라이드가 있는 마스터 슬라이드는 바로 삭제할 수 없습니다. 먼저 해당 슬라이드를 다른 마스터의 레이아웃으로 이동하거나 사용되지 않는 마스터만 제거하는 정리 방법을 사용하십시오.