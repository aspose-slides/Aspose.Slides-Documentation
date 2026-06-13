---
title: PHP에서 프레젠테이션 자리표시자 관리
linktitle: 자리표시자 관리
type: docs
weight: 10
url: /ko/php-java/manage-placeholder/
keywords:
- 자리표시자
- 텍스트 자리표시자
- 이미지 자리표시자
- 차트 자리표시자
- 프롬프트 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 자리표시자를 손쉽게 관리하세요: 텍스트 교체, 프롬프트 맞춤 설정 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 자리표시자를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 자리표시자를 찾고 텍스트를 변경하는 방법, 자리표시자 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 그리고 배경으로 사용되는 그림의 투명도를 조정하는 방법을 설명합니다. 또한 기본 자리표시자와 슬라이드의 로컬 도형 간 차이점, 레이아웃 또는 마스터를 통해 자리표시자 변경을 적용하는 방법, 머리글 및 바닥글 자리표시자 관리에 대한 간단한 FAQ도 포함합니다.

## **자리표시자 텍스트 변경**
[Aspose.Slides for PHP via Java](/slides/ko/php-java/)를 사용하면 프레젠테이션의 슬라이드에서 자리표시자를 찾아 수정할 수 있습니다. Aspose.Slides를 통해 자리표시자 내부 텍스트를 변경할 수 있습니다.

**전제 조건**: 자리표시자가 포함된 프레젠테이션이 필요합니다. 이러한 프레젠테이션은 일반 Microsoft PowerPoint 응용 프로그램에서 만들 수 있습니다.

다음은 Aspose.Slides를 사용하여 해당 프레젠테이션의 자리표시자 텍스트를 교체하는 방법입니다.

1. [`Presentation`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 도형들을 반복하여 자리표시자를 찾습니다.
4. 자리표시자 도형을 [`AutoShape`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/AutoShape) 로 타입 캐스팅하고, 해당 [`AutoShape`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/AutoShape)와 연결된 [`TextFrame`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/TextFrame) 을 사용해 텍스트를 변경합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 PHP 코드가 자리표시자 텍스트를 변경하는 예시입니다:

```php
  # Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # 첫 번째 슬라이드에 접근합니다
    $sld = $pres->getSlides()->get_Item(0);
    # 자리표시자를 찾기 위해 도형들을 반복합니다
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # 각 자리표시자의 텍스트를 변경합니다
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자리표시자 프롬프트 텍스트 설정**
표준 및 사전 구축된 레이아웃에는 ***Click to add a title*** 또는 ***Click to add a subtitle*** 과 같은 자리표시자 프롬프트 텍스트가 포함되어 있습니다. Aspose.Slides를 사용하면 원하는 프롬프트 텍스트를 자리표시자 레이아웃에 삽입할 수 있습니다.

다음 PHP 코드가 자리표시자에 프롬프트 텍스트를 설정하는 방법을 보여 줍니다:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 슬라이드를 반복합니다
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint은 "제목을 추가하려면 클릭하세요"를 표시합니다
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // 부제목을 추가합니다
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자리표시자 이미지 투명도 설정**

Aspose.Slides를 사용하면 텍스트 자리표시자 배경 이미지의 투명도를 설정할 수 있습니다. 해당 프레임 내 그림의 투명도를 조정하면 텍스트 또는 이미지가 더 돋보이게 할 수 있습니다(텍스트와 그림의 색상에 따라 달라집니다).

다음 PHP 코드가 그림 배경(도형 내부)의 투명도를 설정하는 방법을 보여 줍니다:

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**기본 자리표시자란 무엇이며 슬라이드의 로컬 도형과는 어떻게 다릅니까?**

기본 자리표시자는 레이아웃이나 마스터에 존재하는 원본 도형으로, 슬라이드의 도형이 타입, 위치 및 일부 서식 등을 상속받습니다. 로컬 도형은 독립적이며, 기본 자리표시자가 없을 경우 상속이 적용되지 않습니다.

**프레젠테이션 전체의 모든 제목이나 캡션을 각 슬라이드를 반복하지 않고 업데이트하려면 어떻게 해야 하나요?**

레이아웃 또는 마스터의 해당 자리표시자를 편집하면 됩니다. 해당 레이아웃/마스터를 기반으로 하는 슬라이드들은 자동으로 변경 사항을 상속받습니다.

**표준 머리글/바닥글 자리표시자(날짜 및 시간, 슬라이드 번호, 바닥글 텍스트)를 어떻게 제어합니까?**

적절한 범위(일반 슬라이드, 레이아웃, 마스터, 노트/핸드아웃)에서 HeaderFooter 관리자를 사용하여 해당 자리표시자를 켜거나 끌 수 있으며, 내용을 설정할 수 있습니다.