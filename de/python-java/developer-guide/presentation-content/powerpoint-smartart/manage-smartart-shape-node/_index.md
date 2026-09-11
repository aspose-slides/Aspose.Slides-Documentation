---
title: SmartArt‑Formknoten in Präsentationen mit Python verwalten
linktitle: SmartArt‑Formknoten
type: docs
weight: 30
url: /de/python-java/manage-smartart-shape-node/
keywords:
- SmartArt‑Knoten
- Unterknoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistent‑Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie SmartArt‑Formknoten in PPT und PPTX mit Aspose.Slides für Python via Java. Erhalten Sie klare Code‑Beispiele und Tipps, um Ihre Präsentationen zu optimieren."
---
## **Übersicht**

SmartArt‑Grafiken in PowerPoint‑Präsentationen werden über Knoten organisiert, die Text enthalten und die Struktur des Diagramms definieren. Aspose.Slides ermöglicht es, programmgesteuert mit diesen SmartArt‑Knoten zu arbeiten: neue Knoten und Unterknoten hinzuzufügen, Unterknoten an einer bestimmten Position einzufügen, vorhandene Knoten zuzugreifen und deren Text, Ebene und Position auszulesen.

Dieser Artikel erklärt, wie SmartArt‑Formknoten verwaltet werden. Er zeigt, wie Knoten entfernt werden, wie mit Unterknoten nach Index oder Position gearbeitet wird, wie ein Assistent‑Knoten in einen normalen Knoten umgewandelt wird, wie Position, Größe und Drehung von SmartArt‑Knoten‑Formen angepasst werden, wie Füllformate für Knoten festgelegt und wie ein Miniaturbild für einen SmartArt‑Unterknoten erzeugt wird.

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides für Python via Java stellt eine API zum Verwalten von SmartArt‑Formen bereit. Das folgende Beispiel fügt einer SmartArt‑Form einen Knoten und einen Unterknoten hinzu.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die eine SmartArt‑Form enthält.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form eine Instanz von [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.
1. [Neuen Knoten hinzufügen](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnodecollection/#addNode) zur [Knotensammlung](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#getAllNodes) der SmartArt‑Form und setzen Sie dessen Text über [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/).
1. [Hinzufügen](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnodecollection/#addNode) eines [Unterknotens](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#getChildNodes) zum neuen Knoten und setzen Sie dessen Text über [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/).
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Das folgende Beispiel fügt einem SmartArt‑Knoten einen Unterknoten an einer bestimmten Position hinzu.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Fügen Sie der Folie eine [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Form mit dem Layout [StackedList](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/#StackedList) hinzu.
1. Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
1. Fügen Sie dem ausgewählten Knoten mit [addNodeByPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) an Position 2 einen Unterknoten hinzu und setzen Sie dessen Text.
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zugriff auf einen SmartArt‑Knoten**
Das folgende Beispiel greift auf Knoten in einer SmartArt‑Form zu. Das durch [getLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#getLayout) zurückgegebene Layout ist schreibgeschützt und wird festgelegt, wenn die SmartArt‑Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die eine SmartArt‑Form enthält.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form eine Instanz von [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.
1. Durchlaufen Sie alle [Knoten](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#getAllNodes) in der SmartArt‑Form.
1. Lesen und geben Sie die Position, Ebene und den Text jedes SmartArt‑Knotens aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Zugriff auf einen SmartArt‑Unterknoten**
Das folgende Beispiel greift auf die Unterknoten jedes Knotens in einer SmartArt‑Form zu.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die eine SmartArt‑Form enthält.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form eine Instanz von [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.
1. Durchlaufen Sie alle [Knoten](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/#getAllNodes) in der SmartArt‑Form.
1. Für jeden Knoten durchlaufen Sie dessen [Unterknoten](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Lesen und geben Sie die Position, Ebene und den Text des [Unterknotens](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#getChildNodes) aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Zugriff auf einen SmartArt‑Unterknoten an einer bestimmten Position**
Das folgende Beispiel greift auf einen Unterknoten an einem bestimmten Index in der Sammlung seines übergeordneten Knotens zu.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Fügen Sie eine SmartArt‑Form mit dem Layout [StackedList](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/#StackedList) hinzu.
1. Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
1. Greifen Sie auf den Knoten mit Index 0 in der SmartArt‑Form zu.
1. Greifen Sie mit [get_Item](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnodecollection/#get_Item) auf den Unterknoten mit Index 1 zu.
1. Lesen und geben Sie die Position, Ebene und den Text des [Unterknotens](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#getChildNodes) aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt‑Knoten entfernen**
Das folgende Beispiel entfernt einen Knoten aus einer SmartArt‑Form.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die eine SmartArt‑Form enthält.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form eine Instanz von [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.
1. Stellen Sie sicher, dass die [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Form mindestens einen Knoten enthält.
1. Wählen Sie den zu löschenden SmartArt‑Knoten aus.
1. Entfernen Sie den ausgewählten Knoten mit [removeNode](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt‑Knoten an einer bestimmten Position entfernen**
Das folgende Beispiel entfernt einen Unterknoten an einem bestimmten Index in der Sammlung eines SmartArt‑Knotens.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die eine SmartArt‑Form enthält.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form eine Instanz von [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.
1. Greifen Sie, falls vorhanden, auf den SmartArt‑Knoten mit Index 0 zu.
1. Stellen Sie sicher, dass der ausgewählte SmartArt‑Knoten mindestens zwei Unterknoten hat.
1. Entfernen Sie den Unterknoten mit Index 1 mittels [removeNode](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Benutzerdefinierte Position für einen Unterknoten in einem SmartArt‑Objekt festlegen**
Aspose.Slides für Python via Java unterstützt das Festlegen der Position einer [SmartArtShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartshape/) über [setX](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setX) und [setY](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setY). Das folgende Beispiel legt eine benutzerdefinierte Position, Größe und Drehung für SmartArt‑Knoten‑Formen fest. Das Hinzufügen neuer Knoten berechnet die Positionen und Größen aller Knoten neu. Durch benutzerdefinierte Positionierung können Knoten nach Bedarf angeordnet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Assistent‑Knoten prüfen**
{{% alert color="info" title="Hinweis" %}} 

Dieser Abschnitt behandelt SmartArt‑Formen, die programmgesteuert zu Präsentationsfolien mithilfe von Aspose.Slides für Python via Java hinzugefügt werden.

{{% /alert %}} 

Die folgende Quell‑SmartArt‑Form wird in diesem Beispiel verwendet.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Ausgangs‑SmartArt‑Form auf einer Folie**|

Das folgende Beispiel identifiziert Assistent‑Knoten in einer SmartArt‑Knotensammlung und wandelt sie in normale Knoten um.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, die eine SmartArt‑Form enthält.
1. Rufen Sie die erste Folie anhand ihres Indexes ab.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form eine Instanz von [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) ist.
1. Durchlaufen Sie alle Knoten in der SmartArt‑Form und prüfen Sie, ob sie [Assistant Nodes](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#isAssistant) sind.
1. Ändern Sie jeden Assistent‑Knoten in einen normalen Knoten.
1. Speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Abbildung: Assistent‑Knoten in einer SmartArt‑Form auf einer Folie geändert**|

## **Füllformat eines Knotens festlegen**
Aspose.Slides für Python via Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihres Füllformats. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt und zugegriffen sowie ihr Füllformat mit Aspose.Slides für Python via Java festgelegt wird.

Bitte folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie eine Folie anhand ihres Indexes.
1. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)‑Form mit dem Layout [ClosedChevronProcess](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) hinzu.
1. Legen Sie das [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getFillFormat) für die Knoten der SmartArt‑Form fest.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Miniaturansicht eines SmartArt‑Unterknotens erzeugen**
Um eine Miniaturansicht eines SmartArt‑Unterknotens zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. [Fügen Sie eine SmartArt‑Form hinzu](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Holen Sie einen Knoten anhand seines Indexes.
1. Holen Sie das Miniaturbild.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/python-java/shape-animation/) (Eingang, Ausgang, Betonung, Bewegungspfad) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?**

Weisen Sie dem SmartArt einen eindeutigen **alternativen Text** zu und suchen Sie danach. Das Setzen eines unterscheidbaren alternativen Textes ermöglicht es, das SmartArt programmgesteuert zu finden, ohne interne Bezeichner zu verwenden.

**Wird das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF erhalten bleiben?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue beim [PDF‑Export](/slides/de/python-java/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschaubilder oder Berichte)?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate](/slides/de/python-java/aspose.slides/shape/#getImage) oder in [SVG](/slides/de/python-java/aspose.slides/shape/#writeAsSvgToBytes) rendern, um skalierbare Vektorausgaben zu erhalten, die sich für Miniaturansichten, Berichte oder Web‑Nutzung eignen.