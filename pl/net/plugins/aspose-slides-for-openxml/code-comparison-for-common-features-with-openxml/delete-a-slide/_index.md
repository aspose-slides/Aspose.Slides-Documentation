---
title: Usunięcie slajdu
type: docs
weight: 80
url: /pl/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Pobierz obiekt prezentacji i przekaż go do kolejnej metody DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Otwórz dokument źródłowy w trybie odczytu/zapisu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Przekaż dokument źródłowy i indeks slajdu do usunięcia do kolejnej metody DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Usuń określony slajd z prezentacji.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Skorzystaj z przykładu CountSlides, aby uzyskać liczbę slajdów w prezentacji.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Pobierz część prezentacji z dokumentu prezentacji. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz prezentację z części prezentacji.

    Presentation presentation = presentationPart.Presentation;

    // Pobierz listę identyfikatorów slajdów w prezentacji.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Pobierz identyfikator określonego slajdu

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Pobierz identyfikator relacji slajdu.

    string slideRelId = slideId.RelationshipId;

    // Usuń slajd z listy slajdów.

    slideIdList.RemoveChild(slideId);

    //

    // Usuń odwołania do slajdu ze wszystkich niestandardowych pokazów.

    if (presentation.CustomShowList != null)

    {

        // Przejdź przez listę niestandardowych pokazów.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Zadeklaruj listę powiązań wpisów listy slajdów.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Znajdź odwołanie do slajdu, które ma zostać usunięte z niestandardowego pokazu.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Usuń wszystkie odwołania do slajdu z niestandardowego pokazu.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Zapisz zmodyfikowaną prezentację.

    presentation.Save();

    // Pobierz część slajdu dla określonego slajdu.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Usuń część slajdu.

    presentationPart.DeletePart(slidePart);

}

// Pobierz obiekt prezentacji i przekaż go do kolejnej metody CountSlides.

public static int CountSlides(string presentationFile)

{

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Przekaż prezentację do kolejnej metody CountSlide

        // i zwróć liczbę slajdów.

        return CountSlides(presentationDocument);

    }

}

// Policz slajdy w prezentacji.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Sprawdź, czy obiekt dokumentu jest null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Pobierz część prezentacji z dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz liczbę slajdów z SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Zwróć liczbę slajdów do poprzedniej metody.

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

    //Zainicjalizuj obiekt PresentationEx reprezentujący plik PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Uzyskaj dostęp do slajdu za pomocą jego indeksu w kolekcji slajdów

        ISlide slide = pres.Slides[slideIndex];


        //Usuwanie slajdu przy użyciu jego referencji

        pres.Slides.Remove(slide);


        //Zapis prezentacji jako plik PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

```
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)