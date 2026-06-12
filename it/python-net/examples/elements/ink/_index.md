---
title: Inchiostro
type: docs
weight: 180
url: /it/python-net/examples/elements/ink/
keywords:
- inchiostro
- accedi all'inchiostro
- rimuovi inchiostro
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci l'inchiostro digitale sulle diapositive in Python con Aspose.Slides: aggiungi tratti di penna, modifica i percorsi, imposta colore e larghezza, ed esporta i risultati per PowerPoint e OpenDocument."
---
Fornisce esempi di accesso a forme di inchiostro esistenti e la loro rimozione utilizzando **Aspose.Slides for Python via .NET**.

> ❗ **Nota:** Le forme di inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuovi tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.

## **Accedi all'inchiostro**
Ottieni la prima forma di inchiostro da una diapositiva.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Rimuovi l'inchiostro**
Elimina una forma di inchiostro dalla diapositiva.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un oggetto Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```