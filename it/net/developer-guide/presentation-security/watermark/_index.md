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
description: "Gestisci filigrane di testo e immagine in presentazioni PowerPoint e OpenDocument in .NET per indicare una bozza, informazioni riservate, copyright e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Di solito, un watermark serve a indicare che la presentazione è una bozza (ad es., un watermark «Bozza»), che contiene informazioni riservate (ad es., un watermark «Confidenziale»), a specificare a quale azienda appartiene (ad es., un watermark «Nome Azienda»), a identificare l’autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. I watermark sono usati sia nei formati di presentazione PowerPoint sia in quelli OpenDocument. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenDocument ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/net/), esistono vari modi per creare watermark in documenti PowerPoint o OpenDocument e modificarne design e comportamento. L’aspetto comune è che, per aggiungere watermark di testo, si deve utilizzare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/), e per aggiungere watermark di immagine, si utilizza la classe [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/) oppure si riempie una forma watermark con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape) permettendo di usare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape).

Ci sono due modi per applicare un watermark: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare un watermark a tutte le diapositive — il watermark viene aggiunto allo Slide Master, progettato completamente lì, e applicato a tutte le diapositive senza influire sul permesso di modificare il watermark nelle singole diapositive.

Di solito, un watermark è considerato non modificabile da altri utenti. Per impedire che il watermark (o più precisamente la forma padre del watermark) venga modificato, Aspose.Slides fornisce la funzionalità di blocco della forma. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma watermark è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per il watermark così che, in futuro, se lo si desidera eliminare, si possa trovare tra le forme della diapositiva per nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, spesso i watermark presentano caratteristiche comuni, come l’allineamento al centro, la rotazione, la posizione anteriore, ecc. Nei seguenti esempi vedremo come utilizzare queste impostazioni.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo a una Diapositiva**

Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a questa forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), che possiede un ampio set di proprietà per posizionare il watermark in modo flessibile. Perciò, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe) è avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) . Per aggiungere il testo del watermark alla forma, usare il metodo [AddTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/methods/addtextframe) come mostrato di seguito.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Aggiungi la filigrana alla diapositiva.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare la classe TextFrame?](/slides/it/net/text-formatting/)
{{% /alert %}}

### **Aggiungere un Watermark di Testo a una Presentazione**

Se si desidera aggiungere un watermark di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerlo allo [MasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/masterslide/). Il resto della logica è identico a quello per aggiungere un watermark a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e poi aggiungere il watermark usando il metodo [AddTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Aggiungi la filigrana alla diapositiva master.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare lo Slide Master?](/slides/it/net/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e di contorno. Ciò significa che, quando il watermark viene aggiunto, può apparire con uno sfondo solido o un bordo che potrebbe distrarre dal contenuto della diapositiva. Per garantire che il watermark rimanga discreto e non interferisca con il design visivo della presentazione, è possibile rendere la forma completamente trasparente.

Il codice seguente rende la forma trasparente rimuovendo sia il colore di riempimento sia quello del bordo:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Impostare il Font per un Watermark di Testo**

Prima di applicare il watermark di testo alla diapositiva, è importante personalizzarne l’aspetto in modo che si armonizzi con il design complessivo. È possibile cambiare il tipo e la dimensione del font per garantire che il watermark sia leggibile e gradevole. La personalizzazione del font può anche aiutare a rafforzare l’identità del brand o semplicemente a far coincidere lo stile della presentazione.

Il frammento di codice qui sotto dimostra come regolare le impostazioni del font del watermark selezionando un font latino specifico e impostando un’altezza adeguata:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Impostare il Colore del Testo del Watermark**

Prima di applicare il watermark, è essenziale assicurarsi che il colore del testo sia impostato correttamente affinché si integri con il contenuto della diapositiva senza sovrastarlo. Regolare la trasparenza del colore (alpha) insieme ai componenti rosso, verde e blu consente di creare un watermark semi‑trasparente, visibile ma discreto. Questo approccio aiuta a mantenere l’attenzione sulla presentazione principale proteggendo al contempo i contenuti.

Per impostare il colore del testo del watermark, usare il codice seguente:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrare un Watermark di Testo**

Centrare correttamente il watermark di testo può migliorare notevolmente l’estetica complessiva della presentazione assicurando che il watermark sia posizionato in modo simmetrico, indipendentemente dalle dimensioni della diapositiva. Questo approccio conferisce alle diapositive un aspetto professionale e garantisce che il watermark non interferisca con il contenuto principale.

Il frammento di codice sotto mostra come calcolare la posizione centrale di una diapositiva e posizionare il watermark di testo di conseguenza:

```cs
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

![The text watermark](text_watermark.png)

## **Watermark di Immagine**

### **Aggiungere un Watermark di Immagine a una Presentazione**

In molti casi, un watermark di immagine può fornire un elemento di brand unico o un’alternativa più accattivante rispetto a un watermark di testo. Prima di aggiungere il watermark, assicurarsi che il file immagine sia disponibile (ad es., PNG per la trasparenza). L’esempio seguente dimostra come caricare un’immagine dal file system, aggiungerla alla presentazione e poi applicarla come watermark tramite le proprietà di riempimento della forma.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, utilizzare la proprietà [IAutoShape.ShapeLock](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/properties/shapelock) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```cs
// Blocca la forma della filigrana dalla modifica.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Portare un Watermark in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection.Reorder](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/reorder/#reorder). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero d’ordine. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si desidera collocare un watermark davanti alla presentazione:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Impostare la Rotazione del Watermark**

Regolare la rotazione del watermark può migliorare significativamente l’impatto visivo e la discrezione della presentazione. Un watermark diagonale, ad esempio, può risultare meno invasivo pur fornendo una protezione efficace contro l’uso non autorizzato. L’esempio seguente calcola l’angolo appropriato in base alle dimensioni della diapositiva affinché il watermark sia posizionato diagonalmente. Questo calcolo dinamico garantisce che il watermark rimanga efficace indipendentemente dalle diverse dimensioni delle diapositive.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma watermark, assegnarlo alla proprietà [IAutoShape.Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Rimuovere un Watermark**

Per rimuovere la forma watermark, utilizzare la proprietà [IAutoShape.Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/name) per trovarla tra le forme della diapositiva. Quindi passare la forma watermark al metodo [IShapeCollection.Remove](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/remove/) :

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Un Esempio Live**

Potete provare gli strumenti online gratuiti di **Aspose.Slides** [Aggiungi Watermark](https://products.aspose.app/slides/it/watermark) e [Rimuovi Watermark](https://products.aspose.app/slides/it/watermark/remove-watermark).

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Che cos’è un watermark e perché dovrei usarlo?**

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, a migliorare il riconoscimento del brand o a prevenire l’uso non autorizzato delle presentazioni.

**Posso aggiungere un watermark a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere programmaticamente un watermark a ogni diapositiva di una presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni del watermark individualmente.

**Come posso regolare la trasparenza del watermark?**

È possibile regolare la trasparenza del watermark modificando le impostazioni di riempimento ([FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/shape/fillformat/)) della forma. Questo garantisce che il watermark sia discreto e non distragga dal contenuto della diapositiva.

**Quali formati di immagine sono supportati per i watermark?**

Aspose.Slides supporta vari formati di immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di un watermark di testo?**

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattarli al design della presentazione e mantenere la coerenza del brand.

**Come modifico la posizione o l’orientamento di un watermark?**

È possibile regolare programmaticamente la posizione e l’orientamento del watermark modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.