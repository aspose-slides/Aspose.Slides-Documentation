---
title: Estrazione avanzata del testo dalle presentazioni in Python via Java
linktitle: Estrai testo
type: docs
weight: 90
url: /it/python-java/extract-text-from-presentation/
keywords:
- estrarre testo
- estrarre testo dalla diapositiva
- estrarre testo dalla presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo dalla diapositiva
- recuperare testo dalla presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Estrai rapidamente il testo da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via Java. Segui la nostra semplice guida passo passo per risparmiare tempo."
---
## **Panoramica**

Estrarre testo dalle presentazioni è un'operazione comune ma fondamentale per gli sviluppatori che lavorano con contenuti diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere cruciale per analisi, automazione, indicizzazione o migrazione dei contenuti.

Questo articolo fornisce una guida completa su come estrarre efficientemente testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides per Python via Java. Imparerai come iterare sistematicamente attraverso gli elementi della presentazione per recuperare con precisione il contenuto testuale di cui hai bisogno.

## **Estrarre testo da una diapositiva**

Aspose.Slides per Python via Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/). Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, utilizza il metodo [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/#getAllTextBoxes). Questo metodo accetta come parametro un oggetto di tipo [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/). Quando eseguito, il metodo scansiona l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/), mantenendo qualsiasi formattazione del testo.

Il seguente frammento di codice estrae tutto il testo dalla prima diapositiva della presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Estrarre testo da una presentazione**

Per scansionare il testo dell'intera presentazione, utilizza il metodo statico [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/#getAllTextFrames) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/). Accetta due parametri:

1. Primo, un oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.
1. Secondo, un valore `bool` che indica se le diapositive master debbano essere incluse durante la scansione del testo della presentazione.

Il metodo restituisce un array di oggetti di tipo [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/), includendo le informazioni di formattazione del testo. Il codice qui sotto scansiona il testo e i dettagli di formattazione da una presentazione, incluse le diapositive master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Estrazione di testo categorizzata e veloce**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Estrai il testo da un file.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Estrai il testo da uno stream.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Estrai il testo da uno stream usando le opzioni di caricamento.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

L'argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/textextractionarrangingmode/) indica la modalità per organizzare il risultato dell'estrazione del testo e può essere impostato sui seguenti valori:

- [Unarranged](https://reference.aspose.com/slides/it/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - Il testo grezzo senza considerare la sua posizione sulla diapositiva.
- [Arranged](https://reference.aspose.com/slides/it/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - Il testo è disposto nello stesso ordine della diapositiva.

La modalità Unarranged può essere usata quando la velocità è critica; è più veloce della modalità Arranged.

[PresentationText](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationtext/) rappresenta il testo grezzo estratto dalla presentazione. Il suo metodo [getSlidesText](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationtext/#getSlidesText) restituisce un array di oggetti di tipo `SlideText`. Ogni oggetto rappresenta il testo sulla diapositiva corrispondente. L'oggetto di tipo `SlideText` ha i seguenti metodi:

- `getText` - Il testo all'interno delle forme della diapositiva.
- `getMasterText` - Il testo all'interno delle forme della diapositiva master associate a questa diapositiva.
- `getLayoutText` - Il testo all'interno delle forme della diapositiva layout associate a questa diapositiva.
- `getNotesText` - Il testo all'interno delle forme della diapositiva note associate a questa diapositiva.
- `getCommentsText` - Il testo all'interno dei commenti associati a questa diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **Domande frequenti**

**Quanto velocemente Aspose.Slides elabora grandi presentazioni durante l'estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [grandi presentazioni](/slides/it/python-java/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o in batch.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati ai grafici, così puoi accedere e analizzare il contenuto testuale nelle strutture comuni delle presentazioni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre testo usando la versione di prova gratuita di Aspose.Slides, anche se avrà [alcune limitazioni](/slides/it/python-java/licensing/), come la possibilità di elaborare solo un numero limitato di diapositive. Per un uso senza restrizioni e per gestire presentazioni più grandi, è consigliato acquistare una licenza completa.