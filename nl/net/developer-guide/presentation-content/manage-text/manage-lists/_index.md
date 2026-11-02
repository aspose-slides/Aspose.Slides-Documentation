---
title: Beheer opsomming- en genummerde lijsten in presentaties in .NET
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
- symbool-opsommingsteken
- afbeeldings-opsommingsteken
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
description: "Leer hoe u opsomming-, afbeeldings-, meerlagige en genummerde lijsten maakt en opmaakt in PowerPoint- en OpenDocument-presentaties met behulp van Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides voor .NET stelt u in staat om opsomming- en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument-presentaties. Een lijstitem is een alinea waarvan de opsomminginstellingen worden gecontroleerd via de alinea‑indeling.

Gebruik de [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) eigenschap om lijstinstellingen op alinea‑niveau te benaderen. Het hoofdingangspunt is [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), dat een [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) object retourneert. Met dit object kunt u het opsommingstype, symbool, afbeelding, kleur, grootte, nummeringsstijl en beginnummer instellen.

Dit artikel laat zien hoe u:

- een opsomminglijst maakt met een aangepast symbool
- een afbeeldings‑opsomming maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak inspecteert en wijzigt in een bestaande presentatie
- de werkelijke opsommingstekens en nummers leest naast de alinea‑tekst

## **Een opsomminglijst maken**

Om een opsomminglijst te maken, voegt u [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) en stelt u [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Vervolgens kunt u [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/) en [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) instellen om het uiterlijk van de opsomming te regelen.

De volgende C#‑code demonstreert hoe u een opsomminglijst in een dia maakt:

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

![The symbol bullets](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). U kunt ook een nummeringsformaat kiezen met [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) of [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) instellen wanneer de lijst moet beginnen met een andere waarde dan 1.

De volgende C#‑code laat zien hoe u een genummerde lijst in een dia maakt:

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

![The numbered bullets](numbered_bullets.png)

## **Een afbeeldings‑opsomming maken**

Aspose.Slides maakt het mogelijk om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingen werken het best met eenvoudige afbeeldingen die op een kleine grootte leesbaar blijven, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="info" title="Note" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u het beste een eenvoudige grafiek met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeeldings‑opsomming te maken, voegt u een afbeelding toe aan [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) en kent u het geretourneerde afbeeldingsobject toe aan [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Stel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel dat we een “image.png” hebben:

![A picture for the bullets](picture_for_bullets.png)

De volgende C#‑code laat zien hoe u afbeeldings‑opsommingen in een dia maakt:

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

![The picture bullets](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 staat eronder, enzovoort.

De volgende C#‑code toont hoe u een meerlagige opsomminglijst maakt:

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

![The multilevel list](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u de doel‑alinea en werkt u de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen worden gebruikt om lijsten die geladen zijn uit een PPT-, PPTX‑ of ODP‑bestand te inspecteren of te wijzigen.

De volgende C#‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

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

## **Werkelijke opsommingwaarden lezen**

Bij het extraheren van presentatiedata houdt u opsommingstekens naast de alinea‑tekst. Roep [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) aan en krijg toegang tot [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) om het effectieve opsommingformaat te verkrijgen. Controleer de [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) voordat u [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) leest.

Voor genummerde lijsten onderscheiden we deze drie waarden:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) bepaalt het formaat, bijvoorbeeld Arabische cijfers gevolgd door een punt of kleine letters gevolgd door een punt.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) specificeert het beginnummer voor een groep genummerde alinea’s.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) geeft het geformatteerde teken voor een bepaalde alinea terug. Bijvoorbeeld, het tweede item in een lijst die begint bij 5 geeft `6.` terug.

Behoud [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) bij elke alinea om het insprongsniveau te behouden. Het werkelijke teken codeert niet de volledige hiërarchie: een genest item kan `c.` teruggeven in plaats van een gecombineerde label zoals `6.c.`.

Het volgende zelfstandige voorbeeld maakt lijsten, slaat ze op in een presentatie, en laadt de presentatie opnieuw om voor elke alinea de tekst, diepte, opsommingstype en werkelijke waarde te rapporteren. Het kleine blauwe afbeeldings‑teken wordt gemaakt vanuit inline SVG.

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

    // Maak een afbeeldingsmarkering zonder een extern afbeeldingsbestand.
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

De bronomlijsten worden hieronder getoond.

![Lists starting at 5, nested letter and Roman-number items, a symbol marker, a paragraph without a bullet, and a blue picture marker](actual_bullet_values.png)

Het rapport komt overeen met de tekens die in PowerPoint worden weergegeven:

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

Voor [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) geeft [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) `null` terug, niet een lege tekenreeks. Behandel deze typen apart: de eerste heeft geen teken, terwijl de tweede vereist dat u de opsommingafbeelding apart extraheert. Een afbeeldings‑opsomming kan niet worden gereproduceerd door alleen een tekstteken te extraheren.

## **FAQ**

**Kunnen opsomming‑ en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doel‑formaat de overeenkomstige tekstlay-out en opsomming‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg de doel‑alinea, inspecteer of werk de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de gewenste tekens ondersteunen.