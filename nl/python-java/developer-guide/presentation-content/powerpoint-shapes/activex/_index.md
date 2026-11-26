---
title: Beheer ActiveX‑besturingselementen in presentaties met Python
linktitle: ActiveX
type: docs
weight: 80
url: /nl/python-java/activex/
keywords:
- ActiveX
- ActiveX‑besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Bewerk ActiveX‑tekstvakken en -knoppen, werk voorbeeldweergaven van besturingselementen bij en hergebruik een Windows Media Player‑besturingselement in PowerPoint‑presentaties met Aspose.Slides voor Python via Java."
---
## **Introductie**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, opdrachtknoppen en mediaplayers. Aspose.Slides voor Python via Java maakt de besturingselementen van een dia toegankelijk via [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Gebruik deze collectie om een besturingselement te bewerken, te verplaatsen op de dia, of te verwijderen.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende template te onderzoeken, open deze voor lezen en doorloop de besturingselementen op elke dia. Het voorbeeld meldt het dia‑nummer, de naam van het besturingselement, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), en elk sleutel‑waarde‑paar in [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Het leest de presentatie zonder de besturingselementen te activeren, gebeurtenissen of macro's uit te voeren, waarden te wijzigen, of het bestand op te slaan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

Geselecteerde uitvoer van `ActiveX.pptm` toont een tekstvak en een opdrachtknop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschapencollectie verschijnt als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) `None` retourneren, weergegeven als `Properties unavailable`. Als u alleen de namen nodig hebt, gebruik dan [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) nadat u gecontroleerd hebt dat de collectie beschikbaar is. Het rapport lijst de eigenschappen op die beschikbaar zijn vanuit de presentatie. Een besturingselement kan tijdens runtime extra eigenschappen ondersteunen.

## **ActiveX‑besturingselementen aanpassen**

Het voorbeeld verwacht een macro‑ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een opdrachtknop genaamd `CommandButton1` op de eerste dia. Het maakt gebruik van de [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) om de tekstvakwaarde en de knopbijschrift te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activatie. Lever een PNG voor elk besturingselement met de bijgewerkte tekst en weergave. Het voorbeeld wijst deze afbeeldingen toe via [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Het voorbeeld verplaatst elk besturingselement op de eerste dia 100 punten naar beneden door het frame in te stellen met [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Het slaat de bewerkte presentatie op in PPTM‑formaat, en gebruikt vervolgens [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) om een tweede kopie op te slaan zonder alle ActiveX‑besturingselementen van die dia.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **ActiveX‑media‑speler‑besturingselement toevoegen**

Om een geconfigureerd Windows Media Player‑besturingselement opnieuw te gebruiken, begin met een template waarvan de eerste dia een speler bevat met de naam `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in in zijn [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, dus kies een pad dat de speler tijdens afspelen kan bereiken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpave.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers met een dia interactie hebben, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE‑object](/slides/nl/python-java/manage-ole/) laat een dia inhoud bevatten of ernaar koppelen die wordt beheerd door een andere applicatie, zoals een Excel‑werkblad.

**Zullen ActiveX‑gebeurtenissen nog steeds VBA‑macro's activeren nadat ik een presentatie opsla met Aspose.Slides?**

Sla de presentatie op in een macro‑ingeschakelde indeling zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande gebeurtenis‑handlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro's toestaan.