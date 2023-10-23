---
title: Access Slide in Presentation
type: docs
weight: 20
url: /net/access-slide-in-presentation/
keywords: "Access PowerPoint Presentation, Access slide, Edit slide properties, Change slide position, Set slide number, index, ID, position  C#, Csharp, .NET, Aspose.Slides"
description: "Access PowerPoint slide by index, ID, or position in C# or .NET. Edit slide properties"
---

Aspose.Slides allows you to access slides in two ways: by index and by ID.

## **Access Slide by Index**

All slides in a presentation are arranged numerically based on the slide position starting from 0. The first slide is accessible through index 0; the second slide is accessed through index 1; etc.

The Presentation class, representing a presentation file, exposes all slides as an [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) collection (collection of [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) objects). This C# code shows you how to access a slide through its index:

```c#
// Instantiates a Presentation object that represents a presentation file
Presentation presentation = new Presentation("AccessSlides.pptx");

// Gets a slide's reference through its index
ISlide slide = presentation.Slides[0];
```

## **Access Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) method (exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class) to target that ID. This C# code shows you how to provide a valid slide ID and access that slide through the [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) method:

```c#
// Instantiates a Presentation object that represents a presentation file
Presentation presentation = new Presentation("AccessSlides.pptx");

// Gets a slide ID
uint id = presentation.Slides[0].SlideId;

// Accesses the slide through its ID
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Change Slide Position**
Aspose.Slides allow you to change a slide position. For example, you can specify that the first slide should become the second slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get the slide's reference (whose position you want to change) through its index
1. Set a new position for the slide through the [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) property. 
1. Save the modified presentation.

This C# code demonstrates an operation in which the slide in position 1 is moved to position 2:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Gets the slide whose position will be changed
    ISlide sld = pres.Slides[0];

    // Sets the new position for the slide
    sld.SlideNumber = 2;

    // Saves the modified presentation
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

The first slide became the second; the second slide became the first. When you change a slide's position, other slides are automatically adjusted.


## **Set Slide Number**
Using the [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) property (exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get the slide number.
1. Set the slide number.
1. Save the modified presentation.

This C# code demonstrates an operation where the first slide number is set to 10:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Gets the slide number
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Sets the slide number
    presentation.FirstSlideNumber=10;
    
    // Saves the modified presentation
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

If you prefer to skip the first slide, you can start the numbering from the second slide (and hide the numbering for the first slide) this way:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Sets the number for the first presentation slide
    presentation.FirstSlideNumber = 0;

    // Shows slide numbers for all slides
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Hides the slide number for the first slide
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Saves the modified presentation
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```
