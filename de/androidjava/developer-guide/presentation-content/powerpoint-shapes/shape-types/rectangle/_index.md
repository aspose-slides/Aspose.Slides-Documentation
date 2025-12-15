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
description: "Steigern Sie Ihre PowerPoint-Präsentationen, indem Sie mit Aspose.Slides für Android via Java Rechtecke hinzufügen – gestalten und ändern Sie Formen einfach programmgesteuert."
---

{{% alert color="primary" %}} 

Wie bei vorherigen Themen geht es auch hier um das Hinzufügen einer Form und dieses Mal sprechen wir über **Rechteck**. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für Android via Java hinzufügen können.

{{% /alert %}} 

## **Ein Rechteck zu einer Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie über die Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ Rechteck hinzu, das vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```java
// Instanziieren Sie die Presentation‑Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Ellipsen‑Typ hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schreiben Sie die PPTX‑Datei auf die Festplatte
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ein formatiertes Rechteck zu einer Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie über die Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ Rechteck hinzu, das vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks über die Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) des Objekts [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat), das mit dem [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)-Objekt verknüpft ist.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte sind im nachfolgenden Beispiel umgesetzt.
```java
// Instanzieren Sie die Presentation‑Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Füge eine AutoShape vom Ellipsen‑Typ hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Wende einige Formatierungen auf die Ellipsenform an
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Wende einige Formatierungen auf die Linie der Ellipse an
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schreibe die PPTX‑Datei auf die Festplatte
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den Formtyp mit abgerundeten Ecken [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch pro Ecke über Geometrieanpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild-[fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchteffekte haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/androidjava/shape-effect/) sind verfügbar und können über Parameter angepasst werden.

**Kann ich ein Rechteck in einen Button mit Hyperlink verwandeln?**

Ja. [Assign a hyperlink](/slides/de/androidjava/manage-hyperlinks/) zur Form (Sprung zu Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Use shape locks](/slides/de/androidjava/applying-protection-to-presentation/): Sie können das Verschieben, Skalieren, Auswählen oder Bearbeiten von Text verbieten, um das Layout zu erhalten.

**Kann ich ein Rechteck in ein Rasterbild oder SVG konvertieren?**

Ja. Sie können die Form [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) zu einem Bild mit angegebener Größe/Skala rendern oder sie als SVG [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Design und Vererbung?**

[Use the shape’s effective properties](/slides/de/androidjava/shape-effective-properties/): Die API liefert berechnete Werte, die Design‑Stile, Layout und lokale Einstellungen berücksichtigen, was die Analyse der Formatierung vereinfacht.