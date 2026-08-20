---
title: Gestire le forme della presentazione in .NET
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/net/shape-manipulations/
keywords:
- Forma PowerPoint
- forma della presentazione
- forma sulla diapositiva
- trova forma
- clona forma
- rimuovi forma
- nascondi forma
- cambia ordine forma
- ottieni ID forma interop
- testo alternativo forma
- formati layout forma
- forma come SVG
- forma in SVG
- allinea forma
- capovolgi forma
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e capovolgere le forme di presentazione con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/) ordinata. La collezione è sia il luogo in cui trovi e modifichi le forme sia la fonte del loro ordine di impilamento: l'indice `0` è la forma più arretrata, mentre l'ultimo indice è la forma più avanzata.

Questo articolo segue quel modello. Prima spiega come identificare una forma in modo affidabile, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l'esportazione SVG, l'allineamento e le impostazioni di capovolgimento. Ogni esempio è indipendente, quindi puoi usare solo le operazioni necessarie al tuo flusso di lavoro.

## **Identificare e trovare le forme**

Gli indici della collezione sono comodi durante l'elaborazione di un file noto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiarne l'indice. Scegli un identificatore in base a come la presentazione è stata creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/name/) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/alternativetext/) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l'accessibilità e non è garantito univoco. Non riutilizzare silenziosamente testi di accessibilità significativi come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/officeinteropshapeid/) è un identificatore di sola lettura univoco all'interno di una diapositiva e corrisponde all'ID forma utilizzato da PowerPoint interop. Usalo quando integri con PowerPoint o quando ti serve un riferimento senza ambiguità durante la vita di una forma. Una forma clonata o ricreata è una forma diversa e riceve il proprio ID.

La proprietà correlata [UniqueId](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/uniqueid/) ha ambito di presentazione, ma è destinata a componenti aggiuntivi e può essere riassegnata. Non deve essere trattata come una chiave esterna permanente. Se l'identità a lungo termine è essenziale, conserva la mappatura nei dati dell'applicazione e verifica che la forma prevista esista ancora.

L'esempio seguente ricerca per `Name` con un confronto ordinale e restituisce l'ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato invece di continuare con l'oggetto errato.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Quando un'operazione è specifica per un tipo di forma, controlla l'interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l'oggetto nominato è un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Modificare la collezione di forme**

I metodi di aggiunta, clonazione, rimozione e riordino operano sulla collezione immediatamente. Se un'operazione modifica il numero o l'ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell'operazione.

### **Clonare una forma**

[AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/insertclone/) crea anch'essa una copia ma la posiziona a un indice di ordine Z specificato. Le sovraccariche che accettano coordinate spostano il clone senza cambiare le sue dimensioni; quelle con larghezza e altezza possono ridimensionarlo.

L'esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone in fondo. Le modifiche a ciascun clone non modificano la forma originale.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

La clonazione copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando tali valori devono essere univoci. Le risorse usate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere forme**

[Remove](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando rimuovi più corrispondenze durante un'iterazione indicizzata, percorri la collezione dal fondo così ogni indice rimanente rimane valido.

Questo esempio rimuove ogni forma con un nome designato. Legge `slide.Shapes[i]`, non un elemento della collezione fisso, e non effettua cast non necessari sulla forma.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero fare riferimento all'oggetto rimosso; rimuovere una forma visibile può modificare più del semplice aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/hidden/) su `true` mantiene la forma nella collezione ma ne impedisce la comparsa nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili al codice, quindi nascondere è appropriato per elementi opzionali che potrebbero essere ripristinati in seguito.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Nascondere non è eliminazione né sicurezza. L'oggetto può ancora essere scoperto e reso visibile da un utente o dal codice, e resta parte del file di presentazione.

### **Modificare l'ordine Z**

Le forme sovrapposte vengono dipinte nell'ordine della collezione. [Reorder](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L'indice `0` è il retro; `Count - 1` è il fronte.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Il rettangolo è creato per primo e inizialmente si trova dietro l'ellisse. Spostarlo all'indice finale lo pone davanti. Finalizza l'ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare le forme nelle diapositive layout**

Le diapositive normali, le diapositive layout e le diapositive master hanno collezioni di forme separate. Una forma nella collezione layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme del layout quando devi comprendere o modificare la formattazione fornita da un layout.

L'esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/fillformat/) e il [LineFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/lineformat/) di ciascuna forma del layout senza supporre che ogni forma sia un `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma del layout, determina se una diapositiva normale eredita l'oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che usa quel layout.

## **Esportare una forma in SVG**

[WriteAsSvg](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/writeassvg/) scrive il contenuto renderizzato di una singola forma in uno stream. Il risultato contiene la forma, non lo sfondo dell'intera diapositiva né le forme vicine.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Mantieni la presentazione aperta durante il rendering. L'output dipende dalla formattazione della forma e da risorse come font e immagini. Se ti serve l'intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve disponerlo.

## **Allineare le forme**

Le sovraccariche di [SlideUtil.AlignShapes](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/alignshapes/) allineano sia tutte le forme sia gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/net/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti sono convertiti nei loro indici correnti immediatamente prima dell'allineamento.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

L'allineamento modifica le posizioni, non l'ordine Z. L'allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Capovolgere una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/net/aspose.slides/shapeframe/) memorizza posizione, dimensioni, impostazioni di capovolgimento orizzontale e verticale e rotazione. I valori `FlipH` e `FlipV` utilizzano [NullableBool](https://reference.aspose.com/slides/it/net/aspose.slides/nullablebool/): `True` abilita il capovolgimento, `False` lo disabilita e `NotDefined` preserva lo stato non specificato/predefinito.

La presentazione di input qui sotto contiene una forma non capovolta.

![La forma prima del capovolgimento](shape_to_be_flipped.png)

L'esempio conserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di capovolgimento. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/frame/) sostituisce l'intero frame.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

La forma salvata è riflessa orizzontalmente e verticalmente mantenendo posizione, dimensioni e rotazione.

![La forma dopo il capovolgimento](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione con `Name` o `AlternativeText` per modelli creati, o `OfficeInteropShapeId` per lavoro interop a livello di diapositiva.

**Nascondere una forma la rimuove dall'ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un'altra forma?**

`AddClone` aggiunge il clone alla fine della collezione, che corrisponde al fronte dell'ordine Z. Usa `InsertClone` per scegliere l'indice iniziale o `Reorder` dopo aver aggiunto tutte le forme.