---
title: Hyperlinks verwalten
type: docs
weight: 20
url: /php-java/manage-hyperlinks/
keywords: "PowerPoint Hyperlink, Text Hyperlink, Folien Hyperlink, Form Hyperlink, Bild Hyperlink, Video Hyperlink, Java"
description: "So fügen Sie Hyperlinks zu einer PowerPoint-Präsentation hinzu"
---

Ein Hyperlink ist ein Verweis auf ein Objekt, Daten oder einen Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint-Präsentationen:

* Links zu Webseiten innerhalb von Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für PHP über Java ermöglicht es Ihnen, viele Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen durchzuführen.

{{% alert color="primary" %}} 

Sie sollten sich den einfachen, [kostenlosen Online PowerPoint-Editor von Aspose ansehen.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Hinzufügen von URL-Hyperlinks**

### **Hinzufügen von URL-Hyperlinks zu Texten**

Dieser PHP-Code zeigt Ihnen, wie Sie einen Webseiten-Hyperlink zu einem Text hinzufügen:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: Dateiformat-APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("Mehr als 70 % der Fortune 100 Unternehmen vertrauen den Aspose-APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Hinzufügen von URL-Hyperlinks zu Formen oder Rahmen**

Dieser Beispielcode zeigt Ihnen, wie Sie einen Webseiten-Hyperlink zu einer Form hinzufügen:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Mehr als 70 % der Fortune 100 Unternehmen vertrauen den Aspose-APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Hinzufügen von URL-Hyperlinks zu Medien**

Aspose.Slides ermöglicht es Ihnen, Hyperlinks zu Bildern, Audio- und Videodateien hinzuzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Bild** hinzufügen:

```php
  $pres = new Presentation();
  try {
    # Bild zur Präsentation hinzufügen
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Bildrahmen auf Folie 1 basierend auf zuvor hinzugefügtem Bild erstellen
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("Mehr als 70 % der Fortune 100 Unternehmen vertrauen den Aspose-APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einer **Audiodatei** hinzufügen:

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
    $audioFrame->getHyperlinkClick()->setTooltip("Mehr als 70 % der Fortune 100 Unternehmen vertrauen den Aspose-APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Video** hinzufügen:

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
    $videoFrame->getHyperlinkClick()->setTooltip("Mehr als 70 % der Fortune 100 Unternehmen vertrauen den Aspose-APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tipp"  color="primary"  %}} 

Sie sollten *[OLE verwalten](/slides/php-java/manage-ole/)* ansehen.

{{% /alert %}}

## **Verwenden von Hyperlinks zum Erstellen eines Inhaltsverzeichnisses**

Da Hyperlinks es Ihnen ermöglichen, Referenzen zu Objekten oder Orten hinzuzufügen, können Sie sie verwenden, um ein Inhaltsverzeichnis zu erstellen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:

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
    $paragraph->setText("Titel der Folie 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Seite 2");
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

## **Formatierung von Hyperlinks**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink#setColorSource-int-) Eigenschaft in der [IHyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink) Schnittstelle können Sie die Farbe für Hyperlinks festlegen und auch Farbinformationen aus Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an der Eigenschaft nicht auf ältere PowerPoint-Versionen angewendet werden.

Dieser Beispielcode zeigt eine Operation, bei der Hyperlinks mit unterschiedlichen Farben zu derselben Folie hinzugefügt wurden:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("Dies ist ein Beispiel für einen farbigen Hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("Dies ist ein Beispiel für einen gewöhnlichen Hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Entfernen von Hyperlinks in Präsentationen**

### **Entfernen von Hyperlinks aus Texten**

Dieser PHP-Code zeigt Ihnen, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:

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

### **Entfernen von Hyperlinks aus Formen oder Rahmen**

Dieser PHP-Code zeigt Ihnen, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen:

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

## **Veränderlicher Hyperlink**

Die [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink) Klasse ist veränderlich. Mit dieser Klasse können Sie die Werte für diese Eigenschaften ändern:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Der Codeausschnitt zeigt Ihnen, wie Sie einen Hyperlink zu einer Folie hinzufügen und später seinen Tooltip bearbeiten:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: Dateiformat-APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("Mehr als 70 % der Fortune 100 Unternehmen vertrauen den Aspose-APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) aus einer Präsentation, Folie oder einem Text, für den der Hyperlink definiert ist, abrufen.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

Die Klasse [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) unterstützt diese Methoden und Eigenschaften:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)