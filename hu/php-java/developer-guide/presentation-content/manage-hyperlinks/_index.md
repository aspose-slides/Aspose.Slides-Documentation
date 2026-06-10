---
title: "PHP-ben prezentáció hiperhivatkozások kezelése"
linktitle: "Hiperhivatkozás kezelése"
type: docs
weight: 20
url: /hu/php-java/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveg hiperhivatkozás
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Könnyedén kezelheti a PowerPoint és OpenDocument prezentációk hiperhivatkozásait az Aspose.Slides for PHP via Java segítségével – fokozza az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy objektumra, adatra vagy egy helyre mutató hivatkozás. Ezek a gyakori hiperhivatkozások a PowerPoint előadásokban:

* Hivatkozások weboldalakra szövegekben, alakzatokban vagy médiában
* Hivatkozások diákra

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy számos, hiperhivatkozásokkal kapcsolatos feladatot hajtson végre az előadásokban.

{{% alert color="primary" %}} 
Érdemes megnézni az egyszerű, [ingyenes online PowerPoint szerkesztőt.](https://products.aspose.app/slides/hu/editor)
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a PHP kód megmutatja, hogyan lehet egy weboldal hiperhivatkozást hozzáadni egy szöveghez:

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a példa kód megmutatja, hogyan lehet egy weboldal hiperhivatkozást hozzáadni egy alakzathoz:

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

### **URL hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi, hogy hiperhivatkozásokat adjon képekhez, hang- és videofájlokhoz.

Ez a példa kód megmutatja, hogyan lehet egy hiperhivatkozást hozzáadni egy **képre**:

```php
  $pres = new Presentation();
  try {
    # Képet ad a prezentációhoz
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Képkeretet hoz létre az 1. dián a korábban hozzáadott kép alapján
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

Ez a példa kód megmutatja, hogyan lehet egy hiperhivatkozást hozzáadni egy **hangfájlhoz**:

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

Ez a példa kód megmutatja, hogyan lehet egy hiperhivatkozást hozzáadni egy **videóhoz**:

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

{{%  alert  title="Tipp"  color="primary"  %}} 
Érdemes megnézni a *[OLE kezelése](/slides/hu/php-java/manage-ole/)*.
{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik, hogy hivatkozásokat adjunk objektumokra vagy helyekre, felhasználhatók tartalomjegyzék létrehozására.

Ez a példa kód megmutatja, hogyan lehet hiperhivatkozásokkal tartalomjegyzéket létrehozni:

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

## **Hiperhivatkozások formázása**

### **Szín**

A [setColorSource](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/setcolorsource/) metódussal a [Hyperlink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/) osztályban beállíthatja a hiperhivatkozások színét, illetve lekérheti a színinformációt a hiperhivatkozásokból. A funkció először a PowerPoint 2019-ben jelent meg, így a tulajdonságra vonatkozó változások nem érvényesek a régebbi PowerPoint verziókra.

Ez a példa kód bemutat egy műveletet, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a dián:

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

## **Hiperhivatkozások eltávolítása előadásból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a PHP kód megmutatja, hogyan távolítható el a hiperhivatkozás egy szövegből egy prezentációs dián:

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

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a PHP kód megmutatja, hogyan távolítható el a hiperhivatkozás egy alakzatról egy prezentációs dián:

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

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/) osztály módosítható. Ezzel az osztállyal a következő tulajdonságok értékeit változtathatja meg:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

A kódrészlet megmutatja, hogyan adhatunk hiperhivatkozást egy diára, és később szerkeszthetjük a tooltipjét:

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

## **Támogatott tulajdonságok az IHyperlinkQueries-ben**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/) elérhető egy prezentációból, diából vagy szövegből, amelyhez a hiperhivatkozás definiálva van.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/gethyperlinkqueries/)

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/) osztály támogatja ezeket a metódusokat és tulajdonságokat:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **GYIK**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szekcióra” vagy egy szekció első diájára?**

A PowerPoint szekciók a diák csoportosításai; a navigáció technikailag egy konkrét diára irányul. Egy „szekcióra” navigáláshoz általában a szekció első diához kell hivatkozni.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy az összes dián működjön?**

Igen. A mesterdia és elrendezési elemek támogatják a hiperhivatkozásokat. Ezek a hivatkozások megjelennek az aloldalak (gyermekdiák)on, és a diavetítés során kattinthatóak.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) esetén igen – a hivatkozások általában megmaradnak. Képek [képek](/slides/hu/php-java/convert-powerpoint-to-png/) és videó [videó](/slides/hu/php-java/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem marad meg, mivel ezek a formátumok (raszteres keretek/videó) nem támogatják a hiperhivatkozásokat.