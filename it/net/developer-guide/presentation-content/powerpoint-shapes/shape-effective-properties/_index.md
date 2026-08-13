---
title: Ottieni le proprietà efficaci delle forme dalle presentazioni in .NET
linktitle: Proprietà efficaci
type: docs
weight: 50
url: /it/net/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della telecamera
- impianto di luci
- forma smussata
- riquadro di testo
- stile di testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET calcola e applica le proprietà efficaci delle forme per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra proprietà **locali** ed **effettive**. I valori locali sono valori impostati direttamente a un determinato livello di formattazione, ad esempio:

1. Proprietà della porzione su una diapositiva.
1. Stili di testo della forma prototipo su un layout o una diapositiva master, quando la forma del riquadro di testo della porzione ne possiede uno.
1. Impostazioni di testo globali in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides necessita della formattazione finale “come renderizzata”, risolve la catena di ereditarietà e restituisce i valori **effettivi**. È possibile ottenerli chiamando il metodo `GetEffective` sull'oggetto di formattazione locale.

L'esempio seguente mostra come ottenere i valori effettivi. Si presume che la prima forma sulla prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) con un riquadro di testo e almeno una porzione.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}

I dati di formattazione effettiva rappresentano la formattazione calcolata corrente dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformateffectivedata/), possono essere memorizzati nella cache internamente. Richiamare nuovamente `GetEffective` dopo aver modificato la formattazione padre o ereditata può aggiornare i dati nella cache, e un oggetto precedentemente ottenuto potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un uso successivo, copiare le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.

{{% /alert %}}

## **Ottenere le proprietà effettive di una telecamera**

Aspose.Slides consente di ottenere le proprietà effettive di una telecamera. L'interfaccia [ICameraEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/icameraeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà della telecamera effettive. Un'istanza di [ICameraEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/icameraeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/), che fornisce i valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per la telecamera. Si presume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Ottenere le proprietà effettive di un impianto di luci**

Aspose.Slides consente di ottenere le proprietà effettive di un impianto di luci. L'interfaccia [ILightRigEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilightrigeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà dell'impianto di luci effettive. Un'istanza di [ILightRigEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilightrigeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/), che fornisce i valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per l'impianto di luci. Si presume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Ottenere le proprietà effettive di un contorno di forma**

Aspose.Slides consente di ottenere le proprietà effettive di un contorno di forma. L'interfaccia [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ishapebeveleffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà di rilievo facciale effettive per una forma. Un'istanza di [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ishapebeveleffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/), che fornisce i valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per il contorno superiore di una forma. Si presume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Ottenere le proprietà effettive di un riquadro di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di un riquadro di testo. L'interfaccia [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformateffectivedata/) contiene le proprietà di formattazione effettiva del riquadro di testo.

Il seguente esempio di codice mostra come ottenere le proprietà di formattazione effettiva del riquadro di testo. Si presume che la prima forma sulla prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) con un riquadro di testo.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Ottenere le proprietà effettive di uno stile di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di uno stile di testo. L'interfaccia [ITextStyleEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/itextstyleeffectivedata/) contiene le proprietà di stile di testo effettive.

Il seguente esempio di codice mostra come ottenere le proprietà di stile di testo effettive. Si presume che la prima forma sulla prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) con un riquadro di testo.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Ottenere il valore efficace dell'altezza del carattere**

Utilizzando Aspose.Slides, è possibile ottenere l'altezza del carattere efficace. Il codice seguente dimostra come l'altezza del carattere efficace di una porzione cambi dopo aver impostato valori di altezza del carattere locali a diversi livelli della struttura della presentazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Ottenere il formato di riempimento efficace per una tabella**

Utilizzando Aspose.Slides, è possibile ottenere la formattazione di riempimento efficace per diverse parti di una tabella. L'interfaccia [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/) contiene le proprietà di formattazione di riempimento efficaci. La formattazione delle celle ha priorità più alta rispetto a quella delle righe, la formattazione delle righe ha priorità più alta rispetto a quella delle colonne e la formattazione delle colonne ha priorità più alta rispetto alla formattazione dell'intera tabella.

Di conseguenza, le proprietà di [ICellFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/icellformateffectivedata/) vengono utilizzate per disegnare la cella della tabella. Il seguente esempio di codice mostra come ottenere la formattazione di riempimento efficace per diverse parti della tabella. Si presume che la prima forma sulla prima diapositiva sia un [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### `GetEffective` restituisce uno snapshot?

Non sempre. I dati efficaci rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati efficaci possono essere memorizzati nella cache internamente. Una chiamata successiva a `GetEffective` può ricalcolare la formattazione e aggiornare i dati nella cache, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato uno snapshot durevole.

### Quando devo leggere nuovamente le proprietà efficaci?

Richiama `GetEffective` di nuovo dopo aver modificato la formattazione locale, gli stili padre, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva rivaluta la gerarchia di formattazione e restituisce il risultato efficace corrente.

### La modifica o la rimozione di una diapositiva layout/master influisce sulle proprietà efficaci già recuperate?

Sì, ma la modifica viene riflessa nella prossima chiamata a `GetEffective`. Se una fonte di formattazione padre viene modificata o rimossa, i dati efficaci ottenuti in precedenza potrebbero essere obsoleti. Una volta richiamato nuovamente `GetEffective`, Aspose.Slides rivaluta l'albero di formattazione e i caratteri, i colori, le dimensioni o gli altri valori risultanti possono cambiare.

### Posso modificare i valori tramite oggetti di dati efficaci?

No. Gli oggetti di dati efficaci espongono valori calcolati. Apporta le modifiche negli oggetti di formattazione locali, quindi ottieni nuovamente i valori efficaci.

### Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?

Il valore efficace è determinato dal meccanismo predefinito, che include i valori predefiniti di PowerPoint e Aspose.Slides. Quel valore risolto diventa parte dei dati efficaci correnti.

### Dal valore efficace del carattere, posso sapere a quale livello è stata fornita la dimensione o la famiglia tipografica?

Non direttamente. I dati efficaci restituiscono il valore finale. Per trovare la fonte, controlla i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

### Perché i valori efficaci a volte sembrano identici a quelli locali?

Perché il valore locale è risultato finale (non è stato necessario alcun livello di ereditarietà superiore). In tali casi, il valore efficace corrisponde a quello locale.

### Quando devo usare le proprietà efficaci e quando devo lavorare solo con quelle locali?

Usa i dati efficaci quando ti serve il risultato “come renderizzato” dopo l'applicazione di tutta l'ereditarietà, ad esempio per allineare colori, rientri o dimensioni. Se devi conservare tali valori indipendentemente da futuri cambiamenti di formattazione, copia le proprietà richieste nel tuo oggetto. Se devi modificare la formattazione a un livello specifico, modifica le proprietà locali e poi, se necessario, leggi nuovamente i dati efficaci per verificare il risultato.