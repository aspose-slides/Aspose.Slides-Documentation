---
title: Präsentationsformen in PHP anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/php-java/custom-shape/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Bearbeitungspunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- abgerundete Ecke
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie Sie mit [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) arbeiten, um vorhandene Formen zu ändern, grundlegende Pfadbearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder einer Form zuzuweisen.

Er demonstriert außerdem, wie benutzerdefinierte und zusammengesetzte Formen erstellt werden, Formen mit abgerundeten Ecken aufgebaut werden, ermittelt wird, ob eine Formgeometrie geschlossen ist, Formelemente inspiziert werden und Java‑AWT‑Textumrisse in Geometriepfade konvertiert werden.

## **Form mit Bearbeitungspunkten ändern**

* Eine Ecke nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine vorhandene Form als Basis für eine neue verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bei der Bearbeitung von PowerPoint‑Formen sollten Sie diese Konzepte beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuergriffe bestimmen dessen Form.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * An einem Eckpunkt können angrenzende Segmente in einem Winkel aufeinandertreffen.
  * An einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleich weit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können aber unterschiedliche Abstände vom Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) Instanz stellt einen Geometriepfad des [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) Objekts dar.
* Um den [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) aus der [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)‑Instanz abzurufen, können Sie die Methode [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden nutzen: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) für Formen mit einem einzelnen Pfad und [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) für Formen mit mehreren Pfaden.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) verwenden.
* Mit den Methoden [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) und [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Methode [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.
* Um zusätzliche Optionen zur Anpassung der Formgeometrie zu nutzen, können Sie ein [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) über dessen [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) auslesen und die Segmente auf einem [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) wiedergeben.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Ein elliptisches Bogensegment mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Die aktuelle Figur schließen, indem das Endsegment mit dem Startpunkt verbunden wird. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form mithilfe von [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) zwei Punkte hinzu und wendet den bearbeiteten Pfad mit [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) an. Die Koordinaten sind relativ zur Form: Beide neuen Punkte liegen in ihrer Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Segmentindizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem das Segment am nullbasierten Index 2 mit [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) entfernt wird. Das Anwenden des modifizierten Pfads mit [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) aktualisiert die Kontur der Form.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einzüge; ein 72‑Grad‑Schritt verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) geschlossen und mit [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) auf eine rechteckige Form angewendet, wodurch deren Kontur ersetzt wird.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) Objekte für das obere und untere Drittel einer Form. Das Anwenden beider Pfade mit [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzige zusammengesetzte Form mit einer Lücke im mittleren Drittel.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und der -90‑Grad‑Winkel zeichnet ein gegen den Uhrzeigersinn verlaufendes Viertel‑Ellipse. Der fertiggestellte Pfad wird mit [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht‑leere Geometriepfad mit einem Schließsegment endet. Er liest [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) und vergleicht das Abschlusssegment‑[PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) mit [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Er liefert false, wenn es keine nicht‑leeren Pfade gibt. Dabei wird nur der letzte Befehl jedes Pfads geprüft; nicht jede Teilfigur innerhalb eines Pfads wird inspiziert. Das Beispiel gibt für ein Rechteck `true` aus.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formelemente extrahieren und inspizieren**

Verwenden Sie [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements), um eine vorhandene Form als Elemente zu untersuchen, die Pfadpunkte und Punktetypen enthalten. Verwenden Sie jedes zurückgegebene [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) , um die Punkt‑ und Typ‑Arrays über die Methoden [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) und [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) abzurufen. Diese Darstellung ist nützlich für Konturanalysen oder um Geometrie an benutzerdefinierte Zeichenwerkzeuge zu übergeben.

Das Beispiel öffnet input.pptx, findet die erste Geometrieform direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabetypen zu sehen. Es wird nicht innerhalb von Gruppen gesucht.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Den Segmenttyp beibehalten, Flags ausschließend.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Verwende beide Steuerpunkte und den Endpunkt.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Die Arrays entsprechen einander nach Index: `$points[$i]` ist ein Punkt und `$types[$i]` beschreibt dessen Rolle. Typ `0` startet eine Figur und Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment startet am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Typ‑`3`‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Schließung.

Punktetypen enthalten ebenfalls Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu bestimmen, und testen Sie `0x80` separat, um einen geschlossenen Teilpfad zu erkennen. Zum Beispiel bedeutet `129` (`0x81`), dass ein Linienendpunkt einen Teilpfad schließt, und `131` (`0x83`), dass ein Bézier‑Endpunkt einen schließt. Die PHP/Java‑Bridge gibt das Byte‑Array als Binärzeichenkette zurück; das Entpacken mit "C*" erzeugt unsigned‑Byte‑Werte. Das Maskieren bewahrt die beabsichtigten Bitwerte. Ein Vergleich des Rohwerts nur mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Basissegmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten zunimmt. Für eine nicht gruppierte Form enthalten die extrahierten Koordinaten bereits die Position, die von [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) und [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) zurückgegeben wird, und spiegeln ihre aktuelle Breite und Höhe wider. Beispiel: Ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Konturgrenzen `(100, 200)`–`(220, 280)`. Fügen Sie die Position der Form nicht erneut hinzu. Subtrahieren Sie ihr X und Y, um Koordinaten relativ zu ihrem ungedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Rotation der Form, die von [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) zurückgegeben wird, noch horizontale bzw. vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um den Mittelpunkt der Form herum an. Für gruppierte Formen berücksichtigen Sie außerdem die Gruppen‑Koordinatenabbildung und -Transformationen; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen gerenderten Folienkoordinaten sind, und vermeiden Sie eine doppelte Anwendung von Verschiebung oder Skalierung, falls diese bereits im Rahmen des Kind‑Elements enthalten ist.

**Inspektion versus Bearbeitung.** Die extrahierten Arrays beschreiben die Kontur; deren Änderung aktualisiert nicht die ursprüngliche Form. Wählen Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Verwenden Sie [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder deren Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) oder [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) an.

## **Ein Java AWT Shape in GeometryPath konvertieren**

Dieses Beispiel kombiniert einen rechteckigen Umriss mit in Geometrie konvertiertem Text. Die [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode)-Methode des Umrisses deaktiviert dessen Füllung. Ein [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) erzeugt den Textumriss in einem [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Sein [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) liefert Move‑, Linien‑, quadratische, kubische und Schließ‑Segmente, die das Beispiel auf einem [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) wiedergibt.

Das Beispiel verwendet ein Java‑Float‑Array, sodass die PHP/Java‑Bridge die vom Iterator geschriebenen Koordinaten beibehält. Der Text nutzt eine 40‑Punkt‑Arial‑Schrift. Der Umriss ist horizontal um 20 Punkte versetzt und wird so positioniert, dass sein visueller obere Rand 10 Punkte unter dem oberen Rand der Form liegt. Der Textpfad wird gefüllt, während das ursprüngliche Rechteck nur als Umriss erhalten bleibt. Das Anwenden beider Pfade mit [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzige Form, die das Rechteck und den Text enthält.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit der Füllung und dem Umriss, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt bei der Form erhalten; nur die Kontur ändert sich. Füllung und Umriss werden automatisch auf die neue Geometrie angewendet.

**Wie kann ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt drehen?**

Verwenden Sie die [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation)-Methode der Form; die Geometrie dreht sich mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**

Ja. Exportieren Sie den gewünschten [Folie](/slides/de/php-java/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/php-java/create-shape-thumbnails/) selbst in ein Rasterformat; dies vereinfacht die weitere Arbeit mit komplexen Geometrien.