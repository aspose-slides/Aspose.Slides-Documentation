---
title: Verwijder een dia
type: docs
weight: 80
url: /nl/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Haal het presentatie‑object op en geef het door aan de volgende DeleteSlide‑methode.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Open het bron‑document als lezen/schrijven.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Geef het bron‑document en de index van de te verwijderen dia door aan de volgende DeleteSlide‑methode.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Verwijder de opgegeven dia uit de presentatie.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Gebruik het CountSlides‑voorbeeld om het aantal dia’s in de presentatie te krijgen.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Haal het presentatie‑deel op uit het presentatiedocument. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Haal de presentatie op uit het presentatie‑deel.

    Presentation presentation = presentationPart.Presentation;

    // Haal de lijst met dia‑ID’s op in de presentatie.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Haal de dia‑ID op van de opgegeven dia

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Haal de relatie‑ID van de dia op.

    string slideRelId = slideId.RelationshipId;

    // Verwijder de dia uit de dia‑lijst.

    slideIdList.RemoveChild(slideId);

    //

    // Verwijder verwijzingen naar de dia uit alle aangepaste shows.

    if (presentation.CustomShowList != null)

    {

        // Loop door de lijst met aangepaste shows.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Declareer een gekoppelde lijst van dia‑lijst‑items.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Zoek de diaverwijzing om te verwijderen uit de aangepaste show.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Verwijder alle verwijzingen naar de dia uit de aangepaste show.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Sla de aangepaste presentatie op.

    presentation.Save();

    // Haal het dia‑deel op voor de opgegeven dia.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Verwijder het dia‑deel.

    presentationPart.DeletePart(slidePart);

}

// Haal het presentatie‑object op en geef het door aan de volgende CountSlides‑methode.

public static int CountSlides(string presentationFile)

{

    // Open de presentatie als alleen‑lezen.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Geef de presentatie door aan de volgende CountSlide‑methode

        // en retourneer het aantal dia’s.

        return CountSlides(presentationDocument);

    }

}

// Tel de dia’s in de presentatie.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Controleer op een null‑documentobject.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Haal het presentatie‑deel van het document op.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Haal het aantal dia’s op uit de SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retourneer het aantal dia’s aan de vorige methode.

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

    //Instantieer een PresentationEx‑object dat een PPTX‑bestand vertegenwoordigt
    using (Presentation pres = new Presentation(presentationFile))

    {

        //Toegang tot een dia via de index in de dia‑collectie
        ISlide slide = pres.Slides[slideIndex];


        //Verwijderen van een dia via zijn referentie
        pres.Slides.Remove(slide);


        //Opslaan van de presentatie als een PPTX‑bestand
        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Download voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)