---
title: Aggiungere diapositive alle presentazioni con Python
linktitle: Aggiungi diapositiva
type: docs
weight: 10
url: /it/python-net/add-slide-to-presentation/
keywords:
- aggiungi diapositiva
- crea diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via .NET—inserimento di diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Prima di aggiungere diapositive a una presentazione, è utile capire come PowerPoint le organizza. Ogni presentazione contiene una diapositiva master, layout diapositive opzionali e una o più diapositive normali. Ogni diapositiva ha un ID univoco e le diapositive normali sono ordinate tramite un indice basato su zero. Questo articolo mostra come utilizzare Aspose.Slides per Python per creare diapositive e scegliere i layout appropriati.

## **Aggiungere diapositive alle presentazioni**

Aspose.Slides permette di aggiungere nuove diapositive basate su layout esistenti. L'esempio di seguito itera su ogni layout nella presentazione, aggiunge una diapositiva che utilizza quel layout e poi salva il file.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Accedi al [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/).
1. Per ogni elemento in `presentation.layout_slides`, chiama `add_empty_slide` per aggiungere una diapositiva che utilizza quel layout.
1. Modifica facoltativamente le diapositive appena aggiunte.
1. Salva la presentazione come file PPTX.

```py
import aspose.slides as slides

# Istanzia la classe Presentation.
with slides.Presentation() as presentation:
    # Accedi alla collezione di diapositive.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Aggiungi una diapositiva vuota alla collezione di diapositive.
        slides.add_empty_slide(layout_slide)

    # Esegui alcune operazioni sulle diapositive appena aggiunte.

    # Salva la presentazione su disco.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. La libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/insert_clone/), quindi è possibile aggiungere una diapositiva all'indice richiesto anziché solo alla fine.

**I temi/stili vengono preservati quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master, e la nuova diapositiva eredita dal layout selezionato e dal master associato.

**Quale diapositiva è presente in una nuova "vuota" presentazione prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. È importante considerare questo quando si calcolano gli indici di inserimento.

**Come scegliere il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

In genere si sceglie il [LayoutSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/) che corrisponde alla struttura richiesta ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidelayouttype/)). Se tale layout è assente, è possibile [aggiungerlo al master](/slides/it/python-net/slide-layout/) e poi usarlo.