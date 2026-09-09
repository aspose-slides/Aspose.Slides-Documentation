---
title: Manage Presentation BLOBs in Python via Java for Efficient Memory Use
linktitle: Manage BLOB
type: docs
weight: 10
url: /python-java/manage-blob/
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
- Java
- Aspose.Slides
description: "Manage BLOB data in Aspose.Slides for Python via Java to streamline PowerPoint and OpenDocument file operations for efficient presentation handling."
---

## **Overview**

Aspose.Slides provides BLOB-based handling for large binary data in presentations to help reduce memory consumption when working with large images, audio, video, and presentation files.

This article shows how to use BLOB-based processing to add large media to a presentation, export large media from a presentation, and load large presentations more efficiently. It also explains how temporary files can be used during processing and how to change the folder used to store them.

## **About BLOB**

A **BLOB** (**Binary Large Object**) is usually a large item (photo, presentation, document, or media) saved in binary formats.

Aspose.Slides for Python via Java allows you to use BLOBs for objects in a way that reduces memory consumption when large files are involved.

{{% alert color="info" title="Note" %}}

To circumvent certain limitations when interacting with streams, Aspose.Slides may copy the stream's content. Loading a large presentation through its stream will result in the copying of the presentation's contents and cause slow loading. Therefore, when you intend to load a large presentation, we strongly recommend that you use the presentation file path and not its stream.

{{% /alert %}}

## **Use BLOBs to Reduce Memory Consumption**

### **Add a Large File to a Presentation Using BLOBs**

[Aspose.Slides](/slides/python-java/) for Python via Java allows you to add large files (in this case, a large video file) through a process involving BLOBs to reduce memory consumption.

This Python code shows you how to add a large video file through the BLOB process to a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Create a new presentation to which the video will be added.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Keep the stream locked because we do not intend to access the video file.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Save the presentation while keeping memory consumption low.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Export a Large File from a Presentation Using BLOBs**
Aspose.Slides for Python via Java allows you to export large files (in this case, an audio or video file) through a process involving BLOBs from presentations. For example, you may need to extract a large media file from a presentation but do not want the file to be loaded into your computer's memory. By exporting the file through the BLOB process, you get to keep memory consumption low.

This code in Python demonstrates the described operation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Lock the source file instead of loading it into memory.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Transfer video data through a buffer to keep memory consumption low.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Use the stream instead of loading the entire video into a byte array.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # If necessary, apply the same steps to audio files.
finally:
    presentation.dispose()
```

### **Add an Image as a BLOB to a Presentation**
With methods from the [ImageCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/) class, you can add a large image as a stream so that it is treated as a BLOB.

This Python code shows you how to add a large image through the BLOB process:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Create a new presentation to which the image will be added.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Keep the stream locked because we do not intend to access the image file.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Save the presentation while keeping memory consumption low.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memory and Large Presentations**

Typically, to load a large presentation, computers require a lot of temporary memory. All the presentation's content is loaded into memory and the file (from which the presentation was loaded) stops being used.

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this Python code:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

But this method consumes around 1.6 GB of temporary memory.

### **Load a Large Presentation as a BLOB**

By using BLOB handling, you can load a large presentation while using little memory. This Python code shows how to use BLOB handling to load a large presentation file (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Change the Folder for Temporary Files**

When the BLOB process is used, your computer creates temporary files in the default folder for temporary files. If you want the temporary files to be kept in a different folder, you can change the settings for storage using [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}

When you use [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides does not automatically create a folder to store temporary files. You have to create the folder manually.

{{% /alert %}}

### **Dispose of Presentation Objects to Release Memory**

When processing large presentations, ensure that the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance is properly disposed of so that the memory it occupied is released. Call [Presentation.dispose](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#dispose) after you have finished using the presentation to free unmanaged resources.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...process the presentation...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Explicitly release resources.
    presentation.dispose()
```

## **FAQ**

**What data in an Aspose.Slides presentation is treated as a BLOB and controlled by BLOB options?**

Large binary objects such as images, audio, and video are treated as BLOBs. The whole presentation file also involves BLOB handling when it’s loaded or saved. These objects are governed by BLOB policies that let you manage memory usage and spill to temporary files when needed.

**Where do I configure BLOB handling rules during presentation loading?**

Use [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) with [BlobManagementOptions](https://reference.aspose.com/slides/python-java/aspose.slides/blobmanagementoptions/). There you set the in-memory limit for BLOBs, allow or disallow temporary files, choose the root path for temp files, and select source locking behavior.

**Do BLOB settings affect performance, and how do I balance speed vs memory?**

Yes. Keeping BLOBs in memory maximizes speed but increases RAM consumption; lowering the memory limit shifts more work to temporary files, reducing RAM at the cost of additional I/O. Use the [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) method to reach the right balance for your workload and environment.

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**

Yes. [BlobManagementOptions](https://reference.aspose.com/slides/python-java/aspose.slides/blobmanagementoptions/) is designed for such scenarios: enabling temporary files and using source locking can significantly reduce peak RAM use and stabilize processing for very large decks.

**Can I use BLOB policies when loading from streams instead of disk files?**

Yes. The same rules apply to streams: the presentation instance can own and lock the input stream (depending on the chosen locking mode), and temporary files are used when allowed, keeping memory usage predictable during processing.
