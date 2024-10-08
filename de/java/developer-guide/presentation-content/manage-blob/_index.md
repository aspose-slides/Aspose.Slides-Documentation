---
title: Blob verwalten
type: docs
weight: 10
url: /de/java/manage-blob/
description: Verwalten Sie Blob in PowerPoint-Präsentationen mit Java. Verwenden Sie Blob, um den Speicherverbrauch in PowerPoint-Präsentationen mit Java zu reduzieren. Fügen Sie große Dateien über Blob zu PowerPoint-Präsentationen mit Java hinzu. Exportieren Sie große Dateien über Blob aus PowerPoint-Präsentationen mit Java. Laden Sie eine große PowerPoint-Präsentation als Blob mit Java.
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das im Binärformat gespeichert ist.

Aspose.Slides für Java ermöglicht Ihnen die Verwendung von BLOBs für Objekte, um den Speicherverbrauch bei großen Dateien zu reduzieren.

{{% alert title="Info" color="info" %}}

Um bestimmte Einschränkungen bei der Interaktion mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Inhalts der Präsentation und verursacht langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Präsentationsdateipfad und nicht den Stream zu verwenden.

{{% /alert %}}

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/java/) für Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen Prozess mit BLOBs hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieser Java-Code zeigt Ihnen, wie Sie eine große Videodatei über den BLOB-Prozess zu einer Präsentation hinzufügen:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, der das Video hinzugefügt wird
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Lassen Sie uns das Video zur Präsentation hinzufügen - wir haben das KeepLocked-Verhalten gewählt, da wir
        // nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        // während des Lebenszyklus des pres-Objekts gering 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Große Datei über BLOB aus der Präsentation exportieren**
Aspose.Slides für Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio- oder Videodatei) über einen Prozess mit BLOBs aus Präsentationen zu exportieren. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch das Exportieren der Datei über den BLOB-Prozess können Sie den Speicherverbrauch niedrig halten.

Dieser Java-Code demonstriert den beschriebenen Vorgang:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Sperrt die Quelldatei und lädt sie NICHT in den Arbeitsspeicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Erstellen Sie die Instanz der Präsentation, sperren Sie die Datei "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Lassen Sie uns jedes Video in eine Datei speichern. Um einen hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    // um die Daten vom Video-Stream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Iteriert über die Videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öffnet den Video-Stream der Präsentation. Bitte beachten Sie, dass wir absichtlich darauf verzichtet haben, auf Eigenschaften
        // wie video.BinaryData zuzugreifen - da diese Eigenschaft ein Byte-Array zurückgibt, das ein gesamtes Video enthält, was dann
        // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das Stream zurückgibt - und NEIN
        // erfordert, dass wir das gesamte Video im Speicher laden.
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
        // Der Speicherverbrauch bleibt unabhängig von der Größe des Videos oder der Präsentation gering.
    }
    // Falls erforderlich, können Sie die gleichen Schritte auch für Audiodateien anwenden. 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **Bild als BLOB in die Präsentation hinzufügen**
Mit den Methoden des [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) Interfaces und der [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) Klasse können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird.

Dieser Java-Code zeigt Ihnen, wie Sie ein großes Bild über den BLOB-Prozess hinzufügen:

```java
String pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das KeepLocked-Verhalten, da wir dies tun
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
		// während des Lebenszyklus des pres-Objekts gering
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

Typischerweise benötigen Computer viel temporären Speicher, um eine große Präsentation zu laden. Der gesamte Inhalt der Präsentation wird in den Arbeitsspeicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint-Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Java-Code beschrieben:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Aber diese Methode verbraucht rund 1,6 GB temporären Speicher. 

### **Eine große Präsentation als BLOB laden**

Durch den Prozess, der einen BLOB umfasst, können Sie eine große Präsentation mit wenig Speicher laden. Dieser Java-Code beschreibt die Implementierung, bei der der BLOB-Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

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

### **Den Ordner für temporäre Dateien ändern**

Wenn der BLOB-Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie möchten, dass die temporären Dateien in einem anderen Ordner gespeichert werden, können Sie die Einstellungen für den Speicherort mit `TempFilesRootPath` ändern:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner für die Speicherung temporärer Dateien. Sie müssen den Ordner manuell erstellen. 

{{% /alert %}}