---
title: Rechteck
type: docs
weight: 80
url: /de/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

Wie bei den vorherigen Themen geht es auch hier um das Hinzufügen einer Form und diesmal werden wir die Form **Rectangle** besprechen. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien hinzufügen können, indem sie Aspose.Slides für Node.js via Java verwenden.

{{% /alert %}} 

## **Add Rectangle to Slide**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) vom Typ Rectangle mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```javascript
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie ein AutoShape vom Ellipse-Typ hinzu
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Add Formatted Rectangle to Slide**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) vom Typ Rectangle mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt wird.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks mit der Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) , die vom Objekt [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) bereitgestellt wird und dem Objekt [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) zugeordnet ist.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte sind im nachfolgenden Beispiel implementiert.
```javascript
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie ein AutoShape vom Ellipse-Typ hinzu
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Wenden Sie einige Formatierungen auf die Ellipse-Form an
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**How do I add a rectangle with rounded corners?**

Verwenden Sie den abgerundeten [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; die Rundung kann auch pro Ecke über geometrische Anpassungen angewendet werden.

**How do I fill a rectangle with an image (texture)?**

Wählen Sie den Bild-[fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Can a rectangle have shadow and glow?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/nodejs-java/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Can I turn a rectangle into a button with a hyperlink?**

Ja. [Assign a hyperlink](/slides/de/nodejs-java/manage-hyperlinks/) wird dem Klick auf die Form zugewiesen (Navigation zu einer Folie, Datei, Webadresse oder E‑Mail).

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/de/nodejs-java/applying-protection-to-presentation/): Sie können das Verschieben, Skalieren, Auswählen oder Bearbeiten von Text verbieten, um das Layout zu erhalten.

**Can I convert a rectangle to a raster image or SVG?**

Ja. Sie können die Form [die Form rendern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) zu einem Bild mit einer angegebenen Größe/Skalierung rendern oder sie [sie als SVG exportieren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) für die Verwendung als Vektor exportieren.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/de/nodejs-java/shape-effective-properties/): Die API gibt berechnete Werte zurück, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen und die Analyse der Formatierung vereinfachen.