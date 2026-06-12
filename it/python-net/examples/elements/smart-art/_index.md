---
title: SmartArt
type: docs
weight: 140
url: /it/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- aggiungi SmartArt
- accedi a SmartArt
- rimuovi SmartArt
- layout SmartArt
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e modifica SmartArt in Python con Aspose.Slides: aggiungi nodi, cambia layout e stili, converti in forme con precisione e esporta per PPT, PPTX e ODP."
---
Mostra come aggiungere grafica SmartArt, accedervi, rimuoverla e modificare i layout utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi SmartArt**

Inserisci una grafica SmartArt utilizzando uno dei layout predefiniti.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a SmartArt**

Recupera il primo oggetto SmartArt su una diapositiva.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi alla prima forma SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Rimuovi SmartArt**

Elimina una forma SmartArt dalla diapositiva.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un oggetto SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifica layout SmartArt**

Aggiorna il tipo di layout di una grafica SmartArt esistente.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un oggetto SmartArt.
        smart_art = slide.shapes[0]

        # Cambia il layout dello SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```