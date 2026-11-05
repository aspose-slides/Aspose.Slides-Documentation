---
title: PowerPoint-Formen in JavaScript formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/nodejs-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeneffekt
- Skizzenformlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz-Weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Kehl-Effekt
- 3D-Drehungs-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in JavaScript mit Aspose.Slides formatieren – Füll-, Linien- und Effekt-Stile für PPT- und PPTX-Dateien präzise und vollständig steuern."
---
## **Einleitung**

Formatiere Formen in PowerPoint, indem du ihre Konturen, Füllungen und Effekte anpasst. Aspose.Slides für Node.js via Java ermöglicht es, diese Einstellungen programmgesteuert zu steuern, einschließlich Transparenz, Drehung und 3D-Formatierung.

![Formformatierungsoptionen in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für Node.js via Java stellt Klassen und Methoden bereit, mit denen du Formen mit denselben Optionen formatieren kannst, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Verwende [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat), um die Kontur einer Form zu steuern. Dieses Beispiel erstellt ein nicht gefülltes Rechteck mit einer blauen, gestrichelten Kontur. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) wählt eine dick‑dünn zusammengesetzte Linie, während [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) die Breite auf 7 Punkte setzt und [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) das Strichmuster auswählt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

### **Benutzerdefinierte Strichmuster festlegen**

Verwende [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern), wenn vordefinierte Linienstile die gewünschten Strich‑ und Lückenlängen nicht bieten, beispielsweise für Marken‑Konturen oder technische Diagramme. Das Zuweisen eines Musters ändert automatisch den Linien‑Strichstil zu [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

Array‑Einträge wechseln zwischen Strich‑ und Längen‑Werten, beginnend mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `[4, 2]` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkt‑Strich gefolgt von einer 6‑Punkt‑Lücke. Verwende Paare aus endlichen, nicht‑negativen Werten, um komplette Strich‑und‑Lücken‑Segmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Die vierte wiederholt das erste Muster bei doppelter Breite, wodurch sowohl Strich‑ als auch Lückenlänge verdoppelt werden. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // Setze die letzte Linie auf einen durchgezogenen Stil zurück.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um stattdessen zu einem vordefinierten gestrichelten Stil zurückzukehren, übergebe [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) an [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). Der ausgewählte Stil bestimmt das Aussehen der Linie.

Das Ergebnis in PowerPoint, von oben nach unten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; und **Solid, 3 pt**.

![Drei benutzerdefinierte Strichmuster, eine breitere Linie mit dem ersten Muster und eine durchgezogene Linie in PowerPoint](custom-dash-patterns.png)

### **Linienenden festlegen**

Verwende [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle), um die Enden einer offenen Linie festzulegen. Die Klasse [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) bietet drei explizite Enden‑Stile:

- `Flat`: Der Strich endet am Endpunkt.
- `Round`: Eine halbkreisförmige Kappe ragt halb so weit über den Endpunkt hinaus wie die Linienbreite.
- `Square`: Eine quadratische Kappe ragt halb so weit über den Endpunkt hinaus wie die Linienbreite.

Die Klasse enthält außerdem `NotDefined`, was bedeutet, dass kein Enden‑Stil explizit zugewiesen ist.

Enden unterscheiden sich von Pfeilspitzen, die Symbole an Linienenden hinzufügen, und von Verbindungsarten, die Ecken zwischen Liniensegmenten steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) und [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle), sodass nur die Endenformen verglichen werden.

Das folgende Beispiel erstellt drei ansonsten identische horizontale Linien, 20 Punkte breit. Von oben nach unten verwenden sie flache, runde bzw. quadratische Enden. Ihre Endpunkte haben dieselben horizontalen Koordinaten; die runden und quadratischen Enden ragen 10 Punkte über jeden Endpunkt hinaus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint, von oben nach unten: **Flat**, **Round** und **Square**.

![Flache, runde und quadratische Enden auf identischen dicken Linien in PowerPoint](line-caps.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet aussehen. Verwende [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat), um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat), um die Skizzeneinstellungen zu erhalten, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType), um einen Wert aus der Klasse [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende JavaScript‑Code zeigt, wie ein [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/)‑Effekt angewendet, der explizit zugewiesene Wert gelesen und der Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) entfernt wird:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) zurückgegebene Wert repräsentiert die direkt der Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folien oder einer Layout‑Folien geerbt werden kann, verwende [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), rufe `getSketchFormat` auf dem zurückgegebenen Objekt auf und anschließend dessen `getSketchType`‑Methode. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird. Dieses Beispiel erfordert eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie und gibt beide Werte aus:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Verbindungsarten formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Round
* Miter
* Bevel

Der Verbindungsstil bestimmt, wie zwei Kontursegmente an einer Ecke zusammentreffen. Verwende **Round** für abgerundete Ecken, **Miter** für spitze Ecken oder **Bevel** für abgeflachte Ecken.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Umrandungen von 15 Punkten Breite. Es verwendet [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle), um die Werte miter, bevel und round der Klasse [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) anzuwenden und zu vergleichen, wie die Ecken gezeichnet werden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Miter‑Verbindungen bei spitzen Ecken begrenzen**

Verwende [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) zusammen mit [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle), das auf [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) gesetzt ist, um zu begrenzen, wie weit eine scharfe Ecke ausstrecken kann.

Der Grenzwert ist das Verhältnis des Abstands zwischen den inneren und äußeren Ecken der Verbindung zur Linienbreite. Ein Wert von `8` erlaubt beispielsweise eine Miter‑Länge von bis zu achtmal der Linienbreite; er ist keine Messung in Punkten. Überschreitet die Ecke den Grenzwert, verwendet PowerPoint an dieser Stelle eine abgeschrägte Verbindung. Ein größerer Grenzwert erlaubt spitzere Punkte. Die Einstellung wirkt sich nur auf Miter‑Verbindungen aus und hat keinen sichtbaren Effekt, solange die Ecke innerhalb beider Grenzen bleibt.

Dieses Beispiel erstellt zwei identische, nicht gefüllte Dreiecke mit Konturen von 20 Punkten Breite. Das linke Dreieck verwendet einen Grenzwert von `2`, das rechte einen von `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, wodurch das obere Eckverhältnis von Miter‑Länge zu Linienbreite etwa `4,12` beträgt. Folglich wird das linke Apex abgeschrägt und das rechte Apex beibehalten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint: **Miter limit 2** links und **miter limit 8** rechts.

![Ein abgeschrägtes Apex mit Miter‑Grenzwert 2 und ein spitzes Apex mit Miter‑Grenzwert 8 in PowerPoint](miter-limits.png)

## **Verlauffüllung**

Eine Verlauffüllung mischt Farben über eine Form hinweg. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf von Rot nach Lila unter einem Winkel von 45 Grad, indem es [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) verwendet. Die Methode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) legt die Farbstopps bei 0 und 1, also Anfang und Ende des Verlaufs, fest. Das Löschen der vorhandenen Stopps stellt sicher, dass nur diese beiden Farben verwendet werden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlauffüllung](gradient-fill.png)

Falls ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kannst einen Render‑Stil auswählen, ohne die in der Präsentation gespeicherte Verlauffüllung zu ändern.

### **Den Winkel des linearen Verlaufs festlegen**

Verwende [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle), um die Ausrichtung einer [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/)-Füllung zu steuern. Der Winkel wird in Grad gemessen und nimmt im Uhrzeigersinn zu: `0` läuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruchteile von Grad werden unterstützt. Endliche Winkel außerhalb von `[0, 360)` werden zu einer Umdrehung normalisiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen Rot‑, Grün‑ und Blau‑Stopps an den Positionen `0`, `0.5` und `1`. Die Skalierung ist deaktiviert, sodass der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel von links nach rechts lauten in der ersten Zeile `0`, `45` und `90` und in der zweiten Zeile `135`, `180` und `270`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint:

![Lineare Verläufe bei 0, 45 und 90 Grad in der oberen Zeile sowie 135, 180 und 270 Grad in der unteren Zeile](linear-gradient-angles.png)

### **Einen linearen Verlauf mit der Form skalieren**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/)-Wert. Setze ihn explizit auf `False`, um den geometrischen Verlaufswinkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `True`, um den Verlauf mit Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann der sichtbare Winkel von dem zugewiesenen Winkel auf einer nicht‑quadratischen Form abweichen.

Das folgende Beispiel nutzt einen Winkel von `45` Grad und dieselben Farbstopps wie im Winkel‑Vergleich. Die linke Spalte verwendet `False`; die rechte Spalte verwendet `True`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide starten mit denselben breiten Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks zeigt, wie die Füllung auf Größenänderungen reagiert, ohne die Verlaufs‑Einstellungen zu ändern.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis in PowerPoint, mit deaktivierter Skalierung links und aktivierter Skalierung rechts:

![Breite und hohe Rechtecke mit einem 45‑Grad‑Verlauf, Vergleich LinearGradientScaled False links und True rechts](linear-gradient-scaling.png)

Bei deaktivierter Skalierung behalten die diagonalen Farbbänder in beiden Rechtecken dieselbe Ausrichtung bei. Bei aktivierter Skalierung dehnen sich die Bänder mit den Proportionen der Form. Dies hilft, den Verlauf einer Vorlage reproduzieren, wenn eine Form an eine andere Größe angepasst wird. Auf einem Quadrat ändert das Aktivieren der Skalierung das Aussehen dieses `45`‑Grad‑Verlaufs nicht.

Sowohl der Winkel als auch die Skalierungs‑Einstellungen gelten für lineare Verläufe. Sie steuern nicht die Füllungen [GradientShape.Radial oder GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **Winkel mit Verlaufsrichtung kombinieren**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) wählt einen Verlaufsstil aus der Klasse [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) aus; er ersetzt keinen numerischen Winkel. Für einen linearen Verlauf können die Eck‑Stile den Bereich, über den die Farben verteilt werden, ändern, ohne den über [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) zugewiesenen Winkel zu verändern. Belasse die Richtung unverändert, wenn du Winkel oder Skalierung vergleichst.

Das folgende Beispiel wendet die gleichen Einstellungen in umgekehrter Reihenfolge an. Die beiden Rechtecke sehen identisch aus: Das Zuweisen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Musterfüllung**

Eine Musterfüllung wendet ein zweifarbiges Design wie Punkte, Streifen oder Karos an. Dieses Beispiel verwendet [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle), um ein Rasters‑Muster auszuwählen. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) liefert den hellgrauen Hintergrund, und [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) liefert die gelbe Musterfarbe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

Eine Bildfüllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel benötigt ein lokales Bild und lädt es über [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) in die Bildsammlung der Präsentation. Das Setzen von [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) auf den Kachel‑Modus wiederholt das Bild innerhalb des Rechtecks. Das hier verwendete Quellbild ist unten dargestellt:

![Das Lotus‑Bild](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild als Textur kacheln**

Wenn du ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchtest, kannst du die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüll‑Modus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beide Male gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel benötigt ein lokales Bild und konfiguriert [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/), um es mit 50 % seiner Originalgröße zu wiederholen. Offsets von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Spiegeln in beiden Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

Eine einfarbige Füllung gibt einer Form eine einzelne, gleichmäßige Farbe. Dieses Beispiel verwendet [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType), um den einfarbigen Füllmodus auszuwählen, und weist Gelb über [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) zu, dann speichert es das Rechteck in einer Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

### **Farben kopieren und dabei Theme‑Verweise beibehalten**

Verwende [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom), um eine Farbabdefinition zu kopieren, einschließlich Farbtyp, Theme‑Verweis und Transformationen. Dies ist nützlich, wenn eine Füllfarbe zwischen Formen übertragen werden soll, die weiterhin dem Präsentations‑Theme folgen. Die Methode kopiert nur die Farbe: Sie kopiert nicht den Fülltyp, die Kontur oder andere Form‑Formatierungen. Setze den Ziel‑Fülltyp explizit mit [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

Dieses Beispiel erstellt drei Rechtecke, von links nach rechts: die Quelle, eine Theme‑bewusste Kopie und eine feste RGB‑Kopie. Die Quelle verwendet [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor), um die erste Akzentfarbe zu referenzieren, und fügt über [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add) einen Farbton hinzu. Die RGB‑Kopie verwendet die effektive Füllfarbe der Quelle, sodass alle drei zunächst identisch aussehen. Das Aufrufen von [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) setzt einen festen RGB‑Wert und löscht vorhandene Farb‑Transformationen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Theme-Referenzen folgen der neuen Akzentfarbe; der feste RGB-Wert nicht.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vor der Theme‑Änderung stimmen alle drei Füllungen überein:

![Quelle, copyFrom‑Ziel und feste RGB‑Ziel mit identischen blauen Füllungen](color-copy-before.png)

Nach der Theme‑Änderung folgen die Quelle und die Theme‑bewusste Kopie der neuen Akzentfarbe und behalten ihren Farbton bei. Die feste RGB‑Kopie bleibt blau:

![Quelle und copyFrom‑Ziel mit orangefarbenen Füllungen, während das feste RGB‑Ziel blau bleibt](color-copy-after.png)

Die kopierte Definition ist unabhängig von der Quelle. Änderungen am Theme‑Verweis der Quelle, das Zuweisen einer anderen Farbe oder das Hinzufügen/Entfernen von Transformationen ändern das Ziel nicht. Eine Theme‑Änderung wirkt sich weiterhin auf beide Formen aus, da jede eigenständig auf dieselbe Theme‑Farbe verweist.

Das Speichern und erneute Öffnen der PPTX bewahrt den von [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType) zurückgegebenen Farb‑Typ, den Theme‑Verweis und die von [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform) zurückgegebene Transformations‑Sammlung; es wird die Definition nicht zu RGB abgeflacht.

Beim Kopieren zwischen unterschiedlichen Theme‑Kontexten, z. B. Präsentationen mit verschiedenen Akzent‑Paletten, wird der kopierte Verweis gegen das Theme des Ziels aufgelöst. Der gleiche Verweis und dieselben Transformationen können daher eine andere sichtbare Farbe erzeugen. Siehe [Presentation Theme](/slides/de/nodejs-java/presentation-theme/) für weitere Informationen zur Konfiguration von Theme‑Farben.

## **Folien‑Hintergrund als Form‑Füllung verwenden**

Verwende [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill), wenn eine Form dem Folien‑Hintergrund entsprechen soll, beispielsweise in einer Präsentations‑Vorlage. Setze den Fülltyp zunächst mit [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) auf [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), um eine explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folien‑Hintergrund anstelle ihrer Stil‑Füllung. Das Setzen des Flags allein entfernt keine vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): NoFill lässt Objekte hinter der Form sichtbar, während BackgroundFill den Hintergrund hinter der Form mit dem entsprechenden Bereich des Folien‑Hintergrunds füllt. Ein Verlauf bleibt an der Folie ausgerichtet, anstatt in jeder Form neu zu beginnen.

Das folgende Beispiel erstellt einen Master‑Hintergrund, der von der Folie geerbt wird, und platziert einen magentafarbenen Streifen hinter drei Rechtecken. Das linke Rechteck verwendet den Hintergrund, das mittlere hat keine Füllung, und das rechte wechselt von Hintergrund‑Füllung zu einer expliziten orangefarbenen Füllung.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // Vererbe den Verlauf vom Master.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // Füge dieses Objekt zuerst hinzu, damit es hinter den Rechtecken erscheint.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // Deaktiviere die Hintergrundfüllung, bevor eine explizite Füllung angewendet wird.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis, von links nach rechts: **Background‑Füllung**, **NoFill** und **explizite Füllung**. Der magentafarbene Streifen wird von den linken und rechten Rechtecken verdeckt, bleibt jedoch durch das mittlere Rechteck sichtbar.

![Background‑Füllung, NoFill und explizite orange Füllung über einem magentafarbenen Streifen](background-fill.png)

Dasselbe Verhalten gilt für einen direkt auf der Folie definierten oder von einem Layout geerbten Hintergrund. Die Form verwendet den aufgelösten Folien‑Hintergrund; das Beispiel lässt sowohl Folien‑ als auch Layout‑Hintergrund undefiniert, sodass der Master ihn liefert.

## **Transparenz festlegen**

Bei einer einfarbigen Füllung steuert die Alpha‑Komponente der Farbe die Deckkraft: 0 ist vollständig transparent und 255 vollständig undurchsichtig. Dieses Beispiel verwendet einen Alpha‑Wert von 128 für ein gelbes Rechteck, sodass es etwa zu 50 % transparent ist und das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) zugewiesen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Verwende [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation), um eine Form in der Folien‑Ebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Kehl‑Effekte hinzufügen**

Verwende [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat), um einer Form Tiefe und abgeschrägte Kanten zu geben. Dieses Beispiel erstellt eine grüne Ellipse mit orangefarbener Kontur, setzt die Tiefe über [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) auf 4 Punkte und wendet über [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) einen kreisförmigen oberen Kehl mit Breite und Höhe von 6 Punkten an. Eine frontale orthografische Kamera und eine Dreipunkt‑Beleuchtung machen den Kehl sichtbar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der 3D‑Kehl‑Effekt](3D-bevel-effect.png)

## **3D‑Drehungs‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch die Kamera‑Einstellungen gesteuert. Dieses Beispiel verwendet [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) mit Breitengrad‑, Längengrad‑ und Revolutions‑Winkeln von 40, 35 bzw. 20 Grad. Es wählt eine isometrische Kamera über [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) und ausgewogene Beleuchtung über [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) und speichert das formatierte Rechteck.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der 3D‑Drehungs‑Effekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung für Formen steuern**

Die Methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑Weiß‑Anzeige nicht selbst und ändert die Füllung, Kontur oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwende einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die rendrierende Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graustufen, `BlackWhite` nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` bewahrt die normale Farbe, und `Hidden` lässt die Form im Schwarz‑Weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein formbezogener Modus zugewiesen ist.

Dieses Beispiel erstellt ein orangefarbenes Rechteck und verwendet [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode), um eine graue Farbgebung auszuwählen. Die gespeicherte Form behält ihre orange Füllung für die normale Farbanzeige bei und fordert graue Farbgebung von Anwendungen an, die Schwarz‑Weiß‑Anzeige‑Einstellungen berücksichtigen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑Weiß‑Workflow verwendet es graue Farbgebung, weil sein Modus auf `Gray` gesetzt ist. Das ermöglicht das Beibehalten einer Vollfarb‑Folien‑Anzeige und die Definition eines abweichenden Aussehens für Druck, Vorschau oder andere Workflows, die die Schwarz‑Weiß‑Anzeige‑Einstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Verwende [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset), um Position, Größe und Formatierung von Folien‑Platzhaltern aus den entsprechenden Layout‑Platzhaltern wiederherzustellen. Dieses Beispiel benötigt eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt jede Folie zurück, bevor es speichert. Formen ohne entsprechende Layout‑Platzhalter werden nicht zurückgesetzt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beeinflusst die Form‑Formatierung die endgültige Dateigröße der Präsentation?**

Farben, Linien‑Stile und Effekt‑Einstellungen fügen im Vergleich zu eingebetteten Bildern und Medien nur wenig Daten hinzu. Bild‑Füllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, damit ich sie gruppieren kann?**

Vergleiche die Schlüssel‑Formatierungseigenschaften jeder Form – Füllung, Kontur und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, betrachte ihre Stile als identisch und gruppiere die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichere Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Öffne beim Erstellen einer neuen Präsentation die Vorlage, klone die benötigten gestylten Formen und wende deren Formatierung dort an, wo sie gebraucht wird.