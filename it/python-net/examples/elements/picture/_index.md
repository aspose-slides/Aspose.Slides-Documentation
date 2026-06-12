---
title: Immagine
type: docs
weight: 50
url: /it/python-net/examples/elements/picture/
keywords:
- immagine
- cornice immagine
- aggiungi immagine
- accedi immagine
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Lavora con le immagini in Python usando Aspose.Slides: inserisci, sostituisci, ritaglia, comprimi, regola trasparenza ed effetti, riempi forme e esporta per PPT, PPTX e ODP."
---
Mostra come inserire e accedere alle immagini da immagini in memoria utilizzando **Aspose.Slides for Python via .NET**. Gli esempi di seguito creano un'immagine in memoria, la posizionano su una diapositiva e quindi la recuperano.

## **Aggiungi un'immagine**

Questo codice carica un'immagine da un file e la inserisce come cornice immagine sulla prima diapositiva.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Carica un'immagine da un file.
        with open("image.png", "rb") as image_stream:
            # Aggiungi l'immagine alle risorse della presentazione.
            image = presentation.images.add_image(image_stream)

        # Inserisci una cornice immagine che mostra l'immagine sulla prima diapositiva.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un'immagine**

Questo esempio verifica che una diapositiva contenga una cornice immagine e poi accede alla prima trovata.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi alla prima cornice immagine sulla diapositiva.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```