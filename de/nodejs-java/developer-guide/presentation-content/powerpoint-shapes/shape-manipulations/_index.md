---
title: Verwalten von Präsentationsformen in JavaScript
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/nodejs-java/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form klonen
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Form-Alternativtext
- Form-Anpassungspunkt
- Voreingestellte Formanpassung
- Formgeometrie
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für Node.js via Java identifizieren, anpassen, klonen, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for Node.js via Java stellt die Formen auf einer Folie als geordnete [ShapeCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die am weitesten hinten liegende Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Er erklärt zuerst, wie man eine Form zuverlässig identifiziert und voreingestellte Anpassungspunkte der Form ändert, zeigt dann, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑bezogene Formatierung, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Kennungen. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie eine Kennung nach dem Erstellungs‑ und Wartungsstil der Präsentation:

- [Name](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getname/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht in PowerPoints Auswahlbereich inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, also etablieren Sie eine Namenskonvention, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getalternativetext/) ist nützlich, wenn eine Barrierefreiheitsbeschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Es ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie keinen bedeutungsvollen Barrierefreiheitstext stillschweigend als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Form‑ID entspricht. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form eine eindeutige Referenz benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [getUniqueId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getuniqueid/)‑Methode gibt einen Bezeichner im Präsentationsumfang zurück, der jedoch für Add‑Ins gedacht ist und neu zugewiesen werden kann. Er sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität wichtig ist, halten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach Namen mit exakt gleichem Vergleich und meldet die folienbezogene Interop‑ID. Wenn die Vorlage die erwartete Form nicht enthält, gibt der Code dieses Ergebnis aus, anstatt mit dem falschen Objekt weiterzumachen.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Wenn ein Vorgang für einen bestimmten Formtyp spezifisch ist, prüfen Sie die Laufzeitklasse, bevor Sie typenspezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) ist.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Voreingestellte Formanpassungen identifizieren und ändern**

Voreingestellte Geometrieformen können Anpassungspunkte besitzen, die Merkmale wie Eckgröße, Pfeilverhältnisse oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte [GeometryShape.getAdjustments](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/geometryshape/)‑Sammlung darauf zu. Die Sammlung selbst wird von der Form bereitgestellt, aber jedes [AdjustValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/) enthält einen änderbaren Wert.

Verlassen Sie sich nicht nur auf einen festen Sammlungsindex. Durchlaufen Sie die Anpassungen und prüfen Sie die schreibgeschützte [getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/)‑Methode, deren [ShapeAdjustmentType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapeadjustmenttype/)‑Wert beschreibt, was die Anpassung kontrolliert. Die schreibgeschützte [getName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/getname/)‑Methode liefert zusätzliche Identifikationsinformationen und ist besonders nützlich, wenn ein Preset mehr als eine Anpassung desselben semantischen Typs enthält.

Verwenden Sie die Wert‑Methode, die der Bedeutung der Anpassung entspricht:

| Anpassungstyp | Zweck | Zu ändernder Wert |
|---|---|---|
| `CornerSize` | Größe abgerundeter Ecken | [setRawValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Dicke des Pfeilschafts | `setRawValue` |
| `ArrowheadLength` | Länge der Pfeilspitze | `setRawValue` |
| `ArrowheadWidth` | Breite der Pfeilspitze | `setRawValue` |
| `StartAngle` | Startwinkel eines Kuchen‑ oder Bogensegments | [setAngleValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Endwinkel eines Kuchen‑ oder Bogensegments | `setAngleValue` |

`getType` und `getName` geben schreibgeschützte Informationen zurück. `getRawValue` und `setRawValue` arbeiten mit einem Ganzzahlwert in den nativen Geometrieeinheiten des Presets, während `getAngleValue` und `setAngleValue` mit einem Winkel in Grad arbeiten. Anzahl, Reihenfolge, Bedeutung und gültiger Bereich der Anpassungen hängen vom Preset‑[GeometryShape.getShapeType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/geometryshape/) ab. Ein Wert, der für ein Preset gültig ist, kann für ein anderes ungültig sein oder eine andere Wirkung haben.

Wenn `getType` `ShapeAdjustmentType.Custom` zurückgibt, erkennt die API keine standardmäßige semantische Bedeutung. Prüfen Sie `getName`, den Preset‑Typ und den bestehenden Wert und lassen Sie die Anpassung unverändert, sofern die erwartete Bedeutung und der Bereich nicht bekannt sind. Auch bei erkannten Typen sollten Sie prüfen, ob derselbe Typ mehr als einmal vorkommt, bevor Sie einen Wert auswählen. Der Artikel [Connector](/slides/de/nodejs-java/connector/) zeigt diese Situation mit Biegeanpassungen von Verbindern.

Das folgende vollständige Beispiel erzeugt Standard‑ und modifizierte Varianten von drei Preset‑Formen. Es durchläuft jede Anpassung, meldet ihren Namen und Typ, ändert größenbezogene Werte über `setRawValue`, ändert Winkel über `setAngleValue` und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den Vier‑Weg‑Pfeil und das Kuchendiagramm.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Fügt Überschriften für die Standard- und angepassten Formspalten hinzu.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Prüfen des semantischen Typs vor dem Ändern eines Werts macht den Code explizit bezüglich seiner Absicht und verhindert die Annahme, dass ein bestimmter Sammlungsindex dieselbe Bedeutung über verschiedene Preset‑Formen hinweg hat.

## **Formensammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge der Formen ändert, verlassen Sie sich nicht weiter auf zuvor erfasste Indizes.

### **Eine Form klonen**

[addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/addclone/) erstellt eine unabhängige Kopie und hängt sie an die Ziel‑Sammlung an. [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/insertclone/) erstellt ebenfalls eine Kopie, legt sie jedoch an einem angegebenen Z‑Order‑Index ab. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Ziel‑Folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone beeinflussen nicht die Quellform.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonen kopiert den Inhalt und die Formatierung der Form, inklusive Name und Alternativtext. Weisen Sie dem Klon neue logische Kennungen zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Sammlungselement mit einer neuen Form‑Identität.

### **Formen entfernen**

[remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration von hinten nach vorne durchlaufen, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die Form am aktuellen Index und nimmt nicht an, dass es sich um einen bestimmten Formtyp handelt.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nach dem Entfernen ändern sich die Formanzahl und die Indizes späterer Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentationsfunktionen, die auf das entfernte Objekt verweisen könnten; das Entfernen einer sichtbaren Form kann mehr als das Aussehen der Folie verändern.

### **Eine Form ausblenden**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/sethidden/) auf `true` lässt die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ausblenden ist kein Löschen oder eine Sicherheitsmaßnahme. Das Objekt kann weiterhin entdeckt und von einem Benutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Order ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gezeichnet. [reorder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/reorder/) verschiebt eine bestehende Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist hinten; `size() - 1` ist vorne.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben an den letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Order, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, weil diese Vorgänge neue Sammlungselemente anhängen oder einfügen und die beabsichtigte Stapelreihenfolge ändern können.

## **Formen auf Layout‑Folien inspizieren**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Formensammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Inspizieren Sie Layout‑Formen, wenn Sie die durch ein Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getfillformat/) und das [LineFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getlineformat/), ohne anzunehmen, dass jede Form ein `AutoShape` ist.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

[writeAsSvg](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/writeassvg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Halten Sie die Präsentation während des Renderns geöffnet. Die Ausgabe hängt von der Formatierung der Form und von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen.

## **Formen ausrichten**

Die [SlideUtil.alignShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideutil/alignshapes/)‑Überladungen richten entweder alle Formen oder ausgewählte Sammlungsindizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder Verteilungsart an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen am oberen Rand der Folie aus. Die zurückgegebenen Formverweise werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes konvertiert.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ausrichten ändert Positionen, nicht die Z‑Order. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen zur Bestimmung des Abstands benötigt. Berechnen Sie Indizes neu, wenn Sie die Sammlung vor dem Aufruf der Methode ändern.

## **Eine Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegelungs‑Einstellungen sowie Rotation. Ihre `getFlipH`‑ und `getFlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht spezifizierten/Standard‑Zustand.

Die Eingabepräsentation unten enthält eine nicht gespiegelt Form.

![The shape before flipping](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegelungs‑Einstellungen. Das ist wichtig, weil das Zuordnen eines neuen [Frame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/setframe/) den kompletten Frame ersetzt.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, wobei Position, Größe und Rotation erhalten bleiben.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungsindex als Form‑Kennung verwenden?**

Nur für kurzlebige Verarbeitung, wenn sich die Sammlung vor der Verwendung des Index nicht ändert. Bevorzugen Sie eine validierte `Name`‑ oder `AlternativeText`‑Konvention für erstellte Vorlagen oder `OfficeInteropShapeId` für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Order?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu geordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`addClone` hängt den Klon an das Ende der Sammlung, was die Vorderseite der Z‑Order ist. Verwenden Sie `insertClone`, um den Anfangs‑Index zu wählen, oder `reorder` nach dem Hinzufügen aller Formen.

**Kann ich einen festen Index zur Identifikation einer Preset‑Form‑Anpassung verwenden?**

Nur nach Validierung des genauen Presets und des Sammlungs‑Layouts. Durchlaufen Sie lieber `GeometryShape.getAdjustments` und prüfen Sie `AdjustValue.getType`; verwenden Sie `AdjustValue.getName` als zusätzliche Information, wenn derselbe semantische Typ mehr als einmal vorkommt.