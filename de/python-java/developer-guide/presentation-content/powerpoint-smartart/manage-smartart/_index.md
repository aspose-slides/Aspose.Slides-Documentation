---
title: SmartArt in PowerPoint‑Präsentationen mit Python verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- ausgeblendete Eigenschaft
- Organisationsdiagramm
- Bild‑Organisationsdiagramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Python über Java erstellen und bearbeiten, anhand klarer Code‑Beispiele, die das Folien‑Design und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint-Diagramm, das aus Knoten, Knotenformen und einem Layout besteht. Mit Aspose.Slides für Python über Java können Sie SmartArt erstellen, Text aus dessen Knoten auslesen, das Layout ändern, versteckte Knoten prüfen, Organisationsdiagramm-Layouts konfigurieren und Bild-Organisationsdiagramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann eine oder mehrere Formen enthalten. Um Text aus den Knotenformen zu lesen, iterieren Sie durch [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), und lesen dann den [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) , der von [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) zurückgegeben wird.

Das Beispiel erfordert eine Präsentation mit mindestens einer Folie und ein SmartArt-Objekt als erste Form auf dieser Folie. Es gibt jeden verfügbaren TextFrame in der Konsole aus.

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

## **Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt-Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/)‑Wert `BasicBlockList`, ändert ihn auf den Wert `BasicProcess` und speichert die Präsentation. Die an [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) übergebenen Position und Größe werden in Punkten gemessen. Verwenden Sie [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout), um das Layout zu ändern.

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

## **Prüfen, ob ein SmartArt-Knoten ausgeblendet ist**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) gibt an, ob der Knoten im SmartArt-Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur vorhanden sein, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente darstellt.

Das folgende Beispiel fügt einem SmartArt-Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/)‑Wert `RadialCycle` verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten ausgeblendet ist, und speichert das Diagramm.

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

## **Organisationsdiagramm-Layout abrufen oder festlegen**

Für SmartArt-Diagramme, die ein Organisationsdiagramm-Layout verwenden, definieren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) und [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout), wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Sie können beispielsweise untergeordnete Knoten links, rechts oder an beiden Seiten hängen lassen, je nach dem ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisationsdiagramm und setzt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/)‑Wert `LeftHanging`. Der nullbasierte Index `0` wählt den ersten Knoten der obersten Ebene aus; seine untergeordneten Knoten verwenden die ausgewählte Anordnung. Die geänderte Präsentation wird anschließend gespeichert.

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

## **Ein Bild-Organisationsdiagramm erstellen**

Ein Bild-Organisationsdiagramm ist ein SmartArt-Layout, das für Hierarchiediagramme mit Bild-Platzhaltern konzipiert ist. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/)‑Wert `PictureOrganizationChart`, wenn Sie das SmartArt-Objekt zu einer Folie hinzufügen. Dieses Beispiel speichert ein Diagramm mit Bild-Platzhaltern; es füllt die Platzhalter nicht mit Bildern.

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

## **Legacy-Diagramme in Gruppen von Formen konvertieren**

Beim Modernisieren einer bestehenden Präsentation müssen Sie möglicherweise ein Organisationsdiagramm aktualisieren, das ursprünglich in PowerPoint 97–2003 erstellt wurde. Aspose.Slides stellt diese Legacy-Diagramme als [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape), um ein Diagramm in eine Gruppe von Formen zu konvertieren, sodass Sie einzelne Bildelemente bearbeiten können. Weitere Details finden Sie in der [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/).

Die Konvertierung fügt der Formensammlung eine neue Gruppe hinzu, ohne das ursprüngliche Diagramm zu entfernen. Nach erfolgreicher Konvertierung entfernen Sie das Original mit [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove), um doppelte Inhalte zu vermeiden. Sammeln Sie die Legacy-Diagramme in einer Liste, bevor Sie sie konvertieren, damit das Hinzufügen und Entfernen von Formen die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Gruppen von Formen und speichert die aktualisierte Präsentation als PPTX.

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

Die gespeicherte Präsentation enthält bearbeitbare Gruppen von Formen anstelle der konvertierten Legacy-Diagramme, wobei keine Originaldiagramme mehr daneben vorhanden sind. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, z. B. deren Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die Methode [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) ändert die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder zurück, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt-Form](/slides/de/python-java/shape-manipulations/) mit [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) klonen oder die [die gesamte Folie klonen](/slides/de/python-java/clone-slides/) die die SmartArt enthält. Beide Ansätze bewahren Größe, Position und Formatierung.

**Wie render ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Die Folie rendern](/slides/de/python-java/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt-Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Verwenden Sie [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) oder [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName), um dem SmartArt-Shape einen eindeutigen Alternativtext oder Namen zuzuweisen, suchen Sie nach diesem Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) und prüfen Sie anschließend, ob die passende Form ein [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) ist.