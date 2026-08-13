---
title: Beheer van opsommingstekens en genummerde lijsten in presentaties in .NET
linktitle: Beheer Lijsten
type: docs
weight: 70
url: /nl/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- opsommingsteken
- opsomminglijst
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- opsommingsteken maken
- opsommingsteken toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding‑opsommingstekens, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden beheerd via de alinea‑opmaak.

Gebruik de [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/paragraphformat/) eigenschap om de lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat.Bullet](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/bullet/), die een [IBulletFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/) object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomminglijst maakt met een aangepast symbool
- een afbeelding‑opsommingsteken maakt
- een meerlagige lijst maakt door de diepte van de alinea in te stellen
- een genummerde lijst maakt
- de lijstopmaak in een bestaande presentatie bekijkt en wijzigt

## **Een opsomminglijst maken**

Om een opsomminglijst te maken, voegt u [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) en stelt u [IBulletFormat.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/type/) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/net/aspose.slides/bullettype/). Daarna kunt u [IBulletFormat.Char](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/color/) en [IBulletFormat.Height](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/height/) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende C#‑code laat zien hoe u een opsomminglijst in een dia maakt:

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

Het resultaat:

![De symboolopsommingstekens](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van de items van belang is. Stel [IBulletFormat.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/type/) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/net/aspose.slides/bullettype/). U kunt ook een nummeropmaak kiezen met [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstyle/) of [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstartwith/) instellen wanneer de lijst moet beginnen met een andere waarde dan 1.

De volgende C#‑code toont hoe u een genummerde lijst in een dia maakt:

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

Het resultaat:

![De genummerde opsommingstekens](numbered_bullets.png)

## **Een afbeelding‑opsommingsteken maken**

Aspose.Slides stelt u in staat een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het beste met eenvoudige afbeeldingen die op een kleine grootte nog leesbaar blijven, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="info" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u een eenvoudige grafiek met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer kleine grootte. Om die reden raden wij sterk aan een afbeelding te kiezen die duidelijk blijft en visueel effectief is wanneer deze als opsommingsteken in een lijst wordt gebruikt.

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation.Images](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/images/) en kent u het geretourneerde afbeeldingsobject toe aan [IBulletFormat.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/picture/). Stel [IBulletFormat.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/type/) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel dat we een "image.png" hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende C#‑code toont hoe u afbeelding‑opsommingstekens in een dia maakt:

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

Het resultaat:

![De afbeeldings‑opsommingstekens](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [IParagraphFormat.Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/depth/) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 staat eronder genesteld, enzovoort.

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

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst aanpassen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u toegang tot de doel‑alinea en werkt u de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/bullet/)‑instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen worden gebruikt om lijsten die uit een PPT, PPTX of ODP‑bestand zijn geladen, te bekijken of aan te passen.

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

### Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doel‑formaat de overeenkomstige tekstlay‑out en opsommingsteken‑functies ondersteunt.

### Kan ik lijsten bewerken in bestaande presentaties?

Ja. Laad de presentatie, krijg toegang tot de doel‑alinea, bekijk of werk de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/bullet/)‑instellingen bij, en sla de presentatie op.

### Kunnen lijsten niet‑Latijnse tekst bevatten?

Ja. De tekst van een lijstitem kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de benodigde tekens ondersteunen.