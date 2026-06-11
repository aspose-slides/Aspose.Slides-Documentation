---
title: Dodawanie slajdu do prezentacji
type: docs
weight: 20
url: /pl/net/adding-slide-to-presentation/
---
## **OpenXML Presentation**
W poniższej funkcjonalności domyślnie do prezentacji dodawany jest slajd. Tutaj dodajemy nowy slajd na indeksie 2 zawierający tekst.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Wstaw slajd do określonej prezentacji.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Otwórz dokument źródłowy w trybie odczytu/zapisu. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Przekaż dokument źródłowy oraz pozycję i tytuł wstawianego slajdu do kolejnej metody.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Wstaw określony slajd do prezentacji na określonej pozycji.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Zweryfikuj, że prezentacja nie jest pusta.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Zadeklaruj i utwórz nowy slajd.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Zbuduj zawartość slajdu.            

    // Określ właściwości niewizualne nowego slajdu.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Określ właściwości grupy kształtów nowego slajdu.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Zadeklaruj i utwórz kształt tytułu nowego slajdu.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Określ wymagane właściwości kształtu dla kształtu tytułu. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Określ tekst kształtu tytułu.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Zadeklaruj i utwórz kształt treści nowego slajdu.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Określ wymagane właściwości kształtu dla kształtu treści.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Określ tekst kształtu treści.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Utwórz część slajdu dla nowego slajdu.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Zapisz nową część slajdu.

    slide.Save(slidePart);

    // Zmodyfikuj listę identyfikatorów slajdów w części prezentacji.

    // Lista identyfikatorów slajdów nie powinna być nullem.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Znajdź najwyższy identyfikator slajdu w bieżącej liście.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Pobierz identyfikator poprzedniego slajdu.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Użyj tego samego układu slajdu co poprzedni slajd.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Wstaw nowy slajd do listy slajdów po poprzednim slajdzie.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Zapisz zmodyfikowaną prezentację.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Każdy plik prezentacji PowerPoint zawiera jedną **Main Master slide** oraz inne **Normal slides**. Oznacza to, że plik prezentacji zawiera co najmniej jeden lub więcej slajdów. Należy pamiętać, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for .NET. Każdy slajd ma określoną pozycję i **unique Id**. **slide Id** może mieć wartości od 0 do 255 dla slajdów master oraz od 256 do 65535 dla zwykłych slajdów.

Aspose.Slides for .NET umożliwia programistom dodawanie pustych slajdów do prezentacji przy użyciu metody **AddEmptySlide** udostępnionej przez obiekt **Presentation**. Aby dodać pusty slajd w prezentacji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Wywołaj metodę AddEmptySlide udostępnioną przez obiekt Presentation
- Wykonaj potrzebne operacje na nowo dodanym pustym slajdzie
- Dodaj kolejny slajd i wstaw na nim tekst.
- Na koniec zapisz plik PPT przy użyciu metody Write udostępnionej przez obiekt Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Utwórz instancję klasy PresentationEx reprezentującej plik PPT

Presentation pres = new Presentation();

//Pusty slajd jest dodawany domyślnie, gdy tworzysz

//prezentację z domyślnego konstruktora

//Dodawanie pustego slajdu do prezentacji i uzyskanie odniesienia do

//tego pustego slajdu

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Zapisz wynik na dysku

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)