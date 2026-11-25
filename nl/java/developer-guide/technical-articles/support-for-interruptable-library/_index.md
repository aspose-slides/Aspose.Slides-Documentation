---
title: Onderbreek langdurige presentatiebewerkingen in Java
linktitle: Onderbreek presentatiebewerkingen
type: docs
weight: 120
url: /nl/java/support-for-interruptable-library/
keywords:
- onderbreekbare bewerkingen
- onderbrekingstoken
- annulerings‑token
- langdurige taak
- onderbreek taak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u langdurige presentatiebewerkingen kunt annuleren in Aspose.Slides for Java en een gedeeltelijk resultaat kunt retourneren bij het exporteren van dia's in een lus."
---
## **Overzicht**

Aspose.Slides for Java kan langdurige bewerkingen onderbreken, zoals het laden, opslaan en renderen van presentaties. Uw toepassing kan dezelfde onderbrekingstoken gebruiken om een lus te stoppen voordat deze de volgende dia verwerkt.

## **Onderbreek een presentatiebewerking**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), verkrijg zijn token met [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), en geef het token door aan [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Geef de load‑opties door aan de [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Om annulering aan te vragen, roep [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) aan op de bron. Een onderbreekbare bewerking stopt wanneer zij het verzoek opmerkt.

Het voorbeeld converteert `sample.pptx` naar `sample.ppt` op een achtergrondthread. De aanroepende thread wacht tot 10 seconden op het voltooien van de conversie. Als de conversie nog steeds draait, vraagt het om annulering en wacht het tot de worker afsluit.

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

## **Koppel een Java‑time‑out aan Aspose.Slides**

Om een tijdslimiet in te stellen voor een presentatiebewerking, gebruik een [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) om [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) aan te roepen wanneer de time‑out verloopt. Het voorbeeld staat 20 seconden toe om `sample.pptx` te laden en te exporteren naar `sample.pdf`. Als de export vroegtijdig voltooid is, annuleert de toepassing het geplande verzoek.

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

## **Stop vóór het verwerken van de volgende dia**

Gebruik dezelfde [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) voor de presentatie en de lus die haar dia's exporteert. Controleer [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) vóór elke export. Als de aanroeper een gedeeltelijk resultaat kan gebruiken, retourneer dan de dianummers van de exporten die succesvol voltooid zijn.

Gebruik een presentatie met de naam `sample.pptx` met ten minste twee dia's. De [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) overload die een array van dianummers accepteert telt vanaf 1. Het voorbeeld slaat elke dia op in een afzonderlijke PDF en vraagt direct na de eerste succesvolle export om annulering.

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

Het voorbeeld schrijft `slide-1.pdf` en drukt `Starting slide 1` af, gevolgd door `Completed: [1]`. De lus merkt het verzoek op vóór het starten van dia 2. Als annulering plaatsvindt tijdens het opslaan, verlaat de lus deze voordat de dia als voltooid wordt geregistreerd.

Als de aanroeper annulering moet afhandelen, vervang dan de controle en de bijbehorende `break` bovenaan de lus door `token.throwIfInterruptionRequested()`. Verwijder de `try`/`catch` rond het opslaan zodat annulering tijdens een export ook bij de aanroeper terechtkomt. Met dezelfde invoer drukt het voorbeeld alleen `Starting slide 1` af en schrijft `slide-1.pdf`. Aan het begin van de tweede iteratie gooit [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException` voordat de volgende export begint. De methode retourneert geen lijst.

## **Veelgestelde vragen**

**Wanneer moet ik annulering aanvragen?**

Vraag annulering aan wanneer een bewerking uw tijdslimiet overschrijdt of wanneer uw toepassing het resultaat niet meer nodig heeft.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

De bron stelt uw toepassing in staat om annulering aan te vragen. Het token stelt Aspose.Slides en uw toepassing in staat om dat verzoek te controleren.

**Kan ik een bewerking annuleren vanaf een Java‑timer?**

Ja. Plan een aanroep van [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) op de bron die aan de presentatie is gekoppeld.

**Welke bewerkingen kan ik onderbreken?**

U kunt het laden, opslaan en renderen onderbreken. Geef het token door aan de [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). De presentatie kan vervolgens annulering waarnemen tijdens opvolgende bewerkingen, zoals opslaan naar PDF.

**Stopt een bewerking onmiddellijk?**

Annulering is coöperatief. Een bewerking controleert periodiek het token en stopt wanneer ze het verzoek opmerkt.

**Wat gebeurt er als ik [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) aanroep nadat een bewerking is voltooid?**

De voltooide bewerking behoudt haar resultaat.

**Kunnen meerdere bewerkingen een [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) delen?**

Ja. Het aanroepen van [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) vraagt annulering aan voor elke bewerking die een token van die bron gebruikt. Gebruik een aparte bron voor elke bewerking die u onafhankelijk wilt annuleren.