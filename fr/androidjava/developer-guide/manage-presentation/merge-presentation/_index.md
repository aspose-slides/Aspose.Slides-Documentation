---
title: Fusion efficace de présentations sur Android
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/androidjava/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner présentations
- fusionner diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Android
- Java
- Aspose.Slides
description: "Fusionnez facilement des présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Android via Java, simplifiant votre flux de travail."
---

{{% alert  title="Conseil" color="primary" %}} 

You may want to check out **Aspose free online** [application de fusion](https://products.aspose.app/slides/merger). It allows people to merge PowerPoint presentations in the same format (PPT to PPT, PPTX to PPTX, etc.) and merge presentations in different formats (PPT to PPTX, PPTX to ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusion de présentations**

When you merge one presentation to another, you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data.

**See also**

[Cloner les diapositives](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Ce qui peut être fusionné**

With Aspose.Slides, you can merge 

* des présentations complètes. All the slides from the presentations end up in one presentation
* des diapositives spécifiques. Selected slides end up in one presentation
* des présentations dans un même format (PPT to PPT, PPTX to PPTX, etc.) and in different formats (PPT to PPTX, PPTX to ODP, etc.) to one another. 

{{% alert title="Note" color="warning" %}} 

Besides presentations, Aspose.Slides allows you to merge other files:

* [Images](https://products.aspose.com/slides/androidjava/merger/image-to-image/), such as [JPG vers JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) or [PNG vers PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Documents, such as [PDF vers PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) or [HTML vers HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* And two different files such as [image vers PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) or [JPG vers PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) or [TIFF vers PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methods (from the [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) interface). There are several implementations of the `AddClone` methods that define the presentation merging process parameters. Every Presentation object has a [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) collection, so you can call a `AddClone` method from the presentation to which you want to merge slides.

The `AddClone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Fusionner des présentations** 

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


## **Fusionner des présentations avec un masque de diapositive** 

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

## **Fusionner des diapositives spécifiques à partir de présentations** 

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


## **Fusionner des présentations avec une disposition de diapositive** 

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


## **Fusionner des présentations avec des tailles de diapositives différentes** 

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


## **Fusionner des diapositives dans une section de présentation** 

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

{{% alert title="Conseil" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG vers JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}

## **FAQ** 

**Existe-t-il des limites au nombre de diapositives lors de la fusion de présentations ?**

No strict limitations. Aspose.Slides can handle large files, but performance depends on the size and system resources. For very large presentations, it's recommended to use a 64-bit JVM and allocate sufficient heap memory.

**Puis-je fusionner des présentations avec des vidéos ou des audios intégrés ?**

Yes, Aspose.Slides preserves multimedia content embedded in slides, but the final presentation might become significantly larger.

**Les polices seront‑elles conservées lors de la fusion de présentations ?**

Yes. Fonts used in source presentations are preserved in the output file, assuming they are installed on the system or [embedded](/slides/fr/androidjava/embedded-font/).