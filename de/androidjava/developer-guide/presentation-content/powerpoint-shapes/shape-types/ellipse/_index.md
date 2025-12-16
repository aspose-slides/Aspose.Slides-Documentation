---
title: Ellipsen zu Präsentationen auf Android hinzufügen
linktitle: Ellipse
type: docs
weight: 30
url: /de/androidjava/ellipse/
keywords:
- Ellipse
- Form
- Ellipse hinzufügen
- Ellipse erstellen
- Ellipse zeichnen
- formatierte Ellipse
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für Android in PPT- und PPTX-Präsentationen erstellen, formatieren und manipulieren – Java-Codebeispiele enthalten."
---

{{% alert color="primary" %}} 
In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für Android via Java vor. Aspose.Slides für Android via Java bietet eine einfachere API, um verschiedene Formen mit nur wenigen Codezeilen zu zeichnen.
{{% /alert %}} 

## **Eine Ellipse erstellen**
Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie eine AutoShape vom Typ Ellipse hinzu, indem Sie die Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) verwenden, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt
```java
// Instanziieren der Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Erste Folie holen
    ISlide sld = pres.getSlides().get_Item(0);
    
    // AutoShape vom Typ Ellipse hinzufügen
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX-Datei auf die Festplatte schreiben
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie eine AutoShape vom Typ Ellipse hinzu, indem Sie die Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) verwenden, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse über die Eigenschaft SolidFillColor.Color, die vom Objekt [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) bereitgestellt wird, das dem Objekt [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) zugeordnet ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.
```java
// Instanziieren der Presentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Erste Folie holen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Ellipse hinzufügen
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Einige Formatierungen auf die Ellipsenform anwenden
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Einige Formatierungen auf die Linie der Ellipse anwenden
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX-Datei auf die Festplatte schreiben
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse relativ zu den Folieneinheiten fest?**

Koordinaten und Größen werden normalerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und die erforderlichen Millimeter oder Zoll in Punkte umrechnen, bevor Sie Werte zuweisen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhierarchie steuern)?**

Passen Sie die Zeichnungsreihenfolge des Objekts an, indem Sie es nach vorne bringen oder nach hinten senden. Dadurch kann die Ellipse andere Objekte überlappen oder die darunter liegenden sichtbar machen.

**Wie animiere ich das Auftreten oder die Hervorhebung einer Ellipse?**

[Anwenden](/slides/de/androidjava/shape-animation/) von Ein‑, Betonungs‑ oder Ausblendeffekten auf die Form, und konfigurieren Sie Trigger und Zeitsteuerungen, um zu bestimmen, wann und wie die Animation abgespielt wird.