---
title: Zarządzaj Zoomami w prezentacjach przy użyciu Pythona
linktitle: Powiększenie
type: docs
weight: 60
url: /pl/python-net/manage-zoom/
keywords:
- powiększenie
- ramka zoomu
- zoom slajdu
- zoom sekcji
- zoom podsumowujący
- dodaj zoom
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj Zoom przy użyciu Aspose.Slides dla Pythona via .NET — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Zoomy w programie PowerPoint pozwalają przeskakiwać do i z określonych slajdów, sekcji i fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po treści może okazać się bardzo przydatna.

![przegląd](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Summary Zoom](#Summary-Zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Slide Zoom](#Slide-Zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Section Zoom](#Section-Zoom).

## **Zoom slajdu**

Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, pozwalając na swobodne nawigowanie między slajdami w dowolnej kolejności bez przerywania płynności prezentacji. Zoomy slajdów są świetne dla krótkich prezentacji bez wielu sekcji, ale nadal możesz ich używać w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębić się w wiele informacji, jednocześnie dając wrażenie pracy na jednej płaszczyźnie.

![wybór zoomu slajdu](slidezoomsel.png)

Dla obiektów zoomu slajdu, Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/zoomimagetype/) , klasę [ZoomFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/zoomframe/) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/) .

### **Tworzenie ramek Zoom**

Możesz dodać ramkę zoomu na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowe slajdy, do których chcesz odwoływać się.
3.	Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4.	Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Dodaj nowe slajdy do prezentacji
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Utwórz tło dla drugiego slajdu
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Utwórz pole tekstowe dla drugiego slajdu
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Utwórz tło dla trzeciego slajdu
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Utwórz pole tekstowe dla trzeciego slajdu
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Dodaj obiekty ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Zapisz prezentację
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Tworzenie ramek Zoom z własnymi obrazami**

Z Aspose.Slides for Python via .NET możesz utworzyć ramkę zoomu z obrazem innym niż podglądowy obraz slajdu w następujący sposób:

1.	Utwórz instancję klasy `Presentation` .
2.	Utwórz nowy slajd, do którego chcesz odwoływać się.
3.	Dodaj tekst identyfikacyjny i tło do utworzonego slajdu.
4.	Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) , dodając obraz do kolekcji Images powiązanej z obiektem Presentation, który będzie użyty do wypełnienia ramki.
5.	Dodaj ramki zoomu (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Dodaj nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Utwórz tło dla drugiego slajdu
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Utwórz pole tekstowe dla trzeciego slajdu
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Utwórz nowy obraz dla obiektu zoomu
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Dodaj obiekt ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Zapisz prezentację
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatowanie ramek Zoom**

W poprzednich sekcjach (powyżej) pokazaliśmy, jak tworzyć proste ramki zoomu. Aby tworzyć bardziej skomplikowane ramki zoomu, należy zmienić ich formatowanie. Istnieje kilka ustawień formatowania, które można zastosować do ramki zoomu.

Możesz kontrolować formatowanie ramki zoomu na slajdzie w następujący sposób:

1.	Utwórz instancję klasy `Presentation` .
2.	Utwórz nowe slajdy, do których chcesz odwoływać się.
3.	Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4.	Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) , dodając obraz do kolekcji Images powiązanej z obiektem Presentation, który będzie użyty do wypełnienia ramki.
6.	Ustaw własny obraz dla pierwszego obiektu ramki zoomu.
7.	Zmień format linii dla drugiego obiektu ramki zoomu.
8.	Usuń tło z obrazu drugiego obiektu ramki zoomu.
5.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Dodaj nowe slajdy do prezentacji
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Utwórz tło dla drugiego slajdu
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Utwórz pole tekstowe dla drugiego slajdu
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Utwórz tło dla trzeciego slajdu
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Utwórz pole tekstowe dla trzeciego slajdu
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Dodaj obiekty ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Utwórz nowy obraz dla obiektu zoomu
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Ustaw własny obraz dla obiektu zoomFrame1
    zoomFrame1.image = image

    # Ustaw format ramki zoomu dla obiektu zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Nie wyświetlaj tła dla obiektu zoomFrame2
    zoomFrame2.show_background = False

    # Zapisz prezentację
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom sekcji**

Zoom sekcji jest odnośnikiem do sekcji w Twojej prezentacji. Możesz używać zoomów sekcji, aby wracać do sekcji, które chcesz szczególnie podkreślić. Możesz także używać ich, aby uwidocznić, jak poszczególne elementy prezentacji ze sobą powiązane.

![wybór zoomu sekcji](seczoomsel.png)

Dla obiektów zoomu sekcji, Aspose.Slides udostępnia klasę [SectionZoomFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectionzoomframe/) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/) .

### **Tworzenie ramek Zoom sekcji**

Możesz dodać ramkę zoomu sekcji do slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której chcesz odwołać ramkę zoomu.
5.	Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 1", slide)

    # Dodaje obiekt SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Zapisuje prezentację
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Tworzenie ramek Zoom sekcji z własnymi obrazami**

Używając Aspose.Slides for Python, możesz utworzyć ramkę zoomu sekcji z innym obrazem podglądu slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której chcesz odwołać ramkę zoomu.
5.	Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) , dodając obraz do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) , który będzie użyty do wypełnienia ramki.
6.	Dodaj ramkę zoomu sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
7.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 1", slide)

    # Tworzy nowy obraz dla obiektu zoomu
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Dodaje obiekt SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Zapisuje prezentację
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatowanie ramek Zoom sekcji**

Aby tworzyć bardziej skomplikowane ramki zoomu sekcji, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które można zastosować do ramki zoomu sekcji.

Możesz kontrolować formatowanie ramki zoomu sekcji na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której chcesz odwołać ramkę zoomu.
5.	Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zmień rozmiar i pozycję dla utworzonego obiektu zoomu sekcji.
7.	Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) , dodając obraz do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) , który będzie użyty do wypełnienia ramki.
8.	Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
9.	Ustaw możliwość *powrotu do pierwotnego slajdu z połączonej sekcji*.
10.	Usuń tło z obrazu obiektu ramki zoomu sekcji.
11.	Zmień format linii dla drugiego obiektu ramki zoomu.
12.	Zmień czas trwania przejścia.
13.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 1", slide)

    # Dodaje obiekt SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatowanie dla SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Zapisuje prezentację
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom podsumowujący**

Zoom podsumowujący jest jak strona docelowa, na której wszystkie elementy prezentacji są wyświetlane jednocześnie. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca w prezentacji do innego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu slajdów bez przerywania płynności prezentacji.

![przegląd obrazu](summaryzoom.png)

Dla obiektów zoomu podsumowującego, Aspose.Slides udostępnia klasy [SummaryZoomFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/summaryzoomsection/) oraz [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/summaryzoomsectioncollection/) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/) .

### **Tworzenie Zoomu podsumowującego**

Możesz dodać ramkę zoomu podsumowującego do slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowe slajdy z tłem identyfikacyjnym oraz nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Create slides array
    for slideNumber in range(5):
        #Add new slides to presentation
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Create a background for the slide
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Create a text box for the slide
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Create zoom objects for all slides in the first slide
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Set the ReturnToParent property to return to the first slide
        zoomFrame.return_to_parent = True

    # Save the presentation
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Dodawanie i usuwanie sekcji Zoomu podsumowującego**

Wszystkie sekcje w ramce zoomu podsumowującego są reprezentowane przez obiekty [SummaryZoomSection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/summaryzoomsection/) , które są przechowywane w obiekcie [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/summaryzoomsectioncollection/) . Możesz dodać lub usunąć obiekt sekcji zoomu podsumowującego za pomocą klasy [SummaryZoomSectionCollection] w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowe slajdy z tłem identyfikacyjnym oraz nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4.	Dodaj nowy slajd i sekcję do prezentacji.
5.	Dodaj utworzoną sekcję do ramki zoomu podsumowującego.
6.	Usuń pierwszą sekcję z ramki zoomu podsumowującego.
7.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 1", slide)

    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 2", slide)

    # Dodaje obiekt SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Dodaje nową sekcję do prezentacji
    section3 = pres.sections.add_section("Section 3", slide)

    # Dodaje sekcję do Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Usuwa sekcję z Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Zapisuje prezentację
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatowanie sekcji Zoomu podsumowującego**

Aby tworzyć bardziej skomplikowane obiekty sekcji zoomu podsumowującego, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które można zastosować do obiektu sekcji zoomu podsumowującego.

Możesz kontrolować formatowanie obiektu sekcji zoomu podsumowującego w ramce zoomu podsumowującego w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2.	Utwórz nowe slajdy z tłem identyfikacyjnym oraz nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4.	Pobierz obiekt sekcji zoomu podsumowującego dla pierwszego obiektu z `SummaryZoomSectionCollection` .
5.	Utwórz obiekt `PPImage` , dodając obraz do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) , który będzie użyty do wypełnienia ramki.
6.	Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
7.	Ustaw możliwość *powrotu do pierwotnego slajdu z połączonej sekcji*.
8.	Zmień format linii dla drugiego obiektu ramki zoomu.
9.	Zmień czas trwania przejścia.
10.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 1", slide)

    #Dodaje nowy slajd do prezentacji
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Dodaje nową sekcję do prezentacji
    pres.sections.add_section("Section 2", slide)

    # Dodaje obiekt SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Pobiera pierwszy obiekt SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatowanie dla obiektu SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Zapisuje prezentację
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu „nadrzędnego” po wyświetleniu celu?**

Tak. Ramka [Zoom frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/zoomframe/) lub [section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectionzoomframe/) ma zachowanie `return_to_parent`, które po włączeniu odsyła widzów z powrotem do slajdu początkowego po odwiedzeniu docelowej treści.

**Czy mogę dostosować „szybkość” lub czas trwania przejścia Zoom?**

Tak. Zoom obsługuje ustawienie `transition_duration`, dzięki czemu możesz kontrolować, jak długo trwa animacja przeskoku.

**Czy istnieją limity liczby obiektów Zoom, które prezentacja może zawierać?**

Nie ma twardo określonego limitu API w dokumentacji. Praktyczne ograniczenia zależą od ogólnej złożoności prezentacji oraz wydajności odtwarzacza. Można dodać wiele ramek Zoom, ale warto zwrócić uwagę na rozmiar pliku i czas renderowania.