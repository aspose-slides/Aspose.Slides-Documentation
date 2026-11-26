---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí Pythonu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/python-java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- spravovat ActiveX
- přidat ActiveX
- upravit ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Upravit textová pole a tlačítka ActiveX, aktualizovat náhledy ovládacích prvků a znovu použít ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro Python via Java."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní elementy, jako jsou textová pole, tlačítka příkazů a přehrávače médií. Aspose.Slides for Python via Java zpřístupňuje ovládací prvky snímku prostřednictvím [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunu na snímku nebo odstranění.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Pro prozkoumání neznámé šablony ji otevřete pro čtení a projděte ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) a každý pár klíč‑hodnota v [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Prezentaci načítá, aniž by aktivoval ovládací prvky, vyvolával události nebo makra, měnil hodnoty nebo ukládal soubor.

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

Vybraný výstup ze `ActiveX.pptm` ukazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazí jako `[]`. U ovládacích prvků, které používají binární úložiště, může [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) vrátit `None`, což je zobrazeno jako `Properties unavailable`. Pokud potřebujete jen názvy, použijte [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) po kontrole, že kolekce je dostupná. Zpráva uvádí vlastnosti dostupné z prezentace. Ovládací prvek může během běhu podporovat další vlastnosti.

## **Upravit ActiveX ovládací prvky**

Příklad očekává makrem povolenou prezentaci s textovým polem pojmenovaným `TextBox1` a tlačítkem příkazu pojmenovaným `CommandButton1` na prvním snímku. Používá [kolekci vlastností ovládacího prvku](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) ke změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek zobrazující aktualizovaný text a vzhled. Příklad přiřazuje tyto obrázky pomocí [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Příklad přesune každý ovládací prvek na prvním snímku o 100 bodů dolů nastavením jeho rámce pomocí [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Uloží upravenou prezentaci ve formátu PPTM a poté použije [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) k uložení druhé kopie bez všech ActiveX ovládacích prvků na tomto snímku.

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

## **Přidat ActiveX ovládací prvek přehrávače médií**

Pro opakované použití nakonfigurovaného ovládacího prvku Windows Media Player začněte se šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) zkopíruje celý snímek do nové prezentace. Příklad nastaví `URL` přehrávače v jeho [kolekci vlastností](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) a uloží klonovaný snímek jako jediný snímek výstupu. Video zůstává externí, takže zvolte cestu, ke které má přehrávač během přehrávání přístup.

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

## **Často kladené otázky**

**Dokáže Aspose.Slides zachovat ActiveX ovládací prvky, aniž by je spouštěl?**

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, aniž by je aktivoval.

**Jak se liší ActiveX ovládací prvky od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadávat text nebo kliknout na tlačítko. [OLE objekt](/slides/cs/python-java/manage-ole/) umožňuje, aby snímek obsahoval nebo odkazoval na obsah spravovaný jinou aplikací, například list Excelu.

**Spustí se po uložení prezentace pomocí Aspose.Slides stále události ActiveX, které spouštějí VBA makra?**

Uložte prezentaci do makrem povoleného formátu, například PPTM, aby byl zachován její VBA projekt. PowerPoint pro Windows může spustit stávající obslužné rutiny událostí, pokud jeho nastavení zabezpečení povolí jak ActiveX ovládací prvky, tak makra.