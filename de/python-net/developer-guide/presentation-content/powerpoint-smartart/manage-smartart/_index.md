---
title: SmartArt in PowerPoint-Präsentationen mit Python verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/python-net/manage-smartart/
keywords:
- SmartArt
- Text aus SmartArt
- Layouttyp
- Versteckte Eigenschaft
- Organigramm
- Bild-Organigramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-SmartArt mit Aspose.Slides für Python via .NET erstellen und bearbeiten, anhand klarer Codebeispiele, die die Foliengestaltung und Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides for Python via .NET können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten untersuchen, Layouts für Organigramme konfigurieren und Bild‑Organigramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [SmartArt.all_nodes](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartart/all_nodes/), dann lesen Sie den [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) zurückgegeben von [SmartArtShape.text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartshape/text_frame/).

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

## **Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`‑Wert, ändert es auf den `BASIC_PROCESS`‑Wert und speichert die Präsentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prüfen, ob ein SmartArt‑Knoten verborgen ist**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartnode/is_hidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell verborgen ist. Verborgene Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`‑Wert verwendet, einen Knoten hinzu und prüft den verborgenen Zustand des Knotens.

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

## **Organigramm-Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organigramm‑Layout verwenden, definiert [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) wie Kindknoten unter einem Elternknoten angeordnet werden. Beispielsweise können Sie Kindknoten links, rechts oder an beiden Seiten hängen lassen, je nach dem ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organigramm und legt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`‑Wert fest.

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

## **Ein Bild‑Organigramm erstellen**

Ein Bild‑Organigramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bildplatzhaltern entwickelt wurde. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`‑Wert, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Unterstützt SmartArt Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die [SmartArt.is_reversed](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartart/is_reversed/)‑Eigenschaft schaltet die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links um, oder zurück, wenn das ausgewählte SmartArt‑Layout eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form mit [ShapeCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_clone/) oder die gesamte Folie, die das SmartArt enthält, mit dem Klon‑Mechanismus für Folien duplizieren. Beide Ansätze bewahren Größe, Position und Formatierung.

**Wie render ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**

Rendern Sie die Folie oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird dabei als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Setzen Sie einen eindeutigen [Shape.alternative_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/alternative_text/)‑ oder [Shape.name](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/name/)‑Wert auf die SmartArt‑Form, suchen Sie diesen Wert in [Slide.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/shapes/), und prüfen Sie dann, dass die gefundene Form ein [SmartArt](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartart/) ist.