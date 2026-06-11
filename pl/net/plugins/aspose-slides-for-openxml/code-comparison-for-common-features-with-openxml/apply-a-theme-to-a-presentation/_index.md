---
title: Zastosuj motyw do prezentacji
type: docs
weight: 30
url: /pl/net/apply-a-theme-to-a-presentation/
---
## **Prezentacja OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Zastosuj nowy motyw do prezentacji. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Zastosuj nowy motyw do prezentacji. 

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

    // Pobierz część prezentacji dokumentu prezentacji.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz istniejącą część master slajdu.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Pobierz nową część master slajdu.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Usuń istniejącą część motywu.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Usuń starą część master slajdu.

    presentationPart.DeletePart(slideMasterPart);

    // Zaimportuj nową część master slajdu i ponownie użyj starego identyfikatora relacji.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Zmień na nową część motywu.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Wstaw kod układu dla tego przykładu.

    string defaultLayoutType = "Title and Content";

    // Usuń relację układu slajdu we wszystkich slajdach. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Określ typ układu slajdu dla każdego slajdu.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Usuń starą część układu.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Zastosuj nową część układu.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Zastosuj nową domyślną część układu.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Pobierz typ układu slajdu.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Uwaga: Jeśli jest używane w kodzie produkcyjnym, sprawdź, czy nie ma odwołania do null.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Aby zastosować motyw, musimy sklonować slajd wraz z masterem, prosimy postępować zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation zawierającą prezentację źródłową, z której slajd zostanie sklonowany.
- Utwórz instancję klasy Presentation zawierającą prezentację docelową, do której slajd zostanie sklonowany.
- Uzyskaj dostęp do slajdu, który ma zostać sklonowany, wraz z masterem slajdu.
- Zainicjuj klasę IMasterSlideCollection, odwołując się do kolekcji Masters udostępnionej przez obiekt Presentation prezentacji docelowej.
- Wywołaj metodę AddClone udostępnioną przez obiekt IMasterSlideCollection i przekaż jako parametr master z pliku PPTX źródłowego, który ma zostać sklonowany.
- Zainicjuj klasę ISlideCollection, ustawiając odwołanie do kolekcji Slides udostępnionej przez obiekt Presentation prezentacji docelowej.
- Wywołaj metodę AddClone udostępnioną przez obiekt ISlideCollection i przekaż jako parametry slajd z prezentacji źródłowej, który ma zostać sklonowany, oraz master slajd.
- Zapisz zmodyfikowany plik prezentacji docelowej.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Utwórz instancję klasy Presentation, aby załadować plik prezentacji źródłowej
    Presentation srcPres = new Presentation(presentationFile);
    //Utwórz instancję klasy Presentation dla prezentacji docelowej (gdzie slajd ma zostać sklonowany)
    Presentation destPres = new Presentation(outputFile);
    //Utwórz instancję ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
    //master slajdem
    ISlide SourceSlide = srcPres.Slides[0];
    //Sklonuj żądany master slajd z prezentacji źródłowej do kolekcji masterów w
    //prezentacji docelowej
    IMasterSlideCollection masters = destPres.Masters;
    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;
    //Sklonuj żądany master slajd z prezentacji źródłowej do kolekcji masterów w
    //prezentacji docelowej
    IMasterSlide iSlide = masters.AddClone(SourceMaster);
    //Sklonuj żądany slajd z prezentacji źródłowej z żądanym masterem na koniec
    //kolekcji slajdów w prezentacji docelowej
    ISlideCollection slds = destPres.Slides;
    slds.AddClone(SourceSlide, iSlide, true);
    //Sklonuj żądany master slajd z prezentacji źródłowej do kolekcji masterów w //prezentacji docelowej
    //Zapisz prezentację docelową na dysku
    destPres.Save(outputFile, SaveFormat.Pptx);
}
``` 
## **Pobierz działający przykład kodu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)