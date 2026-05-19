---
title: BLOBs in Präsentationen auf Android verwalten für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/androidjava/manage-blob/
keywords:
- großes Objekt
- großer Gegenstand
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
- Android
- Java
- Aspose.Slides
description: "BLOB-Daten in Aspose.Slides für Android über Java verwalten, um PowerPoint- und OpenDocument-Dateioperationen für effiziente Präsentationsverarbeitung zu optimieren."
---
## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides für Android über Java ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.

{{% alert title="Info" color="info" %}}

Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Inhalts der Präsentation und verursacht ein langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Pfad zur Präsentationsdatei und nicht den Stream zu verwenden.

{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/androidjava/) für Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu reduzieren.

Dieses Java‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Lassen Sie uns das Video zur Präsentation hinzufügen - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        // während des gesamten Lebenszyklus des pres-Objekts niedrig 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Eine große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides für Android über Java ermöglicht den Export großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering.

Dieser Java‑Code demonstriert den beschriebenen Vorgang:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Locks the source file and does NOT load it into memory
// Sperrt die Quelldatei und läd sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
 // Erstellt die Instanz der Präsentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // um die Daten vom Videostream der Präsentation zu einem Stream für die neu erstellte Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    // Durchläuft die Videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst das Zugreifen auf Eigenschaften vermieden haben
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // wie video.BinaryData – weil diese Eigenschaft ein Byte-Array mit dem gesamten Video zurückgibt, was dann
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und das NICHT
        //  require us to load the whole video into the memory.
        //  erfordert, dass wir das gesamte Video in den Speicher laden.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
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
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Ein Bild als BLOB in einer Präsentation hinzufügen**
Mit Methoden aus der Schnittstelle [**IImageCollection**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IImageCollection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ImageCollection) können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird.

Dieser Java‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

```java
String pathToLargeImage = "large_image.jpg";

// Erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
		// niedrig während des gesamten Lebenszyklus des pres-Objekts
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht weiter verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Java‑Code beschrieben:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Eine große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser Java‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um die große Präsentationsdatei (large.pptx) zu laden:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen mithilfe von `TempFilesRootPath` ändern:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides keinen Ordner zum Speichern temporärer Dateien automatisch. Sie müssen den Ordner manuell erstellen. 

{{% /alert %}}

### **Presentation‑Objekte freigeben, um Speicher freizugeben**

Beim Verarbeiten großer Präsentationen sollten Sie sicherstellen, dass die Presentation‑Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher freigegeben wird. Rufen Sie `dispose()` auf, nachdem Sie die Präsentation nicht mehr benötigen, um nicht verwaltete Ressourcen freizugeben.

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt dem BLOB‑Handling, wenn sie geladen oder gespeichert wird. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die es Ihnen ermöglichen, die Speichernutzung zu verwalten und bei Bedarf in temporäre Dateien auszulagern.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie `LoadOptions` zusammen mit `BlobManagementOptions`. Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und bestimmen das Verhalten beim Sperren der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie finde ich das Gleichgewicht zwischen Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOB im Arbeitsspeicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; wird das Speicherlimit gesenkt, wird mehr Arbeit auf temporäre Dateien verlagert, wodurch der RAM‑Verbrauch reduziert wird, aber zusätzliche I/O‑Operationen entstehen. Verwenden Sie die Methode `setMaxBlobsBytesInMemory`, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**

Ja. `BlobManagementOptions` sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Nutzung von Source‑Locking können den Spitzen‑RAM‑Verbrauch deutlich reduzieren und die Verarbeitung sehr großer Präsentationen stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Disk‑Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Presentation‑Instanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn dies erlaubt ist, sodass die Speichernutzung während der Verarbeitung vorhersehbar bleibt.