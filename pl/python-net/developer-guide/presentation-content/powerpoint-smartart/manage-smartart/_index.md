---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu Pythona
linktitle: Zarządzanie SmartArt
type: docs
weight: 10
url: /pl/python-net/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- ukryta właściwość
- wykres organizacyjny
- wykres organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides dla Pythona via .NET, korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint składający się z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides for Python via .NET możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać układ, przeglądać ukryte węzły, konfigurować układy wykresów organizacyjnych i tworzyć wykresy organizacyjne z obrazami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj przez [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) zwrócony przez [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Przykład wymaga prezentacji zawierającej co najmniej jeden slajd i obiekt SmartArt jako pierwszy kształt na tym slajdzie. Wypisuje każdą dostępną ramkę tekstową w konsoli.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Zmienianie typu układu obiektu SmartArt**

Układ SmartArt kontroluje, jak węzły są rozmieszczane i połączone. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, zmienia go na wartość `BASIC_PROCESS` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) są mierzone w punktach. Ustaw [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/), aby zmienić układ.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`, i sprawdza stan ukrycia dodanego węzła. Wypisuje komunikat, jeśli węzeł jest ukryty, i zapisuje diagram.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobieranie lub ustawianie układu wykresu organizacyjnego**

Dla diagramów SmartArt wykorzystujących układ wykresu organizacyjnego, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) określa, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby zwisały z lewej, prawej lub obu stron, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Poniższy przykład tworzy wykres organizacyjny i ustawia układ dla pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. Indeks zerowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły podrzędne używają wybranego rozmieszczenia. Zmodyfikowana prezentacja jest następnie zapisywana.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Tworzenie wykresu organizacyjnego z obrazem**

Wykres organizacyjny z obrazem to układ SmartArt przeznaczony do diagramów hierarchicznych zawierających miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` podczas dodawania obiektu SmartArt do slajdu. Ten przykład zapisuje diagram z miejscami na obrazy; nie wypełnia ich jednak obrazami.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Konwertowanie diagramów Legacy na grupy kształtów**

Podczas modernizacji istniejącej prezentacji może być konieczna aktualizacja wykresu organizacyjnego pierwotnie stworzonego w PowerPoint 97–2003. Aspose.Slides przedstawia te starsze diagramy jako obiekty [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Użyj [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/), aby przekształcić diagram w grupę kształtów, co umożliwia edycję poszczególnych elementów wizualnych. Zobacz [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) po szczegóły.

Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania oryginalnego diagramu. Po udanej konwersji usuń oryginał przy pomocy [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/), aby uniknąć duplikacji treści. Zbierz diagramy legacy w listę przed konwersją, aby dodawanie i usuwanie kształtów nie zakłóciło iteracji.

Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Zapisana prezentacja zawiera edytowalne grupy kształtów zamiast skonwertowanych diagramów legacy, bez pozostawionych oryginalnych diagramów. Otwórz plik PPTX w PowerPoint, aby edytować poszczególne elementy w każdej grupie, takie jak tekst, wypełnienie czy położenie.

## **FAQ**

**Czy SmartArt obsługuje lustrzane odbicie lub odwrócenie dla języków RTL?**

Tak. Właściwość [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) zmienia kierunek diagramu z lewej‑do‑prawej na prawą‑do‑lewej, lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [clone the SmartArt shape](/slides/pl/python-net/shape-manipulations/) za pomocą [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) lub [clone the whole slide](/slides/pl/python-net/clone-slides/) zawierającego SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak renderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu na stronę internetową?**

[Render the slide](/slides/pl/python-net/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw charakterystyczną wartość [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) lub [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) na kształcie SmartArt, przeszukaj tę wartość w [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), a następnie sprawdź, czy pasujący kształt jest [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).