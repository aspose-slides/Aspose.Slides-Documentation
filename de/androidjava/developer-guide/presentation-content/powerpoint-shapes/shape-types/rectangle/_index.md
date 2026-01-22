---
title: Rechtecke zu Präsentationen auf Android hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/androidjava/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechteckform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Steigern Sie Ihre PowerPoint-Präsentationen, indem Sie mit Aspose.Slides für Android via Java Rechtecke hinzufügen – Formen einfach programmgesteuert entwerfen und ändern."
---

{{% alert color="primary" %}} 

Wie bei vorherigen Themen geht es auch hier um das Hinzufügen einer Form und diesmal behandeln wir die **Rectangle**. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides for Android via Java hinzufügen können.

{{% /alert %}} 

## **Ein Rectangle zu einer Folie hinzufügen**
Um ein einfaches Rectangle zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ Rectangle mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)‑Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir ein einfaches Rectangle zur ersten Folie der Präsentation hinzugefügt.
```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ein formatiertes Rectangle zu einer Folie hinzufügen**
Um ein formatiertes Rectangle zu einer Folie hinzuzufügen, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ Rectangle mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)‑Objekt bereitgestellt wird.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) des Rectangles auf Solid.
- Setzen Sie die Farbe des Rectangles über die Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) des mit dem [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)‑Objekt assoziierten [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat)‑Objekts.
- Setzen Sie die Farbe der Linien des Rectangles.
- Setzen Sie die Breite der Linien des Rectangles.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die obigen Schritte sind im nachfolgenden Beispiel umgesetzt.
```java
// Instantiieren Sie die Presentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Ellipse-Form an
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie füge ich ein Rectangle mit abgerundeten Ecken hinzu?**

Verwenden Sie den abgerundeten Eckentyp [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) und passen Sie den Eckradius in den Formeigenschaften an; das Abrunden kann auch pro Ecke über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rectangle mit einem Bild (Textur)?**

Wählen Sie den Bild‑[fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**Kann ein Rectangle Schatten und Leuchten haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/androidjava/shape-effect/) sind verfügbar und besitzen anpassbare Parameter.

**Kann ich ein Rectangle in einen Button mit Hyperlink verwandeln?**

Ja. [Assign a hyperlink](/slides/de/androidjava/manage-hyperlinks/) zur Form (Sprung zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rectangle vor Verschieben und Änderungen schützen?**

Verwenden Sie Form‑Locks: Sie können das Verschieben, Größenändern, Auswählen oder Textbearbeiten verbieten, um das Layout zu bewahren.

**Kann ich ein Rectangle in ein Rasterbild oder SVG konvertieren?**

Ja. Sie können die Form über [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) zu einem Bild mit festgelegter Größe/Skala rendern oder sie über [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) als SVG exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rectangles unter Berücksichtigung von Theme und Vererbung?**

[Use the shape’s effective properties](/slides/de/androidjava/shape-effective-properties/): Die API liefert berechnete Werte, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen und die Analyse der Formatierung vereinfachen.