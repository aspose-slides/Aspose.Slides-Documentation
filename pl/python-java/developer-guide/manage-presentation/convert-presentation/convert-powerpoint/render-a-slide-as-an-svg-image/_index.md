---
title: Renderowanie slajdów prezentacji jako obrazy SVG w Pythonie przy użyciu Javy
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentacja do SVG
- slajd do SVG
- PPT do SVG
- PPTX do SVG
- Opcje eksportu SVG
- interaktywny SVG
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w Pythonie przy użyciu Javy i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia za pomocą Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności oraz automatycznym przetwarzaniu końcowym. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować sposób zapisu tekstu, czcionek, obrazów i elementów SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportuj slajd jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia przy użyciu [Slide.writeAsSvg](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/). Przykłady wymagają istniejącego pliku `presentation.pptx`. Każdy przykład uruchamia JVM w razie potrzeby i zamyka swoje strumienie wyjściowe. Poniższy przykład eksportuje każdy slajd z prezentacji jako osobny plik SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Nazwa pliku używa [Slide.getSlideNumber](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getSlideNumber) zamiast indeksu pętli. Możesz również wyeksportować pojedynczy kształt za pomocą [Shape.writeAsSvg](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Skonfiguruj wyjście SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setUseFrameSize) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setUseFrameRotation) określa, czy zastosować obrót ramki. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `True`, gdy tekst musi być renderowany bez ligatur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Kontroluj tekst i czcionki**

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setVectorizeText) na `True`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminuje to zależności od czcionek i sprawia, że wynik wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już wybieralny ani przeszukiwalny jako tekst SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwołać się do oddzielnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Zweryfikuj licencję czcionek przed ich osadzeniem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Zmniejsz rozmiar osadzonych obrazów**

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setPicturesCompression), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setJpegQuality), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Przypisz stałe identyfikatory kształtom i tekstowi**

Użyj kontrolera formatowania w Pythonie zarejestrowanego przez `jpype.JProxy`, aby przypisać wartości [SvgShape.setId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgshape/#setId) do kształtów oraz wartości [SvgTSpan.setId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgtspan/#setId) do elementów tekstowych `tspan`. Przypisz proxy za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Poniższy kontroler używa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getOfficeInteropShapeId), który jest stabilny przez cały czas życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstowych. Dzięki temu wygenerowane identyfikatory są odpowiednie do przetwarzania po wyeksportowaniu niezmienionej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Dodaj obsługiwacze zdarzeń SVG**

W kontrolerze formatowania w Pythonie wywołaj [SvgShape.setEventHandler](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgshape/#setEventHandler) z wartością [SvgEvent](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgevent/), aby dodać obsługiwacz zdarzeń JavaScript do wyeksportowanego kształtu. Zarejestruj kontroler przez `jpype.JProxy` i przypisz go za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Zdefiniuj funkcję JavaScript w stronie lub dokumencie SVG, który hostuje wynik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Strona hostująca może zdefiniować funkcję JavaScript odwoływaną przez obsługiwacz. Przypisywanie identyfikatorów i obsługiwaczy zdarzeń umożliwia przeglądarki slajdów, usprawnienia dostępności oraz inne interaktywne przepływy pracy z SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setVectorizeText) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#setVectorizeText), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), gdy tylko tekst używający czcionek zewnętrznych powinien zostać przekształcony w grafikę.

**Jaki jest najlepszy sposób na zmniejszenie rozmiaru SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wybrania linkowanych plików czcionek, jeśli docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG oraz wektoryzacja tekstu mają różne kompromisy jakości i rozmiaru.

**Czy mogę modyfikować elementy SVG po wyeksportowaniu?**

Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybieraj odpowiadające elementy SVG w narzędziu do przetwarzania po eksporcie lub w skrypcie przeglądarki.