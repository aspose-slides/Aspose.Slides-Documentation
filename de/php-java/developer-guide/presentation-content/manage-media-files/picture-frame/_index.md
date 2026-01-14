---
title: Bildrahmen in Präsentationen mit PHP verwalten
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/php-java/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbilder
- Bild zuschneiden
- zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Foliendesign."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können einem Folienbild über einen Bildrahmen ein Bild hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter — [JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

## **Erstellen eines Bildrahmens**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und das zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erzeugen Sie über die Methode `addPictureFrame` des Shape‑Objekts, das der referenzierten Folie zugeordnet ist, einen [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) basierend auf Breite und Höhe des Bildes.  
6. Fügen Sie der Folie einen Bildrahmen (mit dem Bild) hinzu.  
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieses PHP‑Beispiel zeigt, wie ein Bildrahmen erstellt wird:
```php
  # Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziiert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bildrahmen mit gleicher Höhe und Breite des Bildes hinzu
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 

Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien auf Basis von Bildern. Kombiniert man Bildrahmen mit den Speicheroptionen von Aspose.Slides, können Ein‑ und Ausgabevorgänge manipuliert werden, um Bilder von einem Format in ein anderes zu konvertieren. Weitere nützliche Seiten: Konvertieren Sie [Bild nach JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); konvertieren Sie [JPG nach Bild](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); konvertieren Sie [JPG nach PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), konvertieren Sie [PNG nach JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); konvertieren Sie [PNG nach SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), konvertieren Sie [SVG nach PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Erstellen eines Bildrahmens mit relativer Skalierung**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen. 

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.  
4. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.  
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieses PHP‑Beispiel zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:
```php
  # Instanziert die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Setzt relative Skalierung für Höhe und Breite
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)-Objekten extrahieren und sie im PNG‑, JPG‑ oder anderen Format speichern. Das folgende Beispiel demonstriert, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.
```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```


## **SVG‑Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für PHP via Java das Abrufen der ursprünglichen Vektor‑Bilder mit voller Treue. Durch Durchlaufen der Shape‑Sammlung der Folie können Sie jede [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)-Form identifizieren, prüfen, ob das zugrundeliegende [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) SVG‑Inhalt enthält, und das Bild anschließend im nativen SVG‑Format auf Festplatte oder Stream speichern.

Das folgende Beispiel demonstriert die Extraktion eines SVG‑Bildes aus einem Bildrahmen:
```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **Transparenz eines Bildes ermitteln**

Aspose.Slides ermöglicht das Ermitteln des auf ein Bild angewendeten Transparenzeffekts. Dieser PHP‑Code demonstriert die Vorgehensweise:
```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```


## **Bildrahmen‑Formatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen an bestimmte Anforderungen anpassen.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erzeugen Sie ein `PictureFrame` basierend auf Breite und Höhe des Bildes über die Methode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) des [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)-Objekts, das der referenzierten Folie zugeordnet ist.  
6. Fügen Sie den Bildrahmen (mit dem Bild) der Folie hinzu.  
7. Setzen Sie die Linienfarbe des Bildrahmens.  
8. Setzen Sie die Linienbreite des Bildrahmens.  
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (mit dem Bild) erneut der Folie hinzu.  
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieses PHP‑Beispiel demonstriert den Formatierungsprozess eines Bildrahmens:
```php
  # Instanziert die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Wendet einige Formatierungen auf PictureFrameEx an
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tipp" color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage‑Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie JPG/JPEG‑ oder PNG‑Bilder zusammenführen ([merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg)) oder Raster aus Fotos zu Gittern erstellen ([create grids from photos](https://products.aspose.app/slides/collage/photo-grid)) möchten, können Sie diesen Dienst nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um die Dateigröße von Präsentationen zu reduzieren, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieses PHP‑Beispiel zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:
```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Bilder zuschneiden**

Dieses PHP‑Beispiel demonstriert, wie ein vorhandenes Bild auf einer Folie zugeschnitten wird:
```php
  $pres = new Presentation();
  # Erstellt ein neues Bildobjekt
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt einen PictureFrame zu einer Folie hinzu
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Schneidet das Bild zu (Prozentwerte)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Speichert das Ergebnis
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zugespitzte Bereiche eines Bildes entfernen**

Wenn Sie zugeschnittene Bereiche eines in einem Rahmen enthaltenen Bildes entfernen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) verwenden. Diese Methode gibt das zugeschnittene Bild zurück oder das Originalbild, wenn kein Zuschnitt erforderlich ist.

Dieses PHP‑Beispiel zeigt die Vorgehensweise:
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Holt den PictureFrame von der ersten Folie
    $picFrame = $slide->getShapes()->get_Item(0);
    # Löscht zugeschnittene Bereiche des PictureFrame-Bildes und gibt das zugeschnittene Bild zurück
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Speichert das Ergebnis
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) fügt das zugeschnittene Bild der Bildsammlung der Präsentation hinzu. Wird das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) verwendet, kann diese Einstellung die Dateigröße der Präsentation reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Datei.

Beim Zuschneiden konvertiert diese Methode WMF/EMF‑Metadateien in Raster‑PNG‑Bilder. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu aktivieren.

Dieses PHP‑Beispiel zeigt, wie das Seitenverhältnis einer Form gesperrt wird:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # Form so einstellen, dass das Seitenverhältnis beim Skalieren erhalten bleibt
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form und nicht das des darin enthaltenen Bildes.

{{% /alert %}}

## **Verwendung der StretchOff‑Eigenschaft**

Mit den Methoden [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) und [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) der Klasse [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) können Sie ein Füllrechteck angeben.

Wird ein Bild gestreckt, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet Einzug, ein negativer Prozentsatz Ausbuchtung.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein Rechteck `AutoShape` hinzu.  
4. Erstellen Sie ein Bild.  
5. Setzen Sie den Fülltyp der Form.  
6. Setzen Sie den Bildfüllmodus der Form.  
7. Fügen Sie ein Bild hinzu, um die Form zu füllen.  
8. Geben Sie Bildversätze von der jeweiligen Kante der Begrenzungsbox der Form an.  
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieses PHP‑Beispiel demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Instanziert die ImageEx-Klasse
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt ein AutoShape vom Typ Rectangle hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Setzt den Fülltyp der Form
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Setzt den Bildfüllmodus der Form
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Setzt das Bild zum Füllen der Form
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Gibt die Bildversätze relativ zur entsprechenden Kante des Begrenzungsrahmens der Form an
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Leistung aus?**

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien weiterhin verfügbar sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [Shape‑Locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) für ein [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (z. B. Deaktivierung von Verschieben oder Skalieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/php-java/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), unterstützt.

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation in PDF/Bilder beibehalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export nach PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/php-java/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.