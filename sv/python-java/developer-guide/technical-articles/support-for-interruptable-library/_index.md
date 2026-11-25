---
title: Avbryt långvariga presentationsoperationer i Python
linktitle: Avbryt presentationsoperationer
type: docs
weight: 120
url: /sv/python-java/support-for-interruptable-library/
keywords:
- avbrytbara operationer
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du avbryter långvariga presentationsoperationer i Aspose.Slides för Python via Java och returnerar ett delresultat när du exporterar bilder i en slinga."
---
## **Översikt**

Aspose.Slides för Python via Java kan avbryta långvariga operationer såsom inläsning, sparande och rendering av presentationer. Din applikation kan använda samma avbrottstoken för att stoppa en loop innan den börjar bearbeta nästa bild.

## **Avbryt en presentationsoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), hämta dess token med [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), och skicka token till [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Skicka inlastningsalternativen till [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). För att begära avbrytning, anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) på källan. En avbrottbar operation stoppar när den observerar begäran. Använd `jpype.JClass` för att fånga Java‑undantaget `com.aspose.slides.exceptions.OperationCanceledException` i Python.

Exemplet konverterar `sample.pptx` till `sample.ppt` på en bakgrundstråd. Den anropande tråden väntar upp till 10 sekunder på att konverteringen ska slutföras. Om konverteringen fortfarande körs begär den avbrytning och väntar på att arbetaren ska avslutas.

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

## **Koppla en Python-timeout till Aspose.Slides**

För att ange en tidsgräns för en presentationsoperation, använd en [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) för att anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) när timeouten löper ut. Exemplet tillåter 20 sekunder för att läsa in `sample.pptx` och exportera den till `sample.pdf`. Om exporten avslutas tidigt, avbryter applikationen den schemalagda begäran.

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

## **Stoppa innan nästa bild bearbetas**

Använd samma [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) för presentationen och loopen som exporterar dess bilder. Kontrollera [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) före varje export. Om anroparen kan använda ett delresultat, returnera bildnumren för de exporter som slutförts framgångsrikt.

Använd en presentation med namnet `sample.pptx` som har minst två bilder. Överlagringen [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) som tar en Java `int[]` använder bildnummer med början på 1. Använd `jpype.JArray(jpype.JInt)` för att bygga den arrayen i Python. Exemplet sparar varje bild till en separat PDF och begär avbrytning omedelbart efter att den har registrerat den första lyckade exporten.

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

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Loopen observerar begäran innan bild 2 startas. Om avbrytning kommer under en sparning, avslutas loopen innan den registrerar bilden som slutförd.

Om anroparen behöver hantera avbrytning, ersätt kontrollen och dess `break` högst upp i loopen med `token.throwIfInterruptionRequested()`. Ta bort `try`/`except` runt sparandet så att avbrytning under en export också når anroparen. Med samma indata skriver exemplet bara ut `Starting slide 1` och skriver `slide-1.pdf`. Vid början av den andra iterationen, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) kastar `com.aspose.slides.exceptions.OperationCanceledException` innan nästa export startar. Undantaget propagerar till anroparen innan funktionen kan returnera listan.

## **Vanliga frågor**

**När bör jag begära avbrytning?**

Begär avbrytning när en operation överskrider din tidsgräns eller när din applikation inte längre behöver resultatet.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Källan låter din applikation begära avbrytning. Tokenet låter Aspose.Slides och din applikation kontrollera den begäran.

**Kan jag avbryta en operation från en Python-timer?**

Ja. Schemalägg ett anrop till [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) på källan som är associerad med presentationen.

**Vilka operationer kan jag avbryta?**

Du kan avbryta inläsning, sparning och rendering. Skicka token till [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Presentationen kan sedan observera avbrytning under efterföljande operationer såsom sparning till PDF.

**Stannar en operation omedelbart?**

Avbrytning är samarbetsbaserad. En operation kontrollerar token periodiskt och stannar när den observerar begäran.

**Vad händer om jag anropar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) efter att en operation har slutförts?**

Den slutförda operationen behåller sitt resultat.

**Kan flera operationer dela en [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Ja. Att anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) begär avbrytning för varje operation som använder en token från den källan. Använd en separat källa för varje operation du vill avbryta oberoende.