---
title: "Hantera ActiveX‑kontroller i presentationer med Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /sv/python-net/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- hantera ActiveX
- lägga till ActiveX
- ändra ActiveX
- mediaspelare
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Redigera ActiveX‑textrutor och knappar, uppdatera kontrollförhandsgranskningar och återanvänd en Windows Media Player‑kontroll i PowerPoint‑presentationer med Aspose.Slides för Python via .NET."
---
## **Introduktion**

ActiveX‑kontroller ger en PowerPoint‑bild interaktiva element som textrutor, kommandoknappar och mediaplayer. Aspose.Slides för Python via .NET exponerar en bilds kontroller via [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den.

## **Lista ActiveX‑kontroller och deras lagrade egenskaper**

För att undersöka en okänd mall, öppna den för läsning och gå igenom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), och varje nyckel‑värde‑par i [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Det läser presentationen utan att aktivera kontroller, utlösa händelser eller makron, ändra värden eller spara filen.

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

Urval av utdata från `ActiveX.pptm` visar en textruta och en kommandoknapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapskollektion visas som `[]`. För kontroller som använder binär lagring kan `properties` returnera `None`, visat som `Properties unavailable`. Om du bara behöver namnen, använd [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) efter att ha kontrollerat för `None`. Rapporten listar de egenskaper som är tillgängliga från presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Ändra ActiveX‑kontroller**

Exemplet förutsätter en makroaktiverad presentation med en textruta som heter `TextBox1` och en kommandoknapp som heter `CommandButton1` på den första bilden. Det använder [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsgranskning som PowerPoint kan visa före aktivering. Tillhandahåll en PNG för varje kontroll som visar dess uppdaterade text och utseende. Exemplet tilldelar dessa bilder via [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att ändra dess [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Det sparar den redigerade presentationen i PPTM-format, och använder sedan [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) för att spara en andra kopia där alla ActiveX‑kontroller har tagits bort från den bilden.

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

## **Lägg till en ActiveX‑mediaspelarkontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall där den första bilden innehåller en spelare som heter `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) och sparar den klonade bilden som den enda bilden i resultatet. Videon förblir extern, så välj en sökväg som spelaren kan komma åt under uppspelning.

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

## **Vanliga frågor**

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. Ett [OLE‑objekt](/slides/sv/python-net/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, som ett Excel‑kalkylblad.

**Kommer ActiveX‑händelser fortfarande att utlösa VBA‑makron efter att jag sparat en presentation med Aspose.Slides?**

Spara presentationen i ett makroaktiverat format, till exempel PPTM, för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när dess säkerhetsinställningar tillåter både ActiveX‑kontroller och makron.