---
title: SmartArt-Formknoten in Präsentationen auf Android verwalten
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt-Knoten
- Kindknoten
- Knoten hinzufügen
- Knotenposition
- Knoten zugreifen
- Knoten entfernen
- benutzerdefinierte Position
- Assistant-Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT und PPTX mit Aspose.Slides für Android. Erhalten Sie klare Java-Codebeispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides für Android über Java hat die einfachste API bereitgestellt, um SmartArt‑Formen auf einfachste Weise zu verwalten. Der folgende Beispielcode hilft, einen Knoten und einen Kindknoten innerhalb einer SmartArt‑Form hinzuzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
5. [Fügen Sie einen neuen Knoten hinzu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) in die SmartArt‑Form [**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) und setzen Sie den Text im TextFrame.
6. Jetzt, [Hinzufügen] einen [**Kindknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) zum neu hinzugefügten [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)‑Knoten und setzen Sie den Text im TextFrame.
7. Speichern Sie die Präsentation.
```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Typumwandlung der Form zu SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Hinzufügen eines neuen SmartArt-Knotens
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Text hinzufügen
            TemNode.getTextFrame().setText("Test");
    
            // Hinzufügen eines neuen Kindknotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
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
Im folgenden Beispielcode haben wir erklärt, wie man die Kindknoten, die zu den jeweiligen Knoten einer SmartArt‑Form gehören, an einer bestimmten Position hinzufügt.

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Fügen Sie in der angegriffenen Folie eine SmartArt‑Form vom Typ [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) hinzu.
4. Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
5. Fügen Sie nun den [**Kindknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) an Position 2 hinzu und setzen Sie dessen Text.
6. Speichern Sie die Präsentation.
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


## **Auf einen SmartArt‑Knoten zugreifen**
Der folgende Beispielcode hilft, Knoten innerhalb einer SmartArt‑Form zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form gesetzt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
6. Greifen Sie zu und zeigen Sie Informationen wie SmartArt‑Knoten‑Position, Ebene und Text an.
```java
// Presentation-Klasse instanziieren
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Erste Folie holen
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
    
                // Ausgabe der SmartArt-Knotenparameter
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Auf einen SmartArt‑Kindknoten zugreifen**
Der folgende Beispielcode hilft, die Kindknoten zu den jeweiligen Knoten einer SmartArt‑Form zuzugreifen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
6. Für jeden ausgewählten SmartArt‑[**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) traversieren Sie alle [**Child Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) innerhalb dieses Knotens.
7. Greifen Sie zu und zeigen Sie Informationen wie [**Child Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text an.
```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Erste Folie holen
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


## **Auf einen SmartArt‑Kindknoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie man Kindknoten an einer bestimmten Position zu den jeweiligen Knoten einer SmartArt‑Form zugreift.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Fügen Sie eine SmartArt‑Form vom Typ [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) hinzu.
4. Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
5. Greifen Sie auf den Knoten mit Index 0 der angegriffenen SmartArt‑Form zu.
6. Jetzt greifen Sie mit der Methode **get_Item()** auf den [**Child Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 des angegriffenen SmartArt‑Knotens zu.
7. Greifen Sie zu und zeigen Sie Informationen wie [**Child Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text an.
```java
// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt-Form zur ersten Folie hinzufügen
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


## **Einen SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form entfernt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISSmartArt), falls es sich um SmartArt handelt.
5. Prüfen Sie, ob die [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) mehr als 0 Knoten enthält.
6. Wählen Sie den zu löschenden SmartArt‑Knoten aus.
7. Entfernen Sie nun den ausgewählten Knoten mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
8. Speichern Sie die Präsentation.
```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
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


## **Einen SmartArt‑Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISSmartArt), falls es sich um SmartArt handelt.
5. Wählen Sie den SmartArt‑Form‑Knoten mit Index 0 aus.
6. Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 Kindknoten enthält.
7. Entfernen Sie nun den Knoten an **Position 1** mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
8. Speichern Sie die Präsentation.
```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Form zu SmartArt casten
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf den SmartArt-Knoten bei Index 0
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


## **Eine benutzerdefinierte Position für einen Kindknoten in einem SmartArt‑Objekt festlegen**
Jetzt unterstützt Aspose.Slides für Android über Java das Setzen der Eigenschaften [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-) des [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape). Das nachfolgende Code‑Snippet zeigt, wie benutzerdefinierte Position, Größe und Drehung einer SmartArtShape festgelegt werden können. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Mit benutzerdefinierten Positionseinstellungen kann der Nutzer die Knoten nach Bedarf anordnen.
```java
// Presentation-Klasse instanziieren
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

In diesem Artikel untersuchen wir weitere Funktionen von SmartArt‑Formen, die programmgesteuert mit Aspose.Slides für Android über Java zu Präsentationsfolien hinzugefügt werden.

{{% /alert %}} 

Wir verwenden die nachstehende SmartArt‑Form als Ausgangsbasis für unsere Untersuchungen in den verschiedenen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Ausgangs‑SmartArt‑Form in der Folie**|

Im folgenden Beispielcode untersuchen wir, wie **Assistant‑Knoten** in der SmartArt‑Knotensammlung identifiziert und geändert werden können.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der zweiten Folie über ihren Index.
3. Durchlaufen Sie jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISSmartArt), falls es sich um SmartArt handelt.
5. Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie [**Assistant Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) sind.
6. Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
7. Speichern Sie die Präsentation.
```java
// Präsentationsinstanz erstellen
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
                // Prüfen, ob der Knoten ein Assistant-Knoten ist
                if (node.isAssistant()) 
                {
                    // Assistant-Flag auf false setzen und den Knoten zu einem normalen Knoten machen
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

## **Füllformat für einen Knoten festlegen**
Aspose.Slides für Android über Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihres Füllformats. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt, zugegriffen und ihr Füllformat gesetzt wird.

Bitte folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)‑Form hinzu, indem Sie deren [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
4. Setzen Sie das [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) für die Knoten der SmartArt‑Form.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
```java
// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Auf die Folie zugreifen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt-Form und Knoten hinzufügen
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Knoten-Füllfarbe festlegen
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


## **Ein Thumbnail eines SmartArt‑Kindknotens erzeugen**
Entwickler können ein Thumbnail eines Kindknotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. [SmartArt hinzufügen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Holen Sie die Referenz eines Knotens über dessen Index.
4. Erzeugen Sie das Thumbnail‑Bild.
5. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.
```java
// Instanziieren der Präsentationsklasse, die die PPTX-Datei darstellt 
Presentation pres = new Presentation();
try {
    // SmartArt hinzufügen 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Referenz eines Knotens anhand seines Index abrufen  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Thumbnail abrufen
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

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird als reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/androidjava/shape-animation/) (Eintritt, Austritt, Betonung, Bewegungspfad) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie finde ich ein bestimmtes SmartArt zuverlässig auf einer Folie, wenn seine interne ID unbekannt ist?**

Verwenden Sie [alternativen Text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--). Durch das Setzen eines eindeutigen AltText‑Werts für die SmartArt können Sie sie programmgesteuert finden, ohne interne Bezeichner zu benötigen.

**Bleibt das Aussehen von SmartArt beim Konvertieren der Präsentation zu PDF erhalten?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF‑Exports](/slides/de/androidjava/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt‑Objekts extrahieren (für Vorschauen oder Berichte)?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) oder in [SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) rendern, wodurch sich das Ergebnis für Thumbnails, Berichte oder Web‑Nutzung eignet.