---
title: Ta bort en bild
type: docs
weight: 80
url: /sv/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Hämta presentationsobjektet och skicka det till nästa DeleteSlide-metod.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Öppna källdokumentet som läs-/skriv.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Skicka källdokumentet och indexet för den bild som ska tas bort till nästa DeleteSlide-metod.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Ta bort den angivna bilden från presentationen.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Använd CountSlides-exemplet för att få antalet bilder i presentationen.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Hämta presentationsdelen från presentationsdokumentet. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hämta presentationen från presentationsdelen.

    Presentation presentation = presentationPart.Presentation;

    // Hämta listan med bild‑ID:n i presentationen.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Hämta bild‑ID för den angivna bilden

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Hämta relations‑ID för bilden.

    string slideRelId = slideId.RelationshipId;

    // Ta bort bilden från bildlistan.

    slideIdList.RemoveChild(slideId);

    //

    // Ta bort referenser till bilden från alla anpassade visningar.

    if (presentation.CustomShowList != null)

    {

        // Iterera genom listan med anpassade visningar.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Deklarera en länklad lista med bildlistaposter.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Hitta bildreferensen att ta bort från den anpassade visningen.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Ta bort alla referenser till bilden från den anpassade visningen.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Spara den modifierade presentationen.

    presentation.Save();

    // Hämta bilddelen för den angivna bilden.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Ta bort bilddelen.

    presentationPart.DeletePart(slidePart);

}

// Hämta presentationsobjektet och skicka det till nästa CountSlides-metod.

public static int CountSlides(string presentationFile)

{

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Skicka presentationen till nästa CountSlide-metod

        // och returnera antalet bilder.

        return CountSlides(presentationDocument);

    }

}

// Räkna bilderna i presentationen.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kontrollera om dokumentobjektet är null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hämta presentationsdelen från dokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hämta bildantalet från SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Returnera bildantalet till föregående metod.

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

    //Skapa ett PresentationEx-objekt som representerar en PPTX-fil

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Åtkomst till en bild med dess index i bildsamlingen

        ISlide slide = pres.Slides[slideIndex];


        //Ta bort en bild med dess referens

        pres.Slides.Remove(slide);


        //Spara presentationen som en PPTX-fil

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Ladda ner exempel på kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)