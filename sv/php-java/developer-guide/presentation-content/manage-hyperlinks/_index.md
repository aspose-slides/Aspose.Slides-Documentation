---
title: Hantera presentationshyperlänkar i PHP
linktitle: Hantera hyperlänk
type: docs
weight: 20
url: /sv/php-java/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- ändringsbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java utan ansträngning — förbättra interaktiviteten och arbetsflödet på några minuter."
---
## **Introduktion**

En hyperlänk är en referens till ett objekt eller data eller en plats i något. Detta är vanliga hyperlänkar i PowerPoint‑presentationer:

* Länkar till webbplatser i texter, former eller media
* Länkar till bilder

Aspose.Slides för PHP via Java låter dig utföra många uppgifter som involverar hyperlänkar i presentationer.

{{% alert color="primary" %}} 

Du kanske vill kolla in Aspose Simple, [gratis online PowerPoint‑redigerare.](https://products.aspose.app/slides/sv/editor)

{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

### **Lägg till URL‑hyperlänkar till text**

Denna PHP‑kod visar hur du lägger till en webbplats‑hyperlänk till en text:

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

### **Lägg till URL‑hyperlänkar till former eller ramar**

Detta exempel visar hur du lägger till en webbplats‑hyperlänk till en form:

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

### **Lägg till URL‑hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud‑ och videofiler. 

Detta exempel visar hur du lägger till en hyperlänk till en **bild**:

```php
  $pres = new Presentation();
  try {
    # Lägger till bild i presentationen
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Skapar bildram på bild 1 baserat på tidigare tillagd bild
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

Detta exempel visar hur du lägger till en hyperlänk till en **ljudfil**:

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

Detta exempel visar hur du lägger till en hyperlänk till en **video**:

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

Du kanske vill se *[Hantera OLE](/slides/sv/php-java/manage-ole/)*.

{{% /alert %}}

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Eftersom hyperlänkar låter dig lägga till referenser till objekt eller platser kan du använda dem för att skapa en innehållsförteckning. 

Detta exempel visar hur du skapar en innehållsförteckning med hyperlänkar:

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

## **Formatera hyperlänkar**

### **Färg**

Med metoden [setColorSource](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/setcolorsource/) i klassen [Hyperlink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/) kan du ange färgen för hyperlänkar och även hämta färginformation från hyperlänkar. Funktionen introducerades först i PowerPoint 2019, så ändringar som rör egenskapen gäller inte för äldre PowerPoint‑versioner.

Detta exempel demonstrerar en operation där hyperlänkar med olika färger lades till på samma bild:

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

## **Ta bort hyperlänkar från presentationer**

### **Ta bort hyperlänkar från text**

Denna PHP‑kod visar hur du tar bort hyperlänken från en text i en presentationsbild:

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

### **Ta bort hyperlänkar från former eller ramar**

Denna PHP‑kod visar hur du tar bort hyperlänken från en form i en presentationsbild:

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

## **Ändringsbar hyperlänk**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/) är förändringsbar. Med denna klass kan du ändra värdena för följande egenskaper:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Kodsnutten visar hur du lägger till en hyperlänk till en bild och redigerar dess verktygstips senare:

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

## **Stödda egenskaper i IHyperlinkQueries**

Du kan komma åt [HyperlinkQueries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/) från en presentation, bild eller text där hyperlänken är definierad.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/gethyperlinkqueries/)

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/) stödjer dessa metoder och egenskaper:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Hur kan jag skapa intern navigation inte bara till en bild, utan till ett "avsnitt" eller den första bilden i ett avsnitt?**

Avsnitt i PowerPoint är gruppering av bilder; navigation riktar sig tekniskt sett till en specifik bild. För att "navigera till ett avsnitt" länkar du vanligtvis till dess första bild.

**Kan jag bifoga en hyperlänk till master‑bild‑element så att den fungerar på alla bilder?**

Ja. Master‑bild‑ och layout‑element stödjer hyperlänkar. Sådana länkar visas på underordnade bilder och är klickbara under bildspelet.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

I [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/php-java/convert-powerpoint-to-html/) ja – länkar bevaras i allmänhet. Vid export till [bilder](/slides/sv/php-java/convert-powerpoint-to-png/) och [video](/slides/sv/php-java/convert-powerpoint-to-video/) kommer klickbarhet inte att överföras på grund av formatens natur (rastrera ramar/video stödjer inte hyperlänkar).