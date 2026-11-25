---
title: Interrompere Operazioni di Presentazione a Lungo Termine in Python
linktitle: Interrompere Operazioni di Presentazione
type: docs
weight: 120
url: /it/python-java/support-for-interruptable-library/
keywords:
- operazioni interrompibili
- token di interruzione
- token di cancellazione
- attività a lunga durata
- interrompere attività
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come annullare operazioni di presentazione a lunga durata in Aspose.Slides per Python tramite Java e restituire un risultato parziale durante l'esportazione delle diapositive in un ciclo."
---
## **Panoramica**

Aspose.Slides for Python via Java può interrompere operazioni di lunga durata come il caricamento, il salvataggio e il rendering delle presentazioni. La tua applicazione può utilizzare lo stesso token di interruzione per fermare un ciclo prima che inizi a elaborare la diapositiva successiva.

## **Interrompere un'operazione di presentazione**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), ottieni il suo token con [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), e passa il token a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Passa le opzioni di caricamento al [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Per richiedere l'annullamento, chiama [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) sulla sorgente. Un'operazione interrompibile si interrompe quando rileva la richiesta. Usa `jpype.JClass` per catturare l'eccezione Java `com.aspose.slides.exceptions.OperationCanceledException` in Python.

L'esempio converte `sample.pptx` in `sample.ppt` in un thread in background. Il thread chiamante attende fino a 10 secondi il completamento della conversione. Se la conversione è ancora in esecuzione, richiede l'annullamento e attende che il worker termini.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Collegare un timeout Python a Aspose.Slides**

Per impostare un limite di tempo su un'operazione di presentazione, usa un [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) per chiamare [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) quando il timeout scade. L'esempio consente 20 secondi per caricare `sample.pptx` ed esportarlo in `sample.pdf`. Se l'esportazione termina in anticipo, l'applicazione annulla la richiesta programmata.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Interrompere prima di elaborare la diapositiva successiva**

Usa lo stesso [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) per la presentazione e per il ciclo che esporta le sue diapositive. Controlla [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) prima di ogni esportazione. Se il chiamante può utilizzare un risultato parziale, restituisci i numeri delle diapositive per le esportazioni completate con successo.

Usa una presentazione chiamata `sample.pptx` con almeno due diapositive. La sovraccarico di [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) che accetta un `int[]` Java utilizza i numeri di diapositiva a partire da 1. Usa `jpype.JArray(jpype.JInt)` per costruire quell'array in Python. L'esempio salva ogni diapositiva in un PDF separato e richiede l'annullamento subito dopo aver registrato la prima esportazione riuscita.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. Il ciclo osserva la richiesta prima di avviare la diapositiva 2. Se l'annullamento arriva durante un salvataggio, il ciclo termina prima di registrare quella diapositiva come completata.

Se il chiamante deve gestire l'annullamento, sostituisci il controllo e il relativo `break` all'inizio del ciclo con `token.throwIfInterruptionRequested()`. Rimuovi il `try`/`except` attorno al salvataggio in modo che l'annullamento durante un'esportazione raggiunga anche il chiamante. Con lo stesso input, l'esempio stampa solo `Starting slide 1` e scrive `slide-1.pdf`. All'inizio della seconda iterazione, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) solleva `com.aspose.slides.exceptions.OperationCanceledException` prima che inizi la prossima esportazione. L'eccezione si propaga al chiamante prima che la funzione possa restituire l'elenco.

## **FAQ**

**Quando dovrei richiedere l'annullamento?**

Richiedi l'annullamento quando un'operazione supera il tuo limite di tempo o quando la tua applicazione non ha più bisogno del risultato.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

La sorgente consente alla tua applicazione di richiedere l'annullamento. Il token consente ad Aspose.Slides e alla tua applicazione di verificare tale richiesta.

**Posso annullare un'operazione da un timer Python?**

Sì. Pianifica una chiamata a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) sulla sorgente associata alla presentazione.

**Quali operazioni posso interrompere?**

Puoi interrompere il caricamento, il salvataggio e il rendering. Passa il token al [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) tramite [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). La presentazione può quindi osservare l'annullamento durante operazioni successive, come il salvataggio in PDF.

**Un'operazione si interrompe immediatamente?**

L'annullamento è cooperativo. Un'operazione controlla periodicamente il token e si interrompe quando rileva la richiesta.

**Cosa succede se chiamo [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) dopo che un'operazione è terminata?**

L'operazione completata mantiene il suo risultato.

**Possono più operazioni condividere lo stesso [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Sì. Chiamare [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) richiede l'annullamento per ogni operazione che utilizza un token da quella sorgente. Usa una sorgente separata per ogni operazione che desideri annullare in modo indipendente.