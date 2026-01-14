---
title: Verwalten von Präsentations-BLOBs in PHP für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/php-java/manage-blob/
keywords:
- großes Objekt
- großes Element
- große Datei
- BLOB hinzufügen
- BLOB exportieren
- Bild als BLOB hinzufügen
- Speicher reduzieren
- Speichernutzung
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für PHP via Java, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medien), das in binären Formaten gespeichert wird. 

Aspose.Slides für PHP via Java ermöglicht es Ihnen, BLOBs für Objekte zu verwenden, wodurch der Speicherverbrauch reduziert wird, wenn große Dateien beteiligt sind.

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Präsentationsinhalts und verursacht langsames Laden. Deshalb empfehlen wir, beim Laden einer großen Präsentation den Pfad zur Präsentationsdatei zu verwenden und nicht den Stream.
{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/php-java/) für Java ermöglicht es, große Dateien (in diesem Fall eine große Videodatei) über einen BLOB‑basierten Prozess hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieses Java‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Fügen wir das Video zur Präsentation hinzu - wir wählten das KeepLocked-Verhalten, weil wir
      # nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
      # durch den gesamten Lebenszyklus des Präsentationsobjekts niedrig
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


### **Exportieren Sie eine große Datei über BLOB aus einer Präsentation**
Aspose.Slides für PHP via Java ermöglicht es, große Dateien (in diesem Fall eine Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen zu exportieren. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten diese jedoch nicht in den Arbeitsspeicher Ihres Computers laden. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch gering.

Dieser Code demonstriert den beschriebenen Vorgang:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Sperrt die Quelldatei und lädt sie NICHT in den Speicher
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Erstelle die Instanz der Präsentation und sperre die "hugePresentationWithAudiosAndVideos.pptx" Datei.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Speichere jedes Video in eine Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    # um die Daten vom Video-Stream der Präsentation zu einem Stream für die neu erstellte Videodatei zu übertragen.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Durchläuft die Videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Öffnet den Video-Stream der Präsentation. Bitte beachten Sie, dass wir bewusst das Zugreifen auf Eigenschaften vermieden haben
      # wie video.BinaryData - weil diese Eigenschaft ein Byte-Array mit dem vollständigen Video zurückgibt, was dann
      # dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
      # erfordert, dass das gesamte Video in den Speicher geladen wird.
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
    # Falls nötig, können Sie die gleichen Schritte für Audiodateien anwenden.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **Ein Bild als BLOB zu einer Präsentation hinzufügen**
Mit Methoden aus der [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/)‑Klasse können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

Dieser PHP‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```php
  $pathToLargeImage = "large_image.jpg";
  # erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
      # NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
      # niedrig während des gesamten Lebenszyklus des Präsentationsobjekts.
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

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Arbeitsspeicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht weiter genutzt. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem PHP‑Code beschrieben:
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


Dabei verbraucht diese Methode etwa 1,6 GB temporären Speicher. 

### **Eine große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit geringem Speicherverbrauch laden. Dieser PHP‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:
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


### **Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Möchten Sie die temporären Dateien in einem anderen Ordner ablegen, können Sie die Speichereinstellungen mit `setTempFilesRootPath` ändern:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
Wenn Sie `setTempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen. 
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern über BLOB verarbeitet. Diese Objekte unterliegen BLOB‑Richtlinien, mit denen Sie die Speichernutzung steuern und bei Bedarf in temporäre Dateien auslagern können.

**Wo kann ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation konfigurieren?**

Verwenden Sie [LoadOptions] mit [BlobManagementOptions]. Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten beim Sperren der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie finde ich das Gleichgewicht zwischen Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOB im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; wird das Speicherlimit reduziert, wird mehr Arbeit auf temporäre Dateien verlagert, wodurch der RAM‑Verbrauch sinkt, jedoch zusätzliche I/O‑Kosten entstehen. Verwenden Sie die Methode [setMaxBlobsBytesInMemory], um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**

Ja. [BlobManagementOptions] sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den maximalen RAM‑Verbrauch deutlich senken und die Verarbeitung sehr großer Präsentationen stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.