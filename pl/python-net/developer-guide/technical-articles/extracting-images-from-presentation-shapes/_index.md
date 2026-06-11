---
title: Wyodrębnianie obrazów z kształtów prezentacji w Pythonie
linktitle: Obraz z kształtu
type: docs
weight: 90
url: /pl/python-net/extracting-images-from-presentation-shapes/
keywords:
- wyodrębnić obraz
- pobrać obraz
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Wyodrębnij obrazy z kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via .NET - szybkie, przyjazne dla kodu rozwiązanie."
---
## **Przegląd**

Obrazy w prezentacji mogą pojawiać się w kilku typach kształtów: jako zwykłe ramki obrazów, jako wypełnienia obrazem zastosowane do kształtów, jako obrazy podglądu obiektów OLE, jako miniatury klatek wideo lub audio, jako obrazy powiększenia lub jako obrazy zagnieżdżone wewnątrz kształtów tabel, wykresów i SmartArt. Aspose.Slides przechowuje te obrazy w kolekcji obrazów prezentacji, udostępnianej poprzez obiekty [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/) i [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/).

Jeśli potrzebujesz wyeksportować każdy zasób obrazu osadzony w prezentacji, iteruj po `presentation.images`. Ten artykuł koncentruje się na innym zadaniu: przeglądaniu kształtów w celu znalezienia, gdzie obrazy są używane na slajdach, aby zapisane pliki mogły zachować przydatny kontekst, taki jak numer slajdu, pozycja kształtu i typ źródła (ramka obrazu, wypełnienie obrazu, podgląd multimediów, podgląd OLE lub obraz powiększenia).

{{% alert title="Tip" color="primary" %}}
Użyj właściwości `binary_data` obiektu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/), aby zachować oryginalne zakodowane dane obrazu i typ pliku. Użyj właściwości `image` wraz z `save`, gdy chcesz znormalizować wyjście do konkretnego formatu, takiego jak PNG.
{{% /alert %}}

## **Wspólne Metody Pomocnicze**

Poniższe metody pomocnicze skracają przykłady. `save_original_image` zapisuje oryginalne osadzone bajty, wybiera bezpieczne rozszerzenie na podstawie typu MIME i pomija duplikaty binariów obrazu dzięki skrótowi SHA‑256.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Wyodrębnianie Obrazów z Ramkach Obrazów**

Użyj tego podejścia dla zdjęć wstawionych jako samodzielne obiekty. Obiekt [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) przechowuje swój obraz w `picture_format.picture.image`, który zwraca obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Wyodrębnianie Obrazów z Kształtów Wypełnionych Obrazem**

Kształty mogą używać obrazu jako wypełnienia. Najpierw sprawdź typ wypełnienia kształtu: jeśli nie jest to [FillType.PICTURE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/), nie ma obrazu do wyodrębnienia z tego wypełnienia. Poniższy przykład obsługuje obiekty [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) i zapisuje każdy obraz jako PNG za pomocą właściwości `image` obiektu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Wyodrębnianie Obrazów Podglądu z Ram OLE**

Obiekt [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) może mieć zastępczy obraz, którego PowerPoint używa jako podglądu obiektu na slajdzie. Ten obraz jest dostępny przez `substitute_picture_format.picture.image`. Wyodrębnienie tego obrazu daje podgląd, a nie osadzone treści pakietu OLE.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Wyodrębnianie Obrazów Podglądu z Klatek Wideo**

Obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) może również przechowywać obraz podglądu w `picture_format.picture.image`. Jest to plakat lub miniatura wyświetlana na slajdzie, a nie klatka zdekodowana z strumienia wideo.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Wyodrębnianie Obrazów Podglądu z Klatek Audio**

Obiekt [AudioFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/) może przechowywać miniaturę w `picture_format.picture.image`. To obraz wyświetlany dla obiektu audio na slajdzie.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Wyodrębnianie Obrazów z Obiektów Powiększenia**

[ZoomFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/zoomframe/) i [SectionZoomFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectionzoomframe/) mogą używać własnych obrazów. Odczytaj `zoom_image` z ramki powiększenia.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Wyodrębnianie Obrazów z Ramek Podsumowania Powiększenia**

[SummaryZoomFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/summaryzoomframe/) jest również kształtem. Jego elementy sekcji mogą używać własnych obrazów, udostępnionych przez właściwość `zoom_image` każdego podsumowującego sekcji.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Wyodrębnianie Obrazów z Kształtów Tabel**

[Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) jest kształtem. Obrazy w tabeli są zazwyczaj przechowywane jako wypełnienia obrazem w komórkach tabeli.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Wyodrębnianie Obrazów z Kształtów Wykresów**

[Chart](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/) jest kształtem. Poniższy przykład wyodrębnia obraz z wypełnienia obrazu obszaru wykresu.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Wyodrębnianie Obrazów z Kształtów SmartArt**

Obiekt [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/) jest kształtem. W zależności od układu SmartArt, obrazy mogą być przechowywane w wypełnieniach punktów węzłów lub w formatach wypełnienia kształtów węzłów.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Uwzględnianie Obrazów w Grupowanych Kształtach**

Grupowane kształty zawierają własne kolekcje kształtów. Współdzielona metoda pomocnicza `enumerate_shapes` ma opcję `include_grouped_shapes`. Ustaw ją na `True`, gdy chcesz przeglądać kształty wewnątrz obiektów [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/). Poniższy przykład wyodrębnia obrazy z ramek obrazów, kształtów wypełnionych obrazem, podglądów obiektów OLE, miniatur klatek wideo i miniatur klatek audio. Aby uwzględnić także obrazy z tabel, wykresów, SmartArt i podsumowań powiększenia, ponownie użyj specjalistycznej logiki wyodrębniania z poprzednich sekcji, zachowując tę samą rekurencyjną traversację kształtów.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Przypadki Brzegowe i Praktyczne Uwagi**

- **Duplikaty obrazów:** Wiele kształtów może odwoływać się do tego samego obrazu lub do różnych obrazów o identycznych bajtach. Zhashuj właściwość `binary_data` obiektu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) przed zapisem plików, jeśli chcesz uzyskać jeden plik wyjściowy na każdy unikalny obraz.
- **Oryginalne dane vs. przekonwertowane wyjście:** Zapisywanie właściwości `binary_data` obiektu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) zachowuje osadzony JPEG, PNG, GIF, SVG, EMF lub WMF. Zapisywanie właściwości `image` przy użyciu `save` jest przydatne, gdy potrzebny jest spójny format wyjściowy.
- **Nieobsługiwane typy wypełnień:** Kształty z wypełnieniem jednolitym, gradientowym, wzorowanym lub bez wypełnienia nie zawierają obrazu wypełnienia. Sprawdź [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) przed odczytem `picture_fill_format`.
- **Grupowane kształty:** Górna kolekcja kształtów slajdu nie spłaszcza grup. Rekurencyjnie sprawdzaj [GroupShape.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/shapes/), gdy zawartość grup ma znaczenie.
- **Podglądy obiektów OLE:** [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) może udostępniać obraz podglądu przez `substitute_picture_format`, ale jest to jedynie podgląd slajdu, nie osadzony plik w obiekcie OLE.
- **Miniatury klatek wideo:** [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) może udostępniać obraz podglądu przez `picture_format`, ale jest to jedynie plakat wyświetlany na slajdzie, nie wyodrębniona klatka z strumienia wideo.
- **Miniatury klatek audio:** [AudioFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/) może udostępniać ikonę lub miniaturę przez `picture_format`; nie jest to osadzony dźwięk.
- **Obrazy powiększenia:** Kształty powiększenia slajdu, sekcji i podsumowania mogą używać własnych obiektów [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) poprzez `image`.
- **Zagnieżdżone modele kształtów:** Obiekty tabel, wykresów i SmartArt implementują [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/), ale ich obrazy są często przechowywane w zagnieżdżonych obiektach formatowania komórek tabeli, elementów wykresu lub węzłów SmartArt.
- **Przycięte lub przekształcone obrazy:** Dostęp do [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) daje zasób obrazu przechowywany w prezentacji. Nie renderuje przycięć, przezroczystości, zmian kolorów, rotacji ani innych efektów wizualnych zastosowanych przez kształt.

## **FAQ**

**Czy mogę wyodrębnić oryginalny obraz bez przycinania, efektów lub przekształceń kształtu?**

Tak. Uzyskaj obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) i zapisz jego właściwość `binary_data` na dysk. Dzięki temu zachowasz oryginalnie zakodowany obraz przechowywany w prezentacji, a nie sposób, w jaki jest renderowany na slajdzie.

**Czy mogę wyeksportować każdy wyodrębniony obraz jako PNG?**

Tak. Użyj właściwości `image` obiektu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) i wywołaj `save` z [ImageFormat.PNG](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imageformat/). To konwertuje wyjście i może nie zachować oryginalnego typu pliku ani danych wektorowych.

**Jak uniknąć zapisywania tego samego obrazu więcej niż raz?**

Użyj skrótu właściwości `binary_data` obiektu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) i przechowuj skróty w zestawie. Jeśli nowy obraz ma skrót, który już istnieje, pomiń go lub zanotuj kolejne odniesienie do istniejącego pliku wyjściowego.

**Dlaczego niektóre kształty nie generują obrazu?**

Ramki obrazów, kształty wypełnione obrazem, ramki obiektów OLE, ramki multimediów, ramki powiększenia, tabele, wykresy i obiekty SmartArt mogą odwoływać się do obrazów. Niektóre typy kształtów udostępniają obrazy przez zagnieżdżone obiekty formatowania, więc proste sprawdzenie `picture_format` lub `fill_format` nie zawsze wystarczy.

**Czy mogę wyodrębnić miniaturę wyświetlaną dla klatki wideo?**

Tak. Użyj [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) i odczytaj `picture_format.picture.image`. To wyodrębnia plakat przechowywany razem z klatką wideo, a nie klatkę wygenerowaną z pliku wideo.

**Jak mogę określić, które kształty używają konkretnego obrazu z kolekcji obrazów prezentacji?**

Aspose.Slides nie przechowuje odwróconych odnośników od [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) do kształtów. Zbuduj mapowanie podczas traversacji: za każdym razem, gdy znajdziesz odwołanie do obrazu, zanotuj numer slajdu, ścieżkę kształtu oraz skrót obrazu lub element kolekcji.

**Czy mogę wyodrębnić obrazy osadzone wewnątrz obiektów OLE, np. załączone dokumenty?**

Możesz wyodrębnić podgląd slajdu obiektu OLE z właściwości `substitute_picture_format` obiektu [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/). Jednak ten podgląd nie jest osadzonym dokumentem. Aby wyodrębnić obrazy z wewnątrz pliku osadzonego, wyodrębnij dane OLE i przeanalizuj je przy użyciu narzędzi odpowiednich dla tego typu pliku.