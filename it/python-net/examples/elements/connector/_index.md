---
title: Connettore
type: docs
weight: 190
url: /it/python-net/examples/elements/connector/
keywords:
- connettore
- aggiungi connettore
- accedi al connettore
- rimuovi connettore
- ricollega forme
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Disegna e controlla i connettori in Python con Aspose.Slides: aggiungi, instrada, reinstrada, imposta i punti di connessione, le frecce e gli stili per collegare forme in PPT, PPTX e ODP."
---
Mostra come collegare forme con connettori e modificare i loro obiettivi usando **Aspose.Slides for Python via .NET**.

## **Aggiungi un connettore**

Inserisci una forma di connettore tra due punti sulla diapositiva.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi una forma di connettore piegato.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un connettore**

Recupera la prima forma di connettore aggiunta a una diapositiva.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi al primo connettore sulla diapositiva.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Rimuovi un connettore**

Elimina un connettore dalla diapositiva.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia un connettore.
        connector = slide.shapes[0]

        # Rimuovi il connettore.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ricollega forme**

Collega un connettore a due forme assegnando i target di inizio e fine.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Aggiungi la prima forma rettangolare.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Aggiungi la seconda forma rettangolare.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Aggiungi una forma di connettore piegato.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Collega l'inizio del connettore alla prima forma.
        connector.start_shape_connected_to = shape1
        # Collega la fine del connettore alla seconda forma.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```