---
title: Verwalten von Präsentations-BLOBs in JavaScript für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in JavaScript mit Aspose.Slides für Node.js, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---
## **Übersicht**

Aspose.Slides bietet eine BLOB‑basierte Verarbeitung großer Binärdaten in Präsentationen, um den Speicherverbrauch bei der Arbeit mit großen Bildern, Audio‑, Video‑ und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie Sie die BLOB‑Verarbeitung nutzen, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Außerdem wird erklärt, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie Sie den Ordner ändern, in dem sie gespeichert werden.

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in Binärformaten gespeichert wird.

Aspose.Slides for Node.js via Java ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass der Inhalt der Präsentation kopiert wird und das Laden langsam wird. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Pfad zur Präsentationsdatei und nicht den Stream zu verwenden.
{{% /alert %}}

## **Verwenden von BLOB zur Reduzierung des Speicherverbrauchs**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/nodejs-java/) for Node.js via Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu reduzieren.

Dieses JavaScript zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die "veryLargeVideo.avi" Datei zuzugreifen.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        // während des gesamten Lebenszyklus des pres-Objekts niedrig.
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Große Datei über BLOB aus einer Präsentation exportieren**

Aspose.Slides for Node.js via Java ermöglicht das Exportieren großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise können Sie eine große Mediendatei aus einer Präsentation extrahieren, ohne dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig.

Dieses JavaScript‑Beispiel demonstriert die beschriebene Operation:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Erstellt die Instanz der Präsentation und sperrt die "hugePresentationWithAudiosAndVideos.pptx"-Datei.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    // um die Daten vom Videostream der Präsentation zu einem Stream einer neu erstellten Videodatei zu übertragen.
    var buffer = new byte[8 * 1024];
    // Durchläuft die Videos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst das Zugreifen auf Eigenschaften vermieden haben
        // wie video.BinaryData - weil diese Eigenschaft ein Byte-Array mit dem gesamten Video zurückgibt, was dann
        // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
        // erfordert, dass wir das gesamte Video in den Speicher laden.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Der Speicherverbrauch bleibt niedrig, unabhängig von der Größe des Videos oder der Präsentation.
    }
    // Falls nötig, können Sie dieselben Schritte für Audiodateien anwenden.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Bild als BLOB in die Präsentation einfügen**

Mit Methoden der [**ImageCollection**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ImageCollection)‑Klasse und [**ImageCollection** ](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ImageCollection)‑Klasse können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird.

Dieser JavaScript‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

```javascript
var pathToLargeImage = "large_image.jpg";
// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
        // NICHT beabsichtigen, auf die "largeImage.png" Datei zuzugreifen.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        // während des gesamten Lebenszyklus des pres-Objekts niedrig.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Speicher und große Präsentationen**

In der Regel benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht weiter verwendet.

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem JavaScript‑Code beschrieben:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher.

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit geringem Speicherverbrauch laden. Dieser JavaScript‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Einstellungen für den Speicherort mit `setTempFilesRootPath` ändern:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Wenn Sie `setTempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen.
{{% /alert %}}

### **Präsentationsobjekte freigeben, um Speicher zu löschen**

Bei der Verarbeitung großer Präsentationen sollten Sie sicherstellen, dass die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher wieder freigegeben wird. Rufen Sie `dispose()` auf, nachdem Sie die Präsentation nicht mehr benötigen, um nicht verwaltete Ressourcen freizugeben.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern BLOB‑verarbeitet. Diese Objekte unterliegen BLOB‑Richtlinien, mit denen Sie die Speichernutzung verwalten und bei Bedarf auf temporäre Dateien auslagern können.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und definieren das Lock‑Verhalten der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistungsfähigkeit und wie balanciere ich Geschwindigkeit vs. Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, erhöht jedoch die I/O‑Last. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), um das optimale Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Nutzung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Disk‑Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentations‑Instanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Lock‑Modus), und temporäre Dateien werden verwendet, wenn dies erlaubt ist, wodurch die Speichernutzung während der Verarbeitung vorhersehbar bleibt.