---
title: Manage SmartArt in PowerPoint Presentations Using Python
linktitle: Manage SmartArt
type: docs
weight: 10
url: /de/python-net/manage-smartart/
keywords:
- SmartArt
- text from SmartArt
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Python über .NET erstellen und bearbeiten, mithilfe klarer Code‑Beispiele, die das Folien‑Design und die Automatisierung beschleunigen."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie Sie SmartArt in Aspose.Slides für Python erstellen und manipulieren. Sie lernen, wie Sie Text aus SmartArt extrahieren (einschließlich [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Inhalts in Knotenformen), SmartArt zu Folien hinzufügen und das Layout wechseln, versteckte Knoten erkennen und behandeln, Organisation‑Diagramm‑Layouts konfigurieren und Bild‑Organisation‑Diagramme erstellen – alles mit kurzen, kopier‑und‑einfügbaren Python‑Beispielen, die eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) öffnen, mit Folien und SmartArt‑Knoten arbeiten und die Ergebnisse als PPTX speichern.

## **Text aus SmartArt abrufen**

Die `text_frame`‑Eigenschaft von [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) ermöglicht das Abrufen des gesamten Textes aus einer SmartArt‑Form – nicht nur des Textes in ihren Knoten. Der folgende Beispielcode zeigt, wie Text aus einem SmartArt‑Knoten gelesen wird.

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

Um den SmartArt‑Layouttyp zu ändern, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz auf eine Folie mittels ihres Index.  
3. Fügen Sie eine SmartArt‑Form mit dem Layout `BASIC_BLOCK_LIST` hinzu.  
4. Ändern Sie das Layout zu `BASIC_PROCESS`.  
5. Speichern Sie die Präsentation als PPTX‑Datei.

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

## **Versteckte Eigenschaft von SmartArt prüfen**

Die Eigenschaft `SmartArtNode.is_hidden` gibt `True` zurück, wenn der Knoten im Datenmodell versteckt ist. Um zu prüfen, ob ein SmartArt‑Knoten versteckt ist, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Fügen Sie eine SmartArt‑Form mit dem Layout `RADIAL_CYCLE` hinzu.  
3. Fügen Sie der SmartArt einen Knoten hinzu.  
4. Prüfen Sie die `is_hidden`‑Eigenschaft.

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

## **Organisation‑Diagrammtyp abrufen oder festlegen**

Die Eigenschaft `SmartArtNode.organization_chart_layout` liefert oder legt den Organisation‑Diagrammtyp des aktuellen Knotens fest. Um den Typ abzurufen oder zu setzen, führen Sie diese Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Fügen Sie der Folie eine SmartArt‑Form hinzu.  
3. Rufen Sie den Organisation‑Diagrammtyp ab oder setzen Sie ihn.  
4. Speichern Sie die Präsentation als PPTX‑Datei.

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

## **Bild‑Organisation‑Diagramm erstellen**

Aspose.Slides für Python bietet eine einfache API zum unkomplizierten Erstellen von Bild‑Organisation‑Diagrammen. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz auf die Folie mittels ihres Index.  
3. Fügen Sie ein Diagramm des gewünschten Typs mit Standarddaten hinzu.  
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die Eigenschaft [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) wechselt die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Formen‑Sammlung klonen ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) oder die gesamte Folie, die diese Form enthält, klonen. Beide Methoden erhalten Größe, Position und Stil.

**Wie rendern ich SmartArt zu einem Rasterbild für eine Vorschau oder den Web‑Export?**

Rendern Sie die Folie (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis ist die Verwendung von Alternativtext ([alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/)) oder eines Namens ([name](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/)) und die Suche nach der Form anhand dieses Attributs innerhalb von [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um ein [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) handelt.