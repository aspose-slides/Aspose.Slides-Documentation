---
title: Miniaturen van presentatievormen maken in .NET
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/net/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia’s met Aspose.Slides for .NET – maak en exporteer eenvoudig presentatieminiaturen."
---
## **Inleiding**

Aspose.Slides for .NET wordt gebruikt om presentatie‑bestanden te maken waarbij elke pagina een dia is. Deze dia’s kunnen bekeken worden door de presentatie‑bestanden te openen met Microsoft PowerPoint. Maar soms moeten ontwikkelaars de afbeeldingen van de vormen afzonderlijk bekijken in een afbeeldingsviewer. In dat geval helpt Aspose.Slides for .NET u miniatuurafbeeldingen van de dia‑vormen te genereren. Hoe u deze functie gebruikt wordt beschreven in dit artikel.
Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een miniatuur van een vorm binnen een dia genereren.
- Een miniatuur van een vorm van een dia met door de gebruiker gedefinieerde afmetingen genereren.
- Een miniatuur van een vorm binnen de grenzen van de weergave van een vorm genereren.

## **Miniatuur van een vorm uit een dia genereren**
Om een miniatuur van een vorm van een willekeurige dia te genereren met Aspose.Slides for .NET:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. Haal de miniatuurafbeelding van de vorm van de gerefereerde dia op met de standaard schaal.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

Het voorbeeld hieronder genereert een vormminiatuur.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Miniatuur met door gebruiker gedefinieerde schaalfactor genereren**
Om de miniatuur van een vorm van een willekeurige dia‑vorm te genereren met Aspose.Slides for .NET:

1. Maak een instantie van de `Presentation`‑klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. Haal de miniatuurafbeelding van de gerefereerde dia op met vorm‑grenzen.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

Het voorbeeld hieronder genereert een miniatuur met een door de gebruiker gedefinieerde schaalfactor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Schalen langs X- en Y-as.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Miniatuur van vormweergave op basis van grenzen maken**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vorm‑effecten meegenomen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een willekeurige dia‑vorm binnen de grenzen van de weergave te genereren, gebruikt u de volgende voorbeeldcode:

1. Maak een instantie van de `Presentation`‑klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. Haal de miniatuurafbeelding van de gerefereerde dia op met vorm‑grenzen als weergave.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

Het voorbeeld hieronder maakt een miniatuur door een miniatuur met een door de gebruiker gedefinieerde schaalfactor te genereren.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Schalen langs X- en Y-as.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Werkelijke visuele grenzen van een vorm ophalen**

De frame‑eigenschappen van [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) — zijn `X`, `Y`, `Width` en `Height`‑eigenschappen — beschrijven het rechthoekige gebied dat in het presentatiemodel is opgeslagen. De inhoud die werkelijk gerenderd wordt kan zich buiten dat frame uitstrekken of een ander, as‑georienteerd rechthoekig gebied innemen. Rotatie, contouren, pijlpuntjes, tekstindeling en -overflow, gegenereerde SmartArt‑geometrie, en andere rendering‑effecten kunnen het bezette gebied allemaal wijzigen.

Gebruik [GetVisualBounds](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getvisualbounds/) om dat bezette gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) in dia‑coördinaten. Het geretourneerde rechthoekige gebied wordt niet bijgesneden tot de dia, dus de coördinaten kunnen negatief zijn wanneer de inhoud zich buiten de oorsprong van de dia uitstrekt.

[GetVisualBounds](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getvisualbounds/) wordt momenteel niet gedeclareerd door de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) interface. Daarom moet u de vorm die uit de vormverzameling van de dia is verkregen, als een interface‑waarde behouden en pas casten wanneer u de methode aanroept.

Het volgende voorbeeld haalt en vergelijkt de frame‑ en visuele grenzen:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Dezelfde [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) kan worden gebruikt om naburige vormen uit te lijnen op zijn `Left`, `Right`, `Top` of `Bottom`‑rand; voldoende ruimte te reserveren in een gegenereerde lay‑out; of inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, geroteerde vormen en groep‑vormen, waarbij het opgeslagen frame mogelijk niet het volledige gerenderde resultaat weergeeft.

Gebruik [GetVisualBounds](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getvisualbounds/) wanneer u coördinaten nodig heeft voor lay‑out of validatie en geen bitmap nodig heeft. Gebruik [IShape.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/getimage/) wanneer u de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/net/aspose.slides/shapethumbnailbounds/) bepaalt `ShapeThumbnailBounds.Shape` de afbeelding op basis van de vorm‑grenzen, inclusief contourinstellingen, terwijl `ShapeThumbnailBounds.Appearance` de afbeelding bepaalt op basis van de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. Daarentegen retourneert [GetVisualBounds](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getvisualbounds/) alleen het berekende rechthoekige gebied en snijdt het niet bij tot de dia.

## **Veelgestelde vragen**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/), en andere. Vormen kunnen ook [geëxporteerd worden als vector‑SVG](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/net/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds gerenderd als een miniatuur?**

Een verborgen vorm blijft deel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt alleen de weergave tijdens de diavoorstelling, maar verhindert niet het genereren van de afbeelding van de vorm.

**Worden groep‑vormen, diagrammen, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de vereiste lettertypen leveren](/slides/nl/net/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/net/font-substitution/)) om ongewenste fallback‑lettertypen en tekstreflow te voorkomen.