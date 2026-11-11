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

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, przepływach pracy dostępności oraz automatycznym przetwarzaniu po publikacji. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, w jaki sposób zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportowanie slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia. Poniższy przykład eksportuje każdy slajd w prezentacji jako osobny plik SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Nazwa pliku wykorzystuje [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy użyciu [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfigurowanie wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) określa, czy zastosować obrót ramki. Ustaw [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) na `True`, gdy tekst musi być renderowany bez ligatur.

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

## **Kontrola przycinania końcówek linii przy grotach strzałek**

SVG 1.1 nie posiada ustawienia wcięcia markeru określającego, gdzie linia ma się zatrzymać pod grotem strzałki. Domyślnie Aspose.Slides skraca wyeksportowaną linię, aby jej obrys nie wystawał poza marker. Ustaw [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) na `True`, aby narysować obrys aż do pierwotnego końcowego punktu linii. To ustawienie wpływa tylko na wyjście SVG. Linia zachowuje swoją pozycję i długość na slajdzie.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

Porównanie pokazuje trójkątny grot na linii o szerokości 10 punktów. Przy włączonym przycinaniu końcówka jest ostra. Przy wyłączonym przycinaniu obrys wystaje poza skośne boki markera i pozostawia płaską końcówkę.

![Powiększony trójkąt 10‑punktowy z ostrą końcówką przy włączonym przycinaniu i płaską końcówką przy wyłączonym przycinaniu](line-end-cropping.png)

W pozostałych liniach z przykładu wystający obrys jest mniej widoczny na trójkącie o szerokości 2 punktów. Wypełniony romb zakrywa koniec obrysu w obu szerokościach.

## **Kontrola tekstu i czcionek**

Podczas eksportowania slajdów do SVG możesz kontrolować, czy tekst pozostaje jako tekst, czy jest konwertowany na grafikę wektorową, oraz w jaki sposób zewnętrzne czcionki są dołączane lub odwoływane. Poniższe opcje pomagają wyważyć spójność wizualną, możliwość zaznaczania tekstu oraz zależności czcionek w wyeksportowanym SVG.

### **Wektoryzacja całego tekstu**

Ustaw [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) na `True`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminuje to zależności od czcionek i sprawia, że efekt wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani przeszukania jako tekst SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Wybór sposobu obsługi czcionek zewnętrznych**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `ADD_LINKS_TO_FONT_FILES`, aby odwoływać się do osobnych plików czcionek, `EMBED`, aby dołączyć dane czcionki do SVG, lub `VECTORIZE`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Zweryfikuj licencję czcionek przed ich osadzeniem.

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

Użyj [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) aby pominąć przycięte obszary źródłowe oraz [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

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

## **Kontrola rozdzielczości rastrowania metapliku**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) ustawia dolny limit rozdzielczości przy rastrowaniu metaplików podczas eksportu SVG. Użyj go, aby wyważyć szczegółowość i rozmiar pliku, gdy obraz EMF lub WMF jest rastrowany. Nie definiuje on globalnego DPI dla SVG ani nie zmusza każdego obiektu na slajdzie do przekształcenia w obraz rastrowy.

Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z blisko rozmieszczonymi liniami ukośnymi. Poniższy przykład eksportuje jego pierwszy slajd w trzech rozdzielczościach rastrowania przy użyciu [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Wszystkie pozostałe ustawienia eksportu pozostają identyczne, aby można było porównać wyniki.

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

W wyniku EMF został zamieniony na jeden osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie są ogólną formułą konwertującą DPI na wymiary w pikselach.

| Rozdzielczość rastrowania metapliku DPI | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy tym samym powiększonym rozmiarze wyświetlania. Linie ukośne wykazują widoczną pikselizację przy 72 DPI i płynniejsze krawędzie przy wyższych rozdzielczościach, podczas gdy plik SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy szczegół ani nie zmienia każdego wyeksportowanego obrazu.

![Powiększone szczegóły linii ukośnych przy 72, 150 i 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) kontroluje redukcję rozdzielczości obrazu i może maskować wpływ zmiany rozdzielczości rastrowania metapliku. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) kontroluje jakość kodowania JPEG, a nie rozdzielczość rastrowania metapliku.

## **Najczęściej zadawane pytania**

**Kiedy powinienem używać [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) zamiast [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Użyj [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) gdy tylko tekst używający czcionek zewnętrznych powinien być konwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wyboru odnośników do plików czcionek, gdy docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.