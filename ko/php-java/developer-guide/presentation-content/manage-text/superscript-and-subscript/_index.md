---
title: PHP를 사용하여 프레젠테이션에서 위첨자와 아래첨자 관리
linktitle: 위첨자와 아래첨자
type: docs
weight: 80
url: /ko/php-java/superscript-and-subscript/
keywords:
- 위첨자
- 아래첨자
- 위첨자 추가
- 아래첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides에서 위첨자와 아래첨자를 마스터하고, 전문적인 텍스트 서식으로 프레젠테이션을 향상시켜 최대 효과를 얻으세요."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX)와 OpenDocument(ODP) 프레젠테이션에 위 첨자와 아래 첨자 텍스트를 통합할 수 있는 기능을 제공합니다. 화학식, 수학 방정식 강조 또는 각주로 내용을 보강해야 할 때, 이러한 특수 서식 옵션을 사용하면 명확성과 정확성을 유지할 수 있습니다. 이 문서에서는 위 첨자와 아래 첨자 스타일을 슬라이드마다 전문적으로 적용하는 방법을 배웁니다.

## **위 첨자 및 아래 첨자 텍스트 관리**
어떤 단락의 일부에서도 위 첨자와 아래 첨자 텍스트를 추가할 수 있습니다. Aspose.Slides 텍스트 프레임에서 위 첨자 또는 아래 첨자 텍스트를 사용하려면 [**setEscapement**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setEscapement) 메서드를 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PortionFormat) 클래스에서 사용해야 합니다.

이 속성은 위 첨자 또는 아래 첨자 텍스트를 반환하거나 설정합니다(값 범위는 -100%(아래 첨자)부터 100%(위 첨자)까지). 예시:

- [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용해 슬라이드 참조를 얻습니다.
- 슬라이드에 [Rectangle](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ShapeType#Rectangle) 유형의 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
- 해당 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)와 연결된 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.
- 기존 Paragraph를 모두 삭제합니다.
- 위 첨자 텍스트를 담을 새 Paragraph 객체를 생성하고 이를 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)의 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 위 첨자를 추가하려면 Escapement 속성을 0~100 사이값으로 설정합니다(0은 위 첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Portion)에 텍스트를 지정하고 해당 Paragraph의 Portion 컬렉션에 추가합니다.
- 아래 첨자 텍스트를 담을 새 Paragraph 객체를 생성하고 이를 ITextFrame의 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 아래 첨자를 추가하려면 Escapement 속성을 0~-100 사이값으로 설정합니다(0은 아래 첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Portion)에 텍스트를 지정하고 해당 Paragraph의 Portion 컬렉션에 추가합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예시는 아래와 같습니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 슬라이드 가져오기
    $slide = $pres->getSlides()->get_Item(0);
    # 텍스트 상자 만들기
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # 위첨자 텍스트용 단락 만들기
    $superPar = new Paragraph();
    # 일반 텍스트가 포함된 포션 만들기
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # 위첨자 텍스트가 포함된 포션 만들기
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # 아래첨자 텍스트용 단락 만들기
    $paragraph2 = new Paragraph();
    # 일반 텍스트가 포함된 포션 만들기
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # 아래첨자 텍스트가 포함된 포션 만들기
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # 텍스트 상자에 단락 추가하기
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**PDF 또는 다른 형식으로 내보낼 때 위 첨자와 아래 첨자가 유지되나요?**

예, Aspose.Slides는 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원 형식으로 내보낼 때 위 첨자와 아래 첨자 서식을 올바르게 보존합니다. 특수 서식은 모든 출력 파일에서 그대로 유지됩니다.

**위 첨자와 아래 첨자를 굵게, 기울임꼴 등 다른 서식과 함께 사용할 수 있나요?**

예, Aspose.Slides는 단일 Portion 텍스트 내에서 다양한 텍스트 스타일을 혼합할 수 있도록 지원합니다. 굵게, 기울임꼴, 밑줄을 적용하면서 동시에 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/) 속성을 설정하여 위 첨자 또는 아래 첨자를 적용할 수 있습니다.

**표, 차트 또는 SmartArt 내부 텍스트에도 위 첨자와 아래 첨자를 적용할 수 있나요?**

예, Aspose.Slides는 표와 차트 요소를 포함한 대부분의 개체 내에서 서식 적용을 지원합니다. SmartArt를 사용할 경우 해당 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/))와 텍스트 컨테이너에 접근한 뒤, [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/) 속성을 동일하게 구성하면 됩니다.