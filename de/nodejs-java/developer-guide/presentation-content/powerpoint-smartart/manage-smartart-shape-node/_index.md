---
title: PowerPoint SmartArt Shape-Knoten in JavaScript erstellen oder verwalten
linktitle: SmartArt Shape-Knoten verwalten
type: docs
weight: 30
url: /de/nodejs-java/manage-smartart-shape-node/
keywords: SmartArt PowerPoint, SmartArt-Knoten, SmartArt-Position, SmartArt entfernen, SmartArt-Knoten hinzufügen, PowerPoint-Präsentation, PowerPoint Java, PowerPoint JavaScript-API
description: SmartArt-Knoten und untergeordnete Knoten in PowerPoint-Präsentationen in JavaScript verwalten
---

## **SmartArt‑Knoten zur PowerPoint‑Präsentation mit JavaScript hinzufügen**
Aspose.Slides for Node.js via Java bietet die einfachste API, um SmartArt‑Objekte auf einfachste Weise zu verwalten. Der folgende Beispielcode zeigt, wie man einen Knoten und einen untergeordneten Knoten innerhalb eines SmartArt‑Objekts hinzufügt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) um, falls sie SmartArt ist.
5. Fügen Sie einen neuen Knoten in das SmartArt‑Objekt [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) ein und setzen Sie den Text im TextFrame.
6. Fügen Sie nun einen **untergeordneten Knoten** in den neu hinzugefügten SmartArt‑Knoten ein und setzen Sie den Text im TextFrame.
7. Speichern Sie die Präsentation.
```javascript
// Laden Sie die gewünschte Präsentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufen Sie jede Form auf der ersten Folie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Form zu SmartArt casten
            var smart = shape;
            // Einen neuen SmartArt-Knoten hinzufügen
            var TemNode = smart.getAllNodes().addNode();
            // Text hinzufügen
            TemNode.getTextFrame().setText("Test");
            // Neuen untergeordneten Knoten im übergeordneten Knoten hinzufügen. Er wird am Ende der Sammlung hinzugefügt
            var newNode = TemNode.getChildNodes().addNode();
            // Text hinzufügen
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Präsentation speichern
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie man die untergeordneten Knoten der jeweiligen SmartArt‑Knoten an einer bestimmten Position hinzufügt.

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Fügen Sie in der ausgewählten Folie ein SmartArt‑Objekt vom Typ [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) hinzu.
4. Greifen Sie auf den ersten Knoten des hinzugefügten SmartArt‑Objekts zu.
5. Fügen Sie nun den **untergeordneten Knoten** für den ausgewählten **Knoten** an Position 2 hinzu und setzen Sie dessen Text.
6. Speichern Sie die Präsentation.
```javascript
// Erstellen einer Präsentationsinstanz
var pres = new aspose.slides.Presentation();
try {
    // Auf die Präsentationsfolie zugreifen
    var slide = pres.getSlides().get_Item(0);
    // SmartArt-IShape hinzufügen
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Zugriff auf den SmartArt-Knoten bei Index 0
    var node = smart.getAllNodes().get_Item(0);
    // Neuen untergeordneten Knoten an Position 2 im übergeordneten Knoten hinzufügen
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Text hinzufügen
    chNode.getTextFrame().setText("Sample Text Added");
    // Präsentation speichern
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt‑Knoten in einer PowerPoint‑Präsentation mit JavaScript zugreifen**
Der folgende Beispielcode zeigt, wie man auf Knoten innerhalb eines SmartArt‑Objekts zugreift. Bitte beachten Sie, dass Sie den LayoutType von SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen des SmartArt‑Objekts festgelegt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) um, falls sie SmartArt ist.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) innerhalb des SmartArt‑Objekts.
6. Greifen Sie auf Informationen wie die Position, Ebene und den Text des SmartArt‑Knotens zu und zeigen Sie diese an.
```javascript
// Präsentationsklasse instanziieren
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // Durchlaufen Sie jede Form auf der ersten Folie
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArt casten
            var smart = shape;
            // Durchlaufen Sie alle Knoten innerhalb von SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Zugriff auf den SmartArt-Knoten bei Index i
                var node = smart.getAllNodes().get_Item(j);
                // Ausgabe der SmartArt-Knotenparameter
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zugriff auf SmartArt‑untergeordnete Knoten**
Der folgende Beispielcode zeigt, wie man auf die untergeordneten Knoten der jeweiligen SmartArt‑Knoten zugreift.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) um, falls sie SmartArt ist.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) innerhalb des SmartArt‑Objekts.
6. Für jeden ausgewählten SmartArt‑Knoten [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) durchlaufen Sie alle [**Child Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) des jeweiligen Knotens.
7. Greifen Sie auf Informationen wie die Position, Ebene und den Text des **untergeordneten Knotens** zu und zeigen Sie diese an.
```javascript
// Präsentationsklasse instanziieren
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // Durchlaufen Sie jede Form auf der ersten Folie
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArt casten
            var smart = shape;
            // Durchlaufen Sie alle Knoten innerhalb von SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Zugriff auf den SmartArt-Knoten bei Index i
                var node0 = smart.getAllNodes().get_Item(i);
                // Durchlaufen der untergeordneten Knoten im SmartArt-Knoten bei Index i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
                    var node = node0.getChildNodes().get_Item(j);
                    // Ausgabe der SmartArt-Unterknotenparameter
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zugriff auf SmartArt‑untergeordnete Knoten an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man die untergeordneten Knoten an einer bestimmten Position der jeweiligen SmartArt‑Knoten abruft.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Fügen Sie ein SmartArt‑Objekt vom Typ [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) hinzu.
4. Greifen Sie auf das hinzugefügte SmartArt‑Objekt zu.
5. Greifen Sie auf den Knoten mit Index 0 des ausgewählten SmartArt‑Objekts zu.
6. Greifen Sie nun mit der Methode **get_Item()** auf den **untergeordneten Knoten** an Position 1 des ausgewählten SmartArt‑Knotens zu.
7. Greifen Sie auf Informationen wie die Position, Ebene und den Text des **untergeordneten Knotens** zu und zeigen Sie diese an.
```javascript
// Präsentation instanziieren
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen der SmartArt-Shape in der ersten Folie
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Zugriff auf den SmartArt-Knoten bei Index 0
    var node = smart.getAllNodes().get_Item(0);
    // Zugriff auf den untergeordneten Knoten an Position 1 im übergeordneten Knoten
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Ausgabe der SmartArt-Unterknotenparameter
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt‑Knoten in einer PowerPoint‑Präsentation mit JavaScript entfernen**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb eines SmartArt‑Objekts entfernt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) um, falls sie SmartArt ist.
5. Prüfen Sie, ob das [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) mehr als 0 Knoten enthält.
6. Wählen Sie den zu löschenden SmartArt‑Knoten aus.
7. Entfernen Sie nun den ausgewählten Knoten mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
8. Speichern Sie die Präsentation.
```javascript
// Laden Sie die gewünschte Präsentation
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form auf der ersten Folie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArt casten
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Zugriff auf den SmartArt-Knoten bei Index 0
                var node = smart.getAllNodes().get_Item(0);
                // Entfernen des ausgewählten Knotens
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Präsentation speichern
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt‑Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb eines SmartArt‑Objekts an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
2. Holen Sie sich die Referenz der ersten Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) um, falls sie SmartArt ist.
5. Wählen Sie den SmartArt‑Knoten an Index 0 aus.
6. Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten hat.
7. Entfernen Sie nun den Knoten an **Position 1** mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
8. Speichern Sie die Präsentation.
```javascript
// Laden Sie die gewünschte Präsentation
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form auf der ersten Folie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Form zu SmartArt casten
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Zugriff auf den SmartArt‑Knoten bei Index 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Entfernen des untergeordneten Knotens an Position 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Präsentation speichern
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Benutzerdefinierte Position für untergeordnete Knoten in SmartArt festlegen**
Aspose.Slides for Node.js via Java unterstützt jetzt das Setzen der Eigenschaften X und Y für [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape). Der nachstehende Codeausschnitt zeigt, wie man benutzerdefinierte Position, Größe und Drehung für ein SmartArtShape festlegt. Beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Mit benutzerdefinierten Positionseinstellungen können Benutzer die Knoten nach Bedarf anordnen.
```javascript
// Instantiate Presentation Class
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Move SmartArt shape to new position
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Change SmartArt shape's widths
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Change SmartArt shape's height
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Change SmartArt shape's rotation
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Assistant‑Knoten prüfen**
{{% alert color="primary" %}} 

In diesem Artikel untersuchen wir weitere Funktionen von SmartArt‑Objekten, die programmgesteuert mit Aspose.Slides for Node.js via Java zu Präsentationsfolien hinzugefügt werden.

{{% /alert %}} 

Wir verwenden das folgende Quell‑SmartArt‑Objekt für unsere Untersuchungen in den verschiedenen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Quell‑SmartArt‑Objekt in der Folie**|

Im folgenden Beispielcode untersuchen wir, wie man **Assistant Nodes** in der SmartArt‑Knotensammlung identifiziert und ändert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
2. Holen Sie sich die Referenz der zweiten Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) um, falls sie SmartArt ist.
5. Durchlaufen Sie alle Knoten im SmartArt‑Objekt und prüfen Sie, ob es sich um **Assistant Nodes** handelt.
6. Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
7. Speichern Sie die Präsentation.
```javascript
// Erstellen einer Präsentationsinstanz
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Durchlaufen jeder Form auf der ersten Folie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArt casten
            var smart = shape;
            // Durchlaufen aller Knoten des SmartArt-Objekts
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Prüfen, ob der Knoten ein Assistant-Knoten ist
                if (node.isAssistant()) {
                    // Assistant-Status auf false setzen und den Knoten zu einem normalen Knoten machen
                    node.isAssistant();
                }
            }
        }
    }
    // Präsentation speichern
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Abbildung: Assistant‑Knoten im SmartArt‑Objekt der Folie geändert**|

## **Füllformat für Knoten festlegen**
Aspose.Slides for Node.js via Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Objekte und das Setzen ihres Füllformats. Dieser Artikel erklärt, wie man SmartArt‑Objekte erstellt, darauf zugreift und ihr Füllformat festlegt.

Bitte führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer Folie anhand ihres Index.
3. Fügen Sie ein [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)-Objekt hinzu, indem Sie dessen [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
4. Setzen Sie das [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) für die Knoten des SmartArt‑Objekts.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.
```javascript
// Präsentation instanziieren
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die Folie
    var slide = pres.getSlides().get_Item(0);
    // SmartArt-Shape und Knoten hinzufügen
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Füllfarbe des Knotens setzen
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Präsentation speichern
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Miniaturansicht eines SmartArt‑untergeordneten Knotens erstellen**
Entwickler können eine Miniaturansicht eines untergeordneten Knotens eines SmartArt‑Objekts erzeugen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. [SmartArt hinzufügen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
3. Holen Sie sich die Referenz eines Knotens anhand seines Index.
4. Erhalten Sie das Miniaturbild.
5. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```javascript
// Instanziieren der Presentation-Klasse, die die PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // SmartArt hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Den Verweis auf einen Knoten über seinen Index erhalten
    var node = smart.getNodes().get_Item(1);
    // Thumbnail abrufen
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Thumbnail speichern
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/nodejs-java/shape-animation/) (Einfade, Ausfaden, Hervorhebung, Bewegungsbahnen) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?**

Vergeben und suchen Sie nach dem **alternativen Text**. Durch das Setzen eines eindeutigen AltText‑Werts für das SmartArt‑Objekt können Sie es finden, ohne auf interne Bezeichner angewiesen zu sein.

**Wird das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF erhalten?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Genauigkeit beim PDF‑Export und bewahrt dabei Layout, Farben und Effekte.

**Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschauen oder Berichte)?**

Ja. Sie können ein SmartArt‑Objekt in Rasterformate oder in SVG rendern, um skalierbare Vektorausgaben zu erhalten, was es für Miniaturbilder, Berichte oder die Web‑Nutzung geeignet macht.