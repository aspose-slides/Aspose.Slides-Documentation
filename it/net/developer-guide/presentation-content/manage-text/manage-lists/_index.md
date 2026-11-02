---
title: Gestire elenchi puntati e numerati nelle presentazioni in .NET
linktitle: Gestire gli elenchi
type: docs
weight: 70
url: /it/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - pallottola
  - elenco puntato
  - elenco numerato
  - pallottola simbolo
  - pallottola immagine
  - pallottola personalizzata
  - elenco a più livelli
  - creare pallottola
  - aggiungere pallottola
  - aggiungere elenco
  - PowerPoint
  - OpenDocument
  - presentazione
  - .NET
  - C#
  - Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagine, a più livelli e numerati in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET ti consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento dell'elenco è un paragrafo le cui impostazioni di puntatura sono controllate tramite il formato del paragrafo.

Usa la proprietà [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), che restituisce un oggetto [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/). Con questo oggetto, è possibile impostare il tipo di pallottola, il simbolo, l'immagine, il colore, le dimensioni, lo stile di numerazione e il numero di partenza.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare una puntatura con immagine
- creare un elenco a più livelli impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente
- leggere i marcatori e i numeri dell'elenco reali accanto al testo del paragrafo

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) e imposta [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) su [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Puoi quindi impostare [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), e [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) per controllare l'aspetto della puntatura.

Il seguente codice C# dimostra come creare un elenco puntato in una diapositiva:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le pallottole a simbolo](symbol_bullets.png)

## **Creare un elenco numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) su [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) o impostare [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice C# mostra come creare un elenco numerato in una diapositiva:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le pallottole numerate](numbered_bullets.png)

## **Creare una puntatura immagine**

Aspose.Slides consente di sostituire un simbolo di puntatura normale con un'immagine. Le pallottole immagine funzionano meglio con immagini semplici che rimangono leggibili a piccole dimensioni, come icone o piccoli file PNG trasparenti.

{{% alert color="info" title="Note" %}}
Idealmente, se prevedi di sostituire il simbolo di puntatura normale con un'immagine, è meglio scegliere una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli di puntatura personalizzati.

Tieni presente che l'immagine sarà ridotta a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di scegliere un'immagine che rimanga chiara ed efficace visualmente quando viene utilizzata come puntatura in un elenco.
{{% /alert %}}

Per creare una puntatura immagine, aggiungi un'immagine a [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) e assegna l'oggetto immagine restituito a [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) su [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per le puntature](picture_for_bullets.png)

Il seguente codice C# mostra come creare puntature immagine in una diapositiva:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le puntature immagine](picture_bullets.png)

## **Creare un elenco a più livelli**

Usa [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso, e così via.

Il seguente codice C# mostra come creare un elenco puntato a più livelli:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Il risultato:

![L'elenco a più livelli](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione dell'elenco in una presentazione esistente, accedi al paragrafo target e aggiorna le impostazioni di [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/). Le stesse proprietà usate per creare gli elenchi possono essere utilizzate per esaminare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice C# cambia il primo paragrafo in un fotogramma di testo per utilizzare uno stile di elenco numerato:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Leggere i valori effettivi della puntatura**

Quando si estrae il contenuto di una presentazione, conserva i marcatori dell'elenco insieme al testo del paragrafo. Chiama [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) e accedi a [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) per ottenere il formato di puntatura effettivo. Controlla il suo [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) prima di leggere [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/).

Per gli elenchi numerati, distingui questi tre valori:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) determina il formato, ad esempio numeri arabi seguiti da un punto o lettere minuscole seguite da un punto.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) specifica il numero iniziale per un gruppo di paragrafi numerati.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) restituisce il marcatore formattato per un particolare paragrafo. Per esempio, il secondo elemento in un elenco che inizia da 5 restituisce `6.`.

Preserva [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) con ogni paragrafo per mantenere il suo livello di annidamento. Il marcatore effettivo non codifica l'intera gerarchia: un elemento annidato può restituire `c.` anziché un'etichetta combinata come `6.c.`.

Il seguente esempio autonomo crea elenchi, li salva in una presentazione e ricarica la presentazione per segnalare il testo, la profondità, il tipo di puntatura e il valore reale di ciascun paragrafo. Il piccolo marcatore immagine blu è creato da SVG in linea.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Crea un marcatore immagine senza un file immagine esterno.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Gli elenchi di origine sono mostrati di seguito.

![Elenchi che iniziano da 5, elementi annidati con lettere e numeri romani, un marcatore a simbolo, un paragrafo senza puntatura e un marcatore immagine blu](actual_bullet_values.png)

Il report corrisponde ai marcatori visualizzati in PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Per [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/), [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) restituisce `null`, non una stringa vuota. Gestisci questi tipi separatamente: il primo non ha marcatore, mentre il secondo richiede l'estrazione dell'immagine della puntatura separatamente. Una puntatura immagine non può essere riprodotta solo estraendo un marcatore di testo.

## **FAQ**

**È possibile esportare elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides preserva la formattazione degli elenchi quando il formato di destinazione supporta il layout del testo e le funzionalità di puntatura corrispondenti.

**Posso modificare gli elenchi nelle presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo target, esamina o aggiorna le impostazioni di [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, quindi è possibile creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.