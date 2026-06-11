---
title: Makro VBA
type: docs
weight: 150
url: /pl/python-net/examples/elements/vba-macro/
keywords:
- makro VBA
- dodaj makro VBA
- uzyskaj dostęp do makra VBA
- usuń makro VBA
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Pracuj z makrami VBA w Pythonie przy użyciu Aspose.Slides: dodawaj lub edytuj projekty i moduły, podpisuj lub usuń makra oraz zapisuj prezentacje w formatach PPT, PPTX i ODP."
---
Ilustruje, jak dodać, uzyskać dostęp i usunąć makra VBA przy użyciu **Aspose.Slides for Python via .NET**.

## **Add a VBA Macro**
Dodaj makro VBA

Utwórz prezentację z projektem VBA i prostym modułem makr.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inicjalizuj projekt VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Dodaj pusty moduł o nazwie "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Access a VBA Macro**
Uzyskaj dostęp do makra VBA

Pobierz pierwszy moduł z projektu VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Remove a VBA Macro**
Usuń makro VBA

Usuń moduł z projektu VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Zakładając, że prezentacja zawiera projekt VBA i przynajmniej jeden moduł.
        module = presentation.vba_project.modules[0]

        # Usuń moduł z projektu.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```