---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu Pythona
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/python-java/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- właściwość ukryta
- diagram organizacyjny
- diagram organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides dla Pythona via Java, korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt jest diagramem PowerPoint utworzonym z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides for Python via Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, przeglądać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć diagramy organizacyjne ze zdjęciami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj przez [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) zwrócony przez [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).  
Przykład wymaga prezentacji zawierającej co najmniej jeden slajd oraz obiekt SmartArt jako pierwszy kształt na tym slajdzie. Wypisuje każdą dostępną ramkę tekstową na konsolę.

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
## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczania i łączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia ją na wartość `BasicProcess` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) są mierzone w punktach. Użyj [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout), aby zmienić układ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.  
Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`, i sprawdza ukryty stan dodanego węzła. Wypisuje komunikat, jeśli węzeł jest ukryty, i zapisuje diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Pobieranie lub ustawianie układu diagramu organizacyjnego**

Dla diagramów SmartArt wykorzystujących układ diagramu organizacyjnego, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) i [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) określają, w jaki sposób węzły potomne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły potomne, aby zwisały po lewej, prawej lub obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).  
Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Indeks zerowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły potomne używają wybranego rozmieszczenia. Zmodyfikowana prezentacja jest następnie zapisywana.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Utworzenie diagramu organizacyjnego ze zdjęciem**

Diagram organizacyjny ze zdjęciem jest układem SmartArt przeznaczonym dla diagramów hierarchii, które zawierają miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` podczas dodawania obiektu SmartArt do slajdu. Ten przykład zapisuje diagram z miejscami na obrazy; nie wypełnia tych miejsc obrazami.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Konwertowanie starszych diagramów na grupy kształtów**

Podczas modernizacji istniejącej prezentacji możesz potrzebować zaktualizować diagram organizacyjny pierwotnie utworzony w PowerPoint 97‑2003. Aspose.Slides reprezentuje te starsze diagramy jako obiekty [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Użyj [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape), aby przekształcić diagram w grupę kształtów, co umożliwia edycję poszczególnych elementów wizualnych. Zobacz [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) po szczegóły.  
Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania oryginalnego diagramu. Po pomyślnej konwersji usuń oryginał przy pomocy [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove), aby uniknąć duplikacji treści. Zbierz starsze diagramy na listę przed konwersją, aby dodawanie i usuwanie kształtów nie zakłócało iteracji.  
Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
Zapisana prezentacja zawiera edytowalne grupy kształtów zamiast skonwertowanych starszych diagramów, przy czym nie pozostają już żadne oryginalne diagramy. Otwórz plik PPTX w programie PowerPoint, aby edytować poszczególne elementy w każdej grupie, takie jak tekst, wypełnienie czy pozycję.

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwracanie dla języków RTL?**  
Tak. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) zmienia kierunek diagramu z lewej‑na‑prawą na prawą‑na‑lewą lub odwrotnie, gdy wybrany układ SmartArt wspiera odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**  
Możesz [sklonować kształt SmartArt](/slides/pl/python-java/shape-manipulations/) przy użyciu [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) lub [sklonować cały slajd](/slides/pl/python-java/clone-slides/), które zawiera SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu sieciowego?**  
[Wyrenderować slajd](/slides/pl/python-java/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**  
Użyj [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) lub [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName), aby przypisać unikalny tekst alternatywny lub nazwę do kształtu SmartArt, wyszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), a następnie sprawdź, czy pasujący kształt jest [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).