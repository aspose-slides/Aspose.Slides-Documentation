---
title: Dia hozzáadása a prezentációhoz
type: docs
weight: 20
url: /hu/net/adding-slide-to-presentation/
---
## **OpenXML prezentáció**
Az alábbi funkcióban alapértelmezés szerint egy dia kerül hozzáadásra a prezentációhoz. Itt egy új diát adunk hozzá a 2. indexben, amelyben némi szöveg van.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Diát szúr be a megadott prezentációba.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // A forrásdokumentumot olvasás/írás módban nyitja meg. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Átadja a forrásdokumentumot, a beillesztendő dia pozícióját és címét a következő metódusnak.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// A megadott diát a prezentációba a megadott pozícióban szúrja be.

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

    // Ellenőrzi, hogy a prezentáció nem üres.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Egy új dia deklarálása és példányosítása.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // A dia tartalmának felépítése.            

    // A új dia nem vizuális tulajdonságainak megadása.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // A új dia csoport alakzat tulajdonságainak megadása.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // A új dia cím alakzatának deklarálása és példányosítása.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // A cím alakzat szükséges tulajdonságainak megadása. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // A cím alakzat szövegének megadása.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // A új dia főtest alakzatának deklarálása és példányosítása.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // A főtest alakzat szükséges tulajdonságainak megadása.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // A főtest alakzat szövegének megadása.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // A új dia részének létrehozása.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Az új dia rész mentése.

    slide.Save(slidePart);

    // A dia ID lista módosítása a prezentáció részben.

    // A dia ID lista nem lehet null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // A legmagasabb dia ID megtalálása az aktuális listában.

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

    // Az előző dia ID-jének lekérése.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Az előző diával megegyező diaelrendezés használata.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Az új dia beszúrása a dia listába az előző dia után.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // A módosított prezentáció mentése.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Minden PowerPoint prezentációfájl egy **Main Master slide** és további **Normal slides** elemet tartalmaz. Ez azt jelenti, hogy egy prezentációfájl legalább egy vagy több diát tartalmaz. Fontos tudni, hogy a slide‑ nélküli prezentációfájlok nem támogatottak az Aspose.Slides for .NET által. Minden dia meghatározott pozícióval és egy **unique Id**‑vel rendelkezik. A **slide Id** tartománya 0‑tól 255‑ig terjed a master diák esetén, és 256‑tól 65535‑ig a normál diák esetén.

Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy üres diákat adjanak a prezentációkhoz a **Presentation** objektum által biztosított **AddEmptySlide** metódus használatával. Üres dia hozzáadásához a prezentációhoz kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Hívja meg a Presentation objektum által biztosított AddEmptySlide metódust
- Végezzen némi műveletet az újonnan hozzáadott üres diával
- Adjon hozzá egy újabb diát, és szúrjon be szöveget.
- Végül írja ki a PPT fájlt a Presentation objektum által biztosított Write metódus használatával

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Példányosítja a PresentationEx osztályt, amely a PPT fájlt képviseli

Presentation pres = new Presentation();

//Üres dia alapértelmezés szerint hozzáadódik, amikor létrehozzák

//a prezentációt az alapértelmezett konstruktorból

//Üres dia hozzáadása a prezentációhoz és a hivatkozás lekérése

//az üres diáról

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Az eredmény mentése lemezre

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)