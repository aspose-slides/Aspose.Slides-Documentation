---
title: PowerPoint-Formen auf Android formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/androidjava/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeneffekt
- Skizzenlinien der Form
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz-weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Kehleneffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen auf Android mit Aspose.Slides formatieren - füllen, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie deren Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie ihre Innenflächen gefüllt werden.

![Formformat PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für Android via Java bietet Schnittstellen und Methoden, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Verfahren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Code zeigt, wie man ein Rechteck-`AutoShape` formatiert:

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

    // Entfernen Sie die Füllung der Rechteckform, sodass nur die Linien sichtbar sind.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Formatieren Sie die Linien des Rechtecks.
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

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt die Linie einer Form handgezeichnet erscheinen. Verwenden Sie [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) , um auf die Linieneinstellungen zuzugreifen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) , um auf die Skizzeneinstellungen zuzugreifen, und [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) , um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) auszuwählen.

Der folgende Java-Code zeigt, wie man den Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) entfernt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und dessen Skizzformat zu.
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

Der von [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Theme, einer Masterfolie oder einer Layoutfolie geerbt werden kann, verwenden Sie [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) , greifen Sie auf [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) zu und lesen Sie [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/) . Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

```java
import com.aspose.slides.*;

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

## **Join‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungsstil:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (wie an einer Ecke einer Form) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit spitzen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Gehrung**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende Java-Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Join‑Typ‑Einstellungen Gehrung, Fase und Rund erstellt wurden:

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

    // Setzen Sie die Füllfarbe für jede Rechtecksform.
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

## **Verlauffüllung**

In PowerPoint ist die Verlauffüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbverlauf auftragen können. Zum Beispiel können Sie zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlauffüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen mithilfe der `add`‑Methoden der Verlauf‑Stop‑Sammlung hinzu, die von der Schnittstelle [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Java-Code demonstriert, wie man einer Ellipse einen Verlaufseffekt hinzufügt:

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

![Die Ellipse mit Verlauffüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Wählen Sie einen Verlaufdarstellungsstil](/slides/de/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Darstellungsstil auswählen, ohne die im Dokument gespeicherte Verlauffüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – hinzufügen können. Sie können benutzerdefinierte Farben für den Vordergrund und Hintergrund des Musters wählen.

Aspose.Slides bietet über 45 vordefinierte Mustervorlagen, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu steigern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Mustertyp aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Java-Code demonstriert, wie man ein Rechteck mit Musterfüllung versieht:

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

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild wird effektiv als Hintergrund der Form verwendet.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung hinzuzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `ISlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

![Das Lotus-Bild](lotus.png)

Der folgende Java-Code demonstriert, wie man einer Form das Bild hinzufügt:

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

![Die Form mit Bildfüllung](picture-fill.png)

### **Kachelbild als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Methoden der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) : Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-) : Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-) : Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-) : Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-) : Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-) : Definiert den horizontalen Maßstab der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-) : Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Code‑Beispiel zeigt, wie man ein Rechteck mit gekachelter Bildfüllung erstellt und Kacheloptionen konfiguriert:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine Rechteck-AutoShape hinzu.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Weisen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kachel-Eigenschaften.
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

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser schlichte Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Java-Code demonstriert, wie man einer Rechtecks‑Form in einer PowerPoint‑Folie eine einfarbige Füllung zuweist:

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

In PowerPoint können Sie bei einer einfarbigen, Verlauf‑, Bild‑ oder Texturffüllung die Transparenz einstellen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides lässt Sie die Transparenz festlegen, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht's:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende Java-Code demonstriert, wie man einer Rechtecks‑Form eine transparente Füllfarbe zuweist:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine einfarbige Rechteck‑AutoShape hinzu.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck‑AutoShape über der einfarbigen Form hinzu.
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

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides lässt Sie Formen in PowerPoint‑Präsentationen drehen. Das kann nützlich sein, wenn visuelle Elemente mit bestimmter Ausrichtung oder Design‑Anforderung positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Rotationseigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende Java-Code demonstriert, wie man eine Form um 5 Grad dreht:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotieren Sie die Form um 5 Grad.
    shape.setRotation(5);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Formrotation](shape-rotation.png)

## **3D‑Kehleneffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Kehleneffekten zu Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) konfiguriert werden.

So fügen Sie einer Form 3D‑Kehleneffekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) der Form, um Kehleneinstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende Java-Code zeigt, wie man einer Form 3D‑Kehleneffekte hinzufügt:

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

![Der 3D‑Kehleneffekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Drehungseffekten zu Formen, indem die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) konfiguriert werden.

So wenden Sie 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Verwenden Sie die Methoden [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) und [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende Java-Code demonstriert, wie man einer Form 3D‑Drehungseffekte hinzufügt:

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

Die Methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation in Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert die Füllung, Linie oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) , um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Grautöne, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine einfarbige Darstellung, `Color` bewahrt die normale Farbgebung, und `Hidden` blendet die Form im Schwarz‑weiß‑Modus aus. `NotDefined` bedeutet, dass kein formbezogener Modus zugewiesen ist.

Der folgende Java-Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeigemodus grau erscheinen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Behalten Sie die orange Füllung im Farbmodus, aber rendern Sie die Form mit grauer Farbgebung im Schwarz-weiß-Modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orangefarbene Füllung bei. In einem Schwarz‑weiß‑Anzeige‑Workflow wird es grau gefärbt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Folie in voller Farbe beibehalten und gleichzeitig ein separates Erscheinungsbild für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende Java-Code zeigt, wie man die Formatierung einer Folie zurücksetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) auf ihre Standardwerte zurücksetzt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Setzen Sie jede Form auf der Folie zurück, die im Layout einen Platzhalter hat.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz beanspruchen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, damit ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, behandeln Sie ihre Stile als identisch und gruppieren die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestylten Formen und wenden deren Formatierung dort an, wo sie erforderlich ist.