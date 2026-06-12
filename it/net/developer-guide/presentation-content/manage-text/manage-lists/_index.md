---
title: Gestire elenchi puntati e numerati nelle presentazioni in .NET
linktitle: Gestire gli elenchi
type: docs
weight: 70
url: /it/net/manage-lists/
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
description: "Scopri come creare e formattare elenchi puntati, con immagini, a più livelli e numerati nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET consente di creare e formattare elenchi puntati e numerati nelle presentazioni PowerPoint e OpenDocument. Un elemento dell'elenco è un paragrafo le cui impostazioni di pallottola sono controllate tramite il formato del paragrafo.

Utilizza la proprietà [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/paragraphformat/) per accedere alle impostazioni di elenco a livello di paragrafo. Il punto di ingresso principale è [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/), che restituisce un oggetto [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/). Con questo oggetto è possibile impostare il tipo di pallottola, il simbolo, l’immagine, il colore, la dimensione, lo stile di numerazione e il numero iniziale.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare una pallottola immagine
- creare un elenco multilevel impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) e imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/). Puoi quindi impostare [IBulletFormat.Char](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/color/) e [IBulletFormat.Height](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/height/) per controllare l'aspetto della pallottola.

Il seguente codice C# dimostra come creare un elenco puntato in una diapositiva:

```csharp
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

![The symbol bullets](symbol_bullets.png)

## **Creare un elenco numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstyle/) o impostare [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice C# mostra come creare un elenco numerato in una diapositiva:

```csharp
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

![The numbered bullets](numbered_bullets.png)

## **Creare una pallottola immagine**

Aspose.Slides consente di sostituire un simbolo di pallottola normale con un'immagine. Le pallottole immagine funzionano al meglio con immagini semplici che rimangono leggibili a piccole dimensioni, ad esempio icone o piccoli file PNG trasparenti.

{{% alert color="primary" %}}
Idealmente, se prevedi di sostituire il simbolo di pallottola normale con un'immagine, è consigliabile scegliere una grafica semplice con sfondo trasparente. Questo tipo di immagini funziona bene come simboli di pallottola personalizzati.

Tieni presente che l'immagine sarà scalata a dimensioni molto piccole. Per questo motivo, consigliamo vivamente di selezionare un'immagine che rimanga chiara ed efficace dal punto di vista visivo quando viene usata come pallottola in un elenco.
{{% /alert %}}

Per creare una pallottola immagine, aggiungi un'immagine a [Presentation.Images](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/images/) e assegna l'oggetto immagine restituito a [IBulletFormat.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/picture/). Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un file *image.png*:

![A picture for the bullets](picture_for_bullets.png)

Il seguente codice C# mostra come creare pallottole immagine in una diapositiva:

```csharp
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

![The picture bullets](picture_bullets.png)

## **Creare un elenco multilevel**

Utilizza [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso e così via.

Il seguente codice C# mostra come creare un elenco puntato multilevel:

```csharp
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

![The multilevel list](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/). Le stesse proprietà usate per creare gli elenchi possono essere utilizzate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice C# modifica il primo paragrafo in un riquadro di testo per utilizzare uno stile di elenco numerato:

```csharp
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

## **FAQ**

**È possibile esportare gli elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides preserva la formattazione degli elenchi quando il formato di destinazione supporta la disposizione del testo e le funzionalità di pallottola corrispondenti.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo di destinazione, ispeziona o aggiorna le sue impostazioni [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/) e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, quindi è possibile creare elenchi in presentazioni multilingue. Assicurati che i caratteri usati nella presentazione siano supportati dai font disponibili.