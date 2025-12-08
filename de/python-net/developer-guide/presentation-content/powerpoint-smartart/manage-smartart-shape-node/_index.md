---
title: SmartArt-Formknoten in Präsentationen mit Python verwalten
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/python-net/manage-smartart-shape-node/
keywords:
- SmartArt-Knoten
- untergeordneter Knoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistant-Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT, PPTX und ODP mit Aspose.Slides für Python via .NET. Erhalten Sie klare Code-Beispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt-Knoten hinzufügen**
Aspose.Slides for Python via .NET stellt die einfachste API bereit, um SmartArt‑Formen auf einfachste Weise zu verwalten. Der folgende Beispielcode zeigt, wie ein Knoten und ein untergeordneter Knoten innerhalb einer SmartArt‑Form hinzugefügt werden können.

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Fügen Sie einen neuen Knoten zur NodeCollection der SmartArt‑Form hinzu und setzen Sie den Text im TextFrame.
- Fügen Sie nun einen untergeordneten Knoten zum neu hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
- Speichern Sie die Präsentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:

        # Prüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Hinzufügen eines neuen SmartArt-Knotens
            node1 = shape.all_nodes.add_node()
            # Text hinzufügen
            node1.text_frame.text = "Test"

            # Hinzufügen eines neuen untergeordneten Knotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
            new_node = node1.child_nodes.add_node()

            # Text hinzufügen
            new_node.text_frame.text = "New Node Added"

    # Präsentation speichern
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt-Knoten an bestimmter Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie untergeordnete Knoten, die zu jeweiligen Knoten einer SmartArt‑Form gehören, an einer bestimmten Position hinzugefügt werden.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Fügen Sie der angesprochenen Folie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
- Fügen Sie nun dem ausgewählten Knoten an Position 2 einen untergeordneten Knoten hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Erstellen einer Präsentationsinstanz
with slides.Presentation() as pres:
    # Zugriff auf die Präsentationsfolie
    slide = pres.slides[0]

    # SmartArt IShape hinzufügen
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Zugriff auf den SmartArt-Knoten mit Index 0
    node = smart.all_nodes[0]

    # Hinzufügen eines neuen untergeordneten Knotens an Position 2 im übergeordneten Knoten
    chNode = node.child_nodes.add_node_by_position(2)

    # Text hinzufügen
    chNode.text_frame.text = "Sample text Added"

    # Präsentation speichern
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Auf SmartArt‑Knoten zugreifen**
Der folgende Beispielcode hilft beim Zugriff auf Knoten innerhalb einer SmartArt‑Form. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Greifen Sie auf Informationen wie Position, Ebene und Text des SmartArt‑Knotens zu und zeigen Sie diese an.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Prüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Durchlaufen Sie alle Knoten innerhalb der SmartArt
            for i in range(len(shape.all_nodes)):
                # Zugriff auf den SmartArt‑Knoten mit Index i
                node = shape.all_nodes[i]

                # Ausgabe der SmartArt‑Knoten‑Parameter
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


## **Auf SmartArt‑untergeordneten Knoten zugreifen**
Der folgende Beispielcode hilft beim Zugriff auf die untergeordneten Knoten, die zu den jeweiligen Knoten einer SmartArt‑Form gehören.

- Erstellen Sie eine Instanz der PresentationEx‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArtEx.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Für jeden ausgewählten SmartArt‑Knoten der Form durchlaufen Sie alle untergeordneten Knoten des jeweiligen Knotens.
- Greifen Sie auf Informationen wie Position, Ebene und Text des untergeordneten Knotens zu und zeigen Sie diese an.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Prüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Durchlaufen Sie alle Knoten innerhalb der SmartArt
            for node0 in shape.all_nodes:
                # Durchlaufen der untergeordneten Knoten
                for j in range(len(node0.child_nodes)):
                    # Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
                    node = node0.child_nodes[j]

                    # Ausgabe der Parameter des SmartArt-untergeordneten Knotens
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```


## **Auf SmartArt‑untergeordneten Knoten an bestimmter Position zugreifen**
In diesem Beispiel lernen wir, wie man untergeordnete Knoten an einer bestimmten Position, die zu den jeweiligen Knoten einer SmartArt‑Form gehören, abruft.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Fügen Sie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
- Greifen Sie auf den Knoten mit Index 0 der angeforderten SmartArt‑Form zu.
- Greifen Sie nun mit der Methode GetNodeByPosition() auf den untergeordneten Knoten an Position 1 des angeforderten SmartArt‑Knotens zu.
- Greifen Sie auf Informationen wie Position, Ebene und Text des untergeordneten Knotens zu und zeigen Sie diese an.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Präsentation instanziieren
with slides.Presentation() as pres:
    # Zugriff auf die erste Folie
    slide = pres.slides[0]
    # Hinzufügen der SmartArt-Form auf der ersten Folie
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Zugriff auf den SmartArt-Knoten mit Index 0
    node = smart.all_nodes[0]
    # Zugriff auf den untergeordneten Knoten an Position 1 im übergeordneten Knoten
    position = 1
    chNode = node.child_nodes[position] 
    # Ausgabe der SmartArt-untergeordneten Knoten-Parameter
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```


## **SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form entfernt.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Prüfen Sie, ob die SmartArt mehr als 0 Knoten enthält.
- Wählen Sie den zu löschenden SmartArt‑Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mit der Methode RemoveNode() und speichern Sie die Präsentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Prüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Casten Sie die Form zu SmartArtEx
            if len(shape.all_nodes) > 0:
                # Zugriff auf den SmartArt-Knoten mit Index 0
                node = shape.all_nodes[0]

                # Entfernen des ausgewählten Knotens
                shape.all_nodes.remove_node(node)

    # Präsentation speichern
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt‑Knoten an bestimmter Position entfernen**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Wählen Sie den SmartArt‑Knoten mit Index 0 aus.
- Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten hat.
- Entfernen Sie nun den Knoten an Position 1 mit der Methode RemoveNodeByPosition().
- Speichern Sie die Präsentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Prüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Casten Sie die Form zu SmartArt
            if len(shape.all_nodes) > 0:
                # Zugriff auf den SmartArt-Knoten mit Index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Entfernen des untergeordneten Knotens an Position 1
                    node.child_nodes.remove_node(1)

    # Präsentation speichern
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Benutzerdefinierte Position für untergeordneten Knoten in SmartArt festlegen**
Aspose.Slides for Python via .NET unterstützt jetzt das Festlegen der X- und Y-Eigenschaften von SmartArtShape. Das nachstehende Code‑Snippet zeigt, wie benutzerdefinierte Position, Größe und Drehung von SmartArtShape gesetzt werden können. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt-Form an neue Position verschieben
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Breiten der SmartArt-Form ändern
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Höhe der SmartArt-Form ändern
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Drehung der SmartArt-Form ändern
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```


## **Assistant‑Knoten prüfen**
Im folgenden Beispielcode untersuchen wir, wie Assistant‑Knoten in der SmartArt‑Knoten‑Sammlung identifiziert und geändert werden können.

- Erstellen Sie eine Instanz der PresentationEx‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie die Referenz der zweiten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArtEx.
- Durchlaufen Sie alle Knoten der SmartArt‑Form und prüfen Sie, ob es sich um Assistant‑Knoten handelt.
- Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
- Speichern Sie die Präsentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Präsentationsinstanz erstellen
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Durchlaufen aller Formen in der ersten Folie
    for shape in pres.slides[0].shapes:
        # Prüfen, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Durchlaufen aller Knoten der SmartArt-Form
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Prüfen, ob der Knoten ein Assistent-Knoten ist
                if node.is_assistant:
                    # Setzen des Assistent-Knotens auf false und Umwandeln in normalen Knoten
                    node.is_assistant = False
    # Präsentation speichern
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Füllformat des Knotens festlegen**
Aspose.Slides for Python via .NET ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihrer Füllformate. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt und darauf zugegriffen wird und wie das Füllformat mit Aspose.Slides for Python via .NET gesetzt wird.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie eine SmartArt‑Form hinzu, indem Sie deren LayoutType festlegen.
- Setzen Sie das FillFormat für die Knoten der SmartArt‑Form.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Zugriff auf die Folie
    slide = presentation.slides[0]

    # Hinzufügen der SmartArt-Form und Knoten
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Festlegen der Füllfarbe des Knotens
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Präsentation speichern
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Miniaturansicht eines SmartArt‑untergeordneten Knotens erzeugen**
Entwickler können eine Miniaturansicht eines untergeordneten Knotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Instanziieren Sie die `Presentation`‑Klasse, die die PPTX‑Datei repräsentiert.
1. Fügen Sie SmartArt hinzu.
1. Holen Sie die Referenz eines Knotens über dessen Index
1. Erzeugen Sie das Miniaturbild.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt eine Miniaturansicht eines SmartArt‑untergeordneten Knotens.
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
with slides.Presentation() as presentation: 
    # SmartArt hinzufügen
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Referenz eines Knotens über dessen Index erhalten
    node = smart.nodes[1]

    # Miniaturbild erhalten
    with node.shapes[0].get_image() as bmp:
        # Miniaturbild speichern
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **FAQ**

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/python-net/shape-animation/) (Eintritt, Austritt, Betonung, Bewegungsbahnen) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?**

Weisen Sie ihm einen [alternativen Text](/reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) zu und suchen Sie danach. Durch das Festlegen eines eindeutigen AltText auf dem SmartArt können Sie es programmgesteuert finden, ohne sich auf interne Kennungen zu verlassen.

**Wird das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF erhalten bleiben?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF‑Exports](/slides/de/python-net/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschauen oder Berichte)?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate](/reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) oder in [SVG](/reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) rendern, um skalierbare Vektor‑Ausgaben zu erhalten, die sich für Miniaturansichten, Berichte oder den Webgebrauch eignen.