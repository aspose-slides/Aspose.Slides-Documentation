---
title: Gestisci elenchi puntati e numerati nelle presentazioni in .NET
linktitle: Gestisci elenchi
type: docs
weight: 70
url: /it/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- punto
- elenco puntato
- elenco numerato
- punto simbolico
- punto immagine
- punto personalizzato
- elenco a più livelli
- crea punto
- aggiungi punto
- aggiungi elenco
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagini, a più livelli e numerati nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides for .NET ti consente di creare e formattare elenchi puntati e numerati nelle presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni del punto elenco sono controllate tramite il formato del paragrafo.

Utilizza la proprietà [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/paragraphformat/) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/), che restituisce un oggetto [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/). Con questo oggetto è possibile impostare il tipo di punto, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero di partenza.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un punto elenco immagine
- creare un elenco a più livelli impostando la profondità del paragrafo
- creare un elenco numerato
- ispezionare e modificare la formattazione dell'elenco in una presentazione esistente

## **Crea un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) e imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/). Puoi quindi impostare [IBulletFormat.Char](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/color/), e [IBulletFormat.Height](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/height/) per controllare l'aspetto del punto elenco.

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

![I simboli a pallini](symbol_bullets.png)

## **Crea un elenco numerato**

Utilizza gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstyle/) o impostare [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) quando l'elenco deve iniziare da un valore diverso da 1.

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

![I simboli numerati](numbered_bullets.png)

## **Crea un punto elenco immagine**

Aspose.Slides consente di sostituire un simbolo di punto elenco normale con un'immagine. I punti elenco immagine funzionano meglio con immagini semplici che rimangono leggibili a dimensioni ridotte, come icone o piccoli file PNG trasparenti.

{{% alert color="primary" %}}
Idealmente, se prevedi di sostituire il simbolo di punto elenco normale con un'immagine, è consigliabile scegliere una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli personalizzati per i punti elenco.

Tieni presente che l'immagine verrà ridimensionata a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di selezionare un'immagine che rimanga chiara ed efficace visivamente quando viene utilizzata come punto elenco in un elenco.
{{% /alert %}}

Per creare un punto elenco immagine, aggiungi un'immagine a [Presentation.Images](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/images/) e assegna l'oggetto immagine restituito a [IBulletFormat.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/picture/). Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i punti elenco](picture_for_bullets.png)

Il seguente codice C# mostra come creare punti elenco immagine in una diapositiva:

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

![I punti elenco immagine](picture_bullets.png)

## **Crea un elenco a più livelli**

Utilizza [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso e così via.

Il seguente codice C# mostra come creare un elenco puntato a più livelli:

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

![L'elenco a più livelli](multilevel_list.png)

## **Modifica un elenco esistente**

Per modificare la formattazione dell'elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/). Le stesse proprietà utilizzate per creare gli elenchi possono essere usate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice C# modifica il primo paragrafo in un frame di testo per utilizzare uno stile di elenco numerato:

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

**È possibile esportare elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides conserva la formattazione degli elenchi quando il formato di destinazione supporta il layout del testo e le funzionalità dei punti elenco corrispondenti.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo di destinazione, ispeziona o aggiorna le sue impostazioni [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/), e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, così puoi creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.