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
description: "Learn how to open PowerPoint and OpenDocument presentations in Python, supply opening passwords, and reduce memory use with Aspose.Slides for Python via .NET."
---

## **Introduction**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/) can load PowerPoint and OpenDocument presentations from files and streams. After a presentation is loaded, you can inspect its structure, edit slides, manage resources, and save it in the original or another supported format.

Loading behavior can be customized through the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class. For example, you can supply an opening password, keep large binary objects outside memory, or omit embedded binary data.

## **Open Presentations**

To open an existing presentation, pass its file path to the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) constructor. Use a `with` statement so that file handles, temporary data, and other resources are released promptly.

The following Python example shows how to open a presentation and get its slide count:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Open Password-Protected Presentations**

An opening password encrypts presentation content. To load the complete presentation, assign the correct password to [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) and pass the options to the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) constructor. Loading fails when the password is missing or incorrect.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/python-net/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/python-net/presentation-properties/).

## **Open Large Presentations**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) controls how Aspose.Slides handles binary large objects such as images, audio, and video. You can keep the source file locked, allow temporary files, and limit the amount of BLOB data retained in memory.

This Python code demonstrates loading a large presentation (for example, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}

With `PresentationLockingBehavior.KEEP_LOCKED`, the source file remains locked until the `Presentation` object is disposed. Do not move, overwrite, or delete the source file while that object is alive.

Aspose.Slides may copy the contents of an input stream while loading it. For large presentations, a file path is therefore generally more efficient than a stream. See [Manage BLOBs](/slides/python-net/manage-blob/) for additional storage and memory-management options.

{{% /alert %}}

## **Load Presentations without Embedded Binary Objects**

A presentation may contain embedded binary data that an application does not need or does not want to retain. Examples include:

- VBA projects, available through [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/);
- embedded OLE data, available through [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX control data, available through [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/).

Set [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) to `True` to remove this binary data while loading. Save the loaded presentation to persist the sanitized result.

This option reduces exposure to unwanted embedded payloads, but it is not a complete malware-detection or content-sanitization system.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides raises a parsing or format exception during loading. Handle that failure separately from an incorrect-password error so that the application can report the cause accurately.

**What happens if required fonts are missing?**

The presentation can still load, but rendering and export may substitute fonts. You can [configure font substitution](/slides/python-net/font-substitution/) or [provide custom fonts](/slides/python-net/custom-font/) to make output more predictable.

**Does loading a presentation also load its embedded media?**

Embedded audio and video become available through the presentation object model. External resources are resolved according to the default resource-loading behavior and may be unavailable if their locations cannot be accessed.
