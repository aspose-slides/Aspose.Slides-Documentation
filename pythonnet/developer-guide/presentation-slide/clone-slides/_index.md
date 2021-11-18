---
title: Clone Slides
type: docs
weight: 40
url: /pythonnet/clone-slides/
keywords: "Clone slide, Copy slide, Save slide copy, PowerPoint, Presentation, Python, Aspose.Slides"
description: "Clone PowerPoint slide in Python"
---

## **Clone Slides in Presentation**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for Python via .NET also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

In Aspose.Slides for Python via .NET, (a collection of [ISlide](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islide) objects) exposed by the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) object provides the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) and [InsertClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides.ishapecollection/insertclone/methods/1) methods to perform the above types of slide cloning
## **Clone at End Within a Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method according to the steps listed below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) object.
1. Call the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) object and pass the slide to be cloned as a parameter to the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

```py
// Instantiate Presentation class that represents a presentation file
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clone the desired slide to the end of the collection of slides in the same presentation
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Write the modified presentation to disk
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Clone at Another Position Within Presentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [InsertClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides.ishapecollection/insertclone/methods/1) method:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Instantiate the class by referencing the **Slides** collection exposed by the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) object.
1. Call the [InsertClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides.ishapecollection/insertclone/methods/1) method exposed by the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the [InsertClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides.ishapecollection/insertclone/methods/1) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

```py
// Instantiate Presentation class that represents a presentation file
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clone the desired slide to the end of the collection of slides in the same presentation
    ISlideCollection slds = pres.Slides;

    // Clone the desired slide to the specified index in the same presentation
    slds.InsertClone(2, pres.Slides[1]);

    // Write the modified presentation to disk
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Clone at End in Another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) class by referencing the **Slides** collection exposed by the Presentation object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) object and pass the slide from the source presentation as a parameter to the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

```py
// Instantiate Presentation class to load the source presentation file
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    using (Presentation destPres = new Presentation())
    {
        // Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Write the destination presentation to disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clone at Another Position in Another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [InsertClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides.ishapecollection/insertclone/methods/1) method exposed by the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) object and pass the slide from the source presentation along with the desired position as a parameter to the [InsertClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides.ishapecollection/insertclone/methods/1) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

```py
// Instantiate Presentation class to load the source presentation file
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Write the destination presentation to disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clone at Specific Position in Another Presentation**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **AddClone(ISlide, IMasterSlide)** expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [IMasterSlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/imasterslidecollection) class by referencing the Masters collection exposed by the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [IMasterSlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/imasterslidecollection) object and pass the master from the source PPTX to be cloned as a parameter to the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) class by setting the reference to the Slides collection exposed by the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using a master from source slide.

```py
// Instantiate Presentation class to load the source presentation file

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instantiate Presentation class for destination presentation (where slide is to be cloned)
    using (Presentation destPres = new Presentation())
    {

        // Instantiate ISlide from the collection of slides in source presentation along with
        // Master slide
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clone the desired slide from the source presentation with the desired master to the end of the
        // Collection of slides in the destination presentation
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clone the desired master slide from the source presentation to the collection of masters in the // Destination presentation
        // Save the destination presentation to disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```



## Clone at End in Specified Section

With Aspose.Slides for Python via .NET, you can clone a slide from one section of a presentation and insert that slide into another section in the same presentation. In this case, you have to use the [AddClone](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection/methods/addclone/index) method from the [ISlideCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/islidecollection) Interface. 

This Python code shows you how to clone a slide and insert the cloned slide into a specified section:

```py
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // to clone
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```



