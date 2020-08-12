---
title: Assemble Slides
type: docs
weight: 10
url: /net/assemble-slides/
---

It covers following below features:
## **Adding Slide to Presentation**
Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains Master / Layout slide and other Normal slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for .NET. Each slide has unique Id and all the Normal Slides are arranged in an order specified by the zero based index.

Aspose.Slides for .NET allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of **Presentation** class
- Instantiate **SlideCollection** class by setting a reference to the Slides (collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the **AddEmptySlide** methods exposed by **SlideCollection** object
- Do some work with the newly added empty slide
- Finally, write the presentation file using the **Presentation** object

```

 PresentationEx pres = new PresentationEx();

//Instantiate SlideCollection class

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Add an empty slide to the Slides collection

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Write("EmptySlide.pptx");

```
## **Accessing Slides of Presentation**
Aspose.Slides for .NET provides Presentation class that can be used to find and access any desired slide present in the presentation.

**Using Slides Collection**

**Presentation** class represents a presentation file and exposes all slides in it as a **SlideCollection** collection (that is a collection of **Slide** objects). All of these slides can be accessed from this **Slides** collection using a slide index.

```

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

```
## **Removing Slides**
We know that Presentation class in **Aspose.Slides for .NET** represents a presentation file. Presentation class encapsulates a **SlideCollection** that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

- Using Slide Reference
- Using Slide Index

**Using Slide Reference**

To remove a slide using its reference, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Id or Index
- Remove the referenced slide from the presentation
- Write the modified presentation file

```

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its index in the slides collection

SlideEx slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Write("modified.pptx");

```
## **Changing Position of Slide:**
It's very simple to change the position of a slide in the presentation. Just follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Change the SlideNumber of the referenced slide
- Write the modified presentation file

In the example given below, we have changed the position of a slide (lying at the zero index position 1) of the presentation) to index 1 (Position 2).

```

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instantiate SlideCollection class

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Add an empty slide to the Slides collection

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its slide index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantiate Presentation class to load the source presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Get the slide whose position is to be changed

    ISlide sld = pres.Slides[0];

    //Set the new position for the slide

    sld.SlideNumber = 2;

    //Write the presentation to disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

```
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)
