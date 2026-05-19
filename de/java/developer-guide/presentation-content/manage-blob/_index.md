---
title: Verwalten von Präsentations-BLOBs in Java für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/java/manage-blob/
keywords:
- großes Objekt
- großer Gegenstand
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
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Java, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---
## **Übersicht**

Aspose.Slides bietet BLOB-basierte Verarbeitung großer Binärdaten in Präsentationen, um den Speicherverbrauch beim Arbeiten mit großen Bildern, Audio‑, Video‑ und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie man BLOB‑basierte Verarbeitung nutzt, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Er erklärt außerdem, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie man den Ordner ändert, in dem sie gespeichert werden.

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Objekt (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides for Java ermöglicht die Verwendung von BLOBs für Objekte, um den Speicherverbrauch zu reduzieren, wenn große Dateien beteiligt sind. 

{{% alert title="Info" color="info" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Präsentationsinhalts und verursacht langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.
{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/java/) for Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu reduzieren.

Dieses Java‑Beispiel zeigt, wie man eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügt:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Fügen wir das Video zur Präsentation hinzu – wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
        // der Speicherverbrauch während des Lebenszyklus des pres-Objekts gering 
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
Aspose.Slides for Java ermöglicht den Export großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise kann es erforderlich sein, eine große Mediendatei aus einer Präsentation zu extrahieren, ohne dass die Datei in den Arbeitsspeicher des Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering. 

Der folgende Java‑Code demonstriert den beschriebenen Vorgang:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// erstelle die Instanz von Presentation, sperre die Datei "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Lassen Sie uns jedes Video in einer Datei speichern. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    // um die Daten vom Videostream der Präsentation zu einem Stream für eine neu erstellte Videodatei zu übertragen.
    byte[] buffer = new byte[8 * 1024];

    // Durchläuft die Videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst vermieden haben, Eigenschaften zuzugreifen
        // wie video.BinaryData - weil diese Eigenschaft ein Byte‑Array zurückgibt, das ein vollständiges Video enthält, was dann
        // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
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

### **Ein Bild als BLOB zu einer Präsentation hinzufügen**
Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/de/java/com.aspose.slides/IImageCollection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ImageCollection) können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird. 

Dieser Java‑Code zeigt, wie man ein großes Bild über den BLOB‑Prozess hinzufügt:

```java
String pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Fügen wir das Bild zur Präsentation hinzu - wir wählen KeepLocked-Verhalten, weil wir
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

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

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

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Der folgende Java‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:

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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speicherungseinstellungen mit `TempFilesRootPath` ändern:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen. 
{{% /alert %}}

### **Präsentationsobjekte freigeben, um Speicher freizugeben**

Beim Verarbeiten großer Präsentationen sollten Sie sicherstellen, dass die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz ordnungsgemäß freigegeben wird, damit der von ihr belegte Speicher wieder freigegeben wird. Rufen Sie `dispose()` auf, nachdem Sie die Präsentation nicht mehr benötigen, um nicht verwaltete Ressourcen freizugeben.

```java
Presentation presentation = new Presentation("large.pptx");

// ...Präsentation verarbeiten...
presentation.save("large.pdf", SaveFormat.Pdf);

// Ressourcen explizit freigeben.
presentation.dispose();
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**  
Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern BLOB‑verarbeitet. Diese Objekte unterliegen BLOB‑Richtlinien, die Ihnen ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf auf temporäre Dateien auszuweichen.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**  
Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verbieten temporäre Dateien, bestimmen den Stammordner für temporäre Dateien und wählen das Verhalten der Quellen‑Sperrung.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie finde ich das richtige Gleichgewicht zwischen Geschwindigkeit und Speicher?**  
Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, führt jedoch zu zusätzlichem I/O. Nutzen Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-), um das optimale Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Hilft BLOB bei der Öffnung extrem großer Präsentationen (z. B. mehrere Gigabyte)?**  
Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Durch das Aktivieren temporärer Dateien und die Nutzung der Quellen‑Sperrung lässt sich der maximale RAM‑Verbrauch deutlich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Disk‑Dateien verwenden?**  
Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.