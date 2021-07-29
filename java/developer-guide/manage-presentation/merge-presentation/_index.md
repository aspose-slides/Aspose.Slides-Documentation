---
title: Merge Presentation
type: docs
weight: 40
url: /java/merge-presentation/
keywords: "Merge PPT, combine PowerPoint"
description: "Merge PPT and combine PowerPoint presentations with Aspose.Slides API."
---


## **Live Example**
Free [**Aspose.Slides Merger**](https://products.aspose.app/slides/merger) online web application allows to investigate how presentation merging functionality works. Try to merge PPT to PPT, PPT to PPTX, PPTX to ODP or others:

[](https://products.aspose.app/slides/merger)

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

 
## **About Presentation Merge**

[**Aspose.Slides**](https://products.aspose.com/slides/java) provides a simple and effective interface to merge PPT, PPTX and ODP presentations. The API allows to merge PPT to PPT, PPTX to PPTX, PPTX to ODP or combine PowerPoint presentations in other ways. Both PowerPoint and OpenOffice do not allow to merge PowerPoint and OpenOffice presentations straight away. Users are forced to do it manually, or use third-party solutions. With VBA it is possible to duplicate or copy slides into the same presentation. However, you can’t merge presentations or slides into a new presentation, or change merge process in a flexible way. Aspose.Slides merges presentations with all their shapes, styles, text formatting, comments, animations, smart arts, etc. with no quality and data loss.



With Aspose.Slides it is possible to merge whole presentations or specific slides, save the style of each presentation, or use one style for all merged presentations.

Presentation merging is implemented with **AddClone** methods of
[**ISlideCollection**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) interface, having several implementations of this method:

- [**addClone (ISlide)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) - is used to merge presentation slides with saving their own layouts and styles.
- [**addClone (ISlide, IMasterSlide, Boolean)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) - used to apply Slide Master presentation template, while merging presentation slides. This allows to change their styles while merging.
- [**addClone (ISlide, ILayoutSlide)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) - used to apply SlideLayout to presentation slides while merging.
- [**addClone (ISlide, ISection)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) - used to merge slide into a section. After merge, the resulting section will contains a copy of the source slide.

These methods can be used to merge slides of one or several presentations. Each [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object has a [**Slides**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) collection, so you need to call AddClone method from the presentation you want to merge slides to. This gives you a lot of flexibility to: merge slides into existing presentation, merge slides into a new presentation, merge slides into several presentations at once, etc. It is even possible to merge Slide Master into other presentation, as instance.

AddClone method returns [ISlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide) object with a clone of source slide, having modified (or not) styles and layouts. Each slide, returned by AddClone method is being added to the end of the merged presentation. The resulting slide is just the copy of the source slide. If you make any changes in the resulting slide - they will not affect the source slide.

The example how to merge several presentations of different types is given below. 

## **Merge Presentation**
To merge presentation slides with their own styles, just pass slide object into 
[**AddClone (ISlide)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method:

```java
mergedPresentation.getSlides().addClone(slide);
``` 


## **Merge Presentation with Slide Master**
To merge presentation slides with a slide template of their styles and layouts - pass Slide Master into [**addClone (ISlide, IMasterSlide, Boolean)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) method.

Note, that Slide Layout of the Slide Master, that should be applied to slides, is choosed automatically. If there is no appropriate layout will be found, then layout of the source slide will be used. The allowCloneMissingLayout boolean parameter of AddClone method determines if the source layout can be used instead of not found layout. If allowCloneMissingLayout is true - source layout will be used instead of missed layout, otherwise PptxEditException will be thrown.

```java
mergedPresentation.getSlides().addClone(slide, masterSlide, true);
``` 

If you want to define other Slide Layout, you should use [**addClone (ISlide, ILayoutSlide)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) method.

## **Merge Specific Slides of Presentation**
To merge a specific slide of presentation, you just need to choose it by the slide 
index from source presentation and pass into [**addClone (ISlide)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method:

```java
mergedPresentation.getSlides().addClone(presentation3.getSlides().get_Item(0));
``` 

## **Merge Presentation with Slide Layout**
To merge presentation sides, applying a new slide layout to them - you should use [**addClone (ISlide, ILayoutSlide)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) method:

```java
mergedPresentation.getSlides().addClone(presentation3.getSlides().get_Item(0), layoutSlide);
``` 

## **Merge Slide to Presentation Section**
To merge presentation slide into a presentation section, it is possible to use [**addClone (ISlide, ISection)**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-). You need to pass slide object and the section to which you want to clone this slide. The slide will be added to the end of the section:

```java
 mergedPresentation.getSlides().addClone(presentation3.getSlides().get_Item(0), section);
``` 

It is possible to ask questions, share ideas in the [**Aspose.Slides forum**](https://forum.aspose.com/c/slides).

## **See also**
- [Clone Slides](/slides/java/clone-slides/)
