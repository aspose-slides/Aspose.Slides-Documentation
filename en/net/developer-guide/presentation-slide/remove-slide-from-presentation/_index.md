---
title: Remove Slides from Presentations in .NET
linktitle: Remove Slide
type: docs
weight: 30
url: /net/remove-slide-from-presentation/
keywords:
- remove slide
- delete slide
- remove unused slide
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Effortlessly remove slides from PowerPoint and OpenDocument presentations with Aspose.Slides for .NET. Get clear C# code examples and boost your workflow."
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

## **FAQ**

**What happens to slide indexes after I delete a slide?**

After deletion, the [collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) reindexes: every subsequent slide shifts left by one position, so previous index numbers become outdated. If you need a stable reference, use each slide’s persistent ID rather than its index.

**Is a slide’s ID different from its index, and does it change when neighboring slides are deleted?**

Yes. The index is the slide’s position and will change when slides are added or removed. The slide ID is a persistent identifier and does not change when other slides are deleted.

**How does deleting a slide affect slide sections?**

If the slide belonged to a section, that section will simply contain one fewer slide. The section structure remains; if a section becomes empty, you can [remove or reorganize sections](/slides/net/slide-section/) as needed.

**What happens to notes and comments attached to a slide when it’s deleted?**

[Notes](/slides/net/presentation-notes/) and [comments](/slides/net/presentation-comments/) are tied to that specific slide and are removed along with it. Content on other slides is unaffected.

**How is deleting slides different from cleaning up unused layouts/masters?**

Deleting removes specific normal slides from the deck. Cleaning up unused layouts/masters removes layout or master slides that nothing references, reducing file size without changing remaining slide content. These actions are complementary: typically delete first, then clean up.
