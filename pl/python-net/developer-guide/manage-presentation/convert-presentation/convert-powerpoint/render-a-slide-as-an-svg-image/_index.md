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

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności oraz automatycznym przetwarzaniu post‑produkcyjnym. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i umożliwia kontrolowanie, jak zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/) gdy eksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportuj slajd jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia. Poniższy przykład eksportuje każdy slajd prezentacji jako osobny plik SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Nazwa pliku używa [Slide.slide_number](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/slide_number/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy pomocy [Shape.write_as_svg](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/) gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Skonfiguruj wyjście SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/use_frame_size/) obejmuje ramkę tekstową w obszarze renderowania, a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) określa, czy zastosować obrót ramki. Ustaw [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) na `True`, gdy tekst musi być renderowany bez ligatur.

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

## **Kontroluj tekst i czcionki**

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.vectorize_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/vectorize_text/) na `True`, aby zapisać cały tekst slajdu jako grafikę wektorową. To eliminuje zależności od czcionek i sprawia, że wynik wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `ADD_LINKS_TO_FONT_FILES`, aby odwoływać się do oddzielnych plików czcionek, `EMBED`, aby dołączyć dane czcionki do SVG, lub `VECTORIZE`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Sprawdź licencję czcionek przed ich osadzeniem.

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

## **Zredukuj rozmiar osadzonych obrazów**

Użyj [SVGOptions.pictures_compression](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/pictures_compression/) , aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) , aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/jpeg_quality/) , aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem wierności obrazu lub zachowanych danych obrazu.

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

## **FAQ**

**Kiedy powinienem używać [SVGOptions.vectorize_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/vectorize_text/) zamiast [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Użyj [SVGOptions.vectorize_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/vectorize_text/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgexternalfontshandling/), gdy tylko tekst korzystający z czcionek zewnętrznych powinien być konwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wybrania połączonych plików czcionek, jeśli docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.