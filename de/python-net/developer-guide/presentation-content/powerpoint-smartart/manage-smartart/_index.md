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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via .NET PowerPoint‑SmartArt erstellen und bearbeiten – mit klaren Code‑Beispielen, die die Foliengestaltung und Automatisierung beschleunigen."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie man SmartArt in Aspose.Slides für Python erstellt und manipuliert. Sie lernen, wie Sie Text aus SmartArt extrahieren (einschließlich des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Inhalts innerhalb von Knotenk Formen), SmartArt zu Folien hinzufügen und dessen Layout wechseln, versteckte Knoten erkennen und behandeln, Layouts für Organisationsdiagramme konfigurieren und Bild‑Organisationsdiagramme erstellen – alles mit prägnanten, kopier‑ und einfügbaren Python‑Beispielen, die eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) öffnen, mit Folien und SmartArt‑Knoten arbeiten und die Ergebnisse als PPTX speichern.

## **Text aus SmartArt abrufen**

Die Eigenschaft `text_frame` von [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) ermöglicht das Abrufen des gesamten Textes einer SmartArt‑Form – nicht nur des Textes in ihren Knoten. Der folgende Beispielcode zeigt, wie Text aus einem SmartArt‑Knoten gelesen wird.

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

Um den SmartArt‑Layouttyp zu ändern, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Rufen Sie über den Index auf eine Folie zu.  
3. Fügen Sie eine SmartArt‑Form mit dem Layout `BASIC_BLOCK_LIST` hinzu.  
4. Ändern Sie ihr Layout zu `BASIC_PROCESS`.  
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

Die Eigenschaft `SmartArtNode.is_hidden` liefert `True`, wenn der Knoten im Datenmodell ausgeblendet ist. So prüfen Sie, ob ein SmartArt‑Knoten versteckt ist:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Fügen Sie eine SmartArt‑Form mit dem Layout `RADIAL_CYCLE` hinzu.  
3. Fügen Sie der SmartArt einen Knoten hinzu.  
4. Prüfen Sie die Eigenschaft `is_hidden`.

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

## **Organisationsdiagramm‑Typ abrufen oder festlegen**

Die Eigenschaft `SmartArtNode.organization_chart_layout` gibt den dem aktuellen Knoten zugeordneten Organisationsdiagramm‑Typ zurück oder legt ihn fest. So gehen Sie vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Fügen Sie der Folie eine SmartArt‑Form hinzu.  
3. Rufen Sie den Organisationsdiagramm‑Typ ab oder setzen Sie ihn.  
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

## **Bild‑Organisationsdiagramm erstellen**

Aspose.Slides für Python bietet eine einfache API zum unkomplizierten Erstellen von Bild‑Organisationsdiagrammen. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Greifen Sie über den Index auf die Folie zu.  
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

**Unterstützt SmartArt Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die Eigenschaft [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) wechselt die Diagramm‑Richtung (LTR/RTL), sofern der gewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt‑Form klonen](/slides/de/python-net/shape-manipulations/) über die Shapes‑Sammlung ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) oder die gesamte Folie, die diese Form enthält, [klonen](/slides/de/python-net/clone-slides/). Beide Verfahren erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**

[Rendern Sie die Folie](/slides/de/python-net/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder umwandelt – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt‑Objekt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Vorgehensweise ist, über [alternativen Text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt‑Text) oder einen [Namen](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) zu suchen: Durchsuchen Sie [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) nach dem Attribut, prüfen Sie anschließend, ob der Typ [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) ist. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Shapes.