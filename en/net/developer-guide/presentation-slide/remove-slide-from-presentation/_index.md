---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /net/remove-slide-from-presentation/
keywords: "Remove slide, Delete slide, PowerPoint, Presentation, C#, Csharp, .NET, Aspose.Slides"
description: "Remove slide from PowerPoint by reference or index in C# or .NET"

---

If a slide (or its contents) becomes redundant, you can delete it. Aspose.Slides provides the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class that encapsulates [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), which is a repository for all slides in a presentation. Using pointers (reference or index) for a known [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) object, you can specify the slide you want to remove. 

## **Remove Slide by Reference**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference of the slide you want to remove through its ID or Index.
1. Remove the referenced slide from the presentation.
1. Save the modified presentation. 

This C# code shows you how to remove a slide through its reference:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Accesses a slide through its index in the slides collection
    ISlide slide = pres.Slides[0];

    // Removes a slide through its reference
    pres.Slides.Remove(slide);

    // Saves the modified presentation
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Remove Slide by Index**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Remove the slide from the presentation through its index position.
1. Save the modified presentation. 

This C# code shows you how to remove a slide through its index:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Removes a slide through its slide index
    pres.Slides.RemoveAt(0);

    // Saves the modified presentation
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method (from the [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused layout slides. This C# code shows you how to remove a layout slide from a PowerPoint presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Remove Unused Master Slide**

Aspose.Slides provides the [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) method (from the [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused master slides. This C# code shows you how to remove a master slide from a PowerPoint presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```
