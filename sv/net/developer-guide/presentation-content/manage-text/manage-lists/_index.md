---
title: Hantera punkt- och numrerade listor i presentationer i .NET
linktitle: Hantera listor
type: docs
weight: 70
url: /sv/net/manage-lists/
keywords:
- punkt
- punktlista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägg till punkt
- lägg till lista
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punkt-, bild-, flernivå- och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides för .NET låter dig skapa och formatera punkt- och numrerade listor i PowerPoint- och OpenDocument-presentationer. Ett listobjekt är ett stycke vars punktegenskaper styrs via dess styckeformat.

Använd egenskapen [IParagraph.ParagraphFormat] för att komma åt listinställningar på styckennivå. Huvudingången är [IParagraphFormat.Bullet], som returnerar ett [IBulletFormat]-objekt. Med detta objekt kan du ställa in punkttyp, symbol, bild, färg, storlek, numreringsstil och startnummer.

Denna artikel visar hur du:

- skapar en punktlista med en anpassad symbol
- skapar en bildpunkt
- skapar en flernivålista genom att ange styckets djup
- skapar en numrerad lista
- inspekterar och ändrar listformatering i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [IParagraph]-objekt i ett [ITextFrame] och sätt [IBulletFormat.Type] till [BulletType.Symbol]. Du kan sedan sätta [IBulletFormat.Char], [IBulletFormat.Color] och [IBulletFormat.Height] för att styra punktens utseende.

Följande C#-kod demonstrerar hur man skapar en punktlista i en bild:

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

Resultatet:

![Symbolpunkterna](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningen på objekten är viktig. Sätt [IBulletFormat.Type] till [BulletType.Numbered]. Du kan också välja ett nummerformat med [IBulletFormat.NumberedBulletStyle] eller sätta [IBulletFormat.NumberedBulletStartWith] när listan ska starta från ett annat värde än 1.

Följande C#-kod visar hur man skapar en numrerad lista i en bild:

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

Resultatet:

![De numrerade punkterna](numbered_bullets.png)

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punkt med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, till exempel ikoner eller små transparenta PNG-filer.

{{% alert color="primary" %}}
Idealiskt, om du planerar att ersätta den vanliga punkt-symbolen med en bild, är det bäst att välja en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade punktsymboler.

Kom ihåg att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir tydlig och visuellt effektiv när den används som punkt i en lista.
{{% /alert %}}

För att skapa en bildpunkt, lägg till en bild i [Presentation.Images] och tilldela det returnerade bildobjektet till [IBulletFormat.Picture]. Sätt [IBulletFormat.Type] till [BulletType.Picture] innan du tilldelar bilden.

Låt oss säga att vi har en "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande C#-kod visar hur man skapar bildpunkter i en bild:

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

Resultatet:

![Bildpunkterna](picture_bullets.png)

## **Skapa en flernivålista**

Använd [IParagraphFormat.Depth] för att placera listobjekt på olika nivåer. Nivå 0 är den översta nivån, nivå 1 är nästlad under den, och så vidare.

Följande C#-kod visar hur man skapar en flernivå punktlista:

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

Resultatet:

![Flernivålistan](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, hämta målstycket och uppdatera dess [IParagraphFormat.Bullet]-inställningar. Samma egenskaper som används för att skapa listor kan också användas för att inspektera eller ändra listor som lästs in från en PPT-, PPTX- eller ODP-fil.

Följande C#-kod ändrar det första stycket i en textram till att använda en numrerad liststil:

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

**Kan punkt- och numrerade listor exporteras till PDF eller bilder?**

Ja. Aspose.Slides bevarar listformatering när målformatet stöder motsvarande textlayout och punktfunktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Läs in presentationen, hämta målstycket, inspektera eller uppdatera dess [IParagraphFormat.Bullet]-inställningar och spara presentationen.

**Kan listor innehålla icke-latinsk text?**

Ja. Text i listobjekt kan innehålla Unicode-tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de teckensnitt som används i presentationen stöder de tecken du behöver.