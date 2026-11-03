---
title: Beheer presentatie-placeholders in .NET
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/net/manage-placeholder/
keywords:
- plaatsvervanger
- tekst-placeholder
- afbeelding-placeholder
- grafiek-placeholder
- inhoud-placeholder
- prompt-tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u tekst-, afbeelding-, grafiek- en inhoud-placeholders kunt inspecteren en bewerken en de erfenis van placeholders kunt begrijpen met Aspose.Slides voor .NET."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel‑, hoofdtekst‑, afbeelding‑, diagram‑ en algemene content‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑outdia of master‑dia.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de eigenschap [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). De eigenschap retourneert een [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) object of `null` voor een normale vorm. Gebruik [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) om te bepalen welke inhoud de placeholder moet bevatten.

De vorm‑interface blijft relevant nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of content‑placeholder wordt meestal weergegeven door een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Een gevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Een content‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) als de runtime‑vorm‑interface in plaats van ervan uit te gaan dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat je tekst-, afbeelding-, diagram‑, tabel‑ of mediaspecifieke leden benadert.
{{% /alert %}}

## **Begrijp de erfenis van placeholders**

Placeholders vormen een hiërarchie:

1. Een masterslide definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een layoutslide definieert de indeling die wordt gebruikt door één of meer normale slides en kan van de master erven.
3. Een normale slide bevat de placeholders voor die slide en kan van de lay‑out erven.

Roep [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) aan om een niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst weer van placeholders op de eerste slide en rapporteert hun basis‑placeholders:

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

Het bewerken van een placeholder op een normale slide maakt een lokale overschrijving voor die slide aan of wijzigt deze. Het bewerken van de gerelateerde layout of master kan alle slides beïnvloeden die die instelling nog steeds erven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat ze dezelfde coördinaten inneemt.

## **Placeholder‑status verwijderen**

Wanneer je een sjabloon aanpast, gebruik je [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) om een bestaand object als een gewone vorm te behouden. Zijn [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) eigenschap wordt `null`, maar de vorm blijft in de collectie van de slide. In contrasteert [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) verwijdert de vorm uit die collectie.

Het volgende voorbeeld vereist `template.pptx` met minstens één slide en een niet‑lege tekst‑placeholder op de eerste slide. Gebruik een placeholder met opmaak die is geërfd vanuit de layout of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert of dezelfde vorm behouden blijft, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op.

{{% alert color="warning" title="Warning" %}}
Het verwijderen van de placeholder‑status behoudt niet automatisch de geërfde weergave‑instellingen. Het onderstaande voorbeeld laat die instellingen bewust onveranderd, waardoor de uitvoer er anders uit kan zien. Een vorm waarvan positie en grootte volledig geërfd zijn, kan na de aanroep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, hoewel hij nog steeds in de collectie staat.
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

    // Het aanroepen van de methode op een gewone vorm heeft geen effect.
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

Voor een overeenkomende placeholder geven alle drie de controles `True` terug. De tekst blijft behouden, maar geërfde positie, grootte, rotatie, lettertype, alinea‑uitlijning, marges van het tekstkader, verticale verankering, opvulling‑ en lijneigenschappen kunnen wijzigen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld, geërfde titelopmaak kan terugvallen op gewone tekstopmaak. Zie [Dia-indeling](/slides/nl/net/slide-layout/) voor meer informatie over lay‑outs.

Om de beoogde weergave te behouden, leg je de berekende positie, grootte en rotatie vast vóór de aanroep, en kopieer je de benodigde effectieve opmaakwaarden naar aparte variabelen. Haal die waarden op via [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), en [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Vertrouw niet alleen op de effectieve‑formatobjecten, omdat hun tekst‑opmaakwaarden kunnen veranderen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertype‑familie, grootte, stijl, kleur, alinea‑instellingen, tekstkader‑instellingen, opvulling en lijn die in je sjabloon worden gebruikt.

Geërfde vorm‑geometrie moet mogelijk ook expliciet worden toegewezen via [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); alleen de opvulling en lijn herstellen kan de zichtbare rechthoek niet herstellen. Sjablonen met extra effecten of complexere opmaak vereisen dat die instellingen ook worden verwerkt.

## **Tekst in een Placeholder wijzigen**

Titel‑, gecentreerde‑titel‑, ondertitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) voordat je de [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) eigenschap gebruikt.

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

Dit patroon voorkomt het casten van afbeelding‑, diagram‑, tabel‑ of media‑placeholders naar [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Het identificeert de placeholder bovendien op basis van doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompt‑tekst instellen op een layout**

Prompt‑tekst is de ontwerpinstructie die wordt weergegeven in een lege placeholder, zoals *Click to add title*. Stel aangepaste prompt‑tekst in op de layout‑placeholder in plaats van te proberen deze via de vorm‑collectie van een normale slide te benaderen. Benader de layout via [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) en doorloop [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

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

Prompt‑tekst is geen gewone slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsprogramma’s zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt bovendien niet de bestaande tekst op slides die de layout gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen om te behandelen:

- Als de afbeelding‑placeholder al gevuld is en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), vervang dan de afbeelding via [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) en [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Als het nog een lege placeholder is, voeg dan een afbeeldingsframe toe op de coördinaten van de placeholder met [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) en verwijder de lege placeholder.

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

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal afbeeldingsframe, geen nieuwe placeholder, omdat [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) alleen‑lezen is. Het behoudt de gereserveerde positie maar erft niet meer het placeholder‑specifieke gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint in, en werk daarna het resulterende [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) bij met Aspose.Slides.

Zie [Afbeeldingsframes beheren](/slides/nl/net/picture-frame/) voor beeldtransparantie, bijsnijden en andere afbeelding‑specifieke effecten. Deze bewerkingen behoren tot het afbeeldingsframe of de afbeelding‑opvulling, niet tot placeholder‑metadata.

## **Werken met diagram‑ en content‑placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Dit voorbeeld vindt zo’n diagram op basis van zowel placeholder‑type als runtime‑interface, wijzigt de titel en slaat het bestand op:

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

Een algemene content‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). In PowerPoint fungeert deze als een lanceerder voor diverse inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat deze is gevuld, inspecteer je de daadwerkelijke vorm‑interface om te achterhalen wat het bevat. Gespecialiseerde lay‑outs kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) blootstellen.

Aspose.Slides converteert een lege [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) placeholder niet naar een [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) alleen door [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) te wijzigen; het type is alleen‑lezen. Om een leeg diagram of content‑gebied programmatically te vullen, voeg je het vereiste object toe op de coördinaten van de placeholder en verwijder je daarna de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:

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

Het toegevoegde diagram is een gewone lokale chart. Het vult het gebied van de placeholder maar erft niet van de layout‑placeholder. Gebruik de specifieke [chart‑beheerartikelen](/slides/nl/net/powerpoint-charts/) wanneer je de categorieën, series of workbook‑gegevens moet vervangen.

## **Volledig voorbeeld: Tekst‑ of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end‑voorbeeld opent een sjabloon, zoekt op de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de juiste inhoud bij en slaat de uitvoer op. Het voorbeeld vermijdt opzettelijk het aannemen van een vorm‑index of het casten van elke placeholder naar dezelfde interface.

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

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een layout‑placeholder te bewerken?**

Je kunt de geërfde opmaak of prompt‑tekst via een layout aanpassen, maar bestaande titelinhoud wordt opgeslagen op de normale slides. Om de werkelijke titeltekst in een hele presentatie te vervangen, loop je over de slides en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste slide‑, layout‑, master‑, notitie‑ of handout‑niveau. Zie [Presentatie‑header en -footer beheren](/slides/nl/net/presentation-header-and-footer/) voor volledige voorbeelden.