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
- vormweergave
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides for .NET – maak eenvoudig presentatieminiaturen en exporteer ze."
---
## **Introductie**

Aspose.Slides for .NET wordt gebruikt om presentatiebestanden te maken waarbij elke pagina een dia is. Deze dia's kunnen bekeken worden door de presentatiebestanden te openen met Microsoft PowerPoint. Maar soms moeten ontwikkelaars de afbeeldingen van de vormen afzonderlijk bekijken in een afbeeldingsviewer. In zulke gevallen helpt Aspose.Slides for .NET u bij het genereren van miniatuurafbeeldingen van de dia‑vormen. Hoe u deze functie gebruikt, wordt in dit artikel beschreven.  
Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een vormminiatuur genereren binnen een dia.  
- Een vormminiatuur genereren voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen.  
- Een vormminiatuur genereren binnen de grenzen van de weergave van een vorm.

## **Een vormminiatuur genereren vanuit een dia**
Om een vormminiatuur van een willekeurige dia te genereren met Aspose.Slides for .NET:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Verkrijg de referentie van een willekeurige dia met behulp van het ID of de index.  
3. Haal de miniatuurafbeelding van de vorm van de genoemde dia op, met de standaardschaal.  
4. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

Het onderstaande voorbeeld genereert een vormminiatuur.

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

## **Een miniatuur met door de gebruiker gedefinieerde schaalfactor genereren**
Om de vormminiatuur van een willekeurige dia‑vorm te genereren met Aspose.Slides for .NET:

1. Maak een instantie van de `Presentation`‑klasse.  
2. Verkrijg de referentie van een willekeurige dia met behulp van het ID of de index.  
3. Haal de miniatuurafbeelding van de genoemde dia op met de vormgrenzen.  
4. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

Het onderstaande voorbeeld genereert een miniatuur met een door de gebruiker gedefinieerde schaalfactor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Schalen langs X- en Y-assen.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Een miniatuur van een vormweergave gebaseerd op grenzen maken**
Deze methode voor het maken van miniaturen van vormen stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de vormweergave. Alle vorm‑effecten worden hierbij meegenomen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Gebruik de volgende voorbeeldcode om een miniatuur van een willekeurige dia‑vorm binnen de grenzen van de weergave te genereren:

1. Maak een instantie van de `Presentation`‑klasse.  
2. Verkrijg de referentie van een willekeurige dia met behulp van het ID of de index.  
3. Haal de miniatuurafbeelding van de genoemde dia op met de vormgrenzen als weergave.  
4. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

Het onderstaande voorbeeld maakt een miniatuur op basis van een door de gebruiker gedefinieerde schaalfactor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Schalen langs X- en Y-assen.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/net/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds gerenderd als een miniatuur?**

Een verborgen vorm blijft deel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt alleen de weergave in de diavoorstelling en verhindert niet het genereren van de afbeelding van de vorm.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/), en [SmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de benodigde lettertypen leveren](/slides/nl/net/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/net/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑reflow te voorkomen.