---
title: Gestisci i collegamenti ipertestuali della presentazione in PHP
linktitle: Gestisci collegamento ipertestuale
type: docs
weight: 20
url: /it/php-java/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale testo
- collegamento ipertestuale diapositiva
- collegamento ipertestuale forma
- collegamento ipertestuale immagine
- collegamento ipertestuale video
- collegamento ipertestuale mutabile
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci i collegamenti ipertestuali in presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP tramite Java — migliora l'interattività e il flusso di lavoro in pochi minuti."
---
## **Introduzione**

Un collegamento ipertestuale è un riferimento a un oggetto, a dati o a un punto all'interno di qualcosa. Questi sono collegamenti ipertestuali comuni nelle presentazioni PowerPoint:

* Collegamenti a siti web all'interno di testi, forme o elementi multimediali
* Collegamenti a diapositive

Aspose.Slides per PHP tramite Java consente di eseguire molte attività relative ai collegamenti ipertestuali nelle presentazioni.

{{% alert color="primary" %}} 
Potresti voler provare Aspose simple, [editor online gratuito di PowerPoint.](https://products.aspose.app/slides/it/editor)
{{% /alert %}} 

## **Aggiungi collegamenti URL**

### **Aggiungi collegamenti URL al testo**

Questo codice PHP mostra come aggiungere un collegamento ipertestuale a un sito web a un testo:

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

### **Aggiungi collegamenti URL a forme o riquadri**

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un sito web a una forma:

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

### **Aggiungi collegamenti URL ai media**

Aspose.Slides consente di aggiungere collegamenti ipertestuali a immagini, file audio e video. 

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a una **immagine**:

```php
  $pres = new Presentation();
  try {
    # Aggiunge immagine alla presentazione
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Crea un riquadro immagine nella diapositiva 1 basato sull'immagine precedentemente aggiunta
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

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **file audio**:

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

Questo esempio di codice mostra come aggiungere un collegamento ipertestuale a un **video**:

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
Potresti voler vedere *[Gestisci OLE](/slides/it/php-java/manage-ole/)*.
{{% /alert %}}

## **Usa collegamenti ipertestuali per creare un indice**

Poiché i collegamenti ipertestuali consentono di aggiungere riferimenti a oggetti o posizioni, è possibile usarli per creare un indice. 

Questo esempio di codice mostra come creare un indice con collegamenti ipertestuali:

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

## **Formato dei collegamenti ipertestuali**

### **Colore**

Con il metodo [setColorSource](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/setcolorsource/) nella classe [Hyperlink](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/), è possibile impostare il colore per i collegamenti ipertestuali e anche ottenere le informazioni sul colore dai collegamenti ipertestuali. La funzionalità è stata introdotta per la prima volta in PowerPoint 2019, quindi le modifiche relative a questa proprietà non si applicano alle versioni precedenti di PowerPoint.

Questo esempio di codice dimostra un'operazione in cui collegamenti ipertestuali con colori diversi sono stati aggiunti alla stessa diapositiva:

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

## **Rimuovi collegamenti ipertestuali dalle presentazioni**

### **Rimuovi collegamenti ipertestuali dal testo**

Questo codice PHP mostra come rimuovere il collegamento ipertestuale da un testo in una diapositiva della presentazione:

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

### **Rimuovi collegamenti ipertestuali da forme o riquadri**

Questo codice PHP mostra come rimuovere il collegamento ipertestuale da una forma in una diapositiva della presentazione:

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

## **Collegamento ipertestuale mutabile**

La classe [Hyperlink](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/) è mutabile. Con questa classe è possibile modificare i valori di queste proprietà:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Il frammento di codice mostra come aggiungere un collegamento ipertestuale a una diapositiva e modificarne il tooltip in seguito:

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

## **Proprietà supportate in IHyperlinkQueries**

È possibile accedere a [HyperlinkQueries](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/) da una presentazione, diapositiva o testo per cui è definito il collegamento ipertestuale.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/gethyperlinkqueries/)

La classe [HyperlinkQueries](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/) supporta questi metodi e proprietà:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Come posso creare una navigazione interna non solo a una diapositiva, ma a una "sezione" o alla prima diapositiva di una sezione?**

Le sezioni in PowerPoint sono raggruppamenti di diapositive; la navigazione tecnicamente punta a una diapositiva specifica. Per “navigare a una sezione”, di solito si collega alla sua prima diapositiva.

**Posso collegare un collegamento ipertestuale agli elementi del master slide affinché funzioni su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. Tali collegamenti appaiono sulle diapositive figlie e sono cliccabili durante la presentazione.

**I collegamenti ipertestuali verranno mantenuti durante l'esportazione in PDF, HTML, immagini o video?**

In [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/php-java/convert-powerpoint-to-html/), sì — i collegamenti sono generalmente conservati. Quando si esporta in [immagini](/slides/it/php-java/convert-powerpoint-to-png/) e [video](/slides/it/php-java/convert-powerpoint-to-video/), la cliccabilità non verrà mantenuta a causa della natura di quei formati (fotogrammi raster/video non supportano collegamenti ipertestuali).