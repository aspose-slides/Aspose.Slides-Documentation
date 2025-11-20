---
title: Blob verwalten
type: docs
weight: 10
url: /de/net/manage-blob/
keywords: "Blob hinzufügen, Blob exportieren, Bild als Blob hinzufügen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Blob zu einer PowerPoint-Präsentation in C# oder .NET hinzufügen. Blob exportieren. Bild als Blob hinzufügen"
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides für .NET ermöglicht die Verwendung von BLOBs für Objekte, um den Speicherverbrauch zu reduzieren, wenn große Dateien beteiligt sind. 

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/net/) für .NET ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Vorgang, um den Speicherverbrauch zu reduzieren.

Dieser C#‑Code zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
        // der Speicherverbrauch während des gesamten Lebenszyklus des pres-Objekts gering.
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides für .NET ermöglicht das Exportieren großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Vorgang aus Präsentationen. Für Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch das Exportieren der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering. 

Dieser C#‑Code demonstriert den beschriebenen Vorgang:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Erstellt eine Instanz von Presentation, sperrt die "hugePresentationWithAudiosAndVideos.pptx" Datei.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Wir speichern jedes Video in einer Datei. Um hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
	// um die Daten vom Video-Stream der Präsentation zu einem Stream für eine neu erstellte Videodatei zu übertragen.
	byte[] buffer = new byte[8 * 1024];

	// Durchläuft die Videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Öffnet den Video-Stream der Präsentation. Bitte beachten Sie, dass wir absichtlich das Zugreifen auf Eigenschaften vermieden haben
		// wie video.BinaryData - weil diese Eigenschaft ein Byte-Array zurückgibt, das das gesamte Video enthält, wodurch
		// Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
		//  erfordert, dass das gesamte Video in den Speicher geladen wird.
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


### **Bild als BLOB in einer Präsentation hinzufügen**
Mit Methoden des [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection)-Interfaces und der [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)-Klasse können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird. 

Dieser C#‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```c#
string pathToLargeImage = "large_image.jpg";

// Erzeugt eine neue Präsentation, zu der das Bild hinzugefügt wird.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch 
		// gering während des gesamten Lebenszyklus des pres-Objekts
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Speicher und große Präsentationen**

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem C#‑Code beschrieben:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Doch diese Methode verbraucht etwa 1,6 GB temporären Speicher. 

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Vorgang können Sie eine große Präsentation laden und dabei wenig Speicher verbrauchen. Dieser C#‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:
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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen mit `TempFilesRootPath` ändern:
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
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell erstellen. 
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern BLOB‑verarbeitet. Diese Objekte unterliegen BLOB‑Richtlinien, die es Ihnen ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Dort setzen Sie das In‑Memory‑Limit für BLOBs, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und bestimmen das Verhalten beim Sperren der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie finde ich das Gleichgewicht zwischen Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeiten auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O. Passen Sie den Schwellenwert [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) an, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu erreichen.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateisystemdateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn erlaubt, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.