---
title: Blob verwalten
type: docs
weight: 10
url: /androidjava/manage-blob/
description: Verwalten Sie Blob in PowerPoint-Präsentationen mit Java. Verwenden Sie Blob, um den Speicherverbrauch in PowerPoint-Präsentationen mit Java zu reduzieren. Fügen Sie große Dateien über Blob in PowerPoint-Präsentationen mit Java hinzu. Exportieren Sie große Dateien über Blob aus PowerPoint-Präsentationen mit Java. Laden Sie eine große PowerPoint-Präsentation als Blob mit Java.
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert ist.

Aspose.Slides für Android über Java ermöglicht Ihnen die Verwendung von BLOBs für Objekte auf eine Weise, die den Speicherverbrauch bei großen Dateien reduziert.

{{% alert title="Info" color="info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass die Inhalte der Präsentation kopiert werden, und verursacht ein langsames Laden. Daher empfehlen wir dringend, dass Sie den Dateipfad der Präsentation verwenden und nicht ihren Stream, wenn Sie beabsichtigen, eine große Präsentation zu laden.

{{% /alert %}}

## **Verwenden Sie BLOB, um den Speicherverbrauch zu reduzieren**

### **Fügen Sie große Dateien über BLOB zu einer Präsentation hinzu**

[Aspose.Slides](/slides/androidjava/) für Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) durch einen Prozess zu BLOBs hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieser Java-Code zeigt Ihnen, wie Sie eine große Videodatei über den BLOB-Prozess zu einer Präsentation hinzufügen:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Lassen Sie uns das Video zur Präsentation hinzufügen - wir wählen das Verhalten KeepLocked, weil wir 
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


### **Exportieren Sie große Dateien über BLOB aus der Präsentation**
Aspose.Slides für Android über Java ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio- oder Videodatei) durch einen Prozess zu BLOBs aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB-Prozess behalten Sie den Speicherverbrauch niedrig.

Dieser Java-Code demonstriert den beschriebenen Vorgang:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Sperrt die Quelldatei und LADEN sie NIEMALS in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// erstellt die Instanz der Präsentation, sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Lassen Sie uns jedes Video in eine Datei speichern. Um einen hohen Speicherverbrauch zu vermeiden, 
    // benötigen wir einen Puffer, der verwendet wird, um die Daten vom Videostream der Präsentation zu einem 
    // Stream für die neu erstellte Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Durchläuft die Videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich darauf verzichtet haben, 
        // auf Eigenschaften wie video.BinaryData zuzugreifen - da diese Eigenschaft ein Byte-Array zurückgibt, 
        // das ein vollständiges Video enthält, was dann dazu führt, dass Bytes in den Speicher geladen werden. 
        // Wir verwenden video.GetStream, das Stream zurückgibt - und fordert uns NICHT auf, das gesamte Video in den 
        // Speicher zu laden.
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
    // Falls erforderlich, können Sie die gleichen Schritte auch für Audiodateien anwenden. 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **Fügen Sie ein Bild als BLOB in die Präsentation ein**
Mit den Methoden aus der [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) Schnittstelle und der [**ImageCollection** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) Klasse können Sie ein großes Bild als Stream hinzufügen, um es als BLOB zu behandeln.

Dieser Java-Code zeigt Ihnen, wie Sie ein großes Bild über den BLOB-Prozess hinzufügen:

```java
String pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das Verhalten KeepLocked, weil wir 
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

Typischerweise benötigen Computer viel temporären Speicher, um eine große Präsentation zu laden. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

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

### **Laden Sie eine große Präsentation als BLOB**

Durch den Prozess, der einen BLOB beinhaltet, können Sie eine große Präsentation laden, während Sie wenig Speicher verwenden. Dieser Java-Code beschreibt die Implementierung, bei der der BLOB-Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

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

### **Ändern Sie den Ordner für temporäre Dateien**

Wenn der BLOB-Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie möchten, dass die temporären Dateien in einem anderen Ordner gespeichert werden, können Sie die Einstellungen für den Speicherort mit `TempFilesRootPath` ändern:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zur Speicherung temporärer Dateien. Sie müssen den Ordner manuell erstellen. 

{{% /alert %}}