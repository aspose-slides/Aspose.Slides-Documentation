---
title: SmartArt in PowerPoint-Präsentationen mit Python verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Python via Java erstellen und bearbeiten, anhand klarer Code‑Beispiele, die das Folien‑Design und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotenformen und einem Layout besteht. Mit Aspose.Slides für Python über Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten untersuchen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [SmartArt.getAllNodes](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#getAllNodes), dann lesen Sie das [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) das von [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartshape/#getTextFrame) zurückgegeben wird.

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

## **Layout‑Typ eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑Wert, ändert ihn auf den Wert `BasicProcess` und speichert die Präsentation.

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

## **Überprüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#isHidden) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des Knotens.

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

## **Organisationsdiagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definieren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) und [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout), wie Kindknoten unter einem übergeordneten Knoten angeordnet werden. Beispielsweise können Sie Kindknoten so festlegen, dass sie links, rechts oder an beiden Seiten hängen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisationsdiagramm und legt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑Wert fest.

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

## **Ein Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bildplatzhaltern entwickelt wurde. Verwenden Sie beim Hinzufügen des SmartArt‑Objekts zu einer Folie den [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑Wert.

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

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die Methode [SmartArt.setReversed](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#setReversed) ändert die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder umgekehrt, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form mit [die SmartArt‑Form klonen](/slides/de/python-java/shape-manipulations/) über [ShapeCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addClone) oder die gesamte Folie, die die SmartArt enthält, mit [die gesamte Folie klonen](/slides/de/python-java/clone-slides/) klonen. Beide Ansätze bewahren Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

Rendert die Folie mit [die Folie rendern](/slides/de/python-java/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Legen Sie einen eindeutigen [Shape.getAlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getAlternativeText)‑ oder [Shape.getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getName)‑Wert auf der SmartArt‑Form fest, durchsuchen Sie danach diesen Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getShapes) und prüfen Sie anschließend, ob das gefundene Shape ein [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.