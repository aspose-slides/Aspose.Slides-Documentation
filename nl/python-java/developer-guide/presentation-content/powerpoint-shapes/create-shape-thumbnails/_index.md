---
title: Miniaturen van presentatievormen maken in Python via Java
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/python-java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint‑dia's met Aspose.Slides for Python via Java – maak en exporteer eenvoudig miniaturen van presentaties."
---
## **Inleiding**

Aspose.Slides for Python via Java kan worden gebruikt om presentatiebestanden te maken waarbij elke pagina overeenkomt met een dia. De dia's kunnen worden bekeken door de presentatiebestanden te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen afzonderlijk bekijken in een beeldviewer. In die gevallen helpt Aspose.Slides for Python via Java hen bij het genereren van miniatuurafbeeldingen van de vormdia’s.

Dit artikel legt uit hoe je miniaturen van vormen op verschillende manieren kunt genereren:

- Een miniatuur van een vorm binnen een dia genereren.  
- Een miniatuur van een vorm op een dia genereren met door de gebruiker gedefinieerde afmetingen.  
- Een miniatuur van een vorm genereren binnen de grenzen van de weergave van de vorm.

## **Miniatuur van een vorm vanuit een dia genereren**
Om een miniatuur van een vorm van een willekeurige dia te genereren met Aspose.Slides for Python via Java, doe het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar een dia via zijn ID of index.  
3. [Haal de miniatuurafbeelding van de vorm op](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) van een vorm op de referentie‑dia met de standaardschaal.  
4. Sla de miniatuurafbeelding op in het door u gewenste beeldformaat.

Deze voorbeeldcode laat zien hoe je een miniatuur van een vorm vanuit een dia genereert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Instantieer een Presentation‑klasse die het presentatie‑bestand voorstelt.
presentation = Presentation("Thumbnail.pptx")
try:
    # Maak een afbeelding op volledige schaal.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Sla de afbeelding op schijf op in PNG‑formaat.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Miniatuur genereren met een door de gebruiker gedefinieerde schaalfactor**
Om de miniatuur van een vorm op een dia te genereren met Aspose.Slides for Python via Java, doe het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar een dia via zijn ID of index.  
3. [Haal de miniatuurafbeelding van de vorm op](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) van een vorm op de referentie‑dia met door de gebruiker gedefinieerde afmetingen.  
4. Sla de miniatuurafbeelding op in het door u gewenste beeldformaat.

Deze voorbeeldcode laat zien hoe je een miniatuur van een vorm genereert op basis van een gedefinieerde schaalfactor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instantieer een Presentation-klasse die het presentatie-bestand voorstelt.
presentation = Presentation("Thumbnail.pptx")
try:
    # Maak een afbeelding geschaald met een factor 2 in beide richtingen.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Sla de afbeelding op schijf op in PNG-formaat.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Miniatuur van vormweergave op basis van grenzen maken**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Alle vormeffecten worden hierbij in aanmerking genomen. De gegenereerde miniatuur van de vorm wordt beperkt door de dia‑grenzen. Om een miniatuur van een vorm op een dia te genereren binnen de grenzen van de weergave, doe het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar een dia via zijn ID of index.  
3. Haal de miniatuurafbeelding van een vorm op de referentie‑dia op met behulp van de weergave‑grenzen van de vorm.  
4. Sla de miniatuurafbeelding op in het door u gewenste beeldformaat.

Deze voorbeeldcode is gebaseerd op de bovenstaande stappen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instantieer een Presentation-klasse die het presentatie-bestand voorstelt.
presentation = Presentation("Thumbnail.pptx")
try:
    # Maak een afbeelding op volledige schaal.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Sla de afbeelding op schijf op in PNG-formaat.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **De feitelijke visuele grenzen van een vorm opvragen**

De frame‑eigenschappen van [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)—de methoden [getX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getWidth) en [getHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getHeight)—beschrijven het rechthoekige gebied dat in het presentatiemodel is opgeslagen. De inhoud die werkelijk gerenderd wordt, kan buiten dat frame uitsteken of een ander rechthoekig gebied innemen. Rotatie, omtreklijnen, pijlpunten, tekstindeling en overflow, gegenereerde SmartArt‑geometrie en andere render‑effecten kunnen het ingenomen gebied allemaal wijzigen.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getVisualBounds) om dat ingenomen gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in dia‑coördinaten. Het geretourneerde rechthoekige gebied wordt niet bijgesneden tot de dia, waardoor de coördinaten negatief kunnen zijn wanneer de inhoud buiten de oorsprong van de dia uitstrekt.

Het volgende voorbeeld haalt zowel het frame‑ als het visuele gebied op en vergelijkt ze:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Dezelfde [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kan worden gebruikt om aangrenzende vormen links, rechts, boven of onder uit te lijnen; voldoende ruimte te reserveren in een gegenereerde lay‑out; of inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, geroteerde vormen en groepsvormen, waar het opgeslagen frame mogelijk niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getVisualBounds) wanneer je coördinaten voor lay‑out of validatie nodig hebt en geen bitmap nodig hebt. Gebruik [Shape.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) wanneer je de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapethumbnailbounds/) en [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapethumbnailbounds/#Shape) wordt de afbeelding geschaald op basis van de vorm‑grenzen, inclusief omtrek‑instellingen, terwijl [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapethumbnailbounds/#Appearance) deze schaalt op basis van de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. In contrast retourneert [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getVisualBounds) alleen het berekende rechthoekige gebied en snijdt dit niet bij de dia.

## **Veelgestelde vragen**

**Welke beeldformaten kunnen worden gebruikt bij het opslaan van miniaturen van vormen?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [exported as vector SVG](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#writeAsSvgToBytes) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape- en Appearance‑grenzen bij het renderen van een miniatuur?**  
`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/python-java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds gerenderd als miniatuur?**  
Een verborgen vorm blijft deel van het model en kan worden gerenderd; de verborgen‑vlag beïnvloedt alleen de weergave tijdens de diavoorstelling, maar verhindert niet het genereren van de afbeeldings‑miniatuur van de vorm.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**  
Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)) kan worden opgeslagen als miniatuur of als SVG.

**Hebben systeem‑geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen voor tekstvormen?**  
Ja. Je moet [lever de vereiste lettertypen](/slides/nl/python-java/custom-font/) (of [configureer lettertype‑substituties](/slides/nl/python-java/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑herindeling te vermijden.