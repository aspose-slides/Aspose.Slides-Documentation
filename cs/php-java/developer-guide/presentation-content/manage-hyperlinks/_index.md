---
title: Spravovat hypertextové odkazy v prezentaci v PHP
linktitle: Spravovat hypertextový odkaz
type: docs
weight: 20
url: /cs/php-java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Snadno spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java — zvýšte interaktivitu a efektivitu práce během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt nebo data či místo v něčem. Toto jsou běžné hypertextové odkazy v PowerPoint prezentacích:

* Odkazy na webové stránky uvnitř textu, tvarů nebo médií
* Odkazy na snímky

Aspose.Slides pro PHP přes Java vám umožňuje provádět řadu úkolů souvisejících s hypertextovými odkazy v prezentacích.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet jednoduchý, bezplatný online editor PowerPoint od Aspose.[free online PowerPoint editor.](https://products.aspose.app/slides/cs/editor)
{{% /alert %}} 

## **Přidat URL odkazy**

### **Přidat URL odkazy do textu**

Tento PHP kód ukazuje, jak přidat hypertextový odkaz na webovou stránku do textu:

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

### **Přidat URL odkazy do tvarů nebo rámců**

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na webovou stránku do tvaru:

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

### **Přidat URL odkazy do médií**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy na obrázky, zvukové a video soubory. 

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **obrázek**:

```php
  $pres = new Presentation();
  try {
    # Přidá obrázek do prezentace
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Vytvoří rámeček obrázku na snímku 1 na základě dříve přidaného obrázku
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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **audio soubor**:

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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **video**:

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
Možná budete chtít zobrazit *[Spravovat OLE](/slides/cs/php-java/manage-ole/)*.
{{% /alert %}}

## **Použít hypertextové odkazy k vytvoření obsahu**

Protože hypertextové odkazy vám umožňují přidávat odkazy na objekty nebo místa, můžete je použít k vytvoření obsahu. 

Tento ukázkový kód ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátovat hypertextové odkazy**

### **Barva**

Pomocí metody [setColorSource](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/setcolorsource/) ve třídě [Hyperlink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/) můžete nastavit barvu hypertextových odkazů a také získat informace o barvě z hypertextových odkazů. Tato funkce byla poprvé představena v PowerPointu 2019, takže změny týkající se této vlastnosti se nepoužijí na starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, při které byly do stejného snímku přidány hypertextové odkazy s různými barvami:

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

## **Odstranit hypertextové odkazy z prezentací**

### **Odstranit hypertextové odkazy z textu**

Tento PHP kód ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

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

### **Odstranit hypertextové odkazy z tvarů nebo rámců**

Tento PHP kód ukazuje, jak odstranit hypertextový odkaz z tvaru na snímku prezentace:

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

## **Měnitelný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/) je měnitelná. S touto třídou můžete změnit hodnoty těchto vlastností:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Ukázkový úryvek kódu ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek:

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

## **Podporované vlastnosti v IHyperlinkQueries**

Můžete získat přístup k [HyperlinkQueries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/) z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/gethyperlinkqueries/)

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/) podporuje následující metody a vlastnosti:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Jak mohu vytvořit vnitřní navigaci nejen na snímek, ale i na „sekci“ nebo první snímek sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci k sekci“ obvykle odkazujete na její první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Takové odkazy se zobrazí na podřízených snímcích a jsou klikatelné během prezentace.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/php-java/convert-powerpoint-to-html/) ano — odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/php-java/convert-powerpoint-to-png/) a [videa](/slides/cs/php-java/convert-powerpoint-to-video/) klikatelnost nepřetrvá, protože tyto formáty (rastrové snímky/video) hypertextové odkazy nepodporují.