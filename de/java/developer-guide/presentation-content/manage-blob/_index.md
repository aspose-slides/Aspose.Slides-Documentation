---
title: Verwalten von Präsentations‑BLOBs in Java für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Verwalten Sie BLOB‑Daten in Aspose.Slides für Java, um PowerPoint‑ und OpenDocument‑Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides for Java ermöglicht die Verwendung von BLOBs für Objekte, wodurch bei großen Dateien der Speicherverbrauch reduziert wird. 

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass die Inhalte der Präsentation kopiert werden und das Laden langsam wird. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.
{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

Aspose.Slides for Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen Prozess, der BLOBs verwendet, um den Speicherverbrauch zu reduzieren. 

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

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
        // der Speicherverbrauch während des gesamten Lebenszyklus des pres-Objekts niedrig 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Große Datei über BLOB aus einer Präsentation exportieren**

Aspose.Slides for Java ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten aber nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch gering. 

Dieser Java‑Code demonstriert den beschriebenen Vorgang:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// erstellt die Instanz der Präsentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
    // um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich vermieden haben, auf Eigenschaften zuzugreifen
        // wie video.BinaryData - weil diese Eigenschaft ein Byte-Array zurückgibt, das ein vollständiges Video enthält, das dann
        // Bytes in den Speicher lädt. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
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
        // Der Speicherverbrauch bleibt niedrig, unabhängig von der Größe des Videos oder der Präsentation.
    }
    // Bei Bedarf können Sie die gleichen Schritte für Audiodateien anwenden.
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Bild als BLOB in einer Präsentation hinzufügen**

Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection)‑ und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird. 

Dieser Java‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```java
String pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
		// niedrig während des gesamten Lebenszyklus des pres-Objekts.
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

Um typischerweise eine große Präsentation zu laden, benötigen Computer viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem Java‑Code beschrieben:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit geringem Speicherverbrauch laden. Dieser Java‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:
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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im standardmäßigen temporären Ordner. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speicheroptionen mit `TempFilesRootPath` ändern:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell erstellen. 
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern im BLOB‑Handling berücksichtigt. Diese Objekte unterliegen BLOB‑Richtlinien, mit denen Sie die Speichernutzung verwalten und bei Bedarf in temporäre Dateien auslagern können.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Dort setzen Sie das In‑Memory‑Limit für BLOB, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten der Quellen‑Sperrung.

**Beeinflussen BLOB‑Einstellungen die Leistung, und wie balanciere ich Geschwindigkeit vs. Speicher?**

Ja. Das Halten von BLOB im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; eine Verringerung des Speicherlimits verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, kostet jedoch zusätzlichen I/O‑Aufwand. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Größe)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Nutzung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Präsentationen stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Festplattendateien verwenden?**

Ja. Die selben Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Sperrmodus), und temporäre Dateien werden verwendet, wenn erlaubt, wodurch der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.