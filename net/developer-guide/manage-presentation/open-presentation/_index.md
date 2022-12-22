---
title: Open Presentation in .NET
linktitle: Open Presentation
type: docs
weight: 20
url: /net/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, C#, Csharp, .NET"
description: "Open PowerPoint Presentation and save into many supported formats using C# and perform conversions e.g. ppt to pptx, pptx to pdf, odp to ppt etc."
---

## Open Presentation
Besides creating presentations from scratch, Aspose.Slides allows you to edit or modify existing presentations. First, you have to open the presentation using the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.

This C# code shows you how to open a PowerPoint presentation and then print out the number of its slides:

```c#
// Opens the presentation file by passing the file path to the constructor of the Presentation class
Presentation pres = new Presentation("OpenPresentation.pptx");

// Prints the total number of slides present in the presentation
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## Open Large Presentation
Aspose.Slides provides a facility that allows you to open large presentations. For example, if you have a 2 GB presentation, you can easily open it with this code:

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // let's choose the KeepLocked behavior - the "veryLargePresentation.pptx" will be locked for
        // the Presentation's instance lifetime, but we don't need to load it into memory or copy into
        // the temporary file
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // the huge presentation has been loaded and can be used, but the memory consumption is still low.

    // makes changes to the presentation.
    pres.Slides[0].Name = "Very large presentation";

    // presentation will be saved to the other file. The memory consumptions stays low during saving.
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // can't do that! IO exception will be thrown because the file is locked while pres objects will
    // not be disposed
    File.Delete(pathToVeryLargePresentationFile);
}

// you can do it here. The source file is not locked by the pres object
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

When you have to create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/net/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation
Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) interface to allow you to manage external resources loading for presentations. The interface has a single method.

These snippets show you how to use the [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) interface to load presentations:

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
            try // loads substitute image
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
            // sets substitute url
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // skips all other images
        return ResourceLoadingAction.Skip;
    }
}
```

<h2>Open and Save Presentation</h2>

<a name="csharp-open-save-presentation"><strong>Steps: Open and Save Presentation in C#</strong></a>

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class with and load the presentation.
2. Save the presentation.

```c#
// Loads any supported presentation e.g., ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```
