---
title: Bilderrahmen
type: docs
weight: 10
url: /de/php-java/picture-frame/
keywords: "Bilderrahmen hinzufügen, Bilderrahmen erstellen, Bild hinzufügen, Bild erstellen, Bild extrahieren, StretchOff-Eigenschaft, Bilderrahmenformatierung, Bilderrahmeneigenschaften, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Bilderrahmen zu PowerPoint-Präsentation hinzufügen"

---

Ein Bilderrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.

Sie können ein Bild über einen Bilderrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bilderrahmen formatieren.

{{% alert title="Tipp" color="primary" %}}

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es den Menschen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.

{{% /alert %}}

## **Bilderrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und verwendet wird, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [Bilderrahmen](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) basierend auf der Breite und Höhe des Bildes über die `AddPictureFrame`-Methode, die vom mit der referenzierten Folie verbundenen Formobjekt bereitgestellt wird.
6. Fügen Sie der Folie einen Bilderrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Bilderrahmen erstellen:

```php
  # Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziiert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
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

Bilderrahmen ermöglichen es Ihnen, schnell Präsentationsfolien basierend auf Bildern zu erstellen. Wenn Sie den Bilderrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie die Ein-/Ausgabeoperationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie möchten möglicherweise diese Seiten sehen: konvertieren [Bild in JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); konvertieren [JPG in Bild](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); konvertieren [JPG in PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), konvertieren [PNG in JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); konvertieren [PNG in SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), konvertieren [SVG in PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Bilderrahmen mit relativem Maßstab erstellen**

Durch Ändern des relativen Maßstabs eines Bildes können Sie einen komplizierteren Bilderrahmen erstellen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und verwendet wird, um die Form auszufüllen.
5. Geben Sie die relative Breite und Höhe des Bildes im Bilderrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Bilderrahmen mit relativem Maßstab erstellen:

```php
  # Instanziiert die Präsentation Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziiert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bilderrahmen mit Höhe und Breite des Bildes hinzu
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Legt relative Maßstäbe für Höhe und Breite fest
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

## **Bild aus Bilderrahmen extrahieren**

Sie können Bilder aus [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame)-Objekten extrahieren und sie im PNG-, JPG- und anderen Formaten speichern. Das folgende Codebeispiel demonstriert, wie Sie ein Bild aus dem Dokument "sample.pptx" extrahieren und es im PNG-Format speichern.

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

## **Transparenz des Bildes erhalten**

Aspose.Slides ermöglicht es Ihnen, die Transparenz eines Bildes zu erhalten. Dieser PHP-Code demonstriert die Operation:

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Bildtransparenz: " . $transparencyValue);
    }
  }
```

## **Bilderrahmenformatierung**

Aspose.Slides bietet viele Formatierungsoptionen, die auf einen Bilderrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bilderrahmen ändern, um ihn bestimmten Anforderungen anzupassen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und verwendet wird, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `Bilderrahmen` basierend auf der Breite und Höhe des Bildes über die [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) Methode, die vom [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekt bereitgestellt wird, das mit der referenzierten Folie verbunden ist.
6. Fügen Sie den Bilderrahmen (der das Bild enthält) zur Folie hinzu.
7. Legen Sie die Liniefarbe des Bilderrahmens fest.
8. Legen Sie die Linienstärke des Bilderrahmens fest.
9. Drehen Sie den Bilderrahmen, indem Sie ihm entweder einen positiven oder negativen Wert geben.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bilderrahmen (der das Bild enthält) zur Folie hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code demonstriert den Formatierungsprozess für Bilderrahmen:

```php
  # Instanziiert die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Instanziiert die Image-Klasse
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
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

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG-Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Dienst nutzen.

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzubetten. Dieser PHP-Code zeigt Ihnen, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount); $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture:
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media:
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

## **Bild zuschneiden**

Dieser PHP-Code zeigt Ihnen, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:

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
    # Fügt einen Bilderrahmen zu einer Folie hinzu
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Schneidet das Bild (Prozentwerte)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Speicher das Ergebnis
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Gelöschte zugeschnittene Bereiche von Bildern

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) Methode verwenden. Diese Methode gibt das zugeschnittene Bild oder das ursprüngliche Bild zurück, wenn das Zuschneiden nicht notwendig ist.

Dieser PHP-Code demonstriert die Operation:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Holt den Bilderrahmen von der ersten Folie
    $picFrame = $slide->getShapes()->get_Item(0);
    # Löscht die zugeschnittenen Bereiche des Bilderrahmenbildes und gibt das zugeschnittene Bild zurück
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Speicher das Ergebnis
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="HINWEIS" color="warning" %}}

Die [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) Methode fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [Bilderrahmen](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) verwendet wird, kann dieses Setup die Präsentationsgröße verringern. Andernfalls wird die Anzahl der Bilder in der resultierenden Präsentation erhöht.

Diese Methode konvertiert WMF/EMF-Metadateien in ein Raster-PNG-Bild während des Zuschneidevorgangs.

{{% /alert %}}

## **Verhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Verhältnis beibehält, selbst nachdem Sie die Bildabmessungen geändert haben, können Sie die [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) Methode verwenden, um die Einstellung *Verhältnis sperren* festzulegen.

Dieser PHP-Code zeigt Ihnen, wie Sie das Seitenverhältnis einer Form sperren:

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
    # Setzt die Form so, dass das Seitenverhältnis beim Ändern der Größe erhalten bleibt
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="HINWEIS" color="warning" %}}

Diese *Verhältnis sperren*-Einstellung bewahrt nur das Seitenverhältnis der Form und nicht das Bild, das sie enthält.

{{% /alert %}}

## **StretchOff-Eigenschaft verwenden**

Mit den Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) und [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) aus dem [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat)-Interface und der [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat)-Klasse können Sie ein Füllrechteck angeben.

Wenn das Dehnen für ein Bild festgelegt ist, wird ein Quellrechteck so skaliert, dass es innerhalb des festgelegten Füllrechtecks passt. Jeder Rand des Füllrechtecks wird durch einen prozentualen Versatz vom entsprechenden Rand des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt einen Einzug an, während ein negativer Prozentsatz einen Auszug definiert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
3. Fügen Sie ein Rechteck `AutoShape` hinzu.
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllmodus der Form fest.
7. Fügen Sie ein festgelegtes Bild hinzu, um die Form auszufüllen.
8. Geben Sie Bildversätze vom entsprechenden Rand des Begrenzungsrahmens der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code demonstriert einen Prozess, in dem eine StretchOff-Eigenschaft verwendet wird:

```php
  # Instanziiert die Präsentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Instanziiert die ImageEx-Klasse
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt ein AutoShape hinzu, das auf Rechteck eingestellt ist
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Legt den Fülltyp der Form fest
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Legt den Bildfüllmodus der Form fest
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Setzt das Bild, um die Form auszufüllen
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Gibt die Bildversätze vom entsprechenden Rand des Begrenzungsrahmens der Form an
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