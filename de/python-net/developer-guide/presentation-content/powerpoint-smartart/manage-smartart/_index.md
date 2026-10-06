---
title: SmartArt in PowerPoint-Präsentationen mit Python verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- Ausgeblendete Eigenschaft
- Organisationsdiagramm
- Bild‑Organisations‑Diagramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Python über .NET erstellen und bearbeiten, anhand klarer Code‑Beispiele, die das Foliendesign und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides für Python über .NET können Sie SmartArt erstellen, Text aus seinen Knoten auslesen, das Layout ändern, versteckte Knoten inspizieren, Organisations‑Chart‑Layouts konfigurieren und Bild‑Organisations‑Charts erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um den Text aus den Knotformen zu lesen, iterieren Sie über [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), dann lesen Sie das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aus, das von [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) zurückgegeben wird.

Das Beispiel erfordert eine Präsentation mit mindestens einer Folie und einem SmartArt‑Objekt als erste Form auf dieser Folie. Es gibt jeden verfügbaren Text‑Frame in der Konsole aus.

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

## **Layout‑Typ eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout steuert, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`‑Wert, ändert es zu `BASIC_PROCESS` und speichert die Präsentation. Position und Größe, die an [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) übergeben werden, werden in Punkten gemessen. Setzen Sie [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/), um das Layout zu ändern.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Prüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur vorhanden sein, auch wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente darstellt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten ausgeblendet ist, und speichert das Diagramm.

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

## **Organisations‑Chart‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisations‑Chart‑Layout verwenden, definiert [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/), wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Beispielsweise können Sie untergeordnete Knoten nach links, rechts oder an beiden Seiten hängen lassen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisations‑Chart und legt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`‑Wert fest. Der nullbasierte Index `0` wählt den ersten Knoten der obersten Ebene aus; seine untergeordneten Knoten verwenden die gewählte Anordnung. Die geänderte Präsentation wird dann gespeichert.

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

## **Bild‑Organisations‑Chart erstellen**

Ein Bild‑Organisations‑Chart ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bildplatzhaltern entwickelt wurde. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`‑Wert, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen. Dieses Beispiel speichert ein Diagramm mit Bildplatzhaltern; es füllt die Platzhalter nicht mit Bildern.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Legacy‑Diagramme in Gruppen von Formen konvertieren**

Beim Modernisieren einer vorhandenen Präsentation müssen Sie möglicherweise ein Organisations‑Chart aktualisieren, das ursprünglich in PowerPoint 97–2003 erstellt wurde. Aspose.Slides stellt diese Legacy‑Diagramme als [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/), um ein Diagramm in eine Gruppe von Formen zu konvertieren, sodass Sie einzelne visuelle Elemente bearbeiten können. Details finden Sie in der [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/).

Die Konvertierung fügt der Form‑Sammlung eine neue Gruppe hinzu, ohne das ursprüngliche Diagramm zu entfernen. Nach erfolgreicher Konvertierung entfernen Sie das Original mit [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/), um doppelte Inhalte zu vermeiden. Sammeln Sie die Legacy‑Diagramme vor der Konvertierung in einer Liste, damit das Hinzufügen und Entfernen von Formen die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Gruppen von Formen und speichert die aktualisierte Präsentation als PPTX.

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

Die gespeicherte Präsentation enthält editierbare Gruppen von Formen anstelle der konvertierten Legacy‑Diagramme, ohne dass ursprüngliche Diagramme daneben verbleiben. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, z. B. deren Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/)‑Eigenschaft wechselt die Diagramm‑Richtung von links‑nach‑rechts zu rechts‑nach‑links oder zurück, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können [die SmartArt‑Form klonen](/slides/de/python-net/shape-manipulations/) mit [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) oder die gesamte Folie [klonen](/slides/de/python-net/clone-slides/), die die SmartArt enthält. Beide Ansätze erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Rendern Sie die Folie](/slides/de/python-net/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Setzen Sie einen eindeutigen [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/)‑ oder [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/)‑Wert auf die SmartArt‑Form, suchen Sie nach diesem Wert in [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) und prüfen Sie anschließend, ob die gefundene Form ein [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) ist.