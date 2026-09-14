---
title: "Zarządzanie masterami slajdów prezentacji w Pythonie via Java"
linktitle: "Master slajdu"
type: docs
weight: 70
url: /pl/python-java/slide-master/
keywords:
- master slajdu
- master slajd
- master slajd PPT
- wiele master slajdów
- porównaj master slajdy
- tło
- placeholder
- klonuj master slajd
- kopiuj master slajd
- zduplikuj master slajd
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj master slajdami w Aspose.Slides dla Pythona via Java: dostęp, edycja, klonowanie, porównywanie i usuwanie master slajdów w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

A **slide master** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu i stopki. W programie PowerPoint edycja slide mastera jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for Python via Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej master slajdów, a każdy master slajd może zawierać kilka layout slajdów. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do master slajdu. Zamiast tego zwykły slajd używa layout slajdu, a ten layout slajd należy do master slajdu.

Hierarchia jest:

1. **Slide master** – definiuje współdzielony projekt i motyw.  
1. **Layout slide** – definiuje określone rozmieszczenie placeholderów i formatowanie na poziomie układu.  
1. **Normal slide** – zawiera rzeczywistą treść prezentacji i używa jednego layout slajdu.

![Hierarchia master slajdów, layout slajdów i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajd jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/). Wszystkie master slajdy w prezentacji są dostępne poprzez kolekcję [Presentation.getMasters](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getMasters), która jest reprezentowana przez [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [Apply or Change Slide Layouts](/slides/pl/python-java/slide-layout/).

{{% /alert %}}

## **Dostęp do master slajdów**

W programie PowerPoint można otworzyć widok **Slide Master** z **View** > **Slide Master**.

![Polecenie Slide Master na karcie View w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji [Presentation.getMasters](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getMasters), aby uzyskać dostęp do master slajdów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Możesz również pobrać master slajd używany przez zwykły slajd poprzez jego layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Co zawiera master slajd**

Master slajd jest obiektem podobnym do slajdu. Dziedziczy z [BaseSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez zwykłe i layout slajdy. Specyficzne dla mastera członki są wymienione na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/).

Często używane członki master slajdu obejmują:

| Członek | Cel |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getBackground) | Ustawia tło slajdu na poziomie mastera. |
| [getShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getShapes) | Przechowuje kształty umieszczone na masterze, takie jak logotypy, ramki obrazów i wspólny tekst. |
| [getLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getLayoutSlides) | Przechowuje layout slajdy, które należą do mastera. |
| [getThemeManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getThemeManager) | Udostępnia dostęp do API motywu mastera. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego układów podrzędnych. |
| [getDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getDependingSlides) | Zwraca zwykłe slajdy zależne od mastera poprzez ich layouty. |

## **Dodaj obraz do master slajdu**

Gdy dodasz obraz do master slajdu, pojawi się on na slajdach korzystających z layoutów z tego mastera. Jest to przydatne w przypadku logotypów, znaków wodnych, dekoracyjnych pasów i innych powtarzalnych elementów wizualnych.

Poniższy przykład dodaje logo do pierwszego master slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Po więcej informacji o ramkach obrazów zobacz [Picture Frame](/slides/pl/python-java/picture-frame/).

## **Praca z placeholderami**

Placeholdery są zazwyczaj definiowane na layout slajdach. Master slajd zapewnia wspólny styl i motyw, które te layouty dziedziczą, podczas gdy każdy layout decyduje, które placeholdery są dostępne i gdzie są umieszczone.

W PowerPoint polecenia placeholderów są dostępne w widoku Slide Master.

![Polecenie Insert Placeholder w widoku Slide Master w PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery w Aspose.Slides, pracuj z layout slajdem, który należy do mastera:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Możesz także sformatować istniejące na masterze kształty placeholderów. Poniższy przykład znajduje placeholder tytułu i stosuje wypełnienie gradientem liniowym:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Sformatowany placeholder tytułu dziedziczony przez zwykłe slajdy](slide-master_8.png)

Po więcej opcji formatowania placeholderów i tekstu zobacz [Set Prompt Text in Placeholder](/slides/pl/python-java/manage-placeholder/) oraz [Text Formatting](/slides/pl/python-java/text-formatting/).

## **Zmień tło master slajdu**

Tło mastera jest dziedziczone przez layouty i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego master slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Powiązane tematy: [Presentation Background](/slides/pl/python-java/presentation-background/) oraz [Presentation Theme](/slides/pl/python-java/presentation-theme/).

## **Sklonuj master slajd do innej prezentacji**

Użyj [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/#addClone), aby skopiować master slajd do innej prezentacji. Skopiowany master może następnie być używany przez layouty i slajdy w docelowej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Jeśli potrzebujesz sklonować zwykłe slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/python-java/clone-slides/).

## **Dodaj wiele master slajdów**

Prezentacja może zawierać wiele master slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych brandingów, struktury stron lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania master slajdami](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy layout pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym layoucie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Porównaj master slajdy**

Master slajdy można porównać metodą [equals](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#equals) odziedziczoną po [BaseSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości placeholderów, takich jak bieżąca data.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Po więcej informacji zobacz [Compare Presentation Slides](/slides/pl/python-java/compare-slides/).

## **Ustaw widok master slajdu jako domyślny widok**

Użyj metody [setLastView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setLastView) na [ViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Slide Master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Po więcej ustawień widoku zobacz [Save Presentation](/slides/pl/python-java/save-presentation/).

## **Usuń nieużywane master slajdy**

Prezentacje czasami zawierają master slajdy, które nie są już używane przez żadne zwykłe slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj [removeUnused](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/#removeUnused), aby usunąć nieużywane master slajdy z kolekcji [Presentation.getMasters](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Możesz także użyć niskokodowej metody [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jaka jest różnica między master slajdem a layout slajdem?**

Master slajd definiuje współdzielone ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Layout slajd należy do master slajdu i definiuje konkretne rozmieszczenie placeholderów. Zwykły slajd używa layout slajdu, więc dziedziczy zarówno z layoutu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka master slajdów?**

Tak. Prezentacja może zawierać kilka master slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

**Czy powinienem dodawać placeholdery do master slajdu czy do layout slajdu?**

W większości przypadków dodawaj placeholdery do layout slajdów. Umieść wspólne elementy wizualne i wspólne formatowanie na master slajdzie, a placeholdery treści na layoutach, które będą używane przez zwykłe slajdy.

**Czy mogę usunąć master slajd, który jest nadal używany?**

Nie. Master slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do layoutów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko mastery nie będące w użyciu.