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
- Skizzierte Formlinie
- Verbindungsstil formatieren
- Verlauffüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz‑weiß‑Darstellung von Formen
- Graustufen‑Darstellung von Formen
- Form drehen
- 3D‑Kehlkanteneffekt
- 3D‑Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-Formen in JavaScript mit Aspose.Slides formatieren — Füll‑, Linien‑ und Effektstile für PPT-, PPTX‑ und ODP‑Dateien präzise und mit voller Kontrolle festlegen."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java bietet Klassen und Methoden, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den [line style](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/linestyle/) der Form.
5. Setzen Sie die Linienbreite.
6. Setzen Sie den [dash style](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/linedashstyle/) der Linie.
7. Setzen Sie die Linienfarbe für die Form.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Code zeigt, wie man ein Rechteck‑`AutoShape` formatiert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantiate the Presentation class that represents a presentation file.
let presentation = new aspose.slides.Presentation();
try {
    // Get the first slide.
    let slide = presentation.getSlides().get_Item(0);

    // Add an auto shape of the Rectangle type.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Remove the fill from the rectangle shape.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Apply formatting to the rectangle's lines.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Set the color for the rectangle's line.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Save the PPTX file to disk.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt die Linie einer Form handgezeichnet wirken. Verwenden Sie [Shape.getLineFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) , um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/lineformat/) , um auf die Skizzeneinstellungen zuzugreifen, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sketchformat/) , um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende JavaScript-Code zeigt, wie man einen [LineSketchType.Curved](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/linesketchtype/) Effekt anwendet, den explizit zugewiesenen Wert liest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/linesketchtype/) entfernt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Zugriff auf das Linienformat der Form und deren Skizzenformat.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Skizzeneffekt anwenden.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Den direkt der Form zugewiesenen Skizzeneffekt lesen.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Skizzeneffekt entfernen.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sketchformat/) zurückgegebene Wert stellt die Einstellung dar, die direkt der Form zugewiesen wurde. Wenn die Linienformatierung von einem Theme, einer Master‑Folien oder einer Layout‑Folie vererbt werden kann, verwenden Sie [LineFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/lineformat/), rufen `getSketchFormat` auf dem zurückgegebenen Objekt auf und anschließend dessen `getSketchType`‑Methode. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Hier sind die drei Optionen für den Verbindungsstil:

* Rund
* Gehrung
* Abschrägung

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (z. B. an einer Formkante) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Gehrung**‑Option.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende JavaScript-Code demonstriert, wie drei Rechtecke (wie im obigen Bild) mit den Verbindungsstil‑Einstellungen Miter, Bevel und Round erstellt wurden:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Drei AutoShapes vom Typ Rectangle hinzufügen.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Füllfarbe für jedes Rechteck-Shape festlegen.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Linienstärke festlegen.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Farbe für jede Rechtecklinie festlegen.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Verbindungsstil festlegen.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Text zu jedem Rechteck hinzufügen.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verlauffüllung**

In PowerPoint ist die Verlauffüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Sie können zum Beispiel zwei oder mehr Farben so anwenden, dass eine allmählich in die andere übergeht.

So wenden Sie eine Verlauffüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/) der Form auf `Gradient`.
5. Fügen Sie mit den `add`‑Methoden der Verlauf‑Stop‑Sammlung, die von der Klasse [GradientFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/gradientformat/) bereitgestellt wird, Ihre beiden bevorzugten Farben mit definierten Positionen hinzu.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Ellipse hinzufügen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Verlaufformatierung auf die Ellipse anwenden.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Richtung des Verlaufs festlegen.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Zwei Farbverlaufspunkte hinzufügen.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlauffüllung](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – z. B. Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können benutzerdefinierte Farben für den Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie auf Formen anwenden können, um die optische Attraktivität Ihrer Präsentationen zu erhöhen. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen zu verwendenden Farben festlegen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/) der Form auf `Pattern`.
5. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
6. Setzen Sie die [Background Color](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/patternformat/#getBackColor--) des Musters.
7. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/patternformat/#getForeColor--) des Musters.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rectangle hinzufügen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Fülltyp auf Pattern setzen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Musterstil festlegen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Muster-Hintergrund- und Vordergrundfarben festlegen.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild dient effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung zuzuweisen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/) der Form auf `Picture`.
5. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus).
6. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) Objekt aus dem Bild, das Sie verwenden möchten.
7. Übergeben Sie das Bild an die Methode `ISlidesPicture.setImage`.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Nehmen wir an, wir haben eine Datei „lotus.png“ mit folgendem Bild:

![Das Lotus-Bild](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanzieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rectangle hinzufügen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Fülltyp auf Picture setzen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Bildfüllungsmodus festlegen.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Ein Bild laden und zu den Präsentationsressourcen hinzufügen.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Bild festlegen.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelnverhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel in Prozent.
- [setTileScaleY](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel in Prozent.

Das folgende Codebeispiel zeigt, wie man ein Rechteck mit gekachelter Bildfüllung hinzufügt und die Kacheloptionen konfiguriert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanzieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Ein Rechteck-AutoShape hinzufügen.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Fülltyp der Form auf Picture setzen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Bild laden und zu den Präsentationsressourcen hinzufügen.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Bild der Form zuweisen.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Bildfüllungsmodus und Kachel-Eigenschaften konfigurieren.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Kacheloptionen:

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese schlichte Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

Um mit Aspose.Slides eine einfarbige Füllung auf eine Form anzuwenden, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/) der Form auf `Solid`.
5. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rectangle hinzufügen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Fülltyp auf Solid setzen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Füllfarbe setzen.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie, wenn Sie einer Form eine einfarbige, Verlauf-, Bild‑ oder Texturfüllung zuweisen, auch einen Transparenzwert festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht's:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/) der Form auf `Solid`.
5. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
6. Speichern Sie die Präsentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren der Presentation‑Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Ein festes Rechteck‑AutoShape hinzufügen.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ein transparentes Rechteck‑AutoShape über dem festen Shape hinzufügen.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // PPTX‑Datei auf Festplatte speichern.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die transparente Form:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Das kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen positioniert werden sollen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Setzen Sie die Drehungseigenschaft der Form auf den gewünschten Winkel.
5. Speichern Sie die Präsentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen.
    let slide = presentation.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rectangle hinzufügen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Form um 5 Grad drehen.
    shape.setRotation(5);

    // PPTX-Datei auf Festplatte speichern.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Drehung der Form:

![Die Drehung der Form](shape-rotation.png)

## **3D‑Kehlkanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Kehlkanteneffekten zu Formen, indem Sie die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) konfigurieren.

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) der Form, um Kehlkanten‑Einstellungen zu definieren.
5. Speichern Sie die Präsentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanz der Presentation‑Klasse erstellen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Form zur Folie hinzufügen.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Dreidimensionale Format‑Eigenschaften der Form festlegen.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Präsentation als PPTX‑Datei speichern.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der 3D‑Kehlkanten‑Effekt:

![Der 3D‑Kehlkanten‑Effekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Drehungseffekten zu Formen, indem Sie die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) konfigurieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz zu einer Folie anhand ihres Index ab.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/lightrig/#setLightType), um die 3D‑Drehung zu definieren.
5. Speichern Sie die Präsentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanz der Presentation-Klasse erstellen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Präsentation als PPTX-Datei speichern.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der 3D‑Drehungseffekt:

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Darstellung von Formen steuern**

Die Methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert nicht die Füllung, Linie oder andere Formatierungen der Form im normalen Farbmodus.

Verwenden Sie einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die Anzeigesoftware die Konvertierung wählen, `Gray` und `LightGray` verwenden Graustufen, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine Einzelfarbe, `Color` bewahrt die normale Färbung, und `Hidden` lässt die Form im Schwarz‑weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑Level‑Modus zugewiesen ist.

Der folgende JavaScript-Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeigemodus grau erscheinen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Behalte die orange Füllung im Farbmodus, aber rendere die Form mit grauer Färbung im Schwarz‑weiß‑Modus.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In der normalen Farbdarstellung behält das Rechteck seine orangefüllung bei. In einem Schwarz‑weiß‑Anzeige‑Workflow verwendet es eine graue Färbung, da sein Modus auf `Gray` gesetzt ist. So können Sie eine Folie in voller Farbe behalten und gleichzeitig ein anderes Aussehen für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende JavaScript-Code zeigt, wie man die Formatierung einer Folie zurücksetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/) auf deren Standardwerte zurücksetzt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Setze jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keine zusätzliche Größe hinzufügen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung erleichtert.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.