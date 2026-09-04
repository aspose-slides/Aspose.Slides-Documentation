---
title: Open Presentations in C++
linktitle: Open Presentation
type: docs
weight: 20
url: /cpp/open-presentation/
keywords:
- open PowerPoint
- open OpenDocument
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
- C++
- Aspose.Slides
description: "Learn how to open PowerPoint and OpenDocument presentations in C++, supply opening passwords, control resource loading, and reduce memory use with Aspose.Slides for C++."
---

## **Introduction**

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) can load PowerPoint and OpenDocument presentations from files and streams. After a presentation is loaded, you can inspect its structure, edit slides, manage resources, and save it in the original or another supported format.

Loading behavior can be customized through the [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) class. For example, you can supply an opening password, keep large binary objects outside memory, control external resources, or omit embedded binary data.

## **Open Presentations**

To open an existing presentation, pass its file path to the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) constructor. Dispose the presentation after use so that file handles, temporary data, and other resources are released promptly.

The following C++ example shows how to open a presentation and get its slide count:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Open Password-Protected Presentations**

An opening password encrypts presentation content. To load the complete presentation, pass the correct password to [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) and pass the options to the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) constructor. Loading fails when the password is missing or incorrect.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/cpp/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/cpp/presentation-properties/).

## **Open Large Presentations**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) controls how Aspose.Slides handles binary large objects such as images, audio, and video. You can keep the source file locked, allow temporary files, and limit the amount of BLOB data retained in memory.

The following C++ code demonstrates loading a large presentation (for example, 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

With `PresentationLockingBehavior::KeepLocked`, the source file remains locked until the `Presentation` object is disposed. Do not move, overwrite, or delete the source file while that object is alive.

Aspose.Slides may copy the contents of an input stream while loading it. For large presentations, a file path is therefore generally more efficient than a stream. See [Manage BLOBs](/slides/cpp/manage-blob/) for additional storage and memory-management options.

{{% /alert %}}

## **Control External Resources**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accepts an [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) implementation. The callback can supply replacement data, redirect a resource, use the default loader, or skip the resource. This is useful when presentations contain external images that must be resolved according to application-specific security or storage rules.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Load Presentations without Embedded Binary Objects**

A presentation may contain embedded binary data that an application does not need or does not want to retain. Examples include:

- VBA projects, available through [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/);
- embedded OLE data, available through [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- ActiveX control data, available through [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Pass `true` to [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) to remove this binary data while loading. Save the loaded presentation to persist the sanitized result.

This option reduces exposure to unwanted embedded payloads, but it is not a complete malware-detection or content-sanitization system.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **FAQ**

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides throws a parsing or format exception during loading. Handle that failure separately from an incorrect-password error so that the application can report the cause accurately.

**What happens if required fonts are missing?**

The presentation can still load, but rendering and export may substitute fonts. You can [configure font substitution](/slides/cpp/font-substitution/) or [provide custom fonts](/slides/cpp/custom-font/) to make output more predictable.

**Does loading a presentation also load its embedded media?**

Embedded audio and video become available through the presentation object model. External resources are resolved according to the configured resource-loading behavior and may be unavailable if their locations cannot be accessed.
