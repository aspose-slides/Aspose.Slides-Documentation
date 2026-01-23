---
title: PPT und PPTX in JPG konvertieren in PHP
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/php-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu JPG
- Präsentation zu JPG
- Folie zu JPG
- PPT zu JPG
- PPTX zu JPG
- PowerPoint als JPG speichern
- Präsentation als JPG speichern
- Folie als JPG speichern
- PPT als JPG speichern
- PPTX als JPG speichern
- PPT nach JPG exportieren
- PPTX nach JPG exportieren
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochwertige JPG‑Bilder in PHP mit Aspose.Slides für PHP mithilfe schneller, zuverlässiger Code‑Beispiele."
---

## **Über die PowerPoint-zu-JPG-Konvertierung**
Mit [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) können Sie PowerPoint‑PPT‑ oder PPTX‑Präsentationen in JPG‑Bilder konvertieren. Es ist auch möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentations‑Viewer zu implementieren und das Miniaturbild für jede Folie zu erstellen. Dies kann nützlich sein, wenn Sie die Folien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer bestimmten Folie in Bildformate.

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, können Sie diese kostenlosen Online‑Konverter ausprobieren: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX zu JPG konvertieren**
Hier sind die Schritte, um PPT/PPTX in JPG zu konvertieren:

1. Erstellen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie das Folienobjekt des Typs [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) aus der Sammlung [Presentation::getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. Erstellen Sie das Miniaturbild jeder Folie und konvertieren Sie es anschließend in JPG. Die Methode [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) wird verwendet, um ein Miniaturbild einer Folie zu erhalten. Die Methode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) muss vom gewünschten [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)‑Objekt aufgerufen werden; die Skalierungsfaktoren des resultierenden Miniaturbilds werden dabei an die Methode übergeben.
4. Nachdem Sie das Folien‑Miniaturbild erhalten haben, rufen Sie die Methode [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) vom Miniaturbild‑Objekt auf. Übergeben Sie dabei den resultierenden Dateinamen und das Bildformat.

{{% alert color="primary" %}}
**Hinweis**: Die PPT/PPTX‑zu‑JPG‑Konvertierung unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides API. Für andere Formate verwenden Sie normalerweise die Methode [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), hier benötigen Sie jedoch die Methode [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)). 
{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Erstellt ein Bild in voller Größe
      $slideImage = $sld->getImage(1.0, 1.0);
      # Speichert das Bild auf dem Datenträger im JPEG-Format
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint PPT/PPTX zu JPG mit benutzerdefinierten Abmessungen konvertieren**
Um die Abmessungen des resultierenden Miniaturbilds und JPG‑Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* setzen, indem Sie sie an die Methoden [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) übergeben:
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definiert die Abmessungen
    $desiredX = 1200;
    $desiredY = 800;
    # Ermittelt skalierte Werte von X und Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Erstellt ein Bild in voller Größe
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Speichert das Bild auf dem Datenträger im JPEG-Format
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Kommentare beim Speichern von Folien als Bilder rendern**
Aspose.Slides für PHP via Java bietet eine Funktion, mit der Sie Kommentare in den Folien einer Präsentation rendern können, wenn Sie diese Folien in Bilder konvertieren. Dieser PHP‑Code demonstriert die Vorgehensweise:
```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}
Aspose bietet eine [KOSTENLOSE Collage-Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter.

Mit den gleichen Prinzipien, die in diesem Artikel beschrieben werden, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu JPG konvertieren [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); JPG zu Bild konvertieren [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); JPG zu PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), PNG zu JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); PNG zu SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), SVG zu PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode Batch‑Konvertierung?**  
Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**  
Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei Verwendung benutzerdefinierter oder fehlender Schriftarten.

**Gibt es Beschränkungen für die Anzahl der verarbeitbaren Folien?**  
Aspose.Slides selbst legt keine strikten Grenzen für die Anzahl der verarbeitbaren Folien fest. Allerdings kann bei großen Präsentationen oder hochauflösenden Bildern ein Out‑Of‑Memory‑Fehler auftreten.

## **Siehe auch**
Weitere Optionen, um PPT/PPTX in Bilder zu konvertieren, finden Sie unter:

- [PPT/PPTX zu SVG-Konvertierung](/slides/de/php-java/render-a-slide-as-an-svg-image/).