---
title: Gestire le forme della presentazione in .NET
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine della forma
- Ottieni ID forma interop
- Testo alternativo della forma
- Punto di regolazione della forma
- Regolazione forma predefinita
- Geometria della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come identificare, regolare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme di presentazione con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides for .NET rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/) ordinata. La collezione è sia il luogo in cui si trovano e modificano le forme sia la sorgente del loro ordine di impilamento: l’indice `0` è la forma più posteriore, mentre l’ultimo indice è la forma più anteriore.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma e modificare i punti di regolazione predefiniti, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali trattano la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così è possibile utilizzare solo le operazioni richieste dal proprio flusso di lavoro.

## **Identificare e trovare forme**

Gli indici della collezione sono comodi durante l’elaborazione di un file noto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiare il suo indice. Scegli un identificatore in base a come la presentazione è creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/name/) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi definisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/alternativetext/) è utile quando una descrizione di accessibilità o un’etichetta fornita dall’autore identifica già la forma. È visibile agli utenti, può essere localizzata o riscritta per l’accessibilità e non è garantita l’unicità. Non riutilizzare silenziosamente del testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/officeinteropshapeid/) è un identificatore di sola lettura, univoco all’interno di una diapositiva e corrispondente all’ID forma usato dall’interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento inequivocabile durante la vita di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

La proprietà correlata [UniqueId](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/uniqueid/) ha ambito di presentazione, ma è destinata a componenti aggiuntivi e può essere riassegnata. Non deve essere trattata come una chiave esterna permanente. Se è essenziale un’identità a lungo termine, conserva la mappatura nei dati dell’applicazione e verifica che la forma prevista esista ancora.

L’esempio seguente ricerca per `Name` con un confronto ordinal e restituisce l’interoperabilità a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato anziché continuare con l’oggetto errato.

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

Quando un’operazione è specifica per un tipo di forma, controlla l’interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto nominato è un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).

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

## **Identificare e modificare le regolazioni predefinite delle forme**

Le forme con geometria predefinita possono esporre punti di aggiustamento che controllano caratteristiche come la dimensione dell’angolo, le proporzioni della freccia o gli angoli di arco. Accedili attraverso la collezione di sola lettura [IGeometryShape.Adjustments](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/adjustments/). La collezione stessa è fornita dalla forma, ma ogni [IAdjustValue](https://reference.aspose.com/slides/it/net/aspose.slides/iadjustvalue/) contiene un valore modificabile.

Non fare affidamento solo su un indice fisso della collezione. Itera le regolazioni e ispeziona la proprietà di sola lettura [Type](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/type/), il cui valore [ShapeAdjustmentType](https://reference.aspose.com/slides/it/net/aspose.slides/shapeadjustmenttype/) descrive ciò che la regolazione controlla. La proprietà di sola lettura [Name](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/name/) fornisce ulteriori informazioni di identificazione ed è particolarmente utile quando un preset contiene più di una regolazione con lo stesso tipo semantico.

Usa la proprietà valore che corrisponde al significato della regolazione:

| Tipo di aggiustamento | Scopo | Valore da modificare |
|---|---|---|
| `CornerSize` | Dimensione degli angoli arrotondati | [RawValue](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Spessore della coda della freccia | `RawValue` |
| `ArrowheadLength` | Lunghezza della punta della freccia | `RawValue` |
| `ArrowheadWidth` | Larghezza della punta della freccia | `RawValue` |
| `StartAngle` | Angolo iniziale di una torta o di un arco | [AngleValue](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Angolo finale di una torta o di un arco | `AngleValue` |

`Type` e `Name` non possono essere assegnati. `RawValue` è un intero di lettura/scrittura nelle unità native della geometria del preset, mentre `AngleValue` è un angolo di lettura/scrittura in gradi. Il numero, l’ordine, il significato e l’intervallo valido delle regolazioni dipendono dal preset [ShapeType](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/shapetype/). Un valore valido per un preset può essere non valido o avere un effetto diverso per un altro.

Quando `Type` è `ShapeAdjustmentType.Custom`, l’API non riconosce un significato semantico standard. Ispeziona `Name`, il tipo di preset e il valore esistente, e lascia la regolazione invariata a meno che il significato e l’intervallo attesi non siano noti. Anche per i tipi riconosciuti, verifica se lo stesso tipo compare più volte prima di selezionare un valore. L’articolo [Connector](/slides/it/net/connector/) mostra questa situazione con le regolazioni di piegatura dei connettori.

L’esempio completo seguente crea versioni predefinite e modificate di tre forme preimpostate. Itera ogni regolazione, segnala il suo `Name` e `Type`, cambia i valori legati alle dimensioni tramite `RawValue`, cambia gli angoli tramite `AngleValue` e salva il risultato. La colonna sinistra mantiene la geometria predefinita; la colonna destra mostra il rettangolo arrotondato, la freccia a quattro vie e la torta regolati.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Aggiunge intestazioni per le colonne di forme predefinite e modificate.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Verificare il tipo semantico prima di modificare un valore rende il codice esplicito sul suo intento ed evita di presumere che un determinato indice della collezione abbia lo stesso significato tra forme predefinite diverse.

## **Modificare la collezione di forme**

I metodi di aggiunta, clonazione, rimozione e riordinamento operano sulla collezione immediatamente. Se un’operazione modifica il numero o l’ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell’operazione.

### **Clonare una forma**

[AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/insertclone/) crea anch’essa una copia ma la inserisce a un indice di ordine Z specificato. Le overload che accettano coordinate spostano il clone senza cambiarne le dimensioni; le overload con larghezza e altezza possono ridimensionarlo.

L’esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sullo sfondo. Le modifiche a uno dei clone non modificano la forma sorgente.

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

La clonazione copia contenuto e formattazione della forma, incluso nome e testo alternativo. Assegna nuovi identificatori logici al clone quando questi valori devono essere univoci. Le risorse usate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere forme**

[Remove](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando rimuovi più corrispondenze durante un’iterazione indicizzata, attraversa la collezione dal fondo in modo che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge `slide.Shapes[i]`, non un elemento fisso della collezione, e non esegue cast inutili della forma.

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

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto a indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero fare riferimento all’oggetto rimosso; la rimozione di una forma visibile può alterare più del semplice aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/hidden/) a `true` mantiene la forma nella collezione ma ne impedisce la comparsa nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili per il codice, quindi nascondere è appropriato per elementi opzionali che potrebbero essere ripristinati più tardi.

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

Nascondere non è cancellazione né sicurezza. L’oggetto può ancora essere scoperto e reso visibile da un utente o dal codice, e rimane parte del file della presentazione.

### **Modificare l’ordine Z**

Le forme sovrapposte vengono dipinte nell’ordine della collezione. [Reorder](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L’indice `0` è il retro; `Count - 1` è il fronte.

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

Il rettangolo è creato per primo e inizialmente si trova dietro l’ellisse. Spostarlo all’indice finale lo porta in primo piano. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, poiché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare forme su diapositive layout**

Diapositive normali, layout e master hanno collezioni di forme separate. Una forma nella collezione di layout non è lo stesso oggetto di una forma posizionata similmente su una diapositiva normale. Ispeziona le forme del layout quando devi capire o cambiare la formattazione fornita da un layout.

L’esempio seguente legge per ogni forma del layout il suo [FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/fillformat/) e il suo [LineFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/lineformat/) senza presumere che ogni forma sia un `AutoShape`.

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

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di modificare una forma del layout, verifica se una diapositiva normale eredita l’oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che usa quel layout.

## **Esportare una forma in SVG**

[WriteAsSvg](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/writeassvg/) scrive il contenuto renderizzato di una singola forma su uno stream. Il risultato contiene solo la forma, non lo sfondo dell’intera diapositiva né le forme vicine.

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

Mantieni la presentazione aperta durante il rendering. L’output dipende dalla formattazione della forma e da risorse come caratteri e immagini. Se ti serve l’intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve rilasciarlo.

## **Allineare forme**

Le overload di [SlideUtil.AlignShapes](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/alignshapes/) allineano tutte le forme o indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/net/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` a `true` per usare i bordi della diapositiva; impostalo a `false` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti sono convertiti nei loro indici correnti immediatamente prima dell’allineamento.

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

L’allineamento modifica le posizioni, non l’ordine Z. L’allineamento relativo solitamente richiede almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/net/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `FlipH` e `FlipV` usano [NullableBool](https://reference.aspose.com/slides/it/net/aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita e `NotDefined` preserva lo stato non specificato/predefinito.

La presentazione di input sotto contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L’esempio conserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/frame/) sostituisce l’intero frame.

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

La forma salvata è riflessa orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell’utilizzo dell’indice. Preferisci una convenzione validata di `Name` o `AlternativeText` per modelli creati, oppure `OfficeInteropShapeId` per lavori di interoperabilità a livello di diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un’altra forma?**

`AddClone` aggiunge il clone alla fine della collezione, che corrisponde al fronte dell’ordine Z. Usa `InsertClone` per scegliere l’indice iniziale o `Reorder` dopo aver aggiunto tutte le forme.

**Posso usare un indice fisso per identificare una regolazione di forma predefinita?**

Solo dopo aver validato il preset esatto e la disposizione della collezione. Preferisci iterare su `IGeometryShape.Adjustments` e controllare `IAdjustValue.Type`; usa `IAdjustValue.Name` come informazione aggiuntiva quando lo stesso tipo semantico compare più volte.