---
title: PPT und PPTX zu JPG in PHP konvertieren
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
description: "Konvertieren Sie PowerPoint (PPT, PPTX) Folien in hochwertige JPG-Bilder in PHP mit Aspose.Slides für PHP mithilfe schneller, zuverlässiger Codebeispiele."
---

## **Über die Konvertierung von PowerPoint zu JPG**

Mit [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) können Sie PowerPoint‑PPT‑ oder PPTX‑Präsentationen in JPG‑Bilder konvertieren. Es ist außerdem möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen lässt sich leicht Ihr eigener Präsentations‑Viewer implementieren, das Miniaturbild für jede Folie erstellen. Das kann nützlich sein, wenn Sie die Folien vor Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einzelner Folien in Bildformate.  

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, können Sie diese kostenlosen Online‑Konverter ausprobieren: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX nach JPG konvertieren**
Hier sind die Schritte zur Konvertierung von PPT/PPTX in JPG:

1. Erstellen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie das Folienobjekt des Typs [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) .
3. Erzeugen Sie das Miniaturbild jeder Folie und konvertieren Sie es anschließend in JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) wird verwendet, um ein Miniaturbild einer Folie zu erhalten; sie gibt ein [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images)-Objekt zurück. Die Methode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) muss von der gewünschten Folie des Typs [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) aufgerufen werden, die Maßstäbe des resultierenden Miniaturbilds werden an die Methode übergeben.
4. Nachdem Sie das Folien‑Miniaturbild erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) vom Miniaturbild‑Objekt auf. Übergeben Sie den resultierenden Dateinamen und das Bildformat.  

{{% alert color="primary" %}}

**Hinweis**: Die PPT/PPTX‑zu‑JPG‑Konvertierung unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides‑API. Für andere Formate verwenden Sie normalerweise die Methode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), hier benötigen Sie jedoch die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).  

{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Erstellt ein Bild in voller Größe
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


## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen konvertieren**
Um die Größe des resultierenden Miniaturbilds und JPG‑Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* festlegen, indem Sie sie an die [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-)‑Methoden übergeben:  
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definiert Abmessungen
    $desiredX = 1200;
    $desiredY = 800;
    # Ermittelt skalierte Werte von X und Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Erstellt ein Bild in voller Größe
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


## **Kommentare beim Speichern von Folien als Bilder rendern**
Aspose.Slides für PHP über Java bietet eine Funktion, mit der Sie Kommentare in den Folien einer Präsentation rendern können, wenn Sie diese Folien in Bilder konvertieren. Dieser PHP‑Code demonstriert die Vorgehensweise:  
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

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) zur Verfügung. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg)‑ oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter.

Mit denselben in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: konvertieren [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); konvertieren [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); konvertieren [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), konvertieren [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); konvertieren [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), konvertieren [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).  

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch leicht von PowerPoint abweichen, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Einschränkungen bei der Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strikten Beschränkungen für die Anzahl der zu verarbeitenden Folien fest. Allerdings können bei großen Präsentationen oder hochauflösenden Bildern Out‑of‑Memory‑Fehler auftreten.

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT/PPTX in Bilder finden Sie unter:

- [PPT/PPTX zu SVG-Konvertierung](/slides/de/php-java/render-a-slide-as-an-svg-image/)