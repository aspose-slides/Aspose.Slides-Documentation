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
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bildorganisationsdiagramm
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-SmartArt mit Aspose.Slides für PHP via Java erstellen und bearbeiten, wobei klare Code-Beispiele die Gestaltung und Automatisierung von Folien beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Jetzt wurde die Methode TextFrame der Klasse [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) abzurufen, falls nicht nur Knotentexte vorhanden sind. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu ändern, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) BasicBlockList hinzu.
- Ändern Sie den [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) auf BasicProcess.
- Speichern Sie die Präsentation als PPTX-Datei.
Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # LayoutType auf BasicProcess ändern
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
Bitte beachten Sie: Die Methode [SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) gibt `true` zurück, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu prüfen, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Fügen Sie ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) RadialCycle hinzu.
- Fügen Sie dem SmartArt einen Knoten hinzu.
- Prüfen Sie die [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/)‑Eigenschaft.
- Speichern Sie die Präsentation als PPTX-Datei.
Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.
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
      # Aktionen oder Benachrichtigungen ausführen
    }
    # Präsentation speichern
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Organisationchart‑Typ abrufen oder festlegen**
Die Methoden [SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) und [SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) ermöglichen das Abrufen bzw. Festlegen des Organisationchart‑Typs, der dem aktuellen Knoten zugeordnet ist. Um den Organisationchart‑Typ abzurufen oder festzulegen, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Fügen Sie ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) auf der Folie hinzu.
- Rufen Sie den Organisationchart‑Typ ab oder [set the organization chart type](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/).
- Speichern Sie die Präsentation als PPTX-Datei.
Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.
```php
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Organisationsdiagrammtyp abrufen oder festlegen
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Präsentation speichern
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Picture‑Organisationchart erstellen**
Aspose.Slides für PHP via Java bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen auf unkomplizierte Weise. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType::PictureOrganizationChart) hinzu.
4. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

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


## **SmartArt‑Status abrufen oder festlegen**
Um den Status eines [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) zu ändern, befolgen Sie die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Fügen Sie ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) auf der Folie hinzu.
3. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/) oder [Set](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) Sie den Zustand des SmartArt‑Diagramms.
4. Speichern Sie die Präsentation als PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```php
  # Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # SmartArt BasicProcess hinzufügen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Den Zustand des SmartArt-Diagramms abrufen oder festlegen
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

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) schaltet die Diagrammrichtung (LTR/RTL) um, wenn der ausgewählte SmartArt‑Typ das Umdrehen unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Shape‑Collection ([ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) klonen oder die gesamte Folie, die diese Form enthält, klonen. Beide Ansätze erhalten Größe, Position und Stil.

**Wie renderiere ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**

Rendern Sie die Folie (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmatisch ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Vorgehensweise ist die Verwendung von alternativem Text (Alt‑Text) oder einem Namen und die Suche nach dem Shape anhand dieses Attributs innerhalb der [slide shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Shapes.