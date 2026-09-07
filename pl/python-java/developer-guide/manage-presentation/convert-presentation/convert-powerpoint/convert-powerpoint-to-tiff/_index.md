---
title: Konwertowanie prezentacji PowerPoint do TIFF w Pythonie
linktitle: PowerPoint do TIFF
type: docs
weight: 90
url: /pl/python-java/convert-powerpoint-to-tiff/
keywords:
- konwertować PowerPoint
- konwertować OpenDocument
- konwertować prezentację
- konwertować slajd
- konwertować PPT
- konwertować PPTX
- PowerPoint do TIFF
- prezentacja do TIFF
- slajd do TIFF
- PPT do TIFF
- PPTX do TIFF
- zapisz PPT jako TIFF
- zapisz PPTX jako TIFF
- eksportuj PPT do TIFF
- eksportuj PPTX do TIFF
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) do wysokiej jakości obrazów TIFF przy użyciu Aspose.Slides dla Pythona via Java, z przykładami kodu."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) jest formatem obrazu rastrowego, który obsługuje wiele stron i bezstratną kompresję. Jest przydatny do przechowywania wyrenderowanych slajdów w jednym pliku obrazu.

Korzystając z Aspose.Slides for Python via Java, możesz konwertować prezentacje PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) do TIFF. Każdy poniższy przykład uruchamia maszynę wirtualną Javy w razie potrzeby i zwalnia prezentację po użyciu. 

## **Konwersja prezentacji do TIFF**

Korzystając z metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), możesz szybko skonwertować całą prezentację PowerPoint do TIFF. Powstały wielostronicowy plik TIFF zawiera wyrenderowany obraz każdego slajdu w domyślnym rozmiarze.

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Zapisz wszystkie slajdy w wielostronicowym pliku TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Konwersja prezentacji do czarno-białego TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#setBwConversionMode) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/) umożliwia określenie algorytmu używanego przy konwersji kolorowego slajdu lub obrazu do czarno-białego TIFF. Zauważ, że to ustawienie ma zastosowanie tylko wtedy, gdy metoda [setCompressionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#setCompressionType) jest ustawiona na [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) lub [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Uwaga" %}}
**TiffOptions.setBwConversionMode** jest ustawieniem na poziomie eksportu, które wybiera algorytm konwersji pikseli dla całego obrazu TIFF. Aby określić, jak ma wyglądać pojedynczy kształt w trybie czarno-białym, użyj **Shape.setBlackWhiteMode**. Zobacz [Control Black-and-White Rendering for Shapes](/slides/pl/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) po przykłady.
{{% /alert %}}

Powiedzmy, że mamy plik „sample.pptx” z następującym slajdem:

![A presentation slide](slide_black_and_white.png)

Ten kod demonstruje, jak skonwertować kolorowy slajd do czarno-białego TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Wynik:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Konwersja prezentacji do TIFF z niestandardowym rozmiarem**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości przy pomocy metod dostępnych w klasie TiffOptions. Na przykład metoda setImageSize umożliwia określenie rozmiaru powstałego obrazu.

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do obrazów TIFF o niestandardowym rozmiarze:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Ustaw poziomą i pionową rozdzielczość.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Ustaw wymiary wyjściowe w pikselach.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Dołącz pełne notatki prelegenta pod każdym slajdem.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Konwersja prezentacji do TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z metody [setPixelFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#setPixelFormat) z klasy [TiffOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/), możesz określić preferowany format pikseli dla powstałego obrazu TIFF.

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do obrazu TIFF z niestandardowym formatem pikseli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Porada" color="success" %}}
Sprawdź [DARMOWY konwerter PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę skonwertować pojedynczy slajd zamiast całej prezentacji PowerPoint do TIFF?**

Tak. Aspose.Slides umożliwia konwersję pojedynczych slajdów z prezentacji PowerPoint i OpenDocument do obrazów TIFF osobno.

**Czy istnieje limit liczby slajdów przy konwertowaniu prezentacji do TIFF?**

Nie ma stałego limitu liczby slajdów przy eksporcie do TIFF. Dostępna pamięć, złożoność slajdów oraz wymiary wyjściowe wpływają na rozmiar prezentacji, które możesz przetworzyć.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwertowaniu slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejść nie są zachowywane; eksportowane są tylko statyczne migawki slajdów.