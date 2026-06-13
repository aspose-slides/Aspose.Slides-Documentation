---
title: PHP에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/php-java/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리 표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 바닥글 표시 여부
- 제목 슬라이드
- 제목 및 콘텐츠
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 수직 텍스트
- 수직 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 Aspose.Slides for PHP에서 슬라이드 레이아웃을 관리하고 사용자 지정합니다. 레이아웃 유형, 자리 표시자 제어 및 바닥글 표시 여부를 코드 예제로 살펴보세요."
---
## **Introduction**

슬라이드 레이아웃은 슬라이드의 콘텐츠에 대한 자리 표시자 상자의 배치와 형식을 정의합니다. 이는 사용 가능한 자리 표시자와 그 위치를 제어합니다. 슬라이드 레이아웃은 간단하거나 복잡한 프레젠테이션을 빠르고 일관되게 디자인하는 데 도움이 됩니다. PowerPoint에서 가장 일반적인 슬라이드 레이아웃은 다음과 같습니다:

**Title Slide layout** – 두 개의 텍스트 자리 표시자를 포함합니다: 하나는 제목용, 다른 하나는 부제목용입니다.

**Title and Content layout** – 상단에 작은 제목 자리 표시자가 있고, 그 아래에 본문 콘텐츠(텍스트, 글머리표, 차트, 이미지 등)를 위한 큰 자리 표시자가 있습니다.

**Blank layout** – 자리 표시자가 전혀 없으며, 처음부터 슬라이드를 자유롭게 디자인할 수 있습니다.

슬라이드 레이아웃은 슬라이드 마스터의 일부이며, 슬라이드 마스터는 프레젠테이션 전체의 레이아웃 스타일을 정의하는 최상위 슬라이드입니다. 레이아웃 슬라이드는 유형, 이름 또는 고유 ID로 슬라이드 마스터를 통해 액세스하고 수정할 수 있습니다. 또는 프레젠테이션 내에서 특정 레이아웃 슬라이드를 직접 편집할 수도 있습니다.

Aspose.Slides for PHP에서 슬라이드 레이아웃을 사용하려면 다음을 사용할 수 있습니다:
- [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스 아래의 [getLayoutSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getLayoutSlides) 및 [getMasters](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getMasters)와 같은 메서드
- [LayoutSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutplaceholdermanager/), [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslideheaderfootermanager/)와 같은 타입

{{% alert title="Info" color="info" %}}
마스터 슬라이드 작업에 대해 더 알아보려면 [Slide Master](/slides/ko/php-java/slide-master/) 문서를 확인하세요.
{{% /alert %}}

## **Add Slide Layouts to Presentations**

슬라이드의 모양과 구조를 맞춤 설정하려면 프레젠테이션에 새 레이아웃 슬라이드를 추가해야 할 수 있습니다. Aspose.Slides for PHP를 사용하면 특정 레이아웃이 이미 존재하는지 확인하고, 필요하면 새 레이아웃을 추가한 뒤 해당 레이아웃을 기반으로 슬라이드를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterlayoutslidecollection/)에 액세스합니다.
1. 컬렉션에 원하는 레이아웃 슬라이드가 이미 존재하는지 확인합니다. 존재하지 않으면 필요한 레이아웃 슬라이드를 추가합니다.
1. 새 레이아웃 슬라이드를 기반으로 빈 슬라이드를 추가합니다.
1. 프레젠테이션을 저장합니다.

다음 PHP 코드는 PowerPoint 프레젠테이션에 슬라이드 레이아웃을 추가하는 방법을 보여줍니다:

```php
// PowerPoint 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("Sample.pptx");
try {
    // 레이아웃 슬라이드 유형을 순회하여 레이아웃 슬라이드를 선택합니다.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // 프레젠테이션에 모든 레이아웃 유형이 포함되지 않은 상황입니다.
        // 이 프레젠테이션 파일에는 Blank 및 Custom 레이아웃 유형만 포함되어 있습니다.
        // 그러나 사용자 정의 유형의 레이아웃 슬라이드에는 인식 가능한 이름이 있을 수 있습니다,
        // 예를 들어 "Title", "Title and Content" 등과 같이 레이아웃 슬라이드 선택에 사용할 수 있는 이름이 있습니다.
        // 자리 표시자 도형 유형 집합에 의존할 수도 있습니다.
        // 예를 들어, Title 슬라이드에는 Title 자리 표시자 유형만 있어야 합니다.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 추가된 레이아웃 슬라이드를 사용하여 빈 슬라이드를 추가합니다.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // 프레젠테이션을 디스크에 저장합니다.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remove Unused Layout Slides**

Aspose.Slides는 [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 클래스의 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 메서드를 제공하여 필요 없고 사용되지 않은 레이아웃 슬라이드를 삭제할 수 있게 합니다.

다음 PHP 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Add Placeholders To Slide Layouts**

Aspose.Slides는 [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/#getPlaceholderManager) 메서드를 제공하며, 이를 통해 레이아웃 슬라이드에 새 자리 표시자를 추가할 수 있습니다.

이 관리자는 다음 자리 표시자 유형에 대한 메서드를 포함합니다:

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutplaceholdermanager/) Method |
| ---------------------- | ------------------------------------------------------------ |
| ![콘텐츠](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![콘텐츠(수직)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![텍스트](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![텍스트(수직)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![그림](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![차트](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![표](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![스마트아트](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![미디어](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![온라인 이미지](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

다음 PHP 코드는 Blank 레이아웃 슬라이드에 새 자리 표시자 모양을 추가하는 방법을 보여줍니다:

```php
$presentation = new Presentation();
try {
    // Blank 레이아웃 슬라이드를 가져옵니다.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // 레이아웃 슬라이드의 자리 표시자 관리자를 가져옵니다.
    $placeholderManager = $layout->getPlaceholderManager();

    // Blank 레이아웃 슬라이드에 다양한 자리 표시자를 추가합니다.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Blank 레이아웃을 사용하여 새 슬라이드를 추가합니다.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

결과:

![레이아웃 슬라이드의 자리 표시자](add_placeholders.png)

## **Set Footer Visibility for a Layout Slide**

PowerPoint 프레젠테이션에서 날짜, 슬라이드 번호, 사용자 지정 텍스트와 같은 바닥글 요소는 슬라이드 레이아웃에 따라 표시하거나 숨길 수 있습니다. Aspose.Slides for PHP를 사용하면 이러한 바닥글 자리 표시자의 표시 여부를 제어할 수 있습니다. 이는 특정 레이아웃에서는 바닥글 정보를 표시하고, 다른 레이아웃은 깔끔하게 유지하려는 경우에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 레이아웃 슬라이드 참조를 가져옵니다.
1. 슬라이드 바닥글 자리 표시자를 표시하도록 설정합니다.
1. 슬라이드 번호 자리 표시자를 표시하도록 설정합니다.
1. 날짜/시간 자리 표시자를 표시하도록 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 PHP 코드는 슬라이드 바닥글의 표시 여부를 설정하고 관련 작업을 수행하는 방법을 보여줍니다:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Set Child Footer Visibility for a Slide**

PowerPoint 프레젠테이션에서 날짜, 슬라이드 번호, 사용자 지정 텍스트와 같은 바닥글 요소는 마스터 슬라이드 수준에서 제어하여 모든 레이아웃 슬라이드에 일관성을 제공합니다. Aspose.Slides for PHP는 마스터 슬라이드에서 이러한 바닥글 자리 표시자의 표시 여부와 내용을 설정하고, 해당 설정을 모든 자식 레이아웃 슬라이드에 전파할 수 있게 합니다. 이 접근 방식은 프레젠테이션 전반에 걸쳐 동일한 바닥글 정보를 유지하도록 보장합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 마스터 슬라이드에 대한 참조를 가져옵니다.
1. 마스터와 모든 자식 바닥글 자리 표시자를 표시하도록 설정합니다.
1. 마스터와 모든 자식 슬라이드 번호 자리 표시자를 표시하도록 설정합니다.
1. 마스터와 모든 자식 날짜/시간 자리 표시자를 표시하도록 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 PHP 코드는 이 작업을 수행하는 예시입니다:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇인가요?**

마스터 슬라이드는 전체 테마와 기본 서식을 정의하고, 레이아웃 슬라이드는 다양한 콘텐츠 유형에 대한 특정 자리 표시자 배치를 정의합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있나요?**

예, [getLayoutSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getLayoutSlides) 메서드로 접근 가능한 한 프레젠테이션의 레이아웃 슬라이드 컬렉션에서 레이아웃 슬라이드를 복제하고 `addClone` 메서드를 사용해 다른 프레젠테이션에 삽입할 수 있습니다.

**슬라이드에서 아직 사용 중인 레이아웃 슬라이드를 삭제하면 어떻게 되나요?**

프레젠테이션에 최소 하나의 슬라이드가 해당 레이아웃을 참조하고 있는 상태에서 레이아웃 슬라이드를 삭제하려 하면 Aspose.Slides가 [PptxEditException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxeditexception/)을 발생시킵니다. 이를 방지하려면 사용되지 않은 레이아웃 슬라이드만 안전하게 제거하는 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)를 사용하십시오.