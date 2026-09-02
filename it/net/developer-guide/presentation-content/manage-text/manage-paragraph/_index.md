---
title: Gestire i paragrafi di testo PowerPoint in .NET
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- aggiungi testo
- aggiungi paragrafo
- gestisci testo
- gestisci paragrafo
- gestisci punto
- rientro del paragrafo
- rientro sospeso
- punto del paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importa HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esporta paragrafo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET rappresenta il testo come una gerarchia di riquadri di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) rappresenta un singolo paragrafo in un riquadro di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) rappresenta una sequenza di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse utilizzando più porzioni.

## **Crea e formatta paragrafi**

### **Crea paragrafi con più porzioni**

I passaggi seguenti creano un riquadro di testo con tre paragrafi, ognuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) al riquadro di testo.
6. Aggiungi un numero sufficiente di oggetti [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ogni porzione.
8. Applica la formattazione a livello di carattere tramite [IPortion.PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/portionformat/).
9. Salva la presentazione modificata.

Questo esempio in C# implementa i passaggi:

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

### **Crea un elenco puntato o numerato**

I punti elenco e la numerazione facilitano la scansione di elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma.
5. Rimuovi il paragrafo predefinito dal riquadro di testo.
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) per un punto simbolico.
7. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/) e specifica il carattere del punto.
8. Imposta il testo del paragrafo, l'indentazione, il colore del punto e l'altezza del punto.
9. Aggiungi il paragrafo al riquadro di testo.
10. Crea un secondo paragrafo e imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/).
11. Configura lo stile del punto numerato e aggiungi il paragrafo al riquadro di testo.
12. Salva la presentazione.

Questo esempio in C# crea un punto simbolico e un punto numerato:

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

### **Usa puntini immagine**

I puntini immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e accedi al suo [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/).
4. Rimuovi il paragrafo predefinito dal riquadro di testo.
5. Carica l'immagine del punto e aggiungila alla raccolta di immagini della presentazione come un [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) e imposta il suo testo.
7. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/).
8. Assegna l'immagine tramite [IBulletFormat.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/picture/) e imposta l'altezza del punto.
9. Aggiungi il paragrafo al riquadro di testo.
10. Salva la presentazione modificata.

Questo esempio in C# crea un punto immagine:

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

Imposta [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) per posizionare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e rimuovi il paragrafo predefinito dal suo riquadro di testo.
3. Crea quattro paragrafi e configura i loro simboli di punto.
4. Imposta i valori di [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) su `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi al riquadro di testo e salva la presentazione.

Questo esempio in C# crea un elenco puntato a quattro livelli:

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

### **Inizia gli elementi numerati con valori personalizzati**

Usa [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) a una diapositiva.
2. Rimuovi il paragrafo predefinito dal riquadro di testo della forma.
3. Crea tre paragrafi numerati.
4. Imposta [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi al riquadro di testo e salva la presentazione.

Questo esempio in C# assegna un numero di partenza personalizzato a ciascun paragrafo:

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

## **Controlla il layout del paragrafo e le proprietà di fine**

### **Imposta un rientro della prima riga**

Usa la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per controllare il rientro della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) quando devi spostare l'intero paragrafo. Usa [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) quando devi spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori diversi di [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per ciascuno.
6. Aggiungi i paragrafi al riquadro di testo.
7. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro di paragrafo:

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

Un rientro sospeso è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, crei questo effetto con la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/). Imposta `Indent` su un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo di `MarginLeft` e un valore negativo di `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe avvolte devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) per ciascun paragrafo.
6. Imposta un valore negativo di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per creare l'effetto di rientro sospeso.
7. Aggiungi i paragrafi al riquadro di testo.
8. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro sospeso per un paragrafo:

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

### **Imposta le proprietà di fine paragrafo**

La proprietà [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/endparagraphportionformat/) controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Carica una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e rimuovi il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/fontheight/) e [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/latinfont/).
6. Assegna il formato a [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/endparagraphportionformat/) e salva la presentazione.

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

## **Importa ed esporta contenuto del paragrafo**

### **Importa testo HTML nei paragrafi**

Usa [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/addfromhtml/) per convertire il markup HTML in paragrafi e porzioni in un riquadro di testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi a una diapositiva e aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).
3. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
4. Leggi il file HTML di origine.
5. Passa la stringa HTML a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Salva la presentazione modificata.

Questo esempio in C# importa HTML in un riquadro di testo:

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

Usa [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione desiderata.
2. Accedi alla diapositiva e trova la [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) che contiene il testo.
3. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma.
4. Chiama [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/exporttohtml/) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita in un file.

Questo esempio in C# esporta tutti i paragrafi dalla prima forma di testo:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Renderizza un paragrafo come immagine**

[IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/). Non è necessario renderizzare la forma contenente o ritagliare manualmente una bitmap.

[IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/) può restituire `null` se il paragrafo non è presente nella sua raccolta genitore, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizza un paragrafo alla scala predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

L'esempio seguente renderizza il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG. La dichiarazione `using` garantisce che l'immagine venga rilasciata correttamente.

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

#### **Renderizza un paragrafo in una cella di tabella con ridimensionamento**

Usa la sovraccarico di [IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella a due volte la larghezza e altezza predefinite e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alla dimensione di pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettaglio. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori diversi per gli assi orizzontale e verticale allungano l'output in modo indipendente.

Renderizzare un'intera forma con [IShape.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getimage/) resta utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine contenente solo il paragrafo, usa [IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/).

## **Domande frequenti**

**Posso disattivare completamente l'andare a capo all'interno di un riquadro di testo?**

Sì. Imposta [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/wraptext/) per disabilitare l'andare a capo in modo che le linee non si interrompano ai bordi del riquadro di testo.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usa [IParagraph.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/getrect/) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Imposta [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/) per le singole porzioni, così un paragrafo può contenere testo in più lingue.