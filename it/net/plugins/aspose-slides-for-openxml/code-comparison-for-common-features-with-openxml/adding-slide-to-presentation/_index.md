---
title: Aggiungere diapositiva alla presentazione
type: docs
weight: 20
url: /it/net/adding-slide-to-presentation/
---
## **Presentazione OpenXML**
Nella funzionalità seguente, per impostazione predefinita viene aggiunta una diapositiva alla presentazione. Qui stiamo aggiungendo una nuova diapositiva all'indice 2 contenente del testo.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Inserisci una diapositiva nella presentazione specificata.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Apri il documento di origine in lettura/scrittura. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Passa il documento di origine, la posizione e il titolo della diapositiva da inserire al metodo successivo.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Inserisci la diapositiva specificata nella presentazione alla posizione indicata.

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

    // Verifica che la presentazione non sia vuota.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Dichiara e istanzia una nuova diapositiva.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Costruisci il contenuto della diapositiva.            

    // Specifica le proprietà non visive della nuova diapositiva.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Specifica le proprietà del gruppo di forme della nuova diapositiva.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Dichiara e istanzia la forma del titolo della nuova diapositiva.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Specifica le proprietà di forma richieste per la forma del titolo. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Specifica il testo della forma del titolo.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Dichiara e istanzia la forma del corpo della nuova diapositiva.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Specifica le proprietà di forma richieste per la forma del corpo.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Specifica il testo della forma del corpo.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Crea la parte diapositiva per la nuova diapositiva.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Salva la nuova parte diapositiva.

    slide.Save(slidePart);

    // Modifica l'elenco degli ID delle diapositive nella parte della presentazione.

    // L'elenco degli ID delle diapositive non deve essere nullo.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Trova l'ID diapositiva più alto nell'elenco corrente.

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

    // Ottieni l'ID della diapositiva precedente.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Usa lo stesso layout di diapositiva della diapositiva precedente.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Inserisci la nuova diapositiva nell'elenco delle diapositive dopo quella precedente.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Salva la presentazione modificata.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Ogni file di presentazione PowerPoint contiene una **diapositiva Master principale** e altre **diapositive Normali**. Ciò significa che un file di presentazione contiene almeno una o più diapositive. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides per .NET. Ogni diapositiva ha una posizione specifica e un **Id univoco**. L'**Id diapositiva** può variare da 0 a 255 per le diapositive master e da 256 a 65535 per le diapositive normali.

Aspose.Slides per .NET consente agli sviluppatori di aggiungere diapositive vuote alle presentazioni utilizzando il metodo **AddEmptySlide** esposto dall'oggetto **Presentation**. Per aggiungere una diapositiva vuota nella presentazione, seguite i passaggi seguenti:

- Creare un'istanza della classe Presentation
- Chiamare il metodo AddEmptySlide esposto dall'oggetto Presentation
- Eseguire alcune operazioni con la diapositiva vuota appena aggiunta
- Aggiungere un'altra diapositiva e inserire del testo su di essa.
- Infine, scrivere il file PPT utilizzando il metodo Write esposto dall'oggetto Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Instanzia la classe PresentationEx che rappresenta il file PPT

Presentation pres = new Presentation();

//Una diapositiva vuota è aggiunta per impostazione predefinita, quando crei

//la presentazione dal costruttore predefinito

//Aggiungendo una diapositiva vuota alla presentazione e ottenendo il riferimento di

//quella diapositiva vuota

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Scrivi l'output su disco

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)