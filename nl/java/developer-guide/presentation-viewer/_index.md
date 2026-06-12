---
title: Maak een presentatieviewer in Java
linktitle: Presentatieviewer
type: docs
weight: 50
url: /nl/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "Maak een aangepaste presentatieviewer in Java met Aspose.Slides. Toon eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Inleiding**

Aspose.Slides for Java wordt gebruikt om presentatiebestanden met dia's te maken. Deze dia's kunnen bijvoorbeeld bekeken worden door presentaties te openen in Microsoft PowerPoint. Soms moeten ontwikkelaars echter dia's als afbeeldingen bekijken in hun favoriete afbeeldingsviewer of hun eigen presentatieviewer maken. In zulke gevallen biedt Aspose.Slides de mogelijkheid om een enkele dia als afbeelding te exporteren. Dit artikel beschrijft hoe u dit kunt doen.

## **Genereer een SVG-afbeelding van een dia**

Om met Aspose.Slides een SVG-afbeelding van een presentatiedia te genereren, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.  
2. Haalt de dia-referentie op basis van de index op.  
3. Open een bestandsstroom.  
4. Sla de dia op als een SVG-afbeelding naar de bestandsstroom.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Genereer een SVG met een aangepaste vorm-ID**

Aspose.Slides kan worden gebruikt om een [SVG](https://docs.fileformat.com/page-description-language/svg/) van een dia te genereren met een aangepaste vorm-ID. Gebruik hiervoor de `setId`‑methode van [ISvgShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` kan worden gebruikt om de vorm‑ID in te stellen.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Maak een miniatuurafbeelding van een dia**

Aspose.Slides helpt u bij het genereren van miniatuurafbeeldingen van dia's. Om met Aspose.Slides een miniatuur van een dia te genereren, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.  
2. Haalt de dia-referentie op basis van de index op.  
3. Haal de miniatuurafbeelding van de opgegeven dia op met een gedefinieerde schaal.  
4. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

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

## **Maak een miniatuur van een dia met gebruikersgedefinieerde afmetingen**

Om een miniatuurafbeelding van een dia met door de gebruiker gedefinieerde afmetingen te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.  
2. Haalt de dia-referentie op basis van de index op.  
3. Haal de miniatuurafbeelding van de opgegeven dia op met de gedefinieerde afmetingen.  
4. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Maak een miniatuur van een dia met spreker aantekeningen**

Om met Aspose.Slides de miniatuur van een dia met spreker aantekeningen te genereren, volgt u de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/) klasse.  
2. Gebruik de `RenderingOptions.setSlidesLayoutOptions`‑methode om de positie van spreker aantekeningen in te stellen.  
3. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.  
4. Haalt de dia-referentie op basis van de index op.  
5. Haal de miniatuurafbeelding van de opgegeven dia op met de rendering‑opties.  
6. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

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

U kunt de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) proberen om te zien wat u kunt implementeren met de Aspose.Slides‑API:

![Online PowerPoint‑viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan ik een presentatieviewer insluiten in een webapplicatie?**

Ja. U kunt Aspose.Slides aan de serverzijde gebruiken om dia's te renderen als afbeeldingen of HTML en ze in de browser te tonen. Navigatie‑ en zoomfuncties kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste viewer?**

De aanbevolen aanpak is om elke dia te renderen als een afbeelding (bijv. PNG of SVG) of deze te converteren naar HTML met Aspose.Slides, en vervolgens de output weer te geven in een afbeeldingvak (voor desktop) of een HTML‑container (voor web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote presentaties kunt u lazy‑loading of rendering op aanvraag overwegen. Dit betekent dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker ernaartoe navigeert, waardoor geheugen- en laadtijd worden verminderd.