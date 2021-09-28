---
title: Create Layout Slides using Aspose.Slides and pptx4j
type: docs
weight: 40
url: /java/create-layout-slides-using-aspose-slides-and-pptx4j/
---

## **Aspose.Slides - Create Layout Slides**
**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents the presentation file

Presentation pres = new Presentation();

// Try to search by layout slide type

IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();

ILayoutSlide layoutSlide = null;

if(layoutSlides.getByType(SlideLayoutType.TitleAndObject)!=null)

 layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject) ;

else

    layoutSlide=layoutSlides.getByType(SlideLayoutType.Title);

if (layoutSlide == null)

{

    // The situation when a presentation doesn't contain some type of layouts.

    // Technographics.pptx presentation only contains Blank and Custom layout types.

    // But layout slides with Custom types has different slide names,

    // like "Title", "Title and Content", etc. And it is possible to use these

    // names for layout slide selection.

    // Also it is possible to use the set of placeholder shape types. For example,

    // Title slide should have only Title placeholder type, etc.

    for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides)

    {

        if (titleAndObjectLayoutSlide.getName() == "Title and Object")

        {

            layoutSlide = titleAndObjectLayoutSlide;

            break;

        }

    }

    if (layoutSlide == null)

    {

        for (ILayoutSlide titleLayoutSlide : layoutSlides)

        {

            if (titleLayoutSlide.getName() == "Title")

            {

                layoutSlide = titleLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);

            if (layoutSlide == null)

            {

                layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");

            }

        }

    }

}

//Adding empty slide with added layout slide

pres.getSlides().insertEmptySlide(0, layoutSlide);

//Save presentation

pres.save(dataPath + "Aspose-output.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **pptx4j - Create Layout Slides**
**Java**

{{< highlight java >}}

 // Create skeletal package, including a MainPresentationPart and a SlideLayoutPart

PresentationMLPackage presentationMLPackage = PresentationMLPackage.createPackage();

// Need references to these parts to create a slide

// Please note that these parts *already exist* - they are

// created by createPackage() above.  See that method

// for instruction on how to create and add a part.

MainPresentationPart pp = (MainPresentationPart)presentationMLPackage.getParts().getParts().get(

		new PartName("/ppt/presentation.xml"));

SlideLayoutPart layoutPart1 = (SlideLayoutPart)presentationMLPackage.getParts().getParts().get(

		new PartName("/ppt/slideLayouts/slideLayout1.xml"));

// OK, now we can create a slide

SlidePart slidePart1 = presentationMLPackage.createSlidePart(pp, layoutPart1, new PartName("/ppt/slides/slide1.xml"));

presentationMLPackage.save(new java.io.File(dataPath + "Pptx4j-New Presentation.pptx"));

{{< /highlight >}}
## **Download Running Code**
Download running examples for **Create Layout Slides** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)
## **Download Source Code**
Download source code for **Create Layout Slides** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)

{{% alert color="primary" %}} 

For more details, visit [Adding Layout Slides to Presentation](/slides/java/slide-layout/#adding-a-layout-slide-to-the-presentation).

{{% /alert %}}
