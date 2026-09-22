---
title: Określenie oryginalnego formatu prezentacji w Pythonie przy użyciu Java
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/python-java/detect-presentation-source-format/
keywords:
- format źródłowy
- wykrywanie formatu prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Odczytaj oryginalny format załadowanej prezentacji w Pythonie przy użyciu Java z Aspose.Slides for Python via Java, porównaj API wykrywania i obsługuj pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji wywołaj metodę [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSourceFormat), aby określić jej pierwotny format. Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego załadowano bieżącą instancję.

Format źródłowy różni się od wybranego [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/) dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

Przykłady wymagają Aspose.Slides for Python via Java oraz zgodnego środowiska uruchomieniowego Java. Każdy przykład uruchamia JVM, jeśli nie jest już uruchomiona.

## **Odczytanie formatu źródłowego z pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSourceFormat), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zamień komunikaty na własną logikę aplikacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Rozpoznaj obsługiwane wartości**

Klasa [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/) definiuje stałe całkowite, które rozróżniają następujące formaty prezentacji. Podane poniżej rozszerzenia są konwencjonalne, a nie odtworzeniem oryginalnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentacja PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentacja Office Open XML |
| `Pptm` | `.pptm` | Prezentacja Office Open XML z makrami |
| `Pps` | `.pps` | Pokaz slajdów PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Pokaz slajdów Office Open XML |
| `Ppsm` | `.ppsm` | Pokaz slajdów Office Open XML z makrami |
| `Pot` | `.pot` | Szablon PowerPoint 97–2003 |
| `Potx` | `.potx` | Szablon Office Open XML |
| `Potm` | `.potm` | Szablon Office Open XML z makrami |
| `Odp` | `.odp` | Prezentacja OpenDocument |
| `Otp` | `.otp` | Szablon prezentacji OpenDocument |
| `Fodp` | `.fodp` | Prezentacja Flat XML ODF |
| `Xml` | `.xml` | Prezentacja PowerPoint XML |

## **Odczytanie formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do strumienia pamięciowego modeluje wejście otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) przyjmuje tylko strumień. Python odczytuje bajty pliku, a JPype konwertuje je na tablicę bajtów Java dla strumienia pamięciowego Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu ze ścieżki pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsza zawartość PPS i POT może być zgłaszana jako `SourceFormat.Ppt`; przykład PPS powyżej wypisuje wartość całkowitą `SourceFormat.Ppt`.

Jeśli Twoja aplikacja musi zachować to rozróżnienie, przechowuj oryginalną nazwę pliku lub metadane podtypu osobno. Rozszerzenie jest przydatną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą identyfikacji dowolnej zawartości prezentacji.

## **Porównanie wykrywania przed i po załadowaniu**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) i [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#getLoadFormat), gdy musisz sprawdzić plik przed załadowaniem pełnego modelu obiektu prezentacji. Użyj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSourceFormat), gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje wartości całkowite `LoadFormat.Pptx` oraz `SourceFormat.Pptx`. W produkcji wybierz API odpowiednie do etapu przetwarzania; już załadowana prezentacja nie wymaga drugiego sprawdzenia wyłącznie w celu uzyskania jej formatu źródłowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Wyniki używają stałych z różnych klas: [LoadFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/). Nie porównuj ich wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. PowerPoint XML może być zgłaszany jako `LoadFormat.Unknown` przed załadowaniem i jako `SourceFormat.Xml` po załadowaniu.

## **Utrzymuj formaty źródłowy i wyjściowy oddzielnie**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje wartość całkowitą `SourceFormat.Pptx` zarówno przed, jak i po zapisaniu oryginalnej instancji. Tylko nowa instancja załadowana z wyjściowego pliku ODP zgłasza `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Prezentacja utworzona od podstaw za pomocą `Presentation()` zgłasza `SourceFormat.Pptx`. Nie ma ona pliku wejściowego: jest to wartość domyślna dla nowo utworzonej instancji, a nie dowód na to, że wczytano plik PPTX. Śledź osobno, czy aplikacja utworzyła, czy wczytała instancję, jeśli to rozróżnienie ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Zapasowe rozwiązanie zapobiega cichej przypisaniu rozszerzenia do nierozpoznanej wartości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

To mapowanie nie konwertuje pliku ani nie odtwarza starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Dla rzeczywistego zapisu wybierz wyraźnie [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/), lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Weryfikacja formatów przez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Ponownie otwiera każdy wynik zarówno ze ścieżki, jak i przez strumień pamięciowy. Dla PPTX i ODP obie drogi zgłaszają zapisany format. Dla PPS ładowanie ze ścieżki zgłasza `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku zgłasza `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Poniższa tabela podsumowuje identyfikację formatu źródłowego dla prezentacji o pasujących rozszerzeniach. Nazwy oznaczają stałe; przykłady w Pythonie wypisują ich wartości całkowite:

| Zapisany format | SourceFormat ze ścieżki pliku | SourceFormat ze strumienia bez nazwy |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` odpowiednio | Takie same jak ze ścieżki pliku |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` odpowiednio | Takie same jak ze ścieżki pliku |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` odpowiednio | Takie same jak ze ścieżki pliku |
| ODP, OTP | `Odp`, `Otp` odpowiednio | Takie same jak ze ścieżki pliku |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Zawartość PPS/POT jest identyfikowana jako `Ppt` w strumieniach bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie wszystkich funkcji prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal zgłasza `Pptx`. Instancja załadowana z zapisanego pliku ODP zgłasza `Odp`.

**Czy strumień zawsze potrafi odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT dzielą ten sam format binarny. Przechowuj nazwę pliku lub metadane podtypu osobno, gdy to rozróżnienie jest wymagane.

**Jakie API powinienem używać, jeśli prezentacja jest już załadowana?**

Odczytaj [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSourceFormat). Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) do inspekcji przed załadowaniem.