---
title: "PowerPoint-tekstaalinea's beheren in .NET"
linktitle: "Alinea beheren"
type: docs
weight: 40
url: /nl/net/manage-paragraph/
aliases:
  - /net/alinea/
  - /net/deel/
  - /net/paragraph/
  - /net/portion/
keywords:
  - tekst toevoegen
  - alinea toevoegen
  - tekst beheren
  - alinea beheren
  - opsommingsteken beheren
  - alinea inspringing
  - hangende inspringing
  - alinea opsommingsteken
  - genummerde lijst
  - opsommingslijst
  - alinea-eigenschappen
  - HTML importeren
  - tekst naar HTML
  - alinea naar HTML
  - alinea naar afbeelding
  - tekst naar afbeelding
  - alinea exporteren
  - PowerPoint
  - presentatie
  - .NET
  - C#
  - Aspose.Slides
description: "Leer hoe u alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET stelt tekst voor als een hiërarchie van tekstframes, alinea's en delen:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de verzameling alinea's.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de delen en de alinea‑niveau opmaak.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) vertegenwoordigt een tekstdelen binnen een alinea. Elk deel kan eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan dus tekst met verschillende lettertypen, kleuren, groottes en andere opmaak bevatten door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere delen**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie delen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) objecten toe zodat elke alinea drie delen bevat. De standaard alinea bevat al één leeg deel.
7. Stel de tekst van elk deel in.
8. Pas teken‑niveau opmaak toe via [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/).
9. Sla de gewijzigde presentatie op.

Dit C#‑voorbeeld implementeert de stappen:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstin­stellingen gedefinieerd via [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) en specificeer het opsommingsteken.
8. Stel de alinea‑tekst, inspringing, kleur en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/).
11. Configureer de stijl van het genummerde opsommingsteken en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit C#‑voorbeeld maakt een symbool‑opsommingsteken en een genummerd opsommingsteken:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten je een aangepast beeld gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse.
2. Verkrijg de referentie van de betreffende dia via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe en verkrijg zijn [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad de opsommingstekenge­beeld en voeg het toe aan de afbeeldingscollectie van de presentatie als een [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/).
8. Wijs het beeld toe via [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit C#‑voorbeeld maakt een afbeeldings‑opsommingsteken:

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

### **Een meervoudig niveau‑lijst maken**

Stel [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) in om alinea’s op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) en verkrijg een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe en wis de standaard alinea uit het tekstframe.
3. Maak vier alinea’s en configureer hun opsommingstekensymbolen.
4. Stel hun [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea’s toe aan het tekstframe en sla de presentatie op.

Dit C#‑voorbeeld maakt een vier‑niveau opsomming:

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

### **Genummerde lijstitems beginnen met aangepaste waarden**

Gebruik [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) om het initiële nummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) en voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan een dia.
2. Wis de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea’s.
4. Stel [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) in op `2`, `3` en `7` voor de respectieve alinea’s.
5. Voeg de alinea’s toe aan het tekstframe en sla de presentatie op.

Dit C#‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑lay‑out en eind‑eigenschappen beheren**

### **Een eerste‑regelin­inspringing instellen**

Gebruik de eigenschap [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) om de eerste‑regelin­inspringing van een alinea te bepalen. Deze eigenschap verschuift alleen de eerste regel ten opzichte van de linker­marge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de resterende regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) wanneer je de gehele alinea wilt verplaatsen. Gebruik [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) wanneer je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea’s en past verschillende [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) waarden toe om te laten zien hoe de eerste‑regelin­inspringing de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
2. Verkrijg de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea’s en stel verschillende [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) waarden in.
6. Voeg de alinea’s toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een alinea‑inspringing instelt:

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

Het resultaat:

![De eerste-regel inspringing van de alinea's](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel links van de resterende regels begint. In Aspose.Slides creëer je dit effect met de eigenschap [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Stel `Indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑lichaam.

In de praktijk definieert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) de linkermarge van het alinea‑lichaam, en definieert [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te creëren, stel je een positieve `MarginLeft` waarde en een negatieve `Indent` waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea’s waarbij afgebroken regels onder het alinea‑lichaam moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
2. Verkrijg de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea’s en stel voor elke alinea een positieve [MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) waarde in.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) waarde in om het hangende‑inspringing‑effect te krijgen.
7. Voeg de alinea’s toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een hangende inspringing voor een alinea instelt:

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

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Eind‑alinea‑deel‑eigenschappen instellen**

De eigenschap [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) bepaalt de opmaak van het alinea‑eindteken. Het volgende voorbeeld kent een lettertype‑grootte en een Latijns lettertype toe aan het eindteken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) en verkrijg een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe en wis de standaard alinea.
3. Maak twee alinea’s en voeg tekstdelen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) en [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) in.
6. Ken de opmaak toe aan [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) en sla de presentatie op.

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

## **Aantal gerenderde regels tellen**

Voor alinea‑regels die automatische regel‑afbreking en interpunctie aan het einde van regels beïnvloeden, zie [Control Line Breaking](/slides/nl/net/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/net/text-formatting/#control-hanging-punctuation).

Gebruik [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) om het aantal regels te tellen dat een alinea inneemt na tekst‑lay‑out, inclusief automatische afbreking. Dit is handig bij het controleren van tekstdikte en lay‑out in presentatiesjablonen.

Een alinea is één item in [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), en kan meerdere gerenderde regels innemen. Een expliciete regeleinde‑invoeging binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te creëren. Automatische afbreking maakt regels op basis van de beschikbare breedte zonder expliciete regeleindes in de tekst in te voegen. Het tellen van alinea’s of regeleinde‑tekens geeft dus niet het gerenderde aantal regels.

Het volgende voorbeeld maakt een tekstvorm, telt de regels, maakt de vorm smaller en vervangt daarna de tekst door een kortere string. Inpakken is ingeschakeld en autofit uitgeschakeld zodat de vorm‑breedte de regel‑afbreking bepaalt zonder automatisch de tekst te verkleinen of de vorm te schalen. Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld nog een alinea toe en telt de regels van het gehele tekstframe bij elkaar op.

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

Met deze tekst en afmetingen verhoogt het vernauwen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte string het aantal regels verlaagt. Exacte tellingen kunnen variëren afhankelijk van beschikbare lettertypen en substitutie, lettergrootte, marges, inspringing, inpakken en autofit‑instellingen. Gebruik de lettertypen en lay‑out‑instellingen die voor de doelsituatie bedoeld zijn bij het testen van een sjabloon.

Het aantal regels alleen bepaalt niet of de tekst buiten de container loopt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑interlinie, en autofit‑gedrag zijn ook van belang; zelfs een enkele regel kan de beschikbare breedte overschrijden wanneer inpakken uitgeschakeld is.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea’s**

Gebruik [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) om HTML‑opmaak te converteren naar alinea’s en delen in een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse.
2. Verkrijg een dia en voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe.
3. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van de vorm en wis de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Sla de gewijzigde presentatie op.

Dit C#‑voorbeeld importeert HTML in een tekstframe:

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) om een geselecteerd bereik van alinea’s als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse en laad de gewenste presentatie.
2. Verkrijg de dia en zoek de [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) die de tekst bevat.
3. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van de vorm.
4. Roep [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) aan met de start‑alinea‑index en het aantal alinea’s dat moet worden geëxporteerd.
5. Schrijf de teruggegeven HTML‑string naar een bestand.

Dit C#‑voorbeeld exporteert alle alinea’s van de eerste tekstvorm:

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

### **Een alinea renderen als afbeelding**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) rendert een individuele alinea direct en retourneert een [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Sla het resultaat op naar een bestand of stream met [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Je hoeft de omvattende vorm niet te renderen of een bitmap handmatig bij te snijden.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) kan `null` retourneren als de alinea niet wordt gevonden in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een alinea renderen op de standaard schaal**

Stel dat we een presentatiebestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is met drie alinea’s.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een regulier tekstvak op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. De `using`‑verklaring zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

Het resultaat:

![De alinea afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schaling**

Gebruik de overload van [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) die `float scaleX` en `float scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaard breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer het dubbele van de standaardafmetingen zijn, wat resulteert in vier keer zoveel pixels. Grotere factoren geven over het algemeen scherpere tekst voor zoomen of hoge‑resolutie‑output, maar verhogen ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` leveren kleinere afbeeldingen met minder detail op. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een alleen‑alinea‑afbeelding gebruik je [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kan ik het automatisch afbreken van tekst in een tekstframe volledig uitschakelen?**

Ja. Stel [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) in om afbreken uit te schakelen zodat regels niet bij de randen van het tekstframe worden afgebroken.

**Hoe krijg ik de exacte on‑slide‑grenzen van een specifieke alinea?**

Gebruik [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) om het omvattende rechthoek van de alinea op te halen. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) geeft de grenzen van een individueel deel.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) gecontroleerd?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) is een alinea‑niveau instelling en wordt toegepast op de hele alinea ongeacht de opmaak van individuele delen.

Om delen met verschillende lettergrootten binnen elke regel verticaal uit te lijnen, zie [Align Fonts Within a Line](/slides/nl/net/text-formatting/#align-fonts-within-a-line).

**Kan ik de proeflees‑taal instellen voor een deel van een alinea?**

Ja. Stel [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) in voor individuele delen, zodat één alinea tekst in meerdere talen kan bevatten.