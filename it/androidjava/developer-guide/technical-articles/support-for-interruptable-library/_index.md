---
title: Interrompere operazioni di presentazione a lungo termine su Android
linktitle: Interrompere operazioni di presentazione
type: docs
weight: 120
url: /it/androidjava/support-for-interruptable-library/
keywords:
- operazioni interrompibili
- token di interruzione
- token di cancellazione
- attività a lungo termine
- interrompere attività
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come annullare operazioni di presentazione a lungo termine in Aspose.Slides per Android via Java e restituire un risultato parziale durante l'esportazione delle diapositive in un ciclo."
---
## **Panoramica**

Aspose.Slides for Android via Java può interrompere operazioni lunghe come il caricamento, il salvataggio e il rendering di presentazioni. La tua applicazione può usare lo stesso token di interruzione per fermare un ciclo prima che inizi a elaborare la diapositiva successiva.

## **Interrompere un'operazione di presentazione**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), ottieni il suo token con [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), e passa il token a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Passa le opzioni di caricamento al [costruttore Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Per richiedere la cancellazione, chiama [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) sulla sorgente. Un'operazione interrompibile si arresta quando osserva la richiesta.

L'esempio converte `sample.pptx` in `sample.ppt` su un thread in background. Il thread chiamante attende fino a 10 secondi la fine della conversione. Se la conversione è ancora in esecuzione, richiede la cancellazione e attende che il worker termini.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Chiamare da un thread in background e passare context.getFilesDir(), che contiene sample.pptx.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **Collegare un timeout Java ad Aspose.Slides**

Per impostare un limite di tempo su un'operazione di presentazione, usa un [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) per chiamare [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) quando il timeout scade. L'esempio consente 20 secondi per caricare `sample.pptx` ed esportarlo in `sample.pdf`. Se l'esportazione termina prima, l'applicazione annulla la richiesta pianificata.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Chiamare da un thread in background e passare context.getFilesDir(), che contiene sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Arrestare prima di elaborare la diapositiva successiva**

Usa lo stesso [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) per la presentazione e per il ciclo che esporta le sue diapositive. Controlla [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) prima di ogni esportazione. Se il chiamante può utilizzare un risultato parziale, restituisci i numeri delle diapositive per le esportazioni completate con successo.

Usa una presentazione denominata `sample.pptx` con almeno due diapositive. La sovraccarico [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) che accetta un array di numeri di diapositiva conta a partire da 1. L'esempio salva ogni diapositiva in un PDF separato e richiede la cancellazione immediatamente dopo aver registrato la prima esportazione riuscita.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Chiamare da un thread in background e passare context.getFilesDir(), che contiene sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. Il ciclo osserva la richiesta prima di avviare la diapositiva 2. Se la cancellazione arriva durante un salvataggio, il ciclo esce prima di registrare quella diapositiva come completata.

Se il chiamante deve gestire la cancellazione, sostituisci il controllo e il suo `break` all'inizio del ciclo con `token.throwIfInterruptionRequested()`. Rimuovi il `try`/`catch` attorno al salvataggio in modo che la cancellazione durante un'esportazione raggiunga anche il chiamante. Con lo stesso input, l'esempio stampa solo `Starting slide 1` e scrive `slide-1.pdf`. All'inizio della seconda iterazione, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) genera `com.aspose.slides.exceptions.OperationCanceledException` prima che inizi la successiva esportazione. Il metodo non restituisce alcun elenco.

## **FAQ**

**Quando dovrei richiedere l'annullamento?**

Richiedi l'annullamento quando un'operazione supera il limite di tempo o quando la tua applicazione non ha più bisogno del risultato.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

La sorgente consente alla tua applicazione di richiedere la cancellazione. Il token permette ad Aspose.Slides e alla tua applicazione di verificare tale richiesta.

**Posso annullare un'operazione da un timer Java?**

Sì. Pianifica una chiamata a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) sulla sorgente associata alla presentazione.

**Quali operazioni posso interrompere?**

Puoi interrompere il caricamento, il salvataggio e il rendering. Passa il token al [costruttore Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) tramite [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). La presentazione può quindi osservare la cancellazione durante operazioni successive, come il salvataggio in PDF.

**L'operazione si interrompe immediatamente?**

La cancellazione è cooperativa. Un'operazione controlla periodicamente il token e si ferma quando osserva la richiesta.

**Cosa succede se chiamo [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) dopo che un'operazione è terminata?**

L'operazione completata mantiene il suo risultato.

**Più operazioni possono condividere lo stesso [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Sì. Chiamare [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) richiede la cancellazione per ogni operazione che utilizza un token proveniente da quella sorgente. Usa una sorgente separata per ciascuna operazione che vuoi annullare indipendentemente.