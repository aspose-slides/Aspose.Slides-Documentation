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
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für PHP via Java erstellen und bearbeiten, wobei klare Code‑Beispiele die Foliengestaltung und Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotenshapes und einem Layout besteht. Mit Aspose.Slides für PHP via Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, ausgeblendete Knoten untersuchen, Organisations‑Diagrammlayouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Shapes enthalten. Um Text aus den Knotenshapes zu lesen, iterieren Sie über [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), dann lesen Sie das von [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) zurückgegebene [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Das Beispiel erfordert eine Präsentation mit mindestens einer Folie und einem SmartArt‑Objekt als erstes Shape auf dieser Folie. Es gibt jeden verfügbaren TextFrame in der Konsole aus.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Layouttyp eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑Wert, ändert ihn zu dem Wert `BasicProcess` und speichert die Präsentation. Die an [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) übergebenen Position und Größe werden in Punkten gemessen. Verwenden Sie [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/), um das Layout zu ändern.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Prüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur vorhanden sein, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten ausgeblendet ist, und speichert das Diagramm.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Organisation‑Diagrammlayout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisations‑Chart‑Layout verwenden, definieren [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) und [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/), wie Kindknoten unter einem Elternknoten angeordnet werden. Beispielsweise können Sie Kindknoten je nach ausgewähltem [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) links-, rechts- oder beidseitig hängen lassen.

Das folgende Beispiel erstellt ein Organisations‑Chart und setzt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑Wert. Der nullbasierte Index `0` wählt den ersten Knoten der obersten Ebene aus; seine Kindknoten verwenden die gewählte Anordnung. Die modifizierte Präsentation wird anschließend gespeichert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bildorganisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bild‑Platzhaltern konzipiert ist. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑Wert, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen. Dieses Beispiel speichert ein Diagramm mit Bild‑Platzhaltern; es füllt die Platzhalter nicht mit Bildern.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alte Diagramme in Gruppen von Shapes konvertieren**

Beim Modernisieren einer bestehenden Präsentation müssen Sie möglicherweise ein ursprünglich in PowerPoint 97–2003 erstelltes Organisations‑Chart aktualisieren. Aspose.Slides stellt diese Altdiagramme als [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/), um ein Diagramm in eine Gruppe von Shapes zu konvertieren, sodass Sie einzelne Bildelemente bearbeiten können. Weitere Details finden Sie in der [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/).

Die Konvertierung fügt der Shape‑Sammlung eine neue Gruppe hinzu, ohne das ursprüngliche Diagramm zu entfernen. Nach erfolgreicher Konvertierung entfernen Sie das Original mit [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/), um doppelte Inhalte zu vermeiden. Sammeln Sie die Altdiagramme vor der Konvertierung in einer Liste, damit das Hinzufügen und Entfernen von Shapes die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Gruppen von Shapes und speichert die aktualisierte Präsentation als PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die gespeicherte Präsentation enthält bearbeitbare Shape‑Gruppen anstelle der konvertierten Altdiagramme, wobei keine Originaldiagramme mehr vorhanden sind. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, z. B. deren Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) Methode wechselt die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder zurück, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können das SmartArt‑Shape mit [SmartArt‑Shape duplizieren](/slides/de/php-java/shape-manipulations/) mittels [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) klonen oder die gesamte Folie, die das SmartArt enthält, mit [gesamte Folie duplizieren](/slides/de/php-java/clone-slides/) duplizieren. Beide Ansätze bewahren Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Folie rendern](/slides/de/php-java/convert-powerpoint-to-png/) oder die gesamte Präsentation in PNG oder JPEG. SmartArt wird dabei als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Verwenden Sie [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) oder [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/), um dem SmartArt‑Shape einen eindeutigen Alternativtext zuzuweisen bzw. ihm einen Namen zu geben, suchen Sie danach in [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) und prüfen Sie anschließend, ob das gefundene Shape ein [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) ist.