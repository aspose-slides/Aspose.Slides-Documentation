---
title: Verwalten von SmartArt-Formknoten in Präsentationen mit Java
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/java/manage-smartart-shape-node/
keywords:
- SmartArt-Knoten
- untergeordneter Knoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistenten-Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT und PPTX mit Aspose.Slides für Java. Erhalten Sie klare Codebeispiele und Tipps, um Ihre Präsentationen zu optimieren."
---
## **Übersicht**

SmartArt‑Grafiken in PowerPoint‑Präsentationen sind über Knoten organisiert, die Text enthalten und die Struktur des Diagramms definieren. Aspose.Slides ermöglicht die programmgesteuerte Arbeit mit diesen SmartArt‑Knoten: Hinzufügen neuer Knoten und untergeordneter Knoten, Einfügen von untergeordneten Knoten an einer bestimmten Position, Zugriff auf vorhandene Knoten sowie das Auslesen von Text, Ebene und Position.

Dieser Artikel erklärt, wie SmartArt‑Formknoten verwaltet werden. Er zeigt, wie Knoten entfernt werden, wie mit untergeordneten Knoten nach Index oder Position gearbeitet wird, wie ein Assistent‑Knoten in einen normalen Knoten umgewandelt wird, wie Position, Größe und Drehung von SmartArt‑Knotenformen angepasst werden, wie Füllformate gesetzt werden und wie ein Thumbnail‑Bild für einen SmartArt‑untergeordneten Knoten generiert wird.

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides für Java stellt die einfachste API bereit, um SmartArt‑Formen auf einfachste Weise zu verwalten. Der folgende Beispielcode hilft beim Hinzufügen von Knoten und untergeordneten Knoten innerhalb einer SmartArt‑Form.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt) ist und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
5. [Add a new Node](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) in der SmartArt‑Form [**NodeCollection**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt#getAllNodes--) und setzen Sie den Text im TextFrame.
6. Jetzt, [Add](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) einen [**Child Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#getChildNodes--) im neu hinzugefügten [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt)-Knoten und setzen Sie den Text im TextFrame.
7. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Lade die gewünschte Präsentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufe jede Form auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfe, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Form zu SmartArt casten
            SmartArt smart = (SmartArt) shape;
    
            // Hinzufügen eines neuen SmartArt-Knotens
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Text hinzufügen
            TemNode.getTextFrame().setText("Test");
    
            // Hinzufügen eines neuen untergeordneten Knotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Text hinzufügen
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Präsentation speichern
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie untergeordnete Knoten zu den jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position hinzugefügt werden.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtLayoutType#StackedList)-Art [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArt)-Form in die ausgewählte Folie ein.
4. Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
5. Fügen Sie nun den [**Child Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtNode) an Position 2 hinzu und setzen Sie dessen Text.
6. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Erstellen einer Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Zugriff auf die Präsentationsfolie
    ISlide slide = pres.getSlides().get_Item(0);

    // SmartArt IShape hinzufügen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Hinzufügen eines neuen untergeordneten Knotens an Position 2 im übergeordneten Knoten
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Text hinzufügen
    chNode.getTextFrame().setText("Sample Text Added");

    // Präsentation speichern
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Auf einen SmartArt‑Knoten zugreifen**
Der folgende Beispielcode hilft beim Zugriff auf Knoten innerhalb einer SmartArt‑Form. Bitte beachten Sie, dass Sie den LayoutType von SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt) ist und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
6. Greifen Sie zu und zeigen Sie Informationen wie SmartArt‑Knoten‑Position, Ebene und Text an.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen aller Formen in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArt casten
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen aller Knoten innerhalb von SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf SmartArt-Knoten bei Index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Ausgeben der SmartArt-Knoten-Parameter
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Auf einen SmartArt‑untergeordneten Knoten zugreifen**
Der folgende Beispielcode hilft beim Zugriff auf die untergeordneten Knoten, die zu den jeweiligen Knoten einer SmartArt‑Form gehören.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt) ist und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
6. Für jeden ausgewählten SmartArt‑Form‑[**Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtNode) durchlaufen Sie alle [**Child Nodes**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtNode#getChildNodes--) des jeweiligen Knotens.
7. Greifen Sie zu und zeigen Sie Informationen wie [**Child Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text an.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen aller Formen in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArt casten
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen aller Knoten innerhalb von SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf SmartArt-Knoten bei Index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Durchlaufen der untergeordneten Knoten im SmartArt-Knoten bei Index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Ausgeben der SmartArt-untergeordneten Knoten-Parameter
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑untergeordneten Knoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie man untergeordnete Knoten an einer bestimmten Position, die zu den jeweiligen Knoten einer SmartArt‑Form gehören, abruft.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtLayoutType#StackedList)-Art SmartArt‑Form hinzu.
4. Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
5. Greifen Sie auf den Knoten mit Index 0 der ausgewählten SmartArt‑Form zu.
6. Greifen Sie nun über die **get_Item()**‑Methode auf den [**Child Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 des ausgewählten SmartArt‑Knotens zu.
7. Greifen Sie zu und zeigen Sie Informationen wie [**Child Node**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text an.

```java
import com.aspose.slides.*;

// Instanziieren der Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen der SmartArt-Form in der ersten Folie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Zugriff auf den untergeordneten Knoten an Position 1 im übergeordneten Knoten
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Ausgeben der SmartArt-untergeordneten Knoten-Parameter
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, wie Knoten innerhalb einer SmartArt‑Form entfernt werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt) ist und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISSmartArt), falls es sich um SmartArt handelt.
5. Prüfen Sie, ob das [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt) mehr als 0 Knoten enthält.
6. Wählen Sie den SmartArt‑Knoten aus, der gelöscht werden soll.
7. Entfernen Sie nun den ausgewählten Knoten über die [**RemoveNode**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)‑Methode.
8. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArt casten
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf SmartArt-Knoten bei Index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Entfernen des ausgewählten Knotens
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Präsentation speichern
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie Knoten innerhalb einer SmartArt‑Form an einer konkreten Position entfernt werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über deren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArt) ist und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISSmartArt), falls es sich um SmartArt handelt.
5. Wählen Sie den SmartArt‑Form‑Knoten mit Index 0 aus.
6. Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten besitzt.
7. Entfernen Sie nun den Knoten an **Position 1** über die [**RemoveNode**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)‑Methode.
8. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Form zu SmartArt casten
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf SmartArt-Knoten bei Index 0
                ISsmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Entfernen des untergeordneten Knotens an Position 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Präsentation speichern
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Benutzerdefinierte Position für einen untergeordneten Knoten in einem SmartArt‑Objekt festlegen**
Aspose.Slides für Java unterstützt jetzt das Setzen der [SmartArtShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtShape)‑Eigenschaften [X](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShape#setY-float-). Der nachfolgende Code‑Auszug zeigt, wie benutzerdefinierte SmartArtShape‑Position, -Größe und -Drehung gesetzt werden. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Durch benutzerdefinierte Positionseinstellungen kann der Nutzer die Knoten nach Bedarf ausrichten.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt-Form an neue Position verschieben
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Breite der SmartArt-Form ändern
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Höhe der SmartArt-Form ändern
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Drehung der SmartArt-Form ändern
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Einen Assistent‑Knoten prüfen**
{{% alert color="info" %}} 

In diesem Artikel untersuchen wir weitere Funktionen von SmartArt‑Formen, die programmgesteuert mit Aspose.Slides für Java zu Präsentationsfolien hinzugefügt wurden.

{{% /alert %}} 

Wir verwenden die nachfolgende SmartArt‑Form als Ausgangsbasis für die Untersuchungen in den verschiedenen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Ausgangs‑SmartArt‑Form in Folie**|

Im folgenden Beispielcode untersuchen wir, wie **Assistant Nodes** in der SmartArt‑Knoten‑Sammlung identifiziert und geändert werden können.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie die Referenz der zweiten Folie über deren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISSmartArt) ist und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISSmartArt), falls es sich um SmartArt handelt.
5. Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie [**Assistant Nodes**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtNode#isAssistant--) sind.
6. Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
7. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Erstellen einer Präsentationsinstanz
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArt casten
            ISmartArt smart = (SmartArt) shape;
    
            // Durchlaufen aller Knoten der SmartArt-Form
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Prüfen, ob der Knoten ein Assistant‑Knoten ist
                if (node.isAssistant()) 
                {
                    // Assistant‑Knoten auf false setzen und zu einem normalen Knoten machen
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Präsentation speichern
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Abbildung: Assistant‑Knoten in SmartArt‑Form geändert**|

## **Füllformat eines Knotens festlegen**
Aspose.Slides für Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Setzen ihres Füllformats. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt und darauf zugegriffen sowie ihr Füllformat mit Aspose.Slides für Java festgelegt wird.

Bitte folgen Sie den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISSmartArt)-Form hinzu, indem Sie deren [**LayoutType**](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
4. Setzen Sie das [**FillFormat**](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShape#getFillFormat--) für die SmartArt‑Form‑Knoten.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Zugriff auf die Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen der SmartArt-Form und Knoten
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Festlegen der Füllfarbe des Knotens
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Präsentation speichern
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thumbnail eines SmartArt‑untergeordneten Knotens erzeugen**
Entwickler können ein Thumbnail eines untergeordneten Knotens einer SmartArt erzeugen, indem sie die nachstehenden Schritte ausführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse.
2. [Add SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISSmartArtNodeCollection#addNode--).
3. Holen Sie die Referenz eines Knotens über dessen Index.
4. Erhalten Sie das Thumbnail‑Bild.
5. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // SmartArt hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Referenz eines Knotens über dessen Index erhalten
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Thumbnail erhalten
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Thumbnail speichern
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Wird SmartArt‑Animation unterstützt?

Ja. SmartArt wird als reguläre Form behandelt, sodass Sie [standardmäßige Animationen](/slides/de/java/shape-animation/) (Eintritt, Austritt, Hervorhebung, Bewegungsbahnen) anwenden und das Timing anpassen können. Auf Wunsch können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

### Wie finde ich ein bestimmtes SmartArt zuverlässig auf einer Folie, wenn die interne ID unbekannt ist?

Verwenden Sie [alternativen Text](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getAlternativeText--) zum Zuordnen und Suchen. Durch das Setzen eines eindeutigen AltText auf das SmartArt können Sie es programmgesteuert finden, ohne interne Bezeichner zu benötigen.

### Wird das Aussehen von SmartArt beim Konvertieren der Präsentation nach PDF erhalten bleiben?

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue beim [PDF‑Export](/slides/de/java/convert-powerpoint-to-pdf/), wodurch Layout, Farben und Effekte erhalten bleiben.

### Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschaubilder oder Berichte)?

Ja. Sie können eine SmartArt‑Form in [Rasterformate](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getImage-int-float-float-) oder nach [SVG](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) rendern, um skalierbare Vektordateien zu erhalten, die sich für Thumbnails, Berichte oder Web‑Verwendung eignen.