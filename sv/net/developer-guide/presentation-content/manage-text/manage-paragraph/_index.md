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

Aspose.Slides for .NET representerar text som en hierarki av textramar, stycken och portioner:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) representerar textbehållaren i en form och ger åtkomst till dess stycke­samling.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) representerar ett stycke i en textram och ger åtkomst till dess portioner och styckesnivå‑formatering.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) representerar en textkörning inom ett stycke. Varje portion kan ha sin egen text och teckennivå‑formatering.

Ett stycke kan därför innehålla text med olika teckensnitt, färger, storlekar och annan formatering genom att använda flera portioner.

## **Skapa och formatera stycken**

Skapa stycken i en formes textram och använd portioner för att formatera enskilda textkörningar. Denna sektion visar hur man kombinerar flera portioner i varje stycke och applicerar olika färger, teckenstorlekar och stilar.

### **Skapa stycken med flera portioner**

Följande C#‑exempel skapar tre stycken, vardera innehållande tre textkörningar i dess [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/)‑samling. Det återanvänder standardstycket och dess tomma portion, och lägger sedan till de återstående styckena och portionerna. Formatering appliceras via [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): den första portionen i varje stycke är röd, fet och 15 punkter; den andra är blå, kursiv och 18 punkter. Den tredje portionen behåller sin standardformatering:

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

## **Skapa punktlistor och numrerade listor**

Organisera stycketext i listor med symboler, siffror eller egna bilder. Exemplen i denna sektion täcker punktformatering, flernivålistor och anpassade startnummer.

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Detta C#‑exempel lägger till en symbolpunkt och ett numrerat objekt i samma textram. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) väljer punkt‑typen, medan [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) anger symbolen och [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) väljer numreringsstilen. Båda objekten använder svarta punkter med en höjd på 100 % och ett stycke‑indrag på 25 punkter:

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

### **Använd bildpunkter**

Bildpunkter låter dig använda en anpassad bild i stället för en symbol eller ett nummer.

Detta C#‑exempel lägger till en bild i presentationens bildsamling som en [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) och använder den som ett styckepunkt. Det sätter [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) för att använda en bildpunkt och tilldelar bilden via [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) sätts till 100 % för att dimensionera punkten i förhållande till stycketexten:

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

### **Skapa en flernivålista**

Ange [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) för att placera stycken på olika nivåer i en lista. Toppnivån har ett djup på `0`.

Detta C#‑exempel tilldelar [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) värden från 0 till 3 för fyra stycken, vilket skapar en hierarki i en textram. Varje stycke använder en symbolpunkt, med [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) som växlar mellan en rund punkt och ett bindestreck för att särskilja intilliggande nivåer:

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

### **Starta numrerade listobjekt med anpassade värden**

Använd [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) för att ange det första numret som visas för ett numrerat stycke.

Detta C#‑exempel sätter [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) för att använda numrering för tre stycken och tilldelar [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) värdena 2, 3 och 7. Startvärdet konfigureras separat för varje stycke, vilket gör att de visade numren kan hoppa över värden:

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

## **Styr stycke‑layout och avslutnings‑egenskaper**

Justera styckemarginaler och indrag för att styra positionen för den första raden och de radbryta raderna. Du kan också formatera stycke‑slutmärket separat från de synliga textdelarna.

### **Ställ in ett första‑rad‑indrag**

Använd egenskapen [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) för att kontrollera första‑rad‑indraget för ett stycke. Denna egenskap flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde förskjuter den första raden åt höger, medan de återstående raderna förblir justerade med styckekroppen.

Använd [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) när du behöver flytta hela stycket. Använd [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) när du endast behöver flytta den första raden.

Följande exempel ger tre stycken samma [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) på 20 punkter och [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)‑värden på 0, 20 och 40 punkter. De första raderna börjar med successivt större avstånd, medan radbrytade rader behåller samma vänstra marginal:

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

![Första‑rad‑indraget för styckena](first_line_indent.png)

### **Ställ in ett hängande indrag**

Ett hängande indrag är en stycke‑layout där den första raden startar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Sätt `Indent` till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckekroppen.

I praktiken definierar [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) den vänstra positionen för styckekroppen, och [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, förklaringsordlista‑poster och andra stycken där radbrytade rader måste justeras under styckekroppen snarare än under det första tecknet i den första raden.

Det följande C#‑exemplet parar ihop [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) värden på 40 och 60 punkter med [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) värden på -20 och -30 punkter. I varje stycke startar den första raden till vänster om de radbrytade raderna; det andra stycket har ett djupare hängande indrag:

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

![Det hängande indraget för styckena](hanging_indent.png)

### **Ställ in egenskaper för stycke‑slutkörning**

Egenskapen [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) styr formateringen av styckets slutmarkör. Följande exempel skapar ett [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) med [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) inställt på 48 punkter och [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) inställt på Times New Roman. Det tilldelar detta format till det andra styckets slutmarkör, utan att ändra de synliga textdelarna:

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

## **Räkna renderade rader**

För stycke‑regler som påverkar automatisk radbrytning och skiljetecken vid radslut, se [Kontroll av radbrytning](/slides/sv/net/text-formatting/#control-line-breaking) och [Kontroll av hängande skiljetecken](/slides/sv/net/text-formatting/#control-hanging-punctuation).

Använd [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) för att räkna antalet rader som ett stycke upptar efter textlayout, inklusive automatisk radbrytning. Detta är användbart när man kontrollerar textlängd och layout i presentationsmallar.

Ett stycke är ett objekt i [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), och det kan uppta flera renderade rader. Ett explicit radbrytningstecken inom ett stycke tvingar en ny rad utan att skapa ett nytt stycke. Automatisk radbrytning skapar rader baserat på tillgänglig bredd utan att infoga explicita radbrytningar i texten. Att räkna stycken eller radbrytningstecken ger därför inte det renderade radantalet.

Det följande exemplet skapar en textruta, räknar dess rader, smalnar av formen och ersätter sedan texten med en kortare sträng. Exemplet aktiverar [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) och inaktiverar [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) så att formens bredd styr radbrytning utan att automatiskt krympa texten eller ändra formens storlek. Varje mätning använder [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Formens dimensioner är i punkter. Slutligen lägger exemplet till ett annat stycke och summerar radantalet över textramen.

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

Med denna text och dessa dimensioner ökar radantalet när formen smalnar av, medan ersättning av texten med den korta strängen minskar det. Exakta räknare kan variera beroende på teckensnittstillgänglighet och -substitution, teckenstorlek, marginaler, indrag, radbrytning och autofit‑inställningar. Använd de teckensnitt och layoutinställningar som är avsedda för målmiljön när du kontrollerar en mall.

Radantalet ensam bestämmer inte om texten överflödar sin behållare. Tillgänglig höjd, radhöjder, stycke‑ och radavstånd samt autofit‑beteende spelar också roll; även en enda rad kan överskrida den tillgängliga bredden när radbrytning är inaktiverad.

## **Importera och exportera styckeinnehåll**

Använd HTML för att föra in text i en presentation eller exportera befintliga stycken för användning utanför den. Denna sektion visar också hur man renderar enskilda stycken som bilder, inklusive stycken i tabellceller.

### **Importera HTML‑text i stycken**

Använd [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) för att konvertera HTML‑markup till stycken och portioner i en textram.

Detta C#‑exempel läser HTML från en fil och skickar markupen till [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Det rensar textrammans standardstycke så att ramen endast innehåller det importerade innehållet. Den rektangulära formen lämnar en marginal på 10 punkter på varje sida av bilden:

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

### **Exportera stycketext till HTML**

Använd [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) för att exportera ett valt område av stycken som HTML. När du återanvänder presentationstext på en webbplats kan du vilja bevara lokal betoning utan att föra över presentationens teckensnitt, storlek eller textrutestilar. Ställ in [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) för att kontrollera hur långt exportören följer formatarv.

Ladda ner [exempelpresentationen](text-inheritance.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller en textruta med texten "Inherited text; explicit red 18pt". Inmatningen använder avsiktligt flera formateringsnivåer:

- Presentationens standardtextstil tillhandahåller Calibri och en storlek på 28 pt.
- Textramens förstalinjesta textstil tillhandahåller blå text och kursiv.
- Stycket anger uttryckligen fet text.
- Den andra portionen, "explicit red 18pt", anger uttryckligen röd text och en storlek på 18 pt.

Det följande kompletta exemplet exporterar samma stycken tre gånger. Det skickar [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) till exportmetoden och skriver varje resultat som en separat UTF‑8‑HTML‑fil:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

Den genererade HTML‑koden innehåller följande CSS för den första portionen, "Inherited text; ". Tabellen listar de relevanta deklarationerna; andra genererade egenskaper har utelämnats för tydlighet.

| Utdata | Relevant CSS för den första portionen | Utseende |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blå, fet, kursiv text på 28 pt i Calibri, om det teckensnittet är tillgängligt. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blå, fet, kursiv text; den omgivande sidan eller webbläsaren tillhandahåller teckensnittsfamiljen och storleken. |
| `ParagraphOnly.html` | `font-weight:bold` | Fet text; den omgivande sidan eller webbläsaren tillhandahåller teckensnittsfamiljen, storleken, färgen och kursiv stil. |

Den andra portionen behåller `color:#ff0000`, `font-size:18pt` och `font-weight:bold` i alla tre utskrifterna. Den behåller även kursiv med `All` och `TextBox`, men inte med `ParagraphOnly`. Att begränsa arv tar därför inte bort formatering som uttryckligen tilldelats ett stycke eller en portion.

Öppna filerna i samma webbläsare för att jämföra dem. I de två begränsade lägena löses utelämnade CSS‑egenskaper av destinationssidans stilar eller webbläsarstandarder, så det resulterande utseendet beror på var HTML‑koden används.

### **Rendera ett stycke som en bild**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) renderar ett enskilt stycke direkt och returnerar en [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) kan returnera `null` om stycket inte kan hittas i sin föräldrasamling, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och disponera den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Exemplet använder en presentation med en bild där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Det följande exemplet väljer det andra stycket med index 1 och anropar [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) utan skalparametrar. Det kontrollerar att formen innehåller det nödvändiga stycket och att renderingen returnerar en bild innan den anropar [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) för att spara den i PNG‑format. `using`‑deklarationen disponerar bilden efter användning.

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

![Styckebilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd den överlagrade versionen av [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) som accepterar `float scaleX` och `float scaleY`‑parametrar för att ange de horisontella och vertikala skalningsfaktorerna. Det följande exemplet skapar en tabell, renderar stycket i dess första cell med dubbelt så stor bredd och höjd som standard, och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axeln på dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standarddimensionerna, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger generellt skarpare text för zoomning eller högupplöst utskrift, men de ökar även minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker utdata oberoende.

Att rendera en hel form med [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) är fortfarande användbart när utdata måste inkludera formens fyllning, kant eller annan visuell kontext. För en bild som bara innehåller ett stycke, använd [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **Vanliga frågor**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Ställ in [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) för att inaktivera radbrytning så att rader inte bryts vid textrammens kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Använd [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) för att hämta styckets omgivande rektangel. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) ger gränserna för en enskild portion.

**Var styrs styckejustering (vänster, höger, centrerad eller marginaljusterad)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) är en styckesnivåinställning och gäller hela stycket oavsett enskild portions formatering. För att vertikalt justera portioner med olika teckenstorlekar inom varje rad, se [Justera teckensnitt inom en rad](/slides/sv/net/text-formatting/#align-fonts-within-a-line).

**Kan jag ange korrekturspråket för en del av ett stycke?**

Ja. Ställ in [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) för enskilda portioner, så att ett stycke kan innehålla text på flera språk.