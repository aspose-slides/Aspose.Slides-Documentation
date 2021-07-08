---
title: Open Presentation
type: docs
weight: 30
url: /cpp/open-presentation/
---

## **Open Presentation**
Using Aspose.Slides for C++, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

Aspose.Slides for C++ provides Presentation class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation.In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen. The following example shows how to Open a Presentation.

``` cpp
// The path to the documents directory.
String dataDir = u"";

// Opening the presentation file by passing the file path to the constructor of Presentation class
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// Printing the total number of slides present in the presentation
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```



## **Open Large Presentation**
Aspose.Slides for C++ provides facility to open very large presentations using Presentation class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

``` cpp
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // let's choose the KeepLocked behavior - the "veryLargePresentation.pptx" will be locked for
    // the Presentation's instance lifetime, but we don't need to load it into memory or copy into
    // the temporary file
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // the huge presentation is loaded and ready to use, but the memory consumption is still low.

    // make any changes to the presentation.
    pres->get_Slides()->idx_get(0)->set_Name(u"Very large presentation");

    // presentation will be saved to the other file, the memory consumptions still low during saving.
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // can't do that! IO exception will be thrown, because the file is locked while pres objects will
    // not be disposed
    File::Delete(pathToVeryLargePresentationFile);
}

// it's ok to do it here, the source file is not locked by pres object
File::Delete(pathToVeryLargePresentationFile);
```


## **Load Presentation**
New IResourceLoadingCallback interface has been added. This callback interface is used to manage external resources loading and has one method:

The code snippet below shows how to use IResourceLoadingCallback interface:

``` cpp
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
            // set substitute url
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // skip all other images
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```
