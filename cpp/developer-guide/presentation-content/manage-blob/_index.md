---
title: Manage Blob
type: docs
weight: 10
url: /cpp/manage-blob/
keywords: "Add blob, Export blob, Add image as blob, PowerPoint Presentation, C++, Aspose.Slides for C++"
description: "Add blob to PowerPoint presentation in C++. Export blob. Add Image as blob"
---

## **About BLOB**

**BLOB** (**Binary Large Object**) is usually a large item—a large photo, presentation, document, or media—saved in binary formats. 

Aspose.Slides for C++ allows you to use BLOBs for objects in a way that reduces memory consumption when large files are involved. 

## **Use BLOB to Reduce Memory Consumption**

### **Add Large File through BLOB to a Presentation**

[Aspose.Slides](/slides/cpp/) for C++ allows you to add large files (in this case, a large video file) through a process involving BLOBs to reduce memory consumption.

This C++ code shows you how to add a large video file through the BLOB process to a presentation:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Creates a new presentation to which the video will be added
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Let's add the video to the presentation - we chose the KeepLocked behavior because we do
//not intend to access the "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Saves the presentation. While a large presentation gets outputted, the memory consumption
// stays low through the pres object's lifecycle 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Export Large File Through BLOB from Presentation**
Aspose.Slides for C++ allows you to export large files (in this case, an audio or video file) through a process involving BLOBs from presentations. For example, you may need to extract a large media file from a presentation but do not want the file to be loaded into your computer's memory. By exporting the file through the BLOB process, you get to keep memory consumption low. 

This code in C++ demonstrates the described operation:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Creates a Presentation's instance, locks the "hugePresentationWithAudiosAndVideos.pptx" file.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
// to transfer the data from the presentation's video stream to a stream for a newly created video file.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Opens the presentation video stream. Please, note that we intentionally avoided accessing methods
	// like video->get_BinaryData - because this method returns a byte array containing a full video, which then
	// causes bytes to be loaded into memory. We use video->GetStream, which will return Stream - and does NOT
	// require us to load the whole video into the memory.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Memory consumption will remain low regardless of the size of the video or presentation,
}

// If necessary, you can apply the same steps for audio files.
```

### **Add Image as BLOB in Presentation**
With methods from the [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) interface and [**ImageCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection)class, you can add a large image as a stream to get it treated as a BLOB. 

This C++ code shows you how to add a large image through the BLOB process:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// creates a new presentation to which the image will be added.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Let's add the image to the presentation - we choose KeepLocked behavior because we do
// NOT intend to access the "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Saves the presentation. While a large presentation gets outputted, the memory consumption 
// stays low through the pres object's lifecycle
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memory and Large Presentations**

Typically, to load a large presentation, computers require a lot of temporary memory. All the presentation's content is loaded into the memory and the file (from which the presentation was loaded) stops being used. 

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this C++ code:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

But this method consumes around 1.6 GB of temporary memory. 

### **Load a Large Presentation as BLOB**

Through the process involving a BLOB, you can load up a large presentation while using little memory. This C++ code describes the implementation where the BLOB process is used to load up a large presentation file (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Change the Folder for Temporary Files**

When the BLOB process is used, your computer creates temporary files in the default folder for temporary files. If you want the temporary files to be kept in a different folder, you can change the settings for storage using `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}

When you use `TempFilesRootPath`, Aspose.Slides does not automatically create a folder to store temporary files. You have to create the folder manually. 

{{% /alert %}}