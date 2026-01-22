---
title: Linienformen zu Präsentationen in JavaScript hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/nodejs-java/line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit JavaScript und Aspose.Slides für Node.js manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir, mit Formen zu arbeiten, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides for Node.js via Java können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Create Plain Line**

Um eine einfache, gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse.
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Line über das [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection)-Objekt hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir einer Folie der Präsentation eine Linie hinzugefügt.
```javascript
// Instanziieren der PresentationEx-Klasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie erhalten
    var sld = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Linie hinzufügen
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // PPTX auf Festplatte schreiben
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Create Arrow Shaped Line**

Aspose.Slides for Node.js via Java ermöglicht es Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender aussieht. Versuchen wir, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Folgen Sie dazu den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse.
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Line über das [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection)-Objekt hinzu.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) auf einen der von Aspose.Slides for Node.js via Java angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides for Node.js via Java angebotenen Stile.
- Definieren Sie den [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Definieren Sie den [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.
```javascript
// Instanziieren der PresentationEx-Klasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie erhalten
    var sld = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Linie hinzufügen
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Formatierungen auf die Linie anwenden
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // PPTX auf Festplatte schreiben
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Verwenden Sie stattdessen den dedizierten [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)-Typ und die [entsprechenden APIs](/slides/de/nodejs-java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwer ist, die endgültigen Werte zu ermitteln?**

Lesen Sie die effektiven Eigenschaften über die Klassen `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` ([Read the effective properties](/slides/de/nodejs-java/shape-effective-properties/)) – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/), mit denen Sie Bearbeitungsvorgänge deaktivieren können.