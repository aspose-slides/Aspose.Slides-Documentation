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
- Vektorbild
- Bild zuschneiden
- zugeschnittener Bereich
- StretchOff‑Eigenschaft
- Bildrahmenformatierung
- Bildrahmen‑Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Fügen Sie PowerPoint- und OpenDocument‑Präsentationen Bildrahmen mit Aspose.Slides für PHP via Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design Ihrer Folien."
---
## **Einführung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert title="Tipp" color="primary" %}}
Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—an, die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen.
{{% /alert %}}

## **Erstellen eines Bildrahmens**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) basierend auf der Breite und Höhe des Bildes über die Methode `addPictureFrame`, die vom Form‑Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Bildrahmen erstellen:

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
Bildrahmen ermöglichen es Ihnen, schnell Folien basierend auf Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabevorgänge manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie könnten diese Seiten ansehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/de/php-java/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/de/php-java/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/de/php-java/conversion/jpg-to-png/); konvertieren [PNG zu JPG](https://products.aspose.com/slides/de/php-java/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/de/php-java/conversion/png-to-svg/); konvertieren [SVG zu PNG](https://products.aspose.com/slides/de/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **Erstellen eines Bildrahmens mit relativer Skalierung**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:

```php
  # Instanziiert die Presentation-Klasse, die die PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziiert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Setzt relative Skalierung für Breite und Höhe
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

Sie können Rasterbilder aus [PictureFrame]-Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das untenstehende Codebeispiel zeigt, wie man ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format speichert.

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

Wenn eine Präsentation SVG‑Grafiken enthält, die innerhalb von [PictureFrame]-Formen platziert sind, ermöglicht Aspose.Slides für PHP via Java das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jedes [PictureFrame] identifizieren, prüfen, ob das zugrunde liegende [PPImage] SVG‑Inhalt enthält, und das Bild dann auf dem Datenträger oder in einem Stream im nativen SVG‑Format speichern.

Der folgende Codebeispiel demonstriert, wie man ein SVG‑Bild aus einem Bildrahmen extrahiert:

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

## **Transparenz eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des Transparenzeffekts, der auf ein Bild angewendet wird. Dieser PHP‑Code demonstriert die Vorgehensweise:

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

## **Helligkeit und Kontrast eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des Helligkeits‑ und Kontrasteffekts, der auf ein Bild angewendet wird. Die Klasse [Luminance] stellt diesen Bildtransformations‑Effekt dar.

Dieser PHP‑Code zeigt, wie man die Helligkeits‑ und Kontrasteinstellungen aus einem Bildrahmen abruft:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Bildrahmenformatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er bestimmten Anforderungen entspricht.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `PictureFrame` basierend auf der Breite und Höhe des Bildes über die Methode [addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addpictureframe/) des [ShapeCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/)-Objekts, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Legen Sie die Linienfarbe des Bildrahmens fest.
8. Legen Sie die Linienbreite des Bildrahmens fest.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (der das Bild enthält) zur Folie hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert den Bildrahmenformatierungs‑Prozess:

```php
  # Instanziert die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bildrahmen mit gleicher Höhe und Breite des Bildes hinzu
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
Aspose hat kürzlich einen [kostenlosen Collage‑Ersteller](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie jemals [JPG/JPEG‑Bilder](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/de/collage/photo-grid) müssen, können Sie diesen Dienst nutzen. 
{{% /alert %}}

## **Ein Bild als Link einfügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser PHP‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

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

Dieser PHP‑Code zeigt, wie Sie ein bestehendes Bild auf einer Folie zuschneiden:

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
    # Fügt einen Bildrahmen zu einer Folie hinzu
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

## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes löschen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, wenn ein Zuschneiden nicht nötig ist.

Dieser PHP‑Code demonstriert die Vorgehensweise:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Holt den Bildrahmen von der ersten Folie
    $picFrame = $slide->getShapes()->get_Item(0);
    # Löscht die zugeschnittenen Bereiche des Bildrahmens-Bildes und gibt das zugeschnittene Bild zurück
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
Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame] verwendet wird, kann diese Vorgehensweise die Größe der Präsentation reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien im Zuschneidevorgang in ein rasterisiertes PNG‑Bild. 
{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) komprimieren. Diese Methode komprimiert ein Bild, indem sie seine Größe basierend auf der Formgröße und der angegebenen Auflösung reduziert, mit der Option, zugeschnittene Bereiche zu löschen.

Sie passt Größe und Auflösung des Bildes ähnlich der PowerPoint‑Funktion **Bildformat -> Bilder komprimieren -> Auflösung** an.

Die folgenden PHP‑Beispiele zeigen, wie man ein Bild in einer Präsentation komprimiert, indem man eine Zielauflösung angibt und optional zugeschnittene Bereiche entfernt:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimiert das Bild mit einer Zielauflösung von 150 DPI (Webauflösung) und entfernt zugeschnittene Bereiche.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Prüft das Ergebnis der Kompression.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Oder indem man direkt einen benutzerdefinierten DPI‑Wert verwendet:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Bild auf 150 DPI (Webauflösung) komprimieren, zugeschnittene Bereiche entfernen.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="HINWEIS" color="warning" %}}
Die Methode konvertiert das Bild basierend auf der Formgröße und dem angegebenen DPI in eine niedrigere Auflösung. Zuge‑schneiderte Bereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.  
Wenn das Bild ein Metafile (WMF/EMF) oder SVG ist, wird keine Kompression angewendet. Außerdem wird die JPEG‑Qualität je nach Auflösung beibehalten oder leicht reduziert, ähnlich wie PowerPoint bei hochauflösenden JPEGs.
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu setzen.

Dieser PHP‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:

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
    # Form so einstellen, dass das Seitenverhältnis beim Ändern der Größe beibehalten wird
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="HINWEIS" color="warning" %}}
Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das darin enthaltene Bild.
{{% /alert %}}

## **Verwenden der StretchOff‑Eigenschaft**

Mit den Methoden [setStretchOffsetLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) und [setStretchOffsetBottom](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) können Sie ein Füllrechteck festlegen.

Wenn für ein Bild ein Stretch‑Verhalten angegeben wird, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der jeweiligen Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt ein Inset an, ein negativer Prozentsatz ein Outset.

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Rechteck `AutoShape` hinzu.
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllmodus der Form fest.
7. Fügen Sie ein Bild hinzu, um die Form zu füllen.
8. Geben Sie Bildversätze von der jeweiligen Kante der Begrenzungsbox der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert einen Vorgang, bei dem eine StretchOff‑Eigenschaft verwendet wird:

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
    # Fügt eine AutoShape vom Typ Rechteck hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Setzt den Fülltyp der Form
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Setzt den Bildfüllmodus der Form
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Setzt das Bild, das die Form füllen soll
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Gibt die Bildversätze relativ zu den jeweiligen Kanten der Begrenzungsbox der Form an
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

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame] zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen dutzender großer Bilder auf die PPTX‑Größe und Leistung aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verknüpfen von Bildern hilft, die Präsentationsgröße klein zu halten, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/getpictureframelock/) für einen [PictureFrame] (z. B. zum Deaktivieren von Verschieben oder Größändern). Der Sperrmechanismus wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame].

**Bleibt die Vektor‑Genauigkeit von SVG erhalten, wenn eine Präsentation in PDF/Bilder exportiert wird?**

Aspose.Slides ermöglicht das Extrahieren eines SVGs aus einem [PictureFrame] als Originalvektor. Beim [Exportieren nach PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/php-java/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.