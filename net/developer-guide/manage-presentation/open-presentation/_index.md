---
title: Open Presentation in C#
linktitle: Open Presentation
type: docs
weight: 20
url: /net/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, C#, Csharp, .NET"
description: "Open or load Presentation PPT, PPTX, ODP in C# or .NET"
---

Besides creating PowerPoint presentations from scratch, Aspose.Slides allows you to open existing presentations. After you load a presentation, you can get information about the presentation, edit the presentation (content on its slides), add new slides or remove existing ones, etc. 

## Open Presentation

To open an existing presentation, you simply have to instantiate the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and pass the file path (to the presentation you want to open) to its contructor. 

This C# code shows you how to open a presentation and also find out the number of slides it contains: 

```c#
// Instantiates the Presentation class and passes the file path to its constructor
Presentation pres = new Presentation("OpenPresentation.pptx");

// Prints the total number of slides present in the presentation
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **Open Password-Protected Presentation**

When you have to open a password-protected presentation, you can pass the password through the [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) property (from the [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) class) to decrypt the presentation and load the presentation. This C# code demonstrates the operation:

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // Do some work with the decrypted presentation
	}
```

## Open Large Presentation

Aspose.Slides provides options (the [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) property in particular) under the [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) class to allow you to load large presentations. 

This C# demonstrates an operation in which a large presentation (say 2gb in size) is loaded:

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // Let's choose the KeepLocked behavior - the "veryLargePresentation.pptx" will be locked for
        // the Presentation's instance lifetime, but we don't need to load it into memory or copy into
        // the temporary file
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // The large presentation has been loaded and can be used, but the memory consumption is still low.

    // Makes changes to the presentation.
    pres.Slides[0].Name = "Very large presentation";

    // The presentation will be saved to the other file. The memory consumption stays low during the operation
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // can't do that! IO exception will be thrown, because the file is locked while pres objects will
    // not be disposed
    File.Delete(pathToVeryLargePresentationFile);
}

// It is ok to do it here, the source file is not locked by pres object
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

When you want create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/net/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation
Aspose.Slides provides [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) with a single method to allow you to manage external resources. This C# code shows you how to use the `IResourceLoadingCallback` interface:

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
            try // Loads substitute image
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
            // Sets substitute url
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Skips all other images
        return ResourceLoadingAction.Skip;
    }
}
```

<h2>Open and Save Presentation</h2>

<a name="csharp-open-save-presentation"><strong>Steps: Open and Save Presentation in C#</strong></a>

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and pass the file you want to open. 
2. Save the Presentation.

```c#
// Loads any supported presentation e.g ppt, pptx, odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```
