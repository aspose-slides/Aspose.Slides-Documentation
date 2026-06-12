---
title: Casella di testo
type: docs
weight: 40
url: /it/python-net/examples/elements/text-box/
keywords:
- casella di testo
- aggiungi casella di testo
- accedi alla casella di testo
- rimuovi casella di testo
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e formatta le caselle di testo in Python con Aspose.Slides: imposta i caratteri, l'allineamento, il ritorno a capo, l'adattamento automatico e i collegamenti per perfezionare le diapositive per PowerPoint e OpenDocument."
---
In Aspose.Slides, una **casella di testo** è rappresentata da un `AutoShape`. Quasi qualsiasi forma può contenere testo, ma una tipica casella di testo non ha riempimento né bordo e mostra solo il testo.

Questa guida spiega come aggiungere, accedere e rimuovere le caselle di testo programmaticamente.

## **Aggiungi una casella di testo**

Una casella di testo è semplicemente un `AutoShape` senza riempimento né bordo e con del testo formattato. Ecco come crearne una:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Crea una forma rettangolare (predefinita riempita con bordo e senza testo).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Rimuovi riempimento e bordo per farla sembrare una casella di testo tipica.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Imposta la formattazione del testo.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Assegna il contenuto testuale reale.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Nota:** Qualsiasi `AutoShape` che contiene un `TextFrame` non vuoto può funzionare come una casella di testo.

## **Accedi alle caselle di testo per contenuto**

Per trovare tutte le caselle di testo che contengono una parola chiave specifica (ad es. "Slide"), itera attraverso le forme e controlla il loro testo:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Solo le AutoShape possono contenere testo modificabile.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Fai qualcosa con la casella di testo corrispondente.
                    pass
```

## **Rimuovi le caselle di testo per contenuto**

Questo esempio trova ed elimina tutte le caselle di testo nella prima diapositiva che contengono una parola chiave specifica:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Trova le forme da rimuovere che sono AutoShape contenenti la parola "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Rimuovi ogni forma corrispondente dalla diapositiva.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Suggerimento:** Crea sempre una copia della raccolta di forme prima di modificarla durante l'iterazione per evitare errori di modifica della collezione.