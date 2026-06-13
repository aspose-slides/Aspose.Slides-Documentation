---
title: PHP에서 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/php-java/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 만들기
- 빈 슬라이드
- 파워포인트
- 오픈 도큐먼트
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 슬라이드를 손쉽게 추가합니다 — 몇 초 만에 원활하고 효율적인 슬라이드 삽입이 가능합니다."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에 슬라이드를 추가할 수 있습니다. 프레젠테이션에는 마스터/레이아웃 슬라이드와 일반 슬라이드가 포함되며, 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 각 슬라이드에는 고유 ID가 있으며, 슬라이드가 없는 프레젠테이션 파일은 지원되지 않습니다.

이 문서에서는 `Presentation` 개체를 생성하고, 슬라이드 컬렉션에 접근하며, 빈 슬라이드를 추가하고, 새로 추가된 슬라이드를 사용한 뒤 업데이트된 프레젠테이션을 저장하는 방법을 설명합니다. 또한 특정 위치에 슬라이드를 삽입하고, 레이아웃을 사용하며, 새로 만든 프레젠테이션에 존재하는 빈 슬라이드에 대한 이해와 같은 관련 사항도 다룹니다.

## **프레젠테이션에 슬라이드 추가**

프레젠테이션 파일에 슬라이드를 추가하는 방법을 논하기 전에 슬라이드에 대한 몇 가지 사실을 살펴보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 **마스터/레이아웃** 슬라이드와 기타 **일반** 슬라이드가 포함됩니다. 이는 프레젠테이션 파일에 하나 이상의 슬라이드가 반드시 포함된다는 의미입니다. 슬라이드가 없는 프레젠테이션 파일은 Aspose.Slides for PHP via Java에서 지원되지 않는다는 점을 알아두는 것이 중요합니다. 각 슬라이드에는 고유한 Id가 있으며, 모든 일반 슬라이드는 0부터 시작하는 인덱스로 지정된 순서대로 정렬됩니다.

Aspose.Slides for PHP via Java를 사용하면 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있습니다. 프레젠테이션에 빈 슬라이드를 추가하려면 아래 단계에 따라 진행하십시오:

- 다음 링크의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스로 생성합니다.
- 다음 링크의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 객체가 제공하는 [getSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation#getSlides--) 메서드(내용 슬라이드 객체 컬렉션)를 사용하여 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/) 객체를 가져옵니다.
- 다음 링크의 [SlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/) 객체가 제공하는 [**addEmptySlide**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/#addEmptySlide) 메서드를 호출하여 내용 슬라이드 컬렉션의 끝에 빈 슬라이드를 프레젠테이션에 추가합니다.
- 새로 추가된 빈 슬라이드로 작업을 수행합니다.
- 마지막으로, [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 객체를 사용하여 프레젠테이션 파일을 저장합니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # SlideCollection 클래스를 인스턴스화합니다
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Slides 컬렉션에 빈 슬라이드를 추가합니다
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 새로 추가된 슬라이드에 대해 작업을 수행합니다
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**특정 위치에 새 슬라이드를 삽입할 수 있나요, 끝에만 추가되는 것이 아닌가요?**

예. 라이브러리는 슬라이드 컬렉션 및 [insert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/insertclone/) 작업을 지원하므로, 끝에만 추가하는 것이 아니라 필요한 인덱스에 슬라이드를 추가할 수 있습니다.

**레이아웃을 기반으로 슬라이드를 추가할 때 테마/스타일이 유지되나요?**

예. 레이아웃은 마스터로부터 서식을 상속받으며, 새 슬라이드는 선택된 레이아웃 및 해당 마스터로부터 서식을 상속받습니다.

**슬라이드를 추가하기 전, 새 "빈" 프레젠테이션에 어떤 슬라이드가 존재하나요?**

새로 생성된 프레젠테이션에는 인덱스 0을 가진 빈 슬라이드가 하나 이미 포함되어 있습니다. 삽입 인덱스를 계산할 때 이를 고려하는 것이 중요합니다.

**마스터에 다양한 옵션이 있을 때 새 슬라이드에 적합한 레이아웃을 어떻게 선택하나요?**

일반적으로 필요한 구조와 일치하는 [LayoutSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/)을 선택합니다([Title and Content, Two Content 등](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidelayouttype/)). 해당 레이아웃이 없을 경우, [add it to the master](/slides/ko/php-java/slide-layout/) 를 통해 마스터에 추가한 후 사용할 수 있습니다.