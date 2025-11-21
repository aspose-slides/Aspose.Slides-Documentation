---
title: Ellipse
type: docs
weight: 30
url: /de/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 

In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für Node.js über Java vor. Aspose.Slides für Node.js über Java bietet einen einfacheren Satz von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen.

{{% /alert %}} 

## **Ellipse erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache Ellipse hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Ellipse hinzu, die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt wird.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt
```javascript
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Formatierte Ellipse erstellen**
Um einer Folie eine besser formatierte Ellipse hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Ellipse hinzu, die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse über die Eigenschaft SolidFillColor.Color, die vom Objekt [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) bereitgestellt wird und mit dem [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) Objekt verknüpft ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.
```javascript
// Instanziieren der Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Ellipse hinzufügen
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Einige Formatierungen auf die Ellipsenform anwenden
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Einige Formatierungen auf die Linie der Ellipse anwenden
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX-Datei auf die Festplatte schreiben
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse in Bezug auf die Einheiten der Folie fest?**

Koordinaten und Größen werden üblicherweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und die erforderlichen Millimeter oder Zoll vor der Zuweisung in Punkte umrechnen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhöhe steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne oder nach hinten verschieben. Dadurch kann die Ellipse andere Objekte überlagern oder diejenigen darunter sichtbar machen.

**Wie animiere ich das Auftreten oder die Hervorhebung einer Ellipse?**

[Apply](/slides/de/nodejs-java/shape-animation/) Eingangs-, Hervorhebungs- oder Ausgangseffekte auf die Form und konfigurieren Sie Trigger und Timing, um zu steuern, wann und wie die Animation abgespielt wird.