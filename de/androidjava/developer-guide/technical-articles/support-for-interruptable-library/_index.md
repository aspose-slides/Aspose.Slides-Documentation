---
title: Unterbrechen langlaufender Präsentationsvorgänge auf Android
linktitle: Unterbrechen von Präsentationsvorgängen
type: docs
weight: 120
url: /de/androidjava/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungs-Token
- Abbruch-Token
- langlaufende Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie langlaufende Präsentationsvorgänge in Aspose.Slides für Android via Java abbrechen und bei der Exportierung von Folien in einer Schleife ein Teilergebnis zurückgeben."
---
## **Übersicht**

Aspose.Slides für Android via Java kann langlaufende Vorgänge wie das Laden, Speichern und Rendern von Präsentationen unterbrechen. Ihre Anwendung kann dasselbe Unterbrechungs‑Token verwenden, um eine Schleife zu stoppen, bevor sie die nächste Folie verarbeitet.

## **Unterbrechung eines Präsentationsvorgangs**

Erstellen Sie eine [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), erhalten Sie ihr Token mit [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), und übergeben Sie das Token an [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Übergeben Sie die Ladeoptionen an den [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Um eine Stornierung anzufordern, rufen Sie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) auf der Quelle auf. Ein unterbrechbarer Vorgang stoppt, sobald er die Anforderung erkennt.

Das Beispiel konvertiert `sample.pptx` nach `sample.ppt` in einem Hintergrund‑Thread. Der aufrufende Thread wartet bis zu 10 Sekunden, bis die Konvertierung abgeschlossen ist. Läuft die Konvertierung noch, fordert es die Stornierung an und wartet, bis der Worker beendet wird.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Aufruf von einem Hintergrundthread und Übergabe von context.getFilesDir(), das sample.pptx enthält.
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

## **Java‑Timeout mit Aspose.Slides verbinden**

Um ein Zeitlimit für einen Präsentationsvorgang festzulegen, verwenden Sie einen [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService), um [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) aufzurufen, wenn das Timeout abläuft. Das Beispiel lässt 20 Sekunden zum Laden von `sample.pptx` und zum Exportieren nach `sample.pdf` zu. Wird der Export früher abgeschlossen, bricht die Anwendung die geplante Anforderung ab.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Aufruf von einem Hintergrundthread und Übergabe von context.getFilesDir(), das sample.pptx enthält.
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

## **Stoppen, bevor die nächste Folie verarbeitet wird**

Verwenden Sie dasselbe [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) für die Präsentation und die Schleife, die ihre Folien exportiert. Prüfen Sie vor jedem Export [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) . Wenn der Aufrufer ein Teilergebnis verwenden kann, geben Sie die Foliennummern der erfolgreich abgeschlossenen Exporte zurück.

Verwenden Sie eine Präsentation mit dem Namen `sample.pptx`, die mindestens zwei Folien enthält. Der [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-)‑Überladung, die ein Array von Foliennummern akzeptiert, zählt ab 1. Das Beispiel speichert jede Folie in ein separates PDF und fordert die Stornierung sofort nach dem ersten erfolgreichen Export an.

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

    // Aufruf von einem Hintergrundthread und Übergabe von context.getFilesDir(), das sample.pptx enthält.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Das Beispiel schreibt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die Schleife erkennt die Anforderung, bevor Folie 2 gestartet wird. Wird die Stornierung während eines Speichervorgangs gesendet, beendet die Schleife den Vorgang, bevor sie diese Folie als abgeschlossen markiert.

Wenn der Aufrufer die Stornierung verarbeiten muss, ersetzen Sie die Prüfung und das `break` am Anfang der Schleife durch `token.throwIfInterruptionRequested()`. Entfernen Sie das `try`/`catch`‑Block um das Speichern, sodass eine Stornierung während eines Exports ebenfalls zum Aufrufer gelangt. Mit derselben Eingabe gibt das Beispiel nur `Starting slide 1` aus und schreibt `slide-1.pdf`. Zu Beginn der zweiten Iteration wirft [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException`, bevor der nächste Export beginnt. Die Methode gibt keine Liste zurück.

## **FAQ**

**Wann sollte ich die Stornierung anfordern?**

Fordern Sie die Stornierung an, wenn ein Vorgang Ihr Zeitlimit überschreitet oder Ihre Anwendung das Ergebnis nicht mehr benötigt.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Die Quelle ermöglicht Ihrer Anwendung, eine Stornierung anzufordern. Das Token erlaubt Aspose.Slides und Ihrer Anwendung, diese Anforderung zu prüfen.

**Kann ich einen Vorgang von einem Java‑Timer aus abbrechen?**

Ja. Planen Sie einen Aufruf von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) auf der Quelle, die der Präsentation zugeordnet ist.

**Welche Vorgänge kann ich unterbrechen?**

Sie können das Laden, Speichern und Rendern unterbrechen. Übergeben Sie das Token an den [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) über [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Die Präsentation kann dann während nachfolgender Vorgänge, etwa beim Speichern als PDF, die Stornierung erkennen.

**Stoppt ein Vorgang sofort?**

Die Stornierung ist kooperativ. Ein Vorgang prüft das Token periodisch und stoppt, sobald er die Anforderung erkennt.

**Was passiert, wenn ich [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) nach Abschluss eines Vorgangs aufrufe?**

Der bereits abgeschlossene Vorgang behält sein Ergebnis bei.

**Können mehrere Vorgänge dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) teilen?**

Ja. Ein Aufruf von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) fordert die Stornierung für jeden Vorgang an, der ein Token dieser Quelle verwendet. Verwenden Sie für jeden Vorgang, den Sie unabhängig abbrechen möchten, eine separate Quelle.