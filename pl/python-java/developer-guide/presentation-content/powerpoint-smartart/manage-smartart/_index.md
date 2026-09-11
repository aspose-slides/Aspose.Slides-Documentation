---
title: Zarządzaj SmartArt w prezentacjach PowerPoint przy użyciu Pythona
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/python-java/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- ukryta właściwość
- diagram organizacyjny
- diagram organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i edytować SmartArt w PowerPoint przy pomocy Aspose.Slides for Python via Java, korzystając z przejrzystych przykładów kodu przyspieszających projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint składający się z węzłów, kształtów węzłów oraz układu. Za pomocą Aspose.Slides for Python via Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać układ, przeglądać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć diagramy organizacyjne ze zdjęciami.

## **Pobierz tekst z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, przeiteruj metodą [SmartArt.getAllNodes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#getAllNodes), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) zwrócony przez [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Zmień typ układu obiektu SmartArt**

Układ SmartArt określa, w jaki sposób węzły są rozmieszczane i połączone. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sprawdź, czy węzeł SmartArt jest ukryty**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#isHidden) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt używającego wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` i sprawdza stan ukrycia węzła.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pobierz lub ustaw układ diagramu organizacyjnego**

W diagramach SmartArt wykorzystujących układ diagramu organizacyjnego, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) i [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) określają, jak węzły potomne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić, aby węzły potomne zwisały po lewej, prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/organizationchartlayouttype/).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utwórz diagram organizacyjny ze zdjęciem**

Diagram organizacyjny ze zdjęciem to układ SmartArt przeznaczony do diagramów hierarchicznych zawierających pola na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt do slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwrócenie dla języków RTL?**

Tak. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#setReversed) zmienia kierunek diagramu z lewej‑na‑prawą na prawą‑na‑lewą lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na tę samą slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [sklonować kształt SmartArt](/slides/pl/python-java/shape-manipulations/) za pomocą [ShapeCollection.addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addClone) lub [sklonować cały slajd](/slides/pl/python-java/clone-slides/) zawierający SmartArt. Obie metody zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu do sieci?**

[Renderuj slajd](/slides/pl/python-java/convert-powerpoint-to-png/) lub całą prezentację do formatu PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw unikalną wartość [Shape.getAlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText) lub [Shape.getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getName) dla kształtu SmartArt, wyszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getShapes) i sprawdź, czy pasujący kształt jest [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).