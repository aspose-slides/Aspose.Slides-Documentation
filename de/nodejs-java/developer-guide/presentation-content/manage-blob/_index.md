---
title: Blob verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-blob/
description: Verwalten Sie Blob in PowerPoint-Präsentationen mit JavaScript. Verwenden Sie Blob, um den Speicherverbrauch in PowerPoint-Präsentationen mit JavaScript zu reduzieren. Große Dateien über Blob zu einer PowerPoint-Präsentation mit JavaScript hinzufügen. Große Dateien über Blob aus einer PowerPoint-Präsentation mit JavaScript exportieren. Eine große PowerPoint-Präsentation als Blob mit JavaScript laden.
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird.  

Aspose.Slides for Node.js via Java ermöglicht es Ihnen, BLOBs für Objekte zu verwenden, wodurch der Speicherverbrauch reduziert wird, wenn große Dateien beteiligt sind.

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Inhalts der Präsentation und verursacht ein langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Pfad zur Präsentationsdatei und nicht den Stream zu verwenden.
{{% /alert %}}

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/nodejs-java/) for Node.js via Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen BLOB‑basierten Prozess hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieser JavaScript‑Code zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Lassen Sie uns das Video zur Präsentation hinzufügen - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
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

Aspose.Slides for Node.js via Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten aber nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering.

Dieser JavaScript‑Code demonstriert die beschriebene Vorgangsweise:
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Locks the source file and does NOT load it into memory
// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
 // Erstelle die Instanz der Präsentation und sperre die Datei "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // um die Daten vom Videostream der Präsentation zu einem Stream für eine neu erstellte Videodatei zu übertragen.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    // Durchläuft die Videos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich das Zugreifen auf Eigenschaften vermieden haben
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // wie video.BinaryData - weil diese Eigenschaft ein Byte‑Array mit dem gesamten Video zurückgibt, was dann
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
        // require us to load the whole video into the memory.
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
        // Memory consumption will remain low regardless of the size of the video or presentation.
        // Der Speicherverbrauch bleibt niedrig, unabhängig von der Größe des Videos oder der Präsentation.
    }
    // If necessary, you can apply the same steps for audio files.
    // Bei Bedarf können Sie die gleichen Schritte für Audiodateien anwenden.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **Bild als BLOB in einer Präsentation hinzufügen**

Mit Methoden der Klasse [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

Dieser JavaScript‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```javascript
var pathToLargeImage = "large_image.jpg";
// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das KeepLocked-Verhalten, weil wir
        // nicht beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
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

In der Regel benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speicher‑Einstellungen mit `setTempFilesRootPath` ändern:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
Wenn Sie `setTempFilesRootPath` verwenden, erstellt Aspose.Slides keinen Ordner zum Speichern temporärer Dateien automatisch. Sie müssen den Ordner manuell erstellen.
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern mittels BLOB‑Verarbeitung behandelt. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die es ermöglichen, die Speichernutzung zu verwalten und bei Bedarf in temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verbieten temporäre Dateien, wählen den Stamm‑Pfad für temporäre Dateien und bestimmen das Verhalten beim Sperren der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegenüber Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; eine niedrigere Speichergrenze verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O‑Aufwand. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. mehrere Gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden von Streams statt von Dateien auf der Festplatte verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn dies erlaubt ist, wodurch der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.