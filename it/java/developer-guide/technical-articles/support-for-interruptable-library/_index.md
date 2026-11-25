---
title: Interrompi operazioni di presentazione a lunga esecuzione in Java
linktitle: Interrompi le operazioni di presentazione
type: docs
weight: 120
url: /it/java/support-for-interruptable-library/
keywords:
- operazioni interrompibili
- token di interruzione
- token di cancellazione
- attività a lunga esecuzione
- interruzione attività
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come annullare operazioni di presentazione a lunga esecuzione in Aspose.Slides per Java e restituire un risultato parziale durante l'esportazione delle diapositive in un ciclo."
---
## **Panoramica**

Aspose.Slides per Java può interrompere operazioni a lungo termine come il caricamento, il salvataggio e il rendering delle presentazioni. La tua applicazione può utilizzare lo stesso token di interruzione per fermare un ciclo prima che inizi l'elaborazione della diapositiva successiva.

## **Interrompere un'operazione di presentazione**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), obtain its token with [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), and pass the token to [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). To request cancellation, call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) on the source. An interruptible operation stops when it observes the request.

L'esempio converte `sample.pptx` in `sample.ppt` in un thread in background. Il thread chiamante attende fino a 10 secondi il completamento della conversione. Se la conversione è ancora in esecuzione, richiede la cancellazione e attende che il worker termini.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Collegare un timeout Java a Aspose.Slides**

Per impostare un limite di tempo su un'operazione di presentazione, utilizza un [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) per chiamare [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) quando il timeout scade. L'esempio consente 20 secondi per caricare `sample.pptx` ed esportarlo in `sample.pdf`. Se l'esportazione termina in anticipo, l'applicazione annulla la richiesta programmata.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Interrompere prima di elaborare la diapositiva successiva**

Utilizza lo stesso [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) per la presentazione e per il ciclo che esporta le sue diapositive. Verifica [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) prima di ogni esportazione. Se il chiamante può utilizzare un risultato parziale, restituisci i numeri delle diapositive per le esportazioni completate con successo.

Usa una presentazione denominata `sample.pptx` con almeno due diapositive. La sovraccarico di [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) che accetta un array di numeri di diapositiva conta da 1. L'esempio salva ogni diapositiva in un PDF separato e richiede la cancellazione subito dopo aver registrato la prima esportazione riuscita.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. Il ciclo osserva la richiesta prima di avviare la diapositiva 2. Se la cancellazione arriva durante un salvataggio, il ciclo esce prima di registrare quella diapositiva come completata.

Se il chiamante deve gestire la cancellazione, sostituisci il controllo e il relativo `break` all'inizio del ciclo con `token.throwIfInterruptionRequested()`. Rimuovi il `try`/`catch` intorno al salvataggio in modo che la cancellazione durante un'esportazione raggiunga anche il chiamante. Con lo stesso input, l'esempio stampa solo `Starting slide 1` e scrive `slide-1.pdf`. All'inizio della seconda iterazione, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) genera `com.aspose.slides.exceptions.OperationCanceledException` prima che inizi la successiva esportazione. Il metodo non restituisce alcun elenco.

## **Domande frequenti**

**Quando dovrei richiedere la cancellazione?**

Richiedi la cancellazione quando un'operazione supera il tuo limite di tempo o quando la tua applicazione non ha più bisogno del risultato.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

La sorgente consente alla tua applicazione di richiedere la cancellazione. Il token permette ad Aspose.Slides e alla tua applicazione di verificare tale richiesta.

**Posso annullare un'operazione da un timer Java?**

Sì. Programma una chiamata a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) sulla sorgente associata alla presentazione.

**Quali operazioni posso interrompere?**

Puoi interrompere il caricamento, il salvataggio e il rendering. Passa il token al [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) tramite [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). La presentazione può quindi osservare la cancellazione durante operazioni successive, come il salvataggio in PDF.

**Un'operazione si interrompe immediatamente?**

La cancellazione è cooperativa. Un'operazione verifica il token periodicamente e si interrompe quando osserva la richiesta.

**Cosa succede se chiamo [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) dopo che un'operazione è terminata?**

L'operazione completata mantiene il suo risultato.

**Possono più operazioni condividere un [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Sì. Chiamare [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) richiede la cancellazione per ogni operazione che utilizza un token da quella sorgente. Usa una sorgente separata per ciascuna operazione che desideri annullare in modo indipendente.