---
title: Optymalizacja zarządzania obrazami w PowerPoint przy użyciu Pythona
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/python-net/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zastąp obraz
- zastąp zdjęcie
- z sieci
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona na platformie .NET, optymalizując wydajność i automatyzując swój przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i interesujące. W programie Microsoft PowerPoint możesz wstawiać zdjęcia z pliku, internetu lub innych źródeł na slajdy. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów na kilka sposobów.

{{% alert title="Wskazówka" color="primary" %}}

Aspose udostępnia darmowe konwertery —[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) oraz [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—które pozwalają szybko tworzyć prezentacje z obrazów.

{{% /alert %}}

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako obiekt ramki—szczególnie gdy planujesz używać standardowych opcji formatowania, takich jak zmiana rozmiaru lub stosowanie efektów—zobacz [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/pl/python-net/picture-frame/).

{{% /alert %}}

{{% alert title="Uwaga" color="warning" %}}

Możesz używać operacji I/O obrazów i prezentacji do konwersji obrazów między formatami. Zobacz te strony: konwertuj [image to JPG](https://products.aspose.com/slides/pl/python-net/conversion/image-to-jpg/); konwertuj [JPG to image](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-image/); konwertuj [JPG to PNG](https://products.aspose.com/slides/pl/python-net/conversion/jpg-to-png/); konwertuj [PNG to JPG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-jpg/); konwertuj [PNG to SVG](https://products.aspose.com/slides/pl/python-net/conversion/png-to-svg/); oraz konwertuj [SVG to PNG](https://products.aspose.com/slides/pl/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides obsługuje pracę z obrazami w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne.

## **Dodaj obrazy przechowywane lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów z komputera do slajdu w prezentacji. Poniższy przykład w Pythonie pokazuje, jak dodać obraz do slajdu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj obrazy z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest dostępny na komputerze, możesz go wstawić bezpośrednio z sieci.

Poniższy przykład w Pythonie pokazuje, jak dodać obraz z adresu URL do slajdu:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Pobierz surowe bajty obrazu.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj obrazy do szablonów slajdów**

Szablon slajdu to slajd najwyższego poziomu, który przechowuje i kontroluje informacje—temat, układ itp.—dla wszystkich slajdów pod nim. Gdy dodasz obraz do szablonu slajdu, obraz ten pojawi się na każdym slajdzie używającym tego szablonu.

Poniższy przykład w Pythonie pokazuje, jak dodać obraz do szablonu slajdu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj obrazy jako tło slajdów**

Możesz użyć obrazu jako tła jednego lub wielu slajdów. Szczegóły znajdziesz w *[Setting Images as Backgrounds for Slides](/slides/pl/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodaj SVG do prezentacji**

Treść SVG można dodać do prezentacji za pomocą klasy [SvgImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/). Powstały obraz SVG może następnie zostać dodany do kolekcji obrazów prezentacji i użyty do stworzenia ramki obrazu.

Poniższy przykład w Pythonie importuje samodzielny ciąg SVG. Wszystkie obrazy, style i inne zasoby użyte w tym SVG są osadzone bezpośrednio w treści SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Konwertuj SVG na zestaw kształtów**

Aspose.Slides konwertuje pliki SVG na zestaw kształtów w sposób podobny do obsługi SVG w programie PowerPoint.

![Menu podręczne PowerPoint](img_01_01.png)

Ta funkcjonalność jest udostępniana przez przeciążenie metody [add_group_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_group_shape/) w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/), które przyjmuje obiekt [SvgImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/) jako pierwszy argument. 
 
Poniższy kod pokazuje, jak przekonwertować plik SVG na zestaw kształtów.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Odczytaj zawartość pliku SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Utwórz obiekt SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Pobierz rozmiar slajdu.
        slide_size = presentation.slide_size.size

        # Konwertuj obraz SVG na grupę kształtów i przeskaluj go do rozmiaru slajdu.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Zapisz prezentację w formacie PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj obrazy jako EMF do slajdów**

Aspose.Slides for Python umożliwia wstawianie obrazów Enhanced Metafile (EMF) do prezentacji.

Poniższy przykład w Pythonie demonstruje to:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastąp obrazy w kolekcji obrazów**

Aspose.Slides pozwala zastąpić obrazy przechowywane w kolekcji obrazów prezentacji, w tym te używane przez kształty slajdów. Ten rozdział opisuje kilka podejść do aktualizacji obrazów w kolekcji. API udostępnia proste metody zastąpienia obrazu surowymi danymi bajtowymi, instancją [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) lub innym obrazem już istniejącym w kolekcji.

Postępuj zgodnie z poniższymi krokami:

1. Załaduj prezentację zawierającą obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Załaduj nowy obraz z pliku do tablicy bajtów.
1. Zastąp docelowy obraz nowym obrazem przy użyciu tablicy bajtów.
1. Alternatywnie, załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
1. Lub zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:

    # Pierwszy sposób.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Drugi sposób.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Trzeci sposób.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Zapisz prezentację do pliku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Informacja" color="info" %}}

Korzystając z darmowego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować tekst i tworzyć pliki GIF z tekstu.

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/python-net/picture-frame/) jest skalowany na slajdzie i od kompresji zastosowanej przy zapisie.

**Jaki jest najlepszy sposób na jednoczesną wymianę tego samego logo na dziesiątki slajdów?**

Umieść logo w szablonie master lub układzie i zastąp je w kolekcji obrazów prezentacji — zmiany zostaną rozpowszechnione na wszystkie elementy używające tego zasobu.

**Czy wstawiony SVG można przekonwertować na edytowalne kształty?**

Tak. Możesz przekonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło wielu slajdów jednocześnie?**

[Assign the image as the background](/slides/pl/python-net/presentation-background/) na szablonie master lub odpowiednim układzie — wszystkie slajdy używające tego szablonu/układu odziedziczą tło.

**Jak zapobiec zbyt dużemu rozmiarowi prezentacji spowodowanemu wieloma obrazami?**

Ponownie używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i utrzymuj powtarzalne grafiki w szablonie, gdy to właściwe.