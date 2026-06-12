---
title: Ottenere le proprietà effettive delle forme dalle presentazioni in .NET
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/net/shape-effective-properties/
keywords:
- proprietà forma
- proprietà della fotocamera
- impostazione luci
- forma a smusso
- riquadro di testo
- stile di testo
- altezza carattere
- formato riempimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET calcola e applica le proprietà effettive delle forme per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra **locali** e **effettive**. I valori locali sono valori impostati direttamente a un livello di formattazione specifico, come:

1. Proprietà delle porzioni su una diapositiva.  
1. Stili di testo della forma prototipo su un layout o su una diapositiva master, quando la forma del riquadro di testo della porzione ne possiede uno.  
1. Impostazioni globali del testo in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides ha bisogno della formattazione finale "come resa", risolve la catena di ereditarietà e restituisce i valori **effettivi**. È possibile ottenerli chiamando il metodo `GetEffective` sull'oggetto di formato locale.

L'esempio seguente mostra come ottenere i valori effettivi. Si presume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) con un riquadro di testo e almeno una porzione.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
I dati di formattazione effettiva rappresentano la formattazione calcolata attuale dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformateffectivedata/), possono essere memorizzati nella cache internamente. Richiamare `GetEffective` nuovamente dopo aver modificato la formattazione padre o ereditata può aggiornare i dati nella cache, e un oggetto ottenuto in precedenza potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un riutilizzo futuro, copiate le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottenere le proprietà effettive di una Camera**

Aspose.Slides consente di ottenere le proprietà effettive di una camera. L'interfaccia [ICameraEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/icameraeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive della camera. Un'istanza di [ICameraEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/icameraeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/).

L'esempio di codice seguente mostra come ottenere le proprietà effettive per la camera. Si presume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Ottenere le proprietà effettive di un Light Rig**

Aspose.Slides consente di ottenere le proprietà effettive di un Light Rig. L'interfaccia [ILightRigEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilightrigeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive del Light Rig. Un'istanza di [ILightRigEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilightrigeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/).

L'esempio di codice seguente mostra come ottenere le proprietà effettive per il Light Rig. Si presume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Ottenere le proprietà effettive di una Bevel Shape**

Aspose.Slides consente di ottenere le proprietà effettive di un Bevel di una forma. L'interfaccia [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ishapebeveleffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà di rilievo delle facce per una forma. Un'istanza di [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ishapebeveleffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/).

L'esempio di codice seguente mostra come ottenere le proprietà effettive per lo smusso superiore di una forma. Si presume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```csharp
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

Con Aspose.Slides, è possibile ottenere le proprietà effettive di un riquadro di testo. L'interfaccia [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformateffectivedata/) contiene le proprietà di formattazione effettiva del riquadro di testo.

L'esempio di codice seguente mostra come ottenere le proprietà di formattazione effettiva del riquadro di testo. Si presume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) con un riquadro di testo.

```csharp
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

Con Aspose.Slides, è possibile ottenere le proprietà effettive di uno stile di testo. L'interfaccia [ITextStyleEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/itextstyleeffectivedata/) contiene le proprietà effettive dello stile di testo.

L'esempio di codice seguente mostra come ottenere le proprietà effettive dello stile di testo. Si presume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) con un riquadro di testo.

```csharp
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

## **Ottenere il valore effettivo dell'altezza del carattere**

Con Aspose.Slides, è possibile ottenere l'altezza effettiva del carattere. Il codice seguente dimostra come l'altezza effettiva del carattere di una porzione cambi dopo che i valori locali dell'altezza del carattere sono stati impostati a diversi livelli della struttura della presentazione.

```csharp
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

## **Ottenere il formato di riempimento effettivo per una tabella**

Con Aspose.Slides, è possibile ottenere la formattazione di riempimento effettiva per diverse parti di una tabella. L'interfaccia [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/) contiene le proprietà di formattazione di riempimento effettive. La formattazione delle celle ha priorità più alta rispetto alla formattazione delle righe, la formattazione delle righe ha priorità più alta rispetto a quella delle colonne e la formattazione delle colonne ha priorità più alta rispetto a quella dell'intera tabella.

Di conseguenza, le proprietà di [ICellFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/icellformateffectivedata/) sono utilizzate per disegnare la cella della tabella. L'esempio di codice seguente mostra come ottenere la formattazione di riempimento effettiva per diverse parti della tabella. Si presume che la prima forma nella prima diapositiva sia un [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/).

```csharp
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

**`GetEffective` restituisce un'istantanea?**

Non sempre. I dati effettivi rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati effettivi possono essere memorizzati nella cache internamente. Una chiamata successiva a `GetEffective` può ricalcolare la formattazione e aggiornare i dati nella cache, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato un'istantanea duratura.

**Quando devo leggere nuovamente le proprietà effettive?**

Eseguire di nuovo `GetEffective` dopo aver modificato la formattazione locale, gli stili padre, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva ricalcola la gerarchia di formattazione e restituisce il risultato effettivo corrente.

**La modifica o la rimozione di una diapositiva layout/master influisce sulle proprietà effettive già recuperate?**

Sì, ma la modifica viene riflessa nella prossima chiamata a `GetEffective`. Se una fonte di formattazione padre viene modificata o rimossa, i dati effettivi ottenuti in precedenza possono essere obsoleti. Quando `GetEffective` viene richiamato nuovamente, Aspose.Slides ricalcola l'albero di formattazione e i caratteri, i colori, le dimensioni o altri valori risultanti possono cambiare.

**Posso modificare i valori tramite gli oggetti di dati effettivi?**

No. Gli oggetti di dati effettivi espongono i valori calcolati. Apportare le modifiche negli oggetti di formattazione locale, quindi ottenere nuovamente i valori effettivi.

**Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?**

Il valore effettivo è determinato dal meccanismo predefinito, che comprende le impostazioni predefinite di PowerPoint e Aspose.Slides. Quel valore risolto diventa parte dei dati effettivi correnti.

**Dal valore effettivo del carattere, posso capire a quale livello è stato fornito la dimensione o il tipo di carattere?**

Non direttamente. I dati effettivi restituiscono il valore finale. Per trovare la fonte, controllare i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

**Perché i valori effettivi a volte coincidono con quelli locali?**

Perché il valore locale è risultato finale (non è stata necessaria alcuna ereditarietà a livelli superiori). In tali casi, il valore effettivo coincide con quello locale.

**Quando devo utilizzare le proprietà effettive e quando devo lavorare solo con quelle locali?**

Utilizzare i dati effettivi quando è necessario il risultato "come renderizzato" dopo l'applicazione di tutta l'ereditarietà, ad esempio per allineare colori, rientri o dimensioni. Se è necessario conservare tali valori indipendentemente da eventuali modifiche successive della formattazione, copiare le proprietà richieste in un proprio oggetto. Se è necessario modificare la formattazione a un livello specifico, modificare le proprietà locali e poi, se opportuno, leggere nuovamente i dati effettivi per verificare il risultato.