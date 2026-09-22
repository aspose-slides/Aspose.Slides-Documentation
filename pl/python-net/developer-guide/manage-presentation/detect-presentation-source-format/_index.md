---
title: Określenie oryginalnego formatu prezentacji w Pythonie
linktitle: Format źródłowy
type: docs
weight: 35
url: /pl/python-net/detect-presentation-source-format/
keywords:
- format źródłowy
- wykrywanie formatu prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Odczytaj oryginalny format wczytanej prezentacji w Pythonie przy użyciu Aspose.Slides dla Pythona via .NET, porównaj interfejsy API wykrywania i obsługuj pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji odczytaj właściwość tylko do odczytu [Presentation.source_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/source_format/) określającą jej pierwotny format. Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego została wczytana bieżąca instancja.

Format źródłowy różni się od wybranego [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/) dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

## **Odczytanie formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation.source_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/source_format/), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zastąp komunikaty własną logiką aplikacji.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Rozpoznanie obsługiwanych wartości**

Wymieniona enumeracja [SourceFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sourceformat/) rozróżnia następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalnymi rozszerzeniami, a nie odtworzeniem pierwotnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | Prezentacja PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Prezentacja Office Open XML |
| `PPTM` | `.pptm` | Prezentacja Office Open XML z obsługą makr |
| `PPS` | `.pps` | Pokaz slajdów PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Pokaz slajdów Office Open XML |
| `PPSM` | `.ppsm` | Pokaz slajdów Office Open XML z obsługą makr |
| `POT` | `.pot` | Szablon PowerPoint 97–2003 |
| `POTX` | `.potx` | Szablon Office Open XML |
| `POTM` | `.potm` | Szablon Office Open XML z obsługą makr |
| `ODP` | `.odp` | Prezentacja OpenDocument |
| `OTP` | `.otp` | Szablon prezentacji OpenDocument |
| `FODP` | `.fodp` | Prezentacja Flat XML ODF |
| `XML` | `.xml` | Prezentacja PowerPoint XML |

## **Odczytanie formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do pamięciowego strumienia symuluje dane otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) przyjmuje jedynie strumień.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu z podanej ścieżki rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku zawartość starszych PPS i POT może być zgłaszana jako `SourceFormat.PPT`; powyższy przykład PPS zgłasza `PPT`.

Jeśli aplikacja musi zachować rozróżnienie, przechowuj pierwotną nazwę pliku lub metadane podtypu oddzielnie. Rozszerzenie jest przydatną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą do identyfikacji dowolnej zawartości prezentacji.

## **Porównanie wykrywania przed i po załadowaniu**

Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) i [PresentationInfo.load_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/load_format/) gdy potrzebujesz zbadać plik przed załadowaniem pełnego modelu obiektu prezentacji. Użyj [Presentation.source_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/source_format/) gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje `PPTX` dla obu kontroli. W produkcji wybierz interfejs API odpowiedni dla etapu przetwarzania; już załadowana prezentacja nie wymaga drugiego sprawdzenia wyłącznie w celu uzyskania jej formatu źródłowego.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Wyniki mają różne typy wyliczeń: [LoadFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sourceformat/). Nie porównuj ich poprzez rzutowanie ich wartości numerycznych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. W kontroli zapisu i ponownego otwarcia opisanej poniżej, PowerPoint XML został zgłoszony jako `LoadFormat.UNKNOWN` przed załadowaniem i `SourceFormat.XML` po załadowaniu.

## **Utrzymywanie formatu źródłowego i wyjściowego osobno**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje `PPTX` zarówno przed, jak i po zapisaniu oryginalnej instancji. Tylko nowa instancja załadowana z wyjścia ODP zgłasza `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Prezentacja utworzona od zera przy użyciu `slides.Presentation()` zgłasza `SourceFormat.PPTX`. Nie ma pliku wejściowego: jest to domyślna wartość nowo utworzonej instancji, a nie dowód na załadowanie pliku PPTX. Śledź, czy aplikacja utworzyła, czy załadowała instancję, jeśli to rozróżnienie ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Zapewniony fallback unika cichego przypisywania rozszerzenia do nierozpoznanej wartości.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

To mapowanie nie konwertuje pliku ani nie odzyskuje starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz wyraźnie [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/), lub użyj konwersji przedstawionej w [Save Presentations in Their Original Format](/slides/pl/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Weryfikacja formatów poprzez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Ponownie otwiera każdy wynik zarówno przez ścieżkę, jak i przez pamięciowy strumień. Dla PPTX i ODP obie drogi zgłaszają zapisany format. Dla PPS ładowanie z ścieżki zgłasza `PPS`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku zgłasza `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Ten sam test z wszystkimi formatami wymienionymi powyżej dał następujące wyniki dla wygenerowanych prezentacji o dopasowanych rozszerzeniach:

| Zapisany format | SourceFormat z ścieżki pliku | SourceFormat z strumienia bez nazwy |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` odpowiednio | Tak samo jak ścieżka pliku |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` odpowiednio | Tak samo jak ścieżka pliku |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` odpowiednio | Tak samo jak ścieżka pliku |
| ODP, OTP | `ODP`, `OTP` odpowiednio | Tak samo jak ścieżka pliku |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

W tych kontrolach jedyną normalizacją formatu źródłowego było przekształcenie PPS/POT do `PPT` dla strumieni bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie wszystkich cech prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal zgłasza `PPTX`. Instancja załadowana z zapisanego pliku ODP zgłasza `ODP`.

**Czy strumień zawsze potrafi odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT współdzielą format binarny. Przechowuj nazwę pliku lub metadane podtypu oddzielnie, gdy to rozróżnienie jest wymagane.

**Który interfejs API powinienem używać, jeśli prezentacja jest już załadowana?**

Odczytaj [Presentation.source_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/source_format/). Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) do inspekcji przed ładowaniem.