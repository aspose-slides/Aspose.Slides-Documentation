---
title: PHP에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/php-java/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 하이퍼링크를 손쉽게 관리하고, 몇 분 안에 인터랙티브성과 작업 흐름을 향상시키세요."
---
## **소개**

하이퍼링크는 객체나 데이터, 혹은 어떤 위치에 대한 참조입니다. 다음은 PowerPoint 프레젠테이션에서 흔히 사용되는 하이퍼링크입니다:

* 텍스트, 도형 또는 미디어 안에 있는 웹사이트 링크
* 슬라이드에 대한 링크

Aspose.Slides for PHP via Java를 사용하면 프레젠테이션에서 하이퍼링크와 관련된 다양한 작업을 수행할 수 있습니다.

{{% alert color="primary" %}} 

Aspose 간단한, [무료 온라인 PowerPoint 편집기.](https://products.aspose.app/slides/ko/editor)를 확인해 보세요.

{{% /alert %}} 

## **URL 하이퍼링크 추가**

### **텍스트에 URL 하이퍼링크 추가**

다음 PHP 코드는 텍스트에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **도형 또는 프레임에 URL 하이퍼링크 추가**

다음 샘플 코드는 도형에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **미디어에 URL 하이퍼링크 추가**

Aspose.Slides를 사용하면 이미지, 오디오 및 비디오 파일에 하이퍼링크를 추가할 수 있습니다. 

다음 샘플 코드는 **이미지**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    # 프레젠테이션에 이미지를 추가합니다
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 이전에 추가된 이미지를 기반으로 슬라이드 1에 그림 프레임을 만듭니다
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

다음 샘플 코드는 **오디오 파일**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

다음 샘플 코드는 **비디오**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 

다음도 확인해 보세요 *[Manage OLE](/slides/ko/php-java/manage-ole/)*.

{{% /alert %}}

## **하이퍼링크를 사용하여 목차 만들기**

하이퍼링크는 객체나 위치에 대한 참조를 추가할 수 있기 때문에, 이를 사용하여 목차를 만들 수 있습니다.

다음 샘플 코드는 하이퍼링크를 사용하여 목차를 만드는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **하이퍼링크 서식 지정**

### **색상**

다음 [Hyperlink](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/) 클래스의 [setColorSource](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/setcolorsource/) 메서드를 사용하면 하이퍼링크의 색상을 설정하고 하이퍼링크에서 색상 정보를 가져올 수 있습니다. 이 기능은 PowerPoint 2019에서 처음 도입되었으므로 해당 속성의 변경 사항은 이전 PowerPoint 버전에는 적용되지 않습니다.

다음 샘플 코드는 서로 다른 색상의 하이퍼링크를 동일한 슬라이드에 추가하는 작업을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **프레젠테이션에서 하이퍼링크 제거**

### **텍스트에서 하이퍼링크 제거**

다음 PHP 코드는 프레젠테이션 슬라이드의 텍스트에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **도형 또는 프레임에서 하이퍼링크 제거**

다음 PHP 코드는 프레젠테이션 슬라이드의 도형에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **가변 하이퍼링크**

다음 [Hyperlink](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/) 클래스는 가변(mutable)입니다. 이 클래스를 사용하면 다음 속성들의 값을 변경할 수 있습니다:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

다음 코드 스니펫은 슬라이드에 하이퍼링크를 추가하고 나중에 툴팁을 편집하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **IHyperlinkQueries에서 지원되는 속성**

프레젠테이션, 슬라이드, 또는 하이퍼링크가 정의된 텍스트에서 [HyperlinkQueries](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkqueries/)에 접근할 수 있습니다.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/gethyperlinkqueries/)

[HyperlinkQueries](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkqueries/) 클래스는 다음 메서드와 속성을 지원합니다:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**슬라이드뿐만 아니라 "섹션" 또는 섹션의 첫 슬라이드로도 내부 탐색을 만들려면 어떻게 해야 하나요?**

PowerPoint에서 섹션은 슬라이드의 그룹이며, 탐색은 기술적으로 특정 슬라이드를 목표로 합니다. "섹션으로 이동"하려면 일반적으로 해당 섹션의 첫 슬라이드에 링크합니다.

**마스터 슬라이드 요소에 하이퍼링크를 연결하면 모든 슬라이드에서 작동하도록 할 수 있나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 링크는 자식 슬라이드에 표시되며 슬라이드 쇼 중에 클릭할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지되나요?**

[PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/)와 [HTML](/slides/ko/php-java/convert-powerpoint-to-html/)에서는 링크가 일반적으로 유지됩니다. [이미지](/slides/ko/php-java/convert-powerpoint-to-png/)와 [비디오](/slides/ko/php-java/convert-powerpoint-to-video/)로 내보낼 경우, 이러한 형식은 래스터 프레임/비디오이므로 하이퍼링크 클릭 가능성이 유지되지 않습니다.