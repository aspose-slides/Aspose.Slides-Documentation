---
title: Aggiungere filigrane alle presentazioni in .NET
linktitle: Filigrana
type: docs
weight: 40
url: /it/net/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana immagine
- aggiungi filigrana
- modifica filigrana
- rimuovi filigrana
- elimina filigrana
- aggiungi filigrana a PPT
- aggiungi filigrana a PPTX
- aggiungi filigrana a ODP
- rimuovi filigrana da PPT
- rimuovi filigrana da PPTX
- rimuovi filigrana da ODP
- elimina filigrana da PPT
- elimina filigrana da PPTX
- elimina filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci filigrane di testo e immagine nelle presentazioni PowerPoint e OpenDocument in .NET per indicare bozza, informazioni confidenziali, copyright e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine usato su una diapositiva o su tutte le diapositive della presentazione. Solitamente, un watermark viene utilizzato per indicare che la presentazione è una bozza (ad es., un watermark “Bozza”), che contiene informazioni riservate (ad es., un watermark “Confidenziale”), per specificare a quale azienda appartiene (ad es., un watermark “Nome Azienda”), per identificare l’autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. I watermark sono usati sia nei formati PowerPoint che OpenDocument. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenDocument ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/net/), esistono vari modi per creare watermark in documenti PowerPoint o OpenDocument e modificarne design e comportamento. L’aspetto comune è che, per aggiungere watermark di testo, si deve utilizzare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/), e per aggiungere watermark di immagine, si usa la classe [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/) o si riempie una forma di watermark con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape) , consentendo di usare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape).

Ci sono due modi per applicare un watermark: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master viene usato per applicare un watermark a tutte le diapositive — il watermark viene aggiunto allo Slide Master, progettato completamente lì, e applicato a tutte le diapositive senza influire sul permesso di modificare il watermark su diapositive individuali.

Un watermark è normalmente considerato non modificabile da altri utenti. Per impedire che il watermark (o meglio la forma genitore del watermark) venga modificato, Aspose.Slides offre la funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma del watermark è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per il watermark in modo che in futuro, se si desidera eliminarlo, sia possibile trovarlo fra le forme della diapositiva per nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, di solito i watermark condividono caratteristiche comuni, come l’allineamento centrale, la rotazione, la posizione in primo piano, ecc. Considereremo come utilizzare queste funzionalità negli esempi seguenti.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo a una Diapositiva**

Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a questa forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), che dispone di un ampio set di proprietà per posizionare il watermark in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe) è avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) . Per aggiungere il testo del watermark alla forma, utilizzare il metodo [AddTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/methods/addtextframe) come mostrato di seguito.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Aggiungi la filigrana alla diapositiva.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Vedi anche" %}} 
- [Come utilizzare la classe TextFrame?](/slides/it/net/text-formatting/)
{{% /alert %}}

### **Aggiungere un Watermark di Testo a una Presentazione**

Se si desidera aggiungere un watermark di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerlo al [MasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/masterslide/). Il resto della logica è identico a quello per aggiungere un watermark a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e poi aggiungere il watermark usando il metodo [AddTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Aggiungi la filigrana alla diapositiva master.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Vedi anche" %}} 
- [Come utilizzare lo Slide Master?](/slides/it/net/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e di contorno. Ciò significa che quando il watermark viene aggiunto, può apparire con uno sfondo o un bordo opaco che può distrarre dal contenuto della diapositiva. Per garantire che il watermark rimanga discreto e non interferisca con il design visivo della presentazione, è possibile rendere la forma completamente trasparente.

Le righe di codice seguenti rendono la forma trasparente rimuovendo sia il colore di riempimento sia quello del bordo:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Impostare il Font per un Watermark di Testo**

Prima di applicare il watermark di testo alla diapositiva, è importante personalizzarne l’aspetto affinché si armonizzi con il design complessivo. È possibile cambiare il tipo e la dimensione del font per garantire che il watermark sia leggibile e esteticamente gradevole. Personalizzare il font può anche aiutare a rafforzare l’identità del brand o semplicemente a corrispondere allo stile della presentazione.

Il frammento di codice qui sotto mostra come regolare le impostazioni del font del watermark selezionando un font latino specifico e impostando un’altezza del font appropriata:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Impostare il Colore del Testo del Watermark**

Prima di applicare il watermark, è fondamentale assicurarsi che il colore del testo sia impostato correttamente in modo da integrarsi con il contenuto della diapositiva senza sovrastarlo. Regolare la trasparenza (alpha) del colore insieme ai componenti rosso, verde e blu consente di creare un watermark sottile e semitrasparente, visibile ma non invadente. Questo approccio aiuta a mantenere l’attenzione sulla presentazione principale proteggendo al contempo il contenuto.

Per impostare il colore del testo del watermark, utilizzare il codice seguente:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrare un Watermark di Testo**

Centrare correttamente il watermark di testo può migliorare notevolmente l’estetica della presentazione assicurando che il watermark sia posizionato in modo simmetrico, indipendentemente dalle dimensioni della diapositiva. Questo approccio conferisce alle diapositive un aspetto professionale e garantisce che il watermark non interferisca con il contenuto principale.

Il frammento di codice qui sotto mostra come calcolare la posizione centrale di una diapositiva e posizionare il watermark di testo di conseguenza:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

L’immagine seguente mostra il risultato finale.

![Il watermark di testo](text_watermark.png)

## **Watermark di Immagine**

### **Aggiungere un Watermark di Immagine a una Presentazione**

In molti casi, un watermark di immagine può fornire un elemento di branding unico o un’alternativa più attraente rispetto a un watermark di testo. Prima di aggiungere il watermark, assicurarsi che il file immagine sia disponibile (ad es., PNG per la trasparenza). L’esempio seguente dimostra come caricare un’immagine dal file system, aggiungerla alla presentazione e poi applicarla come watermark tramite le proprietà di riempimento della forma.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, utilizzare la proprietà [IAutoShape.ShapeLock](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/properties/shapelock) sulla forma. Con questa proprietà è possibile proteggere la forma dalla selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il testo dalla modifica e molto altro:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Blocca la forma della filigrana dalla modifica.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Portare un Watermark in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection.Reorder](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/reorder/#reorder). Per farlo, è necessario chiamare questo metodo dalla lista delle diapositive della presentazione e passare il riferimento della forma e il suo numero di ordine. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si desidera posizionare un watermark davanti alla presentazione:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Impostare la Rotazione del Watermark**

Regolare la rotazione del watermark può migliorare significativamente l’impatto visivo e la discrezione della presentazione. Un watermark diagonale, ad esempio, può risultare meno invasivo pur offrendo una protezione efficace contro l’uso non autorizzato. L’esempio seguente calcola l’angolo appropriato in base alle dimensioni della diapositiva affinché il watermark sia posizionato diagonalmente. Questo calcolo dinamico garantisce che il watermark rimanga efficace indipendentemente dalle diverse dimensioni delle diapositive.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma del watermark, assegnarlo alla proprietà [IAutoShape.Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Rimuovere un Watermark**

Per rimuovere la forma del watermark, utilizzare la proprietà [IAutoShape.Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/name) per trovarla tra le forme della diapositiva. Quindi, passare la forma del watermark al metodo [IShapeCollection.Remove](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/remove/) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Un Esempio Live**

Può essere utile provare gli strumenti online gratuiti di **Aspose.Slides** per [Aggiungere Watermark](https://products.aspose.app/slides/it/watermark) e [Rimuovere Watermark](https://products.aspose.app/slides/it/watermark/remove-watermark).

![Strumenti online per aggiungere e rimuovere watermark](online_tools.png)

## **FAQ**

### Cos'è un watermark e perché dovrei usarlo?

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, a migliorare il riconoscimento del brand o a impedire l’uso non autorizzato delle presentazioni.

### Posso aggiungere un watermark a tutte le diapositive di una presentazione?

Sì, Aspose.Slides consente di aggiungere programmaticamente un watermark a ogni diapositiva di una presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni del watermark singolarmente.

### Come posso regolare la trasparenza del watermark?

È possibile regolare la trasparenza del watermark modificando le impostazioni di riempimento ([FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/shape/fillformat/)) della forma. Questo garantisce che il watermark sia discreto e non distragga dal contenuto della diapositiva.

### Quali formati di immagine sono supportati per i watermark?

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

### Posso personalizzare il font e lo stile di un watermark di testo?

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattarli al design della presentazione e mantenere la coerenza del brand.

### Come modifico la posizione o l’orientamento di un watermark?

È possibile regolare la posizione e l’orientamento del watermark programmaticamente modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.