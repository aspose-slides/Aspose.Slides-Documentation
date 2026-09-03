---
title: Gestire le caselle di testo nelle presentazioni in .NET
linktitle: Gestisci casella di testo
type: docs
weight: 20
url: /it/net/manage-textbox/
keywords:
- casella di testo
- riquadro di testo
- aggiungi testo
- aggiorna testo
- crea casella di testo
- verifica casella di testo
- aggiungi colonna di testo
- aggiungi collegamento ipertestuale
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea, identifica, formatta e aggiorna le caselle di testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET."
---
## **Introduzione**

In Aspose.Slides for .NET, il testo delle diapositive è memorizzato nei riquadri di testo che appartengono alle forme. L'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rappresenta la forma più comune contenente testo ed espone il suo testo tramite la proprietà [IAutoShape.TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Ogni auto shape implementa [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), ma non ogni forma è un'auto shape o supporta un riquadro di testo. Quando si elabora una presentazione esistente, verificare che una forma implementi `IAutoShape` prima di accedere al suo testo.
{{% /alert %}}

## **Crea una casella di testo su una diapositiva**

Per creare una casella di testo, aggiungere un'auto shape a una diapositiva, aggiungere testo al suo riquadro di testo e salvare la presentazione. Il seguente esempio crea una casella di testo rettangolare:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Le coordinate e le dimensioni passate a [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addautoshape/) sono misurate in punti. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/addtextframe/) inizializza il riquadro di testo con il testo fornito.

## **Verifica se una forma è una casella di testo**

Utilizzare la proprietà [AutoShape.IsTextBox](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/istextbox/) per determinare se un'auto shape viene trattata come una casella di testo. Questo è utile quando una presentazione contiene sia auto shape contenenti testo sia auto shape puramente grafiche.

![Una casella di testo e una forma](istextbox.png)

Il seguente esempio ispeziona ogni auto shape in una presentazione:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Un'auto shape appena aggiunta non è considerata una casella di testo finché non contiene testo non vuoto. È possibile fornire quel testo tramite [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/addtextframe/) o [ITextFrame.Text](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/text/). Aggiungere o assegnare una stringa vuota lascia `IsTextBox` impostato su `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Le prime due chiamate stampano `True`; le ultime due stampano `False`.

## **Trova la forma che possiede un riquadro di testo**

Il codice generico di elaborazione del testo può ricevere un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) senza sapere quale oggetto della presentazione lo contiene. Utilizzare la proprietà di sola lettura [ITextFrame.ParentShape](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentshape/) per tornare alla sua [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) proprietaria.

Per un riquadro di testo posseduto da un'auto shape o da un'altra forma contenente testo, `ParentShape` contiene il proprietario e [ITextFrame.ParentCell](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentcell/) è `null`. Verificare il valore restituito prima di accedervi. Per identificare sia i proprietari di forma sia di cella di tabella, incluse le forme associate a nodi SmartArt, vedere [Search and Replace Text](/slides/it/net/search-and-replace-text/).

## **Aggiungi colonne a una casella di testo**

La proprietà [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/columncount/) divide il riquadro di testo in colonne, mentre [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/columnspacing/) imposta la distanza tra le colonne in punti. Entrambe le impostazioni appartengono a [ITextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/) e possono essere modificate tramite il riquadro di testo di una casella di testo esistente. Il testo si ridistribuisce tra le colonne all'interno della stessa forma; non continua in un'altra forma.

Il seguente esempio crea una casella di testo a tre colonne con 10 punti tra le colonne, salva la presentazione e legge le impostazioni memorizzate dal file di output:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Estrai il testo da colonne individuali**

Utilizzare [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/splittextbycolumns/) per recuperare il testo assegnato a ciascuna colonna visiva in un riquadro di testo esistente. Il metodo restituisce una stringa per ogni colonna, secondo l'ordine di lettura basato sulle colonne. Un riquadro di testo a colonna singola produce un array con un elemento, e una colonna vuota è rappresentata da una stringa vuota. Le stringhe contengono solo testo semplice; la formattazione a livello di porzione non viene preservata.

Questo è utile quando è necessario:
- Estrarre il testo mantenendo il suo ordine di lettura basato sulle colonne.
- Indicizzare o confrontare il contenuto di diapositive a più colonne.
- Esportare ogni colonna in un file separato, campo database o altra destinazione.
- Ispezionare come il testo viene ridistribuito dopo aver modificato [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/columnspacing/), il carattere o la dimensione del riquadro di testo.

Il metodo restituisce il testo distribuito all'interno dell'attuale [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/); non fa fluire automaticamente il testo tra forme o caselle di testo separate. La distribuzione delle colonne può dipendere dai caratteri disponibili e da altre impostazioni di layout del testo, quindi assicurarsi che i caratteri richiesti siano disponibili quando è importante ottenere risultati consistenti.

Il seguente esempio carica una presentazione, trova la prima auto shape a più colonne con un riquadro di testo, legge il numero di colonne configurato e scrive il testo di ogni colonna in un file separato. Le forme che non forniscono un riquadro di testo vengono ignorate.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Aggiorna il testo**

Per aggiornare il testo in tutta la presentazione, iterare tra le diapositive e le forme, selezionare le auto shape e quindi modificare le loro porzioni di testo. Lavorare a livello di porzione consente di cambiare sia il testo sia la formattazione dei caratteri.

Il seguente esempio sostituisce ogni occorrenza di `years` con `months` nel testo delle auto shape e rende ogni porzione interessata in grassetto:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Questo attraversamento aggiorna il testo solo nelle auto shape. Il testo memorizzato in tabelle, grafici, SmartArt o forme raggruppate richiede l'attraversamento delle rispettive collezioni degli oggetti.

## **Aggiungi una casella di testo con un collegamento ipertestuale**

È possibile assegnare un collegamento ipertestuale a una specifica porzione di testo, in modo che solo quel testo funzioni come link cliccabile. Utilizzare [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) per associare la porzione a un URL esterno.

Il seguente esempio crea testo con collegamento e lo salva in una presentazione:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

Un [placeholder](/slides/it/net/manage-placeholder/) può ereditare la sua posizione e formattazione da una [master slide](https://reference.aspose.com/slides/it/net/aspose.slides/masterslide/) o da una [layout slide](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslide/). Una casella di testo regolare è una forma indipendente sulla diapositiva in cui è stata creata e non acquisisce il comportamento di segnaposto quando il layout cambia.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Limitare l'attraversamento alle forme che implementano [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/), come mostrato nell'esempio Aggiorna il testo. Grafici, tabelle e SmartArt memorizzano il testo nei propri modelli di oggetti, quindi non vengono modificati da quel ciclo.