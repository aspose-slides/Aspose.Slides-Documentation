---
title: Merge Presentation
type: docs
weight: 40
url: /androidjava/merge-presentation/
keywords: "Merge PowerPoint, PPTX, PPT, combine PowerPoint, merge presentation, combine presentation, Java"
description: "Merge or combine PowerPoint Presentation in Java"
---


{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free online** [Merger app](https://products.aspose.app/slides/merger). It allows people to merge PowerPoint presentations in the same format (PPT to PPT, PPTX to PPTX, etc.) and merge presentations in different formats (PPT to PPTX, PPTX to ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

When you merge one presentation to another, you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data.

**See also**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **What Can Be Merged**

With Aspose.Slides, you can merge 

* entire presentations. All the slides from the presentations end up in one presentation
* specific slides. Selected slides end up in one presentation
* presentations in one format (PPT to PPT, PPTX to PPTX, etc) and in different formats (PPT to PPTX, PPTX to ODP, etc) to one another. 

{{% alert title="Note" color="warning" %}} 

Besides presentations, Aspose.Slides allows you to merge other files:

* [Images](https://products.aspose.com/slides/androidjava/merger/image-to-image/), such as [JPG to JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) or [PNG to PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Documents, such as [PDF to PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) or [HTML to HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* And two different files such as [image to PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) or [JPG to PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) or [TIFF to PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merging Options**

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methods (from the [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) interface). There are several implementations of the `AddClone` methods that define the presentation merging process parameters. Every Presentation object has a [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) collection, so you can call a `AddClone` method from the presentation to which you want to merge slides.

The `AddClone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Merge Presentations** 

Aspose.Slides provides the [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method that allows you to combine slides while the slides retain their layouts and styles (default parameters).

This Java code shows you how to merge presentations:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Merge Presentations with Slide Master**

Aspose.Slides provides the [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation.

This code in Java demonstrates the described operation:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

The slide layout for the slide master is determined automatically. When an appropriate layout can't be determined, if the `allowCloneMissingLayout` boolean parameter of the `AddClone` method is set to true, the layout for the source slide is used. Otherwise, [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) will be thrown.

{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) method instead when merging.

## **Merge Specific Slides From Presentations**

Merging specific slides from multiple presentations is useful for creating custom slide decks. Aspose.Slides for Android via Java allows you to select and import only the slides you need. The API preserves formatting, layout, and design of the original slides.

The following Java code creates a new presentation, adds title slides from two other presentations, and saves the result to a file:

```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Merge Presentations With Slide Layout**

This Java code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Merge Presentations With Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

You cannot merge presentations with different slide sizes. 

{{% /alert %}}

To merge 2 presentations with different slide sizes, you have to resize one of the presentations to make its size match that of the other presentation. 

This sample code demonstrates the described operation:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Merge Slides to Presentation Section**

This Java code shows you how to merge a specific slide to a section in a presentation:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

The slide is added at the end of the section. 

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}