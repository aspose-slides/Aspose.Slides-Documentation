---
title: Verwalten von Präsentationsformen in PHP
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/php-java/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID erhalten
- Form-Alternativtext
- Form-Layoutformate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für PHP via Java identifizieren, duplizieren, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for PHP via Java stellt die Formen auf einer Folie als geordnete [ShapeCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die am weitesten hinten liegende Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Zuerst wird erklärt, wie man eine Form zuverlässig identifiziert, dann wird gezeigt, wie man Formen dupliziert, entfernt, ausblendet und neu anordnet. Die letzten Abschnitte behandeln Formatierung auf Layout‑Ebene, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jeder Abschnitt ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Identifizieren und Finden von Formen**

Collection‑Indizes sind praktisch, wenn man eine bekannte Datei verarbeitet, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuanordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner basierend darauf, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getname/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlfenster von PowerPoint einsehen. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention festlegen, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getalternativetext/) ist hilfreich, wenn eine Barrierefreiheitsbeschreibung oder ein vom Autor vergebenes Tag die Form bereits identifiziert. Er ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie nicht stillschweigend bedeutungsvollen Barrierefreiheitstext als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getofficeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Shape‑ID entspricht. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form eine eindeutige Referenz benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält eine eigene ID.

Die zugehörige Methode [Shape::getUniqueId](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getuniqueid/) gibt einen Bezeichner mit Präsentations‑Umfang zurück, der jedoch für Add‑Ins gedacht ist und neu zugewiesen werden kann. Er sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität nötig ist, speichern Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach Namen mit exakt gleichem Vergleich und gibt die slide‑bezogene Interop‑ID aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie die Laufzeitklasse, bevor Sie typ‑spezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) ist.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ändern der Formsammlung**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Ändert ein Vorgang die Anzahl oder Reihenfolge der Formen, dürfen Sie nicht weiterhin auf zuvor ermittelte Indizes vertrauen.

### **Klonen einer Form**

[ShapeCollection::addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addclone/) erstellt eine unabhängige Kopie und hängt sie an die Ziel‑Sammlung an. [ShapeCollection::insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/insertclone/) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon ohne Größenänderung; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Zielfolie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone ändern nicht die Quellform.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Klonen kopiert den Inhalt und das Format der Form, einschließlich Namen und Alternativtext. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Sammlungs‑Element mit neuer Form‑Identität.

### **Formen entfernen**

[ShapeCollection::remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration sollten Sie von hinten nach vorne traversieren, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die Form am aktuellen Index, nicht ein festes Sammlungs‑Element, und wirft die Form nicht unnötig.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes späterer Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen können; das Entfernen einer sichtbaren Form kann mehr als nur das Aussehen der Folie verändern.

### **Form ausblenden**

Das Setzen von [Shape::setHidden](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/sethidden/) auf `true` lässt die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Bildschirmpräsentation. Ihr Index, ihr Format und ihr Inhalt bleiben dem Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ausblenden ist kein Löschen oder eine Sicherheitsmaßnahme. Das Objekt kann weiterhin von einem Benutzer oder Code entdeckt und wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gemalt. [ShapeCollection::reorder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/reorder/) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist hinten; `size() - 1` ist vorne.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Wird es zum letzten Index verschoben, steht es vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Sammlungs‑Elemente anhängen oder einfügen und den geplanten Stapel verändern können.

## **Untersuchen von Formen auf Layout‑Folien**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Untersuchen Sie Layout‑Formen, wenn Sie das vom Layout bereitgestellte Format verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form die [FillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getfillformat/) und [LineFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getlineformat/) ohne anzunehmen, dass jede Form ein `AutoShape` ist.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Export einer Form nach SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/writeassvg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Halten Sie die Präsentation während des Renderns offen. Die Ausgabe hängt vom Format der Form und von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Zusammensetzung benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen.

## **Formen ausrichten**

Die Überladungen von [SlideUtil::alignShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/alignshapes/) richten entweder alle Formen oder ausgewählte Sammlungs‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder den Verteilungsmodus an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ausrichtung ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung ausreichend viele Formen zum Bestimmen des Abstands benötigt. Berechnen Sie die Indizes neu, wenn Sie die Sammlung vor Aufruf der Methode ändern.

## **Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegelungs‑Einstellungen sowie Drehung. Ihre `getFlipH`‑ und `getFlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/php-java/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht spezifizierten/Standard‑Zustand.

Die Eingabe‑Präsentation unten enthält eine nicht gespiegelte Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegelungs‑Einstellungen. Das ist wichtig, weil das Zuordnen eines neuen [Frame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/setframe/) den kompletten Frame ersetzt.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, wobei Position, Größe und Drehung erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungs‑Index als Form‑Bezeichner verwenden?**

Nur für kurzlebige Verarbeitung, wenn die Sammlung vor der Nutzung des Index nicht geändert wird. Bevorzugen Sie für erstellte Vorlagen eine validierte `Name`‑ oder `AlternativeText`‑Konvention oder `OfficeInteropShapeId` für slide‑bezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`addClone` hängt den Klon an das Ende der Sammlung, das die Vorderseite der Z‑Reihenfolge darstellt. Verwenden Sie `insertClone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.