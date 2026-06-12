---
title: Maak een presentatiewiewer in .NET
linktitle: Presentatiewiewer
type: docs
weight: 50
url: /nl/net/presentation-viewer/
keywords:
- presentatie bekijken
- presentatiewiewer
- presentatiewiewer maken
- PPT bekijken
- PPTX bekijken
- ODP bekijken
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak een aangepaste presentatiewiewer in .NET met Aspose.Slides. Toon eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Introductie**

Aspose.Slides voor .NET wordt gebruikt om presentatiebestanden met dia's te maken. Deze dia's kunnen bijvoorbeeld bekeken worden door de presentaties te openen in Microsoft PowerPoint. Soms moeten ontwikkelaars echter dia's als afbeeldingen bekijken in hun favoriete afbeeldingsviewer of ze gebruiken in een aangepaste presentatiewiewer. In zulke gevallen stelt Aspose.Slides je in staat om individuele dia's als afbeeldingen te exporteren. Dit artikel legt uit hoe je dat doet.

## **Genereer een SVG-afbeelding van een dia**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
1. Verkrijg een verwijzing naar de dia op basis van de index.
1. Open een bestandsstroom.
1. Sla de dia op als een SVG-afbeelding in de bestandsstroom.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Genereer een SVG met een aangepaste vorm-ID**

Aspose.Slides kan worden gebruikt om een [SVG](https://docs.fileformat.com/page-description-language/svg/) te genereren vanuit een dia met een aangepaste vorm-`ID`. Gebruik hiervoor de Id-eigenschap van de [ISvgShape](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgshape) interface. De `CustomSvgShapeFormattingController` klasse kan worden gebruikt om de vorm-ID in te stellen.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Maak een miniatuurafbeelding van een dia**

Aspose.Slides helpt je bij het genereren van miniatuurafbeeldingen van dia's. Om een miniatuur van een dia te genereren met Aspose.Slides, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
1. Verkrijg een verwijzing naar de dia op basis van de index.
1. Maak een miniatuurafbeelding van de verwijzende dia op de gewenste schaal.
1. Sla de miniatuurafbeelding op in je gewenste afbeeldingformaat.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Maak een miniatuur van een dia met door de gebruiker gedefinieerde afmetingen**

Om een miniatuurafbeelding van een dia te maken met door de gebruiker gedefinieerde afmetingen, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
1. Verkrijg een verwijzing naar de dia op basis van de index.
1. Genereer een miniatuurafbeelding van de verwijzende dia met de opgegeven afmetingen.
1. Sla de miniatuurafbeelding op in je gewenste afbeeldingformaat.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Maak een miniatuur van een dia met sprekernotities**

Om een miniatuur van een dia met sprekernotities te genereren met Aspose.Slides, volg je de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/) klasse.
1. Gebruik de `RenderingOptions.SlidesLayoutOptions`‑eigenschap om de positie van de sprekernotities in te stellen.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
1. Verkrijg een verwijzing naar de dia op basis van de index.
1. Genereer een miniatuurafbeelding van de verwijzende dia met behulp van de rendering‑opties.
1. Sla de miniatuurafbeelding op in je gewenste afbeeldingformaat.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Live‑voorbeeld**

Probeer de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) om te zien wat je kunt implementeren met de Aspose.Slides‑API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/nl/viewer/)

## **FAQ**

**Kan ik een presentatieviewer inbedden in een ASP.NET‑webapplicatie?**

Ja. Je kunt Aspose.Slides aan de serverkant gebruiken om dia's te renderen als afbeeldingen of HTML en ze in de browser weergeven. Navigatie‑ en zoomfuncties kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste .NET‑viewer?**

De aanbevolen aanpak is om elke dia te renderen als een afbeelding (bijv. PNG of SVG) of deze om te zetten naar HTML met Aspose.Slides, en vervolgens de uitvoer weer te geven in een picture‑box (voor desktop) of een HTML‑container (voor web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote decks kun je overwegen om dia's lazy‑loading of on‑demand te renderen. Dit houdt in dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker ernaar navigeert, waardoor geheugen- en laadtijd worden verminderd.