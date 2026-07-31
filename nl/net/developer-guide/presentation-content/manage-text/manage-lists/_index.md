---
title: Beheer opsommingstekens en genummerde lijsten in presentaties in .NET
linktitle: Lijsten beheren
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
  - afbeeldingsopsommingsteken
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
description: "Leer hoe u opsommingstekens, afbeelding, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint en OpenDocument presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides voor .NET stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument-presentaties. Een lijstitem is een alinea waarvan de opsommingsteken‑instellingen worden beheerd via de alinea‑opmaak.

Gebruik de [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/paragraphformat/) eigenschap om lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat.Bullet](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/bullet/), dat een [IBulletFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/) object oplevert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming maakt met een aangepast symbool
- een afbeelding‑opsommingsteken maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- lijstopmaak inspecteert en wijzigt in een bestaande presentatie

## **Maak een opsomming**

Om een opsomming te maken, voegt u [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) en stelt u [IBulletFormat.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/type/) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/net/aspose.slides/bullettype/). Daarna kunt u [IBulletFormat.Char](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/color/) en [IBulletFormat.Height](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/height/) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende C#‑code toont hoe u een opsomming maakt in een dia:
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

Het resultaat:
![De symbool‑opsommingstekens](symbol_bullets.png)

## **Maak een genummerde lijst**

Gebruik genummerde lijsten wanneer de volgorde van items belangrijk is. Stel [IBulletFormat.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/type/) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/net/aspose.slides/bullettype/). U kunt ook een nummeringsopmaak kiezen met [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstyle/) of [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstartwith/) instellen wanneer de lijst moet beginnen met een andere waarde dan 1.

De volgende C#‑code toont hoe u een genummerde lijst maakt in een dia:
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

Het resultaat:
![De genummerde opsommingstekens](numbered_bullets.png)

## **Maak een afbeelding‑opsommingsteken**

Aspose.Slides stelt u in staat een standaard opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het best met eenvoudige afbeeldingen die ook op een kleine schaal leesbaar blijven, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="primary" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige afbeelding met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation.Images](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/images/) en kent u het geretourneerde afbeeldingsobject toe aan [IBulletFormat.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/picture/). Stel [IBulletFormat.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/type/) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel dat we een "image.png" hebben:
![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende C#‑code toont hoe u afbeelding‑opsommingstekens maakt in een dia:
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

Het resultaat:
![De afbeelding‑opsommingstekens](picture_bullets.png)

## **Maak een meerlagige lijst**

Gebruik [IParagraphFormat.Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/depth/) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 staat eronder genest, enzovoort.

De volgende C#‑code toont hoe u een meerlagige opsomming maakt:
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

Het resultaat:
![De meerlagige lijst](multilevel_list.png)

## **Wijzig een bestaande lijst**

Om de lijstopmaak in een bestaande presentatie te wijzigen, opent u de betreffende alinea en werkt u de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/bullet/) instellingen bij. De dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT-, PPTX- of ODP‑bestand zijn geladen te inspecteren of wijzigen.
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

**Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstopmaak en opsommingsteken‑eigenschappen ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de betreffende alinea, inspecteer of werk de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/bullet/) instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van een lijstitem kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de lettertypen die in de presentatie worden gebruikt, de benodigde tekens ondersteunen.