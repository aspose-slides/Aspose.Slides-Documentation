---
title: Unterbrechung langlaufender Präsentationsvorgänge in PHP
linktitle: Präsentationsoperationen unterbrechen
type: docs
weight: 120
url: /de/php-java/support-for-interruptable-library/
keywords:
- Unterbrechungstoken
- Abbruch
- Konvertierungs-Timeout
- Folienexport
- PowerPoint
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie eine Präsentationskonvertierung mittels Timer abbrechen und die vor dem Abbruch exportierten Folien mit Aspose.Slides für PHP über Java zurückgeben."
---
## **Übersicht**

Aspose.Slides für PHP über Java kann langlaufende Vorgänge wie das Laden, Speichern und Rendern von Präsentationen unterbrechen. In einer Schleife, die Folien einzeln exportiert, ermöglicht dasselbe Token Ihrer Anwendung, vor der nächsten Folie zu stoppen und eine Liste der abgeschlossenen Exporte zurückzugeben.

Beide PHP‑Beispiele gehen davon aus, dass Ihr Bootstrap `define("JAVA_PREFER_VALUES", 1);` aufruft, bevor die Bridge‑Datei `Java.inc` geladen wird, und anschließend `aspose.slides.php` lädt. Diese Einstellung ermöglicht es PHP, Java‑Ausnahmen während des Aufrufs abzufangen. Die Beispiele prüfen die Ursache der umschlossenen Ausnahme, sodass andere Konvertierungsfehler zum Aufrufer durchdringen.

## **Eine Präsentationsoperation unterbrechen**

Erstellen Sie eine [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), holen Sie dessen Token mit [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), und übergeben Sie ihn an [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Geben Sie diese Optionen beim Erzeugen des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) an. Ein Aufruf von [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) fordert die Abbruch an. Ein laufender Vorgang stoppt, sobald er die Anforderung erkennt.

### **Ein Konvertierungs-Timeout festlegen**

Während PHP über die PHP/Java‑Bridge synchrones Laden oder Speichern wartet, kann ein Java‑Timer in einem separaten Thread die Abbruchanforderung stellen. Speichern Sie das folgende Hilfsprogramm als `ConversionTimeout.java`, kompilieren Sie es mit dem Aspose.Slides‑JAR im Klassenpfad und stellen Sie die kompilierte Klasse der Bridge unter ihrem Paketnamen `example.ConversionTimeout` zur Verfügung.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Nachdem die Bridge und der Aspose.Slides‑PHP‑Wrapper geladen sind, führen Sie das folgende Beispiel mit `sample.pptx` im Arbeitsverzeichnis des Java‑Prozesses aus, bzw. verwenden Sie absolute Pfade, die für diesen Prozess erreichbar sind. Das 20‑Sekunden‑Limit deckt sowohl das Laden als auch den PDF‑Export ab. Wird die Konvertierung frühzeitig beendet, canceln PHP den Timer. Um in das ältere PowerPoint‑Format mit einem 10‑Sekunden‑Limit zu konvertieren, verwenden Sie `sample.ppt`, `SaveFormat::Ppt` und `10000` Millisekunden.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Vor der Verarbeitung der nächsten Folie stoppen**

Überprüfen Sie vor jedem Export [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested), bevor Sie exportieren. Die Überladung von [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save), die ausgewählte Folien speichert, akzeptiert Foliennummern beginnend bei 1. Übergeben Sie ein Array mit einem Element, um ein separates PDF für jede Folie zu schreiben.

Verwenden Sie ein `sample.pptx` mit mindestens zwei Folien. Um die Abbruchzwischenexporte zu demonstrieren, fordert das Beispiel den Abbruch sofort nach dem Aufzeichnen der ersten Folie an.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

Das Beispiel schreibt `slide-1.pdf` und gibt `Completed: [1]` aus. Die zweite Iteration sieht die Anforderung, bevor ein weiterer Export startet. Tritt während eines Speichervorgangs ein Abbruch auf, enthält die Liste nur zuvor bestätigte Exporte. Ein unterbrochenes Speichern kann eine unvollständige Datei auf dem Datenträger hinterlassen.

Um den Abbruch an den Aufrufer weiterzugeben, ersetzen Sie die Prüfung zu Beginn der Schleife durch `$token->throwIfInterruptionRequested();` und entfernen das innere `try`/`catch`, wobei das Speichern und die danach folgende Prüfung erhalten bleiben. Mit derselben Eingabe wirft [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) eine Ausnahme vor Folie 2 und der Aufrufer erhält keine Liste.

## **FAQ**

**Wann sollte ich einen Abbruch anfordern?**

Fordern Sie einen Abbruch an, wenn eine Frist abläuft oder der Aufrufer das Ergebnis nicht mehr benötigt. Eine nach Abschluss eines Vorgangs gestellte Anforderung lässt das Ergebnis unverändert.

**Wie unterscheiden sich Quelle und Token?**

Die Quelle ermöglicht einer Anwendung, einen Abbruch anzufordern. Das Token ermöglicht Aspose.Slides und dem Anwendungscode, diese Anforderung zu beobachten.

**Können mehrere Vorgänge dieselbe Quelle teilen?**

Ja. Eine Anforderung gilt für alle Vorgänge, die Tokens aus dieser Quelle verwenden. Erstellen Sie separate Quellen für Vorgänge, die eine unabhängige Abbruchsteuerung benötigen.