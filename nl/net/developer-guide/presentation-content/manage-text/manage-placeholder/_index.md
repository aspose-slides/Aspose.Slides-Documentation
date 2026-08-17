---
title: Beheer presentatie‑placeholders in .NET
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/net/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeeldings‑placeholder
- grafiek‑placeholder
- inhouds‑placeholder
- prompt‑tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, grafiek‑ en inhouds‑placeholders kunt inspecteren en bewerken en de erfenis van placeholders kunt begrijpen met Aspose.Slides voor .NET."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, hoofdtekst, afbeelding, grafiek en algemene inhoudsplaceholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen overnemen van een layout‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [IShape.Placeholder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/placeholder/)‑eigenschap. De eigenschap geeft een [IPlaceholder](https://reference.aspose.com/slides/nl/net/aspose.slides/iplaceholder/)‑object terug of `null` voor een normale vorm. Gebruik [IPlaceholder.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/iplaceholder/type/) om te bepalen wat de placeholder zou moeten bevatten.

De vorm‑interface blijft relevant nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, grafiek‑ of inhoudsplaceholder wordt meestal weergegeven door een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/).
- Een ingevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/).
- Een ingevulde grafiek‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/).
- Een inhoudsplaceholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/iplaceholder/type/) als de runtime‑vorm‑interface in plaats van verondersteld dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Waarschuwing" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/iplaceholder/type/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een typetest vóór het benaderen van tekst-, afbeelding‑, grafiek‑, tabel‑ of media‑specifieke leden.
{{% /alert %}}

## **Begrijp Placeholder‑erfenis**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑niveau placeholders.
2. Een layout‑slide bepaalt de indeling die door één of meer normale slides wordt gebruikt en kan overerven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan overerven van de layout.

Roep [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/getbaseplaceholder/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder geeft normaal gesproken zijn layout‑placeholder terug; een layout‑placeholder kan zijn master‑placeholder teruggeven. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft de placeholders op de eerste slide weer en meldt hun basis‑placeholders:

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

Een placeholder op een normale slide bewerken maakt een lokale overschrijving voor die slide aan of wijzigt deze. Het bewerken van de gerelateerde layout of master kan alle slides beïnvloeden die die instelling nog erven. Een gewone lokale vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten bezet.

## **Tekst wijzigen in een Placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, hoofdtekst‑ en tekst‑placeholders ondersteunen normaal tekst. Controleer op een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) voordat je de [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/textframe/)‑eigenschap gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:

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

Dit patroon voorkomt het casten van afbeelding‑, grafiek‑, tabel‑ of media‑placeholders naar een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/). Het identificeert tevens de placeholder op basis van doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompttekst instellen op een lay‑out**

Prompttekst is de ontwerp‑tijd instructie die in een lege placeholder wordt weergegeven, zoals *Klik om een titel toe te voegen*. Stel aangepaste prompttekst in op de layout‑placeholder in plaats van via de vorm‑collectie van een normale slide te proberen. Benader de layout via [ISlide.LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/layoutslide/) en doorloop [ILayoutSlide.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/shapes/).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de layout die door de eerste slide wordt gebruikt:

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

Prompttekst maakt geen deel uit van de normale slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de layout gebruiken.

## **Afbeeldingsplaceholder bijwerken**

Er zijn twee gevallen te behandelen:

- Als de afbeelding‑placeholder al gevuld is en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/), vervang de afbeelding via [IPictureFillFormat.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/picture/) en [ISlidesPicture.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/image/).
- Als het nog een lege placeholder is, voeg een afbeelding‑frame toe op de coördinaten van de placeholder met [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addpictureframe/) en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

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

De vervanging die voor een lege placeholder wordt gecreëerd, is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [IShape.Placeholder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/placeholder/) alleen‑lezen is. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, prepareer en vul de placeholder eerst in PowerPoint, en werk daarna de resulterende [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) bij met Aspose.Slides.

Voor beeld‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/net/picture-frame/). Die bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑vulling, niet tot placeholder‑metadata.

## **Werken met grafiek‑ en inhoudsplaceholders**

Een ingevulde grafiek‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/). Dit voorbeeld vindt zo’n grafiek op basis van zowel placeholder‑type als runtime‑interface, wijzigt de titel en slaat het bestand op:

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

Een algemene inhoudsplaceholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/nl/net/aspose.slides/placeholdertype/). In PowerPoint fungeert het als een lanceer­mechanisme voor verschillende inhoudstypen, waaronder grafieken, tabellen, diagrammen, afbeeldingen en media. Nadat het is gevuld, inspecteer je de daadwerkelijke vorm‑interface om te ontdekken wat het bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/nl/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/nl/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/nl/net/aspose.slides/placeholdertype/), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/nl/net/aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides zet een lege [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) placeholder niet om in een [IChart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/) enkel door [IPlaceholder.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/iplaceholder/type/) te wijzigen; het type is alleen‑lezen. Om een lege grafiek‑ of inhouds‑zone programmatisch te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je vervolgens de lege placeholder. Het volgende voorbeeld doet dit voor een grafiek:

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

De toegevoegde grafiek is een gewone lokale grafiek. Hij bezet het gebied van de placeholder maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/net/powerpoint-charts/) wanneer je de categorieën, series of werkboek‑data moet vervangen.

## **Compleet voorbeeld: tekst of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt in de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de juiste inhoud bij en slaat de output op. Het voorbeeld vermijdt opzettelijk het aannemen van een vorm‑index of het casten van elke placeholder naar dezelfde interface.

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

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/getbaseplaceholder/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle titels van slides wijzigen door een layout‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompttekst via een layout wijzigen, maar bestaande titelinhoud is opgeslagen op de normale slides. Om de werkelijke titeltekst in een hele presentatie te vervangen, doorloop je de slides en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau (slide, layout, master, notities of handout). Zie [Manage Presentation Header and Footer](/slides/nl/net/presentation-header-and-footer/) voor volledige voorbeelden.