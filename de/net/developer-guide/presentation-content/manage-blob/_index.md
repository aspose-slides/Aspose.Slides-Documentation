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
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für .NET, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides for .NET ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird. 

## **BLOB zum Reduzieren des Speicherverbrauchs verwenden**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/net/) for .NET ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu senken. 

Dieses C#‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        // nicht beabsichtigen, auf die Datei \"veryLargeVideo.avi\" zuzugreifen.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
        // der Speicherverbrauch durch den Lebenszyklus des pres-Objekts niedrig 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```



### **Große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides for .NET ermöglicht den Export großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise können Sie eine große Mediendatei aus einer Präsentation extrahieren, ohne dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig. 

Dieser C#‑Code demonstriert die beschriebene Operation:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Sperrt die Quelldatei und LÄDT sie NICHT in den Speicher
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Erstellt eine Instanz von Presentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Speichern wir jedes Video in eine Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
	// um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
	byte[] buffer = new byte[8 * 1024];

	// Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst vermieden haben, Eigenschaften zuzugreifen
	// wie video.BinaryData - weil diese Eigenschaft ein Byte-Array zurückgibt, das das komplette Video enthält, das dann
	// bewirkt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
	//  erfordert, dass wir das gesamte Video in den Speicher laden.
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Öffnet den Videostream der Präsentation. Bitte, beachten Sie, dass wir bewusst vermieden haben, auf Eigenschaften zuzugreifen
		// wie video.BinaryData - weil diese Eigenschaft ein Byte-Array zurückgibt, das das vollständige Video enthält, das dann
		// bewirkt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt - und NICHT
		//  erfordert, dass wir das ganze Video in den Speicher laden.
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


### **Bild als BLOB in Präsentation hinzufügen**
Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird. 

Dieser C#‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```c#
string pathToLargeImage = "large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Fügen wir das Bild zur Präsentation hinzu - wir wählen das KeepLocked-Verhalten, weil wir
		// NICHT beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
		// der Speicherverbrauch durch den Lebenszyklus des pres-Objekts niedrig.
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Speicher und große Präsentationen**

Typischerweise benötigen Computer viel temporären Speicher, um eine große Präsentation zu laden. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist im folgenden C#‑Code beschrieben:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Große Präsentation als BLOB laden**

Über den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser C#‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:
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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Einstellungen für den Speicherort mit `TempFilesRootPath` ändern:
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

Große binäre Objekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern über BLOB‑Verarbeitung verwaltet. Diese Objekte unterliegen BLOB‑Richtlinien, mit denen Sie die Speichernutzung steuern und bei Bedarf in temporäre Dateien auslagern können.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) mit [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Lock‑Verhalten der Quelle.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit vs. Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O‑Aufwand. Passen Sie den Schwellenwert [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) an, um das optimale Gleichgewicht für Ihre Arbeitslast und Umgebung zu erreichen.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien ausgelegt: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den Spitzen‑RAM‑Verbrauch deutlich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams statt aus Dateien verwenden?**

Ja. dieselben Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Lock‑Modus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.