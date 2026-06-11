---
title: VbaMakro
type: docs
weight: 150
url: /sv/python-net/examples/elements/vba-macro/
keywords:
- VBA-makro
- lägg till VBA-makro
- åtkomst till VBA-makro
- ta bort VBA-makro
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med VBA-makron i Python med Aspose.Slides: lägg till eller redigera projekt och moduler, signera eller ta bort makron, och spara presentationer i PPT, PPTX och ODP."
---
Visar hur du lägger till, får tillgång till och tar bort VBA-makron med hjälp av **Aspose.Slides for Python via .NET**.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA-projekt och en enkel makro-modul.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Initiera ett VBA-projekt.
        presentation.vba_project = slides.vba.VbaProject()

        # Lägg till en tom modul med namnet "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA-projektet.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA-projektet.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Antar att presentationen innehåller ett VBA-projekt och minst en modul.
        module = presentation.vba_project.modules[0]

        # Ta bort modulen från projektet.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```