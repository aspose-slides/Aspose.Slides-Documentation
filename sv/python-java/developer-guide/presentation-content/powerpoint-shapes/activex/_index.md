---
title: Hantera ActiveX-kontroller i presentationer med Python
linktitle: ActiveX
type: docs
weight: 80
url: /sv/python-java/activex/
keywords:
- ActiveX
- ActiveX-kontroll
- hantera ActiveX
- lägga till ActiveX
- modifiera ActiveX
- mediaspelare
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Redigera ActiveX-textrutor och -knappar, uppdatera kontrollförhandsgranskningar och återanvänd en Windows Media Player-kontroll i PowerPoint-presentationer med Aspose.Slides för Python via Java."
---
## **Introduktion**

ActiveX-kontroller ger en PowerPoint-bild interaktiva element såsom textrutor, kommandoknappar och mediaspelare. Aspose.Slides for Python via Java exponerar en bilds kontroller genom [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den.

## **Lista ActiveX-kontroller och deras lagrade egenskaper**

För att undersöka en okänd mall, öppna den för läsning och iterera genom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) och varje nyckel‑värde‑par i [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Det läser presentationen utan att aktivera kontroller, anropa händelser eller makron, ändra värden eller spara filen.

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

Det valda resultatet från `ActiveX.pptm` visar en textruta och en kommandoknapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapskollektion visas som `[]`. För kontroller som använder binär lagring kan [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) returnera `None`, visas som `Properties unavailable`. Om du bara behöver namnen, använd [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) efter att ha kontrollerat att samlingen är tillgänglig. Rapporten listar de egenskaper som finns tillgängliga i presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Modifiera ActiveX-kontroller**

Exemplet förväntar sig en makroaktiverad presentation med en textruta som heter `TextBox1` och en kommandoknapp som heter `CommandButton1` på den första bilden. Det använder [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsgranskning som PowerPoint kan visa före aktivering. Tillhandahåll en PNG för varje kontroll som visar dess uppdaterade text och utseende. Exemplet tilldelar dessa bilder via [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att sätta dess ram med [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Det sparar den redigerade presentationen i PPTM‑format och använder sedan [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) för att spara en andra kopia där alla ActiveX‑kontroller har tagits bort från den bilden.

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

## **Lägg till en ActiveX Media Player‑kontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall vars första bild innehåller en spelare som heter `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) och sparar den klonade bilden som den enda bilden i utdata. Videon förblir extern, så välj en sökväg som spelaren kan komma åt under uppspelning.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

## **Vanliga frågor**

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. En [OLE‑objekt](/slides/sv/python-java/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, såsom ett Excel‑ark.

**Kommer ActiveX‑händelser fortfarande att trigga VBA‑makron efter att jag sparat en presentation med Aspose.Slides?**

Spara presentationen i ett makroaktiverat format såsom PPTM för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när dess säkerhetsinställningar tillåter både ActiveX‑kontroller och makron.