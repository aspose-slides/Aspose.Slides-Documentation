---
title: Unterbrechung langlaufender Präsentationsvorgänge in Java
linktitle: Präsentationsvorgänge unterbrechen
type: docs
weight: 120
url: /de/java/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungstoken
- Abbruchtoken
- langlaufende Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie langlaufende Präsentationsvorgänge in Aspose.Slides für Java abbrechen und bei der Schleifen‑basierten Folienexportierung ein Teilresultat zurückgeben."
---
## **Übersicht**

Aspose.Slides for Java kann langlaufende Vorgänge wie das Laden, Speichern und Rendern von Präsentationen unterbrechen. Ihre Anwendung kann denselben Unterbrechungstoken verwenden, um eine Schleife zu stoppen, bevor sie die nächste Folie verarbeitet.

## **Unterbrechen einer Präsentationsoperation**

Erstellen Sie eine [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), erhalten Sie dessen Token mit [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), und übergeben Sie das Token an [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Übergeben Sie die Ladeoptionen an den [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Um die Abbruchanforderung zu stellen, rufen Sie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) auf der Quelle auf. Ein unterbrechbarer Vorgang stoppt, sobald er die Anforderung erkennt.

Das Beispiel konvertiert `sample.pptx` nach `sample.ppt` in einem Hintergrund‑Thread. Der aufrufende Thread wartet bis zu 10 Sekunden, bis die Konvertierung abgeschlossen ist. Läuft die Konvertierung noch, wird eine Abbruchanforderung gestellt und auf das Beenden des Arbeiters gewartet.

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

## **Java‑Timeout mit Aspose.Slides verbinden**

Um ein Zeitlimit für einen Präsentationsvorgang festzulegen, verwenden Sie einen [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html), um [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) aufzurufen, wenn das Timeout abläuft. Das Beispiel erlaubt 20 Sekunden, um `sample.pptx` zu laden und nach `sample.pdf` zu exportieren. Wird der Export früher beendet, storniert die Anwendung die geplante Anforderung.

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

## **Stoppen, bevor die nächste Folie verarbeitet wird**

Verwenden Sie dasselbe [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) für die Präsentation und die Schleife, die deren Folien exportiert. Prüfen Sie vor jedem Export [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--). Wenn der Aufrufer ein Teilergebnis verwenden kann, geben Sie die Foliennummern der erfolgreich abgeschlossenen Exporte zurück.

Verwenden Sie eine Präsentation mit dem Namen `sample.pptx`, die mindestens zwei Folien enthält. Die [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-)-Überladung, die ein Array von Foliennummern akzeptiert, zählt ab 1. Das Beispiel speichert jede Folie in einer separaten PDF und fordert die Abbruchanforderung sofort nach dem ersten erfolgreichen Export an.

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

Das Beispiel erstellt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die Schleife erkennt die Anforderung, bevor Folie 2 gestartet wird. Wird die Abbruchanforderung während eines Speichervorgangs gestellt, beendet die Schleife sich, bevor sie diese Folie als abgeschlossen vermerkt.

Wenn der Aufrufer eine Abbruchbehandlung benötigt, ersetzen Sie die Prüfung und ihr `break` am Anfang der Schleife durch `token.throwIfInterruptionRequested()`. Entfernen Sie das `try`/`catch` um das Speichern, damit ein Abbruch während eines Exports ebenfalls den Aufrufer erreicht. Mit denselben Eingaben gibt das Beispiel nur `Starting slide 1` aus und schreibt `slide-1.pdf`. Zu Beginn der zweiten Iteration wirft [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException`, bevor der nächste Export startet. Die Methode liefert keine Liste.

## **FAQ**

**Wann sollte ich eine Abbruchanforderung stellen?**

Stellen Sie eine Abbruchanforderung, wenn ein Vorgang Ihr Zeitlimit überschreitet oder Ihre Anwendung das Ergebnis nicht mehr benötigt.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Die Quelle ermöglicht Ihrer Anwendung, eine Abbruchanforderung zu stellen. Das Token ermöglicht es Aspose.Slides und Ihrer Anwendung, diese Anforderung zu prüfen.

**Kann ich einen Vorgang über einen Java‑Timer abbrechen?**

Ja. Planen Sie einen Aufruf von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) für die mit der Präsentation verbundene Quelle.

**Welche Vorgänge kann ich unterbrechen?**

Sie können das Laden, Speichern und Rendern unterbrechen. Übergeben Sie das Token an den [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) über [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Die Präsentation kann dann während nachfolgender Vorgänge, z. B. beim Speichern als PDF, den Abbruch erkennen.

**Hält ein Vorgang sofort an?**

Der Abbruch ist kooperativ. Ein Vorgang prüft das Token periodisch und stoppt, sobald er die Anforderung erkennt.

**Was passiert, wenn ich [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) nach Abschluss eines Vorgangs aufrufe?**

Der abgeschlossene Vorgang behält sein Ergebnis.

**Können mehrere Vorgänge dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) teilen?**

Ja. Ein Aufruf von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) fordert den Abbruch für jeden Vorgang an, der ein Token aus dieser Quelle verwendet. Verwenden Sie für jede Operation, die Sie unabhängig abbrechen möchten, eine separate Quelle.