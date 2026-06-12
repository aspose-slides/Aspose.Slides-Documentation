---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/python-net/examples/elements/hyperlink/
keywords:
- collegamento ipertestuale
- aggiungi collegamento ipertestuale
- accedi al collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungi, modifica e rimuovi collegamenti ipertestuali in Python con Aspose.Slides: testo dei collegamenti, forme, diapositive, URL ed email; imposta destinazioni e azioni per PPT, PPTX e ODP."
---
Dimostra come aggiungere, accedere, rimuovere e aggiornare i collegamenti ipertestuali su forme utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi un collegamento ipertestuale**

Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito web esterno.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a un collegamento ipertestuale**

Leggi le informazioni del collegamento ipertestuale dalla porzione di testo di una forma.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Rimuovi un collegamento ipertestuale**

Rimuovi il collegamento ipertestuale dal testo di una forma.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiorna un collegamento ipertestuale**

Modifica la destinazione di un collegamento ipertestuale esistente. Usa `HyperlinkManager` per modificare il testo che contiene già un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Modificare un collegamento ipertestuale all'interno di testo esistente dovrebbe essere eseguito tramite
        # HyperlinkManager piuttosto che impostare direttamente la proprietà.
        # Questo imita il modo in cui PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```