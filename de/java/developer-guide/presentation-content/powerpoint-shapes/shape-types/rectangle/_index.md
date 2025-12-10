---
title: Rechtecke zu Präsentationen in Java hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/java/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechteckform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Steigern Sie Ihre PowerPoint-Präsentationen, indem Sie mit Aspose.Slides für Java Rechtecke hinzufügen – erstellen und ändern Sie Formen einfach programmgesteuert."
---

{{% alert color="primary" %}} 

Wie bei vorherigen Themen geht es auch hier um das Hinzufügen einer Form und diesmal besprechen wir die **Rectangle**. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides for Java hinzufügen können.

{{% /alert %}} 

## **Ein Rechteck zu einer Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ Rectangle mittels der Methode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
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


## **Ein formatiertes Rechteck zu einer Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ Rectangle mittels der Methode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks über die Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) wie sie vom Objekt [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) bereitgestellt wird, das dem Objekt [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) zugeordnet ist.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte sind im nachfolgenden Beispiel implementiert.
```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
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

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den Shape‑Typ mit abgerundeten Ecken [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch pro Ecke über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchten haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/java/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in einen Button mit Hyperlink umwandeln?**

Ja. [Assign a hyperlink](/slides/de/java/manage-hyperlinks/) zur Form bei einem Klick (Sprung zu Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Use shape locks](/slides/de/java/applying-protection-to-presentation/): Sie können das Verschieben, Ändern der Größe, Auswählen oder Textbearbeiten verbieten, um das Layout zu bewahren.

**Kann ich ein Rechteck in ein Raster‑Bild oder SVG konvertieren?**

Ja. Sie können die Form [render the shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) zu einem Bild mit bestimmter Größe/Skalierung rendern oder sie als SVG [export it as SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Theme und Vererbung?**

[Use the shape’s effective properties](/slides/de/java/shape-effective-properties/): Die API gibt berechnete Werte zurück, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen und die Formatierungsanalyse vereinfachen.