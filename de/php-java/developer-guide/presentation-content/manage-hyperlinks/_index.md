---
title: Präsentations-Hyperlinks in PHP verwalten
linktitle: Hyperlink verwalten
type: docs
weight: 20
url: /de/php-java/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mühelos mit Aspose.Slides für PHP via Java – steigern Sie Interaktivität und Arbeitsabläufe in wenigen Minuten."
---

Ein Hyperlink ist eine Referenz auf ein Objekt, Daten oder eine Stelle in etwas. Dies sind gängige Hyperlinks in PowerPoint-Präsentationen:

* Links zu Websites innerhalb von Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für PHP via Java ermöglicht das Ausführen vieler Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen.

{{% alert color="primary" %}} 
Vielleicht möchten Sie den einfachen, [kostenlosen Online-PowerPoint-Editor.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **URL-Hyperlinks hinzufügen**

### **URL-Hyperlinks zu Text hinzufügen**

Dieser PHP‑Code zeigt Ihnen, wie Sie einem Text einen Website‑Hyperlink hinzufügen:
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


### **URL-Hyperlinks zu Formen oder Rahmen hinzufügen**

Dieses Beispielcode zeigt Ihnen, wie Sie einem Shape einen Website‑Hyperlink hinzufügen:
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


### **URL-Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bild‑, Audio‑ und Videodateien. 

Dieses Beispielcode zeigt Ihnen, wie Sie einem **Bild** einen Hyperlink hinzufügen:
```php
  $pres = new Presentation();
  try {
    # Fügt ein Bild zur Präsentation hinzu
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Erstellt einen Bildrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
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


Dieses Beispielcode zeigt Ihnen, wie Sie einer **Audiodatei** einen Hyperlink hinzufügen:
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


Dieses Beispielcode zeigt Ihnen, wie Sie einem **Video** einen Hyperlink hinzufügen:
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
Vielleicht möchten Sie *[OLE verwalten](/slides/de/php-java/manage-ole/)* sehen.
{{% /alert %}}

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Da Hyperlinks Ihnen ermöglichen, Verweise auf Objekte oder Stellen hinzuzufügen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden. 

Dieses Beispielcode zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:
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


## **Hyperlinks formatieren**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink#setColorSource-int-)‑Eigenschaft im [IHyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink)‑Interface können Sie die Farbe für Hyperlinks festlegen und auch Farbinformationen von Hyperlinks abrufen. Diese Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an dieser Eigenschaft nicht auf ältere PowerPoint‑Versionen angewendet werden.

Dieses Beispielcode demonstriert einen Vorgang, bei dem Hyperlinks mit verschiedenen Farben zur selben Folie hinzugefügt wurden:
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


## **Hyperlinks aus Präsentationen entfernen**

### **Hyperlinks aus Text entfernen**

Dieser PHP‑Code zeigt Ihnen, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:
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


### **Hyperlinks aus Formen oder Rahmen entfernen**

Dieser PHP‑Code zeigt Ihnen, wie Sie den Hyperlink aus einem Shape in einer Präsentationsfolie entfernen:
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


## **Veränderbarer Hyperlink**

Die Klasse [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink) ist veränderbar. Mit dieser Klasse können Sie die Werte für folgende Eigenschaften ändern:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Das Code‑Snippet zeigt Ihnen, wie Sie einer Folie einen Hyperlink hinzufügen und dessen Tooltip später bearbeiten:
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


## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) von einer Präsentation, Folie oder einem Text aus aufrufen, für den der Hyperlink definiert ist.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

Die Klasse [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) unterstützt folgende Methoden und Eigenschaften:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem „Abschnitt“ oder der ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation richtet sich technisch auf eine bestimmte Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie typischerweise zu dessen erster Folie.

**Kann ich einen Hyperlink an Elemente der Master‑Folien anfügen, sodass er auf allen Folien wirkt?**

Ja. Elemente der Master‑Folien und Layouts unterstützen Hyperlinks. Diese Links erscheinen auf den Unterfolien und sind während der Vorführung anklickbar.

**Werden Hyperlinks beim Exportieren nach PDF, HTML, Bildern oder Video beibehalten?**

In [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) und [HTML](/slides/de/php-java/convert-powerpoint-to-html/) ja – Links werden im Allgemeinen beibehalten. Beim Exportieren zu [Bildern](/slides/de/php-java/convert-powerpoint-to-png/) und [Video](/slides/de/php-java/convert-powerpoint-to-video/) wird die Klickbarkeit nicht übernommen, da diese Formate (Raster‑Frames/Video) keine Hyperlinks unterstützen.