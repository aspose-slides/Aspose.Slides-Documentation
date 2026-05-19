---
title: Verwalten von Präsentations‑BLOBs in PHP für effiziente Speichernutzung
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
- Speicherauslastung
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für PHP via Java, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---
## **Übersicht**

Aspose.Slides bietet eine BLOB‑basierte Verarbeitung großer Binärdaten in Präsentationen, um den Speicherverbrauch beim Arbeiten mit großen Bildern, Audio‑ und Videodateien sowie Präsentationen zu reduzieren.

Dieser Artikel zeigt, wie man BLOB‑basierte Verarbeitung verwendet, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Außerdem wird erklärt, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie man den Ordner ändert, in dem sie gespeichert werden.

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das im Binärformat gespeichert wird.  

Aspose.Slides for PHP via Java ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Präsentationsinhalts und verursacht langsames Laden. Daher empfehlen wir, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.
{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/php-java/) für Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess zur Reduzierung des Speicherverbrauchs.

Dieses Java‑Beispiel zeigt, wie man eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügt:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Lassen Sie uns das Video zur Präsentation hinzufügen – wir haben das KeepLocked‑Verhalten gewählt, weil wir
      # nicht beabsichtigen, die Datei "veryLargeVideo.avi" zuzugreifen.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
      # niedrig während des Lebenszyklus des pres‑Objekts.
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
Aspose.Slides for PHP via Java ermöglicht den Export großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise kann es nötig sein, eine große Mediendatei aus einer Präsentation zu extrahieren, ohne die Datei in den Arbeitsspeicher zu laden. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig.

Dieser Code demonstriert die beschriebene Vorgangsweise:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Sperrt die Quelldatei und lädt sie NICHT in den Speicher
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Erstelle die Instanz der Präsentation und sperre die Datei "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Speichern wir jedes Video in eine Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    # um die Daten aus dem Videostream der Präsentation in einen Stream für die neu erstellte Videodatei zu übertragen.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Durchläuft die Videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst vermieden haben, Eigenschaften zuzugreifen
      # wie video.BinaryData – weil diese Eigenschaft ein Byte‑Array mit dem vollständigen Video zurückgibt, was dann
      # verursacht, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
      # erfordert, das gesamte Video in den Speicher zu laden.
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
Mit Methoden der Klasse [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/)-Klasse können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

Dieser PHP‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

```php
  $pathToLargeImage = "large_image.jpg";
  # erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Lassen Sie uns das Bild zur Präsentation hinzufügen – wir wählen das KeepLocked‑Verhalten, weil wir
      # NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
      # niedrig während des Lebenszyklus des pres‑Objekts.
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

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht mehr verwendet.  

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standard‐Methode zum Laden der Präsentation ist in diesem PHP‑Code beschrieben:

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

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser PHP‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:

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

### **Den Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Möchten Sie die temporären Dateien in einem anderen Ordner speichern, können Sie die Einstellung mit `setTempFilesRootPath` ändern:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Wenn Sie `setTempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen.
{{% /alert %}}

### **Präsentationsobjekte freigeben, um Speicher zu entlasten**

Bei der Verarbeitung großer Präsentationen sollten Sie sicherstellen, dass die [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)-Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher wieder freigegeben wird. Rufen Sie nach Abschluss der Arbeit mit der Präsentation `dispose()` auf, um nicht verwaltete Ressourcen freizugeben.

```php
$presentation = new Presentation("large.pptx");

# ...die Präsentation verarbeiten...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Ressourcen explizit freigeben.
$presentation->dispose();
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**  
Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt bei Laden oder Speichern der BLOB‑Verarbeitung. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die es ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**  
Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/blobmanagementoptions/). Dort setzen Sie das Speicherlimit für BLOBs, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und bestimmen das Lock‑Verhalten der Quelle.

**Beeinflussen BLOB‑Einstellungen die Performance und wie balanciere ich Geschwindigkeit versus Speicher?**  
Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicherlimit verlagert mehr Arbeit auf temporäre Dateien, reduziert RAM, verursacht jedoch zusätzlichen I/O‑Aufwand. Nutzen Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabytes)?**  
Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den Spitzen‑RAM‑Verbrauch deutlich senken und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Disk‑Dateien verwenden?**  
Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Lock‑Modus), und temporäre Dateien werden verwendet, wenn dies erlaubt ist, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.