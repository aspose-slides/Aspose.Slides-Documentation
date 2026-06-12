---
title: "Gestire lo Zoom della Presentazione in .NET"
linktitle: "Gestire Zoom"
type: docs
weight: 60
url: /it/net/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom diapositiva
- zoom sezione
- zoom riepilogo
- aggiungere zoom
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea e personalizza lo Zoom con Aspose.Slides per .NET — passa tra le sezioni, aggiungi miniature e transizioni in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Le Zoom in PowerPoint consentono di saltare a e da diapositive, sezioni e parti specifiche di una presentazione. Quando presenti, questa capacità di navigare rapidamente nel contenuto può risultare molto utile. 

![overview_image](overview.png)

* Per riassumere un'intera presentazione in un'unica diapositiva, usa un [Summary Zoom](#Summary-Zoom).
* Per mostrare solo le diapositive selezionate, usa un [Slide Zoom](#Slide-Zoom).
* Per mostrare una singola sezione, usa un [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Una slide zoom può rendere la tua presentazione più dinamica, consentendo di navigare liberamente tra le diapositive in qualsiasi ordine tu scelga senza interrompere il flusso della presentazione. Le slide zoom sono ottime per presentazioni brevi con poche sezioni, ma possono comunque essere utilizzate in diversi scenari di presentazione.

Le slide zoom ti aiutano a approfondire più elementi di informazione mantenendo la sensazione di essere su una singola tela. 

![overview_image](slidezoomsel.png)

Per gli oggetti slide zoom, Aspose.Slides fornisce l'enumerazione [ZoomImageType](https://reference.aspose.com/slides/it/net/aspose.slides/zoomimagetype), l'interfaccia [IZoomFrame](https://reference.aspose.com/slides/it/net/aspose.slides/izoomframe) e alcuni metodi dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection).

### **Crea Frame Zoom**

Puoi aggiungere un frame zoom su una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea nuove diapositive a cui intendi collegare i frame zoom. 
3.	Aggiungi un testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungi i frame zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5.	Scrivi la presentazione modificata come file PPTX.

Questo codice C# mostra come creare un frame zoom su una diapositiva:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge nuove diapositive alla presentazione
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crea uno sfondo per la seconda diapositiva
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crea una casella di testo per la seconda diapositiva
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Crea uno sfondo per la terza diapositiva
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crea una casella di testo per la terza diapositiva
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Aggiunge oggetti ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Crea Frame Zoom con Immagini Personalizzate**
Con Aspose.Slides per .NET, è possibile creare un frame zoom con un'immagine di anteprima della diapositiva diversa in questo modo: 
1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea una nuova diapositiva a cui intendi collegare il frame zoom. 
3.	Aggiungi un testo di identificazione e uno sfondo alla diapositiva.
4.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) che verrà utilizzato per riempire il frame.
5.	Aggiungi i frame zoom (contenenti il riferimento alla diapositiva creata) alla prima diapositiva.
6.	Scrivi la presentazione modificata come file PPTX.

Questo codice C# mostra come creare un frame zoom con un'immagine diversa:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crea uno sfondo per la seconda diapositiva
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crea una casella di testo per la terza diapositiva
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Crea una nuova immagine per l'oggetto zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Aggiunge l'oggetto ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formatta Frame Zoom**
Nelle sezioni precedenti, ti abbiamo mostrato come creare frame zoom semplici. Per creare frame zoom più complessi, devi modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che puoi applicare a un frame zoom. 

Puoi controllare la formattazione di un frame zoom su una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea nuove diapositive a cui intendi collegare il frame zoom. 
3.	Aggiungi del testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungi i frame zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) che sarà usato per riempire il frame.
6.	Imposta un'immagine personalizzata per il primo oggetto frame zoom.
7.	Modifica il formato della linea per il secondo oggetto frame zoom.
8.	Rimuovi lo sfondo da un'immagine del secondo oggetto frame zoom.
5.Scrivi la presentazione modificata come file PPTX.

Questo codice C# mostra come cambiare la formattazione di un frame zoom su una diapositiva: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge nuove diapositive alla presentazione
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crea uno sfondo per la seconda diapositiva
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crea una casella di testo per la seconda diapositiva
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Crea uno sfondo per la terza diapositiva
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crea una casella di testo per la terza diapositiva
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Aggiunge oggetti ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Crea una nuova immagine per l'oggetto zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Imposta un'immagine personalizzata per l'oggetto zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Imposta un formato di frame zoom per l'oggetto zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Impostazione per non mostrare lo sfondo per l'oggetto zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

Una sezione zoom è un collegamento a una sezione della tua presentazione. Puoi utilizzare le sezioni zoom per tornare alle sezioni che desideri enfatizzare. Oppure puoi usarle per evidenziare come determinate parti della tua presentazione si collegano tra loro. 

![overview_image](seczoomsel.png)

Per gli oggetti section zoom, Aspose.Slides fornisce l'interfaccia [ISectionZoomFrame](https://reference.aspose.com/slides/it/net/aspose.slides/isectionzoomframe) e alcuni metodi dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection).

### **Crea Frame Section Zoom**

Puoi aggiungere un frame section zoom a una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea una nuova diapositiva. 
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui intendi collegare il frame zoom. 
5.	Aggiungi un frame section zoom (contenente riferimenti alla sezione creata) alla prima diapositiva.
6.	Scrivi la presentazione modificata come file PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 1", slide);

    // Aggiunge un oggetto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Crea Frame Section Zoom con Immagini Personalizzate**

Utilizzando Aspose.Slides per .NET, è possibile creare un frame section zoom con un'immagine di anteprima della diapositiva diversa in questo modo: 

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea una nuova diapositiva.
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui intendi collegare il frame zoom. 
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) che sarà usato per riempire il frame.
5.	Aggiungi un frame section zoom (contenente un riferimento alla sezione creata) alla prima diapositiva.
6.	Scrivi la presentazione modificata come file PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 1", slide);

    // Crea una nuova immagine per l'oggetto zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Aggiunge un oggetto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formatta Frame Section Zoom**

Per creare frame section zoom più complessi, devi modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che puoi applicare a un frame section zoom. 

Puoi controllare la formattazione di un frame section zoom su una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea una nuova diapositiva.
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui intendi collegare il frame zoom. 
5.	Aggiungi un frame section zoom (contenente riferimenti alla sezione creata) alla prima diapositiva.
6.	Modifica la dimensione e la posizione dell'oggetto section zoom creato.
7.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) che sarà usato per riempire il frame.
8.	Imposta un'immagine personalizzata per l'oggetto frame section zoom creato.
9.	Imposta la capacità di *ritorno alla diapositiva originale dalla sezione collegata*.
10.	Rimuovi lo sfondo da un'immagine dell'oggetto frame section zoom.
11.	Modifica il formato della linea per il secondo oggetto frame zoom.
12.	Modifica la durata della transizione.
13.Scrivi la presentazione modificata come file PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 1", slide);

    // Aggiunge un oggetto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formattazione per SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Summary Zoom**

Uno summary zoom è come una pagina di destinazione in cui tutti gli elementi della tua presentazione sono visualizzati contemporaneamente. Quando presenti, puoi usare lo zoom per passare da un punto all'altro della presentazione in qualsiasi ordine desideri. Puoi essere creativo, saltare in avanti o rivedere parti della tua presentazione senza interrompere il flusso. 

![overview_image](sumzoomsel.png)

Per gli oggetti summary zoom, Aspose.Slides fornisce le interfacce [ISummaryZoomFrame](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomsection) e [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomsectioncollection) e alcuni metodi dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection).

### **Crea un Summary Zoom**

Puoi aggiungere un frame summary zoom a una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi il frame summary zoom alla prima diapositiva.
4.	Scrivi la presentazione modificata come file PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 1", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 2", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 3", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 4", slide);

    // Aggiunge un oggetto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Aggiungi e Rimuovi una Sezione Summary Zoom**

Tutte le sezioni in un frame summary zoom sono rappresentate da oggetti [ISummaryZoomFrameSection](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomsection), che sono memorizzati nell'oggetto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomsectioncollection). È possibile aggiungere o rimuovere un oggetto sezione summary zoom tramite l'interfaccia [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomsectioncollection) in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi un frame summary zoom nella prima diapositiva.
4.	Aggiungi una nuova diapositiva e una sezione alla presentazione.
5.	Aggiungi la sezione creata al frame summary zoom.
6.	Rimuovi la prima sezione dal frame summary zoom.
7.Scrivi la presentazione modificata come file PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 1", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 2", slide);

    // Aggiunge oggetto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Aggiunge una sezione al Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Rimuove la sezione dal Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatta Sezioni Summary Zoom**

Per creare oggetti sezione summary zoom più complessi, devi modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che puoi applicare a un oggetto sezione summary zoom. 

Puoi controllare la formattazione di un oggetto sezione summary zoom in un frame summary zoom in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi un frame summary zoom alla prima diapositiva.
4.	Ottieni un oggetto sezione summary zoom per il primo oggetto dalla `ISummaryZoomSectionCollection`.
7.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un'immagine alla collezione images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) che sarà usato per riempire il frame.
8.	Imposta un'immagine personalizzata per l'oggetto frame sezione zoom creato.
9.	Imposta la capacità di *ritorno alla diapositiva originale dalla sezione collegata*.
11.	Modifica il formato della linea per il secondo oggetto frame zoom.
12.	Modifica la durata della transizione.
13.Scrivi la presentazione modificata come file PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 1", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Aggiunge una nuova sezione alla presentazione
    pres.Sections.AddSection("Section 2", slide);

    // Aggiunge un oggetto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Ottiene il primo oggetto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formattazione per l'oggetto SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Salva la presentazione
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso controllare il ritorno alla diapositiva 'genitore' dopo aver mostrato il bersaglio?**

Sì. Il [Zoom frame](https://reference.aspose.com/slides/it/net/aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/it/net/aspose.slides/sectionzoomframe/) ha un comportamento `ReturnToParent` che, quando abilitato, riporta gli spettatori alla diapositiva di origine dopo che hanno visualizzato il contenuto target.

**Posso regolare la 'velocità' o la durata della transizione Zoom?**

Sì. Zoom supporta la possibilità di impostare un `TransitionDuration` così puoi controllare la durata dell'animazione di salto.

**Ci sono limiti al numero di oggetti Zoom che una presentazione può contenere?**

Non esiste un limite rigido dell'API documentato. I limiti pratici dipendono dalla complessità complessiva della presentazione e dalle prestazioni del visualizzatore. Puoi aggiungere molti frame Zoom, ma considera le dimensioni del file e il tempo di rendering.