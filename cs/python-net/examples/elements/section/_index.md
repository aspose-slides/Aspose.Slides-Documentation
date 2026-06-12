---
title: Sekce
type: docs
weight: 90
url: /cs/python-net/examples/elements/section/
keywords:
- sekce
- sekce snímku
- přidat sekci
- přístup k sekci
- odstranit sekci
- přejmenovat sekci
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte sekce snímků v Pythonu s Aspose.Slides: vytvářejte, přejmenovávejte, snadno měňte pořadí, přesouvejte snímky mezi sekcemi a ovládejte viditelnost pro PPT, PPTX a ODP."
---
Příklady správy sekcí prezentace — přidání, přístupu, odebrání a přejmenování programově pomocí **Aspose.Slides for Python via .NET**.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidejte novou sekci a určete snímek, který označuje začátek sekce.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k sekci**

Získejte sekci z prezentace.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Přístup k sekci podle indexu.
        section = presentation.sections[0]
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Odstraňte sekci.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Přejmenovat sekci**

Změňte název existující sekce.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Přejmenujte sekci.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```