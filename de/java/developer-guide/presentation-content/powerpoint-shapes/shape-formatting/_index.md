---
title: "PowerPoint-Formen in Java formatieren"
linktitle: "Formformatierung"
type: docs
weight: 20
url: /de/java/shape-formatting/
keywords:
- "Form formatieren"
- "Linie formatieren"
- "Verbindungsstil formatieren"
- "Verlaufsfüllung"
- "Musterfüllung"
- "Bildfüllung"
- "Texturfüllung"
- "Einfarbige Füllung"
- "Formtransparenz"
- "Form drehen"
- "3D-Kanteneffekt"
- "3D-Drehungseffekt"
- "Formatierung zurücksetzen"
- "PowerPoint"
- "Präsentation"
- "Java"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Java mit Aspose.Slides formatieren – füllen, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und mit voller Kontrolle festlegen."
---

## **Übersicht**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie deren Konturen formatieren, indem Sie die Linien modifizieren oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java bietet Schnittstellen und Methoden, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienstärke.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Code demonstriert, wie ein Rechteck‑`AutoShape` formatiert wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rechteck hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Legen Sie die Füllfarbe für die Rechteckform fest.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Verbindungsarten formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (wie an einer Formkante) die Einstellung **Round**. Wenn Sie jedoch eine Form mit spitzen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende Java‑Code zeigt, wie drei Rechtecke (wie im obigen Bild) mit den Einstellungen Miter, Bevel und Round erstellt wurden:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie drei AutoShapes des Typs Rechteck hinzu.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Legen Sie die Füllfarbe für jede Rechteckform fest.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Legen Sie die Linienbreite fest.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Legen Sie die Farbe für die Linie jedes Rechtecks fest.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Legen Sie den Verbindungsstil fest.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Fügen Sie jedem Rechteck Text hinzu.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einem Objekt einen kontinuierlichen Farbübergang zuweisen können. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass eine allmählich in die nächste übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden gewünschten Farben mit definierten Positionen mithilfe der `add`‑Methoden der Gradient‑Stop‑Sammlung hinzu, die vom [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/)‑Interface bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Java‑Code demonstriert, wie ein Ellipsen‑Verlaufsfüllungseffekt angewendet wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Ellipse hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Legen Sie die Richtung des Farbverlaufs fest.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Fügen Sie zwei Verlaufspunkte hinzu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anwenden können. Sie können benutzerdefinierte Farben für Vorder- und Hintergrund des Musters wählen.

Aspose.Slides stellt über 45 vordefinierte Mustervorlagen bereit, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Selbst nach der Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Mustertyp aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Java‑Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Setzen Sie den Musterstil.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild dient dabei als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‑Objekt aus dem zu verwendenden Bild.
1. Übergaben Sie das Bild an die Methode `ISlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Nehmen wir an, wir haben die Datei „lotus.png“ mit folgendem Bild:

![The lotus picture](lotus.png)

Der folgende Java‑Code demonstriert, wie eine Form mit dem Bild gefüllt wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Setzen Sie den Fülltyp auf Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Setzen Sie den Bildfüllungsmodus.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laden Sie ein Bild und fügen es den Präsentationsressourcen hinzu.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Setzen Sie das Bild.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The shape with picture fill](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur setzen und das Kachelverhalten anpassen möchten, können Sie die folgenden Methoden des [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/)‑Interfaces und der [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/)‑Klasse verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiert den horizontalen Maßstab der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Code‑Auszug zeigt, wie ein Rechteck mit gekachelter Bildfüllung hinzugefügt und die Kacheloptionen konfiguriert werden:
```java
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Fügen Sie ein Rechteck‑AutoShape hinzu.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Laden Sie das Bild und fügen es den Präsentationsressourcen hinzu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Weisen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kacheleleigenschaften.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser einfache Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Java‑Code demonstriert, wie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folien angewendet wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Setzen Sie die Füllfarbe.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlaufs‑, Bild‑ oder Texturfüllung auch einen Transparenzwert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides lässt Sie den Transparenzwert einstellen, indem Sie den Alpha‑Wert in der für die Füllung verwendeten Farbe anpassen. So geht's:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie eine transparente Füllfarbe auf ein Rechteck angewendet wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie ein festes Rechteck‑AutoShape hinzu.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie ein transparentes Rechteck‑AutoShape über dem festen Shape hinzu.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Das kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungen oder Design‑Ansprüchen zu positionieren.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Drehungseigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie eine Form um 5 Grad gedreht wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    shape.setRotation(5);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Kanteneffekten auf Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) konfiguriert werden.

So fügen Sie einer Form 3D‑Kanteneffekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) der Form, um die Kanten‑Einstellungen zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie 3D‑Kanteneffekte auf eine Form angewendet werden:
```java
// Erstellen Sie eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie der Folie eine Form hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Setzen Sie die ThreeDFormat-Eigenschaften der Form.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) konfiguriert werden.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) und [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie 3D‑Drehungseffekte auf eine Form angewendet werden:
```java
// Erstellen Sie eine Instanz der Presentation-Klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The 3D rotation effect](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende Java‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe sowie Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) zu den Standardeinstellungen zurückgesetzt werden:
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, können Sie deren Stile als identisch behandeln und die Formen logisch gruppieren, was die spätere Stilverwaltung vereinfacht.

**Kann ich einen Satz benutzerdefinierter Formstile in einer separaten Datei speichern, um ihn in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispielformen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, duplizieren die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie gebraucht wird.