---
title: Maak een presentatieweergave op Android
linktitle: Presentatieviewer
type: docs
weight: 50
url: /nl/androidjava/presentation-viewer/
keywords:
- presentatie bekijken
- presentatieviewer
- presentatieviewer maken
- PPT bekijken
- PPTX bekijken
- ODP bekijken
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak een aangepaste presentatieweergave in Java met Aspose.Slides voor Android. Toon eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Inleiding**

Aspose.Slides for Android via Java wordt gebruikt om presentatie‑bestanden met dia’s te maken. Deze dia’s kunnen bekeken worden door bijvoorbeeld presentaties te openen in Microsoft PowerPoint. Soms moeten ontwikkelaars echter dia’s als afbeeldingen bekijken in hun favoriete afbeeldingsviewer of een eigen presentatieweergave maken. In dat geval maakt Aspose.Slides het mogelijk om een enkele dia als afbeelding te exporteren. Dit artikel beschrijft hoe dit te doen.

## **Genereer een SVG‑afbeelding van een dia**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
1. Haal de dia‑referentie op via de index.
1. Open een bestandsstream.
1. Sla de dia op als een SVG‑afbeelding naar de bestandsstream.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Genereer een SVG met een eigen vorm‑ID**

Aspose.Slides kan gebruikt worden om een [SVG](https://docs.fileformat.com/page-description-language/svg/) van een dia te genereren met een eigen vorm‑ID. Hiervoor gebruik je de `setId`‑methode van [ISvgShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` kan gebruikt worden om de vorm‑ID in te stellen.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Maak een miniatuur‑afbeelding van een dia**

Aspose.Slides helpt je bij het genereren van miniatuur‑afbeeldingen van dia’s. Volg de onderstaande stappen om een miniatuur van een dia te genereren met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
1. Haal de dia‑referentie op via de index.
1. Haal de miniatuurafbeelding van de refererende dia op met een gedefinieerde schaal.
1. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Maak een miniatuur van een dia met door de gebruiker gedefinieerde afmetingen**

Om een miniatuurafbeelding van een dia te maken met door de gebruiker gedefinieerde afmetingen, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
1. Haal de dia‑referentie op via de index.
1. Haal de miniatuurafbeelding van de refererende dia op met de gedefinieerde afmetingen.
1. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Maak een miniatuur van een dia met spreker­notities**

Om de miniatuur van een dia met spreker­notities te genereren met Aspose.Slides, volg je de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/renderingoptions/) klasse.
1. Gebruik de `RenderingOptions.setSlidesLayoutOptions`‑methode om de positie van spreker­notities in te stellen.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
1. Haal de dia‑referentie op via de index.
1. Haal de miniatuurafbeelding van de refererende dia op met de rendering‑opties.
1. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Live‑voorbeeld**

Je kunt de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) uitproberen om te zien wat je kunt implementeren met de Aspose.Slides‑API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan ik een presentatieweergave insluiten in een webapplicatie?**

Ja. Je kunt Aspose.Slides aan de server‑kant gebruiken om dia’s te renderen als afbeeldingen of HTML en deze in de browser weer te geven. Navigatie‑ en zoom‑functies kunnen met JavaScript geïmplementeerd worden voor een interactieve ervaring.

**Wat is de beste manier om dia’s te tonen binnen een aangepaste viewer?**

De aanbevolen aanpak is om elke dia te renderen als een afbeelding (bijv. PNG of SVG) of om deze te converteren naar HTML met Aspose.Slides, en vervolgens de output weer te geven in een picture‑box (voor desktop) of een HTML‑container (voor web).

**Hoe ga ik om met grote presentaties met veel dia’s?**

Voor grote presentaties kun je overwegen om dia’s lazy‑load of on‑demand te renderen. Dit betekent dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker ernaartoe navigeert, waardoor geheugen‑ en laadtijd worden verminderd.