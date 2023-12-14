---
title: Open Presentation - C++ PowerPoint API
linktitle: Open Presentation
type: docs
weight: 20
url: /cpp/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, C++, CPP"
description: "Open or load Presentation PPT, PPTX, ODP in C++"
---

Besides creating PowerPoint presentations from scratch, Aspose.Slides allows you to open existing presentations. After you load a presentation, you can get information about the presentation, edit the presentation (content on its slides), add new slides or remove existing ones, etc. 

## Open Presentation

To open an existing presentation, you simply have to instantiate the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and pass the file path (of the presentation you want to open) to its contructor. 

This C++ code shows you how to open a presentation and also find out the number of slides it contains: 

```c++
// The path to the documents directory.
String dataDir = u"";

// Instantiates the Presentation class and passes the file path to its constructor
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// Prints the total number of slides present in the presentation
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **Open Password Protected Presentation**

When you have to open a password-protected presentation, you can pass the password through the [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) property (from the [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) class) to decrypt the presentation and load the presentation. This C++ code demonstrates the operation:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// Do some work with the decrypted presentation
```

## Open Large Presentation

Aspose.Slides provides options (the [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) property in particular) under the [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) class to allow you to load large presentations. 

This C++ demonstrates an operation in which a large presentation (say 2gb in size) is loaded:

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // let's choose the KeepLocked behavior - the "veryLargePresentation.pptx" will be locked for
    // the Presentation's instance lifetime, but we don't need to load it into memory or copy into
    // the temporary file
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // The large presentation has been loaded and can be used, but the memory consumption is still low.

    // Makes changes to the presentation.
    pres->get_Slides()->idx_get(0)->set_Name(u"Very large presentation");

    // The presentation will be saved to the other file. The memory consumption stays low during the operation
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // can't do that! IO exception will be thrown because the file is locked while pres objects will
    // not be disposed
    File::Delete(pathToVeryLargePresentationFile);
}

// It is ok to do it here. The source file is not locked by the pres object
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

When you want create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/cpp/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation

Aspose.Slides provides [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) with a single method to allow you to manage external resources. This C++ code shows you how to use the `IResourceLoadingCallback` interface:

```c++
// The path to the documents directory.
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Sets substitute url
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Skips all other images
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>Open and Save Presentation</h2>

<a name="cplusplus-open-save-presentation"><strong>Steps: Open and Save Presentation in C++</strong></a>

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and pass the file you want to open. 

2. Save the presentation. 

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...do some work here..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```
   
