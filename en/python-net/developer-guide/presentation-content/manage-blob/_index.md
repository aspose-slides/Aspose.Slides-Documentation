---
title: Manage BLOBs in Presentations with Python for Efficient Memory Use
linktitle: Manage BLOB
type: docs
weight: 10
url: /python-net/manage-blob/
keywords:
- large object
- large item
- large file
- add BLOB
- export BLOB
- add image as BLOB
- reduce memory
- memory consumption
- large presentation
- temporary file
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Manage BLOB data in Aspose.Slides for Python via .NET to streamline PowerPoint and OpenDocument file operations for efficient presentation handling."
---

## **About BLOB**

**BLOB** (**Binary Large Object**) is usually a large item (photo, presentation, document, or media) saved in binary formats. 

Aspose.Slides for Python via .NET allows you to use BLOBs for objects in a way that reduces memory consumption when large files are involved. 

## **Use BLOB to Reduce Memory Consumption**

### **Add Large File through BLOB to a Presentation**

[Aspose.Slides](/slides/python-net/) for .NET allows you to add large files (in this case, a large video file) through a process involving BLOBs to reduce memory consumption.

This Python shows you how to add a large video file through the BLOB process to a presentation:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Creates a new presentation to which the video will be added
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Let's add the video to the presentation - we chose the KeepLocked behavior because we do
        # not intend to access the "veryLargeVideo.avi" file.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Saves the presentation. While a large presentation gets outputted, the memory consumption
        # stays low through the pres object's lifecycle 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Export Large File Through BLOB from Presentation**
Aspose.Slides for Python via .NET allows you to export large files (in this case, an audio or video file) through a process involving BLOBs from presentations. For example, you may need to extract a large media file from a presentation but do not want the file to be loaded into your computer's memory. By exporting the file through the BLOB process, you get to keep memory consumption low. 

This code in Python demonstrates the described operation:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
	# to transfer the data from the presentation's video stream to a stream for a newly created video file.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Iterates through the videos
    index = 0
    # If necessary, you can apply the same steps for audio files. 
    for video in pres.videos:
		# Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
		# like video.BinaryData - because this property returns a byte array containing a full video, which then
		# causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
		#  require us to load the whole video into the memory.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Add Image as BLOB in Presentation**
With methods from the [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) class, you can add a large image as a stream to get it treated as a BLOB. 

This Python code shows you how to add a large image through the BLOB process:

```py
import aspose.slides as slides

# creates a new presentation to which the image will be added.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memory and Large Presentations**

Typically, to load a large presentation, computers require a lot of temporary memory. All the presentation's content is loaded into the memory and the file (from which the presentation was loaded) stops being used. 

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this Python code:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

But this method consumes around 1.6 GB of temporary memory. 

### **Load a Large Presentation as BLOB**

Through the process involving a BLOB, you can load up a large presentation while using little memory. This Python code describes the implementation where the BLOB process is used to load up a large presentation file (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Change the Folder for Temporary Files**

When the BLOB process is used, your computer creates temporary files in the default folder for temporary files. If you want the temporary files to be kept in a different folder, you can change the settings for storage using `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}

When you use `temp_files_root_path`, Aspose.Slides does not automatically create a folder to store temporary files. You have to create the folder manually. 

{{% /alert %}}

## **FAQ**

**What data in an Aspose.Slides presentation is treated as BLOB and controlled by BLOB options?**

Large binary objects such as images, audio, and video are treated as BLOB. The whole presentation file also involves BLOB handling when it’s loaded or saved. These objects are governed by BLOB policies that let you manage memory usage and spill to temporary files when needed.

**Where do I configure BLOB handling rules during presentation loading?**

Use [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) with [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). There you set the in-memory limit for BLOB, allow or disallow temporary files, choose the root path for temp files, and select source locking behavior.

**Do BLOB settings affect performance, and how do I balance speed vs memory?**

Yes. Keeping BLOB in memory maximizes speed but increases RAM consumption; lowering the memory limit shifts more work to temporary files, reducing RAM at the cost of additional I/O. Tune the [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) threshold to reach the right balance for your workload and environment.

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**

Yes. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) are designed for such scenarios: enabling temporary files and using source locking can significantly reduce peak RAM use and stabilize processing for very large decks.

**Can I use BLOB policies when loading from streams instead of disk files?**

Yes. The same rules apply to streams: the presentation instance can own and lock the input stream (depending on the chosen locking mode), and temporary files are used when allowed, keeping memory usage predictable during processing.
