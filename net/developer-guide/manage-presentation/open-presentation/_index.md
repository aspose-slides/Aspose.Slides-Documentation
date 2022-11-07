---
title: Open Presentation in .NET
linktitle: Open Presentation
type: docs
weight: 20
url: /net/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, C#, Csharp, .NET"
description: "Open PowerPoint Presentation and save into many supported formats using C# and perform conversions e.g. ppt to pptx, pptx to pdf, odp to ppt etc."
---

## Overview

This article is part of the following two articles.

- [Open Presentation](https://docs.aspose.com/slides/net/open-presentation/)
- [Save Presentation](https://docs.aspose.com/slides/net/save-presentation/)

<strong>Topics Covered</strong>

The above articles together cover such topics. e.g.

- [C# Convert PPT to ODP](#csharp-open-save-presentation)
- [C# Convert ODP to PPTX](#csharp-open-save-presentation)
- [C# PPTX to PPT Code](#csharp-open-save-presentation)
- [See Also](#see-also)

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

## Open and Save Presentation

<a name="csharp-open-save-presentation"><strong>Steps: Open and Save Presentation in C#</strong></a>

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class with any format i.e. PPT, PPTX, ODP etc.
2. Save _Presentation_ to any format supported by [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Load any supported file in Presentation e.g. ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## See Also 

This article also covers these topics. The codes are same as above.

_Format_: **PPTX**
- [C# PPTX to PPT](#csharp-open-save-presentation)
- [C# PPTX to ODP](#csharp-open-save-presentation)
- [C# PPTX to PPS](#csharp-open-save-presentation)
- [C# PPTX to PDF](#csharp-open-save-presentation)
- [C# PPTX to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert PPTX to PPT](#csharp-open-save-presentation)
- [C# Convert PPTX to ODP](#csharp-open-save-presentation)
- [C# Convert PPTX to PPS](#csharp-open-save-presentation)
- [C# Convert PPTX to PDF](#csharp-open-save-presentation)
- [C# Convert PPTX to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# PPTX to PPT Programmatically](#csharp-open-save-presentation)
- [C# PPTX to ODP Programmatically](#csharp-open-save-presentation)
- [C# PPTX to PPS Programmatically](#csharp-open-save-presentation)
- [C# PPTX to PDF Programmatically](#csharp-open-save-presentation)
- [C# PPTX to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# PPTX to PPT API](#csharp-open-save-presentation)
- [C# PPTX to ODP API](#csharp-open-save-presentation)
- [C# PPTX to PPS API](#csharp-open-save-presentation)
- [C# PPTX to PDF API](#csharp-open-save-presentation)
- [C# PPTX to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# PPTX to PPT Code](#csharp-open-save-presentation)
- [C# PPTX to ODP Code](#csharp-open-save-presentation)
- [C# PPTX to PPS Code](#csharp-open-save-presentation)
- [C# PPTX to PDF Code](#csharp-open-save-presentation)
- [C# PPTX to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# PPTX to PPT Library](#csharp-open-save-presentation)
- [C# PPTX to ODP Library](#csharp-open-save-presentation)
- [C# PPTX to PPS Library](#csharp-open-save-presentation)
- [C# PPTX to PDF Library](#csharp-open-save-presentation)
- [C# PPTX to XPS Library](#csharp-open-save-presentation)

_Format_: **PPT**
- [C# PPT to PPTX](#csharp-open-save-presentation)
- [C# PPT to ODP](#csharp-open-save-presentation)
- [C# PPT to PPS](#csharp-open-save-presentation)
- [C# PPT to PDF](#csharp-open-save-presentation)
- [C# PPT to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert PPT to PPTX](#csharp-open-save-presentation)
- [C# Convert PPT to ODP](#csharp-open-save-presentation)
- [C# Convert PPT to PPS](#csharp-open-save-presentation)
- [C# Convert PPT to PDF](#csharp-open-save-presentation)
- [C# Convert PPT to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# PPT to PPTX Programmatically](#csharp-open-save-presentation)
- [C# PPT to ODP Programmatically](#csharp-open-save-presentation)
- [C# PPT to PPS Programmatically](#csharp-open-save-presentation)
- [C# PPT to PDF Programmatically](#csharp-open-save-presentation)
- [C# PPT to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# PPT to PPTX API](#csharp-open-save-presentation)
- [C# PPT to ODP API](#csharp-open-save-presentation)
- [C# PPT to PPS API](#csharp-open-save-presentation)
- [C# PPT to PDF API](#csharp-open-save-presentation)
- [C# PPT to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# PPT to PPTX Code](#csharp-open-save-presentation)
- [C# PPT to ODP Code](#csharp-open-save-presentation)
- [C# PPT to PPS Code](#csharp-open-save-presentation)
- [C# PPT to PDF Code](#csharp-open-save-presentation)
- [C# PPT to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# PPT to PPTX Library](#csharp-open-save-presentation)
- [C# PPT to ODP Library](#csharp-open-save-presentation)
- [C# PPT to PPS Library](#csharp-open-save-presentation)
- [C# PPT to PDF Library](#csharp-open-save-presentation)
- [C# PPT to XPS Library](#csharp-open-save-presentation)

_Format_: **ODP**
- [C# ODP to PPTX](#csharp-open-save-presentation)
- [C# ODP to PPT](#csharp-open-save-presentation)
- [C# ODP to PPS](#csharp-open-save-presentation)
- [C# ODP to PDF](#csharp-open-save-presentation)
- [C# ODP to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert ODP to PPTX](#csharp-open-save-presentation)
- [C# Convert ODP to PPT](#csharp-open-save-presentation)
- [C# Convert ODP to PPS](#csharp-open-save-presentation)
- [C# Convert ODP to PDF](#csharp-open-save-presentation)
- [C# Convert ODP to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# ODP to PPTX Programmatically](#csharp-open-save-presentation)
- [C# ODP to PPT Programmatically](#csharp-open-save-presentation)
- [C# ODP to PPS Programmatically](#csharp-open-save-presentation)
- [C# ODP to PDF Programmatically](#csharp-open-save-presentation)
- [C# ODP to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# ODP to PPTX API](#csharp-open-save-presentation)
- [C# ODP to PPT API](#csharp-open-save-presentation)
- [C# ODP to PPS API](#csharp-open-save-presentation)
- [C# ODP to PDF API](#csharp-open-save-presentation)
- [C# ODP to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# ODP to PPTX Code](#csharp-open-save-presentation)
- [C# ODP to PPT Code](#csharp-open-save-presentation)
- [C# ODP to PPS Code](#csharp-open-save-presentation)
- [C# ODP to PDF Code](#csharp-open-save-presentation)
- [C# ODP to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# ODP to PPTX Library](#csharp-open-save-presentation)
- [C# ODP to PPT Library](#csharp-open-save-presentation)
- [C# ODP to PPS Library](#csharp-open-save-presentation)
- [C# ODP to PDF Library](#csharp-open-save-presentation)
- [C# ODP to XPS Library](#csharp-open-save-presentation)
