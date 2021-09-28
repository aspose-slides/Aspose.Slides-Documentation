---
title: Add Layout Slides to Presentation
type: docs
weight: 20
url: /net/add-layout-slides-to-presentation/
---

Aspose.Slides for .NET allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

- Create an instance of Presentation class
- Access the Master Slide collection
- Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not
- Add a new Layout slide if the desired layout is unavailable
- Add an empty slide with newly added Layout slide
- Finally, write the presentation file using the Presentation object
## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

{

    // Try to search by layout slide type

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // The situation when a presentation doesn't contain some type of layouts.

        // Technographics.pptx presentation only contains Blank and Custom layout types.

        // But layout slides with Custom types has different slide names,

        // like "Title", "Title and Content", etc. And it is possible to use these

        // names for layout slide selection.

        // Also it is possible to use the set of placeholder shape types. For example,

        // Title slide should have only Title pleceholder type, etc.

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "Title and Object")

            {

                layoutSlide = titleAndObjectLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

            {

                if (titleLayoutSlide.Name == "Title")

                {

                    layoutSlide = titleLayoutSlide;

                    break;

                }

            }

            if (layoutSlide == null)

            {

                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

                if (layoutSlide == null)

                {

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

                }

            }

        }

    }

    //Adding empty slide with added layout slide 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Save presentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Download Sample Code**
- [Codeplex](https://archive.codeplex.com/?p=asposeslidesopenxml)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://docs.microsoft.com/en-us/samples/browse/?redirectedfrom=MSDN-samples)
## **Download Running Example**
- [Codeplex](https://archive.codeplex.com/?p=asposeslidesopenxml#Aspose.Slides Features missing in OpenXML/Adding Layout Slides/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)
- [Code.MSDN](https://docs.microsoft.com/en-us/samples/browse/?redirectedfrom=MSDN-samples)

{{% alert color="primary" %}} 

For more details, visit [Adding Layout Slides to Presentation](/slides/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}
