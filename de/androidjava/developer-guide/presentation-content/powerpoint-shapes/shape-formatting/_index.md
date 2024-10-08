---
title: Formatausführung
type: docs
weight: 20
url: /de/androidjava/shape-formatting/
keywords: "Formatausführung, Linieneinstellungen, Join-Stile, Farbverlauf, Musterfüllung, Bildfüllung, einfarbige Füllung, Formen drehen, 3D-Facetteneffekte, 3D-Rotationseffekt, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Formatiere Formen in PowerPoint-Präsentationen mit Java"
---

In PowerPoint kannst du Formen zu Dias hinzufügen. Da Formen aus Linien bestehen, kannst du Formen formatieren, indem du deren Bestandteile (Linien) änderst oder bestimmte Effekte anwendest. Darüber hinaus kannst du Formen formatieren, indem du Einstellungen angibst, die bestimmen, wie sie (der Bereich in ihnen) gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides für Android über Java** bietet Schnittstellen und Eigenschaften, mit denen du Formen basierend auf bekannten Optionen in PowerPoint formatieren kannst.

## **Linien formatieren**

Mit Aspose.Slides kannst du deinen bevorzugten Linienstil für eine Form festlegen. Diese Schritte umreißen ein solches Verfahren:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Setze eine Farbe für die Linien der Form.
5. Setze die Breite für die Linien der Form.
6. Setze den [Linienstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) für die Linieneinstellungen der Form.
7. Setze den [Dash-Stil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) für die Linieneinstellungen der Form.
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert eine Operation, bei der wir ein Rechteck (`AutoShape`) formatiert haben:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich das erste Dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine Autoform des Rechtecktyps hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Setzt die Füllfarbe für die Rechtecksform
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Wendet einige Formatierungen auf die Linien des Rechtecks an
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

## **Join-Stile formatieren**

Dies sind die 3 Optionen für den Joining-Typ:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint die **Rund**-Einstellung, wenn zwei Linien in einem Winkel (oder an einer Ecke einer Form) verbunden werden. Wenn du jedoch eine Form mit sehr scharfen Winkeln zeichnen möchtest, solltest du **Gehrung** auswählen.

![join-style-powerpoint](join-style-powerpoint.png)

Dieses Java-Beispiel demonstriert eine Operation, bei der 3 Rechtecke (das obige Bild) mit den Join-Typ-Einstellungen Gehrung, Fase und Rund erstellt wurden:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {

    // Holt sich das erste Dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt 3 Rechteck-Autoformen hinzu
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

    // Setzt die Linienbreite
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

    // Setzt den Join-Stil
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Fügt jedem Rechteck Text hinzu
    ((IAutoShape)shp1).getTextFrame().setText("Gehrung Join-Stil");
    ((IAutoShape)shp2).getTextFrame().setText("Fase Join-Stil");
    ((IAutoShape)shp3).getTextFrame().setText("Rund Join-Stil");

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Farbverlauf**
In PowerPoint ist Farbverlauf eine Formatierungsoption, die es dir ermöglicht, eine durchgehende Farbmischung auf eine Form anzuwenden. Zum Beispiel kannst du zwei oder mehr Farben in einem Setup anwenden, bei dem eine Farbe allmählich in eine andere Farbe übergeht.

So verwendest du Aspose.Slides, um einem Shape eine Farbverlauf-Füllung anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) der Form auf `Gradient`.
5. Füge deine 2 bevorzugten Farben mit definierten Positionen unter Verwendung der `Add`-Methoden hinzu, die von der `GradientStops`-Sammlung bereitgestellt werden, die mit der `GradientFormat`-Klasse verbunden ist.
6. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert eine Operation, bei der der Farbverlaufseffekt auf eine Ellipse angewendet wurde:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich das erste Dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine Ellipsen-Autoform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Wendet die Farbverlauf-Formatierung auf die Ellipse an
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Setzt die Richtung des Farbverlaufs
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Füge 2 Farbverlaufsstopps hinzu
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Musterfüllung**
In PowerPoint ist Musterfüllung eine Formatierungsoption, die es dir ermöglicht, ein zweifarbige Design, bestehend aus Punkten, Streifen, Kreuzschraffuren oder Karos, auf eine Form anzuwenden. Außerdem kannst du deine bevorzugten Farben für den Vordergrund und den Hintergrund deines Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Stile, die verwendet werden können, um Formen zu formatieren und Präsentationen zu bereichern. Auch nachdem du ein vordefiniertes Muster ausgewählt hast, kannst du die Farben, die das Muster enthalten muss, weiterhin festlegen.

So verwendest du Aspose.Slides, um einer Form eine Musterfüllung anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) der Form auf `Pattern`.
5. Setze deinen bevorzugten Musterstil für die Form.
6. Setze die [Hintergrundfarbe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--) für die [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
7. Setze die [Vordergrundfarbe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--) für die [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert eine Operation, bei der eine Musterfüllung verwendet wurde, um ein Rechteck zu verschönern:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich das erste Dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine Rechteck-Autoform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Muster
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Setzt den Musterstil
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Setzt die Muster Hintergrund- und Vordergrundfarben
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bildfüllung**
In PowerPoint ist Bildfüllung eine Formatierungsoption, die es dir ermöglicht, ein Bild in eine Form einzufügen. Im Wesentlichen erhältst du die Möglichkeit, ein Bild als Hintergrund einer Form zu verwenden.

So verwendest du Aspose.Slides, um eine Form mit einem Bild zu füllen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erhalte eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) der Form auf `Picture`.
5. Setze den Bildfüllmodus auf Kachel.
6. Erstelle ein `IPPImage`-Objekt mit dem Bild, das verwendet wird, um die Form zu füllen.
7. Setze die `Picture.Image`-Eigenschaft des `PictureFillFormat`-Objekts auf das neu erstellte `IPPImage`.
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt dir, wie du eine Form mit einem Bild füllst:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich das erste Dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine Rechteck-Autoform hinzu
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

## **Einfache Farbfüllung**
In PowerPoint ist einfache Farbfüllung eine Formatierungsoption, die es dir ermöglicht, eine Form mit einer einzigen Farbe zu füllen. Die gewählte Farbe ist typischerweise eine einfarbige Farbe. Die Farbe wird auf den Hintergrund der Form angewendet, ohne spezielle Effekte oder Modifikationen.

So verwendest du Aspose.Slides, um eine einfache Farbfüllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Setze den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) der Form auf `Solid`.
5. Setze deine bevorzugte Farbe für die Form.
6. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt dir, wie du die einfache Farbfüllung auf eine Box in PowerPoint anwendest:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich das erste Dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine Rechteck-Autoform hinzu
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Einfach
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

In PowerPoint kannst du beim Füllen von Formen mit einfarbigen Farben, Farbverläufen, Bildern oder Texturen den Transparenzgrad angeben, der die Opazität einer Füllung bestimmt. Auf diese Weise zeigt beispielsweise ein niedriger Transparenzgrad das dahinterliegende Folienobjekt oder den Hintergrund (der Form) durch.

Aspose.Slides ermöglicht es dir, den Transparenzgrad für eine Form folgendermaßen festzulegen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Verwende `new Color` mit dem Alpha-Komponentenwert.
5. Speichere das Objekt als PowerPoint-Datei.

Dieser Java-Code demonstriert den Prozess:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine feste Form hinzu
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Fügt eine transparente Form über der festen Form hinzu
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formen drehen**
Aspose.Slides ermöglicht es dir, eine Form, die einem Dia hinzugefügt wurde, folgendermaßen zu drehen: 

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Drehe die Form um die benötigten Grad. 
5. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt dir, wie du eine Form um 90 Grad drehst:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich das erste Dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine Rechteck-Autoform hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Dreht die Form um 90 Grad
    shp.setRotation(90);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D-Facetteneffekte hinzufügen**
Aspose.Slides ermöglicht es dir, 3D-Facetteneffekte zu einer Form hinzuzufügen, indem du deren [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) Eigenschaften folgendermaßen änderst:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Setze deine bevorzugten Parameter für die [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) Eigenschaften der Form.
5. Schreibe die Präsentation auf die Festplatte.

Dieser Java-Code zeigt dir, wie du 3D-Facetteneffekte zu einer Form hinzufügst:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine Form zum Dia hinzu
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Setzt die Eigenschaften der ThreeDFormat
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

## **3D-Rotationseffekt hinzufügen**
Aspose.Slides ermöglicht es dir, 3D-Rotationseffekte einer Form hinzuzufügen, indem du deren [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) Eigenschaften folgendermaßen änderst:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Hole dir eine Dia-Referenz über seinen Index.
3. Füge ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zum Dia hinzu.
4. Gib deine bevorzugten Figuren für [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--) und [LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--) an. 
5. Schreibe die Präsentation auf die Festplatte.

Dieser Java-Code zeigt dir, wie du 3D-Rotationseffekte auf eine Form anwendest:

```java
// Erstellt eine Instanz der Presentation-Klasse
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

## **Format zurücksetzen**

Dieser Java-Code zeigt dir, wie du das Format in einem Dia zurücksetzen und die Position, Größe und Formatierung jeder Form, die einen Platzhalter auf [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlide) hat, auf ihre Standardeinstellungen zurückbringen kannst:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // Jede Form auf dem Dia, die einen Platzhalter auf dem Layout hat, wird zurückgesetzt
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```