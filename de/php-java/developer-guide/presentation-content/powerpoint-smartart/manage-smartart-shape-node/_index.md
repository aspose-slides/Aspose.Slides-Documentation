---
title: SmartArt-Formknoten in Präsentationen mit PHP verwalten
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/php-java/manage-smartart-shape-node/
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
- PHP
- Aspose.Slides
description: "Verwalten Sie SmartArt‑Formknoten in PPT und PPTX mit Aspose.Slides für PHP via Java. Erhalten Sie klare Code‑Beispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides for PHP via Java stellt die einfachste API zum Verwalten von SmartArt‑Formen auf höchst unkomplizierte Weise bereit. Der folgende Beispielcode hilft, einen Knoten und Unterknoten innerhalb einer SmartArt‑Form hinzuzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)-Typ ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) um, falls es sich um SmartArt handelt.
1. [Fügen Sie einen neuen Knoten](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) in der SmartArt‑Form **NodeCollection** hinzu und setzen Sie den Text im TextFrame.
1. Nun [fügen Sie](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) einen **Unterknoten** in dem neu hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
1. Speichern Sie die Präsentation.
```php
  # Laden Sie die gewünschte Präsentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Durchlaufen Sie jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Prüfen, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Hinzufügen eines neuen SmartArt-Knotens
        $TemNode = $smart->getAllNodes()->addNode();
        # Text hinzufügen
        $TemNode->getTextFrame()->setText("Test");
        # Hinzufügen eines neuen Unterknotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
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
Im folgenden Beispielcode wird erklärt, wie Kindknoten zu den jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position hinzugefügt werden.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Fügen Sie in der zugegriffenen Folie eine SmartArt‑Form des Typs [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) hinzu.
1. Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
1. Fügen Sie nun den **Unterknoten** für den ausgewählten **Knoten** an Position 2 hinzu und setzen Sie dessen Text.
1. Speichern Sie die Präsentation.
```php
  # Erstellen einer Präsentationsinstanz
  $pres = new Presentation();
  try {
    # Zugriff auf die Präsentationsfolie
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape hinzufügen
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Zugriff auf den SmartArt-Knoten mit Index 0
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
Der folgende Beispielcode hilft beim Zugriff auf Knoten innerhalb einer SmartArt‑Form. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form gesetzt wird.

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) um, falls es sich um SmartArt handelt.
1. Durchlaufen Sie alle **Knoten** innerhalb der SmartArt‑Form.
1. Greifen Sie auf Informationen wie Position, Ebene und Text des SmartArt‑Knotens zu und zeigen Sie sie an.
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufen jeder Form auf der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Prüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Durchlaufen aller Knoten innerhalb von SmartArt
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
Der folgende Beispielcode hilft beim Zugriff auf die Unterknoten, die zu den jeweiligen Knoten einer SmartArt‑Form gehören.

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) um, falls es sich um SmartArt handelt.
1. Durchlaufen Sie alle **Knoten** innerhalb der SmartArt‑Form.
1. Für jeden ausgewählten SmartArt‑**Knoten** durchlaufen Sie alle **Unterknoten** innerhalb des jeweiligen Knotens.
1. Greifen Sie auf Informationen wie Position, Ebene und Text des **Unterknotens** zu und zeigen Sie sie an.
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufen jeder Form auf der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Prüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Durchlaufen aller Knoten innerhalb von SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Zugriff auf SmartArt-Knoten bei Index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Durchlaufen der Unterknoten im SmartArt-Knoten bei Index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Zugriff auf den Unterknoten im SmartArt-Knoten
            $node = $node0->getChildNodes()->get_Item($j);
            # Ausgabe der SmartArt-Unterknotenparameter
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
In diesem Beispiel lernen wir, wie man Unterknoten an bestimmten Positionen, die zu den jeweiligen Knoten einer SmartArt‑Form gehören, abruft.

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Fügen Sie eine SmartArt‑Form des Typs [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) hinzu.
1. Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
1. Greifen Sie auf den Knoten mit Index 0 für die zugegriffene SmartArt‑Form zu.
1. Greifen Sie nun mit der Methode **get_Item()** auf den **Unterknoten** an Position 1 für den zugegriffenen SmartArt‑Knoten zu.
1. Zeigen Sie Informationen wie Position, Ebene und Text des **Unterknotens** an.
```php
  # Instanziieren der Präsentation
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt-Form in der ersten Folie hinzufügen
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Zugriff auf SmartArt-Knoten bei Index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Zugriff auf den Unterknoten an Position 1 im übergeordneten Knoten
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Ausgabe der SmartArt-Unterknotenparameter
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Entfernen eines SmartArt‑Knotens**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form entfernt.

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) um, falls es sich um SmartArt handelt.
1. Prüfen Sie, ob das SmartArt mehr als 0 Knoten enthält.
1. Wählen Sie den zu löschenden SmartArt‑Knoten aus.
1. Entfernen Sie nun den ausgewählten Knoten mit der Methode [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Speichern Sie die Präsentation.
```php
  # Lade die gewünschte Präsentation
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Durchlaufe alle Formen in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Prüfe, ob die Form vom Typ SmartArt ist
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


## **Entfernen eines SmartArt‑Knotens an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt.

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Ermitteln Sie die Referenz der ersten Folie mittels ihres Index.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) um, falls es sich um SmartArt handelt.
1. Wählen Sie den SmartArt‑Formknoten mit Index 0 aus.
1. Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 Unterknoten enthält.
1. Entfernen Sie nun den Knoten an **Position 1** mit der Methode [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Speichern Sie die Präsentation.
```php
  # Lade die gewünschte Präsentation
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Durchlaufe jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Prüfe, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Zugriff auf SmartArt-Knoten bei Index 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Entfernen des Unterknotens an Position 1
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
Aspose.Slides for PHP via Java unterstützt das Festlegen der [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape)‑Eigenschaften [X](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setX) und [Y](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setY). Der nachstehende Code‑Abschnitt zeigt, wie man die benutzerdefinierte Position, Größe und Drehung einer SmartArtShape festlegt. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst. Mit benutzerdefinierten Positionseinstellungen kann der Benutzer die Knoten nach Bedarf anordnen.
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt-Form an neue Position verschieben
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt-Formbreiten ändern
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt-Formhöhe ändern
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt-Formdrehung ändern
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Assistant‑Knoten prüfen**
{{% alert color="primary" %}} 

In diesem Artikel untersuchen wir weitere Funktionen von SmartArt‑Formen, die programmgesteuert mittels Aspose.Slides for PHP via Java zu Präsentationsfolien hinzugefügt werden.

{{% /alert %}} 

Wir verwenden die folgende SmartArt‑Form als Ausgangsbasis für unsere Untersuchungen in den einzelnen Abschnitten dieses Artikels.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Abbildung: Ausgangs‑SmartArt‑Form in der Folie**|

Im folgenden Beispielcode untersuchen wir, wie **Assistant‑Knoten** in der SmartArt‑Knotensammlung identifiziert und geändert werden können.

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
1. Ermitteln Sie die Referenz der zweiten Folie mittels ihres Index.
1. Durchlaufen Sie jede Form auf der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) ist, und casten Sie die ausgewählte Form zu [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) um, falls es sich um SmartArt handelt.
1. Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie **Assistant‑Knoten** sind.
1. Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
1. Speichern Sie die Präsentation.
```php
  # Erstellen einer Präsentationsinstanz
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Durchlaufen jeder Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Prüfen, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArt casten
        $smart = $shape;
        # Durchlaufen aller Knoten der SmartArt-Form
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Prüfen, ob Knoten ein Assistant‑Knoten ist
          if ($node->isAssistant()) {
            # Assistant‑Knoten auf false setzen und in normalen Knoten umwandeln
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
|**Abbildung: Assistant‑Knoten in der SmartArt‑Form geändert**|

## **Füllformat eines Knotens festlegen**
Aspose.Slides for PHP via Java ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihres Füllformats. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt, zugegriffen und ihr Füllformat über Aspose.Slides for PHP via Java gesetzt wird.

Bitte folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Ermitteln Sie die Referenz einer Folie über deren Index.
1. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)-Form hinzu, indem Sie deren **LayoutType** festlegen.
1. Legen Sie das **Fill Format** für die Knoten der SmartArt‑Form fest.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
```php
  # Instanziieren der Präsentation
  $pres = new Presentation();
  try {
    # Zugriff auf die Folie
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt-Form und Knoten hinzufügen
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Füllfarbe des Knotens setzen
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


## **Thumbnail eines SmartArt‑Unterknotens generieren**
Entwickler können ein Thumbnail eines Unterknotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. [SmartArt hinzufügen](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode).
1. Ermitteln Sie die Referenz eines Knotens über dessen Index.
1. Holen Sie das Thumbnail‑Bild.
1. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.
```php
  # Instanziieren der Presentation-Klasse, die die PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # SmartArt hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Referenz eines Knotens über dessen Index erhalten
    $node = $smart->getNodes()->get_Item(1);
    # Thumbnail abrufen
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Thumbnail speichern
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

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/php-java/shape-animation/) (Einblenden, Ausblenden, Hervorheben, Bewegungsbahnen) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie finde ich zuverlässig ein bestimmtes SmartArt‑Element auf einer Folie, wenn seine interne ID unbekannt ist?**

Vergeben und suchen Sie nach [alternativem Text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). Das Setzen eines eindeutigen AltText auf das SmartArt ermöglicht ein programmgesteuertes Auffinden ohne interne Kennungen.

**Wird das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF erhalten?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF‑Exports](/slides/de/php-java/convert-powerpoint-to-pdf/), wodurch Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt‑Elements extrahieren (für Vorschaubilder oder Berichte)?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) oder in [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) rendern, um skalierbare Vektor‑Ausgaben zu erhalten – geeignet für Thumbnails, Berichte oder Web‑Verwendung.