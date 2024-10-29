---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 20
url: /de/net/adding-slide-to-presentation/
---

## **OpenXML Präsentation**
In der folgenden Funktionalität wird standardmäßig eine Folie zur Präsentation hinzugefügt. Hier fügen wir eine neue Folie an Index 2 mit etwas Text hinzu.

``` csharp

 string FilePath = @"..\..\..\..\Beispiel Dateien\";

string FileName = FilePath + "Folie zur Präsentation hinzufügen.pptx";

InsertNewSlide(FileName, 1, "Meine neue Folie");

// Fügen Sie eine Folie in die angegebene Präsentation ein.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Öffnen Sie das Quell-Dokument im Lese-/Schreibmodus.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Übergeben Sie das Quell-Dokument sowie die Position und den Titel der einzufügenden Folie an die nächste Methode.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Fügen Sie die angegebene Folie an der angegebenen Position in die Präsentation ein.

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

    // Überprüfen Sie, ob die Präsentation nicht leer ist.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("Das Präsentationsdokument ist leer.");

    }

    // Deklarieren und instanziieren Sie eine neue Folie.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Konstruieren Sie den Folieninhalt.            

    // Geben Sie die nicht visuellen Eigenschaften der neuen Folie an.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Geben Sie die Gruppeneigenschaften der neuen Folie an.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Deklarieren und instanziieren Sie die Titelgestalt der neuen Folie.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Geben Sie die erforderlichen Shape-Eigenschaften für die Titelgestalt an. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Titel" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Geben Sie den Text der Titelgestalt an.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Deklarieren und instanziieren Sie die Körpergestalt der neuen Folie.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Geben Sie die erforderlichen Shape-Eigenschaften für die Körpergestalt an.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Inhaltsplatzhalter" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Geben Sie den Text der Körpergestalt an.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Erstellen Sie den Folienabschnitt für die neue Folie.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Speichern Sie den neuen Folienabschnitt.

    slide.Save(slidePart);

    // Ändern Sie die Folien-ID-Liste im Präsentationsabschnitt.

    // Die Folien-ID-Liste sollte nicht null sein.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Finden Sie die höchste Folien-ID in der aktuellen Liste.

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

    // Holen Sie die ID der vorherigen Folie.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Verwenden Sie dasselbe Folienlayout wie das der vorherigen Folie.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Fügen Sie die neue Folie in die Folienliste nach der vorherigen Folie ein.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Speichern Sie die geänderte Präsentation.

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
Jede PowerPoint-Präsentationsdatei enthält eine **Hauptmasterfolie** und andere **Normalfolien**. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine bestimmte Position und eine **eindeutige ID**. Die **Folien-ID** kann für Masterfolien von 0 bis 255 und für Normalfolien von 256 bis 65535 reichen.

Aspose.Slides für .NET ermöglicht Entwicklern, leere Folien zu den Präsentationen mithilfe der von Objekt **Presentation** bereitgestellten **AddEmptySlide**-Methode hinzuzufügen. Um eine leere Folie in die Präsentation einzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Rufen Sie die von Objekt Präsentation bereitgestellte Methode AddEmptySlide auf
- Bearbeiten Sie die neu hinzugefügte leere Folie
- Fügen Sie eine weitere Folie hinzu und fügen Sie Text darauf ein.
- Schreiben Sie schließlich die PPT-Datei mit der von Objekt Präsentation bereitgestellten Methode Write

``` csharp

 string FileName = FilePath + "Folie zur Präsentation hinzufügen.pptx";

//Instanziieren Sie die Klasse PresentationEx, die die PPT-Datei darstellt

Presentation pres = new Presentation();

//Eine leere Folie wird standardmäßig hinzugefügt, wenn Sie

//eine Präsentation vom Standardkonstruktor erstellen

//Fügen Sie eine leere Folie zur Präsentation hinzu und erhalten Sie die Referenz dieser leeren Folie

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Schreiben Sie die Ausgabe auf die Festplatte

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)