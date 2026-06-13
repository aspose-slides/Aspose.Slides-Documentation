---
title: PHP를 사용하여 프레젠테이션 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/php-java/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 생성
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하면 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 만들고, 편집하고, 복제할 수 있어 프레젠테이션 자동화를 향상시킵니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 만든 후 그 안에 텍스트를 넣어야 합니다. Aspose.Slides for PHP via Java은 텍스트가 포함된 도형을 추가할 수 있는 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 클래스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 슬라이드에 도형을 추가할 수 있는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스를 제공하기도 합니다. 그러나 `Shape` 클래스를 통해 추가된 모든 도형이 텍스트를 담을 수 있는 것은 아닙니다. 반면 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 클래스로 추가된 도형은 텍스트를 포함할 수 있습니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
따라서 텍스트를 추가하려는 도형을 다룰 때는 해당 도형이 `AutoShape` 클래스를 통해 생성되었는지 확인하는 것이 좋습니다. 그래야만 `AutoShape` 아래 속성인 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)을 사용할 수 있습니다. 이 페이지의 [Update Text](/slides/ko/php-java/manage-textbox/#update-text) 섹션을 참고하세요.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

슬라이드에 텍스트 상자를 만들려면 다음 단계에 따라 진행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.  
3. 슬라이드의 지정 위치에 도형 유형을 [Rectangle](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapetype/#Rectangle) 로 설정한 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 객체를 추가하고, 새로 추가된 `AutoShape` 객체에 대한 참조를 얻습니다.  
4. `AutoShape` 객체에 텍스트를 포함할 `TextFrame`을 추가합니다. 아래 예시에서는 *Aspose TextBox* 라는 텍스트를 추가했습니다.  
5. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.  

위 단계들을 구현한 PHP 코드 예시로 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```php
  # Presentation을 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 유형을 Rectangle로 설정한 AutoShape를 추가합니다
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle에 TextFrame을 추가합니다
    $ashp->addTextFrame(" ");
    # 텍스트 프레임에 접근합니다
    $txtFrame = $ashp->getTextFrame();
    # 텍스트 프레임용 Paragraph 객체를 생성합니다
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph용 Portion 객체를 생성합니다
    $portion = $para->getPortions()->get_Item(0);
    # 텍스트를 설정합니다
    $portion->setText("Aspose TextBox");
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **텍스트 상자 도형 확인하기**

Aspose.Slides는 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 클래스의 [isTextBox](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/istextbox/) 메서드를 제공하여 도형이 텍스트 상자인지 검사할 수 있습니다.

![텍스트 상자와 도형](istextbox.png)

다음 PHP 코드는 도형이 텍스트 상자로 생성되었는지 확인하는 방법을 보여줍니다:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

`ShapeCollection` 클래스의 `addAutoShape` 메서드로 자동 도형을 추가한 경우, 해당 자동 도형의 `isTextBox` 메서드는 `false`를 반환합니다. 그러나 `addTextFrame` 메서드나 `setText` 메서드로 자동 도형에 텍스트를 추가하면 `isTextBox` 속성은 `true`를 반환합니다.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox()는 false를 반환합니다
$shape1->addTextFrame("shape 1");
// shape1->isTextBox()는 true를 반환합니다

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox()는 false를 반환합니다
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox()는 true를 반환합니다

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox()는 false를 반환합니다
$shape3->addTextFrame("");
// shape3->isTextBox()는 false를 반환합니다

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox()는 false를 반환합니다
$shape4->getTextFrame()->setText("");
// shape4->isTextBox()는 false를 반환합니다
```

## **텍스트 상자에 열 추가하기**

Aspose.Slides는 [TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setcolumncount/) 및 [setColumnSpacing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setcolumnspacing/) 메서드를 제공하여 텍스트 상자에 열을 추가할 수 있습니다. 텍스트 상자의 열 수와 열 사이의 간격(포인트)을 지정할 수 있습니다.

다음 코드는 위 작업을 시연합니다:

```php
  $pres = new Presentation();
  try {
    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # 유형을 Rectangle로 설정한 AutoShape를 추가합니다
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle에 TextFrame을 추가합니다
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame의 텍스트 형식을 가져옵니다
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame의 열 개수를 지정합니다
    $format->setColumnCount(3);
    # 열 사이의 간격을 지정합니다
    $format->setColumnSpacing(10);
    # 프레젠테이션을 저장합니다
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **텍스트 프레임에 열 추가하기**
Aspose.Slides for PHP via Java는 [TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setcolumncount/) 메서드를 제공하여 텍스트 프레임에 열을 추가할 수 있습니다. 이 속성을 사용하면 텍스트 프레임에 원하는 열 수를 지정할 수 있습니다.

다음 PHP 코드는 텍스트 프레임 안에 열을 추가하는 방법을 보여줍니다:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **텍스트 업데이트**

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트나 프레젠테이션 전체에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다. 

다음 PHP 코드는 프레젠테이션에 있는 모든 텍스트를 업데이트하거나 변경하는 작업을 시연합니다:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # 형태가 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # 텍스트 프레임의 단락들을 반복합니다
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 단락의 각 Portion을 반복합니다
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// 텍스트를 변경합니다

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 서식을 변경합니다

            }
          }
        }
      }
    }
    # 수정된 프레젠테이션을 저장합니다
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **하이퍼링크가 포함된 텍스트 상자 추가하기** 

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자가 해당 링크를 열도록 안내됩니다. 

하이퍼링크가 포함된 텍스트 상자를 추가하려면 다음 단계를 수행하십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.  
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.  
3. 슬라이드의 지정 위치에 `ShapeType`을 `Rectangle` 로 설정한 `AutoShape` 객체를 추가하고, 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.  
4. `AutoShape` 객체에 *Aspose TextBox* 를 기본 텍스트로 하는 `TextFrame`을 추가합니다.  
5. `HyperlinkManager` 클래스를 인스턴스화합니다.  
6. 원하는 `TextFrame` 부분에 대해 [setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) 메서드를 사용하여 하이퍼링크를 할당합니다.  
7. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다. 

위 단계들을 구현한 PHP 코드는 슬라이드에 하이퍼링크가 포함된 텍스트 상자를 추가하는 방법을 보여줍니다:

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # 유형을 Rectangle로 설정한 AutoShape 객체를 추가합니다
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # 도형을 AutoShape로 캐스팅합니다
    $pptxAutoShape = $shape;
    # AutoShape와 연결된 ITextFrame 속성에 접근합니다
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # 프레임에 텍스트를 추가합니다
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Portion 텍스트의 하이퍼링크를 설정합니다
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX 프레젠테이션을 저장합니다
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**마스터 슬라이드에서 텍스트 상자와 텍스트 자리표시자(플레이스홀더)의 차이점은 무엇인가요?**

[플레이스홀더](/slides/ko/php-java/manage-placeholder/)는 [마스터](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)의 스타일·위치를 상속받으며 [레이아웃](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/)에서 재정의될 수 있지만, 일반 텍스트 상자는 특정 슬라이드에 독립적인 객체이므로 레이아웃을 전환해도 변하지 않습니다.

**차트, 표, SmartArt 내부 텍스트를 건드리지 않으면서 프레젠테이션 전체에서 텍스트를 일괄 교체하려면 어떻게 해야 하나요?**

텍스트 프레임이 있는 자동 도형만을 순회하고, 삽입된 객체([차트](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/), [표](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/))는 별도의 컬렉션을 통해 처리하거나 해당 객체 유형을 건너뛰어 반복을 제한하면 됩니다.