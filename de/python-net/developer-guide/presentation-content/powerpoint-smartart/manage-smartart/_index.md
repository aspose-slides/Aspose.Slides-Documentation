---
title: SmartArt in PowerPoint‑Präsentationen mit Python verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/python-net/developer-guide/presentation-content/powerpoint-smartart/manage-smartart/
keywords:
- SmartArt
- Text aus SmartArt
- Layouttyp
- ausgeblendete Eigenschaft
- Organigramm
- Bild‑Organigramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Python via .NET erstellen und bearbeiten, anhand klarer Code‑Beispiele, die das Entwerfen und Automatisieren von Folien beschleunigen."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie Sie SmartArt in Aspose.Slides für Python erstellen und manipulieren. Sie lernen, wie Sie Text aus SmartArt extrahieren (einschließlich des Inhalts von [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) in Knoten‑Shapes), SmartArt zu Folien hinzufügen und das Layout wechseln, ausgeblendete Knoten erkennen und verarbeiten, Layouts für Organigramme konfigurieren und Bild‑Organigramme erstellen – alles mit knappen, kopier‑und‑einfügbaren Python‑Beispielen, die eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) öffnen, mit Folien und SmartArt‑Knoten arbeiten und die Ergebnisse als PPTX speichern.

## **Text aus SmartArt erhalten**

Die Eigenschaft `text_frame` von [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) ermöglicht das Abrufen des gesamten Textes aus einer SmartArt‑Shape – nicht nur des Textes, der in ihren Knoten enthalten ist. Der folgende Beispielcode zeigt, wie man Text aus einem SmartArt‑Knoten erhält.

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **SmartArt‑Layouttyp ändern**

Um den SmartArt‑Layouttyp zu ändern, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Indexes.
1. Fügen Sie eine SmartArt‑Shape mit dem Layout `BASIC_BLOCK_LIST` hinzu.
1. Ändern Sie ihr Layout zu `BASIC_PROCESS`.
1. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the BASIC_BLOCK_LIST layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Change the layout type to BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Save the presentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Die ausgeblendete Eigenschaft von SmartArt prüfen**

Die Eigenschaft `SmartArtNode.is_hidden` gibt `True` zurück, wenn der Knoten im Datenmodell ausgeblendet ist. Um zu prüfen, ob ein SmartArt‑Knoten ausgeblendet ist, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Fügen Sie eine SmartArt‑Shape mit dem Layout `RADIAL_CYCLE` hinzu.
1. Fügen Sie der SmartArt einen Knoten hinzu.
1. Prüfen Sie die Eigenschaft `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the RADIAL_CYCLE layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Add a node to the SmartArt.
    node = smart.all_nodes.add_node()

    # Check the is_hidden property.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Organigramm‑Typ abrufen oder festlegen**

Die Eigenschaft `SmartArtNode.organization_chart_layout` ruft den dem aktuellen Knoten zugeordneten Organigramm‑Typ ab oder legt ihn fest. Um den Organigramm‑Typ abzurufen oder festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Fügen Sie der Folie eine SmartArt‑Shape hinzu.
1. Rufen Sie den Organigramm‑Typ ab bzw. legen Sie ihn fest.
1. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the ORGANIZATION_CHART layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Set the organization chart type.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Save the presentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Bild‑Organigramm erstellen**

Aspose.Slides für Python bietet eine einfache API zum unkomplizierten Erstellen von Bild‑Organigrammen. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Indexes.
1. Fügen Sie ein Diagramm des gewünschten Typs mit Standarddaten hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL‑Sprachen?**

Ja. Die Eigenschaft [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) wechselt die Diagramm‑Richtung (LTR/RTL), sofern der ausgewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Shape über die Shapes‑Sammlung klonen ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) oder die gesamte Folie, die diese Shape enthält, klonen ([clone the entire slide](/slides/de/python-net/clone-slides/)). Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Raster‑Bild für eine Vorschau oder den Web‑Export?**

Rendern Sie die Folie ([Render the slide](/slides/de/python-net/convert-powerpoint-to-png/)) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt‑Objekt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Vorgehensweise ist die Verwendung von [alternativem Text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt‑Text) oder einem [Namen](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) und das Suchen nach der Shape anhand dieses Attributs innerhalb von [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um ein [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Auffinden und Arbeiten mit Shapes.