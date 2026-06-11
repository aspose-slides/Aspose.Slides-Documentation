---
title: Zarządzaj SmartArt w prezentacjach PowerPoint przy użyciu Pythona
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/python-net/manage-smartart/
keywords:
- SmartArt
- tekst ze SmartArt
- typ układu
- właściwość ukryta
- wykres organizacyjny
- wykres organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides for Python via .NET, korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt jest diagramem PowerPoint składającym się z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides for Python via .NET można tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, przeglądać ukryte węzły, konfigurować układy wykresów organizacyjnych oraz tworzyć wykresy organizacyjne ze zdjęciami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, iteruj przez [SmartArt.all_nodes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/all_nodes/), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) zwrócony przez [SmartArtShape.text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczenia i połączenia węzłów. W poniższym przykładzie tworzony jest obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, zmieniana jest na wartość `BASIC_PROCESS` i zapisywana jest prezentacja.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sprawdzenie, czy węzeł SmartArt jest ukryty**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartnode/is_hidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

W poniższym przykładzie dodawany jest węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`, i sprawdzany jest stan ukrycia węzła.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobieranie lub ustawianie układu wykresu organizacyjnego**

W diagramach SmartArt wykorzystujących układ wykresu organizacyjnego, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) definiuje sposób rozmieszczenia węzłów podrzędnych pod węzłem nadrzędnym. Na przykład można ustawić, aby węzły podrzędne wieszały po lewej, prawej lub obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/organizationchartlayouttype/).

W poniższym przykładzie tworzony jest wykres organizacyjny i ustawiany jest układ dla pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tworzenie wykresu organizacyjnego ze zdjęciem**

Wykres organizacyjny ze zdjęciem jest układem SmartArt przeznaczonym do diagramów hierarchicznych, które zawierają miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` podczas dodawania obiektu SmartArt na slajd.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy SmartArt obsługuje lustrzane odbicie lub odwrócenie dla języków RTL?**

Tak. Właściwość [SmartArt.is_reversed](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/is_reversed/) zmienia kierunek diagramu z lewej‑do‑prawej na prawą‑do‑lewej lub z powrotem, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Można [zklonować kształt SmartArt](/slides/pl/python-net/shape-manipulations/) za pomocą [ShapeCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_clone/) lub [zklonować cały slajd](/slides/pl/python-net/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, położenie i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu na stronę?**

[Renderuj slajd](/slides/pl/python-net/convert-powerpoint-to-png/) lub całą prezentację do formatu PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw unikalną wartość [Shape.alternative_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/alternative_text/) lub [Shape.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/name/) na kształcie SmartArt, przeszukaj tę wartość w [Slide.shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/shapes/), a następnie sprawdź, czy pasujący kształt jest [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/).