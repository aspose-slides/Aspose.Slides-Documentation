---
title: Open a Presentation in Python
linktitle: Open Presentation
type: docs
weight: 20
url: /python-net/open-presentation/
keywords:
- open PowerPoint
- open presentation
- open PPTX
- open PPT
- open ODP
- load presentation
- load PPTX
- load PPT
- load ODP
- protected presentation
- large presentation
- Python
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) and OpenDocument (.odp) presentations effortlessly with Aspose.Slides for Python via .NET—fast, reliable, fully featured."
---

## **Overview**

Beyond creating PowerPoint presentations from scratch, Aspose.Slides also lets you open existing presentations. After loading a presentation, you can retrieve information about it, edit slide content, add new slides, remove existing ones, and more.

## **Open Presentations**

To open an existing presentation, instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the file path to its constructor.

This Python example shows how to open a presentation and get its slide count:

```python
import aspose.slides as slides

# Instantiate the Presentation class and pass a file path to its constructor.
with slides.Presentation("sample.pptx") as presentation:
    # Print the total number of slides in the presentation.
    print(presentation.slides.length)
```

## **Open Password Protected Presentations**

When you need to open a password-protected presentation, pass the password through the `password` property of the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class to decrypt and load it. The following Python code demonstrates this operation:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # ...
```

## **Open Large Presentations**

Aspose.Slides provides options—particularly the `blob_management_options` property in the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class—to help you load large presentations.

This Python code demonstrates loading a large presentation (for example, 2 GB):

```python
import aspose.slides as slides
import os

load_options = slides.LoadOptions()
load_options.blob_management_options = slides.BlobManagementOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("sample.pptx", load_options) as presentation:
    # The large presentation has been loaded and can be used, while memory consumption remains low.

    # Make changes to the presentation.
    presentation.slides[0].name = "Very large presentation"

    # Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    os.remove("sample.pptx")

# It is OK to do it here. The source file is no longer locked by the presentation object.
os.remove("sample.pptx")
```

{{% alert color="info" title="Info" %}}

To work around certain limitations when working with streams, Aspose.Slides may copy a stream’s contents. Loading a large presentation from a stream causes the presentation to be copied and can slow loading. Therefore, when you need to load a large presentation, we strongly recommend using the presentation file path rather than a stream.

When creating a presentation that contains large objects (video, audio, high-resolution images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/python-net/manage-blob/) to reduce memory consumption.

{{%/alert %}}

## **Load Presentations**

Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) interface with a single method that lets you manage external resources. The following Python code shows how to use the `IResourceLoadingCallback` interface:

```python
# [TODO[not_supported_yet]: python implementation of .NET interfaces]
```

## **Open and Save Presentations**

Follow these steps to open and save a presentation in Python:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the path of the file you want to open to its constructor.
2. Save the presentation.

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPT file.
with slides.Presentation("sample.ppt") as presentation:
    
    #...do some work here...

    # Save the presentation to a file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```
