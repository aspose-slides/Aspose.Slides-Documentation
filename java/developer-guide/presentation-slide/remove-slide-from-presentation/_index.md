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

We know that [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class in Aspose.Slides for Java represents a presentation file. [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class encapsulates a [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this [**Slides**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) collection in two ways:

1. Using Slide Reference
1. Using Slide Index

## **Remove Slide by Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
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

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
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
