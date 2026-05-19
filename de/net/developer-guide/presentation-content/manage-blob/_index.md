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
- Speicherauslastung
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für .NET, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Verarbeitung von Präsentationen zu ermöglichen."
---
## **Übersicht**

Aspose.Slides bietet BLOB-basierte Verarbeitung großer binärer Daten in Präsentationen, um den Speicherverbrauch bei der Arbeit mit großen Bildern, Audio-, Video- und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie man die BLOB-basierte Verarbeitung verwendet, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Er erklärt außerdem, wie während der Verarbeitung temporäre Dateien verwendet werden können und wie der Ordner, in dem sie gespeichert werden, geändert wird.

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist üblicherweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides für .NET ermöglicht es Ihnen, BLOBs für Objekte zu verwenden, um den Speicherverbrauch zu reduzieren, wenn große Dateien beteiligt sind. 

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/net/) für .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen BLOB-basierten Prozess hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieses C#‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir nicht
        // beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt
        // der Speicherverbrauch während des gesamten Lebenszyklus des pres-Objekts niedrig 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Große Datei über BLOB aus einer Präsentation exportieren**

Aspose.Slides für .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen zu exportieren. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten aber nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering. 

Dieser C#‑Code demonstriert den beschriebenen Vorgang:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Sperrt die Quelldatei und läd sie NICHT in den Speicher
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Erstellt eine Instanz von Presentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx" file.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Lassen Sie uns jedes Video in eine Datei speichern. Um hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
	// um die Daten vom Videostream der Präsentation zu einem Stream für eine neu erstellte Videodatei zu übertragen.
	byte[] buffer = new byte[8 * 1024];

	// Durchläuft die Videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich vermieden haben, Eigenschaften zuzugreifen
		// wie video.BinaryData – weil diese Eigenschaft ein Byte‑Array mit dem gesamten Video zurückgibt, was dann
		// bewirkt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
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

	// Falls nötig, können Sie die gleichen Schritte für Audiodateien anwenden. 
}
```

### **Bild als BLOB zu einer Präsentation hinzufügen**

Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/de/net/aspose.slides/imagecollection) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird. 

Dieses C#‑Beispiel zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

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
		// der Speicherverbrauch während des gesamten Lebenszyklus des pres-Objekts niedrig
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Arbeitsspeicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5‑GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem C#‑Code beschrieben:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser C#‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

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

### **Presentation‑Objekte freigeben, um Speicher freizugeben**

Beim Verarbeiten großer Präsentationen sollten Sie sicherstellen, dass die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher freigegeben wird. Die empfohlene Vorgehensweise ist die Verwendung einer `using`‑Anweisung oder -Deklaration, wie in den obigen Beispielen gezeigt; sie gibt die Präsentation automatisch frei und setzt nicht verwaltete Ressourcen frei, wenn der Block beendet wird.

Erstellen Sie eine Präsentation ohne `using`‑Block, rufen Sie `Dispose()` explizit auf, nachdem Sie sie nicht mehr benötigen.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...verarbeite die Präsentation...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Ressourcen explizit freigeben.
presentation.Dispose();
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt der BLOB‑Verarbeitung, wenn sie geladen oder gespeichert wird. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die es ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten der Quell‑Sperrung.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegen Speicher?**

Ja. Wenn BLOB im Speicher gehalten wird, ist die Geschwindigkeit maximal, jedoch steigt der RAM‑Verbrauch; ein niedrigeres Speicherlimit verlagert mehr Arbeit auf temporäre Dateien, wodurch RAM gespart wird, jedoch zusätzlicher I/O‑Aufwand entsteht. Passen Sie den Schwellenwert [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) an, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu erreichen.

**Hilft BLOB, wenn extrem große Präsentationen (z. B. Gigabytes) geöffnet werden?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Quell‑Sperrung können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Präsentationen stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, wodurch der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.