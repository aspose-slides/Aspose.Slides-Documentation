---
title: Formatin von Formen
type: docs
weight: 20
url: /de/java/shape-formatting/
keywords: "Form formatieren, Linien formatieren, Verbindungsstile formatieren, Farbverlauffüllung, Musterfüllung, Bildfüllung, einfarbige Füllung, Formen drehen, 3D-Fasen-Effekte, 3D-Drehungseffekt, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Form in PowerPoint-Präsentation in Java formatieren"
---

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie Formen formatieren, indem Sie bestimmte Effekte auf ihre Bestandteile anwenden oder diese modifizieren. Darüber hinaus können Sie Formen formatieren, indem Sie Einstellungen festlegen, die bestimmen, wie sie (der darin enthaltene Bereich) gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides für Java** bietet Schnittstellen und Eigenschaften, die es Ihnen ermöglichen, Formen basierend auf bekannten Optionen in PowerPoint zu formatieren.

## **Linien formatieren**

Mit Aspose.Slides können Sie Ihren bevorzugten Linienstil für eine Form angeben. Diese Schritte skizzieren ein solches Verfahren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Setzen Sie eine Farbe für die Linien der Form.
5. Setzen Sie die Breite für die Linien der Form.
6. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) für die Linien der Form.
7. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) für die Linien der Form.
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert eine Operation, bei der wir ein Rechteck `AutoShape` formatiert haben:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine Autohandform vom Rechtecktyp hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Setzt die Füllfarbe für die Rechtecksform
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Wendet einige Formatierungen an den Linien des Rechtecks an
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Setzt die Farbe für die Linie des Rechtecks
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verbindungsstile formatieren**
Dies sind die 3 Verbindungsoptionen:

* Rund
* Spitz
* Fase

Standardmäßig verwendet PowerPoint die Einstellung **Rund**, wenn es zwei Linien in einem Winkel (oder an einer Ecke einer Form) verbindet. Wenn Sie jedoch eine Form mit sehr scharfen Winkeln zeichnen möchten, sollten Sie **Spitz** auswählen.

![join-style-powerpoint](join-style-powerpoint.png)

Diese Java-Operation demonstriert die Erstellung von 3 Rechtecken (das obige Bild) mit den Verbindungsstileinstellungen Spitz, Fase und Rund:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {

    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt 3 rechteckige Autohandformen hinzu
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Setzt die Füllfarbe für die Rechtecksform
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Setzt die Breite der Linie
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // Setzt die Farbe für die Linie des Rechtecks
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Setzt den Verbindungsstil
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Fügt jedem Rechteck Text hinzu
    ((IAutoShape)shp1).getTextFrame().setText("Miter Join Style");
    ((IAutoShape)shp2).getTextFrame().setText("Bevel Join Style");
    ((IAutoShape)shp3).getTextFrame().setText("Round Join Style");

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Farbverlauffüllung**
In PowerPoint ist die Farbverlauffüllung eine Formatierungsoption, die es Ihnen ermöglicht, eine kontinuierliche Farbverlauffüllung auf eine Form anzuwenden. Zum Beispiel können Sie zwei oder mehr Farben in einem Setup anwenden, bei dem eine Farbe allmählich in eine andere Farbe übergeht.

So verwenden Sie Aspose.Slides, um eine Farbverlauffüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) der Form auf `Gradient`.
5. Fügen Sie Ihre 2 bevorzugten Farben mit definierten Positionen hinzu, indem Sie die `Add`-Methoden verwenden, die von der `GradientStops`-Sammlung bereitgestellt werden, die mit der `GradientFormat`-Klasse verknüpft ist.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert eine Operation, bei der der Farbverlaufseffekt auf einer Ellipse verwendet wurde:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine elliptische Autohandform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Wendet die Farbverlaufformatierung auf die Ellipse an
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Setzt die Richtung des Farbverlaufs
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Fügt 2 Farbverlaufstopps hinzu
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Musterfüllung**
In PowerPoint ist die Musterfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein zweifarbige Design, das aus Punkten, Streifen, Kreuzschraffuren oder Überprüfungen besteht, auf eine Form anzuwenden. Darüber hinaus können Sie Ihre bevorzugten Farben für den Vordergrund und den Hintergrund Ihres Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Stile, die zur Formatierung von Formen verwendet werden können und die Präsentationen bereichern. Selbst nachdem Sie ein vordefiniertes Muster ausgewählt haben, können Sie weiterhin die Farben angeben, die das Muster enthalten muss.

So verwenden Sie Aspose.Slides, um eine Musterfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) der Form auf `Pattern`.
5. Setzen Sie Ihren bevorzugten Musterstil für die Form.
6. Setzen Sie die [Hintergrundfarbe](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) für das [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
7. Setzen Sie die [Vordergrundfarbe](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--) für das [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert eine Operation, bei der eine Musterfüllung verwendet wurde, um ein Rechteck zu verschönern:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine rechteckige Autohandform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Muster
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Setzt den Musterstil
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Setzt die Musterhintergrund- und Vordergrundfarben
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bildfüllung**
In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild innerhalb einer Form zu platzieren. Im Wesentlichen können Sie ein Bild als Hintergrund einer Form verwenden.

So verwenden Sie Aspose.Slides, um eine Form mit einem Bild zu füllen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) der Form auf `Picture`.
5. Setzen Sie den Bildfüllmodus auf Kacheln.
6. Erstellen Sie ein `IPPImage`-Objekt mit dem Bild, das verwendet werden soll, um die Form zu füllen.
7. Setzen Sie die `Picture.Image`-Eigenschaft des `PictureFillFormat`-Objekts auf das kürzlich erstellte `IPPImage`.
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie eine Form mit einem Bild füllen:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine rechteckige Autohandform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Setzt den Fülltyp auf Bild
    shp.getFillFormat().setFillType(FillType.Picture);

    // Setzt den Bildfüllmodus
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Setzt das Bild
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Einfarbige Füllung**
In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die es Ihnen ermöglicht, eine Form mit einer einzigen Farbe zu füllen. Die gewählte Farbe ist normalerweise eine einfarbige Farbe. Die Farbe wird auf den Hintergrund der Form angewendet, ohne spezielle Effekte oder Modifikationen.

So verwenden Sie Aspose.Slides, um eine einfarbige Füllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) der Form auf `Solid`.
5. Setzen Sie Ihre bevorzugte Farbe für die Form.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die einfarbige Füllung auf eine Box in PowerPoint anwenden:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine rechteckige Autohandform hinzu
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Solid
    shape.getFillFormat().setFillType(FillType.Solid);

    // Setzt die Farbe für das Rechteck
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Transparenz einstellen**

In PowerPoint können Sie beim Füllen von Formen mit einfarbigen Farben, Farbverläufen, Bildern oder Texturen den Transparenzgrad festlegen, der die Opazität einer Füllung bestimmt. Auf diese Weise zeigt, wenn Sie einen niedrigen Transparenzgrad festlegen, das Folienobjekt oder der Hintergrund hinter (der Form) durch.

Aspose.Slides ermöglicht es Ihnen, den Transparenzgrad für eine Form auf folgende Weise festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Verwenden Sie `new Color` mit dem festgelegten Alpha-Komponentenwert.
5. Speichern Sie das Objekt als PowerPoint-Datei.

Dieser Java-Code demonstriert den Prozess:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine solide Form hinzu
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Fügt eine transparente Form über der soliden Form hinzu
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formen rotieren**
Aspose.Slides ermöglicht es Ihnen, eine Form, die zu einer Folie hinzugefügt wurde, auf folgende Weise zu drehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Drehen Sie die Form um die benötigten Grad.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie eine Form um 90 Grad drehen:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine rechteckige Autohandform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Dreht die Form um 90 Grad
    shp.setRotation(90);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D-Fasen-Effekte hinzufügen**
Aspose.Slides ermöglicht es Ihnen, 3D-Fasen-Effekte zu einer Form hinzuzufügen, indem Sie ihre [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)-Eigenschaften auf folgende Weise ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Setzen Sie Ihre bevorzugten Parameter für die [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)-Eigenschaften der Form.
5. Schreiben Sie die Präsentation auf die Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie 3D-Fasen-Effekte zu einer Form hinzufügen:

```java
// Erstellt eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine Form zur Folie hinzu
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Setzt die ThreeDFormat-Eigenschaften der Form
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Schreibt die Präsentation als PPTX-Datei
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D-Drehungseffekt hinzufügen**
Aspose.Slides ermöglicht es Ihnen, 3D-Drehungseffekte zu einer Form hinzuzufügen, indem Sie ihre [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)-Eigenschaften wie folgt ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) hinzu.
4. Geben Sie Ihre bevorzugten Figuren für [CameraType](https://reference.aspose.com/slides/java/com.aspose.slides/ICamera#getCameraType--) und [LightType](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRig#getLightType--) an.
5. Schreiben Sie die Präsentation auf die Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie 3D-Drehungseffekte auf eine Form anwenden:

```java
// Erstellt eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Schreibt die Präsentation als PPTX-Datei
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formatierung zurücksetzen**

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung in einer Folie zurücksetzen und die Position, Größe und Formatierung jeder Form, die einen Platzhalter auf der [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutSlide) hat, auf ihre Standardwerte zurücksetzen:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // Jede Form auf der Folie, die einen Platzhalter hat, wird zurückgesetzt
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```