---
title: Gestire i paragrafi di PowerPoint in .NET
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire punto
- rientro paragrafo
- rientro sospeso
- punto paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importare HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esportare paragrafo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET rappresenta il testo come una gerarchia di fotogrammi di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) rappresenta un paragrafo in un fotogramma di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) rappresenta una sequenza di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse utilizzando più porzioni.

## **Crea e formatta i paragrafi**

Crea paragrafi nel fotogramma di testo di una forma e utilizza le porzioni per formattare singole sequenze di testo. Questa sezione mostra come combinare più porzioni all'interno di ciascun paragrafo e applicare colori, dimensioni di carattere e stili differenti.

### **Crea paragrafi con più porzioni**

Il seguente esempio C# crea tre paragrafi, ciascuno contenente tre sequenze di testo nella sua collezione [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/). Riutilizza il paragrafo predefinito e la sua porzione vuota, quindi aggiunge i paragrafi e le porzioni restanti. La formattazione viene applicata tramite [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): la prima porzione in ogni paragrafo è rossa, grassetto e 15 punti; la seconda è blu, corsivo e 18 punti. La terza porzione mantiene la formattazione predefinita:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Crea elenchi puntati e numerati**

Organizza il testo del paragrafo in elenchi con simboli, numeri o immagini personalizzate. Gli esempi in questa sezione coprono la formattazione dei punti, gli elenchi a più livelli e i numeri di partenza personalizzati.

### **Crea un elenco puntato o numerato**

I punti e la numerazione rendono gli elementi correlati più facili da leggere. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Questo esempio C# aggiunge un punto simbolico e un elemento numerato allo stesso fotogramma di testo. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) seleziona il tipo di punto, mentre [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) fornisce il simbolo e [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) seleziona lo stile di numerazione. Entrambi gli elementi usano punti neri con un'altezza del 100 % e un rientro del paragrafo di 25 punti:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Usa punti immagine**

I punti immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

Questo esempio C# aggiunge un'immagine alla collezione di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) e la utilizza come punto del paragrafo. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) per usare un punto immagine e assegna l'immagine tramite [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) è impostato al 100 % per dimensionare il punto rispetto al testo del paragrafo:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Crea un elenco a più livelli**

Imposta [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) per posizionare i paragrafi a diversi livelli di un elenco. Il livello superiore ha profondità `0`.

Questo esempio C# assegna valori [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) da 0 a 3 a quattro paragrafi, creando una gerarchia all'interno di un unico fotogramma di testo. Ogni paragrafo utilizza un punto simbolico, con [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) alternato tra un punto rotondo e un trattino per distinguere i livelli adiacenti:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Imposta l'inizio degli elementi numerati con valori personalizzati**

Usa [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

Questo esempio C# imposta [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) per usare la numerazione per tre paragrafi e assegna valori [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) di 2, 3 e 7. Il valore di partenza è configurato separatamente per ciascun paragrafo, consentendo di saltare valori nella numerazione visualizzata:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Controlla il layout del paragrafo e le proprietà di chiusura**

Regola i margini e i rientri del paragrafo per controllare la posizione della prima riga e delle righe avvolte. Puoi anche formattare il segno di chiusura del paragrafo separatamente dalle porzioni di testo visibili.

### **Imposta un rientro della prima riga**

Usa la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) per controllare il rientro della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) quando devi spostare l'intero paragrafo. Usa [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) quando devi spostare solo la prima riga.

L'esempio seguente assegna a tre paragrafi lo stesso [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) di 20 punti e valori [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) di 0, 20 e 40 punti. Le prime righe iniziano con offset progressivamente maggiori, mentre le righe avvolte mantengono lo stesso margine sinistro:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il rientro della prima riga dei paragrafi](first_line_indent.png)

### **Imposta un rientro sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe rimanenti. In Aspose.Slides, crei questo effetto con la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Imposta `Indent` a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo di `MarginLeft` e un valore negativo di `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe avvolte devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

Il seguente esempio C# associa valori [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) di 40 e 60 punti con valori [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) di -20 e -30 punti. In ciascun paragrafo, la prima riga inizia a sinistra delle righe avvolte; il secondo paragrafo ha un rientro sospeso più profondo:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il rientro sospeso dei paragrafi](hanging_indent.png)

### **Imposta le proprietà di chiusura del paragrafo**

La proprietà [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) controlla la formattazione del segno di chiusura del paragrafo. L'esempio seguente crea un [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) con [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) impostato a 48 punti e [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) impostato a Times New Roman. Assegna questo formato al segno di chiusura del secondo paragrafo, lasciando inalterate le porzioni di testo visibili:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Conta le righe renderizzate**

Per le regole di paragrafo che influenzano l'avvolgimento automatico e la punteggiatura alla fine della riga, vedi [Control Line Breaking](/slides/it/net/text-formatting/#control-line-breaking) e [Control Hanging Punctuation](/slides/it/net/text-formatting/#control-hanging-punctuation).

Usa [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) per contare le righe occupate da un paragrafo dopo il layout del testo, incluso l'avvolgimento automatico. Questo è utile per verificare la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), e può occupare diverse righe renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova riga senza creare un altro paragrafo. L'avvolgimento automatico crea righe basate sulla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Pertanto, contare i paragrafi o i caratteri di interruzione di riga non restituisce il conteggio delle righe renderizzate.

L'esempio seguente crea una forma di testo, ne conta le righe, restringe la forma e poi sostituisce il testo con una stringa più corta. L'esempio abilita [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) e disabilita [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) in modo che la larghezza della forma controlli l'avvolgimento senza ridimensionare automaticamente il testo o la forma. Ogni misurazione utilizza [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle righe all'interno del fotogramma di testo.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle righe, mentre sostituire il testo con la stringa breve lo riduce. I conteggi esatti possono variare a seconda della disponibilità dei caratteri e della loro sostituzione, della dimensione del carattere, dei margini, dell'indentazione, dell'avvolgimento e delle impostazioni di autofit. Usa i caratteri e le impostazioni di layout previste per l'ambiente di destinazione quando verifichi un modello.

Il conteggio delle righe da solo non determina se il testo supera il contenitore. Anche l'altezza disponibile, le altezze delle righe, la spaziatura tra paragrafi e righe e il comportamento di autofit sono importanti; anche una sola riga può superare la larghezza disponibile quando l'avvolgimento è disabilitato.

## **Importa ed esporta il contenuto dei paragrafi**

Usa HTML per introdurre testo in una presentazione o per esportare paragrafi esistenti da usare all'esterno. Questa sezione mostra anche come rendere singoli paragrafi come immagini, inclusi paragrafi in celle di tabelle.

### **Importa testo HTML nei paragrafi**

Usa [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) per convertire markup HTML in paragrafi e porzioni in un fotogramma di testo.

Questo esempio C# legge HTML da un file e passa il markup a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Cancella il paragrafo predefinito del fotogramma di testo in modo che il fotogramma contenga solo il contenuto importato. La forma rettangolare lascia un margine di 10 punti su ciascun lato della diapositiva:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Esporta il testo del paragrafo in HTML**

Usa [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi in HTML. Quando riutilizzi il testo della presentazione su un sito web, potresti voler conservare l'enfasi locale senza trasferire lo stile di carattere, dimensione o casella di testo della presentazione. Imposta [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) per controllare fino a che punto l'esportatore segue l'ereditarietà della formattazione.

Scarica [la presentazione di esempio](text-inheritance.pptx) e posizionala nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene una forma di testo con il testo “Inherited text; explicit red 18pt”. L'input utilizza deliberatamente diversi livelli di formattazione:

- Lo stile di testo predefinito della presentazione fornisce Calibri a 28 pt.
- Lo stile di testo di primo livello del fotogramma fornisce testo blu e corsivo.
- Il paragrafo imposta esplicitamente il testo in grassetto.
- La seconda porzione, “explicit red 18pt”, imposta esplicitamente testo rosso e dimensione 18 pt.

Il seguente esempio completo esporta gli stessi paragrafi tre volte. Passa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) al metodo di esportazione e scrive ogni risultato in un file HTML UTF‑8 separato:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

L'HTML generato contiene il seguente CSS per la prima porzione, “Inherited text; ”. La tabella elenca le dichiarazioni rilevanti; le altre proprietà generate sono omesse per chiarezza.

| Output | CSS rilevante per la prima porzione | Aspetto |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Testo blu, grassetto, corsivo a 28 pt in Calibri, se disponibile. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Testo blu, grassetto, corsivo; la pagina o il browser fornisce famiglia di caratteri e dimensione. |
| `ParagraphOnly.html` | `font-weight:bold` | Testo in grassetto; la pagina o il browser fornisce famiglia di caratteri, dimensione, colore e stile corsivo. |

La seconda porzione mantiene `color:#ff0000`, `font-size:18pt` e `font-weight:bold` in tutti e tre gli output. Mantiene anche il corsivo in `All` e `TextBox`, ma non in `ParagraphOnly`. Limitare l'ereditarietà quindi non rimuove la formattazione assegnata esplicitamente a un paragrafo o a una porzione.

Apri i file nello stesso browser per confrontarli. Nei due modi limitati, le proprietà CSS omesse vengono risolte dallo stile della pagina di destinazione o dai valori predefiniti del browser, perciò l'aspetto risultante dipende da dove l'HTML è utilizzato.

### **Rendi un paragrafo come immagine**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) rende direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Non è necessario rendere la forma contenente o ritagliare manualmente una bitmap.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) può restituire `null` se il paragrafo non è presente nella collezione genitore, non ha limiti di rendering validi o non può essere renderizzato. Verifica il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Rendi un paragrafo alla scala predefinita**

L'esempio utilizza una presentazione con una diapositiva la cui prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

Il seguente esempio seleziona il secondo paragrafo all'indice 1 e chiama [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) senza parametri di scala. Controlla che la forma contenga il paragrafo richiesto e che il rendering restituisca un'immagine prima di chiamare [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) per salvarla in formato PNG. La dichiarazione `using` rilascia l'immagine dopo l'uso.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Il risultato:

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Rendi un paragrafo in una cella di tabella con scala**

Usa la sovraccarica di [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, rende il paragrafo nella sua prima cella a due volte la larghezza e l'altezza predefinite e salva il risultato come immagine PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Un fattore di scala `1` mantiene quell'asse alla dimensione predefinita in pixel. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, generando quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettaglio. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output indipendentemente.

Renderizzare un'intera forma con [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) resta utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, usa [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Posso disabilitare completamente l'avvolgimento delle linee all'interno di un fotogramma di testo?**

Sì. Imposta [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) per disabilitare l'avvolgimento in modo che le righe non si spezzino ai bordi del fotogramma di testo.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usa [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

Per allineare verticalmente le porzioni con dimensioni di carattere diverse all'interno di ogni riga, vedi [Align Fonts Within a Line](/slides/it/net/text-formatting/#align-fonts-within-a-line).

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Imposta [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) per le singole porzioni, così un paragrafo può contenere testo in più lingue.