---
title: Avbryt långvariga presentationsoperationer i Java
linktitle: Avbryt presentationsoperationer
type: docs
weight: 120
url: /sv/java/support-for-interruptable-library/
keywords:
- avbrottbara operationer
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du avbryter långvariga presentationsoperationer i Aspose.Slides för Java och returnerar ett delresultat när du exporterar bilder i en loop."
---
## **Översikt**

Aspose.Slides for Java kan avbryta långvariga operationer såsom inläsning, sparande och rendering av presentationer. Din applikation kan använda samma avbrottstoken för att stoppa en loop innan den börjar bearbeta nästa bild.

## **Avbryt en presentationoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), hämta dess token med [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), och skicka token till [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Skicka in lastalternativen till [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). För att begära avbrytning, anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) på källan. En avbrottbar operation stoppas när den observerar begäran.

Exemplet konverterar `sample.pptx` till `sample.ppt` i en bakgrundstråd. Den anropande tråden väntar upp till 10 sekunder på att konverteringen ska slutföras. Om konverteringen fortfarande körs begär den avbrytning och väntar på att arbetaren ska avslutas.

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

## **Koppla en Java-timeout till Aspose.Slides**

För att ange en tidsgräns för en presentationoperation, använd en [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) för att anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) när timeouten löper ut. Exemplet tillåter 20 sekunder att läsa in `sample.pptx` och exportera den till `sample.pdf`. Om exporten slutförs tidigt avbryter applikationen den schemalagda begäran.

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

## **Stoppa innan nästa bild bearbetas**

Använd samma [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) för presentationen och loopen som exporterar dess bilder. Kontrollera [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) före varje export. Om anroparen kan använda ett delresultat, returnera bildnumren för de exporteringar som slutfördes framgångsrikt.

Använd en presentation med namnet `sample.pptx` som har minst två bilder. Överlagringen [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) som tar en array av bildnummer räknar från 1. Exemplet sparar varje bild till en separat PDF och begär avbrytning omedelbart efter att den registrerat den första lyckade exporten.

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

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Loopen observerar begäran innan bild 2 startas. Om avbrytning kommer under en sparning, avslutar loopen innan den registrerar den bilden som slutförd.

Om anroparen behöver hantera avbrytning, ersätt kontrollen och dess `break` högst upp i loopen med `token.throwIfInterruptionRequested()`. Ta bort `try`/`catch` kring sparandet så att avbrytning under en export även når anroparen. Med samma indata skriver exemplet bara ut `Starting slide 1` och skriver `slide-1.pdf`. I början av den andra iterationen kastar [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException` innan nästa export påbörjas. Metoden returnerar ingen lista.

## **Vanliga frågor**

**När bör jag begära avbrytning?**

Begär avbrytning när en operation överskrider din tidsgräns eller när din applikation inte längre behöver resultatet.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Källan låter din applikation begära avbrytning. Token låter Aspose.Slides och din applikation kontrollera den begäran.

**Kan jag avbryta en operation från en Java-timer?**

Ja. Schemalägg ett anrop till [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) på källan som är kopplad till presentationen.

**Vilka operationer kan jag avbryta?**

Du kan avbryta inläsning, sparande och rendering. Skicka token till [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Presentationen kan sedan observera avbrytning under efterföljande operationer såsom sparande till PDF.

**Stoppar en operation omedelbart?**

Avbrytning är kooperativ. En operation kontrollerar token periodiskt och stoppar när den observerar begäran.

**Vad händer om jag anropar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) efter att en operation har avslutats?**

Den avslutade operationen behåller sitt resultat.

**Kan flera operationer dela en [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Ja. Att anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) begär avbrytning för varje operation som använder en token från den källan. Använd en separat källa för varje operation du vill avbryta oberoende.