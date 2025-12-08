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
description: "Open PowerPoint (.pptx, .ppt) and OpenDocument (.odp) presentations effortlessly with Aspose.Slides for C++—fast, reliable, fully featured."
---

## **Overview**

Beyond creating PowerPoint presentations from scratch, Aspose.Slides also lets you open existing presentations. After loading a presentation, you can retrieve information about it, edit slide content, add new slides, remove existing ones, and more.

## **Open Presentations**

To open an existing presentation, instantiate the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and pass the file path to its constructor.

The following C++ example shows how to open a presentation and get its slide count:

```cpp
// Instantiate the Presentation class and pass a file path to its constructor.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Print the total number of slides in the presentation.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Open Password-Protected Presentations**

When you need to open a password-protected presentation, pass the password through the [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) method of the [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) class to decrypt and load it. The following C++ code demonstrates this operation:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Perform operations on the decrypted presentation.

presentation->Dispose();
```

## **Open Large Presentations**

Aspose.Slides provides options—particularly the [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) method in the [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) class—to help you load large presentations.

The following C++ code demonstrates loading a large presentation (for example, 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// The large presentation has been loaded and can be used, while memory consumption remains low.

// Make changes to the presentation.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Save the presentation to another file. Memory consumption remains low during this operation.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
File::Delete(filePath);

presentation->Dispose();

// It is OK to do it here. The source file is no longer locked by the presentation object.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}

To work around certain limitations when working with streams, Aspose.Slides may copy a stream’s contents. Loading a large presentation from a stream causes the presentation to be copied and can slow loading. Therefore, when you need to load a large presentation, we strongly recommend using the presentation file path rather than a stream.

When creating a presentation that contains large objects (video, audio, high-resolution images, etc.), you can use [BLOB management](/slides/cpp/manage-blob/) to reduce memory consumption.

{{%/alert %}}

## **Control External Resources**

Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) interface that lets you manage external resources. The following C++ code shows how to use the `IResourceLoadingCallback` interface:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Load a substitute image.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Set a substitute URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Skip all other images.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Load Presentations without Embedded Binary Objects**

A PowerPoint presentation can contain the following types of embedded binary objects:

- VBA project (accessible via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/));
- OLE object embedded data (accessible via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ActiveX control binary data (accessible via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Using the [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) method, you can load a presentation without any embedded binary objects.

This method is useful for removing potentially malicious binary content. The following C++ code demonstrates how to load a presentation without any embedded binary content:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **FAQ**

**How can I tell that a file is corrupted and can’t be opened?**

You’ll get a parsing/format validation exception during load. Such errors often mention an invalid ZIP structure or broken PowerPoint records.

**What happens if required fonts are missing when opening?**

The file will open, but later [rendering/export](/slides/cpp/convert-presentation/) may substitute fonts. [Configure font substitutions](/slides/cpp/font-substitution/) or [add the required fonts](/slides/cpp/custom-font/) to the runtime environment.

**What about embedded media (video/audio) when opening?**

They become available as presentation resources. If media are referenced via external paths, ensure those paths are accessible in your environment; otherwise [rendering/export](/slides/cpp/convert-presentation/) may omit the media.
