---
title: SmartArt in PowerPoint‑Präsentationen mit Python verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/python-net/manage-smartart/
keywords:
- SmartArt
- Text aus SmartArt
- Layouttyp
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bild‑Organisationsdiagramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Python über .NET erstellen und bearbeiten, wobei klare Code‑Beispiele die Gestaltung und Automatisierung von Folien beschleunigen."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie Sie SmartArt in Aspose.Slides für Python erstellen und manipulieren. Sie lernen, wie Sie Text aus SmartArt extrahieren (einschließlich [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑Inhalt in Knotformen), SmartArt zu Folien hinzufügen und das Layout wechseln, versteckte Knoten erkennen und handhaben, Organisations‑Chart‑Layouts konfigurieren und Bild‑Organisations‑Charts erstellen — alles mit knappen, kopier‑und‑einfügbaren Python‑Beispielen, die eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) öffnen, mit Folien und SmartArt‑Knoten arbeiten und die Ergebnisse als PPTX speichern. 

## **Text aus SmartArt abrufen**

Die `text_frame`‑Eigenschaft des [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) ermöglicht das Abrufen des gesamten Textes aus einer SmartArt‑Form – nicht nur des Textes, der in ihren Knoten enthalten ist. Der folgende Beispielcode zeigt, wie man Text aus einem SmartArt‑Knoten erhält.
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.  
3. Fügen Sie eine SmartArt‑Form mit dem Layout `BASIC_BLOCK_LIST` hinzu.  
4. Ändern Sie ihr Layout zu `BASIC_PROCESS`.  
5. Speichern Sie die Präsentation als PPTX‑Datei.  
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge eine SmartArt-Form mit dem Layout BASIC_BLOCK_LIST hinzu.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Ändere den Layouttyp zu BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Speichere die Präsentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **Versteckte Eigenschaft von SmartArt prüfen**

Die `SmartArtNode.is_hidden`‑Eigenschaft gibt `True` zurück, wenn der Knoten im Datenmodell ausgeblendet ist. Um zu prüfen, ob ein SmartArt‑Knoten ausgeblendet ist, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Fügen Sie eine SmartArt‑Form mit dem Layout `RADIAL_CYCLE` hinzu.  
3. Fügen Sie der SmartArt einen Knoten hinzu.  
4. Prüfen Sie die `is_hidden`‑Eigenschaft.  
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge eine SmartArt-Form mit dem Layout RADIAL_CYCLE hinzu.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Füge einen Knoten zur SmartArt hinzu.
    node = smart.all_nodes.add_node()

    # Überprüfe die is_hidden-Eigenschaft.
    if node.is_hidden:
        print("The node is hidden.")
```


## **Organisation‑Diagrammtyp erhalten oder festlegen**

Die `SmartArtNode.organization_chart_layout`‑Eigenschaft liest oder schreibt den Organisations‑Chart‑Typ, der dem aktuellen Knoten zugeordnet ist. Um den Organisations‑Chart‑Typ zu erhalten oder festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Fügen Sie der Folie eine SmartArt‑Form hinzu.  
3. Lesen oder schreiben Sie den Organisations‑Chart‑Typ.  
4. Speichern Sie die Präsentation als PPTX‑Datei.  
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge eine SmartArt-Form mit dem Layout ORGANIZATION_CHART hinzu.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Setze den Organization-Chart-Typ.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Speichere die Präsentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **Bild‑Organisationsdiagramm erstellen**

Aspose.Slides für Python bietet eine einfache API zum einfachen Erstellen von Bild‑Organisations‑Charts. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.  
3. Fügen Sie ein Diagramm mit den Standarddaten des gewünschten Typs hinzu.  
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

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL‑Sprachen?**

Ja. Die [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/)‑Eigenschaft schaltet die Diagramm‑richtung (LTR/RTL) um, falls der ausgewählte SmartArt‑Typ Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Formen‑Sammlung [clone the SmartArt shape](/slides/de/python-net/shape-manipulations/) ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) oder die gesamte Folie, die diese Form enthält, [clone the entire slide](/slides/de/python-net/clone-slides/) duplizieren. Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Render the slide](/slides/de/python-net/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis ist die Verwendung von [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt‑Text) oder eines [name](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) und das Suchen nach der Form anhand dieses Attributs innerhalb von [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), dann prüfen, ob der Typ [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) ist. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.