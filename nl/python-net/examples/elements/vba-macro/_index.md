---
title: VbaMacro
type: docs
weight: 150
url: /nl/python-net/examples/elements/vba-macro/
keywords:
- VBA-macro
- VBA-macro toevoegen
- VBA-macro openen
- VBA-macro verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk met VBA-macro's in Python met Aspose.Slides: voeg projecten en modules toe of bewerk ze, onderteken of verwijder macro's, en sla presentaties op in PPT, PPTX en ODP."
---
Toont hoe u VBA-macro's kunt toevoegen, openen en verwijderen met **Aspose.Slides for Python via .NET**.

## **VBA-macro toevoegen**

Maak een presentatie met een VBA-project en een eenvoudige macro-module.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Initialiseer een VBA-project.
        presentation.vba_project = slides.vba.VbaProject()

        # Voeg een lege module toe met de naam "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA-macro openen**

Haal de eerste module op uit het VBA-project.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA-macro verwijderen**

Verwijder een module uit het VBA-project.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Aangenomen dat de presentatie een VBA-project bevat en minstens één module.
        module = presentation.vba_project.modules[0]

        # Verwijder de module uit het project.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```