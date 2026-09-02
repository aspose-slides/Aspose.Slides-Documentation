---
title: PowerPoint-Formen in Java formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizze-Effekt
- Skizzenformlinie
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
- 3D-Abrundungseffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in Java mit Aspose.Slides formatieren - Füll-, Linien- und Effekts­stile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenräume gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java bietet Schnittstellen und Methoden, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/de/java/com.aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/de/java/com.aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Code demonstriert, wie man ein Rechteck‑`AutoShape` formatiert:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Wenden Sie die Formatierung auf die Linien des Rechtecks an.
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

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizze‑Effekte auf Formlinien anwenden**

Ein Skizze‑Effekt lässt eine Formlinie handgezeichnet aussehen. Verwenden Sie [IShape.getLineFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/), um auf die Linieneinstellungen zuzugreifen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformat/), um auf die Skizzeeinstellungen zuzugreifen, und [ISketchFormat.setSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isketchformat/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/linesketchtype/) auszuwählen.

Der folgende Java‑Code zeigt, wie man den Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/de/java/com.aspose.slides/linesketchtype/) anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/java/com.aspose.slides/linesketchtype/) entfernt:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Wenden Sie einen Skizze-Effekt an.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lesen Sie den direkt der Form zugewiesenen Skizze-Effekt.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Entfernen Sie den Skizze-Effekt.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Der von [ISketchFormat.getSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isketchformat/) zurückgegebene Wert stellt die Einstellung dar, die direkt der Form zugewiesen wurde. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [ILineFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformat/), greifen Sie auf [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformateffectivedata/) zu und lesen Sie [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isketchformateffectivedata/) aus. Der wirksame Wert spiegelt die Formatierung wider, die tatsächlich nach Auflösung der Vererbung angewendet wird:

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

## **Verbindungs‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint, wenn es zwei Linien in einem Winkel (z. B. an einer Form‑Ecke) verbindet, die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Gehrung**.

![Der Verbindungs‑Stil in der Präsentation](join-style-powerpoint.png)

Der folgende Java‑Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Verbindungs‑Stileinstellungen Gehrung, Fase bzw. Rund erstellt wurden:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie drei AutoShapes vom Typ Rectangle hinzu.
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

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es Ihnen ermöglicht, einer Form einen kontinuierlichen Farbübergang zuzuweisen. Sie können beispielsweise zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen mithilfe der `add`‑Methoden der Gradient‑Stop‑Sammlung hinzu, die von der Schnittstelle [IGradientFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/igradientformat/) bereitgestellt wird.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Java‑Code demonstriert, wie man einer Ellipse einen Verlaufsfüllungseffekt hinzufügt:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Setzen Sie die Richtung des Verlaufs.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Fügen Sie zwei Farbverlaufspunkte hinzu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – z. B. Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können für den Vorder‑ und Hintergrund des Musters eigene Farben wählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um das visuelle Erscheinungsbild Ihrer Präsentationen zu verbessern. Selbst nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/patternformat/#getBackColor--) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/patternformat/#getForeColor--) des Musters.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Java‑Code demonstriert, wie man einer Rechteckform eine Musterfüllung zuweist:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
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

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in eine Form einzufügen – das Bild dient dabei als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung zuzuweisen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungs‑Modus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)-Objekt aus dem Bild, das Sie verwenden möchten.
1. Überggeben Sie das Bild an die Methode `ISlidesPicture.setImage`.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Angenommen, wir haben eine Datei „lotus.png“ mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

Der folgende Java‑Code demonstriert, wie man eine Form mit dem Bild füllt:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
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

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Methoden der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Legt den Bildfüllungs‑Modus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileOffsetY](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileScaleX](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Beispielcode zeigt, wie man ein Rechteck mit gekachelter Bildfüllung hinzufügt und die Kacheloptionen konfiguriert:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine Rechteck‑AutoShape hinzu.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Laden Sie das Bild und fügen Sie es den Präsentationsressourcen hinzu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Ordnen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kacheleigenschaften.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser einheitliche Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Java‑Code demonstriert, wie man einer Rechteckform in einer PowerPoint‑Folie eine einfarbige Füllung zuweist:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
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

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, verlaufs-, bild‑ oder texturellen Füllung von Formen auch einen Transparenzgrad festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzgrads, indem Sie den Alpha‑Wert in der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) der Form auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die Komponente `alpha` steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie man einer Rechteckform eine transparente Füllfarbe zuweist:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine feste Rechteck-AutoShape hinzu.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck-AutoShape über der festen Form hinzu.
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

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit bestimmter Ausrichtung oder Designanforderungen positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Rotationseigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie man eine Form um 5 Grad dreht:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie ein AutoShape vom Typ Rectangle hinzu.
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

![Die Formdrehung](shape-rotation.png)

## **3D‑Abrundungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Abrundungseffekten auf Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/threedformat/) konfiguriert werden.

So fügen Sie einer Form 3D‑Abrundungseffekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/threedformat/) der Form, um die Abrundungseinstellungen zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie man 3D‑Abrundungseffekte auf eine Form anwendet:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Der 3D‑Abrundungseffekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/threedformat/) konfiguriert werden.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/de/java/com.aspose.slides/icamera/#setCameraType-int-) und [setLightType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilightrig/#setLightType-int-), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert, wie man 3D‑Drehungseffekte auf eine Form anwendet:

```java
import com.aspose.slides.*;

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

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Darstellung für Formen steuern**

Die Methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert die Füllung, Kontur oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Render‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graustufen, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` erhält die normale Farbdarstellung und `Hidden` blendet die Form im Schwarz‑weiß‑Modus aus. `NotDefined` bedeutet, dass kein formbezogener Modus zugewiesen ist.

Der folgende Java‑Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeige­modus grau erscheinen:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Behalten Sie die orange Füllung im Farbmodus bei, aber rendern Sie die Form mit grauer Färbung im Schwarz‑weiß‑Modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orangefarbene Füllung. In einem Schwarz‑weiß‑Darstellungs‑Workflow wird es grau angezeigt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Vollfarbfolie beibehalten und gleichzeitig ein separates Erscheinungsbild für den Druck, die Vorschau oder andere Workflows festlegen, die die Schwarz‑weiß‑Anzeige‑Einstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende Java‑Code zeigt, wie man die Formatierung einer Folie zurücksetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslide/) auf die Standardwerte zurücksetzt:

```java
import com.aspose.slides.*;

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

Nur minimal. Eingebettete Bilder und Medien beanspruchen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung aufweisen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Kontur und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich einen Satz benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um ihn in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie erforderlich ist.