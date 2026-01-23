---
title: Verwalten von Bildrahmen in Präsentationen mit PHP
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
  - Zugeschnittener Bereich
  - StretchOff-Eigenschaft
  - Bildrahmen-Formatierung
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
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design Ihrer Folien."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können einem Folienobjekt ein Bild über einen Bildrahmen hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter — [JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie über die Methode `addPictureFrame`, die vom Form-Objekt der referenzierten Folie bereitgestellt wird, ein [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) basierend auf der Bildbreite und -höhe.
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser PHP‑Code zeigt Ihnen, wie Sie einen Bildrahmen erstellen:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziert die Image-Klasse
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

Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien auf der Basis von Bildern. Wenn Sie den Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabevorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Sie können diese Seiten ansehen: Bild zu JPG konvertieren — [convert image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); JPG zu Bild — [convert JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); JPG zu PNG — [convert JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), PNG zu JPG — [convert PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); PNG zu SVG — [convert PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), SVG zu PNG — [convert SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser PHP‑Code zeigt Ihnen, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:
```php
  # Instanziert die Presentation-Klasse, die die PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Setzt relative Skalierung von Breite und Höhe
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

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)-Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das folgende Beispiel demonstriert, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.
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

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für PHP via Java das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung einer Folie können Sie jede [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrundeliegende [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) SVG‑Inhalt enthält, und das Bild anschließend im nativen SVG‑Format auf Datenträger oder in einen Stream speichern.

Der folgende Code demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:
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

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser PHP‑Code demonstriert die Vorgehensweise:
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


## **Bildrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er bestimmte Anforderungen erfüllt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)-Objekt, indem Sie ein Bild zur [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie über die Methode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) ein `PictureFrame` basierend auf der Bildbreite und -höhe, das von der mit der referenzierten Folie verknüpften [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereitgestellt wird.
6. Fügen Sie den Bildrahmen (der das Bild enthält) der Folie hinzu.
7. Setzen Sie die Linienfarbe des Bildrahmens.
8. Setzen Sie die Linienstärke des Bildrahmens.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (der das Bild enthält) erneut der Folie hinzu.
11. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser PHP‑Code demonstriert den Formatierungsprozess für Bildrahmen:
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

Aspose hat kürzlich einen [kostenlosen Collage‑Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals JPG/JPEG‑ oder PNG‑Bilder zusammenführen, [Grids aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Bild als Link einfügen**

Um große Präsentationsdateien zu vermeiden, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser PHP‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:
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

Dieser PHP‑Code zeigt, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:
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
    # Beschneidet das Bild (Prozentwerte)
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


## **Zugeschnittene Bildbereiche eines Bildrahmens löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes entfernen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) verwenden. Diese Methode gibt das beschnittene Bild oder das Originalbild zurück, wenn kein Zuschneiden erforderlich ist.

Dieser PHP‑Code demonstriert die Vorgehensweise:
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Holt den Bildrahmen von der ersten Folie
    $picFrame = $slide->getShapes()->get_Item(0);
    # Löscht zugeschnittene Bereiche des Bildrahmen-Bildes und gibt das zugeschnittene Bild zurück
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

Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) fügt das beschnittene Bild zur Bildsammlung der Präsentation hinzu. Wird das Bild ausschließlich im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) verwendet, kann diese Einstellung die Dateigröße der Präsentation reduzieren. Andernfalls erhöht sich die Bildanzahl in der resultierenden Präsentation.

Während des Zuschneidevorgangs wird eine WMF/EMF‑Metadatei in ein Raster‑PNG‑Bild konvertiert. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu aktivieren.

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
    # Form so einstellen, dass beim Ändern der Größe das Seitenverhältnis erhalten bleibt
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht aber das des darin enthaltenen Bildes.

{{% /alert %}}

## **Die StretchOff‑Eigenschaft verwenden**

Mit den Methoden [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) und [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) der Klasse [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) können Sie ein Füllrechteck festlegen.

Wenn für ein Bild das Strecken angegeben ist, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet Einziehen, ein negativer Prozentsatz bedeutet Ausdehnen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Rechteck‑`AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Setzen Sie den Fülltyp der Form.
6. Setzen Sie den Bildfüllmodus der Form.
7. Fügen Sie ein Bild zum Füllen der Form hinzu.
8. Geben Sie Bildversätze relativ zu den entsprechenden Kanten der Begrenzungsbox der Form an.
9. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser PHP‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
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
    # Fügt ein AutoShape vom Typ Rechteck hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Setzt den Fülltyp der Form
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Setzt den Bildfüllmodus der Form
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Setzt das Bild zum Füllen der Form
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Gibt die Bildversätze relativ zur jeweiligen Kante der Begrenzungsbox der Form an
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

**Wie finde ich heraus, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) zugewiesen ist. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Performance aus?**

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) für einen [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (z. B. Verschieben oder Größenändern deaktivieren). Der Sperrmechanismus wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).

**Wird die Vektor­treue von SVG beim Exportieren einer Präsentation in PDF/Bilder erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Exportieren nach PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/php-java/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.