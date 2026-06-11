---
title: Hantera presentations-BLOB-ar i .NET för effektiv minnesanvändning
linktitle: Hantera BLOB
type: docs
weight: 10
url: /sv/net/manage-blob/
keywords:
- stort objekt
- stor post
- stor fil
- lägg till BLOB
- exportera BLOB
- lägg till bild som BLOB
- reducera minne
- minnesförbrukning
- stor presentation
- temporär fil
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera BLOB-data i Aspose.Slides för .NET för att förenkla PowerPoint- och OpenDocument-filoperationer för effektiv presentationshantering."
---
## **Översikt**

Aspose.Slides provides BLOB-based handling for large binary data in presentations to help reduce memory consumption when working with large images, audio, video, and presentation files.

This article shows how to use BLOB-based processing to add large media to a presentation, export large media from a presentation, and load large presentations more efficiently. It also explains how temporary files can be used during processing and how to change the folder used to store them.

## **Om BLOB**

**BLOB** (**Binary Large Object**) is usually a large item (photo, presentation, document, or media) saved in binary formats. 

Aspose.Slides for .NET allows you to use BLOBs for objects in a way that reduces memory consumption when large files are involved. 

## **Använd BLOB för att minska minnesanvändning**

### **Lägg till en stor fil via BLOB i en presentation**

[Aspose.Slides](/slides/sv/net/) for .NET allows you to add large files (in this case, a large video file) through a process involving BLOBs to reduce memory consumption.

This C# shows you how to add a large video file through the BLOB process to a presentation:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Skapar en ny presentation som videon ska läggas till i
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Låt oss lägga till videon i presentationen - vi valde KeepLocked-beteendet eftersom vi
        //inte avser att komma åt filen "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Sparar presentationen. Medan en stor presentation exporteras, förblir minnesförbrukningen
        // förblir låg under presentationens livscykel 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Exportera en stor fil via BLOB från en presentation**
Aspose.Slides for .NET allows you to export large files (in this case, an audio or video file) through a process involving BLOBs from presentations. For example, you may need to extract a large media file from a presentation but do not want the file to be loaded into your computer's memory. By exporting the file through the BLOB process, you get to keep memory consumption low. 

This code in C# demonstrates the described operation:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Låser källfilen och LÄSER INTE in den i minnet
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Skapar en Presentation-instans, låser filen "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Låt oss spara varje video till en fil. För att förhindra hög minnesanvändning behöver vi en buffert som ska användas
	// för att överföra data från presentationens videoström till en ström för en ny skapad videofil.
	// Itererar igenom videorna
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Öppnar presentationens videoström. Observera att vi avsiktligt undvek åtkomst till egenskaper
		// som video.BinaryData - eftersom denna egenskap returnerar en byte-array som innehåller en hel video, vilket sedan
		// gör att byte laddas in i minnet. Vi använder video.GetStream, som returnerar en Stream - och LÄSER INTE
		//  kräver att vi laddar hela videon i minnet.
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

		// Minnesanvändningen kommer att förbli låg oavsett storlek på videon eller presentationen,
	}

	// Om nödvändigt kan du tillämpa samma steg för ljudfiler. 
}
```

### **Lägg till en bild som BLOB i en presentation**
With methods from the [**IImageCollection**](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) interface and [**ImageCollection**](https://reference.aspose.com/slides/sv/net/aspose.slides/imagecollection)class, you can add a large image as a stream to get it treated as a BLOB. 

This C# code shows you how to add a large image through the BLOB process:

```c#
string pathToLargeImage = "large_image.jpg";

// skapar en ny presentation som bilden kommer att läggas till.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Låt oss lägga till bilden i presentationen - vi väljer KeepLocked-beteendet eftersom vi
		// INTE avser att komma åt filen "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Sparar presentationen. Medan en stor presentation genereras, förblir minnesförbrukningen
		// låg under presentationens livscykel
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Minne och stora presentationer**

Typically, to load a large presentation, computers require a lot of temporary memory. All the presentation's content is loaded into the memory and the file (from which the presentation was loaded) stops being used. 

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this C# code:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

But this method consumes around 1.6 GB of temporary memory. 

### **Läs in en stor presentation som BLOB**

Through the process involving a BLOB, you can load up a large presentation while using little memory. This C# code describes the implementation where the BLOB process is used to load up a large presentation file (large.pptx):

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

### **Ändra mappen för temporära filer**

When the BLOB process is used, your computer creates temporary files in the default folder for temporary files. If you want the temporary files to be kept in a different folder, you can change the settings for storage using `TempFilesRootPath`:

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
When you use `TempFilesRootPath`, Aspose.Slides does not automatically create a folder to store temporary files. You have to create the folder manually. 
{{% /alert %}}

### **Avsluta presentationsobjekt för att frigöra minne**

When processing large presentations, ensure that the [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) instance is properly disposed so that the memory it occupied is released. The recommended way is to use a `using` statement or declaration as shown in the examples above; it automatically disposes the presentation and frees unmanaged resources when the block exits.

If you create a presentation without a `using` block, explicitly call `Dispose()` after you have finished using it.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...processa presentationen...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Frigör resurser explicit.
presentation.Dispose();
```

## **Vanliga frågor**

**Vilken data i en Aspose.Slides-presentation behandlas som BLOB och styrs av BLOB-alternativ?**

Large binary objects such as images, audio, and video are treated as BLOB. The whole presentation file also involves BLOB handling when it’s loaded or saved. These objects are governed by BLOB policies that let you manage memory usage and spill to temporary files when needed.

**Var konfigurerar jag BLOB‑hanteringsregler under laddning av presentation?**

Use [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/) with [BlobManagementOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/blobmanagementoptions/). There you set the in-memory limit for BLOB, allow or disallow temporary files, choose the root path for temp files, and select source locking behavior.

**Påverkar BLOB‑inställningarna prestanda, och hur balanserar jag hastighet mot minne?**

Yes. Keeping BLOB in memory maximizes speed but increases RAM consumption; lowering the memory limit shifts more work to temporary files, reducing RAM at the cost of additional I/O. Tune the [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/sv/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) threshold to reach the right balance for your workload and environment.

**Hjälper BLOB‑alternativen när man öppnar extremt stora presentationer (t.ex. gigabyte)?**

Yes. [BlobManagementOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/blobmanagementoptions/) are designed for such scenarios: enabling temporary files and using source locking can significantly reduce peak RAM use and stabilize processing for very large decks.

**Kan jag använda BLOB‑policyer när jag laddar från strömmar istället för diskfiler?**

Yes. The same rules apply to streams: the presentation instance can own and lock the input stream (depending on the chosen locking mode), and temporary files are used when allowed, keeping memory usage predictable during processing.