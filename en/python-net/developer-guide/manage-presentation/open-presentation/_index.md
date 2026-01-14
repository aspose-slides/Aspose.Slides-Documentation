---
title: Open Presentations in Python
linktitle: Open Presentations
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
- external resource
- binary object
- Python
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) and OpenDocument (.odp) presentations effortlessly with Aspose.Slides for Python via .NET—fast, reliable, fully featured."
---

## **Overview**

Beyond creating PowerPoint presentations from scratch, Aspose.Slides also lets you open existing presentations. After loading a presentation, you can retrieve information about it, edit slide content, add new slides, remove existing ones, and more.

## **Open Presentations**

To open an existing presentation, instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the file path to its constructor.

The following Python example shows how to open a presentation and get its slide count:

```python
import aspose.slides as slides

# Instantiate the Presentation class and pass a file path to its constructor.
with slides.Presentation("sample.pptx") as presentation:
    # Print the total number of slides in the presentation.
    print(presentation.slides.length)
```

## **Open Password-Protected Presentations**

When you need to open a password-protected presentation, pass the password through the [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) property of the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class to decrypt and load it. The following Python code demonstrates this operation:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Perform operations on the decrypted presentation.
```

## **Open Large Presentations**

Aspose.Slides provides options—particularly the [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) property in the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class—to help you load large presentations.

This Python code demonstrates loading a large presentation (for example, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of 
# the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # The large presentation has been loaded and can be used, while memory consumption remains low.

    # Make changes to the presentation.
    presentation.slides[0].name = "Large presentation"

    # Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    os.remove(file_path)

# It is OK to do it here. The source file is no longer locked by the presentation object.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}

To work around certain limitations when working with streams, Aspose.Slides may copy a stream’s contents. Loading a large presentation from a stream causes the presentation to be copied and can slow loading. Therefore, when you need to load a large presentation, we strongly recommend using the presentation file path rather than a stream.

When creating a presentation that contains large objects (video, audio, high-resolution images, etc.), you can use [BLOB management](/slides/python-net/manage-blob/) to reduce memory consumption.

{{%/alert %}}

## **Control External Resources**

Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) class that lets you manage external resources. The following Python code shows how to use the `IResourceLoadingCallback` class:

```python
# [TODO[not_supported_yet]: python implementation of .NET interfaces]
```

## **Load Presentations Without Embedded Binary Objects**

A PowerPoint presentation can contain the following types of embedded binary objects:

- VBA project (accessible via [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- OLE object embedded data (accessible via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX control binary data (accessible via [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

Using the [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) property, you can load a presentation without any embedded binary objects.

This property is useful for removing potentially malicious binary content. The following Python code demonstrates how to load a presentation without any embedded binary content:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Perform operations on the presentation.
```

## **FAQ**

**How can I tell that a file is corrupted and can’t be opened?**

You’ll get a parsing/format validation exception during load. Such errors often mention an invalid ZIP structure or broken PowerPoint records.

**What happens if required fonts are missing when opening?**

The file will open, but later [rendering/export](/slides/python-net/convert-presentation/) may substitute fonts. [Configure font substitutions](/slides/python-net/font-substitution/) or [add the required fonts](/slides/python-net/custom-font/) to the runtime environment.

**What about embedded media (video/audio) when opening?**

They become available as presentation resources. If media are referenced via external paths, ensure those paths are accessible in your environment; otherwise [rendering/export](/slides/python-net/convert-presentation/) may omit the media.
