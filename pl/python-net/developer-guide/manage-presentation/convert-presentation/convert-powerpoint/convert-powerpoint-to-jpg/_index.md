---
title: "Konwertuj PPT, PPTX i ODP do JPG w Pythonie"
linktitle: "Konwertuj slajdy na obrazy JPG"
type: docs
weight: 60
url: /pl/python-net/convert-powerpoint-to-jpg/
keywords:
- "konwertuj PowerPoint na JPG"
- "konwertuj prezentację na JPG"
- "konwertuj slajd na JPG"
- "konwertuj PPT na JPG"
- "konwertuj PPTX na JPG"
- "konwertuj ODP na JPG"
- "PowerPoint na JPG"
- "prezentacja na JPG"
- "slajd na JPG"
- "PPT na JPG"
- "PPTX na JPG"
- "ODP na JPG"
- "konwertuj PowerPoint na JPEG"
- "konwertuj prezentację na JPEG"
- "konwertuj slajd na JPEG"
- "konwertuj PPT na JPEG"
- "konwertuj PPTX na JPEG"
- "konwertuj ODP na JPEG"
- "PowerPoint na JPEG"
- "prezentacja na JPEG"
- "slajd na JPEG"
- "PPT na JPEG"
- "PPTX na JPEG"
- "ODP na JPEG"
- "Python"
- "Aspose.Slides"
description: "Dowiedz się, jak przekształcić slajdy z prezentacji PowerPoint i OpenDocument w obrazy JPEG wysokiej jakości przy użyciu zaledwie kilku wierszy kodu w Pythonie. Optymalizuj prezentacje pod kątem użycia w sieci, udostępniania i archiwizacji. Przeczytaj pełny poradnik już teraz!"
---
## **Wstęp**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG ułatwia udostępnianie slajdów, optymalizację wydajności oraz osadzanie treści w witrynach internetowych lub aplikacjach. Aspose.Slides for Python pozwala przekształcać pliki PPTX, PPT i ODP w obrazy JPEG wysokiej jakości. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo zaimplementować własny podgląd prezentacji i stworzyć miniaturkę każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub przedstawić prezentację w trybie tylko do odczytu. Aspose.Slides umożliwia konwersję całej prezentacji lub wybranego slajdu do formatów graficznych.

## **Konwertowanie slajdów prezentacji do obrazów JPG**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz obiekt slajdu typu [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) z kolekcji [Presentation.slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/).
1. Utwórz obraz slajdu przy użyciu metody [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#float-float).
1. Wywołaj metodę [IImage.save(filename, format)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/save/#str-imageformat) na obiekcie obrazu. Przekaż nazwę pliku wyjściowego i format obrazu jako argumenty.

{{% alert color="primary" %}}
**Uwaga:** Konwersja PPT, PPTX lub ODP do JPG różni się od konwersji do innych formatów w API Aspose.Slides Python. Dla innych formatów zazwyczaj używasz metody [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). Jednak dla konwersji JPG musisz użyć metody [IImage.save(filename, format)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/save/#str-imageformat).
{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Zapisz obraz na dysku w formacie JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Konwertowanie slajdów do JPG z niestandardowymi wymiarami**

Aby zmienić wymiary generowanych obrazów JPG, możesz ustawić rozmiar obrazu, przekazując go do metody [Slide.get_image(image_size)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize). Umożliwia to generowanie obrazów o określonych wartościach szerokości i wysokości, zapewniając, że wynik spełnia wymagania dotyczące rozdzielczości i proporcji. Ta elastyczność jest szczególnie przydatna przy tworzeniu obrazów dla aplikacji internetowych, raportów lub dokumentacji, gdzie wymagane są precyzyjne wymiary obrazu.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Utwórz obraz slajdu o określonym rozmiarze.
        with slide.get_image(image_size) as thumbnail:
            # Zapisz obraz na dysku w formacie JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Renderowanie komentarzy przy zapisywaniu slajdów jako obrazy**

Aspose.Slides for Python udostępnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas konwertowania ich na obrazy JPG. Funkcjonalność ta jest szczególnie przydatna do zachowania adnotacji, opinii lub dyskusji dodanych przez współpracowników w prezentacjach PowerPoint. Włączając tę opcję, zapewniasz, że komentarze są widoczne w wygenerowanych obrazach, co ułatwia przeglądanie i udostępnianie opinii bez konieczności otwierania oryginalnego pliku prezentacji.

Załóżmy, że mamy plik prezentacji „sample.pptx” ze slajdem zawierającym komentarze:

![Slajd z komentarzami](slide_with_comments.png)

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Ustaw opcje dla komentarzy slajdu.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Konwertuj pierwszy slajd na obraz.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

Wynik:

![Obraz JPG z komentarzami](image_with_comments.png)

## **Zobacz także**

Zobacz inne opcje konwersji PPT, PPTX lub ODP do obrazów, takie jak:

- [Konwertuj PowerPoint do GIF](/slides/pl/python-net/convert-powerpoint-to-animated-gif/)
- [Konwertuj PowerPoint do PNG](/slides/pl/python-net/convert-powerpoint-to-png/)
- [Konwertuj PowerPoint do TIFF](/slides/pl/python-net/convert-powerpoint-to-tiff/)
- [Konwertuj PowerPoint do SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aby zobaczyć, jak Aspose.Slides konwertuje PowerPoint na obrazy JPG, wypróbuj te darmowe konwertery online: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/pl/conversion/pptx-to-jpg) i [PPT to JPG](https://products.aspose.app/slides/pl/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Darmowy konwerter online PPTX do JPG](ppt-to-jpg.png)

{{% alert title="Wskazówka" color="primary" %}}

Aspose udostępnia darmową aplikację internetową [Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

Stosując te same zasady opisane w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Aby uzyskać więcej informacji, zobacz te strony: konwertuj [image to JPG](https://products.aspose.com/slides/pl/python-net/conversion/image-to-jpg/); konwertuj [JPG to image](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-image/); konwertuj [JPG to PNG](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-png/), konwertuj [PNG to JPG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-jpg/); konwertuj [PNG to SVG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-svg/), konwertuj [SVG to PNG](https://products.aspose.com/slides/pl/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Czy ta metoda obsługuje konwersję wsadową?**

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

**Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?**

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne elementy. Jednak dokładność renderowania może nieco się różnić w porównaniu z PowerPoint, szczególnie przy użyciu własnych lub brakujących czcionek.

**Czy istnieją ograniczenia dotyczące liczby slajdów, które można przetworzyć?**

Aspose.Slides nie nakłada ścisłych limitów na liczbę slajdów, które można przetworzyć. Jednak przy pracy z dużymi prezentacjami lub obrazami wysokiej rozdzielczości może wystąpić błąd pamięci.