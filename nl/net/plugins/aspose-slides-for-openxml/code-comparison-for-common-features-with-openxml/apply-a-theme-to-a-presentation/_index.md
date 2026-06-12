---
title: Een thema toepassen op een presentatie
type: docs
weight: 30
url: /nl/net/apply-a-theme-to-a-presentation/
---
## **OpenXML-presentatie**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Een nieuw thema toepassen op de presentatie. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Een nieuw thema toepassen op de presentatie. 

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

    // Haal het presentatiedeel van het presentatiedocument op.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Haal het bestaande slide-master-deel op.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Haal het nieuwe slide-master-deel op.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Verwijder het bestaande themadeel.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Verwijder het oude slide-master-deel.

    presentationPart.DeletePart(slideMasterPart);

    // Importeer het nieuwe slide-master-deel en hergebruik de oude relatie-ID.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Schakel over naar het nieuwe themadeel.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Voeg de code voor de lay-out voor dit voorbeeld in.

    string defaultLayoutType = "Title and Content";

    // Verwijder de slide-lay-out-relatie op alle dia's. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Bepaal het slide-lay-outtype voor elke dia.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Verwijder het oude lay-outdeel.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Pas het nieuwe lay-outdeel toe.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Pas het nieuwe standaard-lay-outdeel toe.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Haal het slide-lay-outtype op.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Opmerking: Als dit in productcode wordt gebruikt, controleer dan op een null-referentie.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Om een thema toe te passen moeten we de dia met de master dupliceren; volg de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse aan die de bronpresentatie bevat waaruit de dia wordt gekopieerd.
- Maak een instantie van de Presentation‑klasse aan die de doelpresentatie bevat waarin de dia wordt gekopieerd.
- Open de te kopiëren dia samen met de master‑dia.
- Instantieer de IMasterSlideCollection‑klasse door te verwijzen naar de Masters‑collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
- Roep de AddClone‑methode aan die door het IMasterSlideCollection‑object wordt aangeboden en geef de master uit de bron‑PPTX die gekopieerd moet worden als parameter door.
- Instantieer de ISlideCollection‑klasse door de referentie in te stellen op de Slides‑collectie die door het Presentation‑object van de doelpresentatie wordt aangeboden.
- Roep de AddClone‑methode aan die door het ISlideCollection‑object wordt aangeboden en geef de dia uit de bronpresentatie die gekopieerd moet worden en de master‑dia als parameters door.
- Schrijf het gewijzigde doelpresentatie‑bestand weg.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instantieer Presentation‑klasse om het bronpresentatie‑bestand te laden
    Presentation srcPres = new Presentation(presentationFile);

    //Instantieer Presentation‑klasse voor de doelpresentatie (waar de dia gekloond moet worden)
    Presentation destPres = new Presentation(outputFile);

    //Instantieer ISlide uit de verzameling dia's in de bronpresentatie samen met
    //master‑dia
    ISlide SourceSlide = srcPres.Slides[0];

    //Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de
    //doelpresentatie
    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de
    //doelpresentatie
    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
    //collectie dia's in de doelpresentatie
    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de//bestemmingspresentatie
    //Sla de doelpresentatie op naar schijf
    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **Download werkend code‑voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)