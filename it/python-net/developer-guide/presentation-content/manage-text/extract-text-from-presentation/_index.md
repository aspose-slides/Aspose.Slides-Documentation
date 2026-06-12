---
title: Estrazione avanzata di testo da presentazioni in Python
linktitle: Estrai testo
type: docs
weight: 90
url: /it/python-net/extract-text-from-presentation/
keywords:
- estrarre testo
- estrarre testo da diapositiva
- estrarre testo da presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo da diapositiva
- recuperare testo da presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Estrai rapidamente testo da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET. Segui la nostra semplice guida passo passo per risparmiare tempo."
---
## **Panoramica**

Estrarre il testo dalle presentazioni è un'operazione comune ma essenziale per gli sviluppatori che lavorano con il contenuto delle diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere fondamentale per analisi, automazione, indicizzazione o migrazione di contenuti.

Questo articolo fornisce una guida completa su come estrarre in modo efficiente testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides for Python via .NET. Imparerai come iterare sistematicamente gli elementi della presentazione per recuperare con precisione il contenuto testuale di cui hai bisogno.

## **Estrarre testo da una diapositiva**

Aspose.Slides for Python via .NET fornisce lo spazio dei nomi [aspose.slides.util](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/) che include la classe [SlideUtil](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/). Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, usa il metodo [get_all_text_boxes](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Questo metodo accetta come parametro un oggetto di tipo [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/). Quando viene eseguito, il metodo scansiona l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/), preservando qualsiasi formattazione del testo.

Il frammento di codice seguente estrae tutto il testo dalla prima diapositiva della presentazione:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Estrarre testo da una presentazione**

Per scansionare il testo dell'intera presentazione, utilizza il metodo statico [get_all_text_frames](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/get_all_text_frames/) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/). Accetta due parametri:

1. Prima, un oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.  
2. Secondo, un valore `Boolean` che indica se le diapositive master devono essere incluse durante la scansione del testo nella presentazione.

Il metodo restituisce un array di oggetti di tipo [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/), includendo le informazioni di formattazione del testo. Il codice qui sotto scansiona il testo e i dettagli di formattazione da una presentazione, comprese le diapositive master.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Estrazione di testo categorizzata e veloce**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

L'argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/python-net/aspose.slides/textextractionarrangingmode/) indica la modalità per organizzare il risultato dell'estrazione del testo e può essere impostato sui seguenti valori:
- `UNARRANGED` - Il testo grezzo senza considerare la sua posizione sulla diapositiva.  
- `ARRANGED` - Il testo è disposto nello stesso ordine in cui appare sulla diapositiva.

La modalità `UNARRANGED` può essere usata quando la velocità è fondamentale; è più veloce della modalità `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationtext/) rappresenta il testo grezzo estratto dalla presentazione. La sua proprietà `slides_text` restituisce un array di oggetti di testo delle diapositive. Cada oggetto rappresenta il testo della diapositiva corrispondente e possiede le seguenti proprietà:

- `text` - Il testo all'interno delle forme della diapositiva.  
- `master_text` - Il testo all'interno delle forme della diapositiva master associate a questa diapositiva.  
- `layout_text` - Il testo all'interno delle forme della diapositiva layout associate a questa diapositiva.  
- `notes_text` - Il testo all'interno delle forme della diapositiva delle note associate a questa diapositiva.  
- `comments_text` - Il testo all'interno dei commenti associati a questa diapositiva.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**Quanto velocemente Aspose.Slides elabora presentazioni di grandi dimensioni durante l'estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [presentazioni di grandi dimensioni](/slides/it/python-net/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o in blocco.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati a grafici, consentendoti di accedere e analizzare il contenuto testuale nelle strutture di presentazione più comuni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre il testo usando la versione di prova gratuita di Aspose.Slides, anche se avrà [alcune limitazioni](/slides/it/python-net/licensing/), come l'elaborazione limitata a un numero ristretto di diapositive. Per un utilizzo illimitato e per gestire presentazioni di dimensioni maggiori, è consigliato acquistare una licenza completa.