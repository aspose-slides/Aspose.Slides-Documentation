---
title: Zapis prezentacji w Pythonie
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/python-net/save-presentation/
keywords:
- zapisz PowerPoint
- zapisz OpenDocument
- zapisz prezentację
- zapisz slajd
- zapisz PPT
- zapisz PPTX
- zapisz ODP
- prezentacja do pliku
- prezentacja do strumienia
- wstępnie zdefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- Python
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w Pythonie przy użyciu Aspose.Slides oraz skonfiguruj opcje wyjścia PPTX."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/python-net/open-presentation/), użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipresentation/save/) , aby zapisać wynik. Aspose.Slides for Python via .NET może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisu oraz dostępne opcje wyjścia w formacie PPTX.

## **Zapis prezentacji do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipresentation/save/) . Wartość formatu określa typ pliku, który tworzy Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapis prezentacji w ich oryginalnym formacie**

Przykłady wykrywania plików i strumieni, zachowanie nowo utworzonych prezentacji oraz rozróżnienie między formatem źródłowym a wyjściowym znajdziesz w sekcji [Determine the Original Presentation Format](/slides/pl/python-net/detect-presentation-source-format/).

W aplikacji przetwarzającej wsadowo format wejściowy może nie być znany z góry. Po załadowaniu pliku odczytaj jego oryginalny format z właściwości [Presentation.source_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/source_format/) . Przekaż otrzymaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sourceformat/) do [SlideUtil.to_save_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/to_save_format/) aby uzyskać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/) , a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipresentation/save/) aby zapisać zmodyfikowaną prezentację.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został załadowany:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/to_save_format/) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na ich odpowiadające formaty zapisu prezentacji. Mapuje jedynie formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu, takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sourceformat/) powoduje wyrzucenie wyjątku.

Starsze pliki PPT, PPS i POT używają tego samego kontenera binarnego. Gdy taka prezentacja zostanie załadowana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli konieczne jest zachowanie tych starszych podtypów, zachowaj oryginalną nazwę pliku lub metadane formatu oddzielnie i użyj ich przy wyborze nazwy wyjściowego pliku i formatu.

## **Zapis prezentacji do strumieni**

Aby zapisać prezentację bez polegania na ostatecznej ścieżce pliku, przekaż zapisywalny [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) strumień oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipresentation/save/) . To podejście jest przydatne, gdy wynik musi być zwrócony z usługi webowej, zapisany w bazie danych lub przetwarzany w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia plikowego:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Zapis prezentacji z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisany plik prezentacji. Ustaw właściwość [ViewProperties.last_view](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/last_view/) na wartość [ViewType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Slide Master jako widok początkowy:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapis prezentacji w ścisłym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny z ściśle określonym profilem Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/) , a następnie ustaw jej właściwość [conformance](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/conformance/) na `Conformance.ISO_29500_2008_STRICT` . Następnie przekaż te opcje do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipresentation/save/) .

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zapis prezentacji w formacie Office Open XML w trybie Zip64**

Standardowy archiwum ZIP ogranicza skompresowany i nieskompresowany rozmiar każdego wpisu, całkowity rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą obowiązujące limity rozmiaru i liczby wpisów.

Użyj właściwości [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) , aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- ``IF_NECESSARY`` używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To tryb domyślny.
- ``NEVER`` wyłącza rozszerzenia ZIP64.
- ``ALWAYS`` zawsze zapisuje rozszerzenia ZIP64.

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla prezentacji wyjściowej:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Jeśli użyto `Zip64Mode.NEVER` i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłasza [PptxException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxexception/) .
{{% /alert %}}

## **Zapis prezentacji w formacie Office Open XML ze stopniami kompresji**

Przy wyjściu PPTX możesz zrównoważyć szybkość zapisu z rozmiarem pliku, ustawiając właściwość [PptxOptions.compression_level](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/compression_level/) . Enumeracja [CompressionLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/compressionlevel/) udostępnia następujące wartości:

- ``NONE`` przechowuje dane bez kompresji.
- ``LEVEL1`` zapewnia najszybszą kompresję i największy skompresowany plik wyjściowy.
- ``LEVEL2``‑``LEVEL5`` kolejno faworyzują mniejszy rozmiar wyjścia kosztem szybkości zapisu.
- ``LEVEL6`` równoważy szybkość zapisu i rozmiar pliku. To domyślny poziom.
- ``LEVEL7`` i ``LEVEL8`` jeszcze bardziej faworyzują mniejszy rozmiar kosztem szybkości.
- ``LEVEL9`` zapewnia najsilniejszą kompresję i wymaga najwięcej czasu przetwarzania.

Poniższy przykład zapisuje prezentację bez kompresji:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zapis prezentacji bez odświeżania miniatury**

Gdy prezentacja jest zapisywana jako PPTX, właściwość [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) kontroluje jej miniaturę dokumentu:

- ``True`` odtwarza miniaturę podczas operacji zapisu. To wartość domyślna.
- ``False`` zachowuje istniejącą miniaturę. Jeśli prezentacja nie ma miniatury, Aspose.Slides nie generuje jej.

Poniższy przykład zapisuje prezentację bez odświeżania jej miniatury:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Wyłączenie odświeżania miniatury może skrócić czas potrzebny na zapis pliku PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose udostępnia darmowy [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) oparty na API Aspose.Slides. Zapisuje wybrane slajdy z prezentacji jako oddzielne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje zapisy przyrostowe lub „fast save”?**

Nie. Każda operacja zapisu tworzy kompletny plik wyjściowy, zamiast aktualizować jedynie zmienione fragmenty.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/python-net/multithreading/). Dostęp i zapis każdej instancji powinny odbywać się tylko z jednego wątku naraz.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisu prezentacji?**

[Hyperlinki](/slides/pl/python-net/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje zewnętrznie powiązanych plików, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [właściwości dokumentu](/slides/pl/python-net/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.