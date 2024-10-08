---
title: Ellipse
type: docs
weight: 30
url: /de/java/ellipse/
---


{{% alert color="primary" %}} 

In diesem Thema werden wir Entwicklern erklären, wie man Ellipsenformen zu ihren Folien mit Aspose.Slides für Java hinzufügt. Aspose.Slides für Java bietet eine einfachere Reihe von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen.

{{% /alert %}} 

## **Ellipse erstellen**
Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
- Beschaffen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Ellipsentyp mit der [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.

```java
// Instanziieren Sie die Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape vom Ellipsentyp hinzu
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
- Beschaffen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Ellipsentyp mit der [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse mit der SolidFillColor.Color Eigenschaft, die vom [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) Objekt bereitgestellt wird, das mit dem [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) Objekt verbunden ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.

```java
// Instanziieren Sie die Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Ellipsentyp hinzu
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Wenden Sie einige Formatierungen auf die Ellipsenform an
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```