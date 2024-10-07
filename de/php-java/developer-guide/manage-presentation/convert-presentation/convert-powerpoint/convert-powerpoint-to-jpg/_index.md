---
title: PowerPoint in JPG konvertieren
type: docs
weight: 60
url: /php-java/convert-powerpoint-to-jpg/
keywords: "PowerPoint in JPG konvertieren, PPTX in JPEG, PPT in JPEG"
description: "PowerPoint in JPG konvertieren: PPT in JPG, PPTX in JPG"
---

## **Über die Konvertierung von PowerPoint in JPG**
Mit der [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) können Sie PowerPoint PPT oder PPTX Präsentationen in JPG-Bilder konvertieren. Es ist auch möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen ist es einfach, Ihre eigene Präsentationsanzeige zu implementieren und das Thumbnail für jede Folie zu erstellen. Dies kann nützlich sein, wenn Sie die Präsentationsfolien vor Urheberrechtsschutz schützen oder die Präsentation im Nur-Lesen-Modus anzeigen möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer bestimmten Folie in Bildformate.

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder konvertiert, möchten Sie vielleicht diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT in JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG konvertieren**
Hier sind die Schritte, um PPT/PPTX in JPG zu konvertieren:

1. Erstellen Sie eine Instanz vom Typ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. Erstellen Sie das Thumbnail jeder Folie und konvertieren Sie es dann in JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) wird verwendet, um ein Thumbnail einer Folie zu erhalten; sie gibt ein [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) Objekt als Ergebnis zurück. Die Methode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) muss von der benötigten Folie vom Typ [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) aufgerufen werden; die Maßstäbe des resultierenden Thumbnails werden in die Methode übergeben.
4. Nachdem Sie das Folien-Thumbnail erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) vom Thumbnail-Objekt auf. Übergeben Sie den resultierenden Dateinamen und das Bildformat.

{{% alert color="primary" %}}

**Hinweis**: Die Konvertierung von PPT/PPTX in JPG unterscheidet sich von der Konvertierung in andere Typen in der Aspose.Slides API. Für andere Typen verwenden Sie normalerweise die Methode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), aber hier benötigen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Präsentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Erstellt ein Vollbildbild
      $slideImage = $sld->getImage(1.0, 1.0);
      # Speichert das Bild auf der Festplatte im JPEG-Format
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

## **PowerPoint PPT/PPTX in JPG mit angepassten Dimensionen konvertieren**
Um die Dimension des resultierenden Thumbnails und des JPG-Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* festlegen, indem Sie sie in die Methoden [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) übergeben:

```php
  $pres = new Presentation("PowerPoint-Präsentation.pptx");
  try {
    # Definiert Dimensionen
    $desiredX = 1200;
    $desiredY = 800;
    # Holt die skalierten Werte von X und Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Erstellt ein Vollbildbild
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Speichert das Bild auf der Festplatte im JPEG-Format
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

## **Kommentare beim Speichern der Präsentation in ein Bild rendern**
Aspose.Slides für PHP über Java bietet eine Funktion, die es Ihnen ermöglicht, Kommentare in den Folien einer Präsentation zu rendern, wenn Sie diese Folien in Bilder konvertieren. Dieser PHP-Code demonstriert die Operation:

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

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Web-App](https://products.aspose.app/slides/collage). Mit diesem Online-Dienst können Sie [JPG in JPG](https://products.aspose.app/slides/collage/jpg) oder PNG in PNG Bilder zusammenführen, [Foto-Raster](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter. 

Mit denselben Prinzipien, die in diesem Artikel beschrieben sind, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: [Bild in JPG konvertieren](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); [JPG in Bild konvertieren](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); [JPG in PNG konvertieren](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), [PNG in JPG konvertieren](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); [PNG in SVG konvertieren](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), [SVG in PNG konvertieren](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Siehe andere Optionen zur Konvertierung von PPT/PPTX in Bilder wie:

- [PPT/PPTX in SVG-Konvertierung](/slides/php-java/render-a-slide-as-an-svg-image/).