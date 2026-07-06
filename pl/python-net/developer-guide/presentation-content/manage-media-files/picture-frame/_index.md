---
title: Dodaj ramki obrazu do prezentacji przy użyciu Pythona
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/python-net/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- dodaj obraz
- utwórz obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz wektorowy
- przytnij obraz
- przycięty obszar
- właściwość StretchOff
- formatowanie ramki obrazu
- właściwości ramki obrazu
- skala względna
- efekt obrazu
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w środowisku .NET. Usprawnij swoją pracę i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Ramki obrazu w Aspose.Slides for Python umożliwiają umieszczanie i zarządzanie obrazami rastrowymi i wektorowymi jako natywnymi kształtami slajdu. Możesz wstawiać obrazy z plików lub strumieni, pozycjonować i zmieniać ich rozmiar przy użyciu precyzyjnych współrzędnych, stosować obrót, ustawiać przezroczystość oraz kontrolować kolejność Z razem z innymi kształtami. API obsługuje także przycinanie, zachowanie proporcji, ustawianie krawędzi i efektów oraz wymianę podstawowego obrazu bez przebudowy układu. Ponieważ ramki obrazu zachowują się jak zwykłe kształty, możesz dodawać animacje, hiperlinki i tekst alternatywny, co umożliwia łatwe tworzenie wizualnie bogatych, dostępnych prezentacji.

## **Tworzenie ramek obrazu**

W tej sekcji pokazano, jak wstawić obraz do slajdu, tworząc [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) w Aspose.Slides for Python. Dowiesz się, jak wczytać obraz, precyzyjnie umieścić go na slajdzie oraz kontrolować jego rozmiar i formatowanie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd po jego indeksie.
3. Utwórz [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) poprzez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) prezentacji. Ten obraz będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość ramki.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) o podanym rozmiarze przy użyciu metody [add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Zapisz prezentację jako plik PPTX.

Poniższy kod w Pythonie pokazuje, jak utworzyć ramkę obrazu:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik PPTX.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj obraz do prezentacji.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Dodaj ramkę obrazu o rozmiarze obrazu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Zapisz prezentację jako PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji z obrazów. Gdy połączysz ramki obrazu z opcjami zapisu Aspose.Slides, możesz sterować operacjami I/O, aby konwertować obrazy z jednego formatu na inny. Możesz zainteresować się następującymi stronami: konwersja [image to JPG](https://products.aspose.com/slides/pl/python-net/conversion/image-to-jpg/); konwersja [JPG to image](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-image/); konwersja [JPG to PNG](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-png/); konwersja [PNG to JPG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-jpg/); konwersja [PNG to SVG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-svg/); konwersja [SVG to PNG](https://products.aspose.com/slides/pl/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Tworzenie ramek obrazu ze skalowaniem względnym**

Ta sekcja demonstruje umieszczanie obrazu o stałym rozmiarze, a następnie stosowanie skalowania procentowego niezależnie dla szerokości i wysokości. Ponieważ procenty mogą się różnić, stosunek proporcji może ulec zmianie. Skalowanie odbywa się względem oryginalnych wymiarów obrazu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd po jego indeksie.
3. Utwórz [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) poprzez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) prezentacji.
4. Dodaj [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) do slajdu.
5. Ustaw względną szerokość i wysokość ramki obrazu.
6. Zapisz prezentację jako plik PPTX.

Poniższy kod w Pythonie pokazuje, jak utworzyć ramkę obrazu ze skalowaniem względnym:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik PPTX.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj obraz do kolekcji obrazów prezentacji.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Dodaj ramkę obrazu do slajdu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Ustaw względną szerokość i wysokość skali.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Zapisz prezentację.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyodrębnianie obrazów rastrowych z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu demonstruje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Wyodrębnianie obrazów SVG z ramek obrazu**

Gdy prezentacja zawiera grafikę SVG umieszczoną w kształtach [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), Aspose.Slides for Python via .NET umożliwia pobranie oryginalnych obrazów wektorowych z pełną wiernością. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), sprawdzić, czy powiązany [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w jego natywnym formacie SVG.

Poniższy przykład kodu demonstruje, jak wyodrębnić obraz SVG z ramki obrazu:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Uzyskiwanie przezroczystości obrazu**

Aspose.Slides umożliwia pobranie efektu przezroczystości zastosowanego do obrazu. Ten kod w Pythonie demonstruje operację:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Wszystkie efekty stosowane do obrazów można znaleźć w [aspose.slides.effects](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Uzyskiwanie jasności i kontrastu obrazu**

Aspose.Slides umożliwia pobranie efektu jasności i kontrastu zastosowanego do obrazu. Klasa [Luminance](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/luminance/) reprezentuje ten efekt transformacji obrazu.

Ten kod w Pythonie demonstruje, jak pobrać ustawienia jasności i kontrastu z ramki obrazu:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Formatowanie ramki obrazu**

Aspose.Slides udostępnia wiele opcji formatowania, które możesz zastosować do ramki obrazu. Dzięki tym opcjom możesz dostosować ramkę obrazu do konkretnych wymagań.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd po jego indeksie.
3. Utwórz [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) poprzez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) prezentacji. Ten obraz będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość ramki.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) o podanym rozmiarze przy użyciu metody [add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/) slajdu.
6. Ustaw kolor linii ramki obrazu.
7. Ustaw szerokość linii ramki obrazu.
8. Obróć ramkę obrazu, podając wartość dodatnią (zgodną z ruchem wskazówek zegara) lub ujemną (przeciwną do ruchu wskazówek zegara).
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w Pythonie demonstruje proces formatowania ramki obrazu:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, aby reprezentować plik PPTX.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj obraz do kolekcji obrazów prezentacji.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Dodaj ramkę obrazu o rozmiarze obrazu.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Zastosuj formatowanie do ramki obrazu.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Zapisz prezentację jako PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose opracowało darmowe narzędzie [Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli potrzebujesz [połączyć obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, albo [utworzyć siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi.
{{% /alert %}}

## **Dodawanie obrazów jako linki**

Aby utrzymać mały rozmiar plików prezentacji, możesz dodawać obrazy lub filmy za pomocą linków zamiast osadzania ich bezpośrednio w prezentacji. Poniższy kod w Pythonie pokazuje, jak wstawić obraz i wideo do placeholdera:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Przycinanie obrazów**

W tej sekcji dowiesz się, jak przyciąć widoczny obszar obrazu w ramce obrazu bez zmiany pliku źródłowego. Poznasz także podstawową metodę stosowania marginesów przycinania, aby stworzyć czystą, wyśrodkowaną kompozycję bezpośrednio na slajdzie.

Poniższy kod w Pythonie pokazuje, jak przyciąć obraz na slajdzie:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj obraz do kolekcji obrazów prezentacji.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Dodaj ramkę obrazu do slajdu.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Przytnij obraz (wartości procentowe).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Zapisz wynik.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie przyciętych obszarów obrazów**

Jeśli chcesz usunąć przycięte obszary obrazu w ramce, użyj metody [delete_picture_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Metoda ta zwraca przycięty obraz lub oryginalny, jeśli przycinanie nie jest wymagane.

Poniższy kod w Pythonie demonstruje tę operację:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Pobierz ramkę obrazu z pierwszego slajdu.
    picture_frame = slides.shape[0]

    # Pobierz ramkę obrazu z pierwszego slajdu.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Zapisz wynik.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoda [delete_picture_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanym [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), może to zmniejszyć rozmiar prezentacji; w przeciwnym razie liczba obrazów w wynikowej prezentacji może wzrosnąć.

Podczas przycinania metoda konwertuje pliki metafile WMF/EMF na rastrowy obraz PNG.
{{% /alert %}}

## **Kompresowanie obrazów**

Możesz skompresować obraz w prezentacji, używając metody [PictureFillFormat.compress_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/compress_image/). Metoda ta zmniejsza rozmiar obrazu na podstawie rozmiaru kształtu i określonej rozdzielczości, z opcją usunięcia przyciętych obszarów.

Działa analogicznie do funkcji PowerPoint **Picture Format → Compress Pictures → Resolution**.

Poniższe przykłady w Pythonie demonstrują, jak skompresować obraz w prezentacji, określając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Skompresuj obraz do docelowej rozdzielczości 150 DPI (rozdzielczość internetowa) i usuń przycięte obszary.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Sprawdź wynik kompresji.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

lub bezpośrednio przy użyciu własnej wartości DPI:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Skompresuj obraz do 150 DPI (rozdzielczość internetowa), usuwając przycięte obszary.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoda konwertuje obraz do niższej rozdzielczości w oparciu o rozmiar kształtu i podane DPI. Przycięte fragmenty mogą być także usunięte w celu optymalizacji rozmiaru pliku.
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Jakość JPEG jest zachowywana lub nieznacznie obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint.
{{% /alert %}}

## **Blokowanie proporcji**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje po zmianie wymiarów obrazu, ustaw właściwość [aspect_ratio_locked](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) na `True`.

Poniższy kod w Pythonie pokazuje, jak zablokować proporcje kształtu:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Zablokuj proporcje przy zmianie rozmiaru.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje samego kształtu, a nie proporcje obrazu w nim umieszczonego.
{{% /alert %}}

## **Użycie właściwości offsetu rozciągania**

Korzystając z właściwości `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` i `stretch_offset_bottom` klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/), możesz zdefiniować prostokąt wypełnienia.

Gdy określone jest rozciąganie obrazu, prostokąt źródłowy jest skalowany, aby pasował do prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest określana przez procentowy offset od odpowiadającej krawędzi ramki kształtu. Dodatni procent oznacza wcięcie, ujemny – wystawienie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz referencję do slajdu po jego indeksie.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/).
4. Ustaw typ wypełnienia kształtu.
5. Ustaw tryb wypełnienia obrazem kształtu.
6. Wczytaj obraz.
7. Przypisz obraz jako wypełnienie kształtu.
8. Określ offsety obrazu względem odpowiednich krawędzi ramki kształtu.
9. Zapisz prezentację jako plik PPTX.

Poniższy kod w Pythonie demonstruje użycie właściwości Stretch Offset:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation reprezentującą plik PPTX.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj prostokątną AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Ustaw typ wypełnienia kształtu.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ustaw tryb wypełnienia obrazu kształtu.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Wczytaj obraz i dodaj go do prezentacji.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Przypisz obraz jako wypełnienie kształtu.
    shape.fill_format.picture_fill_format.picture.image = image

    # Określ offsety obrazu względem odpowiednich krawędzi ramki ograniczającej kształt.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Zapisz plik PPTX na dysku.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose udostępnia darmowe konwertery — [JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów.
{{% /alert %}}

## **FAQ**

**Jak mogę sprawdzić, które formaty obrazów są obsługiwane przez PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itd.), jak i wektorowe (np. SVG) poprzez obiekt obrazu przypisany do [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; linkowanie obrazów pomaga utrzymać niewielki rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne pozostawały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako linków w celu redukcji rozmiaru pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przesunięciem/zmianą rozmiaru?**

Użyj [shape locks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/picture_frame_lock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) (np. wyłącz przesuwanie lub zmianę rozmiaru). Mechanizm blokady opisano w osobnym [artykule o ochronie](/slides/pl/python-net/applying-protection-to-presentation/) i jest wspierany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/).

**Czy wierność wektorowa SVG jest zachowana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) jako oryginalnego wektora. Przy [eksporcie do PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/python-net/convert-powerpoint-to-png/) rezultat może zostać rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, potwierdzany jest zachowaniem przy wyodrębnianiu.