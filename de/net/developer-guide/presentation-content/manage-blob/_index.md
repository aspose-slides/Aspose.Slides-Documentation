---
title: Blob verwalten
type: docs
weight: 10
url: /de/net/manage-blob/
keywords: "Blob hinzufügen, Blob exportieren, Bild als Blob hinzufügen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Blob zu PowerPoint-Präsentation in C# oder .NET hinzufügen. Blob exportieren. Bild als Blob hinzufügen"
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medien), das in binären Formaten gespeichert ist.

Aspose.Slides für .NET ermöglicht es Ihnen, BLOBs für Objekte auf eine Weise zu verwenden, die den Speicherverbrauch verringert, wenn große Dateien beteiligt sind.

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/net/) für .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen Prozess, der BLOBs umfasst, hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieser C#-Code zeigt Ihnen, wie man eine große Videodatei über den BLOB-Prozess zu einer Präsentation hinzufügt:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Lassen Sie uns das Video zur Präsentation hinzufügen - wir haben uns für das Verhalten KeepLocked entschieden, da wir nicht beabsichtigen,
        // die "veryLargeVideo.avi"-Datei zuzugreifen.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        // während des Lebenszyklus des pres-Objekts gering
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Große Datei über BLOB aus Präsentation exportieren**
Aspose.Slides für .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio- oder Videodatei) über einen Prozess, der BLOBs umfasst, aus Präsentationen zu exportieren. Zum Beispiel möchten Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, wollen jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB-Prozess können Sie den Speicherverbrauch gering halten.

Dieser C#-Code zeigt die beschriebene Operation:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Sperrt die Quelldatei und lädt sie NICHT in den Speicher
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Erstellt eine Instanz der Präsentation, sperrt die "hugePresentationWithAudiosAndVideos.pptx"-Datei.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Lassen Sie uns jedes Video in eine Datei speichern. Um einen hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird,
	// um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
	byte[] buffer = new byte[8 * 1024];

	// Iteriert durch die Videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Öffnet den Präsentationsvideostream. Bitte beachten Sie, dass wir absichtlich vermieden haben, Eigenschaften zuzugreifen
		// wie video.BinaryData - da diese Eigenschaft ein Byte-Array zurückgibt, das ein vollständiges Video enthält, was dann
		// dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das Stream zurückgibt - und das NICHT
		// erfordert, dass wir das gesamte Video in den Speicher laden.
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

		// Der Speicherverbrauch bleibt gering, unabhängig von der Größe des Videos oder der Präsentation.
	}

	// Wenn nötig, können Sie die gleichen Schritte für Audiodateien anwenden.
}
```

### **Bild als BLOB in Präsentation hinzufügen**
Mit Methoden aus der [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) Schnittstelle und der [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) Klasse können Sie ein großes Bild als Stream hinzufügen, um es als BLOB zu behandeln.

Dieser C#-Code zeigt Ihnen, wie Sie ein großes Bild über den BLOB-Prozess hinzufügen können:

```c#
string pathToLargeImage = "large_image.jpg";

// Erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das Verhalten KeepLocked, da wir nicht
		// beabsichtigen, die "largeImage.png"-Datei zuzugreifen.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch 
		// während des Lebenszyklus des pres-Objekts gering
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer viel temporären Speicher, um eine große Präsentation zu laden. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint-Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem C#-Code beschrieben:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Aber diese Methode verbraucht etwa 1,6 GB temporären Speicher.

### **Eine große Präsentation als BLOB laden**

Durch den Prozess, der einen BLOB umfasst, können Sie eine große Präsentation laden und dabei wenig Speicher verwenden. Dieser C#-Code beschreibt die Implementierung, bei der der BLOB-Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

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

### **Ändern Sie den Ordner für temporäre Dateien**

Wenn der BLOB-Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie möchten, dass die temporären Dateien in einem anderen Ordner gespeichert werden, können Sie die Einstellungen für den Speicherort mit `TempFilesRootPath` ändern:

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