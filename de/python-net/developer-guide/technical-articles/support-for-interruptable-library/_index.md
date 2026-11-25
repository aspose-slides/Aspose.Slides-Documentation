---
title: Unterbrechung lang laufender Präsentationsoperationen in Python
linktitle: Präsentationsoperationen unterbrechen
type: docs
weight: 150
url: /de/python-net/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungstoken
- PDF-Export abbrechen
- PowerPoint
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie eine Präsentationskonvertierung in Python abbrechen und die Liste der Folien zurückgeben, die vor dem Abbruch den Export abgeschlossen haben."
---
## **Übersicht**

Aspose.Slides for Python via .NET unterstützt kooperative Abbruchsteuerung bei lang laufenden Vorgängen wie dem Laden, Speichern und Rendern von Präsentationen. Wenn Sie Folien einzeln exportieren, können Sie außerdem zwischen den Folien auf einen Abbruch prüfen und die Nummern der Folien zurückgeben, die den Export abgeschlossen haben.

## **Abbruch einer Präsentationskonvertierung**

Erstellen Sie einen [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), weisen Sie dessen [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) dem [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) zu und übergeben Sie die Optionen an den [Presentation‑Konstruktor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Der Token gilt für die Präsentation während ihrer gesamten Lebensdauer. Um einen Abbruch aus Ihrer Anwendung anzufordern, rufen Sie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/) auf.

Das Beispiel konvertiert `sample.pptx` zu `sample.pdf`. Ein [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) ruft `source.interrupt` nach 20 Sekunden auf. Starten des Timers vor dem Öffnen der Datei lässt die Zeitüberschreitung sowohl beim Laden als auch beim Speichern gelten. Eine Anwendung mit einer Abbrechen‑Schaltfläche kann dieselbe Methode aus ihrem Ereignishandler aufrufen.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Die explizite Prüfung nach dem Laden überspringt den Export, wenn die Zeitüberschreitung bereits abgelaufen ist. Wenn Laden oder Speichern die Anforderung bemerken, erreicht die Abbruchs‑Ausnahme den Aufrufer. Ein Speichern kann auch abgeschlossen sein, bevor es die Anforderung bemerkt, in diesem Fall ist das PDF vollständig.

## **Anhalten, bevor die nächste Folie verarbeitet wird**

Prüfen Sie [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) vor jedem Export. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) akzeptiert eine Liste von Foliennummern, beginnend bei 1. Fügen Sie einer abgeschlossenen Liste eine Nummer erst hinzu, nachdem ihr PDF erfolgreich gespeichert wurde.

Verwenden Sie eine Datei namens `sample.pptx` mit mindestens zwei Folien. Um das Ergebnis reproduzierbar zu machen, fordert das Beispiel den Abbruch an, sobald Folie 1 abgeschlossen ist. In einer Anwendung kann die Anforderung von einem anderen Thread kommen, während eine Folie gespeichert wird.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Das Beispiel schreibt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die nächste Iteration erkennt die Anforderung, bevor Folie 2 gestartet wird. Wenn ein Abbruch ein Speichern unterbricht, gibt der Ausnahme‑Handler die von früheren Iterationen aufgezeichneten Nummern zurück. Andere Exportfehler erreichen den Aufrufer.

Wenn der Aufrufer den Abbruch als Ausnahme behandeln soll, ersetzen Sie die Prüfung und ihr `break` am Anfang der Schleife durch [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Entfernen Sie außerdem das `try`/`except` um das Speichern. Mit derselben Eingabe wird Folie 1 gespeichert und die zweite Iteration löst eine Abbruch‑Ausnahme aus, bevor Folie 2 gestartet wird.

## **FAQ**

**Wann tritt eine Abbruch‑Anforderung in Kraft?**

Ein unterbrechbarer Vorgang prüft sein Token periodisch. Er stoppt, wenn er die Anforderung bemerkt. Ein bereits abgeschlossener Vorgang behält sein Ergebnis bei.

**Was ist der Unterschied zwischen Quelle und Token?**

Die Quelle ermöglicht Ihrer Anwendung, einen Abbruch anzufordern. Das Token ermöglicht sowohl der Präsentation als auch Ihrem eigenen Code, nach dieser Anforderung zu prüfen.

**Können mehrere Vorgänge dieselbe Quelle teilen?**

Ja. Der Aufruf von `interrupt` fordert den Abbruch für jeden Vorgang an, der ein Token dieser Quelle verwendet. Geben Sie jedem Vorgang seine eigene Quelle, wenn Sie ihn unabhängig abbrechen müssen.