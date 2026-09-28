---
title: "Zarządzanie masterami slajdów prezentacji w Pythonie"
linktitle: "Master slajdu"
type: docs
weight: 80
url: /pl/python-net/slide-master/
keywords:
  - "master slajdu"
  - "master slajd"
  - "master slajd PPT"
  - "wiele master slajdów"
  - "porównanie master slajdów"
  - "tło"
  - "symbol zastępczy"
  - "klonowanie master slajdu"
  - "kopiowanie master slajdu"
  - "duplikowanie master slajdu"
  - "nieużywany master slajd"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - "Python"
  - "Aspose.Slides"
description: "Zarządzaj masterami slajdów w Aspose.Slides for Python via .NET: dostęp, edycja, klonowanie, porównywanie i usuwanie master slajdów w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Slide master** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu oraz ustawienia stopki. W programie PowerPoint edycja slide mastera jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Python via .NET obsługuje ten sam model. Prezentacja może zawierać jedną lub więcej master‑slajdów, a każdy master‑slajd może zawierać kilka layout‑slajdów. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do master‑slajdu. Zamiast tego używają layout‑slajdu, który należy do master‑slajdu.

Hierarchia wygląda następująco:

1. **Slide master** – definiuje wspólny projekt i motyw.  
1. **Layout slide** – definiuje konkretne rozmieszczenie placeholderów i formatowanie na poziomie layoutu.  
1. **Normal slide** – zawiera rzeczywistą treść prezentacji i używa jednego layout‑slajdu.

![Hierarchia master‑slajdów, layout‑slajdów i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides master‑slajd jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/). Wszystkie master‑slajdy w prezentacji są dostępne poprzez kolekcję `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}

Gdy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master‑slajd i layout‑slajd definiują tło, slajdy oparte na tym layout‑slajdzie używają tła layoutu. Więcej informacji o layout‑slajdach znajdziesz w sekcji [Apply or Change Slide Layouts](/slides/pl/python-net/slide-layout/).

{{% /alert %}}

## **Dostęp do Slide Masterów**

W programie PowerPoint można otworzyć widok Slide Master z **View** > **Slide Master**.

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

## **Co zawiera Slide Master**

Master‑slajd jest obiektem podobnym do slajdu. Dziedziczy wspólne zachowanie slajdu z klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości używanych przez normalne i layout‑slajdy. Członkowie specyficzni dla mastera są wymienieni na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/).

Typowo używane członki master‑slajdu to:

| Członek | Cel |
| --- | --- |
| `background` | Ustawia tło na poziomie master‑slajdu. |
| `shapes` | Przechowuje kształty umieszczone na masterze, takie jak loga, ramki obrazów i wspólny tekst. |
| `layout_slides` | Przechowuje layout‑slajdy należące do mastera. |
| `theme_manager` | Udostępnia dostęp do API motywu mastera. |
| `header_footer_manager` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego layoutów potomnych. |
| `get_depending_slides` | Zwraca normalne slajdy zależne od mastera poprzez ich layouty. |

## **Dodanie obrazu do Slide Mastera**

Gdy dodasz obraz do master‑slajdu, pojawi się on na slajdach korzystających z layoutów z tego mastera. Jest to przydatne dla logo, znaków wodnych, dekoracyjnych pasów i innych powtarzalnych elementów graficznych.

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

Więcej informacji o ramkach obrazu znajdziesz w sekcji [Picture Frame](/slides/pl/python-net/picture-frame/).

## **Kontrola widoczności grafiki mastera**

Użyj [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/show_master_shapes/), aby ukryć odziedziczoną grafikę mastera, taką jak loga lub dekoracyjne kształty, bez ich usuwania z mastera. Ustaw [Slide.show_master_shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/show_master_shapes/) na `False` na slajdzie, który ma pominąć tę grafikę, i pozostaw `True` na slajdach, które mają ją wyświetlać.

Poniższy, samodzielny przykład tworzy niebieski dekoracyjny pas na masterze oraz dwa slajdy używające tego samego pustego layoutu. Pas jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie wymaga żadnej wejściowej prezentacji ani obrazu.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Przykład używa layoutu **Blank** dostarczonego z nową prezentacją i usuwa początkowe placeholdery własne pierwszego slajdu.

### **Wybór zakresu ustawienia**

Normalny slajd korzysta ze swojego mastera poprzez [Slide.layout_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/layout_slide/) oraz [LayoutSlide.master_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/master_slide/). Ustawienie właściwości na pojedynczym slajdzie wpływa tylko na ten slajd. Ustawienie [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/show_master_shapes/) na `False` ukrywa grafikę mastera dla wszystkich slajdów używających tego wspólnego layoutu, nawet jeśli ich własne ustawienie jest `True`. Aby ukryć grafikę tylko na jednym slajdzie, zmień właściwość tego slajdu i pozostaw niezmieniony współdzielony layout.

Ustawienie to nie jest obsługiwane jako kontrola widoczności bezpośrednio na master‑slajdzie. Na masterze zawsze zwraca `False`, a przypisanie `True` generuje wyjątek. Zastosuj je do normalnego slajdu lub layoutu.

### **Rozróżnianie grafiki od tła**

| Operacja | Efekt |
| --- | --- |
| Ukryj grafikę mastera | Kontroluje widoczność odziedziczonych kształtów mastera bez ich usuwania lub zmiany własnych kształtów slajdu. |
| Zmień wypełnienie tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafika mastera jest oddzielnym kształtem i może pozostać widoczna nad tym tłem. Zobacz [Presentation Background](/slides/pl/python-net/presentation-background/). |
| Usuń kształt z mastera | Usuwa współdzielony źródłowy kształt, więc nie jest już dostępny dla żadnego slajdu korzystającego z tego mastera. |

## **Praca z placeholderami**

Placeholdery są zazwyczaj definiowane na layout‑slajdach. Master‑slajd zapewnia współdzielony styl i motyw, które te layouty dziedziczą, natomiast każdy layout decyduje, które placeholdery są dostępne i gdzie są umieszczone.

W PowerPoint polecenia placeholderów są dostępne w widoku Slide Master.

![Polecenie Insert Placeholder w widoku Slide Master w PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery za pomocą Aspose.Slides, pracuj z layout‑slajdem należącym do mastera:

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

Możesz także sformatować istniejące już kształty placeholderów na master‑slajdzie. Poniższy przykład znajduje placeholder tytułu i stosuje liniowy gradient:

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

![Sformatowany placeholder tytułu dziedziczony przez normalne slajdy](slide-master_8.png)

Więcej opcji dotyczących placeholderów i formatowania tekstu znajdziesz w sekcjach [Set Prompt Text in Placeholder](/slides/pl/python-net/manage-placeholder/) oraz [Text Formatting](/slides/pl/python-net/text-formatting/).

## **Zmiana tła Slide Mastera**

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

Powiązane tematy znajdziesz w sekcjach [Presentation Background](/slides/pl/python-net/presentation-background/) i [Presentation Theme](/slides/pl/python-net/presentation-theme/).

## **Klonoanie Slide Mastera do innej prezentacji**

Użyj metody `add_clone` klasy [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/), aby skopiować master‑slajd do innej prezentacji. Skopiowany master może następnie być używany przez layouty i slajdy w docelowej prezentacji.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz sklonować normalne slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/python-net/clone-slides/).

## **Dodawanie wielu Slide Masterów**

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

## **Porównywanie Slide Masterów**

Master‑slajdy można porównać przy użyciu metody `equals` odziedziczonej z klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak slide ID, ani dynamicznych wartości placeholderów, takich jak bieżąca data.

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

Więcej informacji znajdziesz w sekcji [Compare Presentation Slides](/slides/pl/python-net/compare-slides/).

## **Ustawienie widoku Slide Master jako widoku domyślnego**

Użyj właściwości `last_view` na obiekcie [ViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/) prezentacji, aby kontrolować widok otwierany jako pierwszy w PowerPoint. Poniższy przykład otwiera prezentację w widoku Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Więcej ustawień widoku znajdziesz w sekcji [Save Presentation](/slides/pl/python-net/save-presentation/).

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

Slide master definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Layout‑slajd należy do mastera i definiuje określone rozmieszczenie placeholderów. Normalny slajd używa layout‑slajdu, więc dziedziczy zarówno z layoutu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka slide masterów?**

Tak. Prezentacja może zawierać kilka slide masterów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

**Czy placeholdery powinny być dodawane do master‑slajdu czy do layout‑slajdu?**

W większości przypadków dodawaj placeholdery do layout‑slajdów. Umieść wspólne elementy wizualne i wspólne formatowanie na master‑slajdzie, a placeholdery treści na layoutach, z których będą korzystać normalne slajdy.

**Czy mogę usunąć master‑slajd, który jest nadal używany?**

Nie. Master‑slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do layoutów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko te, które nie są używane.