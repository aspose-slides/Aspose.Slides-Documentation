---
title: Hantera presentationsplatshållare i .NET
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/net/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- innehållsplatshållare
- prompttext
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du inspekterar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärv med Aspose.Slides för .NET."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och allmänna innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller en huvudbild.

Aspose.Slides exponerar platshållarinformation via egenskapen [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). Egenskapen returnerar ett [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/)‑objekt eller `null` för en normal form. Använd [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) för att avgöra vad platshållaren är avsedd att innehålla.

Formgränssnittet är fortfarande relevant efter att du känner till platshållartypen:

- En tom text-, bild-, diagram- eller innehållsplatshållare representeras vanligtvis av en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- En ifylld bildplatshållare kan representeras av en [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- En ifylld diagramplatshållare kan representeras av en [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) och runtime‑formgränssnittet istället för att anta att varje platshållare är en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) beskriver en platshållares roll; den garanterar inte formens runtime‑typ. Använd alltid en typkontroll innan du får åtkomst till text-, bild-, diagram-, tabell- eller mediaspecifika medlemmar.
{{% /alert %}}

## **Förstå platshållar‑arv**

Platshållare bildar en hierarki:

1. En huvudsida definierar återanvändbara stilar och, i vissa fall, platshållare på huvudnivå.
2. En layoutbild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från huvudsidan.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från sin layout.

Anropa [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) för att gå ett nivå upp i hierarkin. En bildplatshållare returnerar normalt sin layout‑platshållare; en layout‑plats­hållare kan returnera sin huvud‑platshållare. Metoden returnerar `null` när formen inte har någon bas‑platshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras bas‑platshållare:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Att redigera en platshållare på en vanlig bild skapar eller ändrar en lokal överskuggning för den bilden. Att redigera den relaterade layouten eller huvudsidan kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen bas‑platshållare och börjar inte ärva bara för att den ligger på samma koordinater.

## **Ta bort platshållarstatus**

När du anpassar en mall, använd [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) för att behålla ett befintligt objekt som en vanlig form. Dess [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/)‑egenskap blir `null`, men formen finns kvar i bildens samling. I kontrast tar [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) bort formen från den samlingen.

Följande exempel kräver `template.pptx` med minst en bild och en icke‑tom text‑platshållare på den första bilden. Använd en platshållare med formatering ärvd från dess layout eller huvud för att se effekten av att ta bort den relationen. Exemplet kontrollerar att samma form kvarstår, anropar metoden igen på den nu vanliga formen och sparar resultatet.

{{% alert color="warning" title="Warning" %}}
Att ta bort platshållarstatus bevarar inte automatiskt ärvda utseendeinställningar. Exemplet nedan lämnar medvetet dessa inställningar oförändrade, så resultatet kan se annorlunda ut. En form vars position och storlek är helt ärvda kan ha nollkoordinater och dimensioner efter anropet och bli osynlig även om den fortfarande finns i samlingen.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Att anropa metoden på en vanlig form har ingen effekt.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

För en matchande platshållare skriver alla tre kontroller ut `True`. Texten kvarstår, men ärvd position, storlek, rotation, teckensnitt, styckejustering, text‑ram‑marginaler, vertikal förankring, fyllnings‑ och linjeinställningar kan ändras när platshållarrelationen tas bort. Till exempel kan ärvd titelformatering falla tillbaka till vanlig textformatering. Se [Bildlayout](/slides/sv/net/slide-layout/) för mer om layouter.

För att bevara det avsedda utseendet, fånga den lösta positionen, storleken och rotationen innan anropet och kopiera de nödvändiga effektiva formateringsvärdena till separata variabler. Hämta dessa värden via [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), och [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Lita inte enbart på att behålla effektiva‑format‑objekt, eftersom deras textformateringsvärden kan förändras efter att relationen tagits bort. Tilldela uttryckligen de fångade värdena till den vanliga formen efteråt, inklusive teckensnittsfamilj, storlek, stil, färg, styckeinställningar, text‑ram‑inställningar, fyllning och linje som används i din mall.

Ärvd formgeometri kan också behöva tilldelas explicit via [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). För en rektangulär text‑platshållare betyder detta att tilldela [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); att bara återställa fyllning och linje kan misslyckas med att återge den synliga rektangeln. Mallar med ytterligare effekter eller mer komplex formatering kräver att dessa inställningar också hanteras som väl.

## **Ändra text i en platshållare**

Titel‑, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stödjer normalt text. Kontrollera [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) innan du använder dess [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/)‑egenskap.

Detta exempel uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Detta mönster undviker att kasta bild‑, diagram‑, tabell‑ eller mediaplatshållare till [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Det identifierar också platshållaren efter syfte istället för att förlita sig på ett ömtåligt form‑index.

## **Ange förinställd text på en layout**

Prompt‑text är den design‑tid‑instruktion som visas i en tom platshållare, till exempel *Klicka för att lägga till titel*. Ställ in anpassad prompt‑text på layout‑platshållaren snarare än att försöka nå den via en vanlig bilds form‑samling. Åtkomst till layouten sker via [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) och iterera över [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Följande exempel ändrar titel‑ och undertitel‑prompterna på den layout som används av den första bilden:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Prompt‑text är inte vanligt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller riktigt innehåll visas prompten inte längre. Att ändra en prompt ersätter inte heller befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), ersätt bilden via [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) och [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) och ta bort den tomma platshållaren.

Nästa exempel stödjer båda fallen och sparar presentationen:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) är skrivskyddad. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll i platshållaren i PowerPoint först och uppdatera sedan den resulterande [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Hantera bildramar](/slides/sv/net/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållarmetadata.

## **Arbeta med diagram‑ och innehållsplatshållare**

En ifylld diagram‑platshållare kan representeras av en [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Detta exempel hittar ett sådant diagram både via platshållartyp och runtime‑gränssnitt, ändrar dess titel och sparar filen:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

En allmän innehållsplatshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts i, inspektera det faktiska form‑gränssnittet för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)‑platshållare till en [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) enbart genom att ändra [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); typen är skrivskyddad. För att fylla ett tomt diagram‑ eller innehållsområde programatiskt, lägg till det erforderliga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [artiklarna om diagramhantering](/slides/sv/net/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsboksdata.

## **Komplett exempel: Uppdatera text‑ eller bildinnehåll**

Följande helhets­exempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar lämpligt innehåll och sparar resultatet. Exemplet undviker medvetet att anta ett form‑index eller kasta varje platshållare till samma gränssnitt.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Vad är en bas‑platshållare?**

En bas‑platshållare är den motsvarande formen på layouten eller huvudsidan som en annan platshållare ärver från. Använd [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte ingår i platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller prompt‑text via en layout, men befintligt titel­innehåll lagras på de vanliga bilderna. För att ersätta den faktiska titeltexten i en hel presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bildnummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd header‑ och footer‑hanterarna på lämplig bild, layout, huvud, anteckningar eller utdelnings‑omfång. Se [Hantera presentationens sidhuvud och sidfot](/slides/sv/net/presentation-header-and-footer/) för kompletta exempel.