---
title: Erstellen oder Verwalten von PowerPoint SmartArt Formknoten in Java
linktitle: SmartArt Formknoten verwalten
type: docs
weight: 30
url: /java/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart knoten, smartart position, smartart entfernen, smartart knoten hinzufügen, powerpoint präsentation, powerpoint java, powerpoint java api
description: Verwalten Sie SmartArt-Knoten und Kindknoten in PowerPoint-Präsentationen in Java
---

## **Fügen Sie einen SmartArt-Knoten in eine PowerPoint-Präsentation mit Java hinzu**
Aspose.Slides für Java hat die einfachste API bereitgestellt, um SmartArt-Formen auf die einfachste Weise zu verwalten. Der folgende Beispielcode hilft, Knoten und Kindknoten innerhalb der SmartArt-Form hinzuzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und typecasten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
1. [Fügen Sie einen neuen Knoten](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) in die SmartArt-Form [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) hinzu und setzen Sie den Text im TextFrame.
1. Jetzt [fügen Sie](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) einen [**Kindknoten**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) im neu hinzugefügten [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) Knoten hinzu und setzen Sie den Text im TextFrame.
1. Speichern Sie die Präsentation.

```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Typecasten Sie die Form zu SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Einen neuen SmartArt-Knoten hinzufügen
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Text hinzufügen
            TemNode.getTextFrame().setText("Test");
    
            // Neuen Kindknoten im übergeordneten Knoten hinzufügen. Er wird am Ende der Sammlung hinzugefügt
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Text hinzufügen
            newNode.getTextFrame().setText("Neuer Knoten hinzugefügt");
        }
    }
    
    // Präsentation speichern
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Fügen Sie einen SmartArt-Knoten an einer bestimmten Position hinzu**
Im folgenden Beispielcode haben wir erklärt, wie man die Kindknoten, die zu den jeweiligen Knoten der SmartArt-Form gehören, an einer bestimmten Position hinzufügt.

1. Erstellen Sie eine Instanz der Presentation-Klasse.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) Form in die aufgerufene Folie hinzu.
1. Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt-Form zu.
1. Jetzt fügen Sie den [**Kindknoten**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Knoten**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) an Position 2 hinzu und setzen Sie seinen Text.
1. Speichern Sie die Präsentation.

```java
// Erstellen Sie eine Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Zugriff auf die Präsentationsfolie
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape hinzufügen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Zugriff auf den SmartArt-Knoten an Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Neuen Kindknoten an Position 2 im übergeordneten Knoten hinzufügen
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Text hinzufügen
    chNode.getTextFrame().setText("Beispieltext hinzugefügt");

    // Präsentation speichern
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Greifen Sie auf SmartArt-Knoten in einer PowerPoint-Präsentation mithilfe von Java zu**
Der folgende Beispielcode hilft, auf Knoten innerhalb der SmartArt-Form zuzugreifen. Bitte beachten Sie, dass Sie den Layouttyp der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt-Form festgelegt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und typecasten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
1. Durchlaufen Sie alle [**Knoten**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt-Form.
1. Greifen Sie auf Informationen wie die Position, den Level und den Text des SmartArt-Knotens zu und zeigen Sie diese an.

```java
// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form auf SmartArt typecasten
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen Sie alle Knoten in der SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf den SmartArt-Knoten an Index i
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

## **Greifen Sie auf SmartArt-Kindknoten zu**
Der folgende Beispielcode hilft, auf die Kindknoten zuzugreifen, die den jeweiligen Knoten der SmartArt-Form angehören.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und typecasten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
1. Durchlaufen Sie alle [**Knoten**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt-Form.
1. Für jeden ausgewählten SmartArt-Form [**Knoten**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) durchlaufen Sie alle [**Kindknoten**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) innerhalb des bestimmten Knotens.
1. Greifen Sie auf Informationen wie die Position, den Level und den Text des [**Kindknotens**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) zu und zeigen Sie diese an.

```java
// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Form auf SmartArt typecasten
            ISmartArt smart = (ISmartArt) shape;
    
            // Durchlaufen Sie alle Knoten in der SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Zugriff auf den SmartArt-Knoten an Index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Durchlaufen der Kindknoten im SmartArt-Knoten an Index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Zugriff auf den Kindknoten im SmartArt-Knoten
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Drucken der Parameter des SmartArt-Kindknotens
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Greifen Sie auf SmartArt-Kindknoten an einer bestimmten Position zu**
In diesem Beispiel erfahren wir, wie man auf die Kindknoten an einer bestimmten Position zugreifen kann, die zu den jeweiligen Knoten der SmartArt-Form gehören.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) Typ SmartArt-Form hinzu.
1. Greifen Sie auf die hinzugefügte SmartArt-Form zu.
1. Greifen Sie auf den Knoten an Index 0 für die aufgerufene SmartArt-Form zu.
1. Jetzt weisen Sie den [**Kindknoten**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 für den aufgerufenen SmartArt-Knoten mithilfe der **get_Item()** Methode zu.
1. Greifen Sie auf Informationen wie die Position, den Level und den Text des [**Kindknotens**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) zu und zeigen Sie diese an.

```java
// Instanziieren der Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen der SmartArt-Form in die erste Folie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Zugriff auf den SmartArt-Knoten an Index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Zugriff auf den Kindknoten an Position 1 im übergeordneten Knoten
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Drucken der Parameter des SmartArt-Kindknotens
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Entfernen Sie einen SmartArt-Knoten in einer PowerPoint-Präsentation mithilfe von Java**
In diesem Beispiel erfahren wir, wie man die Knoten innerhalb der SmartArt-Form entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und typecasten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
1. Überprüfen Sie, ob die [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) mehr als 0 Knoten hat.
1. Wählen Sie den SmartArt-Knoten aus, der gelöscht werden soll.
1. Jetzt entfernen Sie den ausgewählten Knoten mit der [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) Methode.
1. Speichern Sie die Präsentation.

```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Typecasten Sie die Form zu SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf den SmartArt-Knoten an Index 0
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

## **Entfernen Sie einen SmartArt-Knoten an einer bestimmten Position**
In diesem Beispiel erfahren wir, wie man die Knoten innerhalb der SmartArt-Form an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist, und typecasten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
1. Wählen Sie den SmartArt-Formknoten an Index 0 aus.
1. Überprüfen Sie, ob der ausgewählte SmartArt-Knoten mehr als 2 Kindknoten hat.
1. Entfernen Sie nun den Knoten an **Position 1** mit der [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) Methode.
1. Speichern Sie die Präsentation.

```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof SmartArt) 
        {
            // Typecasten Sie die Form zu SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Zugriff auf den SmartArt-Knoten an Index 0
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

## **Setzen Sie die benutzerdefinierte Position für den Kindknoten in SmartArt**
Jetzt unterstützt Aspose.Slides für Java das Festlegen der [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-) Eigenschaften. Der folgende Codeausschnitt zeigt, wie Sie die benutzerdefinierte SmartArtShape-Position, Größe und Drehung festlegen können. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht. Auch mit benutzerdefinierten Positionseinstellungen kann der Benutzer die Knoten nach seinen Anforderungen anpassen.

```java
// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Bewegen Sie die SmartArt-Form an eine neue Position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Ändern Sie die Breiten der SmartArt-Form
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Ändern Sie die Höhe der SmartArt-Form
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Ändern Sie die Drehung der SmartArt-Form
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Überprüfen Sie den Assistenten-Knoten**
{{% alert color="primary" %}} 

In diesem Artikel werden wir die Funktionen von SmartArt-Formen, die programmatisch in Präsentationsfolien mit Aspose.Slides für Java hinzugefügt wurden, weiter untersuchen.

{{% /alert %}} 

Wir werden die folgende Quell-SmartArt-Form für unsere Untersuchung in verschiedenen Abschnitten dieses Artikels verwenden.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Quell-SmartArt-Form in der Folie**|

Im folgenden Beispielcode werden wir untersuchen, wie man **Assistenten-Knoten** in der SmartArt-Knoten Sammlung identifiziert und ändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz zur zweiten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) ist und typecasten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), falls es sich um SmartArt handelt.
1. Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form und überprüfen Sie, ob sie [**Assistenten-Knoten**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--) sind.
1. Ändern Sie den Status des Assistenten-Knotens in einen normalen Knoten.
1. Speichern Sie die Präsentation.

```java
// Erstellen Sie eine Präsentationsinstanz
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Typecasten Sie die Form zu SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Durchlauf durch alle Knoten der SmartArt-Form
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Überprüfen Sie, ob der Knoten ein Assistentenknoten ist
                if (node.isAssistant()) 
                {
                    // Setzen Sie den Assistenten-Knoten auf false und machen Sie ihn zu einem normalen Knoten
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
|**Abbildung: Assistenten-Knoten in der SmartArt-Form innerhalb der Folie geändert**|

## **Setzen Sie das Füllformat des Knotens**
Aspose.Slides für Java macht es möglich, benutzerdefinierte SmartArt-Formen hinzuzufügen und deren Füllformat festzulegen. Dieser Artikel erklärt, wie Sie SmartArt-Formen erstellen und darauf zugreifen sowie deren Füllformat mit Aspose.Slides für Java festlegen.

Bitte folgen Sie den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz zu einer Folie mithilfe ihres Index.
1. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) Form hinzu, indem Sie ihren [**Layouttyp**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
1. Setzen Sie das [**Füllformat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) für die SmartArt-Knoten.
1. Schreiben Sie die bearbeitete Präsentation als PPTX-Datei.

```java
// Instanziieren der Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen der SmartArt-Form und -Knoten
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Einige Texte");
    
    // Setzen der Knotenfüllfarbe
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

## **Thumbnail eines SmartArt-Kindknotens generieren**
Entwickler können ein Thumbnail eines Kindknotens von einer SmartArt erstellen, indem sie die folgenden Schritte durchführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. [Fügen Sie SmartArt hinzu](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Erhalten Sie die Referenz zu einem Knoten, indem Sie seinen Index verwenden.
1. Holen Sie das Thumbnail-Bild.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```java
// Instanziieren der Präsentationsklasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // SmartArt hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Erhalten Sie die Referenz zu einem Knoten, indem Sie seinen Index verwenden  
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