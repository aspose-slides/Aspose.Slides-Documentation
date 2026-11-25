---
title: Unterbrechung langlaufender Präsentationsoperationen in Python
linktitle: Präsentationsoperationen unterbrechen
type: docs
weight: 120
url: /de/python-java/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungs-Token
- Abbruch-Token
- langlaufende Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie langlaufende Präsentationsvorgänge in Aspose.Slides für Python über Java abbrechen und bei der Schleifenexport von Folien ein Teilergebnis zurückgeben können."
---
## **Übersicht**

Aspose.Slides für Python über Java kann lang laufende Vorgänge wie das Laden, Speichern und Rendern von Präsentationen unterbrechen. Ihre Anwendung kann dasselbe Unterbrechungs‑Token verwenden, um eine Schleife zu stoppen, bevor sie die nächste Folie verarbeitet.

## **Unterbrechung eines Präsentationsvorgangs**

Erstellen Sie eine [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), erhalten Sie dessen Token mit [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), und übergeben Sie das Token an [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Übergeben Sie die Ladeoptionen an den [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Um eine Abbruchanforderung zu stellen, rufen Sie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) auf der Quelle auf. Ein unterbrechbarer Vorgang stoppt, wenn er die Anforderung erkennt. Verwenden Sie `jpype.JClass`, um die Java‑Ausnahme `com.aspose.slides.exceptions.OperationCanceledException` in Python abzufangen.

Das Beispiel konvertiert `sample.pptx` zu `sample.ppt` in einem Hintergrund‑Thread. Der aufrufende Thread wartet bis zu 10 Sekunden, bis die Konvertierung abgeschlossen ist. Läuft die Konvertierung noch, fordert es die Abbruch an und wartet, bis der Worker beendet ist.

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

## **Python‑Timeout mit Aspose.Slides verbinden**

Um ein Zeitlimit für einen Präsentationsvorgang festzulegen, benutzen Sie einen [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer), um [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) aufzurufen, wenn das Timeout abläuft. Das Beispiel gewährt 20 Sekunden zum Laden von `sample.pptx` und zum Exportieren nach `sample.pdf`. Wird der Export früh abgeschlossen, bricht die Anwendung die geplante Anforderung ab.

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

## **Vor dem Verarbeiten der nächsten Folie stoppen**

Verwenden Sie dasselbe [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) für die Präsentation und die Schleife, die deren Folien exportiert. Prüfen Sie [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) vor jedem Export. Falls der Aufrufer ein Teilergebnis nutzen kann, geben Sie die Foliennummern der erfolgreich abgeschlossenen Exporte zurück.

Verwenden Sie eine Präsentation namens `sample.pptx` mit mindestens zwei Folien. Die Überladung von [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), die ein Java `int[]` akzeptiert, verwendet Foliennummern beginnend bei 1. Nutzen Sie `jpype.JArray(jpype.JInt)`, um dieses Array in Python zu erstellen. Das Beispiel speichert jede Folie in ein separates PDF und fordert die Abbruchanforderung sofort nach dem ersten erfolgreichen Export an.

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

Das Beispiel schreibt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die Schleife erkennt die Anforderung, bevor Folie 2 gestartet wird. Kommt die Abbruchanforderung während eines Speichervorgangs, beendet die Schleife, bevor sie diese Folie als abgeschlossen markiert.

Falls der Aufrufer die Abbruchbehandlung übernehmen muss, ersetzen Sie die Prüfung und das `break` am Anfang der Schleife durch `token.throwIfInterruptionRequested()`. Entfernen Sie das `try`/`except` um den Save‑Vorgang, sodass ein Abbruch während eines Exports ebenfalls zum Aufrufer gelangt. Mit denselben Eingaben gibt das Beispiel nur `Starting slide 1` aus und schreibt `slide-1.pdf`. Zu Beginn der zweiten Iteration löst [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) `com.aspose.slides.exceptions.OperationCanceledException` aus, bevor der nächste Export beginnt. Die Ausnahme wird an den Aufrufer propagiert, bevor die Funktion die Liste zurückgeben kann.

## **FAQ**

**Wann sollte ich eine Abbruchanforderung stellen?**

Stellen Sie eine Abbruchanforderung, wenn ein Vorgang Ihr Zeitlimit überschreitet oder wenn Ihre Anwendung das Ergebnis nicht mehr benötigt.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Die Quelle ermöglicht Ihrer Anwendung, einen Abbruch anzufordern. Das Token ermöglicht Aspose.Slides und Ihrer Anwendung, diese Anforderung zu prüfen.

**Kann ich einen Vorgang von einem Python‑Timer aus abbrechen?**

Ja. Planen Sie einen Aufruf von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) auf der mit der Präsentation verknüpften Quelle.

**Welche Vorgänge kann ich unterbrechen?**

Sie können das Laden, Speichern und Rendern unterbrechen. Übergeben Sie das Token dem [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) über [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Die Präsentation kann dann während nachfolgender Vorgänge wie dem Speichern als PDF den Abbruch erkennen.

**Hört ein Vorgang sofort auf?**

Der Abbruch ist kooperativ. Ein Vorgang prüft das Token periodisch und stoppt, wenn er die Anforderung erkennt.

**Was passiert, wenn ich [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) nach Abschluss eines Vorgangs aufrufe?**

Der abgeschlossene Vorgang behält sein Ergebnis.

**Können mehrere Vorgänge dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) teilen?**

Ja. Ein Aufruf von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) fordert den Abbruch für jeden Vorgang an, der ein Token aus dieser Quelle verwendet. Verwenden Sie eine separate Quelle für jeden Vorgang, den Sie unabhängig abbrechen möchten.