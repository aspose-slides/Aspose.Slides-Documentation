---
title: SmartArt-Formknoten verwalten
type: docs
weight: 30
url: /de/python-net/manage-smartart-shape-node/
keywords: "SmartArt-Knoten, SmartArt-Kindknoten, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Smart-Knoten und Kindknoten in PowerPoint-Präsentationen in Python"
---


## **SmartArt-Knoten hinzufügen**
Aspose.Slides für Python über .NET bietet die einfachste API zur Verwaltung der SmartArt-Formen auf die einfachste Weise. Der folgende Beispielcode hilft, Knoten und Kindknoten innerhalb der SmartArt-Form hinzuzufügen.

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, undTypcasten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.
- Fügen Sie einen neuen Knoten in die SmartArt-Form Knoten-Sammlung hinzu und setzen Sie den Text im Textfeld.
- Fügen Sie nun einen Kindknoten im neu hinzugefügten SmartArt-Knoten hinzu und setzen Sie den Text im Textfeld.
- Speichern Sie die Präsentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:

        # Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Hinzufügen eines neuen SmartArt-Knotens
            node1 = shape.all_nodes.add_node()
            # Text hinzufügen
            node1.text_frame.text = "Test"

            # Hinzufügen eines neuen Kindknotens im Elternknoten. Der Knoten wird am Ende der Sammlung hinzugefügt.
            new_node = node1.child_nodes.add_node()

            # Text hinzufügen
            new_node.text_frame.text = "Neuer Knoten hinzugefügt"

    # Speichern der Präsentation
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt-Knoten an spezifischer Position hinzufügen**
Im folgenden Beispielcode haben wir erklärt, wie man die Kindknoten, die zu entsprechenden Knoten der SmartArt-Form gehören, an einer bestimmten Position hinzufügt.

- Erstellen Sie eine Instanz der `Presentation` Klasse.
- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form vom Typ StackedList in die zugängliche Folie ein.
- Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt-Form zu.
- Fügen Sie nun den Kindknoten für den ausgewählten Knoten an Position 2 hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Erstellen einer Präsentationsinstanz
with slides.Presentation() as pres:
    # Zugriff auf die Präsentationsfolie
    slide = pres.slides[0]

    # Hinzufügen der SmartArt IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Zugriff auf den SmartArt-Knoten mit dem Index 0
    node = smart.all_nodes[0]

    # Hinzufügen eines neuen Kindknotens an Position 2 im Elternknoten
    chNode = node.child_nodes.add_node_by_position(2)

    # Text hinzufügen
    chNode.text_frame.text = "Beispieltext hinzugefügt"

    # Präsentation speichern
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **SmartArt-Knoten zugreifen**
Der folgende Beispielcode hilft, auf Knoten innerhalb der SmartArt-Form zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die SmartArt-Form hinzugefügt wird.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.

- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.

- Durchlaufen Sie jede Form auf der ersten Folie.

- Überprüfen Sie, ob die Form vom Typ SmartArt ist, undTypcasten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.

- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form.

- Greifen Sie auf Informationen wie Position, Ebene und Text des SmartArt-Knotens zu und zeigen Sie sie an.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Durchlaufen Sie alle Knoten innerhalb der SmartArt
            for i in range(len(shape.all_nodes)):
                # Zugriff auf den SmartArt-Knoten mit dem Index i
                node = shape.all_nodes[i]

                # Drucken der Parameter des SmartArt-Knotens
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **Zugriff auf SmartArt-Kindknoten**
Der folgende Beispielcode hilft, auf die Kindknoten zuzugreifen, die zu den jeweiligen Knoten der SmartArt-Form gehören.

- Erstellen Sie eine Instanz der PresentationEx-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, undTypcasten Sie die ausgewählte Form zu SmartArtEx, wenn es sich um SmartArt handelt.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form.
- Für jeden ausgewählten SmartArt-Formknoten durchlaufen Sie alle Kindknoten innerhalb des jeweiligen Knotens.
- Greifen Sie auf Informationen wie Position, Ebene und Text des Kindknotens zu und zeigen Sie sie an.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Durchlaufen Sie alle Knoten innerhalb der SmartArt
            for node0 in shape.all_nodes:
                # Durchlaufen der Kindknoten
                for j in range(len(node0.child_nodes)):
                    # Zugriff auf den Kindknoten im SmartArt-Knoten
                    node = node0.child_nodes[j]

                    # Drucken der Parameter des SmartArt-Kindknoten
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Zugriff auf SmartArt-Kindknoten an spezifischer Position**
In diesem Beispiel werden wir lernen, wie man auf die Kindknoten an einer bestimmten Position zugreift, die zu den jeweiligen Knoten der SmartArt-Form gehören.

- Erstellen Sie eine Instanz der `Presentation` Klasse.
- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt-Form zu.
- Greifen Sie auf den Knoten mit dem Index 0 für die abgerufene SmartArt-Form zu.
- Greifen Sie nun auf den Kindknoten an Position 1 für den abgerufenen SmartArt-Knoten zu, indem Sie die Methode GetNodeByPosition() verwenden.
- Greifen Sie auf Informationen wie Position, Ebene und Text des Kindknotens zu und zeigen Sie sie an.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanziieren der Präsentation
with slides.Presentation() as pres:
    # Zugriff auf die erste Folie
    slide = pres.slides[0]
    # Hinzufügen der SmartArt-Form auf der ersten Folie
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Zugriff auf den SmartArt-Knoten mit dem Index 0
    node = smart.all_nodes[0]
    # Zugriff auf den Kindknoten an Position 1 im Elternknoten
    position = 1
    chNode = node.child_nodes[position] 
    # Drucken der Parameter des SmartArt-Kindknotens
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **SmartArt-Knoten entfernen**
In diesem Beispiel werden wir lernen, wie man die Knoten innerhalb der SmartArt-Form entfernt.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, undTypcasten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.
- Überprüfen Sie, ob die SmartArt mehr als 0 Knoten hat.
- Wählen Sie den zu löschenden SmartArt-Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mit der Methode RemoveNode() und speichern Sie die Präsentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Typcasten der Form zu SmartArtEx
            if len(shape.all_nodes) > 0:
                # Zugriff auf den SmartArt-Knoten mit dem Index 0
                node = shape.all_nodes[0]

                # Entfernen des ausgewählten Knotens
                shape.all_nodes.remove_node(node)

    # Präsentation speichern
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt-Knoten an spezifischer Position entfernen**
In diesem Beispiel werden wir lernen, wie man die Knoten innerhalb der SmartArt-Form an einer bestimmten Position entfernt.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Holen Sie sich die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, undTypcasten Sie die ausgewählte Form zu SmartArt, wenn es sich um SmartArt handelt.
- Wählen Sie den SmartArt-Formknoten mit dem Index 0 aus.
- Überprüfen Sie nun, ob der ausgewählte SmartArt-Knoten mehr als 2 Kindknoten hat.
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
        # Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Typcasten der Form zu SmartArt
            if len(shape.all_nodes) > 0:
                # Zugriff auf den SmartArt-Knoten mit dem Index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Entfernen des Kindknotens an Position 1
                    node.child_nodes.remove_node(1)

    # Präsentation speichern
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Benutzerdefinierte Position für Kindknoten in SmartArt festlegen**
Jetzt unterstützt Aspose.Slides für Python über .NET das Festlegen der X- und Y-Eigenschaften von SmartArtShape. Der folgende Codeausschnitt zeigt, wie man die benutzerdefinierte Position, Größe und Rotation der SmartArt-Form festlegt. Please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laden Sie die gewünschte Präsentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Verschieben der SmartArt-Form zu neuer Position
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Ändern der Breiten der SmartArt-Form
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Ändern der Höhe der SmartArt-Form
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Ändern der Rotation der SmartArt-Form
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **Assistentenknoten überprüfen**
Im folgenden Beispielcode werden wir untersuchen, wie man Assistentenknoten in der SmartArt-Knotensammlung identifiziert und sie ändert.

- Erstellen Sie eine Instanz der PresentationEx-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Holen Sie sich die Referenz der zweiten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, undTypcasten Sie die ausgewählte Form zu SmartArtEx, wenn es sich um SmartArt handelt.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form und überprüfen Sie, ob es sich um Assistentenknoten handelt.
- Ändern Sie den Status des Assistentenknotens in einen normalen Knoten.
- Speichern Sie die Präsentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Erstellen einer Präsentationsinstanz
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Durchlaufen Sie jede Form auf der ersten Folie
    for shape in pres.slides[0].shapes:
        # Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Durchlaufen Sie alle Knoten der SmartArt-Form
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Überprüfen Sie, ob der Knoten ein Assistentenknoten ist
                if node.is_assistant:
                    # Setzen des Assistentenknotens auf falsch und ihn zu einem normalen Knoten machen
                    node.is_assistant = False
    # Präsentation speichern
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Füllformat des Knotens festlegen**
Aspose.Slides für Python über .NET macht es möglich, benutzerdefinierte SmartArt-Formen hinzuzufügen und deren Füllformate festzulegen. Dieser Artikel erklärt, wie man SmartArt-Formen erstellt und darauf zugreift und deren Füllformat mithilfe von Aspose.Slides für Python über .NET festlegt.

Bitte befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der `Presentation` Klasse.
- Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form hinzu, indem Sie ihren LayoutType festlegen.
- Setzen Sie das FillFormat für die SmartArt-Formknoten.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

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
    node.text_frame.text = "Einige Texte"

    # Festlegen der Knotenfüllfarbe
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Speichern der Präsentation
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Miniaturansicht des SmartArt-Kindknotens generieren**
Entwickler können eine Miniaturansicht des Kindknotens einer SmartArt generieren, indem sie die folgenden Schritte befolgen:

1. Instanziieren Sie die `Presentation` Klasse, die die PPTX-Datei darstellt.
1. Fügen Sie SmartArt hinzu.
1. Holen Sie sich die Referenz eines Knotens, indem Sie dessen Index verwenden.
1. Holen Sie sich das Miniaturansichtsbild.
1. Speichern Sie das Miniaturansichtsbild in einem beliebigen gewünschten Bildformat.

Das Beispiel unten generiert eine Miniaturansicht des Kindknotens der SmartArt:

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanziieren der Präsentation, die die PPTX-Datei darstellt 
with slides.Presentation() as presentation: 
    # SmartArt hinzufügen 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Holen Sie sich die Referenz eines Knotens, indem Sie dessen Index verwenden  
    node = smart.nodes[1]

    # Holen Sie sich die Miniaturansicht
    with node.shapes[0].get_image() as bmp:
        # Miniaturansicht speichern
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```