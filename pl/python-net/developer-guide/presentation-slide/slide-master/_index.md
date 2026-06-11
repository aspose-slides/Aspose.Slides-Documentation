---
title: Zarządzanie masterami slajdów prezentacji w Pythonie
linktitle: Master slajdu
type: docs
weight: 80
url: /pl/python-net/slide-master/
keywords:
- master slajdu
- slajd master
- master slajd PPT
- wiele master slajdów
- porównanie master slajdów
- tło
- placeholder
- klonuj master slajd
- kopiuj master slajd
- duplikuj master slajd
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla Pythona poprzez .NET: uzyskuj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Slide master** określa wspólne ustawienia projektu dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu oraz stopki. W programie PowerPoint edycja slide mastera jest typowym sposobem zachowania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Python via .NET obsługuje ten sam model. Prezentacja może zawierać jedną lub więcej master‑slajdów, a każdy master‑slajd może zawierać kilka layout‑slajdów. Normalne slajdy zazwyczaj nie odwołują się bezpośrednio do master‑slajdu. Zamiast tego używają layout‑slajdu, który należy do master‑slajdu.

Hierarchia wygląda następująco:

1. **Slide master** – definiuje wspólny projekt i motyw.  
1. **Layout slide** – definiuje konkretny układ placeholderów i formatowanie na poziomie układu.  
1. **Normal slide** – zawiera rzeczywistą treść prezentacji i korzysta z jednego layout‑slajdu.

![Hierarchia master‑slajdów, layout‑slajdów i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides master‑slajd jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/). Wszystkie master‑slajdy w prezentacji są dostępne przez kolekcję `Presentation.masters`.

{{% alert color="info" title="Dziedziczenie" %}}

Gdy to samo właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master‑slajd i layout‑slajd definiują tło, slajdy oparte na tym layout‑cie używają tła layout‑u. Więcej informacji o layout‑slajdach znajdziesz w [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **Dostęp do master‑slajdów**

W programie PowerPoint możesz otworzyć widok Slide Master z **View** > **Slide Master**.

![Polecenie Slide Master na karcie View w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `masters`, aby uzyskać dostęp do master‑slajdów:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Możesz także pobrać master‑slajd używany przez normalny slajd poprzez jego layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Co zawiera master‑slajd**

Master‑slajd jest obiektem podobnym do slajdu. Dziedziczy wspólne zachowanie slajdu z klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/), więc udostępnia wiele takich samych właściwości slajdu, które są używane przez slajdy normalne i layout‑slajdy. Członkowie specyficzni dla master‑slajdu są opisani na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/).

Często używane członki master‑slajdu:

| Member | Cel |
| --- | --- |
| `background` | Ustawia tło na poziomie master‑slajdu. |
| `shapes` | Przechowuje kształty umieszczone na masterze, takie jak loga, ramki obrazów i współdzielony tekst. |
| `layout_slides` | Przechowuje layout‑slajdy należące do mastera. |
| `theme_manager` | Udostępnia dostęp do API motywu mastera. |
| `header_footer_manager` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego podrzędnych layoutów. |
| `get_depending_slides` | Zwraca normalne slajdy zależne od mastera poprzez ich layouty. |

## **Dodanie obrazu do master‑slajdu**

Gdy dodasz obraz do master‑slajdu, pojawi się on na slajdach wykorzystujących layouty z tego mastera. Jest to przydatne dla logotypów, znaków wodnych, dekoracyjnych pasków i innych powtarzalnych elementów wizualnych.

Poniższy przykład dodaje logo do pierwszego master‑slajdu:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Więcej informacji o ramkach obrazów znajdziesz w [Picture Frame](/python-net/picture-frame/).

## **Praca z placeholderami**

Placeholdery są zazwyczaj definiowane na layout‑slajdach. Master‑slajd zapewnia wspólny styl i motyw, które te layouty dziedziczą, podczas gdy każdy layout decyduje, które placeholdery są dostępne i gdzie są umieszczone.

W PowerPoint polecenia placeholderów są dostępne w widoku Slide Master.

![Polecenie Insert Placeholder w widoku Slide Master w PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery w Aspose.Slides, pracuj z layout‑slajdem, który należy do mastera:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Możesz także sformatować istniejące kształty placeholderów na master‑slajdzie. Poniższy przykład znajduje placeholder tytułu i stosuje wypełnienie gradientem liniowym:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Sformatowany placeholder tytułu dziedziczony przez normalne slajdy](slide-master_8.png)

Więcej opcji formatowania placeholderów i tekstu znajdziesz w [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) oraz [Text Formatting](/python-net/text-formatting/).

## **Zmiana tła master‑slajdu**

Tło mastera jest dziedziczone przez layouty i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego master‑slajdu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Powiązane tematy: [Presentation Background](/python-net/presentation-background/) i [Presentation Theme](/python-net/presentation-theme/).

## **Klonowanie master‑slajdu do innej prezentacji**

Użyj metody `add_clone` klasy [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/), aby skopiować master‑slajd do innej prezentacji. Skopiowany master może potem być używany przez layouty i slajdy w prezentacji docelowej.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz sklonować normalne slajdy razem z ich masterem, zobacz [Clone Slides](/python-net/clone-slides/).

## **Dodawanie wielu master‑slajdów**

Prezentacja może zawierać wiele master‑slajdów. Jest to przydatne, gdy różne sekcje wymagają innego brandingu, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania master‑slajdami](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, pobiera pusty layout pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym layoutcie:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Porównywanie master‑slajdów**

Master‑slajdy można porównać metodą `equals` dziedziczoną po klasie [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości placeholderów, takich jak bieżąca data.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Więcej informacji znajdziesz w [Compare Presentation Slides](/python-net/compare-slides/).

## **Ustawienie widoku Slide Master jako widoku domyślnego**

Użyj właściwości `last_view` na obiekcie [ViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/) prezentacji, aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/python-net/save-presentation/).

## **Usuwanie nieużywanych master‑slajdów**

Czasami prezentacje zawierają master‑slajdy, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `remove_unused`, aby usunąć nieużywane mastery z kolekcji `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Możesz także skorzystać z niskokodowej metody `remove_unused_master_slides` klasy [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaka jest różnica między slide masterem a layout‑slajdem?**

Slide master definiuje wspólne ustawienia projektu, takie jak motyw, tło, wspólne kształty i style tekstu. Layout‑slajd należy do mastera i definiuje konkretny układ placeholderów. Normalny slajd używa layout‑slajdu, więc dziedziczy zarówno z layoutu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka master‑slajdów?**

Tak. Prezentacja może zawierać wiele master‑slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

**Czy powinienem dodawać placeholdery do master‑slajdu czy do layout‑slajdu?**

W większości przypadków dodawaj placeholdery do layout‑slajdów. Umieść współdzielone elementy wizualne i formatowanie na master‑slajdzie, a placeholdery treści na layoutach, które będą wykorzystywane przez normalne slajdy.

**Czy mogę usunąć master‑slajd, który jest nadal używany?**

Nie. Master‑slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do layoutów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko te, które nie są wykorzystywane.