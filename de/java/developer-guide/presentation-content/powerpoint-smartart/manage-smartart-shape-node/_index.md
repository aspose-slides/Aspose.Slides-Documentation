---
title: SmartArt-Formknoten in Präsentationen mit Java verwalten
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/java/manage-smartart-shape-node/
keywords:
- SmartArt-Knoten
- Kindknoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistent-Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT und PPTX mit Aspose.Slides für Java. Erhalten Sie klare Code-Beispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides für Java stellt die einfachste API bereit, um SmartArt‑Formen auf unkomplizierte Weise zu verwalten. Der folgende Beispielcode hilft, einen Knoten und einen Kindknoten in einer SmartArt‑Form hinzuzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie alle Formen in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
1. Fügen Sie einen neuen Knoten in die SmartArt‑Form [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) ein und setzen Sie den Text im TextFrame.
1. Fügen Sie nun einen [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) zum neu hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
1. Speichern Sie die Präsentation.
```java
// Laden der gewünschten Präsentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof SmartArt) 
        {
            // Form in SmartArt umwandeln
            SmartArt smart = (SmartArt) shape;
    
            // Neuen SmartArt-Knoten hinzufügen
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Text hinzufügen
            TemNode.getTextFrame().setText("Test");
    
            // Neuen Kindknoten im übergeordneten Knoten hinzufügen. Er wird am Ende der Sammlung eingefügt.
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
Im folgenden Beispielcode wird erklärt, wie Kindknoten zu den jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position hinzugefügt werden.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList)‑Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)‑Form in die angegebene Folie ein.
1. Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt‑Form zu.
1. Fügen Sie nun den [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) an Position 2 hinzu und setzen Sie dessen Text.
1. Speichern Sie die Präsentation.
```java
// Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Auf die Folie der Präsentation zugreifen
    ISlide slide = pres.getSlides().get_Item(0);

    // SmartArt IShape hinzufügen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Neuen Kindknoten an Position 2 im übergeordneten Knoten hinzufügen
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Text hinzufügen
    chNode.getTextFrame().setText("Sample Text Added");

    // Präsentation speichern
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf einen SmartArt‑Knoten**
Der folgende Beispielcode zeigt, wie Sie Knoten innerhalb einer SmartArt‑Form zugreifen können. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie alle Formen in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
1. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
1. Greifen Sie auf die Informationen zu Position, Ebene und Text des SmartArt‑Knotens zu und zeigen Sie sie an.
```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Erste Folie erhalten
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Prüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form in SmartArt umwandeln
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen aller Knoten innerhalb von SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf SmartArt-Knoten bei Index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Ausgabe der SmartArt-Knotenparameter
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf einen SmartArt‑Kindknoten**
Der folgende Beispielcode hilft, die Kindknoten zu den jeweiligen Knoten einer SmartArt‑Form zuzugreifen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie alle Formen in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
1. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
1. Für jeden ausgewählten SmartArt‑Knoten [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) durchlaufen Sie alle [**Child Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) des jeweiligen Knotens.
1. Greifen Sie auf die Informationen zu Position, Ebene und Text des [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) zu und zeigen Sie sie an.
```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Erste Folie erhalten
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Prüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form in SmartArt umwandeln
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen aller Knoten innerhalb von SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf SmartArt-Knoten bei Index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Durchlaufen der Kindknoten im SmartArt-Knoten bei Index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Zugriff auf den Kindknoten im SmartArt-Knoten
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Ausgabe der SmartArt-Kindknotenparameter
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf einen SmartArt‑Kindknoten an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man Kindknoten an einer bestimmten Position zu den jeweiligen Knoten einer SmartArt‑Form zugreift.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList)‑Typ SmartArt‑Form hinzu.
1. Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
1. Greifen Sie auf den Knoten mit Index 0 der SmartArt‑Form zu.
1. Greifen Sie nun mit der **get_Item()**‑Methode auf den [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 des ausgewählten SmartArt‑Knotens zu.
1. Zeigen Sie die Informationen zu Position, Ebene und Text des [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArtNode#getChildNodes--) an.
```java
// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen der SmartArt-Form in der ersten Folie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Zugriff auf den Kindknoten an Position 1 im übergeordneten Knoten
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Ausgabe der SmartArt-Kindknotenparameter
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Entfernen eines SmartArt‑Knotens**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie alle Formen in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
1. Prüfen Sie, ob die [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) mehr als 0 Knoten enthält.
1. Wählen Sie den zu löschenden SmartArt‑Knoten aus.
1. Entfernen Sie den ausgewählten Knoten mit der [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)‑Methode.
1. Speichern Sie die Präsentation.
```java
// Gewünschte Präsentation laden
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen aller Formen auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form in SmartArt umwandeln
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf SmartArt-Knoten bei Index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Ausgewählten Knoten entfernen
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


## **Entfernen eines SmartArt‑Knotens an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie alle Formen in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt), falls sie SmartArt ist.
1. Wählen Sie den SmartArt‑Form‑Knoten mit Index 0 aus.
1. Prüfen Sie, ob der ausgewählte SmartArt‑Knoten mehr als 2 Kindknoten enthält.
1. Entfernen Sie den Knoten an **Position 1** mit der [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArtNodeCollection#removeNode-int-)‑Methode.
1. Speichern Sie die Präsentation.
```java
// Gewünschte Präsentation laden
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Alle Formen auf der ersten Folie durchlaufen
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof SmartArt) 
        {
            // Form in SmartArt umwandeln
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf SmartArt-Knoten bei Index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Entfernen des Kindknotens an Position 1
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


## **Benutzerdefinierte Position für einen Kindknoten in einem SmartArt‑Objekt festlegen**
Jetzt unterstützt Aspose.Slides für Java das Setzen der [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape)‑Eigenschaften [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-). Das folgende Code‑Snippet zeigt, wie man die benutzerdefinierte Position, Größe und Drehung einer SmartArtShape festlegt; beachten Sie bitte, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Mit benutzerdefinierten Positionseinstellungen können Benutzer die Knoten nach Bedarf anordnen.
```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt-Form an neue Position verschieben
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Breiten der SmartArt-Form ändern
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


## **Assistant‑Knoten prüfen**
{{% alert color="primary" %}} 

In diesem Artikel untersuchen wir weitere Funktionen von SmartArt‑Formen, die programmgesteuert mit Aspose.Slides für Java zu Präsentationsfolien hinzugefügt werden.

{{% /alert %}} 

Wir verwenden die folgende SmartArt‑Form als Ausgangsbasis für unsere Untersuchungen in den verschiedenen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Ausgangs‑SmartArt‑Form in der Folie**|

Im folgenden Beispielcode untersuchen wir, wie man **Assistant Nodes** in der SmartArt‑Knoten‑Sammlung identifiziert und ändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Holen Sie sich die Referenz der zweiten Folie über deren Index.
1. Durchlaufen Sie alle Formen in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
1. Durchlaufen Sie alle Knoten in der SmartArt‑Form und prüfen Sie, ob sie [**Assistant Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--) sind.
1. Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
1. Speichern Sie die Präsentation.
```java
// Präsentationsinstanz erstellen
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Durchlaufen aller Formen in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form in SmartArt umwandeln
            ISmartArt smart = (SmartArt) shape;
    
            // Durchlaufen aller Knoten der SmartArt-Form
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Prüfen, ob der Knoten ein Assistant-Knoten ist
                if (node.isAssistant()) 
                {
                    // Assistant-Status auf false setzen und den Knoten zu einem normalen Knoten machen
                    node.isAssistant();
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
|**Abbildung: Assistant‑Knoten in der SmartArt‑Form geändert**|

## **Füllformat eines Knotens festlegen**
Aspose.Slides für Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihres Füllformats. Dieser Artikel erklärt, wie Sie SmartArt‑Formen erstellen, darauf zugreifen und das Füllformat mit Aspose.Slides für Java festlegen.

Bitte folgen Sie den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse.
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)‑Form hinzu, indem Sie deren [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
1. Setzen Sie das [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) für die SmartArt‑Formknoten.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```java
// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Zugriff auf die Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt-Form und Knoten hinzufügen
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Füllfarbe des Knotens festlegen
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


## **Thumbnail eines SmartArt‑Kindknotens erzeugen**
Entwickler können ein Thumbnail eines Kindknotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse.
1. [SmartArt hinzufügen](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArtNodeCollection#addNode--).
1. Holen Sie sich die Referenz eines Knotens über dessen Index.
1. Erhalten Sie das Thumbnail‑Bild.
1. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.
```java
// Presentation-Klasse instanziieren, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // SmartArt hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Referenz eines Knotens anhand seines Index erhalten
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Miniaturbild abrufen
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Miniaturbild speichern
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

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/java/shape-animation/) (Eingang, Ausgang, Betonung, Bewegungspfade) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie finde ich zuverlässig ein bestimmtes SmartArt auf einer Folie, wenn die interne ID unbekannt ist?**

Verwenden Sie das [alternative text](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) Attribut. Durch das Setzen eines eindeutigen AltText auf das SmartArt können Sie es programmgesteuert finden, ohne interne Kennungen zu benötigen.

**Bleibt das Erscheinungsbild von SmartArt beim Konvertieren der Präsentation in PDF erhalten?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Genauigkeit beim [PDF‑Export](/slides/de/java/convert-powerpoint-to-pdf/), sodass Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschaubilder oder Berichte)?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) oder in [SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) rendern, um skalierbare Vektordateien zu erhalten, die sich gut für Thumbnails, Berichte oder Webnutzung eignen.