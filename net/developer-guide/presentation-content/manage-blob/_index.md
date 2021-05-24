---
title: Manage Blob
type: docs
weight: 80
url: /net/manage-blob/
---

## **Add Blob in Presentation**
[Aspose.Slides](/slides/net/) for .NET provides a facility to add large files (video file in that case) and prevent a high memory consumption. An example is given below that shows how to add Blob in presentations.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Conversion();
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// create a new presentation which will contain this video
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // let's add the video to the presentation - we choose KeepLocked behavior, because we not
        // have an intent to access the "veryLargeVideo.avi" file.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // save the presentation. Despite that the output presentation will be very large, the memory
        // consumption will be low the whole lifetime of the pres object
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


## **Export Blob from Presentation**
Aspose.Slides for .NET provides a facility to Export large files (audio and video file in that case). We want to extract these files from the presentation and do not want to load this presentation into memory to keep our memory consumption low. Here is an example is given below how we can export blob from presentations.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Conversion();
const string hugePresentationWithAudiosAndVideosFile = @"c:\bin\aspose\Tasks\020, 38595\orig\Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// lock the source file and don't load it into memory
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// let's save each video to a file. to prevent memory usage we need a buffer which will be used
	// to exchange tha data from the presentation's video stream to a stream for newly created video file.
	byte[] buffer = new byte[8 * 1024];

	// iterate through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// open the presentation video stream. Please note that we intentionally avoid accessing properties
		// like video.BinaryData - this property returns a byte array containing full video, and that means
		// this bytes will be loaded into memory. We will use video.GetStream, which will return Stream and
		// that allows us to not load the whole video into memory.
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

		// memory consumption will stay low no matter what size the videos or presentation is.
	}

	// do the same for audios if needed.
}
```



## **Add Image as BLOB in Presentation**
Aspose.Slides for .NET added a new method to [**IImageCollection**](https://apireference.aspose.com/net/slides/aspose.slides/iimagecollection) interface and [**ImageCollection** ](https://apireference.aspose.com/net/slides/aspose.slides/imagecollection)class to support adding a large image as streams to treat them as BLOBs.

This example demonstrates how to include the large BLOB (image) and prevent high memory consumption.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationSaving();

string pathToLargeImage = dataDir + "large_image.jpg";

// create a new presentation which will contain this image
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// let's add the image to the presentation - we choose KeepLocked behavior, because we not
		// have an intent to access the "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// save the presentation. Despite that the output presentation will be
		// large, the memory consumption will be low the whole lifetime of the pres object
		pres.Save(dataDir + "presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}

```



