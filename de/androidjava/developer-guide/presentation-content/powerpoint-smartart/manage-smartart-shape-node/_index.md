---
title: SmartArt-Formknoten in Präsentationen auf Android verwalten
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt-Knoten
- Unterknoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistentenknoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT und PPTX mit Aspose.Slides für Android. Erhalten Sie klare Java-Codebeispiele und Tipps, um Ihre Präsentationen zu optimieren."
---
## **Übersicht**

SmartArt‑Grafiken in PowerPoint‑Präsentationen werden über Knoten organisiert, die Text enthalten und die Struktur des Diagramms definieren. Aspose.Slides ermöglicht es, diese SmartArt‑Knoten programmgesteuert zu verwalten: neue Knoten und Unterknoten hinzufügen, Unterknoten an einer bestimmten Position einfügen, vorhandene Knoten zugreifen und deren Text, Ebene und Position auslesen.

Dieser Artikel erklärt, wie SmartArt‑Form‑Knoten verwaltet werden. Er zeigt, wie Knoten entfernt werden, wie mit Unterknoten nach Index oder Position gearbeitet wird, wie ein Assistent‑Knoten in einen normalen Knoten geändert wird, wie Position, Größe und Drehung von SmartArt‑Knoten‑Formen angepasst werden, wie Füllformate gesetzt werden und wie ein Thumbnail‑Bild für einen SmartArt‑Knoten erzeugt wird.

## **einen SmartArt‑Knoten hinzufügen**
Aspose.Slides für Android via Java stellt die einfachste API bereit, um SmartArt‑Formen auf unkomplizierte Weise zu verwalten. Der folgende Beispielcode hilft, einen Knoten und Unterknoten innerhalb einer SmartArt‑Form hinzuzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
5. [Add a new Node](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) in SmartArt‑Form [**NodeCollection**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) und setzen Sie den Text im TextFrame.
6. Jetzt [Add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) einen [**Child Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) zum gerade hinzugefügten [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt)-Knoten und setzen Sie den Text im TextFrame.
7. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufen Sie alle Formen auf der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Form zu SmartArt casten
            SmartArt smart = (SmartArt) shape;
    
            // Hinzufügen eines neuen SmartArt-Knotens
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Text hinzufügen
            TemNode.getTextFrame().setText("Test");
    
            // Hinzufügen eines neuen Unterknotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
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

## **einen SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie Unterknoten zu den jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position hinzugefügt werden.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)-Art [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArt)-Form in die ausgewählte Folie ein.
4. Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
5. Fügen Sie nun den [**Child Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtNode) an Position 2 hinzu und setzen Sie dessen Text.
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

    // Hinzufügen eines neuen Unterknotens an Position 2 im übergeordneten Knoten
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Text hinzufügen
    chNode.getTextFrame().setText("Sample Text Added");

    // Präsentation speichern
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **einen SmartArt‑Knoten zugreifen**
Der folgende Beispielcode hilft, Knoten innerhalb einer SmartArt‑Form zuzugreifen. Bitte beachten Sie, dass der LayoutType der SmartArt beim Hinzufügen der Form gewählt wird; ein späteres Ändern mit **setLayout** rekonstruiert das gesamte Diagramm, sodass die zuvor gesetzten Positionen und Größen neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die Auswahl zu [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
6. Greifen Sie zu und zeigen Sie Informationen wie SmartArt‑Knoten‑Position, Ebene und Text an.

```java
import com.aspose.slides.*;

// Präsentationsklasse instanziieren
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Erste Folie holen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen aller Formen auf der ersten Folie
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

## **einen SmartArt‑Unterknoten zugreifen**
Der folgende Beispielcode hilft, die Unterknoten zu den jeweiligen Knoten einer SmartArt‑Form zuzugreifen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die Auswahl zu [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
5. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt‑Form.
6. Für jeden ausgewählten SmartArt‑Form‑[**Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtNode) durchlaufen Sie alle [**Child Nodes**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) innerhalb dieses Knotens.
7. Greifen Sie zu und zeigen Sie Informationen wie [**Child Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text an.

```java
import com.aspose.slides.*;

// Präsentationsklasse instanziieren
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Erste Folie holen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen aller Formen auf der ersten Folie
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
                
                // Durchlaufen der Unterknoten im SmartArt-Knoten bei Index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Zugriff auf den Unterknoten im SmartArt-Knoten
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Ausgabe der SmartArt-Unterknotenparameter
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **einen SmartArt‑Unterknoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie die Unterknoten an einer bestimmten Position zu den jeweiligen Knoten einer SmartArt‑Form zugegriffen werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)-Art SmartArt‑Form hinzu.
4. Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
5. Greifen Sie auf den Knoten mit Index 0 der ausgewählten SmartArt‑Form zu.
6. Greifen Sie nun mit der **get_Item()**‑Methode auf den [**Child Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 des ausgewählten SmartArt‑Knotens zu.
7. Greifen Sie zu und zeigen Sie Informationen wie [**Child Node**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text an.

```java
import com.aspose.slides.*;

// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Erste Folie zugreifen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt-Form auf der ersten Folie hinzufügen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Zugriff auf den Unterknoten an Position 1 im übergeordneten Knoten
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Ausgabe der SmartArt-Unterknotenparameter
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **einen SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, wie Knoten innerhalb einer SmartArt‑Form entfernt werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die Auswahl zu [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISSmartArt) falls sie SmartArt ist.
5. Prüfen Sie, ob die [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) mehr als 0 Knoten enthält.
6. Wählen Sie den zu löschenden SmartArt‑Knoten aus.
7. Entfernen Sie nun den ausgewählten Knoten mit der [**RemoveNode**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)‑Methode.
8. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen aller Formen in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArt casten
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf den SmartArt-Knoten bei Index 0
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

## **einen SmartArt‑Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die Auswahl zu [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISSmartArt) falls sie SmartArt ist.
5. Wählen Sie den SmartArt‑Form‑Knoten mit Index 0 aus.
6. Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 Unterknoten enthält.
7. Entfernen Sie nun den Knoten an **Position 1** mit der [**RemoveNode**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)‑Methode.
8. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen aller Formen in der ersten Folie
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
                    // Entfernen des Unterknotens an Position 1
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

## **eine benutzerdefinierte Position für einen Unterknoten in einem SmartArt‑Objekt festlegen**
Aspose.Slides für Android via Java unterstützt das Setzen der [SmartArtShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtShape)-Eigenschaften [X](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShape#setY-float-). Der nachfolgende Code‑Abschnitt zeigt, wie benutzerdefinierte Position, Größe und Drehung einer SmartArtShape gesetzt werden. Beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Mit benutzerdefinierten Positionseinstellungen kann der Benutzer die Knoten nach Bedarf anordnen.

```java
import com.aspose.slides.*;

// Präsentationsklasse instanziieren
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

    // Rotation der SmartArt-Form ändern
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **einen Assistent‑Knoten prüfen**
{{% alert color="info" %}} 

In diesem Artikel untersuchen wir weitere Funktionen von SmartArt‑Formen, die programmgesteuert mit Aspose.Slides für Android via Java zu Präsentationsfolien hinzugefügt werden.

{{% /alert %}} 

Wir verwenden die folgende Quell‑SmartArt‑Form für unsere Untersuchungen in den verschiedenen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Quell‑SmartArt‑Form in der Folie**|

Im nachfolgenden Beispielcode untersuchen wir, wie **Assistant Nodes** in der SmartArt‑Knoten‑Sammlung identifiziert und geändert werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit SmartArt‑Form.
2. Holen Sie sich die Referenz der ersten Folie über ihren Index.
3. Durchlaufen Sie alle Formen auf der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt) ist, und casten Sie die Auswahl zu [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt), falls sie SmartArt ist.
5. Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie [**Assistant Nodes**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) sind.
6. Ändern Sie den Status des Assistant‑Knotens in einen normalen Knoten.
7. Speichern Sie die Präsentation.

```java
import com.aspose.slides.*;

// Eine Präsentationsinstanz erstellen
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Alle Formen auf der ersten Folie durchlaufen
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
                // Prüfen, ob der Knoten ein Assistentenknoten ist
                if (node.isAssistant()) 
                {
                    // Assistentenknoten auf false setzen und in einen normalen Knoten verwandeln
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

## **das Füllformat eines Knotens festlegen**
Aspose.Slides für Android via Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihres Füllformats. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt und zugegriffen sowie deren Füllformat mit Aspose.Slides für Android via Java gesetzt wird.

Bitte folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArt)-Form hinzu, indem Sie deren [**LayoutType**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
4. Setzen Sie das [**FillFormat**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShape#getFillFormat--) für die SmartArt‑Form‑Knoten.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Präsentation instanziieren
Presentation pres = new Presentation();
try {
    // Folie zugreifen
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

## **ein Thumbnail eines SmartArt‑Knotens erzeugen**
Entwickler können ein Thumbnail eines Knotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Klasse.
2. [Add SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Holen Sie sich die Referenz eines Knotens über dessen Index.
4. Holen Sie das Thumbnail‑Bild.
5. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

```java
import com.aspose.slides.*;

// Präsentationsklasse instanziieren, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // SmartArt hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Referenz eines Knotens über seinen Index erhalten
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

Ja. SmartArt wird als reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/androidjava/shape-animation/) (Einblenden, Ausblenden, Hervorheben, Bewegungsabläufe) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

### Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?

Verwenden Sie [alternativen Text](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getAlternativeText--) zum Zuordnen und Suchen. Durch das Setzen eines eindeutigen AltText auf das SmartArt finden Sie es programmgesteuert, ohne interne Kennungen nutzen zu müssen.

### Bleibt das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF erhalten?

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF‑Exports](/slides/de/androidjava/convert-powerpoint-to-pdf/), sodass Layout, Farben und Effekte erhalten bleiben.

### Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschauen oder Berichte)?

Ja. Sie können eine SmartArt‑Form in [Rasterformate](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) oder in [SVG](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) rendern, um skalierbare Vektorausgaben zu erhalten, die sich für Thumbnails, Berichte oder Web‑Nutzung eignen.