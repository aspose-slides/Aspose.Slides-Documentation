---
title: Beheer ActiveX-besturingselementen in presentaties met Python
linktitle: ActiveX
type: docs
weight: 80
url: /nl/python-net/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Bewerk ActiveX-tekstvakken en -knoppen, update de voorbeeldweergave van besturingselementen, en hergebruik een Windows Media Player-besturingselement in PowerPoint-presentaties met Aspose.Slides for Python via .NET."
---
## **Introductie**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, opdrachtknoppen en mediaspelers. Aspose.Slides for Python via .NET maakt de besturingselementen van een dia toegankelijk via [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Gebruik deze collectie om een besturingselement te bewerken, het op de dia te verplaatsen of te verwijderen.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende sjabloon te inspecteren, open je deze leestoestand en loop je de besturingselementen op elke dia door. Het voorbeeld meldt het dianummer, de naam van het besturingselement, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), en elk sleutel‑waarde‑paar in [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Het leest de presentatie zonder de besturingselementen te activeren, zonder gebeurtenissen of macro's uit te voeren, zonder waarden te wijzigen of het bestand op te slaan.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
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

Een lege eigenschaps‑collectie wordt weergegeven als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan `properties` de waarde `None` teruggeven, weergegeven als `Properties unavailable`. Als je alleen de namen nodig hebt, gebruik dan [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) nadat je op `None` gecontroleerd hebt. Het rapport somt de eigenschappen op die beschikbaar zijn in de presentatie. Een besturingselement kan tijdens uitvoering extra eigenschappen ondersteunen.

## **ActiveX‑besturingselementen wijzigen**

Het voorbeeld gaat uit van een macro‑ingeschakelde presentatie met op de eerste dia een tekstvak met de naam `TextBox1` en een opdrachtknop met de naam `CommandButton1`. Het gebruikt de [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) om de tekstvakwaarde en de knopbijschrift te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen voordat het geactiveerd wordt. Lever een PNG voor elk besturingselement dat de bijgewerkte tekst en weergave toont. Het voorbeeld kent deze afbeeldingen toe via [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Het voorbeeld verplaatst elk besturingselement op de eerste dia 100 punten naar beneden door zijn [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) aan te passen. Het slaat de bewerkte presentatie op in PPTM‑formaat en gebruikt vervolgens [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) om een tweede kopie op te slaan waarbij alle ActiveX‑besturingselementen van die dia verwijderd zijn.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Een ActiveX‑mediaplayer‑besturingselement toevoegen**

Om een geconfigureerde Windows Media Player‑besturingselement opnieuw te gebruiken, begin je met een sjabloon waarvan de eerste dia een speler bevat met de naam `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in via zijn [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, dus kies een pad dat de speler tijdens afspelen kan benaderen.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers met een dia interactie hebben, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE object](/slides/nl/python-net/manage-ole/) laat een dia inhoud bevatten of ernaar linken die door een andere applicatie wordt beheerd, zoals een Excel‑werkblad.

**Zullen ActiveX‑gebeurtenissen nog steeds VBA‑macro’s activeren nadat ik een presentatie met Aspose.Slides heb opgeslagen?**

Sla de presentatie op in een macro‑ingeschakeld formaat zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande gebeurtenis‑handlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro’s toestaan.