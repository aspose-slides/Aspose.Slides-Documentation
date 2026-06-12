---
title: Macro VBA
type: docs
weight: 150
url: /it/python-net/examples/elements/vba-macro/
keywords:
- macro VBA
- aggiungi macro VBA
- accedi macro VBA
- rimuovi macro VBA
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Lavora con le macro VBA in Python usando Aspose.Slides: aggiungi o modifica progetti e moduli, firma o rimuovi macro, e salva le presentazioni in PPT, PPTX e ODP."
---
Illustra come aggiungere, accedere e rimuovere macro VBA utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi una macro VBA**

Crea una presentazione con un progetto VBA e un semplice modulo macro.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inizializza un progetto VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Aggiungi un modulo vuoto chiamato "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Accedi a una macro VBA**

Recupera il primo modulo dal progetto VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Rimuovi una macro VBA**

Elimina un modulo dal progetto VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Supponendo che la presentazione contenga un progetto VBA e almeno un modulo.
        module = presentation.vba_project.modules[0]

        # Rimuovi il modulo dal progetto.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```