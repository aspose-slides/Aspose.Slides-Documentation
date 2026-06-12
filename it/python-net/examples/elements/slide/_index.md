---
title: Diapositiva
type: docs
weight: 10
url: /it/python-net/examples/elements/slide/
keywords:
- diapositiva
- aggiungi diapositiva
- accedi alla diapositiva
- indice diapositiva
- clona diapositiva
- riordina diapositive
- rimuovi diapositiva
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le diapositive in Python con Aspose.Slides: crea, clona, riordina, nascondi, imposta sfondi e dimensioni, applica transizioni ed esporta per PowerPoint e OpenDocument."
---
Questo articolo fornisce una serie di esempi che dimostrano come lavorare con le diapositive utilizzando **Aspose.Slides for Python via .NET**. Imparerai come aggiungere, accedere, clonare, riordinare e rimuovere le diapositive utilizzando la classe `Presentation`.

Ogni esempio qui sotto include una breve spiegazione seguita da uno snippet di codice in Python.

## **Aggiungi una diapositiva**

Per aggiungere una nuova diapositiva, devi prima selezionare un layout. In questo esempio utilizziamo il layout `Blank` e aggiungiamo una diapositiva vuota alla presentazione.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Ogni diapositiva si basa su un layout, che a sua volta è basato su una diapositiva master.
        # Usa il layout Blank per creare una nuova diapositiva.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Aggiungi una nuova diapositiva vuota usando il layout selezionato.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Suggerimento:** Ogni layout di diapositiva è derivato da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposti. L'immagine seguente illustra come le diapositive master e i loro layout associati sono organizzati in PowerPoint.

![Relazione tra Master e Layout](master-layout-slide.png)

## **Accedi alle diapositive per indice**

Puoi accedere alle diapositive usando il loro indice. Questo è utile per iterare o modificare diapositive specifiche.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Accedi a una diapositiva per indice.
        first_slide = presentation.slides[0]
```

## **Clona una diapositiva**

Questo esempio dimostra come clonare una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della collezione di diapositive.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Clona la diapositiva; verrà aggiunta alla fine della presentazione.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Riordina le diapositive**

Puoi modificare l'ordine delle diapositive spostandone una in un nuovo indice. In questo caso, spostiamo una diapositiva nella prima posizione.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Sposta la diapositiva nella prima posizione (le altre si spostano verso il basso).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovi una diapositiva**

Per rimuovere una diapositiva, basta fare riferimento ad essa e chiamare `remove`. Questo esempio rimuove la prima diapositiva.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Rimuovi la diapositiva.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```