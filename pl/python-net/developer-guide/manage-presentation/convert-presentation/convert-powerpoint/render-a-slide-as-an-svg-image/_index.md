---
title: Renderowanie slajdów prezentacji jako obrazy SVG w Pythonie
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentacja do SVG
- slajd do SVG
- PPT do SVG
- PPTX do SVG
- opcje eksportu SVG
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w Pythonie i kontroluj czcionki, tekst oraz obrazy przy użyciu Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, przepływach dostępności i automatycznym przetwarzaniu po publikacji. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, jak zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksport slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia. Poniższy przykład eksportuje każdy slajd w prezentacji jako osobny plik SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Nazwa pliku używa [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy pomocy [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) steruje renderowaniem SVG. Dla ramek tekstowych, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) określa, czy zastosować rotację ramki. Ustaw [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) na `True`, gdy tekst musi być renderowany bez ligatur.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Kontrola tekstu i czcionek**

Podczas eksportu slajdów do SVG możesz kontrolować, czy tekst pozostaje jako tekst czy zostaje przekształcony w grafikę wektorową oraz w jaki sposób zewnętrzne czcionki są dołączane lub odwoływane. Poniższe opcje pomagają zrównoważyć spójność wizualną, możliwość zaznaczania tekstu i zależności czcionek w wyeksportowanym SVG.

### **Wektoryzacja całego tekstu**

Ustaw [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) na `True`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminuje to zależności od czcionek i sprawia, że rezultat wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Wybór sposobu obsługi zewnętrznych czcionek**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `ADD_LINKS_TO_FONT_FILES`, aby odwoływać się do oddzielnych plików czcionek, `EMBED`, aby dołączyć dane czcionki do SVG, lub `VECTORIZE`, aby renderować tekst używający zewnętrznych czcionek jako grafikę. Przed osadzeniem czcionek sprawdź licencję.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Zmniejszanie rozmiaru osadzonych obrazów**

Użyj [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/), aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/), aby kontrolować jakość kodowania JPEG. Ustawienia te zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Kontrola rozdzielczości rastrowania metafili**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) ustawia dolny limit rozdzielczości przy rastrowaniu metafili podczas eksportu SVG. Służy to do wyważenia szczegółowości i rozmiaru pliku, gdy obraz EMF lub WMF jest rastrowany. Nie definiuje ona globalnego DPI dla SVG ani nie zmusza każdego obiektu na slajdzie do przekształcenia w obraz rastrowy.

Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z ściśle rozmieszczonymi liniami ukośnymi. Poniższy przykład eksportuje jego pierwszy slajd przy trzech rozdzielczościach rastrowania za pomocą [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Wszystkie pozostałe ustawienia eksportu pozostają takie same, aby wyniki można było porównać.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

W wyniku EMF został zamieniony na jeden osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie stanowią ogólnej formuły konwersji DPI na wymiary pikseli.

| DPI rastrowania metafili | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy tej samej powiększonej wielkości wyświetlania. Linie ukośne wykazują widoczną pikselację przy 72 DPI i gładsze krawędzie przy wyższych rozdzielczościach, podczas gdy plik SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy detal ani nie zmienia każdego wyeksportowanego obrazu.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) kontroluje redukcję rozdzielczości obrazu i może maskować efekt zmiany rozdzielczości rastrowania metafili. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) kontroluje jakość kodowania JPEG, a nie rozdzielczość rastrowania metafili.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) zamiast [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Użyj [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), gdy tylko tekst korzystający z zewnętrznych czcionek powinien być przekształcony w grafikę.

**Jaki jest najlepszy sposób na zmniejszenie rozmiaru SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wyboru powiązanych plików czcionek, gdy docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy jakości i rozmiaru.