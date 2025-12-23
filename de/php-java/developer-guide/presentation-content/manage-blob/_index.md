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
- Speicherverbrauch
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten von BLOB-Daten in Aspose.Slides für PHP via Java, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird.  

Aspose.Slides für PHP über Java ermöglicht die Verwendung von BLOBs für Objekte auf eine Weise, die den Speicherverbrauch reduziert, wenn große Dateien beteiligt sind.

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass der Inhalt der Präsentation kopiert wird und ein langsames Laden verursacht. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht deren Stream zu verwenden.
{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/php-java/) für Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu reduzieren.

Dieses Java‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Lassen Sie uns das Video zur Präsentation hinzufügen - wir haben das KeepLocked-Verhalten gewählt, weil wir
      # nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
      # der Speicherverbrauch durch die Lebensdauer des pres-Objekts gering
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


### **Eine große Datei über BLOB aus einer Präsentation exportieren**

Aspose.Slides für PHP über Java ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, wollen jedoch nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig.

Dieser Code demonstriert den beschriebenen Vorgang:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Sperrt die Quelldatei und läd sie NICHT in den Speicher
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # erstellt die Instanz der Präsentation und sperrt die "hugePresentationWithAudiosAndVideos.pptx"-Datei.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
    # um die Daten vom Videostream der Präsentation in einen Stream für die neu erstellte Videodatei zu übertragen.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Durchläuft die Videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich vermieden haben, auf Eigenschaften zuzugreifen
      # wie video.BinaryData - weil diese Eigenschaft ein Byte‑Array mit dem gesamten Video zurückgibt, was dann
      # Bytes in den Speicher lädt. Wir verwenden video.GetStream, das einen Stream zurückgibt – und das NICHT
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

Mit Methoden des [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) Interface und der [**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection) Klasse können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

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
      # bleibt niedrig während des Lebenszyklus des pres-Objekts
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

Im Allgemeinen benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht weiter verwendet.  

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem PHP‑Code beschrieben:
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


Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher.  

### **Eine große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser PHP‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:
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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen mit `TempFilesRootPath` ändern:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen.
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**  
Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt der BLOB‑Verarbeitung, wenn sie geladen oder gespeichert wird. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die Ihnen ermöglichen, die Speichernutzung zu verwalten und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**  
Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) mit [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). Dort setzen Sie das In‑Memory‑Limit für BLOB, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und bestimmen das Verhalten beim Sperren der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegenüber Speicher?**  
Ja. Das Halten von BLOB im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; eine Verringerung des Speicherlimits verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, aber verursacht zusätzlichen I/O. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**  
Ja. [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Durch Aktivieren temporärer Dateien und Verwendung des Source‑Locking kann der maximale RAM‑Verbrauch erheblich reduziert und die Verarbeitung sehr großer Decks stabilisiert werden.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateien verwenden?**  
Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn erlaubt, sodass die Speichernutzung während der Verarbeitung vorhersehbar bleibt.