---
title: Dodaj ramki obrazu do prezentacji w Pythonie
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
- skalowanie względne
- efekt obrazu
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via .NET. Usprawnij swój przepływ pracy i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Ramki obrazu w Aspose.Slides for Python pozwalają umieszczać i zarządzać obrazami rastrowymi i wektorowymi jako natywnymi kształtami slajdu. Możesz wstawiać obrazy z plików lub strumieni, pozycjonować i zmieniać ich rozmiar przy użyciu precyzyjnych współrzędnych, stosować obrót, ustawiać przezroczystość oraz kontrolować kolejność Z razem z innymi kształtami. API obsługuje także przycinanie, zachowanie proporcji, ustawianie obramowań i efektów oraz zastępowanie podstawowego obrazu bez potrzeby przebudowy układu. Ponieważ ramki obrazu zachowują się jak zwykłe kształty, możesz dodawać animacje, hiperłącza i tekst alternatywny, co ułatwia tworzenie wizualnie bogatych, dostępnych prezentacji.

## **Tworzenie ramek obrazu**

Ta sekcja pokazuje, jak wstawić obraz na slajd, tworząc [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) w Aspose.Slides for Python. Dowiesz się, jak załadować obraz, umieścić go precyzyjnie na slajdzie oraz kontrolować jego rozmiar i formatowanie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd według jego indeksu.
3. Utwórz [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) przez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) prezentacji. Ten obraz będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość ramki.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) o tym rozmiarze, używając metody [add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Zapisz prezentację jako plik PPTX.

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
Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji z obrazów. Łącząc ramki obrazu z opcjami zapisu Aspose.Slides, możesz kontrolować operacje I/O, aby konwertować obrazy z jednego formatu na inny. Możesz zainteresować się następującymi stronami: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/python-net/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-png/); konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-svg/); konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Tworzenie ramek obrazu ze skalowaniem względnym**

Ta sekcja demonstruje umieszczenie obrazu o stałym rozmiarze, a następnie zastosowanie skalowania procentowego niezależnie dla szerokości i wysokości. Ponieważ wartości procentowe mogą się różnić, proporcje mogą ulec zmianie. Skalowanie jest wykonywane względem oryginalnych wymiarów obrazu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd według jego indeksu.
3. Utwórz [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) przez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/).
4. Dodaj [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) do slajdu.
5. Ustaw względną szerokość i wysokość ramki obrazu.
6. Zapisz prezentację jako plik PPTX.

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

        # Ustaw względną skalę szerokości i wysokości.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Zapisz prezentację.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Eksportowanie obrazów rastrowych z ramek obrazu**

Możesz eksportować obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) i zapisywać je w formatach PNG, JPG i innych. Poniższy przykład kodu pokazuje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Ekstrahowanie obrazów SVG z ramek obrazu**

Gdy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), Aspose.Slides for Python via .NET umożliwia pobranie oryginalnych obrazów wektorowych z pełną wiernością. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), sprawdzić, czy podstawowy [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w natywnym formacie SVG.

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

Aspose.Slides umożliwia pobranie efektu przezroczystości zastosowanego do obrazu. Poniższy kod w Pythonie demonstruje tę operację:

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
Wszystkie efekty stosowane do obrazów znajdują się w [aspose.slides.effects](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Formatowanie ramek obrazu**

Aspose.Slides zapewnia wiele opcji formatowania, które możesz zastosować do ramki obrazu. Dzięki tym opcjom możesz dostosować ramkę obrazu do konkretnych wymagań.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz slajd według jego indeksu.
3. Utwórz [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) przez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) prezentacji. Ten obraz będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość ramki.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) o tym rozmiarze, używając metody [add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/) slajdu.
6. Ustaw kolor linii ramki obrazu.
7. Ustaw szerokość linii ramki obrazu.
8. Obróć ramkę obrazu, podając dodatnią (zgodną z ruchem wskazówek zegara) lub ujemną (przeciwną) wartość.
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

Aby utrzymać mały rozmiar plików prezentacji, możesz dodawać obrazy lub filmy za pomocą linków zamiast osadzać je bezpośrednio w prezentacjach. Poniższy kod w Pythonie pokazuje, jak wstawić obraz i wideo do miejsca zastępczego:

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

W tej sekcji dowiesz się, jak przyciąć widoczny obszar obrazu w ramce bez zmiany pliku źródłowego. Poznasz również podstawową metodę stosowania marginesów przycinania w celu uzyskania czystej, skoncentrowanej kompozycji bezpośrednio na slajdzie.

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

Jeśli chcesz usunąć przycięte obszary obrazu w ramce, użyj metody [delete_picture_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Metoda zwraca przycięty obraz lub oryginalny obraz, jeśli przycinanie nie jest wymagane.

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
Metoda [delete_picture_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanej [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), może to zmniejszyć rozmiar prezentacji; w przeciwnym razie liczba obrazów w otrzymanej prezentacji może wzrosnąć.

Podczas przycinania metoda konwertuje pliki metafile WMF/EMF do obrazu rastrowego PNG.
{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji, używając metody [PictureFillFormat.compress_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/compress_image/). Metoda ta kompresuje obraz, zmniejszając jego rozmiar w zależności od rozmiaru kształtu i określonej rozdzielczości, z możliwością usunięcia przyciętych obszarów.

Dostosowuje rozmiar i rozdzielczość obrazu podobnie jak funkcja **Format obrazu -> Kompresuj obrazy -> Rozdzielczość** w PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Skompresuj obraz do docelowej rozdzielczości 150 DPI (rozdzielczość sieciowa) i usuń przycięte obszary.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Sprawdź wynik kompresji.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Lub używając bezpośrednio własnej wartości DPI:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Skompresuj obraz do 150 DPI (rozdzielczość sieciowa), usuwając przycięte obszary.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoda konwertuje obraz do niższej rozdzielczości na podstawie rozmiaru kształtu i podanej wartości DPI. Przycięte regiony mogą również zostać usunięte w celu optymalizacji rozmiaru pliku.
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Ponadto jakość JPEG jest zachowywana lub nieznacznie zmniejszana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.
{{% /alert %}}

## **Zablokowanie proporcji**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje po zmianie wymiarów obrazu, ustaw właściwość [aspect_ratio_locked](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) na `True`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Zablokuj proporcje podczas zmiany rozmiaru.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje samego kształtu, a nie proporcje obrazu wewnątrz niego.
{{% /alert %}}

## **Używanie właściwości Stretch Offset**

Korzystając z właściwości `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` i `stretch_offset_bottom` klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/), możesz zdefiniować prostokąt wypełnienia.

Gdy określone jest rozciąganie obrazu, prostokąt źródłowy jest skalowany, aby dopasować się do prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest określana przez procentowy offset od odpowiadającej krawędzi obramowania kształtu. Pozytywny procent określa wcięcie, ujemny – wystawienie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu według jego indeksu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/).
4. Ustaw typ wypełnienia kształtu.
5. Ustaw tryb wypełnienia obrazu kształtu.
6. Załaduj obraz.
7. Przypisz obraz jako wypełnienie kształtu.
8. Określ offsety obrazu względem odpowiadających krawędzi obramowania kształtu.
9. Zapisz prezentację jako plik PPTX.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation reprezentującej plik PPTX.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt prostokątny.
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

    # Określ przesunięcia obrazu względem odpowiednich krawędzi obramowania kształtu.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Zapisz plik PPTX na dysku.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose udostępnia darmowe konwertery – [JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) – które umożliwiają szybkie tworzenie prezentacji z obrazów.
{{% /alert %}}

## **FAQ**

**Jak mogę dowiedzieć się, które formaty obrazów są obsługiwane dla PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) za pośrednictwem obiektu obrazu przypisanego do [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; łączenie obrazów pomaga utrzymać mały rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne pozostały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako linków w celu zmniejszenia rozmiaru pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przesuwaniem/zmianą rozmiaru?**

Użyj [shape locks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/picture_frame_lock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) (np. wyłącz przesuwanie lub zmianę rozmiaru). Mechanizm blokowania opisany jest w oddzielnym [artykule o ochronie](/slides/pl/python-net/applying-protection-to-presentation/) i jest obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/).

**Czy integralność wektora SVG jest zachowana przy eksporcie prezentacji do PDF/obrazów?**

Aspose.Slides pozwala wyodrębnić SVG z [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) jako oryginalny wektor. Przy [eksportowaniu do PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/python-net/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, jest potwierdzany przez zachowanie podczas ekstrakcji.