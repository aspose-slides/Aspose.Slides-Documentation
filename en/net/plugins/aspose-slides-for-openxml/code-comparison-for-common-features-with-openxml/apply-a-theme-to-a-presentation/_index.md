---
title: Apply a theme to a presentation
type: docs
weight: 30
url: /net/apply-a-theme-to-a-presentation/
---

## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Apply a new theme to the presentation. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Apply a new theme to the presentation. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Get the presentation part of the presentation document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Get the existing slide master part.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Get the new slide master part.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Remove the existing theme part.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Remove the old slide master part.

    presentationPart.DeletePart(slideMasterPart);

    // Import the new slide master part, and reuse the old relationship ID.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Change to the new theme part.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Insert the code for the layout for this example.

    string defaultLayoutType = "Title and Content";

    // Remove the slide layout relationship on all slides. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Determine the slide layout type for each slide.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Delete the old layout part.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Apply the new layout part.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Apply the new default layout part.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Get the slide layout type.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Remarks: If this is used in production code, check for a null reference.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
In order to apply theme we need to clone the slide with master, please follow the steps below:

- Create an instance of the Presentation class containing the source presentation the slide will be cloned from.
- Create an instance of the Presentation class containing the destination presentation the slide will be cloned to.
- Access the slide to be cloned along with the master slide.
- Instantiate the IMasterSlideCollection class by referencing the Masters collection exposed by the Presentation object of the destination presentation.
- Call the AddClone method exposed by the IMasterSlideCollection object and pass the master from the source PPTX to be cloned as parameter to the AddClone method.
- Instantiate the ISlideCollection class by setting the reference to the Slides collection exposed by the Presentation object of the destination presentation.
- Call the AddClone method exposed by the ISlideCollection object and pass the slide from the source presentation to be cloned and master slide as parameter to the AddClone method.
- Write the modified destination presentation file.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instantiate Presentation class to load the source presentation file

    Presentation srcPres = new Presentation(presentationFile);

    //Instantiate Presentation class for destination presentation (where slide is to be cloned)

    Presentation destPres = new Presentation(outputFile);

    //Instantiate ISlide from the collection of slides in source presentation along with

    //master slide

    ISlide SourceSlide = srcPres.Slides[0];

    //Clone the desired master slide from the source presentation to the collection of masters in the

    //destination presentation

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Clone the desired master slide from the source presentation to the collection of masters in the

    //destination presentation

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Clone the desired slide from the source presentation with the desired master to the end of the

    //collection of slides in the destination presentation

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Clone the desired master slide from the source presentation to the collection of masters in the//destination presentation

    //Save the destination presentation to disk

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Download Running Code Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)
