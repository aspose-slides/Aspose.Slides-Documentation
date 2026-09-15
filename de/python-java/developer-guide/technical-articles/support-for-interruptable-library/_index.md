---
title: Unterstützung für eine unterbrechbare Bibliothek
type: docs
weight: 120
url: /de/python-java/support-for-interruptable-library/
keywords:
- unterbrechbare Bibliothek
- Unterbrechungs-Token
- Abbruch-Token
- langwierige Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Machen Sie langwierige Aufgaben mit Aspose.Slides für Python über Java abbrechbar. Unterbrechen Sie das Rendern und Konvertieren von PowerPoint und OpenDocument sicher, mit Beispielen."
---
## **Übersicht**

Aspose.Slides bietet einen unterbrechbaren Verarbeitungsmechanismus für langwierige Präsentationsaufgaben, wie Deserialisierung, Serialisierung und Rendering. Dieser Mechanismus basiert auf den Klassen [InterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/).

Ein [InterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontoken/) kann [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/) zugewiesen und dem Konstruktor von [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) übergeben werden. Wenn [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/#interrupt) aufgerufen wird, wird die zugehörige langwierige Aufgabe unterbrochen.

## **Unterbrechbare Bibliothek**

Aspose.Slides für Python über Java stellt die Klassen [InterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/) bereit. Sie ermöglichen das Unterbrechen langwieriger Aufgaben wie Deserialisierung, Serialisierung und Rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/) ist die Quelle der Token, die an [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setInterruptionToken) übergeben werden.
- Wenn [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setInterruptionToken) aufgerufen wird und die Instanz von [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/) dem Konstruktor von [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) übergeben wird, unterbricht das Aufrufen von [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/#interrupt) jede langwierige Aufgabe, die mit dieser [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) verknüpft ist.

Das folgende Code‑Snippet demonstriert das Unterbrechen einer laufenden Aufgabe:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Führt die Aktion in einem separaten Thread aus.
    time.sleep(10)  # Zeitüberschreitung.
    token_source.interrupt()  # Stoppt die Konvertierung.
```

## **FAQ**

**Was ist der Zweck der Aspose.Slides‑Interrupt‑Bibliothek?**

Sie bietet einen Mechanismus, um langwierige Vorgänge – wie das Laden, Speichern oder Rendern von Präsentationen – vor dem Abschluss zu unterbrechen. Dies ist nützlich, wenn die Verarbeitungszeit begrenzt werden muss oder die Aufgabe nicht mehr benötigt wird.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontoken/) wird an die Aspose.Slides‑API übergeben und während langwieriger Vorgänge geprüft.
- [InterruptionTokenSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/) wird in Ihrem Code verwendet, um Token zu erstellen und Unterbrechungen auszulösen, indem Sie [interrupt](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/#interrupt) aufrufen.

**Welche Vorgänge können unterbrochen werden?**

Jeder Aspose.Slides‑Vorgang, der ein [InterruptionToken](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontoken/) akzeptiert – zum Beispiel das Laden einer Präsentation mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) oder das Speichern mit [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) – kann unterbrochen werden.

**Findet die Unterbrechung sofort statt?**

Nein. Die Unterbrechung ist kooperativ: Der Vorgang prüft periodisch das Token und stoppt, sobald er erkennt, dass [interrupt](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/#interrupt) aufgerufen wurde.

**Was passiert, wenn ich [interrupt](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/#interrupt) aufrufe, nachdem eine Aufgabe bereits abgeschlossen ist?**

Nichts – der Aufruf hat keine Wirkung, wenn die entsprechende Aufgabe bereits beendet ist.

**Kann ich dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/) für mehrere Aufgaben wiederverwenden?**

Ja – nachdem Sie [interrupt](https://reference.aspose.com/slides/de/python-java/aspose.slides/interruptiontokensource/#interrupt) für diese Quelle aufgerufen haben, werden alle Aufgaben, die deren Token verwenden, unterbrochen. Verwenden Sie separate Token‑Quellen, um Aufgaben unabhängig zu verwalten.