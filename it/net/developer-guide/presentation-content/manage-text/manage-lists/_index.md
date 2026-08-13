---
title: Gestire elenchi puntati e numerati nelle presentazioni in .NET
linktitle: Gestire gli elenchi
type: docs
weight: 70
url: /it/net/manage-lists/
aliases:
  - /net/gestire-elenchi-puntati-e-numerati/
keywords:
- punto
- elenco puntato
- elenco numerato
- punto simbolo
- punto immagine
- punto personalizzato
- elenco multilivello
- creare punto
- aggiungere punto
- aggiungere elenco
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagini, multilivello e numerati in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides for .NET consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni di elenco puntato sono controllate tramite il suo formato di paragrafo.

Utilizza la proprietà [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/paragraphformat/) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/), che restituisce un oggetto [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/). Con questo oggetto è possibile impostare il tipo di punto, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero iniziale.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un punto immagine
- creare un elenco multilivello impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) e imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/). È quindi possibile impostare [IBulletFormat.Char](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/color/) e [IBulletFormat.Height](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/height/) per controllare l'aspetto del punto.

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

![I simboli puntati](symbol_bullets.png)

## **Creare un elenco numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstyle/) o impostare [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith/) quando l'elenco deve iniziare da un valore diverso da 1.

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

![I punti numerati](numbered_bullets.png)

## **Creare un punto immagine**

Aspose.Slides consente di sostituire un simbolo di punto regolare con un'immagine. I punti immagine funzionano al meglio con immagini semplici che rimangono leggibili a dimensioni ridotte, come icone o piccoli file PNG trasparenti.

 {{% alert color="info" %}}
Idealmente, se prevedi di sostituire il simbolo di punto regolare con un'immagine, è meglio scegliere una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli di punto personalizzati.

Tieni presente che l'immagine verrà ridotta a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di selezionare un'immagine che rimanga chiara ed efficace visivamente quando viene utilizzata come punto in un elenco.
{{% /alert %}}

Per creare un punto immagine, aggiungi un'immagine a [Presentation.Images](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/images/) e assegna l'oggetto immagine restituito a [IBulletFormat.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/picture/). Imposta [IBulletFormat.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/type/) su [BulletType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i punti](picture_for_bullets.png)

Il seguente codice C# mostra come creare punti immagine in una diapositiva:

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

![I punti immagine](picture_bullets.png)

## **Creare un elenco multilivello**

Usa [IParagraphFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello più alto, il livello 1 è annidato al di sotto e così via.

Il seguente codice C# mostra come creare un elenco puntato multilivello:

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

![L'elenco multilivello](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione dell'elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/). Le stesse proprietà utilizzate per creare gli elenchi possono essere usate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

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

## **FAQ**

### È possibile esportare elenchi puntati e numerati in PDF o immagini?

Sì. Aspose.Slides conserva la formattazione degli elenchi quando il formato di destinazione supporta la disposizione del testo e le funzionalità di punto corrispondenti.

### Posso modificare gli elenchi nelle presentazioni esistenti?

Sì. Carica la presentazione, accedi al paragrafo di destinazione, ispeziona o aggiorna le sue impostazioni [IParagraphFormat.Bullet](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/bullet/), e salva la presentazione.

### Gli elenchi possono contenere testo non latino?

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, così puoi creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i glifi di cui hai bisogno.