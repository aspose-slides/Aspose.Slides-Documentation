---
title: Blob verwalten
type: docs
weight: 10
url: /de/php-java/manage-blob/
description: Verwalten Sie Blob in PowerPoint-Präsentationen mit PHP. Verwenden Sie Blob, um den Speicherverbrauch in PowerPoint-Präsentationen mit PHP zu reduzieren. Fügen Sie große Dateien über Blob zu PowerPoint-Präsentationen mit PHP hinzu. Exportieren Sie große Dateien über Blob aus PowerPoint-Präsentationen mit PHP. Laden Sie eine große PowerPoint-Präsentation als Blob mit PHP.
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert ist. 

Aspose.Slides für PHP über Java ermöglicht es Ihnen, BLOBs für Objekte zu verwenden, um den Speicherverbrauch bei großen Dateien zu reduzieren.

{{% alert title="Info" color="info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zu einer Kopie der Inhalte der Präsentation und verursacht langsames Laden. Daher empfehlen wir dringend, dass Sie den Dateipfad der Präsentation und nicht ihren Stream verwenden, wenn Sie eine große Präsentation laden möchten.

{{% /alert %}}

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Fügen Sie große Dateien über BLOB zu einer Präsentation hinzu**

[Aspose.Slides](/slides/de/php-java/) für Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen Prozess mit BLOBs hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieses Java zeigt Ihnen, wie Sie eine große Videodatei über den BLOB-Prozess zu einer Präsentation hinzufügen:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Lassen Sie uns das Video zur Präsentation hinzufügen - wir wählen das Verhalten KeepLocked,
      # da wir die Datei "veryLargeVideo.avi" nicht verwenden wollten.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
      # während des Lebenszyklus des pres-Objekts gering
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Exportieren Sie große Dateien über BLOB aus einer Präsentation**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio- oder Videodatei) über einen Prozess mit BLOBs aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB-Prozess können Sie den Speicherverbrauch gering halten.

Dieser Code demonstriert den beschriebenen Vorgang:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Sperrt die Quelldatei und lädt sie NICHT in den Speicher
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Erstellt die Instanz der Präsentation, sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Lassen Sie uns jedes Video in eine Datei speichern. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer,
    # der verwendet wird, um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Iteriert durch die Videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Öffnet den Präsentationsvideostream. Bitte beachten Sie, dass wir absichtlich darauf verzichtet haben, auf Eigenschaften
      # wie video.BinaryData zuzugreifen - da diese Eigenschaft ein Byte-Array zurückgibt, das ein vollständiges Video enthält, was dann
      # dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und erfordert NICHT,
      # dass wir das gesamte Video in den Speicher laden.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Der Speicherverbrauch bleibt niedrig, unabhängig von der Größe des Videos oder der Präsentation.
    }
    # Falls erforderlich, können Sie die gleichen Schritte auch für Audiodateien anwenden.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Fügen Sie ein Bild als BLOB in eine Präsentation ein**
Mit Methoden der [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) Schnittstelle und der [**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection) Klasse können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird.

Dieser PHP-Code zeigt Ihnen, wie Sie ein großes Bild über den BLOB-Prozess hinzufügen:

```php
  $pathToLargeImage = "large_image.jpg";
  # Erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das Verhalten KeepLocked,
      # weil wir die Datei "largeImage.png" NICHT verwenden wollten.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
      # während des Lebenszyklus des pres-Objekts gering
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer viel temporären Speicher, um eine große Präsentation zu laden. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint-Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem PHP-Code beschrieben:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Aber diese Methode verbraucht etwa 1,6 GB temporären Speicher. 

### **Laden Sie eine große Präsentation als BLOB**

Durch den Prozess mit einem BLOB können Sie eine große Präsentation laden, während Sie wenig Speicher verwenden. Dieser PHP-Code beschreibt die Implementierung, bei der der BLOB-Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ändern Sie den Ordner für temporäre Dateien**

Wenn der BLOB-Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie möchten, dass die temporären Dateien in einem anderen Ordner gespeichert werden, können Sie die Einstellungen für den Speicher mit `TempFilesRootPath` ändern:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}

Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner, um temporäre Dateien zu speichern. Sie müssen den Ordner manuell erstellen. 

{{% /alert %}}