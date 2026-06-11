---
title: Lägg till vattenmärken i presentationer i .NET
linktitle: Vattenmärke
type: docs
weight: 40
url: /sv/net/watermark/
keywords:
- vattenmärke
- textvattenmärke
- bildvattenmärke
- lägg till vattenmärke
- ändra vattenmärke
- ta bort vattenmärke
- radera vattenmärke
- lägg till vattenmärke i PPT
- lägg till vattenmärke i PPTX
- lägg till vattenmärke i ODP
- ta bort vattenmärke från PPT
- ta bort vattenmärke från PPTX
- ta bort vattenmärke från ODP
- radera vattenmärke från PPT
- radera vattenmärke från PPTX
- radera vattenmärke från ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera text- och bildvattenmärken i PowerPoint- och OpenDocument-presentationer i .NET för att ange ett utkast, konfidentiell information, upphovsrätt med mera."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är ett text‑ eller bildstämpel som används på en bild eller genom alla presentationsbilder. Vanligtvis används ett vattenmärke för att indikera att presentationen är ett utkast (t.ex. ett “Draft”-vattenmärke), att den innehåller konfidentiell information (t.ex. ett “Confidential”-vattenmärke), för att ange vilket företag den tillhör (t.ex. ett “Company Name”-vattenmärke), för att identifiera presentationens författare osv. Ett vattenmärke hjälper till att förhindra upphovsrättsbrott genom att visa att presentationen inte får kopieras. Vattenmärken används både i PowerPoint‑ och OpenDocument‑presentationsformat. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint‑filerna PPT, PPTX och OpenDocument‑filformatet ODP.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/net/) finns olika sätt att skapa vattenmärken i PowerPoint‑ eller OpenDocument‑dokument och ändra deras design och beteende. Den gemensamma faktorn är att för att lägga till textvattenmärken bör du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), och för att lägga till bildvattenmärken, använda klassen [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/) eller fylla en vattenmärkesform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape) vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, kapslas den in i ett [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape)-objekt.

Det finns två sätt att applicera ett vattenmärke: på en enskild bild eller på alla presentationsbilder. Slide Master används för att applicera ett vattenmärke på alla presentationsbilder — vattenmärket läggs till i Slide Master, designas helt där och tillämpas på alla bilder utan att påverka möjligheten att ändra vattenmärket på enskilda bilder.

Ett vattenmärke anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare vattenmärkets föräldraform) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en vanlig bild eller på en Slide Master. När vattenmärkesformen är låst på Slide Master låses den på alla presentationsbilder.

Du kan sätta ett namn på vattenmärket så att du i framtiden, om du vill ta bort det, kan hitta det bland bildens former efter namn.

Du kan utforma vattenmärket på vilket sätt som helst; dock finns det vanligtvis vanliga egenskaper i vattenmärken, såsom centrerad justering, rotation, position framåt osv. Vi kommer att gå igenom hur man använder dessa i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en form på bilden, sedan lägga till en textram på denna form. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe). Denna typ är inte ärvd från [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/), som har ett brett set av egenskaper för att positionera vattenmärket på ett flexibelt sätt. Därför kapslas [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe)-objektet in i ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)-objekt. För att lägga till vattenmärketext på formen, använd metoden [AddTextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/methods/addtextframe) som visas nedan.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Lägg till vattenmärket på sliden.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Se också" %}} 
- [Hur använder man TextFrame-klassen?](/slides/sv/net/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång) lägger du till det i [MasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)-objekt och lägg sedan till vattenmärket på det med metoden [AddTextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Lägg till vattenmärket på master-sliden.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Se också" %}} 
- [Hur använder man Slide Master?](/slides/sv/net/slide-master/)
{{% /alert %}}

### **Ställ in vattenmärkets formtransparenthet**

Som standard är rektangelformen formaterad med fyllnings‑ och linjefärger. Detta innebär att när vattenmärket läggs till kan det visas med en solid bakgrund eller ram som potentiellt kan distrahera från bildens innehåll. För att säkerställa att vattenmärket förblir subtilt och inte stör presentationens visuella design kan du göra formen helt genomskinlig.

Följande kodrader gör formen genomskinlig genom att ta bort både dess fyllnings‑ och ramfärger:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Ställ in teckensnittet för ett textvattenmärke**

Innan du applicerar textvattenmärket på din bild är det viktigt att anpassa dess utseende så att det harmoniserar med den övergripande designen. Du kan ändra teckensnittstyp och storlek för att säkerställa att vattenmärket både är läsbart och estetiskt tilltalande. Att anpassa teckensnittet kan även hjälpa till att stärka varumärkesidentiteten eller helt enkelt matcha presentationens stil.

Kodsnutten nedan visar hur du justerar vattenmärkets teckensnittinställningar genom att välja ett specifikt latinskt teckensnitt och sätta en lämplig teckenhöjd:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Ställ in textfärgen för vattenmärket**

Innan du applicerar ditt vattenmärke är det viktigt att säkerställa att textfärgen är rätt inställd så att den smälter väl in med bildens innehåll utan att dominera. Genom att justera färgtransparenten (alpha) samt de röda, gröna och blå komponenterna kan du skapa ett subtilt, halvgenomskinligt vattenmärke som är synligt men ändå diskret. Detta tillvägagångssätt hjälper till att behålla fokus på din huvudpresentation samtidigt som ditt innehåll skyddas.

För att sätta färgen på vattenmärketexten, använd följande kod:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrera ett textvattenmärke**

Att korrekt centrera ditt textvattenmärke kan avsevärt förbättra den övergripande estetiken i din presentation genom att säkerställa att vattenmärket är symmetriskt placerat, oavsett bildens dimensioner. Detta tillvägagångssätt ger dina bilder ett professionellt utseende och säkerställer samtidigt att vattenmärket inte stör bildens huvudinnehåll.

Kodsnutten nedan visar hur du beräknar bildens mittposition och placerar textvattenmärket därefter:

```cs
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

![Textvattenmärket](text_watermark.png)

## **Bildvattenmärke**

### **Lägg till ett bildvattenmärke i en presentation**

I många fall kan ett bildvattenmärke ge ett unikt varumärkeselement eller ett mer visuellt tilltalande alternativ till ett textvattenmärke. Innan du lägger till vattenmärket, se till att bildfilen är tillgänglig (t.ex. PNG för transparens). Följande exempel visar hur du laddar en bild från ditt filsystem, lägger till den i presentationen och sedan använder den som vattenmärke via formens fyllningsegenskaper.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Lås ett vattenmärke från redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras, använd egenskapen [IAutoShape.ShapeLock](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/properties/shapelock) på formen. Med denna egenskap kan du skydda formen från att väljas, ändras i storlek, flyttas, grupperas med andra element, låsa dess text från redigering och mycket mer:

```cs
// Lås vattenmärkesformen från att ändras.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Flytta ett vattenmärke framåt**

I Aspose.Slides kan Z‑ordningen för former sättas via metoden [IShapeCollection.Reorder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/reorder/#reorder). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka formens referens samt dess ordningsnummer till metoden. På så sätt kan du flytta en form framåt eller skicka den bakåt i bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför presentationen:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Ställ in vattenmärkets rotation**

Att justera rotationen av ditt vattenmärke kan avsevärt förbättra den visuella påverkan och subtiliteten i din presentation. Ett diagonalt vattenmärke kan till exempel vara mindre påträngande samtidigt som det ger ett starkt skydd mot otillåten användning. Följande exempel beräknar rätt vinkel baserat på bildens dimensioner så att vattenmärket placeras diagonalt över bilden. Denna dynamiska beräkning säkerställer att vattenmärket förblir effektivt oavsett varierande bildstorlekar.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Ange ett namn för ett vattenmärke**

Aspose.Slides låter dig ange ett namn för en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namn på vattenmärkesformen, tilldela den egenskapen [IAutoShape.Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Ta bort ett vattenmärke**

För att ta bort vattenmärkesformen, använd egenskapen [IAutoShape.Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/name) för att hitta den bland bildens former. Därefter skickar du vattenmärkesformen till metoden [IShapeCollection.Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/remove/):

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Live‑exempel**

Du kanske vill testa de **gratis Aspose.Slides**‑verktygen [Lägg till vattenmärke](https://products.aspose.app/slides/sv/watermark) och [Ta bort vattenmärke](https://products.aspose.app/slides/sv/watermark/remove-watermark) online.

![Online‑verktyg för att lägga till och ta bort vattenmärken](online_tools.png)

## **FAQ**

**Vad är ett vattenmärke och varför ska jag använda det?**

Ett vattenmärke är en text‑ eller bildövertäckning som appliceras på bilder och hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra otillåten användning av presentationer.

**Kan jag lägga till ett vattenmärke på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera igenom alla bilder och applicera vattenmärkesinställningarna individuellt.

**Hur kan jag justera transparensen för vattenmärket?**

Du kan justera vattenmärkets transparens genom att ändra fyllningsinställningarna ([FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/fillformat/)) för formen. Detta säkerställer att vattenmärket är subtilt och inte distraherar från bildens innehåll.

**Vilka bildformat stöds för vattenmärken?**

Aspose.Slides stödjer olika bildformat som PNG, JPEG, GIF, BMP, SVG med mera.

**Kan jag anpassa teckensnittet och stilen för ett textvattenmärke?**

Ja, du kan välja valfritt teckensnitt, storlek och stil för att matcha designen av din presentation och upprätthålla varumärkeskonsekvens.

**Hur ändrar jag positionen eller orienteringen av ett vattenmärke?**

Du kan programatiskt justera position och orientering av vattenmärket genom att ändra formens koordinater, storlek och rotationsegenskaper.