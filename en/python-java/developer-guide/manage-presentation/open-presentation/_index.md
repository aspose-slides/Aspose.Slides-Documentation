---
title: Open Presentations in Python via Java
linktitle: Open Presentation
type: docs
weight: 20
url: /python-java/open-presentation/
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
- Java
- Aspose.Slides
description: "Learn how to open PowerPoint and OpenDocument presentations in Python via Java, supply opening passwords, control resource loading, and reduce memory use with Aspose.Slides for Python via Java."
---

## **Introduction**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) can load PowerPoint and OpenDocument presentations from files and streams. After a presentation is loaded, you can inspect its structure, edit slides, manage resources, and save it in the original or another supported format.

Loading behavior can be customized through the [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) class. For example, you can supply an opening password, keep large binary objects outside Java heap memory, control external resources, or omit embedded binary data.

## **Open Presentations**

To open an existing presentation, pass its file path to the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) constructor. Dispose the presentation after use so that file handles, temporary data, and other resources are released promptly.

The following Python example shows how to open a presentation and get its slide count:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Open Password-Protected Presentations**

An opening password encrypts presentation content. To load the complete presentation, pass the correct password to [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) and provide the options to the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) constructor. Loading fails when the password is missing or incorrect.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/python-java/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/python-java/presentation-properties/).

## **Open Large Presentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) returns options that control how Aspose.Slides handles binary large objects such as images, audio, and video. You can keep the source file locked, allow temporary files, and limit the amount of BLOB data retained in memory.

The following Python code demonstrates loading a large presentation (for example, 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

With [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), the source file remains locked until the presentation instance is disposed. Do not move, overwrite, or delete the source file while that instance is alive.

Aspose.Slides may copy the contents of an input stream while loading it. For large presentations, a file path is therefore generally more efficient than a stream. See [Manage BLOBs](/slides/python-java/manage-blob/) for additional storage and memory-management options.

{{% /alert %}}

## **Control External Resources**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepts a JPype proxy implementing the Java resource-loading callback interface. The callback can supply replacement data, redirect a resource, use the default loader, or skip the resource. This is useful when presentations contain external images that must be resolved according to application-specific security or storage rules.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Load Presentations without Embedded Binary Objects**

A presentation may contain embedded binary data that an application does not need or does not want to retain. Examples include:

- VBA projects, available through [Presentation.getVbaProject](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getVbaProject);
- embedded OLE data, available through [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX control data, available through [Control.getActiveXControlBinary](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getActiveXControlBinary).

Set [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) to `True` to remove this binary data while loading. Save the loaded presentation to persist the sanitized result.

This option reduces exposure to unwanted embedded payloads, but it is not a complete malware-detection or content-sanitization system.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides throws a parsing or format exception during loading. Handle that failure separately from an incorrect-password error so that the application can report the cause accurately.

**What happens if required fonts are missing?**

The presentation can still load, but rendering and export may substitute fonts. You can [configure font substitution](/slides/python-java/font-substitution/) or [provide custom fonts](/slides/python-java/custom-font/) to make output more predictable.

**Does loading a presentation also load its embedded media?**

Embedded audio and video become available through the presentation object model. External resources are resolved according to the configured resource-loading behavior and may be unavailable if their locations cannot be accessed.
