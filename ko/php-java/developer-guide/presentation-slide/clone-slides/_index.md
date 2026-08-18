---
title: PHP에서 프레젠테이션 슬라이드 복제
linktitle: 슬라이드 복제
type: docs
weight: 35
url: /ko/php-java/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 PowerPoint 슬라이드를 신속하게 복제하십시오. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

클로닝은 무언가를 정확하게 복제하거나 복사하는 과정입니다. Aspose.Slides for PHP via Java를 사용하면任意의 슬라이드를 복제하거나 복사한 후 현재 프레젠테이션이나 다른 열린 프레젠테이션에 삽입할 수 있습니다. 슬라이드 클로닝 과정은 원본 슬라이드를 변경하지 않고도 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 방법에는 여러 가지가 있습니다:

- 프레젠테이션 내에서 끝에 복제.
- 프레젠테이션 내 다른 위치에 복제.
- 다른 프레젠테이션의 끝에 복제.
- 다른 프레젠테이션의 다른 위치에 복제.
- 다른 프레젠테이션의 특정 위치에 복제.

Aspose.Slides for PHP via Java에서는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 ( [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Slide) 객체 컬렉션) 를 통해 위와 같은 슬라이드 복제를 수행할 수 있는 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 및 [insertClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#insertClone) 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 복제**
동일한 프레젠테이션 파일 내에서 기존 슬라이드 끝에 복제한 슬라이드를 사용하려면 아래 단계에 따라 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 슬라이드 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 객체를 가져옵니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 메서드를 호출하고 복제할 슬라이드를 매개변수로 전달합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 원하는 슬라이드를 동일한 프레젠테이션의 슬라이드 컬렉션 끝으로 복제합니다
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 수정된 프레젠테이션을 디스크에 저장합니다
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **프레젠테이션 내 다른 위치에 슬라이드 복제**
동일한 프레젠테이션 파일 내에서 다른 위치에 복제된 슬라이드를 사용하려면 [insertClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#insertClone) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection) 객체를 가져옵니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#insertClone) 메서드를 호출하고 복제할 슬라이드와 새 위치의 인덱스를 매개변수로 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0, 실제 위치 1)에 있는 슬라이드를 인덱스 1(실제 위치 2)으로 복제했습니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 원하는 슬라이드를 동일한 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
    $slds = $pres->getSlides();
    # 원하는 슬라이드를 동일한 프레젠테이션의 지정된 인덱스로 복제합니다
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 수정된 프레젠테이션을 디스크에 저장합니다
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **다른 프레젠테이션 끝에 슬라이드 복제**
한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 삽입하려면 다음을 수행하십시오:

1. 복제할 슬라이드가 포함된 원본 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 인스턴스를 생성합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection) 객체를 가져옵니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션의 끝으로 복제했습니다.

```php
  # 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 대상 PPTX(슬라이드를 복제할 위치)를 위해 Presentation 클래스를 인스턴스화합니다
    $destPres = new Presentation();
    try {
      # 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝으로 복제합니다
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 대상 프레젠테이션을 디스크에 저장합니다
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **다른 프레젠테이션 내 다른 위치에 슬라이드 복제**
한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 특정 위치에 삽입하려면 다음을 수행하십시오:

1. 슬라이드를 복제할 원본 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 클래스를 가져옵니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#insertClone) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(실제 위치 2)으로 복제했습니다.

```php
  # 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 대상 PPTX(슬라이드를 복제할 위치)를 위해 Presentation 클래스를 인스턴스화합니다
    $destPres = new Presentation();
    try {
      # 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝으로 복제합니다
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 대상 프레젠테이션을 디스크에 저장합니다
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **다른 프레젠테이션의 특정 위치에 마스터 슬라이드와 함께 슬라이드 복제**
원본 프레젠테이션에 마스터 슬라이드가 있는 경우, 먼저 원본 프레젠테이션에서 대상 프레젠테이션으로 원하는 마스터 슬라이드를 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용해 마스터 슬라이드가 포함된 슬라이드를 복제합니다. [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 은 대상 프레젠테이션의 마스터 슬라이드를 요구합니다. 마스터와 함께 슬라이드를 복제하려면 아래 단계를 따르세요:

1. 원본 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 대상 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 복제할 슬라이드와 해당 마스터 슬라이드에 접근합니다.
1. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 Masters 컬렉션을 참조하여 [MasterSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/MasterSlideCollection) 클래스를 인스턴스화합니다.
1. [MasterSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/MasterSlideCollection) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 메서드를 호출하고 원본 PPTX의 마스터를 매개변수로 전달합니다.
1. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 클래스를 인스턴스화합니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation/#getSlides) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 복제한 마스터 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 마스터 슬라이드와 함께 슬라이드를 복제하여 대상 프레젠테이션 끝에 삽입했습니다.

```php
  # 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 대상 프레젠테이션(슬라이드를 복제할 위치)을 위해 Presentation 클래스를 인스턴스화합니다
    $destPres = new Presentation();
    try {
      # 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를 마스터 슬라이드와 함께 인스턴스화합니다
      # 마스터 슬라이드
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 원하는 마스터 슬라이드를 소스 프레젠테이션에서 대상 프레젠테이션의 마스터 컬렉션으로 복제합니다
      # 대상 프레젠테이션
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 원하는 마스터 슬라이드를 소스 프레젠테이션에서 대상 프레젠테이션의 마스터 컬렉션으로 복제합니다
      # 대상 프레젠테이션
      $iSlide = $masters->addClone($SourceMaster);
      # 원하는 마스터와 함께 소스 프레젠테이션의 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝으로 복제합니다
      # 대상 프레젠테이션의 슬라이드 컬렉션
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 대상 프레젠테이션을 디스크에 저장합니다
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **지정된 섹션 끝에 슬라이드 복제**
같은 프레젠테이션 파일 내에서 다른 섹션에 복제된 슬라이드를 사용하려면 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection) 클래스가 제공하는 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SlideCollection/#addClone) 메서드를 사용하십시오. Aspose.Slides for PHP via Java를 사용하면 첫 번째 섹션에서 슬라이드를 복제한 뒤 동일 프레젠테이션의 두 번째 섹션에 삽입할 수 있습니다.

다음 코드 스니펫은 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여 줍니다.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 대상 프레젠테이션을 디스크에 저장합니다
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **슬라이드 크기 일치 보장**

슬라이드를 다른 프레젠테이션에 복제할 때 대상 프레젠테이션의 슬라이드 크기가 원본과 동일한지 확인하십시오. 슬라이드 크기가 다르면 Aspose.Slides는 복제된 도형의 크기를 자동으로 조정하지 않으며, 원래 좌표와 치수가 그대로 유지되어 내용이 정렬되지 않거나 슬라이드 경계를 벗어날 수 있습니다.

복제하기 전에 마스터와 슬라이드의 크기를 원본에 맞추려면 다음과 같이 설정하십시오:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

마스터와 슬라이드를 복제하기 전에 이 작업을 수행하십시오.

## **FAQ**

**슬라이드 노트와 검토자 코멘트도 복제되나요?**

예. 노트 페이지와 검토 코멘트가 복제에 포함됩니다. 필요하지 않다면 삽입 후 [제거](/slides/ko/php-java/presentation-notes/)하십시오.

**차트와 데이터 소스는 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)와 연결되어 있었다면 해당 연결이 [OLE 객체](/slides/ko/php-java/manage-ole/) 형태로 보존됩니다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인하십시오.

**복제 위치와 섹션을 제어할 수 있나요?**

예. 복제된 슬라이드를 특정 인덱스에 삽입하고 원하는 [섹션](/slides/ko/php-java/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 섹션을 생성한 뒤 슬라이드를 이동하십시오.