---
title: Zapisywanie prezentacji w Pythonie przy pomocy Java
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/python-java/save-presentation/
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
- wstępnie określony typ widoku
- ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- Python
- Java
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w Pythonie przy użyciu Java z Aspose.Slides oraz skonfiguruj wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwarciu istniejącej](/slides/pl/python-java/open-presentation/), użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać wynik. Aspose.Slides dla Pythona za pośrednictwem Java może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisu oraz dostępne opcje wyjściowe dla PPTX.

## **Zapisz prezentacje do plików**

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
    # Dodaj lub zmodyfikuj treść prezentacji tutaj.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zapisz prezentacje w ich pierwotnym formacie**

W aplikacji przetwarzającej wsadowo format wejściowy może nie być znany z góry. Po załadowaniu pliku odczytaj jego pierwotny format z metody [Presentation.getSourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSourceFormat). Przekaż uzyskaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/) do [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#toSaveFormat), aby uzyskać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/), a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać zmodyfikowaną prezentację.

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#toSaveFormat) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP oraz PowerPoint XML na ich odpowiadające formaty zapisu prezentacji. Mapuje jedynie formaty źródłowe prezentacji; nie jest przeznaczony do wyboru formatów eksportu takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sourceformat/) skutkuje [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Starsze pliki PPT, PPS i POT używają tego samego kontenera binarnego. Kiedy taka prezentacja jest wczytywana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli konieczne jest zachowanie tych starszych podtypów, zachowaj pierwotną nazwę pliku lub metadane formatu osobno i użyj ich przy wyborze nazwy i formatu wyjściowego.

## **Zapisz prezentacje do strumieni**

Aby zapisać prezentację bez zależności od ostatecznej ścieżki pliku, przekaż zapisywalny strumień oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). To podejście jest przydatne, gdy wynik musi zostać zwrócony z usługi sieciowej, przechowany w bazie danych lub przetworzony w pamięci.

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

## **Zapisz prezentacje z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otwiera zapisany plik prezentacji. Użyj metody [ViewProperties.setLastView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setLastView) z wartością [ViewType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Master slajdów jako widok początkowy:

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

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aby utworzyć plik PPTX zgodny ze ścisłym profilem Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/) i użyj jej metody [setConformance](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setConformance) z wartością [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Następnie przekaż opcje do metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save).

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

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza rozmiar skompresowany i nieskompresowany każdej pozycji, łączny rozmiar archiwum oraz liczbę pozycji. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą obowiązujące limity rozmiaru i liczby pozycji.

Użyj metody [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setZip64Mode), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#IfNecessary) używa Zip64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To domyślny tryb.
- [Never](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#Never) wyłącza rozszerzenia Zip64.
- [Always](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#Always) zawsze zapisuje rozszerzenia Zip64.

Poniższy przykład zawsze włącza rozszerzenia Zip64 dla wyjściowej prezentacji:

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

{{% alert color="warning" title="Ostrzeżenie" %}}
Jeśli użyto [Zip64Mode.Never](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zip64mode/#Never) i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłosi [PptxException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz zbalansować szybkość zapisu z rozmiarem pliku, używając metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Klasa [CompressionLevel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/) udostępnia następujące wartości:

- [None](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#None) przechowuje dane bez kompresji.
- [Level1](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level1) zapewnia najszybszą kompresję i największy skompresowany wynik.
- [Level2](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level2)‑[Level5](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level5) stopniowo faworyzują mniejszy rozmiar kosztem szybkości zapisu.
- [Level6](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level6) równoważy szybkość zapisu i rozmiar pliku. To domyślny poziom.
- [Level7](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level7) i [Level8](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level8) jeszcze bardziej faworyzują mniejszy rozmiar kosztem szybkości zapisu.
- [Level9](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compressionlevel/#Level9) zapewnia najsilniejszą kompresję i wymaga najwięcej czasu przetwarzania.

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

## **Zapisz prezentacje bez odświeżania miniatury**

Podczas zapisu prezentacji jako PPTX metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kontroluje miniaturę dokumentu:

- `True` odtwarza miniaturę podczas operacji zapisu. To domyślna wartość.
- `False` zachowuje istniejącą miniaturę. Jeśli prezentacja nie ma miniatury, Aspose.Slides nie tworzy jej.

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

{{% alert color="info" title="Uwaga" %}}
Wyłączenie odświeżania miniatury może skrócić czas potrzebny na zapis pliku PPTX.
{{% /alert %}}

## **Raportuj postęp zapisu w procentach**

Aby monitorować operację zapisu, zarejestruj obsługę postępu w Pythonie przy użyciu `jpype.JProxy` i przekaż ją do metody [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides wywoła metodę `reporting` obsługi z wartościami postępu podczas eksportu.

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

{{% alert color="info" title="Uwaga" %}}
Aspose oferuje darmowy [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) zbudowany na bazie API Aspose.Slides. Dzieli wybrane slajdy z prezentacji na oddzielne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje zapisy przyrostowe lub „szybkie zapisy”?**

Nie. Każda operacja zapisu tworzy kompletny plik wyjściowy, a nie aktualizuje tylko zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja Presentation nie jest bezpieczna wątkowo. Dostęp i zapis każdej instancji powinny odbywać się tylko z jednego wątku naraz.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami przy zapisie prezentacji?**

Hiperłącza pozostają w prezentacji. Aspose.Slides nie kopiuje plików powiązanych zewnętrznie, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [właściwości dokumentu](/slides/pl/python-java/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.