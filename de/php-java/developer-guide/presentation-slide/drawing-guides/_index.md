---
title: Verwalten von Zeichnungshilfen in Präsentationen in PHP
linktitle: Zeichnungshilfen
type: docs
weight: 85
url: /de/php-java/drawing-guides/
keywords:
- Zeichnungshilfe
- horizontale Hilfslinie
- vertikale Hilfslinie
- Ausrichtungshilfe
- Folienansicht
- Masterfolie
- Layoutfolie
- Notizen-Master
- Handzettel-Master
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Hinzufügen, Zugreifen und Löschen von horizontalen und vertikalen Zeichnungshilfen in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java."
---
## **Übersicht**

Zeichnungshilfen sind verstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer Präsentation in PowerPoint konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation erzeugt, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungshilfen speichern, denen die Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Zeichnungshilfen sind Bearbeitungshilfen, kein Folieninhalt. Sie erscheinen nicht in einer Bildschirmpräsentation oder gerenderten Ausgabe. Aspose.Slides für PHP via Java stellt sie über die [DrawingGuidesCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguidescollection/)-Klasse bereit. Eine Hilfslinie wird durch [DrawingGuide](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguide/) repräsentiert und besitzt eine Ausrichtung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Eck der jeweiligen Folie oder des Folienmasters gemessen. Eine vertikale Hilfslinie verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Hilfslinie verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Hilfslinien zur Folienansicht hinzufügen**

Verwenden Sie [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/de/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides), um die beim Bearbeiten normaler Folien angezeigten Hilfslinien zu verwalten. Rufen Sie [DrawingGuidesCollection::add](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguidescollection/#add) mit einem [Orientation](https://reference.aspose.com/slides/de/php-java/aspose.slides/orientation/)-Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt eine vertikale Hilfslinie rechts von der Folienmitte und eine horizontale Hilfslinie darunter hinzu:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Auf Zeichnungshilfen zugreifen**

Die Methoden [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguidescollection/#getCount) und [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguidescollection/#get_Item) ermöglichen den Zugriff auf vorhandene Hilfslinien. Die Methoden [DrawingGuide::getOrientation](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguide/#getPosition) und [DrawingGuide::getColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguide/#getColor) geben Werte zurück, die über die entsprechenden Setter-Methoden auch geändert werden können.

Das folgende Beispiel liest die Hilfslinien der Folienansicht aus der oben erstellten Präsentation:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Hilfslinien zu Master- und Layout-Folien hinzufügen**

Ein Folien-Master und jede seiner Layout-Folien können eigene Zeichnungshilfen-Sammlungen besitzen. Verwenden Sie [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/#getDrawingGuides) für einen Master-Slide und [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#getDrawingGuides) für einen Layout-Slide.

Das folgende Beispiel fügt dem ersten Master-Slide eine vertikale Hilfslinie und dem ersten Layout-Slide eine horizontale Hilfslinie hinzu:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hilfslinien zu Notizen- und Handzettel-Mastern hinzufügen**

Notizen-Master und Handzettel-Master unterstützen ebenfalls Zeichenhilfen. Verwenden Sie [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslide/#getDrawingGuides) und [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides), um auf deren Sammlungen zuzugreifen. Enthält eine Präsentation keinen dieser Master, rufen Sie den entsprechenden Manager mit [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) bzw. [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) ab und erstellen Sie den Standard-Master mit `setDefaultMasterNotesSlide` oder `setDefaultMasterHandoutSlide`.

Das folgende Beispiel fügt einem Notizen-Master eine horizontale Hilfslinie und einem Handzettel-Master eine vertikale Hilfslinie hinzu:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zeichnungshilfen löschen**

Rufen Sie [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguidescollection/#clear) auf, um jede Hilfslinie aus einer bestimmten Sammlung zu entfernen. Das Löschen einer Sammlung wirkt sich nicht auf in einem anderen Geltungsbereich gespeicherte Hilfslinien aus.

Das folgende Beispiel löscht die Hilfslinien der Folienansicht sowie alle Hilfslinien auf Folien-Mastern, Layout-Folien, dem Notizen-Master und dem Handzettel-Master, ohne fehlende Master zu erstellen:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Erscheinen Zeichnungshilfen in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Zeichnungshilfen sind Ausrichtungshilfen zur Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Zeichnungshilfe direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Bearbeitungs-Hilfslinien für normale Folien werden in den Folienansichts-Eigenschaften der Präsentation gespeichert. Separate Hilfslinien-Sammlungen stehen für Folien-Master, Layout-Folien, Notizen-Master und Handzettel-Master zur Verfügung.

**Welche Einheiten werden für die Positionen von Hilfslinien verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichnungshilfen Formen oder ändert den Folieninhalt?**

Nein. Die Methode [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/drawingguidescollection/#clear) entfernt nur die Hilfslinien in der ausgewählten Sammlung. Formen und anderer Folieninhalt bleiben unverändert.