---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /java/remove-slide-from-presentation/
---


## **Overview**
{{% alert color="primary" %}} 

Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for Java offers few methods to do so. In this topic, we will explore these methods to accomplish this task.

{{% /alert %}} 

We know that [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class in Aspose.Slides for Java represents a presentation file. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class encapsulates a [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) collection in two ways:

1. Using Slide Reference
1. Using Slide Index

## **Remove Slide by Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Id or Index
1. Remove the referenced slide from the presentation
1. Write the modified presentation file

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Accessing a slide using its index in the slides collection
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Removing a slide using its reference
    pres.getSlides().remove(slide);
    
    // Writing the presentation file
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove Slide by Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Remove the slide from the presentation by using its index position
1. Write the modified presentation file

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Removing a slide using its slide index
    pres.getSlides().removeAt(0);
    
    // Writing the presentation file
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) method from the [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) class to allow you to delete unwanted and unused layout slides. This Java code shows you how to remove a layout slide from a PowerPoint presentation:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Unused Master Slide**

Aspose.Slides provides the [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) method (from the [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) class) to allow you to delete unwanted and unused master slides. This Java code shows you how to remove a master slide from a PowerPoint presentation:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

