---
title: Maak een presentatieweergave in C++
linktitle: Presentatieweergave
type: docs
weight: 50
url: /nl/cpp/presentation-viewer/
keywords:
- presentatie bekijken
- presentatieweergave
- presentatieweergave maken
- PPT bekijken
- PPTX bekijken
- ODP bekijken
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak een aangepaste presentatieweergave in C++ met Aspose.Slides. Toon eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Introductie**

Aspose.Slides for C++ wordt gebruikt om presentatiebestanden met dia's te maken. Deze dia's kunnen bekeken worden door presentaties te openen in Microsoft PowerPoint, bijvoorbeeld. Soms moeten ontwikkelaars echter dia's als afbeeldingen bekijken in hun favoriete beeldviewer of hun eigen presentatieweergave maken. In dergelijke gevallen laat Aspose.Slides u een enkele dia exporteren als afbeelding. Dit artikel beschrijft hoe u dit doet.

## **Genereer een SVG-afbeelding van een dia**

Om een SVG-afbeelding van een presentatiedia te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
1. Haal de dia-referentie op via de index.
1. Open een bestandsstream.
1. Sla de dia op als een SVG-afbeelding naar de bestandsstream.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Genereer een SVG met een aangepaste vorm-ID**

Aspose.Slides kan worden gebruikt om een [SVG](https://docs.fileformat.com/page-description-language/svg/) te genereren van een dia met een aangepaste vorm-ID. Gebruik hiervoor de `set_Id`-methode van [ISvgShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` kan worden gebruikt om de vorm-ID in te stellen.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Maak een miniatuurafbeelding van een dia**

Aspose.Slides helpt u miniatuurafbeeldingen van dia's te genereren. Om een miniatuur van een dia te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
1. Haal de dia-referentie op via de index.
1. Haal de miniatuurafbeelding van de verwijzende dia op met een gedefinieerde schaal.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Maak een miniatuur met door de gebruiker gedefinieerde afmetingen**

Om een miniatuurafbeelding van een dia met door de gebruiker gedefinieerde afmetingen te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
1. Haal de dia-referentie op via de index.
1. Haal de miniatuurafbeelding van de verwijzende dia op met de opgegeven afmetingen.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Maak een miniatuur met spreker-notities**

Om de miniatuur van een dia met spreker-notities te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/)-klasse.
1. Gebruik de `RenderingOptions.set_SlidesLayoutOptions`-methode om de positie van spreker-notities in te stellen.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse.
1. Haal de dia-referentie op via de index.
1. Haal de miniatuurafbeelding van de verwijzende dia op met de renderopties.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Live-voorbeeld**

U kunt de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) uitproberen om te zien wat u kunt implementeren met de Aspose.Slides-API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan ik een presentatieweergave inbedden in een webapplicatie?**

Ja. U kunt Aspose.Slides aan de serverzijde gebruiken om dia's te renderen als afbeeldingen of HTML en deze in de browser weer te geven. Navigatie- en zoomfuncties kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste viewer?**

De aanbevolen aanpak is om elke dia te renderen als een afbeelding (bijvoorbeeld PNG of SVG) of deze te converteren naar HTML met Aspose.Slides, en vervolgens de output weer te geven in een picture box (voor desktop) of HTML-container (voor web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote decks kunt u overwegen om dia's lazy-loading of on-demand te renderen. Dit betekent dat u de inhoud van een dia alleen genereert wanneer de gebruiker er naartoe navigeert, waardoor geheugen- en laadtijd worden verminderd.