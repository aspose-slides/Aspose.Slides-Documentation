---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /net/remove-slide-from-presentation/
keywords: "Remove slide, Delete slide, PowerPoint, Presentation, C#, Csharp, .NET, Aspose.Slides"
description: "Remove slide from PowerPoint by reference or index in C# or .NET"
---

## Overview
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for .NET offers few methods to do so. In this topic, we will explore these methods to accomplish this task. We know that [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class in Aspose.Slides for .NET represents a presentation file. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class encapsulates a [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

1. Using Slide Reference
1. Using Slide Index
## **Remove Slide by Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Id or Index.
1. Remove the referenced slide from the presentation.
1. Write the modified presentation file.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Accessing a slide using its index in the slides collection
    ISlide slide = pres.Slides[0];

    // Removing a slide using its reference
    pres.Slides.Remove(slide);

    //Writing the presentation file
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Remove Slide by Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Remove the slide from the presentation by using its index position.
1. Write the modified presentation file.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Removing a slide using its slide index
    pres.Slides.RemoveAt(0);

    // Writing the presentation file
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

