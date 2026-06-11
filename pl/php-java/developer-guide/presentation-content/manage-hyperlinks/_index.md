---
title: Zarządzaj hiperłączami w prezentacji w PHP
linktitle: Zarządzaj hiperłączem
type: docs
weight: 20
url: /pl/php-java/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatowanie hiperłącza
- usuń hiperłącze
- aktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Bezproblemowo zarządzaj hiperłączami w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for PHP via Java — zwiększ interaktywność i wydajność pracy w kilka minut."
---
## **Wprowadzenie**

Hiperłącze to odwołanie do obiektu, danych lub miejsca w czymś. Są to typowe hiperłącza w prezentacjach PowerPoint:

* Odnośniki do stron internetowych w tekstach, kształtach lub mediach
* Odnośniki do slajdów

Aspose.Slides for PHP via Java umożliwia wykonywanie wielu zadań związanych z hiperłączami w prezentacjach.

{{% alert color="primary" %}} 
Możesz chcieć sprawdzić prosty, [free online PowerPoint editor.](https://products.aspose.app/slides/pl/editor)
{{% /alert %}} 

## **Dodaj hiperłącza URL**

### **Dodaj hiperłącza URL do tekstu**

Ten kod PHP pokazuje, jak dodać hiperłącze do witryny internetowej w tekście:

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

### **Dodaj hiperłącza URL do kształtów lub ramek**

Ten przykładowy kod pokazuje, jak dodać hiperłącze do witryny internetowej w kształcie:

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

### **Dodaj hiperłącza URL do mediów**

Aspose.Slides umożliwia dodawanie hiperłączy do obrazów, plików audio i wideo.

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **obrazu**:

```php
  $pres = new Presentation();
  try {
    # Dodaje obraz do prezentacji
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Tworzy ramkę obrazu na slajdzie 1 na podstawie wcześniej dodanego obrazu
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

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **pliku audio**:

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

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **wideo**:

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

{{% alert title="Tip" color="primary" %}} 
Możesz zobaczyć *[Manage OLE](/slides/pl/php-java/manage-ole/)*.
{{% /alert %}}

## **Użyj hiperłączy do tworzenia spisu treści**

Ponieważ hiperłącza umożliwiają dodawanie odwołań do obiektów lub miejsc, możesz ich użyć do stworzenia spisu treści.

Ten przykładowy kod pokazuje, jak utworzyć spis treści z hiperłączami:

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

## **Formatuj hiperłącza**

### **Kolor**

Za pomocą metody [setColorSource](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/setcolorsource/) w klasie [Hyperlink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/) możesz ustawić kolor hiperłączy oraz pobrać informację o kolorze z hiperłączy. Funkcja została wprowadzona po raz pierwszy w PowerPoint 2019, więc zmiany dotyczące tej właściwości nie mają zastosowania do starszych wersji PowerPointa.

Ten przykładowy kod demonstruje operację, w której do tego samego slajdu dodano hiperłącza o różnych kolorach:

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

## **Usuń hiperłącza z prezentacji**

### **Usuń hiperłącza z tekstu**

Ten kod PHP pokazuje, jak usunąć hiperłącze z tekstu w slajdzie prezentacji:

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

### **Usuń hiperłącza z kształtów lub ramek**

Ten kod PHP pokazuje, jak usunąć hiperłącze z kształtu w slajdzie prezentacji:

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

## **Modyfikowalne hiperłącze**

Klasa [Hyperlink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/) jest mutowalna. Dzięki niej możesz zmienić wartości następujących właściwości:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Fragment kodu pokazuje, jak dodać hiperłącze do slajdu i później edytować jego podpowiedź (tooltip):

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

## **Obsługiwane właściwości w IHyperlinkQueries**

Możesz uzyskać dostęp do [HyperlinkQueries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/) z prezentacji, slajdu lub tekstu, dla którego zdefiniowano hiperłącze.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/gethyperlinkqueries/)

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/) obsługuje następujące metody i właściwości:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Jak mogę stworzyć wewnętrzną nawigację nie tylko do slajdu, ale do „sekcji” lub pierwszego slajdu sekcji?**

Sekcje w PowerPoint to grupowania slajdów; nawigacja technicznie odnosi się do konkretnego slajdu. Aby „nawigować do sekcji”, zazwyczaj linkuje się do jej pierwszego slajdu.

**Czy mogę dołączyć hiperłącze do elementów slajdu master, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu master i układu obsługują hiperłącza. Takie linki pojawiają się na slajdach potomnych i są klikalne podczas pokazu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

W [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/php-java/convert-powerpoint-to-html/) tak — linki są zazwyczaj zachowywane. Przy eksporcie do [obrazów](/slides/pl/php-java/convert-powerpoint-to-png/) i [wideo](/slides/pl/php-java/convert-powerpoint-to-video/) klikalność nie zostanie przeniesiona ze względu na charakter tych formatów (klatki rastrowe/wideo nie wspierają hiperłączy).