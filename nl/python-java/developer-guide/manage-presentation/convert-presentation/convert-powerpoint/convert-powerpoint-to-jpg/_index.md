---
title: PPT en PPTX naar JPG converteren in Python
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PowerPoint naar JPG
- PPT naar JPG
- PPTX naar JPG
- dia opslaan als JPG
- PPT exporteren naar JPG
- PPTX exporteren naar JPG
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint (PPT, PPTX) dia's naar JPG-afbeeldingen in Python via Java. Stel aangepaste afbeeldingsafmetingen in en render notities en commentaren met Aspose.Slides."
---
## **Inleiding**

Aspose.Slides for Python via Java stelt u in staat om PowerPoint- en OpenDocument-presentaties (PPT, PPTX en ODP) om te zetten naar JPEG-afbeeldingen. U kunt elke dia of een geselecteerde dia exporteren om miniaturen te maken, een presentatieviewer te bouwen of dia-preview's in een website of applicatie in te sluiten.

## **PowerPoint PPT/PPTX naar JPG converteren**

1. Laad de presentatie met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/).
2. Haal de dia's op met [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides).
3. Roep [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) aan met horizontale en verticale schaalfactoren om elke dia te renderen.
4. Sla elke gerenderde afbeelding op als JPEG met [ImageFormat.Jpeg](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imageformat/#Jpeg), en maak vervolgens de afbeeldingsbronnen vrij.

{{% alert color="info" title="Note" %}}
Exporteren naar JPG maakt voor elke dia een afzonderlijke afbeelding. Sla de gerenderde afbeelding op in plaats van de presentatie direct naar een afbeeldingsformaat op te slaan.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **PowerPoint PPT/PPTX naar JPG met aangepaste afmetingen**

Bereken horizontale en verticale schaalfactoren op basis van de gewenste pixelafmetingen en de oorspronkelijke dia-grootte, en geef ze vervolgens door aan [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage). Het onderstaande voorbeeld maakt een afbeelding van 1200 x 800 voor elke dia.

Het gebruik van verschillende schaalfactoren kan de dia uitrekken. Om de beeldverhouding te behouden, gebruik dezelfde schaalfactor voor beide assen; de resulterende breedte en hoogte volgen dan de oorspronkelijke dia-proporties.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Commentaren renderen bij het opslaan van dia's als afbeeldingen**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/) om notities en commentaren te configureren, en pas de lay-out toe via [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Dit voorbeeld plaatst notities onderaan, afkapt notities die niet passen, en toont commentaren rechts in een gebied van 200 pixels breed. Het slaat elke gerenderde dia op als een JPG-afbeelding.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **FAQ**

**Kan ik meerdere dia's of presentaties naar JPG converteren?**

Ja. De voorbeelden doorlopen alle dia's en slaan één JPG per dia op. Om meerdere presentaties te verwerken, herhaal de conversie voor elk invoerbestand en gebruik aparte uitvoermappen of unieke bestandsnamen om het overschrijven van afbeeldingen te voorkomen.

**Worden diagrammen, SmartArt, tabellen en vormen in de afbeeldingen opgenomen?**

Deze objecten worden als onderdeel van de dia gerenderd. Zorg ervoor dat de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in de conversie-omgeving om verschillen door lettertype-substitutie te beperken.

**Hoe kan ik het geheugenverbruik verminderen bij het exporteren van grote presentaties?**

Verwerk afbeeldingen één voor één, maak elke afbeelding na het opslaan vrij, en vermijd onnodig grote uitvoerafmetingen. Het geheugenverbruik hangt af van de inhoud van de dia en de afbeeldingsgrootte.

## **Zie ook**

- [PowerPoint naar PNG converteren](/slides/nl/python-java/convert-powerpoint-to-png/).
- [Dia renderen als een SVG-afbeelding](/slides/nl/python-java/render-a-slide-as-an-svg-image/).