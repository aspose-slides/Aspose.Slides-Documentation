---
title: Ottieni le proprietà effettive della forma dalle presentazioni in .NET
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/net/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- illuminazione
- forma smussata
- frame di testo
- stile del testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per .NET per distinguere la formattazione locale, ereditata ed effettiva delle forme in presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate ed effettive**

La formattazione di PowerPoint può provenire da diversi luoghi. Il valore memorizzato direttamente su un oggetto è il suo **valore locale**. Se tale valore non è impostato, PowerPoint cerca le fonti di formattazione genitore, come il valore predefinito del paragrafo, uno stile di testo, un layout o una diapositiva master, un tema o i valori predefiniti a livello di presentazione. Quei valori sono **valori ereditati**. Il valore che rimane dopo che l'intera gerarchia è stata risolta è il **valore effettivo** — il valore usato per renderizzare l'oggetto.

Ad esempio, una porzione di testo potrebbe non definire la propria altezza del carattere. Il suo valore locale [FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/fontheight/) è allora `float.NaN`, che significa "non impostato qui". La porzione può ereditare un'altezza dal suo paragrafo, dallo stile di testo predefinito della presentazione o da un'altra fonte applicabile. Chiamare [GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/geteffective/) sul formato della porzione restituisce l'altezza finale risolta.

Usa i due tipi di dati di formattazione per scopi diversi:

- Leggi o modifica un oggetto di formato locale, come [IPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/), quando è necessario controllare dove è definito un valore.
- Leggi un oggetto di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformateffectivedata/), quando è necessario il risultato finale renderizzato. I dati effettivi sono di sola lettura.

## **Confronta valori locali, ereditati ed effettivi**

Il seguente esempio completo crea una forma e applica altezze del carattere a livello di presentazione, paragrafo e porzione. Ogni passo stampa i valori definiti a quei livelli e il valore effettivo risultante per la stessa porzione di testo. Dimostra inoltre perché i dati effettivi devono essere letti nuovamente dopo le modifiche di formattazione.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Definisci valori ereditati a due livelli diversi.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Modificare un valore ereditato non sovrascrive un valore locale esistente.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Cancella il valore locale. La porzione ora eredita di nuovo dal paragrafo.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Cancella il valore del paragrafo. Il valore predefinito della presentazione fornisce ora il risultato.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Leggi i dati effettivi dopo le modifiche precedenti.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

La priorità in questo esempio è la formattazione locale della porzione, poi quella del paragrafo, poi il valore predefinito della presentazione. Altri oggetti possono avere catene di ereditarietà diverse, ma il principio è lo stesso: un valore esplicito più specifico vince, e [GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/geteffective/) restituisce il risultato finale.

## **Ottieni le proprietà di testo effettive**

La formattazione del testo è suddivisa in diversi oggetti:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/geteffective/) risolve le proprietà del frame di testo come margini, ancoraggio, adattamento automatico e direzione verticale del testo.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/it/net/aspose.slides/itextstyle/geteffective/) risolve la formattazione del paragrafo per ogni livello di stile di testo.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/geteffective/) risolve le proprietà del paragrafo come allineamento, rientro e elenchi puntati.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/geteffective/) risolve le proprietà dei caratteri come altezza del carattere, tipo di carattere, colore, grassetto e corsivo.

Per l'esempio successivo, `text-formatting.pptx` deve contenere almeno una diapositiva e una [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) con un frame di testo non vuoto. L'AutoShape può trovarsi in qualsiasi posizione nella collezione di forme; il codice cerca un oggetto idoneo e lo convalida prima dell'uso.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Ottieni le proprietà 3D effettive**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/geteffective/) restituisce un oggetto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/) che raggruppa tutte le impostazioni 3D risolte. Le sue proprietà [Camera](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/beveltop/) e [BevelBottom](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) espongono i dati effettivi corrispondenti. Leggere queste impostazioni correlate insieme facilita la comprensione dell'aspetto 3D finale di una forma.

Per questo esempio, `shape-3d.pptx` deve contenere almeno una forma nella sua prima diapositiva. Applica impostazioni di telecamera 3D, illuminazione o smussatura a quella forma se desideri che l'output contenga valori diversi da quelli predefiniti.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Ottieni la formattazione della tabella effettiva**

La formattazione della tabella può provenire dallo stile della tabella e dai formati applicati all'intera tabella, a una colonna, a una riga o a una singola cella. Per i conflitti tra riempimenti definiti esplicitamente, la priorità è cella, riga, colonna e poi intera tabella. Il formato effettivo di una cella è il formato finale usato per disegnarla.

Per questo esempio, `table-formatting.pptx` deve contenere almeno una tabella nella sua prima diapositiva. La tabella deve avere almeno una riga e una colonna. Il codice cerca un [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) anziché presumere che `Shapes[0]` sia una tabella.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Se hai bisogno del colore anziché solo del tipo di riempimento, controlla prima il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/filltype/) effettivo, quindi leggi la proprietà che si applica a quel tipo — ad esempio, [SolidFillColor](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) per un riempimento solido.

## **Rileggi i dati effettivi dopo le modifiche**

I dati effettivi descrivono la gerarchia di formattazione al momento in cui viene risolta. Chiama nuovamente `GetEffective` dopo aver modificato qualsiasi elemento che possa partecipare a tale gerarchia, includendo:

- la formattazione locale dell'oggetto;
- i valori predefiniti del paragrafo o del frame di testo;
- uno stile di tabella, la tabella, la colonna, la riga o il formato della cella;
- la formattazione del layout o della diapositiva master;
- i dati del tema o i valori predefiniti a livello di presentazione;
- il layout o il master assegnato a una diapositiva.

Non conservare un oggetto di dati effettivi come un'istantanea permanente. Aspose.Slides può memorizzare nella cache alcuni dati effettivi internamente, e una successiva chiamata a `GetEffective` può aggiornare tali dati. Se hai bisogno di confrontare i valori prima e dopo una modifica, copia i valori scalari di cui hai bisogno — come altezza del carattere, colore, allineamento o larghezza dello smusso — nelle tue variabili prima di effettuare la modifica.

Per modificare un valore, aggiorna l'oggetto di formato locale appropriato e poi chiama `GetEffective` per verificare il risultato. Gli oggetti di dati effettivi stessi sono di sola lettura.

## **FAQ**

**Come posso capire quale livello ha fornito un valore effettivo?**

I dati effettivi contengono il valore finale, non la sua origine. Ispeziona gli oggetti locali applicabili dal livello più specifico verso l'esterno. Per il testo, ciò può includere la porzione, il paragrafo, il frame di testo, il layout, il master, il tema e i valori predefiniti della presentazione. Valori non definiti come `float.NaN` o `null` indicano che la ricerca continua a un altro livello.

**Cosa succede quando nessun livello definisce una proprietà?**

Aspose.Slides risolve il valore predefinito appropriato di PowerPoint o della libreria. Quel valore risolto appare nei dati effettivi anche se nessun oggetto locale lo definisce esplicitamente.

**Perché a volte un valore effettivo è uguale al valore locale?**

Il valore locale ha vinto il calcolo dell'ereditarietà. Questo è previsto quando la proprietà è impostata esplicitamente sull'oggetto e nessuna regola più specifica la sovrascrive.

**Quando dovrei usare i dati locali invece dei dati effettivi?**

Usa i dati locali per ispezionare o modificare un livello specifico di formattazione. Usa i dati effettivi quando ti serve l'aspetto finale dopo l'ereditarietà, le regole del tema e gli stili applicabili sono stati risolti. L'[esempio di confronto completo](#compare-local-inherited-and-effective-values) dimostra entrambi nello stesso flusso di lavoro.