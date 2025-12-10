---
title: "Ellipsen zu Präsentationen in Java hinzufügen"
linktitle: "Ellipse"
type: docs
weight: 30
url: /de/java/ellipse/
keywords:
- "Ellipse"
- "Form"
- "Ellipse hinzufügen"
- "Ellipse erstellen"
- "Ellipse zeichnen"
- "formatierte Ellipse"
- "PowerPoint"
- "Präsentation"
- "Java"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für Java in PPT- und PPTX-Präsentationen erstellen, formatieren und manipulieren – Java-Codebeispiele sind enthalten."
---

{{% alert color="primary" %}} 

In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für Java vor. Aspose.Slides für Java bietet eine einfachere API, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen.

{{% /alert %}} 

## **Erstellen einer Ellipse**
Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir der ersten Folie eine Ellipse hinzugefügt
```java
// Instanziieren Sie die Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // AutoShape vom Ellipsentyp hinzufügen
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Erstellen einer formatierten Ellipse**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse über die Eigenschaft SolidFillColor.Color, die vom Objekt [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) bereitgestellt wird und mit dem Objekt [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) verknüpft ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir der ersten Folie der Präsentation eine formatierte Ellipse hinzugefügt.
```java
// Instanziieren Sie die Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Ellipsentyp hinzufügen
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Einige Formatierungen auf die Ellipsenform anwenden
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Einige Formatierungen auf die Linie der Ellipse anwenden
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse in Bezug auf die Einheit der Folie fest?**

Koordinaten und Größen werden typischerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und erforderliche Millimeter oder Zoll in Punkte umrechnen, bevor Sie Werte zuweisen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhierarchie steuern)?**

Passen Sie die Zeichnungsreihenfolge des Objekts an, indem Sie es nach vorne oder nach hinten verschieben. Damit kann die Ellipse andere Objekte überlappen oder solche darunter sichtbar machen.

**Wie animiere ich das Erscheinen oder die Betonung einer Ellipse?**

[Anwenden](/slides/de/java/shape-animation/) Eintritts-, Betonungs- oder Ausgangseffekte auf die Form anwenden und Trigger sowie Timing konfigurieren, um zu steuern, wann und wie die Animation abgespielt wird.