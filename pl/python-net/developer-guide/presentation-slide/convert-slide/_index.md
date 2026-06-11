---
title: Konwertowanie slajdów PowerPoint na obrazy w Pythonie
linktitle: Slajd na obraz
type: docs
weight: 41
url: /pl/python-net/convert-slide/
keywords:
- konwertuj slajd
- konwertuj slajd na obraz
- eksportuj slajd jako obraz
- zapisz slajd jako obraz
- slajd na obraz
- slajd na PNG
- slajd na JPEG
- slajd na bitmapę
- Python
- Aspose.Slides
description: "Dowiedz się, jak konwertować slajdy PowerPoint i OpenDocument do różnych formatów przy użyciu Aspose.Slides for Python via .NET. Łatwo eksportuj slajdy PPTX i ODP do BMP, PNG, JPEG, TIFF i innych, uzyskując wysoką jakość."
---
## **Wstęp**

Aspose.Slides for Python via .NET umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument na różne formaty obrazów, w tym BMP, PNG, JPG (JPEG), GIF i inne.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj żądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - klasy [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/),
    - klasy [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/).
2. Utwórz obraz slajdu, wywołując metodę `get_image` klasy [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/).

W Aspose.Slides for Python via .NET, [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) jest klasą pozwalającą pracować z obrazami definiowanymi przez dane pikseli. Możesz użyć jej instancji do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itp.).

## **Konwertuj slajdy do bitmapy i zapisz obrazy w PNG**

Możesz przekonwertować slajd do obiektu bitmapy i używać go bezpośrednio w aplikacji. Alternatywnie możesz przekonwertować slajd do bitmapy, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Ten kod w Pythonie demonstruje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Konwertuj pierwszy slajd w prezentacji na bitmapę.
    with presentation.slides[0].get_image() as image:
        # Zapisz obraz w formacie PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Konwertuj slajdy na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość). 

Poniższy przykładowy kod pokazuje, jak to zrobić:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Konwertuj pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
    with presentation.slides[0].get_image(image_size) as image:
        # Zapisz obraz w formacie JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Konwertuj slajdy z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwie klasy — [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/) i [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/) — które pozwalają kontrolować renderowanie slajdów prezentacji na obrazy. Obie klasy zawierają właściwość `slides_layout_options`, umożliwiającą skonfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji na obraz.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w wynikowym obrazie.

Ten kod w Pythonie demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Ustaw pozycję notatek.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Ustaw pozycję komentarzy.
    notes_comments_options.comments_area_width = 500                                       # Ustaw szerokość obszaru komentarzy.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Ustaw kolor obszaru komentarzy.

    # Utwórz opcje renderowania.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Konwertuj pierwszy slajd prezentacji na obraz.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Zapisz obraz w formacie GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
W każdym procesie konwersji slajdu na obraz, właściwość [notes_position](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) nie może być ustawiona na `BOTTOM_FULL` (aby określić pozycję notatek), ponieważ tekst notatki może być zbyt długi, co uniemożliwia zmieszczenie go w określonym rozmiarze obrazu.
{{% /alert %}} 

## **Konwertuj slajdy na obrazy przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/) zapewnia większą kontrolę nad wynikowym obrazem TIFF, umożliwiając określenie parametrów takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Ten kod w Pythonie demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania obrazu czarno-białego o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Załaduj plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    # Pobierz pierwszy slajd z prezentacji.
    slide = presentation.slides[0]

    # Skonfiguruj ustawienia wyjściowego obrazu TIFF.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Ustaw rozmiar obrazu.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Ustaw format pikseli (czarno-biały).
    options.dpi_x = 300                                                        # Ustaw rozdzielczość poziomą.
    options.dpi_y = 300                                                        # Ustaw rozdzielczość pionową.

    # Przekonwertuj slajd na obraz z podanymi opcjami.
    with slide.get_image(options) as image:
        # Zapisz obraz w formacie TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Konwertuj wszystkie slajdy na obrazy**

Aspose.Slides umożliwia konwersję wszystkich slajdów w prezentacji na obrazy, skutecznie przekształcając całą prezentację w serię obrazów.

Ten przykładowy kod pokazuje, jak w Pythonie przekonwertować wszystkie slajdy prezentacji na obrazy:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Renderuj prezentację do obrazów slajd po slajdzie.
    for i, slide in enumerate(presentation.slides):
        # Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
        if slide.hidden:
            continue

        # Przekonwertuj slajd na obraz.
        with slide.get_image(scale_x, scale_y) as image:
            # Zapisz obraz w formacie JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `get_image` zapisuje jedynie statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak normalne. Należy tylko upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.