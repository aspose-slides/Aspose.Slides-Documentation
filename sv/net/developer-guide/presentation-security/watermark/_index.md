---
title: Lägg till vattenstämplar i presentationer i .NET
linktitle: Vattenstämpel
type: docs
weight: 40
url: /sv/net/watermark/
keywords:
- vattenstämpel
- textvattenstämpel
- bildvattenstämpel
- lägg till vattenstämpel
- ändra vattenstämpel
- ta bort vattenstämpel
- radera vattenstämpel
- lägg till vattenstämpel i PPT
- lägg till vattenstämpel i PPTX
- lägg till vattenstämpel i ODP
- ta bort vattenstämpel från PPT
- ta bort vattenstämpel från PPTX
- ta bort vattenstämpel från ODP
- radera vattenstämpel från PPT
- radera vattenstämpel från PPTX
- radera vattenstämpel från ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera text- och bildvattenstämplar i PowerPoint- och OpenDocument-presentationer i .NET för att ange ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenstämpel** i en presentation är en text‑ eller bildstämpel som används på en bild eller genom alla presentationsbilder. Vanligtvis används ett vattenstämpel för att ange att presentationen är ett utkast (t.ex. ett ”Utkast”-vattenstämpel), att den innehåller konfidentiell information (t.ex. ett ”Konfidentiellt”-vattenstämpel), för att specificera vilket företag den tillhör (t.ex. ett ”Företagsnamn”-vattenstämpel), för att identifiera författaren till presentationen osv. Ett vattenstämpel hjälper till att förhindra upphovsrättsintrång genom att indikera att presentationen inte bör kopieras. Vattenstämplar används både i PowerPoint‑ och OpenDocument‑presentationsformat. I Aspose.Slides kan du lägga till ett vattenstämpel i PowerPoint‑PPT, PPTX och OpenDocument‑ODP‑filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/net/), finns det flera sätt att skapa vattenstämplar i PowerPoint‑ eller OpenDocument‑dokument och att ändra deras design och beteende. Det gemensamma är att för att lägga till textvattenstämplar bör du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), och för att lägga till bildvattenstämplar, använda klassen [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/) eller fylla en vattenstämpelform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape) och gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape)‑objekt.

Det finns två sätt att tillämpa ett vattenstämpel: på en enskild bild eller på alla presentationsbilder. Bild‑mastern används för att applicera ett vattenstämpel på alla presentationsbilder — vattenstämpeln läggs till i Bild‑mastern, designas där fullständigt och appliceras på alla bilder utan att påverka möjligheten att ändra vattenstämpeln på enskilda bilder.

Ett vattenstämpel anses normalt vara otillgängligt för redigering av andra användare. För att förhindra att vattenstämpeln (eller snarare dess föräldraform) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en normal bild eller på en Bild‑master. När vattenstämpelformen låses på Bild‑mastern, låses den på alla presentationsbilder.

Du kan ange ett namn för vattenstämpeln så att du i framtiden, om du vill ta bort den, kan hitta den bland bildens former via namn.

Du kan designa vattenstämpeln på vilket sätt som helst; vanligtvis har vattenstämplar dock gemensamma egenskaper såsom centrering, rotation, placering framåt osv. Vi kommer att gå igenom hur man använder dessa i exemplen nedan.

## **Textvattenstämpel**

### **Lägg till ett textvattenstämpel på en bild**

För att lägga till ett textvattenstämpel i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram i den formen. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe). Denna typ är inte ärvd från [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/), som har ett brett urval av egenskaper för att placera vattenstämpeln på ett flexibelt sätt. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe)-objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)-objekt. För att lägga till vattenstämpeltext till formen, använd metoden [AddTextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/methods/addtextframe) som visas nedan.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Lägg till vattenstämpeln på bilden.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Se också" %}} 
- [Hur man använder TextFrame‑klassen?](/slides/sv/net/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenstämpel i en presentation**

Om du vill lägga till ett textvattenstämpel i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenstämpel på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)-objekt och lägg sedan till vattenstämpeln i det med hjälp av metoden [AddTextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Lägg till vattenstämpeln på masterbilden.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Se också" %}} 
- [Hur man använder Bild‑mastern?](/slides/sv/net/slide-master/)
{{% /alert %}}

### **Ställ in transparens för vattenstämpelform**

Som standard är rektangelformen formaterad med fyllnings‑ och linjefärger. Detta innebär att när vattenstämpeln läggs till kan den visas med en solid bakgrund eller kant som potentiellt distraherar från bildens innehåll. För att säkerställa att vattenstämpeln förblir subtil och inte stör presentationens visuella design kan du göra formen helt transparent.

Följande kodrad gör formen transparent genom att ta bort både dess fyllnings‑ och kantfärger:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Ställ in teckensnitt för ett textvattenstämpel**

Innan du applicerar textvattenstämpeln på din bild är det viktigt att anpassa dess utseende så att det harmoniserar med den övergripande designen. Du kan ändra teckensnittstyp och storlek för att säkerställa att vattenstämpeln är både läsbar och estetiskt tilltalande. Anpassning av teckensnittet kan också hjälpa till att förstärka varumärkesidentiteten eller helt enkelt matcha presentationsstilen.

Kodsnutten nedan visar hur du justerar vattenstämpelns teckensnittsinställningar genom att välja ett specifikt latinskt teckensnitt och ange en lämplig teckenhöjd:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Ställ in färg för vattenstämpeltext**

Innan du applicerar ditt vattenstämpel är det nödvändigt att se till att textfärgen är korrekt inställd så att den smälter in med bildens innehåll utan att dominera. Att justera färgens transparens (alpha) tillsammans med de röda, gröna och blå komponenterna gör att du kan skapa ett subtilt, halvt transparent vattenstämpel som är synligt men ändå diskret. Detta tillvägagångssätt hjälper till att behålla fokus på din huvudpresentation samtidigt som ditt innehåll skyddas.

För att ställa in färgen på vattenstämpeltexten, använd följande kod:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrera ett textvattenstämpel**

Att centrera ditt textvattenstämpel på rätt sätt kan avsevärt förbättra presentationens övergripande estetik genom att säkerställa att vattenstämpeln är symmetriskt placerad, oavsett bildens dimensioner. Detta ger dina bilder ett professionellt intryck och ser till att vattenstämpeln inte stör bildens huvudinnehåll.

Kodsnutten nedan demonstrerar hur du beräknar bildens mittposition och placerar textvattenstämpeln därefter:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Bilden nedan visar slutresultatet.

![The text watermark](text_watermark.png)

## **Bildvattenstämpel**

### **Lägg till ett bildvattenstämpel i en presentation**

I många fall kan ett bildvattenstämpel erbjuda ett unikt varumärkesinslag eller ett mer visuellt tilltalande alternativ till ett textvattenstämpel. Innan du lägger till vattenstämpeln, se till att bildfilen är tillgänglig (t.ex. PNG för transparens). Följande exempel visar hur du läser in en bild från ditt filsystem, lägger till den i presentationen och sedan applicerar den som vattenstämpel via formens fyllningsegenskaper.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Lås ett vattenstämpel mot redigering**

Om det är nödvändigt att förhindra att ett vattenstämpel redigeras, använd egenskapen [IAutoShape.ShapeLock](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/properties/shapelock) på formen. Med denna egenskap kan du skydda formen från att väljas, storleksändras, flyttas, grupperas med andra element, låsa dess text mot redigering och mycket mer:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Lås vattenstämpelformen så att den inte kan ändras.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Flytta ett vattenstämpel framåt**

I Aspose.Slides kan Z‑ordningen för former sättas via metoden [IShapeCollection.Reorder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/reorder/#reorder). För att göra detta anropas metoden från presentationsbildernas lista och formreferensen samt dess ordningsnummer skickas in i metoden. På så sätt är det möjligt att föra en form framåt eller skicka den bakåt på bilden. Detta är särskilt användbart om du behöver placera ett vattenstämpel framför presentationen:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Ställ in rotation för vattenstämpel**

Att justera rotationen av ditt vattenstämpel kan avsevärt förbättra den visuella påverkan och subtiliteten i din presentation. Ett diagonalt vattenstämpel, till exempel, kan vara mindre påträngande men ändå ge starkt skydd mot obehörig användning. Följande exempel beräknar lämplig vinkel baserat på bildens dimensioner så att vattenstämpeln placeras diagonalt över bilden. Denna dynamiska beräkning säkerställer att vattenstämpeln förblir effektiv oavsett varierande bildstorlekar.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Ange ett namn för ett vattenstämpel**

Aspose.Slides låter dig ange ett namn för en form. Genom att använda formens namn kan du i framtiden komma åt den för att modifiera eller ta bort den. För att ange namn på vattenstämpelformen, tilldela den till egenskapen [IAutoShape.Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Ta bort ett vattenstämpel**

För att ta bort vattenstämpelformen, använd egenskapen [IAutoShape.Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/name) för att hitta den i bildens former. Passa sedan in vattenstämpelformen i metoden [IShapeCollection.Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/remove/):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Ett levande exempel**

Du kan prova de kostnadsfria Aspose.Slides‑verktygen **Add Watermark** och **Remove Watermark** online:

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### Vad är ett vattenstämpel och varför bör jag använda det?

Ett vattenstämpel är ett text‑ eller bildöverlägg som appliceras på bilder och hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

### Kan jag lägga till ett vattenstämpel på alla bilder i en presentation?

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenstämpel på varje bild i en presentation. Du kan iterera genom alla bilder och applicera vattenstämpelinställningarna individuellt.

### Hur kan jag justera transparensen för vattenstämpeln?

Du kan justera transparensen för vattenstämpeln genom att ändra fyllningsinställningarna ([FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/fillformat/)) för formen. Detta säkerställer att vattenstämpeln är subtil och inte distraherar från bildens innehåll.

### Vilka bildformat stöds för vattenstämplar?

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG och fler.

### Kan jag anpassa teckensnitt och stil för ett textvattenstämpel?

Ja, du kan välja vilket teckensnitt, storlek och stil som helst för att matcha din presentations design och upprätthålla varumärkeskonsekvens.

### Hur ändrar jag position eller orientering för ett vattenstämpel?

Du kan justera position och orientering för vattenstämpeln programatiskt genom att ändra formens koordinater, storlek och rotationsegenskaper.