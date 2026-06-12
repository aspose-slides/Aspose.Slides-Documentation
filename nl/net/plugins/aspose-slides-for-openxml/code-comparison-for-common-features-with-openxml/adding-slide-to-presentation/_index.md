---
title: Dia toevoegen aan presentatie
type: docs
weight: 20
url: /nl/net/adding-slide-to-presentation/
---
## **OpenXML-presentatie**
In de onderstaande functionaliteit wordt standaard een dia aan de presentatie toegevoegd. Hier voegen we een nieuwe dia toe op index 2 met wat tekst erin.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Voeg een dia toe aan de opgegeven presentatie.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Open het brondocument als lezen/schrijven. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Geef het brondocument, de positie en de titel van de toe te voegen dia door aan de volgende methode.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Voeg de opgegeven dia toe aan de presentatie op de opgegeven positie.

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

    // Controleer of de presentatie niet leeg is.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Declareer en instantieer een nieuwe dia.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Construeer de inhoud van de dia.            

    // Specificeer de niet‑visuele eigenschappen van de nieuwe dia.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Specificeer de groepsvormeigenschappen van de nieuwe dia.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Declareer en instantieer de titelvorm van de nieuwe dia.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Specificeer de vereiste vormeigenschappen voor de titelvorm. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Specificeer de tekst van de titelvorm.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Declareer en instantieer de inhoudsvorm van de nieuwe dia.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Specificeer de vereiste vormeigenschappen voor de inhoudsvorm.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Specificeer de tekst van de inhoudsvorm.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Maak het slide‑onderdeel voor de nieuwe dia.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Sla het nieuwe slide‑onderdeel op.

    slide.Save(slidePart);

    // Pas de slide‑ID‑lijst in het presentatiedeel aan.

    // De slide‑ID‑lijst mag niet null zijn.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Zoek de hoogste slide‑ID in de huidige lijst.

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

    // Haal de ID op van de vorige dia.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Gebruik hetzelfde slide‑layout als dat van de vorige dia.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Voeg de nieuwe dia toe aan de dia‑lijst na de vorige dia.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Sla de gewijzigde presentatie op.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Elk PowerPoint‑presentatie‑bestand bevat één **Main Master‑dia** en andere **Normale dia's**. Dit betekent dat een presentatiedossier minstens één of meer dia's bevat. Het is belangrijk te weten dat presentatiedossiers zonder dia's niet worden ondersteund door Aspose.Slides voor .NET. Elke dia heeft een specifieke positie en een **unieke Id**. De **dia‑Id** kan variëren van 0 tot 255 voor master‑dia's en van 256 tot 65535 voor normale dia's.

Aspose.Slides voor .NET stelt ontwikkelaars in staat om lege dia's aan presentaties toe te voegen met behulp van de **AddEmptySlide**‑methode die wordt aangeboden door het **Presentation**‑object. Om een lege dia aan de presentatie toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse
- Roep de AddEmptySlide‑methode aan die wordt aangeboden door het Presentation‑object
- Voer wat werk uit met de nieuw toegevoegde lege dia
- Voeg een andere dia toe en plaats er tekst in.
- Schrijf tenslotte het PPT‑bestand weg met de Write‑methode die wordt aangeboden door het Presentation‑object

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Instantieer de PresentationEx-klasse die het PPT-bestand vertegenwoordigt
Presentation pres = new Presentation();

//Lege dia wordt standaard toegevoegd, wanneer je
//presentatie maakt via de standaardconstructor
//Een lege dia toevoegen aan de presentatie en de referentie verkrijgen van
//die lege dia
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Schrijf de output naar schijf
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)