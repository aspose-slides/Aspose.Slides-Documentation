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
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint SmartArt mit Aspose.Slides für Python via .NET erstellen und bearbeiten, mithilfe klarer Codebeispiele, die das Entwerfen und Automatisieren von Folien beschleunigen."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie Sie SmartArt in Aspose.Slides für Python erstellen und manipulieren. Sie lernen, wie Sie Text aus SmartArt extrahieren (einschließlich des Inhalts von [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) in Knotenformen), SmartArt zu Folien hinzufügen und sein Layout wechseln, versteckte Knoten erkennen und behandeln, Layouts für Organisationsdiagramme konfigurieren und Bild-Organisationsdiagramme erstellen – alles mit prägnanten, per Kopieren‑Einfügen nutzbaren Python‑Beispielen, die eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) öffnen, mit Folien und SmartArt‑Knoten arbeiten und die Ergebnisse als PPTX speichern.

## **Text aus SmartArt erhalten**

Die `text_frame`‑Eigenschaft von [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) ermöglicht es Ihnen, den gesamten Text aus einer SmartArt‑Form abzurufen – nicht nur den Text, der in ihren Knoten enthalten ist. Der folgende Beispielcode zeigt, wie man Text aus einem SmartArt‑Knoten erhält.

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

## **SmartArt-Layouttyp ändern**

Um den SmartArt‑Layouttyp zu ändern, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
2. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.
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

Die Eigenschaft `SmartArtNode.is_hidden` liefert `True`, wenn der Knoten im Datenmodell ausgeblendet ist. Um zu prüfen, ob ein SmartArt‑Knoten ausgeblendet ist, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
2. Fügen Sie eine SmartArt‑Form mit dem Layout `RADIAL_CYCLE` hinzu.
3. Fügen Sie der SmartArt einen Knoten hinzu.
4. Prüfen Sie die Eigenschaft `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge eine SmartArt-Form mit dem Layout RADIAL_CYCLE hinzu.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Füge der SmartArt einen Knoten hinzu.
    node = smart.all_nodes.add_node()

    # Prüfe die Eigenschaft is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Organisationsdiagrammtyp abrufen oder festlegen**

Die Eigenschaft `SmartArtNode.organization_chart_layout` ruft den mit dem aktuellen Knoten verbundenen Organisationsdiagrammtyp ab oder legt ihn fest. Um den Organisationsdiagrammtyp abzurufen oder festzulegen, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
2. Fügen Sie der Folie eine SmartArt-Form hinzu.
3. Rufen Sie den Organisationsdiagrammtyp ab oder legen Sie ihn fest.
4. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge eine SmartArt-Form mit dem Layout ORGANIZATION_CHART hinzu.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Setze den Organisationsdiagrammtyp.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Speichere die Präsentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Bild-Organisationsdiagramm erstellen**

Aspose.Slides für Python stellt eine einfache API zum einfachen Erstellen von Bild-Organisationsdiagrammen bereit. Um ein Diagramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
2. Holen Sie sich eine Referenz zur Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten des gewünschten Typs hinzu.
4. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL-Sprachen?**

Ja. Die [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/)‑Eigenschaft ändert die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren, dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Formen‑Sammlung [clone the SmartArt shape](/slides/de/python-net/shape-manipulations/) ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) klonen oder die gesamte Folie, die diese Form enthält, [clone the entire slide](/slides/de/python-net/clone-slides/) duplizieren. Beide Ansätze erhalten Größe, Position und Stil.

**Wie kann ich SmartArt zu einem Rasterbild für Vorschau oder Web-Export rendern?**

[Render the slide](/slides/de/python-net/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Vorgehensweise ist die Verwendung von [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt‑Text) oder einem [name](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) und das Suchen nach der Form anhand dieses Attributs innerhalb von [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), dann den Typ prüfen, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.