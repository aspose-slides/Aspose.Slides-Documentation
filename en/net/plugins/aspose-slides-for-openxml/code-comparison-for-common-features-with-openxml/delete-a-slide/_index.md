---
title: Delete a Slide
type: docs
weight: 80
url: /net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Get the presentation object and pass it to the next DeleteSlide method.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Open the source document as read/write.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Pass the source document and the index of the slide to be deleted to the next DeleteSlide method.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Delete the specified slide from the presentation.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Use the CountSlides sample to get the number of slides in the presentation.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Get the presentation part from the presentation document. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Get the presentation from the presentation part.

    Presentation presentation = presentationPart.Presentation;

    // Get the list of slide IDs in the presentation.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Get the slide ID of the specified slide

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Get the relationship ID of the slide.

    string slideRelId = slideId.RelationshipId;

    // Remove the slide from the slide list.

    slideIdList.RemoveChild(slideId);

    //

    // Remove references to the slide from all custom shows.

    if (presentation.CustomShowList != null)

    {

        // Iterate through the list of custom shows.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Declare a link list of slide list entries.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Find the slide reference to remove from the custom show.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Remove all references to the slide from the custom show.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Save the modified presentation.

    presentation.Save();

    // Get the slide part for the specified slide.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Remove the slide part.

    presentationPart.DeletePart(slidePart);

}

// Get the presentation object and pass it to the next CountSlides method.

public static int CountSlides(string presentationFile)

{

    // Open the presentation as read-only.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pass the presentation to the next CountSlide method

        // and return the slide count.

        return CountSlides(presentationDocument);

    }

}

// Count the slides in the presentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Check for a null document object.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Get the presentation part of document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Get the slide count from the SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Return the slide count to the previous method.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Instantiate a PresentationEx object that represents a PPTX file

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Accessing a slide using its index in the slides collection

        ISlide slide = pres.Slides[slideIndex];


        //Removing a slide using its reference

        pres.Slides.Remove(slide);


        //Writing the presentation as a PPTX file

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Download Sample Code**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Delete%20a%20slide%20\(Aspose.Slides\).zip)
