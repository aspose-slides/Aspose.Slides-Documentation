---
title: PowerPoint-Formen in Java formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Skizzenformlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Form drehen
- 3D-Fasen-Effekt
- 3D-Dreh-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Java mit Aspose.Slides formatieren – füllen, Linien und Effekte für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie deren Umrisse formatieren, indem Sie die Linien modifizieren oder Effekte darauf anwenden. Außerdem können Sie Formen formatieren, indem Sie Einstellungen festlegen, die bestimmen, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java bietet Schnittstellen und Methoden, mit denen Sie Formen auf dieselbe Weise wie in PowerPoint formatieren können.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Der folgende Ablauf beschreibt die Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/de/java/com.aspose.slides/linestyle/) der Form.
1. Legen Sie die Linienbreite fest.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/de/java/com.aspose.slides/linedashstyle/) der Linie.
1. Definieren Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Code demonstriert, wie ein Rechteck‑AutoShape formatiert wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Wenden Sie Formatierungen auf die Linien des Rechtecks an.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Setzen Sie die Farbe für die Linie des Rechtecks.
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

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet erscheinen. Verwenden Sie [IShape.getLineFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/), um auf die Linieneinstellungen zuzugreifen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformat/), um die Skizzeinstellungen zu erhalten, und [ISketchFormat.setSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isketchformat/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/linesketchtype/) auszuwählen.

Der folgende Java‑Code zeigt, wie der Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/de/java/com.aspose.slides/linesketchtype/) angewendet, der explizit zugewiesene Wert ausgelesen und der Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/java/com.aspose.slides/linesketchtype/) entfernt wird:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Wenden Sie einen Skizzeneffekt an.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lesen Sie den direkt der Form zugewiesenen Skizzeneffekt.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Entfernen Sie den Skizzeneffekt.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Der von [ISketchFormat.getSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isketchformat/) zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folie geerbt werden kann, verwenden Sie [ILineFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformat/), greifen Sie auf [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformateffectivedata/) zu und lesen Sie [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isketchformateffectivedata/). Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien unter einem Winkel (z. B. an einer Formkante) die Einstellung **Round**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende Java‑Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Verbindungsstil‑Einstellungen Miter, Bevel und Round erstellt wurden:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Setzen Sie die Füllfarbe für jede Rechteckform.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Setzen Sie die Linienbreite.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Setzen Sie die Farbe für die Linie jedes Rechtecks.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Setzen Sie den Verbindungsstil.
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

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es ermöglicht, einer Form einen kontinuierlichen Farbverlauf zuzuweisen. Sie können beispielsweise zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen über die `add`‑Methoden der Verlaufsstopp‑Sammlung hinzu, die von der [IGradientFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/igradientformat/)‑Schnittstelle bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Java‑Code demonstriert, wie ein Farbverlauf auf eine Ellipse angewendet wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufformatierung auf die Ellipse an.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Setzen Sie die Richtung des Farbverlaufs.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Fügen Sie zwei Verlaufsstopps hinzu.
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

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – z. B. Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können für Vorder‑ und Hintergrund des Musters eigene Farben wählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie auf Formen anwenden können, um Ihre Präsentationen optisch aufzuwerten. Selbst nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/patternformat/#getBackColor--) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/patternformat/#getForeColor--) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Java‑Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Muster.
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

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild in eine Form einzufügen – das Bild wird dabei zum Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Picture`.
1. Legen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen gewünschten Modus) fest.
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)-Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `ISlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Angenommen, wir haben die Datei „lotus.png“ mit folgendem Bild:

![The lotus picture](lotus.png)

Der folgende Java‑Code demonstriert, wie eine Form mit dem Bild gefüllt wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Setzen Sie den Fülltyp auf Bild.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Setzen Sie den Bildfüllungsmodus.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
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

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Methoden der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiert den horizontalen Maßstab der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Codeausschnitt zeigt, wie ein Rechteck mit einer gekachelten Bildfüllung hinzugefügt und die Kacheloptionen konfiguriert werden:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Fügen Sie ein Rechteck‑AutoShape hinzu.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Bild.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Weisen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kachel‑Eigenschaften.
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

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser schlichte Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Java‑Code demonstriert, wie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folie angewendet wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den FillType auf Solid.
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

In PowerPoint können Sie bei einfarbiger, Verlaufs‑, Bild‑ oder Texturfüllung einer Form auch einen Transparenzwert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert lässt die Form stärker durchscheinen, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem der Alpha‑Wert der für die Füllung verwendeten Farbe angepasst wird. So geht's:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die Komponente `alpha` steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie eine transparente Füllfarbe auf ein Rechteck angewendet wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
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

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit einer bestimmten Ausrichtung oder Design‑Anforderung positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Dreheigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie eine Form um 5 Grad gedreht wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
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

## **3D‑Fasen‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Fasen‑Effekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/threedformat/)-Eigenschaften konfiguriert werden.

So fügen Sie einer Form 3D‑Fasen‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/threedformat/) der Form, um die Faseneinstellungen zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie 3D‑Fasen‑Effekte auf eine Form angewendet werden:

```java
// Instanziieren Sie die Presentation-Klasse.
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

    // Setzen Sie die ThreeDFormat‑Eigenschaften der Form.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Speichern Sie die Präsentation als PPTX‑Datei.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Dreh‑Effekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/threedformat/)-Eigenschaften konfiguriert werden.

So wenden Sie einen 3D‑Dreh‑Effekt auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/de/java/com.aspose.slides/icamera/#setCameraType-int-) und [setLightType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilightrig/#setLightType-int-), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie 3D‑Dreh‑Effekte auf eine Form angewendet werden:

```java
// Instanziieren Sie die Presentation-Klasse.
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

Der folgende Java‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslide/) auf ihre Standardwerte zurückgesetzt werden:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Setze jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Dateiraums, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz beanspruchen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung aufweisen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, gelten die Stile als identisch und können logisch gruppiert werden, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Folien‑Datei oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestalteten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.