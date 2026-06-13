---
title: PHP에서 프레젠테이션 슬라이드에 접근
linktitle: 슬라이드 접근
type: docs
weight: 20
url: /ko/php-java/access-slide-in-presentation/
keywords:
- 슬라이드 접근
- 슬라이드 인덱스
- 슬라이드 ID
- 슬라이드 위치
- 위치 변경
- 슬라이드 속성
- 슬라이드 번호
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드에 접근하고 관리하는 방법을 배우세요. 코드 예제로 생산성을 향상시킵니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드에 접근하고 관리하는 방법을 설명합니다. 슬라이드 컬렉션에서 제로 기반 인덱스로 슬라이드를 검색하는 방법과 `getSlideById` 메서드를 사용하여 고유 ID로 슬라이드에 접근하는 방법을 보여줍니다.

또한 `setSlideNumber` 메서드를 사용하여 슬라이드 위치를 변경하는 방법과 `setFirstSlideNumber` 메서드로 프레젠테이션의 시작 슬라이드 번호를 정의하는 방법을 배울 수 있습니다. 예제에서는 프레젠테이션을 로드하고, 슬라이드 참조를 얻으며, 슬라이드 순서 또는 번호를 업데이트하고, 수정된 프레젠테이션을 저장하는 과정을 보여줍니다.

## **인덱스로 슬라이드에 접근**

프레젠테이션의 모든 슬라이드는 슬라이드 위치를 기준으로 0부터 숫자로 정렬됩니다. 첫 번째 슬라이드는 인덱스 0을 통해 접근할 수 있고, 두 번째 슬라이드는 인덱스 1을 통해 접근합니다; 등등.

프레젠테이션 파일을 나타내는 Presentation 클래스는 모든 슬라이드를 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/) 컬렉션([Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/) 객체의 컬렉션)으로 노출합니다. 이 PHP 코드는 인덱스를 통해 슬라이드에 접근하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("demo.pptx");
  try {
    # 슬라이드 인덱스를 사용하여 슬라이드에 접근합니다
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **ID로 슬라이드에 접근**

프레젠테이션의 각 슬라이드에는 고유한 ID가 할당됩니다. 해당 ID를 대상으로 하려면 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스에서 제공하는 [getSlideById](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSlideById-long-) 메서드를 사용할 수 있습니다. 이 PHP 코드는 유효한 슬라이드 ID를 제공하고 [getSlideById](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSlideById-long-) 메서드를 통해 해당 슬라이드에 접근하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("demo.pptx");
  try {
    # 슬라이드 ID를 가져옵니다
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # ID를 통해 슬라이드에 접근합니다
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **슬라이드 위치 변경**

Aspose.Slides를 사용하면 슬라이드 위치를 변경할 수 있습니다. 예를 들어, 첫 번째 슬라이드를 두 번째 슬라이드가 되도록 지정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 위치를 변경하려는 슬라이드의 참조를 인덱스로 가져옵니다.
1. [setSlideNumber](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#setSlideNumber) 메서드를 사용하여 슬라이드의 새로운 위치를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

이 PHP 코드는 위치 1에 있는 슬라이드를 위치 2로 이동하는 작업을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("Presentation.pptx");
  try {
    # 위치가 변경될 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 슬라이드의 새로운 위치를 설정합니다
    $sld->setSlideNumber(2);
    # 수정된 프레젠테이션을 저장합니다
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

첫 번째 슬라이드가 두 번째가 되고, 두 번째 슬라이드가 첫 번째가 됩니다. 슬라이드 위치를 변경하면 다른 슬라이드가 자동으로 조정됩니다.

## **슬라이드 번호 설정**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스에서 제공하는 [setFirstSlideNumber](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) 메서드를 사용하면 프레젠테이션의 첫 번째 슬라이드에 새로운 번호를 지정할 수 있습니다. 이 작업은 다른 슬라이드 번호를 재계산하게 합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 번호를 가져옵니다.
1. 슬라이드 번호를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

이 PHP 코드는 첫 번째 슬라이드 번호를 10으로 설정하는 작업을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # 슬라이드 번호를 가져옵니다
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # 슬라이드 번호를 설정합니다
    $pres->setFirstSlideNumber(10);
    # 수정된 프레젠테이션을 저장합니다
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

첫 번째 슬라이드를 건너뛰고 싶다면, 두 번째 슬라이드부터 번호 매기기를 시작하고(첫 번째 슬라이드의 번호는 숨기는) 다음과 같이 할 수 있습니다:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # 첫 번째 프레젠테이션 슬라이드의 번호를 설정합니다
    $presentation->setFirstSlideNumber(0);
    # 모든 슬라이드에 슬라이드 번호를 표시합니다
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # 첫 번째 슬라이드의 슬라이드 번호를 숨깁니다
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # 수정된 프레젠테이션을 저장합니다
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**사용자가 보는 슬라이드 번호가 컬렉션의 제로 기반 인덱스와 일치합니까?**

슬라이드에 표시되는 번호는 임의의 값(예: 10)부터 시작할 수 있으며 인덱스와 일치할 필요가 없습니다; 이 관계는 프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/setfirstslidenumber/) 설정에 의해 제어됩니다.

**숨겨진 슬라이드가 인덱싱에 영향을 줍니까?**

예. 숨겨진 슬라이드는 컬렉션에 남아 있으며 인덱싱에 포함됩니다; “숨김”은 표시 여부를 의미할 뿐 컬렉션 내 위치에는 영향을 주지 않습니다.

**다른 슬라이드를 추가하거나 제거하면 슬라이드 인덱스가 변경됩니까?**

예. 인덱스는 항상 현재 슬라이드 순서를 반영하며 삽입, 삭제, 이동 작업이 발생할 때마다 재계산됩니다.