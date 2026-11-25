---
title: Przerywanie długotrwałych operacji prezentacji w Pythonie
linktitle: Przerywanie operacji prezentacji
type: docs
weight: 120
url: /pl/python-java/support-for-interruptable-library/
keywords:
  - przerywalne operacje
  - token przerywania
  - token anulowania
  - długotrwałe zadanie
  - przerywanie zadania
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Python
  - Java
  - Aspose.Slides
description: "Dowiedz się, jak anulować długotrwałe operacje prezentacji w Aspose.Slides for Python via Java i zwrócić częściowy wynik podczas eksportowania slajdów w pętli."
---
## **Przegląd**

Aspose.Slides for Python via Java może przerywać długotrwałe operacje, takie jak wczytywanie, zapisywanie i renderowanie prezentacji. Twoja aplikacja może używać tego samego tokenu przerywania, aby zatrzymać pętlę przed rozpoczęciem przetwarzania kolejnego slajdu.

## **Przerwanie operacji prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), uzyskaj jego token za pomocą [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) i przekaż token do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Przekaż opcje wczytywania do [konstruktor Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Aby zlecić anulowanie, wywołaj [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) na źródle. Przerwana operacja zatrzymuje się, gdy zauważy żądanie. Użyj `jpype.JClass`, aby przechwycić wyjątek Javy `com.aspose.slides.exceptions.OperationCanceledException` w Pythonie.

Przykład konwertuje `sample.pptx` na `sample.ppt` w tle. Wątek wywołujący czeka do 10 sekund na zakończenie konwersji. Jeśli konwersja nadal trwa, żąda anulowania i czeka na zakończenie pracy wątku.

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

## **Połączenie limitu czasu w Pythonie z Aspose.Slides**

Aby ustawić limit czasu na operację prezentacji, użyj [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer), aby wywołać [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt), gdy limit czasu wygaśnie. Przykład pozwala 20 sekund na wczytanie `sample.pptx` i wyeksportowanie go do `sample.pdf`. Jeśli eksport zakończy się wcześniej, aplikacja odwołuje zaplanowane żądanie.

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

## **Zatrzymaj przed przetworzeniem kolejnego slajdu**

Użyj tego samego [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) dla prezentacji i pętli eksportującej jej slajdy. Sprawdzaj [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) przed każdym eksportem. Jeśli wywołujący może wykorzystać częściowy wynik, zwróć numery slajdów, które zostały pomyślnie wyeksportowane.

Użyj prezentacji o nazwie `sample.pptx` zawierającej co najmniej dwa slajdy. Przeciążenie [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), które przyjmuje tablicę Java `int[]`, używa numeracji slajdów zaczynając od 1. Użyj `jpype.JArray(jpype.JInt)`, aby zbudować tę tablicę w Pythonie. Przykład zapisuje każdy slajd do oddzielnego pliku PDF i żąda anulowania zaraz po zapisaniu pierwszego udanego eksportu.

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

Przykład zapisuje `slide-1.pdf` i wypisuje `Starting slide 1`, po czym `Completed: [1]`. Pętla zauważa żądanie przed rozpoczęciem slajdu 2. Jeśli anulowanie nastąpi w trakcie zapisu, pętla kończy się przed oznaczeniem tego slajdu jako zakończonego.

Jeśli wywołujący musi obsłużyć anulowanie, zamień sprawdzenie i `break` na początku pętli na `token.throwIfInterruptionRequested()`. Usuń `try`/`except` wokół zapisu, aby anulowanie podczas eksportu również dotarło do wywołującego. Przy tych samych danych wejściowych przykład wypisuje tylko `Starting slide 1` i zapisuje `slide-1.pdf`. Na początku drugiej iteracji [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) podnosi `com.aspose.slides.exceptions.OperationCanceledException` przed rozpoczęciem kolejnego eksportu. Wyjątek propaguje się do wywołującego przed zwróceniem listy.

## **FAQ**

**Kiedy powinienem żądać anulowania?**

Żądaj anulowania, gdy operacja przekracza ustalony limit czasu lub gdy aplikacja nie potrzebuje już wyniku.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Źródło pozwala aplikacji żądać anulowania. Token umożliwia Aspose.Slides i aplikacji sprawdzanie tego żądania.

**Czy mogę anulować operację z timera Pythona?**

Tak. Zaplanuj wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) na źródle powiązanym z prezentacją.

**Jakie operacje mogę przerwać?**

Możesz przerwać wczytywanie, zapisywanie i renderowanie. Przekaż token do [konstruktor Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) poprzez [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Prezentacja może wtedy zauważyć anulowanie podczas kolejnych operacji, takich jak zapisywanie do PDF.

**Czy operacja zatrzymuje się natychmiast?**

Anulowanie jest kooperatywne. Operacja okresowo sprawdza token i zatrzymuje się, gdy zauważy żądanie.

**Co się stanie, jeśli wywołam [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) po zakończeniu operacji?**

Ukończona operacja zachowuje swój wynik.

**Czy wiele operacji może współdzielić [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Tak. Wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) żąda anulowania dla każdej operacji używającej tokenu z tego źródła. Użyj osobnego źródła dla każdej operacji, którą chcesz anulować niezależnie.