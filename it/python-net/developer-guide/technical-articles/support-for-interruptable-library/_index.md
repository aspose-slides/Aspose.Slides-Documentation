---
title: Interrompi operazioni di presentazione a lunga durata in Python
linktitle: Interrompi operazioni di presentazione
type: docs
weight: 150
url: /it/python-net/support-for-interruptable-library/
keywords:
- operazioni interruttibili
- token di interruzione
- annulla esportazione PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Scopri come annullare una conversione di presentazione in Python e restituire l'elenco delle diapositive che hanno completato l'esportazione prima della cancellazione."
---
## **Panoramica**

Aspose.Slides per Python tramite .NET supporta la cancellazione cooperativa durante operazioni a lunga durata come il caricamento, il salvataggio e il rendering delle presentazioni. Quando esporti le diapositive singolarmente, puoi anche verificare la cancellazione tra le diapositive e restituire i numeri delle diapositive che hanno completato l'esportazione.

## **Annulla la conversione di una presentazione**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), assegna il suo [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) a [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), e passa le opzioni al [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Il token si applica alla presentazione per tutta la sua durata. Per richiedere la cancellazione dalla tua applicazione, chiama [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

L'esempio converte `sample.pptx` in `sample.pdf`. Un [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) chiama `source.interrupt` dopo 20 secondi. Avviare il timer prima di aprire il file fa sì che il timeout si applichi sia al caricamento sia al salvataggio. Un'applicazione con un pulsante Annulla può chiamare lo stesso metodo dal gestore dell'evento.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

La verifica esplicita dopo il caricamento salta l'esportazione se il timeout è già scaduto. Se il caricamento o il salvataggio osservano la richiesta, l'eccezione di cancellazione raggiunge il chiamante. Un salvataggio può anche completarsi prima di osservare la richiesta, nel qual caso il PDF è completo.

## **Interrompi prima di elaborare la diapositiva successiva**

Verifica [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) prima di ogni esportazione. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) accetta un elenco di numeri di diapositiva a partire da 1. Aggiungi un numero all'elenco completato solo dopo che il relativo PDF è stato salvato correttamente.

Utilizza un file chiamato `sample.pptx` con almeno due diapositive. Per rendere il risultato riproducibile, l'esempio richiede la cancellazione non appena la diapositiva 1 termina. In un'applicazione, la richiesta può provenire da un altro thread mentre una diapositiva è in fase di salvataggio.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. L'iterazione successiva vede la richiesta prima di avviare la diapositiva 2. Se la cancellazione interrompe un salvataggio, il gestore delle eccezioni restituisce i numeri registrati dalle iterazioni precedenti. Altri errori di esportazione raggiungono il chiamante.

Se il chiamante deve gestire la cancellazione come un'eccezione, sostituisci la verifica e il suo `break` all'inizio del ciclo con [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Rimuovi anche il `try`/`except` attorno al salvataggio. Con lo stesso input, la diapositiva 1 viene salvata e la seconda iterazione genera un'eccezione di cancellazione prima di avviare la diapositiva 2.

## **FAQ**

**Quando ha effetto una richiesta di annullamento?**

Un'operazione interrompibile verifica periodicamente il suo token. Si arresta quando rileva la richiesta. Un'operazione già completata mantiene il suo risultato.

**Qual è la differenza tra la sorgente e il token?**

La sorgente consente alla tua applicazione di richiedere la cancellazione. Il token permette sia alla presentazione sia al tuo codice di verificare tale richiesta.

**Possono diverse operazioni condividere una sorgente?**

Sì. Chiamare `interrupt` richiede la cancellazione per ogni operazione che utilizza un token di quella sorgente. Assegna a ciascuna operazione la propria sorgente se hai bisogno di annullarla in modo indipendente.