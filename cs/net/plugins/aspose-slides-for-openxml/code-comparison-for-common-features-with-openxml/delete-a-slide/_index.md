---
title: Smazat snímek
type: docs
weight: 80
url: /cs/net/delete-a-slide/
---
## **OpenXML SDK**
```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Získat objekt prezentace a předat jej další metodě DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Otevřít zdrojový dokument pro čtení i zápis.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Předat zdrojový dokument a index slajdu, který má být smazán, další metodě DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Smazat určený slajd z prezentace.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Použít ukázku CountSlides pro získání počtu slajdů v prezentaci.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Získat část prezentace z dokumentu prezentace.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Získat prezentaci z části prezentace.

    Presentation presentation = presentationPart.Presentation;

    // Získat seznam ID slajdů v prezentaci.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Získat ID určeného slajdu

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Získat ID vztahu slajdu.

    string slideRelId = slideId.RelationshipId;

    // Odstranit slajd ze seznamu slajdů.

    slideIdList.RemoveChild(slideId);

    //

    // Odstranit odkazy na slajd ze všech vlastních ukázek.

    if (presentation.CustomShowList != null)

    {

        // Procházet seznam vlastních ukázek.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Deklarovat propojený seznam položek seznamu slajdů.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Najít odkaz na slajd, který má být odstraněn z vlastní ukázky.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Odstranit všechny odkazy na slajd z vlastní ukázky.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Uložit upravenou prezentaci.

    presentation.Save();

    // Získat část slajdu pro určený slajd.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Odstranit část slajdu.

    presentationPart.DeletePart(slidePart);

}

// Získat objekt prezentace a předat jej další metodě CountSlides.

public static int CountSlides(string presentationFile)

{

    // Otevřít prezentaci jen pro čtení.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Předat prezentaci další metodě CountSlide

        // a vrátit počet slajdů.

        return CountSlides(presentationDocument);

    }

}

// Spočítat slajdy v prezentaci.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ověřit, zda není dokument objekt null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Získat část prezentace z dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Získat počet slajdů ze SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Vrátit počet slajdů předchozí metodě.

    return slidesCount;

}   
``` 
## **Aspose.Slides**
```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Vytvořit objekt PresentationEx, který představuje soubor PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Přístup k slajdu pomocí jeho indexu v kolekci slajdů

        ISlide slide = pres.Slides[slideIndex];


        //Odstranění slajdu pomocí jeho reference

        pres.Slides.Remove(slide);


        //Uložení prezentace jako soubor PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)