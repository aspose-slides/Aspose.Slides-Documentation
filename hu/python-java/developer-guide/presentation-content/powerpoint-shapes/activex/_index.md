---
title: ActiveX vezérlők kezelése prezentációkban Python használatával
linktitle: ActiveX
type: docs
weight: 80
url: /hu/python-java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- média lejátszó
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Szerkessze az ActiveX szövegdobozokat és gombokat, frissítse a vezérlő előnézeteket, valamint használja újra a Windows Media Player vezérlőt PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Bevezetés**

ActiveX vezérlők interaktív elemeket adnak a PowerPoint diához, például szövegdobozokat, parancsgombokat és média lejátszókat. Aspose.Slides for Python via Java egy dia vezérlőit a [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) segítségével teszi elérhetővé. Használja ezt a gyűjteményt egy vezérlő szerkesztéséhez, mozgatásához a dián vagy eltávolításához.

## **ActiveX vezérlők listázása és tárolt tulajdonságaik**

Egy ismeretlen sablon ellenőrzéséhez nyissa meg olvasásra, és iteráljon végig a diákon lévő vezérlőkön. A példa jelentést készít a dia számáról, a vezérlő nevéről, a [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) és minden kulcs-érték párról a [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) segítségével. A prezentációt úgy olvassa be, hogy nem aktiválja a vezérlőket, nem hív meg eseményeket vagy makrókat, nem módosítja az értékeket, és nem menti a fájlt.

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

A `ActiveX.pptm` kiválasztott kimenete egy szövegdobozt és egy parancsgombot mutat.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Egy üres tulajdonsággyűjtemény `[]` formában jelenik meg. Azoknál a vezérlőknél, amelyek bináris tárolást használnak, a [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) `None` értéket adhat vissza, ami `Properties unavailable`‑ként jelenik meg. Ha csak a nevekre van szüksége, használja a [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)‑t, miután ellenőrizte, hogy a gyűjtemény elérhető. A jelentés felsorolja a prezentációból elérhető tulajdonságokat. Egy vezérlő futásidőben további tulajdonságokat is támogathat.

## **ActiveX vezérlők módosítása**

A példa egy makrók támogatott prezentációt vár, amelyen az első dián egy `TextBox1` nevű szövegdoboz és egy `CommandButton1` nevű parancsgomb található. A [vezérlő tulajdonsággyűjtemény](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) segítségével módosítja a szövegdoboz értékét és a gomb feliratát. Minden vezérlőnek van egy statikus előnézete is, amelyet a PowerPoint az aktiválás előtt megjeleníthet. Biztosítson egy PNG-t minden vezérlőhöz, amely az frissített szöveget és megjelenést mutatja. A példa ezeket a képeket a [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) segítségével rendeli hozzá.

A példa az első dián lévő minden vezérlőt 100 ponttal lefelé mozgatja a keretét a [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) beállításával. A szerkesztett prezentációt PPTM formátumban menti, majd a [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) segítségével elment egy második példányt, amelyben az összes ActiveX vezérlő eltávolításra került az adott diákról.

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

## **ActiveX média lejátszó vezérlő hozzáadása**

Egy konfigurált Windows Media Player vezérlő újrafelhasználásához kezdjen egy olyan sablonnal, amelynek az első diáján egy `WindowsMediaPlayer1` nevű lejátszó található. A [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) lemásolja az egész diát egy új prezentációba. A példa beállítja a lejátszó `URL`‑jét a [tulajdonsággyűjtemény](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) segítségével, és a klónozott diát az egyetlen diaként menti a kimenetbe. A videó külső marad, ezért válasszon egy olyan útvonalat, amelyhez a lejátszó a lejátszás közben hozzáfér.

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

## **GYIK**

**Megőrizheti az Aspose.Slides az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes olvasni és menteni a vezérlőket, beleértve azok tulajdonságait és pozícióit, anélkül, hogy aktiválná őket.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára, hogy interakcióba lépjenek a diával, például szöveget gépeljenek be vagy egy gombot kattintsanak. Egy [OLE objektum](/slides/hu/python-java/manage-ole/) lehetővé teszi, hogy a dia tartalmazzon vagy hivatkozzon egy másik alkalmazás által kezelt tartalomra, például egy Excel munkalapra.

**Kiváltanak még mindig VBA makrókat az ActiveX események, miután az Aspose.Slides‑szel mentem egy prezentációt?**

Mentse a prezentációt makrókat támogató formátumban, például PPTM‑ben, hogy megőrizze a VBA projektet. A Windows PowerPoint képes futtatni a meglévő eseménykezelőket, ha a biztonsági beállítások engedélyezik az ActiveX vezérlőket és a makrókat is.