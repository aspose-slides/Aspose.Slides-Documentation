---
title: SmartArt verwalten
type: docs
weight: 10
url: /php-java/manage-smartart/
---

## **Text aus SmartArt abrufen**
Jetzt wurde die TextFrame-Methode zur [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) Schnittstelle und zur [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) Klasse hinzugefügt. Diese Eigenschaft ermöglicht es Ihnen, gesamten Text aus [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) abzurufen, falls er nicht nur Knoten-Text enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten abzurufen.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Layouttyp von SmartArt ändern**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie durch ihren Index.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```php
  $pres = new Presentation();
  try {
    # Fügen Sie SmartArt BasicProcess hinzu
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # Ändern Sie den Layouttyp auf BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Präsentation speichern
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Versteckte Eigenschaft von SmartArt überprüfen**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu überprüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) Eigenschaft.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```php
  $pres = new Presentation();
  try {
    # Fügen Sie SmartArt BasicProcess hinzu
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Fügen Sie einen Knoten zu SmartArt hinzu
    $node = $smart->getAllNodes()->addNode();
    # Überprüfen Sie die isHidden-Eigenschaft
    $hidden = $node->isHidden();// Gibt true zurück

    if ($hidden) {
      # Führen Sie einige Aktionen oder Benachrichtigungen durch
    }
    # Präsentation speichern
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Organigrammtyp abrufen oder festlegen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen oder Setzen des Organigrammtyps, der mit dem aktuellen Knoten verbunden ist. Um den Organigrammtyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf die Folie hinzu.
- Abrufen oder [setzen Sie den Organigrammtyp](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```php
  $pres = new Presentation();
  try {
    # Fügen Sie SmartArt BasicProcess hinzu
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Organigrammtyp abrufen oder setzen
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Präsentation speichern
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bild-Organigramm erstellen**
Aspose.Slides für PHP über Java bietet eine einfache API zur Erstellung von Bild-Organigrammen auf einfache Weise. Um ein Diagramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie durch ihren Index.
1. Fügen Sie ein Diagramm mit standardmäßigen Daten zusammen mit dem gewünschten Typ (ChartType::PictureOrganizationChart) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.

```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt-Zustand abrufen oder festlegen**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Fügen Sie [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf die Folie hinzu.
1. [Holen Sie sich](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) oder [setzen Sie](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) den Zustand des SmartArt-Diagramms.
1. Schreiben Sie die Präsentation als PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.

```php
  # Instanziiere die Presentation-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Fügen Sie SmartArt BasicProcess hinzu
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Holen Sie sich oder setzen Sie den Zustand des SmartArt-Diagramms
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # Präsentation speichern
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```