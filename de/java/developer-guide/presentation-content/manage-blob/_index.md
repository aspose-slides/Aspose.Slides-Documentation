---
title: Verwalten von Präsentations-BLOBs in Java für effiziente Speichernutzung
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
- Speicherverbrauch
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Java, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird.  

Aspose.Slides for Java ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.  

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zu einer Kopie des Präsentationsinhalts und verursacht ein langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.  
{{% /alert %}}

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/java/) für Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen Prozess mit BLOBs, um den Speicherverbrauch zu reduzieren.  

Dieses Java‑Beispiel zeigt, wie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzugefügt wird:  
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        // gering während der gesamten Lebensdauer des pres-Objekts
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

Aspose.Slides für Java ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen Prozess mit BLOBs aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering.  

Dieser Java‑Code demonstriert die beschriebene Operation:  
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Locks the source file and does NOT load it into memory
// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
 // Erstellt die Instanz von Presentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // Speichern wir jedes Video in einer Datei. Um einen hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // um die Daten vom Video-Stream der Präsentation zu einem Stream für eine neu erstellte Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    // Durchläuft die Videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // Öffnet den Video-Stream der Präsentation. Bitte beachten Sie, dass wir absichtlich das Zugreifen auf Eigenschaften vermieden haben
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // wie video.BinaryData - weil diese Eigenschaft ein Byte-Array zurückgibt, das das gesamte Video enthält, was dann
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
        //  require us to load the whole video into the memory.
        //  erfordert nicht, dass wir das gesamte Video in den Speicher laden.
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
    // Falls nötig, können Sie dieselben Schritte für Audiodateien anwenden. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```



### **Ein Bild als BLOB zu einer Präsentation hinzufügen**

Mit Methoden des [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection)-Interfaces und der [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection)-Klasse können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.  

Dieser Java‑Code zeigt, wie ein großes Bild über den BLOB‑Prozess hinzugefügt wird:  
```java
String pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
		// gering während des gesamten Lebenszyklus des pres-Objekts.
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

In der Regel benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.  

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem Java‑Code beschrieben:  
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

Durch den Prozess mit einem BLOB können Sie eine große Präsentation mit wenig Speicher laden. Dieser Java‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:  
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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen mit `TempFilesRootPath` ändern:  
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
Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern mithilfe von BLOB verarbeitet. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die es ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf in temporäre Dateien auszulagern.  

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**  
Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Stammpfad für temporäre Dateien und bestimmen das Lock‑Verhalten der Quelle.  

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegenüber Speicher?**  
Ja. Das Halten von BLOB im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O‑Aufwand. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), um das optimale Gleichgewicht für Ihre Arbeitslast und Umgebung zu erreichen.  

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**  
Ja. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.  

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Festplattendateien verwenden?**  
Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Lock‑Modus), und temporäre Dateien werden verwendet, wenn erlaubt, wodurch der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.  