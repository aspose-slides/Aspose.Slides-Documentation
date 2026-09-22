---
title: Zapis prezentacji w Pythonie przez Java
linktitle: Zapis prezentacji
type: docs
weight: 80
url: /pl/python-java/save-presentation/
keywords:
- zapis PowerPoint
- zapis OpenDocument
- zapis prezentacji
- zapis slajdu
- zapis PPT
- zapis PPTX
- zapis ODP
- prezentacja do pliku
- prezentacja do strumienia
- określony typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- raportowanie postępu zapisu
- Python
- Java
- Aspose.Slides
description: "Zapisuj prezentacje PowerPoint i OpenDocument do plików lub strumieni w Pythonie przez Java przy użyciu Aspose.Slides, oraz konfigurować wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/python-java/open-presentation/), użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać wynik. Aspose.Slides for Python via Java może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisu oraz dostępne opcje dla wyjścia PPTX.

## **Zapis prezentacji do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). Wartość formatu określa typ pliku, który tworzy Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zapis prezentacji w ich oryginalnym formacie**

Przykłady wykrywania formatu pliku i strumienia, zachowanie nowo utworzonych prezentacji oraz rozróżnienie między formatem źródłowym a wyjściowym znajdziesz w artykule [Determine the Original Presentation Format](/slides/pl/python-java/detect-presentation-source-format/).

W aplikacji przetwarzającej wsadowo format wejściowy może być nieznany z góry. Po załadowaniu pliku odczytaj jego oryginalny format metodą [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSourceFormat). Przekaż uzyskaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/) do [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#toSaveFormat), aby otrzymać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/), a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać zmodyfikowaną prezentację.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został wczytany:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#toSaveFormat) mapuje formaty PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na odpowiadające formaty zapisu prezentacji. Mapuje wyłącznie formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu, takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/) skutkuje rzuceniem [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Starsze pliki PPT, PPS i POT używają tego samego kontenera binarnego. Gdy taka prezentacja zostanie wczytana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli konieczne jest zachowanie tych starszych podtypów, należy zachować oryginalną nazwę pliku lub metadane formatu i używać ich przy wyborze nazwy i formatu pliku wyjściowego.

## **Zapis prezentacji do strumieni**

Aby zapisać prezentację bez określania końcowej ścieżki pliku, przekaż strumień zapisu oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). Takie podejście jest przydatne, gdy wynik ma zostać zwrócony z usługi webowej, zapisany w bazie danych lub przetworzony w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia plikowego:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Zapis prezentacji z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisaną prezentację. użyj metody [ViewProperties.setLastView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setLastView) z wartością [ViewType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Slide Master jako widok początkowy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zapis prezentacji w ścisłym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny ze ściśle określonym profilem Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/) i użyj jej metody [setConformance](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setConformance) z wartością [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Następnie przekaż opcje do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Zapis prezentacji w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza skompresowany i nieskompresowany rozmiar każdego wpisu, całkowity rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą obowiązujące limity rozmiaru i liczby wpisów.

Użyj metody [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setZip64Mode), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#IfNecessary) używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. Jest to tryb domyślny.
- [Never](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#Never) wyłącza rozszerzenia ZIP64.
- [Always](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#Always) zawsze zapisuje rozszerzenia ZIP64.

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla prezentacji wyjściowej:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Jeśli użyto [Zip64Mode.Never](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#Never) i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu rzuca [PptxException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapis prezentacji w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz zrównoważyć szybkość zapisu z rozmiarem pliku, używając metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Klasa [CompressionLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/) udostępnia następujące wartości:

- [None](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#None) przechowuje dane bez kompresji.
- [Level1](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level1) zapewnia najszybszą kompresję i największy rozmiar skompresowanego pliku.
- [Level2](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level2) do [Level5](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level5) stopniowo faworyzują mniejszy rozmiar wyjścia kosztem szybkości zapisu.
- [Level6](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level6) równoważy szybkość zapisu i rozmiar pliku. Jest to poziom domyślny.
- [Level7](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level7) i [Level8](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level8) jeszcze bardziej preferują mniejszy rozmiar kosztem szybkości.
- [Level9](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level9) zapewnia najsilniejszą kompresję i wymaga najdłuższego czasu przetwarzania.

Poniższy przykład zapisuje prezentację bez kompresji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Zapis prezentacji bez odświeżania miniatury**

Podczas zapisu prezentacji jako PPTX metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje miniaturę dokumentu:

- `True` ponownie generuje miniaturę podczas zapisu. Jest to wartość domyślna.
- `False` zachowuje istniejącą miniaturę. Jeśli prezentacja nie ma miniatury, Aspose.Slides jej nie wygeneruje.

Poniższy przykład zapisuje prezentację bez odświeżania jej miniatury:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Wyłączenie odświeżania miniatury może skrócić czas zapisu pliku PPTX.
{{% /alert %}}

## **Raportowanie postępu zapisu jako procent**

Aby monitorować operację zapisu, zarejestruj obsługę postępu w Pythonie za pomocą `jpype.JProxy` i przekaż ją do metody [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides wywoła metodę `reporting` obsługi z wartościami postępu w trakcie eksportu.

Poniższy przykład raportuje postęp eksportu PDF w konsoli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose udostępnia bezpłatny [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) zbudowany na API Aspose.Slides. Splitsuje wybrane slajdy z prezentacji i zapisuje je jako oddzielne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje tryb przyrostowy lub „szybkiego zapisu”?**

Nie. Każda operacja zapisu tworzy kompletny plik wyjściowy, zamiast aktualizować jedynie zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) **nie jest bezpieczna wątkowo** (/slides/pl/python-java/multithreading/). Dostęp i zapis każdej instancji powinny być wykonywane z jednego wątku w danym momencie.

**Co się dzieje z hiperłączami i plikami powiązanymi zewnętrznie po zapisaniu prezentacji?**

[Hyperlinks](/slides/pl/python-java/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje plików powiązanych zewnętrznie, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [document properties](/slides/pl/python-java/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.