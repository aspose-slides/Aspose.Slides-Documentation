---
title: PHP에서 프레젠테이션을 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/php-java/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 손쉽게 병합하고 워크플로우를 간소화합니다."
---
## **개요**

Aspose.Slides를 사용하면 한 프레젠테이션의 슬라이드를 복제하여 다른 프레젠테이션에 병합할 수 있습니다. 이 문서에서는 전체 프레젠테이션이나 선택된 슬라이드를 병합하는 방법, 병합 시 슬라이드 마스터 또는 특정 레이아웃을 사용하는 방법, 슬라이드 크기가 다른 프레젠테이션을 처리하는 방법, 그리고 병합된 슬라이드를 프레젠테이션 섹션에 추가하는 방법을 설명합니다. 또한 병합된 콘텐츠와 관련된 실용적인 주의 사항(예: 발표자 메모, 주석, 암호로 보호된 원본 파일, 스레드 사용)도 다룹니다.

## **프레젠테이션 병합**

한 프레젠테이션을 다른 프레젠테이션에 병합하면, 사실상 두 프레젠테이션의 슬라이드를 하나의 프레젠테이션으로 결합하여 하나의 파일을 얻는 것입니다.

{{% alert title="Info" color="info" %}}

대부분의 프레젠테이션 프로그램(PowerPoint 또는 OpenOffice)에는 사용자가 프레젠테이션을 이러한 방식으로 결합할 수 있는 기능이 없습니다.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/ko/php-java/)는 다양한 방식으로 프레젠테이션을 병합할 수 있도록 해줍니다. 모양, 스타일, 텍스트, 서식, 주석, 애니메이션 등 모든 요소를 손실이나 품질 저하 없이 병합할 수 있습니다.

**또한 보기**

[슬라이드 복제](/slides/ko/php-java/clone-slides/).

{{% /alert %}}

### **무엇을 병합할 수 있나요**

Aspose.Slides를 사용하면 다음을 병합할 수 있습니다.

* 전체 프레젠테이션. 모든 프레젠테이션의 슬라이드가 하나의 프레젠테이션에 포함됩니다
* 특정 슬라이드. 선택한 슬라이드가 하나의 프레젠테이션에 포함됩니다
* 동일 형식의 프레젠테이션(PPT → PPT, PPTX → PPTX 등) 및 서로 다른 형식(PPT → PPTX, PPTX → ODP 등) 간의 병합

{{% alert title="Note" color="warning" %}} 

프레젠테이션 외에도 Aspose.Slides를 사용하면 다른 파일도 병합할 수 있습니다:

* [이미지](https://products.aspose.com/slides/ko/php-java/merger/image-to-image/), 예를 들어 [JPG → JPG](https://products.aspose.com/slides/ko/php-java/merger/jpg-to-jpg/) 또는 [PNG → PNG](https://products.aspose.com/slides/ko/php-java/merger/png-to-png/)
* 문서, 예: [PDF → PDF](https://products.aspose.com/slides/ko/php-java/merger/pdf-to-pdf/) 또는 [HTML → HTML](https://products.aspose.com/slides/ko/php-java/merger/html-to-html/)
* 서로 다른 형식의 파일, 예: [이미지 → PDF](https://products.aspose.com/slides/ko/php-java/merger/image-to-pdf/) 또는 [JPG → PDF](https://products.aspose.com/slides/ko/php-java/merger/jpg-to-pdf/) 또는 [TIFF → PDF](https://products.aspose.com/slides/ko/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **병합 옵션**

다음과 같은 옵션을 적용하여 결정할 수 있습니다.

* 출력 프레젠테이션의 각 슬라이드가 고유한 스타일을 유지합니다
* 출력 프레젠테이션의 모든 슬라이드에 특정 스타일을 적용합니다 

프레젠테이션을 병합하려면 Aspose.Slides가 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 메서드([SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/) 클래스)를 제공합니다. `addClone` 메서드에는 병합 프로세스 매개변수를 정의하는 여러 구현이 있습니다. 모든 Presentation 객체는 [slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getslides/) 컬렉션을 가지고 있으므로, 슬라이드를 병합하려는 프레젠테이션에서 `addClone` 메서드를 호출할 수 있습니다.

`addClone` 메서드는 원본 슬라이드의 복제본인 `Slide` 객체를 반환합니다. 출력 프레젠테이션의 슬라이드는 단순히 원본 슬라이드의 복사본이므로, 소스 프레젠테이션에 영향을 주지 않으면서 결과 슬라이드에 스타일, 서식 옵션 또는 레이아웃 등을 적용할 수 있습니다. 

## **프레젠테이션 병합** 

Aspose.Slides는 슬라이드가 레이아웃과 스타일을 유지하면서 결합할 수 있도록 하는 [addClone(Slide)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 메서드를 제공합니다(기본 매개변수).

이 PHP 코드는 프레젠테이션을 병합하는 방법을 보여줍니다:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **슬라이드 마스터를 사용한 프레젠테이션 병합**

Aspose.Slides는 슬라이드 마스터 프레젠테이션 템플릿을 적용하면서 슬라이드를 결합할 수 있는 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 메서드를 제공합니다. 이를 통해 필요시 출력 프레젠테이션의 슬라이드 스타일을 변경할 수 있습니다.

다음 코드는 설명된 작업을 보여줍니다:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

슬라이드 마스터의 레이아웃은 자동으로 결정됩니다. 적절한 레이아웃을 결정할 수 없을 경우 `addClone` 메서드의 `allowCloneMissingLayout` Boolean 매개변수가 true로 설정되어 있으면 원본 슬라이드의 레이아웃이 사용됩니다. 그렇지 않으면 [PptxEditException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PptxEditException)이 발생합니다.

{{% /alert %}}

출력 프레젠테이션의 슬라이드에 다른 레이아웃을 적용하고 싶다면 병합 시 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 메서드를 대신 사용하십시오.

## **프레젠테이션에서 특정 슬라이드 병합**

여러 프레젠테이션에서 특정 슬라이드만 병합하면 맞춤형 슬라이드 덱을 만들 수 있습니다. Aspose.Slides for PHP via Java는 필요한 슬라이드만 선택하여 가져올 수 있게 해줍니다. API는 원본 슬라이드의 서식, 레이아웃 및 디자인을 그대로 유지합니다.

다음 PHP 코드는 새 프레젠테이션을 생성하고 두 다른 프레젠테이션에서 타이틀 슬라이드를 추가한 뒤 파일로 저장합니다:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **슬라이드 레이아웃을 사용한 프레젠테이션 병합**

이 PHP 코드는 선호하는 슬라이드 레이아웃을 적용하면서 프레젠테이션의 슬라이드를 결합하여 하나의 출력 프레젠테이션을 만드는 방법을 보여줍니다:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

{{% alert title="Note" color="warning" %}} 

다른 슬라이드 크기를 가진 프레젠테이션은 병합할 수 없습니다. 

{{% /alert %}}

다른 슬라이드 크기를 가진 2개의 프레젠테이션을 병합하려면, 크기가 다른 프레젠테이션 중 하나를 크기를 맞추어 다른 프레젠테이션과 동일하게 만들어야 합니다.

이 샘플 코드는 설명된 작업을 보여줍니다:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **프레젠테이션 섹션에 슬라이드 병합**

이 PHP 코드는 특정 슬라이드를 프레젠테이션 섹션에 병합하는 방법을 보여줍니다:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

슬라이드는 섹션의 끝에 추가됩니다. 

## **또한 보기**

Aspose는 [FREE Online Collage Maker](https://products.aspose.app/slides/ko/collage)를 제공합니다. 이 온라인 서비스를 이용하면 [JPG → JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG → PNG 이미지 병합, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid) 만들기 등을 할 수 있습니다.

[Aspose FREE Online Merger](https://products.aspose.app/slides/ko/merger)를 확인해 보세요. 동일한 형식(PPT → PPT, PPTX → PPTX) 또는 서로 다른 형식(PPT → PPTX, PPTX → ODP) 간에 PowerPoint 프레젠테이션을 병합할 수 있습니다.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/ko/merger)

## **FAQ**

**프레젠테이션을 병합할 때 슬라이드 수에 제한이 있나요?**

엄격한 제한은 없습니다. Aspose.Slides는 대용량 파일을 처리할 수 있지만 성능은 파일 크기와 시스템 리소스에 따라 달라집니다. 매우 큰 프레젠테이션의 경우 64비트 JVM을 사용하고 충분한 힙 메모리를 할당하는 것이 권장됩니다.

**임베디드 비디오나 오디오가 포함된 프레젠테이션을 병합할 수 있나요?**

예, Aspose.Slides는 슬라이드에 삽입된 멀티미디어 콘텐츠를 그대로 보존하지만, 최종 프레젠테이션의 파일 크기가 크게 증가할 수 있습니다.

**병합 시 폰트가 유지되나요?**

예. 원본 프레젠테이션에 사용된 폰트는 시스템에 설치되어 있거나 [embedded](/slides/ko/php-java/embedded-font/)된 경우 출력 파일에 그대로 보존됩니다.