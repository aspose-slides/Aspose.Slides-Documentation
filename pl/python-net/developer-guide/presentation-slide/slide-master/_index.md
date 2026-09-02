---
title: Zarządzanie masterami slajdów w Pythonie
linktitle: Master slajdu
type: docs
weight: 80
url: /pl/python-net/slide-master/
keywords:
- master slajdu
- master slajd
- master slajdu PPT
- wiele masterów slajdów
- porównanie masterów slajdów
- tło
- element zastępczy
- klonowanie mastera slajdu
- kopiowanie mastera slajdu
- duplikowanie mastera slajdu
- nieużywany master slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides for Python via .NET: uzyskuj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Master slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu oraz stopki. W PowerPoint edycja mastera slajdu jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Python via .NET obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master może zawierać kilka układów slajdów. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do mastera slajdu. Zamiast tego zwykły slajd używa układu slajdu, a ten układ należy do mastera slajdu.

Hierarchia wygląda następująco:

1. **Master slajdu** – definiuje wspólny projekt i motyw.  
1. **Układ slajdu** – definiuje określony układ elementów zastępczych i formatowanie poziomu układu.  
1. **Zwykły slajd** – zawiera rzeczywistą treść prezentacji i używa jednego układu slajdu.

![Hierarchia master slajdów, układów slajdów i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajdu jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/). Wszystkie master slajdy w prezentacji są dostępne poprzez kolekcję `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Gdy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master slajdu i układ slajdu definiują tło, slajdy oparte na tym układzie używają tła układu. Więcej informacji o układach slajdów znajdziesz w [Apply or Change Slide Layouts](/slides/pl/python-net/slide-layout/).
{{% /alert %}}

## **Dostęp do masterów slajdów**

W PowerPoint możesz otworzyć widok Master slajdu z **View** > **Slide Master**.

![Polecenie Slide Master na karcie View w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `masters`, aby uzyskać dostęp do masterów slajdów:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Możesz także pobrać master slajdu używany przez zwykły slajd poprzez jego układ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Co zawiera master slajdu**

Master slajd jest obiektem podobnym do slajdu. Dziedziczy wspólne zachowanie slajdu z klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez zwykłe i układy slajdów. Członkowie specyficzni dla mastera są wymienieni na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/).

Często używane członki mastera slajdu obejmują:

| Członek | Zastosowanie |
| --- | --- |
| `background` | Ustawia tło slajdu na poziomie mastera. |
| `shapes` | Przechowuje kształty umieszczone na masterze, takie jak logo, ramki obrazu i wspólny tekst. |
| `layout_slides` | Przechowuje układy slajdów należące do mastera. |
| `theme_manager` | Zapewnia dostęp do interfejsów API motywu mastera. |
| `header_footer_manager` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego układów potomnych. |
| `get_depending_slides` | Zwraca zwykłe slajdy zależne od mastera poprzez ich układy. |

## **Dodanie obrazu do mastera slajdu**

Gdy dodasz obraz do mastera slajdu, pojawia się on na slajdach, które używają układów z tego mastera. Jest to przydatne przy logo, znakach wodnych, dekoracyjnych pasach i innych powtarzających się elementach wizualnych.

Poniższy przykład dodaje logo do pierwszego mastera slajdu:

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

Więcej informacji o ramkach obrazu znajdziesz w [Picture Frame](/slides/pl/python-net/picture-frame/).

## **Praca z elementami zastępczymi**

Elementy zastępcze są zazwyczaj definiowane w układach slajdów. Master slajdu zapewnia wspólny styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które elementy zastępcze są dostępne i gdzie są rozmieszczone.

W PowerPoint polecenia elementów zastępczych są dostępne w widoku Master slajdu.

![Polecenie Insert Placeholder w widoku Master slajdu PowerPoint](slide-master_5.png)

Aby dodać nowe elementy zastępcze za pomocą Aspose.Slides, pracuj z układem slajdu należącym do mastera:

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

Możesz także formatować kształty elementów zastępczych, które już istnieją w masterze slajdu. Poniższy przykład znajduje element zastępczy tytułu i stosuje liniowe wypełnienie gradientowe:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Sformatowany element zastępczy tytułu dziedziczony przez zwykłe slajdy](slide-master_8.png)

Więcej opcji formatowania elementów zastępczych i tekstu znajdziesz w [Set Prompt Text in Placeholder](/slides/pl/python-net/manage-placeholder/) oraz [Text Formatting](/slides/pl/python-net/text-formatting/).

## **Zmiana tła mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mastera slajdu:

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

Powiązane tematy: [Presentation Background](/slides/pl/python-net/presentation-background/) oraz [Presentation Theme](/slides/pl/python-net/presentation-theme/).

## **Klonowanie mastera slajdu do innej prezentacji**

Użyj metody `add_clone` klasy [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/), aby skopiować master slajdu do innej prezentacji. Skopiowany master może potem być używany przez układy i slajdy w docelowej prezentacji.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz sklonować zwykłe slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/python-net/clone-slides/).

## **Dodanie wielu masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych elementów brandingowych, struktury strony lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania masterami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, pobiera pusty układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

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

## **Porównywanie masterów slajdów**

Master slajdy można porównać metodą `equals` dziedziczoną po klasie [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości elementów zastępczych, np. bieżącej daty.

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

Więcej informacji znajdziesz w [Compare Presentation Slides](/slides/pl/python-net/compare-slides/).

## **Ustawienie widoku Master slajdu jako widoku domyślnego**

Użyj właściwości `last_view` w obiekcie prezentacji [ViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/), aby kontrolować widok otwierany jako pierwszy w PowerPoint. Poniższy przykład otwiera prezentację w widoku Master slajdu:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/slides/pl/python-net/save-presentation/).

## **Usuwanie nieużywanych masterów slajdów**

Prezentacje czasami zawierają mastery slajdów, które nie są już używane przez żadne zwykłe slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `remove_unused`, aby usunąć nieużywane mastery z kolekcji `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Możesz również skorzystać z niskokodowej metody `remove_unused_master_slides` klasy [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Jaka jest różnica między masterem slajdu a układem slajdu?

Master slajdu definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Układ slajdu należy do mastera i określa konkretny układ elementów zastępczych. Zwykły slajd używa układu, więc dziedziczy zarówno z układu, jak i z mastera.

### Czy jedna prezentacja może zawierać kilka masterów slajdów?

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

### Czy powinienem dodawać elementy zastępcze do mastera slajdu czy do układu slajdu?

W większości przypadków elementy zastępcze dodaje się do układów slajdów. Na masterze umieszcza się wspólne elementy wizualne i wspólne formatowanie, a na układach – miejsca na treść, które będą wykorzystywane przez zwykłe slajdy.

### Czy mogę usunąć master slajdu, który jest nadal używany?

Nie. Master slajdu, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko te, które nie są w użyciu.