---
title: Merge Presentation
type: docs
weight: 40
url: /net/merge-presentation/
keywords: "Merge PowerPoint, PPTX, PPT, combine PowerPoint, merge presentation, combine presentation, C#, Csharp, .NET"
description: "Merge or combine PowerPoint Presentation in C# or .NET"
---

{{% alert  title="Tip" color="primary" %}} 

You may want to check out [Aspose free online Merger service](https://products.aspose.app/slides/merger), which allows people to merge presentations. It provides support for merging PowerPoint presentations in the same format (PPT to PPT, PPTX to PPTX, etc.) and for merging presentations in different format (PPT to PPTX, PPTX to ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

When you merge one presentation to another, you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net) , however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data. 

**See also**

You may want to see [Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

With Aspose.Slides, you can merge 

* entire presentations. All the slides from the presentations end up in one presentation
* specific slides. Selected slides end up in one presentation
* presentations in one format (PPT to PPT, PPTX to PPTX, etc) and in different formats (PPT to PPTX, PPTX to ODP, etc) to one another. 

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [AddClone](https://apireference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) methods (from the [ISlideCollection](https://apireference.aspose.com/slides/net/aspose.slides/islidecollection) interface). There are several implementations of the `AddClone` methods that define the presentation merging process parameters. Every Presentation object has a [Slides](https://apireference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) collection, so you can call a `AddClone` method from the presentation to which you want to merge slides. 

The `AddClone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Merge Presentations** 

Aspose.Slides provides the [**AddClone (ISlide)**](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone) method that allows you to combine slides while the slides retain their layouts and styles (default parameters). 

This C# code shows you how to merge presentations:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Presentations with Slide Master**

Aspose.Slides provides the [**AddClone (ISlide, IMasterSlide, Boolean)**](https://apireference.aspose.com/net/slides/aspose.slides.islidecollection/addclone/methods/2) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation. 

This code in C# demonstrates the described operation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 

The slide layout for the slide master is determined automatically. When an appropriate layout can't be determined, if the `allowCloneMissingLayout` boolean parameter of the `AddClone` method is set to true, the layout for the source slide is used. Otherwise, [PptxEditException](https://apireference.aspose.com/slides/net/aspose.slides/pptxeditexception) will be thrown. 

{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [AddClone (ISlide, ILayoutSlide)](https://apireference.aspose.com/net/slides/aspose.slides.islidecollection/addclone/methods/1) method instead when merging. 

## **Merge Specific Slides From Presentations**

This C# code shows you how to select and combine specific slides from different presentations to get one output presentation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Presentations With Slide Layout**

This C# code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Presentations With Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

You cannot merge presentations with different slide sizes. 

{{% /alert %}}

To merge 2 presentations with different slide sizes, you have to resize one of the presentations to make its size match that of the other presentation. 

This sample code demonstrates the described operation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Slides to Presentation Section**

This C# code shows you how to merge a specific slide to a section in a presentation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

The slide is added at the end of the section. 
