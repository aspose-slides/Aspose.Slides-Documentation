---
title: Maak een presentatiewiewer in PHP
linktitle: Presentatiewiewer
type: docs
weight: 50
url: /nl/php-java/presentation-viewer/
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
- PHP
- Aspose.Slides
description: "Maak een aangepaste presentatiewiewer met Aspose.Slides voor PHP via Java. Toon eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Inleiding**

Aspose.Slides for PHP via Java wordt gebruikt om presentatiebestanden met dia's te maken. Deze dia's kunnen worden bekeken door presentaties te openen in Microsoft PowerPoint, bijvoorbeeld. Soms moeten ontwikkelaars echter dia's als afbeeldingen bekijken in hun favoriete afbeeldingsviewer of hun eigen presentatiewiewer maken. In dergelijke gevallen stelt Aspose.Slides u in staat om een enkele dia als afbeelding te exporteren. Dit artikel beschrijft hoe u dit doet.

## **Genereer een SVG-afbeelding van een dia**

Om een SVG-afbeelding van een presentatiedia met Aspose.Slides te genereren, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
1. Haal de dia-referentie op op basis van de index.
1. Open een bestandsstroom.
1. Sla de dia op als een SVG-afbeelding naar de bestandsstroom.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Genereer een SVG met een aangepaste vorm‑ID**

Aspose.Slides kan worden gebruikt om een [SVG](https://docs.fileformat.com/page-description-language/svg/) van een dia met een aangepaste vorm‑ID te genereren. Gebruik hiervoor de `setId`‑methode van [SvgShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kan worden gebruikt om de vorm‑ID in te stellen.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Maak een miniatuurafbeelding van een dia**

Aspose.Slides helpt u miniatuurafbeeldingen van dia's te genereren. Om een miniatuur van een dia met Aspose.Slides te genereren, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
1. Haal de dia-referentie op op basis van de index.
1. Haal de miniatuurafbeelding van de opgegeven dia op met een gedefinieerde schaal.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Maak een dia‑miniatuur met gebruikersgedefinieerde afmetingen**

Om een dia‑miniatuur met gebruikersgedefinieerde afmetingen te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
1. Haal de dia-referentie op op basis van de index.
1. Haal de miniatuurafbeelding van de opgegeven dia op met de gedefinieerde afmetingen.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Maak een dia‑miniatuur met sprekersnotities**

Om de miniatuur van een dia met sprekersnotities te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/) klasse.
1. Gebruik de `RenderingOptions.setSlidesLayoutOptions`‑methode om de positie van sprekersnotities in te stellen.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
1. Haal de dia-referentie op op basis van de index.
1. Haal de miniatuurafbeelding van de opgegeven dia op met de rendering‑opties.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Live‑voorbeeld**

U kunt de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) proberen om te zien wat u kunt implementeren met de Aspose.Slides‑API:

![Online PowerPoint-viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan ik een presentatiewiewer in een webapplicatie insluiten?**

Ja. U kunt Aspose.Slides aan de serverkant gebruiken om dia's als afbeeldingen of HTML weer te geven en ze in de browser te tonen. Navigatie‑ en zoomfuncties kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste viewer?**

De aanbevolen aanpak is om elke dia weer te geven als een afbeelding (bijv. PNG of SVG) of deze met Aspose.Slides naar HTML te converteren, en vervolgens de uitvoer weer te geven in een afbeeldingsvak (voor desktop) of een HTML‑container (voor web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote sets kunt u overwegen om dia's lazy‑loading of on‑demand te renderen. Dit betekent dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker er naartoe navigeert, waardoor geheugen‑ en laadtijd worden verminderd.