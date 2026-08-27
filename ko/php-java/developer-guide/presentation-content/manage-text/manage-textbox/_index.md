---
title: "PHP를 사용하여 프레젠테이션에서 텍스트 상자 관리"
linktitle: "텍스트 상자 관리"
type: docs
weight: 20
url: /ko/php-java/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 만들기
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP는 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 생성, 편집 및 복제할 수 있게 하여 프레젠테이션 자동화를 향상시킵니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 추가하고 그 안에 텍스트를 넣어야 합니다. Aspose.Slides for PHP via Java는 텍스트를 포함하는 도형을 추가할 수 있는 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 클래스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 슬라이드에 도형을 추가할 수 있는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스도 제공합니다. 그러나 `Shape` 클래스를 통해 추가된 모든 도형이 텍스트를 담을 수 있는 것은 아닙니다. 하지만 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 클래스를 통해 추가된 도형은 텍스트를 포함할 수 있습니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
따라서 텍스트를 추가하고자 하는 도형을 다룰 때, 해당 도형이 `AutoShape` 클래스로 캐스팅 되었는지 확인하고 확인하고 싶을 수 있습니다. 그래야만 `AutoShape` 아래의 속성인 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)을 사용할 수 있습니다. 이 페이지의 [Update Text](/slides/ko/php-java/manage-textbox/#update-text) 섹션을 참조하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

슬라이드에 텍스트 상자를 만들려면 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.
3. 슬라이드의 지정된 위치에 shape type을 [Rectangle](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapetype/#Rectangle) 로 설정한 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 객체를 추가하고 새로 추가된 `AutoShape` 객체에 대한 참조를 얻습니다.
4. 텍스트를 포함할 `AutoShape` 객체에 `TextFrame`을 추가합니다. 아래 예제에서는 다음 텍스트를 추가했습니다: *Aspose TextBox*
5. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다. 

다음 PHP 코드는 위 단계들을 구현한 것으로, 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```php
  # Presentation을 인스턴스화합니다
  # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
  # 형식을 Rectangle로 설정한 AutoShape을 추가합니다
  # Rectangle에 TextFrame을 추가합니다
  # 텍스트 프레임에 접근합니다
  # 텍스트 프레임을 위한 Paragraph 객체를 생성합니다
  # Paragraph를 위한 Portion 객체를 생성합니다
  # 텍스트를 설정합니다
  # 프레젠테이션을 디스크에 저장합니다
  $pres = new Presentation();
  try {
    # Gets the first slide in the presentation
    $sld = $pres->getSlides()->get_Item(0);
    # Adds an AutoShape with type set as Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Adds TextFrame to the Rectangle
    $ashp->addTextFrame(" ");
    # Accesses the text frame
    $txtFrame = $ashp->getTextFrame();
    # Creates the Paragraph object for text frame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Creates a Portion object for paragraph
    $portion = $para->getPortions()->get_Item(0);
    # Sets Text
    $portion->setText("Aspose TextBox");
    # Saves the presentation to disk
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **텍스트 상자 도형 확인**

Aspose.Slides는 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 클래스의 [isTextBox](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/istextbox/) 메서드를 제공하여 도형을 검사하고 텍스트 상자를 식별할 수 있게 합니다.

![Text box and shape](istextbox.png)

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

`addAutoShape` 메서드를 사용하여 [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 클래스에서 단순히 자동 도형을 추가하면, 해당 자동 도형의 `isTextBox` 메서드는 `false`를 반환합니다. 그러나 `addTextFrame` 메서드나 `setText` 메서드를 사용해 자동 도형에 텍스트를 추가하면 `isTextBox` 속성은 `true`를 반환합니다.

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

## **텍스트 프레임을 소유하는 도형 찾기**

일반적인 텍스트 처리 코드에서는 해당 텍스트 프레임이 어느 프레젠테이션 객체에 포함되어 있는지 모른 채 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)을 받을 수 있습니다. [TextFrame::getParentShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentShape) 메서드를 사용하여 소유하고 있는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)으로 되돌아갈 수 있습니다.

[AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 또는 다른 텍스트가 포함된 도형에 속한 텍스트 프레임의 경우, [TextFrame::getParentShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentShape) 은 소유자를 반환하고 [TextFrame::getParentCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentCell) 은 `null`을 반환합니다. 두 메서드는 읽기 전용 탐색을 제공하므로 호출해도 소유권이 변경되지 않습니다. 도형에 접근하기 전에 항상 `java_is_null` 로 반환 값을 확인하십시오.

SmartArt 노드와 연결된 도형을 포함해 도형 및 테이블 셀 소유자를 식별하는 전체 예제는 [Search and Replace Text](/slides/ko/php-java/search-and-replace-text/)를 참고하십시오.

## **텍스트 상자에 열 추가**

Aspose.Slides는 텍스트 상자에 열을 추가할 수 있는 [TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setcolumncount/) 및 [setColumnSpacing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setcolumnspacing/) 메서드를 제공합니다. 텍스트 상자의 열 수를 지정하고 열 사이의 간격을 포인트 단위로 설정할 수 있습니다.

다음 코드는 설명된 작업을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # 형식을 Rectangle로 설정한 AutoShape을 추가합니다
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle에 TextFrame을 추가합니다
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame의 텍스트 형식을 가져옵니다
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame의 열 수를 지정합니다
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

## **텍스트 프레임에 열 추가**

Aspose.Slides for PHP via Java는 텍스트 프레임에 열을 추가할 수 있는 [TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setcolumncount/) 메서드를 제공합니다. 이 속성을 통해 텍스트 프레임에서 원하는 열 수를 지정할 수 있습니다.

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

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트 또는 프레젠테이션에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다.

다음 PHP 코드는 프레젠테이션의 모든 텍스트를 업데이트하거나 변경하는 작업을 보여줍니다:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # shape이 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # 텍스트 프레임의 단락들을 반복합니다
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 단락의 각 portion을 반복합니다
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

## **하이퍼링크가 있는 텍스트 상자 추가** 

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자가 해당 링크를 열도록 이동합니다.

링크가 포함된 텍스트 상자를 추가하려면 다음 단계에 따라 진행하십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.
3. 슬라이드의 지정된 위치에 `ShapeType`을 `Rectangle`으로 설정한 `AutoShape` 객체를 추가하고 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.
4. 기본 텍스트로 *Aspose TextBox*를 포함하는 `AutoShape` 객체에 `TextFrame`을 추가합니다.
5. `HyperlinkManager` 클래스를 인스턴스화합니다.
6. 원하는 `TextFrame` 부분에 대해 [setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) 메서드를 사용하여 하이퍼링크를 할당합니다.
7. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.

다음 PHP 코드는 위 단계들을 구현한 것으로, 슬라이드에 하이퍼링크가 포함된 텍스트 상자를 추가하는 방법을 보여줍니다:

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # 형식을 Rectangle로 설정한 AutoShape 객체를 추가합니다
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # shape을 AutoShape으로 캐스팅합니다
    $pptxAutoShape = $shape;
    # AutoShape에 연결된 ITextFrame 속성에 접근합니다
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # 프레임에 텍스트를 추가합니다
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # portion 텍스트에 대한 하이퍼링크를 설정합니다
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

**마스터 슬라이드 작업 시 텍스트 상자와 텍스트 자리표시자(placeholder)의 차이점은 무엇인가요?**

A [placeholder](/slides/ko/php-java/manage-placeholder/)는 [master](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)의 스타일/위치를 상속받으며 [layouts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/)에서 재정의될 수 있는 반면, 일반 텍스트 상자는 특정 슬라이드에 독립적인 객체로, 레이아웃을 전환해도 변경되지 않습니다.

**차트, 표, SmartArt 내부의 텍스트를 건드리지 않고 프레젠테이션 전체에서 대량 텍스트 교체를 수행하려면 어떻게 해야 하나요?**

텍스트 프레임을 가진 자동 도형만을 반복 대상으로 제한하고, 내장 객체인 ([charts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/))는 별도의 컬렉션을 탐색하거나 해당 객체 유형을 건너뛰어 제외하십시오.