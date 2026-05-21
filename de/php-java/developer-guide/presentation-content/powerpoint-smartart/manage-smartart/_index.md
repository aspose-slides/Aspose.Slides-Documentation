---
title: SmartArt in PowerPoint-Präsentationen mit PHP verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layout-Typ
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint SmartArt mit Aspose.Slides für PHP via Java erstellen und bearbeiten, anhand klarer Codebeispiele, die die Foliengestaltung und Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint-Diagramm, das aus Knoten, Knotenformen und einem Layout besteht. Mit Aspose.Slides für PHP via Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten untersuchen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Shapes enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [SmartArt::getAllNodes](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartart/#getAllNodes), dann lesen Sie das von [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartshape/#getTextFrame) zurückgegebene [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem Wert `BasicBlockList` von [SmartArtLayoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartlayouttype/), ändert ihn zu dem Wert `BasicProcess` und speichert die Präsentation.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Überprüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartnode/ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den Wert `RadialCycle` von [SmartArtLayoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartlayouttype/) verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des Knotens.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Organisation‑Diagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisations‑Chart‑Layout verwenden, definieren [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) und [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartnode/setorganizationchartlayout/), wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Zum Beispiel können Sie untergeordnete Knoten von links, rechts oder von beiden Seiten hängen lassen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisations‑Chart und setzt das Layout für den ersten Knoten auf den Wert `LeftHanging` von [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/organizationchartlayouttype/).

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bild‑Organisations‑Chart erstellen**

Ein Bild‑Organisations‑Chart ist ein SmartArt‑Layout, das für Hierarchie‑Diagramme mit Bild‑Platzhaltern entwickelt wurde. Verwenden Sie den Wert `PictureOrganizationChart` von [SmartArtLayoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartlayouttype/), wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL-Sprachen?**

Ja. Die Methode [SmartArt::setReversed](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartart/setreversed/) wechselt die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder zurück, wenn das ausgewählte SmartArt‑Layout eine Umkehrung unterstützt.

**Wie kann ich SmartArt in derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form klonen mit [ShapeCollection::addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addclone/) [SmartArt-Form klonen](/slides/de/php-java/shape-manipulations/) oder die gesamte Folie, die die SmartArt enthält, [die gesamte Folie klonen](/slides/de/php-java/clone-slides/). Beide Vorgehensweisen erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**

[Die Folie rendern](/slides/de/php-java/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Setzen Sie einen eindeutigen [Shape::getAlternativeText](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getalternativetext/)‑ oder [Shape::getName](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getname/)‑Wert auf die SmartArt‑Form, suchen Sie diesen Wert in [BaseSlide::getShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getShapes), und prüfen Sie anschließend, dass die gefundene Form ein [SmartArt](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartart/) ist.