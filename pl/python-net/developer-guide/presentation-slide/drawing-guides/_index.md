---
title: Zarządzanie liniami prowadzącymi w prezentacjach w Pythonie
linktitle: Linie prowadzące
type: docs
weight: 85
url: /pl/python-net/drawing-guides/
keywords:
- linia prowadząca
- linia pozioma
- linia pionowa
- linia wyrównania
- widok slajdu
- master slajd
- slajd układu
- master notatek
- master wersji rozdawniczej
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome i pionowe linie prowadzące w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Linie prowadzące to regulowane linie poziome i pionowe, które pomagają użytkownikom konsekwentnie wyrównywać kształty podczas edycji prezentacji w PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie dopracowywać: aplikacja może zapisać te same pomoce wyrównujące, których autorzy powinni się trzymać przy dodawaniu lub przemieszczaniu treści.

Linie prowadzące są pomocnikami edycji, a nie treścią slajdu. Nie pojawiają się podczas pokazu slajdów ani w wyjściu renderowanym. Aspose.Slides for Python via .NET udostępnia je za pośrednictwem interfejsu [IDrawingGuidesCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguidescollection/) . Linia prowadząca jest reprezentowana przez [IDrawingGuide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego narożnika odpowiedniego slajdu lub mastera. Pionowa linia prowadząca używa współrzędnej poziomej, zazwyczaj pomiędzy zerem a szerokością slajdu. Pozioma linia prowadząca używa współrzędnej pionowej, zazwyczaj pomiędzy zerem a wysokością slajdu.

## **Dodawanie linii prowadzących w widoku slajdu**

Użyj [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) aby zarządzać liniami prowadzącymi wyświetlanymi podczas edycji zwykłych slajdów. Wywołaj [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguidescollection/add/) z wartością [Orientation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową linię prowadzącą po prawej stronie środka slajdu oraz jedną poziomą linię prowadzącą poniżej niego:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do linii prowadzących**

Właściwość i indeksator [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguidescollection/count/) umożliwiają dostęp do istniejących linii prowadzących. Właściwości [IDrawingGuide.orientation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguide/position/) i [IDrawingGuide.color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguide/color/) mogą być odczytywane lub modyfikowane.

Poniższy przykład odczytuje linie prowadzące widoku slajdu z prezentacji utworzonej powyżej:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Dodawanie linii prowadzących do mastera i slajdów układu**

Master slajdu i każdy z jego slajdów układu mogą mieć własne kolekcje linii prowadzących. Użyj [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterslide/drawing_guides/) dla mastera slajdu oraz [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilayoutslide/drawing_guides/) dla slajdu układu.

Poniższy przykład dodaje pionową linię prowadzącą do pierwszego mastera slajdu i poziomą linię prowadzącą do pierwszego slajdu układu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie linii prowadzących do masterów notatek i wersji rozdawniczych**

Mastery notatek i mastery wersji rozdawniczych również obsługują linie prowadzące. Użyj [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasternotesslide/drawing_guides/) i [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych masterów, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) lub [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) tworzy domyślny master i zwraca go.

Poniższy przykład dodaje poziomą linię prowadzącą do mastera notatek i pionową linię prowadzącą do mastera wersji rozdawniczej:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Czyszczenie linii prowadzących**

Wywołaj [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/idrawingguidescollection/clear/) aby usunąć każdą linię prowadzącą z konkretnej kolekcji. Czyszczenie jednej kolekcji nie wpływa na linie prowadzące przechowywane w innym zakresie.

Poniższy przykład czyści linie prowadzące widoku slajdu oraz wszystkie linie prowadzące na masterach slajdów, slajdach układu, masterze notatek i masterze wersji rozdawniczej, nie tworząc brakujących masterów:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy linie prowadzące pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Linie prowadzące są pomocnikami wyrównania podczas edycji i nie są renderowane jako treść prezentacji.

**Czy linię prowadzącą można dodać bezpośrednio do pojedynczego normalnego slajdu?**

Linie prowadzące edycji normalnych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje linii prowadzących są dostępne dla masterów slajdów, slajdów układu, masterów notatek i masterów wersji rozdawniczych.

**Jakie jednostki są używane dla pozycji linii prowadzących?**

Pozycje podawane są w punktach, gdzie 72 punkty równa się jednemu calowi. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy czyszczenie linii prowadzących usuwa kształty lub zmienia treść slajdu?**

Nie. Metoda `clear` usuwa tylko linie prowadzące w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.