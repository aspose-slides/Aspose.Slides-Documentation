---
title: Lägg till bild i presentation
type: docs
weight: 20
url: /sv/net/adding-slide-to-presentation/
---
## **OpenXML-presentation**
I funktionen nedan läggs som standard en bild till presentationen. Här lägger vi till en ny bild på index 2 med lite text i den.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Infoga en bild i den specificerade presentationen.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Öppna källdokumentet som läs/skriv. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Skicka källdokumentet samt position och titel för den bild som ska infogas till nästa metod.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Infoga den specificerade bilden i presentationen på den angivna positionen.

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

    // Verifiera att presentationen inte är tom.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Deklarera och instansiera en ny bild.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Konstruera bildens innehåll.            

    // Ange de icke‑visuella egenskaperna för den nya bilden.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Ange gruppformsegenskaperna för den nya bilden.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Deklarera och instansiera titelformen för den nya bilden.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Ange de erforderliga formsegenskaperna för titelformen. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Ange texten för titelformen.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Deklarera och instansiera kroppformen för den nya bilden.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Ange de erforderliga formsegenskaperna för kroppformen.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Ange texten för kroppformen.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Skapa bilddelen för den nya bilden.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Spara den nya bilddelen.

    slide.Save(slidePart);

    // Modifiera bild‑ID‑listan i presentationsdelen.

    // Bild‑ID‑listan får inte vara null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Hitta det högsta bild‑ID‑et i den aktuella listan.

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

    // Hämta ID för föregående bild.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Använd samma bildlayout som den föregående bilden.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Infoga den nya bilden i bildlistan efter den föregående bilden.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Spara den modifierade presentationen.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Varje PowerPoint-presentationfil innehåller en **Main Master slide** och övriga **Normal slides**. Det betyder att en presentationsfil innehåller minst en eller flera bilder. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides för .NET. Varje bild har en specifik position och ett **unique Id**. **slide Id** kan variera från 0 till 255 för master slides och från 256 till 65535 för normala bilder.

Aspose.Slides för .NET låter utvecklare lägga till tomma bilder i presentationerna med hjälp av **AddEmptySlide**‑metoden som exponeras av **Presentation**‑objektet. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Anropa AddEmptySlide‑metoden som exponeras av Presentation‑objektet
- Utför några uppgifter med den nyligen tillagda tomma bilden
- Lägg till en annan bild och infoga text på den.
- Slutligen, skriv PPT‑filen med Write‑metoden som exponeras av Presentation‑objektet

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Instansiera PresentationEx-klassen som representerar PPT-filen
Presentation pres = new Presentation();

//Tom bild läggs till som standard, när du skapar
//presentation från standardkonstruktorn
//Lägga till en tom bild i presentationen och hämta referensen till
//den tomma bilden
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Skriv utdata till disk
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)