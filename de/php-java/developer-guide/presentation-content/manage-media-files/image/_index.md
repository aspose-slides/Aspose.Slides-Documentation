---
title: Optimieren Sie die Bildverwaltung in Präsentationen mit PHP
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/php-java/image/
keywords:
- Bild hinzufügen
- Bild einfügen
- Bitmap hinzufügen
- Bild ersetzen
- Bild ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Vereinfachen Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für PHP via Java, optimieren Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---

## **Bilder in Präsentationsfolien**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Quellen auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen über verschiedene Verfahren.

{{% alert  title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Frame‑Objekt hinzufügen möchten – insbesondere, wenn Sie beabsichtigen, die standardmäßigen Formatierungsoptionen zu verwenden, um seine Größe zu ändern, Effekte hinzuzufügen usw. – siehe [Picture Frame](/slides/de/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Sie können Eingabe‑/Ausgabe‑Operationen mit Bildern und PowerPoint‑Präsentationen manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: konvertieren [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); konvertieren [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); konvertieren [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), konvertieren [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); konvertieren [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), konvertieren [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Operationen mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und anderen. 

## **Bilder lokal zu Folien hinzufügen**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie in einer Präsentation hinzufügen. Dieser Beispielcode zeigt, wie Sie ein Bild zu einer Folie hinzufügen:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Dieser Beispielcode zeigt, wie Sie ein Bild aus dem Web zu einer Folie hinzufügen:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster ist die übergeordnete Folie, die Informationen (Design, Layout usw.) über alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesen Folienmaster verwendet. 

Dieser Java‑Beispielcode zeigt, wie Sie ein Bild zu einem Folienmaster hinzufügen:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Bilder als Folienhintergrund hinzufügen**

Möglicherweise möchten Sie ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien verwenden. In diesem Fall sollten Sie sehen, wie Sie [Set an Image as a Slide Background](/slides/de/php-java/presentation-background/#set-an-image-as-a-slide-background) einsetzen.

## **SVG zu Präsentationen hinzufügen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) der Klasse [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) verwenden.

Um ein Bildobjekt auf Basis einer SVG‑Datei zu erstellen, gehen Sie folgendermaßen vor:

1. Erzeugen Sie ein SvgImage‑Objekt, um es in die ImageShapeCollection einzufügen
2. Erzeugen Sie ein PPImage‑Objekt aus ISvgImage
3. Erzeugen Sie ein PictureFrame‑Objekt mithilfe der PPImage‑Klasse

Dieser Beispielcode zeigt, wie Sie die oben genannten Schritte implementieren, um ein SVG‑Bild in eine Präsentation einzufügen:
```php
  # Instanziiere die Presentation-Klasse, die die PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SVG in eine Menge von Formen konvertieren**
Die SVG‑Konvertierung von Aspose.Slides in eine Menge von Formen entspricht der PowerPoint‑Funktionalität zur Verarbeitung von SVG‑Bildern:

![PowerPoint Popup Menu](img_01_01.png)

Die Funktion wird über eine der Überladungen der Methode [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addgroupshape/) der Klasse [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereitgestellt, die ein [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/)‑Objekt als erstes Argument akzeptiert.

Dieser Beispielcode zeigt, wie Sie die beschriebene Methode verwenden, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:
```php
  # Neue Präsentation erstellen
  $presentation = new Presentation();
  try {
    # SVG-Dateiinhalt lesen
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # SvgImage-Objekt erstellen
    $svgImage = new SvgImage($svgContent);
    # Foliengröße ermitteln
    $slideSize = $presentation->getSlideSize()->getSize();
    # SVG-Bild in Gruppe von Formen konvertieren und an Foliengröße skalieren
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Präsentation im PPTX-Format speichern
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Bilder als EMF zu Folien hinzufügen**
Aspose.Slides für PHP via Java ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Tabellen und das Hinzufügen dieser Bilder als EMF in Folien mit Aspose.Cells. 

Dieser Beispielcode zeigt, wie Sie die beschriebene Aufgabe ausführen:
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Arbeitsmappe in Stream speichern
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind (einschließlich der von Folienformen verwendeten Bilder). Dieser Abschnitt zeigt mehrere Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API bietet einfache Methoden zum Ersetzen eines Bildes mithilfe von Roh‑Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/)-Instanz oder einem anderen bereits in der Sammlung vorhandenen Bild.

Befolgen Sie die folgenden Schritte:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
1. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
1. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/)-Objekt und ersetzen das Zielbild durch dieses Objekt.
1. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation vorhanden ist.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation("sample.pptx");
try {
    // Die erste Methode.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Die zweite Methode.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Die dritte Methode.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Speichern Sie die Präsentation in einer Datei.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose‑Converter [Text to GIF](https://products.aspose.app/slides/text-to-gif) können Sie Texte leicht animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Quellpixel bleiben erhalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [picture](/slides/de/php-java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie kann man das gleiche Logo auf Dutzenden von Folien gleichzeitig ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation – die Änderungen werden zu allen Elementen propagiert, die diese Ressource verwenden.

**Kann ein eingefügtes SVG in editierbare Formen umgewandelt werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren; danach werden einzelne Teile mit den üblichen Form‑Eigenschaften editierbar.

**Wie setze ich ein Bild als Hintergrund für mehrere Folien gleichzeitig?**

[Weisen Sie das Bild als Hintergrund](/slides/de/php-java/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass die Präsentation durch viele Bilder stark an Größe zunimmt?**

Verwenden Sie eine einzelne Bildressource statt Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie Kompression beim Speichern an und platzieren Sie wiederkehrende Grafiken nach Möglichkeit im Master.