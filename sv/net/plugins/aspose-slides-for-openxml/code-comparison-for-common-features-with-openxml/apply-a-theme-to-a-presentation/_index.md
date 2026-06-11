---
title: Tillämpa ett tema på en presentation
type: docs
weight: 30
url: /sv/net/apply-a-theme-to-a-presentation/
---
## **OpenXML-presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Tillämpa ett nytt tema på presentationen. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Tillämpa ett nytt tema på presentationen. 

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

    // Hämta presentationsdelen av presentationsdokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hämta den befintliga bildmasterdelen.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Hämta den nya bildmasterdelen.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Ta bort den befintliga temadelen.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Ta bort den gamla bildmasterdelen.

    presentationPart.DeletePart(slideMasterPart);

    // Importera den nya bildmasterdelen och återanvänd det gamla relations-ID:t.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Byt till den nya temadelen.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Infoga koden för layouten för detta exempel.

    string defaultLayoutType = "Title and Content";

    // Ta bort bildlayoutrelationen på alla bilder. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Bestäm bildlayouttypen för varje bild.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Ta bort den gamla layoutdelen.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Tillämpa den nya layoutdelen.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Tillämpa den nya standardlayoutdelen.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Hämta bildlayouttypen.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Anmärkning: Om detta används i produktionskod, kontrollera en null-referens.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
För att tillämpa tema måste vi klona bilden med master, följ stegen nedan:

- Skapa en instans av Presentation-klassen som innehåller källpresentationen som bilden ska klonas från.
- Skapa en instans av Presentation-klassen som innehåller målpresentationen som bilden ska klonas till.
- Åtkomst till bilden som ska klonas tillsammans med master-bilden.
- Instansiera klassen IMasterSlideCollection genom att referera till Masters-samlingen som exponeras av Presentation-objektet i målpresentationen.
- Anropa AddClone‑metoden som exponeras av IMasterSlideCollection‑objektet och skicka med master från käll‑PPTX som ska klonas som parameter till AddClone‑metoden.
- Instansiera klassen ISlideCollection genom att sätta referensen till Slides‑samlingen som exponeras av Presentation‑objektet i målpresentationen.
- Anropa AddClone‑metoden som exponeras av ISlideCollection‑objektet och skicka med bilden från källpresentationen som ska klonas samt master‑bilden som parameter till AddClone‑metoden.
- Skriv den modifierade målpresentationsfilen.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instansiera Presentation-klassen för att läsa in källpresentationsfilen
    Presentation srcPres = new Presentation(presentationFile);

    //Instansiera Presentation-klassen för målpresentationen (där bilden ska klonas)
    Presentation destPres = new Presentation(outputFile);

    //Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
    //master-bilden
    ISlide SourceSlide = srcPres.Slides[0];

    //Klona den önskade master-bilden från källpresentationen till samlingen av masters i den
    //målpresentationen
    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Klona den önskade master-bilden från källpresentationen till samlingen av masters i den
    //målpresentationen
    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Klona den önskade bilden från källpresentationen med den önskade master-bilden till slutet av
    //samlingen av bilder i målpresentationen
    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Klona den önskade master-bilden från källpresentationen till samlingen av masters i den//destinationspresentationen
    //Spara målpresentationen till disk
    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **Ladda ner körande kodexempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)