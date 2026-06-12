---
title: Použít motiv na prezentaci
type: docs
weight: 30
url: /cs/net/apply-a-theme-to-a-presentation/
---
## **OpenXML prezentace**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Použít nový motiv na prezentaci. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Použít nový motiv na prezentaci. 

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

    // Získat část prezentace z dokumentu prezentace.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Získat existující část hlavního snímku.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Získat novou část hlavního snímku.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Odstranit existující část motivu.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Odstranit starou část hlavního snímku.

    presentationPart.DeletePart(slideMasterPart);

    // Naimportovat novou část hlavního snímku a znovu použít staré ID vztahu.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Přepnout na novou část motivu.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Vložit kód rozložení pro tento příklad.

    string defaultLayoutType = "Title and Content";

    // Odstranit vztah rozložení snímku u všech snímků. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Určit typ rozložení snímku pro každý snímek.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Smazat starou část rozložení.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Použít novou část rozložení.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Použít novou výchozí část rozložení.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Získat typ rozložení snímku.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Poznámka: Pokud je tento kód používán v produkci, zkontrolujte null referenci.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Abychom použili motiv, musíme klonovat snímek s hlavním snímkem, postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation, která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
- Vytvořte instanci třídy Presentation, která obsahuje cílovou prezentaci, do které bude snímek klonován.
- Získejte přístup k snímku, který má být klonován, spolu s hlavním snímkem.
- Instancujte třídu IMasterSlideCollection odkazem na kolekci Masters, kterou poskytuje objekt Presentation cílové prezentace.
- Zavolejte metodu AddClone poskytovanou objektem IMasterSlideCollection a předáte jako parametr hlavní snímek ze zdrojového PPTX, který má být klonován.
- Instancujte třídu ISlideCollection nastavením reference na kolekci Slides, kterou poskytuje objekt Presentation cílové prezentace.
- Zavolejte metodu AddClone poskytovanou objektem ISlideCollection a jako parametry předáte snímek ze zdrojové prezentace, který má být klonován, a hlavní snímek.
- Zapište upravený soubor cílové prezentace.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Vytvořit instanci třídy Presentation pro načtení zdrojového souboru prezentace
    Presentation srcPres = new Presentation(presentationFile);
    //Vytvořit instanci třídy Presentation pro cílovou prezentaci (kam bude snímek zkopírován)
    Presentation destPres = new Presentation(outputFile);
    //Vytvořit instanci ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
    //hlavním snímkem
    ISlide SourceSlide = srcPres.Slides[0];
    //Zkopírovat požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
    //cílové prezentaci
    IMasterSlideCollection masters = destPres.Masters;
    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;
    //Zkopírovat požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
    //cílové prezentaci
    IMasterSlide iSlide = masters.AddClone(SourceMaster);
    //Zkopírovat požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
    //kolekce snímků v cílové prezentaci
    ISlideCollection slds = destPres.Slides;
    slds.AddClone(SourceSlide, iSlide, true);
    //Zkopírovat požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v //cílové prezentaci
    //Uložit cílovou prezentaci na disk
    destPres.Save(outputFile, SaveFormat.Pptx);
}
``` 
## **Stáhnout spustitelný ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)