---
title: Animare testo PowerPoint in Python
linktitle: Testo animato
type: docs
weight: 60
url: /it/python-net/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python tramite .NET, con esempi di codice ottimizzati e facili da seguire."
---
## **Panoramica**

Questo articolo mostra come animare il testo nelle presentazioni PowerPoint usando Aspose.Slides per Python. Imparerai ad aggiungere effetti a singoli paragrafi, regolare i trigger e leggere le sequenze di animazione esistenti. Alla fine, sarai in grado di creare flussi di lavoro riutilizzabili per l'animazione del testo che esportano in PPTX standard e si riproducono correttamente in PowerPoint.

## **Aggiungere effetti di animazione al paragrafo**

Il metodo [add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/) della classe [Sequence](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/) consente di applicare un effetto di animazione a un singolo paragrafo. Il codice di esempio riportato di seguito dimostra come farlo:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Seleziona il paragrafo a cui aggiungere l'effetto.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Aggiungi un effetto di animazione Fly al paragrafo selezionato.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere gli effetti di animazione del paragrafo**

Potresti voler determinare quali effetti di animazione sono applicati a un paragrafo, ad esempio se intendi copiare tali effetti su un altro paragrafo o forma.

Aspose.Slides per Python consente di recuperare tutti gli effetti di animazione applicati ai paragrafi in un frame di testo (forma). Il codice di esempio riportato di seguito mostra come ottenere gli effetti di animazione di un paragrafo:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**In che modo le animazioni di testo differiscono dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni di testo controllano il comportamento di un oggetto nel tempo su una diapositiva, mentre le [transitions](/slides/it/python-net/slide-transition/) controllano il modo in cui le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è gestito dalla timeline dell'animazione e dalle impostazioni della transizione.

**Le animazioni di testo vengono preservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/python-net/convert-powerpoint-to-video/) o in [HTML](/slides/it/python-net/export-to-html5/).

**Le animazioni di testo funzionano nei layout e nel master delle diapositive?**

Gli effetti applicati agli oggetti di layout/master vengono ereditati dalle diapositive, ma la loro temporizzazione e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.