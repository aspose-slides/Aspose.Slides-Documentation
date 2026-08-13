---
title: Effektive Formeigenschaften aus Präsentationen in JavaScript abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/nodejs-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtsystem
- Fasenform
- Textrahmen
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Node.js via Java verwenden, um lokale, geerbte und effektive Formformatierungen in PowerPoint-Präsentationen zu unterscheiden."
---
## **Lokale, geerbte und effektive Eigenschaften verstehen**

PowerPoint-Formatierungen können aus mehreren Quellen stammen. Der direkt auf einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Wenn dieser Wert nicht gesetzt ist, prüft PowerPoint die übergeordneten Formatierungsquellen, wie z. B. die Standardwerte eines Absatzes, einen Textstil, ein Layout oder eine Masterfolie, ein Design oder Präsentations‑Standardwerte. Diese Werte sind **geerbte Werte**. Der Wert, der nach Auflösung der gesamten Hierarchie verbleibt, ist der **effektive Wert** – der zum Rendern des Objekts verwendete Wert.

Beispielsweise definiert ein Textabschnitt seine Schriftgröße möglicherweise nicht. Sein lokaler [getFontHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/#getFontHeight)-Wert ist dann `NaN`, was „hier nicht gesetzt“ bedeutet. Der Abschnitt kann die Höhe von seinem Absatz, dem Standard‑Textstil der Präsentation oder einer anderen zutreffenden Quelle erben. Ein Aufruf von [getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/#getEffective) auf das PortionFormat gibt die endgültig aufgelöste Höhe zurück.

Verwenden Sie die beiden Arten von Formatierungsdaten zu unterschiedlichen Zwecken:

- Lesen oder ändern Sie ein lokales Formatobjekt, wie z. B. [PortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/), wenn Sie steuern müssen, wo ein Wert definiert ist.
- Lesen Sie die [die von PortionFormat.getEffective zurückgegebenen effektiven Daten](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/#getEffective), wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

Bevor Sie die Beispiele ausführen, [installieren Sie Aspose.Slides für Node.js via Java](/slides/de/nodejs-java/installation/).

## **Lokale, geerbte und effektive Werte vergleichen**

Das folgende vollständige Beispiel erstellt eine Form und legt Schriftgrößen auf Präsentations‑, Absatz‑ und Abschnittsebene fest. Jeder Schritt gibt die an diesen Ebenen definierten Werte und den daraus resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt auch, warum effektive Daten nach Formatierungsänderungen erneut gelesen werden müssen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Effektive Daten nach den vorangegangenen Änderungen lesen.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Geerbte Werte auf zwei verschiedenen Ebenen festlegen.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Das Ändern eines geerbten Werts überschreibt keinen bestehenden lokalen Wert.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Lokalen Wert löschen. Der Abschnitt erbt jetzt wieder vom Absatz.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Absatzwert löschen. Der Präsentationsstandard liefert nun das Ergebnis.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Priorität in diesem Beispiel ist die lokale Formatierung des Abschnitts, dann die Absatzformatierung, dann die Präsentations‑Standardwerte. Andere Objekte können unterschiedliche Vererbungsketten haben, aber das Prinzip ist dasselbe: ein spezifischerer expliziter Wert gewinnt, und [getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/#getEffective) liefert das Endergebnis.

## **Effektive Texteigenschaften abrufen**

Textformatierung ist über mehrere Objekte verteilt:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#getEffective) löst Text‑Frame‑Eigenschaften wie Ränder, Verankerung, Autofit und vertikale Textausrichtung auf.
- [TextStyle.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textstyle/#getEffective) löst Absatzformatierung für jede Textebenen‑Stufe auf.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/#getEffective) löst Absatz‑Eigenschaften wie Ausrichtung, Einrückung und Aufzählungen auf.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/#getEffective) löst Zeichen‑Eigenschaften wie Schriftgröße, Schriftart, Farbe, Fett und Kursiv auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem nicht leeren Text‑Frame enthalten. Das AutoShape kann an beliebiger Position in der Formensammlung stehen; der Code sucht nach einem geeigneten Objekt und validiert es vor der Verwendung.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Effektive 3D‑Eigenschaften abrufen**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getEffective) liefert ein effektives Datenobjekt, das alle aufgelösten 3D‑Einstellungen zusammenfasst. Seine Methoden [getCamera](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getBevelBottom) geben die entsprechenden effektiven Daten zurück. Das gleichzeitige Lesen dieser verwandten Einstellungen erleichtert das Verständnis des endgültigen 3D‑Aussehens einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf der ersten Folie enthalten. Wenden Sie 3D‑Kamera-, Beleuchtungs- oder Abschrägungs‑Einstellungen auf diese Form an, wenn die Ausgabe Werte enthalten soll, die von den Standardwerten abweichen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Effektive Tabellenformatierung abrufen**

Die Tabellenformatierung kann aus dem Tabellenstil und aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen ist die Priorität: Zelle, Zeile, Spalte und schließlich die gesamte Tabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf der ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte haben. Der Code sucht nach einer [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/table/), anstatt anzunehmen, dass `getShapes().get_Item(0)` eine Tabelle ist.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Wenn Sie die Farbe und nicht nur den Fülltyp benötigen, prüfen Sie zuerst das effektive [getFillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/#getFillType) und lesen anschließend die Methode, die für diesen Typ gilt – zum Beispiel [getSolidFillColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) für eine Vollfüllung.

## **Effektive Daten nach Änderungen erneut einlesen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie `getEffective` erneut auf, nachdem Sie etwas geändert haben, das an dieser Hierarchie teilnehmen kann, einschließlich:

- der lokalen Formatierung des Objekts;
- Absatz‑ oder Text‑Frame‑Standardwerte;
- eines Tabellenstils, einer Tabelle, Spalte, Zeile oder Zellenformat;
- Layout‑ oder Master‑Folien‑Formatierung;
- Designdaten oder Präsentations‑Standardwerte;
- das dem Bild zugewiesene Layout oder den Master.

Bewahren Sie kein effektives Datenobjekt als permanente Momentaufnahme auf. Aspose.Slides kann einige effektive Daten intern cachen, und ein späterer Aufruf von `getEffective` kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die benötigten skalaren Werte – etwa Schriftgröße, Farbe, Ausrichtung oder Abschrägungsbreite – in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen anschließend `getEffective` auf, um das Ergebnis zu überprüfen. Effektive Datenobjekte sind selbst schreibgeschützt.

## **FAQ**

**Wie kann ich erkennen, welche Ebene einen effektiven Wert geliefert hat?**

Effektive Daten enthalten den endgültigen Wert, nicht dessen Quelle. Untersuchen Sie die relevanten lokalen Objekte von der am spezifischsten Ebene aus nach außen. Für Text können das der Abschnitt, Absatz, Text‑Frame, Layout, Master, Design und die Präsentations‑Standardwerte sein. Nicht definierte Werte wie `NaN` oder `null` zeigen an, dass die Suche zu einer anderen Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides ermittelt den entsprechenden PowerPoint‑ oder Bibliotheksstandard. Dieser aufgelöste Wert erscheint in den effektiven Daten, obwohl kein lokales Objekt ihn explizit definiert.

**Warum entspricht ein effektiver Wert manchmal dem lokalen Wert?**

Der lokale Wert hat die Vererbungsberechnung gewonnen. Das ist zu erwarten, wenn die Eigenschaft explizit am Objekt gesetzt ist und keine spezifischere Regel sie überschreibt.

**Wann sollte ich lokale Daten anstelle von effektiven Daten verwenden?**

Verwenden Sie lokale Daten, um ein bestimmtes Formatierungsebene zu untersuchen oder zu bearbeiten. Verwenden Sie effektive Daten, wenn Sie das endgültige Aussehen nach Vererbung, Design‑Regeln und angewandten Stilen benötigen. Das [vollständiges Vergleichsbeispiel](#compare-local-inherited-and-effective-values) demonstriert beides im gleichen Arbeitsablauf.