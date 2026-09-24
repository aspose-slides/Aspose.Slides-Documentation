---
title: Hantera PowerPoint-textstycken i .NET
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- lägga till text
- lägga till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckeegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, portioner, punkter, numrerade listor, indrag, HTML‑innehåll och styckebilder med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides för .NET representerar text som en hierarki av textramar, stycken och portioner:

* [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) representerar textbehållaren i en form och ger åtkomst till dess samling av stycken.
* [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/) representerar ett stycke i en textram och ger åtkomst till dess portioner och formatering på styckennivå.
* [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/) representerar ett textsegment inom ett stycke. Varje portion kan ha sin egen text och teckenbaserad formatering.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annan formatering genom att använda flera portioner.

## **Skapa och Formatera Stycken**

### **Skapa Stycken med Flera Portioner**

Följande steg skapar en textram med tre stycken, där varje stycke innehåller tre portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Få åtkomst till den relevanta bildens referens via dess index.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).
5. Använd standardstycket och lägg till två ytterligare [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/)‑objekt i textramen.
6. Lägg till tillräckligt med [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/)‑objekt så att varje stycke innehåller tre portioner. Standardstycket innehåller redan en tom portion.
7. Sätt texten för varje portion.
8. Tillämpa teckenbaserad formatering via [IPortion.PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/portionformat/).
9. Spara den ändrade presentationen.

Detta C#‑exempel implementerar stegen:

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

## **Skapa Punkt- och Numrerade Listor**

### **Skapa en Punkt- eller Numrerad Lista**

Punkter och numrering gör relaterade objekt enklare att skumma igenom. I Aspose.Slides definieras listinställningar via [IBulletFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/).

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen.
2. Få åtkomst till den relevanta bildens referens via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på den valda bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/) för en symbolpunkt.
7. Sätt [IBulletFormat.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/type/) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/net/aspose.slides/bullettype/) och ange punkttecknet.
8. Ställ in styckestext, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och sätt [IBulletFormat.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/type/) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/net/aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

Detta C#‑exempel skapar en symbolpunkt och en numrerad punkt:

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

### **Använd Bildpunkter**

Bildpunkter låter dig använda en anpassad bild i stället för en symbol eller siffra.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen.
2. Få åtkomst till den relevanta bildens referens via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) och få åtkomst till dess [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/) och sätt dess text.
7. Sätt [IBulletFormat.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/type/) till [BulletType.Picture](https://reference.aspose.com/slides/sv/net/aspose.slides/bullettype/).
8. Tilldela bilden via [IBulletFormat.Picture](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/picture/) och sätt punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den ändrade presentationen.

Detta C#‑exempel skapar en bildpunkt:

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

### **Skapa en Flernivålista**

Sätt [IParagraphFormat.Depth](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/depth/) för att placera stycken på olika nivåer i en lista. Toppraden har djupet `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och få åtkomst till en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkttecken.
4. Sätt deras [IParagraphFormat.Depth](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/depth/)‑värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

Detta C#‑exempel skapar en fyranivåpunktlista:

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

### **Starta Numrerade Listpunkter med Anpassade Värden**

Använd [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/numberedbulletstartwith/) för att ange startnumret för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Sätt [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/numberedbulletstartwith/) till `2`, `3` respektive `7` för de aktuella styckena.
5. Lägg till styckena i textramen och spara presentationen.

Detta C#‑exempel tilldelar ett eget startnummer till varje stycke:

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

## **Styr Stycke Layout och Slutegenskaper**

### **Ange Ett Indrag för Första Raden**

Använd egenskapen [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/) för att kontrollera indraget för första raden i ett stycke. Denna egenskap flyttar endast den första raden relativt styckets vänstra marginal. Ett positivt värde flyttar första raden åt höger, medan de återstående raderna förblir justerade med styckeskroppen.

Använd [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginleft/) när du vill flytta hela stycket. Använd [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/) när du bara vill flytta första raden.

Exemplet nedan skapar flera stycken och tillämpar olika [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/)‑värden för att demonstrera hur indraget för första raden påverkar layouten.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen.
2. Få åtkomst till målbilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa flera stycken och sätt olika [Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den ändrade presentationen.

Denna kod visar hur du angav ett styckeindrag:

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

Resultatet:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Ange Ett Hängande Indrag**

Ett hängande indrag är en stycke‑layout där första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/). Sätt `Indent` till ett negativt värde för att flytta första raden åt vänster relativt styckeskroppen.

I praktiken definierar [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginleft/) den vänstra positionen för styckeskroppen, och [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/) definierar positionen för första raden relativt den marginalen. För att skapa ett hängande indrag sätter du ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, ordlistposter och andra stycken där radbrytningar måste ligga under styckeskroppen snarare än under den första tecknet i första raden.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen.
2. Få åtkomst till målbilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa stycken och sätt ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginleft/)‑värde för varje stycke.
6. Sätt ett negativt [Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den ändrade presentationen.

Denna kod visar hur du anger ett hängande indrag för ett stycke:

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

Resultatet:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Ange Slut‑Stycke‑Run‑Egenskaper**

Egenskapen [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/endparagraphportionformat/) styr formateringen av styckets slutmarkering. Följande exempel tilldelar en teckenstorlek och ett latinskt teckensnitt till slutmarkeringen för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och öppna en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textportioner i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/portionformat/) för det andra styckets slutmarkering.
5. Sätt [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/fontheight/) och [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/latinfont/).
6. Tilldela formatet till [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/endparagraphportionformat/) och spara presentationen.

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

## **Räkna Renderade Rader**

Använd [IParagraph.GetLinesCount](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getlinescount/) för att räkna antalet rader som ett stycke upptar efter textlayout, inklusive automatisk radbrytning. Detta är användbart när man kontrollerar textlängd och layout i presentationsmallar.

Ett stycke är ett objekt i [ITextFrame.Paragraphs](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/paragraphs/), och det kan uppta flera renderade rader. Ett explicit radbrytningstecken i ett stycke tvingar en ny rad utan att skapa ett nytt stycke. Automatisk radbrytning skapar rader baserat på den tillgängliga bredden utan att infoga explicita radbrytningstecken i texten. Att räkna stycken eller radbrytningstecken ger därför inte antalet renderade rader.

Följande exempel skapar en textruta, räknar dess rader, minskar formen och ersätter sedan texten med en kortare sträng. Radbrytning är aktiverad och autofit är inaktiverat så att formens bredd styr radbrytningen utan att automatiskt krympa texten eller ändra formens storlek. Formens dimensioner är i punkter. Slutligen lägger exemplet till ett ytterligare stycke och summerar radantalet över textramen.

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

Med denna text och dessa dimensioner ökar radantalet när formen smalnas, medan ersättningen med den korta strängen minskar det. Exakta antal kan variera beroende på teckensnittstillgänglighet och ersättning, teckenstorlek, marginaler, indrag, radbrytning och autofit‑inställningar. Använd de teckensnitt och layoutinställningar som är avsedda för målmiljön när du kontrollerar en mall.

Radantalet ensam avgör inte om texten överskrider sin behållare. Tillgänglig höjd, radhöjder, stycke‑ och radavstånd samt autofit‑beteende spelar också roll; även en enda rad kan överskrida den tillgängliga bredden när radbrytning är inaktiverad.

## **Import och Export av Styckeinnehåll**

### **Importera HTML‑text till Stycken**

Använd [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphcollection/addfromhtml/) för att konvertera HTML‑markup till stycken och portioner i en textram.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen.
2. Få åtkomst till en bild och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).
3. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Spara den ändrade presentationen.

Detta C#‑exempel importerar HTML till en textram:

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

### **Exportera Stycketext till HTML**

Använd [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphcollection/exporttohtml/) för att exportera ett valt intervall av stycken som HTML.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen och läs in den önskade presentationen.
2. Få åtkomst till bilden och hitta den [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) som innehåller texten.
3. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).
4. Anropa [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphcollection/exporttohtml/) med start‑styckeindex och antalet stycken som ska exporteras.
5. Skriv den returnerade HTML‑strängen till en fil.

Detta C#‑exempel exporterar alla stycken från den första textrutan:

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

### **Rendera ett Stycke som Bild**

[IParagraph.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getimage/) renderar ett enskilt stycke direkt och returnerar en [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/save/). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[IParagraph.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getimage/) kan returnera `null` om stycket inte kan hittas i sin föräldrasamling, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och frigör den returnerade bilden efter användning.

#### **Rendera ett Stycke i Standardskala**

Låt oss anta att vi har en presentationsfil kallad sample.pptx med en bild, där den första formen är en textruta med tre stycken.

![The text box with three paragraphs](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta i standardskala och sparar den returnerade bilden i PNG‑format. `using`‑deklarationen säkerställer att bilden frigörs korrekt.

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

Resultatet:

![The paragraph image](paragraph_to_image_output.png)

#### **Rendera ett Stycke i En Tabellcell med Skalning**

Använd [IParagraph.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getimage/)‑overloaden som tar emot `float scaleX` och `float scaleY`‑parametrar för att ange horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor bredd och höjd som standard och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axiella standardpixelstorleken. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket ger fyra gånger så många pixlar. Större faktorer ger generellt skarpare text för zoom eller högupplöst utskrift, men ökar också minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker ut resultatet oberoende.

Att rendera en hel form med [IShape.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getimage/) är fortfarande användbart när utskriften måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart bild av ett stycke, använd [IParagraph.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Sätt [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/wraptext/) för att inaktivera radbrytning så att rader inte bryts vid textramens kanter.

**Hur får jag exakt position för ett specifikt stycke på bilden?**

Använd [IParagraph.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getrect/) för att hämta styckets omgivande rektangel. [IPortion.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/getrect/) ger gränserna för en enskild portion.

**Var styrs styckejustering (vänster, höger, centrerad eller marginal)?"**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/alignment/) är en inställning på styckennivå och tillämpas på hela stycket oavsett individuell portionsformatering.

**Kan jag ange korrekturspråk för en del av ett stycke?**

Ja. Sätt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/languageid/) för enskilda portioner, så att ett stycke kan innehålla text på flera språk.