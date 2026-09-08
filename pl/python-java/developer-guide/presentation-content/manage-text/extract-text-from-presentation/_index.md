---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w Python via Java
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/python-java/extract-text-from-presentation/
keywords:
- wyodrębnić tekst
- wyodrębnić tekst ze slajdu
- wyodrębnić tekst z prezentacji
- wyodrębnić tekst z PowerPointa
- wyodrębnić tekst z OpenDocument
- wyodrębnić tekst z PPT
- wyodrębnić tekst z PPTX
- wyodrębnić tekst z ODP
- pobrać tekst
- pobrać tekst ze slajdu
- pobrać tekst z prezentacji
- pobrać tekst z PowerPointa
- pobrać tekst z OpenDocument
- pobrać tekst z PPT
- pobrać tekst z PPTX
- pobrać tekst z ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Szybko wyodrębnij tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via Java. Postępuj zgodnie z naszym prostym przewodnikiem krok po kroku, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji jest powszechnym, a jednocześnie kluczowym zadaniem dla programistów pracujących z zawartością slajdów. Niezależnie od tego, czy obsługujesz pliki Microsoft PowerPoint w formacie PPT lub PPTX, czy prezentacje OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być niezbędne do analizy, automatyzacji, indeksowania lub migracji treści.

Ten artykuł przedstawia kompleksowy przewodnik, jak wydajnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for Python via Java. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie uzyskać potrzebny tekst.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for Python via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/). Klasa ta zawiera kilka przeciążonych metod statycznych służących do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#getAllTextBoxes). Metoda ta przyjmuje jako parametr obiekt typu [BaseSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/). Po wywołaniu metoda przeszukuje cały slajd w poszukiwaniu tekstu i zwraca tablicę obiektów typu [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/), zachowując formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Wyodrębnianie tekstu z prezentacji**

Aby przeszukać tekst w całej prezentacji, użyj statycznej metody [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#getAllTextFrames) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/). Przyjmuje ona dwa parametry:

1. Po pierwsze, obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) reprezentujący prezentację PowerPoint lub OpenDocument, z której ma zostać wyodrębniony tekst.
1. Po drugie, wartość typu `bool` wskazująca, czy podczas skanowania tekstu mają być uwzględnione slajdy wzorcowe (master slides).

Metoda zwraca tablicę obiektów typu [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania w prezentacji, uwzględniając slajdy wzorcowe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Kategoryzowane i szybkie wyodrębnianie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/) również oferuje metody do wyodrębniania całego tekstu z prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Wyodrębnij tekst z pliku.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Wyodrębnij tekst ze strumienia.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Wyodrębnij tekst ze strumienia przy użyciu opcji ładowania.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Argument wyliczeniowy [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:

- [Unarranged](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) – surowy tekst bez uwzględnienia jego pozycji na slajdzie.
- [Arranged](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textextractionarrangingmode/#Arranged) – tekst ułożony w tej samej kolejności, co na slajdzie.

Tryb nieuporządkowany (Unarranged) można używać, gdy priorytetem jest szybkość; jest szybszy niż tryb uporządkowany (Arranged).

[PresentationText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego metoda [getSlidesText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationtext/#getSlidesText) zwraca tablicę obiektów typu `SlideText`. Każdy obiekt reprezentuje tekst na odpowiednim slajdzie. Obiekt typu `SlideText` posiada następujące metody:

- `getText` – tekst znajdujący się w kształtach slajdu.
- `getMasterText` – tekst znajdujący się w kształtach slajdu wzorcowego powiązanego z danym slajdem.
- `getLayoutText` – tekst znajdujący się w kształtach slajdu układu powiązanego z danym slajdem.
- `getNotesText` – tekst znajdujący się w kształtach notatek powiązanych z danym slajdem.
- `getCommentsText` – tekst znajdujący się w komentarzach powiązanych z danym slajdem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas wyodrębniania tekstu?**

Aspose.Slides jest zoptymalizowany pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/python-java/open-presentation/), co czyni go odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub masowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów powiązanych z wykresami, co umożliwia dostęp i analizę treści tekstowych w typowych strukturach prezentacji.

**Czy potrzebna jest specjalna licencja Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Możesz wyodrębniać tekst przy użyciu wersji próbnej Aspose.Slides, choć będzie ona miała [pewne ograniczenia](/slides/pl/python-java/licensing/), takie jak przetwarzanie tylko ograniczonej liczby slajdów. Dla nieograniczonego użytku i obsługi większych prezentacji zaleca się zakup pełnej licencji.