---
title: Presentation-BLOBs auf Android verwalten für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Android über Java, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird.

Aspose.Slides für Android über Java ermöglicht die Verwendung von BLOBs für Objekte in einer Weise, die den Speicherverbrauch reduziert, wenn große Dateien beteiligt sind.

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass der Inhalt der Präsentation kopiert wird und ein langsames Laden verursacht. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Datei‑Pfad der Präsentation und nicht den Stream zu verwenden.
{{% /alert %}}

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/androidjava/) für Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen mit BLOBs verbundenen Prozess, um den Speicherverbrauch zu reduzieren.

Dieses Java‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Fügen wir das Video zur Präsentation hinzu – wir haben das KeepLocked-Verhalten gewählt, weil wir
        //nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
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

Aspose.Slides für Android über Java ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen mit BLOBs verbundenen Prozess aus Präsentationen. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch das Exportieren der Datei über den BLOB‑Prozess halten Sie den Speicherverbrauch niedrig.

Dieser Java‑Code demonstriert den beschriebenen Vorgang:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Erstelle die Presentation‑Instanz und sperre die Datei "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Speichern wir jedes Video in eine Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    // um die Daten vom Videostream der Präsentation in einen Stream einer neu erstellten Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Durchläuft die Videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst vermieden haben, auf Eigenschaften zuzugreifen
        // wie video.BinaryData – weil diese Eigenschaft ein Byte‑Array mit dem gesamten Video zurückgibt, das dann
        // Bytes in den Speicher lädt. Wir verwenden video.GetStream, das einen Stream zurückgibt – und das
        //  erfordert nicht, das gesamte Video in den Speicher zu laden.
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
    // Falls nötig, können Sie die gleichen Schritte für Audiodateien anwenden. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Ein Bild als BLOB in einer Präsentation hinzufügen**

Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird.

Dieser Java‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```java
String pathToLargeImage = "large_image.jpg";

// Erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Fügen wir das Bild zur Präsentation hinzu – wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, ist der Speicherverbrauch
		// bleibt während des gesamten Lebenszyklus des pres-Objekts niedrig.
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

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Arbeitsspeicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5‑GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Java‑Code beschrieben:
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

Durch den mit BLOBs verbundenen Prozess können Sie eine große Präsentation laden, während Sie nur wenig Speicher verwenden. Dieser Java‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:
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

Wird der BLOB‑Prozess verwendet, erstellt Ihr Computer temporäre Dateien im Standard‑Temp‑Ordner. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen mit `TempFilesRootPath` ändern:
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

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern über BLOB‑Verarbeitung verwaltet. Diese Objekte unterliegen BLOB‑Richtlinien, die es Ihnen ermöglichen, den Speicherverbrauch zu steuern und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verhindern temporäre Dateien, wählen den Stamm‑Pfad für Temp‑Dateien und bestimmen das Lock‑Verhalten der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegen Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; eine Verringerung des Speicherlimits verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, kostet jedoch zusätzlichen I/O. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können die Spitzen‑RAM‑Nutzung erheblich reduzieren und die Verarbeitung sehr großer Präsentationen stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Festplattendateien verwenden?**

Ja. dieselben Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, wodurch die Speicher­nutzung während der Verarbeitung vorhersehbar bleibt.