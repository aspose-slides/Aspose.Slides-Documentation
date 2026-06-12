---
title: Gestisci le transizioni delle diapositive nelle presentazioni usando Python
linktitle: Transizione diapositiva
type: docs
weight: 90
url: /it/python-net/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- applica transizione diapositiva
- transizione diapositiva avanzata
- transizione Morph
- tipo di transizione
- effetto di transizione
- Python
- Aspose.Slides
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per Python tramite .NET, con una guida passo passo per le presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides for Python fornisce il controllo totale sulle transizioni delle diapositive, dalla selezione del tipo di transizione alla configurazione dei tempi e dei trigger come parte dei flussi di lavoro di presentazione automatizzati. È possibile impostare le diapositive affinché avanzino al clic e/o dopo un ritardo specificato e perfezionare il comportamento visivo con effetti come tagli dal nero o ingressi direzionali. La libreria supporta anche la transizione Morph introdotta in PowerPoint 2019, incluse le modalità che morph per oggetto, parola o carattere per creare un movimento fluido e coerente tra le diapositive.

## **Aggiungi transizioni alle diapositive**

Per rendere più semplice la comprensione, questo esempio dimostra come utilizzare Aspose.Slides for Python per gestire transizioni semplici delle diapositive. Gli sviluppatori possono applicare diversi effetti di transizione alle diapositive e personalizzarne il comportamento. Per creare una transizione semplice, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Applica una transizione alla diapositiva usando uno degli effetti dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitiontype/).
1. Salva il file di presentazione modificato.

```py
import aspose.slides as slides

# Istitanzia la classe Presentation per caricare un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Applica una transizione a cerchio alla diapositiva 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Applica una transizione a pettine alla diapositiva 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi transizioni avanzate alle diapositive**

In questa sezione abbiamo applicato un effetto di transizione semplice a una diapositiva. Per rendere quell'effetto più controllato e raffinato, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Applica una transizione alla diapositiva usando uno degli effetti dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitiontype/).
1. Configura la transizione per avanzare al clic, dopo un periodo di tempo specifico, o entrambi.
1. Salva il file di presentazione modificato.

Se **Advance On Click** è abilitato, la diapositiva avanza solo quando l'utente fa clic. Se la proprietà **Advance After Time** è impostata, la diapositiva avanza automaticamente dopo l'intervallo specificato.

```py
import aspose.slides as slides

# Istitanzia la classe Presentation per aprire un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Applica una transizione a cerchio alla diapositiva 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Abilita avanzamento al clic e imposta un avanzamento automatico di 3 secondi.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Applica una transizione a pettine alla diapositiva 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Abilita avanzamento al clic e imposta un avanzamento automatico di 5 secondi.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Applica una transizione zoom alla diapositiva 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Abilita avanzamento al clic e imposta un avanzamento automatico di 7 secondi.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Transizione Morph**

Aspose.Slides for Python supporta la [transizione Morph](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/morphtransition/), che anima il movimento fluido da una diapositiva alla successiva. Questa sezione spiega come utilizzare la transizione Morph. Per usarla efficacemente, sono necessarie due diapositive con almeno un oggetto in comune. L'approccio più semplice è duplicare una diapositiva e poi spostare l'oggetto in una posizione diversa nella seconda diapositiva.

Il frammento di codice seguente mostra come clonare una diapositiva che contiene testo e applicare una transizione Morph alla seconda diapositiva.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clona la prima diapositiva per creare una seconda diapositiva con le stesse forme per la continuità Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Seleziona lo stesso rettangolo sulla seconda diapositiva e modifica la sua posizione e dimensione.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Abilita la transizione Morph sulla seconda diapositiva per animare le modifiche della forma in modo fluido.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipi di transizione Morph**

L'enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionmorphtype/) rappresenta i diversi tipi di transizioni Morph delle diapositive.

Il frammento di codice seguente mostra come applicare una transizione Morph a una diapositiva e modificare il tipo di morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta effetti di transizione**

Aspose.Slides for Python ti consente di impostare effetti di transizione come **From Black**, **From Left**, **From Right**, ecc. Per configurare un effetto di transizione, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva.
1. Imposta l'effetto di transizione desiderato.
1. Salva la presentazione come file PPTX.

Nell'esempio seguente, impostiamo diversi effetti di transizione.

```py
import aspose.slides as slides

# Istitanzia la classe Presentation per aprire un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Applica una transizione Cut e abilita From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione della diapositiva?**

Sì. Imposta la [speed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/speed/) della transizione usando l'impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionspeed/) (ad esempio, slow/medium/fast).

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. È possibile incorporare un suono per la transizione e controllarne il comportamento tramite impostazioni come modalità suono e loop (ad esempio, [sound](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), oltre a metadati come [sound_is_built_in](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) e [sound_name](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Qual è il modo più veloce per applicare la stessa transizione a ogni diapositiva?**

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ciascuna diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive fornisce un risultato coerente.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Ispeziona le [transition settings](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/slide_show_transition/) della diapositiva e leggi il suo [transition type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/type/); quel valore ti indica esattamente quale effetto è stato applicato.