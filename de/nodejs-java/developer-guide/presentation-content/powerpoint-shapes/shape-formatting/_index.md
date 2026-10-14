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
- Formlinien skizzieren
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form-Transparenz
- Schwarz-Weiß-Formdarstellung
- Graustufen-Formdarstellung
- Form drehen
- 3D-Kanteneffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-Formen in JavaScript mit Aspose.Slides formatieren — Füll-, Linien- und Effekt-Stile für PPT-, PPTX- und ODP-Dateien präzise und mit voller Kontrolle festlegen."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Umrisse ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für Node.js via Java stellt Klassen und Methoden bereit, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben das Verfahren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Legen Sie den [Linienstil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) der Form fest.
1. Legen Sie die Linienbreite fest.
1. Legen Sie den [Strichstil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) der Linie fest.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Code demonstriert, wie man ein Rechteck‑`AutoShape` formatiert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Entfernen Sie die Füllung von der Rechteckform.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet aussehen. Verwenden Sie [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) , um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) , um auf die Skizzeneinstellungen zuzugreifen, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) , um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende JavaScript‑Code zeigt, wie man einen [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) entfernt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und dessen Skizzierungsformat zu.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Wenden Sie einen Skizzeneffekt an.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Lesen Sie den direkt der Form zugewiesenen Skizzeneffekt.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Entfernen Sie den Skizzeneffekt.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), rufen `getSketchFormat` auf dem zurückgegebenen Objekt auf und dann dessen `getSketchType`‑Methode. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

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

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Zusammenführen zweier Linien in einem Winkel (z. B. an einer Formkante) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Einstellung **Gehrung**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende JavaScript‑Code demonstriert, wie drei Rechtecke (wie im Bild oben) mit den Verbindungsstil‑Einstellungen Miter, Bevel und Round erstellt wurden:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Setzen Sie die Füllfarbe für jede Rechteckform.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Setzen Sie die Linienbreite.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Setzen Sie die Farbe für die Linie jedes Rechtecks.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Setzen Sie den Verbindungsstil.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Fügen Sie jedem Rechteck Text hinzu.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es Ihnen ermöglicht, einer Form einen kontinuierlichen Farbübergang zuzuweisen. Sie können beispielsweise zwei oder mehr Farben so anwenden, dass eine allmählich in die andere übergeht.

Hier erfahren Sie, wie Sie mit Aspose.Slides eine Verlaufsfüllung auf eine Form anwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen mithilfe der `add`‑Methoden der Farbverlauf‑Stop‑Sammlung hinzu, die von der Klasse [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende JavaScript‑Code demonstriert, wie man einer Ellipse einen Verlaufsfüllungseffekt hinzufügt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Setzen Sie die Richtung des Verlaufs.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Fügen Sie zwei Verlaufsstopps hinzu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Falls ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Rendering‑Stil auswählen, ohne die in der Präsentation gespeicherte Verlaufsfüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anzuwenden. Sie können benutzerdefinierte Farben für Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu steigern. Auch nach der Auswahl eines vordefinierten Musters können Sie noch die genauen Farben festlegen, die verwendet werden sollen.

Hier erfahren Sie, wie Sie mit Aspose.Slides eine Musterfüllung auf eine Form anwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende JavaScript‑Code demonstriert, wie man einer Rechtecksform eine Musterfüllung hinzufügt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Muster.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Setzen Sie den Musterstil.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in eine Form einzufügen – das Bild wird dabei effektiv als Hintergrund der Form verwendet.

Hier erfahren Sie, wie Sie mit Aspose.Slides eine Bildfüllung auf eine Form anwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `ISlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Angenommen, wir haben eine Datei "lotus.png" mit folgendem Bild:

![Das Lotus-Bild](lotus.png)

Der folgende JavaScript‑Code demonstriert, wie man einer Form das Bild zuweist:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Setzen Sie den Fülltyp auf Bild.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Setzen Sie den Bildfüllungsmodus.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Setzen Sie das Bild.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert den horizontalen Maßstab der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Code‑Beispiel zeigt, wie man einer Rechtecksform eine gekachelte Bildfüllung hinzufügt und Kachel‑Optionen konfiguriert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine Rechteck‑AutoShape hinzu.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Bild.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Weisen Sie das Bild der Form zu.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kacheligeigenschaften.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese schlichte Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

Um mit Aspose.Slides eine einfarbige Füllung auf eine Form anzuwenden, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende JavaScript‑Code demonstriert, wie man einer Rechtecksform in einer PowerPoint‑Folien eine einfarbige Füllung hinzufügt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Setzen Sie die Füllfarbe.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie beim Anwenden einer einfarbigen, Verlauf-, Bild‑ oder Texturfüllung auf Formen auch einen Transparenzwert festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem der Alpha‑Wert der für die Füllung verwendeten Farbe angepasst wird. Hier erfahren Sie, wie es geht:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code demonstriert, wie man einer Rechtecksform eine transparente Füllfarbe zuweist:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine solide Rechteck‑AutoShape hinzu.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck‑AutoShape über der soliden Form hinzu.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungen oder Designanforderungen positioniert werden sollen.

Um eine Form auf einer Folie zu drehen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die Rotations‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code demonstriert, wie man eine Form um 5 Grad dreht:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie.
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    shape.setRotation(5);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Formrotation](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Kanteneffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) Eigenschaften konfiguriert werden.

Um einer Form 3D‑Kanteneffekte hinzuzufügen, gehen Sie wie folgt vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) der Form, um Kanten‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code zeigt, wie man 3D‑Kanteneffekte auf eine Form anwendet:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Erstellen Sie eine Instanz der Presentation-Klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Fügen Sie der Folie eine Form hinzu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Setzen Sie die ThreeDFormat-Eigenschaften der Form.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der 3D‑Kanteneffekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) Eigenschaften konfiguriert werden.

Um einer Form 3D‑Drehungen hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code demonstriert, wie man 3D‑Drehungseffekte auf eine Form anwendet:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Erstellen Sie eine Instanz der Presentation‑Klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung von Formen steuern**

Die Methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation in Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert nicht selbst die Schwarz‑Weiß‑Anzeige und ändert weder die Füllung, Linie noch andere Formatierungen der Form im normalen Farbmodus.

Verwenden Sie einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Grautöne, `BlackWhite` verwendet nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` erhält die normale Farben bei, und `Hidden` blendet die Form im Schwarz‑Weiß‑Modus aus. `NotDefined` bedeutet, dass kein Form‑Ebene‑Modus zugewiesen ist.

Der folgende JavaScript‑Code erstellt eine farbige Form und lässt sie im Schwarz‑Weiß‑Anzeigemodus grau erscheinen:

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

    // Behalte die orange Füllung im Farbmodus, aber rendere die Form mit grauer Färbung im Schwarz-Weiß-Modus.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑Weiß‑Anzeige‑Workflow wird es grau dargestellt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Folie in Vollfarbe erhalten und gleichzeitig ein separates Erscheinungsbild für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende JavaScript‑Code zeigt, wie man die Formatierung einer Folie zurücksetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) auf ihre Standard‑Einstellungen zurückführt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur sehr wenig. Eingebettete Bilder und Medien beanspruchen den größten Teil des Dateiraums, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keine zusätzliche Größe hinzufügen.

**Wie kann ich Formen auf einer Folie erkennen, die dieselbe Formatierung besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, betrachten Sie deren Stile als identisch und gruppieren die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einem Vorlagen‑Foliendeck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie gebraucht wird.