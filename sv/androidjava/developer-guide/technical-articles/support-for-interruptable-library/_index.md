---
title: Avbryt långvariga presentationsoperationer på Android
linktitle: Avbryt presentationsoperationer
type: docs
weight: 120
url: /sv/androidjava/support-for-interruptable-library/
keywords:
- avbrottbara operationer
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du avbryter långvariga presentationsoperationer i Aspose.Slides för Android via Java och returnerar ett partiellt resultat när du exporterar bilder i en slinga."
---
## **Översikt**

Aspose.Slides for Android via Java kan avbryta långvariga operationer som att läsa in, spara och rendera presentationer. Din applikation kan använda samma avbrottstoken för att stoppa en slinga innan den börjar bearbeta nästa bild.

## **Avbryt en presentationsoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), hämta dess token med [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), och skicka token till [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Skicka in lastalternativen till [Presentation‑konstruktorn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). För att begära avbrytning, anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) på källan. En avbrottsbar operation stoppas när den observerar begäran.

Exemplet konverterar `sample.pptx` till `sample.ppt` på en bakgrundstråd. Den anropande tråden väntar i upp till 10 sekunder på att konverteringen ska slutföras. Om konverteringen fortfarande körs begär den avbrytning och väntar på att arbetstråden ska avslutas.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Anropa från en bakgrundstråd och skicka context.getFilesDir(), som innehåller sample.pptx.
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

## **Anslut en Java-timeout till Aspose.Slides**

För att sätta en tidsgräns på en presentationsoperation, använd en [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) för att anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) när timeouten löper ut. Exemplet tillåter 20 sekunder för att läsa in `sample.pptx` och exportera den till `sample.pdf`. Om exporten avslutas tidigt avbryter applikationen den schemalagda begäran.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Anropa från en bakgrundstråd och skicka context.getFilesDir(), som innehåller sample.pptx.
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

## **Stoppa innan nästa bild bearbetas**

Använd samma [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) för presentationen och slingan som exporterar dess bilder. Kontrollera [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) före varje export. Om anroparen kan använda ett partiellt resultat, returnera bildnumren för de exporter som slutförts framgångsrikt.

Använd en presentation med namnet `sample.pptx` som innehåller minst två bilder. Den [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) överlagring som tar en array av bildnummer räknar från 1. Exemplet sparar varje bild till en separat PDF och begär avbrytning omedelbart efter att den registrerat den första lyckade exporten.

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

    // Anropa från en bakgrundstråd och skicka context.getFilesDir(), som innehåller sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Slingan observerar begäran innan den startar bild 2. Om avbrytning kommer under en sparning avslutas slingan innan den registrerar den bilden som klar.

Om anroparen måste hantera avbrytning, ersätt kontrollen och dess `break` högst upp i slingan med `token.throwIfInterruptionRequested()`. Ta bort `try`/`catch`‑blocket runt sparandet så att avbrytning under en export också når anroparen. Med samma indata skriver exemplet bara ut `Starting slide 1` och skriver `slide-1.pdf`. I början av den andra iterationen kastar [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException` innan nästa export påbörjas. Metoden returnerar ingen lista.

## **Vanliga frågor**

**När bör jag begära avbrytning?**

Begär avbrytning när en operation överskrider din tidsgräns eller när din applikation inte längre behöver resultatet.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Källan låter din applikation begära avbrytning. Token låter Aspose.Slides och din applikation kontrollera den begäran.

**Kan jag avbryta en operation från en Java-timer?**

Ja. Schemalägg ett anrop till [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) på den källa som är associerad med presentationen.

**Vilka operationer kan jag avbryta?**

Du kan avbryta inläsning, sparning och rendering. Skicka token till [Presentation‑konstruktorn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Presentationen kan då observera avbrytning under efterföljande operationer, såsom sparning till PDF.

**Stoppar en operation omedelbart?**

Avbrytning är samarbetsbaserad. En operation kontrollerar token periodiskt och stoppar när den observerar begäran.

**Vad händer om jag anropar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) efter att en operation har avslutats?**

Den slutförda operationen behåller sitt resultat.

**Kan flera operationer dela en [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Ja. Att anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) begär avbrytning för varje operation som använder en token från den källan. Använd en separat källa för varje operation du vill avbryta oberoende.