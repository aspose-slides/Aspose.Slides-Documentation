---
title: Beheer presentatie-hyperlinks in PHP
linktitle: Beheer hyperlink
type: docs
weight: 20
url: /nl/php-java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst-hyperlink
- dia-hyperlink
- vorm-hyperlink
- afbeelding-hyperlink
- video-hyperlink
- wijzigbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer hyperlinks moeiteloos in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java — verhoog interactiviteit en workflow in enkele minuten."
---
## **Introductie**

Een hyperlink is een verwijzing naar een object, gegevens of een locatie in iets. Dit zijn veelvoorkomende hyperlinks in PowerPoint‑presentaties:

* Verwijzingen naar websites binnen tekst, vormen of media
* Verwijzingen naar dia’s

Aspose.Slides for PHP via Java stelt u in staat om tal van taken met hyperlinks in presentaties uit te voeren.

{{% alert color="primary" %}} 
U wilt misschien Aspose Simple, [gratis online PowerPoint‑editor](https://products.aspose.app/slides/nl/editor)
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

### **URL‑hyperlinks aan tekst toevoegen**

Deze PHP‑code laat zien hoe u een website‑hyperlink aan een tekst toevoegt:

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

### **URL‑hyperlinks aan vormen of kaders toevoegen**

Deze voorbeeldcode laat zien hoe u een website‑hyperlink aan een vorm toevoegt:

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

### **URL‑hyperlinks aan media toevoegen**

Aspose.Slides maakt het mogelijk om hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden. 

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **afbeelding** toevoegt:

```php
  $pres = new Presentation();
  try {
    # Voeg afbeelding toe aan presentatie
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Maak een afbeeldingsframe op dia 1 op basis van de eerder toegevoegde afbeelding
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

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **audio‑bestand** toevoegt:

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

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **video** toevoegt:

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
U wilt misschien *[OLE beheren](/slides/nl/php-java/manage-ole/)*.
{{% /alert %}}

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Aangezien hyperlinks verwijzingen naar objecten of locaties mogelijk maken, kunt u ze gebruiken om een inhoudsopgave te maken. 

Deze voorbeeldcode laat zien hoe u een inhoudsopgave met hyperlinks maakt:

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

## **Hyperlinks opmaken**

### **Kleur**

Met de [setColorSource](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/setcolorsource/)‑methode in de [Hyperlink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/)‑klasse kunt u de kleur van hyperlinks instellen en ook de kleureninformatie opvragen. Deze functie werd voor het eerst geïntroduceerd in PowerPoint 2019, dus wijzigingen die deze eigenschap betreffen, gelden niet voor oudere PowerPoint‑versies.

Deze voorbeeldcode toont een bewerking waarbij hyperlinks met verschillende kleuren aan dezelfde dia worden toegevoegd:

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

## **Hyperlinks uit presentaties verwijderen**

### **Hyperlinks uit tekst verwijderen**

Deze PHP‑code laat zien hoe u de hyperlink uit een tekst op een presentatiedia verwijdert:

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

### **Hyperlinks uit vormen of kaders verwijderen**

Deze PHP‑code laat zien hoe u de hyperlink uit een vorm op een presentatiedia verwijdert:

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

## **Mutable hyperlink**

De [Hyperlink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/)‑klasse is mutable. Met deze klasse kunt u de waarden van de volgende eigenschappen wijzigen:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

De code‑snippet laat zien hoe u een hyperlink aan een dia toevoegt en later de tooltip bewerkt:

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

## **Ondersteunde eigenschappen in IHyperlinkQueries**

U kunt [HyperlinkQueries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/) benaderen vanaf een presentatie, dia of tekst waarvoor de hyperlink is gedefinieerd.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/gethyperlinkqueries/)

De [HyperlinkQueries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/)‑klasse ondersteunt de volgende methoden en eigenschappen:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Hoe kan ik interne navigatie maken niet alleen naar een dia, maar naar een “sectie” of de eerste dia van een sectie?**

Secties in PowerPoint zijn groeperingen van dia’s; de navigatie richt zich technisch op een specifieke dia. Om “naar een sectie te navigeren” linkt u doorgaans naar de eerste dia ervan.

**Kan ik een hyperlink aan elementen van de master‑dia koppelen zodat deze op alle dia’s werkt?**

Ja. Master‑dia‑ en lay‑outelementen ondersteunen hyperlinks. Dergelijke koppelingen verschijnen op onderliggende dia’s en zijn klikbaar tijdens de diavoorstelling.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

In [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/php-java/convert-powerpoint-to-html/) ja – links blijven meestal behouden. Bij export naar [afbeeldingen](/slides/nl/php-java/convert-powerpoint-to-png/) en [video](/slides/nl/php-java/convert-powerpoint-to-video/) gaat de klikbaarheid verloren vanwege de aard van deze formaten (raster‑frames/video ondersteunen geen hyperlinks).