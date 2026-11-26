---
title: ActiveX vezérlők kezelése prezentációkban Python segítségével
linktitle: ActiveX
type: docs
weight: 80
url: /hu/python-net/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Szerkessze az ActiveX szövegdobozokat és gombokat, frissítse a vezérlő előnézeteket, valamint használja újra a Windows Media Player vezérlőt PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével."
---
## **Bevezetés**

Az ActiveX vezérlők interaktív elemeket adnak egy PowerPoint diára, például szövegdobozokat, parancsgombokat és média lejátszókat. Az Aspose.Slides for Python via .NET a diák vezérlőit a [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) segítségével teszi elérhetővé. Használja ezt a gyűjteményt egy vezérlő szerkesztéséhez, áthelyezéséhez a dián, vagy eltávolításához.

## **ActiveX vezérlők listája és tárolt tulajdonságaik**

Egy ismeretlen sablon ellenőrzéséhez nyissa meg olvasási módban, és iteráljon végig a diákon lévő vezérlőkön. A példa jelentést készít a diaszámról, a vezérlő nevéről, a [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/) értékről, valamint a [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) kulcs-érték párokról. A prezentációt anélkül olvassa, hogy aktiválná a vezérlőket, eseményeket vagy makrókat hívna meg, értékeket módosítana, vagy a fájlt mentené.

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

A `ActiveX.pptm` kiválasztott kimenete egy szövegdobozt és egy parancsgombot mutat.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Az üres tulajdonsággyűjtemény `[]` formában jelenik meg. Azoknál a vezérlőknél, amelyek bináris tárolást használnak, a `properties` `None` értéket adhat vissza, ami `Properties unavailable`‑ként jelenik meg. Ha csak a nevekre van szüksége, használja a [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) metódust a `None` ellenőrzése után. A jelentés felsorolja a prezentációból elérhető tulajdonságokat. Egy vezérlő a futásidőben további tulajdonságokkal is rendelkezhet.

## **ActiveX vezérlők módosítása**

A példa egy makróval engedélyezett prezentációt vár, amelynek az első diáján egy `TextBox1` nevű szövegdoboz és egy `CommandButton1` nevű parancsgomb található. A [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) használatával módosítja a szövegdoboz értékét és a gomb feliratát. Minden vezérlőnek van egy statikus előnézete, amelyet a PowerPoint az aktiválás előtt megjeleníthet. Adjon meg egy PNG‑t minden vezérlőhöz, amely mutatja a frissített szöveget és megjelenést. A példa ezeket a képeket a [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) segítségével rendeli hozzá.

A példa minden vezérlőt az első dián 100 ponttal lefelé mozgat a [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) módosításával. A szerkesztett prezentációt PPTM formátumban menti, majd a [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) használatával egy második példányt ment, amelyből az összes ActiveX vezérlő el lett távolítva az adott diáról.

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

## **ActiveX média lejátszó vezérlő hozzáadása**

Egy már beállított Windows Media Player vezérlő újrahasználatához kezdjen egy olyan sablonnal, amelynek az első diája egy `WindowsMediaPlayer1` nevű lejátszót tartalmaz. A [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) lemásolja az egész diát egy új prezentációba. A példa beállítja a lejátszó `URL`‑jét a [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) segítségével, és az átmásolt diát az egyetlen diaként menti a kimenetbe. A videó külső marad, ezért válasszon egy olyan útvonalat, amelyhez a lejátszó a lejátszás során hozzáfér.

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

## **GYIK**

**Meg tudja őrizni az Aspose.Slides az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes a vezérlőket olvasni és menteni, beleértve azok tulajdonságait és pozícióit, anélkül hogy aktiválná őket.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára, hogy interakcióba lépjenek egy diával, például szöveget írjanak be vagy gombra kattintsanak. Egy [OLE object](/slides/hu/python-net/manage-ole/) lehetővé teszi, hogy egy dia tartalmazzon vagy hivatkozzon egy másik alkalmazás által kezelt tartalomra, például egy Excel munkalapra.

**Az ActiveX események továbbra is elindítják a VBA makrókat, miután a prezentációt az Aspose.Slides‑szel mentem?**

Mentse a prezentációt makróval engedélyezett formátumban, például PPTM‑ben, hogy megmaradjon a VBA projektje. A Windowsra készült PowerPoint képes futtatni a meglévő eseménykezelőket, ha a biztonsági beállítások engedélyezik mind az ActiveX vezérlőket, mind a makrókat.