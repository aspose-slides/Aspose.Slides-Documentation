---
title: Layoutdia
type: docs
weight: 20
url: /nl/python-java/examples/elements/layout-slide/
keywords:
- codevoorbeeld
- layoutdia
- layoutdia toevoegen
- layoutdia benaderen
- layoutdia verwijderen
- ongebruikte layoutdia
- layoutdia klonen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer layoutdia's met Aspose.Slides voor Python via Java: voeg toe, benader, verwijder, maak schoon en kloon layouts in PowerPoint- en OpenDocument-presentaties."
---
Dit artikel laat zien hoe u met **layoutdia's** kunt werken met Aspose.Slides voor Python via Java. Een layoutdia definieert het ontwerp en de opmaak die door normale dia’s worden geërfd. U kunt layoutdia's toevoegen, benaderen, klonen en verwijderen, en ongebruikte dia's opschonen om de bestandsgrootte van de presentatie te verkleinen.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` vóór het starten van de JVM en importeert vervolgens de API nadat de JVM draait.

## **Een layoutdia toevoegen**

Maak een aangepaste layoutdia om herbruikbare opmaak te definiëren. Het volgende voorbeeld voegt een tekstvak toe aan een nieuwe layout en maakt vervolgens twee dia's die deze gebruiken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Maak een layoutdia met een leeg layouttype en een aangepaste naam.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Voeg een tekstvak toe aan de layoutdia.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Voeg twee dia's toe die de tekst van de layout erven.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Opmerking 1:** Layoutdia's fungeren als sjablonen voor individuele dia's. U kunt gemeenschappelijke elementen één keer definiëren en ze hergebruiken in meerdere dia's.

> 💡 **Opmerking 2:** Wanneer u vormen of tekst toevoegt aan een layoutdia, tonen alle dia's die op die layout zijn gebaseerd automatisch de gedeelde inhoud.  
> De schermafbeelding hieronder toont twee dia's die een tekstvak van dezelfde layoutdia erven.

![Dia's die layoutinhoud erven](layout-slide-result.png)

## **Een layoutdia benaderen**

```python
import jpapi
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Toegang tot een layoutdia via index.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Toegang tot een layoutdia via type.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Een layoutdia verwijderen**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Ongebruikte layoutdia's verwijderen**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Een layoutdia klonen**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Samenvatting:** Layoutdia's helpen bij het behouden van consistente opmaak door een hele presentatie. Aspose.Slides stelt u in staat om layouts te maken, beheren, hergebruiken en indien nodig op te schonen.