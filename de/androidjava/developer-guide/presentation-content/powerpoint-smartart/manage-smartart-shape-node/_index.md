---
title: Erstellen oder Verwalten von PowerPoint SmartArt-Former-Knoten in Java
linktitle: Verwalten von SmartArt-Former-Knoten
type: docs
weight: 30
url: /de/androidjava/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart knoten, smartart position, smartart entfernen, smartart knoten hinzufügen, powerpoint präsentation, powerpoint java, powerpoint java api
description: Verwalten von SmartArt-Knoten und untergeordneten Knoten in PowerPoint-Präsentationen in Java
---

## **SmartArt-Knoten in PowerPoint-Präsentation mit Java hinzufügen**
Aspose.Slides für Android über Java bietet die einfachste API zur Verwaltung von SmartArt-Formen auf die einfachste Weise. Der folgende Beispielcode hilft Ihnen, einen Knoten und einen untergeordneten Knoten innerhalb einer SmartArt-Form hinzuzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) -Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist, und typisieren Sie die ausgewählte Form in [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. [Fügen Sie einen neuen Knoten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) in der SmartArt-Form [**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) hinzu und setzen Sie den Text im TextFrame.
1. Fügen Sie nun einen [**Unterknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) in den neu hinzugefügten [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) Knoten hinzu und setzen Sie den Text im TextFrame.
1. Speichern Sie die Präsentation.

```java
// Laden der gewünschten Präsentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Die Form in SmartArt typisieren
            SmartArt smart = (SmartArt) shape;

            // Hinzufügen eines neuen SmartArt-Knotens
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();

            // Hinzufügen von Text
            TemNode.getTextFrame().setText("Test");

            // Hinzufügen eines neuen Unterknotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();

            // Hinzufügen von Text
            newNode.getTextFrame().setText("Neuer Knoten hinzugefügt");
        }
    }

    // Speichern der Präsentation
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt-Knoten an spezifischer Position hinzufügen**
Im folgenden Beispielcode wird erläutert, wie man die untergeordneten Knoten, die zu den entsprechenden Knoten der SmartArt-Form gehören, an einer bestimmten Position hinzufügt.

1. Erstellen Sie eine Instanz der Presentation-Klasse.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) Form in die zugegriffene Folie hinzu.
1. Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt-Form zu.
1. Fügen Sie nun den [**Unterknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Knoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) an Position 2 hinzu und setzen Sie seinen Text.
1. Speichern Sie die Präsentation.

```java
// Erstellen einer Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Zugriff auf die Präsentationsfolie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen von Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Hinzufügen eines neuen Unterknotens an Position 2 im übergeordneten Knoten
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Text hinzufügen
    chNode.getTextFrame().setText("Beispielftext hinzugefügt");

    // Speichern der Präsentation
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugriff auf SmartArt-Knoten in PowerPoint-Präsentation mit Java**
Der folgende Beispielcode hilft Ihnen, auf Knoten innerhalb einer SmartArt-Form zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die SmartArt-Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form in [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Durchlaufen Sie alle [**Knoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt-Form.
1. Greifen Sie auf Informationen wie SmartArt-Knotenposition, Ebene und Text zu und zeigen Sie sie an.

```java
// Instanziieren der Präsentationsklasse
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Erhalten der ersten Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Die Form in SmartArt typisieren
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen Sie alle Knoten innerhalb der SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf den SmartArt-Knoten bei Index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Drucken der Parameter des SmartArt-Knotens
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugriff auf SmartArt-Unterknoten**
Der folgende Beispielcode hilft Ihnen, auf die untergeordneten Knoten zuzugreifen, die zu den jeweiligen Knoten der SmartArt-Form gehören.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form in [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Durchlaufen Sie alle [**Knoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt-Form.
1. Für jeden ausgewählten SmartArt-Form [**Knoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) durchlaufen Sie alle [**Unterknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) innerhalb eines bestimmten Knotens.
1. Greifen Sie auf Informationen wie [**Unterknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text zu und zeigen Sie sie an.

```java
// Instanziieren der Präsentationsklasse
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Erhalten der ersten Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Die Form in SmartArt typisieren
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen Sie alle Knoten innerhalb der SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf den SmartArt-Knoten bei Index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Durchlaufen der untergeordneten Knoten im SmartArt-Knoten bei Index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Zugriff auf den Unterknoten im SmartArt-Knoten
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Drucken der Parameter des SmartArt-Unterknotens
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Ebene = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugriff auf SmartArt-Unterknoten an spezifischer Position**
In diesem Beispiel lernen wir, wie man auf die untergeordneten Knoten an einer bestimmten Position zugreift, die zu den jeweiligen Knoten der SmartArt-Form gehören.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) Typ SmartArt-Form hinzu.
1. Greifen Sie auf die hinzugefügte SmartArt-Form zu.
1. Greifen Sie auf den Knoten bei Index 0 für die zugegriffene SmartArt-Form zu.
1. Nun, greifen Sie auf den [**Unterknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 für den zugegriffenen SmartArt-Knoten mit der Methode **get_Item()** zu.
1. Greifen Sie auf Informationen wie [**Unterknoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) Position, Ebene und Text zu und zeigen Sie sie an.

```java
// Instanziieren der Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen der SmartArt-Form in die erste Folie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Zugriff auf den SmartArt-Knoten bei Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Zugriff auf den Unterknoten an Position 1 im übergeordneten Knoten
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Drucken der Parameter des SmartArt-Unterknotens
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Ebene = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Entfernen von SmartArt-Knoten in PowerPoint-Präsentationen mit Java**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb einer SmartArt-Form entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form in [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Überprüfen Sie, ob die [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) mehr als 0 Knoten hat.
1. Wählen Sie den SmartArt-Knoten aus, der gelöscht werden soll.
1. Entfernen Sie nun den ausgewählten Knoten mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Speichern Sie die Präsentation.

```java
// Laden der gewünschten Präsentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Die Form in SmartArt typisieren
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
    
    // Speichern der Präsentation
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Entfernen von SmartArt-Knoten an spezifischer Position**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb einer SmartArt-Form an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erlangen Sie das Referenz zur ersten Folie mithilfe ihres Index.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form in [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Wählen Sie den SmartArt-Form-Knoten bei Index 0 aus.
1. Überprüfen Sie nun, ob der ausgewählte SmartArt-Knoten mehr als 2 untergeordnete Knoten hat.
1. Entfernen Sie nun den Knoten an **Position 1** mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) Methode.
1. Speichern Sie die Präsentation.

```java
// Laden der gewünschten Präsentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Die Form in SmartArt typisieren
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
    
    // Speichern der Präsentation
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Benutzerdefinierte Position für Unterknoten in SmartArt festlegen**
Jetzt unterstützt Aspose.Slides für Android über Java die Festlegung der [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-) Eigenschaften. Der folgende Codeausschnitt zeigt, wie man die benutzerdefinierte SmartArtShape-Position, -Größe und -Drehung festlegt. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht. Außerdem können Benutzer mit benutzerdefinierten Positionseinstellungen die Knoten gemäß ihren Anforderungen einstellen.

```java
// Instanziieren der Präsentationsklasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);
    
    // Bewege die SmartArt-Form zu einer neuen Position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Ändere die Breiten der SmartArt-Form
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Ändere die Höhe der SmartArt-Form
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Ändere die Drehung der SmartArt-Form
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Assistenten-Knoten überprüfen**
{{% alert color="primary" %}} 

In diesem Artikel werden wir die Funktionen der SmartArt-Formen weiter untersuchen, die programmgesteuert in Präsentationsfolien mit Aspose.Slides für Android über Java hinzugefügt wurden.

{{% /alert %}} 

Wir werden die folgende Quell-SmartArt-Form für unsere Untersuchung in verschiedenen Abschnitten dieses Artikels verwenden.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Quell-SmartArt-Form in der Folie**|

Im folgenden Beispielcode werden wir untersuchen, wie man **Assistenten-Knoten** in der Sammlung von SmartArt-Knoten identifiziert und sie ändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erlangen Sie das Referenz zur zweiten Folie mithilfe ihres Index.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form in [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form und überprüfen Sie, ob sie [**Assistenten-Knoten**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) sind.
1. Ändern Sie den Status des Assistenten-Knotens in einen normalen Knoten.
1. Speichern Sie die Präsentation.

```java
// Erstellen einer Präsentationsinstanz
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Durchlaufen Sie jede Form innerhalb der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Die Form in SmartArt typisieren
            ISmartArt smart = (SmartArt) shape;
    
            // Durchlaufen Sie alle Knoten der SmartArt-Form
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Überprüfen Sie, ob der Knoten ein Assistentenknoten ist
                if (node.isAssistant()) 
                {
                    // Setzen Sie den Assistenten-Knoten auf falsch und machen Sie ihn zu einem normalen Knoten
                    node.isAssistant();
                }
            }
        }
    }
    
    // Speichern der Präsentation
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Abbildung: Assistenten-Knoten in der SmartArt-Form innerhalb der Folie geändert**|

## **Festlegen des Füllformats eines Knotens**
Aspose.Slides für Android über Java ermöglicht es, benutzerdefinierte SmartArt-Formen hinzuzufügen und deren Füllformat festzulegen. Dieser Artikel erklärt, wie man SmartArt-Formen erstellt und darauf zugreift sowie das Füllformat mit Aspose.Slides für Android über Java festlegt.

Bitte folgen Sie den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse.
1. Erlangen Sie das Referenz zu einer Folie mithilfe ihres Index.
1. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) -Form hinzu, indem Sie ihren [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
1. Legen Sie das [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) für die SmartArt-Formknoten fest.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```java
// Instanziieren der Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen von SmartArt-Form und Knoten
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Einige Texte");
    
    // Festlegen der Füllfarbe des Knotens
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Speichern der Präsentation
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thumbnail des SmartArt-Unterknotens generieren**
Entwickler können ein Thumbnail des Unterknotens einer SmartArt generieren, indem sie die folgenden Schritte befolgen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) -Klasse.
1. [Fügen Sie SmartArt hinzu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Erlangen Sie das Referenz zu einem Knoten mithilfe seines Index.
1. Holen Sie das Thumbnail-Bild.
1. Speichern Sie das Thumbnail-Bild in jedem gewünschten Bildformat.

```java
// Instanziieren der Präsentationsklasse, die die PPTX-Datei darstellt 
Presentation pres = new Presentation();
try {
    // Hinzufügen von SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Erlangen Sie das Referenz zu einem Knoten mithilfe seines Index  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Holen Sie das Thumbnail
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Speichern des Thumbnails
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```