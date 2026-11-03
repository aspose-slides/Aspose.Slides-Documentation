---
title: Zarządzanie placeholderami prezentacji w Pythonie
linktitle: Zarządzaj placeholderami
type: docs
weight: 10
url: /pl/python-net/manage-placeholder/
keywords:
- symbol zastępczy
- symbol zastępczy tekstowy
- symbol zastępczy obrazu
- symbol zastępczy wykresu
- symbol zastępczy treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazkowe, wykresu i treści oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla Pythona w technologii .NET."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to placeholdery tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć pozycję, rozmiar, formatowanie i inne ustawienia ze slajdu układu lub slajdu master.

Aspose.Slides udostępnia informacje o placeholderach poprzez właściwość [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). Właściwość zwraca obiekt [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) lub `None` dla zwykłego kształtu. Użyj [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) aby określić, co placeholder ma zawierać.

Klasa kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstowy, obrazkowy, wykresu lub treści jest zazwyczaj reprezentowany przez [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Placeholder treści może zawierać różne rodzaje treści. Sprawdź zarówno [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) jak i klasę kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) opisuje rolę placeholdera; nie gwarantuje klasy kształtu w czasie wykonywania. Zawsze używaj sprawdzenia typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholders tworzą hierarchię:

1. Slajd master definiuje wielokrotnego użytku style i, w niektórych przypadkach, placeholdery na poziomie master.
2. Slajd układu definiuje układ używany przez jeden lub więcej normalnych slajdów i może dziedziczyć po masterze.
3. Normalny slajd zawiera placeholdery dla tego slajdu i może dziedziczyć po jego układzie.

Wywołaj [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) aby przejść jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder master. Metoda zwraca `None`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wymienia placeholdery na pierwszym slajdzie i raportuje ich bazowe placeholdery:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Edycja placeholdera na normalnym slajdzie tworzy lub zmienia lokalne zastąpienie dla tego slajdu. Edycja powiązanego układu lub mastera może wpływać na wszystkie slajdy, które nadal dziedziczą to ustawienie. Lokalne zwykłe kształty nie mają bazowego placeholdera i nie zaczynają dziedziczyć tylko dlatego, że zajmują te same współrzędne.

## **Usuwanie statusu placeholdera**

Podczas dostosowywania szablonu użyj [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) aby zachować istniejący obiekt jako zwykły kształt. Jego właściwość [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) staje się `None`, ale kształt pozostaje w kolekcji slajdu. Natomiast [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga pliku `template.pptx` zawierającego co najmniej jeden slajd i niepusty placeholder tekstowy na pierwszym slajdzie. Użyj placeholdera z formatowaniem dziedziczonym z jego układu lub mastera, aby zobaczyć efekt usunięcia tego powiązania. Przykład sprawdza, że ten sam kształt pozostaje, ponownie wywołuje metodę na teraz zwykłym kształcie i zapisuje wynik.

{{% alert color="warning" title="Warning" %}}
Usunięcie statusu placeholdera nie zachowuje automatycznie dziedziczonych ustawień wyglądu. Poniższy przykład celowo pozostawia te ustawienia niezmienione, więc wynik może wyglądać inaczej. Kształt, którego pozycja i rozmiar są całkowicie dziedziczone, może po wywołaniu mieć zerowe współrzędne i wymiary i stać się niewidoczny, mimo że pozostaje w kolekcji.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Wywołanie metody na zwykłym kształcie nie ma wpływu.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Dla pasującego placeholdera wszystkie trzy sprawdzenia wypisują `True`. Tekst pozostaje, ale dziedziczona pozycja, rozmiar, obrót, czcionka, wyrównanie akapitu, marginesy ramki tekstowej, pionowe zakotwiczenie, wypełnienie i ustawienia linii mogą się zmienić po usunięciu relacji placeholdera. Na przykład dziedziczony format tytułu może powrócić do zwykłego formatowania tekstu. Zobacz [Układ slajdu](/slides/pl/python-net/slide-layout/) po więcej informacji o układach.

Aby zachować zamierzony wygląd, przed wywołaniem przechwyć wyliczoną pozycję, rozmiar i obrót, a następnie skopiuj wymagane wartości efektywnego formatowania do osobnych zmiennych. Pobierz te wartości przy użyciu [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), oraz [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Nie polegaj wyłącznie na obiektach efektywnego formatowania, ponieważ ich wartości formatowania tekstu mogą się zmienić po usunięciu relacji. Następnie jawnie zastosuj przechwycone wartości do zwykłego kształtu, w tym rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstowej, wypełnienie i linię używaną w szablonie.

Dziedziczona geometria kształtu może również wymagać jawnego przypisania poprzez [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Dla prostokątnego placeholdera tekstowego oznacza to przypisanie [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); przywrócenie jedynie wypełnienia i linii może nie odtworzyć widocznego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem wymagają także obsługi tych ustawień.

## **Zmiana tekstu w placeholderze**

Placeholdery tytułu, wyśrodkowanego tytułu, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy jest to [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) przed użyciem jego właściwości [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

Ten przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ten wzorzec unika traktowania placeholderów obrazu, wykresu, tabeli lub mediów jako obiektów [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Identyfikuje również placeholder według przeznaczenia, zamiast polegać na kruchym indeksie kształtu.

## **Ustawianie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Click to add title*. Ustaw niestandardowy tekst podpowiedzi na placeholderze układu zamiast próbować go uzyskać przez kolekcję kształtów normalnego slajdu. Dostęp do układu uzyskaj przez [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) i iteruj po [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Tekst podpowiedzi nie jest normalną zawartością slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edycyjnych, takich jak PowerPoint. Po dostarczeniu prawdziwej treści przez użytkownika lub program, podpowiedź nie jest już wyświetlana. Zmiana podpowiedzi nie zastępuje również istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Do obsługi istnieją dwa przypadki:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), zastąp obraz przy użyciu [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) oraz [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Jeśli jest nadal pustym placeholderem, dodaj ramkę obrazu w współrzędnych placeholdera za pomocą [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) i usuń pusty placeholder.

Kolejny przykład obsługuje oba przypadki i zapisuje prezentację:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Zastępstwo utworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) jest tylko do odczytu. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie relacji placeholdera jest istotne, najpierw przygotuj i wypełnij placeholder w PowerPoint, a następnie zaktualizuj powstały [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) przy użyciu Aspose.Slides.

Aby uzyskać przezroczystość obrazu, przycinanie i inne efekty specyficzne dla obrazu, zobacz [Zarządzanie ramkami obrazu](/slides/pl/python-net/picture-frame/). Te operacje należą do ramki obrazu lub wypełnienia obrazu, a nie do metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i klasie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ogólny placeholder treści zazwyczaj ma typ [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz kilku rodzajów treści, w tym wykresów, tabel, diagramów, obrazów i mediów. Po jego wypełnieniu, sprawdź rzeczywistą klasę kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również udostępniać [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), lub [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) na [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) jedynie przez zmianę [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); typ jest tylko do odczytu. Aby programowo wypełnić pusty obszar wykresu lub treści, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy po placeholderze układu. Skorzystaj z dedykowanych [artykuły o zarządzaniu wykresami](/slides/pl/python-net/powerpoint-charts/) gdy potrzebujesz zamienić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja treści tekstowej lub graficznej**

Poniższy przykład end‑to‑end otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub traktowania każdego placeholdera jako tej samej klasy kształtu.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Co to jest bazowy placeholder?**

Bazowy placeholder to odpowiadający mu kształt na układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) aby go pobrać. Zwykły lokalny kształt zwraca `None`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułów jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie slajdu, układu, mastera, notatek lub rozdania. Zobacz [Zarządzanie nagłówkiem i stopką prezentacji](/slides/pl/python-net/presentation-header-and-footer/) po pełne przykłady.