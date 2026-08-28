---
title: Converti diapositive di presentazione in immagini in .NET
linktitle: Diapositiva in immagine
type: docs
weight: 41
url: /it/net/convert-slide/
keywords:
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
- diapositiva in EMF
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Converti diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in C# con Aspose.Slides per .NET."
---
## **Introduzione**

Aspose.Slides for .NET può renderizzare diapositive individuali da presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Seleziona la diapositiva che desideri renderizzare.
3. Se necessario, configura il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/).
4. Chiama il metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/). Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/).
5. Chiama il metodo [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/) e specifica il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/).

## **Converti una diapositiva in un'immagine PNG**

La conversione più semplice utilizza le impostazioni di rendering predefinite. L'oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su file.

Il seguente esempio C# renderizza la prima diapositiva e la salva come immagine PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Converti diapositive in immagini con dimensioni personalizzate**

Usa la sovraccarico del metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/) che accetta un valore [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) per renderizzare una diapositiva con dimensioni in pixel esatte.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Converti diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Assegna un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/notescommentslayoutingoptions/) alla proprietà [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) per controllare dove compaiono note e commenti.

Il seguente esempio posiziona le note troncate sotto la diapositiva e i commenti a destra:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Per la conversione da diapositiva a immagine, non impostare la proprietà [NotesPosition](https://reference.aspose.com/slides/it/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) su [BottomFull](https://reference.aspose.com/slides/it/net/aspose.slides.export/notespositions/). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Usa invece [BottomTruncated](https://reference.aspose.com/slides/it/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Converti diapositive in immagini utilizzando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/) ti consente di controllare le dimensioni, la risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio renderizza la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Converti tutte le diapositive in immagini**

Itera la collezione di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non le salti esplicitamente.

Il seguente esempio renderizza ogni diapositiva come immagine JPEG con fattori di scala orizzontali e verticali pari a 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Crea output Enhanced Metafile**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafica vettoriale con Microsoft Office o altre applicazioni Windows che supportano i metafile di Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza la stessa perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per le applicazioni con supporto ai metafile di Windows, non un formato di interscambio universale. Inoltre, contenuti complessi delle diapositive, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore del metafile vettoriale.

### **Esporta una diapositiva in EMF**

Il metodo [ISlide.WriteAsEmf](https://reference.aspose.com/slides/it/net/aspose.slides/islide/writeasemf/) scrive un [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) in un flusso di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive in un flusso di file EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Chiama dispone del flusso passato a [ISlide.WriteAsEmf](https://reference.aspose.com/slides/it/net/aspose.slides/islide/writeasemf/) e deve chiuderlo o eliminarlo. Aspose.Slides scrive nella posizione corrente del flusso e lo lascia aperto.

### **Converti un'immagine SVG in EMF e aggiungila a una presentazione**

Usa [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/writeasemf/) per convertire contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [IImageCollection.AddImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection/addimage/) e inseriti in una diapositiva con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addpictureframe/).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile nella prima diapositiva e salva la presentazione:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/writeasemf/) non prende possesso del flusso di destinazione. Dopo la scrittura, la posizione del flusso è alla fine dei dati generati. Reimposta `Position` all'inizio prima di passare lo stesso flusso ricercabile a un lettore, come mostrato sopra. Mantieni il flusso aperto finché il consumatore non ha terminato la lettura, e poi eliminalo. In alternativa, chiama `ToArray` e passa l'array di byte restituito a [IImageCollection.AddImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection/addimage/); `ToArray` restituisce il buffer completo indipendentemente dalla posizione corrente del flusso.

La generazione di EMF è disponibile sui sistemi operativi supportati dalla versione di Aspose.Slides for .NET selezionata, ma il rendering può differire tra piattaforme quando i font o le dipendenze grafiche native non sono disponibili. Installa i font utilizzati dal contenuto di origine o configura sostituzioni appropriate, segui i [platform requirements](/slides/it/net/system-requirements/) per il tuo pacchetto Aspose.Slides, e valida il risultato nell'applicazione destinataria di EMF. Le applicazioni Linux e macOS hanno spesso supporto limitato o incoerente per la visualizzazione e modifica di metafile Windows.

## **Rendering di Emoji a Colori**

{{% alert title="Note" color="info" %}}
Per renderizzare correttamente le emoji a colori durante la conversione delle diapositive della presentazione in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione usa **Segoe UI Emoji** e questo font è mancante, le emoji potrebbero apparire in monocromo nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/) renderizza un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come le diapositive normali. Includile nel ciclo di elaborazione, come mostrato nell'esempio sopra.

**Le ombre e altri effetti sono preservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.