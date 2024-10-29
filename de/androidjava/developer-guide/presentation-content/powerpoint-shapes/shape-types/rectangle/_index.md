---
title: Rechteck
type: docs
weight: 80
url: /de/androidjava/rectangle/
---

{{% alert color="primary" %}} 

Wie bei den vorherigen Themen geht es auch hier um das Hinzufügen einer Form, und diesmal ist die Form, über die wir sprechen werden, **Rechteck**. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für Android über Java hinzufügen können.

{{% /alert %}} 

## **Rechteck zur Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie über ihren Index.
- Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) des Typs Rechteck über die [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formatiertes Rechteck zur Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie über ihren Index.
- Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) des Typs Rechteck über die [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Setzen Sie den [Fülltyp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks mit der Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) wie vom [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) Objekt bereitgestellt.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte sind im folgenden Beispiel implementiert.

```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Rechteckform an
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Wenden Sie einige Formatierungen auf die Linien des Rechtecks an
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```