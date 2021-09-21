---
title: Open Presentation
type: docs
weight: 20
url: /net/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, C#, Csharp, .NET"
description: "Open and load PowerPoint presentation in C# or .NET"
---

## **Open Presentation**
Using Aspose.Slides for .NET, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

Aspose.Slides for .NET provides Presentation class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen. The following example shows how to Open a Presentation.

```c#
// Opening the presentation file by passing the file path to the constructor of Presentation class
Presentation pres = new Presentation("OpenPresentation.pptx");

// Printing the total number of slides present in the presentation
System.Console.WriteLine(pres.Slides.Count.ToString());
```



## **Open Large Presentation**
Aspose.Slides for .NET provides facility to open very large presentations using Presentation class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // let's choose the KeepLocked behavior - the "veryLargePresentation.pptx" will be locked for
        // the Presentation's instance lifetime, but we don't need to load it into memory or copy into
        // thetemporary file
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // the huge presentation is loaded and ready to use, but the memory consumption is still low.

    // make any changes to the presentation.
    pres.Slides[0].Name = "Very large presentation";

    // presentation will be saved to the other file, the memory consumptions still low during saving.
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // can't do that! IO exception will be thrown, because the file is locked while pres objects will
    // not be disposed
    File.Delete(pathToVeryLargePresentationFile);
}

// it's ok to do it here, the source file is not locked by pres object
File.Delete(pathToVeryLargePresentationFile);
```



{{% alert color="info" title="Info" %}}When you have to create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/net/manage-blob/) to reduce memory consumption.{{%/alert %}} 


## **Load Presentation**
New IResourceLoadingCallback interface has been added. This callback interface is used to manage external resources loading and has one method:

The code snippet below shows how to use IResourceLoadingCallback interface:

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // load substitute image
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // set substitute url
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // skip all other images
        return ResourceLoadingAction.Skip;
    }
}
```

