---
title: Onderbreek langdurige presentatie-operaties op Android
linktitle: Onderbreek presentatieoperaties
type: docs
weight: 120
url: /nl/androidjava/support-for-interruptable-library/
keywords:
- onderbreekbare bewerkingen
- onderbrekingstoken
- annuleringstoken
- langdurige taak
- onderbreekbare taak
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u langdurige presentatie-operaties in Aspose.Slides voor Android via Java kunt annuleren en een gedeeltelijk resultaat kunt retourneren bij het exporteren van dia's in een lus."
---
## **Overzicht**

Aspose.Slides voor Android via Java kan langdurige bewerkingen onderbreken, zoals het laden, opslaan en renderen van presentaties. Uw applicatie kan dezelfde onderbrekingstoken gebruiken om een lus te stoppen voordat deze de volgende dia verwerkt.

## **Onderbreek een presentatiewerking**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) aan, verkrijg zijn token met [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), en geef het token door aan [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Geef de laadopties door aan de [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Om annulering aan te vragen, roep [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) aan op de bron. Een onderbreekbare bewerking stopt wanneer deze het verzoek opmerkt.

Het voorbeeld zet `sample.pptx` om naar `sample.ppt` op een achtergrondthread. De aanroepende thread wacht maximaal 10 seconden tot de conversie is voltooid. Als de conversie nog steeds loopt, vraagt het om annulering en wacht het tot de werker beëindigt.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Roep aan vanuit een achtergrondthread en geef context.getFilesDir() door, die sample.pptx bevat.
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

## **Verbind een Java‑timeout met Aspose.Slides**

Om een tijdslimiet voor een presentatie‑bewerking in te stellen, gebruik een [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) om [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) aan te roepen wanneer de timeout verloopt. Het voorbeeld staat 20 seconden toe om `sample.pptx` te laden en te exporteren naar `sample.pdf`. Als de export vroegtijdig voltooid is, annuleert de applicatie het geplande verzoek.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Roep aan vanuit een achtergrondthread en geef context.getFilesDir() door, die sample.pptx bevat.
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

## **Stop voordat de volgende dia wordt verwerkt**

Gebruik dezelfde [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) voor de presentatie en de lus die de dia's exporteert. Controleer [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) vóór elke export. Als de aanroeper een gedeeltelijk resultaat kan gebruiken, geef dan de diacijfers terug voor de exporten die succesvol zijn voltooid.

Gebruik een presentatie genaamd `sample.pptx` met ten minste twee dia's. De overload van [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) die een array met dianummers accepteert telt vanaf 1. Het voorbeeld slaat elke dia op in een afzonderlijke PDF en vraagt onmiddellijk na het registreren van de eerste succesvolle export om annulering.

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

    // Roep aan vanuit een achtergrondthread en geef context.getFilesDir() door, die sample.pptx bevat.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Het voorbeeld schrijft `slide-1.pdf` en print `Starting slide 1` gevolgd door `Completed: [1]`. De lus ziet het verzoek voordat dia 2 gestart wordt. Als de annulering tijdens een opslaan binnenkomt, verlaat de lus voordat die dia als voltooid wordt geregistreerd.

Als de aanroeper annulering moet afhandelen, vervang dan de controle en de `break` bovenaan de lus door `token.throwIfInterruptionRequested()`. Verwijder de `try`/`catch` rond het opslaan zodat annulering tijdens een export ook bij de aanroeper terechtkomt. Met dezelfde invoer print het voorbeeld alleen `Starting slide 1` en schrijft `slide-1.pdf`. Aan het begin van de tweede iteratie, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) gooit `com.aspose.slides.exceptions.OperationCanceledException` voordat de volgende export start. De methode retourneert geen lijst.

## **FAQ**

**Wanneer moet ik annulering aanvragen?**

Vraag annulering aan wanneer een bewerking uw tijdslimiet overschrijdt of wanneer uw applicatie het resultaat niet meer nodig heeft.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

De bron stelt uw applicatie in staat annulering aan te vragen. Het token laat Aspose.Slides en uw applicatie controleren op dat verzoek.

**Kan ik een bewerking annuleren vanuit een Java‑timer?**

Ja. Plan een aanroep van [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) in op de bron die bij de presentatie hoort.

**Welke bewerkingen kan ik onderbreken?**

U kunt het laden, opslaan en renderen onderbreken. Geef het token door aan de [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). De presentatie kan dan annulering waarnemen tijdens latere bewerkingen, zoals opslaan naar PDF.

**Stopt een bewerking onmiddellijk?**

Annulering is coöperatief. Een bewerking controleert periodiek het token en stopt wanneer het het verzoek waarneemt.

**Wat gebeurt er als ik [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) aanroep nadat een bewerking voltooid is?**

De voltooide bewerking behoudt zijn resultaat.

**Kunnen meerdere bewerkingen een [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) delen?**

Ja. Het aanroepen van [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) vraagt annulering voor elke bewerking die een token van die bron gebruikt. Gebruik een aparte bron voor elke bewerking die u onafhankelijk wilt annuleren.