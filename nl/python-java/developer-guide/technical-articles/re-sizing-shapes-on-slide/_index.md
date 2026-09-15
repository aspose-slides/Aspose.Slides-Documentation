---
title: Vormen schalen op presentatiedia's in Python via Java
type: docs
weight: 110
url: /nl/python-java/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Schaal eenvoudig vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via Java—automatiseer dia-indelingsaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides for Python via Java‑klanten is hoe vormen te schalen zodat, wanneer de dia‑grootte verandert, de gegevens niet worden afgekapt. Dit korte technische artikel laat zien hoe dat te doen.

## **Vormen schalen**

Om te voorkomen dat vormen verkeerd uitgelijnd raken wanneer de dia‑grootte verandert, werkt u de positie en afmetingen van elke vorm bij zodat ze overeenkomen met de nieuwe dia‑indeling.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Laad het presentatiebestand.
presentation = Presentation("sample.ppt")
try:
    # Haal de oorspronkelijke dia-grootte op.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Wijzig de dia-grootte zonder bestaande vormen te schalen.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Haal de nieuwe dia-grootte op.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Vergroot en verplaats vormen op elke dia.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Schaal de vormgrootte.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Schaal de vormpositie.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}} 

Tabellen hebben geen speciale behandeling nodig: de breedte en hoogte van een tabel instellen schaalt haar kolommen en rijen evenredig, dus het opnieuw schalen van de rijhoogtes en kolombreedtes zou de verhouding twee keer toepassen.

{{% /alert %}} 

De bovenstaande code wijzigt alleen de vormen op de dia’s. Master‑dia’s en lay‑out‑dia’s behouden hun eigen vormen, dus schaal deze ook wanneer u wilt dat de hele presentatie de nieuwe dia‑grootte volgt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Haal de oorspronkelijke dia-grootte op.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Wijzig de dia-grootte zonder bestaande vormen te schalen.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Haal de nieuwe dia-grootte op.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Schaal de vormgrootte.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Schaal de vormpositie.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Schaal de vormgrootte.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Schaal de vormpositie.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Schaal de vormgrootte.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Schaal de vormpositie.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Waarom worden vormen vervormd of afgekapt na het schalen van een dia?**

Wanneer een dia wordt geschaald, behouden vormen hun oorspronkelijke positie en afmeting tenzij de schaal expliciet wordt gewijzigd. Hierdoor kan inhoud worden bijgesneden of kunnen vormen verkeerd uitgelijnd raken.

**Werkt de meegeleverde code voor alle type vormen?**

Ja. Het instellen van de hoogte en breedte werkt voor tekstvakken, afbeeldingen, diagrammen en tabellen gelijk.

**Hoe schaal ik tabellen bij het aanpassen van een dia?**

Schaal de tabelvorm zelf, precies zoals elke andere vorm. De rijen en kolommen schalen proportioneel mee, dus schaal ze daarna niet opnieuw.

**Werkt deze schaalmethode voor master‑dia’s en lay‑out‑dia’s?**

Ja, maar u moet ook door [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters) en [Presentation.getLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getLayoutSlides) itereren en dezelfde schaallogica toepassen op hun vormen om consistentie in de hele presentatie te waarborgen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen samen met het schalen?**

Ja. U kunt [SlideSize.setOrientation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesize/#setOrientation) gebruiken om de oriëntatie te wijzigen. Zorg ervoor dat u de schaallogica dienovereenkomstig aanpast om de lay‑out te behouden.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Aspose.Slides ondersteunt aangepaste formaten, maar zeer grote formaten kunnen de prestaties of de compatibiliteit met sommige versies van PowerPoint beïnvloeden.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

U kunt de [getAspectRatioLocked](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked)‑methode van de vormvergrendeling controleren vóór het schalen. Als deze vergrendeld is, past u de breedte of hoogte evenredig aan in plaats van ze afzonderlijk te schalen.