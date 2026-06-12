---
title: Oggetto OLE
type: docs
weight: 210
url: /it/python-net/examples/elements/ole-object/
keywords:
- oggetto OLE
- aggiungi oggetto OLE
- accedi all'oggetto OLE
- rimuovi oggetto OLE
- aggiorna oggetto OLE
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Lavora con gli oggetti OLE in Python utilizzando Aspose.Slides: inserisci o aggiorna file incorporati, imposta icone o collegamenti, estrai contenuti, controlla il comportamento per PPT, PPTX e ODP."
---
Dimostra come incorporare un file come oggetto OLE e aggiornare i suoi dati utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi un oggetto OLE**

Incorpora un file PDF nella presentazione.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Carica i dati PDF da incorporare.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Aggiungi un frame oggetto OLE alla diapositiva.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un oggetto OLE**

Recupera il primo frame dell'oggetto OLE su una diapositiva.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Ottieni il primo frame oggetto OLE sulla diapositiva.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Rimuovi un oggetto OLE**

Elimina un oggetto OLE incorporato dalla diapositiva.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un oggetto OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiorna i dati dell'oggetto OLE**

Sostituisci i dati incorporati in un oggetto OLE esistente.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un oggetto OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Aggiorna l'oggetto OLE con i nuovi dati incorporati.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```