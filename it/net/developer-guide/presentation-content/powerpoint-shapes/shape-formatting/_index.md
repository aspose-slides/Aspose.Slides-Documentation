---
title: Formattare le forme PowerPoint in .NET
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/net/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile di giunzione
- riempimento gradiente
- riempimento a trama
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in C# usando Aspose.Slides—imposta riempimento, linea e stili di effetto per file PPT e PPTX con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides per .NET fornisce interfacce e proprietà che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti illustrano la procedura:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare lo [stile della linea](https://reference.aspose.com/slides/it/net/aspose.slides/linestyle/) della forma.
1. Impostare lo spessore della linea.
1. Impostare lo [stile tratteggiato](https://reference.aspose.com/slides/it/net/aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il seguente codice C# dimostra come formattare un `AutoShape` rettangolare:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il colore di riempimento per la forma rettangolare.
    shape.FillFormat.FillType = FillType.NoFill;

    // Applica la formattazione alle linee del rettangolo.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Imposta il colore per la linea del rettangolo.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Salva il file PPTX su disco.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The formatted lines in the presentation](formatted-lines.png)

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a disegnata a mano. Utilizzare [IShape.LineFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/lineformat/) per accedere alle impostazioni della linea, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformat/sketchformat/) per accedere alle impostazioni dello schizzo e [ISketchFormat.SketchType](https://reference.aspose.com/slides/it/net/aspose.slides/isketchformat/sketchtype/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/net/aspose.slides/linesketchtype/).

Il seguente codice C# mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/net/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Il valore restituito da `ISketchFormat.SketchType` rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, una diapositiva master o una diapositiva layout, utilizzare [ILineFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformat/geteffective/), accedere a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformateffectivedata/sketchformat/) e leggere [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/it/net/aspose.slides/isketchformateffectivedata/sketchtype/). Il valore effettivo riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Arrotondato
* Smusso
* Smussato

Per impostazione predefinita, quando PowerPoint unisce due linee ad angolo (ad esempio a un angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se si sta disegnando una forma con angoli acuti, si potrebbe preferire l'opzione **Smusso**.

![The join style in the presentation](join-style-powerpoint.png)

Il seguente codice C# dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di giunzione Smusso, Smussato e Arrotondato:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi tre forme automatiche di tipo Rettangolo.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Imposta il colore di riempimento per ciascuna forma rettangolare.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Imposta lo spessore della linea.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Imposta il colore per la linea di ciascun rettangolo.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Imposta lo stile di giunzione.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Aggiungi testo a ciascun rettangolo.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Salva il file PPTX su disco.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Riempimento gradiente**

In PowerPoint, il Riempimento gradiente è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma usando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con posizioni definite utilizzando i metodi `Add` della collezione di stop del gradiente esposta dall'interfaccia [IGradientFormat](https://reference.aspose.com/slides/it/net/aspose.slides/igradientformat/).
1. Salvare la presentazione modificata come file PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applica la formattazione gradiente all'ellisse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Imposta la direzione del gradiente.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Aggiungi due punti di arresto del gradiente.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Salva il file PPTX su disco.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![The ellipse with gradient fill](gradient-fill.png)

## **Riempimento a trama**

In PowerPoint, il Riempimento a trama è un'opzione di formattazione che consente di applicare a una forma un disegno a due colori — come punti, strisce, tratteggi incrociati o quadretti —. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di trama predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato una trama predefinita, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a trama a una forma usando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di trama dalle opzioni predefinite.
1. Impostare il [Background Color](https://reference.aspose.com/slides/it/net/aspose.slides/ipatternformat/backcolor/) della trama.
1. Impostare il [Foreground Color](https://reference.aspose.com/slides/it/net/aspose.slides/ipatternformat/forecolor/) della trama.
1. Salvare la presentazione modificata come file PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento a Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Imposta lo stile del motivo.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Imposta i colori di sfondo e di primo piano del motivo.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Salva il file PPTX su disco.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![The rectangle with pattern fill](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma, utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come usare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Creare un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) dall'immagine da utilizzare.
1. Assegnare questa immagine alla proprietà `Picture.Image` del `PictureFillFormat` della forma.
1. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![The lotus picture](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Imposta il tipo di riempimento a Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Imposta la modalità di riempimento immagine.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Carica un'immagine e aggiungila alle risorse della presentazione.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Imposta l'immagine.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Salva il file PPTX su disco.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

![The shape with picture fill](picture-fill.png)

### **Immagine a piastrellare come texture**

Se si desidera impostare un'immagine a piastrellare come texture e personalizzare il comportamento della piastrellatura, è possibile utilizzare le seguenti proprietà dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/picturefillmode/): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tilealignment/): Specifica l'allineamento delle piastrelle all'interno della forma.
- [TileFlip](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tileflip/): Controlla se la piastrella è capovolta orizzontalmente, verticalmente o in entrambi i modi.
- [TileOffsetX](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tileoffsetx/): Imposta lo spostamento orizzontale della piastrella (in punti) dall'origine della forma.
- [TileOffsetY](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tileoffsety/): Imposta lo spostamento verticale della piastrella (in punti) dall'origine della forma.
- [TileScaleX](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tilescalex/): Definisce la scala orizzontale della piastrella in percentuale.
- [TileScaleY](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tilescaley/): Definisce la scala verticale della piastrella in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con un riempimento immagine a piastrellare e configurare le opzioni di piastrellatura:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide firstSlide = presentation.Slides[0];

    // Aggiungi una forma automatica rettangolare.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Imposta il tipo di riempimento della forma su Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Carica l'immagine e aggiungila alle risorse della presentazione.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Assegna l'immagine alla forma.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configura la modalità di riempimento immagine e le proprietà di piastrellatura.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Salva il file PPTX su disco.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

![The tile options](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o trame.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare il colore di riempimento preferito alla forma.
1. Salvare la presentazione modificata come file PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Imposta il colore di riempimento.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Salva il file PPTX su disco.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![The shape with solid color fill](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento a colore solido, gradiente, immagine o texture a delle forme, è possibile anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore utilizzato per il riempimento. Ecco come fare:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Solid`.
1. Utilizzare `Color.FromArgb(alpha, baseColor)` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica rettangolare solida.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Aggiungi una forma automatica rettangolare trasparente sopra la forma solida.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Salva il file PPTX su disco.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![The transparent shape](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare la proprietà `Rotation` della forma sull'angolo desiderato.
1. Salvare la presentazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ruota la forma di 5 gradi.
    shape.Rotation = 5;

    // Salva il file PPTX su disco.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![The shape rotation](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, seguire questi passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salvare la presentazione.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma alla diapositiva.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Imposta le proprietà ThreeDFormat della forma.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Salva la presentazione come file PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

![The 3D bevel effect](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [CameraType](https://reference.aspose.com/slides/it/net/aspose.slides/icamera/cameratype/) e il [LightType](https://reference.aspose.com/slides/it/net/aspose.slides/ilightrig/lighttype/) della forma per definire la rotazione 3D.
1. Salvare la presentazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Salva la presentazione come file PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

![The 3D rotation effect](3D-rotation-effect.png)

## **Controllare la resa in bianco e nero per le forme**

La proprietà [IShape.BlackWhiteMode](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/blackwhitemode/) specifica come viene renderizzata una singola forma quando una presentazione viene visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero di per sé e non modifica il riempimento, la linea o altre formattazioni della forma in modalità colore normale.

Utilizzare un valore dell'enumerazione [BlackWhiteMode](https://reference.aspose.com/slides/it/net/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all'applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` utilizza solo nero e bianco, `Black` e `White` forzano un unico colore, `Color` preserva la colorazione normale e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che non è stato assegnato alcun modo a livello di forma.

Il seguente codice C# crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione in bianco e nero:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Mantieni il riempimento arancione in modalità colore, ma visualizza la forma con colorazione grigia in modalità bianco e nero.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, utilizza la colorazione grigia perché il suo modo è impostato su `Gray`. Questo consente di preservare una diapositiva a colori completi definendo al contempo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione in bianco e nero della presentazione.

## **Reimpostare la formattazione**

Il seguente codice C# mostra come reimpostare la formattazione di una diapositiva e ripristinare posizione, dimensione e formattazione di tutte le forme con segnaposto sulla [LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslide/) alle impostazioni predefinite:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Reimposta ogni forma della diapositiva che ha un segnaposto nel layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso individuare le forme su una diapositiva che condividono la stessa formattazione in modo da poterle raggruppare?**

Confrontare le proprietà chiave di formattazione di ciascuna forma — impostazioni di riempimento, linea ed effetto. Se tutti i valori corrispondenti coincidono, considerare i loro stili identici e raggruppare logicamente quelle forme, semplificando la gestione degli stili successiva.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarli in altre presentazioni?**

Sì. Conservare le forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme stilizzate necessarie e riapplicare la loro formattazione dove richiesto.