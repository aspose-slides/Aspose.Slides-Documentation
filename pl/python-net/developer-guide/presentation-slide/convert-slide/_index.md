---
title: Konwertowanie slajdów prezentacji na obrazy w Pythonie
linktitle: Slajd na obraz
type: docs
weight: 41
url: /pl/python-net/convert-slide/
keywords:
  - konwertuj slajd
  - eksportuj slajd
  - slajd na obraz
  - zapisz slajd jako obraz
  - slajd na EMF
  - slajd na PNG
  - slajd na JPEG
  - slajd na bitmapę
  - slajd na TIFF
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Python
  - Aspose.Slides
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na obrazy PNG, JPEG, GIF, TIFF, EMF oraz inne formaty obrazów w Pythonie przy użyciu Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty obrazów.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. W razie potrzeby skonfiguruj renderowanie przy użyciu klasy [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/).
4. Wywołaj metodę [Slide.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/).
5. Wywołaj metodę [IImage.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/save/) i określ format wyjściowy za pomocą wartości [ImageFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imageformat/).

## **Konwertowanie slajdu do obrazu PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Powstały obiekt [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład w Pythonie renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Konwertowanie slajdów do obrazów o niestandardowych rozmiarach**

Użyj przeciążenia [Slide.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), które przyjmuje wartość [Size](https://reference.aspose.com/slides/pl/python-net/aspose.pydrawing/size/), aby renderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Konwertowanie slajdów z notatkami i komentarzami do obrazów**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przypisz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/) do właściwości [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/slides_layout_options/), aby kontrolować, gdzie pojawią się notatki i komentarze.

Poniższy przykład umieszcza przycięte notatki pod slajdem oraz komentarze po jego prawej stronie:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Podczas konwersji slajdu na obraz, nie ustawiaj właściwości [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) na [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notespositions/). Notatki mogą zawierać więcej tekstu niż stały rozmiar obrazu może pomieścić. Zamiast tego użyj [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Konwertowanie slajdów do obrazów przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/) umożliwia kontrolowanie rozmiaru, rozdzielczości i innych właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Konwertowanie wszystkich slajdów do obrazów**

Iteruj kolekcję slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że jawnie je pominiętesz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomymi i pionowymi współczynnikami skali równymi 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Utworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysowania wektorowego, które skalują się bez utraty ostrości. Jednak EMF jest głównie formatem kompatybilności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo, złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rastrowe wewnątrz kontenera wektorowego metafile.

### **Eksport slajdu do EMF**

Metoda [Slide.write_as_emf](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/write_as_emf/) zapisuje [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Wywołujący jest właścicielem strumienia przekazanego do [Slide.write_as_emf](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/write_as_emf/) i musi go zamknąć. Aspose.Slides zapisuje w bieżącej pozycji strumienia i pozostawia strumień otwarty.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [SvgImage.write_as_emf](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/write_as_emf/) do konwersji zawartości SVG na EMF. Powstałe bajty można dodać do prezentacji za pomocą [ImageCollection.add_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/add_image/) i umieścić na slajdzie przy pomocy [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/) z kodu SVG, konwertuje go do pamięciowego EMF, wstawia metafile na pierwszy slajd i zapisuje prezentację:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/write_as_emf/) nie przejmuje własności docelowego strumienia. Po zapisie pozycja strumienia znajduje się na końcu wygenerowanych danych. Wywołaj `getvalue`, aby uzyskać pełny bufor niezależnie od bieżącej pozycji strumienia, jak pokazano powyżej. Trzymaj strumień otwarty, dopóki dane nie zostaną odczytane, a następnie go zamknij.

Generowanie EMF jest dostępne w systemach operacyjnych obsługiwanych przez Aspose.Slides for Python via .NET, ale renderowanie może się różnić w zależności od platform, gdy brak fontów lub natywnych zależności graficznych. Zainstaluj czcionki używane w źródłowej treści lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [platform requirements](/slides/pl/python-net/system-requirements/) dla Aspose.Slides i zweryfikuj wynik w docelowej aplikacji wykorzystującej EMF. Aplikacje Linux i macOS często mają ograniczone lub niejednolite wsparcie dla wyświetlania i edytowania metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby prawidłowo renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji używane w prezentacji muszą być zainstalowane i dostępne na systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą pojawiać się w monochromatycznej formie w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [Slide.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane w obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.