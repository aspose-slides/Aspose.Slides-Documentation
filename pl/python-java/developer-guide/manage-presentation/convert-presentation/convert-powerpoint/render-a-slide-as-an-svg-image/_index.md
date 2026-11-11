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
- opcje eksportu SVG
- interaktywny SVG
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w Pythonie przy użyciu Javy i kontroluj czcionki, tekst, obrazy, identyfikatory i zdarzenia za pomocą Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, przepływach pracy dostępności i automatycznym przetwarzaniu końcowym. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, jak tekst, czcionki, obrazy i elementy SVG są zapisywane.

Użyj [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportuj slajd jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia za pomocą [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Przykłady wymagają istniejącego pliku `presentation.pptx`. Każdy przykład uruchamia JVM w razie potrzeby i zamyka swoje strumienie wyjściowe. Poniższy przykład eksportuje każdy slajd prezentacji jako osobny plik SVG.

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

Nazwa pliku wykorzystuje [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt za pomocą [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) , gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Skonfiguruj wyjście SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) określa, czy zastosować obrót ramki. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `True`, gdy tekst musi być renderowany bez ligatur.

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

## **Kontroluj przycinanie końca linii przy grotach strzałek**

SVG 1.1 nie posiada ustawienia wstawki markera określającego, gdzie linia powinna zakończyć się pod grotami strzałki. Domyślnie Aspose.Slides skraca wyeksportowaną linię, aby jej obrys nie wystawał poza marker. Wywołaj [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) z wartością `True`, aby narysować obrys aż do oryginalnego punktu końcowego linii. To ustawienie wpływa tylko na wyjście SVG. Linia zachowuje swoją pozycję i długość na slajdzie.

Przykład rysuje trójkątne i diamentowe groty strzałek na liniach o szerokości 2 i 10 punktów. Eksportuje ten sam slajd dwa razy, zmieniając jedynie opcję przycinania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Porównanie pokazuje trójkątny grot na linii o szerokości 10 punktów. Przy włączonym przycinaniu końcówka jest ostra. Przy wyłączonym przycinaniu obrys wystaje poza nachylone boki markera, pozostawiając płaską końcówkę.

![Powiększony trójkąt o szerokości 10 punktów z ostrą końcówką przy włączonym przycinaniu i płaską końcówką przy wyłączonym przycinaniu](line-end-cropping.png)

W pozostałych liniach z przykładu, wystający obrys jest mniej widoczny na trójkącie o szerokości 2 punkty. Wypełniony diament zakrywa koniec obrysu przy obu szerokościach.

## **Kontroluj tekst i czcionki**

Podczas eksportowania slajdów do SVG możesz kontrolować, czy tekst pozostaje tekstem czy jest konwertowany na grafikę wektorową oraz jak zewnętrzne czcionki są dołączane lub odwoływane. Poniższe opcje pomagają zrównoważyć spójność wizualną, możliwość zaznaczania tekstu i zależności czcionek w wyeksportowanym SVG.

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) na `True`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminuje to zależności od czcionek i sprawia, że rezultat wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już wybieralny ani przeszukiwalny jako tekst SVG.

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

### **Wybierz sposób obsługi zewnętrznych czcionek**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwołać się do osobnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający zewnętrznych czcionek jako grafikę. Zweryfikuj licencję czcionek przed ich osadzeniem.

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

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality), aby kontrolować jakość kodowania JPEG. Ustawienia te zmniejszają rozmiar pliku kosztem wierności obrazu lub zachowanych danych obrazu.

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

## **Kontroluj rozdzielczość rastrowania metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) ustawia dolny limit rozdzielczości przy rastrowaniu metafili podczas eksportu SVG. Użyj go, aby zrównoważyć szczegółowość i rozmiar pliku, gdy obraz EMF lub WMF jest rastrowany. Nie definiuje on globalnego DPI dla SVG ani nie zmusza każdego obiektu na slajdzie do przekształcenia w obraz rastrowy.

Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z blisko rozmieszczonymi liniami ukośnymi. Poniższy przykład eksportuje jego pierwszy slajd przy trzech rozdzielczościach rastrowania za pomocą [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Wszystkie pozostałe ustawienia eksportu pozostają identyczne, aby można było porównać wyniki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

W wyniku EMF został zamieniony na pojedynczy osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie są ogólną formułą przeliczania DPI na wymiary w pikselach.

| Rozdzielczość rastrowania metafile DPI | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy takiej samej powiększonej wielkości wyświetlania. Linie ukośne wykazują widoczną pikselację przy 72 DPI i gładsze krawędzie przy wyższych rozdzielczościach, podczas gdy plik SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy szczegół ani nie zmienia każdego wyeksportowanego obrazu.

![Powiększony szczegół linii ukośnych przy 72, 150 i 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) kontroluje redukcję rozdzielczości obrazu i może maskować wpływ zmiany rozdzielczości rastrowania metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) kontroluje jakość kodowania JPEG, a nie rozdzielczość rastrowania metafile.

## **Przypisz stabilne identyfikatory do kształtów i tekstu**

Użyj kontrolera formatowania w Pythonie zarejestrowanego przez `jpype.JProxy`, aby przypisać wartości [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) do kształtów i wartości [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) do elementów tekstowych `tspan`. Przypisz proxy za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Poniższy kontroler używa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), który jest stabilny przez cały okres życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstu. Dzięki temu wygenerowane identyfikatory są odpowiednie do post‑processingu niezmienionej prezentacji.

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

W kontrolerze formatowania w Pythonie wywołaj [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) z wartością [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) , aby dodać obsługiwacz zdarzeń JavaScript do wyeksportowanego kształtu. Zarejestruj kontroler przez `jpype.JProxy` i przypisz go za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

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

Strona hostująca może zdefiniować funkcję JavaScript odwoływaną przez obsługiwacz. Przypisywanie identyfikatorów i obsługiwaczy zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności i inne interaktywne przepływy pracy SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), gdy tylko tekst używający zewnętrznych czcionek ma być konwertowany na grafikę.

**Jaki jest najlepszy sposób na zmniejszenie rozmiaru SVG?**

Zacznij od kompresji osadzonych obrazów, usuwania przyciętych obszarów obrazów i wyboru linkowanych plików czcionek, gdy docelowe środowisko może je dostarczyć. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**

Tak. Przypisz identyfikatory przez kontroler formatowania, a następnie wybierz pasujące elementy SVG w narzędziu do post‑processingu lub w skrypcie przeglądarki.