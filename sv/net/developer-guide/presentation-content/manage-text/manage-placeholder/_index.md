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
- instruktionstext
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du granskar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår arv av platshållare med Aspose.Slides för .NET."
---
## **Översikt**

Ett platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och generella innehållsplatshållare. Till skillnad från en vanlig form kan ett platshållare ärva sin position, storlek, formatering och andra inställningar från en layout‑bild eller en master‑bild.

Aspose.Slides exponerar platshållarinformation via egenskapen [IShape.Placeholder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/placeholder/). Egenskapen returnerar ett [IPlaceholder](https://reference.aspose.com/slides/sv/net/aspose.slides/iplaceholder/)‑objekt eller `null` för en normal form. Använd [IPlaceholder.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/iplaceholder/type/) för att avgöra vad platshållaren är avsedd att innehålla.

Form‑gränssnittet är fortfarande relevant efter att du vet platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras vanligtvis av en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).
- En ifylld bild‑platshållare kan representeras av en [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/).
- En ifylld diagram‑platshållare kan representeras av en [IChart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [IPlaceholder.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/iplaceholder/type/) och den körning‑specifika form‑gränssnittet istället för att anta att varje platshållare är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Varning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/iplaceholder/type/) beskriver ett platshållares roll; den garanterar inte formens körning‑typ. Använd alltid en typkontroll innan du får åtkomst till text‑, bild‑, diagram‑, tabell‑ eller media‑specifika medlemmar.
{{% /alert %}}

## **Förstå arv av platshållare**

Platshållare bildar en hierarki:

1. En master‑bild definierar återanvändbara stilar och, i vissa fall, master‑nivå platshållare.
2. En layout‑bild definierar arrangementet som används av en eller flera vanliga bilder och kan ärva från master‑bilden.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från sin layout.

Anropa [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getbaseplaceholder/) för att gå ett nivå upp i hierarkin. En bild‑platshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin master‑platshållare. Metoden returnerar `null` när formen inte har någon bas‑platshållare.

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

Att redigera en platshållare på en vanlig bild skapar eller ändrar en lokal åsidosättning för den bilden. Att redigera den relaterade layout‑ eller master‑bilden kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen bas‑platshållare och börjar inte ärva bara för att den ligger på samma koordinater.

## **Ändra text i en platshållare**

Titel‑, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stöder normalt text. Kontrollera att formen är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) innan du använder dess [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/textframe/)-egenskap.

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

Detta mönster undviker att kasta bild‑, diagram‑, tabell‑ eller media‑platshållare till [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/). Det identifierar också platshållaren efter dess syfte istället för att förlita sig på ett bräckligt form‑index.

## **Ange introduktionstext på en layout**

Introduktionstext är design‑tidsinstruktionen som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ange anpassad introduktionstext på layout‑platshållaren i stället för att försöka nå den via en vanlig bilds form‑samling. Åtkomst till layouten sker via [ISlide.LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/layoutslide/) och iterera över [ILayoutSlide.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/shapes/).

Följande exempel ändrar titel‑ och undertitel‑introduktionstexterna på den layout som används av den första bilden:

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

Introduktionstext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram såsom PowerPoint. När en användare eller ett program levererar riktigt innehåll visas inte längre introduktionstexten. Att ändra en introduktionstext ersätter inte befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/), ersätt bilden via [IPictureFillFormat.Picture](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/picture/) och [ISlidesPicture.Image](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/image/).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addpictureframe/) och ta bort den tomma platshållaren.

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

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [IShape.Placeholder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/placeholder/) är skrivskyddad. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är avgörande att behålla relationen till platshållaren, förbered och fyll platshållaren i PowerPoint först, och uppdatera sedan den resulterande [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bild‑specifika effekter, se [Manage Picture Frames](/slides/sv/net/picture-frame/). Dessa operationer tillhör bildramen eller bild‑fyllningen, inte platshållarens metadata.

## **Arbeta med diagram‑ och innehållsplatshållare**

En ifylld diagram‑platshållare kan representeras av en [IChart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/). Detta exempel hittar ett sådant diagram både via platshållartyp och körning‑gränssnitt, ändrar dess titel och sparar filen:

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

En generell innehållsplatshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/sv/net/aspose.slides/placeholdertype/). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. När den har fyllts i, inspektera det faktiska form‑gränssnittet för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/sv/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/sv/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/sv/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/sv/net/aspose.slides/placeholdertype/), eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/sv/net/aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)‑platshållare till ett [IChart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/) bara genom att ändra [IPlaceholder.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/iplaceholder/type/); typen är skrivskyddad. För att programmässigt fylla ett tomt diagram‑ eller innehållsområde, lägg till det erforderliga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

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

Det tillagda diagrammet är ett ordinärt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/net/powerpoint-charts/) när du behöver ersätta kategorier, serier eller arbetsbok‑data.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande end‑to‑end‑exempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar lämpligt innehåll och sparar resultatet. Exemplet undviker medvetet att anta ett form‑index eller kasta varje platshållare till samma gränssnitt.

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

En bas‑platshållare är den motsvarande formen på layout‑ eller master‑nivå som en annan platshållare ärver från. Använd [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getbaseplaceholder/) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte är en del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller introduktionstext via en layout, men befintligt titelinnehåll lagras på de vanliga bilderna. För att ersätta den faktiska titeltexten i en hel presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bild‑nummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd sidhuvuds‑ och sidfots‑hanterarna på den aktuella bild‑, layout‑, master‑, antecknings‑ eller utdelningsnivån. Se [Manage Presentation Header and Footer](/slides/sv/net/presentation-header-and-footer/) för kompletta exempel.