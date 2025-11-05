---
title: Manage Blob
type: docs
weight: 10
url: /net/manage-blob/
keywords: "Add blob, Export blob, Add image as blob, PowerPoint Presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add blob to PowerPoint presentation in C# or .NET. Export blob. Add Image as blob"
---

## **About BLOB**

**BLOB** (**Binary Large Object**) is usually a large item (photo, presentation, document, or media) saved in binary formats. 

Aspose.Slides for .NET allows you to use BLOBs for objects in a way that reduces memory consumption when large files are involved. 

## **Use BLOB to Reduce Memory Consumption**

### **Add Large File through BLOB to a Presentation**

[Aspose.Slides](/slides/net/) for .NET allows you to add large files (in this case, a large video file) through a process involving BLOBs to reduce memory consumption.

This C# shows you how to add a large video file through the BLOB process to a presentation:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Creates a new presentation to which the video will be added
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Let's add the video to the presentation - we chose the KeepLocked behavior because we do
        //not intend to access the "veryLargeVideo.avi" file.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Saves the presentation. While a large presentation gets outputted, the memory consumption
        // stays low through the pres object's lifecycle 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Export Large File Through BLOB from Presentation**
Aspose.Slides for .NET allows you to export large files (in this case, an audio or video file) through a process involving BLOBs from presentations. For example, you may need to extract a large media file from a presentation but do not want the file to be loaded into your computer's memory. By exporting the file through the BLOB process, you get to keep memory consumption low. 

This code in C# demonstrates the described operation:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Locks the source file and does NOT load it into memory
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Creates a Presentation's instance, locks the "hugePresentationWithAudiosAndVideos.pptx" file.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
	// to transfer the data from the presentation's video stream to a stream for a newly created video file.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
		// like video.BinaryData - because this property returns a byte array containing a full video, which then
		// causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
		//  require us to load the whole video into the memory.
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

		// Memory consumption will remain low regardless of the size of the video or presentation,
	}

	// If necessary, you can apply the same steps for audio files. 
}
```

### **Add Image as BLOB in Presentation**
With methods from the [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) interface and [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)class, you can add a large image as a stream to get it treated as a BLOB. 

This C# code shows you how to add a large image through the BLOB process:

```c#
string pathToLargeImage = "large_image.jpg";

// creates a new presentation to which the image will be added.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Let's add the image to the presentation - we choose KeepLocked behavior because we do
		// NOT intend to access the "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Saves the presentation. While a large presentation gets outputted, the memory consumption 
		// stays low through the pres object's lifecycle
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memory and Large Presentations**

Typically, to load a large presentation, computers require a lot of temporary memory. All the presentation's content is loaded into the memory and the file (from which the presentation was loaded) stops being used. 

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this C# code:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

But this method consumes around 1.6 GB of temporary memory. 

### **Load a Large Presentation as BLOB**

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

### **Change the Folder for Temporary Files**

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

## **FAQ**

**What data in an Aspose.Slides presentation is treated as BLOB and controlled by BLOB options?**

Large binary objects such as images, audio, and video are treated as BLOB. The whole presentation file also involves BLOB handling when it’s loaded or saved. These objects are governed by BLOB policies that let you manage memory usage and spill to temporary files when needed.

**Where do I configure BLOB handling rules during presentation loading?**

Use [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) with [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). There you set the in-memory limit for BLOB, allow or disallow temporary files, choose the root path for temp files, and select source locking behavior.

**Do BLOB settings affect performance, and how do I balance speed vs memory?**

Yes. Keeping BLOB in memory maximizes speed but increases RAM consumption; lowering the memory limit shifts more work to temporary files, reducing RAM at the cost of additional I/O. Tune the [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) threshold to reach the right balance for your workload and environment.

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**

Yes. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) are designed for such scenarios: enabling temporary files and using source locking can significantly reduce peak RAM use and stabilize processing for very large decks.

**Can I use BLOB policies when loading from streams instead of disk files?**

Yes. The same rules apply to streams: the presentation instance can own and lock the input stream (depending on the chosen locking mode), and temporary files are used when allowed, keeping memory usage predictable during processing.
