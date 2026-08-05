---
title: Formattare le forme PowerPoint in .NET
linktitle: Formattazione della forma
type: docs
weight: 20
url: /it/net/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile unione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento trama
- riempimento a colore solido
- trasparenza forma
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in C# usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT e PPTX con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti gli interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fornisce interfacce e proprietà che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Con Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti illustrano la procedura:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta lo [line style](https://reference.aspose.com/slides/it/net/aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [dash style](https://reference.aspose.com/slides/it/net/aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice C# dimostra come formattare un `AutoShape` rettangolare:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
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

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a un disegno a mano. Usa [IShape.LineFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/lineformat/) per accedere alle impostazioni della linea, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformat/sketchformat/) per accedere alle impostazioni dello schizzo e [ISketchFormat.SketchType](https://reference.aspose.com/slides/it/net/aspose.slides/isketchformat/sketchtype/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/net/aspose.slides/linesketchtype/).

Il seguente codice C# mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/net/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/net/aspose.slides/linesketchtype/):

```csharp
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

Il valore restituito da `ISketchFormat.SketchType` rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [ILineFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformat/geteffective/), accedi a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformateffectivedata/sketchformat/) e leggi [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/it/net/aspose.slides/isketchformateffectivedata/sketchtype/). Il valore efficace riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà:

```csharp
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

* Round
* Miter
* Bevel

Per impostazione predefinita, quando PowerPoint unisce due linee ad angolo (ad esempio nell'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se stai disegnando una forma con angoli acuti, potresti preferire l'opzione **Miter**.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Il seguente codice C# dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di giunzione Miter, Bevel e Round:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi tre forme automatiche di tipo Rectangle.
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

    // Imposta la larghezza della linea.
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

In PowerPoint, il Riempimento Gradiente è un'opzione di formattazione che consente di applicare una transizione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungi i due colori preferiti con posizioni definite usando i metodi `Add` della raccolta di fermate gradiente esposta dall'interfaccia [IGradientFormat](https://reference.aspose.com/slides/it/net/aspose.slides/igradientformat/).
1. Salva la presentazione modificata come file PPTX.

Il seguente codice C# dimostra come applicare un effetto di riempimento gradiente a un'ellisse:

```c#
 // Istantiare la classe Presentation che rappresenta un file di presentazione.
 using (Presentation presentation = new Presentation())
 {
     // Ottieni la prima diapositiva.
     ISlide slide = presentation.Slides[0];

     // Aggiungi una forma automatica di tipo Ellipse.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

     // Applica la formattazione a gradiente all'ellisse.
     shape.FillFormat.FillType = FillType.Gradient;
     shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

     // Imposta la direzione del gradiente.
     shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

     // Aggiungi due fermate del gradiente.
     shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
     shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

     // Salva il file PPTX su disco.
     presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
 }
```

Il risultato:

![L'ellisse con riempimento sfumato](gradient-fill.png)

## **Riempimento a motivo**

In PowerPoint, il Riempimento a Motivo è un'opzione di formattazione che consente di applicare un disegno a due colori—come punti, strisce, incroci o scacchi—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegli uno stile di motivo tra le opzioni predefinite.
1. Imposta il [Background Color](https://reference.aspose.com/slides/it/net/aspose.slides/ipatternformat/backcolor/) del motivo.
1. Imposta il [Foreground Color](https://reference.aspose.com/slides/it/net/aspose.slides/ipatternformat/forecolor/) del motivo.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice C# dimostra come applicare un riempimento a motivo a un rettangolo:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Imposta lo stile del motivo.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Imposta i colori di sfondo e primo piano del motivo.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Salva il file PPTX su disco.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento Immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma—utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Picture`.
1. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) dall'immagine che desideri utilizzare.
1. Assegna questa immagine alla proprietà `Picture.Image` del `PictureFillFormat` della forma.
1. Salva la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

Il seguente codice C# dimostra come riempire una forma con l'immagine:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Imposta il tipo di riempimento su Picture.
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

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Piastrellare l'immagine come trama**

Se desideri impostare un'immagine a piastrellatura come trama e personalizzare il comportamento della piastrellatura, puoi utilizzare le seguenti proprietà dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/picturefillmode/): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tilealignment/): Specifica l'allineamento delle piastrelle all'interno della forma.
- [TileFlip](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tileflip/): Controlla se la piastrella è capovolta orizzontalmente, verticalmente o entrambi.
- [TileOffsetX](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tileoffsetx/): Imposta lo spostamento orizzontale della piastrella (in punti) dall'origine della forma.
- [TileOffsetY](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tileoffsety/): Imposta lo spostamento verticale della piastrella (in punti) dall'origine della forma.
- [TileScaleX](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tilescalex/): Definisce la scala orizzontale della piastrella in percentuale.
- [TileScaleY](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/tilescaley/): Definisce la scala verticale della piastrella in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine a piastrellatura e configurare le opzioni di piastrellatura:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
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

Il risultato:

![Le opzioni di piastrellatura](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a Colore Solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice è applicato senza gradienti, trame o motivi.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Solid`.
1. Assegna alla forma il colore di riempimento desiderato.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice C# dimostra come applicare un riempimento a colore solido a un rettangolo in una diapositiva PowerPoint:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
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

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando applichi un riempimento a colore solido, gradiente, immagine o trama a delle forme, puoi anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più traslucida, permettendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) della forma su `Solid`.
1. Usa `Color.FromArgb(alpha, baseColor)` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

Il seguente codice C# dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```c#
const int alpha = 128;

// Istantiare la classe Presentation che rappresenta un file di presentazione.
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

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta la proprietà `Rotation` della forma sull'angolo desiderato.
1. Salva la presentazione.

Il seguente codice C# dimostra come ruotare una forma di 5 gradi:

```c#
// Istantiare la classe Presentation che rappresenta un file di presentazione.
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

Il risultato:

![Rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le proprietà del loro [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salva la presentazione.

Il seguente codice C# mostra come applicare effetti di smusso 3D a una forma:

```c#
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

Il risultato:

![Effetto smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le proprietà del loro [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [CameraType](https://reference.aspose.com/slides/it/net/aspose.slides/icamera/cameratype/) e il [LightType](https://reference.aspose.com/slides/it/net/aspose.slides/ilightrig/lighttype/) della forma per definire la rotazione 3D.
1. Salva la presentazione.

Il seguente codice C# dimostra come applicare effetti di rotazione 3D a una forma:

```c#
// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Salva la presentazione come file PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Effetto di rotazione 3D](3D-rotation-effect.png)

## **Ripristinare la formattazione**

Il seguente codice C# mostra come ripristinare la formattazione di una diapositiva e riportare la posizione, le dimensioni e la formattazione di tutte le forme con segnaposto sul [LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslide/) alle impostazioni predefinite:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Ripristina ogni forma sulla diapositiva che ha un segnaposto sul layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso individuare le forme su una diapositiva che condividono la stessa formattazione per raggrupparle?**

Confronta le proprietà chiave di formattazione di ciascuna forma—impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili identici e raggruppa logicamente quelle forme, semplificando la gestione degli stili in seguito.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva le forme di esempio con gli stili desiderati in un modello di presentazione o in un file .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.