---
title: Hosszú ideig futó prezentációs műveletek megszakítása Pythonban
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 120
url: /hu/python-java/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- megszakítási token
- leállítási token
- hosszú ideig futó feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet megszakítani a hosszú ideig futó prezentációs műveleteket az Aspose.Slides for Python via Java-ban, és hogyan adhat vissza részleges eredményt a diák ciklikus exportálása során."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java képes megszakítani a hosszú ideig tartó műveleteket, például a prezentációk betöltését, mentését és renderelését. Az alkalmazása ugyanazt a megszakítási tokent használhatja a ciklus leállításához, mielőtt a következő dia feldolgozása megkezdődne.

## **Prezentáció művelet megszakítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), szerezze meg a tokenjét a [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) használatával, és adja át a tokent a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Adja át a betöltési beállításokat a [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). A leállítás kéréséhez hívja a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) metódust a forráson. Egy megszakítható művelet leáll, amikor észleli a kérést. Használja a `jpype.JClass`-t a Java kivétel `com.aspose.slides.exceptions.OperationCanceledException` Pythonban történő elkapásához.

A példa a `sample.pptx` fájlt `sample.ppt` formátumba konvertálja egy háttérszálon. A hívó szál legfeljebb 10 másodpercig várja a konvertálás befejeződését. Ha a konvertálás még fut, leállítási kérelmet küld, és várja a munkavégző szál kilépését.

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

## **Python időkorlát csatlakoztatása az Aspose.Slides-hez**

A prezentációs művelet időkorlátának beállításához használjon egy [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer), amely a lejáratkor meghívja a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt). A példa 20 másodpercet enged a `sample.pptx` betöltésére és `sample.pdf` exportálására. Ha az export hamarabb befejeződik, az alkalmazás törli a tervezett kérést.

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

## **Leállítás a következő dia feldolgozása előtt**

Használja ugyanazt a [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) a prezentációhoz és a diák exportálását végző ciklushoz. Minden export előtt ellenőrizze az [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) állapotot. Ha a hívó részleges eredményt használhat, adja vissza a sikeresen befejezett exportálások dia számait.

Használjon egy `sample.pptx` nevű prezentációt, amely legalább két diát tartalmaz. A [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) túlterhelés, amely Java `int[]` tömböt vár, az 1‑től kezdődő dia számokat használja. Használja a `jpype.JArray(jpype.JInt)`-t a tömb Pythonban történő felépítéséhez. A példa minden diát külön PDF‑be ment, és az első sikeres export rögzítése után azonnal kér leállítást.

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

A példa `slide-1.pdf`-t ír, és kiírja a `Starting slide 1` üzenetet, majd a `Completed: [1]`-et. A ciklus a kérést a 2. dia indítása előtt észleli. Ha a leállítás a mentés közben érkezik, a ciklus kilép, mielőtt azt a diát teljesnek jelölné.

Ha a hívónak kezelnie kell a leállítást, cserélje le a ciklus elején lévő ellenőrzést és `break`-et a `token.throwIfInterruptionRequested()` hívásra. Távolítsa el a `try`/`except` blokkot a mentés körül, hogy az export közbeni leállítás is elérje a hívót. Ugyanazzal a bemenettel a példa csak a `Starting slide 1`-et írja ki, és menti a `slide-1.pdf`-t. A második iteráció kezdetén a [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) `com.aspose.slides.exceptions.OperationCanceledException` kivételt dob a következő export kezdete előtt. A kivétel a hívóhoz terjed, mielőtt a függvény vissza tudná adni a listát.

## **GYIK**

**Mikor kell leállítási kérelmet küldeni?**

Küldjön leállítási kérelmet, ha egy művelet meghaladja az időkorlátját, vagy ha az alkalmazás már nem igényli az eredményt.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) között?**

A forrás lehetővé teszi az alkalmazás számára leállítási kérelem küldését. A token a Aspose.Slides és az alkalmazás számára jelzi, hogy ellenőrizhetik a kérést.

**Törölhetek egy műveletet egy Python időzítőtől?**

Igen. Ütemezzen egy hívást a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) metódusra a prezentációval összekapcsolt forráson.

**Mely műveleteket tudom megszakítani?**

A betöltést, mentést és renderelést. Adja át a tokent a [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) használatával. A prezentáció ezután a későbbi műveletek (például PDF‑be mentés) során észlelheti a leállítást.

**Megáll-e a művelet azonnal?**

A leállítás együttműködésen alapul. A művelet időnként ellenőrzi a tokent, és a kérés észlelésekor leáll.

**Mi történik, ha a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) hívást a művelet befejezése után hajtom végre?**

A befejezett művelet megtartja az eredményét.

**Több művelet is használhat egy [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)-t?**

Igen. A [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) minden olyan művelet leállítását kéri, amely a forrás tokenjét használja. Használjon külön forrást minden olyan művelethez, amelyet függetlenül szeretne leállítani.