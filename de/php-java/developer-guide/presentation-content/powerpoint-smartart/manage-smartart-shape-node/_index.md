---
title: Erstellen oder Verwalten von PowerPoint SmartArt Formknoten
linktitle: SmartArt Formknoten verwalten
type: docs
weight: 30
url: /de/php-java/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart knoten, smartart position, smartart entfernen, smartart knoten hinzufügen, powerpoint präsentation, powerpoint java, powerpoint java api
description: Verwalten Sie den SmartArt-Knoten und den untergeordneten Knoten in PowerPoint-Präsentationen
---

## **SmartArt-Knoten in PowerPoint-Präsentation mit PHP hinzufügen**
Aspose.Slides für PHP über Java hat die einfachste API bereitgestellt, um die SmartArt-Formen auf die einfachste Weise zu verwalten. Der folgende Beispielcode hilft dabei, Knoten und untergeordnete Knoten innerhalb der SmartArt-Form hinzuzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form, wenn es sich um SmartArt handelt.
1. [Fügen Sie einen neuen Knoten](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) in die SmartArt-Form [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) hinzu und setzen Sie den Text im TextFrame.
1. Nun, [fügen Sie](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) einen [**untergeordneten Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) in den neu hinzugefügten [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) Knoten ein und setzen Sie den Text im TextFrame.
1. Speichern Sie die Präsentation.

```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Durchlaufen Sie jede Form innerhalb der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfen Sie, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typisieren Sie die Form als SmartArt
        $smart = $shape;
        # Hinzufügen eines neuen SmartArt-Knotens
        $TemNode = $smart->getAllNodes()->addNode();
        # Hinzufügen von Text
        $TemNode->getTextFrame()->setText("Test");
        # Hinzufügen eines neuen untergeordneten Knotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
        $newNode = $TemNode->getChildNodes()->addNode();
        # Hinzufügen von Text
        $newNode->getTextFrame()->setText("Neuer Knoten hinzugefügt");
      }
    }
    # Speichern der Präsentation
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt-Knoten an bestimmter Position hinzufügen**
Im folgenden Beispielcode erklären wir, wie man die untergeordneten Knoten, die zu den jeweiligen Knoten der SmartArt-Form gehören, an einer bestimmten Position hinzufügt.

1. Erstellen Sie eine Instanz der Presentation-Klasse.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Form in die angeforderte Folie ein.
1. Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt-Form zu.
1. Fügen Sie nun den [**untergeordneten Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) für den ausgewählten [**Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) an der Position 2 hinzu und setzen Sie dessen Text.
1. Speichern Sie die Präsentation.

```php
  # Erstellung einer Präsentationsinstanz
  $pres = new Presentation();
  try {
    # Zugriff auf die Präsentationsfolie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen einer Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Zugriff auf den SmartArt-Knoten unter dem Index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Hinzufügen eines neuen untergeordneten Knotens an Position 2 im übergeordneten Knoten
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Text hinzufügen
    $chNode->getTextFrame()->setText("Hinzugefügter Beispieltext");
    # Präsentation speichern
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zugriff auf SmartArt-Knoten in PowerPoint-Präsentation mit PHP**
Der folgende Beispielcode hilft Ihnen beim Zugriff auf Knoten innerhalb der SmartArt-Form. Bitte beachten Sie, dass Sie den LayoutTyp der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt-Form festgelegt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Durchlaufen Sie alle [**Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt-Form.
1. Greifen Sie auf Informationen wie SmartArt-Knotenposition, Ebene und Text zu und zeigen Sie sie an.

```php
  # Instanziieren der Präsentationsklasse
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufen Sie jede Form in der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Überprüfen Sie, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typisieren Sie die Form als SmartArt
        $smart = $shape;
        # Durchlaufen Sie alle Knoten innerhalb der SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Zugriff auf den SmartArt-Knoten unter dem Index i
          $node = $smart->getAllNodes()->get_Item($i);
          # Drucken der SmartArt-Knotenparameter
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

## **Zugriff auf SmartArt-Unterknoten**
Der folgende Beispielcode hilft Ihnen beim Zugriff auf die untergeordneten Knoten, die zu den jeweiligen Knoten der SmartArt-Form gehören.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Durchlaufen Sie alle [**Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) innerhalb der SmartArt-Form.
1. Für jeden ausgewählten SmartArt-Form [**Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) durchlaufen Sie alle [**untergeordneten Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) innerhalb des jeweiligen Knotens.
1. Greifen Sie auf Informationen wie die Position, Ebene und den Text des [**untergeordneten Knotens**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) zu und zeigen Sie diese an.

```php
  # Instanziieren der Präsentationsklasse
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufen Sie jede Form in der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Überprüfen Sie, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typisieren Sie die Form als SmartArt
        $smart = $shape;
        # Durchlaufen Sie alle Knoten innerhalb der SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Zugriff auf den SmartArt-Knoten unter dem Index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Durchlaufen der untergeordneten Knoten im SmartArt-Knoten unter dem Index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
            $node = $node0->getChildNodes()->get_Item($j);
            # Drucken der SmartArt-Unterknotenparameter
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Ebene = " . $node->getLevel() . ", Position = " . $node->getPosition());
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

## **Zugriff auf SmartArt-Unterknoten an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man die untergeordneten Knoten an einer bestimmten Position, die zu den jeweiligen Knoten der SmartArt-Form gehören, aufruft.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) Typ SmartArt-Form hinzu.
1. Greifen Sie auf die hinzugefügte SmartArt-Form zu.
1. Greifen Sie auf den Knoten unter dem Index 0 für die angeforderte SmartArt-Form zu.
1. Greifen Sie nun auf den [**untergeordneten Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) an der Position 1 für den angeforderten SmartArt-Knoten unter Verwendung der **get_Item()**-Methode zu.
1. Greifen Sie auf Informationen wie die Position, Ebene und den Text des [**untergeordneten Knotens**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) zu und zeigen Sie diese an.

```php
  # Instanziieren der Präsentation
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen der SmartArt-Form in die erste Folie
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Zugriff auf den SmartArt-Knoten unter dem Index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Zugriff auf den untergeordneten Knoten an Position 1 im übergeordneten Knoten
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Drucken der SmartArt-Unterknotenparameter
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Ebene = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Entfernen des SmartArt-Knotens in der PowerPoint-Präsentation mit PHP**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb der SmartArt-Form entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Überprüfen Sie, ob die [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) mehr als 0 Knoten enthält.
1. Wählen Sie den zu löschenden SmartArt-Knoten aus.
1. Entfernen Sie nun den ausgewählten Knoten mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Speichern Sie die Präsentation.

```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Durchlaufen Sie jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfen Sie, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typisieren Sie die Form als SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Zugriff auf den SmartArt-Knoten unter dem Index 0
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

## **Entfernen des SmartArt-Knotens an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb der SmartArt-Form an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie das Referenzobjekt der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Wählen Sie den SmartArt-Formknoten unter dem Index 0 aus.
1. Überprüfen Sie nun, ob der ausgewählte SmartArt-Knoten mehr als 2 untergeordnete Knoten enthält.
1. Entfernen Sie nun den Knoten an **Position 1** mit der Methode [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Speichern Sie die Präsentation.

```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Durchlaufen Sie jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfen Sie, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typisieren Sie die Form als SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Zugriff auf den SmartArt-Knoten unter dem Index 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Entfernen des untergeordneten Knotens an Position 1
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

## **Benutzerdefinierte Position für den untergeordneten Knoten in SmartArt festlegen**
Jetzt unterstützt Aspose.Slides für PHP über Java das Festlegen der [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) und [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-) Eigenschaften. Der folgende Codeausschnitt zeigt, wie man die benutzerdefinierte SmartArtShape-Position, Größe und Drehung festlegt. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neubewertung der Positionen und Größen aller Knoten verursacht. Auch mit benutzerdefinierten Positionseinstellungen kann der Benutzer die Knoten nach den Anforderungen festlegen.

```php
  # Instanziieren der Präsentationsklasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Bewegen Sie die SmartArt-Form an eine neue Position
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Ändern der Breite der SmartArt-Form
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() + $shape->getWidth() * 2);
    # Ändern der Höhe der SmartArt-Form
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() + $shape->getHeight() * 2);
    # Ändern der Drehung der SmartArt-Form
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Assistenten-Knoten überprüfen**
{{% alert color="primary" %}} 

In diesem Artikel werden wir weitere Funktionen von SmartArt-Formen untersuchen, die programmgesteuert zu Präsentationsfolien mit Aspose.Slides für PHP über Java hinzugefügt wurden.

{{% /alert %}} 

Wir werden die folgende Quell-SmartArt-Form für unsere Untersuchungen in verschiedenen Abschnitten dieses Artikels verwenden.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Quell-SmartArt-Form in der Folie**|

Im folgenden Beispielcode werden wir untersuchen, wie man **Assistenten-Knoten** in der SmartArt-Knoten-Sammlung identifiziert und sie ändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie das Referenzobjekt der zweiten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form der ersten Folie.
1. Überprüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) ist und typisieren Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), wenn es sich um SmartArt handelt.
1. Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form und überprüfen Sie, ob sie [**Assistenten-Knoten**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--) sind.
1. Ändern Sie den Status des Assistenten-Knotens in einen normalen Knoten.
1. Speichern Sie die Präsentation.

```php
  # Erstellung einer Präsentationsinstanz
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Durchlaufen Sie jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfen Sie, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typisieren Sie die Form als SmartArt
        $smart = $shape;
        # Durchlaufen Sie alle Knoten der SmartArt-Form
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Überprüfen Sie, ob der Knoten ein Assistenten-Knoten ist
          if ($node->isAssistant()) {
            # Setzen des Assistenten-Knotens auf false und umwandeln in einen normalen Knoten
            $node->isAssistant(false);
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
|**Abbildung: Assistenten-Knoten in der SmartArt-Form innerhalb der Folie geändert**|

## **Festlegen des Füllformats des Knotens**
Aspose.Slides für PHP über Java ermöglicht es, benutzerdefinierte SmartArt-Formen hinzuzufügen und deren Füllformat festzulegen. Dieser Artikel erklärt, wie man SmartArt-Formen erstellt und darauf zugreift sowie deren Füllformat mit Aspose.Slides für PHP über Java festlegt.

Bitte folgen Sie den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie das Referenzobjekt einer Folie anhand ihres Index.
1. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) Form hinzu, indem Sie ihren [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) festlegen.
1. Legen Sie das [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) für die SmartArt-Formknoten fest.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```php
  # Instanziieren der Präsentation
  $pres = new Presentation();
  try {
    # Zugriff auf die Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen der SmartArt-Form und Knoten
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Einige Texte");
    # Festlegen der Knotenfüllfarbe
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

## **Thumbnail des SmartArt-Unterknotens generieren**
Entwickler können ein Thumbnail des untergeordneten Knotens einer SmartArt erstellen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. [Fügen Sie SmartArt hinzu](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
1. Erhalten Sie das Referenzobjekt eines Knotens anhand seines Index.
1. Holen Sie das Thumbnail-Bild.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```php
  # Instanziieren der Präsentationsklasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # SmartArt hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Erhalten Sie das Referenzobjekt eines Knotens anhand seines Index
    $node = $smart->getNodes()->get_Item(1);
    # Holen Sie sich das Thumbnail
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Speichern Sie das Thumbnail
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