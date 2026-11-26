---
title: Správa ActiveX ovládacích prvků v prezentacích v Pythonu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/python-net/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- mediální přehrávač
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Upravujte ActiveX textová pole a tlačítka, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro Python přes .NET."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní prvky, jako jsou textová pole, tlačítka příkazů a mediální přehrávače. Aspose.Slides pro Python přes .NET zpřístupňuje ovládací prvky snímku prostřednictvím [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunutí na snímku nebo odebrání.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Chcete‑li prozkoumat neznámou šablonu, otevřete ji pro čtení a procházejte ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), a každý pár klíč‑hodnota v [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Prezentaci načte, aniž by aktivoval ovládací prvky, spouštěl události nebo makra, měnil hodnoty či ukládal soubor.

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

Vybraný výstup z `ActiveX.pptm` ukazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazuje jako `[]`. U ovládacích prvků, které používají binární úložiště, může `properties` vrátit `None`, zobrazené jako `Properties unavailable`. Pokud potřebujete jen názvy, použijte [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) po kontrole, zda není `None`. Zpráva uvádí vlastnosti dostupné v prezentaci. Ovládací prvek může během běhu podporovat další vlastnosti.

## **Úprava ActiveX ovládacích prvků**

Ukázka předpokládá makrem povolenou prezentaci s textovým polem pojmenovaným `TextBox1` a tlačítkem příkazu pojmenovaným `CommandButton1` na prvním snímku. Používá [kolekci vlastností ovládacího prvku](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) k změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek, zobrazující jeho aktualizovaný text a vzhled. Příklad přiřazuje tyto obrázky pomocí [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Ukázka posune každý ovládací prvek na prvním snímku o 100 bodů dolů změnou jeho [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Uloží upravenou prezentaci ve formátu PPTM a poté použije [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) k uložení druhé kopie s odebranými všemi ActiveX ovládacími prvky z tohoto snímku.

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

## **Přidání ActiveX ovládacího prvku Media Player**

Chcete‑li znovu použít nakonfigurovaný ovládací prvek Windows Media Player, začněte šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) zkopíruje celý snímek do nové prezentace. Příklad nastaví `URL` přehrávače v jeho [kolekci vlastností](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) a uloží klonovaný snímek jako jediný snímek ve výstupu. Video zůstává externí, proto zvolte cestu, ke které má přehrávač během přehrávání přístup.

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

## **Často kladené otázky**

**Může Aspose.Slides zachovat ActiveX ovládací prvky, aniž by je spouštěl?**

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, aniž by je aktivoval.

**Jak se ActiveX ovládací prvky liší od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadáním textu nebo kliknutím na tlačítko. O [OLE objekt](/slides/cs/python-net/manage-ole/) umožňuje snímku obsahovat nebo odkazovat na obsah spravovaný jinou aplikací, například sešit Excel.

**Spustí události ActiveX po uložení prezentace pomocí Aspose.Slides VBA makra?**

Uložte prezentaci ve formátu podporujícím makra, například PPTM, aby byl zachován její projekt VBA. PowerPoint pro Windows může spustit existující obslužné rutiny událostí, pokud nastavení zabezpečení povolí jak ActiveX ovládací prvky, tak makra.