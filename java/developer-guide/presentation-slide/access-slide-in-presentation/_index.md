---
title: Access Slide in Presentation
type: docs
weight: 20
url: /java/access-slide-in-presentation/
---

## **Access Slides in Presentation**
{{% alert color="primary" %}} 

In this topic, we will introduce the possible ways to access a slide from a presentation file. Each slide in a presentation has a unique Id. On the other hand, all the slides in the presentation are arranged in the order of the slide position starting from 0, that is, slide at position 1 will be accessible through 0 index of [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) associated with a [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) object.

{{% /alert %}} 

Aspose.Slides for Java provides [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class that can be used to find and access any desired slide present in the presentation. Currently, developers can access a slide in two ways:

1. Accessing Slide by Index
1. Accessing Slide by ID

### **Access Slide by Index**
[Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class represents a presentation file and exposes all slides in it as a [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) collection (that is a collection of [ISlide](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlide) objects). All of these slides can be accessed from this [**Slides**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) collection using a slide index as shown below in the example.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Accessing a slide using its slide index
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

### **Access Slide by ID**
Every slide in the presentation has a unique ID associated with it. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class exposes the [**getSlideById(id)**](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation#getSlideById-long-) method that can be used to access the slide by ID. All you need to do is to provide the valid slide ID and access that slide using [**getSlideById(id)**](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation#getSlideById-long-) method as shown below in the example.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Getting Slide ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Accessing Slide by ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Change Slide Position**
{{% alert color="primary" %}} 

If you create a presentation using **MS PowerPoint**, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using **MS PowerPoint**, you can drag a selected slide to any other position of the presentation. Aspose.Slides for Java also allows developers to change the position of a slide within the presentation. Let's see how to get it done.

{{% /alert %}} 

It's very simple to change the position of a slide in the presentation. Just follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Change the [SlideNumber](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#setSlideNumber-int-) of the referenced slide.
- Write the modified presentation file.

In the example given below, we have changed the position of a slide (lying at the zero index position 1) of the presentation) to index 1 (Position 2).

```java
// Instantiate Presentation class to load the source presentation file
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Get the slide whose position is to be changed
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Set the new position for the slide
    sld.setSlideNumber(2);
    
    // Write the presentation to disk
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

The example above moves the slide (that was at position 1 to the second position and the slide that was at a second position, is moved to the first position and so on. In this way, all slides are adjusted automatically by Aspose.Slides for Java.

## **Set Slide Number**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports, setting the Slide Number. In this topic, we will see with example how to get and set the slide number property in Aspose.Slides.

{{% /alert %}} 

The new methods added to [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class allow to get or to set the number of the first slide in a presentation. When a new [FirstSlideNumber](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#setFirstSlideNumber-int-) value is specified all slide numbers are recalculated. In order to get or set the Slide Number, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class
1. Get the slide number
1. Set the slide number
1. Write the presentation as a PPTX file
   In the example given below, we have get and set the slide number.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Get the slide number
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Set the slide number
    pres.setFirstSlideNumber(10);

    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


