---
title: Masterdia
type: docs
weight: 30
url: /nl/python-java/examples/elements/master-slide/
keywords:
- codevoorbeeld
- masterdia
- masterdia toevoegen
- masterdia openen
- masterdia verwijderen
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer masterdia's met Aspose.Slides for Python via Java: maak, open, verwijder en ruim masterdia's op in PowerPoint- en OpenDocument-presentaties."
---
Masterdia’s vormen het hoogste niveau in de dia‑erfenishierarchie in PowerPoint. Een **masterdia** defineert gemeenschappelijke ontwerpelementen zoals achtergronden, logo's en tekstopmaak. **Lay-outdia’s** erven van masterdia’s, en **normale dia’s** erven van lay-outdia’s.

Dit artikel laat zien hoe u masterdia’s kunt maken, wijzigen en beheren met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM draait.

## **Een masterdia toevoegen**

Dit voorbeeld toont hoe u een nieuwe masterdia kunt maken door de standaarddia te klonen. Vervolgens wordt er een banner met de bedrijfsnaam aan alle dia’s toegevoegd via lay-out‑erfenis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Kloon de standaard masterdia.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Voeg een banner met de bedrijfsnaam toe aan de bovenkant van de masterdia.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Wijs de nieuwe masterdia toe aan een lay-outdia.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Wijs de lay-outdia toe aan de eerste dia in de presentatie.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}
Masterdia’s bieden een manier om consistente branding of gedeelde ontwerpelementen toe te passen op alle dia’s. Wijzigingen die op een master worden aangebracht, worden automatisch weergegeven op afhankelijke lay-out- en normale dia’s.
{{% /alert %}}

{{% alert color="info" title="Opmerking" %}}
Vormen en opmaak die aan een masterdia worden toegevoegd, worden overgeërfd door lay-outdia’s en, op hun beurt, door alle normale dia’s die die lay-outs gebruiken. De afbeelding hieronder illustreert hoe een tekstvak dat aan een masterdia wordt toegevoegd, automatisch wordt weergegeven op de uiteindelijke dia.
{{% /alert %}}

![Voorbeeld van master‑erfenis](master-slide-banner.png)

## **Toegang tot een masterdia**

U kunt masterdia’s benaderen via de mastercollectie van de presentatie. Dit voorbeeld haalt de eerste masterdia op en verandert het achtergrondtype.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Een masterdia verwijderen**

Een masterdia kan worden verwijderd op index of op referentie nadat deze niet meer wordt gebruikt. Dit voorbeeld kent een gekloonde masterdia toe aan de presentatie en verwijdert vervolgens de originele master op index.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Verwijder de ongebruikte originele masterdia op index.
    presentation.getMasters().removeAt(0)

    # Alternatief, verwijder een ongebruikte masterdia via referentie:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Niet‑gebruikte masterdia’s verwijderen**

Sommige presentaties bevatten masterdia’s die niet in gebruik zijn. Het verwijderen van deze dia’s kan helpen de bestandsgrootte te verkleinen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Verwijder alle ongebruikte masterdia's, inclusief diegene die als Preserve gemarkeerd zijn.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```