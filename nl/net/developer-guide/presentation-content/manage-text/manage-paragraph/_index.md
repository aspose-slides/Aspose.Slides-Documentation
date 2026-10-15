---
title: Beheer PowerPoint-tekst alinea's in .NET
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
  - /net/alinea/
  - /net/deel/
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
  - opsomminglijst
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

Aspose.Slides for .NET vertegenwoordigt tekst als een hiërarchie van tekstkaders, alinea’s en delen:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) vertegenwoordigt de tekstaanduiding in een vorm en biedt toegang tot de alinea‑collectie.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de delen en alinea‑niveau‑opmaak.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) vertegenwoordigt een tekstreeks binnen een alinea. Elk deel kan zijn eigen tekst en teken‑niveau‑opmaak hebben.

Een alinea kan dus tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

Maak alinea’s in het tekstkader van een vorm en gebruik delen om individuele tekstreeksen op te maken. Deze sectie laat zien hoe meerdere delen binnen elke alinea te combineren en verschillende kleuren, lettergroottes en stijlen toe te passen.

### **Alinea's maken met meerdere delen**

Het volgende C#‑voorbeeld maakt drie alinea’s, elk met drie tekstreeksen in de [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/)‑collectie. Het hergebruikt de standaardalinea en het lege deel, voegt vervolgens de overige alinea’s en delen toe. Opmaak wordt toegepast via [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): het eerste deel in elke alinea is rood, vet en 15 pt; het tweede is blauw, cursief en 18 pt. Het derde deel behoudt de standaardopmaak:

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

## **Genummerde en opsommingstekst maken**

Organiseer alinea‑tekst in lijsten met opsommingstekens, nummers of aangepaste afbeeldingen. De voorbeelden in deze sectie behandelen opsommingstekstopmaak, meerlagige lijsten en aangepaste startnummers.

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Dit C#‑voorbeeld voegt een symbool‑opsommingsteken en een genummerd item toe aan hetzelfde tekstkader. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) selecteert het type opsommingsteken, terwijl [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) het symbool levert en [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) de nummeringsstijl. Beide items gebruiken zwarte opsommingstekens met een hoogte van 100 procent en een alinea‑inspringing van 25 pt:

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

Afbeeldings‑opsommingstekens laten u een aangepaste afbeelding gebruiken in plaats van een symbool of nummer.

Dit C#‑voorbeeld voegt een afbeelding toe aan de afbeeldingscollectie van de presentatie als een [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) en gebruikt deze als alinea‑opsommingsteken. Het stelt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op een afbeelding‑opsommingsteken en wijst de afbeelding toe via [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) wordt ingesteld op 100 procent om de opsomming relativiteit tot de alinea‑tekst te dimensioneren:

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

### **Een meerlagige lijst maken**

Stel [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) in om alinea’s op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

Dit C#‑voorbeeld kent [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/)‑waarden van 0 tot 3 toe aan vier alinea’s, waardoor een hiërarchie binnen één tekstkader ontstaat. Elke alinea gebruikt een opsommingsteken, waarbij [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) wisselt tussen een ronde punt en een streepje om aangrenzende niveaus te onderscheiden:

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

### **Genummerde lijstitems starten bij aangepaste waarden**

Gebruik [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) om het initiële nummer voor een genummerde alinea in te stellen.

Dit C#‑voorbeeld stelt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) in op nummering voor drie alinea’s en kent [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) de waarden 2, 3 en 7 toe. De startwaarde wordt afzonderlijk voor elke alinea geconfigureerd, waardoor de weergegeven nummers waarden kunnen overslaan:

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

## **Alinea‑lay-out en eind‑eigenschappen beheersen**

Pas alinea‑marges en inspringingen aan om de positie van de eerste regel en ingesprongen regels te regelen. U kunt ook het einde‑teken van de alinea apart opmaken van de zichtbare tekstdelen.

### **Een eerste‑rij‑inspringing instellen**

Gebruik de eigenschap [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) om de eerste‑rij‑inspringing van een alinea te beheersen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde schuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) wanneer u de volledige alinea wilt verplaatsen. Gebruik [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het volgende voorbeeld geeft drie alinea’s dezelfde [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) van 20 pt en [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) waarden van 0, 20 en 40 pt. De eerste regels starten bij steeds grotere offsets, terwijl ingesprongen regels dezelfde linkermarge behouden:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel links van de overige regels start. In Aspose.Slides creëert u dit effect met de eigenschap [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Stel `Indent` in op een negatieve waarde om de eerste regel links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) de linkse positie van de alinea‑inhoud, en [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea’s waarbij ingesprongen regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

Het volgende C#‑voorbeeld combineert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) waarden van 40 en 60 pt met [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) waarden van -20 en -30 pt. In elke alinea start de eerste regel links van de ingesprongen regels; de tweede alinea heeft een diepere hangende inspringing:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Eind‑alinea‑run‑eigenschappen instellen**

De eigenschap [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) regelt de opmaak van het alinea‑eindteken. Het volgende voorbeeld maakt een [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) met [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) ingesteld op 48 pt en [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) ingesteld op Times New Roman. Het kent dit formaat toe aan het eindteken van de tweede alinea, terwijl de zichtbare tekstdelen ongewijzigd blijven:

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

Voor alinea‑regels die automatische omschakeling en interpunctie aan regeleinden beïnvloeden, zie [Control Line Breaking](/slides/nl/net/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/net/text-formatting/#control-hanging-punctuation).

Gebruik [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) om het aantal regels te tellen dat door een alinea wordt ingenomen na tekst‑lay‑out, inclusief automatische omschakeling. Dit is handig bij het controleren van tekstlengte en lay‑out in presentatiesjablonen.

Een alinea is één item in [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), en kan meerdere gerenderde regels innemen. Een expliciete regeleinde‑invoeging binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te creëren. Automatische omschakeling maakt regels op basis van de beschikbare breedte zonder expliciete regeleinde‑karakters in de tekst te voegen. Het tellen van alinea’s of regeleinde‑tekens geeft daarom niet het gerenderde regel‑aantal.

Het volgende voorbeeld maakt een tekstoppervlak, telt de regels, vernauwt de vorm en vervangt vervolgens de tekst door een kortere string. Het voorbeeld schakelt [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) in en schakelt [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) uit zodat de breedte van de vorm de omschakeling bepaalt zonder de tekst automatisch te verkleinen of de vorm te herschalen. Elke meting maakt gebruik van [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regel‑aantallen bij elkaar over het tekstkader.

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

Met deze tekst en afmetingen verhoogt het vernauwen van de vorm het aantal regels, terwijl het vervangen van de tekst door de korte string het aantal verlaagt. Exacte aantallen kunnen variëren door lettertype‑beschikbaarheid en substitutie, lettergrootte, marges, inspringing, omschakeling en autofit‑instellingen. Gebruik de lettertypen en lay‑out‑instellingen die voor de doelomgeving bedoeld zijn bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of tekst buiten de container stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑interlinie en autofit‑gedrag zijn ook van belang; zelfs een enkele regel kan de beschikbare breedte overschrijden wanneer omschakeling uitgeschakeld is.

## **Alinea‑inhoud importeren en exporteren**

Gebruik HTML om tekst in een presentatie te brengen of om bestaande alinea’s te exporteren voor gebruik daarbuiten. Deze sectie laat ook zien hoe u individuele alinea’s als afbeeldingen rendert, inclusief alinea’s in tabelcellen.

### **HTML‑tekst importeren in alinea’s**

Gebruik [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) om HTML‑markering te converteren naar alinea’s en delen in een tekstkader.

Dit C#‑voorbeeld leest HTML uit een bestand en geeft de markering door aan [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Het wist de standaardalinea van het tekstkader zodat het kader alleen de geïmporteerde inhoud bevat. De rechthoekige vorm laat een marge van 10 pt aan elke kant van de dia achter:

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

Gebruik [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) om een geselecteerd bereik van alinea’s als HTML te exporteren. Wanneer u presentatietekst opnieuw wilt gebruiken op een website, wilt u mogelijk lokale nadruk behouden zonder de lettertype‑, grootte‑ of tekstvak‑stijlen van de presentatie over te nemen. Stel [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) in om te bepalen hoe ver de exporteur de opmaak‑overerving volgt.

Download [de voorbeeld‑presentatie](text-inheritance.pptx) en plaats deze in de werkmap van de applicatie. De eerste dia bevat één tekstvorm met de tekst “Inherited text; explicit red 18pt”. De invoer gebruikt bewust verschillende opmaakniveaus:

- De standaardtekststijl van de presentatie levert Calibri en een grootte van 28 pt.
- De eerste‑niveau‑tekststijl van het tekstkader levert blauwe tekst en cursief.
- De alinea stelt expliciet vetgedrukte tekst in.
- Het tweede deel, “explicit red 18pt”, stelt expliciet rode tekst en een grootte van 18 pt in.

Het volgende volledige voorbeeld exporteert dezelfde alinea’s drie keer. Het geeft [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) door aan de exportmethode en schrijft elk resultaat naar een apart UTF‑8‑HTML‑bestand:

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

De gegenereerde HTML bevat de volgende CSS voor het eerste deel, “Inherited text;”. De tabel somt de relevante declaraties; andere gegenereerde eigenschappen zijn weggelaten voor duidelijkheid.

| Output | Relevante CSS voor het eerste deel | Uiterlijk |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vette, cursieve tekst van 28 pt in Calibri, indien dat lettertype beschikbaar is. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauwe, vette, cursieve tekst; de omringende pagina of browser levert lettertypefamilie en grootte. |
| `ParagraphOnly.html` | `font-weight:bold` | Vette tekst; de omringende pagina of browser levert lettertypefamilie, grootte, kleur en cursieve stijl. |

Het tweede deel behoudt `color:#ff0000`, `font-size:18pt` en `font-weight:bold` in alle drie de uitvoerbestanden. Het behoudt ook cursief in `All` en `TextBox`, maar niet in `ParagraphOnly`. Het beperken van overerving verwijdert dus niet de expliciet toegewezen opmaak aan een alinea of deel.

Open de bestanden in dezelfde browser om ze te vergelijken. In de twee beperkte modi worden weggelaten CSS‑eigenschappen opgelost door de stijlen van de bestemmingspagina of de standaardinstellingen van de browser, waardoor het uiteindelijke uiterlijk afhangt van de plaats waar de HTML wordt gebruikt.

### **Een alinea als afbeelding renderen**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) rendert een individuele alinea rechtstreeks en retourneert een [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Sla het resultaat op in een bestand of stream met [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). U hoeft de omvattende vorm niet te renderen of handmatig een bitmap bij te snijden.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) kan `null` retourneren als de alinea niet in de bovenliggende collectie voorkomt, geen geldige render‑bounds heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een alinea renderen op de standaard schaal**

Het voorbeeld gebruikt een presentatie met één dia waarvan de eerste vorm een tekstvak is met drie alinea’s.

![The text box with three paragraphs](paragraph_to_image_input.png)

Het volgende voorbeeld selecteert de tweede alinea op index 1 en roept [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) aan zonder schaal‑parameters. Het controleert dat de vorm de vereiste alinea bevat en dat het renderen een afbeelding oplevert voordat [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) wordt aangeroepen om deze als PNG op te slaan. De `using`‑verklaring maakt de afbeelding na gebruik schoon.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Een alinea in een tabelcel renderen met schaal**

Gebruik de overload van [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) die de parameters `float scaleX` en `float scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op dubbele breedte en hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer het dubbele zijn van de standaardafmetingen, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor inzoomen of hoge‑resolutie‑output, maar verhogen ook het geheugen‑ en bestandsgrootteverbruik. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de aspect‑ratio van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding van alleen de alinea, gebruik [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kan ik het automatisch omschakelen binnen een tekstkader volledig uitschakelen?**

Ja. Stel [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) in om omschakeling uit te schakelen zodat regels niet breken aan de randen van het tekstkader.

**Hoe krijg ik de exacte on‑dia‑afmetingen van een specifieke alinea?**

Gebruik [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) om de omhullende rechthoek van de alinea op te halen. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) geeft de afmetingen van een individueel deel.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) beheerd?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) is een alinea‑niveau‑instelling en wordt toegepast op de volledige alinea ongeacht de opmaak van individuele delen.

Om verschillende lettergroottes binnen elke regel verticaal uit te lijnen, zie [Align Fonts Within a Line](/slides/nl/net/text-formatting/#align-fonts-within-a-line).

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) in voor individuele delen, zodat één alinea tekst in meerdere talen kan bevatten.