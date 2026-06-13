---
title: PHP를 사용한 프레젠테이션 글꼴 관리
linktitle: 글꼴 관리
type: docs
weight: 10
url: /ko/php-java/manage-fonts/
keywords:
- 글꼴 관리
- 글꼴 속성
- 단락
- 텍스트 서식
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용한 PHP에서 글꼴을 제어합니다: 맞춤 글꼴을 삽입하고, 교체하며, 로드하여 PPT, PPTX 및 ODP 프레젠테이션을 명확하고, 브랜드에 안전하며, 일관되게 유지합니다."
---
## **글꼴 관련 속성 관리**
{{% alert color="primary" %}} 
프레젠테이션에는 보통 텍스트와 이미지가 모두 포함됩니다. 텍스트는 특정 섹션과 단어를 강조하거나 기업 스타일에 맞추기 위해 다양한 방식으로 서식 지정할 수 있습니다. 텍스트 서식은 사용자가 프레젠테이션 콘텐츠의 모양과 느낌을 다양하게 할 수 있도록 도와줍니다. 이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 슬라이드의 텍스트 단락에 대한 글꼴 속성을 구성하는 방법을 보여줍니다.
{{% /alert %}} 

Aspose.Slides for PHP via Java를 사용하여 단락의 글꼴 속성을 관리하려면:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 슬라이드의 [Placeholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholder/) 모양에 접근하고 이를 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)으로 형변환합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)가 제공하는 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에서 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)를 가져옵니다.
5. 단락을 양쪽 정렬합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)의 텍스트 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)에 접근합니다.
7. [FontData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontdata/)를 사용하여 글꼴을 정의하고 텍스트 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)의 **Font**를 해당하게 설정합니다.
   1. 글꼴을 굵게 설정합니다.
   2. 글꼴을 이탤릭체로 설정합니다.
8. [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 객체가 제공하는 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)을 사용하여 글꼴 색상을 설정합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예는 아래에 제공됩니다. 기본 프레젠테이션을 가져와 슬라이드 중 하나의 글꼴을 형식화합니다. 다음 스크린샷은 입력 파일과 코드 스니펫이 어떻게 변경하는지를 보여줍니다. 코드는 글꼴, 색상 및 글꼴 스타일을 변경합니다.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: 입력 파일의 텍스트**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: 업데이트된 서식이 적용된 동일 텍스트**|

```php
  # PPTX 파일을 나타내는 Presentation 객체 인스턴스화
  $pres = new Presentation("FontProperties.pptx");
  try {
    # 슬라이드 위치를 사용하여 슬라이드에 접근
    $slide = $pres->getSlides()->get_Item(0);
    # 슬라이드에서 첫 번째와 두 번째 자리 표시자에 접근하고 AutoShape로 형변환
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 첫 번째 단락에 접근
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 단락을 양쪽 정렬
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # 첫 번째 구절에 접근
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 새 글꼴 정의
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # 구절에 새 글꼴 할당
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # 글꼴을 굵게 설정
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # 글꼴을 이탤릭체로 설정
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # 글꼴 색상 설정
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # PPTX를 디스크에 저장
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **텍스트 글꼴 속성 설정**
{{% alert color="primary" %}} 
**Managing Font Related Properties**에서 언급했듯이, [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)은 단락 내에서 형식이 유사한 텍스트를 보관하는 데 사용됩니다. 이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 텍스트 상자를 만들고 일부 텍스트를 삽입한 뒤 특정 글꼴 및 글꼴 패밀리 카테고리의 다양한 속성을 정의하는 방법을 보여줍니다.
{{% /alert %}} 

텍스트 상자를 만들고 그 안의 텍스트에 대한 글꼴 속성을 설정하려면:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
3. 슬라이드에 **Rectangle** 유형의 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)를 추가합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)와 연결된 채우기 스타일을 제거합니다.
5. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 접근합니다.
6. [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 텍스트를 추가합니다.
7. [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)와 연결된 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 객체에 접근합니다.
8. [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)에 사용할 글꼴을 정의합니다.
9. [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 객체가 제공하는 관련 속성을 사용하여 굵게, 이탤릭체, 밑줄, 색상 및 높이와 같은 기타 글꼴 속성을 설정합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예는 아래에 제공됩니다.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Aspose.Slides for PHP via Java에 의해 일부 글꼴 속성이 설정된 텍스트**|

```php
  # PPTX 파일을 나타내는 Presentation 객체를 인스턴스화
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드 가져오기
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle 유형의 AutoShape 추가
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShape와 연결된 모든 채우기 스타일 제거
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShape와 연결된 TextFrame에 접근
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # TextFrame와 연결된 Portion에 접근
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Portion에 대한 글꼴 설정
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # 글꼴의 굵게 속성 설정
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # 글꼴의 이탤릭체 속성 설정
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # 글꼴의 밑줄 속성 설정
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # 글꼴 높이 설정
    $port->getPortionFormat()->setFontHeight(25);
    # 글꼴 색상 설정
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 프레젠테이션을 디스크에 저장
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```