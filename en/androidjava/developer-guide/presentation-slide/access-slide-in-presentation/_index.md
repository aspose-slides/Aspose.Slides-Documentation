---
title: Access Presentation Slides on Android
linktitle: Access Slide
type: docs
weight: 20
url: /androidjava/access-slide-in-presentation/
keywords:
- access slide
- slide index
- slide id
- slide position
- change position
- slide properties
- slide number
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to access and manage slides in PowerPoint and OpenDocument presentations with Aspose.Slides for Android. Boost productivity with Java code examples."
---

Aspose.Slides allows you to access slides in two ways: by index and by ID.

## **Access a Slide by Index**

All slides in a presentation are arranged numerically based on the slide position starting from 0. The first slide is accessible through index 0; the second slide is accessed through index 1; etc.

The Presentation class, representing a presentation file, exposes all slides as an [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) collection (collection of [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) objects). This Java code shows you how to access a slide through its index:

```java
// Instantiates a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Accesses a slide using its slide index
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Access a Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) method (exposed by the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class) to target that ID. This Java code shows you how to provide a valid slide ID and access that slide through the [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) method:

```java
// Instantiates a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Gets a slide ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Accesses the slide through its ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Change the Slide Position**

Aspose.Slides allow you to change a slide position. For example, you can specify that the first slide should become the second slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Get the slide's reference (whose position you want to change) through its index
1. Set a new position for the slide through the [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) property.
1. Save the modified presentation.

This Java code demonstrates an operation in which the slide in position 1 is moved to position 2: 

```java
// Instantiates a Presentation object that represents a presentation file
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Gets the slide whose position will be changed
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Sets the new position for the slide
    sld.setSlideNumber(2);
    
    // Saves the modified presentation
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

The first slide became the second; the second slide became the first. When you change a slide's position, other slides are automatically adjusted.


## **Set the Slide Number**

Using the [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) property (exposed by the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Get the slide number.
1. Set the slide number.
1. Save the modified presentation.

This Java code demonstrates an operation where the first slide number is set to 10: 

```java
// Instantiates a Presentation object that represents a presentation file
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Gets the slide number
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Sets the slide number
    pres.setFirstSlideNumber(10);
	
    // Saves the modified presentation
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

If you prefer to skip the first slide, you can start the numbering from the second slide (and hide the numbering for the first slide) this way:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Sets the number for the first presentation slide
    presentation.setFirstSlideNumber(0);

    // Shows slide numbers for all slides
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Hides the slide number for the first slide
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Saves the modified presentation
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

The number shown on a slide can start from an arbitrary value (e.g., 10) and does not have to match the index; the relationship is controlled by the presentation’s [first slide number](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) setting.

**Do hidden slides affect indexing?**

Yes. A hidden slide remains in the collection and is counted in indexing; "hidden" refers to display, not its position in the collection.

**Does a slide’s index change when other slides are added or removed?**

Yes. Indexes always reflect the current order in slides and are recalculated upon insert, delete, and move operations.
