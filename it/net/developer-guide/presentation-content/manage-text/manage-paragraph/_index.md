---
title: Gestire i paragrafi di testo PowerPoint in .NET
linktitle: Gestisci paragrafo
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
  - gestire punto elenco
  - rientro paragrafo
  - rientro sospeso
  - punto elenco del paragrafo
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
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides for .NET rappresenta il testo come una gerarchia di frame di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) rappresenta un paragrafo in un frame di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) rappresenta un blocco di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altra formattazione utilizzando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare Paragrafi con Più Porzioni**

I passaggi seguenti creano un frame di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma.
5. Utilizzare il paragrafo predefinito e aggiungere altri due oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) al frame di testo.
6. Aggiungere un numero sufficiente di oggetti [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Impostare il testo di ogni porzione.
8. Applicare la formattazione a livello di carattere tramite [IPortion.PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/portionformat/).
9. Salvare la presentazione modificata.

Questo esempio C# implementa i passaggi:

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

## **Creare Elenchi Puntati e Numerati**

### **Creare un Elenco Puntato o Numerato**

I punti elenco e la numerazione rendono gli elementi correlati più facili da leggere. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/).

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma.
5. Rimuovere il paragrafo predefinito dal frame di testo.
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) per un punto elenco simbolico.
7. Impostare [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/) e specificare il carattere del punto elenco.
8. Impostare il testo del paragrafo, l'indentazione, il colore del punto elenco e l'altezza del punto elenco.
9. Aggiungere il paragrafo al frame di testo.
10. Creare un secondo paragrafo e impostare [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/).
11. Configurare lo stile del punto elenco numerato e aggiungere il paragrafo al frame di testo.
12. Salvare la presentazione.

Questo esempio C# crea un punto elenco simbolico e uno numerato:

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

### **Utilizzare Punti Elenco Immagine**

I punti elenco immagine consentono di usare un'immagine personalizzata al posto di un simbolo o numero.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e accedere al suo [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/).
4. Rimuovere il paragrafo predefinito dal frame di testo.
5. Caricare l'immagine del punto elenco e aggiungerla alla raccolta di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) e impostarne il testo.
7. Impostare [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/).
8. Assegnare l'immagine tramite [IBulletFormat.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/picture/) e impostare l'altezza del punto elenco.
9. Aggiungere il paragrafo al frame di testo.
10. Salvare la presentazione modificata.

Questo esempio C# crea un punto elenco immagine:

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

### **Creare un Elenco Multilivello**

Impostare [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) per posizionare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e cancellare il paragrafo predefinito dal suo frame di testo.
3. Creare quattro paragrafi e configurare i loro simboli di punto elenco.
4. Impostare i valori di [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) a `0`, `1`, `2` e `3`.
5. Aggiungere i paragrafi al frame di testo e salvare la presentazione.

Questo esempio C# crea un elenco puntato a quattro livelli:

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

### **Iniziare gli Elementi Numerati con Valori Personalizzati**

Utilizzare [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) a una diapositiva.
2. Cancellare il paragrafo predefinito dal frame di testo della forma.
3. Creare tre paragrafi numerati.
4. Impostare [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) a `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungere i paragrafi al frame di testo e salvare la presentazione.

Questo esempio C# assegna un numero di avvio personalizzato a ciascun paragrafo:

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

## **Controllare il Layout del Paragrafo e le Proprietà di Fine**

### **Impostare un Rientro della Prima Riga**

Utilizzare la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per controllare il rientro della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le linee rimanenti rimangono allineate al corpo del paragrafo.

Usare [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) quando è necessario spostare l'intero paragrafo. Usare [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori diversi di [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori diversi di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per ciascuno.
6. Aggiungere i paragrafi al frame di testo.
7. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro del paragrafo:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Impostare un Rientro Sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima riga inizia a sinistra delle linee successive. In Aspose.Slides, è possibile creare questo effetto con la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/). Impostare `Indent` su un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

Nella pratica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, impostare un valore positivo di `MarginLeft` e un valore negativo di `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le linee a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare paragrafi e impostare un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) per ciascun paragrafo.
6. Impostare un valore negativo di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per creare l'effetto di rientro sospeso.
7. Aggiungere i paragrafi al frame di testo.
8. Salvare la presentazione modificata.

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Impostare le Proprietà di Esecuzione di Fine Paragrafo**

La proprietà [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/endparagraphportionformat/) controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Caricare una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e cancellare il suo paragrafo predefinito.
3. Creare due paragrafi e aggiungere porzioni di testo a ciascuno.
4. Creare un [PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Impostare [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/fontheight/) e [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/latinfont/).
6. Assegnare il formato a [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/endparagraphportionformat/) e salvare la presentazione.

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

## **Contare le Linee Renderizzate**

Utilizzare [IParagraph.GetLinesCount](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getlinescount/) per contare le linee occupate da un paragrafo dopo il layout del testo, inclusi gli a capo automatici. Questo è utile quando si verifica la lunghezza e il layout del testo nei modelli di presentazione.

Un paragrafo è un elemento in [ITextFrame.Paragraphs](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/paragraphs/), e può occupare diverse linee renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova linea senza creare un altro paragrafo. L'avvolgimento automatico crea linee in base alla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Pertanto, contare i paragrafi o i caratteri di interruzione di riga non fornisce il conteggio delle linee renderizzate.

L'esempio seguente crea una forma di testo, conta le sue linee, restringe la forma e poi sostituisce il testo con una stringa più corta. L'avvolgimento è abilitato e l'autoadattamento è disabilitato in modo che la larghezza della forma controlli l'avvolgimento senza ridurre automaticamente il testo o ridimensionare la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee nell'intero frame di testo.

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

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa corta lo riduce. I conteggi esatti possono variare in base alla disponibilità e sostituzione dei font, dimensione del carattere, margini, indentazione, avvolgimento e impostazioni di autoadattamento. Utilizzare i font e le impostazioni di layout previste per l'ambiente di destinazione quando si verifica un modello.

Il conteggio delle linee da solo non determina se il testo supera il contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura dei paragrafi e delle linee e il comportamento dell'autoadattamento sono importanti; anche una sola linea può superare la larghezza disponibile quando l'avvolgimento è disattivato.

## **Importare ed Esportare il Contenuto dei Paragrafi**

### **Importare Testo HTML nei Paragrafi**

Utilizzare [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/addfromhtml/) per convertire il markup HTML in paragrafi e porzioni in un frame di testo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedere a una diapositiva e aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) .
3. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma e cancellare il suo paragrafo predefinito.
4. Leggere il file HTML sorgente.
5. Passare la stringa HTML a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. Salvare la presentazione modificata.

Questo esempio C# importa HTML in un frame di testo:

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

### **Esportare il Testo del Paragrafo in HTML**

Utilizzare [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e caricare la presentazione desiderata.
2. Accedere alla diapositiva e trovare la [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) che contiene il testo.
3. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) della forma.
4. Chiamare [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/exporttohtml/) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivere la stringa HTML restituita su un file.

Questo esempio C# esporta tutti i paragrafi dalla prima forma di testo:

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

### **Renderizzare un Paragrafo come Immagine**

[IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/) renderizza un singolo paragrafo direttamente e restituisce un [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/). Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/) può restituire `null` se il paragrafo non può essere trovato nella sua collezione genitore, non ha limiti di rendering validi o non può essere renderizzato. Controllare il risultato prima di salvarlo e rilasciare l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![The text box with three paragraphs](paragraph_to_image_input.png)

L'esempio seguente rende il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG. L'istruzione `using` garantisce che l'immagine venga eliminata correttamente.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scaling**

Utilizzare la sovraccarico di [IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, rende il paragrafo nella sua prima cella a una larghezza e altezza doppie rispetto al valore predefinito, e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alle dimensioni pixel predefinite. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, generando quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per ingrandimenti o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Utilizzare fattori uguali per preservare le proporzioni del paragrafo; fattori orizzontali e verticali diversi allungano l'output in modo indipendente.

Renderizzare un'intera forma con [IShape.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getimage/) rimane utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine contenente solo il paragrafo, usare [IParagraph.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Posso disabilitare completamente l'avvolgimento delle linee all'interno di un frame di testo?**

Sì. Impostare [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/wraptext/) per disabilitare l'avvolgimento in modo che le linee non si interrompano ai bordi del frame di testo.

**Come posso ottenere i limiti esatti sulla diapositiva di un paragrafo specifico?**

Utilizzare [IParagraph.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/getrect/) fornisce i limiti di una singola porzione.

**Dove viene controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Impostare [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/) per le singole porzioni, in modo che un paragrafo possa contenere testo in più lingue.