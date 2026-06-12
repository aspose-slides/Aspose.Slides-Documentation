---
title: Přidání snímku do prezentace
type: docs
weight: 20
url: /cs/net/adding-slide-to-presentation/
---
## **OpenXML Prezentace**
V níže uvedené funkčnosti je ve výchozím nastavení přidán snímek do prezentace. Zde přidáváme nový snímek na index 2 s nějakým textem.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Vložte snímek do určené prezentace.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Otevřete zdrojový dokument pro čtení a zápis. 
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Předejte zdrojový dokument, pozici a název snímku, který má být vložen, další metodě.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Vložte určený snímek do prezentace na určenou pozici.

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

    // Ověřte, že prezentace není prázdná.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Deklarujte a vytvořte nový snímek.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Sestavte obsah snímku.            

    // Zadejte neviditelné vlastnosti nového snímku.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Zadejte vlastnosti skupinového tvaru nového snímku.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Deklarujte a vytvořte tvar titulku nového snímku.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Zadejte požadované vlastnosti tvaru titulku. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Zadejte text titulkového tvaru.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Deklarujte a vytvořte tvar těla nového snímku.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Zadejte požadované vlastnosti tvaru těla.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Zadejte text tvaru těla.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Vytvořte část snímku pro nový snímek.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Uložte novou část snímku.

    slide.Save(slidePart);

    // Upravte seznam ID snímků v části prezentace.

    // Seznam ID snímků by neměl být null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Najděte nejvyšší ID snímku v aktuálním seznamu.

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

    // Získejte ID předchozího snímku.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Použijte stejný rozvržení snímku jako u předchozího snímku.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Vložte nový snímek do seznamu snímků za předchozí snímek.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Uložte upravenou prezentaci.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Každý soubor prezentace PowerPoint obsahuje jeden **Main Master slide** a další **Normal slides**. To znamená, že soubor prezentace obsahuje alespoň jeden či více snímků. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány Aspose.Slides pro .NET. Každý snímek má konkrétní pozici a **jedinečný Id**. **slide Id** může mít hodnotu od 0 do 255 pro hlavní snímky a od 256 do 65535 pro běžné snímky.

Aspose.Slides pro .NET umožňuje vývojářům přidávat prázdné snímky do prezentací pomocí metody **AddEmptySlide**, která je součástí objektu **Presentation**. Chcete-li přidat prázdný snímek do prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Zavolejte metodu AddEmptySlide, kterou poskytuje objekt Presentation
- Proveďte potřebné operace s nově přidaným prázdným snímkem
- Přidejte další snímek a vložte do něj text.
- Nakonec zapište soubor PPT pomocí metody Write, kterou poskytuje objekt Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Vytvořte instanci třídy PresentationEx, která představuje soubor PPT

Presentation pres = new Presentation();

//Prázdný snímek je přidán ve výchozím nastavení, když vytvoříte

//prezentaci z výchozího konstruktoru

//Přidání prázdného snímku do prezentace a získání reference na

//ten prázdný snímek

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Zapište výstup na disk

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)