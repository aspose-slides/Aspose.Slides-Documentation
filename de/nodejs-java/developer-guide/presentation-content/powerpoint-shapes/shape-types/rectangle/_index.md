---
title: Rechtecke zu Präsentationen in JavaScript hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/nodejs-java/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechteckform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Steigern Sie Ihre PowerPoint‑Präsentationen, indem Sie Rechtecke mit JavaScript und Aspose.Slides für Node.js hinzufügen – gestalten und ändern Sie Formen einfach programmatisch."
---

{{% alert color="primary" %}} 

Wie bei den vorherigen Themen geht es auch hier um das Hinzufügen einer Form, und diesmal besprechen wir die **Rechteck**‑Form. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien hinzufügen können, indem sie Aspose.Slides für Node.js via Java verwenden.

{{% /alert %}} 

## **Rechteck zur Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) vom Typ Rectangle hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```javascript
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Formatiertes Rechteck zur Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) vom Typ Rectangle hinzu.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks mit der Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) des [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat), das dem [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)-Objekt zugeordnet ist.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die oben genannten Schritte sind im nachstehenden Beispiel implementiert.
```javascript
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Wenden Sie einige Formatierungen auf die Ellipsenform an
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) für abgerundete Ecken und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch für jede Ecke einzeln über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchteffekte haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/nodejs-java/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in einen Button mit Hyperlink verwandeln?**

Ja. [Assign a hyperlink](/slides/de/nodejs-java/manage-hyperlinks/) zur Form bei einem Klick (Sprung zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor dem Verschieben und Änderungen schützen?**

Verwenden Sie Form‑Locks: Sie können das Verschieben, die Größenänderung, die Auswahl oder das Text‑Editing verbieten, um das Layout zu bewahren.

**Kann ich ein Rechteck in ein Rasterbild oder SVG konvertieren?**

Ja. Sie können die Form mit [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) zu einem Bild in einer angegebenen Größe/Skalierung rendern oder sie mit [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) als Vektorgrafik exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Design und Vererbung?**

[Use the shape’s effective properties](/slides/de/nodejs-java/shape-effective-properties/): Die API liefert berechnete Werte, die Design‑Stile, Layout und lokale Einstellungen berücksichtigen und so die Formatierungsanalyse vereinfachen.