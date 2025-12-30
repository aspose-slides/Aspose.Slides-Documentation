---
title: SmartArt in PowerPoint-Präsentationen mit PHP verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- versteckte Eigenschaft
- Organisationsdiagramm
- Bildorganisationsdiagramm
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für PHP via Java erstellen und bearbeiten, und nutzen Sie klare Code‑Beispiele, die die Foliengestaltung und Automatisierung beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Jetzt wurde die TextFrame‑Methode sowohl dem [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape)-Interface als auch der [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape)-Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) abzurufen, wenn nicht nur Knotentexte vorhanden sind. Der folgende Beispielcode zeigt, wie man Text aus einem SmartArt‑Knoten erhält.
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


## **Layouttyp eines SmartArt-Objekts ändern**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu ändern, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
- Holen Sie sich die Referenz einer Folie über ihren Index.
- Fügen Sie zur [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie den [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX‑Datei.
  Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # LayoutType zu BasicProcess ändern
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Präsentation speichern
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Versteckte Eigenschaft eines SmartArt-Objekts prüfen**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) gibt true zurück, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu prüfen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
- Fügen Sie zur [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie dem SmartArt einen Knoten hinzu.
- Prüfen Sie die [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)‑Eigenschaft.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Knoten zu SmartArt hinzufügen
    $node = $smart->getAllNodes()->addNode();
    # isHidden-Eigenschaft prüfen
    $hidden = $node->isHidden();// Gibt true zurück

    if ($hidden) {
      # Einige Aktionen oder Benachrichtigungen ausführen
    }
    # Präsentation speichern
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Organisation‑Diagrammtyp abrufen oder festlegen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen bzw. Festlegen des Organisation‑Diagrammtyps des aktuellen Knotens. Um den Organisation‑Diagrammtyp abzurufen oder festzulegen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
- Fügen Sie zur [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
- Abrufen oder [setzen Sie den Organisation‑Diagrammtyp](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX‑Datei.
  Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Organisation‑Diagrammtyp abrufen oder festlegen
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Präsentation speichern
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Picture‑Organisations‑Diagramm erstellen**
Aspose.Slides for PHP via Java stellt eine einfache API zum Erstellen von PictureOrganization‑Diagrammen bereit. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType::PictureOrganizationChart) hinzu.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

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


## **SmartArt‑Zustand abrufen oder festlegen**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu ändern, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Fügen Sie zur [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
1. [Abrufen](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) oder [Festlegen](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) Sie den Zustand des SmartArt‑Diagramms.
1. Schreiben Sie die Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```php
  # Präsentationsklasse instanziieren die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Zustands von SmartArt Diagramm abrufen oder festlegen
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


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) schaltet die Diagramm­richtung (LTR/RTL) um, sofern der ausgewählte SmartArt‑Typ ein Umdrehen unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Shapes‑Sammlung [clone the SmartArt shape](/slides/de/php-java/shape-manipulations/) ([ShapeCollection.addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) oder die gesamte Folie, die diese Form enthält, [clone the entire slide](/slides/de/php-java/clone-slides/), duplizieren. Beide Vorgehensweisen erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt als Raster‑Bild für die Vorschau oder den Web‑Export?**

[Render the slide](/slides/de/php-java/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt‑Objekt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis ist, das [alternative text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt‑Text) oder einen [name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) zu verwenden und dann innerhalb der [slide shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) nach dieser Eigenschaft zu suchen, anschließend den Typ zu prüfen, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Shapes.