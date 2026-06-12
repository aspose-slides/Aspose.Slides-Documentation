---
title: VBA makro
type: docs
weight: 150
url: /cs/python-net/examples/elements/vba-macro/
keywords:
- VBA makro
- přidat VBA makro
- přístup k VBA makru
- odstranit VBA makro
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Práce s VBA makry v Pythonu pomocí Aspose.Slides: přidávejte nebo upravujte projekty a moduly, podepisujte nebo odstraňujte makra a ukládejte prezentace ve formátech PPT, PPTX a ODP."
---
Ukazuje, jak přidávat, přistupovat k a odstraňovat VBA makra pomocí **Aspose.Slides for Python via .NET**.

## **Přidat VBA makro**

Vytvořte prezentaci s VBA projektem a jednoduchým modulem makra.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inicializovat VBA projekt.
        presentation.vba_project = slides.vba.VbaProject()

        # Přidat prázdný modul s názvem "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Přístup k VBA makru**

Získejte první modul z VBA projektu.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Odstranit VBA makro**

Odstraňte modul z VBA projektu.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Předpokládá se, že prezentace obsahuje VBA projekt a alespoň jeden modul.
        module = presentation.vba_project.modules[0]

        # Odstranit modul z projektu.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```