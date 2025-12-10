---
title: Verwalten von Präsentations-BLOBs in .NET für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Verwalten von BLOB-Daten in Aspose.Slides für .NET, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides for .NET ermöglicht die Verwendung von BLOBs für Objekte auf eine Weise, die den Speicherverbrauch reduziert, wenn große Dateien beteiligt sind. 

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/net/) for .NET ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen Prozess, der BLOBs einsetzt, um den Speicherverbrauch zu reduzieren.

Dieses C#‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, die Datei "veryLargeVideo.avi" zu öffnen.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
        // der Speicherverbrauch während des gesamten Lebenszyklus des pres-Objekts niedrig.
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Eine große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides for .NET ermöglicht den Export großer Dateien (in diesem Fall einer Audio- oder Videodatei) über einen Prozess, der BLOBs aus Präsentationen einsetzt. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten aber nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering. 

Dieser C#‑Code demonstriert die beschriebene Vorgehensweise:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Erstellt eine Instanz von Presentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
	// um die Daten vom Videostream der Präsentation in einen Stream einer neu erstellten Videodatei zu übertragen.
	byte[] buffer = new byte[8 * 1024];

	// Durchläuft die Videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst auf das Zugreifen von Eigenschaften verzichtet haben
		// wie video.BinaryData - weil diese Eigenschaft ein Byte‑Array mit dem gesamten Video zurückgibt, was dann
		// dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und das NICHT
		//  erfordert, dass wir das gesamte Video in den Speicher laden.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Der Speicherverbrauch bleibt niedrig, unabhängig von der Größe des Videos oder der Präsentation,
	}

	// Falls nötig, können Sie dieselben Schritte für Audiodateien anwenden. 
}
```


### **Ein Bild als BLOB zu einer Präsentation hinzufügen**
Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) und der Klasse [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird. 

Dieser C#‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```c#
string pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, die Datei "largeImage.png" zu öffnen.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch 
		// niedrig während des gesamten Lebenszyklus des pres-Objekts
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Speicher und große Präsentationen**

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem C#‑Code beschrieben:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Eine große Präsentation als BLOB laden**
Durch einen Prozess, der ein BLOB verwendet, können Sie eine große Präsentation mit wenig Speicher laden. Dieser C#‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:
```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


### **Ordner für temporäre Dateien ändern**
Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen mit `TempFilesRootPath` ändern:
```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```


{{% alert title="Info" color="info" %}}
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides keinen Ordner zum Speichern temporärer Dateien automatisch. Sie müssen den Ordner **manuell erstellen**. 
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt der BLOB‑Verarbeitung, wenn sie geladen oder gespeichert wird. Diese Objekte werden durch BLOB‑Richtlinien gesteuert, die Ihnen ermöglichen, die Speicherverwendung zu verwalten und bei Bedarf in temporäre Dateien auszulagern. 

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten der Quellsperrung. 

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegenüber Speicher?**

Ja. Das Verbleiben von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; eine Reduzierung des Speicherlimits verlagert mehr Arbeit auf temporäre Dateien, verringert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O. Passen Sie den Schwellenwert [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) an, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu erzielen. 

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Durch das Aktivieren temporärer Dateien und die Verwendung von Quellsperrungen kann der Spitzen‑RAM‑Verbrauch erheblich reduziert und die Verarbeitung sehr großer Decks stabilisiert werden. 

**Kann ich BLOB‑Richtlinien beim Laden von Streams anstelle von Disk‑Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Sperrmodus), und temporäre Dateien werden verwendet, wenn dies erlaubt ist, sodass die Speicherverwendung während der Verarbeitung vorhersehbar bleibt.