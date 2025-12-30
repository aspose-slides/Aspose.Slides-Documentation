---
title: SmartArt-Formknoten in Präsentationen mit PHP verwalten
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/php-java/manage-smartart-shape-node/
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
- PHP
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT und PPTX mit Aspose.Slides für PHP via Java. Erhalten Sie klare Codebeispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides for PHP via Java bietet die einfachste API, um SmartArt‑Objekte auf einfachste Weise zu verwalten. Der nachstehende Beispielcode hilft dabei, einen Knoten und einen untergeordneten Knoten innerhalb eines SmartArt‑Objekts hinzuzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Durchlaufen Sie jede Form auf der ersten Folie.  
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form bei Bedarf zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) um.  
1. [Add a new Node](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) in die SmartArt‑Form [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) ein und setzen Sie den Text im TextFrame.  
1. Jetzt, [Add](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) einen [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) im neu hinzugefügten [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)‑Knoten und setzen Sie den Text im TextFrame.  
1. Speichern Sie die Präsentation.  
```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Durchlaufen Sie jede Form auf der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Prüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Shape zu SmartArt casten
        $smart = $shape;
        # Einen neuen SmartArt-Knoten hinzufügen
        $TemNode = $smart->getAllNodes()->addNode();
        # Text hinzufügen
        $TemNode->getTextFrame()->setText("Test");
        # Neuen Unterknoten im Elternknoten hinzufügen. Er wird am Ende der Sammlung hinzugefügt
        $newNode = $TemNode->getChildNodes()->addNode();
        # Text hinzufügen
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Präsentation speichern
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie Unterknoten zu den jeweiligen Knoten eines SmartArt‑Objekts an einer bestimmten Position hinzugefügt werden.

1. Erstellen Sie eine Instanz der Klasse Presentation.  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Fügen Sie der aufgerufenen Folie ein [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList)-Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)‑Objekt hinzu.  
1. Greifen Sie auf den ersten Knoten im hinzugefügten SmartArt‑Objekt zu.  
1. Jetzt fügen Sie den [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) an Position 2 hinzu und setzen dessen Text.  
1. Speichern Sie die Präsentation.  
```php
  # Erstellen einer Präsentationsinstanz
  $pres = new Presentation();
  try {
    # Zugriff auf die Präsentationsfolie
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt IShape hinzufügen
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Zugriff auf den SmartArt-Knoten bei Index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Neuen Unterknoten an Position 2 im übergeordneten Knoten hinzufügen
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Text hinzufügen
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Präsentation speichern
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zugriff auf einen SmartArt‑Knoten**
Der folgende Beispielcode hilft beim Zugriff auf Knoten innerhalb eines SmartArt‑Objekts. Bitte beachten Sie, dass Sie den LayoutType des SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn das SmartArt‑Objekt hinzugefügt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Durchlaufen Sie jede Form auf der ersten Folie.  
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form bei Bedarf zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) um.  
1. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) innerhalb des SmartArt‑Objekts.  
1. Greifen Sie zu und zeigen Sie Informationen wie die Position, Ebene und den Text des SmartArt‑Knotens an.  
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Erste Folie holen
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufen jeder Form in der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Prüfen, ob Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Durchlaufen aller Knoten in SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Zugriff auf SmartArt-Knoten bei Index i
          $node = $smart->getAllNodes()->get_Item($i);
          # Ausgabe der SmartArt-Knotenparameter
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zugriff auf einen SmartArt‑Unterknoten**
Der folgende Beispielcode hilft beim Zugriff auf die Unterknoten, die zu den jeweiligen Knoten eines SmartArt‑Objekts gehören.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Durchlaufen Sie jede Form auf der ersten Folie.  
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form bei Bedarf zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) um.  
1. Durchlaufen Sie alle [**Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) innerhalb des SmartArt‑Objekts.  
1. Für jeden ausgewählten SmartArt‑Knoten [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) durchlaufen Sie alle [**Child Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) innerhalb des jeweiligen Knotens.  
1. Greifen Sie zu und zeigen Sie Informationen wie die Position, Ebene und den Text des [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) an.  
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Erste Folie holen
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufen jeder Form in der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Prüfen, ob Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Durchlaufen aller Knoten in SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Zugriff auf SmartArt-Knoten bei Index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Durchlaufen der Kindknoten im SmartArt-Knoten bei Index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Zugriff auf den Kindknoten im SmartArt-Knoten
            $node = $node0->getChildNodes()->get_Item($j);
            # Ausgabe der SmartArt-Kindknoten-Parameter
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zugriff auf einen SmartArt‑Unterknoten an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man die Unterknoten an einer bestimmten Position, die zu den jeweiligen Knoten eines SmartArt‑Objekts gehören, abruft.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Fügen Sie ein [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList)-Typ SmartArt‑Objekt hinzu.  
1. Greifen Sie auf das hinzugefügte SmartArt‑Objekt zu.  
1. Greifen Sie auf den Knoten mit Index 0 des aufgerufenen SmartArt‑Objekts zu.  
1. Jetzt greifen Sie mithilfe der Methode **get_Item()** auf den [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) an Position 1 des aufgerufenen SmartArt‑Knotens zu.  
1. Greifen Sie zu und zeigen Sie Informationen wie die Position, Ebene und den Text des [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) an.  
```php
  # Instanziieren der Präsentation
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen der SmartArt-Form in der ersten Folie
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Zugriff auf den SmartArt-Knoten bei Index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Zugriff auf den Unterknoten bei Position 1 im übergeordneten Knoten
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Ausgabe der SmartArt-Kindknoten-Parameter
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Entfernen eines SmartArt‑Knotens**
In diesem Beispiel lernen wir, wie man Knoten innerhalb eines SmartArt‑Objekts entfernt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Durchlaufen Sie jede Form auf der ersten Folie.  
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form bei Bedarf zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) um.  
1. Prüfen Sie, ob das [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) mehr als 0 Knoten enthält.  
1. Wählen Sie den zu löschenden SmartArt‑Knoten aus.  
1. Jetzt entfernen Sie den ausgewählten Knoten mithilfe der Methode [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .  
1. Speichern Sie die Präsentation.  
```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Durchlaufen Sie jede Form auf der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Prüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Zugriff auf SmartArt-Knoten bei Index 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Entfernen des ausgewählten Knotens
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Präsentation speichern
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Entfernen eines SmartArt‑Knotens von einer bestimmten Position**
In diesem Beispiel lernen wir, wie man Knoten innerhalb eines SmartArt‑Objekts an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.  
1. Holen Sie sich die Referenz der ersten Folie über deren Index.  
1. Durchlaufen Sie jede Form auf der ersten Folie.  
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form bei Bedarf zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) um.  
1. Wählen Sie den SmartArt‑Form‑Knoten mit Index 0 aus.  
1. Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten enthält.  
1. Jetzt entfernen Sie den Knoten an **Position 1** mithilfe der Methode [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) .  
1. Speichern Sie die Präsentation.  
```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Durchlaufen Sie jede Form auf der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Prüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Zugriff auf SmartArt-Knoten bei Index 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Entfernen des Kindknotens an Position 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Präsentation speichern
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Benutzerdefinierte Position für einen Unterknoten in einem SmartArt‑Objekt festlegen**
Jetzt unterstützt Aspose.Slides for PHP via Java das Setzen der [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape)-Eigenschaften [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-). Der nachstehende Code‑Snippet zeigt, wie man die benutzerdefinierte Position, Größe und Rotation eines SmartArtShape festlegt; beachten Sie zudem, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Mit benutzerdefinierten Positionseinstellungen kann der Benutzer die Knoten nach Bedarf anordnen.  
```php
  # Instanziieren der Präsentationsklasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt-Form an neue Position verschieben
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Breite der SmartArt-Form ändern
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Höhe der SmartArt-Form ändern
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Drehung der SmartArt-Form ändern
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Überprüfung eines Assistenten‑Knotens**
{{% alert color="primary" %}} 

In diesem Artikel werden wir die Funktionen von SmartArt‑Objekten, die programmgesteuert zu Präsentationsfolien mit Aspose.Slides für PHP via Java hinzugefügt wurden, weiter untersuchen.  
{{% /alert %}} 

Wir verwenden das folgende Quell‑SmartArt‑Objekt für unsere Untersuchungen in den verschiedenen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Quell‑SmartArt‑Form in Folie**|

Im folgenden Beispielcode untersuchen wir, wie **Assistenten‑Knoten** in der SmartArt‑Knotensammlung identifiziert und geändert werden können.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.  
1. Holen Sie sich die Referenz der zweiten Folie über deren Index.  
1. Durchlaufen Sie jede Form auf der ersten Folie.  
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist, und casten Sie die ausgewählte Form bei Bedarf zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) um.  
1. Durchlaufen Sie alle Knoten innerhalb des SmartArt‑Objekts und prüfen Sie, ob sie [**Assistant Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--) sind.  
1. Ändern Sie den Status des Assistenten‑Knotens zu einem normalen Knoten.  
1. Speichern Sie die Präsentation.  
```php
  # Präsentationsinstanz erstellen
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Durchlaufen jeder Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Prüfen, ob Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Durchlaufen aller Knoten des SmartArt-Objekts
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Prüfen, ob Knoten ein Assistent‑Knoten ist
          if ($node->isAssistant()) {
            # Assistent‑Knoten auf false setzen und zu einem normalen Knoten machen
            $node->isAssistant();
          }
        }
      }
    }
    # Präsentation speichern
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Abbildung: Geänderte Assistenten‑Knoten im SmartArt‑Objekt in der Folie**|

## **Füllformat eines Knotens festlegen**
Aspose.Slides for PHP via Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Objekte und das Festlegen ihres Füllformats. Dieser Artikel erklärt, wie SmartArt‑Objekte erstellt, darauf zugegriffen und ihr Füllformat mithilfe von Aspose.Slides for PHP via Java gesetzt wird.

Bitte folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Holen Sie sich die Referenz einer Folie über deren Index.  
1. Fügen Sie ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)-Objekt hinzu, indem Sie dessen [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.  
1. Setzen Sie das [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) für die Knoten des SmartArt‑Objekts.  
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  
```php
  # Instanziieren der Präsentation
  $pres = new Presentation();
  try {
    # Zugriff auf die Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen der SmartArt-Form und Knoten
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Festlegen der Füllfarbe des Knotens
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Präsentation speichern
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Erzeugen eines Miniaturbilds eines SmartArt‑Unterknotens**
Entwickler können ein Miniaturbild eines Unterknotens eines SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. [Add SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Holen Sie sich die Referenz eines Knotens über dessen Index.  
1. Erhalten Sie das Miniaturbild.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.  
```php
  # Instanziieren der Presentation-Klasse, die die PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # SmartArt hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Referenz eines Knotens über dessen Index erhalten
    $node = $smart->getNodes()->get_Item(1);
    # Miniaturbild erhalten
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Miniaturbild speichern
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/php-java/shape-animation/) (Eintritt, Austritt, Hervorhebung, Bewegungsbahnen) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?**

Weisen Sie ihm einen [alternativen Text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) zu und suchen Sie danach. Das Festlegen eines eindeutigen AltText für das SmartArt ermöglicht es, es programmgesteuert zu finden, ohne interne Kennungen zu verwenden.

**Wird das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF erhalten bleiben?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Genauigkeit beim [PDF‑Export](/slides/de/php-java/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschauen oder Berichte)?**

Ja. Sie können ein SmartArt‑Objekt in [Rasterformate](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) oder in [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) rendern, um skalierbare Vektor­ausgaben zu erhalten, was es für Miniaturbilder, Berichte oder Web‑Verwendung geeignet macht.