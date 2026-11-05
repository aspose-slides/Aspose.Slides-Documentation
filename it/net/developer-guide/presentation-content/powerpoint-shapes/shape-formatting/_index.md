---
title: Formattare le forme PowerPoint in .NET
linktitle: Formattazione delle forme
type: docs
weight: 20
url: /it/net/shape-formatting/
keywords:
- formattazione forma
- formattazione linea
- effetto schizzo
- linea forma schizzo
- formattazione stile giunzione
- riempimento gradiente
- riempimento pattern
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- rotazione forma
- effetto smusso 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in C# usando Aspose.Slides — imposta stili di riempimento, linea ed effetto per file PPT e PPTX con precisione e pieno controllo."
---
## **Introduzione**

Formatta le forme in PowerPoint regolando i contorni, i riempimenti e gli effetti. Aspose.Slides per .NET consente di controllare queste impostazioni programmaticamente, inclusi trasparenza, rotazione e formattazione 3D.

![Opzioni di formattazione della forma in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per .NET fornisce interfacce e proprietà che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Usa [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) per controllare il contorno di una forma. Questo esempio crea un rettangolo non riempito con un contorno blu a tratteggio. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) seleziona una linea composta spessa-sottile, mentre [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) imposta la larghezza a 7 punti e [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) sceglie il modello di tratto.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

### **Imposta modelli di tratto personalizzati**

Usa [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) quando gli stili di linea predefiniti non forniscono le lunghezze di tratto e i vuoti di cui hai bisogno, ad esempio per contorni aziendali o diagrammi tecnici. L'assegnazione di un modello imposta automaticamente [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) su [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Le voci dell'array alternano lunghezze di tratto e di vuoto, iniziando con un tratto. Ogni valore è un multiplo della larghezza della linea: `{ 4, 2 }` con larghezza di 3 punti genera un tratto di 12 punti seguito da un vuoto di 6 punti. Usa coppie di valori finiti e non negativi per definire segmenti completi di tratto‑vuoto. L'esempio utilizza valori positivi per mantenere visibili tutti i tratti e i vuoti.

Questo esempio crea cinque linee blu della stessa lunghezza e con estremità piatte. Le prime tre confrontano i modelli a una larghezza di 3 punti. La quarta ripete il primo modello a doppia larghezza, raddoppiando sia le lunghezze dei tratti sia dei vuoti. La quinta passa da un modello personalizzato a una linea continua.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Per tornare a uno stile di tratto predefinito, assegna [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) a [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Lo stile selezionato controlla l'aspetto della linea.

Il risultato in PowerPoint, dall'alto verso il basso: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Tre modelli di tratto personalizzati, una linea più larga usando il primo modello, e una linea continua in PowerPoint](custom-dash-patterns.png)


### **Imposta le estremità della linea**

Usa [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) per impostare le estremità di una linea aperta. L'enumerazione [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) fornisce tre stili di estremità espliciti:

- `Flat`: il tratto termina al punto finale.
- `Round`: un'estremità semicircolare si estende oltre il punto finale per metà della larghezza della linea.
- `Square`: un'estremità quadrata si estende oltre il punto finale per metà della larghezza della linea.

L'enumerazione include anche `NotDefined`, che indica che nessuno stile di estremità è stato assegnato esplicitamente.

Le estremità sono diverse dalle punte delle frecce, che aggiungono simboli alle estremità della linea, e dalle giunzioni, che controllano gli angoli tra i segmenti della linea. Questo esempio disabilita le punte delle frecce tramite [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) e [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) in modo che vengano confrontate solo le forme delle estremità.

L'esempio seguente crea tre linee orizzontali altrimenti identiche, larghe 20 punti. Dall'alto verso il basso, usano estremità piatte, arrotondate e quadrate. Le loro estremità hanno le stesse coordinate orizzontali; le estremità arrotondate e quadrate si estendono di 10 punti oltre ciascuna estremità.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Il risultato in PowerPoint, dall'alto verso il basso: **Flat**, **Round**, e **Square**.

![Estremità piatte, arrotondate e quadrate su linee spesse identiche in PowerPoint](line-caps.png)

## **Applicare effetti di schizzi alle linee della forma**

Un effetto di schizzo rende una linea della forma simile a un tratto a mano libera. Usa [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) per accedere alle impostazioni della linea, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) per le impostazioni dello schizzo e [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Il codice C# seguente mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Il valore restituito da [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, dal master slide o dal layout slide, usa [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), accedi a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) e leggi [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Il valore effettivo riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà. Questo esempio richiede una presentazione esistente con almeno una forma nella prima diapositiva e stampa entrambi i valori:

```csharp
using System;
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

* Round
* Miter
* Bevel

Lo stile di giunzione controlla come due segmenti di contorno si incontrano a un angolo. Usa **Round** per angoli arrotondati, **Miter** per angoli affilati o **Bevel** per angoli smussati.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Questo esempio crea tre rettangoli neri con contorni blu larghi 15 punti. Imposta [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) sui valori miter, bevel e round dell'enumerazione [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), rispettivamente, per confrontare come vengono disegnati gli angoli.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Limitare le giunzioni miter in angoli affilati**

Usa [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) con [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) impostato su [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) per limitare quanto può estendersi un angolo affilato.

Il limite è un rapporto tra la distanza tra gli angoli interno ed esterno della giunzione e la larghezza della linea. Ad esempio, un valore di `8` consente una lunghezza di miter fino a otto volte la larghezza della linea; non è una misura in punti. Se l'angolo supera il limite, PowerPoint utilizza una giunzione smussata in quel punto. Un limite più grande permette punte più affilate. L'impostazione influenza solo le giunzioni miter e non ha effetto visibile quando l'angolo rimane entro entrambi i limiti.

Questo esempio crea due triangoli identici non riempiti con contorni larghi 20 punti. Il triangolo sinistro usa un limite di `2`, quello destro di `8`. Ogni triangolo è largo 80 punti e alto 160 punti, così l'angolo superiore ha un rapporto lunghezza‑miter‑a‑larghezza della linea di circa `4.12`. Di conseguenza, PowerPoint smussa il vertice sinistro e mantiene quello destro.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Il risultato in PowerPoint: **Miter limit 2** a sinistra e **miter limit 8** a destra.

![Un vertice smussato con limite miter 2 e un vertice appuntito con limite miter 8 in PowerPoint](miter-limits.png)

## **Riempimento gradiente**

Un riempimento gradiente sfuma i colori lungo una forma. Questo esempio riempie un'ellisse con un gradiente lineare a 45° dal rosso al viola usando [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Il metodo [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) posiziona le fermate di colore a 0 e 1, all'inizio e alla fine del gradiente. Cancellare le fermate esistenti garantisce che vengano usati solo questi due colori.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Il risultato:

![L'ellisse con riempimento gradiente](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a PowerPoint, consulta [Choose a Gradient Rendering Style](/slides/it/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puoi selezionare uno stile di rendering senza modificare il gradiente memorizzato nella presentazione.

### **Imposta l'angolo del gradiente lineare**

Usa [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) per controllare l'orientamento di un riempimento [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). L'angolo è misurato in gradi e aumenta in senso orario: `0` va da sinistra a destra, `90` dall'alto verso il basso, `180` da destra a sinistra e `270` dal basso verso l'alto. Sono supportati angoli frazionari. Angoli finiti al di fuori di `[0, 360)` sono normalizzati a una rotazione completa; ad esempio, `-45` diventa `315` e `360` diventa `0`.

Questo esempio crea sei rettangoli con fermate rosse, verdi e blu identiche alle posizioni `0`, `0.5` e `1`. La scala è disabilitata così l'angolo può essere confrontato indipendentemente dalle proporzioni dei rettangoli. Gli angoli, da sinistra a destra, sono `0`, `45` e `90` nella prima riga, e `135`, `180` e `270` nella seconda riga.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Il risultato in PowerPoint:

![Gradienti lineari a 0, 45 e 90 gradi nella prima riga, e a 135, 180 e 270 gradi nella seconda riga](linear-gradient-angles.png)

### **Scala un gradiente lineare con la forma**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) accetta un valore [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Impostalo esplicitamente su `False` per mantenere l'angolo geometrico del gradiente quando le proporzioni della forma cambiano, o su `True` per scalare il gradiente con larghezza e altezza della forma. Con la scala attiva, l'angolo visibile può differire dall'angolo assegnato su una forma non quadrata.

L'esempio seguente usa un angolo di `45` gradi e le stesse fermate di colore dell'esempio di confronto degli angoli. La colonna sinistra usa `False`; la colonna destra usa `True`. Ogni colonna contiene un rettangolo largo sopra un rettangolo alto. Entrambi partono dalle stesse dimensioni larghe; la modifica di larghezza e altezza del secondo rettangolo dimostra come il riempimento risponde al ridimensionamento senza cambiare le impostazioni del gradiente.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Il risultato in PowerPoint, con la scala disabilitata a sinistra e abilitata a destra:

![Rettangoli larghi e alti con un gradiente a 45°, confrontando LinearGradientScaled False a sinistra con True a destra](linear-gradient-scaling.png)

Con la scala disabilitata, le bande di colore diagonali mantengono la stessa orientazione in entrambi i rettangoli. Con la scala abilitata, le bande si allungano con le proporzioni della forma. Questo aiuta a riprodurre il gradiente di un modello quando la forma viene adattata a una dimensione diversa. Su un quadrato, abilitare la scala non modifica l'aspetto di questo gradiente a `45` gradi.

Sia l'angolo sia le impostazioni di scala si applicano ai gradienti lineari. Non controllano i riempimenti [GradientShape.Radial o GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Combina l'angolo con la direzione del gradiente**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) seleziona uno stile di gradiente dall'enumerazione [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); non è un sostituto di un angolo numerico. Per un gradiente lineare, gli stili d'angolo possono modificare l'area su cui i colori sono distribuiti senza cambiare [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Mantieni la direzione invariata quando confronti angoli o scale.

L'esempio seguente applica le stesse impostazioni in ordine inverso. I due rettangoli hanno lo stesso aspetto: assegnare la direzione prima o dopo l'angolo non cambia il risultato.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Riempimento pattern**

Un riempimento pattern applica un disegno a due colori, ad esempio punti, strisce o quadrati. Questo esempio usa [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) per selezionare un pattern a reticolo. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) fornisce lo sfondo grigio chiaro, e [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) fornisce il colore giallo del pattern.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il rettangolo con riempimento pattern](pattern-fill.png)

## **Riempimento immagine**

Un riempimento immagine utilizza un'immagine all'interno di una forma. Questo esempio richiede un'immagine locale e utilizza [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) per caricarla nella collezione di immagini della presentazione. Impostando [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) sulla modalità a tasselli l'immagine viene ripetuta all'interno del rettangolo. L'immagine di origine utilizzata qui è mostrata di seguito:

![L'immagine del loto](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Tassella immagine come texture**

Se desideri impostare un'immagine a tasselli come texture e personalizzare il comportamento della tassellatura, puoi usare le seguenti proprietà dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Specifica l'allineamento delle tessere all'interno della forma.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Controlla se la tessera è capovolta orizzontalmente, verticalmente o in entrambe le direzioni.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definisce la scala orizzontale della tessera come percentuale.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definisce la scala verticale della tessera come percentuale.

Questo esempio richiede un'immagine locale e la configura in [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) per ripeterla al 50 % della sua dimensione originale. Gli offset di −32 punti spostano le tessere orizzontalmente e verticalmente; l'allineamento in basso a destra e il capovolgimento in entrambe le direzioni determinano come la texture ripetuta è disposta.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le opzioni di tessellatura](tile-options.png)

## **Riempimento colore solido**

Un riempimento solido conferisce a una forma un unico colore uniforme. Questo esempio imposta [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) sul tipo di riempimento solido e assegna il giallo tramite [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), quindi salva il rettangolo nella presentazione.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Il risultato:

![La forma con riempimento colore solido](solid-color-fill.png)

### **Copia i colori mantenendo i riferimenti al tema**

Usa [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) per copiare una definizione di colore, inclusi tipo di colore, riferimento al tema e trasformazioni. È utile quando si trasferisce il colore di riempimento tra forme che devono continuare a seguire il tema della presentazione. Il metodo copia solo il colore: non copia il tipo di riempimento, il contorno o altre formattazioni della forma. Imposta esplicitamente il [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) della destinazione.

Questo esempio crea tre rettangoli, da sinistra a destra: la sorgente, una copia consapevole del tema e una copia RGB fissa. La sorgente usa [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) per riferirsi al primo colore di accento e aggiunge una tinta tramite [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). La copia RGB usa il colore di riempimento effettivo della sorgente, così tutti e tre appaiono inizialmente identici. Assegnare [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) imposta un valore RGB fisso e cancella eventuali trasformazioni di colore esistenti.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Prima della modifica del tema, tutti e tre i riempimenti corrispondono:

![Sorgente, destinazione CopyFrom e destinazione RGB fissa con riempimenti blu identici](color-copy-before.png)

Dopo la modifica del tema, la sorgente e la copia consapevole del tema seguono il nuovo colore di accento e mantengono la loro tinta. La copia RGB fissa rimane blu:

![Sorgente e destinazione CopyFrom con riempimenti arancioni, mentre la destinazione RGB fissa rimane blu](color-copy-after.png)

La definizione copiata è indipendente dalla sorgente. Modificare successivamente il riferimento al tema della sorgente, assegnare un altro colore o aggiungere o rimuovere le sue trasformazioni non cambia la destinazione. Una modifica del tema influisce comunque su entrambe le forme perché ciascuna riferisce indipendentemente allo stesso colore del tema.

Il salvataggio e la riapertura del PPTX preservano il [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), il riferimento al tema e la raccolta [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) della definizione copiata; non convertono la definizione in RGB.

Quando si copia tra contesti tematici diversi, come presentazioni con palette di accento diverse, il riferimento copiato viene risolto rispetto al tema della destinazione. Lo stesso riferimento e le stesse trasformazioni possono quindi produrre un colore visibile diverso. Consulta [Presentation Theme](/slides/it/net/presentation-theme/) per ulteriori dettagli sulla configurazione dei colori del tema.

## **Usare lo sfondo della diapositiva come riempimento della forma**

Usa [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) quando una forma deve corrispondere allo sfondo della diapositiva, ad esempio in un modello di presentazione. Imposta prima [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) su [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) per rimuovere qualsiasi riempimento esplicito. Con questa combinazione, la forma utilizza lo sfondo della diapositiva anziché il riempimento di stile. L'attivazione del flag da sola non rimuove un riempimento esplicito esistente.

Questo differisce da [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): lo sfondo riempito copre gli oggetti dietro la forma con l'area corrispondente dello sfondo della diapositiva, mentre nessun riempimento lascia visibili quegli oggetti. Un gradiente resta allineato alla diapositiva anziché ricominciare all'interno di ogni forma.

L'esempio seguente crea uno sfondo master ereditato dalla diapositiva e posiziona una banda magenta dietro tre rettangoli. Il rettangolo sinistro usa lo sfondo, il rettangolo centrale non ha riempimento e il rettangolo destro passa dallo sfondo riempito a un riempimento arancione esplicito.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Eredita il gradiente dal master.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Aggiungi questo oggetto per primo così appare dietro i rettangoli.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Disattiva il riempimento di sfondo prima di applicare un riempimento esplicito.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Il risultato, da sinistra a destra: **riempimento di sfondo**, **nessun riempimento** e **riempimento esplicito**. La banda magenta è nascosta dai rettangoli sinistro e destro ma rimane visibile attraverso il rettangolo centrale.

![Riempimento di sfondo, nessun riempimento e riempimento arancione esplicito sopra una banda magenta](background-fill.png)

Lo stesso comportamento si applica a uno sfondo definito direttamente sulla diapositiva o ereditato da un layout. La forma utilizza lo sfondo risolto della diapositiva; l'esempio lascia sia lo sfondo della diapositiva sia quello del layout non definiti così il master fornisce lo sfondo.

## **Impostare la trasparenza**

Per un riempimento solido, il componente alfa del colore controlla l'opacità: 0 è completamente trasparente e 255 è completamente opaco. Questo esempio usa un valore alfa di 128 per un rettangolo giallo, rendendolo circa 50 % trasparente così il rettangolo sottostante rimane visibile. Il colore è assegnato tramite [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Usa [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) per ruotare una forma nel piano della diapositiva. L'angolo è misurato in gradi; questo esempio ruota un rettangolo di 5 gradi in senso orario e salva la presentazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Usa [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) per dare profondità a una forma e bordi smussati. Questo esempio crea un'ellisse verde con contorno arancione, imposta [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) a 4 punti e applica uno smusso superiore circolare con larghezza e altezza di 6 punti tramite [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Una telecamera ortografica frontale e un'illuminazione a tre punti rendono visibile lo smusso.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Il risultato:

![L'effetto di smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

La vista 3D di una forma è controllata dalle impostazioni della telecamera. Questo esempio usa [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) con angoli di latitudine, longitudine e rivoluzione di 40, 35 e 20 gradi, rispettivamente. Seleziona una telecamera isometrica tramite [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) e un'illuminazione bilanciata tramite [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), quindi salva il rettangolo formattato.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare la resa in bianco e nero per le forme**

La proprietà [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) specifica come una singola forma viene resa quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero da sola e non cambia il riempimento, il contorno o altre formattazioni della forma in modalità colore normale.

Usa un valore dell'enumerazione [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` lascia all'applicazione di rendering scegliere la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` usa solo nero e bianco, `Black` e `White` forzano un colore unico, `Color` conserva la colorazione normale, e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` significa che non è stato assegnato alcun livello di forma.

Questo esempio crea un rettangolo arancione e imposta [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) su grigio. La forma salvata mantiene il riempimento arancione per la visualizzazione a colori normali e richiede la colorazione grigia dalle applicazioni che rispettano le impostazioni di visualizzazione in bianco e nero:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, utilizza la colorazione grigia perché il suo modo è impostato su `Gray`. Questo consente di preservare una diapositiva a colori completi definendo al contempo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione in bianco e nero della presentazione.

## **Ripristinare la formattazione**

Usa [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) per ripristinare posizione, dimensione e formattazione dei segnaposto della diapositiva dai corrispondenti segnaposto del layout. Questo esempio richiede una presentazione esistente con segnaposto collegati al layout e ripristina ogni diapositiva prima del salvataggio. Le forme senza segnaposto corrispondente nel layout non vengono ripristinate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

I colori, gli stili di linea e le impostazioni degli effetti aggiungono generalmente pochi dati rispetto a immagini e media incorporati. I riempimenti immagine possono aumentare la dimensione del file perché le loro immagini sono memorizzate nella presentazione.

**Come posso individuare forme su una diapositiva che condividono la stessa formattazione per raggrupparle?**

Confronta le proprietà chiave di formattazione di ciascuna forma — riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondono, tratta i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarli in altre presentazioni?**

Sì. Memorizza forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme con lo stile necessario e riapplica la loro formattazione dove richiesto.