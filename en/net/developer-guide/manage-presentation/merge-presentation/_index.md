---
title: Efficiently Merge PowerPoint Presentations (PPT, PPTX) with C#
linktitle: Merge Presentation
type: docs
weight: 40
url: /net/merge-presentation/
keywords: "Merge PowerPoint, PPTX, PPT, combine PowerPoint, merge presentation, combine presentation, C#, Csharp, .NET"
description: "Learn to merge or combine PowerPoint presentations in C# or .NET effortlessly."
---

## **Optimize Your Presentation Merging**

With [Aspose.Slides for .NET](https://products.aspose.com/slides/net/), seamlessly combine PowerPoint presentations while preserving styles, layouts, and all elements. Unlike other tools, Aspose.Slides blends presentations without compromising on quality or losing data. Merge entire presentations, specific slides, and even different file formats (PPT to PPTX, etc.).

### **Merging Features**

- **Full Presentation Merge:** Assemble all slides into a single file.
- **Specific Slide Merge:** Choose and combine selected slides.
- **Cross-Format Merge:** Integrate presentations of varying formats, maintaining integrity.

{{% alert title="Tip" color="primary" %}}  

Looking for a quick and **free online tool** to **merge PowerPoint presentations**? Try the [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **Merge PowerPoint files easily**: Combine multiple **PPT, PPTX, ODP** presentations into a single file.  
- **Supports different formats**: Merge **PPT to PPTX**, **PPTX to ODP**, and more.  
- **No installation required**: Works directly in your browser, fast and secure.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Start merging your PowerPoint files with **Aspose free online tool** today!  

{{% /alert %}}

## **Presentation Merging**

When you [merge one presentation to another](https://products.aspose.com/slides/net/merger/ppt/), you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) , however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data. 

**See also**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **What Can Be Merged**

With Aspose.Slides, you can merge 

* entire presentations. All the slides from the presentations end up in one presentation
* specific slides. Selected slides end up in one presentation
* presentations in one format (PPT to PPT, PPTX to PPTX, etc) and in different formats (PPT to PPTX, PPTX to ODP, etc) to one another. 

{{% alert title="Note" color="warning" %}} 

Besides presentations, Aspose.Slides allows you to merge other files:

* [Images](https://products.aspose.com/slides/net/merger/image-to-image/), such as [JPG to JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) or [PNG to PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Documents, such as [PDF to PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) or [HTML to HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* And two different files such as [image to PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) or [JPG to PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) or [TIFF to PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merging Options**

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) methods (from the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) interface). There are several implementations of the `AddClone` methods that define the presentation merging process parameters. Every Presentation object has a [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) collection, so you can call a `AddClone` method from the presentation to which you want to merge slides. 

The `AddClone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Merge Presentations** 

Aspose.Slides provides the [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) method that allows you to combine slides while the slides retain their layouts and styles (default parameters). 

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

Aspose.Slides provides the [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation. 

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

The slide layout for the slide master is determined automatically. When an appropriate layout can't be determined, if the `allowCloneMissingLayout` boolean parameter of the `AddClone` method is set to true, the layout for the source slide is used. Otherwise, [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) will be thrown. 

{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) method instead when merging. 

## **Merge Specific Slides From Presentations**

Merging specific slides from multiple presentations is useful for creating custom slide decks. Aspose.Slides for .NET allows you to select and import only the slides you need. The API preserves formatting, layout, and design of the original slides.

The following C# code creates a new presentation, adds title slides from two other presentations, and saves the result to a file:

```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```
```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
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

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}

## **FAQ**

**Are speaker notes preserved during merge?**

Yes. When cloning slides, Aspose.Slides carries over all slide elements, including notes, formatting, and animations.

**Are comments and their authors transferred?**

Comments, as part of slide content, are copied with the slide. Comment author labels are preserved as comment objects in the resulting presentation.

**What if the source presentation is password-protected?**

It must be [opened with the password](/slides/net/password-protected-presentation/) via [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); after loading, those slides can be safely cloned into an unprotected target file (or a protected one as well).

**How thread-safe is the merge operation?**

Do not use the same [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance from [multiple threads](/slides/net/multithreading/). The recommended rule is "one document — one thread"; different files can be processed in parallel in separate threads.
